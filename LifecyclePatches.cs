using System;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;

namespace LoadTimeProfiler;

internal static class LifecyclePatches
{
    private static readonly List<LifecycleTarget> Targets = BuildTargets();
    private static readonly Dictionary<MethodBase, LifecycleTarget> TargetsByMethod = BuildTargetLookup();

    internal static IEnumerable<MethodBase> GetTargets()
    {
        foreach (LifecycleTarget target in Targets)
        {
            if (!target.DedicatedStartupCompletion || LoadTimeProfilerPatcher.IsDedicatedServer)
            {
                yield return target.Method;
            }
        }
    }

    internal static void Enter(MethodBase method)
    {
        if (!LoadTimeProfilerPatcher.ProfilingEnabled || !TargetsByMethod.TryGetValue(method, out LifecycleTarget target))
        {
            return;
        }

        bool dedicatedServer = LoadTimeProfilerPatcher.IsDedicatedServer;
        if (!dedicatedServer && target.BeginsConnection)
        {
            TimelineProfiler.BeginConnection(target.Label, target.RestartsConnection);
        }

        if (target.StartupMilestone ||
            dedicatedServer && (target.ConnectionMilestone || target.DedicatedStartupCompletion))
        {
            TimelineProfiler.MarkStartup(target.Label);
        }

        if (!dedicatedServer && target.ConnectionMilestone)
        {
            TimelineProfiler.MarkConnection(target.Label);
        }

        if (!dedicatedServer && target.PreparesDeepLobbyAttribution)
        {
            DeepLobbyAttributionProfiler.PrepareForActiveSession();
        }

        LifecyclePhaseProfiler.BeginTarget(method, target.Label);
        DeepLobbyAttributionProfiler.BeginTarget(method);
    }

    internal static void Exit(MethodBase method, Exception? exception)
    {
        if (!LoadTimeProfilerPatcher.ProfilingEnabled || !TargetsByMethod.TryGetValue(method, out LifecycleTarget target))
        {
            return;
        }

        DeepLobbyAttributionProfiler.EndTarget(method);
        LifecyclePhaseProfiler.EndTarget(method);

        bool dedicatedServer = LoadTimeProfilerPatcher.IsDedicatedServer;
        bool completesStartup = !dedicatedServer && target.CompletesStartup ||
                                dedicatedServer && target.DedicatedStartupCompletion;
        if (completesStartup)
        {
            if (exception == null)
            {
                TimelineProfiler.CompleteStartup(target.Label + " complete");
            }
            else
            {
                TimelineProfiler.AbortStartup(target.Label + " failed: " + exception.GetType().Name);
            }
        }

        if (!dedicatedServer && target.CompletesConnection)
        {
            if (exception == null)
            {
                TimelineProfiler.CompleteConnection(target.Label + " local player ready");
            }
            else
            {
                TimelineProfiler.AbortConnection(target.Label + " failed: " + exception.GetType().Name);
            }
        }

        if (!dedicatedServer && target.AbortsConnection)
        {
            string status;
            try
            {
                status = ZNet.GetConnectionStatus().ToString();
            }
            catch
            {
                status = "unknown";
            }

            TimelineProfiler.AbortConnection(target.Label + " status=" + status);
        }
    }

