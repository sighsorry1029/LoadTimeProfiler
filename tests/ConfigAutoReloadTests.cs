using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using BepInEx.Configuration;
using HarmonyLib;

// Real product, ConfigFile and filesystem events. Only the main-thread dispatcher
// is substituted; all queued reloads are explicitly drained on this test thread.
internal static class ConfigAutoReloadTests
{
    private const BindingFlags Any = BindingFlags.Public | BindingFlags.NonPublic |
                                     BindingFlags.Instance | BindingFlags.Static;
    private static Assembly product;
    private static string scratch;
    private static int cases;
    private static int failures;
    private static object throwingFile;
    private static int injectedReloads;
    private static bool autosaveAtInjectedFailure;

    private static int Main(string[] args)
    {
        if (args.Length != 4) return 2;
        AppDomain.CurrentDomain.AssemblyResolve += (_, request) =>
        {
            foreach (string directory in new[] { args[1], args[2] })
            {
                string path = Path.Combine(directory, new AssemblyName(request.Name).Name + ".dll");
                if (File.Exists(path)) return Assembly.LoadFrom(path);
            }
            return null;
        };
        product = Assembly.LoadFrom(args[0]);
        scratch = args[3];
        Run("tracked startup files establish a baseline without reload", StartupBaseline);
        Run("filesystem changes dispatch setting and reload events on the owner thread", MainThreadDispatch);
        Run("a new save invalidates an older queued reload until the bytes settle", QueuedSaveChanges);
        Run("burst writes apply the final complete file once", BurstWrites);
        Run("identical saved bytes do not emit another ConfigReloaded", UnchangedBytes);
        Run("replacement saves reload the registered object", ReplacementSave);
        Run("deletion retains values and recreation resumes watching", DeleteAndRecreate);
        Run("initially absent cfg files and directories stay quiet and reload when created", MissingInitialPaths);
        Run("only registered cfg files are watched and the LTP file is excluded", RegisteredFilesOnly);
        Run("distinct ConfigFile objects sharing one path all reload", SharedPathObjects);
        Run("two registered files in one directory retain independent settings", SharedDirectory);
        Run("Reload suppresses automatic saves and restores both original flag states", SaveFlagAndBytes);
        Run("a thrown Reload restores SaveOnConfigSet and later edits recover", ReloadFailureRecovery);
        Run("restoring baseline bytes reverts a sibling after another object failed", RevertAfterSiblingFailure);
        Run("a throwing mod callback does not stop another registered config", CallbackFailureIsolation);
        Run("the watcher does not retain dead ConfigFile objects", WeakLifetime);
        Run("disposal invalidates queued work and stops new work", DisposeQueuedWork);
        Run("a temporarily locked cfg reloads once it becomes readable", LockedFileRecovery);
        Run("ordinary BepInEx per-entry validation is preserved", PartialValueValidation);
        Run("repeated Track and Start do not duplicate reload events", DuplicateRegistration);
        Run("a delayed error from a replaced watcher cannot remove its successor", DelayedWatcherError);
        Run("standalone ConfigWatcher ownership disables only LTP auto reload", StandaloneWatcherConflict);
        Console.WriteLine(failures == 0 ? "All " + cases + " config auto-reload cases passed." : failures + " config auto-reload case(s) failed.");
        Console.WriteLine("Not tested here: native Unity dispatch, dedicated servers, ServerSync transport, arbitrary foreign watcher behavior, or config callbacks that require restart.");
        return failures == 0 ? 0 : 1;
    }

