using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Bootstrap;
using HarmonyLib;

namespace LoadTimeProfiler;

/// <summary>
/// Starts AzuAntiCheat 4.3.11's per-plugin SHA-256 work while BepInEx is still
/// constructing plugins. This is intentionally a same-process, single-use
/// prehash: no digest is trusted across launches.
///
/// The Azu-owned GetModList implementation still builds the mod map and applies
/// its SHA-384 transformations. Only the exact
/// File.ReadAllBytes(path) -> TrustworthyTrygve(byte[]) pair is replaced with
/// an equivalent streaming SHA-256 operation.
/// </summary>
internal static class AzuAntiCheatPrehashAcceleration
{
    private const string AzuGuid = "Azumatt.AzuAntiCheat";
    private const string AzuAssemblyName = "AzuAnticheat";
    private const string ObserverTypeName = "AzuAnticheat.Internal.Observer";
    private const string PluginTypeName = "AzuAntiCheat.AzuAnticheatPlugin";
    private static readonly System.Version SupportedPluginVersion = new(4, 3, 11);
    private static readonly System.Version SupportedAssemblyVersion = new(4, 3, 11, 0);
    private const int StreamBufferSize = 1024 * 1024;

    private static readonly object Lock = new();
    private static readonly StringComparer PathComparer =
        Path.DirectorySeparatorChar == '\\'
            ? StringComparer.OrdinalIgnoreCase
            : StringComparer.Ordinal;
    private static readonly Harmony Harmony =
        new(LoadTimeProfilerPatcher.ModGUID + ".azu-prehash");
    private static readonly HashSet<string> ObservedPaths = new(PathComparer);
    private static readonly Dictionary<string, PrehashEntry> Entries = new(PathComparer);
    private static readonly LinkedList<PrehashEntry> Pending = new();
    private static readonly MethodInfo? ReadAllBytesMethod =
        AccessTools.DeclaredMethod(typeof(File), nameof(File.ReadAllBytes), new[] { typeof(string) });
    private static readonly MethodInfo? ConsumeMethod =
        AccessTools.DeclaredMethod(
            typeof(AzuAntiCheatPrehashAcceleration),
            nameof(GetVerifiedHash));

    private static bool _azuObserved;
    private static bool _installAttempted;
    private static bool _patchInstalled;
    private static bool _discoveryComplete;
    private static bool _workerStarted;
    private static bool _workerExited;
    private static bool _cleanupRequested;
    private static bool _transpilerApplied;
    private static MethodInfo? _getModListMethod;
    private static MethodInfo? _trustworthyTrygveMethod;
    private static long _workerStartedAt;
    private static long _workerExitedAt;
    private static long _firstConsumptionAt;
    private static int _observedPluginFiles;
    private static int _scheduledFiles;
    private static long _scheduledBytes;
    private static int _backgroundCompletedFiles;
    private static long _backgroundCompletedBytes;
    private static double _backgroundHashMilliseconds;
    private static int _backgroundFailures;
    private static int _cacheHits;
    private static int _metadataInvalidations;
    private static int _synchronousFallbacks;
    private static long _synchronousFallbackBytes;
    private static double _synchronousFallbackMilliseconds;
    private static double _consumerWaitMilliseconds;
    private static double _getModListMilliseconds;
    private static double _installationMilliseconds;
    private static string? _skipReason;

    /// <summary>
    /// Main-thread integration point. Call after a BaseUnityPlugin component has
    /// been constructed. Reflection and BepInEx access remain on the main
    /// thread; the worker receives only normalized immutable file paths.
    /// </summary>
    internal static void ObservePlugin(Type componentType)
    {
        if (componentType == null ||
            !typeof(BaseUnityPlugin).IsAssignableFrom(componentType))
        {
            return;
        }

        Assembly assembly = componentType.Assembly;
        string? path = NormalizeAssemblyPath(assembly);
        if (path != null)
        {
            ObservePath(path);
        }

        BepInPlugin? metadata;
        try
        {
            metadata = componentType
                .GetCustomAttributes(typeof(BepInPlugin), inherit: false)
                .OfType<BepInPlugin>()
                .FirstOrDefault();
        }
        catch (Exception ex)
        {
            ProfilerLog.WriteLine(
                "AzuAntiCheat prehash metadata observation failed open for " +
                (componentType.FullName ?? componentType.Name) +
                ": " +
                OneLine(ex));
            return;
        }

        if (metadata == null ||
            !string.Equals(metadata.GUID, AzuGuid, StringComparison.Ordinal))
        {
            return;
        }

        lock (Lock)
        {
            _azuObserved = true;
        }

        TryInstall(assembly, componentType, metadata.Version);
    }

