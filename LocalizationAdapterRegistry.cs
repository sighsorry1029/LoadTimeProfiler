using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using BepInEx;
using BepInEx.Bootstrap;
using HarmonyLib;
using UnityEngine;

namespace LoadTimeProfiler;

internal static class LocalizationAdapterRegistry
{
    private static readonly object Lock = new();
    private static readonly Harmony Harmony =
        new(LoadTimeProfilerPatcher.ModGUID + ".localization-adapters");
    private static readonly HashSet<Assembly> ScannedAssemblies = new();
    private static readonly HashSet<Assembly> RetryAssemblies = new();
    private static readonly HashSet<MethodBase> RegisteredTargets = new();
    private static readonly Dictionary<MethodBase, ParsedMapLocalizationAdapter>
        ParsedCandidates = new();
    private static readonly Dictionary<MethodBase, ParsedMapLocalizationAdapter>
        ParsedAdapters = new();
    private static readonly Dictionary<MethodBase, CapturedLocalizationAdapter>
        CapturedAdapters = new();
    private static readonly Dictionary<MethodBase, CapturedLocalizationAdapter>
        MutationAdapters = new();

    private static readonly MethodInfo? LoadCsvMethod = AccessTools.DeclaredMethod(
        typeof(Localization),
        nameof(Localization.LoadCSV),
        new[] { typeof(TextAsset), typeof(string) });
    private static readonly MethodInfo? SetupLanguageMethod =
        AccessTools.DeclaredMethod(
            typeof(Localization),
            nameof(Localization.SetupLanguage),
            new[] { typeof(string) });
    private static readonly string[] ParsedMapTypeNames =
    {
        "LocalizationManager.Localizer",
        "Marketplace.Localizer"
    };
    private static readonly string[] LocalizeKeyTypeNames =
    {
        "ItemManager.LocalizeKey",
        "PieceManager.LocalizeKey",
        "CreatureManager.LocalizeKey",
        "StatusEffectManager.LocalizeKey",
        "SkillManager.Skill+LocalizeKey"
    };

    [ThreadStatic]
    private static Stack<LocalizationProducerCallState>? _activeCaptures;

    private static bool _installed;
    private static volatile bool _startupScopeActive;
    private static int _parsedDiscoveryPending;
    private static int _localizeKeyDiscoveryPending;

    internal static bool InstallBeforeChainloader()
    {
        lock (Lock)
        {
            if (_installed)
            {
                return true;
            }

            _installed = true;
        }

        return true;
    }

    internal static void BeginStartupScope()
    {
        Interlocked.Exchange(ref _parsedDiscoveryPending, 0);
        Interlocked.Exchange(ref _localizeKeyDiscoveryPending, 0);
        _startupScopeActive = _installed;
    }

    internal static void ObservePluginComponent(
        GameObject gameObject,
        Type componentType)
    {
        if (!_installed ||
            !_startupScopeActive ||
            gameObject == null ||
            componentType == null ||
            !typeof(BaseUnityPlugin).IsAssignableFrom(componentType) ||
            !ReferenceEquals(gameObject, Chainloader.ManagerObject))
        {
            return;
        }

        try
        {
            if (Interlocked.Exchange(
                    ref _parsedDiscoveryPending,
                    0) != 0)
            {
                DiscoverRegisteredParsedMapCallbacks();
            }

            if (Interlocked.Exchange(
                    ref _localizeKeyDiscoveryPending,
                    0) != 0)
            {
                DiscoverRegisteredLocalizeKeyCallbacks();
            }

            ScanAssembly(componentType.Assembly, forceRescan: false);
        }
        catch (Exception ex)
        {
            ProfilerLog.WriteWarning(
                "Localization adapter plugin discovery warning: " +
                ex.Message);
        }
    }

    internal static void AfterChainloaderStart()
    {
        if (!_installed)
        {
            return;
        }

        try
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assembly in assemblies)
            {
                if (IsPluginAssembly(assembly))
                {
                    ScanAssembly(assembly, forceRescan: false);
                }
            }

            Assembly[] retry;
            lock (Lock)
            {
                retry = RetryAssemblies.ToArray();
                RetryAssemblies.Clear();
            }