    private static void Run(string name, Action action)
    {
        cases++;
        try { action(); Console.WriteLine("PASS " + name); }
        catch (Exception ex) { failures++; Console.WriteLine("FAIL " + name + ": " + ex.GetBaseException()); }
    }
    private static void Check(bool condition, string reason)
    {
        if (!condition) throw new InvalidOperationException(reason);
    }
    private static string Document(int value, int other = 2) =>
        "# Preserve this comment and formatting.\r\n[Live]\r\nNumber = " + value + "\r\nOther = " + other + "\r\n";
    private static void Write(string path, int value, int other = 2) =>
        File.WriteAllText(path, Document(value, other), new UTF8Encoding(false));
    private static void Eventually(Scope scope, Func<bool> ready, string reason, bool pump = true)
    {
        Stopwatch timer = Stopwatch.StartNew();
        do
        {
            if (pump) scope.Pump();
            if (ready()) return;
            Thread.Sleep(20);
        } while (timer.ElapsedMilliseconds < 6500);
        if (pump) scope.Pump();
        Check(ready(), reason);
    }
    private static void Settle(Scope scope, int milliseconds = 1600)
    {
        Stopwatch timer = Stopwatch.StartNew();
        do { scope.Pump(); Thread.Sleep(20); } while (timer.ElapsedMilliseconds < milliseconds);
        scope.Pump();
    }

    private sealed class Fixture
    {
        internal readonly string Path;
        internal readonly ConfigFile File;
        internal readonly ConfigEntry<int> Number;
        internal readonly ConfigEntry<int> Other;
        internal int Reloads;
        internal readonly List<int> ChangedValues = new List<int>();
        internal Fixture(string path, bool write = true)
        {
            Path = path;
            if (write) Write(path, 1);
            File = new ConfigFile(path, false) { SaveOnConfigSet = false };
            Number = File.Bind("Live", "Number", 1);
            Other = File.Bind("Live", "Other", 2);
            File.ConfigReloaded += (_, __) => Reloads++;
            Number.SettingChanged += (_, __) => ChangedValues.Add(Number.Value);
        }
    }

    private sealed class Scope : IDisposable
    {
        internal readonly string Directory;
        internal readonly string Excluded;
        internal readonly ConcurrentQueue<Action> Queue = new ConcurrentQueue<Action>();
        internal readonly ConcurrentQueue<string> Warnings = new ConcurrentQueue<string>();
        internal readonly int OwnerThread = Thread.CurrentThread.ManagedThreadId;
        private readonly object service;
        internal Scope(bool start = true)
        {
            Directory = System.IO.Path.Combine(scratch, "case-" + cases + "-" + Guid.NewGuid().ToString("N"));
            System.IO.Directory.CreateDirectory(Directory);
            Excluded = System.IO.Path.Combine(Directory, "sighsorry.LoadTimeProfiler.cfg");
            Type type = product.GetType("LoadTimeProfiler.ConfigAutoReload+WatchService", true);
            service = Activator.CreateInstance(type, Any, null,
                new object[] { new Action<Action>(Queue.Enqueue), new Action<string>(Warnings.Enqueue), Excluded }, null);
            if (start) Start();
        }
        internal Fixture Config(string name = "mod.cfg") => new Fixture(System.IO.Path.Combine(Directory, name));
        internal void Track(ConfigFile file) => Call("Track", file);
        internal void Start() => Call("Start");
        internal FileSystemWatcher Watcher
        {
            get
            {
                object gate = service.GetType().GetField("_gate", Any).GetValue(service);
                lock (gate)
                {
                    var watchers = (IDictionary)service.GetType().GetField("_watchers", Any).GetValue(service);
                    return (FileSystemWatcher)watchers[Directory];
                }
            }
        }
        internal void WatcherError(FileSystemWatcher watcher) =>
            Call("WatcherError", watcher, new ErrorEventArgs(new InternalBufferOverflowException("Injected watcher overflow.")));
        private void Call(string name, params object[] arguments) =>
            service.GetType().GetMethod(name, Any).Invoke(service, arguments);
        internal void Pump()
        {
            Check(Thread.CurrentThread.ManagedThreadId == OwnerThread, "Dispatcher drained from the wrong thread.");
            int count = 0;
            Action action;
            while (Queue.TryDequeue(out action))
            {
                Check(++count < 1000, "Dispatcher keeps requeuing immediate work.");
                action();
            }
        }
        public void Dispose() => ((IDisposable)service).Dispose();
    }