    /// <summary>
    /// Main-thread safety net to call once Chainloader.Start has returned.
    /// It catches plugin-construction hook failures and closes the producer
    /// side of the worker queue.
    /// </summary>
    internal static void CompletePluginDiscovery()
    {
        try
        {
            PluginInfo[] plugins = Chainloader.PluginInfos.Values.ToArray();
            foreach (PluginInfo plugin in plugins)
            {
                BaseUnityPlugin? instance = plugin.Instance;
                if (instance != null)
                {
                    ObservePlugin(instance.GetType());
                }
            }
        }
        catch (Exception ex)
        {
            ProfilerLog.WriteLine(
                "AzuAntiCheat prehash final plugin discovery failed open: " +
                OneLine(ex));
        }
        finally
        {
            lock (Lock)
            {
                _discoveryComplete = true;
                Monitor.PulseAll(Lock);
            }
        }
    }

    internal static void AbortAfterChainloaderFailure(string reason)
    {
        List<IDisposable> handles = new();
        bool hadWorker;
        lock (Lock)
        {
            hadWorker = _workerStarted;
            RequestCleanupLocked(handles);
        }

        DisposeHandles(handles);
        if (hadWorker)
        {
            ProfilerLog.WriteLine(
                "AzuAntiCheat async prehash stopped after Chainloader failure: " +
                reason);
        }
    }

    internal static void AppendStartupReport(StringBuilder builder)
    {
        bool azuObserved;
        bool installAttempted;
        bool patchInstalled;
        bool workerExited;
        int observedPluginFiles;
        int scheduledFiles;
        long scheduledBytes;
        int backgroundCompletedFiles;
        long backgroundCompletedBytes;
        double backgroundHashMilliseconds;
        int backgroundFailures;
        int cacheHits;
        int metadataInvalidations;
        int synchronousFallbacks;
        long synchronousFallbackBytes;
        double synchronousFallbackMilliseconds;
        double consumerWaitMilliseconds;
        double getModListMilliseconds;
        double installationMilliseconds;
        double leadMilliseconds;
        double workerWallMilliseconds;
        string? skipReason;

        lock (Lock)
        {
            azuObserved = _azuObserved;
            installAttempted = _installAttempted;
            patchInstalled = _patchInstalled;
            workerExited = _workerExited;
            observedPluginFiles = _observedPluginFiles;
            scheduledFiles = _scheduledFiles;
            scheduledBytes = _scheduledBytes;
            backgroundCompletedFiles = _backgroundCompletedFiles;
            backgroundCompletedBytes = _backgroundCompletedBytes;
            backgroundHashMilliseconds = _backgroundHashMilliseconds;
            backgroundFailures = _backgroundFailures;
            cacheHits = _cacheHits;
            metadataInvalidations = _metadataInvalidations;
            synchronousFallbacks = _synchronousFallbacks;
            synchronousFallbackBytes = _synchronousFallbackBytes;
            synchronousFallbackMilliseconds = _synchronousFallbackMilliseconds;
            consumerWaitMilliseconds = _consumerWaitMilliseconds;
            getModListMilliseconds = _getModListMilliseconds;
            installationMilliseconds = _installationMilliseconds;
            skipReason = _skipReason;
            leadMilliseconds =
                _workerStartedAt > 0L && _firstConsumptionAt > _workerStartedAt
                    ? TicksToMilliseconds(_firstConsumptionAt - _workerStartedAt)
                    : 0d;
            long workerEnd = _workerExitedAt > 0L
                ? _workerExitedAt
                : Stopwatch.GetTimestamp();
            workerWallMilliseconds = _workerStartedAt > 0L
                ? TicksToMilliseconds(workerEnd - _workerStartedAt)
                : 0d;
        }

        builder.AppendLine("AzuAntiCheat asynchronous prehash:");
        if (!azuObserved)
        {
            builder.AppendLine("  AzuAntiCheat was not loaded; no hashing work was scheduled.");
            return;
        }

        if (!patchInstalled)
        {
            builder.Append("  Original AzuAntiCheat behavior retained");
            if (installAttempted && !string.IsNullOrEmpty(skipReason))
            {
                builder.Append(": ").Append(skipReason);
            }

            builder.AppendLine(".");
            return;
        }

        builder.Append("  Compatibility: AzuAntiCheat 4.3.11 exact IL patch installed in ")
            .AppendLine(TimelineProfiler.FormatDuration(installationMilliseconds));
        builder.Append("  Plugin files: observed=")
            .Append(observedPluginFiles)
            .Append(", scheduled=")
            .Append(scheduledFiles)
            .Append(" (")
            .Append(FormatBytes(scheduledBytes))
            .AppendLine(")");
        builder.Append("  Background streaming SHA-256: completed=")
            .Append(backgroundCompletedFiles)
            .Append('/')
            .Append(scheduledFiles)
            .Append(" (")
            .Append(FormatBytes(backgroundCompletedBytes))
            .Append("), inclusive file time=")
            .Append(TimelineProfiler.FormatDuration(backgroundHashMilliseconds))
            .Append(", worker wall=")
            .Append(TimelineProfiler.FormatDuration(workerWallMilliseconds))
            .Append(", worker=")
            .AppendLine(workerExited ? "finished" : "active");
        builder.Append("  Safe consumption: hits=")
            .Append(cacheHits)
            .Append(", metadata invalidations=")
            .Append(metadataInvalidations)
            .Append(", background failures=")
            .Append(backgroundFailures)
            .Append(", wait=")
            .Append(TimelineProfiler.FormatDuration(consumerWaitMilliseconds))
            .Append(", prehash lead=")
            .AppendLine(TimelineProfiler.FormatDuration(leadMilliseconds));
        builder.Append("  Synchronous streaming fallback: files=")
            .Append(synchronousFallbacks)
            .Append(" (")
            .Append(FormatBytes(synchronousFallbackBytes))
            .Append("), time=")
            .AppendLine(TimelineProfiler.FormatDuration(synchronousFallbackMilliseconds));
        builder.Append("  AzuAntiCheat Observer.GetModList total: ")
            .AppendLine(TimelineProfiler.FormatDuration(getModListMilliseconds));
    }

