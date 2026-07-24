using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using BepInEx;
using BepInEx.Bootstrap;
using HarmonyLib;
using UnityEngine;

namespace LoadTimeProfiler;

internal static class ChainloaderProfiler
{
    private static readonly object Lock = new();
    private static readonly Harmony PluginStartHarmony = new(LoadTimeProfilerPatcher.ModGUID + ".plugin-start");
    private static readonly Dictionary<string, MutableTiming> Initializations = new(StringComparer.Ordinal);
    private static readonly Dictionary<string, MutableTiming> Starts = new(StringComparer.Ordinal);
    private static readonly Dictionary<MethodBase, PluginIdentity> StartMethods = new();
    private static readonly HashSet<MethodBase> InstrumentedStartMethods = new();
    private static bool _chainloaderActive;
    private static long _chainloaderStarted;
    private static double _preChainloaderMilliseconds;
    private static double _chainloaderMilliseconds;

    internal static void ResetSession()
    {
        lock (Lock)
        {
            Initializations.Clear();
            Starts.Clear();
            _chainloaderActive = false;
            _chainloaderStarted = 0L;
            _preChainloaderMilliseconds = 0d;
            _chainloaderMilliseconds = 0d;
        }
    }

    internal static void BeginChainloader()
    {
        if (!LoadTimeProfilerPatcher.ProfilingEnabled)
        {
            return;
        }

        lock (Lock)
        {
            _chainloaderActive = true;
            _chainloaderStarted = Stopwatch.GetTimestamp();
            _preChainloaderMilliseconds = TimelineProfiler.GetElapsedSincePatcherStart();
        }

        TimelineProfiler.MarkStartup("BepInEx.Chainloader.Start");
    }

    internal static void EndChainloader()
    {
        long end = Stopwatch.GetTimestamp();
        lock (Lock)
        {
            if (_chainloaderStarted > 0L)
            {
                _chainloaderMilliseconds = TicksToMilliseconds(end - _chainloaderStarted);
                _chainloaderStarted = 0L;
            }

            _chainloaderActive = false;
        }

        TimelineProfiler.MarkStartup("BepInEx.Chainloader.Start complete");
    }

    internal static PluginInitializationState? BeginPlugin(GameObject gameObject, Type componentType)
    {
        if (!LoadTimeProfilerPatcher.ProfilingEnabled || !typeof(BaseUnityPlugin).IsAssignableFrom(componentType))
        {
            return null;
        }

        lock (Lock)
        {
            if (!_chainloaderActive || !ReferenceEquals(gameObject, Chainloader.ManagerObject))
            {
                return null;
            }
        }

        return new PluginInitializationState(componentType, ResolveIdentity(componentType), Stopwatch.GetTimestamp());
    }

    internal static void CompletePlugin(PluginInitializationState? state)
    {
        if (state == null || state.Completed)
        {
            return;
        }

        state.Completed = true;
        double elapsed = TicksToMilliseconds(Stopwatch.GetTimestamp() - state.StartTimestamp);
        lock (Lock)
        {
            Add(Initializations, state.Identity.Key, state.Identity, elapsed);
        }

        InstrumentStart(state.ComponentType, state.Identity);
    }

    internal static void AppendStartupReport(StringBuilder builder)
    {
        TimingSnapshot[] initializations;
        TimingSnapshot[] starts;
        double preChainloaderMilliseconds;
        double chainloaderMilliseconds;
        lock (Lock)
        {
            initializations = Initializations.Values.Select(value => value.Snapshot()).ToArray();
            starts = Starts.Values.Select(value => value.Snapshot()).ToArray();
            preChainloaderMilliseconds = _preChainloaderMilliseconds;
            chainloaderMilliseconds = _chainloaderMilliseconds;
        }

        builder.AppendLine("BepInEx startup:");
        builder.Append("  Before Chainloader.Start (includes Chainloader.Initialize): ")
            .AppendLine(TimelineProfiler.FormatDuration(preChainloaderMilliseconds));
        builder.Append("  Chainloader.Start: ").AppendLine(TimelineProfiler.FormatDuration(chainloaderMilliseconds));

        builder.AppendLine("Plugin construction/Awake/OnEnable:");
        AppendTimings(builder, initializations);

        builder.AppendLine("Plugin Start methods:");
        AppendTimings(builder, starts);

        double initializationTotal = initializations.Sum(value => value.ElapsedMilliseconds);
        double chainloaderRemainder = Math.Max(0d, chainloaderMilliseconds - initializationTotal);
        builder.Append("  Chainloader scan/load/dependency remainder: ")
            .AppendLine(TimelineProfiler.FormatDuration(chainloaderRemainder));
    }

    private static void AppendTimings(StringBuilder builder, TimingSnapshot[] timings)
    {
        if (timings.Length == 0)
        {
            builder.AppendLine("  No callbacks were measured.");
            return;
        }

        foreach (TimingSnapshot timing in timings.OrderByDescending(value => value.ElapsedMilliseconds))
        {
            builder.Append("  ").Append(TimelineProfiler.FormatSeconds(timing.ElapsedMilliseconds));
            if (timing.Count > 1)
            {
                builder.Append(" x").Append(timing.Count);
            }

            builder.Append(": ").AppendLine(timing.Identity.DisplayName);
        }
    }

