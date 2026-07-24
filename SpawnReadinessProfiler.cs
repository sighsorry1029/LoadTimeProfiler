using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using HarmonyLib;
using UnityEngine;

namespace LoadTimeProfiler;

internal static class SpawnReadinessProfiler
{
    private const int MaximumSamples = 120;
    private const int MaximumMinimapEvents = 16;
    private static readonly long SampleIntervalTicks = Stopwatch.Frequency;
    private static readonly object Lock = new();
    private static readonly List<ReadinessSample> Samples = new(MaximumSamples);
    private static readonly List<MinimapEvent> MinimapEvents =
        new(MaximumMinimapEvents);
    private static readonly List<string> Warnings = new();

    private static volatile bool _sessionActive;
    private static bool _respawnActive;
    private static volatile bool _hotPathActive;
    private static bool _findHookEnabled;
    private static bool _areaHookEnabled;
    private static bool _minimapHookEnabled;
    private static int _sessionGeneration;
    private static long _requestTicks;
    private static long _activationTicks;
    private static long _spawnStartedTicks;
    private static long _spawnCompletedTicks;
    private static long _firstFindTicks;
    private static long _findSucceededTicks;
    private static long _firstAreaCheckTicks;
    private static long _areaReadyTicks;
    private static long _zoneLoadedTicks;
    private static long _activeAreaLoadedTicks;
    private static long _builtInGateCrossedTicks;
    private static long _nextSampleTicks;
    private static long _findInclusiveTicks;
    private static long _areaInclusiveTicks;
    private static long _diagnosticOverheadTicks;
    private static int _requestCount;
    private static int _findCallCount;
    private static int _areaCallCount;
    private static int _omittedSamples;
    private static int _targetEpoch;
    private static int _targetZoneX;
    private static int _targetZoneY;
    private static bool _hasTargetZone;
    private static SpawnBranch _branch;
    private static int _branchEpoch;
    private static bool _afterDeath;
    private static bool _spawnFailed;
    private static float _requestedDelay;
    private static float _respawnLoadDuration;
    private static string _route = "unknown";
    private static string _world = "unknown";
    private static int _minimapLoadHits;
    private static int _minimapLoadMisses;
    private static int _minimapLoadErrors;
    private static int _minimapGenerationCount;
    private static int _minimapGenerationErrors;
    private static int _omittedMinimapEvents;
    private static double _minimapLoadMilliseconds;
    private static double _minimapGenerationMilliseconds;

    [ThreadStatic]
    private static int _areaReadyDepth;

    [ThreadStatic]
    private static int _findSpawnPointDepth;

    [ThreadStatic]
    private static List<ZDO>? _sampleObjects;

    internal static void Install(
        Harmony harmony,
        ref int installed,
        ref int failed)
    {
        if (LoadTimeProfilerPatcher.IsDedicatedServer)
        {
            ProfilerLog.WriteLine(
                "Spawn readiness diagnostics skipped on the dedicated server.");
            return;
        }

        TryPatch(
            harmony,
            AccessTools.Method(
                typeof(Game),
                nameof(Game.RequestRespawn),
                new[] { typeof(float), typeof(bool) }),
            prefix: PatchMethod(
                typeof(SpawnReadinessRequestPatch),
                nameof(SpawnReadinessRequestPatch.Prefix),
                int.MaxValue),
            postfix: null,
            finalizer: null,
            "Game.RequestRespawn",
            ref installed,
            ref failed);
        TryPatch(
            harmony,
            AccessTools.Method(
                typeof(Game),
                "_RequestRespawn",
                Type.EmptyTypes),
            prefix: PatchMethod(
                typeof(SpawnReadinessActivationPatch),
                nameof(SpawnReadinessActivationPatch.Prefix),
                int.MaxValue),
            postfix: PatchMethod(
                typeof(SpawnReadinessActivationPatch),
                nameof(SpawnReadinessActivationPatch.Postfix),
                int.MinValue),
            finalizer: PatchMethod(
                typeof(SpawnReadinessActivationPatch),
                nameof(SpawnReadinessActivationPatch.Finalizer),
                int.MinValue),
            "Game._RequestRespawn",
            ref installed,
            ref failed);
        TryPatch(
            harmony,
            AccessTools.Method(
                typeof(Game),
                nameof(Game.FindSpawnPoint),
                new[]
                {
                    typeof(Vector3).MakeByRefType(),
                    typeof(bool).MakeByRefType(),
                    typeof(float)
                }),
            prefix: PatchMethod(
                typeof(SpawnReadinessFindSpawnPointPatch),
                nameof(SpawnReadinessFindSpawnPointPatch.Prefix),
                int.MaxValue),
            postfix: PatchMethod(
                typeof(SpawnReadinessFindSpawnPointPatch),
                nameof(SpawnReadinessFindSpawnPointPatch.Postfix),
                int.MinValue),
            finalizer: PatchMethod(
                typeof(SpawnReadinessFindSpawnPointPatch),
                nameof(SpawnReadinessFindSpawnPointPatch.Finalizer),
                int.MinValue),
            "Game.FindSpawnPoint",
            ref installed,
            ref failed);
        TryPatch(
            harmony,
            AccessTools.Method(
                typeof(ZNetScene),
                nameof(ZNetScene.IsAreaReady),
                new[] { typeof(Vector3) }),
            prefix: PatchMethod(
                typeof(SpawnReadinessAreaReadyPatch),
                nameof(SpawnReadinessAreaReadyPatch.Prefix),
                int.MaxValue),
            postfix: PatchMethod(
                typeof(SpawnReadinessAreaReadyPatch),
                nameof(SpawnReadinessAreaReadyPatch.Postfix),
                int.MinValue),
            finalizer: PatchMethod(
                typeof(SpawnReadinessAreaReadyPatch),
                nameof(SpawnReadinessAreaReadyPatch.Finalizer),
                int.MinValue),
            "ZNetScene.IsAreaReady",
            ref installed,
            ref failed);
        TryPatch(
            harmony,
            AccessTools.Method(
                typeof(Minimap),
                nameof(Minimap.TryLoadMinimapTextureData),
                Type.EmptyTypes),
            prefix: PatchMethod(
                typeof(SpawnReadinessMinimapLoadPatch),
                nameof(SpawnReadinessMinimapLoadPatch.Prefix),
                int.MaxValue),
            postfix: PatchMethod(
                typeof(SpawnReadinessMinimapLoadPatch),
                nameof(SpawnReadinessMinimapLoadPatch.Postfix),
                int.MinValue),
            finalizer: PatchMethod(
                typeof(SpawnReadinessMinimapLoadPatch),
                nameof(SpawnReadinessMinimapLoadPatch.Finalizer),
                int.MinValue),
            "Minimap.TryLoadMinimapTextureData",
            ref installed,
            ref failed);
        TryPatch(
            harmony,
            AccessTools.Method(
                typeof(Minimap),
                nameof(Minimap.GenerateWorldMap),
                Type.EmptyTypes),
            prefix: PatchMethod(
                typeof(SpawnReadinessMinimapGenerationPatch),
                nameof(SpawnReadinessMinimapGenerationPatch.Prefix),
                int.MaxValue),
            postfix: null,
            finalizer: PatchMethod(
                typeof(SpawnReadinessMinimapGenerationPatch),
                nameof(SpawnReadinessMinimapGenerationPatch.Finalizer),
                int.MinValue),
            "Minimap.GenerateWorldMap",
            ref installed,
            ref failed);
    }

    internal static void ResetSession()
    {
        lock (Lock)
        {
            _sessionGeneration++;
            _sessionActive = true;
            _findHookEnabled = true;
            _areaHookEnabled = true;
            _minimapHookEnabled = true;
            _diagnosticOverheadTicks = 0L;
            _requestCount = 0;
            _minimapLoadHits = 0;
            _minimapLoadMisses = 0;
            _minimapLoadErrors = 0;
            _minimapGenerationCount = 0;
            _minimapGenerationErrors = 0;
            _omittedMinimapEvents = 0;
            _minimapLoadMilliseconds = 0d;
            _minimapGenerationMilliseconds = 0d;
            MinimapEvents.Clear();
            Warnings.Clear();
            ResetRespawnAttemptLocked();
        }
    }

