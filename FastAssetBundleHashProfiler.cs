using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using BepInEx;
using HarmonyLib;

namespace LoadTimeProfiler;

/// <summary>
/// Measures FastAssetBundleLoader's original-bundle hash work during startup.
/// The source scope deliberately excludes ComputeHash(string), which is also
/// used for cache-output verification and is not original-source work.
/// </summary>
internal static class FastAssetBundleHashProfiler
{
    private const string CacheManagerTypeName =
        "FastAssetBundleLoader.Managers.AssetBundleCacheManager";
    private const string HashingHelperTypeName =
        "FastAssetBundleLoader.Helpers.HashingHelper";
    private const int MaxTrackedSources = 256;
    private const int MaxReportedSources = 8;

    private static readonly object Lock = new();
    private static readonly Harmony Harmony =
        new(LoadTimeProfilerPatcher.ModGUID + ".fast-asset-bundle-hash-profile");
    private static readonly Dictionary<string, MutableSourceTiming> Sources =
        new(StringComparer.OrdinalIgnoreCase);

    [ThreadStatic]
    private static int _sourceScopeDepth;

    [ThreadStatic]
    private static SourceIdentity? _currentSource;

    [ThreadStatic]
    private static int _hashDepth;

    private static bool _installAttempted;
    private static volatile bool _active;
    private static bool _sourceScopeHookInstalled;
    private static bool _streamHashHookInstalled;
    private static int _calls;
    private static int _failedCalls;
    private static int _unknownByteCalls;
    private static long _knownBytes;
    private static long _callbackOverheadTicks;
    private static double _totalMilliseconds;
    private static double _maxMilliseconds;
    private static string _maxSource = "unknown source";

    /// <summary>
    /// Call after TimelineProfiler.BeginStartup and before Chainloader.Start.
    /// Missing types or changed signatures are reported and otherwise ignored.
    /// </summary>
    internal static void InstallBeforeChainloader()
    {
        lock (Lock)
        {
            if (_installAttempted)
            {
                return;
            }

            _installAttempted = true;
            ResetMetricsLocked();
        }

        try
        {
            Type? cacheManagerType =
                AccessTools.TypeByName(CacheManagerTypeName);
            Type? hashingHelperType =
                AccessTools.TypeByName(HashingHelperTypeName);
            if (cacheManagerType == null ||
                hashingHelperType == null)
            {
                ProfilerLog.WriteLine(
                    "FastAssetBundleLoader original hash diagnostic unavailable: compatible runtime types were not loaded.");
                return;
            }

            MethodInfo? sourceScopeMethod =
                cacheManagerType.GetMethod(
                    "TryUseCachedBundle",
                    BindingFlags.Instance |
                    BindingFlags.Public |
                    BindingFlags.NonPublic,
                    binder: null,
                    types: new[]
                    {
                        typeof(Stream),
                        typeof(string).MakeByRefType()
                    },
                    modifiers: null);
            MethodInfo? streamHashMethod =
                hashingHelperType.GetMethod(
                    "ComputeHash",
                    BindingFlags.Static |
                    BindingFlags.Public |
                    BindingFlags.NonPublic,
                    binder: null,
                    types: new[] { typeof(Stream) },
                    modifiers: null);

            _sourceScopeHookInstalled = TryPatch(
                sourceScopeMethod,
                nameof(SourceScopePrefix),
                nameof(SourceScopeFinalizer),
                int.MaxValue,
                int.MinValue,
                "AssetBundleCacheManager.TryUseCachedBundle(Stream)");
            _streamHashHookInstalled = TryPatch(
                streamHashMethod,
                nameof(StreamHashPrefix),
                nameof(StreamHashFinalizer),
                int.MinValue,
                int.MaxValue,
                "HashingHelper.ComputeHash(Stream)");

            _active =
                TimelineProfiler.IsActive(ProfileSession.Startup) &&
                _sourceScopeHookInstalled &&
                _streamHashHookInstalled;

            if (_active)
            {
                ProfilerLog.WriteLine(
                    "FastAssetBundleLoader original-source hash diagnostic installed for TryUseCachedBundle(Stream).");
            }
            else
            {
                ProfilerLog.WriteLine(
                    "FastAssetBundleLoader original hash diagnostic unavailable: " +
                    $"source scope={FormatHookState(_sourceScopeHookInstalled)}, " +
                    $"stream hash={FormatHookState(_streamHashHookInstalled)}. " +
                    "Original behavior retained.");
            }
        }
        catch (Exception ex)
        {
            _active = false;
            ProfilerLog.WriteLine(
                "FastAssetBundleLoader original hash diagnostic warning; original behavior retained: " +
                ex.Message);
        }
    }

