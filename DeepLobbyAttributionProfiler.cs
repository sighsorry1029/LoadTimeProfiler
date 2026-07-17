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

internal static class DeepLobbyAttributionProfiler
{
    private const string ObjectDbLabel = "ObjectDB.Awake";
    private const string ZNetSceneLabel = "ZNetScene.Awake";
    private const int MaximumReportedPlugins = 60;
    private static readonly object Lock = new();
    private static readonly Harmony InstrumentationHarmony = new(LoadTimeProfilerPatcher.ModGUID + ".deep-lobby-attribution");
    private static readonly Dictionary<MethodBase, string> TargetLabels = BuildTargetLabels();
    private static readonly HashSet<MethodBase> InstrumentedMethods = new();
    private static readonly Dictionary<MethodBase, PluginIdentity> CallbackOwners = new();
    private static readonly Dictionary<string, PluginAggregate> PluginTimings = new(StringComparer.Ordinal);

    [ThreadStatic]
    private static Stack<PhaseState>? _activePhases;

    [ThreadStatic]
    private static Stack<CallbackState>? _activeCallbacks;

    private static PreparationSummary _lastPreparation;

    internal static void ResetSession()
    {
        lock (Lock)
        {
            PluginTimings.Clear();
            _lastPreparation = default;
        }

        _activePhases?.Clear();
        _activeCallbacks?.Clear();
    }