            foreach (Assembly assembly in retry)
            {
                ScanAssembly(assembly, forceRescan: true);
            }

            DiscoverRegisteredParsedMapCallbacks();
            DiscoverRegisteredLocalizeKeyCallbacks();
            Interlocked.Exchange(
                ref _parsedDiscoveryPending,
                0);
            Interlocked.Exchange(
                ref _localizeKeyDiscoveryPending,
                0);

        }
        catch (Exception ex)
        {
            ProfilerLog.WriteWarning(
                "Localization adapter reconciliation warning: " + ex);
        }
    }

    internal static void EndStartupScope()
    {
        _startupScopeActive = false;
        if (_activeCaptures != null)
        {
            _activeCaptures.Clear();
        }

        ParsedMapLocalizationAdapter[] parsed;
        CapturedLocalizationAdapter[] captured;
        lock (Lock)
        {
            parsed = ParsedAdapters.Values.ToArray();
            captured = CapturedAdapters.Values.ToArray();
        }

        foreach (ParsedMapLocalizationAdapter adapter in parsed)
        {
            try
            {
                adapter.ClearStartupCache();
            }
            catch (Exception ex)
            {
                adapter.Disable(
                    "startup cache cleanup failed: " +
                    ex.GetBaseException().Message);
            }
        }

        foreach (CapturedLocalizationAdapter adapter in captured)
        {
            try
            {
                adapter.ClearStartupCache();
            }
            catch (Exception ex)
            {
                adapter.Disable(
                    "startup cache cleanup failed: " +
                    ex.GetBaseException().Message);
            }
        }
    }

    internal static void AbortStartupScope()
    {
        EndStartupScope();
    }

    internal static bool BeforeParsedMap(
        MethodBase originalMethod,
        Localization instance,
        string language,
        out ParsedMapCallState? state)
    {
        state = null;
        if (!CanUseAdapters())
        {
            return true;
        }

        ParsedMapLocalizationAdapter? adapter;
        lock (Lock)
        {
            ParsedAdapters.TryGetValue(originalMethod, out adapter);
        }

        if (adapter == null)
        {
            return true;
        }

        try
        {
            return adapter.Before(instance, language, out state);
        }
        catch (Exception ex)
        {
            adapter.Disable(
                "parsed-map prefix failed: " +
                ex.GetBaseException().Message);
            state = null;
            return true;
        }
    }

    internal static void CompleteParsedMap(
        ParsedMapCallState? state,
        bool succeeded)
    {
        if (state == null)
        {
            return;
        }

        try
        {
            state.Complete(succeeded);
        }
        catch (Exception ex)
        {
            state.Fail(
                "parsed-map completion failed: " +
                ex.GetBaseException().Message);
        }
    }

    internal static bool BeforeCapturedProducer(
        MethodBase originalMethod,
        Localization instance,
        string language,
        out LocalizationProducerCallState? state)
    {
        state = null;
        if (!CanUseAdapters())
        {
            return true;
        }

        CapturedLocalizationAdapter? adapter;
        lock (Lock)
        {
            CapturedAdapters.TryGetValue(originalMethod, out adapter);
        }

        if (adapter == null)
        {
            return true;
        }

        bool runOriginal;
        try
        {
            runOriginal = adapter.Before(
                instance,
                language,
                out state);
        }
        catch (Exception ex)
        {
            adapter.Disable(
                "captured producer prefix failed: " +
                ex.GetBaseException().Message);
            state = null;
            return true;
        }

        if (state != null)
        {
            (_activeCaptures ??=
                    new Stack<LocalizationProducerCallState>())
                .Push(state);
        }

        return runOriginal;
    }

    internal static void CompleteCapturedProducer(
        LocalizationProducerCallState? state,
        bool succeeded)
    {
        if (state == null || state.Completed)
        {
            return;
        }

        state.Completed = true;
        Stack<LocalizationProducerCallState>? captures =
            _activeCaptures;
        if (captures == null ||
            captures.Count == 0 ||
            !ReferenceEquals(captures.Peek(), state))
        {
            captures?.Clear();
            state.Adapter.Disable(
                "capture nesting did not complete in stack order");
            return;
        }

        captures.Pop();
        try
        {
            state.Adapter.Complete(state, succeeded);
        }
        catch (Exception ex)
        {
            state.Adapter.Disable(
                "captured producer completion failed: " +
                ex.GetBaseException().Message);
        }
    }

    internal static void CaptureAddWord(
        string key,
        string value,
        bool originalRan)
    {
        if (!originalRan)
        {
            return;
        }

        Stack<LocalizationProducerCallState>? captures =
            _activeCaptures;
        if (captures == null || captures.Count == 0)
        {
            return;
        }

        captures.Peek().Writes.Add(
            new LocalizationAcceleration.WriteOperation(key, value));
    }

    internal static void MutationCompleted(MethodBase originalMethod)
    {
        if (!IsStartupScopeActive)
        {
            return;
        }

        CapturedLocalizationAdapter? adapter;
        lock (Lock)
        {
            MutationAdapters.TryGetValue(originalMethod, out adapter);
        }

        if (adapter == null || adapter.Disabled)
        {
            return;
        }

        try
        {
            adapter.Invalidate();
        }
        catch (Exception ex)
        {
            adapter.Disable(
                "mutation invalidation failed: " +
                ex.GetBaseException().Message);
        }
    }

    internal static bool IsStartupScopeActive =>
        _startupScopeActive;

    internal static bool HasForeignPatches(MethodBase target)
    {
        try
        {
            Patches? patches = HarmonyLib.Harmony.GetPatchInfo(target);
            return patches != null &&
                   patches.Owners.Any(owner =>
                       !string.Equals(
                           owner,
                           Harmony.Id,
                           StringComparison.Ordinal));
        }
        catch (Exception ex)
        {
            ProfilerLog.WriteWarning(
                "Localization adapter compatibility check warning for " +
                FormatMethod(target) +
                ": " +
                ex.Message);
            return true;
        }
    }

    internal static string FormatMethod(MethodBase method)
    {
        return (method.DeclaringType?.FullName ?? "<unknown>") +
               "." +
               method.Name;
    }

    private static bool CanUseAdapters()
    {
        return _installed &&
               _startupScopeActive &&
               LoadTimeProfilerPatcher.LocalizationCacheEnabled;
    }

    private static bool IsPluginAssembly(Assembly assembly)
    {
        try
        {
            if (assembly.IsDynamic ||
                string.IsNullOrEmpty(assembly.Location))
            {
                return false;
            }

            string pluginPath = Path.GetFullPath(Paths.PluginPath)
                .TrimEnd(
                    Path.DirectorySeparatorChar,
                    Path.AltDirectorySeparatorChar) +
                Path.DirectorySeparatorChar;
            string assemblyPath = Path.GetFullPath(assembly.Location);
            return assemblyPath.StartsWith(
                pluginPath,
                StringComparison.OrdinalIgnoreCase);
        }
        catch
        {
            return false;
        }
    }

    private static void ScanAssembly(
        Assembly assembly,
        bool forceRescan)
    {
        if (!_installed ||
            !_startupScopeActive)
        {
            return;
        }

        lock (Lock)
        {
            if (!forceRescan &&
                !ScannedAssemblies.Add(assembly))
            {
                return;
            }

            ScannedAssemblies.Add(assembly);
        }

        foreach (string typeName in ParsedMapTypeNames)
        {
            Type? type;
            try
            {
                type = assembly.GetType(
                    typeName,
                    throwOnError: false,
                    ignoreCase: false);
            }
            catch (Exception ex)
            {
                lock (Lock)
                {
                    RetryAssemblies.Add(assembly);
                }

                ProfilerLog.WriteWarning(
                    "Localization adapter scan warning for " +
                    assembly.GetName().Name +
                    ": " +
                    ex.GetBaseException().Message);
                continue;
            }

            if (type == null)
            {
                continue;
            }

            try
            {
                if (ParsedMapLocalizationAdapter.TryCreate(
                        type,
                        out ParsedMapLocalizationAdapter? adapter))
                {
                    RegisterParsedMapCandidate(adapter!);
                }
            }
            catch (Exception ex)
            {
                ProfilerLog.WriteWarning(
                    "Localization adapter validation warning for " +
                    type.FullName +
                    ": " +
                    ex.GetBaseException().Message +
                    ".");
            }
        }

        foreach (string typeName in LocalizeKeyTypeNames)
        {
            try
            {
                if (assembly.GetType(
                        typeName,
                        throwOnError: false,
                        ignoreCase: false) != null)
                {
                    Interlocked.Exchange(
                        ref _localizeKeyDiscoveryPending,
                        1);
                    break;
                }
            }
            catch (Exception ex)
            {
                lock (Lock)
                {
                    RetryAssemblies.Add(assembly);
                }

                ProfilerLog.WriteWarning(
                    "LocalizeKey candidate scan warning for " +
                    assembly.GetName().Name +
                    ": " +
                    ex.GetBaseException().Message);
                break;
            }
        }

    }

    private static void RegisterParsedMapCandidate(
        ParsedMapLocalizationAdapter adapter)
    {
        lock (Lock)
        {
            if (RegisteredTargets.Contains(adapter.Target) ||
                ParsedCandidates.ContainsKey(adapter.Target))
            {
                return;
            }

            ParsedCandidates.Add(adapter.Target, adapter);
            Interlocked.Exchange(
                ref _parsedDiscoveryPending,
                1);
        }
    }

    private static void InstallParsedMapAdapter(
        ParsedMapLocalizationAdapter adapter)
    {
        MethodBase target = adapter.Target;
        if (HasForeignPatches(target))
        {
            adapter.Disable(
                "the producer method already has a foreign Harmony patch");
            lock (Lock)
            {
                ParsedCandidates.Remove(target);
                RegisteredTargets.Add(target);
            }

            return;
        }

        lock (Lock)
        {
            if (!RegisteredTargets.Add(target))
            {
                return;
            }

            ParsedAdapters[target] = adapter;
            ParsedCandidates.Remove(target);
        }

        try
        {
            Harmony.Patch(
                target,
                prefix: new HarmonyMethod(
                    typeof(ParsedMapLocalizationPatch),
                    nameof(ParsedMapLocalizationPatch.Prefix))
                {
                    priority = int.MaxValue
                },
                postfix: new HarmonyMethod(
                    typeof(ParsedMapLocalizationPatch),
                    nameof(ParsedMapLocalizationPatch.Postfix))
                {
                    priority = int.MinValue
                },
                finalizer: new HarmonyMethod(
                    typeof(ParsedMapLocalizationPatch),
                    nameof(ParsedMapLocalizationPatch.Finalizer))
                {
                    priority = int.MinValue
                });
        }
        catch (Exception ex)
        {
            try
            {
                Harmony.Unpatch(
                    target,
                    HarmonyPatchType.All,
                    Harmony.Id);
            }
            catch (Exception rollbackException)
            {
                ProfilerLog.WriteWarning(
                    "Localization parsed-map adapter rollback warning for " +
                    FormatMethod(target) +
                    ": " +
                    rollbackException.Message);
            }

            lock (Lock)
            {
                ParsedAdapters.Remove(target);
            }

            adapter.Disable("Harmony installation failed: " + ex.Message);
            ProfilerLog.WriteWarning(
                "Localization parsed-map adapter installation warning for " +
                FormatMethod(target) +
                ": " +
                ex.Message);
        }
    }

    private static void DiscoverRegisteredParsedMapCallbacks()
    {
        if (!_installed ||
            (SetupLanguageMethod == null &&
             LoadCsvMethod == null))
        {
            return;
        }

        lock (Lock)
        {
            if (ParsedCandidates.Count == 0)
            {
                return;
            }
        }

        List<MethodInfo> registered = new();
        foreach (
            MethodInfo outerTarget in
            new[] { SetupLanguageMethod, LoadCsvMethod }
                .Where(method => method != null)
                .Cast<MethodInfo>())
        {
            try
            {
                Patches? patches =
                    HarmonyLib.Harmony.GetPatchInfo(outerTarget);
                if (patches != null)
                {
                    registered.AddRange(
                        patches.Postfixes
                            .Select(patch => patch.PatchMethod)
                            .Where(method => method != null)
                            .Cast<MethodInfo>());
                }
            }
            catch (Exception ex)
            {
                ProfilerLog.WriteWarning(
                    "Parsed-map localization discovery warning for " +
                    FormatMethod(outerTarget) +
                    ": " +
                    ex.Message);
            }
        }

        if (registered.Count == 0)
        {
            return;
        }
        ParsedMapLocalizationAdapter[] candidates;
        lock (Lock)
        {
            candidates = ParsedCandidates.Values.ToArray();
        }

        foreach (ParsedMapLocalizationAdapter adapter in candidates)
        {
            if (registered.Any(method =>
                    SameMethod(method, adapter.Target)))
            {
                InstallParsedMapAdapter(adapter);
            }
        }
    }

    private static void DiscoverRegisteredLocalizeKeyCallbacks()
    {
        if (!_installed ||
            LoadCsvMethod == null)
        {
            return;
        }

        Patches? patches;
        try
        {
            patches = HarmonyLib.Harmony.GetPatchInfo(LoadCsvMethod);
        }
        catch (Exception ex)
        {
            ProfilerLog.WriteWarning(
                "LocalizeKey discovery warning: " + ex.Message);
            return;
        }

        if (patches == null)
        {
            return;
        }

        foreach (Patch patch in patches.Postfixes)
        {
            MethodInfo? method = patch.PatchMethod;
            if (method == null)
            {
                continue;
            }

            lock (Lock)
            {
                if (RegisteredTargets.Contains(method))
                {
                    continue;
                }
            }

            if (LocalizeKeyLocalizationAdapter.TryCreate(
                    method,
                    out LocalizeKeyLocalizationAdapter? adapter))
            {
                InstallCapturedAdapter(adapter!);
            }
        }
    }

    private static bool SameMethod(
        MethodBase left,
        MethodBase right)
    {
        try
        {
            return left.Module == right.Module &&
                   left.MetadataToken == right.MetadataToken;
        }
        catch
        {
            return left == right;
        }
    }

    private static void InstallCapturedAdapter(
        CapturedLocalizationAdapter adapter)
    {
        MethodBase target = adapter.Target;
        if (HasForeignPatches(target))
        {
            adapter.Disable(
                "the producer method already has a foreign Harmony patch");
            lock (Lock)
            {
                RegisteredTargets.Add(target);
            }

            return;
        }

        lock (Lock)
        {
            if (!RegisteredTargets.Add(target))
            {
                return;
            }

            CapturedAdapters[target] = adapter;
        }

        bool installed = false;
        MethodBase[] rollbackMethods =
            new[] { target }
                .Concat(adapter.MutationMethods)
                .Distinct()
                .ToArray();
        try
        {
            Harmony.Patch(
                target,
                prefix: new HarmonyMethod(
                    typeof(CapturedLocalizationProducerPatch),
                    nameof(CapturedLocalizationProducerPatch.Prefix))
                {
                    priority = int.MaxValue
                },
                postfix: new HarmonyMethod(
                    typeof(CapturedLocalizationProducerPatch),
                    nameof(CapturedLocalizationProducerPatch.Postfix))
                {
                    priority = int.MinValue
                },
                finalizer: new HarmonyMethod(
                    typeof(CapturedLocalizationProducerPatch),
                    nameof(CapturedLocalizationProducerPatch.Finalizer))
                {
                    priority = int.MinValue
                });

            foreach (MethodBase mutation in adapter.MutationMethods)
            {
                Harmony.Patch(
                    mutation,
                    postfix: new HarmonyMethod(
                        typeof(LocalizationProducerMutationPatch),
                        nameof(LocalizationProducerMutationPatch.Postfix))
                    {
                        priority = int.MinValue
                    });
                lock (Lock)
                {
                    MutationAdapters[mutation] = adapter;
                }
            }

            installed = true;
        }
        catch (Exception ex)
        {
            adapter.Disable(
                "required Harmony hook installation failed: " +
                ex.Message);
            ProfilerLog.WriteWarning(
                "Localization producer adapter installation warning for " +
                FormatMethod(target) +
                ": " +
                ex.Message);
        }
        if (!installed)
        {
            foreach (MethodBase installedMethod in rollbackMethods)
            {
                try
                {
                    Harmony.Unpatch(
                        installedMethod,
                        HarmonyPatchType.All,
                        Harmony.Id);
                }
                catch (Exception rollbackException)
                {
                    ProfilerLog.WriteWarning(
                        "Localization producer adapter rollback warning for " +
                        FormatMethod(installedMethod) +
                        ": " +
                        rollbackException.Message);
                }
            }

            lock (Lock)
            {
                CapturedAdapters.Remove(target);
                foreach (MethodBase mutation in adapter.MutationMethods)
                {
                    MutationAdapters.Remove(mutation);
                }
            }
        }
    }

}

