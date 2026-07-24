using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using BepInEx;
using BepInEx.Bootstrap;
using HarmonyLib;

namespace LoadTimeProfiler;

/// <summary>
/// Narrowly scoped attribution for the synchronous Harmony callbacks
/// attached to FejdStartup.Awake. The target's patch list is inspected at two
/// bounded points; assemblies and unrelated game methods are never scanned.
/// </summary>
internal static class FejdStartupAttributionProfiler
{
    private const string TargetLabel = "FejdStartup.Awake";
    private const int MaximumReportedPlugins = 60;
    private static readonly object Lock = new();
    private static readonly Harmony InstrumentationHarmony =
        new(LoadTimeProfilerPatcher.ModGUID + ".fejd-startup-attribution");
    private static readonly MethodBase? Target =
        AccessTools.Method(typeof(FejdStartup), nameof(FejdStartup.Awake));
    private static readonly HashSet<MethodBase> InstrumentedMethods = new();
    private static readonly Dictionary<MethodBase, PluginIdentity> CallbackOwners = new();
    private static readonly Dictionary<string, PluginAggregate> PluginTimings =
        new(StringComparer.Ordinal);

    [ThreadStatic]
    private static int _activeTargetDepth;

    [ThreadStatic]
    private static Stack<CallbackState>? _activeCallbacks;

    private static bool _preparationAttempted;
    private static bool _entryRefreshAttempted;
    private static PreparationSummary _preparation;
    private static RuntimeAggregate _runtime = new();

    /// <summary>
    /// Clears data owned by the current startup report. Installed callback
    /// wrappers and preparation metadata intentionally survive because Harmony
    /// patches are process-wide and each preparation pass is one-shot.
    /// </summary>
    internal static void ResetSession()
    {
        lock (Lock)
        {
            PluginTimings.Clear();
            _runtime = new RuntimeAggregate();
        }

        _activeTargetDepth = 0;
        _activeCallbacks?.Clear();
    }

    /// <summary>
    /// Preferred preparation point. Calling this immediately after
    /// Chainloader.Start lets Harmony rebuild each callback before
    /// FejdStartup.Awake's own wrapper is first invoked/JIT-compiled.
    /// </summary>
    internal static void PrepareAfterChainloader()
    {
        if (!LoadTimeProfilerPatcher.ProfilingEnabled ||
            LoadTimeProfilerPatcher.IsDedicatedServer ||
            !TimelineProfiler.IsActive(ProfileSession.Startup))
        {
            return;
        }

        try
        {
            PreparePass(entryRefresh: false);
        }
        catch (Exception ex)
        {
            RecordRuntimeFailure();
            ProfilerLog.WriteLine(
                "FejdStartup attribution warning: early preparation failed open: " +
                ex.Message);
        }
    }

    /// <summary>
    /// Called from the highest-priority lifecycle prefix. Preparation happens
    /// before the phase is made active, so setup cost is reported separately
    /// and is not attributed to a mod callback.
    /// </summary>
    internal static void BeginTarget(MethodBase target)
    {
        if (!LoadTimeProfilerPatcher.ProfilingEnabled ||
            LoadTimeProfilerPatcher.IsDedicatedServer ||
            Target == null ||
            !Target.Equals(target) ||
            !TimelineProfiler.IsActive(ProfileSession.Startup))
        {
            return;
        }

        try
        {
            // Plugin Start methods run after Chainloader.Start and can still
            // add FejdStartup.Awake patches. Refresh the same single target
            // once at entry and install wrappers only for new callback
            // methods; the lifecycle stopwatch starts after this setup.
            PreparePass(entryRefresh: true);
        }
        catch (Exception ex)
        {
            RecordRuntimeFailure();
            ProfilerLog.WriteLine(
                "FejdStartup attribution warning: preparation failed open: " +
                ex.Message);
        }

        // Early-pass wrappers remain useful even if the incremental refresh
        // fails unexpectedly.
        _activeTargetDepth++;
    }

