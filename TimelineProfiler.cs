using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace LoadTimeProfiler;

internal enum ProfileSession
{
    Startup,
    Connection
}

[Flags]
internal enum ProfileSessionMask
{
    None = 0,
    Startup = 1,
    Connection = 2
}

internal static class TimelineProfiler
{
    private static readonly object Lock = new();
    private static readonly SessionState Startup = new(ProfileSession.Startup, "Start To Lobby");
    private static readonly SessionState Connection = new(ProfileSession.Connection, "Lobby To World");
    private static double _patcherStartMilliseconds;

    internal static void CapturePatcherStart()
    {
        lock (Lock)
        {
            if (_patcherStartMilliseconds <= 0d)
            {
                _patcherStartMilliseconds = NowMilliseconds();
            }
        }
    }

    internal static void BeginStartup(bool dedicatedServer)
    {
        if (!LoadTimeProfilerPatcher.ProfilingEnabled)
        {
            return;
        }

        LifecyclePhaseProfiler.ResetSession(ProfileSession.Startup);
        ChainloaderProfiler.ResetSession();
        StartupAcceleration.ResetSession(ProfileSession.Startup);
        if (dedicatedServer)
        {
            DeepLobbyAttributionProfiler.ResetSession();
        }

        lock (Lock)
        {
            double now = NowMilliseconds();
            double started = _patcherStartMilliseconds > 0d ? _patcherStartMilliseconds : now;
            Startup.Begin(started, dedicatedServer ? "Server Startup" : "Start To Lobby");
            Startup.AddMilestone("LoadTimeProfiler.Patcher.Finish", started);
            Startup.AddMilestone("LoadTimeProfiler.Patcher initialized", now);
        }
    }

    internal static void BeginConnection(string label, bool restartActive)
    {
        if (!LoadTimeProfilerPatcher.ProfilingEnabled)
        {
            return;
        }

        if (restartActive)
        {
            CancelConnection("superseded by " + label);
        }

        lock (Lock)
        {
            if (Connection.Active)
            {
                Connection.AddMilestoneOnce(label, NowMilliseconds());
                return;
            }
        }

        LifecyclePhaseProfiler.ResetSession(ProfileSession.Connection);
        DeepLobbyAttributionProfiler.ResetSession();
        StartupAcceleration.ResetSession(ProfileSession.Connection);
        SpawnReadinessProfiler.ResetSession();
        lock (Lock)
        {
            double now = NowMilliseconds();
            if (Connection.Active)
            {
                Connection.AddMilestoneOnce(label, now);
                return;
            }

            Connection.Begin(now);
            Connection.AddMilestone(label, now);
        }
    }

    internal static void MarkStartup(string label)
    {
        Mark(Startup, label);
    }

    internal static void MarkConnection(string label)
    {
        Mark(Connection, label);
    }

    internal static bool IsActive(ProfileSession session)
    {
        lock (Lock)
        {
            return GetState(session).Active;
        }
    }

    internal static ProfileSessionMask GetActiveSessionMask()
    {
        lock (Lock)
        {
            ProfileSessionMask mask = ProfileSessionMask.None;
            if (Startup.Active)
            {
                mask |= ProfileSessionMask.Startup;
            }

            if (Connection.Active)
            {
                mask |= ProfileSessionMask.Connection;
            }

            return mask;
        }
    }

    internal static double GetElapsedSincePatcherStart()
    {
        lock (Lock)
        {
            return _patcherStartMilliseconds <= 0d
                ? 0d
                : Math.Max(0d, NowMilliseconds() - _patcherStartMilliseconds);
        }
    }

    internal static void CompleteStartup(string label)
    {
        Finish(Startup, label, "completed");
    }

    internal static void AbortStartup(string label)
    {
        Finish(Startup, label, "aborted");
    }

    internal static void CompleteConnection(string label)
    {
        Finish(Connection, label, "completed");
    }

    internal static void AbortConnection(string label)
    {
        MarkConnectionFailureDecision(label);
        Finish(Connection, label, "failed");
    }

