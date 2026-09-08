using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using BepInEx;
using BepInEx.Logging;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace LoadTimeProfiler;

public static class LoadTimeProfilerPatcher
{
    internal const string ModName = "LoadTimeProfiler";
    internal const string ModVersion = "1.3.1";
    internal const string Author = "sighsorry";
    internal const string ModGUID = Author + ".LoadTimeProfiler";
    internal const string ConfigFileName = ModGUID + ".cfg";
    private static int _bootstrapped;
    private static bool _initialized;
    private static ModConfiguration? _configuration;

    public static IEnumerable<string> TargetDLLs { get; } = new[] { "UnityEngine.CoreModule.dll" };
    internal static ModConfiguration? Configuration => Volatile.Read(ref _configuration);
    internal static ManualLogSource? Log { get; private set; }
    internal static bool ProfilingEnabled { get; private set; } = true;
    internal static bool LocalizationCacheEnabled { get; private set; } = true;
    internal static bool ConfigWriteCoalescingEnabled { get; private set; } = true;
    internal static bool ConfigAutoReloadEnabled { get; private set; }
    internal static float ConnectionTimeoutSeconds { get; private set; } = 120f;
    internal static bool TimeoutProtectionEnabled => ConnectionTimeoutSeconds > 0f;
    internal static bool StartupAccelerationEnabled => LocalizationCacheEnabled || ConfigWriteCoalescingEnabled;
    internal static bool RuntimeInstrumentationNeeded => ProfilingEnabled || LocalizationCacheEnabled;
    // Logging has its own process lifetime, including when every startup feature is disabled.
    internal static bool AnyStartupFeatureEnabled =>
        ProfilingEnabled || LocalizationCacheEnabled || ConfigWriteCoalescingEnabled || TimeoutProtectionEnabled;
    internal static bool IsDedicatedServer { get; private set; }

    // BepInEx calls this before Cecil processing. Do not resolve Unity/game types here.
    public static void Initialize()
    {
        if (Interlocked.Exchange(ref _bootstrapped, 1) != 0) return;
        AttachBepInExLogger();
        try
        {
            ModConfiguration configuration = new(
                Path.Combine(Paths.ConfigPath, ConfigFileName), LogWarning, LogInfo);
            Volatile.Write(ref _configuration, configuration);
            ModSettings startup = configuration.StartupSettings;
            ProfilingEnabled = startup.ProfilingEnabled;
            LocalizationCacheEnabled = startup.LocalizationCacheEnabled;
            ConfigWriteCoalescingEnabled = startup.ConfigWriteCoalescingEnabled;
            ConfigAutoReloadEnabled = startup.ConfigAutoReloadEnabled;
            ConnectionTimeoutSeconds = startup.TimeoutProtectionSeconds;
        }
        catch (Exception ex)
        {
            // Default startup features remain available if logging/configuration setup fails.
            LogError("Could not initialize configuration; startup defaults retained and logging filter disabled: " + ex);
        }

        if (Configuration is ModConfiguration config)
        {
            try { LogFiltering.Install(config); }
            catch (Exception ex)
            {
                LogFiltering.Dispose();
                LogError("Could not install logging filters; other features remain active: " + ex);
            }
        }
        if (ConfigAutoReloadEnabled)
        {
            try { ConfigAutoReload.Install(); }
            catch (Exception ex) { LogWarning("Config auto reload initialization failed: " + ex.Message); }
        }
        AppDomain.CurrentDomain.ProcessExit += Shutdown;
        AppDomain.CurrentDomain.DomainUnload += Shutdown;
    }

    public static void Patch(AssemblyDefinition assembly)
    {
        TimelineProfiler.CapturePatcherStart();
        try { InjectRuntimeEntrypoint(assembly); }
        catch (Exception ex) { LogError("Could not inject runtime entrypoint: " + ex); }
    }

    public static void Finish() => LogFiltering.CheckForConflicts();

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
        Initialize();
        if (_initialized) return;
        _initialized = true;
        string processName = Paths.ProcessName ?? string.Empty;
        IsDedicatedServer = processName.IndexOf("valheim_server", StringComparison.OrdinalIgnoreCase) >= 0;
        if (ProfilingEnabled)
        {
            ProfilerLog.Initialize();
            TimelineProfiler.BeginStartup(IsDedicatedServer);
            LogInfo("Writing " + (IsDedicatedServer ? "dedicated server startup" : "startup and connection") +
                    " profiles to " + ProfilerLog.FilePath + ".");
        }
        else
        {
            LogInfo("Profiling is disabled; independently enabled acceleration, timeout and logging features remain active.");
        }
    }

    internal static void AttachBepInExLogger()
    {
        if (Log != null) return;
        try { Log = Logger.CreateLogSource(ModName); }
        catch (Exception ex) { WriteConsole("Could not create log source: " + ex.Message); }
    }

    internal static void LogInfo(string message) => WriteLog(LogLevel.Info, message);
    internal static void LogWarning(string message) => WriteLog(LogLevel.Warning, message);
    internal static void LogError(string message) => WriteLog(LogLevel.Error, message);

    private static void WriteLog(LogLevel level, string message)
    {
        try
        {
            if (Log != null) Log.Log(level, message);
            else WriteConsole(message);
        }
        catch { WriteConsole(message); } // An unrelated listener must not abort startup or cfg reload.
    }

    private static void WriteConsole(string message)
    {
        try { System.Console.Error.WriteLine("[" + ModName + "] " + message); }
        catch { }
    }

    private static void Shutdown(object? sender, EventArgs args)
    {
        ConfigAutoReload.Dispose();
        ConfigManagerIntegration.Dispose();
        LogFiltering.Disable();
        Interlocked.Exchange(ref _configuration, null)?.Dispose();
    }
}