    /// <summary>
    /// Called from the lowest-priority lifecycle finalizer. No callback wrapper
    /// is removed here: rebuilding every patched method would add avoidable
    /// startup work. Dormant wrappers take only a thread-static depth check, and
    /// these callback methods normally exist solely for FejdStartup.Awake.
    /// </summary>
    internal static void EndTarget(MethodBase target)
    {
        if (Target == null || !Target.Equals(target) || _activeTargetDepth <= 0)
        {
            return;
        }

        _activeTargetDepth--;
        if (_activeTargetDepth == 0 && _activeCallbacks is { Count: > 0 })
        {
            int abandoned = _activeCallbacks.Count;
            _activeCallbacks.Clear();
            RecordStackRecovery(abandoned);
        }
    }

    internal static void AppendReport(StringBuilder builder)
    {
        PluginSnapshot[] plugins;
        PreparationSummary preparation;
        RuntimeSnapshot runtime;
        lock (Lock)
        {
            plugins = PluginTimings.Values
                .Select(value => value.Snapshot())
                .ToArray();
            preparation = _preparation;
            runtime = _runtime.Snapshot();
        }

        builder.AppendLine("Scoped FejdStartup.Awake attribution:");
        builder.AppendLine(
            "  Estimated exclusive synchronous time of Harmony prefix/postfix/finalizer callbacks; directly measured wrapper bookkeeping is excluded.");
        builder.AppendLine(
            "  Scope discovery inspects only Harmony.GetPatchInfo(FejdStartup.Awake): once after Chainloader.Start and once at target entry for patches added by plugin Start methods.");
        if (!preparation.Attempted)
        {
            builder.AppendLine("  Preparation was not attempted.");
            return;
        }

        builder.Append("  Preparation passes: scans=")
            .Append(preparation.Scans)
            .Append(", candidates examined=")
            .Append(preparation.Candidates)
            .Append(", newly installed=").Append(preparation.Installed)
            .Append(", already wrapped=").Append(preparation.AlreadyInstrumented)
            .Append(", skipped=").Append(preparation.Skipped)
            .Append(", failed=").Append(preparation.Failed)
            .Append(", setup=")
            .AppendLine(
                TimelineProfiler.FormatSeconds(
                    preparation.ElapsedMilliseconds));
        builder.Append("  Runtime diagnostics: calls=")
            .Append(runtime.Invocations)
            .Append(", recursive=").Append(runtime.RecursiveInvocations)
            .Append(", stack recoveries=").Append(runtime.StackRecoveries)
            .Append(", failures=").Append(runtime.Failures)
            .Append(", measured bookkeeping=")
            .Append(
                TimelineProfiler.FormatSeconds(
                    runtime.BookkeepingMilliseconds));
        if (runtime.Invocations > 0)
        {
            builder.Append(" (")
                .Append(
                    (runtime.BookkeepingMilliseconds /
                     runtime.Invocations).ToString("F3"))
                .Append(" ms/call)");
        }

        builder.AppendLine(".");
        builder.AppendLine(
            "  Bookkeeping excludes callback bodies; Harmony dispatcher overhead outside these wrappers is not measurable here.");

        PluginSnapshot[] ordered = plugins
            .Where(value => value.TotalTicks > 0L)
            .OrderByDescending(value => value.TotalTicks)
            .ThenBy(value => value.Identity.DisplayName, StringComparer.Ordinal)
            .ToArray();
        long attributedTicks = ordered.Sum(value => value.TotalTicks);
        double attributedMilliseconds =
            TicksToMilliseconds(attributedTicks);
        IReadOnlyDictionary<string, double> lifecycleTimes =
            LifecyclePhaseProfiler.SnapshotSingleExecutionTimes(
                ProfileSession.Startup);
        builder.Append("  Attributed callback total: ")
            .AppendLine(
                TimelineProfiler.FormatSeconds(
                    attributedMilliseconds));
        if (lifecycleTimes.TryGetValue(
                TargetLabel,
                out double targetMilliseconds))
        {
            builder.Append("  FejdStartup.Awake remaining (original body, uninstrumented callbacks, dispatcher, and profiler overhead): ")
                .AppendLine(
                    TimelineProfiler.FormatSeconds(
                        Math.Max(
                            0d,
                            targetMilliseconds -
                            attributedMilliseconds)));
        }

        if (ordered.Length == 0)
        {
            builder.AppendLine(
                "  No instrumented callback completed while FejdStartup.Awake was active.");
            return;
        }

        int count = Math.Min(ordered.Length, MaximumReportedPlugins);
        for (int i = 0; i < count; i++)
        {
            PluginSnapshot plugin = ordered[i];
            builder.Append("  ")
                .Append(
                    TimelineProfiler.FormatSeconds(
                        TicksToMilliseconds(plugin.TotalTicks)))
                .Append(" x").Append(plugin.Invocations)
                .Append(" (max ")
                .Append(
                    TimelineProfiler.FormatSeconds(
                        TicksToMilliseconds(plugin.MaximumTicks)))
                .Append("): ")
                .AppendLine(plugin.Identity.DisplayName);
        }

        if (ordered.Length > count)
        {
            builder.Append("  ... ")
                .Append(ordered.Length - count)
                .AppendLine(" more plugins omitted.");
        }
    }