    internal static void CancelConnection(string label)
    {
        bool failureWasAlreadyDecided;
        lock (Lock)
        {
            failureWasAlreadyDecided = Connection.HasFailureDecision;
        }

        Finish(
            Connection,
            label,
            failureWasAlreadyDecided ? "failed" : "cancelled");
    }

    internal static void MarkConnectionFailureDecision(string reason)
    {
        if (!LoadTimeProfilerPatcher.ProfilingEnabled)
        {
            return;
        }

        lock (Lock)
        {
            if (Connection.Active)
            {
                Connection.MarkFailureDecision(NowMilliseconds(), reason);
            }
        }
    }

    internal static void MarkConnectionLogoutCandidate(string observation)
    {
        if (!LoadTimeProfilerPatcher.ProfilingEnabled)
        {
            return;
        }

        lock (Lock)
        {
            if (Connection.Active)
            {
                Connection.MarkLogoutCandidate(
                    NowMilliseconds(),
                    observation);
            }
        }
    }

    internal static void ConfirmConnectionFailureDecision(string reason)
    {
        if (!LoadTimeProfilerPatcher.ProfilingEnabled)
        {
            return;
        }

        lock (Lock)
        {
            if (Connection.Active)
            {
                Connection.ConfirmFailureDecision(
                    NowMilliseconds(),
                    reason);
            }
        }
    }

    private static void Mark(SessionState state, string label)
    {
        if (!LoadTimeProfilerPatcher.ProfilingEnabled)
        {
            return;
        }

        lock (Lock)
        {
            if (state.Active)
            {
                state.AddMilestoneOnce(label, NowMilliseconds());
            }
        }
    }

    private static void Finish(SessionState state, string label, string result)
    {
        SessionSnapshot snapshot;
        lock (Lock)
        {
            if (!state.Active)
            {
                return;
            }

            double now = NowMilliseconds();
            state.AddMilestone(label, now);
            snapshot = state.Complete(now, result);
        }

        if (snapshot.Session == ProfileSession.Connection)
        {
            SpawnReadinessProfiler.CloseSession();
        }

        StringBuilder builder = new();
        builder.AppendLine($"=== {snapshot.Name} ===");
        builder.AppendLine($"Result: {snapshot.Result}");
        builder.Append("Total: ").AppendLine(FormatDuration(snapshot.TotalMilliseconds));
        if (snapshot.Session == ProfileSession.Connection)
        {
            AppendConnectionOutcome(builder, snapshot);
        }

        Dictionary<string, double> lifecycleExecutionTimes =
            LifecyclePhaseProfiler.SnapshotSingleExecutionTimes(snapshot.Session);
        AppendMilestoneIntervals(builder, snapshot.Milestones, lifecycleExecutionTimes);
        if (snapshot.Session == ProfileSession.Connection)
        {
            SpawnReadinessProfiler.AppendReport(builder);
        }

        StartupAcceleration.AppendReport(builder, snapshot.Session);
        ConnectionStability.AppendReport(builder, snapshot.Session);
        if (snapshot.Session == ProfileSession.Startup)
        {
            ChainloaderProfiler.AppendStartupReport(builder);
        }

        LifecyclePhaseProfiler.AppendSessionReport(builder, snapshot.Session);
        if (snapshot.Session == ProfileSession.Connection ||
            snapshot.Session == ProfileSession.Startup && LoadTimeProfilerPatcher.IsDedicatedServer)
        {
            DeepLobbyAttributionProfiler.AppendReport(builder);
        }

        ProfilerLog.WriteBlock(builder.ToString());
        LoadTimeProfilerPatcher.LogInfo($"{snapshot.Name} profile {snapshot.Result}: {FormatDuration(snapshot.TotalMilliseconds)}. See {ProfilerLog.FilePath}.");
    }

