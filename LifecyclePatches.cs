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

    internal static void Enter(
        MethodBase method,
        object[] arguments)
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

        if (!dedicatedServer && target.ObservesConnectionLogout)
        {
            ObserveConnectionLogout();
        }

        if (!dedicatedServer && target.MarksFailureDecisionFallback)
        {
            ObserveConnectionErrorDisplay(arguments);
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
            DeepLobbyAttributionProfiler.PrepareForActiveSession(method);
        }

        FejdStartupAttributionProfiler.BeginTarget(method);
        LifecyclePhaseProfiler.BeginTarget(method, target.Label);
        DeepLobbyAttributionProfiler.BeginTarget(method);
    }

    internal static void Exit(
        MethodBase method,
        Exception? exception)
    {
        if (!LoadTimeProfilerPatcher.ProfilingEnabled || !TargetsByMethod.TryGetValue(method, out LifecycleTarget target))
        {
            return;
        }

        DeepLobbyAttributionProfiler.EndTarget(method);
        LifecyclePhaseProfiler.EndTarget(method);
        FejdStartupAttributionProfiler.EndTarget(method);

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
                TimelineProfiler.CompleteConnection(
                    target.Label + " local player ready");
            }
            else
            {
                TimelineProfiler.AbortConnection(target.Label + " failed: " + exception.GetType().Name);
            }
        }

        if (!dedicatedServer && target.AbortsConnection)
        {
            TimelineProfiler.CancelConnection(
                target.Label + " status=" + GetConnectionStatus());
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
            nameof(FejdStartup.TransitionToMainScene),
            "FejdStartup.TransitionToMainScene",
            connection: true,
            beginsConnection: true,
            restartsConnection: true,
            preparesDeepLobbyAttribution: true);
        Add(targets, typeof(FejdStartup), nameof(FejdStartup.LoadMainScene), "FejdStartup.LoadMainScene", connection: true);
        Add(
            targets,
            typeof(FejdStartup),
            nameof(FejdStartup.ShowConnectError),
            "FejdStartup.ShowConnectError",
            connection: true,
            marksFailureDecisionFallback: true,
            abortsConnection: true);

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
        Add(
            targets,
            typeof(Game),
            nameof(Game.Logout),
            "Game.Logout",
            connection: true,
            observesConnectionLogout: true);
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
        bool observesConnectionLogout = false,
        bool marksFailureDecisionFallback = false,
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
            observesConnectionLogout,
            marksFailureDecisionFallback,
            abortsConnection));
    }

    private static void ObserveConnectionLogout()
    {
        if (!TimelineProfiler.IsActive(ProfileSession.Connection))
        {
            return;
        }

        // ServerSync and AzuAntiCheat set ErrorVersion immediately after
        // Game.Logout returns, so this hook records a candidate but never
        // closes the session from the still-benign prefix state.
        try
        {
            if (ZNet.m_loadError)
            {
                const string observation = "Game.Logout WorldLoadError";
                TimelineProfiler.MarkConnectionLogoutCandidate(observation);
                TimelineProfiler.ConfirmConnectionFailureDecision(observation);
                return;
            }

            ZNet.ConnectionStatus status = ZNet.GetConnectionStatus();
            string statusObservation = "Game.Logout status=" + status;
            TimelineProfiler.MarkConnectionLogoutCandidate(statusObservation);
            if (IsTerminalConnectionStatus(status))
            {
                TimelineProfiler.ConfirmConnectionFailureDecision(
                    statusObservation);
            }
        }
        catch (Exception ex)
        {
            TimelineProfiler.MarkConnectionLogoutCandidate(
                "Game.Logout status check failed: " + ex.GetType().Name);
        }
    }

    private static void ObserveConnectionErrorDisplay(object[] arguments)
    {
        if (!TimelineProfiler.IsActive(ProfileSession.Connection))
        {
            return;
        }

        ZNet.ConnectionStatus? suppliedStatus =
            arguments.Length > 0 &&
            arguments[0] is ZNet.ConnectionStatus statusArgument
                ? statusArgument
                : null;
        try
        {
            // FejdStartup.Start calls ShowConnectError(None) on every lobby
            // entry. Only a terminal supplied/current state confirms failure.
            if (ZNet.m_loadError)
            {
                TimelineProfiler.ConfirmConnectionFailureDecision(
                    "FejdStartup.ShowConnectError status=WorldLoadError");
                return;
            }

            if (suppliedStatus.HasValue &&
                IsTerminalConnectionStatus(suppliedStatus.Value))
            {
                TimelineProfiler.ConfirmConnectionFailureDecision(
                    "FejdStartup.ShowConnectError status=" +
                    suppliedStatus.Value);
                return;
            }

            ZNet.ConnectionStatus currentStatus = ZNet.GetConnectionStatus();
            if (IsTerminalConnectionStatus(currentStatus))
            {
                TimelineProfiler.ConfirmConnectionFailureDecision(
                    "FejdStartup.ShowConnectError status=" +
                    currentStatus);
            }
        }
        catch (Exception ex)
        {
            if (suppliedStatus.HasValue &&
                IsTerminalConnectionStatus(suppliedStatus.Value))
            {
                TimelineProfiler.ConfirmConnectionFailureDecision(
                    "FejdStartup.ShowConnectError status=" +
                    suppliedStatus.Value +
                    " (state check failed: " +
                    ex.GetType().Name +
                    ")");
            }
        }
    }

    private static bool IsTerminalConnectionStatus(
        ZNet.ConnectionStatus status)
    {
        return status != ZNet.ConnectionStatus.None &&
               status != ZNet.ConnectionStatus.Connecting &&
               status != ZNet.ConnectionStatus.Connected;
    }

    private static string GetConnectionStatus()
    {
        try
        {
            return ZNet.m_loadError
                ? "WorldLoadError"
                : ZNet.GetConnectionStatus().ToString();
        }
        catch
        {
            return "unknown";
        }
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
            bool observesConnectionLogout,
            bool marksFailureDecisionFallback,
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
            ObservesConnectionLogout = observesConnectionLogout;
            MarksFailureDecisionFallback = marksFailureDecisionFallback;
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
        internal bool ObservesConnectionLogout { get; }
        internal bool MarksFailureDecisionFallback { get; }
        internal bool AbortsConnection { get; }
    }
}

internal static class LoadTimeProfilerLifecyclePatch
{
    internal static void Prefix(
        MethodBase __originalMethod,
        object[] __args)
    {
        LifecyclePatches.Enter(
            __originalMethod,
            __args);
    }

    internal static Exception? Finalizer(
        MethodBase __originalMethod,
        Exception? __exception)
    {
        LifecyclePatches.Exit(
            __originalMethod,
            __exception);
        return __exception;
    }
}
