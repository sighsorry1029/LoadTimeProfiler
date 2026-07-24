using System;
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

    internal static void Install()
    {
        lock (Lock)
        {
            if (_installed)
            {
                return;
            }

            _installed = true;
            int installed = 0;
            int failed = 0;
            if (TryPatchPluginConstruction())
            {
                installed++;
            }
            else
            {
                failed++;
            }

            PatchLifecycleTargets(ref installed, ref failed);
            ProfilerLog.WriteLine(
                $"Unity and Valheim runtime hook installation completed: installed={installed}, failed={failed}.");
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
                ProfilerLog.WriteLine("Removed the startup-only GameObject.AddComponent profiling hook.");
            }
            catch (Exception ex)
            {
                ProfilerLog.WriteLine("Runtime hook warning: could not remove the plugin construction hook: " + ex.Message);
            }
            finally
            {
                _pluginConstructionPatched = false;
                _pluginConstructionTarget = null;
            }
        }
    }

    private static bool TryPatchPluginConstruction()
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

            Harmony.Patch(
                target,
                prefix: Highest(typeof(LoadTimeProfilerPluginInitializationPatch), "Prefix"),
                postfix: Lowest(typeof(LoadTimeProfilerPluginInitializationPatch), "Postfix"),
                finalizer: Lowest(typeof(LoadTimeProfilerPluginInitializationPatch), "Finalizer"));
            _pluginConstructionTarget = target;
            _pluginConstructionPatched = true;
            return true;
        }
        catch (Exception ex)
        {
            ProfilerLog.WriteLine("Runtime hook warning: could not profile plugin construction: " + ex.Message);
            return false;
        }
    }

    private static void PatchLifecycleTargets(ref int installed, ref int failed)
    {
        HarmonyMethod prefix;
        HarmonyMethod finalizer;
        try
        {
            prefix = Highest(typeof(LoadTimeProfilerLifecyclePatch), "Prefix");
            finalizer = Lowest(typeof(LoadTimeProfilerLifecyclePatch), "Finalizer");
        }
        catch (Exception ex)
        {
            failed++;
            ProfilerLog.WriteLine("Runtime hook warning: could not prepare lifecycle hooks: " + ex.Message);
            return;
        }

        foreach (MethodBase target in LifecyclePatches.GetTargets())
        {
            try
            {
                Harmony.Patch(target, prefix: prefix, finalizer: finalizer);
                installed++;
            }
            catch (Exception ex)
            {
                failed++;
                string targetName = (target.DeclaringType?.FullName ?? "<unknown>") + "." + target.Name;
                ProfilerLog.WriteLine($"Runtime hook warning: could not patch {targetName}: {ex.Message}");
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