    internal static void PrepareForActiveSession(MethodBase? activePreparationMethod = null)
    {
        if (!LoadTimeProfilerPatcher.ProfilingEnabled)
        {
            return;
        }

        long started = Stopwatch.GetTimestamp();
        HashSet<MethodBase> blockedMethods = LoadTimeProfilerPatcher.IsDedicatedServer
            ? new HashSet<MethodBase>()
            : GetCurrentMethodBlocklist(activePreparationMethod);
        PluginResolver resolver = PluginResolver.Create();
        HashSet<MethodBase> seenCandidates = new();
        int installed = 0;
        int alreadyInstrumented = 0;
        int skipped = 0;
        int failed = 0;

        foreach (MethodBase target in TargetLabels.Keys)
        {
            Patches? patchInfo;
            try
            {
                patchInfo = Harmony.GetPatchInfo(target);
            }
            catch (Exception ex)
            {
                failed++;
                ProfilerLog.WriteLine($"Deep attribution warning: could not inspect {FormatMethodName(target)}: {ex.Message}");
                continue;
            }

            if (patchInfo == null)
            {
                continue;
            }

            foreach (Patch patch in EnumerateInvocationPatches(patchInfo))
            {
                MethodBase? patchMethod = patch.PatchMethod;
                if (patchMethod == null || !seenCandidates.Add(patchMethod))
                {
                    continue;
                }

                if (!CanInstrument(patchMethod, blockedMethods))
                {
                    skipped++;
                    continue;
                }

                PluginIdentity identity = resolver.Resolve(patchMethod, patch.owner);
                lock (Lock)
                {
                    if (InstrumentedMethods.Contains(patchMethod))
                    {
                        alreadyInstrumented++;
                        continue;
                    }

                    InstrumentedMethods.Add(patchMethod);
                    CallbackOwners[patchMethod] = identity;
                }

                try
                {
                    InstrumentationHarmony.Patch(
                        patchMethod,
                        prefix: new HarmonyMethod(typeof(DeepLobbyAttributionProfiler), nameof(ProfiledCallbackPrefix))
                        {
                            priority = int.MaxValue
                        },
                        finalizer: new HarmonyMethod(typeof(DeepLobbyAttributionProfiler), nameof(ProfiledCallbackFinalizer))
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

                    ProfilerLog.WriteLine($"Deep attribution warning: could not instrument {FormatMethodName(patchMethod)}: {ex.Message}");
                }
            }
        }

        double elapsed = TicksToMilliseconds(Stopwatch.GetTimestamp() - started);
        lock (Lock)
        {
            _lastPreparation = new PreparationSummary(installed, alreadyInstrumented, skipped, failed, elapsed);
        }

        string scope = LoadTimeProfilerPatcher.IsDedicatedServer ? "server startup" : "deep lobby";
        ProfilerLog.WriteLine(
            $"Scoped {scope} attribution prepared: installed={installed}, existing={alreadyInstrumented}, " +
            $"skipped={skipped}, failed={failed}, setup={TimelineProfiler.FormatSeconds(elapsed)}.");
    }

    internal static void BeginTarget(MethodBase target)
    {
        ProfileSession session = LoadTimeProfilerPatcher.IsDedicatedServer
            ? ProfileSession.Startup
            : ProfileSession.Connection;
        if (!LoadTimeProfilerPatcher.ProfilingEnabled ||
            !TargetLabels.TryGetValue(target, out string label) ||
            !TimelineProfiler.IsActive(session))
        {
            return;
        }

        (_activePhases ??= new Stack<PhaseState>()).Push(new PhaseState(target, label));
    }

    internal static void EndTarget(MethodBase target)
    {
        if (_activePhases == null || _activePhases.Count == 0)
        {
            return;
        }

        PhaseState state = _activePhases.Peek();
        if (state.Target != target)
        {
            _activePhases.Clear();
            _activeCallbacks?.Clear();
            return;
        }

        _activePhases.Pop();
        _activeCallbacks?.Clear();
    }

    internal static void AppendReport(StringBuilder builder)
    {
        builder.AppendLine(LoadTimeProfilerPatcher.IsDedicatedServer
            ? "Scoped server startup attribution:"
            : "Scoped deep lobby attribution:");
        PluginSnapshot[] plugins;
        PreparationSummary preparation;
        lock (Lock)
        {
            plugins = PluginTimings.Values.Select(value => value.Snapshot()).ToArray();
            preparation = _lastPreparation;
        }

        builder.AppendLine("  Exclusive synchronous Harmony callback time in ObjectDB.Awake and ZNetScene.Awake.");
        builder.AppendLine("  Breakdown order: ObjectDB + ZNetScene.");
        builder.Append("  Prepared callbacks: installed=").Append(preparation.Installed)
            .Append(", existing=").Append(preparation.AlreadyInstrumented)
            .Append(", skipped=").Append(preparation.Skipped)
            .Append(", failed=").Append(preparation.Failed)
            .Append(", setup=").AppendLine(TimelineProfiler.FormatSeconds(preparation.ElapsedMilliseconds));

        PluginSnapshot[] ordered = plugins
            .Where(value => value.TotalMilliseconds > 0d)
            .OrderByDescending(value => value.TotalMilliseconds)
            .ThenBy(value => value.Identity.DisplayName, StringComparer.Ordinal)
            .ToArray();
        if (ordered.Length == 0)
        {
            builder.AppendLine("  No instrumented callbacks were invoked in the two scoped phases.");
        }
        else
        {
            int count = Math.Min(ordered.Length, MaximumReportedPlugins);
            for (int i = 0; i < count; i++)
            {
                PluginSnapshot plugin = ordered[i];
                double objectDb = plugin.GetPhaseMilliseconds(ObjectDbLabel);
                double zNetScene = plugin.GetPhaseMilliseconds(ZNetSceneLabel);
                builder.Append("  ").Append(TimelineProfiler.FormatSeconds(plugin.TotalMilliseconds))
                    .Append(" (").Append(TimelineProfiler.FormatSeconds(objectDb))
                    .Append(" + ").Append(TimelineProfiler.FormatSeconds(zNetScene))
                    .Append("): ").AppendLine(plugin.Identity.DisplayName);
            }

            if (ordered.Length > count)
            {
                builder.Append("  ... ").Append(ordered.Length - count).AppendLine(" more plugins omitted.");
            }
        }

    }

    private static void ProfiledCallbackPrefix(MethodBase __originalMethod, out CallbackState? __state)
    {
        __state = null;
        if (_activePhases == null || _activePhases.Count == 0)
        {
            return;
        }

        PluginIdentity identity;
        lock (Lock)
        {
            if (!CallbackOwners.TryGetValue(__originalMethod, out identity))
            {
                return;
            }
        }

        PhaseState phase = _activePhases.Peek();
        CallbackState state = new(identity, phase.Label, Stopwatch.GetTimestamp());
        (_activeCallbacks ??= new Stack<CallbackState>()).Push(state);
        __state = state;
    }

    private static Exception? ProfiledCallbackFinalizer(CallbackState? __state, Exception? __exception)
    {
        if (__state == null)
        {
            return __exception;
        }

        long elapsedTicks = Math.Max(0L, Stopwatch.GetTimestamp() - __state.StartTimestamp);
        if (TryRemoveActiveCallback(__state) && _activeCallbacks != null && _activeCallbacks.Count > 0)
        {
            _activeCallbacks.Peek().ChildTicks += elapsedTicks;
        }

        long exclusiveTicks = Math.Max(0L, elapsedTicks - __state.ChildTicks);
        double exclusiveMilliseconds = TicksToMilliseconds(exclusiveTicks);
        lock (Lock)
        {
            if (!PluginTimings.TryGetValue(__state.Identity.Key, out PluginAggregate aggregate))
            {
                aggregate = new PluginAggregate(__state.Identity);
                PluginTimings[__state.Identity.Key] = aggregate;
            }

            aggregate.Add(__state.PhaseLabel, exclusiveMilliseconds);
        }

        return __exception;
    }

    private static bool TryRemoveActiveCallback(CallbackState state)
    {
        if (_activeCallbacks == null || _activeCallbacks.Count == 0)
        {
            return false;
        }

        if (ReferenceEquals(_activeCallbacks.Peek(), state))
        {
            _activeCallbacks.Pop();
            return true;
        }

        CallbackState[] callbacks = _activeCallbacks.ToArray();
        int stateIndex = Array.FindIndex(callbacks, candidate => ReferenceEquals(candidate, state));
        if (stateIndex < 0)
        {
            return false;
        }

        _activeCallbacks.Clear();
        for (int i = callbacks.Length - 1; i > stateIndex; i--)
        {
            _activeCallbacks.Push(callbacks[i]);
        }

        return true;
    }

    private static Dictionary<MethodBase, string> BuildTargetLabels()
    {
        Dictionary<MethodBase, string> targets = new();
        AddTarget(targets, typeof(ObjectDB), nameof(ObjectDB.Awake), ObjectDbLabel);
        AddTarget(targets, typeof(ZNetScene), nameof(ZNetScene.Awake), ZNetSceneLabel);
        return targets;
    }

    private static void AddTarget(Dictionary<MethodBase, string> targets, Type type, string methodName, string label)
    {
        MethodBase? method = AccessTools.Method(type, methodName);
        if (method != null)
        {
            targets[method] = label;
        }
    }

    private static HashSet<MethodBase> GetCurrentMethodBlocklist(MethodBase? activeMethod)
    {
        HashSet<MethodBase> blocked = new();
        if (activeMethod == null)
        {
            return blocked;
        }

        blocked.Add(activeMethod);
        try
        {
            Patches? patchInfo = Harmony.GetPatchInfo(activeMethod);
            if (patchInfo != null)
            {
                foreach (Patch patch in EnumerateInvocationPatches(patchInfo))
                {
                    if (patch.PatchMethod != null)
                    {
                        blocked.Add(patch.PatchMethod);
                    }
                }
            }
        }
        catch
        {
        }

        return blocked;
    }

    private static IEnumerable<Patch> EnumerateInvocationPatches(Patches patches)
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

    private static bool CanInstrument(MethodBase method, ISet<MethodBase> blockedMethods)
    {
        if (blockedMethods.Contains(method) ||
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
        if (assembly.IsDynamic || assembly == typeof(DeepLobbyAttributionProfiler).Assembly)
        {
            return false;
        }

        string assemblyName = assembly.GetName().Name ?? string.Empty;
        if (assemblyName.Equals("0Harmony", StringComparison.OrdinalIgnoreCase) ||
            assemblyName.StartsWith("BepInEx", StringComparison.OrdinalIgnoreCase) ||
            assemblyName.StartsWith("MonoMod", StringComparison.OrdinalIgnoreCase) ||
            assemblyName.StartsWith("Mono.Cecil", StringComparison.OrdinalIgnoreCase))
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

    private static string FormatMethodName(MethodBase method)
    {
        return (method.DeclaringType?.FullName ?? "<dynamic>") + "." + method.Name;
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
            Dictionary<string, PluginIdentity> byGuid = new(StringComparer.Ordinal);
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
                    if (!byAssembly.TryGetValue(assembly, out List<PluginIdentity> identities))
                    {
                        identities = new List<PluginIdentity>();
                        byAssembly[assembly] = identities;
                    }

                    identities.Add(identity);
                }
                catch
                {
                }
            }

            return new PluginResolver(byAssembly, byGuid);
        }

        internal PluginIdentity Resolve(MethodBase method, string? owner)
        {
            string normalizedOwner = owner ?? string.Empty;
            if (string.IsNullOrWhiteSpace(normalizedOwner))
            {
                normalizedOwner = string.Empty;
            }
            Assembly assembly = method.Module.Assembly;
            if (_byAssembly.TryGetValue(assembly, out List<PluginIdentity> identities))
            {
                if (identities.Count == 1)
                {
                    return identities[0];
                }

                PluginIdentity matching = identities.FirstOrDefault(identity =>
                    string.Equals(identity.Key, normalizedOwner, StringComparison.Ordinal));
                if (!string.IsNullOrEmpty(matching.Key))
                {
                    return matching;
                }

                string assemblyName = assembly.GetName().Name ?? "<unknown assembly>";
                return new PluginIdentity("assembly:" + assembly.FullName, assemblyName);
            }

            if (!string.IsNullOrEmpty(normalizedOwner) && _byGuid.TryGetValue(normalizedOwner, out PluginIdentity ownerIdentity))
            {
                return ownerIdentity;
            }

            string fallbackAssembly = assembly.GetName().Name ?? "<unknown assembly>";
            if (!string.IsNullOrEmpty(normalizedOwner))
            {
                return new PluginIdentity(
                    "owner:" + normalizedOwner + "|assembly:" + fallbackAssembly,
                    normalizedOwner);
            }

            return new PluginIdentity("assembly:" + assembly.FullName, fallbackAssembly);
        }
    }

