using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Threading;
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

    private static bool _installed;
    private static bool _foreignBodyPatchDetected;
    private static int _foreignBodyPatchWarningLogged;
    private static int _directReplaySafety;

    internal static bool Install(Harmony harmony)
    {
        if (TranslationsField == null ||
            TranslationsField.FieldType != typeof(Dictionary<string, string>))
        {
            ProfilerLog.WriteWarning(
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
            ProfilerLog.WriteWarning("Localization acceleration disabled: required LoadCSV methods were not found.");
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
                ProfilerLog.WriteWarning(
                    "Localization acceleration rollback warning: " + rollbackException.Message);
            }

            _installed = false;
            ProfilerLog.WriteWarning("Localization acceleration disabled: " + ex);
            return false;
        }
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
            Language = language
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
                RefreshDirectReplayCompatibility();
                if (HasUnsafeForeignBodyPatches())
                {
                    state.Cacheable = false;
                    _foreignBodyPatchDetected = true;
                    if (Interlocked.Exchange(ref _foreignBodyPatchWarningLogged, 1) == 0)
                    {
                        ProfilerLog.WriteWarning(
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

                if (state.Cacheable && state.CacheEntry == null)
                {
                    state.Before = new Dictionary<string, string>(translations, StringComparer.Ordinal);
                    state.Writes = new List<WriteOperation>();
                }
            }
        }
        catch (Exception ex)
        {
            state.Cacheable = false;
            ProfilerLog.WriteWarning("Localization cache prefix warning: " + ex.Message);
        }

        (_activeLoads ??= new Stack<LoadState>()).Push(state);
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
            return true;
        }
        catch (Exception ex)
        {
            state.CacheEntry = null;
            state.Replayed = false;
            ProfilerLog.WriteWarning("Localization cache replay warning; falling back to LoadCSV: " + ex.Message);
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
            return;
        }

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
            ProfilerLog.WriteWarning("Localization cache store warning: " + ex.Message);
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

    internal static bool CanReplayDirectWrites()
    {
        if (!_installed ||
            !LoadTimeProfilerPatcher.LocalizationCacheEnabled)
        {
            return false;
        }

        int safety = Volatile.Read(ref _directReplaySafety);
        if (safety != 0)
        {
            return safety == 1;
        }

        return !HasUnsafeForeignBodyPatches();
    }

    internal static void FinalizeLoadedCompatibility()
    {
        RefreshDirectReplayCompatibility();
    }

    internal static bool RefreshDirectReplayCompatibility()
    {
        if (!_installed ||
            Volatile.Read(ref _directReplaySafety) == 2)
        {
            Volatile.Write(ref _directReplaySafety, 2);
            return false;
        }

        bool safe = !DetectUnsafeForeignBodyPatches();
        Volatile.Write(ref _directReplaySafety, safe ? 1 : 2);
        if (safe)
        {
            return true;
        }

        _foreignBodyPatchDetected = true;
        if (Interlocked.Exchange(
                ref _foreignBodyPatchWarningLogged,
                1) == 0)
        {
            ProfilerLog.WriteWarning(
                "Localization acceleration stayed fail-open after loaded-mod Harmony compatibility validation.");
        }

        return false;
    }

    internal static bool TryGetTranslations(
        Localization instance,
        out Dictionary<string, string>? translations)
    {
        translations = null;
        try
        {
            translations =
                TranslationsField?.GetValue(instance) as
                    Dictionary<string, string>;
            return translations != null;
        }
        catch
        {
            return false;
        }
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

    private static bool HasUnsafeForeignBodyPatches()
    {
        int finalizedSafety = Volatile.Read(
            ref _directReplaySafety);
        if (finalizedSafety != 0)
        {
            return finalizedSafety == 2;
        }

        return DetectUnsafeForeignBodyPatches();
    }

    private static bool DetectUnsafeForeignBodyPatches()
    {
        if (_foreignBodyPatchDetected)
        {
            return true;
        }

        try
        {
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
            ProfilerLog.WriteWarning(
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
        internal Dictionary<string, string>? Before;
        internal Dictionary<string, string>? BeforeDictionary;
        internal List<WriteOperation>? Writes;
        internal CacheEntry? CacheEntry;
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
        LocalizationAdapterRegistry.CaptureAddWord(
            key,
            text,
            __runOriginal);
    }
}