    private static void ObservePath(string path)
    {
        bool enqueue;
        lock (Lock)
        {
            if (!ObservedPaths.Add(path))
            {
                return;
            }

            _observedPluginFiles = ObservedPaths.Count;
            enqueue = _patchInstalled && !_cleanupRequested;
        }

        if (enqueue)
        {
            Enqueue(path);
        }
    }

    private static void TryInstall(
        Assembly assembly,
        Type componentType,
        System.Version pluginVersion)
    {
        lock (Lock)
        {
            if (_installAttempted)
            {
                return;
            }

            _installAttempted = true;
        }

        Stopwatch stopwatch = Stopwatch.StartNew();
        try
        {
            ValidateIdentity(assembly, componentType, pluginVersion);
            MethodInfo getModList = ResolveAndValidateMethods(
                assembly,
                componentType,
                out MethodInfo trustworthyTrygve);
            ValidateHashEquivalence(trustworthyTrygve);
            ValidateCurrentIl(getModList, trustworthyTrygve);

            MethodInfo transpiler = AccessTools.DeclaredMethod(
                                        typeof(AzuAntiCheatPrehashAcceleration),
                                        nameof(GetModListTranspiler)) ??
                                    throw new MissingMethodException(
                                        typeof(AzuAntiCheatPrehashAcceleration).FullName,
                                        nameof(GetModListTranspiler));
            MethodInfo prefix = AccessTools.DeclaredMethod(
                                    typeof(AzuAntiCheatPrehashAcceleration),
                                    nameof(GetModListPrefix)) ??
                                throw new MissingMethodException(
                                    typeof(AzuAntiCheatPrehashAcceleration).FullName,
                                    nameof(GetModListPrefix));
            MethodInfo finalizer = AccessTools.DeclaredMethod(
                                       typeof(AzuAntiCheatPrehashAcceleration),
                                       nameof(GetModListFinalizer)) ??
                                   throw new MissingMethodException(
                                       typeof(AzuAntiCheatPrehashAcceleration).FullName,
                                       nameof(GetModListFinalizer));

            lock (Lock)
            {
                _getModListMethod = getModList;
                _trustworthyTrygveMethod = trustworthyTrygve;
                _transpilerApplied = false;
            }

            Harmony.Patch(
                getModList,
                prefix: new HarmonyMethod(prefix) { priority = Priority.First },
                transpiler: new HarmonyMethod(transpiler) { priority = Priority.Last },
                finalizer: new HarmonyMethod(finalizer) { priority = Priority.Last });

            lock (Lock)
            {
                if (!_transpilerApplied)
                {
                    throw new InvalidOperationException(
                        "the verified ReadAllBytes/SHA-256 call pair was not replaced");
                }

                _patchInstalled = true;
                _skipReason = null;
            }

            string[] paths;
            lock (Lock)
            {
                paths = ObservedPaths.ToArray();
            }

            foreach (string path in paths)
            {
                Enqueue(path);
            }

            ProfilerLog.WriteLine(
                "AzuAntiCheat 4.3.11 async prehash installed: exact GetModList " +
                "ReadAllBytes/SHA-256 pair replaced; same-process streaming worker started.");
        }
        catch (Exception ex)
        {
            List<IDisposable> handles = new();
            try
            {
                MethodInfo? target;
                lock (Lock)
                {
                    target = _getModListMethod;
                }

                if (target != null)
                {
                    Harmony.Unpatch(target, HarmonyPatchType.All, Harmony.Id);
                }
            }
            catch
            {
                // The compatibility path is already fail-open. Do not obscure
                // the original validation failure with cleanup noise.
            }

            lock (Lock)
            {
                _patchInstalled = false;
                _skipReason = OneLine(ex);
                RequestCleanupLocked(handles);
            }

            DisposeHandles(handles);
            ProfilerLog.WriteLine(
                "AzuAntiCheat async prehash skipped; original hashing retained: " +
                OneLine(ex));
        }
        finally
        {
            stopwatch.Stop();
            lock (Lock)
            {
                _installationMilliseconds = stopwatch.Elapsed.TotalMilliseconds;
            }
        }
    }

