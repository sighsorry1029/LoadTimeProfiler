using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
using HarmonyLib;

namespace LoadTimeProfiler;

// Tracks existing ConfigFile objects for the process lifetime. Startup write
// coalescing and our own immutable logging configuration have different owners.
internal static class ConfigAutoReload
{
    private const string Owner = LoadTimeProfilerPatcher.ModGUID + ".config-auto-reload";
    private static readonly object LifecycleLock = new();
    private static WatchService? _service;
    private static Harmony? _harmony;

    internal static void Install()
    {
        lock (LifecycleLock)
        {
            if (_service != null || HasStandaloneWatcher()) return;
            WatchService service = new(Runtime.Dispatch, LoadTimeProfilerPatcher.LogWarning,
                Path.Combine(Paths.ConfigPath, LoadTimeProfilerPatcher.ConfigFileName));
            Harmony harmony = new(Owner);
            try
            {
                _service = service;
                ConstructorInfo constructor = AccessTools.Constructor(typeof(ConfigFile),
                    new[] { typeof(string), typeof(bool), typeof(BepInPlugin) })
                    ?? throw new MissingMethodException("ConfigFile constructor");
                harmony.Patch(constructor, postfix: new HarmonyMethod(typeof(ConfigAutoReload), nameof(Constructed)));
                _harmony = harmony;
            }
            catch
            {
                _service = null;
                service.Dispose();
                harmony.UnpatchSelf();
                throw;
            }
        }
    }