    /// <summary>
    /// Optional reset hook for the startup session reset path. Installation
    /// also clears all metrics, so calling this is not required for first use.
    /// </summary>
    internal static void ResetSession(ProfileSession session)
    {
        if (session != ProfileSession.Startup)
        {
            return;
        }

        lock (Lock)
        {
            ResetMetricsLocked();
            _active =
                _sourceScopeHookInstalled &&
                _streamHashHookInstalled;
        }
    }

    /// <summary>
    /// Appends one compact startup-only section and closes the measurement
    /// window so hashes after the lobby appears are not included.
    /// </summary>
    internal static void AppendReport(
        StringBuilder builder,
        ProfileSession session)
    {
        if (session != ProfileSession.Startup)
        {
            return;
        }

        SourceTimingSnapshot[] sources;
        int calls;
        int failedCalls;
        int unknownByteCalls;
        long knownBytes;
        long callbackOverheadTicks;
        double totalMilliseconds;
        double maxMilliseconds;
        string maxSource;
        bool installAttempted;
        bool sourceScopeHookInstalled;
        bool streamHashHookInstalled;
        lock (Lock)
        {
            _active = false;
            sources = Sources.Values
                .Select(value => value.Snapshot())
                .ToArray();
            calls = _calls;
            failedCalls = _failedCalls;
            unknownByteCalls = _unknownByteCalls;
            knownBytes = _knownBytes;
            callbackOverheadTicks =
                Interlocked.Read(
                    ref _callbackOverheadTicks);
            totalMilliseconds = _totalMilliseconds;
            maxMilliseconds = _maxMilliseconds;
            maxSource = _maxSource;
            installAttempted = _installAttempted;
            sourceScopeHookInstalled =
                _sourceScopeHookInstalled;
            streamHashHookInstalled =
                _streamHashHookInstalled;
        }

        builder.AppendLine(
            "FastAssetBundleLoader original-source hashing:");
        if (!sourceScopeHookInstalled ||
            !streamHashHookInstalled)
        {
            builder.Append("  Diagnostic unavailable; source scope=")
                .Append(
                    FormatHookState(
                        sourceScopeHookInstalled))
                .Append(", stream hash=")
                .Append(
                    FormatHookState(
                        streamHashHookInstalled))
                .Append(", install=")
                .AppendLine(
                    installAttempted
                        ? "attempted"
                        : "not attempted");
            return;
        }

        builder.Append("  Calls: ")
            .Append(calls)
            .Append(", original bytes=")
            .Append(FormatBytes(knownBytes));
        if (unknownByteCalls > 0)
        {
            builder.Append(", unknown-size calls=")
                .Append(unknownByteCalls);
        }

        if (failedCalls > 0)
        {
            builder.Append(", failed calls=")
                .Append(failedCalls);
        }

        builder.AppendLine();
        builder.Append("  Original hash elapsed: total=")
            .Append(
                TimelineProfiler.FormatDuration(
                    totalMilliseconds))
            .Append(", max=")
            .Append(
                TimelineProfiler.FormatDuration(
                    maxMilliseconds))
            .Append(" (")
            .Append(maxSource)
            .AppendLine(")");
        builder.Append("  Diagnostic callback overhead (measured lower bound): ")
            .AppendLine(
                TimelineProfiler.FormatDuration(
                    TicksToMilliseconds(
                        callbackOverheadTicks)));

        if (sources.Length == 0)
        {
            builder.AppendLine(
                "  No original-source hash calls were measured during startup.");
            return;
        }

        builder.AppendLine("  Slowest source streams:");
        foreach (SourceTimingSnapshot source in sources
                     .OrderByDescending(
                         value =>
                             value.TotalMilliseconds)
                     .Take(MaxReportedSources))
        {
            builder.Append("    ")
                .Append(
                    TimelineProfiler.FormatDuration(
                        source.TotalMilliseconds))
                .Append(" total, ")
                .Append(source.Count)
                .Append(" call");
            if (source.Count != 1)
            {
                builder.Append('s');
            }

            builder.Append(", max ")
                .Append(
                    TimelineProfiler.FormatDuration(
                        source.MaxMilliseconds))
                .Append(", ")
                .Append(
                    FormatBytes(
                        source.KnownBytes));
            if (source.UnknownByteCalls > 0)
            {
                builder.Append(" + ")
                    .Append(source.UnknownByteCalls)
                    .Append(" unknown-size");
            }

            builder.Append(": ")
                .Append(source.Owner)
                .Append(" - ")
                .AppendLine(source.Source);
        }

        int omitted = Math.Max(
            0,
            sources.Length -
            MaxReportedSources);
        if (omitted > 0)
        {
            builder.Append("    ... ")
                .Append(omitted)
                .AppendLine(
                    " additional source stream(s) omitted.");
        }
    }