    private static void ValidateIdentity(
        Assembly assembly,
        Type componentType,
        System.Version pluginVersion)
    {
        AssemblyName name = assembly.GetName();
        if (!string.Equals(name.Name, AzuAssemblyName, StringComparison.OrdinalIgnoreCase))
        {
            throw new NotSupportedException(
                "unexpected assembly name " + (name.Name ?? "<null>"));
        }

        if (!SupportedPluginVersion.Equals(pluginVersion))
        {
            throw new NotSupportedException(
                "plugin version " + pluginVersion + " is not supported");
        }

        if (!SupportedAssemblyVersion.Equals(name.Version))
        {
            throw new NotSupportedException(
                "assembly version " + (name.Version?.ToString() ?? "<null>") +
                " is not supported");
        }

        if (!string.Equals(componentType.FullName, PluginTypeName, StringComparison.Ordinal))
        {
            throw new NotSupportedException(
                "unexpected plugin type " +
                (componentType.FullName ?? componentType.Name));
        }
    }

    private static MethodInfo ResolveAndValidateMethods(
        Assembly assembly,
        Type componentType,
        out MethodInfo trustworthyTrygve)
    {
        Type observer = assembly.GetType(ObserverTypeName, throwOnError: false) ??
                        throw new MissingMemberException(
                            assembly.FullName,
                            ObserverTypeName);
        MethodInfo getModList = observer.GetMethod(
                                        "GetModList",
                                        BindingFlags.Static |
                                        BindingFlags.Public |
                                        BindingFlags.NonPublic,
                                        binder: null,
                                        types: Type.EmptyTypes,
                                        modifiers: null) ??
                                    throw new MissingMethodException(
                                        ObserverTypeName,
                                        "GetModList()");
        if (getModList.ReturnType != typeof(void) ||
            getModList.ContainsGenericParameters)
        {
            throw new NotSupportedException(
                "Observer.GetModList has an unexpected signature");
        }

        trustworthyTrygve = componentType.GetMethod(
                                  "TrustworthyTrygve",
                                  BindingFlags.Static |
                                  BindingFlags.Public |
                                  BindingFlags.NonPublic,
                                  binder: null,
                                  types: new[] { typeof(byte[]) },
                                  modifiers: null) ??
                              throw new MissingMethodException(
                                  PluginTypeName,
                                  "TrustworthyTrygve(byte[])");
        if (trustworthyTrygve.ReturnType != typeof(string))
        {
            throw new NotSupportedException(
                "TrustworthyTrygve has an unexpected return type");
        }

        MethodInfo start = componentType.GetMethod(
                               "Start",
                               BindingFlags.Instance |
                               BindingFlags.Public |
                               BindingFlags.NonPublic |
                               BindingFlags.DeclaredOnly,
                               binder: null,
                               types: Type.EmptyTypes,
                               modifiers: null) ??
                           throw new MissingMethodException(
                               PluginTypeName,
                               "Start()");
        List<CodeInstruction> startInstructions =
            PatchProcessor.GetCurrentInstructions(start);
        if (startInstructions.Count(instruction =>
                Calls(instruction, getModList)) != 1)
        {
            throw new NotSupportedException(
                "AzuAntiCheat.Start does not contain exactly one GetModList call");
        }

        return getModList;
    }

