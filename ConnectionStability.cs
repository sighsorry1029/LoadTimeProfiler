using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using BepInEx;
using BepInEx.Bootstrap;
using HarmonyLib;

namespace LoadTimeProfiler;

/// <summary>
/// Applies a small, fixed timeout floor to the connection paths that are known
/// to disconnect otherwise healthy peers while large mod payloads are queued.
/// Target discovery is deliberately narrow so startup profiling does not add a
/// second expensive compatibility-analysis phase.
/// </summary>
internal static class ConnectionStability
{
    private const string JotunnGuid = "com.jotunn.jotunn";
    private const string AzuAntiCheatGuid = "Azumatt.AzuAntiCheat";
    private const string LegacyTimeoutLimitGuid = "com.maxsch.valheim.TimeoutLimit";
    private const string ServerSyncTypeName = "ServerSync.ConfigSync";
    private const string OriginalServerSyncTimeoutMessage =
        "Disconnecting {0} after 30 seconds config sending timeout";
    private const string FixedServerSyncTimeoutMessage =
        "Disconnecting {0} after 90 seconds config sending timeout";

    private static readonly object Lock = new();
    private static readonly Harmony Harmony =
        new(LoadTimeProfilerPatcher.ModGUID + ".connection-stability");
    private static readonly HashSet<Assembly> InspectedAssemblies = new();
    private static readonly HashSet<MethodBase> RegisteredWaitTargets = new();
    private static readonly HashSet<MethodBase> CompatibleWaitTargets = new();
    private static readonly HashSet<MethodBase> RaisedWaitTargets = new();
    private static readonly HashSet<string> WarningSet = new(StringComparer.Ordinal);
    private static readonly List<string> Warnings = new();
    private static readonly MethodInfo? TimeGetter =
        AccessTools.PropertyGetter(typeof(UnityEngine.Time), nameof(UnityEngine.Time.time));
    private static readonly MethodInfo? WaitTranspilerMethod =
        AccessTools.DeclaredMethod(typeof(ConnectionStability), nameof(WaitForQueueTranspiler));

    private static bool _vanillaInstallAttempted;
    private static bool _vanillaPatchInstalled;
    private static FieldInfo? _zRpcTimeoutField;
    private static bool _loadedIntegrationsInstalled;
    private static bool _legacyTimeoutLimitDetected;
    private static bool _jotunnDetected;
    private static bool _jotunnTimeoutApplied;
    private static int _serverSyncAssembliesFound;
    private static int _serverSyncTargetsRegistered;
    private static int _serverSyncTargetsCompatible;
    private static int _azuTargetsRegistered;
    private static int _azuTargetsCompatible;
    private static double _installationMilliseconds;

    internal static void InstallBeforeChainloader()
    {
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
                _vanillaPatchInstalled = true;
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
        lock (Lock)
        {
            if (_loadedIntegrationsInstalled)
            {
                return;
            }

            _loadedIntegrationsInstalled = true;
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                PluginInfo[] plugins = GetLoadedPlugins();
                _legacyTimeoutLimitDetected = plugins.Any(plugin =>
                    string.Equals(
                        plugin.Metadata?.GUID,
                        LegacyTimeoutLimitGuid,
                        StringComparison.Ordinal));
                if (_legacyTimeoutLimitDetected)
                {
                    RecordWarning(
                        "Legacy TimeoutLimit is loaded; Jotunn and mod queue timeout ownership was left to it.");
                    return;
                }

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
            finally
            {
                stopwatch.Stop();
                _installationMilliseconds = stopwatch.Elapsed.TotalMilliseconds;
                ProfilerLog.WriteLine(
                    "Minimal connection stability installed in " +
                    stopwatch.Elapsed.TotalMilliseconds.ToString(
                        "0.###",
                        CultureInfo.InvariantCulture) +
                    " ms: ServerSync " +
                    _serverSyncTargetsCompatible.ToString(CultureInfo.InvariantCulture) +
                    "/" +
                    _serverSyncTargetsRegistered.ToString(CultureInfo.InvariantCulture) +
                    ", AzuAntiCheat " +
                    _azuTargetsCompatible.ToString(CultureInfo.InvariantCulture) +
                    "/" +
                    _azuTargetsRegistered.ToString(CultureInfo.InvariantCulture) +
                    " compatible queue target(s).");
            }
        }
    }

