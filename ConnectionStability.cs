using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using BepInEx;
using BepInEx.Bootstrap;
using HarmonyLib;

namespace LoadTimeProfiler;

/// <summary>
/// Applies a small, configurable timeout floor to connection paths that are known
/// to disconnect otherwise healthy peers while large mod payloads are queued.
/// Target discovery is deliberately narrow so startup profiling does not add a
/// second expensive compatibility-analysis phase.
/// </summary>
internal static class ConnectionStability
{
    private const string JotunnGuid = "com.jotunn.jotunn";
    private const string AzuAntiCheatGuid = "Azumatt.AzuAntiCheat";
    private const string ServerSyncTypeName = "ServerSync.ConfigSync";
    private const string OriginalServerSyncTimeoutMessage =
        "Disconnecting {0} after 30 seconds config sending timeout";

    private static readonly object Lock = new();
    private static readonly Harmony Harmony =
        new(LoadTimeProfilerPatcher.ModGUID + ".connection-stability");
    private static readonly HashSet<Assembly> InspectedAssemblies = new();
    private static readonly HashSet<MethodBase> RegisteredWaitTargets = new();
    private static readonly HashSet<MethodBase> CompatibleWaitTargets = new();
    private static readonly HashSet<string> WarningSet = new(StringComparer.Ordinal);
    private static readonly MethodInfo? TimeGetter =
        AccessTools.PropertyGetter(typeof(UnityEngine.Time), nameof(UnityEngine.Time.time));
    private static readonly MethodInfo? WaitTranspilerMethod =
        AccessTools.DeclaredMethod(typeof(ConnectionStability), nameof(WaitForQueueTranspiler));

    private static bool _vanillaInstallAttempted;
    private static FieldInfo? _zRpcTimeoutField;
    private static bool _loadedIntegrationsInstalled;

    internal static void InstallBeforeChainloader()
    {
        if (!LoadTimeProfilerPatcher.TimeoutProtectionEnabled)
        {
            return;
        }

        lock (Lock)
        {
            if (_vanillaInstallAttempted)
            {
                return;
            }

            _vanillaInstallAttempted = true;
            try
            {
                MethodInfo? target = AccessTools.DeclaredMethod(
                    typeof(ZRpc),
                    nameof(ZRpc.SetLongTimeout),
                    new[] { typeof(bool) });
                FieldInfo? timeoutField = AccessTools.DeclaredField(typeof(ZRpc), "m_timeout");
                MethodInfo? postfix = AccessTools.DeclaredMethod(
                    typeof(ConnectionStability),
                    nameof(ZRpcSetLongTimeoutPostfix));
                if (target == null ||
                    timeoutField == null ||
                    timeoutField.FieldType != typeof(float) ||
                    !timeoutField.IsStatic ||
                    postfix == null)
                {
                    RecordWarning(
                        "Vanilla ZRpc timeout protection was skipped because the expected method or static float field was unavailable.");
                    return;
                }

                Harmony.Patch(
                    target,
                    postfix: new HarmonyMethod(postfix) { priority = Priority.Last });
                _zRpcTimeoutField = timeoutField;
            }
            catch (Exception ex)
            {
                RecordWarning(
                    "Vanilla ZRpc timeout protection failed open: " + OneLine(ex));
            }
        }
    }