    private static void ValidateHashEquivalence(MethodInfo trustworthyTrygve)
    {
        byte[][] samples =
        {
            Array.Empty<byte>(),
            new byte[] { 0, 1, 2, 0x7f, 0x80, 0xfe, 0xff },
            Encoding.UTF8.GetBytes("LoadTimeProfiler/AzuAntiCheat/4.3.11")
        };
        foreach (byte[] sample in samples)
        {
            string original = (string)(trustworthyTrygve.Invoke(
                                           null,
                                           new object[] { sample }) ??
                                       string.Empty);
            string replacement;
            using (MemoryStream stream = new(sample, writable: false))
            {
                replacement = ComputeHashHex(stream);
            }

            if (!string.Equals(original, replacement, StringComparison.Ordinal))
            {
                throw new NotSupportedException(
                    "AzuAntiCheat SHA-256 string format does not match the streaming implementation");
            }
        }
    }

    private static void ValidateCurrentIl(
        MethodInfo getModList,
        MethodInfo trustworthyTrygve)
    {
        if (ReadAllBytesMethod == null || ConsumeMethod == null)
        {
            throw new MissingMethodException(
                "Required File.ReadAllBytes or prehash consumer method is unavailable");
        }

        List<CodeInstruction> instructions =
            PatchProcessor.GetCurrentInstructions(getModList);
        int readCalls = instructions.Count(instruction =>
            Calls(instruction, ReadAllBytesMethod));
        int hashCalls = instructions.Count(instruction =>
            Calls(instruction, trustworthyTrygve));
        int pairs = CountExpectedPairs(
            instructions,
            ReadAllBytesMethod,
            trustworthyTrygve);
        if (readCalls != 1 || hashCalls != 1 || pairs != 1)
        {
            throw new NotSupportedException(
                "Observer.GetModList IL mismatch: expected exactly one adjacent " +
                "File.ReadAllBytes/TrustworthyTrygve pair, found reads=" +
                readCalls.ToString(CultureInfo.InvariantCulture) +
                ", hashes=" +
                hashCalls.ToString(CultureInfo.InvariantCulture) +
                ", pairs=" +
                pairs.ToString(CultureInfo.InvariantCulture));
        }
    }

    private static IEnumerable<CodeInstruction> GetModListTranspiler(
        IEnumerable<CodeInstruction> instructions)
    {
        List<CodeInstruction> result = instructions.ToList();
        MethodInfo? hashMethod;
        lock (Lock)
        {
            hashMethod = _trustworthyTrygveMethod;
        }

        if (ReadAllBytesMethod == null ||
            ConsumeMethod == null ||
            hashMethod == null ||
            CountExpectedPairs(result, ReadAllBytesMethod, hashMethod) != 1)
        {
            return result;
        }

        for (int index = 0; index < result.Count; index++)
        {
            if (!Calls(result[index], ReadAllBytesMethod))
            {
                continue;
            }

            int next = NextNonNop(result, index + 1);
            if (next < 0 || !Calls(result[next], hashMethod))
            {
                continue;
            }

            result[index].opcode = OpCodes.Call;
            result[index].operand = ConsumeMethod;
            result[next].opcode = OpCodes.Nop;
            result[next].operand = null;
            lock (Lock)
            {
                _transpilerApplied = true;
            }

            break;
        }

        return result;
    }

    private static void GetModListPrefix(out long __state)
    {
        __state = Stopwatch.GetTimestamp();
        lock (Lock)
        {
            if (_firstConsumptionAt == 0L)
            {
                // If the mod list is empty, this still gives the report a
                // meaningful upper bound for available prehash lead time.
                _firstConsumptionAt = __state;
            }
        }
    }

    private static Exception? GetModListFinalizer(
        long __state,
        Exception? __exception)
    {
        long ended = Stopwatch.GetTimestamp();
        List<IDisposable> handles = new();
        lock (Lock)
        {
            if (__state > 0L)
            {
                _getModListMilliseconds =
                    TicksToMilliseconds(ended - __state);
            }

            RequestCleanupLocked(handles);
        }

        DisposeHandles(handles);

        ProfilerLog.WriteLine(
            "AzuAntiCheat async prehash consumed: hits=" +
            ReadStat(ref _cacheHits).ToString(CultureInfo.InvariantCulture) +
            ", wait=" +
            ReadDoubleStat(ref _consumerWaitMilliseconds).ToString(
                "0.###",
                CultureInfo.InvariantCulture) +
            " ms, fallback=" +
            ReadStat(ref _synchronousFallbacks).ToString(CultureInfo.InvariantCulture) +
            ", GetModList=" +
            ReadDoubleStat(ref _getModListMilliseconds).ToString(
                "0.###",
                CultureInfo.InvariantCulture) +
            " ms.");
        return __exception;
    }