    internal static void AppendReport(StringBuilder builder, ProfileSession session)
    {
        lock (Lock)
        {
            builder.AppendLine("Connection stability:");
            builder.AppendLine(
                "  Mode: minimal; fixed timeout floor=90 s; original longer limits are preserved");
            builder.Append("  Integration installation: ")
                .AppendLine(TimelineProfiler.FormatDuration(_installationMilliseconds));
            builder.Append("  Vanilla ZRpc.SetLongTimeout: ")
                .AppendLine(_vanillaPatchInstalled
                    ? "postfix installed"
                    : _vanillaInstallAttempted
                        ? "not patched (original behavior retained)"
                        : "not attempted");
            builder.Append("  Jotunn CustomRPC.Timeout: ")
                .AppendLine(_legacyTimeoutLimitDetected
                    ? "left to legacy TimeoutLimit"
                    : !_jotunnDetected
                        ? "not present"
                        : _jotunnTimeoutApplied
                            ? "90-second floor applied"
                            : "already 90 seconds or longer");
            builder.Append("  ServerSync queue waits: ")
                .Append(_serverSyncTargetsCompatible)
                .Append('/')
                .Append(_serverSyncTargetsRegistered)
                .Append(" compatible target(s) in ")
                .Append(_serverSyncAssembliesFound)
                .AppendLine(" detected assembly/assemblies");
            builder.Append("  AzuAntiCheat queue waits: ")
                .Append(_azuTargetsCompatible)
                .Append('/')
                .Append(_azuTargetsRegistered)
                .AppendLine(" compatible target(s)");
            builder.Append("  Queue limits raised to 90 seconds: ")
                .AppendLine(RaisedWaitTargets.Count.ToString(CultureInfo.InvariantCulture));
            builder.AppendLine(
                "  Fragment cache lifetime: unchanged (original mod behavior retained)");

            if (Warnings.Count > 0)
            {
                builder.AppendLine("  Compatibility notes:");
                foreach (string warning in Warnings)
                {
                    builder.Append("    - ").AppendLine(warning);
                }
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

        _jotunnDetected = true;
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
                _jotunnTimeoutApplied = true;
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
                _serverSyncAssembliesFound++;
                foreach (MethodInfo target in FindWaitTargets(configSync))
                {
                    _serverSyncTargetsRegistered++;
                    bool compatible = PatchWaitTarget(
                        target,
                        "ServerSync in " + sourceName);
                    if (compatible)
                    {
                        _serverSyncTargetsCompatible++;
                    }
                }
            }

            if (isAzuAntiCheat)
            {
                foreach (MethodInfo target in FindAzuWaitTargets(assembly))
                {
                    _azuTargetsRegistered++;
                    bool compatible = PatchWaitTarget(
                        target,
                        "AzuAntiCheat in " + sourceName);
                    if (compatible)
                    {
                        _azuTargetsCompatible++;
                    }
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

    private static bool PatchWaitTarget(
        MethodInfo target,
        string integrationName)
    {
        if (!RegisteredWaitTargets.Add(target))
        {
            return CompatibleWaitTargets.Contains(target);
        }

        if (WaitTranspilerMethod == null || TimeGetter == null)
        {
            RecordWarning(
                integrationName +
                " queue timeout was skipped because the minimal transpiler prerequisites were unavailable.");
            return false;
        }

        try
        {
            CompatibleWaitTargets.Remove(target);
            RaisedWaitTargets.Remove(target);
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
                return false;
            }

            return true;
        }
        catch (Exception ex)
        {
            RecordWarning(
                integrationName + " queue timeout patch failed open for " +
                Describe(target) + ": " + OneLine(ex));
            return false;
        }
    }

    private static IEnumerable<CodeInstruction> WaitForQueueTranspiler(
        IEnumerable<CodeInstruction> instructions,
        MethodBase __originalMethod)
    {
        List<CodeInstruction> result = instructions.ToList();
        try
        {
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
                lock (Lock)
                {
                    RaisedWaitTargets.Add(__originalMethod);
                }
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
                            FixedServerSyncTimeoutMessage;
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

            if (Warnings.Count < 12)
            {
                Warnings.Add(warning);
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