    private static void Constructed(ConfigFile __instance)
    {
        try { Volatile.Read(ref _service)?.Track(__instance); }
        catch (Exception ex) { LoadTimeProfilerPatcher.LogWarning("Could not track config for reload: " + ex.Message); }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void Start()
    {
        if (Volatile.Read(ref _service) == null) return;
        if (HasStandaloneWatcher()) { Dispose(); return; }
        try { Runtime.Start(); }
        catch (Exception ex)
        {
            Dispose();
            LoadTimeProfilerPatcher.LogWarning("Config auto reload could not start: " + ex.Message);
        }
    }

    // Keep Unity types out of preloader initialization and constructor patching.
    private static class Runtime
    {
        internal static void Dispatch(Action action) => ThreadingHelper.Instance.StartSyncInvoke(action);

        internal static void Start()
        {
            WatchService? service = Volatile.Read(ref _service);
            if (service == null) return;
            if (ThreadingHelper.Instance == null)
                throw new InvalidOperationException("BepInEx main-thread dispatcher is unavailable.");
            // Reconcile defaults that may have been constructed before our hook.
            foreach (PluginInfo plugin in Chainloader.PluginInfos.Values)
                if (plugin.Instance != null) service.Track(plugin.Instance.Config);
            service.Start();
        }
    }

    private static bool HasStandaloneWatcher()
    {
        bool found = Harmony.HasAnyPatches("org.bepinex.patchers.configwatcher");
        if (!found)
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                if (string.Equals(assembly.GetName().Name, "ConfigWatcher", StringComparison.OrdinalIgnoreCase))
                { found = true; break; }
        if (found)
            LoadTimeProfilerPatcher.LogWarning("Config auto reload is inactive because standalone ConfigWatcher is loaded. " +
                "Remove it and restart to use LoadTimeProfiler's watcher. Other features remain active.");
        return found;
    }

    internal static void Dispose()
    {
        lock (LifecycleLock)
        {
            Interlocked.Exchange(ref _service, null)?.Dispose();
            Harmony? harmony = _harmony;
            _harmony = null;
            if (harmony != null)
                try { harmony.UnpatchSelf(); }
                catch (Exception ex) { LoadTimeProfilerPatcher.LogWarning("Config tracking cleanup failed: " + ex.Message); }
        }
    }

    // The dispatcher is supplied by the runtime boundary; this service itself
    // never calls Unity. Only changed registered paths are read after startup.
    internal sealed class WatchService : IDisposable
    {
        private const int PollMilliseconds = 250;
        private const int SettleMilliseconds = 500;
        private static readonly StringComparer PathComparer = Path.DirectorySeparatorChar == '\\'
            ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal;
        private readonly object _gate = new();
        private readonly Dictionary<string, WatchedFile> _files = new(PathComparer);
        private readonly Dictionary<string, FileSystemWatcher> _watchers = new(PathComparer);
        private readonly HashSet<WatchedFile> _pending = new();
        private readonly Action<Action> _dispatch;
        private readonly Action<string> _warning;
        private readonly string _excludedPath;
        private readonly Timer _timer;
        private bool _started;
        private bool _disposed;
        private bool _ticking;
        private int _pollBusy;

        internal WatchService(Action<Action> dispatch, Action<string> warning, string excludedPath)
        {
            _dispatch = dispatch ?? throw new ArgumentNullException(nameof(dispatch));
            _warning = warning ?? throw new ArgumentNullException(nameof(warning));
            _excludedPath = Path.GetFullPath(excludedPath);
            _timer = new Timer(Poll, null, Timeout.Infinite, Timeout.Infinite);
        }

        internal void Track(ConfigFile config)
        {
            string path = Path.GetFullPath(config.ConfigFilePath);
            if (PathComparer.Equals(path, _excludedPath) ||
                !string.Equals(Path.GetExtension(path), ".cfg", StringComparison.OrdinalIgnoreCase)) return;
            lock (_gate)
            {
                if (_disposed) return;
                if (!_files.TryGetValue(path, out WatchedFile? file))
                {
                    file = new WatchedFile(path);
                    _files.Add(path, file);
                    if (_started) { CaptureBaseline(file); BeginWatching(file); }
                }
                for (int i = file.Configs.Count - 1; i >= 0; i--)
                {
                    if (!file.Configs[i].Reference.TryGetTarget(out ConfigFile target)) file.Configs.RemoveAt(i);
                    else if (ReferenceEquals(target, config)) return;
                }
                file.Configs.Add(new WatchedConfig(config, file.Applied));
            }
        }

        internal void Start()
        {
            lock (_gate)
            {
                if (_disposed || _started) return;
                _started = true;
                // Startup writes have finished. Capture every baseline before
                // enabling any directory watcher, then recheck the setup gap.
                foreach (WatchedFile file in _files.Values) CaptureBaseline(file);
                foreach (WatchedFile file in _files.Values) BeginWatching(file);
            }
        }

        private void CaptureBaseline(WatchedFile file)
        {
            try
            {
                file.Applied = Fingerprint(file.Path);
            }
            // Plugins with no bound settings normally have no cfg file yet.
            catch (FileNotFoundException) { file.Applied = null; }
            catch (DirectoryNotFoundException) { file.Applied = null; }
            catch (Exception ex) { Warn(file, ex); }
            foreach (WatchedConfig config in file.Configs) config.Applied = file.Applied;
        }

        private void BeginWatching(WatchedFile file)
        {
            try { EnsureWatcher(file.Directory); }
            catch (Exception ex) { Warn(file, ex); }
            // Check once after installing the watcher to close the baseline gap.
            Dirty(file);
        }

        private void EnsureWatcher(string directory)
        {
            if (_watchers.ContainsKey(directory) || !Directory.Exists(directory)) return;
            FileSystemWatcher watcher = new(directory)
            {
                IncludeSubdirectories = false,
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.Size
            };
            watcher.Changed += FileChanged;
            watcher.Created += FileChanged;
            watcher.Deleted += FileChanged;
            watcher.Renamed += FileRenamed;
            watcher.Error += WatcherError;
            try
            {
                watcher.EnableRaisingEvents = true;
                _watchers.Add(directory, watcher);
            }
            catch { ReleaseWatcher(watcher); throw; }
        }

        private void FileChanged(object sender, FileSystemEventArgs args)
        {
            lock (_gate)
                if (!_disposed && _files.TryGetValue(args.FullPath, out WatchedFile? file)) Dirty(file);
        }

        private void FileRenamed(object sender, RenamedEventArgs args)
        {
            lock (_gate)
            {
                if (_disposed) return;
                if (_files.TryGetValue(args.OldFullPath, out WatchedFile? old)) Dirty(old);
                if (_files.TryGetValue(args.FullPath, out WatchedFile? current)) Dirty(current);
            }
        }

        private void WatcherError(object sender, ErrorEventArgs args)
        {
            lock (_gate)
            {
                if (_disposed) return;
                string directory = ((FileSystemWatcher)sender).Path;
                if (!_watchers.TryGetValue(directory, out FileSystemWatcher? current) ||
                    !ReferenceEquals(current, sender)) return;
                Report("Config watcher will recheck registered files after a filesystem error: " + args.GetException().Message);
                _watchers.Remove(directory);
                ReleaseWatcher((FileSystemWatcher)sender);
                foreach (WatchedFile file in _files.Values)
                    if (PathComparer.Equals(file.Directory, directory)) Dirty(file);
            }
        }

        // All state mutations happen under _gate. No callbacks into a mod do.
        private void Dirty(WatchedFile file)
        {
            file.Generation++;
            file.Candidate = null;
            file.Due = Now + SettleMilliseconds;
            _pending.Add(file);
            if (!_ticking)
            {
                _ticking = true;
                _timer.Change(PollMilliseconds, PollMilliseconds);
            }
        }

        private static long Now => (long)(Stopwatch.GetTimestamp() * (1000d / Stopwatch.Frequency));

        private void Poll(object? state)
        {
            if (Interlocked.Exchange(ref _pollBusy, 1) != 0) return;
            try
            {
                WatchedFile[] pending;
                lock (_gate)
                {
                    if (_disposed) return;
                    pending = new WatchedFile[_pending.Count];
                    _pending.CopyTo(pending);
                }
                foreach (WatchedFile file in pending) CheckFile(file);
            }
            catch (Exception ex) { Report("Config watcher check failed: " + ex.Message); }
            finally { Volatile.Write(ref _pollBusy, 0); }
        }

        private void CheckFile(WatchedFile file)
        {
            long generation;
            lock (_gate)
            {
                if (_disposed || !_pending.Contains(file) || file.Queued || file.Due > Now) return;
                if (!Prune(file)) { RemoveFile(file); return; }
                generation = file.Generation;
            }
            try
            {
                lock (_gate)
                {
                    if (_disposed) return;
                    EnsureWatcher(file.Directory);
                }
                byte[] fingerprint = Fingerprint(file.Path);
                lock (_gate)
                {
                    if (_disposed || file.Generation != generation) return;
                    if (AllApplied(file, fingerprint)) { Complete(file, fingerprint); return; }
                    if (!Equal(fingerprint, file.Candidate))
                    {
                        file.Candidate = fingerprint;
                        file.Due = Now + PollMilliseconds;
                        return;
                    }
                    file.Queued = true;
                }
                _dispatch(() => Reload(file, generation, fingerprint));
            }
            catch (FileNotFoundException) { Missing(file, generation); }
            catch (DirectoryNotFoundException) { Missing(file, generation); }
            catch (Exception ex) { Retry(file, ex); }
        }

        private void Reload(WatchedFile file, long generation, byte[] expected)
        {
            List<KeyValuePair<ConfigFile, WatchedConfig>> configs = new();
            lock (_gate)
            {
                file.Queued = false;
                if (_disposed || file.Generation != generation || !_pending.Contains(file)) return;
                foreach (WatchedConfig config in file.Configs)
                    if (config.Reference.TryGetTarget(out ConfigFile target) && !Equal(config.Applied, expected))
                        configs.Add(new KeyValuePair<ConfigFile, WatchedConfig>(target, config));
            }
            try
            {
                if (!Equal(expected, Fingerprint(file.Path)))
                {
                    lock (_gate) if (!_disposed) Dirty(file);
                    return;
                }
                Exception? failure = null;
                foreach (KeyValuePair<ConfigFile, WatchedConfig> tracked in configs)
                {
                    lock (_gate) if (_disposed) return;
                    ConfigFile config = tracked.Key;
                    bool saveOnConfigSet = config.SaveOnConfigSet;
                    try
                    {
                        config.SaveOnConfigSet = false;
                        config.Reload();
                        lock (_gate) tracked.Value.Applied = expected;
                    }
                    catch (Exception ex)
                    {
                        lock (_gate) tracked.Value.Applied = null;
                        failure = ex;
                    }
                    finally { config.SaveOnConfigSet = saveOnConfigSet; }
                }
                if (failure != null) { Retry(file, failure); return; }
                lock (_gate)
                    if (!_disposed && file.Generation == generation) Complete(file, expected);
            }
            catch (FileNotFoundException) { Missing(file, generation); }
            catch (DirectoryNotFoundException) { Missing(file, generation); }
            catch (Exception ex) { Retry(file, ex); }
        }

        private void Missing(WatchedFile file, long generation)
        {
            lock (_gate)
            {
                if (_disposed || file.Generation != generation) return;
                file.Queued = false;
                file.Applied = null;
                foreach (WatchedConfig config in file.Configs) config.Applied = null;
                // A not-yet-created directory needs a retry until it can be watched.
                if (!_watchers.ContainsKey(file.Directory)) file.Due = Now + 5000;
                else { _pending.Remove(file); StopIdleTimer(); }
            }
        }

        private void Retry(WatchedFile file, Exception exception)
        {
            lock (_gate)
            {
                if (_disposed) return;
                file.Queued = false;
                file.Candidate = null;
                file.Due = Now + 1000;
                Warn(file, exception);
            }
        }

        private void Complete(WatchedFile file, byte[] fingerprint)
        {
            file.Applied = fingerprint;
            file.LastError = null;
            file.Candidate = null;
            file.Queued = false;
            _pending.Remove(file);
            StopIdleTimer();
        }

        private static bool Prune(WatchedFile file)
        {
            for (int i = file.Configs.Count - 1; i >= 0; i--)
                if (!file.Configs[i].Reference.TryGetTarget(out _)) file.Configs.RemoveAt(i);
            return file.Configs.Count != 0;
        }

        private static bool AllApplied(WatchedFile file, byte[] fingerprint)
        {
            foreach (WatchedConfig config in file.Configs)
                if (config.Reference.TryGetTarget(out _) && !Equal(config.Applied, fingerprint)) return false;
            return true;
        }

        private void RemoveFile(WatchedFile file)
        {
            _files.Remove(file.Path);
            _pending.Remove(file);
            bool needed = false;
            foreach (WatchedFile other in _files.Values)
                if (PathComparer.Equals(other.Directory, file.Directory)) { needed = true; break; }
            if (!needed && _watchers.TryGetValue(file.Directory, out FileSystemWatcher? watcher))
            { _watchers.Remove(file.Directory); ReleaseWatcher(watcher); }
            StopIdleTimer();
        }

        private void StopIdleTimer()
        {
            if (_pending.Count != 0 || !_ticking) return;
            _ticking = false;
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        private static byte[] Fingerprint(string path)
        {
            using FileStream stream = new(path, FileMode.Open, FileAccess.Read, FileShare.Read | FileShare.Delete);
            using SHA256 hash = SHA256.Create();
            return hash.ComputeHash(stream);
        }

        private static bool Equal(byte[]? left, byte[]? right)
        {
            if (left == null || right == null || left.Length != right.Length) return false;
            for (int i = 0; i < left.Length; i++) if (left[i] != right[i]) return false;
            return true;
        }

        private void Warn(WatchedFile file, Exception exception)
        {
            string message = exception.Message;
            if (file.LastError == message) return;
            file.LastError = message;
            Report("Could not reload " + file.Path + "; will retry: " + message);
        }

        private void Report(string message)
        {
            try { _warning(message); }
            catch { } // Diagnostics must not terminate a filesystem callback.
        }

        private void ReleaseWatcher(FileSystemWatcher watcher)
        {
            watcher.Changed -= FileChanged;
            watcher.Created -= FileChanged;
            watcher.Deleted -= FileChanged;
            watcher.Renamed -= FileRenamed;
            watcher.Error -= WatcherError;
            watcher.Dispose();
        }

        public void Dispose()
        {
            lock (_gate)
            {
                if (_disposed) return;
                _disposed = true;
                _timer.Dispose();
                foreach (FileSystemWatcher watcher in _watchers.Values) ReleaseWatcher(watcher);
                _watchers.Clear();
                _files.Clear();
                _pending.Clear();
            }
        }

        private sealed class WatchedFile
        {
            internal WatchedFile(string path) { Path = path; Directory = System.IO.Path.GetDirectoryName(path)!; }
            internal readonly string Path;
            internal readonly string Directory;
            internal readonly List<WatchedConfig> Configs = new();
            internal byte[]? Applied;
            internal byte[]? Candidate;
            internal string? LastError;
            internal long Generation;
            internal long Due;
            internal bool Queued;
        }

        private sealed class WatchedConfig
        {
            internal WatchedConfig(ConfigFile config, byte[]? applied)
            { Reference = new WeakReference<ConfigFile>(config); Applied = applied; }
            internal readonly WeakReference<ConfigFile> Reference;
            internal byte[]? Applied;
        }
    }
}