    private static void AppendConnectionOutcome(
        StringBuilder builder,
        SessionSnapshot snapshot)
    {
        builder.AppendLine("Connection outcome:");
        if (string.Equals(snapshot.Result, "completed", StringComparison.Ordinal))
        {
            builder.Append("  Normal connection time: ")
                .AppendLine(FormatDuration(snapshot.TotalMilliseconds));
            return;
        }

        if (string.Equals(snapshot.Result, "failed", StringComparison.Ordinal))
        {
            double decisionMilliseconds =
                snapshot.FailureDecisionMilliseconds ?? snapshot.TotalMilliseconds;
            builder.Append("  Failure: ")
                .AppendLine(snapshot.FailureReason ?? "unknown");
            builder.Append("  Time to failure decision: ")
                .AppendLine(FormatDuration(decisionMilliseconds));
            builder.Append("  Return to lobby/error display after decision: ")
                .AppendLine(
                    FormatDuration(
                        Math.Max(
                            0d,
                            snapshot.TotalMilliseconds - decisionMilliseconds)));
            return;
        }

        builder.Append("  Cancelled attempt time: ")
            .AppendLine(FormatDuration(snapshot.TotalMilliseconds));
    }

    private static void AppendMilestoneIntervals(
        StringBuilder builder,
        Milestone[] milestones,
        IReadOnlyDictionary<string, double> lifecycleExecutionTimes)
    {
        builder.AppendLine("Milestone intervals:");
        builder.AppendLine("  Breakdown: lifecycle execution + remaining time until the next milestone.");
        if (milestones.Length < 2)
        {
            builder.AppendLine("  No milestone interval completed.");
            return;
        }

        for (int i = 0; i < milestones.Length - 1; i++)
        {
            Milestone current = milestones[i];
            Milestone next = milestones[i + 1];
            double rawIntervalMilliseconds = Math.Max(
                0d,
                next.ElapsedMilliseconds - current.ElapsedMilliseconds);
            double intervalMilliseconds = Math.Truncate(rawIntervalMilliseconds);
            builder.Append("  ")
                .Append(FormatSeconds(intervalMilliseconds));
            if (lifecycleExecutionTimes.TryGetValue(current.Label, out double executionMilliseconds) &&
                executionMilliseconds <= rawIntervalMilliseconds)
            {
                double displayedExecutionMilliseconds = Math.Min(
                    intervalMilliseconds,
                    Math.Truncate(Math.Max(0d, executionMilliseconds)));
                double remainingMilliseconds = intervalMilliseconds - displayedExecutionMilliseconds;
                builder.Append(" (")
                    .Append(FormatSeconds(displayedExecutionMilliseconds))
                    .Append(" + ")
                    .Append(FormatSeconds(remainingMilliseconds))
                    .Append(')');
            }

            builder.Append(": ").AppendLine(current.Label);
        }
    }

    private static SessionState GetState(ProfileSession session)
    {
        return session == ProfileSession.Startup ? Startup : Connection;
    }

    private static double NowMilliseconds()
    {
        return Stopwatch.GetTimestamp() * 1000d / Stopwatch.Frequency;
    }

    internal static string FormatDuration(double milliseconds)
    {
        if (milliseconds >= 60000d)
        {
            int minutes = (int)(milliseconds / 60000d);
            double seconds = (milliseconds - minutes * 60000d) / 1000d;
            return $"{minutes} min {seconds:00.000} s";
        }

        if (milliseconds >= 1000d)
        {
            return $"{milliseconds / 1000d:0.000} s";
        }

        return $"{milliseconds:0.###} ms";
    }

    internal static string FormatSeconds(double milliseconds)
    {
        double truncatedSeconds = Math.Truncate(Math.Max(0d, milliseconds)) / 1000d;
        return truncatedSeconds.ToString("0.000", CultureInfo.InvariantCulture) + " s";
    }

    private sealed class SessionState
    {
        private readonly List<Milestone> _milestones = new();
        private readonly HashSet<string> _seenMilestones = new(StringComparer.Ordinal);
        private double? _failureDecisionMilliseconds;
        private string? _failureReason;
        private double? _logoutCandidateMilliseconds;
        private string? _logoutCandidateObservation;

        internal SessionState(ProfileSession session, string name)
        {
            Session = session;
            Name = name;
        }