    internal static void CloseSession()
    {
        lock (Lock)
        {
            _sessionActive = false;
            _respawnActive = false;
            _hotPathActive = false;
        }
    }

    private static void ResetRespawnAttemptLocked()
    {
        _respawnActive = false;
        _hotPathActive = false;
        _requestTicks = 0L;
        _activationTicks = 0L;
        _spawnStartedTicks = 0L;
        _spawnCompletedTicks = 0L;
        _firstFindTicks = 0L;
        _findSucceededTicks = 0L;
        _firstAreaCheckTicks = 0L;
        _areaReadyTicks = 0L;
        _zoneLoadedTicks = 0L;
        _activeAreaLoadedTicks = 0L;
        _builtInGateCrossedTicks = 0L;
        _nextSampleTicks = 0L;
        _findInclusiveTicks = 0L;
        _areaInclusiveTicks = 0L;
        _findCallCount = 0;
        _areaCallCount = 0;
        _omittedSamples = 0;
        _targetEpoch = 0;
        _targetZoneX = 0;
        _targetZoneY = 0;
        _hasTargetZone = false;
        _branch = SpawnBranch.Unknown;
        _branchEpoch = 0;
        _afterDeath = false;
        _spawnFailed = false;
        _requestedDelay = 0f;
        _respawnLoadDuration = 0f;
        _route = "unknown";
        _world = "unknown";
        Samples.Clear();
    }

    internal static void ObserveSpawnPlayerStarted()
    {
        long overheadStarted = Stopwatch.GetTimestamp();
        try
        {
            long now = Stopwatch.GetTimestamp();
            lock (Lock)
            {
                if (!_sessionActive || !_respawnActive)
                {
                    return;
                }

                if (_spawnStartedTicks == 0L)
                {
                    _spawnStartedTicks = now;
                }
            }
        }
        catch (Exception ex)
        {
            DisableHook("spawn completion", ex);
        }
        finally
        {
            AddDiagnosticOverhead(overheadStarted);
        }
    }

    internal static void ObserveSpawnPlayerCompleted(Exception? exception)
    {
        long overheadStarted = Stopwatch.GetTimestamp();
        try
        {
            long now = Stopwatch.GetTimestamp();
            lock (Lock)
            {
                if (!_sessionActive)
                {
                    return;
                }

                if (_spawnCompletedTicks == 0L)
                {
                    _spawnCompletedTicks = now;
                }

                _spawnFailed = exception != null;
                _respawnActive = false;
                _hotPathActive = false;
            }
        }
        catch (Exception ex)
        {
            DisableHook("spawn completion", ex);
        }
        finally
        {
            AddDiagnosticOverhead(overheadStarted);
        }
    }

    internal static void ObserveRequest(
        Game game,
        float delay,
        bool afterDeath)
    {
        if (!IsSessionActive())
        {
            return;
        }

        long overheadStarted = Stopwatch.GetTimestamp();
        try
        {
            string route = GetRoute();
            string world = GetWorldName();
            float loadDuration = game.m_respawnLoadDuration;
            long now = Stopwatch.GetTimestamp();
            lock (Lock)
            {
                if (!_sessionActive)
                {
                    return;
                }

                _requestCount++;
                ResetRespawnAttemptLocked();
                _requestTicks = now;
                _requestedDelay = delay;
                _afterDeath = afterDeath;
                _respawnLoadDuration = loadDuration;
                _route = route;
                _world = world;
            }
        }
        catch (Exception ex)
        {
            DisableHook("Game.RequestRespawn", ex);
        }
        finally
        {
            AddDiagnosticOverhead(overheadStarted);
        }
    }

    internal static long BeginActivation()
    {
        return IsSessionActive() ? Stopwatch.GetTimestamp() : 0L;
    }

    internal static void CompleteActivation(
        Game game,
        long startedTicks)
    {
        if (startedTicks == 0L)
        {
            return;
        }

        long overheadStarted = Stopwatch.GetTimestamp();
        try
        {
            if (!game.m_requestRespawn)
            {
                return;
            }

            string route = GetRoute();
            string world = GetWorldName();
            long now = Stopwatch.GetTimestamp();
            lock (Lock)
            {
                if (!_sessionActive)
                {
                    return;
                }

                _activationTicks = now;
                _respawnActive = true;
                _hotPathActive = true;
                _nextSampleTicks = now;
                _route = route;
                _world = world;
                _respawnLoadDuration = game.m_respawnLoadDuration;
            }
        }
        catch (Exception ex)
        {
            DisableHook("Game._RequestRespawn", ex);
        }
        finally
        {
            AddDiagnosticOverhead(overheadStarted);
        }
    }

    internal static void ActivationFailed(
        long startedTicks,
        Exception exception)
    {
        if (startedTicks != 0L)
        {
            DisableHook("Game._RequestRespawn", exception);
        }
    }

    internal static FindCallState BeginFindSpawnPoint(
        Game game,
        float deltaTime)
    {
        if (!_hotPathActive)
        {
            return default;
        }

        long overheadStarted = Stopwatch.GetTimestamp();
        try
        {
            lock (Lock)
            {
                if (!_sessionActive ||
                    !_respawnActive ||
                    !_findHookEnabled)
                {
                    return default;
                }
            }

            SpawnBranch branch = GetSpawnBranch(game);
            bool gateApplies =
                branch == SpawnBranch.Logout ||
                branch == SpawnBranch.Custom;
            bool crossesGate =
                gateApplies &&
                game.m_respawnWait + deltaTime >
                game.m_respawnLoadDuration;
            long now = Stopwatch.GetTimestamp();
            lock (Lock)
            {
                if (!_sessionActive ||
                    !_respawnActive ||
                    !_findHookEnabled)
                {
                    return default;
                }

                if (_firstFindTicks == 0L)
                {
                    _firstFindTicks = now;
                }

                UpdateBranchLocked(branch);

                if (crossesGate && _builtInGateCrossedTicks == 0L)
                {
                    _builtInGateCrossedTicks = now;
                }

                _findSpawnPointDepth++;
                return new FindCallState(
                    true,
                    true,
                    _sessionGeneration,
                    _requestCount,
                    now);
            }
        }
        catch (Exception ex)
        {
            DisableFindHook(ex);
            return default;
        }
        finally
        {
            AddDiagnosticOverhead(overheadStarted);
        }
    }