    private static bool TryPatch(
        MethodInfo? target,
        string prefixName,
        string finalizerName,
        int prefixPriority,
        int finalizerPriority,
        string displayName)
    {
        if (target == null ||
            target.IsAbstract ||
            target.ContainsGenericParameters)
        {
            return false;
        }

        try
        {
            MethodInfo? prefix =
                AccessTools.Method(
                    typeof(
                        FastAssetBundleHashProfiler),
                    prefixName);
            MethodInfo? finalizer =
                AccessTools.Method(
                    typeof(
                        FastAssetBundleHashProfiler),
                    finalizerName);
            if (prefix == null ||
                finalizer == null)
            {
                throw new MissingMethodException(
                    typeof(
                            FastAssetBundleHashProfiler)
                        .FullName,
                    prefix == null
                        ? prefixName
                        : finalizerName);
            }

            Harmony.Patch(
                target,
                prefix: new HarmonyMethod(prefix)
                {
                    priority = prefixPriority
                },
                finalizer: new HarmonyMethod(finalizer)
                {
                    priority = finalizerPriority
                });
            return true;
        }
        catch (Exception ex)
        {
            ProfilerLog.WriteLine(
                "FastAssetBundleLoader original hash diagnostic could not patch " +
                displayName +
                "; original behavior retained: " +
                ex.Message);
            return false;
        }
    }

    private static void SourceScopePrefix(
        Stream __0,
        out SourceScopeState? __state)
    {
        __state = null;
        if (!_active)
        {
            return;
        }

        long overheadStarted =
            Stopwatch.GetTimestamp();
        SourceIdentity? previous =
            _currentSource;
        try
        {
            _sourceScopeDepth++;
            _currentSource =
                ResolveSource(__0);
            __state = new SourceScopeState(
                previous);
        }
        catch
        {
            _sourceScopeDepth =
                Math.Max(
                    0,
                    _sourceScopeDepth - 1);
            _currentSource = previous;
            __state = null;
        }
        finally
        {
            AddCallbackOverhead(
                overheadStarted);
        }
    }

