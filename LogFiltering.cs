using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace LoadTimeProfiler;

internal static class LogFiltering
{
    private const string Owner = "sighsorry.LoadTimeProfiler.logging";
    private static readonly object LifecycleLock = new();
    private static ModConfiguration? _config;
    private static Harmony? _manualHarmony;
    private static Harmony? _ownershipHarmony;
    // Store only the standard logger and GUID, never the Unity plugin instance.
    // ConcurrentDictionary reads do not lock or allocate; all writes are at plugin creation.
    private static readonly ConcurrentDictionary<ManualLogSource, string> PluginOwners =
        new(new LoggerIdentityComparer());
    private static string? _conflict;

    // Set during patcher startup; the optional settings UI reads it once after Chainloader.
    internal static string? ConflictName => Volatile.Read(ref _conflict);

    // Configuration belongs to the patcher. Disabling a filter must not stop its
    // watcher or reset the immutable startup settings used by the other features.
    internal static void Install(ModConfiguration configuration)
    {
        lock (LifecycleLock)
        {
            if (_manualHarmony != null) return;
            CheckForConflicts();
            if (_conflict != null) return;
            Volatile.Write(ref _config, configuration);
            _manualHarmony = new Harmony(Owner + ".manual");
            try
            {
                _manualHarmony.Patch(AccessTools.Method(typeof(ManualLogSource), nameof(ManualLogSource.Log),
                    new[] { typeof(LogLevel), typeof(object) }), prefix: new HarmonyMethod(
                    typeof(LogFiltering), nameof(ManualLogPrefix)) { priority = Priority.First });
            }
            catch
            {
                Dispose();
                throw;
            }
        }
    }

    private static bool ManualLogPrefix(ManualLogSource __instance, LogLevel level)
        => Allows(__instance, level);

    internal static bool Allows(ManualLogSource source, LogLevel level)
    {
        if (ReferenceEquals(source, LoadTimeProfilerPatcher.Log)) return true;
        ModConfiguration? config = Volatile.Read(ref _config);
        if (config == null) return true;
        if (!PluginOwners.TryGetValue(source, out string? guid)) return true;
        return config.Snapshot.Logging.Allows(guid, level);
    }

    // Enter only after Unity has loaded, before Chainloader creates any plugins.
    // This hook survives the profiler's separate, startup-only construction hook.
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void InstallPluginOwnership() => PluginOwnership.Install();

    // Keep Unity-derived types out of preloader field initialization/reflection.
    private static class PluginOwnership
    {
        private static Func<BaseUnityPlugin, ManualLogSource>? _getLogger;

        internal static void Install()
        {
            lock (LifecycleLock)
            {
                if (_ownershipHarmony != null || Volatile.Read(ref _config) == null) return;
                Harmony harmony = new(Owner + ".ownership");
                try
                {
                    MethodInfo getter = AccessTools.PropertyGetter(typeof(BaseUnityPlugin), "Logger")
                        ?? throw new MissingMethodException("BaseUnityPlugin.Logger");
                    _getLogger = (Func<BaseUnityPlugin, ManualLogSource>)Delegate.CreateDelegate(
                        typeof(Func<BaseUnityPlugin, ManualLogSource>), getter);
                    ConstructorInfo constructor = AccessTools.Constructor(typeof(BaseUnityPlugin), Type.EmptyTypes)
                        ?? throw new MissingMethodException("BaseUnityPlugin constructor");
                    harmony.Patch(constructor, postfix: new HarmonyMethod(
                        typeof(PluginOwnership), nameof(Constructed)) { priority = Priority.First });
                    _ownershipHarmony = harmony;
                }
                catch (Exception ex)
                {
                    RemovePatches(harmony);
                    _getLogger = null;
                    Report("Mod logger ownership unavailable; unowned Manual logs remain allowed: " + ex.Message);
                }
            }
        }

        private static void Constructed(BaseUnityPlugin __instance)
        {
            // Info.Instance is assigned by Chainloader only after AddComponent returns.
            // The protected Logger and Info.Metadata are already valid here.
            Func<BaseUnityPlugin, ManualLogSource>? getLogger = _getLogger;
            if (getLogger == null || Volatile.Read(ref _config) == null) return;
            BindPluginLogger(getLogger(__instance), __instance.Info.Metadata.GUID);
        }
    }

    internal static void BindPluginLogger(ManualLogSource source, string guid)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (string.IsNullOrEmpty(guid)) throw new ArgumentException("A mod GUID is required.", nameof(guid));
        PluginOwners.TryAdd(source, guid);
    }

    private sealed class LoggerIdentityComparer : IEqualityComparer<ManualLogSource>
    {
        public bool Equals(ManualLogSource? x, ManualLogSource? y) => ReferenceEquals(x, y);
        public int GetHashCode(ManualLogSource obj) => RuntimeHelpers.GetHashCode(obj);
    }

    internal static void CheckForConflicts()
    {
        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            string name = assembly.GetName().Name;
            if (!string.Equals(name, "ShutUp", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(name, "QuietLogs", StringComparison.OrdinalIgnoreCase)) continue;
            if (Interlocked.CompareExchange(ref _conflict, name, null) == null)
            {
                Disable();
                Report("Logging filter disabled because " + name + " is also loaded. Remove that standalone patcher and restart to use integrated filtering. Other LoadTimeProfiler features remain active.");
            }
            return;
        }
    }

    // Used only at session boundaries, never in a logging prefix.
    internal static string DescribeHooks()
    {
        string? conflict = Volatile.Read(ref _conflict);
        if (conflict != null) return "disabled (conflict: " + conflict + ")";
        return "Manual=" + (Volatile.Read(ref _config) != null) +
               "; mod GUID=" + (_ownershipHarmony != null);
    }

    internal static void Report(string message) => LoadTimeProfilerPatcher.LogWarning(message);
    internal static void RemovePatches(Harmony harmony)
    {
        try { harmony.UnpatchSelf(); }
        catch (Exception ex) { Report("Could not remove patches for " + harmony.Id + ": " + ex.Message); }
    }

    internal static void Disable() => Volatile.Write(ref _config, null);

    internal static void Dispose()
    {
        lock (LifecycleLock)
        {
            Disable();
            Harmony? manual = _manualHarmony;
            Harmony? ownership = _ownershipHarmony;
            _manualHarmony = null;
            _ownershipHarmony = null;
            if (manual != null) RemovePatches(manual);
            if (ownership != null) RemovePatches(ownership);
            PluginOwners.Clear();
        }
    }
}