    /// <summary>
    /// Called on AzuAntiCheat's main-thread GetModList path. It only consumes
    /// an immutable worker result after path metadata has been revalidated.
    /// A mismatch or worker failure uses a fresh synchronous streaming hash.
    /// </summary>
    private static string GetVerifiedHash(string path)
    {
        string normalized = Path.GetFullPath(path);
        PrehashEntry? entry;
        lock (Lock)
        {
            if (_firstConsumptionAt == 0L)
            {
                _firstConsumptionAt = Stopwatch.GetTimestamp();
            }

            if (Entries.TryGetValue(normalized, out entry) &&
                entry.PendingNode != null &&
                !ReferenceEquals(Pending.First, entry.PendingNode))
            {
                Pending.Remove(entry.PendingNode);
                entry.PendingNode = Pending.AddFirst(entry);
                Monitor.PulseAll(Lock);
            }

            // A previous GetModList invocation can exit early and close the
            // producer queue. Never wait on an in-flight task during a later
            // invocation; the original synchronous behavior is the safe
            // fallback in that state.
            if (_cleanupRequested &&
                entry != null &&
                !entry.Completion.Task.IsCompleted)
            {
                entry = null;
            }
        }

        if (entry != null)
        {
            long waitedAt = Stopwatch.GetTimestamp();
            HashResult? result = null;
            try
            {
                result = entry.Completion.Task.GetAwaiter().GetResult();
            }
            catch
            {
                // The original synchronous behavior below determines whether
                // the file is genuinely unreadable and should still throw.
            }
            finally
            {
                AddDoubleStat(
                    ref _consumerWaitMilliseconds,
                    TicksToMilliseconds(Stopwatch.GetTimestamp() - waitedAt));
            }

            if (result != null)
            {
                bool valid;
                lock (Lock)
                {
                    valid = !result.Consumed &&
                            result.HeldStream != null &&
                            FileStamp.TryCapture(
                                normalized,
                                out FileStamp current) &&
                            result.Stamp.Equals(current);
                    if (valid)
                    {
                        result.Consumed = true;
                    }
                }

                if (valid)
                {
                    IncrementStat(ref _cacheHits);
                    string hash = result.Hash;
                    // Revalidation above is deliberately performed while the
                    // stable read handle is still open. Close it immediately
                    // before handing the immutable digest back to Azu.
                    DisposeHeldStream(result);
                    return hash;
                }

                if (!result.Consumed)
                {
                    IncrementStat(ref _metadataInvalidations);
                }

                DisposeHeldStream(result);
            }
        }

        return ComputeSynchronousFallback(normalized);
    }

    private static void Enqueue(string path)
    {
        FileStamp.TryCapture(path, out FileStamp stamp);
        lock (Lock)
        {
            if (!_patchInstalled ||
                _cleanupRequested ||
                Entries.ContainsKey(path))
            {
                return;
            }

            PrehashEntry entry = new(path);
            entry.PendingNode = Pending.AddLast(entry);
            Entries.Add(path, entry);
            _scheduledFiles++;
            _scheduledBytes += Math.Max(0L, stamp.Length);
            StartWorkerLocked();
            Monitor.PulseAll(Lock);
        }
    }

    private static void StartWorkerLocked()
    {
        if (_workerStarted)
        {
            return;
        }

        _workerStarted = true;
        _workerStartedAt = Stopwatch.GetTimestamp();
        Task.Factory.StartNew(
            WorkerLoop,
            CancellationToken.None,
            TaskCreationOptions.LongRunning,
            TaskScheduler.Default);
    }

    private static void WorkerLoop()
    {
        try
        {
            try
            {
                if (Thread.CurrentThread.Name == null)
                {
                    Thread.CurrentThread.Name = "LoadTimeProfiler Azu prehash";
                }

                Thread.CurrentThread.Priority = ThreadPriority.BelowNormal;
            }
            catch
            {
                // Thread metadata is an optional courtesy only.
            }

            while (true)
            {
                PrehashEntry? entry;
                lock (Lock)
                {
                    while (Pending.Count == 0 &&
                           !_discoveryComplete &&
                           !_cleanupRequested)
                    {
                        Monitor.Wait(Lock);
                    }

                    if (_cleanupRequested ||
                        Pending.Count == 0 && _discoveryComplete)
                    {
                        return;
                    }

                    LinkedListNode<PrehashEntry> node = Pending.First!;
                    Pending.RemoveFirst();
                    entry = node.Value;
                    entry.PendingNode = null;
                }

                HashEntry(entry);
            }
        }
        finally
        {
            lock (Lock)
            {
                _workerExited = true;
                _workerExitedAt = Stopwatch.GetTimestamp();
                Monitor.PulseAll(Lock);
            }
        }
    }

