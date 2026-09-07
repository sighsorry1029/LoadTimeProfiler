using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
using HarmonyLib;

namespace LoadTimeProfiler;

internal static class StartupAcceleration
{
    private static readonly object Lock = new();
    private static readonly Harmony Harmony =
        new(LoadTimeProfilerPatcher.ModGUID + ".startup-acceleration");
    private static readonly Dictionary<ConfigFile, TrackedConfig> TrackedConfigs =
        new(ReferenceComparer<ConfigFile>.Instance);

    private static bool _installed;
    private static bool _scopeActive;
    private static bool _boundaryInstalled;
    private static bool _localizationInstalled;
    private static bool _localizationAdaptersInstalled;
    private static bool _localizationAdapterScopeStarted;
    private static bool _configHooksInstalled;
    private static MethodInfo? _configSaveMethod;
    private static bool _configCompatibilityBypassed;

    internal static void InstallBeforeChainloader()
    {
        lock (Lock)
        {
            if (_installed)
            {
                return;
            }

            _installed = true;
        }

        bool accelerationRequested =
            LoadTimeProfilerPatcher.StartupAccelerationEnabled;
        bool boundaryRequired =
            LoadTimeProfilerPatcher.ProfilingEnabled ||
            accelerationRequested;
        if (boundaryRequired)
        {
            _boundaryInstalled =
                InstallChainloaderSafetyFinalizer();
        }

        if (!accelerationRequested)
        {
            return;
        }

        if (LoadTimeProfilerPatcher.LocalizationCacheEnabled)
        {
            _localizationInstalled =
                LocalizationAcceleration.Install(Harmony);
            _localizationAdaptersInstalled =
                LocalizationAdapterRegistry.InstallBeforeChainloader();
        }

        if (LoadTimeProfilerPatcher.ConfigWriteCoalescingEnabled)
        {
            _configHooksInstalled = InstallConfigHooks();
        }
    }

    internal static void BeginChainloader()
    {
        lock (Lock)
        {
            _configCompatibilityBypassed = false;
            TrackedConfigs.Clear();
            _scopeActive =
                LoadTimeProfilerPatcher.ConfigWriteCoalescingEnabled &&
                _boundaryInstalled &&
                _configHooksInstalled;
        }

        _localizationAdapterScopeStarted = false;
        if (_localizationAdaptersInstalled &&
            _boundaryInstalled &&
            RuntimeHookInstaller.StartupCompletionHookInstalled)
        {
            LocalizationAdapterRegistry.BeginStartupScope();
            _localizationAdapterScopeStarted = true;
        }
        else if (_localizationAdaptersInstalled)
        {
            LocalizationAdapterRegistry.AbortStartupScope();
            ProfilerLog.WriteWarning(
                "External localization producer acceleration stayed fail-open because an exception-safe startup boundary was unavailable.");
        }

        if (LoadTimeProfilerPatcher.StartupAccelerationEnabled &&
            !_boundaryInstalled)
        {
            ProfilerLog.WriteWarning(
                "Startup acceleration scopes were not started because the Chainloader safety boundary is unavailable.");
        }
    }

    internal static void EndChainloader()
    {
        FlushConfigs();
    }

    internal static void AfterChainloaderStart()
    {
        if (_localizationInstalled)
        {
            LocalizationAcceleration.FinalizeLoadedCompatibility();
        }

        if (_localizationAdapterScopeStarted &&
            !RuntimeHookInstaller.IsStartupCompletionHookActive())
        {
            ProfilerLog.WriteWarning(
                "External localization producer acceleration stopped fail-open because its startup completion boundary was removed.");
            AbortStartupScope();
            return;
        }

        if (_localizationAdaptersInstalled &&
            _localizationAdapterScopeStarted)
        {
            LocalizationAdapterRegistry.AfterChainloaderStart();
        }
    }

    internal static void EndStartupScope()
    {
        if (_localizationAdaptersInstalled &&
            _localizationAdapterScopeStarted)
        {
            _localizationAdapterScopeStarted = false;
            try
            {
                LocalizationAdapterRegistry.EndStartupScope();
            }
            catch (Exception ex)
            {
                ProfilerLog.WriteWarning(
                    "Localization adapter startup cleanup warning: " +
                    ex.GetBaseException().Message);
            }
        }
    }

    internal static void AbortStartupScope()
    {
        if (_localizationAdaptersInstalled)
        {
            _localizationAdapterScopeStarted = false;
            try
            {
                LocalizationAdapterRegistry.AbortStartupScope();
            }
            catch (Exception ex)
            {
                ProfilerLog.WriteWarning(
                    "Localization adapter abort cleanup warning: " +
                    ex.GetBaseException().Message);
            }
        }
    }

    internal static void ConfigConstructed(ConfigFile config)
    {
        lock (Lock)
        {
            if (!_scopeActive || TrackedConfigs.ContainsKey(config))
            {
                return;
            }

            TrackedConfigs.Add(config, new TrackedConfig());
        }
    }

