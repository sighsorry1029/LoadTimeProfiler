using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using BepLogger = BepInEx.Logging.Logger;

[BepInPlugin("sighsorry.LoadTimeProfiler.UnitySmokeProbe", "LoadTimeProfiler Unity smoke probe", "1.0.0")]
public sealed class UnitySmokeProbe : BaseUnityPlugin
{
    private readonly List<string> results = new List<string>();
    private readonly Dictionary<string, int> unityEvents = new Dictionary<string, int>(StringComparer.Ordinal);
    private readonly Dictionary<string, int> forwardedEvents = new Dictionary<string, int>(StringComparer.Ordinal);
    private readonly object eventLock = new object();
    private ManualLogSource source;
    private ManualLogSource impostor;
    private ManualLogSource diagnostic;
    private ManualLogSource pluginA;
    private ManualLogSource pluginB;
    private UnityLogSource bridgeSource;
    private string resultPath;
    private string configPath;
    private Type patcherType;
    private bool startupFeaturesEnabled;
    private bool configAutoReloadEnabled;
    private bool shutUpConflictFixture;
    private string reportPath;
    private string startupReport;
    private string managerAssemblyPath;
    private IDisposable otherExternalRegistration;
    private int manualEvents;
    private int failures;

    public UnitySmokeProbe() { SmokeEarlyLogs.Emit(Logger, "default_ctor"); }
    private void Awake()
    {
        SmokeEarlyLogs.Emit(Logger, "default_awake");
        SmokeDedicatedGuard.Install();
    }

    private IEnumerator Start()
    {
        // Drive nested iterators too, so any fixture/callback exception produces
        // a FAIL result instead of silently stopping a child Unity coroutine.
        Stack<IEnumerator> steps = new Stack<IEnumerator>();
        steps.Push(Run());
        while (steps.Count > 0)
        {
            object next;
            try
            {
                IEnumerator current = steps.Peek();
                if (!current.MoveNext())
                {
                    steps.Pop();
                    IDisposable disposable = current as IDisposable;
                    if (disposable != null) disposable.Dispose();
                    continue;
                }
                next = current.Current;
                IEnumerator nested = next as IEnumerator;
                if (nested != null) { steps.Push(nested); continue; }
            }
            catch (Exception ex)
            {
                failures++;
                results.Add("FAIL unexpected exception: " + ex);
                break;
            }
            yield return next;
        }

        results.Add(failures == 0 ? "STATUS=PASS" : "STATUS=FAIL");
        try { if (resultPath != null) File.WriteAllLines(resultPath, results, new UTF8Encoding(false)); }
        finally { Application.Quit(failures == 0 ? 0 : 1); }
    }

    private IEnumerator Run()
    {
        string expectedRoot = Environment.GetEnvironmentVariable("LOADTIMEPROFILER_SMOKE_ROOT");
        if (string.IsNullOrEmpty(expectedRoot)) throw new InvalidOperationException("Runner root is missing.");
        expectedRoot = Path.GetFullPath(expectedRoot);
        resultPath = Path.Combine(expectedRoot, "UnitySmokeResult.txt");
        string pluginRoot = Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        if (!SamePath(Paths.BepInExRootPath, expectedRoot) || !SamePath(pluginRoot, expectedRoot) ||
            !SamePath(Paths.ConfigPath, Path.Combine(expectedRoot, "config")))
            throw new InvalidOperationException("BepInEx paths escaped the isolated smoke root.");

        if (SmokeDedicatedGuard.Failure != null) throw new InvalidOperationException("Dedicated runtime isolation guard failed.", SmokeDedicatedGuard.Failure);
        bool dedicated = Environment.GetEnvironmentVariable("LOADTIMEPROFILER_SMOKE_DEDICATED") == "enabled";
        results.Add(dedicated
            ? "MODE=actual-dedicated-runtime (probe guards prevent platform login, network and world startup; not full server gameplay)"
            : "MODE=headless-client (not a dedicated-server executable)");
        if (dedicated)
        {
            MethodInfo isDedicated = AccessTools.Method(AccessTools.TypeByName("ZNet"), "IsDedicated");
            // The server build compiles this instance method to ldc.i4.1; ret.
            // Inspect it without constructing ZNet or starting a world merely
            // to obtain an invocation target for the dedicated-mode assertion.
            byte[] dedicatedIl = isDedicated == null ? null : isDedicated.GetMethodBody().GetILAsByteArray();
            Record("dedicated runtime: server assembly has the constant-true IsDedicated body and isolation guards are installed",
                SmokeDedicatedGuard.Installed && dedicatedIl != null && dedicatedIl.Length == 2 &&
                dedicatedIl[0] == 0x17 && dedicatedIl[1] == 0x2a);
        }
        results.Add("BEPINEX_ROOT=" + Paths.BepInExRootPath);
        results.Add("UNITY_VERSION=" + Application.unityVersion);
        startupFeaturesEnabled = Environment.GetEnvironmentVariable("LOADTIMEPROFILER_SMOKE_STARTUP") != "disabled";
        configAutoReloadEnabled = Environment.GetEnvironmentVariable("LOADTIMEPROFILER_SMOKE_AUTO_RELOAD") == "enabled";
        shutUpConflictFixture = Environment.GetEnvironmentVariable("LOADTIMEPROFILER_SMOKE_SHUTUP_FIXTURE") == "enabled";
        results.Add("STARTUP_FEATURES=" + (startupFeaturesEnabled ? "enabled" : "disabled"));
        results.Add("CONFIG_AUTO_RELOAD=" + (configAutoReloadEnabled ? "enabled" : "disabled"));
        results.Add("SHUTUP_CONFLICT=" + (shutUpConflictFixture ? "no-op assembly identity fixture, not original ShutUp execution" : "none"));
        configPath = Path.Combine(Paths.ConfigPath, "sighsorry.LoadTimeProfiler.cfg");
        managerAssemblyPath = Environment.GetEnvironmentVariable("LOADTIMEPROFILER_SMOKE_CONFIG_MANAGER");
        Assembly product = FindProductAssembly();
        patcherType = product.GetType("LoadTimeProfiler.LoadTimeProfilerPatcher", true);
        CheckInstallation(product);
        CheckStartupFlags("initial");

        PluginInfo fixtureA;
        PluginInfo fixtureB;
        if (!Chainloader.PluginInfos.TryGetValue(SmokePluginA.Guid, out fixtureA) ||
            !Chainloader.PluginInfos.TryGetValue(SmokePluginB.Guid, out fixtureB))
            throw new InvalidOperationException("Both real plugin fixtures must load through Chainloader.");
        pluginA = ((SmokePluginA)fixtureA.Instance).TestLogger;
        pluginB = ((SmokePluginB)fixtureB.Instance).TestLogger;
        Record("same-name fixture plugins have different GUIDs and different default logger objects",
            fixtureA.Metadata.Name == fixtureB.Metadata.Name && fixtureA.Metadata.GUID != fixtureB.Metadata.GUID &&
            !ReferenceEquals(pluginA, pluginB) && pluginA.SourceName == pluginB.SourceName);
        Record("plugin A constructor and Awake logs obey " + (shutUpConflictFixture ? "conflict pass-through" : "GUID Errors, Warnings policy"),
            SmokeEarlyLogs.Matches("A_ctor", shutUpConflictFixture, true) && SmokeEarlyLogs.Matches("A_awake", shutUpConflictFixture, true));
        Record("same-name plugin B constructor and Awake logs independently obey all four GUID groups",
            SmokeEarlyLogs.Matches("B_ctor", true, true) && SmokeEarlyLogs.Matches("B_awake", true, true));
        Record("unconfigured GUID constructor and Awake obey " + (shutUpConflictFixture ? "conflict pass-through" : "Errors, Warnings default"),
            SmokeEarlyLogs.Matches("default_ctor", shutUpConflictFixture, true) && SmokeEarlyLogs.Matches("default_awake", shutUpConflictFixture, true) &&
            ReadConfigValue(File.ReadAllText(configPath), "Logging.Mods", Info.Metadata.GUID) == null);

        // These names deliberately collide with registered plugin/default
        // diagnostic names. Only the exact logger object may confer ownership.
        source = BepLogger.CreateLogSource(SmokePluginA.FriendlyName);
        impostor = BepLogger.CreateLogSource("LoadTimeProfiler");
        diagnostic = (ManualLogSource)patcherType.GetProperty("Log", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null, null);
        bridgeSource = new UnityLogSource();
        bridgeSource.LogEvent += OnForwardedUnity;
        Application.logMessageReceivedThreaded += OnUnityLog;
        yield return new WaitForSecondsRealtime(0.25f);

        if (startupFeaturesEnabled)
        {
            float deadline = Time.realtimeSinceStartup + 20f;
            do
            {
                CaptureCompletedReport();
                if (startupReport != null) break;
                yield return new WaitForSecondsRealtime(0.25f);
            } while (Time.realtimeSinceStartup < deadline);
            Record("normal client lifecycle completes Start To Lobby report", startupReport != null);
        }
        else Record("disabled profiling creates no report", ReportFiles().Length == 0);

        CheckGroups("initial", 3, 15);
        yield return CheckUnity("initial");
        CheckNoUnityLoggingPatches("initial");

        // Exercise every checkbox combination through the production timer,
        // with a different complementary policy for the same-name other mod.
        // The conflict path needs only the policy extremes: neither may
        // suppress a log when the no-op ShutUp identity fixture is loaded.
        for (int groups = 0; groups < 16; groups += shutUpConflictFixture ? 15 : 1)
        {
            ReplaceConfig(GroupsText(groups), GroupsText(15 - groups));
            yield return WaitForGroups(groups, 15 - groups);
            CheckGroups("timer_groups_" + groups, groups, 15 - groups);
            if (groups == 0)
            {
                // Ownership must remain installed after profiling finishes and
                // when all startup features were disabled from the beginning.
                GameObject lateObject = new GameObject("LoadTimeProfiler late fixture");
                try
                {
                    SmokePluginA late = lateObject.AddComponent<SmokePluginA>();
                    Record("late-created instance constructor and Awake obey " + (shutUpConflictFixture ? "conflict pass-through" : "GUID None policy"),
                        SmokeEarlyLogs.Matches("A_ctor", shutUpConflictFixture, shutUpConflictFixture) &&
                        SmokeEarlyLogs.Matches("A_awake", shutUpConflictFixture, shutUpConflictFixture));
                    CheckManual("late_instance", late.TestLogger, 0);
                    BepLogger.Sources.Remove(late.TestLogger);
                    late.TestLogger.Dispose();
                }
                finally { UnityEngine.Object.Destroy(lateObject); }
                yield return CheckUnity("owned_mod_none");
                CheckStartupFlags("timer_groups_none");
            }
        }

        ReplaceConfig("not-a-group", GroupsText(15));
        yield return WaitForGroups(15, 15);
        CheckGroups("invalid_edit_retains_only_invalid_mod", 15, 15);
        CheckStartupFlags("invalid_edit_retains_only_invalid_mod");
        // Observe the restored snapshot explicitly: the prior partial reload
        // changed B and the Manager callback checks require A=15, B=0.
        ReplaceConfig(GroupsText(15), GroupsText(0));
        yield return WaitForGroups(15, 0);
        CheckReportPreserved("all_groups_after_reload");
        yield return CheckUnity("after_all_group_combinations");
        CheckNoUnityLoggingPatches("after_all_group_combinations");
        string finalConfig = File.ReadAllText(configPath);
        Record("timer preserves next-launch settings and saved policy for an unloaded GUID",
            ReadConfigValue(finalConfig, "General", "ProfilingEnabled") == (!startupFeaturesEnabled ? "true" : "false") &&
            ReadConfigValue(finalConfig, "General", "TimeoutProtectionSeconds") == (startupFeaturesEnabled ? "0" : "120") &&
            ReadConfigValue(finalConfig, "Logging.Mods", SmokeEarlyLogs.UnloadedGuid) == "None");

        if (!string.IsNullOrEmpty(managerAssemblyPath)) yield return CheckConfigManager(product);
        yield return CheckConfigAutoReload(product, (SmokePluginA)fixtureA.Instance);
    }