    private static List<LifecycleTarget> BuildTargets()
    {
        List<LifecycleTarget> targets = new();

        Add(targets, typeof(FejdStartup), nameof(FejdStartup.Awake), "FejdStartup.Awake", startup: true);
        Add(targets, typeof(FejdStartup), nameof(FejdStartup.SetupGui), "FejdStartup.SetupGui", startup: true);
        Add(targets, typeof(FejdStartup), nameof(FejdStartup.SetupObjectDB), "FejdStartup.SetupObjectDB", startup: true);
        Add(targets, typeof(FejdStartup), nameof(FejdStartup.Start), "FejdStartup.Start", startup: true, completesStartup: true);

        Add(
            targets,
            typeof(FejdStartup),
            nameof(FejdStartup.JoinServer),
            "FejdStartup.JoinServer",
            connection: true,
            beginsConnection: true,
            restartsConnection: true);
        Add(
            targets,
            typeof(FejdStartup),
            nameof(FejdStartup.OnWorldStart),
            "FejdStartup.OnWorldStart",
            connection: true,
            beginsConnection: true,
            preparesDeepLobbyAttribution: true);
        Add(targets, typeof(FejdStartup), nameof(FejdStartup.TransitionToMainScene), "FejdStartup.TransitionToMainScene", connection: true);
        Add(targets, typeof(FejdStartup), nameof(FejdStartup.LoadMainScene), "FejdStartup.LoadMainScene", connection: true);
        Add(targets, typeof(FejdStartup), nameof(FejdStartup.ShowConnectError), "FejdStartup.ShowConnectError", connection: true, abortsConnection: true);

        Add(targets, typeof(Game), nameof(Game.Awake), "Game.Awake", connection: true);
        Add(targets, typeof(ZoneSystem), nameof(ZoneSystem.Awake), "ZoneSystem.Awake", connection: true);
        Add(targets, typeof(ZNet), nameof(ZNet.Awake), "ZNet.Awake", connection: true);
        Add(targets, typeof(ZNetScene), nameof(ZNetScene.Awake), "ZNetScene.Awake", connection: true);
        Add(targets, typeof(ObjectDB), nameof(ObjectDB.Awake), "ObjectDB.Awake", connection: true);
        Add(targets, typeof(Game), nameof(Game.Start), "Game.Start", connection: true);
        Add(targets, typeof(ZoneSystem), nameof(ZoneSystem.Start), "ZoneSystem.Start", connection: true);
        Add(targets, typeof(DungeonDB), nameof(DungeonDB.Start), "DungeonDB.Start", connection: true);
        Add(targets, typeof(ZNet), nameof(ZNet.Start), "ZNet.Start", connection: true);
        Add(
            targets,
            typeof(ZNet),
            "OnGenerationFinished",
            "ZNet.OnGenerationFinished",
            dedicatedStartupCompletion: true);
        Add(targets, typeof(ZNet), nameof(ZNet.ClientConnect), "ZNet.ClientConnect", connection: true);
        Add(targets, typeof(ZNet), nameof(ZNet.OnNewConnection), "ZNet.OnNewConnection", connection: true);
        Add(targets, typeof(ZNet), "RPC_PeerInfo", "ZNet.RPC_PeerInfo", connection: true);
        Add(targets, typeof(Game), nameof(Game.RequestRespawn), "Game.RequestRespawn", connection: true);
        Add(targets, typeof(Game), nameof(Game.SpawnPlayer), "Game.SpawnPlayer", connection: true, completesConnection: true);

        return targets;
    }

    private static Dictionary<MethodBase, LifecycleTarget> BuildTargetLookup()
    {
        Dictionary<MethodBase, LifecycleTarget> lookup = new();
        foreach (LifecycleTarget target in Targets)
        {
            lookup[target.Method] = target;
        }

        return lookup;
    }

    private static void Add(
        List<LifecycleTarget> targets,
        Type type,
        string methodName,
        string label,
        bool startup = false,
        bool connection = false,
        bool beginsConnection = false,
        bool restartsConnection = false,
        bool preparesDeepLobbyAttribution = false,
        bool completesStartup = false,
        bool dedicatedStartupCompletion = false,
        bool completesConnection = false,
        bool abortsConnection = false)
    {
        MethodBase? method = AccessTools.Method(type, methodName);
        if (method == null)
        {
            ProfilerLog.WriteLine("Target warning: could not find " + type.FullName + "." + methodName + ".");
            return;
        }

        targets.Add(new LifecycleTarget(
            method,
            label,
            startup,
            connection,
            beginsConnection,
            restartsConnection,
            preparesDeepLobbyAttribution,
            completesStartup,
            dedicatedStartupCompletion,
            completesConnection,
            abortsConnection));
    }

    private sealed class LifecycleTarget
    {
        internal LifecycleTarget(
            MethodBase method,
            string label,
            bool startupMilestone,
            bool connectionMilestone,
            bool beginsConnection,
            bool restartsConnection,
            bool preparesDeepLobbyAttribution,
            bool completesStartup,
            bool dedicatedStartupCompletion,
            bool completesConnection,
            bool abortsConnection)
        {
            Method = method;
            Label = label;
            StartupMilestone = startupMilestone;
            ConnectionMilestone = connectionMilestone;
            BeginsConnection = beginsConnection;
            RestartsConnection = restartsConnection;
            PreparesDeepLobbyAttribution = preparesDeepLobbyAttribution;
            CompletesStartup = completesStartup;
            DedicatedStartupCompletion = dedicatedStartupCompletion;
            CompletesConnection = completesConnection;
            AbortsConnection = abortsConnection;
        }

        internal MethodBase Method { get; }
        internal string Label { get; }
        internal bool StartupMilestone { get; }
        internal bool ConnectionMilestone { get; }
        internal bool BeginsConnection { get; }
        internal bool RestartsConnection { get; }
        internal bool PreparesDeepLobbyAttribution { get; }
        internal bool CompletesStartup { get; }
        internal bool DedicatedStartupCompletion { get; }
        internal bool CompletesConnection { get; }
        internal bool AbortsConnection { get; }
    }
}

internal static class LoadTimeProfilerLifecyclePatch
{
    internal static void Prefix(MethodBase __originalMethod)
    {
        LifecyclePatches.Enter(__originalMethod);
    }

    internal static Exception? Finalizer(MethodBase __originalMethod, Exception? __exception)
    {
        LifecyclePatches.Exit(__originalMethod, __exception);
        return __exception;
    }
}