internal static class ParsedMapLocalizationPatch
{
    internal static bool Prefix(
        MethodBase __originalMethod,
        Localization __0,
        string __1,
        out ParsedMapCallState? __state)
    {
        __state = null;
        try
        {
            return LocalizationAdapterRegistry.BeforeParsedMap(
                __originalMethod,
                __0,
                __1,
                out __state);
        }
        catch (Exception ex)
        {
            ProfilerLog.WriteWarning(
                "Parsed-map localization prefix warning: " +
                ex.GetBaseException().Message);
            return true;
        }
    }

    internal static void Postfix(
        bool __runOriginal,
        ParsedMapCallState? __state)
    {
        try
        {
            LocalizationAdapterRegistry.CompleteParsedMap(
                __state,
                __runOriginal);
        }
        catch (Exception ex)
        {
            try
            {
                __state?.Fail(
                    "parsed-map postfix boundary failed: " +
                    ex.GetBaseException().Message);
            }
            catch
            {
                // The profiler must not fail the producer's successful call.
            }
        }
    }

    internal static Exception? Finalizer(
        Exception? __exception,
        ParsedMapCallState? __state)
    {
        try
        {
            if (__exception != null)
            {
                LocalizationAdapterRegistry.CompleteParsedMap(
                    __state,
                    succeeded: false);
            }
        }
        catch (Exception ex)
        {
            try
            {
                __state?.Fail(
                    "parsed-map finalizer boundary failed: " +
                    ex.GetBaseException().Message);
            }
            catch
            {
                // A Harmony finalizer must never replace the original error.
            }
        }

        return __exception;
    }
}