    internal static void CompleteFindSpawnPoint(
        bool result,
        bool usedLogoutPoint,
        FindCallState state)
    {
        if (!state.Active)
        {
            return;
        }

        long overheadStarted = Stopwatch.GetTimestamp();
        try
        {
            long now = Stopwatch.GetTimestamp();
            bool captureSample;
            int generation;
            lock (Lock)
            {
                if (!_sessionActive ||
                    !_respawnActive ||
                    !_findHookEnabled ||
                    _sessionGeneration != state.SessionGeneration ||
                    _requestCount != state.RequestEpoch)
                {
                    return;
                }

                _findCallCount++;
                _findInclusiveTicks +=
                    Math.Max(0L, now - state.StartedTicks);
                if (result && _findSucceededTicks == 0L)
                {
                    _findSucceededTicks = now;
                    if (usedLogoutPoint)
                    {
                        UpdateBranchLocked(SpawnBranch.Logout);
                    }
                }

                captureSample =
                    now >= _nextSampleTicks ||
                    result && _areaReadyTicks == 0L;
                if (captureSample)
                {
                    _nextSampleTicks = now + SampleIntervalTicks;
                }

                generation = state.SessionGeneration;
            }

            if (!captureSample)
            {
                return;
            }

            bool zoneLoaded = false;
            bool activeAreaLoaded = false;
            bool hasZone = false;
            int zoneX = 0;
            int zoneY = 0;
            ZoneSystem? zoneSystem = ZoneSystem.instance;
            ZNet? znet = ZNet.instance;
            if (zoneSystem != null && znet != null)
            {
                Vector2i zone = ZoneSystem.GetZone(znet.GetReferencePosition());
                zoneX = zone.x;
                zoneY = zone.y;
                hasZone = true;
                zoneLoaded = zoneSystem.IsZoneLoaded(zone);
                activeAreaLoaded = zoneSystem.IsActiveAreaLoaded();
            }

            int total = -1;
            int valid = -1;
            int missing = -1;
            int invalid = -1;
            ZNetScene? scene = ZNetScene.instance;
            ZDOMan? zdoMan = ZDOMan.instance;
            bool countsAvailable =
                hasZone &&
                zoneLoaded &&
                scene != null &&
                zdoMan != null &&
                TryCaptureKnownZdos(
                    scene,
                    zdoMan,
                    new Vector2i(zoneX, zoneY),
                    out total,
                    out valid,
                    out missing,
                    out invalid);

            SpawnBranch branch;
            int branchEpoch;
            int targetEpoch;
            lock (Lock)
            {
                if (!_sessionActive ||
                    !_respawnActive ||
                    !_findHookEnabled ||
                    _sessionGeneration != generation ||
                    _requestCount != state.RequestEpoch)
                {
                    return;
                }

                if (hasZone)
                {
                    UpdateTargetZoneLocked(zoneX, zoneY);
                }

                if (zoneLoaded && _zoneLoadedTicks == 0L)
                {
                    _zoneLoadedTicks = now;
                }

                if (activeAreaLoaded && _activeAreaLoadedTicks == 0L)
                {
                    _activeAreaLoadedTicks = now;
                }

                branch = _branch;
                branchEpoch = _branchEpoch;
                targetEpoch = _targetEpoch;
            }

            AddSample(
                generation,
                state.RequestEpoch,
                now,
                branch,
                branchEpoch,
                targetEpoch,
                hasZone,
                zoneX,
                zoneY,
                zoneLoaded,
                activeAreaLoaded,
                total,
                valid,
                missing,
                invalid,
                countsAvailable);
        }
        catch (Exception ex)
        {
            DisableFindHook(ex);
        }
        finally
        {
            AddDiagnosticOverhead(overheadStarted);
        }
    }

    internal static Exception? FinishFindSpawnPoint(
        FindCallState state,
        Exception? exception)
    {
        try
        {
            if (state.Active && exception != null)
            {
                DisableFindHook(exception);
            }
        }
        finally
        {
            if (state.CountedDepth)
            {
                _findSpawnPointDepth = Math.Max(
                    0,
                    _findSpawnPointDepth - 1);
            }
        }

        return exception;
    }

    internal static AreaCallState BeginAreaReady()
    {
        if (!_hotPathActive)
        {
            return default;
        }

        bool countedDepth = false;
        try
        {
            _areaReadyDepth++;
            countedDepth = true;
            bool observe;
            int sessionGeneration;
            int requestEpoch;
            lock (Lock)
            {
                observe =
                    _areaReadyDepth == 1 &&
                    _findSpawnPointDepth > 0 &&
                    _sessionActive &&
                    _respawnActive &&
                    _areaHookEnabled;
                sessionGeneration =
                    observe ? _sessionGeneration : 0;
                requestEpoch =
                    observe ? _requestCount : 0;
            }

            return new AreaCallState(
                countedDepth,
                observe,
                sessionGeneration,
                requestEpoch,
                observe ? Stopwatch.GetTimestamp() : 0L);
        }
        catch (Exception ex)
        {
            if (countedDepth)
            {
                _areaReadyDepth = Math.Max(0, _areaReadyDepth - 1);
            }

            DisableAreaHook(ex);
            return default;
        }
    }

    internal static void CompleteAreaReady(
        ZNetScene scene,
        Vector3 point,
        bool result,
        AreaCallState state)
    {
        if (!state.Observe)
        {
            return;
        }

        long overheadStarted = Stopwatch.GetTimestamp();
        try
        {
            long now = Stopwatch.GetTimestamp();
            Vector2i zone = ZoneSystem.GetZone(point);
            bool captureSample;
            int generation;
            SpawnBranch branch;
            int branchEpoch;
            int targetEpoch;
            lock (Lock)
            {
                if (!_sessionActive ||
                    !_respawnActive ||
                    !_areaHookEnabled ||
                    _sessionGeneration != state.SessionGeneration ||
                    _requestCount != state.RequestEpoch)
                {
                    return;
                }

                _areaCallCount++;
                _areaInclusiveTicks +=
                    Math.Max(0L, now - state.StartedTicks);
                UpdateTargetZoneLocked(zone.x, zone.y);
                if (_firstAreaCheckTicks == 0L)
                {
                    _firstAreaCheckTicks = state.StartedTicks;
                }

                if (result && _areaReadyTicks == 0L)
                {
                    _areaReadyTicks = now;
                }

                captureSample =
                    result ||
                    now >= _nextSampleTicks;
                if (captureSample)
                {
                    _nextSampleTicks = now + SampleIntervalTicks;
                }

                generation = state.SessionGeneration;
                branch = _branch;
                branchEpoch = _branchEpoch;
                targetEpoch = _targetEpoch;
            }

            if (!captureSample)
            {
                return;
            }

            ZoneSystem? zoneSystem = ZoneSystem.instance;
            bool zoneLoaded =
                zoneSystem != null &&
                zoneSystem.IsZoneLoaded(zone);
            bool activeAreaLoaded =
                zoneSystem != null &&
                ZNet.instance != null &&
                zoneSystem.IsActiveAreaLoaded();
            int total = -1;
            int valid = -1;
            int missing = -1;
            int invalid = -1;
            ZDOMan? zdoMan = ZDOMan.instance;
            bool countsAvailable =
                zoneLoaded &&
                zdoMan != null &&
                TryCaptureKnownZdos(
                    scene,
                    zdoMan,
                    zone,
                    out total,
                    out valid,
                    out missing,
                    out invalid);

            lock (Lock)
            {
                if (!_sessionActive ||
                    !_respawnActive ||
                    !_areaHookEnabled ||
                    _sessionGeneration != generation ||
                    _requestCount != state.RequestEpoch ||
                    _targetEpoch != targetEpoch)
                {
                    return;
                }

                if (zoneLoaded && _zoneLoadedTicks == 0L)
                {
                    _zoneLoadedTicks = now;
                }

                if (activeAreaLoaded && _activeAreaLoadedTicks == 0L)
                {
                    _activeAreaLoadedTicks = now;
                }
            }

            AddSample(
                generation,
                state.RequestEpoch,
                now,
                branch,
                branchEpoch,
                targetEpoch,
                true,
                zone.x,
                zone.y,
                zoneLoaded,
                activeAreaLoaded,
                total,
                valid,
                missing,
                invalid,
                countsAvailable);
        }
        catch (Exception ex)
        {
            DisableAreaHook(ex);
        }
        finally
        {
            AddDiagnosticOverhead(overheadStarted);
        }
    }

    internal static Exception? FinishAreaReady(
        AreaCallState state,
        Exception? exception)
    {
        try
        {
            if (state.Observe && exception != null)
            {
                DisableAreaHook(exception);
            }
        }
        finally
        {
            if (state.CountedDepth)
            {
                _areaReadyDepth = Math.Max(
                    0,
                    _areaReadyDepth - 1);
            }
        }

        return exception;
    }

    internal static MinimapCallState BeginMinimapCall()
    {
        if (!IsSessionActive())
        {
            return default;
        }

        long overheadStarted = Stopwatch.GetTimestamp();
        try
        {
            lock (Lock)
            {
                if (!_sessionActive || !_minimapHookEnabled)
                {
                    return default;
                }

                return new MinimapCallState(
                    true,
                    _sessionGeneration,
                    _requestCount,
                    Stopwatch.GetTimestamp(),
                    _activationTicks);
            }
        }
        catch (Exception ex)
        {
            DisableMinimapHook(ex);
            return default;
        }
        finally
        {
            AddDiagnosticOverhead(overheadStarted);
        }
    }

