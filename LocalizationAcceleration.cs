using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using BepInEx.Bootstrap;
using HarmonyLib;
using UnityEngine;

namespace LoadTimeProfiler;

internal static class LocalizationAcceleration
{
    private static readonly object CacheLock = new();
    private static readonly ConditionalWeakTable<TextAsset, AssetCache> Cache = new();
    private static readonly FieldInfo? TranslationsField =
        AccessTools.DeclaredField(typeof(Localization), "m_translations");
    private static readonly MethodInfo? LoadCsvMethod = AccessTools.DeclaredMethod(
        typeof(Localization),
        nameof(Localization.LoadCSV),
        new[] { typeof(TextAsset), typeof(string) });
    private static readonly MethodInfo? AddWordMethod =
        AccessTools.DeclaredMethod(typeof(Localization), "AddWord");
    private static readonly MethodBase[] LoadCsvBodyHelpers =
        new MethodBase?[]
    {
        AccessTools.DeclaredMethod(typeof(Localization), "DoQuoteLineSplit"),
        AccessTools.DeclaredMethod(typeof(Localization), "StripCitations")
    }.Where(method => method != null).Cast<MethodBase>().ToArray();
    private const string HarmonyOwner =
        LoadTimeProfilerPatcher.ModGUID + ".startup-acceleration";

    [ThreadStatic]
    private static Stack<LoadState>? _activeLoads;

    private static long _startupHits;
    private static long _startupMisses;
    private static long _startupReplayTicks;
    private static long _startupParseTicks;
    private static long _startupReplayedWords;
    private static long _connectionHits;
    private static long _connectionMisses;
    private static long _connectionReplayTicks;
    private static long _connectionParseTicks;
    private static long _connectionReplayedWords;
    private static bool _installed;
    private static bool _legacyLocalizationCacheDetected;
    private static bool _foreignBodyPatchDetected;
    private static int _foreignBodyPatchWarningLogged;

    internal static bool Install(Harmony harmony)
    {
        if (TranslationsField == null ||
            TranslationsField.FieldType != typeof(Dictionary<string, string>))
        {
            ProfilerLog.WriteLine(
                "Localization acceleration disabled: Localization.m_translations has an unsupported layout.");
            return false;
        }

        MethodInfo? target = LoadCsvMethod;
        MethodInfo? addWordTarget = AddWordMethod;
        MethodInfo? prefix = AccessTools.DeclaredMethod(typeof(LocalizationAccelerationPatch), "Prefix");
        MethodInfo? postfix = AccessTools.DeclaredMethod(typeof(LocalizationAccelerationPatch), "Postfix");
        MethodInfo? transpiler = AccessTools.DeclaredMethod(typeof(LocalizationAccelerationPatch), "Transpiler");
        MethodInfo? finalizer = AccessTools.DeclaredMethod(typeof(LocalizationAccelerationPatch), "Finalizer");
        MethodInfo? addWordPostfix = AccessTools.DeclaredMethod(
            typeof(LocalizationAddWordCapturePatch),
            nameof(LocalizationAddWordCapturePatch.Postfix));
        if (target == null ||
            addWordTarget == null ||
            prefix == null ||
            postfix == null ||
            transpiler == null ||
            finalizer == null ||
            addWordPostfix == null)
        {
            ProfilerLog.WriteLine("Localization acceleration disabled: required LoadCSV methods were not found.");
            return false;
        }

        try
        {
            // Capture support must be live before the entry guard can possibly
            // cache or replay a LoadCSV call.
            harmony.Patch(
                addWordTarget,
                postfix: new HarmonyMethod(addWordPostfix) { priority = int.MaxValue });
            harmony.Patch(
                target,
                prefix: new HarmonyMethod(prefix) { priority = int.MinValue },
                postfix: new HarmonyMethod(postfix) { priority = int.MaxValue },
                transpiler: new HarmonyMethod(transpiler) { priority = int.MinValue },
                finalizer: new HarmonyMethod(finalizer) { priority = int.MaxValue },
                ilmanipulator: null);
            _installed = true;
            ProfilerLog.WriteLine(
                "Localization acceleration installed: cached AddWord sequences preserve the active dictionary and foreign patches.");
            return true;
        }
        catch (Exception ex)
        {
            try
            {
                harmony.Unpatch(target, HarmonyPatchType.All, harmony.Id);
                harmony.Unpatch(addWordTarget, HarmonyPatchType.All, harmony.Id);
            }
            catch (Exception rollbackException)
            {
                ProfilerLog.WriteLine(
                    "Localization acceleration rollback warning: " + rollbackException.Message);
            }

            _installed = false;
            ProfilerLog.WriteLine("Localization acceleration disabled: " + ex);
            return false;
        }
    }