    internal static bool BeforeConfigSave(
        ConfigFile config,
        out ConfigSaveState state)
    {
        state = default;
        lock (Lock)
        {
            if (!_scopeActive || !TrackedConfigs.TryGetValue(config, out TrackedConfig? tracked))
            {
                return true;
            }

            state = new ConfigSaveState(tracked.Generation);
        }

        if (HasForeignPatchOwner(_configSaveMethod, Harmony.Id, out string owners))
        {
            bool logWarning;
            lock (Lock)
            {
                logWarning = !_configCompatibilityBypassed;
                _configCompatibilityBypassed = true;
            }

            if (logWarning)
            {
                ProfilerLog.WriteWarning(
                    "Config write coalescing stopped fail-open because ConfigFile.Save has foreign Harmony ownership: " +
                    owners + ".");
            }

            return true;
        }

        lock (Lock)
        {
            if (_configCompatibilityBypassed)
            {
                return true;
            }
        }

        if (!IsAutomaticConfigSave())
        {
            return true;
        }

        lock (Lock)
        {
            if (!_scopeActive || !TrackedConfigs.TryGetValue(config, out TrackedConfig? tracked))
            {
                return true;
            }

            tracked.HasPendingWrites = true;
            tracked.Generation++;
            state = new ConfigSaveState(tracked.Generation);
            return false;
        }
    }

    internal static void ConfigSaveCompleted(
        ConfigFile config,
        bool originalRan,
        ConfigSaveState state)
    {
        if (!originalRan || !state.Tracked)
        {
            return;
        }

        lock (Lock)
        {
            if (_scopeActive &&
                TrackedConfigs.TryGetValue(config, out TrackedConfig? tracked) &&
                tracked.Generation == state.Generation)
            {
                // A successful explicit save already persisted every pending
                // Bind/setting update for this file.
                tracked.HasPendingWrites = false;
            }
        }
    }

    private static bool InstallConfigHooks()
    {
        try
        {
            ConstructorInfo? constructor = AccessTools.DeclaredConstructor(
                typeof(ConfigFile),
                new[] { typeof(string), typeof(bool), typeof(BepInPlugin) });
            MethodInfo? save = AccessTools.DeclaredMethod(typeof(ConfigFile), nameof(ConfigFile.Save));
            MethodInfo? constructorPostfix = AccessTools.DeclaredMethod(
                typeof(ConfigCoalescingPatch),
                nameof(ConfigCoalescingPatch.ConstructorPostfix));
            MethodInfo? savePrefix = AccessTools.DeclaredMethod(
                typeof(ConfigCoalescingPatch),
                nameof(ConfigCoalescingPatch.SavePrefix));
            MethodInfo? savePostfix = AccessTools.DeclaredMethod(
                typeof(ConfigCoalescingPatch),
                nameof(ConfigCoalescingPatch.SavePostfix));
            if (constructor == null ||
                save == null ||
                constructorPostfix == null ||
                savePrefix == null ||
                savePostfix == null)
            {
                throw new MissingMethodException("Required ConfigFile constructor/save methods were not found.");
            }

            if (HasForeignPatchOwner(save, Harmony.Id, out string owners))
            {
                ProfilerLog.WriteWarning(
                    "Startup config write coalescing disabled because ConfigFile.Save already has foreign Harmony ownership: " +
                    owners + ".");
                return false;
            }

            _configSaveMethod = save;
            Harmony.Patch(
                constructor,
                postfix: new HarmonyMethod(constructorPostfix) { priority = int.MinValue });
            Harmony.Patch(
                save,
                prefix: new HarmonyMethod(savePrefix) { priority = int.MaxValue },
                postfix: new HarmonyMethod(savePostfix) { priority = int.MaxValue });
            return true;
        }
        catch (Exception ex)
        {
            ProfilerLog.WriteWarning("Startup config write coalescing disabled: " + ex);
            return false;
        }
    }

    private static bool InstallChainloaderSafetyFinalizer()
    {
        try
        {
            MethodInfo? target = AccessTools.DeclaredMethod(typeof(Chainloader), nameof(Chainloader.Start));
            MethodInfo? finalizer = AccessTools.DeclaredMethod(
                typeof(StartupAccelerationBoundaryPatch),
                nameof(StartupAccelerationBoundaryPatch.Finalizer));
            if (target == null || finalizer == null)
            {
                throw new MissingMethodException("Chainloader.Start safety boundary was not found.");
            }

            Harmony.Patch(
                target,
                finalizer: new HarmonyMethod(finalizer) { priority = int.MinValue });
            return true;
        }
        catch (Exception ex)
        {
            ProfilerLog.WriteWarning(
                "Startup acceleration warning: Chainloader exception safety finalizer was not installed: " + ex);
            return false;
        }
    }