internal static class CapturedLocalizationProducerPatch
{
    internal static bool Prefix(
        MethodBase __originalMethod,
        Localization __0,
        string __1,
        out LocalizationProducerCallState? __state)
    {
        __state = null;
        try
        {
            return LocalizationAdapterRegistry.BeforeCapturedProducer(
                __originalMethod,
                __0,
                __1,
                out __state);
        }
        catch (Exception ex)
        {
            ProfilerLog.WriteWarning(
                "Captured localization prefix warning: " +
                ex.GetBaseException().Message);
            return true;
        }
    }

    internal static void Postfix(
        bool __runOriginal,
        LocalizationProducerCallState? __state)
    {
        try
        {
            LocalizationAdapterRegistry.CompleteCapturedProducer(
                __state,
                __runOriginal);
        }
        catch (Exception ex)
        {
            try
            {
                __state?.Adapter.Disable(
                    "captured producer postfix boundary failed: " +
                    ex.GetBaseException().Message);
            }
            catch
            {
                // The profiler must not fail the producer's successful call.
            }
        }
    }

    internal static Exception? Finalizer(
        Exception? __exception,
        LocalizationProducerCallState? __state)
    {
        try
        {
            if (__exception != null)
            {
                LocalizationAdapterRegistry.CompleteCapturedProducer(
                    __state,
                    succeeded: false);
            }
        }
        catch (Exception ex)
        {
            try
            {
                __state?.Adapter.Disable(
                    "captured producer finalizer boundary failed: " +
                    ex.GetBaseException().Message);
            }
            catch
            {
                // A Harmony finalizer must never replace the original error.
            }
        }

        return __exception;
    }
}

internal static class LocalizationProducerMutationPatch
{
    internal static void Postfix(MethodBase __originalMethod)
    {
        try
        {
            LocalizationAdapterRegistry.MutationCompleted(
                __originalMethod);
        }
        catch (Exception ex)
        {
            ProfilerLog.WriteWarning(
                "Localization mutation boundary warning: " +
                ex.GetBaseException().Message);
        }
    }
}
