using System;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using UnityEngine;

namespace LoadTimeProfiler;

internal static class RuntimeHookInstaller
{
    private static readonly object Lock = new();
    private static readonly Harmony Harmony = new(LoadTimeProfilerPatcher.ModGUID + ".runtime");
    private static bool _installed;
    private static MethodBase? _pluginConstructionTarget;
    private static bool _pluginConstructionPatched;
    private static MethodBase? _startupCompletionTarget;

    internal static bool StartupCompletionHookInstalled { get; private set; }

    internal static bool IsStartupCompletionHookActive()
    {
        lock (Lock)
        {
            if (!StartupCompletionHookInstalled ||
                _startupCompletionTarget == null)
            {
                return false;
            }

            try
            {
                Patches? patches =
                    HarmonyLib.Harmony.GetPatchInfo(
                        _startupCompletionTarget);
                return patches != null &&
                       patches.Finalizers.Any(patch =>
                           string.Equals(
                               patch.owner,
                               Harmony.Id,
                               StringComparison.Ordinal));
            }
            catch (Exception ex)
            {
                ProfilerLog.WriteWarning(
                    "Runtime hook warning: could not revalidate the startup completion hook: " +
                    ex.Message);
                return false;
            }
        }
    }

    internal static void Install()
    {
        lock (Lock)
        {
            if (_installed)
            {
                return;
            }

            _installed = true;
            bool profiling = LoadTimeProfilerPatcher.ProfilingEnabled;
            bool localization =
                LoadTimeProfilerPatcher.LocalizationCacheEnabled;
            if (!profiling && !localization)
            {
                return;
            }

            TryPatchPluginConstruction(profiling);

            PatchLifecycleTargets(
                startupCompletionOnly: !profiling);
        }
    }

    internal static void RemovePluginConstructionHook()
    {
        lock (Lock)
        {
            if (!_pluginConstructionPatched || _pluginConstructionTarget == null)
            {
                return;
            }

            try
            {
                Harmony.Unpatch(_pluginConstructionTarget, HarmonyPatchType.All, Harmony.Id);
            }
            catch (Exception ex)
            {
                ProfilerLog.WriteWarning("Runtime hook warning: could not remove the plugin construction hook: " + ex.Message);
            }
            finally
            {
                _pluginConstructionPatched = false;
                _pluginConstructionTarget = null;
            }
        }
    }

    private static bool TryPatchPluginConstruction(
        bool profiling)
    {
        try
        {
            MethodBase? target = AccessTools.Method(
                typeof(GameObject),
                nameof(GameObject.AddComponent),
                new[] { typeof(Type) });
            if (target == null)
            {
                throw new MissingMethodException(typeof(GameObject).FullName, nameof(GameObject.AddComponent));
            }

            if (profiling)
            {
                Harmony.Patch(
                    target,
                    prefix: Highest(
                        typeof(LoadTimeProfilerPluginInitializationPatch),
                        "Prefix"),
                    postfix: Lowest(
                        typeof(LoadTimeProfilerPluginInitializationPatch),
                        "Postfix"),
                    finalizer: Lowest(
                        typeof(LoadTimeProfilerPluginInitializationPatch),
                        "Finalizer"));
            }
            else
            {
                Harmony.Patch(
                    target,
                    prefix: Highest(
                        typeof(LoadTimeProfilerPluginInitializationPatch),
                        "LocalizationDiscoveryPrefix"));
            }

            _pluginConstructionTarget = target;
            _pluginConstructionPatched = true;
            return true;
        }
        catch (Exception ex)
        {
            ProfilerLog.WriteWarning("Runtime hook warning: could not install the plugin-boundary hook: " + ex.Message);
            return false;
        }
    }

    private static void PatchLifecycleTargets(bool startupCompletionOnly)
    {
        HarmonyMethod? prefix = null;
        HarmonyMethod finalizer;
        try
        {
            if (!startupCompletionOnly)
            {
                prefix = Highest(
                    typeof(LoadTimeProfilerLifecyclePatch),
                    "Prefix");
            }

            finalizer = Lowest(typeof(LoadTimeProfilerLifecyclePatch), "Finalizer");
        }
        catch (Exception ex)
        {
            ProfilerLog.WriteWarning("Runtime hook warning: could not prepare lifecycle hooks: " + ex.Message);
            return;
        }

        foreach (MethodBase target in LifecyclePatches.GetTargets())
        {
            if (startupCompletionOnly &&
                !LifecyclePatches.IsStartupCompletionTarget(target))
            {
                continue;
            }

            try
            {
                Harmony.Patch(target, prefix: prefix, finalizer: finalizer);
                if (LifecyclePatches.IsStartupCompletionTarget(target))
                {
                    StartupCompletionHookInstalled = true;
                    _startupCompletionTarget = target;
                }

            }
            catch (Exception ex)
            {
                string targetName = (target.DeclaringType?.FullName ?? "<unknown>") + "." + target.Name;
                ProfilerLog.WriteWarning($"Runtime hook warning: could not patch {targetName}: {ex.Message}");
            }
        }
    }

    private static HarmonyMethod Highest(Type type, string methodName)
    {
        MethodInfo? method = AccessTools.Method(type, methodName);
        if (method == null)
        {
            throw new MissingMethodException(type.FullName, methodName);
        }

        return new HarmonyMethod(method)
        {
            priority = int.MaxValue
        };
    }

    private static HarmonyMethod Lowest(Type type, string methodName)
    {
        MethodInfo? method = AccessTools.Method(type, methodName);
        if (method == null)
        {
            throw new MissingMethodException(type.FullName, methodName);
        }

        return new HarmonyMethod(method)
        {
            priority = int.MinValue
        };
    }
}