    private sealed class CallbackState
    {
        internal CallbackState(PluginIdentity identity, string phaseLabel, long startTimestamp)
        {
            Identity = identity;
            PhaseLabel = phaseLabel;
            StartTimestamp = startTimestamp;
        }

        internal PluginIdentity Identity { get; }
        internal string PhaseLabel { get; }
        internal long StartTimestamp { get; }
        internal long ChildTicks { get; set; }
    }

    private sealed class PhaseState
    {
        internal PhaseState(MethodBase target, string label)
        {
            Target = target;
            Label = label;
        }

        internal MethodBase Target { get; }
        internal string Label { get; }
    }

    private sealed class PluginAggregate
    {
        private readonly Dictionary<string, double> _phases = new(StringComparer.Ordinal);

        internal PluginAggregate(PluginIdentity identity)
        {
            Identity = identity;
        }

        private PluginIdentity Identity { get; }

        internal void Add(string phaseLabel, double elapsedMilliseconds)
        {
            _phases.TryGetValue(phaseLabel, out double elapsed);
            _phases[phaseLabel] = elapsed + elapsedMilliseconds;
        }

        internal PluginSnapshot Snapshot()
        {
            return new PluginSnapshot(
                Identity,
                _phases.ToDictionary(pair => pair.Key, pair => pair.Value, StringComparer.Ordinal));
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
        private readonly IReadOnlyDictionary<string, double> _phases;

        internal PluginSnapshot(PluginIdentity identity, IReadOnlyDictionary<string, double> phases)
        {
            Identity = identity;
            _phases = phases;
            TotalMilliseconds = phases.Values.Sum();
        }

        internal PluginIdentity Identity { get; }
        internal double TotalMilliseconds { get; }

        internal double GetPhaseMilliseconds(string phaseLabel)
        {
            return _phases.TryGetValue(phaseLabel, out double elapsed) ? elapsed : 0d;
        }
    }

    private readonly struct PreparationSummary
    {
        internal PreparationSummary(int installed, int alreadyInstrumented, int skipped, int failed, double elapsedMilliseconds)
        {
            Installed = installed;
            AlreadyInstrumented = alreadyInstrumented;
            Skipped = skipped;
            Failed = failed;
            ElapsedMilliseconds = elapsedMilliseconds;
        }

        internal int Installed { get; }
        internal int AlreadyInstrumented { get; }
        internal int Skipped { get; }
        internal int Failed { get; }
        internal double ElapsedMilliseconds { get; }
    }
}