    internal static void CompleteMinimapLoad(
        MinimapCallState state,
        bool result)
    {
        if (!state.Active)
        {
            return;
        }

        long overheadStarted = Stopwatch.GetTimestamp();
        try
        {
            long endedTicks = Stopwatch.GetTimestamp();
            double elapsed = TicksToMilliseconds(
                endedTicks - state.StartedTicks);
            lock (Lock)
            {
                if (!_sessionActive ||
                    !_minimapHookEnabled ||
                    _sessionGeneration != state.SessionGeneration)
                {
                    return;
                }

                _minimapLoadMilliseconds += elapsed;
                if (result)
                {
                    _minimapLoadHits++;
                }
                else
                {
                    _minimapLoadMisses++;
                }

                MinimapPhase phase = GetMinimapPhaseLocked(
                    state,
                    endedTicks,
                    out long activationTicks);
                AddMinimapEventLocked(
                    new MinimapEvent(
                        MinimapEventKind.CacheLoad,
                        phase,
                        result
                            ? MinimapOutcome.Hit
                            : MinimapOutcome.Miss,
                        state.RequestEpoch,
                        activationTicks,
                        state.StartedTicks,
                        endedTicks));
            }
        }
        catch (Exception ex)
        {
            DisableMinimapHook(ex);
        }
        finally
        {
            AddDiagnosticOverhead(overheadStarted);
        }
    }

    internal static void MinimapLoadFailed(
        MinimapCallState state,
        Exception exception)
    {
        if (!state.Active)
        {
            return;
        }

        long endedTicks = Stopwatch.GetTimestamp();
        lock (Lock)
        {
            if (!_sessionActive ||
                _sessionGeneration != state.SessionGeneration)
            {
                return;
            }

            _minimapLoadErrors++;
            _minimapLoadMilliseconds +=
                TicksToMilliseconds(
                    endedTicks -
                    state.StartedTicks);
            MinimapPhase phase = GetMinimapPhaseLocked(
                state,
                endedTicks,
                out long activationTicks);
            AddMinimapEventLocked(
                new MinimapEvent(
                    MinimapEventKind.CacheLoad,
                    phase,
                    MinimapOutcome.Error,
                    state.RequestEpoch,
                    activationTicks,
                    state.StartedTicks,
                    endedTicks));
        }

        DisableMinimapHook(exception);
    }

    internal static void CompleteMinimapGeneration(
        MinimapCallState state,
        Exception? exception)
    {
        if (!state.Active)
        {
            return;
        }

        long overheadStarted = Stopwatch.GetTimestamp();
        try
        {
            long endedTicks = Stopwatch.GetTimestamp();
            double elapsed = TicksToMilliseconds(
                endedTicks - state.StartedTicks);
            lock (Lock)
            {
                if (!_sessionActive ||
                    !_minimapHookEnabled ||
                    _sessionGeneration != state.SessionGeneration)
                {
                    return;
                }

                _minimapGenerationCount++;
                _minimapGenerationMilliseconds += elapsed;
                if (exception != null)
                {
                    _minimapGenerationErrors++;
                }

                MinimapPhase phase = GetMinimapPhaseLocked(
                    state,
                    endedTicks,
                    out long activationTicks);
                AddMinimapEventLocked(
                    new MinimapEvent(
                        MinimapEventKind.GenerateWorldMap,
                        phase,
                        exception == null
                            ? MinimapOutcome.Completed
                            : MinimapOutcome.Error,
                        state.RequestEpoch,
                        activationTicks,
                        state.StartedTicks,
                        endedTicks));
            }

            if (exception != null)
            {
                DisableMinimapHook(exception);
            }
        }
        catch (Exception ex)
        {
            DisableMinimapHook(ex);
        }
        finally
        {
            AddDiagnosticOverhead(overheadStarted);
        }
    }

    internal static void AppendReport(StringBuilder builder)
    {
        try
        {
            DiagnosticSnapshot snapshot = Snapshot();
            builder.AppendLine("Spawn readiness diagnostics:");
            if (!snapshot.RequestObserved &&
                snapshot.MinimapLoadCount == 0 &&
                snapshot.MinimapGenerationCount == 0)
            {
                builder.AppendLine(
                    "  No respawn readiness or minimap activity was observed.");
                AppendWarnings(builder, snapshot.Warnings);
                return;
            }

            builder.Append("  Route: ")
                .Append(snapshot.Route)
                .Append(", world=")
                .AppendLine(snapshot.World);
            if (snapshot.RequestObserved)
            {
                builder.Append("  Respawn requests observed: ")
                    .Append(snapshot.RequestCount)
                    .Append("; latest attempt branch=")
                    .Append(FormatBranch(snapshot.Branch))
                    .Append(", branch epochs=")
                    .Append(snapshot.BranchEpoch)
                    .Append(", after death=")
                    .Append(snapshot.AfterDeath ? "yes" : "no")
                    .Append(", requested delay=")
                    .Append(TimelineProfiler.FormatSeconds(
                        snapshot.RequestedDelay * 1000d))
                    .AppendLine();
                builder.Append("  Built-in respawn gate: ")
                    .Append(TimelineProfiler.FormatSeconds(
                        snapshot.RespawnLoadDuration * 1000d))
                    .AppendLine(
                        " (applies only to logout/custom branches)");
                AppendOffset(
                    builder,
                    "RequestRespawn -> _RequestRespawn activation",
                    snapshot.RequestTicks,
                    snapshot.ActivationTicks);
                AppendFromActivation(
                    builder,
                    "First FindSpawnPoint",
                    snapshot,
                    snapshot.FirstFindTicks);
                if (snapshot.Branch == SpawnBranch.Logout ||
                    snapshot.Branch == SpawnBranch.Custom)
                {
                    AppendFromActivation(
                        builder,
                        "Built-in gate crossed",
                        snapshot,
                        snapshot.BuiltInGateCrossedTicks);
                }
                else
                {
                    builder.AppendLine(
                        "  Built-in gate crossed: not applicable to the final branch (see samples for prior branches)");
                }
                AppendFromActivation(
                    builder,
                    "Target center zone first observed loaded",
                    snapshot,
                    snapshot.ZoneLoadedTicks);
                AppendFromActivation(
                    builder,
                    "Active area first observed loaded",
                    snapshot,
                    snapshot.ActiveAreaLoadedTicks);
                AppendFromActivation(
                    builder,
                    "First IsAreaReady call",
                    snapshot,
                    snapshot.FirstAreaCheckTicks);
                AppendFromActivation(
                    builder,
                    "IsAreaReady first true",
                    snapshot,
                    snapshot.AreaReadyTicks);
                AppendFromActivation(
                    builder,
                    "FindSpawnPoint first true",
                    snapshot,
                    snapshot.FindSucceededTicks);
                AppendFromActivation(
                    builder,
                    "SpawnPlayer entry",
                    snapshot,
                    snapshot.SpawnStartedTicks);
                if (snapshot.SpawnStartedTicks != 0L &&
                    snapshot.SpawnCompletedTicks != 0L)
                {
                    AppendOffset(
                        builder,
                        snapshot.SpawnFailed
                            ? "SpawnPlayer failed after"
                            : "SpawnPlayer execution",
                        snapshot.SpawnStartedTicks,
                        snapshot.SpawnCompletedTicks);
                }

                builder.Append("  Calls and inclusive synchronous time: FindSpawnPoint=")
                    .Append(snapshot.FindCallCount)
                    .Append("/")
                    .Append(TimelineProfiler.FormatSeconds(
                        TicksToMilliseconds(
                            snapshot.FindInclusiveTicks)))
                    .Append(", IsAreaReady=")
                    .Append(snapshot.AreaCallCount)
                    .Append("/")
                    .Append(TimelineProfiler.FormatSeconds(
                        TicksToMilliseconds(
                            snapshot.AreaInclusiveTicks)))
                    .AppendLine();
                if (snapshot.HasTargetZone)
                {
                    builder.Append("  Final target zone: ")
                        .Append(snapshot.TargetZoneX)
                        .Append(",")
                        .Append(snapshot.TargetZoneY)
                        .Append(" (target epochs=")
                        .Append(snapshot.TargetEpoch)
                        .AppendLine(")");
                    AppendZdoSummary(
                        builder,
                        snapshot.Samples,
                        snapshot.TargetEpoch);
                }
                else
                {
                    builder.AppendLine(
                        "  Known spawn-sector ZDO counts: unavailable for the final target");
                }

                AppendSamples(
                    builder,
                    snapshot.ActivationTicks,
                    snapshot.Samples,
                    snapshot.OmittedSamples);
            }

            AppendMinimap(builder, snapshot);
            builder.Append("  Measured diagnostic work (lower bound): ")
                .Append(TimelineProfiler.FormatSeconds(
                    TicksToMilliseconds(
                        snapshot.DiagnosticOverheadTicks)))
                .AppendLine(
                    " (includes sampled ZDO scans; excludes hook dispatch and counter bookkeeping)");
            builder.AppendLine(
                "  Times above can overlap; do not add them as a sequential breakdown.");
            AppendWarnings(builder, snapshot.Warnings);
        }
        catch (Exception ex)
        {
            builder.AppendLine("Spawn readiness diagnostics:");
            builder.Append("  Report generation failed: ")
                .Append(ex.GetType().Name)
                .Append(": ")
                .AppendLine(ex.Message);
        }
    }