    internal static void ResetSession(ProfileSession session)
    {
        if (session == ProfileSession.Startup)
        {
            Interlocked.Exchange(ref _startupHits, 0);
            Interlocked.Exchange(ref _startupMisses, 0);
            Interlocked.Exchange(ref _startupReplayTicks, 0);
            Interlocked.Exchange(ref _startupParseTicks, 0);
            Interlocked.Exchange(ref _startupReplayedWords, 0);
            return;
        }

        Interlocked.Exchange(ref _connectionHits, 0);
        Interlocked.Exchange(ref _connectionMisses, 0);
        Interlocked.Exchange(ref _connectionReplayTicks, 0);
        Interlocked.Exchange(ref _connectionParseTicks, 0);
        Interlocked.Exchange(ref _connectionReplayedWords, 0);
    }

    internal static void AppendReport(StringBuilder builder, ProfileSession session)
    {
        long hits;
        long misses;
        long replayTicks;
        long parseTicks;
        long replayedWords;
        if (session == ProfileSession.Startup)
        {
            hits = Interlocked.Read(ref _startupHits);
            misses = Interlocked.Read(ref _startupMisses);
            replayTicks = Interlocked.Read(ref _startupReplayTicks);
            parseTicks = Interlocked.Read(ref _startupParseTicks);
            replayedWords = Interlocked.Read(ref _startupReplayedWords);
        }
        else
        {
            hits = Interlocked.Read(ref _connectionHits);
            misses = Interlocked.Read(ref _connectionMisses);
            replayTicks = Interlocked.Read(ref _connectionReplayTicks);
            parseTicks = Interlocked.Read(ref _connectionParseTicks);
            replayedWords = Interlocked.Read(ref _connectionReplayedWords);
        }

        builder.AppendLine("Localization CSV acceleration:");
        if (_legacyLocalizationCacheDetected)
        {
            builder.AppendLine(
                "  Bypassed because legacy MSchmoecker LocalizationCache is loaded.");
            return;
        }

        if (_foreignBodyPatchDetected)
        {
            builder.AppendLine(
                "  Bypassed after a foreign patch was detected on CSV body work.");
            return;
        }

        if (!LoadTimeProfilerPatcher.LocalizationCacheEnabled)
        {
            builder.AppendLine("  Disabled by config.");
            return;
        }

        if (!_installed)
        {
            builder.AppendLine(
                "  Not installed (unsupported layout or compatibility conflict).");
            return;
        }

        builder.Append("  Cache hits/misses: ")
            .Append(hits)
            .Append('/')
            .AppendLine(misses.ToString());
        builder.Append("  Cached delta replay: ")
            .Append(TimelineProfiler.FormatDuration(ToMilliseconds(replayTicks)))
            .Append(", assignments/removals applied=")
            .AppendLine(replayedWords.ToString());
        builder.Append("  Uncached CSV work observed: ")
            .AppendLine(TimelineProfiler.FormatDuration(ToMilliseconds(parseTicks)));
    }