        internal ProfileSession Session { get; }
        internal string Name { get; private set; }
        internal bool Active { get; private set; }
        internal bool HasFailureDecision => _failureDecisionMilliseconds.HasValue;
        private double StartMilliseconds { get; set; }

        internal void Begin(double startMilliseconds, string? name = null)
        {
            if (!string.IsNullOrEmpty(name))
            {
                Name = name!;
            }

            Active = true;
            StartMilliseconds = startMilliseconds;
            _milestones.Clear();
            _seenMilestones.Clear();
            _failureDecisionMilliseconds = null;
            _failureReason = null;
            _logoutCandidateMilliseconds = null;
            _logoutCandidateObservation = null;
        }

        internal void AddMilestoneOnce(string label, double absoluteMilliseconds)
        {
            if (_seenMilestones.Add(label))
            {
                AddMilestone(label, absoluteMilliseconds);
            }
        }

        internal void AddMilestone(string label, double absoluteMilliseconds)
        {
            _seenMilestones.Add(label);
            _milestones.Add(new Milestone(label, Math.Max(0d, absoluteMilliseconds - StartMilliseconds)));
        }

        internal void MarkFailureDecision(
            double absoluteMilliseconds,
            string reason)
        {
            if (_failureDecisionMilliseconds.HasValue)
            {
                return;
            }

            _failureDecisionMilliseconds = Math.Max(
                0d,
                absoluteMilliseconds - StartMilliseconds);
            _failureReason = reason;
            AddMilestone(
                "Connection failure decided: " + reason,
                absoluteMilliseconds);
        }

        internal void MarkLogoutCandidate(
            double absoluteMilliseconds,
            string observation)
        {
            if (_logoutCandidateMilliseconds.HasValue)
            {
                return;
            }

            _logoutCandidateMilliseconds = Math.Max(
                0d,
                absoluteMilliseconds - StartMilliseconds);
            _logoutCandidateObservation = observation;
        }

        internal void ConfirmFailureDecision(
            double absoluteMilliseconds,
            string reason)
        {
            if (_failureDecisionMilliseconds.HasValue)
            {
                return;
            }

            _failureDecisionMilliseconds =
                _logoutCandidateMilliseconds ??
                Math.Max(0d, absoluteMilliseconds - StartMilliseconds);
            _failureReason = _logoutCandidateObservation == null
                ? reason
                : reason + " (logout first observed as " +
                  _logoutCandidateObservation + ")";
            AddMilestone(
                "Connection failure confirmed: " + reason,
                absoluteMilliseconds);
        }

        internal SessionSnapshot Complete(double absoluteMilliseconds, string result)
        {
            Active = false;
            double total = Math.Max(0d, absoluteMilliseconds - StartMilliseconds);
            return new SessionSnapshot(
                Session,
                Name,
                result,
                total,
                _milestones.ToArray(),
                _failureDecisionMilliseconds,
                _failureReason);
        }
    }

    private readonly struct SessionSnapshot
    {
        internal SessionSnapshot(
            ProfileSession session,
            string name,
            string result,
            double totalMilliseconds,
            Milestone[] milestones,
            double? failureDecisionMilliseconds,
            string? failureReason)
        {
            Session = session;
            Name = name;
            Result = result;
            TotalMilliseconds = totalMilliseconds;
            Milestones = milestones;
            FailureDecisionMilliseconds = failureDecisionMilliseconds;
            FailureReason = failureReason;
        }

        internal ProfileSession Session { get; }
        internal string Name { get; }
        internal string Result { get; }
        internal double TotalMilliseconds { get; }
        internal Milestone[] Milestones { get; }
        internal double? FailureDecisionMilliseconds { get; }
        internal string? FailureReason { get; }
    }

    private readonly struct Milestone
    {
        internal Milestone(string label, double elapsedMilliseconds)
        {
            Label = label;
            ElapsedMilliseconds = elapsedMilliseconds;
        }

        internal string Label { get; }
        internal double ElapsedMilliseconds { get; }
    }
}