    private static Exception? SourceScopeFinalizer(
        SourceScopeState? __state,
        Exception? __exception)
    {
        if (__state == null)
        {
            return __exception;
        }

        long overheadStarted =
            Stopwatch.GetTimestamp();
        try
        {
            _currentSource =
                __state.PreviousSource;
            _sourceScopeDepth =
                Math.Max(
                    0,
                    _sourceScopeDepth - 1);
        }
        catch
        {
            // Diagnostic cleanup must never replace the original result.
        }
        finally
        {
            AddCallbackOverhead(
                overheadStarted);
        }

        return __exception;
    }

    private static void StreamHashPrefix(
        Stream __0,
        out HashCallState? __state)
    {
        __state = null;
        if (!_active ||
            _sourceScopeDepth <= 0)
        {
            return;
        }

        long overheadStarted =
            Stopwatch.GetTimestamp();
        int previousDepth = _hashDepth;
        try
        {
            _hashDepth =
                previousDepth + 1;
            SourceIdentity source =
                _currentSource ??
                ResolveSource(__0);
            __state = new HashCallState(
                previousDepth == 0,
                source);
        }
        catch
        {
            _hashDepth =
                previousDepth;
            __state = null;
        }

        AddCallbackOverhead(
            overheadStarted);
        if (__state != null &&
            __state.IsRoot)
        {
            // Begin after diagnostic setup so source resolution and callback
            // accounting are excluded from original hash elapsed time.
            __state.StartTimestamp =
                Stopwatch.GetTimestamp();
        }
    }

    private static Exception? StreamHashFinalizer(
        HashCallState? __state,
        Exception? __exception)
    {
        if (__state == null)
        {
            return __exception;
        }

        long hashEnded =
            Stopwatch.GetTimestamp();
        long overheadStarted = hashEnded;
        try
        {
            _hashDepth =
                Math.Max(
                    0,
                    _hashDepth - 1);
            if (__state.IsRoot &&
                __state.StartTimestamp > 0L)
            {
                Record(
                    __state.Source,
                    TicksToMilliseconds(
                        hashEnded -
                        __state.StartTimestamp),
                    __exception != null);
            }
        }
        catch
        {
            // A diagnostic finalizer must preserve the original exception.
        }
        finally
        {
            AddCallbackOverhead(
                overheadStarted);
        }

        return __exception;
    }

    private static SourceIdentity ResolveSource(
        Stream stream)
    {
        long bytes =
            TryGetStreamLength(stream);
        if (stream is FileStream fileStream)
        {
            return ResolvePath(
                fileStream.Name,
                bytes);
        }

        string typeName =
            stream.GetType().FullName ??
            stream.GetType().Name;
        return new SourceIdentity(
            typeName,
            "in-memory/source stream",
            bytes);
    }

    private static SourceIdentity ResolvePath(
        string path,
        long bytes)
    {
        string fullPath;
        try
        {
            fullPath = Path.GetFullPath(path);
        }
        catch
        {
            fullPath = path;
        }

        if (TryMakeRelative(
                fullPath,
                Paths.PluginPath,
                out string pluginRelative))
        {
            string owner =
                FirstPathSegment(
                    pluginRelative);
            if (string.IsNullOrEmpty(owner))
            {
                owner =
                    Path.GetFileNameWithoutExtension(
                        fullPath);
            }

            return new SourceIdentity(
                "plugins/" +
                NormalizeSeparators(
                    pluginRelative),
                owner,
                bytes);
        }

        if (TryMakeRelative(
                fullPath,
                Paths.BepInExRootPath,
                out string bepinexRelative))
        {
            return new SourceIdentity(
                "BepInEx/" +
                NormalizeSeparators(
                    bepinexRelative),
                "BepInEx",
                bytes);
        }

        if (TryMakeRelative(
                fullPath,
                AppContext.BaseDirectory,
                out string gameRelative))
        {
            return new SourceIdentity(
                "game/" +
                NormalizeSeparators(
                    gameRelative),
                "game",
                bytes);
        }

        return new SourceIdentity(
            NormalizeSeparators(fullPath),
            "external path",
            bytes);
    }