    internal static void BeginLoad(
        Localization instance,
        TextAsset file,
        string language,
        out LoadState state)
    {
        state = new LoadState
        {
            Instance = instance,
            File = file,
            Language = language,
            SessionMask = TimelineProfiler.GetActiveSessionMask(),
            StartedTimestamp = Stopwatch.GetTimestamp()
        };

        try
        {
            if (!_installed ||
                !LoadTimeProfilerPatcher.LocalizationCacheEnabled ||
                file == null ||
                string.IsNullOrEmpty(language) ||
                TranslationsField?.GetValue(instance) is not Dictionary<string, string> translations)
            {
                state.Cacheable = false;
            }
            else
            {
                state.Cacheable = true;
                state.BeforeDictionary = translations;
                if (HasUnsafeForeignBodyPatches())
                {
                    state.Cacheable = false;
                    _foreignBodyPatchDetected = true;
                    if (Interlocked.Exchange(ref _foreignBodyPatchWarningLogged, 1) == 0)
                    {
                        ProfilerLog.WriteLine(
                            "Localization acceleration stopped fail-open after a foreign CSV body patch was detected.");
                    }
                }

                lock (CacheLock)
                {
                    if (state.Cacheable)
                    {
                        AssetCache assetCache = Cache.GetValue(file, _ => new AssetCache());
                        assetCache.ByLanguage.TryGetValue(language, out CacheEntry? entry);
                        state.CacheEntry = entry;
                    }
                }

                if (state.CacheEntry == null)
                {
                    state.Before = new Dictionary<string, string>(translations, StringComparer.Ordinal);
                    state.Writes = new List<WriteOperation>();
                }
            }
        }
        catch (Exception ex)
        {
            state.Cacheable = false;
            ProfilerLog.WriteLine("Localization cache prefix warning: " + ex.Message);
        }

        (_activeLoads ??= new Stack<LoadState>()).Push(state);
    }

    internal static void NoteLegacyLocalizationCache()
    {
        _legacyLocalizationCacheDetected = true;
    }

    internal static bool TryReplayCurrent()
    {
        Stack<LoadState>? activeLoads = _activeLoads;
        if (activeLoads == null || activeLoads.Count == 0)
        {
            return false;
        }

        LoadState state = activeLoads.Peek();
        state.BodyEntered = true;
        if (!state.Cacheable || state.CacheEntry == null)
        {
            return false;
        }

        long started = Stopwatch.GetTimestamp();
        try
        {
            if (TranslationsField?.GetValue(state.Instance) is not Dictionary<string, string> translations)
            {
                return false;
            }

            foreach (string removedKey in state.CacheEntry.RemovedKeys)
            {
                translations.Remove(removedKey);
            }

            foreach (WriteOperation write in state.CacheEntry.Writes)
            {
                translations.Remove(write.Key);
                translations.Add(write.Key, write.Value);
            }

            state.Replayed = true;
            state.ReplayedWordCount =
                state.CacheEntry.RemovedKeys.Length + state.CacheEntry.Writes.Length;
            state.ReplayTicks = Stopwatch.GetTimestamp() - started;
            return true;
        }
        catch (Exception ex)
        {
            state.CacheEntry = null;
            state.Replayed = false;
            ProfilerLog.WriteLine("Localization cache replay warning; falling back to LoadCSV: " + ex.Message);
            return false;
        }
    }

    internal static void CompleteLoad(LoadState? state, bool succeeded)
    {
        if (state == null)
        {
            return;
        }

        if (state.Completed)
        {
            return;
        }

        state.Completed = true;
        if (!PopState(state))
        {
            return;
        }

        if (!state.Cacheable || !state.BodyEntered)
        {
            return;
        }

        if (state.Replayed)
        {
            Record(
                state.SessionMask,
                hit: true,
                state.ReplayTicks,
                state.ReplayedWordCount);
            return;
        }

        long elapsed = Math.Max(0L, Stopwatch.GetTimestamp() - state.StartedTimestamp);
        Record(state.SessionMask, hit: false, elapsed, 0);
        if (!succeeded ||
            state.Before == null ||
            state.File == null ||
            state.Writes == null ||
            TranslationsField?.GetValue(state.Instance) is not Dictionary<string, string> current ||
            !ReferenceEquals(current, state.BeforeDictionary))
        {
            return;
        }

        try
        {
            List<string> removedKeys = new();
            foreach (string key in state.Before.Keys)
            {
                if (!current.ContainsKey(key))
                {
                    removedKeys.Add(key);
                }
            }

            CacheEntry entry = new(state.Writes.ToArray(), removedKeys.ToArray());
            lock (CacheLock)
            {
                AssetCache assetCache = Cache.GetValue(state.File, _ => new AssetCache());
                assetCache.ByLanguage[state.Language] = entry;
            }
        }
        catch (Exception ex)
        {
            ProfilerLog.WriteLine("Localization cache store warning: " + ex.Message);
        }
    }