    private static void TryPatch(
        Harmony harmony,
        MethodBase? target,
        HarmonyMethod? prefix,
        HarmonyMethod? postfix,
        HarmonyMethod? finalizer,
        string label,
        ref int installed,
        ref int failed)
    {
        if (target == null)
        {
            failed++;
            ProfilerLog.WriteLine(
                "Spawn readiness diagnostic warning: could not find " +
                label +
                ".");
            return;
        }

        try
        {
            harmony.Patch(
                target,
                prefix: prefix,
                postfix: postfix,
                finalizer: finalizer);
            installed++;
        }
        catch (Exception ex)
        {
            failed++;
            ProfilerLog.WriteLine(
                "Spawn readiness diagnostic warning: could not patch " +
                label +
                ": " +
                ex.Message);
        }
    }

    private static HarmonyMethod PatchMethod(
        Type type,
        string name,
        int priority)
    {
        MethodInfo? method = AccessTools.Method(type, name);
        if (method == null)
        {
            throw new MissingMethodException(type.FullName, name);
        }

        return new HarmonyMethod(method)
        {
            priority = priority
        };
    }

    private static bool IsSessionActive()
    {
        return _sessionActive;
    }

    private static SpawnBranch GetSpawnBranch(Game game)
    {
        PlayerProfile? profile = game.m_playerProfile;
        if (!game.m_respawnAfterDeath &&
            profile != null &&
            profile.HaveLogoutPoint())
        {
            return SpawnBranch.Logout;
        }

        if (profile != null &&
            profile.HaveCustomSpawnPoint())
        {
            return SpawnBranch.Custom;
        }

        return SpawnBranch.Start;
    }

    private static string GetRoute()
    {
        try
        {
            ZNet? znet = ZNet.instance;
            if (znet == null)
            {
                return "unknown";
            }

            return znet.IsServer()
                ? "local host"
                : "remote client";
        }
        catch
        {
            return "unknown";
        }
    }

    private static string GetWorldName()
    {
        try
        {
            World? world = ZNet.World;
            return world == null ||
                   string.IsNullOrEmpty(world.m_name)
                ? "unknown"
                : world.m_name;
        }
        catch
        {
            return "unknown";
        }
    }

    private static bool TryCaptureKnownZdos(
        ZNetScene scene,
        ZDOMan zdoMan,
        Vector2i zone,
        out int total,
        out int valid,
        out int missing,
        out int invalid)
    {
        total = -1;
        valid = -1;
        missing = -1;
        invalid = -1;
        List<ZDO> sampleObjects =
            _sampleObjects ??= new List<ZDO>(2048);
        sampleObjects.Clear();
        try
        {
            zdoMan.FindSectorObjects(
                zone,
                1,
                0,
                sampleObjects);
            total = sampleObjects.Count;
            valid = 0;
            missing = 0;
            invalid = 0;
            foreach (ZDO zdo in sampleObjects)
            {
                if (!scene.IsPrefabZDOValid(zdo))
                {
                    invalid++;
                    continue;
                }

                valid++;
                if (!scene.m_instances.TryGetValue(
                        zdo,
                        out ZNetView instance) ||
                    instance == null)
                {
                    missing++;
                }
            }

            return true;
        }
        finally
        {
            sampleObjects.Clear();
        }
    }

    private static void UpdateTargetZoneLocked(
        int zoneX,
        int zoneY)
    {
        if (_hasTargetZone &&
            _targetZoneX == zoneX &&
            _targetZoneY == zoneY)
        {
            return;
        }

        _hasTargetZone = true;
        _targetZoneX = zoneX;
        _targetZoneY = zoneY;
        _targetEpoch++;
        ResetTargetReadinessLocked();
    }

    private static void ResetTargetReadinessLocked()
    {
        _zoneLoadedTicks = 0L;
        _activeAreaLoadedTicks = 0L;
        _firstAreaCheckTicks = 0L;
        _areaReadyTicks = 0L;
    }

    private static void UpdateBranchLocked(SpawnBranch branch)
    {
        if (_branch == branch)
        {
            return;
        }

        _branch = branch;
        _branchEpoch++;
        _builtInGateCrossedTicks = 0L;
        _hasTargetZone = false;
        ResetTargetReadinessLocked();
    }

    private static void AddSample(
        int generation,
        int requestEpoch,
        long timestamp,
        SpawnBranch branch,
        int branchEpoch,
        int targetEpoch,
        bool hasZone,
        int zoneX,
        int zoneY,
        bool zoneLoaded,
        bool activeAreaLoaded,
        int total,
        int valid,
        int missing,
        int invalid,
        bool countsAvailable)
    {
        lock (Lock)
        {
            if (_sessionGeneration != generation ||
                _requestCount != requestEpoch ||
                !_respawnActive)
            {
                return;
            }

            ReadinessSample sample = new(
                timestamp,
                branch,
                branchEpoch,
                targetEpoch,
                hasZone,
                zoneX,
                zoneY,
                zoneLoaded,
                activeAreaLoaded,
                total,
                valid,
                missing,
                invalid,
                countsAvailable);
            if (Samples.Count < MaximumSamples)
            {
                Samples.Add(sample);
                return;
            }

            _omittedSamples++;
            Samples[Samples.Count - 1] = sample;
        }
    }

    private static MinimapPhase GetMinimapPhaseLocked(
        MinimapCallState state,
        long endedTicks,
        out long activationTicks)
    {
        if (state.ActivationTicksAtStart != 0L)
        {
            activationTicks = state.ActivationTicksAtStart;
            return MinimapPhase.AfterActivation;
        }

        if (_requestCount == state.RequestEpoch &&
            _activationTicks >= state.StartedTicks &&
            _activationTicks <= endedTicks)
        {
            activationTicks = _activationTicks;
            return MinimapPhase.CrossedActivation;
        }

        activationTicks = 0L;
        return MinimapPhase.BeforeActivation;
    }

    private static void AddMinimapEventLocked(MinimapEvent minimapEvent)
    {
        if (MinimapEvents.Count < MaximumMinimapEvents)
        {
            MinimapEvents.Add(minimapEvent);
            return;
        }

        _omittedMinimapEvents++;
        MinimapEvents[MinimapEvents.Count - 1] = minimapEvent;
    }

    private static void AddDiagnosticOverhead(long startedTicks)
    {
        AddRawOverheadTicks(
            Math.Max(
                0L,
                Stopwatch.GetTimestamp() - startedTicks));
    }

    private static void AddRawOverheadTicks(long ticks)
    {
        lock (Lock)
        {
            _diagnosticOverheadTicks += ticks;
        }
    }

    private static void DisableFindHook(Exception exception)
    {
        string? warning;
        lock (Lock)
        {
            _findHookEnabled = false;
            warning = AddWarningLocked(
                "FindSpawnPoint diagnostic",
                exception);
        }

        LogWarning(warning);
    }

    private static void DisableAreaHook(Exception exception)
    {
        string? warning;
        lock (Lock)
        {
            _areaHookEnabled = false;
            warning = AddWarningLocked(
                "IsAreaReady diagnostic",
                exception);
        }

        LogWarning(warning);
    }

    private static void DisableMinimapHook(Exception exception)
    {
        string? warning;
        lock (Lock)
        {
            _minimapHookEnabled = false;
            warning = AddWarningLocked(
                "Minimap diagnostic",
                exception);
        }

        LogWarning(warning);
    }