    private static void PreparePass(bool entryRefresh)
    {
        lock (Lock)
        {
            if (entryRefresh)
            {
                if (_entryRefreshAttempted)
                {
                    return;
                }

                _entryRefreshAttempted = true;
            }
            else if (_preparationAttempted)
            {
                return;
            }

            // Mark each bounded pass before reflection/Harmony work so an
            // unexpected failure cannot turn into a repeated startup stall.
            _preparationAttempted = true;
        }

        long started = Stopwatch.GetTimestamp();
        int candidates = 0;
        int installed = 0;
        int alreadyInstrumented = 0;
        int skipped = 0;
        int failed = 0;

        if (Target == null)
        {
            failed++;
            FinishPreparation(
                candidates,
                installed,
                alreadyInstrumented,
                skipped,
                failed,
                started,
                entryRefresh);
            return;
        }

        Patches? patchInfo;
        try
        {
            patchInfo = Harmony.GetPatchInfo(Target);
        }
        catch (Exception ex)
        {
            failed++;
            ProfilerLog.WriteLine(
                "FejdStartup attribution warning: could not inspect " +
                TargetLabel +
                ": " +
                ex.Message);
            FinishPreparation(
                candidates,
                installed,
                alreadyInstrumented,
                skipped,
                failed,
                started,
                entryRefresh);
            return;
        }

        if (patchInfo != null)
        {
            PluginResolver resolver = PluginResolver.Create();
            HashSet<MethodBase> seenCandidates = new();
            foreach (Patch patch in EnumerateInvocationPatches(patchInfo))
            {
                MethodBase? patchMethod = patch.PatchMethod;
                if (patchMethod == null || !seenCandidates.Add(patchMethod))
                {
                    continue;
                }

                candidates++;
                if (!CanInstrument(patchMethod))
                {
                    skipped++;
                    continue;
                }

                PluginIdentity identity = resolver.Resolve(
                    patchMethod,
                    patch.owner);
                bool known;
                lock (Lock)
                {
                    known = InstrumentedMethods.Contains(patchMethod);
                    if (!known)
                    {
                        // Reserve before asking Harmony to patch so re-entry
                        // cannot install the same wrapper twice.
                        InstrumentedMethods.Add(patchMethod);
                        CallbackOwners[patchMethod] = identity;
                    }
                }

                if (known)
                {
                    alreadyInstrumented++;
                    continue;
                }

                try
                {
                    InstrumentationHarmony.Patch(
                        patchMethod,
                        prefix: new HarmonyMethod(
                            typeof(FejdStartupAttributionProfiler),
                            nameof(ProfiledCallbackPrefix))
                        {
                            priority = int.MaxValue
                        },
                        finalizer: new HarmonyMethod(
                            typeof(FejdStartupAttributionProfiler),
                            nameof(ProfiledCallbackFinalizer))
                        {
                            priority = int.MinValue
                        });
                    installed++;
                }
                catch (Exception ex)
                {
                    failed++;
                    lock (Lock)
                    {
                        InstrumentedMethods.Remove(patchMethod);
                        CallbackOwners.Remove(patchMethod);
                    }

                    ProfilerLog.WriteLine(
                        "FejdStartup attribution warning: could not instrument " +
                        FormatMethodName(patchMethod) +
                        ": " +
                        ex.Message);
                }
            }
        }

        FinishPreparation(
            candidates,
            installed,
            alreadyInstrumented,
            skipped,
            failed,
            started,
            entryRefresh);
    }