    private void CheckGroups(string stage, int aGroups, int bGroups)
    {
        CheckManual(stage + "_A", pluginA, aGroups);
        CheckManual(stage + "_B", pluginB, bGroups);
        CheckManual(stage + "_unconfigured_GUID", Logger, 3);
        CheckManual(stage + "_custom_same_name_unmapped", source, null);
        CheckManual(stage + "_diagnostic_name_impostor_unmapped", impostor, null);
        CheckManual(stage + "_real_diagnostic_unmapped", diagnostic, null);
    }

    private static Assembly FindProductAssembly()
    {
        Assembly found = null;
        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            if (assembly.GetName().Name != "LoadTimeProfiler") continue;
            if (found != null) throw new InvalidOperationException("Multiple product assemblies loaded.");
            found = assembly;
        }
        if (found == null) throw new InvalidOperationException("The integrated product assembly was not loaded.");
        return found;
    }

    private void CheckInstallation(Assembly product)
    {
        string[] patcherFiles = Directory.GetFiles(Paths.PatcherPluginPath, "*.dll", SearchOption.AllDirectories);
        string expectedProduct = Path.Combine(Paths.PatcherPluginPath, "LoadTimeProfiler.dll");
        Record("one product DLL and only the requested test fixtures in the isolated patcher directory",
            patcherFiles.Length == (shutUpConflictFixture ? 2 : 1) && File.Exists(expectedProduct) &&
            (!shutUpConflictFixture || File.Exists(Path.Combine(Paths.PatcherPluginPath, "ShutUp.dll"))) && SamePath(product.Location, expectedProduct));
        Type filtering = product.GetType("LoadTimeProfiler.LogFiltering", true);
        object conflict = filtering.GetProperty("ConflictName", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null, null);
        Record("logging conflict detector identifies the requested loaded assembly without treating cfg edits as enablement",
            Equals(conflict, shutUpConflictFixture ? "ShutUp" : null));

        int entries = 0;
        foreach (Type type in product.GetTypes())
        {
            if (type.GetProperty("TargetDLLs", BindingFlags.Public | BindingFlags.Static) == null) continue;
            foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.Static))
            {
                ParameterInfo[] parameters = method.GetParameters();
                if (method.Name == "Patch" && method.ReturnType == typeof(void) && parameters.Length == 1 &&
                    parameters[0].ParameterType.FullName == "Mono.Cecil.AssemblyDefinition") entries++;
            }
        }
        Record("one public preloader patcher entry point", entries == 1);
        string text = File.ReadAllText(configPath);
        HashSet<string> sections = new HashSet<string>(StringComparer.Ordinal);
        foreach (string raw in text.Split('\n'))
        {
            string line = raw.Trim();
            if (line.StartsWith("[", StringComparison.Ordinal) && line.EndsWith("]", StringComparison.Ordinal))
                sections.Add(line.Substring(1, line.Length - 2));
        }
        Record("GUID cfg uses exactly General and Logging.Mods with the five current startup keys",
            sections.SetEquals(new[] { "General", "Logging.Mods" }) &&
            ReadConfigValue(text, "General", "ProfilingEnabled") == (startupFeaturesEnabled ? "true" : "false") &&
            ReadConfigValue(text, "General", "LocalizationCacheEnabled") == (startupFeaturesEnabled ? "true" : "false") &&
            ReadConfigValue(text, "General", "ConfigWriteCoalescingEnabled") == (startupFeaturesEnabled ? "true" : "false") &&
            ReadConfigValue(text, "General", "ConfigAutoReloadEnabled") == (configAutoReloadEnabled ? "true" : "false") &&
            ReadConfigValue(text, "General", "TimeoutProtectionSeconds") == (startupFeaturesEnabled ? "120" : "0"));
        results.Add("PRODUCT=" + product.FullName);
        results.Add("CONFIG=" + configPath);
    }

    private IEnumerator CheckConfigManager(Assembly product)
    {
        PluginInfo info;
        if (!Chainloader.PluginInfos.TryGetValue("sighsorry.ConfigManager", out info) || info.Instance == null)
            throw new InvalidOperationException("The requested ConfigManager plugin was not loaded.");
        object manager = info.Instance;
        Type managerType = manager.GetType();
        Record("manager: requested DLL loaded from the isolated plugin directory",
            SamePath(managerType.Assembly.Location, managerAssemblyPath) &&
            SamePath(Path.GetDirectoryName(managerAssemblyPath), Paths.PluginPath));
        results.Add("CONFIG_MANAGER=" + managerType.Assembly.FullName);
        results.Add("CONFIG_MANAGER_SCOPE=actual collection/Get/Set; visible OnGUI and focus/Enter input are not tested");

        Type groupsType = product.GetType("LoadTimeProfiler.LogGroups", true);
        Record("manager: LogGroups exposes None and exactly four independent flags without an All field",
            groupsType.IsEnum && groupsType.IsDefined(typeof(FlagsAttribute), false) &&
            string.Join(",", Enum.GetNames(groupsType)) == "None,Errors,Warnings,Information,Debug" &&
            Convert.ToInt32(Enum.Parse(groupsType, "Errors")) == 1 &&
            Convert.ToInt32(Enum.Parse(groupsType, "Warnings")) == 2 &&
            Convert.ToInt32(Enum.Parse(groupsType, "Information")) == 4 &&
            Convert.ToInt32(Enum.Parse(groupsType, "Debug")) == 8);
        int loadedPlugins = 0;
        foreach (PluginInfo loaded in Chainloader.PluginInfos.Values)
            if (loaded.Instance != null && loaded.Metadata.GUID != "sighsorry.LoadTimeProfiler") loadedPlugins++;
        Dictionary<string, object> settings = ProductSettings(CollectManagerSettings(manager));
        int expectedSettingCount = 5 + loadedPlugins + (shutUpConflictFixture ? 1 : 0);
        Record("manager: actual collection has five startup entries, one row per loaded plugin and only the requested conflict status",
            settings.Count == expectedSettingCount);
        object statusEntry;
        bool hasStatus = settings.TryGetValue("Logging - Mods.Status", out statusEntry);
        Record("manager: conflict status identifies ShutUp and is read-only, or is absent without a conflict",
            shutUpConflictFixture ? hasStatus && (Type)EntryProperty(statusEntry, "SettingType") == typeof(string) &&
                Equals(EntryGet(statusEntry), "Disabled: ShutUp is loaded.") &&
                Equals(EntryProperty(statusEntry, "ReadOnly"), true) &&
                ((string)EntryProperty(statusEntry, "Description")).Contains("Remove the overlapping patcher and restart") : !hasStatus);
        string[] names = { "General.ProfilingEnabled", "General.LocalizationCacheEnabled", "General.ConfigWriteCoalescingEnabled",
            "General.ConfigAutoReloadEnabled", "General.TimeoutProtectionSeconds" };
        Type[] types = { typeof(bool), typeof(bool), typeof(bool), typeof(bool), typeof(float) };
        object[] defaults = { true, true, true, false, 120f };
        bool schema = true;
        for (int i = 0; i < names.Length; i++)
        {
            object entry;
            if (!settings.TryGetValue(names[i], out entry)) { schema = false; continue; }
            schema &= (Type)EntryProperty(entry, "SettingType") == types[i] &&
                EntryProperty(entry, "DefaultValue").GetType() == types[i] &&
                Equals(EntryProperty(entry, "DefaultValue"), defaults[i]) && EntryGet(entry).GetType() == types[i] &&
                ((string)EntryProperty(entry, "Description") ?? "").Contains("Restart required.") &&
                !Equals(EntryProperty(entry, "ReadOnly"), true);
        }
        HashSet<string> categories = new HashSet<string>(StringComparer.Ordinal);
        int generalEntries = 0;
        foreach (object entry in settings.Values)
        {
            string category = (string)EntryProperty(entry, "Category");
            categories.Add(category);
            if (category == "General") generalEntries++;
        }
        Record("manager: exactly General and Logging - Mods categories, with five General entries preserving types/defaults/restart comments",
            schema && generalEntries == 5 && categories.SetEquals(new[] { "General", "Logging - Mods" }));
        if (!schema) yield break;
        object modA = FindModSetting(settings, SmokePluginA.Guid);
        object modB = FindModSetting(settings, SmokePluginB.Guid);
        bool groupSchema = true;
        string[] groupNames = { "Errors", "Warnings", "Information", "Debug" };
        string[] groupDescriptions = { "Fatal + Error", "Warning", "Message + Info", "Debug" };
        for (int i = 0; i < groupNames.Length; i++)
        {
            DescriptionAttribute attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(
                groupsType.GetField(groupNames[i]), typeof(DescriptionAttribute));
            groupSchema &= attribute != null && attribute.Description == groupDescriptions[i];
        }
        foreach (object entry in settings.Values)
        {
            if ((string)EntryProperty(entry, "Category") != "Logging - Mods" || ReferenceEquals(entry, statusEntry)) continue;
            string description = (string)EntryProperty(entry, "Description");
            groupSchema &= (Type)EntryProperty(entry, "SettingType") == groupsType &&
                EntryProperty(entry, "DefaultValue").GetType() == groupsType &&
                Convert.ToInt32(EntryProperty(entry, "DefaultValue")) == 3 &&
                EntryGet(entry).GetType() == groupsType && !string.IsNullOrEmpty(description) &&
                Equals(EntryProperty(entry, "ReadOnly"), true) == shutUpConflictFixture &&
                (!shutUpConflictFixture || (description.Contains("because ShutUp is loaded") &&
                    description.Contains("show saved LTP rules")));
        }
        Record("manager: every mod row has four group labels, Errors/Warnings default and correct conflict editability", groupSchema);
        object timeoutEntry = settings["General.TimeoutProtectionSeconds"];
        // DrawSettingValue gives this flag precedence; SettingsWindow offers
        // Edit only for UsesTextEditor && !UsesInlineNumericEditor. The broader
        // UsesTextEditor capability remains true for compatibility with callers.
        Record("manager: timeout selects the existing inline numeric route",
            (bool)timeoutEntry.GetType().GetProperty("UsesInlineNumericEditor", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(timeoutEntry, null));
        Record("manager: duplicate friendly names are disambiguated by GUID and retain independent values",
            ((string)EntryProperty(modA, "DispName")).Contains("[" + SmokePluginA.Guid + "]") &&
            ((string)EntryProperty(modB, "DispName")).Contains("[" + SmokePluginB.Guid + "]") &&
            Convert.ToInt32(EntryGet(modA)) == 15 && Convert.ToInt32(EntryGet(modB)) == 0);
        Record("manager: unloaded GUID policy is not a fabricated loaded-plugin row",
            FindModSettingOrNull(settings, SmokeEarlyLogs.UnloadedGuid) == null);

        Type externalType = managerType.Assembly.GetType("ConfigurationManager.ExternalSetting", true);
        object externalValue = true;
        object external = Activator.CreateInstance(externalType, new object[] {
            "Smoke", "Retained", "Unrelated registration must survive LTP disposal.", typeof(bool), false,
            new Func<object>(() => externalValue), new Action<object>(value => externalValue = value) });
        Array registrations = Array.CreateInstance(externalType, 1);
        registrations.SetValue(external, 0);
        otherExternalRegistration = (IDisposable)managerType.GetMethod("RegisterExternalSettings", BindingFlags.Public | BindingFlags.Static)
            .Invoke(null, new object[] { "sighsorry.LoadTimeProfiler.UnitySmokeOther", "Smoke other owner", "1.0.0", registrations });
        List<string> otherKeys = OtherSettingKeys(CollectManagerSettings(manager));
        Record("manager: public external registration coexists with Manager's existing settings",
            otherExternalRegistration != null && otherKeys.Contains("sighsorry.LoadTimeProfiler.UnitySmokeOther/Smoke/Retained"));

        const string comment = "# LOADTIMEPROFILER_SMOKE_MANAGER_PRESERVE_COMMENT";
        WriteConfigText(comment + "\n" + File.ReadAllText(configPath));
        yield return new WaitForSecondsRealtime(2f);
        string beforeCheckboxEdits = File.ReadAllText(configPath);
        EntrySet(modA, Enum.ToObject(groupsType, 5));
        EntrySet(modB, Enum.ToObject(groupsType, 10));
        if (shutUpConflictFixture)
        {
            EntrySet(modA, EntryProperty(modA, "DefaultValue"));
            EntrySet(modB, EntryProperty(modB, "DefaultValue"));
            EntrySet(statusEntry, "attempted status edit");
            bool directWrite = (bool)modA.GetType().GetMethod("TrySet", BindingFlags.Instance | BindingFlags.NonPublic)
                .Invoke(modA, new object[] { Enum.ToObject(groupsType, 5) });
            Record("manager: read-only Set, reset and direct TrySet reject edits without changing cfg or saved groups",
                !directWrite && File.ReadAllText(configPath) == beforeCheckboxEdits &&
                Convert.ToInt32(EntryGet(modA)) == 15 && Convert.ToInt32(EntryGet(modB)) == 0 &&
                Equals(EntryGet(statusEntry), "Disabled: ShutUp is loaded."));
        }
        else Record("manager: same-name mod checkbox callbacks address independent GUID group combinations",
            Convert.ToInt32(EntryGet(modA)) == 5 && Convert.ToInt32(EntryGet(modB)) == 10);
        CheckManual("manager_A_errors_information", pluginA, 5);
        CheckManual("manager_B_warnings_debug", pluginB, 10);
        CheckManual("manager_custom_unmapped", source, null);
        CheckManual("manager_impostor_unmapped", impostor, null);
        CheckManual("manager_diagnostic_unmapped", diagnostic, null);
        Record("manager: a loaded plugin without a saved GUID entry defaults to Errors, Warnings",
            Convert.ToInt32(EntryGet(FindModSetting(settings, Info.Metadata.GUID))) == 3 &&
            ReadConfigValue(File.ReadAllText(configPath), "Logging.Mods", Info.Metadata.GUID) == null);
        CheckManual("manager_new_mod_default_errors_warnings", Logger, 3);
        yield return CheckUnity("manager_mod_edits");

        string[] bootNames = { "General.ProfilingEnabled", "General.LocalizationCacheEnabled", "General.ConfigWriteCoalescingEnabled" };
        foreach (string name in bootNames) EntrySet(settings[name], startupFeaturesEnabled);
        foreach (string name in bootNames) EntrySet(settings[name], !startupFeaturesEnabled);
        float nextTimeout = startupFeaturesEnabled ? 240f : 60f;
        EntrySet(settings["General.TimeoutProtectionSeconds"], nextTimeout);
        EntrySet(settings["General.ConfigAutoReloadEnabled"], !configAutoReloadEnabled);
        Record("manager: boot-only edits are readable as next-launch values",
            (bool)EntryGet(settings[bootNames[0]]) == !startupFeaturesEnabled &&
            (bool)EntryGet(settings[bootNames[1]]) == !startupFeaturesEnabled &&
            (bool)EntryGet(settings[bootNames[2]]) == !startupFeaturesEnabled &&
            (bool)EntryGet(settings["General.ConfigAutoReloadEnabled"]) == !configAutoReloadEnabled &&
            (float)EntryGet(settings["General.TimeoutProtectionSeconds"]) == nextTimeout);
        CheckStartupFlags("manager_boot_edits");
        string saved = File.ReadAllText(configPath);
        Record("manager: edits preserve comments, unloaded GUID policy and the other mod's setting",
            saved.Contains(comment) && ReadConfigValue(saved, "Logging.Mods", SmokeEarlyLogs.UnloadedGuid) == "None" &&
            ReadConfigValue(saved, "Logging.Mods", SmokePluginA.Guid) == GroupsText(shutUpConflictFixture ? 15 : 5) &&
            ReadConfigValue(saved, "Logging.Mods", SmokePluginB.Guid) == GroupsText(shutUpConflictFixture ? 0 : 10) &&
            ReadConfigValue(saved, "General", "TimeoutProtectionSeconds") == (startupFeaturesEnabled ? "240" : "60"));

        if (!shutUpConflictFixture)
            yield return CheckTolerantConfigManager(settings, modA, modB, groupsType);

        ReplaceConfig(GroupsText(0), GroupsText(15));
        yield return WaitForGroups(0, 15);
        Record("manager: existing Get callbacks observe external group/boot edits without recollection",
            Convert.ToInt32(EntryGet(modA)) == 0 && Convert.ToInt32(EntryGet(modB)) == 15 &&
            (float)EntryGet(settings["General.TimeoutProtectionSeconds"]) == (startupFeaturesEnabled ? 0f : 120f));
        CollectManagerSettings(manager);
        List<object> all = CollectManagerSettings(manager);
        Record("manager: recollection keeps one row per GUID and retains other owners",
            ProductSettings(all).Count == expectedSettingCount && SameKeys(otherKeys, OtherSettingKeys(all)));

        Type integration = product.GetType("LoadTimeProfiler.ConfigManagerIntegration", true);
        integration.GetMethod("Dispose", BindingFlags.Static | BindingFlags.NonPublic).Invoke(null, null);
        all = CollectManagerSettings(manager);
        object retained = all.Find(entry =>
        {
            BepInPlugin owner = (BepInPlugin)EntryProperty(entry, "PluginInfo");
            return owner != null && owner.GUID == "sighsorry.LoadTimeProfiler.UnitySmokeOther";
        });
        if (retained != null) EntrySet(retained, false);
        Record("manager: disposing LTP registration removes only its rows and preserves another owner's live callbacks",
            ProductSettings(all).Count == 0 && SameKeys(otherKeys, OtherSettingKeys(all)) &&
            retained != null && Equals(EntryGet(retained), false) && Equals(externalValue, false));
        CheckManual("manager_disposed_A", pluginA, 0);
        CheckManual("manager_disposed_B", pluginB, 15);
        CheckReportPreserved("manager_disposed");
    }

    private IEnumerator CheckTolerantConfigManager(Dictionary<string, object> settings, object modA, object modB, Type groupsType)
    {
        object timeout = settings["General.TimeoutProtectionSeconds"];
        object profiling = settings["General.ProfilingEnabled"];
        float acceptedTimeout = (float)EntryGet(timeout);
        bool acceptedProfiling = (bool)EntryGet(profiling);
        const string unknown = "# PRESERVE_UNRELATED_SECTION\n[Unknown.Smoke]\nUnrelated = keep this text\n";
        const string invalidTimeout = "TimeoutProtectionSeconds = not-a-number";
        const string invalidB = "not-a-log-group";
        string mixed = File.ReadAllText(configPath)
            .Replace("TimeoutProtectionSeconds = " + (startupFeaturesEnabled ? "240" : "60"), invalidTimeout)
            .Replace(SmokePluginB.Guid + " = " + GroupsText(10), SmokePluginB.Guid + " = " + invalidB) + "\n" + unknown;
        WriteConfigText(mixed);

        // Do not wait for the timer: saving must re-read valid disk siblings
        // while retaining only each invalid entry's last accepted value.
        EntrySet(modA, Enum.ToObject(groupsType, 9));
        string saved = File.ReadAllText(configPath);
        Record("manager: unrelated unknown sections and invalid entries do not block a valid mod checkbox save",
            Convert.ToInt32(EntryGet(modA)) == 9 && Convert.ToInt32(EntryGet(modB)) == 10 &&
            (float)EntryGet(timeout) == acceptedTimeout && saved.Contains(unknown) &&
            saved.Contains(invalidTimeout) && saved.Contains(SmokePluginB.Guid + " = " + invalidB) &&
            ReadConfigValue(saved, "Logging.Mods", SmokePluginA.Guid) == GroupsText(9) && EntryHasNoError(modA));
        CheckManual("manager_tolerant_valid_mod_A", pluginA, 9);
        CheckManual("manager_tolerant_invalid_mod_B_retained", pluginB, 10);

        EntrySet(timeout, 90f);
        saved = File.ReadAllText(configPath);
        Record("manager: an invalid selected General value can be repaired without rewriting unrelated invalid text",
            (float)EntryGet(timeout) == 90f && ReadConfigValue(saved, "General", "TimeoutProtectionSeconds") == "90" &&
            saved.Contains(unknown) && saved.Contains(SmokePluginB.Guid + " = " + invalidB) && EntryHasNoError(timeout));

        const string obsolete = "# PRESERVE_OLD_SHAPED_DOCUMENT\n[Profiling]\nEnabled = false\n" +
            "[Startup]\nLocalizationCacheEnabled = false\nConfigWriteCoalescingEnabled = false\n" +
            "[Connection]\nTimeoutProtectionSeconds = 999\n";
        string malformed = "[broken header\n" + SmokePluginA.Guid + " = Debug\n" + Info.Metadata.GUID + " = Debug\n";
        string oldShaped = obsolete + "[Logging.Mods]\n" + SmokePluginA.Guid + " = Warnings\n" +
            SmokePluginB.Guid + " = Errors\n# PRESERVE_INVALID_OTHER_GUID\nsighsorry.Smoke.Invalid = bad-group\n" +
            malformed + unknown;
        WriteConfigText(oldShaped);

        // This is a current GUID edit in an unrecognized surrounding document;
        // it must not migrate the old section/key names or recreate the file.
        EntrySet(modA, Enum.ToObject(groupsType, 5));
        saved = File.ReadAllText(configPath);
        Record("manager: old-shaped cfg without General still accepts logging edits and merges valid disk siblings immediately",
            Convert.ToInt32(EntryGet(modA)) == 5 && Convert.ToInt32(EntryGet(modB)) == 1 &&
            Convert.ToInt32(EntryGet(FindModSetting(settings, Info.Metadata.GUID))) == 3 &&
            (float)EntryGet(timeout) == 90f && (bool)EntryGet(profiling) == acceptedProfiling &&
            saved.StartsWith(obsolete, StringComparison.Ordinal) && saved.Contains(malformed) && saved.Contains(unknown) &&
            saved.Contains("# PRESERVE_INVALID_OTHER_GUID\nsighsorry.Smoke.Invalid = bad-group\n") &&
            !saved.Contains("[General]") && EntryHasNoError(modA));

        EntrySet(timeout, 135f);
        saved = File.ReadAllText(configPath);
        Record("manager: editing a missing General key appends its current name without converting or deleting old sections",
            (float)EntryGet(timeout) == 135f && ReadConfigValue(saved, "General", "TimeoutProtectionSeconds") == "135" &&
            ReadConfigValue(saved, "General", "ProfilingEnabled") == null &&
            saved.StartsWith(obsolete, StringComparison.Ordinal) && saved.Contains(malformed) && saved.Contains(unknown) &&
            Convert.ToInt32(EntryGet(modA)) == 5 && Convert.ToInt32(EntryGet(modB)) == 1 && EntryHasNoError(timeout));

        // Give the independent timer a new sibling value so waiting cannot
        // accidentally succeed against the snapshot just published by the UI.
        WriteConfigText(saved.Replace(SmokePluginB.Guid + " = Errors\n", ""));
        yield return WaitForGroups(5, 3);
        Record("manager: malformed header cannot leak GUID assignments, missing override resets only that mod, and missing General values stay accepted",
            Convert.ToInt32(EntryGet(modA)) == 5 && Convert.ToInt32(EntryGet(modB)) == 3 &&
            Convert.ToInt32(EntryGet(FindModSetting(settings, Info.Metadata.GUID))) == 3 &&
            (float)EntryGet(timeout) == 135f && (bool)EntryGet(profiling) == acceptedProfiling);
        CheckStartupFlags("manager_tolerant_cfg_edits");
    }

    private static bool EntryHasNoError(object entry)
    {
        return entry.GetType().GetProperty("ErrorText", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(entry, null) == null;
    }

    private IEnumerator CheckConfigAutoReload(Assembly product, SmokePluginA fixture)
    {
        results.Add("AUTO_RELOAD_SCOPE=actual BepInEx ConfigFile objects and filesystem saves; no server-client synchronization or mod-specific reconfiguration is simulated");
        int mainThread = Thread.CurrentThread.ManagedThreadId;
        ConfigObservation plugin = new ConfigObservation(fixture.TestConfig, fixture.ConstructorValue, fixture.AwakeValue, mainThread);
        ConfigObservation custom = null;
        ConfigObservation shared = null;
        try
        {
            Record("auto reload: plugin default Config entries were bound during constructor and Awake",
                plugin.First.Value == 1 && plugin.Second.Value == 2 &&
                SamePath(plugin.File.ConfigFilePath, Path.Combine(Paths.ConfigPath, SmokePluginA.Guid + ".cfg")));
            string initialEdit = ProbeConfigText("11", "12");
            File.WriteAllText(plugin.File.ConfigFilePath, initialEdit, new UTF8Encoding(false));
            if (!configAutoReloadEnabled)
            {
                yield return new WaitForSecondsRealtime(2f);
                Record("auto reload disabled: changing another mod's cfg causes no value/event changes even after next-launch setting was enabled",
                    plugin.First.Value == 1 && plugin.Second.Value == 2 && plugin.Reloads == 0 && plugin.Changes == 0 &&
                    File.ReadAllText(plugin.File.ConfigFilePath) == initialEdit);
                CheckStartupFlags("auto_reload_disabled_external_save");
                yield break;
            }

            yield return WaitForCondition(() => plugin.First.Value == 11 && plugin.Second.Value == 12,
                "default plugin config constructor/Awake entries");
            Record("auto reload: external save updates the actual default plugin Config without an admin or ConfigManager setter",
                plugin.Reloads == 1 && plugin.Changes == 2);
            Record("auto reload: default Config callbacks run on the Unity main thread with SaveOnConfigSet restored and external text untouched",
                plugin.MainThreadOnly && plugin.AutoSaveSuppressed && plugin.File.SaveOnConfigSet &&
                File.ReadAllText(plugin.File.ConfigFilePath) == initialEdit);

            string directory = Path.Combine(Paths.ConfigPath, "SmokeAutoReload");
            Directory.CreateDirectory(directory);
            string path = Path.Combine(directory, "custom.cfg");
            ConfigFile firstFile = new ConfigFile(path, true);
            ConfigEntry<int> firstValue = firstFile.Bind("Probe", "CtorValue", 1, "Late ConfigFile value.");
            ConfigEntry<int> secondValue = firstFile.Bind("Probe", "AwakeValue", 2, "Late ConfigFile second value.");
            custom = new ConfigObservation(firstFile, firstValue, secondValue, mainThread);
            ConfigFile secondFile = new ConfigFile(path, false);
            ConfigEntry<int> sharedFirst = secondFile.Bind("Probe", "CtorValue", 1);
            ConfigEntry<int> sharedSecond = secondFile.Bind("Probe", "AwakeValue", 2);
            secondFile.SaveOnConfigSet = false;
            shared = new ConfigObservation(secondFile, sharedFirst, sharedSecond, mainThread);
            yield return new WaitForSecondsRealtime(1.5f);
            custom.Reset();
            shared.Reset();

            string replaced = ProbeConfigText("21", "22");
            ReplaceFileText(path, replaced);
            yield return WaitForCondition(() => custom.First.Value == 21 && custom.Second.Value == 22 &&
                shared.First.Value == 21 && shared.Second.Value == 22, "late objects sharing one replaced cfg");
            Record("auto reload: late-created ConfigFile objects sharing the same path both receive one replacement reload",
                custom.Reloads == 1 && shared.Reloads == 1 && custom.Changes == 2 && shared.Changes == 2);
            Record("auto reload: original true and false SaveOnConfigSet values are both restored after main-thread callbacks",
                custom.File.SaveOnConfigSet && !shared.File.SaveOnConfigSet && custom.MainThreadOnly && shared.MainThreadOnly &&
                custom.AutoSaveSuppressed && shared.AutoSaveSuppressed && File.ReadAllText(path) == replaced);

            custom.Reset();
            shared.Reset();
            string burst = null;
            for (int i = 30; i <= 39; i++)
            {
                burst = ProbeConfigText(i.ToString(), (i + 1).ToString());
                File.WriteAllText(path, burst, new UTF8Encoding(false));
            }
            yield return WaitForCondition(() => custom.First.Value == 39 && shared.Second.Value == 40, "coalesced burst saves");
            yield return new WaitForSecondsRealtime(1f);
            Record("auto reload: a burst of ten writes reloads only the settled contents once per actual ConfigFile",
                custom.Reloads == 1 && shared.Reloads == 1 && custom.Changes == 2 && shared.Changes == 2 &&
                File.ReadAllText(path) == burst);
            File.WriteAllText(path, burst, new UTF8Encoding(false));
            yield return new WaitForSecondsRealtime(1.5f);
            Record("auto reload: rewriting identical content does not invoke ConfigReloaded again",
                custom.Reloads == 1 && shared.Reloads == 1);

            string invalid = ProbeConfigText("invalid-number", "51");
            ReplaceFileText(path, invalid);
            yield return WaitForCondition(() => custom.Second.Value == 51 && shared.Second.Value == 51,
                "BepInEx per-entry invalid numeric handling");
            Record("auto reload: BepInEx retains an invalid entry while applying another valid entry without claiming an atomic transaction",
                custom.First.Value == 39 && shared.First.Value == 39 &&
                File.ReadAllText(path) == invalid && custom.File.SaveOnConfigSet && !shared.File.SaveOnConfigSet);

            int beforeDelete = custom.Reloads;
            File.Delete(path);
            yield return new WaitForSecondsRealtime(1.5f);
            Record("auto reload: missing file is not recreated and last in-memory values remain available",
                !File.Exists(path) && custom.First.Value == 39 && custom.Second.Value == 51 && custom.Reloads == beforeDelete);
            string recreated = ProbeConfigText("61", "62");
            File.WriteAllText(path, recreated, new UTF8Encoding(false));
            yield return WaitForCondition(() => custom.First.Value == 61 && shared.Second.Value == 62,
                "file recreated after deletion");
            Record("auto reload: recreating a watched cfg resumes updates for every registered object",
                custom.First.Value == 61 && custom.Second.Value == 62 && shared.First.Value == 61 && shared.Second.Value == 62 &&
                custom.MainThreadOnly && shared.MainThreadOnly && File.ReadAllText(path) == recreated);
            CheckStartupFlags("auto_reload_enabled_external_saves");

            custom.Reset();
            shared.Reset();
            ReplaceFileText(path, ProbeConfigText("71", "72"));
            // Let the background watcher settle and queue its main-thread work
            // while this owned probe deliberately keeps Unity from consuming it.
            Thread.Sleep(1300);
            Type service = product.GetType("LoadTimeProfiler.ConfigAutoReload", true);
            service.GetMethod("Dispose", BindingFlags.Static | BindingFlags.NonPublic).Invoke(null, null);
            yield return new WaitForSecondsRealtime(1.5f);
            Record("auto reload: disposal cancels pending work and leaves previously applied values intact",
                custom.First.Value == 61 && shared.Second.Value == 62 && custom.Reloads == 0 && shared.Reloads == 0 &&
                custom.File.SaveOnConfigSet && !shared.File.SaveOnConfigSet);
            File.WriteAllText(path, ProbeConfigText("81", "82"), new UTF8Encoding(false));
            yield return new WaitForSecondsRealtime(1.5f);
            Record("auto reload: later saves remain inactive after service disposal",
                custom.First.Value == 61 && shared.Second.Value == 62 && custom.Reloads == 0 && shared.Reloads == 0);

            ReplaceConfig(GroupsText(6), GroupsText(9));
            yield return WaitForGroups(6, 9);
            Record("auto reload: disposing generic cfg watching leaves independent LTP Logging.Mods timer active", true);
            CheckManual("generic_watcher_disposed_A", pluginA, 6);
            CheckManual("generic_watcher_disposed_B", pluginB, 9);
        }
        finally
        {
            plugin.Dispose();
            if (custom != null) custom.Dispose();
            if (shared != null) shared.Dispose();
        }
    }

    private static string ProbeConfigText(string first, string second)
    {
        return "# External operator formatting must survive reload.\n[Probe]\nCtorValue = " + first + "\nAwakeValue = " + second + "\n";
    }

    private static void ReplaceFileText(string path, string text)
    {
        string staging = path + ".smoke-next";
        File.WriteAllText(staging, text, new UTF8Encoding(false));
        File.Replace(staging, path, null);
    }

    private static IEnumerator WaitForCondition(Func<bool> condition, string description)
    {
        float deadline = Time.realtimeSinceStartup + 7f;
        while (!condition())
        {
            if (Time.realtimeSinceStartup >= deadline) throw new TimeoutException("Native auto reload timed out: " + description);
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }

    private sealed class ConfigObservation : IDisposable
    {
        internal readonly ConfigFile File;
        internal readonly ConfigEntry<int> First;
        internal readonly ConfigEntry<int> Second;
        internal int Reloads;
        internal int Changes;
        internal bool MainThreadOnly = true;
        internal bool AutoSaveSuppressed = true;
        private readonly int mainThread;

        internal ConfigObservation(ConfigFile file, ConfigEntry<int> first, ConfigEntry<int> second, int thread)
        {
            File = file;
            First = first;
            Second = second;
            mainThread = thread;
            File.ConfigReloaded += OnReloaded;
            File.SettingChanged += OnChanged;
        }

        private void OnReloaded(object sender, EventArgs args)
        {
            Reloads++;
            MainThreadOnly &= Thread.CurrentThread.ManagedThreadId == mainThread;
            AutoSaveSuppressed &= !File.SaveOnConfigSet;
        }

        private void OnChanged(object sender, SettingChangedEventArgs args)
        {
            Changes++;
            MainThreadOnly &= Thread.CurrentThread.ManagedThreadId == mainThread;
            AutoSaveSuppressed &= !File.SaveOnConfigSet;
        }

        internal void Reset() { Reloads = 0; Changes = 0; MainThreadOnly = true; AutoSaveSuppressed = true; }
        public void Dispose() { File.ConfigReloaded -= OnReloaded; File.SettingChanged -= OnChanged; }
    }

    private static object FindModSetting(Dictionary<string, object> settings, string guid)
    {
        object found = FindModSettingOrNull(settings, guid);
        if (found == null) throw new InvalidOperationException("Missing Manager row for GUID " + guid);
        return found;
    }

    private static object FindModSettingOrNull(Dictionary<string, object> settings, string guid)
    {
        object found = null;
        foreach (object entry in settings.Values)
        {
            if ((string)EntryProperty(entry, "Category") != "Logging - Mods" ||
                !((string)EntryProperty(entry, "Description")).Contains("Mod GUID: " + guid + ".")) continue;
            if (found != null) throw new InvalidOperationException("Duplicate Manager rows for GUID " + guid);
            found = entry;
        }
        return found;
    }

    private static List<object> CollectManagerSettings(object manager)
    {
        Type type = manager.GetType();
        type.GetMethod("BuildSettingList", BindingFlags.Public | BindingFlags.Instance).Invoke(manager, null);
        IEnumerable all = (IEnumerable)type.GetField("_allSettings", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(manager);
        List<object> entries = new List<object>();
        foreach (object entry in all) entries.Add(entry);
        return entries;
    }

    private static Dictionary<string, object> ProductSettings(List<object> entries)
    {
        Dictionary<string, object> settings = new Dictionary<string, object>(StringComparer.Ordinal);
        foreach (object entry in entries)
        {
            BepInPlugin plugin = (BepInPlugin)EntryProperty(entry, "PluginInfo");
            if (plugin == null || plugin.GUID != "sighsorry.LoadTimeProfiler") continue;
            settings.Add((string)EntryProperty(entry, "Category") + "." + (string)EntryProperty(entry, "DispName"), entry);
        }
        return settings;
    }

    private static List<string> OtherSettingKeys(List<object> entries)
    {
        List<string> keys = new List<string>();
        foreach (object entry in entries)
        {
            BepInPlugin plugin = (BepInPlugin)EntryProperty(entry, "PluginInfo");
            if (plugin == null || plugin.GUID == "sighsorry.LoadTimeProfiler") continue;
            keys.Add(plugin.GUID + "/" + EntryProperty(entry, "Category") + "/" + EntryProperty(entry, "DispName"));
        }
        keys.Sort(StringComparer.Ordinal);
        return keys;
    }

    private static bool SameKeys(List<string> left, List<string> right)
    {
        if (left.Count != right.Count) return false;
        for (int i = 0; i < left.Count; i++) if (left[i] != right[i]) return false;
        return true;
    }

    private static object EntryProperty(object entry, string name)
    {
        return entry.GetType().GetProperty(name, BindingFlags.Public | BindingFlags.Instance).GetValue(entry, null);
    }

    private static object EntryGet(object entry)
    {
        return entry.GetType().GetMethod("Get", BindingFlags.Public | BindingFlags.Instance).Invoke(entry, null);
    }

    private static void EntrySet(object entry, object value)
    {
        entry.GetType().GetMethod("Set", BindingFlags.Public | BindingFlags.Instance).Invoke(entry, new object[] { value });
    }

    private static string ReadConfigValue(string text, string category, string name)
    {
        string section = "";
        foreach (string raw in text.Split('\n'))
        {
            string line = raw.Trim();
            if (line.StartsWith("[", StringComparison.Ordinal) && line.EndsWith("]", StringComparison.Ordinal))
                section = line.Substring(1, line.Length - 2);
            int equals = line.IndexOf('=');
            if (section == category && equals > 0 && line.Substring(0, equals).Trim() == name)
                return line.Substring(equals + 1).Trim();
        }
        return null;
    }

    private void CheckStartupFlags(string stage)
    {
        bool passed = (bool)ReadPatcherProperty("ProfilingEnabled") == startupFeaturesEnabled &&
            (bool)ReadPatcherProperty("LocalizationCacheEnabled") == startupFeaturesEnabled &&
            (bool)ReadPatcherProperty("ConfigWriteCoalescingEnabled") == startupFeaturesEnabled &&
            (bool)ReadPatcherProperty("ConfigAutoReloadEnabled") == configAutoReloadEnabled &&
            (float)ReadPatcherProperty("ConnectionTimeoutSeconds") == (startupFeaturesEnabled ? 120f : 0f);
        Record(stage + ": profiling, startup acceleration, auto reload and timeout remain at boot values", passed);
    }

    private object ReadPatcherProperty(string name)
    {
        PropertyInfo property = patcherType.GetProperty(name, BindingFlags.Static | BindingFlags.NonPublic);
        if (property == null) throw new MissingMemberException(patcherType.FullName, name);
        return property.GetValue(null, null);
    }

    private static string[] ReportFiles()
    {
        string directory = Path.Combine(Paths.ConfigPath, "LoadTimeProfiler");
        return Directory.Exists(directory) ? Directory.GetFiles(directory, "*.log") : new string[0];
    }

    private void CaptureCompletedReport()
    {
        foreach (string file in ReportFiles())
        {
            string text = ReadSharedText(file);
            if (!text.Contains("=== Start To Lobby ===") || !text.Contains("Result: completed")) continue;
            reportPath = file;
            startupReport = text;
            results.Add("REPORT=" + reportPath);
            return;
        }
    }

    private void CheckReportPreserved(string stage)
    {
        bool passed = startupFeaturesEnabled
            ? startupReport != null && File.Exists(reportPath) &&
                ReadSharedText(reportPath).StartsWith(startupReport, StringComparison.Ordinal)
            : ReportFiles().Length == 0;
        Record(stage + ": logging reload preserves the report and boot profiling policy", passed);
    }

    private static string ReadSharedText(string path)
    {
        // ProfilerLog intentionally keeps its autoflushing writer open for the
        // whole process. A reader must allow that existing writer to keep writing.
        using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            return reader.ReadToEnd();
    }

    private void CheckManual(string stage, ManualLogSource logger, int? groups)
    {
        if (shutUpConflictFixture) groups = null;
        LogLevel[] levels = { LogLevel.Fatal, LogLevel.Error, LogLevel.Warning, LogLevel.Message,
            LogLevel.Info, LogLevel.Debug, LogLevel.None, (LogLevel)128,
            LogLevel.Fatal | LogLevel.Info, LogLevel.Warning | LogLevel.Debug, LogLevel.Info | (LogLevel)128 };
        bool passed = true;
        logger.LogEvent += OnManualLog;
        try
        {
            foreach (LogLevel level in levels)
            {
                int before = Volatile.Read(ref manualEvents);
                Payload payload = new Payload("LOADTIMEPROFILER_SMOKE_MANUAL_" + stage + "_" + level);
                logger.Log(level, payload);
                bool allowed = GroupsAllow(groups, level);
                passed &= Volatile.Read(ref manualEvents) - before == (allowed ? 1 : 0) &&
                    (allowed ? payload.Calls > 0 : payload.Calls == 0);
            }
        }
        finally { logger.LogEvent -= OnManualLog; }
        Record(stage + ": Manual levels including None/unknown/mixed and formatting obey " +
            (groups.HasValue ? GroupsText(groups.Value) : shutUpConflictFixture ? "conflict pass-through" : "unmapped pass-through"), passed);
    }

    private IEnumerator CheckUnity(string stage)
    {
        LogType[] kinds = { LogType.Log, LogType.Warning, LogType.Error };
        foreach (LogType kind in kinds)
        {
            Payload payload = new Payload("LOADTIMEPROFILER_SMOKE_UNITY_" + stage + "_" + kind);
            Debug.unityLogger.Log(kind, payload);
            yield return new WaitForSecondsRealtime(0.1f);
            Record(stage + ": managed Unity " + kind + " always formats and remains visible",
                payload.Calls > 0 && UnityCount(payload.Text) > 0);

            // Native handler output and the BepInEx UnityLogSource callback
            // must remain untouched by all mod-owned ManualLogSource policies.
            string native = "LOADTIMEPROFILER_SMOKE_UNITY_BRIDGE_" + stage + "_" + kind;
            Debug.unityLogger.logHandler.LogFormat(kind, null, "{0}", native);
            yield return new WaitForSecondsRealtime(0.1f);
            Record(stage + ": native-only Unity " + kind + " remains visible with exact forwarding count",
                UnityCount(native) > 0 && ForwardedCount(native) == 1);
        }
    }

    private void CheckNoUnityLoggingPatches(string stage)
    {
        bool clean = true;
        foreach (MethodBase method in Harmony.GetAllPatchedMethods())
        {
            Type declaring = method.DeclaringType;
            if (declaring == null) continue;
            bool forbidden = declaring.Assembly.GetName().Name.StartsWith("UnityEngine", StringComparison.Ordinal) ||
                declaring == typeof(UnityLogSource) ||
                (declaring == typeof(BepLogger) && method.Name == "InitializeInternalLoggers");
            if (!forbidden) continue;
            Patches patches = Harmony.GetPatchInfo(method);
            if (patches == null) continue;
            foreach (string owner in patches.Owners)
                if (owner.StartsWith("sighsorry.LoadTimeProfiler", StringComparison.Ordinal))
                {
                    clean = false;
                    results.Add("UNEXPECTED_PATCH=" + declaring.FullName + "." + method.Name + "; " + owner);
                }
        }
        Record(stage + ": no LTP patches target UnityEngine, UnityLogSource or internal logger initialization", clean);
    }

    private static bool GroupsAllow(int? groups, LogLevel level)
    {
        // All selected permits every event level, including
        // None and unknown future levels. Unowned loggers always pass through.
        if (!groups.HasValue || groups.Value == 15) return true;
        LogLevel selected = LogLevel.None;
        if ((groups.Value & 1) != 0) selected |= LogLevel.Fatal | LogLevel.Error;
        if ((groups.Value & 2) != 0) selected |= LogLevel.Warning;
        if ((groups.Value & 4) != 0) selected |= LogLevel.Message | LogLevel.Info;
        if ((groups.Value & 8) != 0) selected |= LogLevel.Debug;
        return (selected & level) != 0;
    }

    private static string GroupsText(int groups)
    {
        if (groups == 0) return "None";
        List<string> names = new List<string>();
        if ((groups & 1) != 0) names.Add("Errors");
        if ((groups & 2) != 0) names.Add("Warnings");
        if ((groups & 4) != 0) names.Add("Information");
        if ((groups & 8) != 0) names.Add("Debug");
        return string.Join(", ", names.ToArray());
    }

    private void ReplaceConfig(string aGroups, string bGroups)
    {
        string nextStartup = startupFeaturesEnabled ? "false" : "true";
        WriteConfigText(
            "[General]\nProfilingEnabled = " + nextStartup +
            "\nLocalizationCacheEnabled = " + nextStartup +
            "\nConfigWriteCoalescingEnabled = " + nextStartup +
            "\nConfigAutoReloadEnabled = " + (configAutoReloadEnabled ? "false" : "true") +
            "\nTimeoutProtectionSeconds = " + (startupFeaturesEnabled ? "0" : "120") +
            "\n\n[Logging.Mods]\n" + SmokePluginA.Guid + " = " + aGroups +
            "\n" + SmokePluginB.Guid + " = " + bGroups + "\n" + SmokeEarlyLogs.UnloadedGuid + " = None\n");
        // No manual reload API: the production timer must apply this file.
    }

    private IEnumerator WaitForGroups(int aGroups, int bGroups)
    {
        object configuration = ReadPatcherProperty("Configuration");
        MethodInfo get = configuration.GetType().GetMethod("GetModLogGroups", BindingFlags.Instance | BindingFlags.NonPublic);
        float deadline = Time.realtimeSinceStartup + 5f;
        while (Convert.ToInt32(get.Invoke(configuration, new object[] { SmokePluginA.Guid })) != aGroups ||
            Convert.ToInt32(get.Invoke(configuration, new object[] { SmokePluginB.Guid })) != bGroups)
        {
            if (Time.realtimeSinceStartup >= deadline)
                throw new TimeoutException("Production config timer did not publish expected groups " + aGroups + "/" + bGroups + ".");
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }

    private void WriteConfigText(string text)
    {
        string staging = configPath + ".smoke-next";
        File.WriteAllText(staging, text, new UTF8Encoding(false));
        File.Replace(staging, configPath, null);
    }

    private void OnManualLog(object sender, LogEventArgs args)
    {
        Interlocked.Increment(ref manualEvents);
        args.Data.ToString();
    }

    private void OnUnityLog(string message, string stackTrace, LogType type)
    {
        if (!message.StartsWith("LOADTIMEPROFILER_SMOKE_UNITY_", StringComparison.Ordinal)) return;
        lock (eventLock)
        {
            int count;
            unityEvents.TryGetValue(message, out count);
            unityEvents[message] = count + 1;
        }
    }

    private int UnityCount(string message)
    {
        lock (eventLock)
        {
            int count;
            return unityEvents.TryGetValue(message, out count) ? count : 0;
        }
    }

    private void OnForwardedUnity(object sender, LogEventArgs args)
    {
        string message = args.Data as string;
        if (message == null || !message.StartsWith("LOADTIMEPROFILER_SMOKE_UNITY_BRIDGE_", StringComparison.Ordinal)) return;
        lock (eventLock)
        {
            int count;
            forwardedEvents.TryGetValue(message, out count);
            forwardedEvents[message] = count + 1;
        }
    }

    private int ForwardedCount(string message)
    {
        lock (eventLock)
        {
            int count;
            return forwardedEvents.TryGetValue(message, out count) ? count : 0;
        }
    }

    private void Record(string name, bool passed)
    {
        if (!passed) failures++;
        results.Add((passed ? "PASS " : "FAIL ") + name);
        File.WriteAllLines(resultPath, results, new UTF8Encoding(false));
    }

    private static bool SamePath(string left, string right)
    {
        return string.Equals(Path.GetFullPath(left).TrimEnd(Path.DirectorySeparatorChar),
            Path.GetFullPath(right).TrimEnd(Path.DirectorySeparatorChar), StringComparison.OrdinalIgnoreCase);
    }

    private void OnDestroy()
    {
        if (otherExternalRegistration != null) otherExternalRegistration.Dispose();
        Application.logMessageReceivedThreaded -= OnUnityLog;
        if (bridgeSource != null)
        {
            bridgeSource.LogEvent -= OnForwardedUnity;
            bridgeSource.Dispose();
        }
        if (impostor != null)
        {
            BepLogger.Sources.Remove(impostor);
            impostor.Dispose();
        }
        if (source != null)
        {
            source.LogEvent -= OnManualLog;
            BepLogger.Sources.Remove(source);
            source.Dispose();
        }
    }

    private sealed class Payload
    {
        internal readonly string Text;
        private int calls;
        internal int Calls { get { return Volatile.Read(ref calls); } }
        internal Payload(string text) { Text = text; }
        public override string ToString() { Interlocked.Increment(ref calls); return Text; }
    }
}

// Real Chainloader fixtures: same display name, different GUID and logger
// objects. The base constructor postfix must run before these ctor bodies.
[BepInPlugin(Guid, FriendlyName, "1.0.0")]
public sealed class SmokePluginA : BaseUnityPlugin
{
    public const string Guid = "sighsorry.LoadTimeProfiler.SmokeA";
    public const string FriendlyName = "LoadTimeProfiler smoke twin";
    public ManualLogSource TestLogger { get { return Logger; } }
    public ConfigFile TestConfig { get { return Config; } }
    public ConfigEntry<int> ConstructorValue { get; private set; }
    public ConfigEntry<int> AwakeValue { get; private set; }
    public SmokePluginA()
    {
        SmokeEarlyLogs.Emit(Logger, "A_ctor");
        ConstructorValue = Config.Bind("Probe", "CtorValue", 1, "Bound in derived plugin constructor.");
    }
    private void Awake()
    {
        SmokeEarlyLogs.Emit(Logger, "A_awake");
        AwakeValue = Config.Bind("Probe", "AwakeValue", 2, "Bound in plugin Awake.");
    }
}

[BepInPlugin(Guid, SmokePluginA.FriendlyName, "1.0.0")]
public sealed class SmokePluginB : BaseUnityPlugin
{
    public const string Guid = "sighsorry.LoadTimeProfiler.SmokeB";
    public ManualLogSource TestLogger { get { return Logger; } }
    public SmokePluginB() { SmokeEarlyLogs.Emit(Logger, "B_ctor"); }
    private void Awake() { SmokeEarlyLogs.Emit(Logger, "B_awake"); }
}

internal static class SmokeDedicatedGuard
{
    internal static Exception Failure;
    internal static bool Installed;

    internal static void Install()
    {
        if (Environment.GetEnvironmentVariable("LOADTIMEPROFILER_SMOKE_DEDICATED") != "enabled") return;
        try
        {
            Harmony guard = new Harmony("ltp-smoke-dedicated-isolation");
            HarmonyMethod skip = new HarmonyMethod(typeof(SmokeDedicatedGuard), "SkipWorldAndNetworkStartup");
            foreach (string name in new[] { "FejdStartup", "ZNet" })
            {
                MethodInfo awake = AccessTools.Method(AccessTools.TypeByName(name), "Awake");
                if (awake == null) throw new MissingMethodException(name, "Awake");
                guard.Patch(awake, prefix: skip);
            }
            Installed = true;
        }
        catch (Exception ex) { Failure = ex; }
    }

    private static bool SkipWorldAndNetworkStartup(Behaviour __instance)
    {
        __instance.enabled = false;
        return false;
    }
}

internal static class SmokeEarlyLogs
{
    internal const string UnloadedGuid = "sighsorry.LoadTimeProfiler.SavedUnloaded";
    private static readonly Dictionary<string, EarlyPayload[]> Events = new Dictionary<string, EarlyPayload[]>(StringComparer.Ordinal);
    private static readonly object Sync = new object();

    internal static void Emit(ManualLogSource logger, string stage)
    {
        EarlyPayload info = new EarlyPayload("LOADTIMEPROFILER_SMOKE_EARLY_" + stage + "_info");
        EarlyPayload warning = new EarlyPayload("LOADTIMEPROFILER_SMOKE_EARLY_" + stage + "_warning");
        lock (Sync) Events[stage] = new[] { info, warning };
        logger.LogInfo(info);
        logger.LogWarning(warning);
    }

    internal static bool Matches(string stage, bool infoAllowed, bool warningAllowed)
    {
        lock (Sync)
        {
            EarlyPayload[] events;
            return Events.TryGetValue(stage, out events) &&
                (infoAllowed ? events[0].Calls > 0 : events[0].Calls == 0) &&
                (warningAllowed ? events[1].Calls > 0 : events[1].Calls == 0);
        }
    }

    private sealed class EarlyPayload
    {
        private readonly string text;
        private int calls;
        internal int Calls { get { return Volatile.Read(ref calls); } }
        internal EarlyPayload(string value) { text = value; }
        public override string ToString() { Interlocked.Increment(ref calls); return text; }
    }
}