    private static void InstrumentStart(Type componentType, PluginIdentity identity)
    {
        MethodInfo? start = componentType.GetMethod(
            "Start",
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly,
            binder: null,
            types: Type.EmptyTypes,
            modifiers: null);
        if (start == null || start.IsAbstract || start.ContainsGenericParameters)
        {
            return;
        }

        lock (Lock)
        {
            if (!InstrumentedStartMethods.Add(start))
            {
                return;
            }

            StartMethods[start] = identity;
        }

        try
        {
            HarmonyMethod prefix = new(typeof(ChainloaderProfiler), nameof(ProfiledStartPrefix))
            {
                priority = int.MaxValue
            };
            HarmonyMethod finalizer = new(typeof(ChainloaderProfiler), nameof(ProfiledStartFinalizer))
            {
                priority = int.MinValue
            };
            PluginStartHarmony.Patch(start, prefix: prefix, finalizer: finalizer);
        }
        catch (Exception ex)
        {
            lock (Lock)
            {
                InstrumentedStartMethods.Remove(start);
                StartMethods.Remove(start);
            }

            ProfilerLog.WriteLine($"Instrumentation warning: could not profile plugin Start '{componentType.FullName}': {ex.Message}");
        }
    }

    private static void ProfiledStartPrefix(out long __state)
    {
        __state = 0L;
        if (!LoadTimeProfilerPatcher.ProfilingEnabled || !TimelineProfiler.IsActive(ProfileSession.Startup))
        {
            return;
        }

        __state = Stopwatch.GetTimestamp();
    }

    private static Exception? ProfiledStartFinalizer(MethodBase __originalMethod, long __state, Exception? __exception)
    {
        if (__state <= 0L)
        {
            return __exception;
        }

        long ended = Stopwatch.GetTimestamp();
        double elapsed = TicksToMilliseconds(ended - __state);
        lock (Lock)
        {
            if (StartMethods.TryGetValue(__originalMethod, out PluginIdentity identity))
            {
                Add(Starts, identity.Key, identity, elapsed);
            }
        }

        return __exception;
    }

    private static PluginIdentity ResolveIdentity(Type componentType)
    {
        BepInPlugin? metadata = componentType
            .GetCustomAttributes(typeof(BepInPlugin), inherit: false)
            .OfType<BepInPlugin>()
            .FirstOrDefault();
        string guid = metadata?.GUID ?? componentType.FullName ?? componentType.Name;
        string name = metadata?.Name ?? componentType.Name;
        return new PluginIdentity(guid, name);
    }

    private static void Add(
        Dictionary<string, MutableTiming> timings,
        string key,
        PluginIdentity identity,
        double elapsedMilliseconds)
    {
        if (!timings.TryGetValue(key, out MutableTiming timing))
        {
            timing = new MutableTiming(identity);
            timings[key] = timing;
        }

        timing.Add(elapsedMilliseconds);
    }

    private static double TicksToMilliseconds(long ticks)
    {
        return ticks * 1000d / Stopwatch.Frequency;
    }

    internal sealed class PluginInitializationState
    {
        internal PluginInitializationState(Type componentType, PluginIdentity identity, long startTimestamp)
        {
            ComponentType = componentType;
            Identity = identity;
            StartTimestamp = startTimestamp;
        }

        internal Type ComponentType { get; }
        internal PluginIdentity Identity { get; }
        internal long StartTimestamp { get; }
        internal bool Completed { get; set; }
    }

    internal readonly struct PluginIdentity
    {
        internal PluginIdentity(string key, string displayName)
        {
            Key = key;
            DisplayName = displayName;
        }

        internal string Key { get; }
        internal string DisplayName { get; }
    }

    private sealed class MutableTiming
    {
        internal MutableTiming(PluginIdentity identity)
        {
            Identity = identity;
        }

        private PluginIdentity Identity { get; }
        private int Count { get; set; }
        private double ElapsedMilliseconds { get; set; }

        internal void Add(double elapsedMilliseconds)
        {
            Count++;
            ElapsedMilliseconds += elapsedMilliseconds;
        }

        internal TimingSnapshot Snapshot()
        {
            return new TimingSnapshot(Identity, Count, ElapsedMilliseconds);
        }
    }

    private readonly struct TimingSnapshot
    {
        internal TimingSnapshot(PluginIdentity identity, int count, double elapsedMilliseconds)
        {
            Identity = identity;
            Count = count;
            ElapsedMilliseconds = elapsedMilliseconds;
        }

        internal PluginIdentity Identity { get; }
        internal int Count { get; }
        internal double ElapsedMilliseconds { get; }
    }
}

internal static class LoadTimeProfilerPluginInitializationPatch
{
    internal static void Prefix(GameObject __instance, Type componentType, out ChainloaderProfiler.PluginInitializationState? __state)
    {
        __state = ChainloaderProfiler.BeginPlugin(__instance, componentType);
    }

    internal static void Postfix(ChainloaderProfiler.PluginInitializationState? __state)
    {
        ChainloaderProfiler.CompletePlugin(__state);
    }

    internal static Exception? Finalizer(ChainloaderProfiler.PluginInitializationState? __state, Exception? __exception)
    {
        ChainloaderProfiler.CompletePlugin(__state);
        return __exception;
    }
}