    private static void DisableHook(
        string hook,
        Exception exception)
    {
        string? warning;
        lock (Lock)
        {
            warning = AddWarningLocked(hook, exception);
        }

        LogWarning(warning);
    }

    private static string? AddWarningLocked(
        string hook,
        Exception exception)
    {
        string warning =
            hook +
            " disabled or incomplete after " +
            exception.GetType().Name +
            ": " +
            exception.Message;
        if (!Warnings.Contains(warning))
        {
            Warnings.Add(warning);
            return warning;
        }

        return null;
    }

    private static void LogWarning(string? warning)
    {
        if (warning != null)
        {
            ProfilerLog.WriteLine(
                "Spawn readiness diagnostic warning: " +
                warning);
        }
    }

    private static DiagnosticSnapshot Snapshot()
    {
        lock (Lock)
        {
            return new DiagnosticSnapshot(
                _requestTicks != 0L,
                _requestTicks,
                _activationTicks,
                _spawnStartedTicks,
                _spawnCompletedTicks,
                _firstFindTicks,
                _findSucceededTicks,
                _firstAreaCheckTicks,
                _areaReadyTicks,
                _zoneLoadedTicks,
                _activeAreaLoadedTicks,
                _builtInGateCrossedTicks,
                _findInclusiveTicks,
                _areaInclusiveTicks,
                _diagnosticOverheadTicks,
                _requestCount,
                _findCallCount,
                _areaCallCount,
                _omittedSamples,
                _targetEpoch,
                _targetZoneX,
                _targetZoneY,
                _hasTargetZone,
                _branch,
                _branchEpoch,
                _afterDeath,
                _spawnFailed,
                _requestedDelay,
                _respawnLoadDuration,
                _route,
                _world,
                _minimapLoadHits,
                _minimapLoadMisses,
                _minimapLoadErrors,
                _minimapGenerationCount,
                _minimapGenerationErrors,
                _minimapLoadMilliseconds,
                _minimapGenerationMilliseconds,
                _omittedMinimapEvents,
                MinimapEvents.ToArray(),
                Samples.ToArray(),
                Warnings.ToArray());
        }
    }

    private static void AppendOffset(
        StringBuilder builder,
        string label,
        long startTicks,
        long endTicks)
    {
        builder.Append("  ").Append(label).Append(": ");
        if (startTicks == 0L || endTicks == 0L)
        {
            builder.AppendLine("not observed");
            return;
        }

        builder.AppendLine(
            TimelineProfiler.FormatSeconds(
                TicksToMilliseconds(
                    Math.Max(0L, endTicks - startTicks))));
    }

    private static void AppendFromActivation(
        StringBuilder builder,
        string label,
        DiagnosticSnapshot snapshot,
        long timestamp)
    {
        AppendOffset(
            builder,
            label,
            snapshot.ActivationTicks,
            timestamp);
    }

    private static void AppendZdoSummary(
        StringBuilder builder,
        ReadinessSample[] samples,
        int targetEpoch)
    {
        bool found = false;
        int firstTotal = 0;
        int peakTotal = 0;
        int finalTotal = 0;
        int peakMissing = 0;
        int finalMissing = 0;
        int peakInvalid = 0;
        foreach (ReadinessSample sample in samples)
        {
            if (!sample.CountsAvailable ||
                sample.TargetEpoch != targetEpoch)
            {
                continue;
            }

            if (!found)
            {
                firstTotal = sample.Total;
                found = true;
            }

            peakTotal = Math.Max(peakTotal, sample.Total);
            finalTotal = sample.Total;
            peakMissing = Math.Max(peakMissing, sample.Missing);
            finalMissing = sample.Missing;
            peakInvalid = Math.Max(peakInvalid, sample.Invalid);
        }

        if (!found)
        {
            builder.AppendLine(
                "  Known spawn-sector ZDO counts: unavailable");
            return;
        }

        builder.Append("  Known spawn-sector ZDOs (final target 3x3, retained samples): first=")
            .Append(firstTotal)
            .Append(", peak=")
            .Append(peakTotal)
            .Append(", final=")
            .Append(finalTotal)
            .AppendLine();
        builder.Append("  Uninstantiated valid ZDOs: retained peak=")
            .Append(peakMissing)
            .Append(", final=")
            .Append(finalMissing)
            .Append(", invalid prefab retained peak=")
            .Append(peakInvalid)
            .AppendLine();
    }

    private static void AppendSamples(
        StringBuilder builder,
        long activationTicks,
        ReadinessSample[] samples,
        int omittedSamples)
    {
        if (samples.Length == 0)
        {
            builder.AppendLine("  Readiness samples: none");
            return;
        }

        builder.AppendLine(
            "  Readiness samples (after activation; periodic <=1 Hz plus terminal):");
        foreach (ReadinessSample sample in samples)
        {
            builder.Append("    ")
                .Append(TimelineProfiler.FormatSeconds(
                    TicksToMilliseconds(
                        sample.TimestampTicks -
                        activationTicks)))
                .Append(": branch=")
                .Append(FormatBranch(sample.Branch))
                .Append(", branchEpoch=")
                .Append(sample.BranchEpoch)
                .Append(", targetEpoch=")
                .Append(sample.TargetEpoch);
            if (sample.HasZone)
            {
                builder.Append(", zone=")
                    .Append(sample.ZoneX)
                    .Append(",")
                    .Append(sample.ZoneY);
            }

            builder.Append(", zoneLoaded=")
                .Append(sample.ZoneLoaded ? "yes" : "no")
                .Append(", activeAreaLoaded=")
                .Append(sample.ActiveAreaLoaded ? "yes" : "no");
            if (sample.CountsAvailable)
            {
                builder.Append(", known/valid/missing/invalid=")
                    .Append(sample.Total)
                    .Append("/")
                    .Append(sample.Valid)
                    .Append("/")
                    .Append(sample.Missing)
                    .Append("/")
                    .Append(sample.Invalid);
            }

            builder.AppendLine();
        }

        if (omittedSamples > 0)
        {
            builder.Append("    ... ")
                .Append(omittedSamples)
                .AppendLine(
                    " sample(s) omitted after the fixed in-memory limit.");
        }
    }

    private static void AppendMinimap(
        StringBuilder builder,
        DiagnosticSnapshot snapshot)
    {
        builder.AppendLine(
            "  Minimap activity during the connection (inclusive call elapsed):");
        builder.Append("    Cache loads: hits=")
            .Append(snapshot.MinimapLoadHits)
            .Append(", misses=")
            .Append(snapshot.MinimapLoadMisses)
            .Append(", errors=")
            .Append(snapshot.MinimapLoadErrors)
            .Append(", total=")
            .Append(TimelineProfiler.FormatSeconds(
                snapshot.MinimapLoadMilliseconds))
            .AppendLine();
        builder.Append("    GenerateWorldMap calls: count=")
            .Append(snapshot.MinimapGenerationCount)
            .Append(", errors=")
            .Append(snapshot.MinimapGenerationErrors)
            .Append(", total=")
            .Append(TimelineProfiler.FormatSeconds(
                snapshot.MinimapGenerationMilliseconds))
            .AppendLine();

        if (snapshot.MinimapEvents.Length > 0)
        {
            builder.AppendLine(
                "    Call phase detail (bounded; relative to respawn activation):");
            foreach (MinimapEvent minimapEvent in snapshot.MinimapEvents)
            {
                builder.Append("      ")
                    .Append(FormatMinimapEventKind(minimapEvent.Kind))
                    .Append(": ")
                    .Append(FormatMinimapPhase(minimapEvent))
                    .Append(", ")
                    .Append(FormatMinimapOutcome(minimapEvent.Outcome))
                    .Append(", ")
                    .Append(TimelineProfiler.FormatSeconds(
                        TicksToMilliseconds(
                            minimapEvent.EndedTicks -
                            minimapEvent.StartedTicks)))
                    .Append(", requestEpoch=")
                    .Append(minimapEvent.RequestEpoch)
                    .AppendLine();
            }
        }

        if (snapshot.OmittedMinimapEvents > 0)
        {
            builder.Append("      ... ")
                .Append(snapshot.OmittedMinimapEvents)
                .AppendLine(
                    " event(s) omitted from detail; totals remain complete.");
        }
    }