    private static void FinishPreparation(
        int candidates,
        int installed,
        int alreadyInstrumented,
        int skipped,
        int failed,
        long started,
        bool entryRefresh)
    {
        double elapsed = TicksToMilliseconds(
            Math.Max(0L, Stopwatch.GetTimestamp() - started));
        lock (Lock)
        {
            _preparation = new PreparationSummary(
                attempted: true,
                _preparation.Scans + 1,
                _preparation.Candidates + candidates,
                _preparation.Installed + installed,
                _preparation.AlreadyInstrumented + alreadyInstrumented,
                _preparation.Skipped + skipped,
                _preparation.Failed + failed,
                _preparation.ElapsedMilliseconds + elapsed);
        }

        ProfilerLog.WriteLine(
            "Scoped FejdStartup.Awake attribution " +
            (entryRefresh ? "entry refresh" : "early pass") +
            " completed: " +
            $"candidates={candidates}, installed={installed}, " +
            $"existing={alreadyInstrumented}, skipped={skipped}, " +
            $"failed={failed}, setup={TimelineProfiler.FormatSeconds(elapsed)}.");
    }

    private static void ProfiledCallbackPrefix(
        MethodBase __originalMethod,
        out CallbackState? __state)
    {
        __state = null;
        if (_activeTargetDepth <= 0)
        {
            return;
        }

        long prefixEntered = Stopwatch.GetTimestamp();
        CallbackState? state = null;
        try
        {
            if (!CallbackOwners.TryGetValue(
                    __originalMethod,
                    out PluginIdentity identity))
            {
                return;
            }

            Stack<CallbackState> callbacks =
                _activeCallbacks ??= new Stack<CallbackState>();
            bool recursive = callbacks.Any(
                candidate =>
                    candidate.Method.Equals(__originalMethod));
            state = new CallbackState(
                __originalMethod,
                identity,
                prefixEntered,
                recursive);
            callbacks.Push(state);

            // Start body timing as late as possible so our own lookup,
            // allocation, recursion check, and stack update are excluded.
            long callbackStarted = Stopwatch.GetTimestamp();
            state.StartBody(callbackStarted);
            __state = state;
        }
        catch
        {
            if (state != null)
            {
                RemoveActiveCallback(state, out _, out _);
            }

            RecordRuntimeFailure();
            __state = null;
        }
    }

    private static Exception? ProfiledCallbackFinalizer(
        CallbackState? __state,
        Exception? __exception)
    {
        if (__state == null)
        {
            return __exception;
        }

        long callbackEnded = Stopwatch.GetTimestamp();
        CallbackState? parent = null;
        bool removed = false;
        int discardedCallbacks = 0;
        try
        {
            long bodyTicks = Math.Max(
                0L,
                callbackEnded - __state.BodyStartedTimestamp);
            removed = RemoveActiveCallback(
                __state,
                out parent,
                out discardedCallbacks);
            if (removed)
            {
                long exclusiveTicks = Math.Max(
                    0L,
                    bodyTicks - __state.ChildInvocationTicks);
                lock (Lock)
                {
                    if (!PluginTimings.TryGetValue(
                            __state.Identity.Key,
                            out PluginAggregate aggregate))
                    {
                        aggregate = new PluginAggregate(__state.Identity);
                        PluginTimings[__state.Identity.Key] = aggregate;
                    }

                    aggregate.Add(exclusiveTicks);
                }
            }
            else
            {
                // The callback body still completed, but its nesting context is
                // no longer trustworthy. Skip attribution instead of risking a
                // duplicate/overlapping total.
                discardedCallbacks = Math.Max(1, discardedCallbacks);
            }
        }
        catch
        {
            RecordRuntimeFailure();
        }
        finally
        {
            long finalizerEnded = Stopwatch.GetTimestamp();
            long prefixTicks = Math.Max(
                0L,
                __state.BodyStartedTimestamp -
                __state.PrefixEnteredTimestamp);
            long finalizerTicks = Math.Max(
                0L,
                finalizerEnded - callbackEnded);
            long invocationTicks = Math.Max(
                0L,
                finalizerEnded - __state.PrefixEnteredTimestamp);

            if (removed && parent != null)
            {
                parent.ChildInvocationTicks += invocationTicks;
            }

            lock (Lock)
            {
                _runtime.AddInvocation(
                    prefixTicks,
                    finalizerTicks,
                    __state.Recursive);
                if (discardedCallbacks > 0)
                {
                    _runtime.AddStackRecovery(discardedCallbacks);
                }
            }
        }

        // The profiler must never replace or suppress the callback's exception.
        return __exception;
    }

