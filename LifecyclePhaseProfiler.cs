using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LoadTimeProfiler;

internal static class LifecyclePhaseProfiler
{
    private static readonly object Lock = new();
    private static readonly List<PhaseContext> ActivePhases = new();
    private static readonly Dictionary<ProfileSession, SessionAggregate> Sessions = new()
    {
        [ProfileSession.Startup] = new SessionAggregate(),
        [ProfileSession.Connection] = new SessionAggregate()
    };
    internal static void BeginTarget(MethodBase target, string label)
    {
        if (!LoadTimeProfilerPatcher.ProfilingEnabled)
        {
            return;
        }

        ProfileSessionMask sessions = TimelineProfiler.GetActiveSessionMask();
        if (sessions == ProfileSessionMask.None)
        {
            return;
        }

        lock (Lock)
        {
            ActivePhases.Add(new PhaseContext(target, label, sessions, Stopwatch.GetTimestamp()));
        }
    }

    internal static void EndTarget(MethodBase target)
    {
        if (!LoadTimeProfilerPatcher.ProfilingEnabled)
        {
            return;
        }

        long end = Stopwatch.GetTimestamp();
        lock (Lock)
        {
            for (int i = ActivePhases.Count - 1; i >= 0; i--)
            {
                PhaseContext context = ActivePhases[i];
                if (context.Target != target)
                {
                    continue;
                }

                ActivePhases.RemoveAt(i);
                double elapsed = TicksToMilliseconds(end - context.StartTimestamp);
                if ((context.Sessions & ProfileSessionMask.Startup) != 0)
                {
                    Sessions[ProfileSession.Startup].Add(context, elapsed);
                }

                if ((context.Sessions & ProfileSessionMask.Connection) != 0)
                {
                    Sessions[ProfileSession.Connection].Add(context, elapsed);
                }

                return;
            }
        }
    }

    internal static void ResetSession(ProfileSession session)
    {
        lock (Lock)
        {
            Sessions[session].Clear();
        }
    }

    internal static Dictionary<string, double> SnapshotSingleExecutionTimes(ProfileSession session)
    {
        lock (Lock)
        {
            return Sessions[session].SnapshotSingleExecutionTimes();
        }
    }

    internal static void AppendSessionReport(StringBuilder builder, ProfileSession session)
    {
        PhaseTiming[] phases;
        lock (Lock)
        {
            phases = Sessions[session].Snapshot();
        }

        builder.AppendLine("Measured lifecycle execution times (prefix -> finalizer, inclusive):");
        if (phases.Length == 0)
        {
            builder.AppendLine("  No profiled lifecycle phase completed.");
        }
        else
        {
            foreach (PhaseTiming phase in phases.OrderByDescending(value => value.ElapsedMilliseconds))
            {
                builder.Append("  ").Append(TimelineProfiler.FormatSeconds(phase.ElapsedMilliseconds));
                if (phase.Count > 1)
                {
                    builder.Append(" x").Append(phase.Count);
                }

                builder.Append(": ").AppendLine(phase.Label);
            }
        }
    }

    private static double TicksToMilliseconds(long ticks)
    {
        return ticks * 1000d / Stopwatch.Frequency;
    }

    private sealed class PhaseContext
    {
        internal PhaseContext(MethodBase target, string label, ProfileSessionMask sessions, long startTimestamp)
        {
            Target = target;
            Label = label;
            Sessions = sessions;
            StartTimestamp = startTimestamp;
        }

        internal MethodBase Target { get; }
        internal string Label { get; }
        internal ProfileSessionMask Sessions { get; }
        internal long StartTimestamp { get; }
    }

    private sealed class SessionAggregate
    {
        private readonly Dictionary<string, MutableTiming> _timings = new(StringComparer.Ordinal);

        internal void Clear()
        {
            _timings.Clear();
        }

        internal void Add(PhaseContext context, double elapsedMilliseconds)
        {
            if (!_timings.TryGetValue(context.Label, out MutableTiming timing))
            {
                timing = new MutableTiming();
                _timings[context.Label] = timing;
            }

            timing.Count++;
            timing.ElapsedMilliseconds += elapsedMilliseconds;
        }

        internal PhaseTiming[] Snapshot()
        {
            return _timings
                .Select(pair => new PhaseTiming(
                    pair.Key,
                    pair.Value.Count,
                    pair.Value.ElapsedMilliseconds))
                .ToArray();
        }

        internal Dictionary<string, double> SnapshotSingleExecutionTimes()
        {
            return _timings
                .Where(pair => pair.Value.Count == 1)
                .ToDictionary(
                    pair => pair.Key,
                    pair => pair.Value.ElapsedMilliseconds,
                    StringComparer.Ordinal);
        }

    }

    private sealed class MutableTiming
    {
        internal int Count { get; set; }
        internal double ElapsedMilliseconds { get; set; }
    }

    private readonly struct PhaseTiming
    {
        internal PhaseTiming(
            string label,
            int count,
            double elapsedMilliseconds)
        {
            Label = label;
            Count = count;
            ElapsedMilliseconds = elapsedMilliseconds;
        }

        internal string Label { get; }
        internal int Count { get; }
        internal double ElapsedMilliseconds { get; }
    }
}