    private static string FormatMinimapEventKind(
        MinimapEventKind kind)
    {
        return kind == MinimapEventKind.CacheLoad
            ? "TryLoadMinimapTextureData"
            : "GenerateWorldMap";
    }

    private static string FormatMinimapPhase(
        MinimapEvent minimapEvent)
    {
        switch (minimapEvent.Phase)
        {
            case MinimapPhase.CrossedActivation:
                return "crossed respawn activation";
            case MinimapPhase.AfterActivation:
                if (minimapEvent.ActivationTicks == 0L)
                {
                    return "after respawn activation";
                }

                return "started " +
                       TimelineProfiler.FormatSeconds(
                           TicksToMilliseconds(
                               minimapEvent.StartedTicks -
                               minimapEvent.ActivationTicks)) +
                       " after respawn activation";
            default:
                return "before respawn activation";
        }
    }

    private static string FormatMinimapOutcome(
        MinimapOutcome outcome)
    {
        switch (outcome)
        {
            case MinimapOutcome.Hit:
                return "hit";
            case MinimapOutcome.Miss:
                return "miss";
            case MinimapOutcome.Completed:
                return "completed";
            default:
                return "error";
        }
    }

    private static void AppendWarnings(
        StringBuilder builder,
        string[] warnings)
    {
        foreach (string warning in warnings)
        {
            builder.Append("  Warning: ")
                .AppendLine(warning);
        }
    }

    private static string FormatBranch(SpawnBranch branch)
    {
        switch (branch)
        {
            case SpawnBranch.Logout:
                return "logout point";
            case SpawnBranch.Custom:
                return "custom spawn/bed";
            case SpawnBranch.Start:
                return "start/default";
            default:
                return "unknown";
        }
    }

    private static double TicksToMilliseconds(long ticks)
    {
        return Math.Max(0L, ticks) * 1000d / Stopwatch.Frequency;
    }

    internal readonly struct FindCallState
    {
        internal FindCallState(
            bool active,
            bool countedDepth,
            int sessionGeneration,
            int requestEpoch,
            long startedTicks)
        {
            Active = active;
            CountedDepth = countedDepth;
            SessionGeneration = sessionGeneration;
            RequestEpoch = requestEpoch;
            StartedTicks = startedTicks;
        }

        internal bool Active { get; }
        internal bool CountedDepth { get; }
        internal int SessionGeneration { get; }
        internal int RequestEpoch { get; }
        internal long StartedTicks { get; }
    }

    internal readonly struct AreaCallState
    {
        internal AreaCallState(
            bool countedDepth,
            bool observe,
            int sessionGeneration,
            int requestEpoch,
            long startedTicks)
        {
            CountedDepth = countedDepth;
            Observe = observe;
            SessionGeneration = sessionGeneration;
            RequestEpoch = requestEpoch;
            StartedTicks = startedTicks;
        }

        internal bool CountedDepth { get; }
        internal bool Observe { get; }
        internal int SessionGeneration { get; }
        internal int RequestEpoch { get; }
        internal long StartedTicks { get; }
    }

    internal readonly struct MinimapCallState
    {
        internal MinimapCallState(
            bool active,
            int sessionGeneration,
            int requestEpoch,
            long startedTicks,
            long activationTicksAtStart)
        {
            Active = active;
            SessionGeneration = sessionGeneration;
            RequestEpoch = requestEpoch;
            StartedTicks = startedTicks;
            ActivationTicksAtStart = activationTicksAtStart;
        }

        internal bool Active { get; }
        internal int SessionGeneration { get; }
        internal int RequestEpoch { get; }
        internal long StartedTicks { get; }
        internal long ActivationTicksAtStart { get; }
    }

    private enum MinimapEventKind : byte
    {
        CacheLoad,
        GenerateWorldMap
    }

    private enum MinimapPhase : byte
    {
        BeforeActivation,
        CrossedActivation,
        AfterActivation
    }

    private enum MinimapOutcome : byte
    {
        Hit,
        Miss,
        Completed,
        Error
    }

    private readonly struct MinimapEvent
    {
        internal MinimapEvent(
            MinimapEventKind kind,
            MinimapPhase phase,
            MinimapOutcome outcome,
            int requestEpoch,
            long activationTicks,
            long startedTicks,
            long endedTicks)
        {
            Kind = kind;
            Phase = phase;
            Outcome = outcome;
            RequestEpoch = requestEpoch;
            ActivationTicks = activationTicks;
            StartedTicks = startedTicks;
            EndedTicks = endedTicks;
        }

        internal MinimapEventKind Kind { get; }
        internal MinimapPhase Phase { get; }
        internal MinimapOutcome Outcome { get; }
        internal int RequestEpoch { get; }
        internal long ActivationTicks { get; }
        internal long StartedTicks { get; }
        internal long EndedTicks { get; }
    }

    private enum SpawnBranch : byte
    {
        Unknown,
        Logout,
        Custom,
        Start
    }

    private readonly struct ReadinessSample
    {
        internal ReadinessSample(
            long timestampTicks,
            SpawnBranch branch,
            int branchEpoch,
            int targetEpoch,
            bool hasZone,
            int zoneX,
            int zoneY,
            bool zoneLoaded,
            bool activeAreaLoaded,
            int total,
            int valid,
            int missing,
            int invalid,
            bool countsAvailable)
        {
            TimestampTicks = timestampTicks;
            Branch = branch;
            BranchEpoch = branchEpoch;
            TargetEpoch = targetEpoch;
            HasZone = hasZone;
            ZoneX = zoneX;
            ZoneY = zoneY;
            ZoneLoaded = zoneLoaded;
            ActiveAreaLoaded = activeAreaLoaded;
            Total = total;
            Valid = valid;
            Missing = missing;
            Invalid = invalid;
            CountsAvailable = countsAvailable;
        }

        internal long TimestampTicks { get; }
        internal SpawnBranch Branch { get; }
        internal int BranchEpoch { get; }
        internal int TargetEpoch { get; }
        internal bool HasZone { get; }
        internal int ZoneX { get; }
        internal int ZoneY { get; }
        internal bool ZoneLoaded { get; }
        internal bool ActiveAreaLoaded { get; }
        internal int Total { get; }
        internal int Valid { get; }
        internal int Missing { get; }
        internal int Invalid { get; }
        internal bool CountsAvailable { get; }
    }

    private sealed class DiagnosticSnapshot
    {
        internal DiagnosticSnapshot(
            bool requestObserved,
            long requestTicks,
            long activationTicks,
            long spawnStartedTicks,
            long spawnCompletedTicks,
            long firstFindTicks,
            long findSucceededTicks,
            long firstAreaCheckTicks,
            long areaReadyTicks,
            long zoneLoadedTicks,
            long activeAreaLoadedTicks,
            long builtInGateCrossedTicks,
            long findInclusiveTicks,
            long areaInclusiveTicks,
            long diagnosticOverheadTicks,
            int requestCount,
            int findCallCount,
            int areaCallCount,
            int omittedSamples,
            int targetEpoch,
            int targetZoneX,
            int targetZoneY,
            bool hasTargetZone,
            SpawnBranch branch,
            int branchEpoch,
            bool afterDeath,
            bool spawnFailed,
            float requestedDelay,
            float respawnLoadDuration,
            string route,
            string world,
            int minimapLoadHits,
            int minimapLoadMisses,
            int minimapLoadErrors,
            int minimapGenerationCount,
            int minimapGenerationErrors,
            double minimapLoadMilliseconds,
            double minimapGenerationMilliseconds,
            int omittedMinimapEvents,
            MinimapEvent[] minimapEvents,
            ReadinessSample[] samples,
            string[] warnings)
        {
            RequestObserved = requestObserved;
            RequestTicks = requestTicks;
            ActivationTicks = activationTicks;
            SpawnStartedTicks = spawnStartedTicks;
            SpawnCompletedTicks = spawnCompletedTicks;
            FirstFindTicks = firstFindTicks;
            FindSucceededTicks = findSucceededTicks;
            FirstAreaCheckTicks = firstAreaCheckTicks;
            AreaReadyTicks = areaReadyTicks;
            ZoneLoadedTicks = zoneLoadedTicks;
            ActiveAreaLoadedTicks = activeAreaLoadedTicks;
            BuiltInGateCrossedTicks = builtInGateCrossedTicks;
            FindInclusiveTicks = findInclusiveTicks;
            AreaInclusiveTicks = areaInclusiveTicks;
            DiagnosticOverheadTicks = diagnosticOverheadTicks;
            RequestCount = requestCount;
            FindCallCount = findCallCount;
            AreaCallCount = areaCallCount;
            OmittedSamples = omittedSamples;
            TargetEpoch = targetEpoch;
            TargetZoneX = targetZoneX;
            TargetZoneY = targetZoneY;
            HasTargetZone = hasTargetZone;
            Branch = branch;
            BranchEpoch = branchEpoch;
            AfterDeath = afterDeath;
            SpawnFailed = spawnFailed;
            RequestedDelay = requestedDelay;
            RespawnLoadDuration = respawnLoadDuration;
            Route = route;
            World = world;
            MinimapLoadHits = minimapLoadHits;
            MinimapLoadMisses = minimapLoadMisses;
            MinimapLoadErrors = minimapLoadErrors;
            MinimapGenerationCount = minimapGenerationCount;
            MinimapGenerationErrors = minimapGenerationErrors;
            MinimapLoadMilliseconds = minimapLoadMilliseconds;
            MinimapGenerationMilliseconds =
                minimapGenerationMilliseconds;
            OmittedMinimapEvents = omittedMinimapEvents;
            MinimapEvents = minimapEvents;
            Samples = samples;
            Warnings = warnings;
        }