    private static bool RemoveActiveCallback(
        CallbackState state,
        out CallbackState? parent,
        out int discardedCallbacks)
    {
        parent = null;
        discardedCallbacks = 0;
        if (_activeCallbacks == null || _activeCallbacks.Count == 0)
        {
            return false;
        }

        if (ReferenceEquals(_activeCallbacks.Peek(), state))
        {
            _activeCallbacks.Pop();
            if (_activeCallbacks.Count > 0)
            {
                parent = _activeCallbacks.Peek();
            }

            return true;
        }

        // A callback/finalizer ordering mismatch should not poison later
        // measurements. Discard only frames above this state and preserve a
        // valid parent if one exists.
        CallbackState[] callbacks = _activeCallbacks.ToArray();
        int stateIndex = Array.FindIndex(
            callbacks,
            candidate => ReferenceEquals(candidate, state));
        if (stateIndex < 0)
        {
            return false;
        }

        discardedCallbacks = stateIndex;
        _activeCallbacks.Clear();
        for (int i = callbacks.Length - 1; i > stateIndex; i--)
        {
            _activeCallbacks.Push(callbacks[i]);
        }

        if (_activeCallbacks.Count > 0)
        {
            parent = _activeCallbacks.Peek();
        }

        return true;
    }

    private static IEnumerable<Patch> EnumerateInvocationPatches(
        Patches patches)
    {
        foreach (Patch patch in patches.Prefixes)
        {
            yield return patch;
        }

        foreach (Patch patch in patches.Postfixes)
        {
            yield return patch;
        }

        foreach (Patch patch in patches.Finalizers)
        {
            yield return patch;
        }
    }