    private static void FlushConfigs()
    {
        List<KeyValuePair<ConfigFile, TrackedConfig>> configs;
        lock (Lock)
        {
            if (!_scopeActive && TrackedConfigs.Count == 0)
            {
                return;
            }

            _scopeActive = false;
            configs = TrackedConfigs.ToList();
            TrackedConfigs.Clear();
        }

        foreach (KeyValuePair<ConfigFile, TrackedConfig> pair in configs)
        {
            ConfigFile config = pair.Key;
            TrackedConfig tracked = pair.Value;
            if (!tracked.HasPendingWrites)
            {
                continue;
            }

            try
            {
                config.Save();
            }
            catch (Exception ex)
            {
                ProfilerLog.WriteWarning(
                    "Config coalescing flush warning for " + config.ConfigFilePath + ": " + ex.Message);
            }
        }
    }

    private static bool IsAutomaticConfigSave()
    {
        StackFrame[] frames = new StackTrace(skipFrames: 2, fNeedFileInfo: false).GetFrames() ??
                              Array.Empty<StackFrame>();
        bool foundSaveFrame = false;
        foreach (StackFrame frame in frames)
        {
            MethodBase? method = frame.GetMethod();
            if (method == null)
            {
                continue;
            }

            if (!foundSaveFrame)
            {
                bool isConfigSave =
                    method.DeclaringType == typeof(ConfigFile) &&
                    method.Name.IndexOf("Save", StringComparison.Ordinal) >= 0 ||
                    method.Name.IndexOf("ConfigFile::Save", StringComparison.Ordinal) >= 0;
                if (isConfigSave)
                {
                    foundSaveFrame = true;
                }

                continue;
            }

            Type? declaringType = method.DeclaringType;
            string? declaringNamespace = declaringType?.Namespace;
            if (declaringType == typeof(ConfigCoalescingPatch) ||
                declaringType == typeof(StartupAcceleration) ||
                declaringNamespace == "HarmonyLib" ||
                declaringNamespace?.StartsWith("System.Reflection", StringComparison.Ordinal) == true)
            {
                continue;
            }

            return declaringType == typeof(ConfigFile) &&
                   (method.Name == "OnSettingChanged" ||
                    method.Name == "Bind" ||
                    method.Name.StartsWith("Bind<", StringComparison.Ordinal) ||
                    method.Name.IndexOf("Bind", StringComparison.Ordinal) >= 0);
        }

        return false;
    }

    private static bool HasForeignPatchOwner(
        MethodBase? method,
        string allowedOwner,
        out string owners)
    {
        owners = string.Empty;
        if (method == null)
        {
            owners = "target unavailable";
            return true;
        }

        try
        {
            Patches? patches = Harmony.GetPatchInfo(method);
            if (patches == null)
            {
                return false;
            }

            string[] foreignOwners = patches.Owners
                .Where(owner => !string.Equals(owner, allowedOwner, StringComparison.Ordinal))
                .Distinct(StringComparer.Ordinal)
                .OrderBy(owner => owner, StringComparer.Ordinal)
                .ToArray();
            if (foreignOwners.Length == 0)
            {
                return false;
            }

            owners = string.Join(", ", foreignOwners);
            return true;
        }
        catch (Exception ex)
        {
            owners = "inspection failed (" + ex.GetType().Name + ")";
            return true;
        }
    }

    private sealed class TrackedConfig
    {
        internal bool HasPendingWrites { get; set; }
        internal long Generation { get; set; }
    }

    internal readonly struct ConfigSaveState
    {
        internal ConfigSaveState(long generation)
        {
            Generation = generation;
            Tracked = true;
        }

        internal long Generation { get; }
        internal bool Tracked { get; }
    }
}

internal static class ConfigCoalescingPatch
{
    internal static void ConstructorPostfix(ConfigFile __instance)
    {
        StartupAcceleration.ConfigConstructed(__instance);
    }

    internal static bool SavePrefix(
        ConfigFile __instance,
        out StartupAcceleration.ConfigSaveState __state)
    {
        return StartupAcceleration.BeforeConfigSave(__instance, out __state);
    }

    internal static void SavePostfix(
        ConfigFile __instance,
        bool __runOriginal,
        StartupAcceleration.ConfigSaveState __state)
    {
        StartupAcceleration.ConfigSaveCompleted(__instance, __runOriginal, __state);
    }
}

internal static class StartupAccelerationBoundaryPatch
{
    internal static Exception? Finalizer(Exception? __exception)
    {
        try
        {
            StartupAcceleration.EndChainloader();
        }
        catch (Exception ex)
        {
            ProfilerLog.WriteLine("Startup acceleration cleanup warning: " + ex);
        }

        if (__exception != null)
        {
            RuntimeEntrypoint.HandleChainloaderFailure(__exception);
        }

        return __exception;
    }
}

internal sealed class ReferenceComparer<T> : IEqualityComparer<T>
    where T : class
{
    internal static readonly ReferenceComparer<T> Instance = new();

    public bool Equals(T? x, T? y)
    {
        return ReferenceEquals(x, y);
    }

    public int GetHashCode(T obj)
    {
        return System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(obj);
    }
}