        internal bool RequestObserved { get; }
        internal long RequestTicks { get; }
        internal long ActivationTicks { get; }
        internal long SpawnStartedTicks { get; }
        internal long SpawnCompletedTicks { get; }
        internal long FirstFindTicks { get; }
        internal long FindSucceededTicks { get; }
        internal long FirstAreaCheckTicks { get; }
        internal long AreaReadyTicks { get; }
        internal long ZoneLoadedTicks { get; }
        internal long ActiveAreaLoadedTicks { get; }
        internal long BuiltInGateCrossedTicks { get; }
        internal long FindInclusiveTicks { get; }
        internal long AreaInclusiveTicks { get; }
        internal long DiagnosticOverheadTicks { get; }
        internal int RequestCount { get; }
        internal int FindCallCount { get; }
        internal int AreaCallCount { get; }
        internal int OmittedSamples { get; }
        internal int TargetEpoch { get; }
        internal int TargetZoneX { get; }
        internal int TargetZoneY { get; }
        internal bool HasTargetZone { get; }
        internal SpawnBranch Branch { get; }
        internal int BranchEpoch { get; }
        internal bool AfterDeath { get; }
        internal bool SpawnFailed { get; }
        internal float RequestedDelay { get; }
        internal float RespawnLoadDuration { get; }
        internal string Route { get; }
        internal string World { get; }
        internal int MinimapLoadHits { get; }
        internal int MinimapLoadMisses { get; }
        internal int MinimapLoadErrors { get; }
        internal int MinimapLoadCount =>
            MinimapLoadHits +
            MinimapLoadMisses +
            MinimapLoadErrors;
        internal int MinimapGenerationCount { get; }
        internal int MinimapGenerationErrors { get; }
        internal double MinimapLoadMilliseconds { get; }
        internal double MinimapGenerationMilliseconds { get; }
        internal int OmittedMinimapEvents { get; }
        internal MinimapEvent[] MinimapEvents { get; }
        internal ReadinessSample[] Samples { get; }
        internal string[] Warnings { get; }
    }
}

internal static class SpawnReadinessRequestPatch
{
    internal static void Prefix(
        Game __instance,
        float delay,
        bool afterDeath)
    {
        try
        {
            SpawnReadinessProfiler.ObserveRequest(
                __instance,
                delay,
                afterDeath);
        }
        catch
        {
        }
    }
}

internal static class SpawnReadinessActivationPatch
{
    internal static void Prefix(out long __state)
    {
        try
        {
            __state = SpawnReadinessProfiler.BeginActivation();
        }
        catch
        {
            __state = 0L;
        }
    }

    internal static void Postfix(
        Game __instance,
        long __state)
    {
        try
        {
            SpawnReadinessProfiler.CompleteActivation(
                __instance,
                __state);
        }
        catch
        {
        }
    }

    internal static Exception? Finalizer(
        long __state,
        Exception? __exception)
    {
        try
        {
            if (__exception != null)
            {
                SpawnReadinessProfiler.ActivationFailed(
                    __state,
                    __exception);
            }
        }
        catch
        {
        }

        return __exception;
    }
}

internal static class SpawnReadinessFindSpawnPointPatch
{
    internal static void Prefix(
        Game __instance,
        float dt,
        out SpawnReadinessProfiler.FindCallState __state)
    {
        try
        {
            __state =
                SpawnReadinessProfiler.BeginFindSpawnPoint(
                    __instance,
                    dt);
        }
        catch
        {
            __state = default;
        }
    }

    internal static void Postfix(
        bool __result,
        ref bool usedLogoutPoint,
        SpawnReadinessProfiler.FindCallState __state)
    {
        try
        {
            SpawnReadinessProfiler.CompleteFindSpawnPoint(
                __result,
                usedLogoutPoint,
                __state);
        }
        catch
        {
        }
    }

    internal static Exception? Finalizer(
        SpawnReadinessProfiler.FindCallState __state,
        Exception? __exception)
    {
        try
        {
            return SpawnReadinessProfiler.FinishFindSpawnPoint(
                __state,
                __exception);
        }
        catch
        {
            return __exception;
        }
    }
}

internal static class SpawnReadinessAreaReadyPatch
{
    internal static void Prefix(
        out SpawnReadinessProfiler.AreaCallState __state)
    {
        try
        {
            __state = SpawnReadinessProfiler.BeginAreaReady();
        }
        catch
        {
            __state = default;
        }
    }

    internal static void Postfix(
        ZNetScene __instance,
        Vector3 point,
        bool __result,
        SpawnReadinessProfiler.AreaCallState __state)
    {
        try
        {
            SpawnReadinessProfiler.CompleteAreaReady(
                __instance,
                point,
                __result,
                __state);
        }
        catch
        {
        }
    }

    internal static Exception? Finalizer(
        SpawnReadinessProfiler.AreaCallState __state,
        Exception? __exception)
    {
        try
        {
            return SpawnReadinessProfiler.FinishAreaReady(
                __state,
                __exception);
        }
        catch
        {
            return __exception;
        }
    }
}

internal static class SpawnReadinessMinimapLoadPatch
{
    internal static void Prefix(
        out SpawnReadinessProfiler.MinimapCallState __state)
    {
        try
        {
            __state = SpawnReadinessProfiler.BeginMinimapCall();
        }
        catch
        {
            __state = default;
        }
    }

    internal static void Postfix(
        bool __result,
        SpawnReadinessProfiler.MinimapCallState __state)
    {
        try
        {
            SpawnReadinessProfiler.CompleteMinimapLoad(
                __state,
                __result);
        }
        catch
        {
        }
    }

    internal static Exception? Finalizer(
        SpawnReadinessProfiler.MinimapCallState __state,
        Exception? __exception)
    {
        try
        {
            if (__exception != null)
            {
                SpawnReadinessProfiler.MinimapLoadFailed(
                    __state,
                    __exception);
            }
        }
        catch
        {
        }

        return __exception;
    }
}

internal static class SpawnReadinessMinimapGenerationPatch
{
    internal static void Prefix(
        out SpawnReadinessProfiler.MinimapCallState __state)
    {
        try
        {
            __state = SpawnReadinessProfiler.BeginMinimapCall();
        }
        catch
        {
            __state = default;
        }
    }

    internal static Exception? Finalizer(
        SpawnReadinessProfiler.MinimapCallState __state,
        Exception? __exception)
    {
        try
        {
            SpawnReadinessProfiler.CompleteMinimapGeneration(
                __state,
                __exception);
        }
        catch
        {
        }

        return __exception;
    }
}