    internal static void CaptureAddWord(string key, string value, bool originalRan)
    {
        if (!originalRan)
        {
            return;
        }

        Stack<LoadState>? activeLoads = _activeLoads;
        if (activeLoads == null || activeLoads.Count == 0)
        {
            return;
        }

        LoadState state = activeLoads.Peek();
        if (!state.Cacheable ||
            !state.BodyEntered ||
            state.Replayed ||
            state.Writes == null)
        {
            return;
        }

        state.Writes.Add(new WriteOperation(key, value));
    }

    private static bool PopState(LoadState state)
    {
        Stack<LoadState>? activeLoads = _activeLoads;
        if (activeLoads == null || activeLoads.Count == 0)
        {
            return false;
        }

        if (ReferenceEquals(activeLoads.Peek(), state))
        {
            activeLoads.Pop();
            return true;
        }

        // A mismatched nesting order means another patch interrupted the normal call flow.
        // Clearing is safer than allowing a later LoadCSV call to replay against stale state.
        activeLoads.Clear();
        return false;
    }

    private static void Record(
        ProfileSessionMask sessionMask,
        bool hit,
        long elapsedTicks,
        int replayedWords)
    {
        if ((sessionMask & ProfileSessionMask.Startup) != 0)
        {
            if (hit)
            {
                Interlocked.Increment(ref _startupHits);
                Interlocked.Add(ref _startupReplayTicks, elapsedTicks);
                Interlocked.Add(ref _startupReplayedWords, replayedWords);
            }
            else
            {
                Interlocked.Increment(ref _startupMisses);
                Interlocked.Add(ref _startupParseTicks, elapsedTicks);
            }
        }

        if ((sessionMask & ProfileSessionMask.Connection) != 0)
        {
            if (hit)
            {
                Interlocked.Increment(ref _connectionHits);
                Interlocked.Add(ref _connectionReplayTicks, elapsedTicks);
                Interlocked.Add(ref _connectionReplayedWords, replayedWords);
            }
            else
            {
                Interlocked.Increment(ref _connectionMisses);
                Interlocked.Add(ref _connectionParseTicks, elapsedTicks);
            }
        }
    }

    private static double ToMilliseconds(long ticks)
    {
        return ticks * 1000d / Stopwatch.Frequency;
    }

