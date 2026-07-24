using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace LoadTimeProfiler;

public static class LoadTimeProfilerPatcher
{
    internal const string ModName = "LoadTimeProfiler";
    internal const string ModVersion = "1.1.2";
    internal const string Author = "sighsorry";
    internal const string ModGUID = Author + ".LoadTimeProfiler";
    internal const float ConnectionTimeoutSeconds = 90f;

    private static readonly ConfigDefinition GeneralEnabledDefinition =
        new("General", "Enabled");
    private static readonly ConfigDefinition[] LegacyDefinitions =
    {
        new("Startup Acceleration", "CacheLocalizationCsv"),
        new("Startup Acceleration", "CoalesceConfigWrites"),
        new("Startup Acceleration", "BatchHarmonyPatches"),
        new("Startup Acceleration", "HarmonyBatchPassthroughTypes"),
        new("Connection Stability", "Enabled"),
        new("Connection Stability", "TimeoutSeconds"),
        new("Connection Stability", "FragmentCacheLifetimeSeconds")
    };
    // BepInEx preserves unbound keys as orphaned entries. Inspect that
    // collection so an already-clean config is not rewritten every launch.
    private static readonly PropertyInfo? OrphanedEntriesProperty =
        typeof(ConfigFile).GetProperty(
            "OrphanedEntries",
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic);

    private static ConfigEntry<bool>? _enabled;
    private static bool _initialized;

    public static IEnumerable<string> TargetDLLs { get; } = new[] { "UnityEngine.CoreModule.dll" };

    internal static ManualLogSource? Log { get; private set; }
    internal static bool ProfilingEnabled { get; private set; }
    internal static bool LocalizationCacheEnabled => ProfilingEnabled;
    internal static bool CoalesceConfigWrites => ProfilingEnabled;
    internal static bool AnyRuntimeFeatureEnabled => ProfilingEnabled;
    internal static bool IsDedicatedServer { get; private set; }

    public static void Patch(AssemblyDefinition assembly)
    {
        TimelineProfiler.CapturePatcherStart();
        try
        {
            InjectRuntimeEntrypoint(assembly);
        }
        catch (Exception ex)
        {
            System.Console.Error.WriteLine($"[{ModName}] Could not inject runtime entrypoint: {ex}");
        }
    }

    public static void Finish()
    {
    }

    private static void InjectRuntimeEntrypoint(AssemblyDefinition assembly)
    {
        TypeDefinition gameObject = assembly.MainModule.Types.First(type =>
            type.Namespace == "UnityEngine" && type.Name == "GameObject");
        MethodDefinition staticConstructor = gameObject.Methods.First(method => method.IsConstructor && method.IsStatic);
        Instruction chainloaderStart = staticConstructor.Body.Instructions.First(instruction =>
            instruction.OpCode == OpCodes.Call &&
            instruction.Operand is MethodReference reference &&
            reference.DeclaringType.FullName == "BepInEx.Bootstrap.Chainloader" &&
            reference.Name == "Start");

        MethodInfo beforeMethod = typeof(RuntimeEntrypoint).GetMethod(
            nameof(RuntimeEntrypoint.BeforeChainloaderStart),
            BindingFlags.Public | BindingFlags.Static)!;
        MethodInfo afterMethod = typeof(RuntimeEntrypoint).GetMethod(
            nameof(RuntimeEntrypoint.AfterChainloaderStart),
            BindingFlags.Public | BindingFlags.Static)!;
        ILProcessor processor = staticConstructor.Body.GetILProcessor();
        processor.InsertBefore(
            chainloaderStart,
            processor.Create(OpCodes.Call, assembly.MainModule.ImportReference(beforeMethod)));
        processor.InsertAfter(
            chainloaderStart,
            processor.Create(OpCodes.Call, assembly.MainModule.ImportReference(afterMethod)));
    }