    private static void StartupBaseline()
    {
        using (var scope = new Scope(false))
        {
            Fixture fixture = scope.Config();
            scope.Track(fixture.File);
            scope.Start();
            Settle(scope);
            Check(fixture.Reloads == 0 && fixture.Number.Value == 1, "Starting the watcher reloaded an unchanged file.");
            Write(fixture.Path, 9);
            Eventually(scope, () => fixture.Number.Value == 9, "The pre-start registered file did not reload.");
        }
    }

    private static void MainThreadDispatch()
    {
        using (var scope = new Scope())
        {
            Fixture fixture = scope.Config();
            var callbackThreads = new List<int>();
            fixture.Number.SettingChanged += (_, __) => callbackThreads.Add(Thread.CurrentThread.ManagedThreadId);
            fixture.File.ConfigReloaded += (_, __) => callbackThreads.Add(Thread.CurrentThread.ManagedThreadId);
            scope.Track(fixture.File);
            Write(fixture.Path, 9);
            Eventually(scope, () => !scope.Queue.IsEmpty, "No main-thread reload was dispatched.", false);
            Check(fixture.Number.Value == 1 && callbackThreads.Count == 0, "Background work changed a live setting before main-thread dispatch.");
            Eventually(scope, () => fixture.Number.Value == 9 && fixture.Reloads == 1, "The queued work did not update the live ConfigEntry.");
            Check(callbackThreads.Count == 2 && callbackThreads.TrueForAll(id => id == scope.OwnerThread), "Config events did not run on the dispatch owner thread.");
        }
    }

    private static void BurstWrites()
    {
        using (var scope = new Scope())
        {
            Fixture fixture = scope.Config();
            scope.Track(fixture.File);
            Write(fixture.Path, 3);
            Thread.Sleep(50);
            Write(fixture.Path, 5);
            Thread.Sleep(50);
            Write(fixture.Path, 9, 12);
            Eventually(scope, () => fixture.Number.Value == 9 && fixture.Other.Value == 12, "The final saved settings did not reload.");
            Settle(scope);
            Check(fixture.Reloads == 1 && fixture.ChangedValues.Count == 1 && fixture.ChangedValues[0] == 9,
                "One save burst produced duplicate or intermediate setting changes.");
        }
    }

    private static void QueuedSaveChanges()
    {
        using (var scope = new Scope())
        {
            Fixture fixture = scope.Config();
            scope.Track(fixture.File);
            Write(fixture.Path, 9);
            Eventually(scope, () => !scope.Queue.IsEmpty, "No first reload was queued.", false);
            Write(fixture.Path, 11);
            scope.Pump();
            Check(fixture.Number.Value == 1 && fixture.Reloads == 0,
                "A stale queued action bypassed stabilization and loaded a newer save immediately.");
            Eventually(scope, () => fixture.Number.Value == 11 && fixture.Reloads == 1,
                "The replacement contents did not reload after stabilization.");
        }
    }

    private static void UnchangedBytes()
    {
        using (var scope = new Scope())
        {
            Fixture fixture = scope.Config();
            scope.Track(fixture.File);
            Write(fixture.Path, 8);
            Eventually(scope, () => fixture.Reloads == 1, "The initial changed file did not reload.");
            Write(fixture.Path, 8);
            Settle(scope);
            Check(fixture.Reloads == 1, "Rewriting identical bytes emitted a second ConfigReloaded.");
        }
    }

    private static void ReplacementSave()
    {
        using (var scope = new Scope())
        {
            Fixture fixture = scope.Config();
            scope.Track(fixture.File);
            string replacement = fixture.Path + ".replacement";
            Write(replacement, 15);
            Eventually(scope, () =>
            {
                try { File.Replace(replacement, fixture.Path, null); return true; }
                catch (IOException) { return false; }
            }, "The test editor could not complete its replacement save within the deadline.");
            Eventually(scope, () => fixture.Number.Value == 15, "A replacement save was not detected.");
        }
    }