    private static bool HasUnsafeForeignBodyPatches()
    {
        if (_foreignBodyPatchDetected)
        {
            return true;
        }

        try
        {
            if (Chainloader.PluginInfos.ContainsKey("com.maxsch.valheim.LocalizationCache"))
            {
                return true;
            }

            if (AddWordMethod != null)
            {
                Patches? addWordPatches = Harmony.GetPatchInfo(AddWordMethod);
                if (addWordPatches != null &&
                    addWordPatches.Owners.Any(owner =>
                        !string.Equals(owner, HarmonyOwner, StringComparison.Ordinal)))
                {
                    return true;
                }
            }

            if (LoadCsvMethod != null)
            {
                Patches? loadCsvPatches = Harmony.GetPatchInfo(LoadCsvMethod);
                if (loadCsvPatches != null &&
                    loadCsvPatches.Transpilers.Any(patch =>
                        !string.Equals(patch.owner, HarmonyOwner, StringComparison.Ordinal)))
                {
                    return true;
                }

                if (loadCsvPatches != null &&
                    loadCsvPatches.ILManipulators.Any(patch =>
                        !string.Equals(patch.owner, HarmonyOwner, StringComparison.Ordinal)))
                {
                    return true;
                }
            }

            foreach (MethodBase helper in LoadCsvBodyHelpers)
            {
                Patches? helperPatches = Harmony.GetPatchInfo(helper);
                if (helperPatches != null &&
                    helperPatches.Owners.Any(owner =>
                        !string.Equals(owner, HarmonyOwner, StringComparison.Ordinal)))
                {
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            ProfilerLog.WriteLine(
                "Localization cache compatibility check warning; bypassing cache: " + ex.Message);
            return true;
        }

        return false;
    }

    internal sealed class LoadState
    {
        internal Localization Instance = null!;
        internal TextAsset? File;
        internal string Language = string.Empty;
        internal ProfileSessionMask SessionMask;
        internal Dictionary<string, string>? Before;
        internal Dictionary<string, string>? BeforeDictionary;
        internal List<WriteOperation>? Writes;
        internal CacheEntry? CacheEntry;
        internal long StartedTimestamp;
        internal long ReplayTicks;
        internal int ReplayedWordCount;
        internal bool Cacheable;
        internal bool BodyEntered;
        internal bool Replayed;
        internal bool Completed;
    }

    private sealed class AssetCache
    {
        internal readonly Dictionary<string, CacheEntry> ByLanguage =
            new(StringComparer.Ordinal);
    }

    internal sealed class CacheEntry
    {
        internal CacheEntry(
            WriteOperation[] writes,
            string[] removedKeys)
        {
            Writes = writes;
            RemovedKeys = removedKeys;
        }

        internal WriteOperation[] Writes { get; }
        internal string[] RemovedKeys { get; }
    }

    internal readonly struct WriteOperation
    {
        internal WriteOperation(string key, string value)
        {
            Key = key;
            Value = value;
        }

        internal string Key { get; }
        internal string Value { get; }
    }
}

internal static class LocalizationAccelerationPatch
{
    internal static void Prefix(
        Localization __instance,
        TextAsset file,
        string language,
        out LocalizationAcceleration.LoadState __state)
    {
        LocalizationAcceleration.BeginLoad(__instance, file, language, out __state);
    }

    internal static void Postfix(
        bool __result,
        LocalizationAcceleration.LoadState? __state)
    {
        if (__state != null)
        {
            LocalizationAcceleration.CompleteLoad(__state, __result);
        }
    }

    internal static Exception? Finalizer(
        Exception? __exception,
        LocalizationAcceleration.LoadState? __state)
    {
        if (__state != null)
        {
            LocalizationAcceleration.CompleteLoad(__state, succeeded: false);
        }

        return __exception;
    }

    internal static IEnumerable<CodeInstruction> Transpiler(
        IEnumerable<CodeInstruction> instructions,
        ILGenerator generator)
    {
        List<CodeInstruction> original = new(instructions);
        if (original.Count == 0)
        {
            return original;
        }

        MethodInfo? replay = AccessTools.DeclaredMethod(
            typeof(LocalizationAcceleration),
            nameof(LocalizationAcceleration.TryReplayCurrent));
        if (replay == null)
        {
            throw new MissingMethodException(
                typeof(LocalizationAcceleration).FullName,
                nameof(LocalizationAcceleration.TryReplayCurrent));
        }

        Label runOriginal = generator.DefineLabel();
        original[0].labels.Add(runOriginal);
        List<CodeInstruction> result = new(original.Count + 3)
        {
            new(OpCodes.Call, replay),
            new(OpCodes.Brfalse, runOriginal),
            new(OpCodes.Ldc_I4_1),
            new(OpCodes.Ret)
        };
        result.AddRange(original);
        return result;
    }
}

internal static class LocalizationAddWordCapturePatch
{
    internal static void Postfix(string key, string text, bool __runOriginal)
    {
        LocalizationAcceleration.CaptureAddWord(key, text, __runOriginal);
    }
}