    private static bool CanInstrument(MethodBase method)
    {
        if (Target != null && Target.Equals(method) ||
            method is not MethodInfo methodInfo ||
            method is DynamicMethod ||
            method.DeclaringType == null ||
            method.DeclaringType.ContainsGenericParameters ||
            method.ContainsGenericParameters ||
            method.IsAbstract)
        {
            return false;
        }

        Assembly assembly = method.Module.Assembly;
        if (assembly.IsDynamic ||
            assembly == typeof(FejdStartupAttributionProfiler).Assembly)
        {
            return false;
        }

        string assemblyName = assembly.GetName().Name ?? string.Empty;
        if (assemblyName.Equals(
                "0Harmony",
                StringComparison.OrdinalIgnoreCase) ||
            assemblyName.StartsWith(
                "BepInEx",
                StringComparison.OrdinalIgnoreCase) ||
            assemblyName.StartsWith(
                "MonoMod",
                StringComparison.OrdinalIgnoreCase) ||
            assemblyName.StartsWith(
                "Mono.Cecil",
                StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        string typeName = method.DeclaringType.FullName ?? string.Empty;
        if (typeName.StartsWith("HarmonyLib.", StringComparison.Ordinal) ||
            typeName.StartsWith("BepInEx.", StringComparison.Ordinal) ||
            typeName.StartsWith("MonoMod.", StringComparison.Ordinal) ||
            typeName.StartsWith("Mono.Cecil.", StringComparison.Ordinal) ||
            methodInfo.Name.StartsWith("DMD<", StringComparison.Ordinal))
        {
            return false;
        }

        try
        {
            return methodInfo.GetMethodBody() != null;
        }
        catch
        {
            return false;
        }
    }

    private static void RecordRuntimeFailure()
    {
        lock (Lock)
        {
            _runtime.AddFailure();
        }
    }

    private static void RecordStackRecovery(int discardedCallbacks)
    {
        lock (Lock)
        {
            _runtime.AddStackRecovery(discardedCallbacks);
        }
    }

    private static string FormatMethodName(MethodBase method)
    {
        return (method.DeclaringType?.FullName ?? "<dynamic>") +
               "." +
               method.Name;
    }

    private static double TicksToMilliseconds(long ticks)
    {
        return ticks * 1000d / Stopwatch.Frequency;
    }

    private sealed class PluginResolver
    {
        private readonly Dictionary<Assembly, List<PluginIdentity>> _byAssembly;
        private readonly Dictionary<string, PluginIdentity> _byGuid;

        private PluginResolver(
            Dictionary<Assembly, List<PluginIdentity>> byAssembly,
            Dictionary<string, PluginIdentity> byGuid)
        {
            _byAssembly = byAssembly;
            _byGuid = byGuid;
        }

        internal static PluginResolver Create()
        {
            Dictionary<Assembly, List<PluginIdentity>> byAssembly = new();
            Dictionary<string, PluginIdentity> byGuid =
                new(StringComparer.Ordinal);
            foreach (PluginInfo pluginInfo in Chainloader.PluginInfos.Values)
            {
                try
                {
                    string guid = pluginInfo.Metadata.GUID;
                    string name = pluginInfo.Metadata.Name;
                    PluginIdentity identity = new(guid, name);
                    byGuid[guid] = identity;

                    BaseUnityPlugin? instance = pluginInfo.Instance;
                    if (instance == null)
                    {
                        continue;
                    }

                    Assembly assembly = instance.GetType().Assembly;
                    if (!byAssembly.TryGetValue(
                            assembly,
                            out List<PluginIdentity> identities))
                    {
                        identities = new List<PluginIdentity>();
                        byAssembly[assembly] = identities;
                    }

                    identities.Add(identity);
                }
                catch
                {
                    // One malformed PluginInfo must not disable attribution
                    // for the remaining loaded plugins.
                }
            }

            return new PluginResolver(byAssembly, byGuid);
        }

        internal PluginIdentity Resolve(
            MethodBase method,
            string? owner)
        {
            string normalizedOwner =
                string.IsNullOrWhiteSpace(owner) ? string.Empty : owner!;
            Assembly assembly = method.Module.Assembly;
            if (_byAssembly.TryGetValue(
                    assembly,
                    out List<PluginIdentity> identities))
            {
                if (identities.Count == 1)
                {
                    return identities[0];
                }

                PluginIdentity matching = identities.FirstOrDefault(
                    identity =>
                        string.Equals(
                            identity.Key,
                            normalizedOwner,
                            StringComparison.Ordinal));
                if (!string.IsNullOrEmpty(matching.Key))
                {
                    return matching;
                }

                string assemblyName =
                    assembly.GetName().Name ?? "<unknown assembly>";
                return new PluginIdentity(
                    "assembly:" + assembly.FullName,
                    assemblyName);
            }

            if (!string.IsNullOrEmpty(normalizedOwner) &&
                _byGuid.TryGetValue(
                    normalizedOwner,
                    out PluginIdentity ownerIdentity))
            {
                return ownerIdentity;
            }

            string fallbackAssembly =
                assembly.GetName().Name ?? "<unknown assembly>";
            return !string.IsNullOrEmpty(normalizedOwner)
                ? new PluginIdentity(
                    "owner:" +
                    normalizedOwner +
                    "|assembly:" +
                    fallbackAssembly,
                    normalizedOwner)
                : new PluginIdentity(
                    "assembly:" + assembly.FullName,
                    fallbackAssembly);
        }
    }

    private sealed class CallbackState
    {
        internal CallbackState(
            MethodBase method,
            PluginIdentity identity,
            long prefixEnteredTimestamp,
            bool recursive)
        {
            Method = method;
            Identity = identity;
            PrefixEnteredTimestamp = prefixEnteredTimestamp;
            Recursive = recursive;
        }

        internal MethodBase Method { get; }
        internal PluginIdentity Identity { get; }
        internal long PrefixEnteredTimestamp { get; }
        internal bool Recursive { get; }
        internal long BodyStartedTimestamp { get; private set; }
        internal long ChildInvocationTicks { get; set; }

        internal void StartBody(long timestamp)
        {
            BodyStartedTimestamp = timestamp;
        }
    }

    private sealed class PluginAggregate
    {
        private long _totalTicks;
        private long _maximumTicks;
        private int _invocations;

        internal PluginAggregate(PluginIdentity identity)
        {
            Identity = identity;
        }

        private PluginIdentity Identity { get; }

        internal void Add(long elapsedTicks)
        {
            _totalTicks += elapsedTicks;
            _maximumTicks = Math.Max(_maximumTicks, elapsedTicks);
            _invocations++;
        }

        internal PluginSnapshot Snapshot()
        {
            return new PluginSnapshot(
                Identity,
                _invocations,
                _totalTicks,
                _maximumTicks);
        }
    }

    private sealed class RuntimeAggregate
    {
        private long _prefixTicks;
        private long _finalizerTicks;
        private int _invocations;
        private int _recursiveInvocations;
        private int _stackRecoveries;
        private int _failures;

        internal void AddInvocation(
            long prefixTicks,
            long finalizerTicks,
            bool recursive)
        {
            _prefixTicks += prefixTicks;
            _finalizerTicks += finalizerTicks;
            _invocations++;
            if (recursive)
            {
                _recursiveInvocations++;
            }
        }

        internal void AddStackRecovery(int discardedCallbacks)
        {
            _stackRecoveries += Math.Max(1, discardedCallbacks);
        }

        internal void AddFailure()
        {
            _failures++;
        }

        internal RuntimeSnapshot Snapshot()
        {
            return new RuntimeSnapshot(
                _invocations,
                _recursiveInvocations,
                _stackRecoveries,
                _failures,
                TicksToMilliseconds(_prefixTicks + _finalizerTicks));
        }
    }

    private readonly struct PluginIdentity
    {
        internal PluginIdentity(string key, string displayName)
        {
            Key = key;
            DisplayName = displayName;
        }

        internal string Key { get; }
        internal string DisplayName { get; }
    }

    private readonly struct PluginSnapshot
    {
        internal PluginSnapshot(
            PluginIdentity identity,
            int invocations,
            long totalTicks,
            long maximumTicks)
        {
            Identity = identity;
            Invocations = invocations;
            TotalTicks = totalTicks;
            MaximumTicks = maximumTicks;
        }

        internal PluginIdentity Identity { get; }
        internal int Invocations { get; }
        internal long TotalTicks { get; }
        internal long MaximumTicks { get; }
    }

    private readonly struct PreparationSummary
    {
        internal PreparationSummary(
            bool attempted,
            int scans,
            int candidates,
            int installed,
            int alreadyInstrumented,
            int skipped,
            int failed,
            double elapsedMilliseconds)
        {
            Attempted = attempted;
            Scans = scans;
            Candidates = candidates;
            Installed = installed;
            AlreadyInstrumented = alreadyInstrumented;
            Skipped = skipped;
            Failed = failed;
            ElapsedMilliseconds = elapsedMilliseconds;
        }

        internal bool Attempted { get; }
        internal int Scans { get; }
        internal int Candidates { get; }
        internal int Installed { get; }
        internal int AlreadyInstrumented { get; }
        internal int Skipped { get; }
        internal int Failed { get; }
        internal double ElapsedMilliseconds { get; }
    }

    private readonly struct RuntimeSnapshot
    {
        internal RuntimeSnapshot(
            int invocations,
            int recursiveInvocations,
            int stackRecoveries,
            int failures,
            double bookkeepingMilliseconds)
        {
            Invocations = invocations;
            RecursiveInvocations = recursiveInvocations;
            StackRecoveries = stackRecoveries;
            Failures = failures;
            BookkeepingMilliseconds = bookkeepingMilliseconds;
        }

        internal int Invocations { get; }
        internal int RecursiveInvocations { get; }
        internal int StackRecoveries { get; }
        internal int Failures { get; }
        internal double BookkeepingMilliseconds { get; }
    }
}