    private static long TryGetStreamLength(
        Stream stream)
    {
        try
        {
            return stream.CanSeek
                ? Math.Max(
                    0L,
                    stream.Length)
                : -1L;
        }
        catch
        {
            return -1L;
        }
    }

    private static void Record(
        SourceIdentity source,
        double elapsedMilliseconds,
        bool failed)
    {
        lock (Lock)
        {
            _calls++;
            if (failed)
            {
                _failedCalls++;
            }

            if (source.Bytes >= 0L)
            {
                _knownBytes =
                    SaturatingAdd(
                        _knownBytes,
                        source.Bytes);
            }
            else
            {
                _unknownByteCalls++;
            }

            _totalMilliseconds +=
                elapsedMilliseconds;
            if (elapsedMilliseconds >
                _maxMilliseconds)
            {
                _maxMilliseconds =
                    elapsedMilliseconds;
                _maxSource =
                    source.Owner +
                    " - " +
                    source.Source;
            }

            string key =
                source.Owner +
                "\0" +
                source.Source;
            if (!Sources.TryGetValue(
                    key,
                    out MutableSourceTiming? timing))
            {
                string owner =
                    source.Owner;
                string sourceName =
                    source.Source;
                if (Sources.Count >=
                    MaxTrackedSources)
                {
                    owner = "other";
                    sourceName =
                        "additional source streams";
                    key =
                        owner +
                        "\0" +
                        sourceName;
                }

                if (!Sources.TryGetValue(
                        key,
                        out timing))
                {
                    timing =
                        new MutableSourceTiming(
                            owner,
                            sourceName);
                    Sources.Add(
                        key,
                        timing);
                }
            }

            timing.Add(
                source.Bytes,
                elapsedMilliseconds);
        }
    }

    private static void AddCallbackOverhead(
        long started)
    {
        long elapsed =
            Math.Max(
                0L,
                Stopwatch.GetTimestamp() -
                started);
        Interlocked.Add(
            ref _callbackOverheadTicks,
            elapsed);
    }

    private static void ResetMetricsLocked()
    {
        Sources.Clear();
        _calls = 0;
        _failedCalls = 0;
        _unknownByteCalls = 0;
        _knownBytes = 0L;
        Interlocked.Exchange(
            ref _callbackOverheadTicks,
            0L);
        _totalMilliseconds = 0d;
        _maxMilliseconds = 0d;
        _maxSource = "unknown source";
    }