    private static void DeleteAndRecreate()
    {
        using (var scope = new Scope())
        {
            Fixture fixture = scope.Config();
            scope.Track(fixture.File);
            File.Delete(fixture.Path);
            Settle(scope);
            Check(fixture.Reloads == 0 && fixture.Number.Value == 1, "Deleting the file reset or reloaded live settings.");
            Write(fixture.Path, 17);
            Eventually(scope, () => fixture.Number.Value == 17, "Recreating the file did not resume reloads.");
        }
    }

    private static void RegisteredFilesOnly()
    {
        using (var scope = new Scope())
        {
            Fixture registered = scope.Config("registered.cfg");
            Fixture unknown = scope.Config("unknown.cfg");
            Fixture otherFormat = scope.Config("other.json");
            Fixture excluded = new Fixture(scope.Excluded);
            scope.Track(registered.File);
            scope.Track(otherFormat.File);
            scope.Track(excluded.File);
            Write(unknown.Path, 3);
            Write(otherFormat.Path, 5);
            Write(excluded.Path, 7);
            Settle(scope);
            Check(unknown.Number.Value == 1 && otherFormat.Number.Value == 1 && excluded.Number.Value == 1,
                "An unregistered, non-cfg, or LTP configuration was reloaded.");
            Check(registered.Reloads == 0, "Unrelated saves reloaded a registered file.");
            Write(registered.Path, 9);
            Eventually(scope, () => registered.Number.Value == 9, "Ignored paths disabled the valid registered file.");
        }
    }

    private static void MissingInitialPaths()
    {
        foreach (bool nested in new[] { false, true })
        using (var scope = new Scope())
        {
            string directory = nested ? System.IO.Path.Combine(scope.Directory, "not-created-yet") : scope.Directory;
            string path = System.IO.Path.Combine(directory, "not-created-yet.cfg");
            var fixture = new Fixture(path, false);
            scope.Track(fixture.File);
            Settle(scope);
            Check(!File.Exists(path) && fixture.Number.Value == 1 && fixture.Reloads == 0,
                "Registering an absent config created or reloaded it before its owner saved anything.");
            Check(scope.Warnings.IsEmpty, "A normal not-yet-created cfg or directory produced a warning.");
            System.IO.Directory.CreateDirectory(directory);
            Write(path, 89);
            Eventually(scope, () => fixture.Number.Value == 89 && fixture.Reloads == 1,
                "The initially absent cfg did not reload after its directory and file were created.");
        }
    }

    private static void SharedPathObjects()
    {
        using (var scope = new Scope())
        {
            Fixture first = scope.Config();
            Fixture second = new Fixture(first.Path, false);
            scope.Track(first.File);
            scope.Track(second.File);
            Write(first.Path, 23);
            Eventually(scope, () => first.Number.Value == 23 && second.Number.Value == 23, "Not every live object for the same file was reloaded.");
            Check(first.Reloads == 1 && second.Reloads == 1, "One shared-path object was reloaded more than once.");
        }
    }

    private static void SharedDirectory()
    {
        using (var scope = new Scope())
        {
            Fixture first = scope.Config("first.cfg");
            Fixture second = scope.Config("second.cfg");
            scope.Track(first.File);
            scope.Track(second.File);
            Write(first.Path, 29);
            Eventually(scope, () => first.Number.Value == 29, "The first registered path did not reload.");
            Check(second.Number.Value == 1 && second.Reloads == 0, "The directory watcher reloaded an unchanged neighboring file.");
            Write(second.Path, 31);
            Eventually(scope, () => second.Number.Value == 31, "The second registered path did not reload independently.");
            Check(first.Reloads == 1, "A neighboring path caused another reload of the first file.");
        }
    }