    private static void HashEntry(PrehashEntry entry)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        FileStream? stream = null;
        try
        {
            stream = OpenForStableSequentialRead(entry.Path);
            if (!FileStamp.TryCapture(entry.Path, out FileStamp before))
            {
                throw new FileNotFoundException(
                    "Could not capture plugin metadata before hashing",
                    entry.Path);
            }

            string hash = ComputeHashHex(stream);
            if (!FileStamp.TryCapture(entry.Path, out FileStamp after) ||
                !before.Equals(after) ||
                stream.Length != after.Length)
            {
                throw new IOException(
                    "Plugin file metadata changed during asynchronous hashing: " +
                    entry.Path);
            }

            HashResult result = new(hash, after, stream);
            stream = null;
            lock (Lock)
            {
                entry.Result = result;
                _backgroundCompletedFiles++;
                _backgroundCompletedBytes += after.Length;
                _backgroundHashMilliseconds += stopwatch.Elapsed.TotalMilliseconds;
                if (_cleanupRequested)
                {
                    result.HeldStream?.Dispose();
                    result.HeldStream = null;
                }
            }

            entry.Completion.TrySetResult(result);
        }
        catch (Exception ex)
        {
            lock (Lock)
            {
                _backgroundFailures++;
                _backgroundHashMilliseconds += stopwatch.Elapsed.TotalMilliseconds;
            }

            entry.Completion.TrySetException(ex);
        }
        finally
        {
            stopwatch.Stop();
            stream?.Dispose();
        }
    }

    private static string ComputeSynchronousFallback(string path)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        long length = 0L;
        try
        {
            using FileStream stream = OpenForStableSequentialRead(path);
            length = stream.Length;
            return ComputeHashHex(stream);
        }
        finally
        {
            stopwatch.Stop();
            lock (Lock)
            {
                _synchronousFallbacks++;
                _synchronousFallbackBytes += Math.Max(0L, length);
                _synchronousFallbackMilliseconds += stopwatch.Elapsed.TotalMilliseconds;
            }
        }
    }

    private static FileStream OpenForStableSequentialRead(string path)
    {
        // FileShare.Read prevents new writers and replacement/deletion on
        // Windows while the digest is waiting to be consumed. The metadata
        // stamp provides an additional cross-platform revalidation layer.
        return new FileStream(
            path,
            FileMode.Open,
            FileAccess.Read,
            FileShare.Read,
            StreamBufferSize,
            FileOptions.SequentialScan);
    }

    private static string ComputeHashHex(Stream stream)
    {
        using SHA256 sha256 = SHA256.Create();
        byte[] hash = sha256.ComputeHash(stream);
        StringBuilder builder = new(hash.Length * 2);
        foreach (byte value in hash)
        {
            builder.Append(value.ToString("X2", CultureInfo.InvariantCulture));
        }

        return builder.ToString();
    }

    private static int CountExpectedPairs(
        IReadOnlyList<CodeInstruction> instructions,
        MethodInfo readAllBytes,
        MethodInfo hashMethod)
    {
        int count = 0;
        for (int index = 0; index < instructions.Count; index++)
        {
            if (!Calls(instructions[index], readAllBytes))
            {
                continue;
            }

            int next = NextNonNop(instructions, index + 1);
            if (next >= 0 && Calls(instructions[next], hashMethod))
            {
                count++;
            }
        }

        return count;
    }

    private static int NextNonNop(
        IReadOnlyList<CodeInstruction> instructions,
        int start)
    {
        for (int index = start; index < instructions.Count; index++)
        {
            if (instructions[index].opcode != OpCodes.Nop)
            {
                return index;
            }
        }

        return -1;
    }

    private static bool Calls(CodeInstruction instruction, MethodInfo method)
    {
        if (instruction.opcode != OpCodes.Call &&
            instruction.opcode != OpCodes.Callvirt)
        {
            return false;
        }

        return instruction.operand is MethodInfo candidate &&
               candidate.Module == method.Module &&
               candidate.MetadataToken == method.MetadataToken;
    }

    private static string? NormalizeAssemblyPath(Assembly assembly)
    {
        try
        {
            string location = assembly.Location;
            if (string.IsNullOrWhiteSpace(location))
            {
                return null;
            }

            return Path.GetFullPath(location);
        }
        catch
        {
            return null;
        }
    }

    private static void DisposeHeldStream(HashResult result)
    {
        FileStream? stream;
        lock (Lock)
        {
            stream = result.HeldStream;
            result.HeldStream = null;
        }

        stream?.Dispose();
    }

    private static void RequestCleanupLocked(
        List<IDisposable> handles)
    {
        _cleanupRequested = true;
        _discoveryComplete = true;
        foreach (PrehashEntry pendingEntry in Pending)
        {
            pendingEntry.PendingNode = null;
            pendingEntry.Completion.TrySetCanceled();
        }

        Pending.Clear();
        foreach (PrehashEntry entry in Entries.Values)
        {
            HashResult? result = entry.Result;
            if (result?.HeldStream != null)
            {
                handles.Add(result.HeldStream);
                result.HeldStream = null;
            }
        }

        Monitor.PulseAll(Lock);
    }

    private static void DisposeHandles(
        IEnumerable<IDisposable> handles)
    {
        foreach (IDisposable handle in handles)
        {
            try
            {
                handle.Dispose();
            }
            catch
            {
                // Cleanup must never hide an AzuAntiCheat exception.
            }
        }
    }

    private static void IncrementStat(ref int field)
    {
        lock (Lock)
        {
            field++;
        }
    }

    private static int ReadStat(ref int field)
    {
        lock (Lock)
        {
            return field;
        }
    }

    private static void AddDoubleStat(ref double field, double value)
    {
        lock (Lock)
        {
            field += value;
        }
    }

    private static double ReadDoubleStat(ref double field)
    {
        lock (Lock)
        {
            return field;
        }
    }

    private static double TicksToMilliseconds(long ticks)
    {
        return ticks * 1000d / Stopwatch.Frequency;
    }

    private static string FormatBytes(long bytes)
    {
        if (bytes < 1024L)
        {
            return bytes.ToString(CultureInfo.InvariantCulture) + " B";
        }

        if (bytes < 1024L * 1024L)
        {
            return (bytes / 1024d).ToString("0.##", CultureInfo.InvariantCulture) +
                   " KiB";
        }

        if (bytes < 1024L * 1024L * 1024L)
        {
            return (bytes / (1024d * 1024d)).ToString(
                       "0.##",
                       CultureInfo.InvariantCulture) +
                   " MiB";
        }

        return (bytes / (1024d * 1024d * 1024d)).ToString(
                   "0.##",
                   CultureInfo.InvariantCulture) +
               " GiB";
    }

    private static string OneLine(Exception exception)
    {
        string message = exception.GetBaseException().Message;
        return message.Replace('\r', ' ').Replace('\n', ' ');
    }

    private sealed class PrehashEntry
    {
        internal PrehashEntry(string path)
        {
            Path = path;
            Completion = new TaskCompletionSource<HashResult>(
                TaskCreationOptions.RunContinuationsAsynchronously);
        }

        internal string Path { get; }
        internal TaskCompletionSource<HashResult> Completion { get; }
        internal LinkedListNode<PrehashEntry>? PendingNode { get; set; }
        internal HashResult? Result { get; set; }
    }

    private sealed class HashResult
    {
        internal HashResult(
            string hash,
            FileStamp stamp,
            FileStream heldStream)
        {
            Hash = hash;
            Stamp = stamp;
            HeldStream = heldStream;
        }

        internal string Hash { get; }
        internal FileStamp Stamp { get; }
        internal FileStream? HeldStream { get; set; }
        internal bool Consumed { get; set; }
    }

    private readonly struct FileStamp : IEquatable<FileStamp>
    {
        private FileStamp(
            long length,
            long creationUtcTicks,
            long lastWriteUtcTicks,
            FileAttributes attributes)
        {
            Length = length;
            CreationUtcTicks = creationUtcTicks;
            LastWriteUtcTicks = lastWriteUtcTicks;
            Attributes = attributes;
        }

        internal long Length { get; }
        private long CreationUtcTicks { get; }
        private long LastWriteUtcTicks { get; }
        private FileAttributes Attributes { get; }

        internal static bool TryCapture(string path, out FileStamp stamp)
        {
            try
            {
                FileInfo info = new(path);
                info.Refresh();
                if (!info.Exists)
                {
                    stamp = default;
                    return false;
                }

                stamp = new FileStamp(
                    info.Length,
                    info.CreationTimeUtc.Ticks,
                    info.LastWriteTimeUtc.Ticks,
                    info.Attributes);
                return true;
            }
            catch
            {
                stamp = default;
                return false;
            }
        }

        public bool Equals(FileStamp other)
        {
            return Length == other.Length &&
                   CreationUtcTicks == other.CreationUtcTicks &&
                   LastWriteUtcTicks == other.LastWriteUtcTicks &&
                   Attributes == other.Attributes;
        }

        public override bool Equals(object? obj)
        {
            return obj is FileStamp other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Length.GetHashCode();
                hashCode = (hashCode * 397) ^ CreationUtcTicks.GetHashCode();
                hashCode = (hashCode * 397) ^ LastWriteUtcTicks.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)Attributes;
                return hashCode;
            }
        }
    }
}