    private static bool TryMakeRelative(
        string path,
        string root,
        out string relative)
    {
        relative = string.Empty;
        if (string.IsNullOrWhiteSpace(path) ||
            string.IsNullOrWhiteSpace(root))
        {
            return false;
        }

        string normalizedRoot;
        string normalizedPath;
        try
        {
            normalizedRoot =
                Path.GetFullPath(root)
                    .TrimEnd(
                        Path.DirectorySeparatorChar,
                        Path.AltDirectorySeparatorChar);
            normalizedPath =
                Path.GetFullPath(path);
        }
        catch
        {
            return false;
        }

        if (normalizedPath.Equals(
                normalizedRoot,
                StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        string prefix =
            normalizedRoot +
            Path.DirectorySeparatorChar;
        if (!normalizedPath.StartsWith(
                prefix,
                StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        relative =
            normalizedPath.Substring(
                prefix.Length);
        return true;
    }

    private static string FirstPathSegment(
        string relative)
    {
        if (string.IsNullOrWhiteSpace(relative))
        {
            return string.Empty;
        }

        int separator =
            relative.IndexOfAny(
                new[]
                {
                    Path.DirectorySeparatorChar,
                    Path.AltDirectorySeparatorChar
                });
        string segment =
            separator < 0
                ? relative
                : relative.Substring(
                    0,
                    separator);
        return Path.GetFileNameWithoutExtension(
            segment);
    }

    private static string NormalizeSeparators(
        string path)
    {
        return path.Replace(
            '\\',
            '/');
    }

    private static long SaturatingAdd(
        long left,
        long right)
    {
        if (right <= 0L)
        {
            return left;
        }

        return left >
               long.MaxValue -
               right
            ? long.MaxValue
            : left + right;
    }

    private static string FormatHookState(
        bool installed)
    {
        return installed
            ? "installed"
            : "unavailable";
    }

    private static string FormatBytes(
        long bytes)
    {
        if (bytes < 0L)
        {
            return "unknown";
        }

        string[] units =
        {
            "B",
            "KiB",
            "MiB",
            "GiB",
            "TiB"
        };
        double value = bytes;
        int unit = 0;
        while (value >= 1024d &&
               unit < units.Length - 1)
        {
            value /= 1024d;
            unit++;
        }

        string format =
            unit == 0
                ? "0"
                : value >= 100d
                    ? "0.0"
                    : value >= 10d
                        ? "0.00"
                        : "0.000";
        return value.ToString(
                   format,
                   CultureInfo.InvariantCulture) +
               " " +
               units[unit];
    }

    private static double TicksToMilliseconds(
        long ticks)
    {
        return ticks *
               1000d /
               Stopwatch.Frequency;
    }

    private sealed class SourceScopeState
    {
        internal SourceScopeState(
            SourceIdentity? previousSource)
        {
            PreviousSource = previousSource;
        }

        internal SourceIdentity? PreviousSource
        {
            get;
        }
    }

    private sealed class HashCallState
    {
        internal HashCallState(
            bool isRoot,
            SourceIdentity source)
        {
            IsRoot = isRoot;
            Source = source;
        }

        internal bool IsRoot { get; }
        internal SourceIdentity Source { get; }
        internal long StartTimestamp { get; set; }
    }

    private readonly struct SourceIdentity
    {
        internal SourceIdentity(
            string source,
            string owner,
            long bytes)
        {
            Source = source;
            Owner = owner;
            Bytes = bytes;
        }

        internal string Source { get; }
        internal string Owner { get; }
        internal long Bytes { get; }
    }

    private sealed class MutableSourceTiming
    {
        private long _knownBytes;

        internal MutableSourceTiming(
            string owner,
            string source)
        {
            Owner = owner;
            Source = source;
        }

        private string Owner { get; }
        private string Source { get; }
        private int Count { get; set; }
        private int UnknownByteCalls { get; set; }
        private double TotalMilliseconds { get; set; }
        private double MaxMilliseconds { get; set; }

        internal void Add(
            long bytes,
            double elapsedMilliseconds)
        {
            Count++;
            if (bytes >= 0L)
            {
                _knownBytes =
                    SaturatingAdd(
                        _knownBytes,
                        bytes);
            }
            else
            {
                UnknownByteCalls++;
            }

            TotalMilliseconds +=
                elapsedMilliseconds;
            MaxMilliseconds =
                Math.Max(
                    MaxMilliseconds,
                    elapsedMilliseconds);
        }

        internal SourceTimingSnapshot Snapshot()
        {
            return new SourceTimingSnapshot(
                Owner,
                Source,
                Count,
                UnknownByteCalls,
                _knownBytes,
                TotalMilliseconds,
                MaxMilliseconds);
        }
    }

    private readonly struct SourceTimingSnapshot
    {
        internal SourceTimingSnapshot(
            string owner,
            string source,
            int count,
            int unknownByteCalls,
            long knownBytes,
            double totalMilliseconds,
            double maxMilliseconds)
        {
            Owner = owner;
            Source = source;
            Count = count;
            UnknownByteCalls =
                unknownByteCalls;
            KnownBytes = knownBytes;
            TotalMilliseconds =
                totalMilliseconds;
            MaxMilliseconds =
                maxMilliseconds;
        }

        internal string Owner { get; }
        internal string Source { get; }
        internal int Count { get; }
        internal int UnknownByteCalls { get; }
        internal long KnownBytes { get; }
        internal double TotalMilliseconds { get; }
        internal double MaxMilliseconds { get; }
    }
}
