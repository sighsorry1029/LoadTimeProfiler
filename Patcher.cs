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
    internal const string ModVersion = "1.2.5";
    internal const string Author = "sighsorry";
    internal const string ModGUID = Author + ".LoadTimeProfiler";
    private const float DefaultConnectionTimeoutSeconds = 120f;
    private const string LocalizationCacheDescription =
        "Cache supported localization work during startup. Set to false when " +
        "Smoothbrain-StartupAccelerator or MSchmoecker-LocalizationCache is installed. " +
        "Changes apply on the next launch.";
    private const string ConfigWriteCoalescingDescription =
        "Coalesce automatic BepInEx config writes during Chainloader.Start while preserving explicit saves. " +
        "Set to false when Smoothbrain-StartupAccelerator is installed. " +
        "Changes apply on the next launch.";
    private const string TimeoutProtectionDescription =
        "Minimum timeout for supported connection and mod send queues. " +
        "Use 0 to disable protection or when MSchmoecker-TimeoutLimit is installed; " +
        "longer original limits are preserved. Changes apply on the next launch.";

    private static readonly ConfigDefinition[] CurrentDefinitions =
    {
        new("General", "ProfilingEnabled"),
        new("General", "LocalizationCacheEnabled"),
        new("General", "ConfigWriteCoalescingEnabled"),
        new("General", "TimeoutProtectionSeconds")
    };
    // BepInEx preserves unbound keys as orphaned entries. Inspect that
    // collection so the file can be kept to the current supported surface.
    private static readonly PropertyInfo? OrphanedEntriesProperty =
        typeof(ConfigFile).GetProperty(
            "OrphanedEntries",
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic);

    private static bool _initialized;

    public static IEnumerable<string> TargetDLLs { get; } = new[] { "UnityEngine.CoreModule.dll" };

    internal static ManualLogSource? Log { get; private set; }
    internal static bool ProfilingEnabled { get; private set; }
    internal static bool LocalizationCacheEnabled { get; private set; }
    internal static bool ConfigWriteCoalescingEnabled { get; private set; }
    internal static float ConnectionTimeoutSeconds { get; private set; } =
        DefaultConnectionTimeoutSeconds;
    internal static bool TimeoutProtectionEnabled =>
        ConnectionTimeoutSeconds > 0f;
    internal static bool StartupAccelerationEnabled =>
        LocalizationCacheEnabled || ConfigWriteCoalescingEnabled;
    internal static bool RuntimeInstrumentationNeeded =>
        ProfilingEnabled || LocalizationCacheEnabled;
    internal static bool AnyRuntimeFeatureEnabled =>
        ProfilingEnabled ||
        LocalizationCacheEnabled ||
        ConfigWriteCoalescingEnabled ||
        TimeoutProtectionEnabled;
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
                IDictionary<ConfigDefinition, string>? existingSettings =
                    TryGetExistingSettings(config);
                bool rewriteConfig =
                    ShouldRewriteConfig(existingSettings) ||
                    !DescriptionsAreCurrent(config.ConfigFilePath);

                ConfigEntry<bool> profilingEntry = config.Bind(
                    "General",
                    "ProfilingEnabled",
                    true,
                    "Create startup, world-loading, connection-outcome, and per-mod timing reports. " +
                    "Changes apply on the next launch.");
                ProfilingEnabled = profilingEntry.Value;
                ConfigEntry<bool> localizationEntry = config.Bind(
                    "General",
                    "LocalizationCacheEnabled",
                    true,
                    LocalizationCacheDescription);
                LocalizationCacheEnabled = localizationEntry.Value;
                ConfigEntry<bool> configCoalescingEntry = config.Bind(
                    "General",
                    "ConfigWriteCoalescingEnabled",
                    true,
                    ConfigWriteCoalescingDescription);
                ConfigWriteCoalescingEnabled = configCoalescingEntry.Value;
                ConfigEntry<float> timeoutEntry = config.Bind(
                    "General",
                    "TimeoutProtectionSeconds",
                    DefaultConnectionTimeoutSeconds,
                    new ConfigDescription(TimeoutProtectionDescription));
                float configuredTimeout = timeoutEntry.Value;
                ConnectionTimeoutSeconds =
                    NormalizeTimeout(configuredTimeout);
                if (!SameTimeout(
                        configuredTimeout,
                        ConnectionTimeoutSeconds))
                {
                    timeoutEntry.Value = ConnectionTimeoutSeconds;
                    rewriteConfig = true;
                }
                if (!SerializedValuesMatch(
                        existingSettings,
                        profilingEntry,
                        localizationEntry,
                        configCoalescingEntry,
                        timeoutEntry))
                {
                    rewriteConfig = true;
                }

                try
                {
                    if (rewriteConfig)
                    {
                        ClearUnsupportedSettings(config);
                        config.Save();
                    }
                }
                catch (Exception saveException)
                {
                    System.Console.Error.WriteLine(
                        $"[{ModName}] Could not save the current config file; the parsed feature values are still active: " +
                        saveException.Message);
                }
            }
            finally
            {
                config.SaveOnConfigSet = originalSaveOnConfigSet;
            }
        }
        catch (Exception ex)
        {
            ApplyDefaultSettings();
            System.Console.Error.WriteLine(
                $"[{ModName}] Could not read config; default feature settings remain active: {ex.Message}");
        }

        if (!AnyRuntimeFeatureEnabled)
        {
            return;
        }

        if (ProfilingEnabled)
        {
            ProfilerLog.Initialize();
            TimelineProfiler.BeginStartup(IsDedicatedServer);
        }
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
            if (ProfilingEnabled)
            {
                string profileScope = IsDedicatedServer
                    ? "dedicated server startup"
                    : "startup and connection";
                Log.LogInfo(
                    $"Writing {profileScope} profiles to {ProfilerLog.FilePath}.");
            }
            else
            {
                Log.LogInfo(
                    "Profiling is disabled; enabled acceleration and timeout features will run without report files.");
            }
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

    private static IDictionary<ConfigDefinition, string>? TryGetExistingSettings(
        ConfigFile config)
    {
        try
        {
            if (OrphanedEntriesProperty?.GetValue(config) is
                IDictionary<ConfigDefinition, string> orphanedEntries)
            {
                return new Dictionary<ConfigDefinition, string>(
                    orphanedEntries);
            }
        }
        catch (Exception ex)
        {
            System.Console.Error.WriteLine(
                $"[{ModName}] Could not inspect BepInEx orphaned config entries; raw config discovery will be used: " +
                ex.Message);
        }

        try
        {
            Dictionary<ConfigDefinition, string> settings = new();
            if (!File.Exists(config.ConfigFilePath))
            {
                return settings;
            }

            string section = string.Empty;
            foreach (string rawLine in File.ReadLines(
                         config.ConfigFilePath))
            {
                string line = rawLine.Trim();
                if (line.Length == 0 ||
                    line.StartsWith("#", StringComparison.Ordinal))
                {
                    continue;
                }

                if (line.Length >= 2 &&
                    line[0] == '[' &&
                    line[line.Length - 1] == ']')
                {
                    section = line.Substring(
                        1,
                        line.Length - 2).Trim();
                    continue;
                }

                int equals = line.IndexOf('=');
                if (equals <= 0 ||
                    section.Length == 0)
                {
                    continue;
                }

                string key = line.Substring(0, equals).Trim();
                if (key.Length > 0)
                {
                    settings[new ConfigDefinition(section, key)] =
                        line.Substring(equals + 1).Trim();
                }
            }

            return settings;
        }
        catch (Exception ex)
        {
            System.Console.Error.WriteLine(
                $"[{ModName}] Could not inspect current config keys; the config file will be rewritten: " +
                ex.Message);
            return null;
        }
    }

    private static bool ShouldRewriteConfig(
        IDictionary<ConfigDefinition, string>? existingSettings)
    {
        return existingSettings == null ||
               existingSettings.Count != CurrentDefinitions.Length ||
               CurrentDefinitions.Any(
                   definition => !existingSettings.ContainsKey(definition));
    }

    private static bool DescriptionsAreCurrent(string configPath)
    {
        if (!File.Exists(configPath))
        {
            return false;
        }

        try
        {
            string contents = File.ReadAllText(configPath);
            return contents.IndexOf(
                       LocalizationCacheDescription,
                       StringComparison.Ordinal) >= 0 &&
                   contents.IndexOf(
                       ConfigWriteCoalescingDescription,
                       StringComparison.Ordinal) >= 0 &&
                   contents.IndexOf(
                       TimeoutProtectionDescription,
                       StringComparison.Ordinal) >= 0;
        }
        catch
        {
            return false;
        }
    }

    private static bool SerializedValuesMatch(
        IDictionary<ConfigDefinition, string>? existingSettings,
        params ConfigEntryBase[] entries)
    {
        if (existingSettings == null)
        {
            return false;
        }

        foreach (ConfigEntryBase entry in entries)
        {
            if (!existingSettings.TryGetValue(
                    entry.Definition,
                    out string? serializedValue) ||
                !string.Equals(
                    serializedValue,
                    entry.GetSerializedValue(),
                    StringComparison.Ordinal))
            {
                return false;
            }
        }

        return true;
    }

    private static void ClearUnsupportedSettings(ConfigFile config)
    {
        if (OrphanedEntriesProperty?.GetValue(config) is
            IDictionary<ConfigDefinition, string> orphanedEntries)
        {
            orphanedEntries.Clear();
            return;
        }

        throw new InvalidOperationException(
            "BepInEx did not expose its unbound config entries.");
    }

    private static float NormalizeTimeout(float value)
    {
        return float.IsNaN(value) ||
               float.IsInfinity(value)
            ? DefaultConnectionTimeoutSeconds
            : value <= 0f
                ? 0f
                : value;
    }

    private static bool SameTimeout(float left, float right)
    {
        return !float.IsNaN(left) &&
               !float.IsInfinity(left) &&
               Math.Abs(left - right) < 0.0001f;
    }

    private static void ApplyDefaultSettings()
    {
        ProfilingEnabled = true;
        LocalizationCacheEnabled = true;
        ConfigWriteCoalescingEnabled = true;
        ConnectionTimeoutSeconds = DefaultConnectionTimeoutSeconds;
    }
}