    private static void SaveFlagAndBytes()
    {
        foreach (bool autosave in new[] { false, true })
        using (var scope = new Scope())
        {
            Fixture fixture = scope.Config();
            fixture.File.SaveOnConfigSet = autosave;
            var callbackFlags = new List<bool>();
            fixture.Number.SettingChanged += (_, __) => callbackFlags.Add(fixture.File.SaveOnConfigSet);
            fixture.File.ConfigReloaded += (_, __) => callbackFlags.Add(fixture.File.SaveOnConfigSet);
            scope.Track(fixture.File);
            Write(fixture.Path, 37);
            byte[] expected = File.ReadAllBytes(fixture.Path);
            Eventually(scope, () => fixture.Reloads == 1, "The auto-save fixture did not reload.");
            Check(callbackFlags.Count == 2 && callbackFlags.TrueForAll(flag => !flag), "Automatic save stayed enabled during a reload callback.");
            Check(fixture.File.SaveOnConfigSet == autosave, "The original SaveOnConfigSet was not restored.");
            Check(Convert.ToBase64String(expected) == Convert.ToBase64String(File.ReadAllBytes(fixture.Path)), "Reload rewrote comments or formatting.");
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void ThrowReloadPrefix(ConfigFile __instance)
    {
        if (!ReferenceEquals(__instance, throwingFile)) return;
        Interlocked.Increment(ref injectedReloads);
        autosaveAtInjectedFailure = __instance.SaveOnConfigSet;
        throw new IOException("Injected foreign Reload failure.");
    }

    private static void ReloadFailureRecovery()
    {
        var harmony = new Harmony("ltp.tests.autoreload.foreign-failure");
        MethodInfo original = typeof(ConfigFile).GetMethod("Reload", Any);
        MethodInfo prefix = typeof(ConfigAutoReloadTests).GetMethod("ThrowReloadPrefix", Any);
        harmony.Patch(original, prefix: new HarmonyMethod(prefix));
        try
        {
            using (var scope = new Scope())
            {
                Fixture fixture = scope.Config();
                Fixture healthy = new Fixture(fixture.Path, false);
                fixture.File.SaveOnConfigSet = true;
                scope.Track(fixture.File);
                scope.Track(healthy.File);
                throwingFile = fixture.File;
                injectedReloads = 0;
                autosaveAtInjectedFailure = true;
                Write(fixture.Path, 41);
                Eventually(scope, () => injectedReloads > 0, "The injected Reload failure was not reached.");
                Check(!autosaveAtInjectedFailure && fixture.File.SaveOnConfigSet, "A thrown Reload did not suppress then restore automatic saves.");
                Check(fixture.Number.Value == 1 && !scope.Warnings.IsEmpty, "The reload failure was not isolated and reported.");
                Check(healthy.Number.Value == 41 && healthy.Reloads == 1,
                    "One failing object blocked another live ConfigFile for the same path.");
                Eventually(scope, () => injectedReloads >= 2, "The failed ConfigFile was not retried.");
                Check(healthy.Reloads == 1, "Retrying one failed object repeated a healthy sibling's callback.");
                Check(scope.Warnings.Count == 1, "The same persistent Reload failure emitted repeated warnings.");
                throwingFile = null;
                Write(fixture.Path, 43);
                Eventually(scope, () => fixture.Number.Value == 43, "A later edit did not recover after Reload threw.");
                Check(healthy.Number.Value == 43 && healthy.Reloads == 2,
                    "The healthy sibling did not apply the next distinct save exactly once.");
            }
            Check(Harmony.GetPatchInfo(original).Owners.Contains(harmony.Id), "The service removed the foreign Reload patch.");
        }
        finally
        {
            throwingFile = null;
            harmony.Unpatch(original, prefix);
        }
    }

    private static void CallbackFailureIsolation()
    {
        using (var scope = new Scope())
        {
            Fixture first = scope.Config("throwing.cfg");
            Fixture second = scope.Config("healthy.cfg");
            first.Number.SettingChanged += (_, __) => { throw new InvalidOperationException("Deliberately failing mod callback."); };
            scope.Track(first.File);
            scope.Track(second.File);
            Write(first.Path, 47);
            Write(second.Path, 53);
            Eventually(scope, () => first.Number.Value == 47 && second.Number.Value == 53,
                "One mod callback prevented another registered configuration from reloading.");
            Check(first.Reloads == 1 && second.Reloads == 1, "A callback failure duplicated or skipped a ConfigReloaded event.");
        }
    }

    private static void RevertAfterSiblingFailure()
    {
        var harmony = new Harmony("ltp.tests.autoreload.foreign-revert-failure");
        MethodInfo original = typeof(ConfigFile).GetMethod("Reload", Any);
        MethodInfo prefix = typeof(ConfigAutoReloadTests).GetMethod("ThrowReloadPrefix", Any);
        harmony.Patch(original, prefix: new HarmonyMethod(prefix));
        try
        {
            using (var scope = new Scope())
            {
                Fixture healthy = scope.Config();
                Fixture failing = new Fixture(healthy.Path, false);
                scope.Track(healthy.File);
                scope.Track(failing.File);
                throwingFile = failing.File;
                injectedReloads = 0;
                Write(healthy.Path, 9);
                Eventually(scope, () => healthy.Number.Value == 9 && injectedReloads > 0,
                    "The partial shared-path reload fixture did not reach its expected state.");
                Check(healthy.Reloads == 1 && failing.Number.Value == 1 && failing.Reloads == 0,
                    "The failure fixture did not preserve one successful and one unchanged sibling.");
                Write(healthy.Path, 1);
                Eventually(scope, () => healthy.Number.Value == 1 && healthy.Reloads == 2,
                    "Restoring the original file bytes failed to revert the sibling that had already changed.");
                Settle(scope);
                Check(failing.Number.Value == 1 && failing.Reloads == 0,
                    "The already current sibling reloaded when the original bytes were restored.");
                Check(healthy.Reloads == 2 && healthy.ChangedValues.Count == 2 &&
                    healthy.ChangedValues[0] == 9 && healthy.ChangedValues[1] == 1,
                    "Reverting the partial reload emitted duplicate or incorrect setting changes.");
            }
        }
        finally
        {
            throwingFile = null;
            harmony.Unpatch(original, prefix);
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static WeakReference TrackEphemeral(Scope scope, string path)
    {
        var config = new ConfigFile(path, false) { SaveOnConfigSet = false };
        config.Bind("Live", "Number", 1);
        scope.Track(config);
        return new WeakReference(config);
    }

    private static void WeakLifetime()
    {
        using (var scope = new Scope())
        {
            string path = System.IO.Path.Combine(scope.Directory, "ephemeral.cfg");
            Write(path, 1);
            WeakReference weak = TrackEphemeral(scope, path);
            for (int i = 0; i < 5 && weak.IsAlive; i++)
            {
                GC.Collect(); GC.WaitForPendingFinalizers(); GC.Collect(); Thread.Sleep(20);
            }
            Check(!weak.IsAlive, "A watcher or queued state retained the ConfigFile after its owner released it.");
            Write(path, 59);
            Settle(scope);
            Check(scope.Warnings.IsEmpty, "A dead weak registration caused a reload warning.");
        }
    }

    private static void DisposeQueuedWork()
    {
        using (var scope = new Scope())
        {
            Fixture fixture = scope.Config();
            scope.Track(fixture.File);
            Write(fixture.Path, 61);
            Eventually(scope, () => !scope.Queue.IsEmpty, "No work was queued before disposal.", false);
            scope.Dispose();
            scope.Pump();
            Check(fixture.Number.Value == 1 && fixture.Reloads == 0, "Already queued work reloaded a disposed service.");
            Write(fixture.Path, 67);
            Settle(scope);
            Check(fixture.Number.Value == 1 && scope.Queue.IsEmpty, "A disposed watcher scheduled new reload work.");
        }
    }

    private static void LockedFileRecovery()
    {
        using (var scope = new Scope())
        {
            Fixture fixture = scope.Config();
            scope.Track(fixture.File);
            using (var stream = new FileStream(fixture.Path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(Document(71));
                stream.Write(bytes, 0, bytes.Length);
                stream.Flush(true);
                Settle(scope);
                Check(fixture.Number.Value == 1 && fixture.Reloads == 0, "A locked file caused a premature live reload.");
            }
            Eventually(scope, () => fixture.Number.Value == 71, "Reload did not recover once the cfg lock was released.");
        }
    }

    private static void PartialValueValidation()
    {
        using (var scope = new Scope())
        {
            Fixture fixture = scope.Config();
            scope.Track(fixture.File);
            string contents = "[Live]\nNumber = invalid\nOther = 73\n";
            File.WriteAllText(fixture.Path, contents);
            Eventually(scope, () => fixture.Reloads == 1, "An ordinary BepInEx parse warning prevented the normal reload event.");
            Check(fixture.Number.Value == 1 && fixture.Other.Value == 73, "The service changed BepInEx per-entry validation behavior.");
            Check(File.ReadAllText(fixture.Path) == contents, "A partially invalid foreign config was rewritten.");
        }
    }

    private static void DuplicateRegistration()
    {
        using (var scope = new Scope())
        {
            Fixture fixture = scope.Config();
            scope.Track(fixture.File);
            scope.Track(fixture.File);
            scope.Start();
            scope.Start();
            Write(fixture.Path, 79);
            Eventually(scope, () => fixture.Number.Value == 79, "The repeatedly registered cfg did not reload.");
            Settle(scope);
            Check(fixture.Reloads == 1, "Idempotent registration or activation produced duplicate reloads.");
        }
    }

    private static void HarmlessPrefix() { }

    private static void DelayedWatcherError()
    {
        using (var scope = new Scope())
        {
            Fixture fixture = scope.Config();
            scope.Track(fixture.File);
            FileSystemWatcher old = scope.Watcher;
            Check(old != null, "The fixture directory has no watcher to invalidate.");
            scope.WatcherError(old);
            Eventually(scope, () => scope.Watcher != null && !ReferenceEquals(scope.Watcher, old),
                "An errored watcher was not replaced.");
            FileSystemWatcher successor = scope.Watcher;
            Check(scope.Warnings.Count == 1, "The initial watcher failure was not reported once.");
            scope.WatcherError(old);
            Check(ReferenceEquals(scope.Watcher, successor) && scope.Warnings.Count == 1,
                "A queued error from the old watcher removed or reported against the active successor.");
            Write(fixture.Path, 83);
            Eventually(scope, () => fixture.Number.Value == 83 && fixture.Reloads == 1,
                "The successor watcher did not reload a later real file change.");
        }
    }

    private static void StandaloneWatcherConflict()
    {
        var foreign = new Harmony("org.bepinex.patchers.configwatcher");
        MethodInfo original = typeof(ConfigFile).GetMethod("Reload", Any);
        MethodInfo prefix = typeof(ConfigAutoReloadTests).GetMethod("HarmlessPrefix", Any);
        Type wrapper = product.GetType("LoadTimeProfiler.ConfigAutoReload", true);
        foreign.Patch(original, prefix: new HarmonyMethod(prefix));
        try
        {
            wrapper.GetMethod("Install", Any).Invoke(null, null);
            Check(wrapper.GetField("_service", Any).GetValue(null) == null &&
                wrapper.GetField("_harmony", Any).GetValue(null) == null,
                "LTP created a second watcher while standalone ConfigWatcher ownership was present.");
            Check(!Harmony.HasAnyPatches("sighsorry.LoadTimeProfiler.config-auto-reload"),
                "LTP installed a config tracking hook despite the standalone watcher conflict.");
            wrapper.GetMethod("Dispose", Any).Invoke(null, null);
            Check(Harmony.GetPatchInfo(original).Owners.Contains(foreign.Id),
                "LTP conflict handling or disposal removed the standalone watcher's patch.");
        }
        finally
        {
            wrapper.GetMethod("Dispose", Any).Invoke(null, null);
            foreign.Unpatch(original, prefix);
        }
    }
}