    internal static void InstallLoadedModIntegrations()
    {
        if (!LoadTimeProfilerPatcher.TimeoutProtectionEnabled)
        {
            return;
        }

        lock (Lock)
        {
            if (_loadedIntegrationsInstalled)
            {
                return;
            }

            _loadedIntegrationsInstalled = true;
            try
            {
                PluginInfo[] plugins = GetLoadedPlugins();
                InstallJotunnTimeout(plugins);
                foreach (PluginInfo plugin in plugins)
                {
                    Assembly assembly = plugin.Instance.GetType().Assembly;
                    bool isAzuAntiCheat = string.Equals(
                        plugin.Metadata?.GUID,
                        AzuAntiCheatGuid,
                        StringComparison.Ordinal);
                    InspectAssembly(
                        assembly,
                        plugin.Metadata == null
                            ? assembly.GetName().Name ?? "unknown plugin"
                            : plugin.Metadata.Name + " [" + plugin.Metadata.GUID + "]",
                        isAzuAntiCheat);
                }

                // ServerSync may be a regular dependency rather than merged into
                // the plugin assembly. Exact type lookup keeps this pass cheap.
                foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    InspectAssembly(
                        assembly,
                        "loaded assembly " + (assembly.GetName().Name ?? "unknown"),
                        isAzuAntiCheat: false);
                }
            }
            catch (Exception ex)
            {
                RecordWarning(
                    "Minimal mod timeout integration failed open: " + OneLine(ex));
            }
        }
    }

    private static PluginInfo[] GetLoadedPlugins()
    {
        try
        {
            return Chainloader.PluginInfos.Values
                .Where(plugin => plugin != null && plugin.Instance != null)
                .ToArray();
        }
        catch (Exception ex)
        {
            RecordWarning("Loaded plugin enumeration failed: " + OneLine(ex));
            return Array.Empty<PluginInfo>();
        }
    }

    private static void InstallJotunnTimeout(IEnumerable<PluginInfo> plugins)
    {
        PluginInfo? plugin = plugins.FirstOrDefault(candidate =>
            string.Equals(candidate.Metadata?.GUID, JotunnGuid, StringComparison.Ordinal));
        if (plugin?.Instance == null)
        {
            return;
        }

        try
        {
            Type? customRpc = plugin.Instance.GetType().Assembly.GetType(
                "Jotunn.Entities.CustomRPC",
                throwOnError: false);
            FieldInfo? timeout = customRpc?.GetField(
                "Timeout",
                BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
            if (timeout == null ||
                timeout.FieldType != typeof(float) ||
                timeout.IsInitOnly ||
                timeout.IsLiteral)
            {
                RecordWarning(
                    "Jotunn was detected, but CustomRPC.Timeout was not a mutable static float; its original timeout was retained.");
                return;
            }

            object? value = timeout.GetValue(null);
            if (value is not float current)
            {
                RecordWarning(
                    "Jotunn CustomRPC.Timeout could not be read; its original timeout was retained.");
                return;
            }

            if (float.IsNaN(current) ||
                current < LoadTimeProfilerPatcher.ConnectionTimeoutSeconds)
            {
                timeout.SetValue(null, LoadTimeProfilerPatcher.ConnectionTimeoutSeconds);
            }
        }
        catch (Exception ex)
        {
            RecordWarning("Jotunn timeout integration failed open: " + OneLine(ex));
        }
    }

    private static void InspectAssembly(
        Assembly assembly,
        string sourceName,
        bool isAzuAntiCheat)
    {
        if (!InspectedAssemblies.Add(assembly) || assembly.IsDynamic)
        {
            return;
        }

        try
        {
            Type? configSync = assembly.GetType(
                ServerSyncTypeName,
                throwOnError: false,
                ignoreCase: false);
            if (configSync != null)
            {
                foreach (MethodInfo target in FindWaitTargets(configSync))
                {
                    PatchWaitTarget(
                        target,
                        "ServerSync in " + sourceName);
                }
            }

            if (isAzuAntiCheat)
            {
                foreach (MethodInfo target in FindAzuWaitTargets(assembly))
                {
                    PatchWaitTarget(
                        target,
                        "AzuAntiCheat in " + sourceName);
                }
            }
        }
        catch (Exception ex)
        {
            RecordWarning(
                "Connection timeout discovery failed for " + sourceName + ": " +
                OneLine(ex));
        }
    }

    private static IEnumerable<MethodInfo> FindWaitTargets(Type root)
    {
        HashSet<MethodInfo> targets = new();
        foreach (Type type in EnumerateTypeAndNested(root))
        {
            AddIteratorTargets(type, targets);
        }

        return targets;
    }

    private static IEnumerable<MethodInfo> FindAzuWaitTargets(Assembly assembly)
    {
        HashSet<MethodInfo> targets = new();
        foreach (Type type in GetLoadableTypes(assembly))
        {
            AddIteratorTargets(type, targets);
        }

        return targets;
    }

    private static void AddIteratorTargets(
        Type type,
        ISet<MethodInfo> targets)
    {
        foreach (MethodInfo factory in GetDeclaredMethods(type))
        {
            if (factory.Name.IndexOf(
                    "waitForQueue",
                    StringComparison.OrdinalIgnoreCase) < 0)
            {
                continue;
            }

            IteratorStateMachineAttribute? stateMachine;
            try
            {
                stateMachine = factory.GetCustomAttribute<IteratorStateMachineAttribute>(
                    inherit: false);
            }
            catch
            {
                continue;
            }

            MethodInfo? moveNext = stateMachine?.StateMachineType.GetMethod(
                "MoveNext",
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.DeclaredOnly);
            if (moveNext != null &&
                moveNext.ReturnType == typeof(bool) &&
                moveNext.GetParameters().Length == 0)
            {
                targets.Add(moveNext);
            }
        }
    }

    private static void PatchWaitTarget(
        MethodInfo target,
        string integrationName)
    {
        if (!RegisteredWaitTargets.Add(target))
        {
            return;
        }

        if (WaitTranspilerMethod == null || TimeGetter == null)
        {
            RecordWarning(
                integrationName +
                " queue timeout was skipped because the minimal transpiler prerequisites were unavailable.");
            return;
        }

        try
        {
            CompatibleWaitTargets.Remove(target);
            Harmony.Patch(
                target,
                transpiler: new HarmonyMethod(WaitTranspilerMethod)
                {
                    priority = Priority.Last
                });

            if (!CompatibleWaitTargets.Contains(target))
            {
                RecordWarning(
                    integrationName +
                    " queue timeout retained its original body because no unique Time.time deadline was found in " +
                    Describe(target) + ".");
            }
        }
        catch (Exception ex)
        {
            RecordWarning(
                integrationName + " queue timeout patch failed open for " +
                Describe(target) + ": " + OneLine(ex));
        }
    }

    private static IEnumerable<CodeInstruction> WaitForQueueTranspiler(
        IEnumerable<CodeInstruction> instructions,
        MethodBase __originalMethod)
    {
        List<CodeInstruction> result = instructions.ToList();
        try
        {
            if (!LoadTimeProfilerPatcher.TimeoutProtectionEnabled)
            {
                return result;
            }

            List<int> deadlineLiterals = new();
            for (int i = 0; i + 2 < result.Count; i++)
            {
                if (TimeGetter == null ||
                    !result[i].Calls(TimeGetter) ||
                    result[i + 1].opcode != OpCodes.Ldc_R4 ||
                    result[i + 1].operand is not float ||
                    result[i + 2].opcode != OpCodes.Add)
                {
                    continue;
                }

                deadlineLiterals.Add(i + 1);
            }

            if (deadlineLiterals.Count != 1)
            {
                return result;
            }

            CodeInstruction literal = result[deadlineLiterals[0]];
            float originalTimeout = (float)literal.operand;
            if (float.IsNaN(originalTimeout) || originalTimeout <= 0f)
            {
                return result;
            }

            if (originalTimeout < LoadTimeProfilerPatcher.ConnectionTimeoutSeconds)
            {
                literal.operand = LoadTimeProfilerPatcher.ConnectionTimeoutSeconds;
            }

            if (originalTimeout <=
                LoadTimeProfilerPatcher.ConnectionTimeoutSeconds)
            {
                foreach (CodeInstruction instruction in result)
                {
                    if (instruction.opcode == OpCodes.Ldstr &&
                        instruction.operand is string text &&
                        string.Equals(
                            text,
                            OriginalServerSyncTimeoutMessage,
                            StringComparison.Ordinal))
                    {
                        instruction.operand =
                            "Disconnecting {0} after " +
                            FormatConfiguredTimeout() +
                            " seconds config sending timeout";
                    }
                }
            }

            lock (Lock)
            {
                CompatibleWaitTargets.Add(__originalMethod);
            }
        }
        catch (Exception ex)
        {
            RecordWarning(
                "Minimal queue timeout transpiler retained the original body for " +
                Describe(__originalMethod) + ": " + OneLine(ex));
        }

        return result;
    }

    private static void ZRpcSetLongTimeoutPostfix()
    {
        if (!LoadTimeProfilerPatcher.TimeoutProtectionEnabled)
        {
            return;
        }

        try
        {
            FieldInfo? timeoutField = _zRpcTimeoutField;
            if (timeoutField?.GetValue(null) is not float current)
            {
                return;
            }

            if (float.IsNaN(current) ||
                current < LoadTimeProfilerPatcher.ConnectionTimeoutSeconds)
            {
                timeoutField.SetValue(
                    null,
                    LoadTimeProfilerPatcher.ConnectionTimeoutSeconds);
            }
        }
        catch (Exception ex)
        {
            RecordWarning("ZRpc timeout override failed open: " + OneLine(ex));
        }
    }

    private static string FormatConfiguredTimeout()
    {
        return LoadTimeProfilerPatcher.ConnectionTimeoutSeconds.ToString(
            "0.###",
            CultureInfo.InvariantCulture);
    }

    private static IEnumerable<Type> EnumerateTypeAndNested(Type root)
    {
        yield return root;
        Type[] nested;
        try
        {
            nested = root.GetNestedTypes(
                BindingFlags.Public | BindingFlags.NonPublic);
        }
        catch
        {
            yield break;
        }

        foreach (Type type in nested)
        {
            foreach (Type descendant in EnumerateTypeAndNested(type))
            {
                yield return descendant;
            }
        }
    }

    private static IEnumerable<Type> GetLoadableTypes(Assembly assembly)
    {
        try
        {
            return assembly.GetTypes();
        }
        catch (ReflectionTypeLoadException ex)
        {
            return ex.Types.Where(type => type != null).Cast<Type>();
        }
        catch
        {
            return Array.Empty<Type>();
        }
    }

    private static MethodInfo[] GetDeclaredMethods(Type type)
    {
        try
        {
            return type.GetMethods(
                BindingFlags.Instance |
                BindingFlags.Static |
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.DeclaredOnly);
        }
        catch
        {
            return Array.Empty<MethodInfo>();
        }
    }

    private static void RecordWarning(string warning)
    {
        lock (Lock)
        {
            if (!WarningSet.Add(warning))
            {
                return;
            }

            LoadTimeProfilerPatcher.LogWarning(warning);
            ProfilerLog.WriteLine("Connection stability warning: " + warning);
        }
    }

    private static string Describe(MethodBase method)
    {
        return (method.DeclaringType?.FullName ?? "<unknown type>") +
               "." +
               method.Name;
    }

    private static string OneLine(Exception exception)
    {
        Exception root = exception is TargetInvocationException { InnerException: not null }
            ? exception.InnerException
            : exception;
        return root.GetType().Name + ": " +
               (root.Message ?? string.Empty).Replace('\r', ' ').Replace('\n', ' ');
    }
}
