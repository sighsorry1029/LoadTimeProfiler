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
    internal const string ModVersion = "1.0.0";
    internal const string Author = "sighsorry";
    internal const string ModGUID = Author + ".LoadTimeProfiler";

    private static ConfigEntry<bool>? _enabled;
    private static bool _initialized;

    public static IEnumerable<string> TargetDLLs { get; } = new[] { "UnityEngine.CoreModule.dll" };

    internal static ManualLogSource? Log { get; private set; }
    internal static bool ProfilingEnabled { get; private set; }
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
            ConfigFile config = new(Path.Combine(Paths.ConfigPath, ModGUID + ".cfg"), true);
            _enabled = config.Bind(
                "General",
                "Enabled",
                true,
                "Profile client loading or dedicated server startup. Changes apply on the next launch.");
            ProfilingEnabled = _enabled.Value;
        }
        catch (Exception ex)
        {
            ProfilingEnabled = true;
            System.Console.Error.WriteLine($"[{ModName}] Could not read config; profiling remains enabled: {ex.Message}");
        }

        ProfilerLog.Initialize();
        if (!ProfilingEnabled)
        {
            ProfilerLog.WriteLine("Profiling is disabled in config.");
            return;
        }

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
            if (ProfilingEnabled)
            {
                string profileScope = IsDedicatedServer ? "dedicated server startup" : "startup and connection";
                Log.LogInfo($"Writing {profileScope} profiles to {ProfilerLog.FilePath}.");
            }
            else
            {
                Log.LogInfo($"Profiler disabled. Session log reset at {ProfilerLog.FilePath}.");
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
}