    internal static void InitializeProfiler()
    {
        if (_initialized)
        {
            return;
        }

        _initialized = true;
        IsDedicatedServer = DetectDedicatedServer();
        try
        {
            ConfigFile config = new(Path.Combine(Paths.ConfigPath, ModGUID + ".cfg"), false);
            bool originalSaveOnConfigSet = config.SaveOnConfigSet;
            config.SaveOnConfigSet = false;
            try
            {
                bool saveSimplifiedConfig =
                    ShouldSaveSimplifiedConfig(config);
                _enabled = config.Bind(
                    "General",
                    "Enabled",
                    true,
                    "Enable profiling, safe startup acceleration, and fixed 90-second connection-timeout protection. " +
                    "Changes apply on the next launch.");
                ProfilingEnabled = _enabled.Value;

                try
                {
                    if (saveSimplifiedConfig)
                    {
                        RemoveLegacySettings(config);
                        config.Save();
                    }
                }
                catch (Exception migrationException)
                {
                    System.Console.Error.WriteLine(
                        $"[{ModName}] Could not simplify the existing config file; the parsed Enabled value is still active: " +
                        migrationException.Message);
                }
            }
            finally
            {
                config.SaveOnConfigSet = originalSaveOnConfigSet;
            }
        }
        catch (Exception ex)
        {
            ProfilingEnabled = true;
            System.Console.Error.WriteLine(
                $"[{ModName}] Could not read config; LoadTimeProfiler remains enabled: {ex.Message}");
        }

        if (!AnyRuntimeFeatureEnabled)
        {
            return;
        }

        ProfilerLog.Initialize();
        TimelineProfiler.BeginStartup(IsDedicatedServer);
        ProfilerLog.WriteLine(IsDedicatedServer
            ? "Preloader profiler active. Waiting for dedicated server startup."
            : "Preloader profiler active. Waiting for BepInEx chainloader startup.");
    }

    internal static void AttachBepInExLogger()
    {
        if (Log != null)
        {
            return;
        }

        try
        {
            Log = Logger.CreateLogSource(ModName);
            string profileScope = IsDedicatedServer ? "dedicated server startup" : "startup and connection";
            Log.LogInfo($"Writing {profileScope} profiles to {ProfilerLog.FilePath}.");
        }
        catch (Exception ex)
        {
            System.Console.Error.WriteLine($"[{ModName}] Could not create BepInEx log source: {ex.Message}");
        }
    }

    internal static void LogInfo(string message)
    {
        Log?.LogInfo(message);
    }

    internal static void LogWarning(string message)
    {
        if (Log != null)
        {
            Log.LogWarning(message);
        }
        else
        {
            System.Console.Error.WriteLine($"[{ModName}] {message}");
        }
    }

    internal static void LogError(string message)
    {
        if (Log != null)
        {
            Log.LogError(message);
        }
        else
        {
            System.Console.Error.WriteLine($"[{ModName}] {message}");
        }
    }

    private static bool DetectDedicatedServer()
    {
        string processName = Paths.ProcessName ?? string.Empty;
        return processName.IndexOf("valheim_server", StringComparison.OrdinalIgnoreCase) >= 0;
    }

    private static void RemoveLegacySettings(ConfigFile config)
    {
        RemoveLegacySetting(config, "Startup Acceleration", "CacheLocalizationCsv", true);
        RemoveLegacySetting(config, "Startup Acceleration", "CoalesceConfigWrites", true);
        RemoveLegacySetting(config, "Startup Acceleration", "BatchHarmonyPatches", false);
        RemoveLegacySetting(config, "Startup Acceleration", "HarmonyBatchPassthroughTypes", string.Empty);
        RemoveLegacySetting(config, "Connection Stability", "Enabled", true);
        RemoveLegacySetting(config, "Connection Stability", "TimeoutSeconds", 90f);
        RemoveLegacySetting(config, "Connection Stability", "FragmentCacheLifetimeSeconds", 600f);
    }

    private static void RemoveLegacySetting<T>(
        ConfigFile config,
        string section,
        string key,
        T defaultValue)
    {
        ConfigEntry<T> entry = config.Bind(section, key, defaultValue, string.Empty);
        config.Remove(entry.Definition);
    }

    private static bool ShouldSaveSimplifiedConfig(ConfigFile config)
    {
        try
        {
            if (OrphanedEntriesProperty?.GetValue(config) is
                IDictionary<ConfigDefinition, string> orphanedEntries)
            {
                return !orphanedEntries.ContainsKey(
                           GeneralEnabledDefinition) ||
                       LegacyDefinitions.Any(
                           orphanedEntries.ContainsKey);
            }
        }
        catch (Exception ex)
        {
            System.Console.Error.WriteLine(
                $"[{ModName}] Could not inspect existing config entries; a safe config rewrite will be used: " +
                ex.Message);
        }

        return true;
    }
}
