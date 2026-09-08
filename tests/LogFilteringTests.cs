using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using LogLevel = BepInEx.Logging.LogLevel;

// Uses the real compiled product and BepInEx/Harmony in a separate process.
// No Unity engine objects, native calls, or ShutUp initializers are executed.
internal static class LogFilteringTests
{
    private const BindingFlags Any = BindingFlags.Public | BindingFlags.NonPublic |
                                     BindingFlags.Static | BindingFlags.Instance;
    private static Assembly product;
    private static string scratch;
    private static string livePath;
    private static object ownedLiveConfig;
    private static int failures;
    private static int cases;
    private static object stackLevels;
    private static int foreignCalls;

    private static int Main(string[] args)
    {
        if (args.Length != 5 && (args.Length != 6 || args[5] != "--skip-benchmark"))
        {
            Console.Error.WriteLine("Expected product DLL, BepInEx core directory, Unity managed directory, scratch directory, and iteration count.");
            return 2;
        }
        AppDomain.CurrentDomain.AssemblyResolve += (_, request) =>
        {
            foreach (string directory in new[] { args[1], args[2] })
            {
                string path = Path.Combine(directory, new AssemblyName(request.Name).Name + ".dll");
                if (File.Exists(path)) return Assembly.LoadFrom(path);
            }
            return null;
        };
        product = Assembly.LoadFrom(args[0]);
        scratch = args[3];
        Run("fresh configuration defaults known mods to errors and warnings", DefaultConfiguration);
        Run("partial General settings use initial defaults and retain current values", GeneralSchema);
        Run("the DLL exposes one BepInEx patcher contract", SinglePatcherContract);
        Run("invalid initial entries use defaults while valid siblings apply", MalformedStartup);
        Run("unknown sections and keys are ignored without rewriting", UnknownSections);
        Run("mod policies use exact GUID identity", ExactSourcePolicies);
        Run("mod policy report descriptions are deterministic", PolicyDescriptions);
        Run("all 16 group combinations preserve mapped severities", GroupCombinations);
        Run("explicit reload applies edits without rewriting them", ReloadWithoutRewrite);
        Run("startup settings remain fixed while logging reloads", StartupSettingsStayFixed);
        Run("config auto reload toggles require restart independently of logging", AutoReloadStartupToggle);
        Run("UI fixed settings save typed values without changing startup settings", UiTypedSettings);
        Run("UI saves preserve comments and unrelated external edits", UiPreservesDocument);
        Run("UI saves preserve old and invalid rows while adding current settings", UiTolerantDocument);
        Run("duplicate entries read the last valid value and UI edits the last occurrence", DuplicateEntries);
        Run("malformed section headers end the previous section for reading and editing", MalformedSectionBoundaries);
        Run("unchanged entry diagnostics are not repeated by reload or UI edits", DiagnosticDeduplication);
        Run("UI mod edits preserve unrelated entries and comments", UiModEntries);
        Run("invalid UI values leave the file and snapshot unchanged", UiInvalidValues);
        Run("UI file failures leave the file and snapshot unchanged", UiFileFailures);
        Run("UI saves serialize with reload and publish each change once", UiReloadConcurrency);
        Run("completed reports retain start and end settings snapshots", ReportBoundarySnapshots);
        Run("invalid reload entries retain previous values while valid siblings apply", InvalidReload);
        Run("automatic reload handles replacement saves", ReplacementSave);
        Run("deleted configuration retains settings and recreation resumes reload", DeletedConfiguration);
        Run("invalid UTF-8 and oversized files retain the previous snapshot", InvalidFileBytes);
        Run("disposed configuration no longer publishes snapshots", DisposedConfiguration);
        Run("concurrent readers observe complete snapshots", SnapshotConcurrency);
        InstallFilter(Config()); // Install before logging test callers are first JIT-compiled.
        Run("actual Harmony prefix drops before listeners and ToString", ManualEarlyDrop);
        Run("allowed logs preserve source, payload, and level", ManualPayloadIdentity);
        Run("manual severity masks preserve warning, error, and fatal", SeverityMasks);
        Run("live filter reload observes GUID ownership", RuntimeReload);
        Run("disposing filters removes previous logger ownership", OwnershipDisposal);
        Run("file watcher or timer observes an external edit", AutomaticReload);
        Run("concurrent logging and reload preserve allowed events", LoggingConcurrency);
        Run("all four groups pass known, None, and unknown event bits", AllGroupsPassThrough);
        Run("unowned and diagnostic loggers always pass through", UnownedPassThrough);
        Run("filter disposal leaves the shared configuration usable", SharedConfigurationLifetime);
        Run("dispose restores logging and retains foreign patches", DisposeIsolation);
        Console.WriteLine(failures == 0 ? "All " + cases + " managed regression cases passed." : failures + " regression case(s) failed.");
        if (failures == 0 && args.Length == 5)
        {
            try { Benchmark(int.Parse(args[4])); }
            catch (Exception ex) { failures++; Console.WriteLine("FAIL benchmark: " + ex.GetBaseException()); }
        }
        else if (args.Length == 6) Console.WriteLine("Benchmark skipped by request.");
        TryDisposeFilter();
        Console.WriteLine("Not tested: real plugin constructor/Awake registration, game startup, native Unity pass-through, full ShutUp behavior, or multiplayer.");
        return failures == 0 ? 0 : 1;
    }

    private static Type T(string name) => product.GetType("LoadTimeProfiler." + name, true);
    private static object Call(string type, string method, params object[] args) => T(type).GetMethod(method, Any).Invoke(null, args);
    private static object Invoke(object instance, string method, params object[] args) => instance.GetType().GetMethod(method, Any).Invoke(instance, args);
    private static object Value(object instance, string property) => instance.GetType().GetProperty(property, Any).GetValue(instance);
    private static object Snapshot(object config) => config.GetType().GetProperty("Snapshot", Any).GetValue(config);
    private static bool Allows(object snapshot, string guid, LogLevel level) =>
        (bool)Invoke(Value(snapshot, "Logging"), "Allows", guid, level);
    private static object Groups(int bits) => Enum.ToObject(T("LogGroups"), bits);
    private static void Bind(ManualLogSource source, string guid) => Call("LogFiltering", "BindPluginLogger", source, guid);
    private static ManualLogSource Owned(string name, string guid = "mod.fixture")
    {
        var source = new ManualLogSource(name);
        Bind(source, guid);
        return source;
    }
    private static object NewConfig(string path, Action<string> notice = null, Action<string> warning = null) => Activator.CreateInstance(T("ModConfiguration"), Any, null,
        new object[] { path, warning ?? new Action<string>(_ => { }), notice ?? new Action<string>(_ => { }) }, null);
    private static void Check(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
    }
    private static void Run(string name, Action action)
    {
        cases++;
        try { action(); Console.WriteLine("PASS " + name); }
        catch (Exception ex) { failures++; Console.WriteLine("FAIL " + name + ": " + ex.GetBaseException()); }
    }
    private static string PathFor(string name) => Path.Combine(scratch, name + ".cfg");
    private static string Config(string mods = "", bool profiling = true, bool localization = true,
        bool coalescing = true, double timeout = 120, bool autoReload = false) =>
        "[General]\nProfilingEnabled = " + profiling +
        "\nLocalizationCacheEnabled = " + localization + "\nConfigWriteCoalescingEnabled = " + coalescing +
        "\nConfigAutoReloadEnabled = " + autoReload +
        "\nTimeoutProtectionSeconds = " + timeout.ToString(System.Globalization.CultureInfo.InvariantCulture) +
        "\n\n[Logging.Mods]\n" + mods;
    private static bool WaitUntil(Func<bool> predicate, int milliseconds = 3000)
    {
        Stopwatch wait = Stopwatch.StartNew();
        do { if (predicate()) return true; Thread.Sleep(10); } while (wait.ElapsedMilliseconds < milliseconds);
        return false;
    }
    private static void Reload(object config) => Check(WaitUntil(() => (bool)Invoke(config, "ReloadNow")), "Valid configuration did not reload.");
    private static void DisposeConfig(object config) => ((IDisposable)config).Dispose();
    private static void UiSet(object config, string method, params object[] args)
    {
        Check(WaitUntil(() =>
        {
            try { Invoke(config, method, args); return true; }
            catch (TargetInvocationException ex) when (ex.InnerException is InvalidOperationException &&
                ex.InnerException.Message.StartsWith("Another configuration reload or save", StringComparison.Ordinal)) { return false; }
        }), "UI save remained busy.");
    }
    private static void Throws<TException>(Action action) where TException : Exception
    {
        try { action(); }
        catch (Exception ex)
        {
            if (ex.GetBaseException() is TException) return;
            throw;
        }
        throw new InvalidOperationException("Expected " + typeof(TException).Name + ".");
    }

    private static void DefaultConfiguration()
    {
        string path = PathFor("missing");
        object config = NewConfig(path);
        try
        {
            Check(File.Exists(path), "The initial default file was not created.");
            string generated = File.ReadAllText(path);
            Check(generated.Contains("[General]") && generated.Contains("ProfilingEnabled = true") &&
                generated.Contains("ConfigAutoReloadEnabled = false"),
                "The generated configuration does not use the General schema.");
            object snapshot = Snapshot(config);
            Check(!(bool)Value(snapshot, "ConfigAutoReloadEnabled"), "Automatic reload of other mods must be opt-in.");
            Check(Equals(Invoke(config, "GetModLogGroups", "new.mod"), Groups(3)), "Unconfigured mod defaults are not Errors + Warnings.");
            Check(Allows(snapshot, "new.mod", LogLevel.Fatal) && Allows(snapshot, "new.mod", LogLevel.Warning) &&
                !Allows(snapshot, "new.mod", LogLevel.Info) && !Allows(snapshot, "new.mod", LogLevel.Debug), "Fresh valid configuration did not apply the normal default policy.");
            Check(Allows(snapshot, null, LogLevel.Info) && Allows(snapshot, null, LogLevel.None) && Allows(snapshot, null, (LogLevel)64),
                "Unowned logs must always pass through.");
            string secondPath = PathFor("missing-second");
            object second = NewConfig(secondPath);
            try { Check(File.ReadAllBytes(path).SequenceEqual(File.ReadAllBytes(secondPath)), "Default text depends on creation time or path."); }
            finally { DisposeConfig(second); }
            File.WriteAllText(path, Config().Replace("\n\n[Logging.Mods]\n", ""));
            Reload(config);
            Check(Equals(Invoke(config, "GetModLogGroups", "new.mod"), Groups(3)), "An omitted optional mod section changed defaults.");
        }
        finally { DisposeConfig(config); }
    }

    private static void GeneralSchema()
    {
        string path = PathFor("general-schema");
        string original = "[General]\nProfilingEnabled = false\n[Logging.Mods]\nmod.fixture = Information\n";
        File.WriteAllText(path, original);
        object config = NewConfig(path);
        try
        {
            object initial = Snapshot(config);
            Check(!(bool)Value(initial, "ProfilingEnabled") && (bool)Value(initial, "LocalizationCacheEnabled") &&
                (bool)Value(initial, "ConfigWriteCoalescingEnabled") && !(bool)Value(initial, "ConfigAutoReloadEnabled") &&
                (float)Value(initial, "TimeoutProtectionSeconds") == 120f && Allows(initial, "mod.fixture", LogLevel.Info),
                "Partial initial General settings did not combine valid values with per-setting defaults.");
            Check(File.ReadAllText(path) == original, "Reading a partial configuration filled or rewrote missing keys.");
            File.WriteAllText(path, Config("mod.fixture = Information\n", profiling: false, localization: false,
                coalescing: false, timeout: 45, autoReload: true));
            Reload(config);
            string partial = "[General]\nProfilingEnabled = true\nConfigAutoReloadEnabled = sometimes\n[Logging.Mods]\nmod.fixture = Debug\n";
            File.WriteAllText(path, partial);
            Reload(config);
            object latest = Snapshot(config);
            Check((bool)Value(latest, "ProfilingEnabled") && !(bool)Value(latest, "LocalizationCacheEnabled") &&
                !(bool)Value(latest, "ConfigWriteCoalescingEnabled") && (bool)Value(latest, "ConfigAutoReloadEnabled") &&
                (float)Value(latest, "TimeoutProtectionSeconds") == 45f && Allows(latest, "mod.fixture", LogLevel.Debug),
                "Missing or invalid General keys discarded prior values or blocked valid siblings.");
            Check(ReferenceEquals(initial, Value(config, "StartupSettings")) && File.ReadAllText(path) == partial,
                "A partial reload changed startup-owned state or source text.");
            File.WriteAllText(path, "[Logging.Mods]\nmod.fixture = Errors\n");
            Reload(config);
            Check((bool)Value(Snapshot(config), "ProfilingEnabled") && (bool)Value(Snapshot(config), "ConfigAutoReloadEnabled") &&
                (float)Value(Snapshot(config), "TimeoutProtectionSeconds") == 45f,
                "An omitted General section reset runtime preferences.");
        }
        finally { DisposeConfig(config); }
    }

    private static void SinglePatcherContract()
    {
        using (Mono.Cecil.AssemblyDefinition assembly = Mono.Cecil.AssemblyDefinition.ReadAssembly(product.Location))
        {
            Mono.Cecil.TypeDefinition[] patchers = assembly.MainModule.Types.Where(type => type.IsPublic &&
                type.Methods.Any(method => method.IsPublic && method.IsStatic && method.Name == "Patch" &&
                    method.ReturnType.FullName == "System.Void" && method.Parameters.Count == 1 &&
                    method.Parameters[0].ParameterType.FullName == "Mono.Cecil.AssemblyDefinition") &&
                type.Properties.Any(property => property.Name == "TargetDLLs" && property.GetMethod != null &&
                    property.GetMethod.IsPublic && property.GetMethod.IsStatic)).ToArray();
            Check(patchers.Length == 1 && patchers[0].FullName == "LoadTimeProfiler.LoadTimeProfilerPatcher", "The integrated DLL exposes more than one or an unexpected BepInEx patcher entry point.");
            Check(!assembly.MainModule.AssemblyReferences.Any(reference => reference.Name == "QuietLogs"), "Integrated logging still depends on the former standalone DLL.");
            Check(!assembly.MainModule.AssemblyReferences.Any(reference =>
                string.Equals(reference.Name, "ConfigManager", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(reference.Name, "ConfigurationManager", StringComparison.OrdinalIgnoreCase)),
                "The optional configuration UI became an assembly dependency.");
            Check(!assembly.MainModule.Types.Any(type => type.FullName == "LoadTimeProfiler.UnityLogFiltering"),
                "The removed Unity filter remains in the product.");
            var logging = assembly.MainModule.Types.Single(type => type.FullName == "LoadTimeProfiler.LogFiltering");
            foreach (var instruction in NestedTypes(logging).SelectMany(type => type.Methods)
                .Where(method => method.HasBody).SelectMany(method => method.Body.Instructions))
            {
                var member = instruction.Operand as Mono.Cecil.MemberReference;
                string owner = member == null || member.DeclaringType == null ? "" : member.DeclaringType.FullName;
                Check(!owner.StartsWith("UnityEngine.", StringComparison.Ordinal) && owner != "BepInEx.Logging.UnityLogSource" &&
                    !(instruction.Operand is Mono.Cecil.TypeReference type && type.FullName.StartsWith("UnityEngine.", StringComparison.Ordinal)) &&
                    !(instruction.Operand is Mono.Cecil.MethodReference method && method.Name == "InitializeInternalLoggers") &&
                    !(instruction.Operand is string text && (text == "InitializeInternalLoggers" || text.Contains(".unity.") || text == ".bootstrap")),
                    "Manual logging still contains Unity or internal-logger bootstrap patch targets.");
            }
        }
    }
    private static IEnumerable<Mono.Cecil.TypeDefinition> NestedTypes(Mono.Cecil.TypeDefinition type)
    {
        yield return type;
        foreach (var nested in type.NestedTypes)
            foreach (var descendant in NestedTypes(nested)) yield return descendant;
    }
    private static void UiTypedSettings()
    {
        string path = PathFor("ui-typed");
        File.WriteAllText(path, Config("mod.fixture = Errors, Warnings, Information, Debug\n"));
        int notices = 0;
        object config = NewConfig(path, _ => Interlocked.Increment(ref notices));
        try
        {
            object startup = Value(config, "StartupSettings");
            long revision = Convert.ToInt64(Value(Snapshot(config), "Revision"));
            object[][] changes = {
                new object[] { "General", "ProfilingEnabled", false },
                new object[] { "General", "LocalizationCacheEnabled", false },
                new object[] { "General", "ConfigWriteCoalescingEnabled", false },
                new object[] { "General", "ConfigAutoReloadEnabled", true },
                new object[] { "General", "TimeoutProtectionSeconds", 9.25f }
            };
            foreach (object[] change in changes)
            {
                UiSet(config, "SetSettingValue", change);
                Check(Equals(Invoke(config, "GetSettingValue", change[0], change[1]), change[2]), "A typed UI value did not publish immediately.");
                Check(Convert.ToInt64(Value(Snapshot(config), "Revision")) == ++revision, "A UI save did not create exactly one semantic revision.");
                Reload(config);
                Check(Convert.ToInt64(Value(Snapshot(config), "Revision")) == revision, "Reload duplicated a UI save revision.");
            }
            Check(ReferenceEquals(startup, Value(config, "StartupSettings")) && (bool)Value(startup, "ProfilingEnabled") &&
                (bool)Value(startup, "LocalizationCacheEnabled") && (bool)Value(startup, "ConfigWriteCoalescingEnabled") &&
                !(bool)Value(startup, "ConfigAutoReloadEnabled") &&
                (float)Value(startup, "TimeoutProtectionSeconds") == 120f, "A UI save replaced or mutated captured startup settings.");
            Check(notices == 5, "Startup UI edits and live logging edits produced incorrect restart notices.");
            object disk = NewConfig(path);
            try
            {
                foreach (object[] change in changes)
                    Check(Equals(Invoke(disk, "GetSettingValue", change[0], change[1]), change[2]), "Saved typed value did not survive a new configuration instance.");
            }
            finally { DisposeConfig(disk); }
        }
        finally { DisposeConfig(config); }
    }
    private static void UiPreservesDocument()
    {
        string path = PathFor("ui-preserve");
        string original = "\uFEFF# header retained\r\n" + Config("; mod note\norg.old = Errors, Warnings\n")
            .Replace("org.old = Errors, Warnings", "  org.old  = \tErrors, Warnings \t").Replace("\n", "\r\n");
        File.WriteAllBytes(path, new System.Text.UTF8Encoding(false, true).GetBytes(original));
        object config = NewConfig(path);
        try
        {
            object startup = Value(config, "StartupSettings");
            string external = original.Replace("ConfigWriteCoalescingEnabled = True", "ConfigWriteCoalescingEnabled = False") +
                "# external comment\r\norg.external = Information\r\n";
            File.WriteAllBytes(path, new System.Text.UTF8Encoding(false, true).GetBytes(external));
            UiSet(config, "SetModLogGroups", "org.old", Groups(4));
            string expected = external.Replace("  org.old  = \tErrors, Warnings \t", "  org.old  = \tInformation \t");
            Check(File.ReadAllBytes(path).SequenceEqual(new System.Text.UTF8Encoding(false, true).GetBytes(expected)),
                "UI save changed unrelated edits, comments, whitespace, BOM, or line endings.");
            Check(!(bool)Value(Snapshot(config), "ConfigWriteCoalescingEnabled") &&
                Equals(Invoke(config, "GetModLogGroups", "org.external"), Groups(4)), "UI save used stale settings instead of current disk contents.");
            Check(ReferenceEquals(startup, Value(config, "StartupSettings")) && (bool)Value(startup, "ConfigWriteCoalescingEnabled"),
                "External startup edits changed captured startup settings.");
        }
        finally { DisposeConfig(config); }
    }

    private static void UiTolerantDocument()
    {
        string path = PathFor("ui-tolerant-document");
        string original = "\uFEFF# user notes retained\r\n[Profiling]\r\nEnabled = false\r\n" +
            "[Startup]\r\nLocalizationCacheEnabled = false\r\n[Connection]\r\nTimeoutProtectionSeconds = 9\r\n" +
            "[Logging.Mods]\r\n  org.target  = \tBogus \t\r\norg.invalid = Errors,\r\n" +
            "# tail note\r\n[Unknown]\r\nUnrecognized = kept\r\n";
        var encoding = new System.Text.UTF8Encoding(false, true);
        File.WriteAllBytes(path, encoding.GetBytes(original));
        object config = NewConfig(path);
        try
        {
            Check((bool)Value(Snapshot(config), "ProfilingEnabled") && (bool)Value(Snapshot(config), "LocalizationCacheEnabled") &&
                (float)Value(Snapshot(config), "TimeoutProtectionSeconds") == 120f,
                "Old section names were migrated or applied as current settings.");
            UiSet(config, "SetModLogGroups", "org.target", Groups(4));
            string edited = original.Replace("  org.target  = \tBogus \t", "  org.target  = \tInformation \t");
            Check(File.ReadAllBytes(path).SequenceEqual(encoding.GetBytes(edited)) &&
                Equals(Invoke(config, "GetModLogGroups", "org.target"), Groups(4)) &&
                Equals(Invoke(config, "GetModLogGroups", "org.invalid"), Groups(3)),
                "An invalid target value was not replaced in place or unrelated old/invalid rows changed.");
            UiSet(config, "SetSettingValue", "General", "ProfilingEnabled", false);
            string withGeneral = File.ReadAllText(path);
            Check(File.ReadAllBytes(path).Take(encoding.GetByteCount(edited)).SequenceEqual(encoding.GetBytes(edited)) &&
                withGeneral.Contains("[General]\r\nProfilingEnabled = false\r\n") &&
                !(bool)Value(Snapshot(config), "ProfilingEnabled"),
                "UI could not append a missing current General section while preserving the original bytes.");
            UiSet(config, "SetSettingValue", "General", "TimeoutProtectionSeconds", 45.5f);
            string saved = File.ReadAllText(path);
            Check(saved.Contains("TimeoutProtectionSeconds = 45.5") && saved.Contains("TimeoutProtectionSeconds = 9\r\n") &&
                (float)Value(Snapshot(config), "TimeoutProtectionSeconds") == 45.5f,
                "UI could not add a missing General key without changing the old Connection value.");
            object reopened = NewConfig(path);
            try
            {
                Check(!(bool)Value(Snapshot(reopened), "ProfilingEnabled") &&
                    (float)Value(Snapshot(reopened), "TimeoutProtectionSeconds") == 45.5f &&
                    Equals(Invoke(reopened, "GetModLogGroups", "org.target"), Groups(4)),
                    "Edits in an old or partially invalid document did not survive reopening.");
            }
            finally { DisposeConfig(reopened); }
        }
        finally { DisposeConfig(config); }
    }

    private static void DuplicateEntries()
    {
        string path = PathFor("duplicates");
        string original = "[General]\nProfilingEnabled = false\nProfilingEnabled = true\nProfilingEnabled = invalid\n" +
            "TimeoutProtectionSeconds = 15\nTimeoutProtectionSeconds = NaN\n" +
            "[Logging.Mods]\norg.target = Errors\norg.target = Debug\n" +
            "[Logging.Mods]\norg.target = Bogus\norg.other = Information\n";
        File.WriteAllText(path, original);
        object config = NewConfig(path);
        try
        {
            Check((bool)Value(Snapshot(config), "ProfilingEnabled") && (float)Value(Snapshot(config), "TimeoutProtectionSeconds") == 15f &&
                Equals(Invoke(config, "GetModLogGroups", "org.target"), Groups(8)),
                "Duplicate keys did not use their last valid occurrence when the final occurrence was invalid.");
            UiSet(config, "SetModLogGroups", "org.target", Groups(2));
            string edited = original.Replace("org.target = Bogus", "org.target = Warnings");
            Check(File.ReadAllText(path) == edited && Equals(Invoke(config, "GetModLogGroups", "org.target"), Groups(2)),
                "UI edited an earlier duplicate or failed to make the requested mod value effective.");
            UiSet(config, "SetSettingValue", "General", "ProfilingEnabled", false);
            edited = edited.Replace("ProfilingEnabled = invalid", "ProfilingEnabled = false");
            Check(File.ReadAllText(path) == edited && !(bool)Value(Snapshot(config), "ProfilingEnabled"),
                "UI did not replace the final General occurrence while leaving earlier duplicates untouched.");
            Reload(config);
            Check(!(bool)Value(Snapshot(config), "ProfilingEnabled") && Equals(Invoke(config, "GetModLogGroups", "org.target"), Groups(2)),
                "Reload disagreed with the values published by duplicate-key UI edits.");
        }
        finally { DisposeConfig(config); }
    }

    private static void MalformedSectionBoundaries()
    {
        string path = PathFor("malformed-section-boundaries");
        string original = "[General]\nProfilingEnabled = false\n[broken\nProfilingEnabled = true\n" +
            "[Logging.Mods]\norg.target = Information\n[\norg.target = Debug\n";
        File.WriteAllText(path, original);
        object config = NewConfig(path);
        try
        {
            Check(!(bool)Value(Snapshot(config), "ProfilingEnabled") && Equals(Invoke(config, "GetModLogGroups", "org.target"), Groups(4)),
                "A malformed header allowed following rows to inherit the preceding section.");
            UiSet(config, "SetModLogGroups", "org.target", Groups(2));
            string edited = original.Replace("org.target = Information", "org.target = Warnings");
            UiSet(config, "SetSettingValue", "General", "ProfilingEnabled", true);
            edited = edited.Replace("ProfilingEnabled = false", "ProfilingEnabled = true");
            Check(File.ReadAllText(path) == edited && Equals(Invoke(config, "GetModLogGroups", "org.target"), Groups(2)),
                "UI altered matching key text beyond a malformed section boundary.");
            string missingKey = "[General]\nProfilingEnabled = false\n[broken\nTimeoutProtectionSeconds = 900\n";
            File.WriteAllText(path, missingKey);
            UiSet(config, "SetSettingValue", "General", "TimeoutProtectionSeconds", 30f);
            Check(File.ReadAllText(path).Contains("[broken\nTimeoutProtectionSeconds = 900\n") &&
                (float)Value(Snapshot(config), "TimeoutProtectionSeconds") == 30f,
                "Adding a missing General key overwrote unscoped text after a malformed header.");
        }
        finally { DisposeConfig(config); }
    }

    private static void DiagnosticDeduplication()
    {
        string path = PathFor("diagnostic-deduplication");
        string original = Config("org.invalid = Bogus\norg.editable = Warnings\n")
            .Replace("ProfilingEnabled = True", "ProfilingEnabled = maybe");
        File.WriteAllText(path, original);
        int warnings = 0;
        object config = NewConfig(path, warning: _ => Interlocked.Increment(ref warnings));
        try
        {
            int initialWarnings = Volatile.Read(ref warnings);
            Check(initialWarnings > 0, "Invalid known entries produced no diagnostic.");
            Reload(config);
            Reload(config);
            Check(Volatile.Read(ref warnings) == initialWarnings, "Unchanged invalid entries repeated diagnostics on explicit reload.");
            UiSet(config, "SetModLogGroups", "org.editable", Groups(4));
            Check(Volatile.Read(ref warnings) == initialWarnings && Equals(Invoke(config, "GetModLogGroups", "org.editable"), Groups(4)),
                "Editing an unrelated valid value repeated the same entry diagnostic or blocked the edit.");
            File.WriteAllText(path, Config("org.invalid = Errors\norg.editable = Information\n"));
            Reload(config);
            File.WriteAllText(path, original);
            Reload(config);
            Check(Volatile.Read(ref warnings) > initialWarnings,
                "A problem that recurred after a clean document produced no new diagnostic.");
        }
        finally { DisposeConfig(config); }
    }

    private static void UiModEntries()
    {
        string path = PathFor("ui-mods");
        string original = Config("# retain comment\norg.zulu = Information\norg.alpha = Errors, Warnings\n; retain tail\n");
        File.WriteAllText(path, original);
        object config = NewConfig(path);
        try
        {
            UiSet(config, "SetModLogGroups", "org.alpha", Groups(0));
            Check(File.ReadAllText(path) == original.Replace("org.alpha = Errors, Warnings", "org.alpha = None"),
                "An existing GUID edit rewrote unrelated entries.");
            string before = File.ReadAllText(path);
            UiSet(config, "SetModLogGroups", "org.new", Groups(8));
            Check(File.ReadAllText(path) == before.Replace("[Logging.Mods]\n", "[Logging.Mods]\norg.new = Debug\n"),
                "Adding a GUID discarded unloaded mod entries or comments.");
            Check(Equals(Invoke(config, "GetModLogGroups", "org.new"), Groups(8)) &&
                Equals(Invoke(config, "GetModLogGroups", "org.NEW"), Groups(3)), "GUID matching is not exact.");
            Check(!Allows(Snapshot(config), "org.alpha", LogLevel.Fatal) && Allows(Snapshot(config), "org.zulu", LogLevel.Info),
                "Per-GUID editing changed another mod policy.");
            string noSection = Config().Replace("\n\n[Logging.Mods]\n", "");
            File.WriteAllText(path, noSection);
            UiSet(config, "SetModLogGroups", "other.mod", Groups(4));
            Check(File.ReadAllText(path) == noSection + "\n[Logging.Mods]\nother.mod = Information\n", "An absent mod section was not safely appended.");
        }
        finally { DisposeConfig(config); }
    }

    private static void UiInvalidValues()
    {
        string path = PathFor("ui-invalid");
        File.WriteAllText(path, Config());
        object config = NewConfig(path);
        try
        {
            byte[] original = File.ReadAllBytes(path);
            object previous = Snapshot(config);
            Action[] invalid = {
                () => Invoke(config, "SetSettingValue", "General", "ProfilingEnabled", "true"),
                () => Invoke(config, "SetSettingValue", "General", "ConfigAutoReloadEnabled", "true"),
                () => Invoke(config, "SetSettingValue", "General", "ConfigAutoReloadEnabled", 1),
                () => Invoke(config, "SetSettingValue", "General", "UnknownSetting", true),
                () => Invoke(config, "SetSettingValue", "Unexpected.Section", "ProfilingEnabled", true),
                () => Invoke(config, "SetModLogGroups", "valid.guid", Groups(16)),
                () => Invoke(config, "SetModLogGroups", "valid.guid", Groups(-1)),
                () => Invoke(config, "SetSettingValue", "General", "TimeoutProtectionSeconds", float.NaN),
                () => Invoke(config, "SetSettingValue", "General", "TimeoutProtectionSeconds", -1f),
                () => Invoke(config, "SetModLogGroups", "bad=guid", Groups(4)),
                () => Invoke(config, "SetModLogGroups", "[invalid.guid]", Groups(4)),
                () => Invoke(config, "SetModLogGroups", "bad\nguid", Groups(4)),
                () => Invoke(config, "SetModLogGroups", " guid ", Groups(4)),
                () => Invoke(config, "SetModLogGroups", "#comment", Groups(4))
            };
            foreach (Action edit in invalid)
            {
                Throws<ArgumentException>(edit);
                Check(ReferenceEquals(previous, Snapshot(config)) && File.ReadAllBytes(path).SequenceEqual(original),
                    "Invalid UI input changed the file or published a snapshot.");
            }
        }
        finally { DisposeConfig(config); }
    }

    private static void UiFileFailures()
    {
        string path = PathFor("ui-file-failures");
        string original = Config();
        File.WriteAllText(path, original);
        object config = NewConfig(path);
        try
        {
            object previous = Snapshot(config);
            Action save = () => UiSet(config, "SetModLogGroups", "mod.fixture", Groups(4));
            byte[] invalid = { 0xc3, 0x28 };
            File.WriteAllBytes(path, invalid);
            Throws<System.Text.DecoderFallbackException>(save);
            Check(File.ReadAllBytes(path).SequenceEqual(invalid) && ReferenceEquals(previous, Snapshot(config)), "UI overwrote invalid UTF-8 bytes.");
            byte[] oversized = new byte[256 * 1024 + 1];
            File.WriteAllBytes(path, oversized);
            Throws<InvalidDataException>(save);
            Check(File.ReadAllBytes(path).SequenceEqual(oversized) && ReferenceEquals(previous, Snapshot(config)), "UI overwrote an oversized external edit.");
            File.Delete(path);
            Throws<FileNotFoundException>(save);
            Check(!File.Exists(path) && ReferenceEquals(previous, Snapshot(config)), "UI recreated a missing config or published an unsaved value.");
            File.WriteAllText(path, original);
            using (FileStream locked = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None))
                Throws<IOException>(save);
            // The read succeeds, but this handle denies delete sharing so File.Replace must fail.
            using (FileStream locked = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                Throws<IOException>(save);
            Check(File.ReadAllText(path) == original && ReferenceEquals(previous, Snapshot(config)), "A failed read or atomic replacement changed the file or snapshot.");
            Check(Directory.GetFiles(scratch, Path.GetFileName(path) + ".*.tmp").Length == 0, "A failed atomic replacement leaked its temporary file.");
            save();
            Check(Equals(Invoke(config, "GetModLogGroups", "mod.fixture"), Groups(4)), "Failed saves left subsequent UI saves blocked.");
            previous = Snapshot(config);
            byte[] saved = File.ReadAllBytes(path);
            DisposeConfig(config);
            Throws<ObjectDisposedException>(() => Invoke(config, "SetModLogGroups", "mod.fixture", Groups(15)));
            Check(File.ReadAllBytes(path).SequenceEqual(saved) && ReferenceEquals(previous, Snapshot(config)), "Disposed configuration saved or published UI changes.");
        }
        finally { DisposeConfig(config); }
    }
    private static void UiReloadConcurrency()
    {
        string path = PathFor("ui-concurrent");
        File.WriteAllText(path, Config());
        object config = NewConfig(path);
        int stop = 0;
        Task reloader = Task.Run(() =>
        {
            while (Volatile.Read(ref stop) == 0) { Invoke(config, "ReloadNow"); Thread.Sleep(2); }
        });
        try
        {
            object startup = Value(config, "StartupSettings");
            long before = Convert.ToInt64(Value(Snapshot(config), "Revision"));
            for (int i = 0; i < 20; i++)
            {
                object groups = Groups((i % 2) == 0 ? 8 : 4);
                UiSet(config, "SetModLogGroups", "mod.fixture", groups);
                Check(Equals(Invoke(config, "GetModLogGroups", "mod.fixture"), groups), "Concurrent reload overwrote a completed UI save.");
                Thread.Sleep(55); // Keep the real 500 ms timer active during this test.
            }
            Check(Convert.ToInt64(Value(Snapshot(config), "Revision")) == before + 20, "UI/reload concurrency lost a change or published a duplicate revision.");
            Check(ReferenceEquals(startup, Value(config, "StartupSettings")) && File.ReadAllText(path).Contains("mod.fixture = Information"), "Concurrent save changed startup state or left disk stale.");
            Check(Directory.GetFiles(scratch, Path.GetFileName(path) + ".*.tmp").Length == 0, "Concurrent saves leaked temporary files.");
        }
        finally { Volatile.Write(ref stop, 1); reloader.GetAwaiter().GetResult(); DisposeConfig(config); }
    }
    private static void MalformedStartup()
    {
        string path = PathFor("malformed-initial");
        string original = Config("mod.valid = Information\nmod.invalid = Bogus\n", localization: false)
            .Replace("ProfilingEnabled = True", "ProfilingEnabled = maybe")
            .Replace("TimeoutProtectionSeconds = 120", "TimeoutProtectionSeconds = NaN")
            .Replace("ConfigAutoReloadEnabled = False", "ConfigAutoReloadEnabled = sometimes");
        File.WriteAllText(path, original);
        object config = NewConfig(path);
        try
        {
            object snapshot = Snapshot(config);
            Check((bool)Value(snapshot, "ProfilingEnabled") && !(bool)Value(snapshot, "LocalizationCacheEnabled") &&
                !(bool)Value(snapshot, "ConfigAutoReloadEnabled") && (float)Value(snapshot, "TimeoutProtectionSeconds") == 120f,
                "Invalid initial General values did not use individual defaults while applying a valid sibling.");
            Check(Equals(Invoke(config, "GetModLogGroups", "mod.valid"), Groups(4)) &&
                Equals(Invoke(config, "GetModLogGroups", "mod.invalid"), Groups(3)) &&
                !Allows(snapshot, "mod.unconfigured", LogLevel.Info) && Allows(snapshot, "mod.invalid", LogLevel.Error),
                "Malformed entries disabled the whole logging policy or failed to use default groups for an invalid mod.");
            Check(File.ReadAllText(path) == original, "Partial initial recovery rewrote user text.");
        }
        finally { DisposeConfig(config); }
    }
    private static void ExactSourcePolicies()
    {
        string path = PathFor("identity");
        File.WriteAllText(path, Config("org.exact = Information\norg.silent = None\n"));
        object config = NewConfig(path);
        try
        {
            object snapshot = Snapshot(config);
            Check(Allows(snapshot, "org.exact", LogLevel.Info) && !Allows(snapshot, "org.exact", LogLevel.Warning), "Exact GUID policy did not apply.");
            Check(!Allows(snapshot, "ORG.EXACT", LogLevel.Info) && !Allows(snapshot, "org.exact.child", LogLevel.Info) &&
                Allows(snapshot, "ORG.EXACT", LogLevel.Warning), "Unknown GUIDs must use Errors + Warnings without case or prefix matching.");
            Check(!Allows(snapshot, "org.silent", LogLevel.Fatal) && Allows(snapshot, null, LogLevel.Fatal), "None affected unowned logs or failed to block a known mod.");
        }
        finally { DisposeConfig(config); }
    }

    private static void GroupCombinations()
    {
        string path = PathFor("groups");
        File.WriteAllText(path, Config());
        object config = NewConfig(path);
        try
        {
            LogLevel[] events = { LogLevel.Fatal, LogLevel.Error, LogLevel.Warning, LogLevel.Message, LogLevel.Info, LogLevel.Debug,
                LogLevel.None, (LogLevel)64, LogLevel.Info | LogLevel.Warning };
            for (int bits = 0; bits < 16; bits++)
            {
                UiSet(config, "SetModLogGroups", "mod.fixture", Groups(bits));
                int mask = ((bits & 1) != 0 ? 3 : 0) | ((bits & 2) != 0 ? 4 : 0) |
                    ((bits & 4) != 0 ? 24 : 0) | ((bits & 8) != 0 ? 32 : 0);
                object snapshot = Snapshot(config);
                foreach (LogLevel level in events)
                    Check(Allows(snapshot, "mod.fixture", level) == (bits == 15 || ((int)level & mask) != 0),
                        "Incorrect group-to-severity mapping for " + bits + " / " + level + ".");
                Check(Equals(Invoke(config, "GetModLogGroups", "mod.fixture"), Groups(bits)), "Checkbox combination failed to round-trip.");
            }
            Check(Attribute.IsDefined(T("LogGroups"), typeof(FlagsAttribute)) &&
                Enum.GetNames(T("LogGroups")).SequenceEqual(new[] { "None", "Errors", "Warnings", "Information", "Debug" }),
                "The checkbox enum contains unexpected groups or composite choices.");
            string[] labels = { "Fatal + Error", "Warning", "Message + Info", "Debug" };
            foreach (var pair in new[] { "Errors", "Warnings", "Information", "Debug" }.Select((name, index) => new { name, index }))
                Check(((System.ComponentModel.DescriptionAttribute)Attribute.GetCustomAttribute(T("LogGroups").GetField(pair.name),
                    typeof(System.ComponentModel.DescriptionAttribute))).Description == labels[pair.index], "Group labels lost their severity meaning.");
            object previous = Snapshot(config);
            foreach (string value in new[] { "0", "15", "Errors, 2", "Errors,", "None, Warnings", "Bogus" })
            {
                File.WriteAllText(path, Config("mod.fixture = " + value + "\n"));
                Reload(config);
                Check(ReferenceEquals(previous, Snapshot(config)) && Equals(Invoke(config, "GetModLogGroups", "mod.fixture"), Groups(15)),
                    "Unsupported group syntax replaced the previous valid group value.");
            }
            File.WriteAllText(path, Config("mod.fixture = eRrOrS, wArNiNgS\n"));
            Reload(config);
            Check(Equals(Invoke(config, "GetModLogGroups", "mod.fixture"), Groups(3)), "Named group parsing became case-sensitive.");
        }
        finally { DisposeConfig(config); }
    }

    private static void PolicyDescriptions()
    {
        string firstPath = PathFor("description-first");
        string secondPath = PathFor("description-second");
        File.WriteAllText(firstPath, Config("org.zulu = Information\norg.alpha = Errors, Warnings\n"));
        File.WriteAllText(secondPath, Config("org.alpha = Errors, Warnings\norg.zulu = Information\n"));
        object first = NewConfig(firstPath);
        object second = NewConfig(secondPath);
        try
        {
            string firstDescription = (string)Value(Value(Snapshot(first), "Logging"), "Description");
            string secondDescription = (string)Value(Value(Snapshot(second), "Logging"), "Description");
            Check(firstDescription == secondDescription, "Equivalent policies produce different report descriptions.");
            Check(firstDescription.IndexOf("org.alpha=", StringComparison.Ordinal) >= 0 &&
                  firstDescription.IndexOf("org.alpha=", StringComparison.Ordinal) < firstDescription.IndexOf("org.zulu=", StringComparison.Ordinal),
                "Source overrides are not reported in a stable ordinal order.");
            object previous = Snapshot(first);
            File.WriteAllText(firstPath, "# changed source order only\n" + File.ReadAllText(secondPath));
            Reload(first);
            Check(Convert.ToInt64(Value(Snapshot(first), "Revision")) == Convert.ToInt64(Value(previous, "Revision")),
                "Cosmetic source ordering created a new settings revision.");
        }
        finally { DisposeConfig(first); DisposeConfig(second); }
    }
    private static void ReloadWithoutRewrite()
    {
        string path = PathFor("reload");
        File.WriteAllText(path, Config());
        object config = NewConfig(path);
        try
        {
            string changed = "# external formatting is retained\n" + Config("mod.example = Information\n");
            File.WriteAllText(path, changed);
            Reload(config);
            Check(Allows(Snapshot(config), "mod.example", LogLevel.Info), "Valid edit did not apply.");
            Check(File.ReadAllText(path) == changed, "Reload rewrote the user's file.");
        }
        finally { DisposeConfig(config); }
    }
    private static void InvalidReload()
    {
        string path = PathFor("invalid-reload");
        File.WriteAllText(path, Config("mod.invalid = Debug\nmod.removed = Information\n", profiling: false, timeout: 30, autoReload: true));
        object config = NewConfig(path);
        try
        {
            foreach (string invalidTimeout in new[] { "-1", "NaN", "Infinity", "not-a-number" })
            {
                string mixed = "[General]\nProfilingEnabled = invalid\nTimeoutProtectionSeconds = " + invalidTimeout +
                    "\nConfigAutoReloadEnabled = maybe\nLocalizationCacheEnabled = false\n" +
                    "[Logging.Mods]\nmod.invalid = Bogus\nmod.new.invalid = 64\nmod.valid = Information\n";
                File.WriteAllText(path, mixed);
                Reload(config);
                object latest = Snapshot(config);
                Check(!(bool)Value(latest, "ProfilingEnabled") && !(bool)Value(latest, "LocalizationCacheEnabled") &&
                    (bool)Value(latest, "ConfigAutoReloadEnabled") && (float)Value(latest, "TimeoutProtectionSeconds") == 30f,
                    "An invalid General value replaced a prior value or blocked its valid sibling.");
                Check(Equals(Invoke(config, "GetModLogGroups", "mod.invalid"), Groups(8)) &&
                    Equals(Invoke(config, "GetModLogGroups", "mod.new.invalid"), Groups(3)) &&
                    Equals(Invoke(config, "GetModLogGroups", "mod.valid"), Groups(4)) &&
                    Equals(Invoke(config, "GetModLogGroups", "mod.removed"), Groups(3)),
                    "Reload failed to distinguish an invalid present mod, a new invalid mod, a valid mod, and a removed override.");
                Check(File.ReadAllText(path) == mixed, "Recovering valid reload entries rewrote invalid rows.");
            }
        }
        finally { DisposeConfig(config); }
    }
    private static void UnknownSections()
    {
        string path = PathFor("unknown-section");
        string unknown = Config("mod.fixture = Information\n", autoReload: true).Replace("[General]\n", "[General]\nUnknownSetting = false\n") +
            "\n[Unexpected.Section]\nProfilingEnabled = false\n[general]\nConfigAutoReloadEnabled = false\n";
        File.WriteAllText(path, unknown);
        object config = NewConfig(path);
        try
        {
            Check(Equals(Invoke(config, "GetModLogGroups", "mod.fixture"), Groups(4)) &&
                !Allows(Snapshot(config), "mod.unconfigured", LogLevel.Debug) &&
                (bool)Value(Value(config, "StartupSettings"), "ConfigAutoReloadEnabled") &&
                (bool)Value(Snapshot(config), "ProfilingEnabled"),
                "An unknown section/key disabled valid values or was incorrectly mapped to a known section.");
            Check(File.ReadAllText(path) == unknown, "Opening a document with unknown rows rewrote it.");
            string updated = unknown.Replace("mod.fixture = Information", "mod.fixture = Debug");
            File.WriteAllText(path, updated);
            Reload(config);
            Check(Equals(Invoke(config, "GetModLogGroups", "mod.fixture"), Groups(8)) && File.ReadAllText(path) == updated,
                "Unknown rows blocked a later valid logging edit or were discarded during reload.");
        }
        finally { DisposeConfig(config); }
    }

    private static void StartupSettingsStayFixed()
    {
        string path = PathFor("fixed-startup");
        File.WriteAllText(path, Config());
        int notices = 0;
        object config = NewConfig(path, _ => Interlocked.Increment(ref notices));
        try
        {
            object startup = Value(config, "StartupSettings");
            File.WriteAllText(path, Config("mod.fixture = Information\n", profiling: false, localization: false, coalescing: false, timeout: 45, autoReload: true));
            Reload(config);
            object latest = Snapshot(config);
            Check(ReferenceEquals(startup, Value(config, "StartupSettings")), "Reload replaced the startup snapshot.");
            Check((bool)Value(startup, "ProfilingEnabled") && (bool)Value(startup, "LocalizationCacheEnabled") &&
                  (bool)Value(startup, "ConfigWriteCoalescingEnabled") && !(bool)Value(startup, "ConfigAutoReloadEnabled") &&
                  Convert.ToDouble(Value(startup, "TimeoutProtectionSeconds")) == 120,
                "Reload changed startup-owned feature settings.");
            Check(!(bool)Value(latest, "ProfilingEnabled") && !(bool)Value(latest, "LocalizationCacheEnabled") &&
                  !(bool)Value(latest, "ConfigWriteCoalescingEnabled") && (bool)Value(latest, "ConfigAutoReloadEnabled") &&
                  Convert.ToDouble(Value(latest, "TimeoutProtectionSeconds")) == 45,
                "The latest parsed settings were not published.");
            Check(Allows(latest, "mod.fixture", LogLevel.Info) && !Allows(latest, "mod.fixture", LogLevel.Debug), "Logging did not update independently of fixed startup features.");
            Check(Volatile.Read(ref notices) > 0, "Changed startup settings were not identified as requiring restart.");
            int afterChange = Volatile.Read(ref notices);
            Reload(config);
            Check(Volatile.Read(ref notices) == afterChange, "An unchanged reload repeated the startup notice.");
        }
        finally { DisposeConfig(config); }
    }
    private static void AutoReloadStartupToggle()
    {
        foreach (bool enabledAtStartup in new[] { false, true })
        {
            string path = PathFor("auto-reload-toggle-" + enabledAtStartup);
            File.WriteAllText(path, Config(autoReload: enabledAtStartup));
            int notices = 0;
            object config = NewConfig(path, _ => Interlocked.Increment(ref notices));
            try
            {
                object startup = Value(config, "StartupSettings");
                long revision = (long)Value(Snapshot(config), "Revision");
                File.WriteAllText(path, Config(autoReload: !enabledAtStartup));
                Reload(config);
                Check((bool)Value(startup, "ConfigAutoReloadEnabled") == enabledAtStartup &&
                    (bool)Invoke(config, "GetSettingValue", "General", "ConfigAutoReloadEnabled") == !enabledAtStartup,
                    "The toggle must change the saved preference without changing startup state.");
                Check(notices == 1 && (long)Value(Snapshot(config), "Revision") == revision + 1,
                    "A config auto reload toggle must publish one revision and require restart.");
                Reload(config);
                Check(notices == 1 && (long)Value(Snapshot(config), "Revision") == revision + 1,
                    "Reloading the unchanged toggle duplicated its notice or revision.");
                UiSet(config, "SetModLogGroups", "mod.fixture", Groups(4));
                Check(Allows(Snapshot(config), "mod.fixture", LogLevel.Info) && notices == 1 &&
                    ReferenceEquals(startup, Value(config, "StartupSettings")),
                    "Live logging must remain independent of the startup-only auto reload toggle.");
                UiSet(config, "SetSettingValue", "General", "ConfigAutoReloadEnabled", enabledAtStartup);
                Check(notices == 1, "Restoring the startup value unnecessarily required another restart.");
            }
            finally { DisposeConfig(config); }
        }
    }
    private static void ReportBoundarySnapshots()
    {
        string path = PathFor("report-boundaries");
        File.WriteAllText(path, Config("mod.fixture = Warnings\n"));
        object config = NewConfig(path);
        FieldInfo configurationField = T("LoadTimeProfilerPatcher").GetField("_configuration", Any);
        object previousConfig = configurationField.GetValue(null);
        try
        {
            configurationField.SetValue(null, config);
            object atStart = Snapshot(config);
            string startHooks = (string)Call("LogFiltering", "DescribeHooks");
            object session = Activator.CreateInstance(T("TimelineProfiler+SessionState"), Any, null,
                new[] { Enum.Parse(T("ProfileSession"), "Connection"), (object)"report snapshot fixture" }, null);
            Invoke(session, "Begin", 100d, null, null, null);

            File.WriteAllText(path, Config("mod.fixture = Information\n"));
            Reload(config);
            object atEnd = Snapshot(config);
            string endHooks = (string)Call("LogFiltering", "DescribeHooks");
            object report = Invoke(session, "Complete", 150d, "fixture complete");

            File.WriteAllText(path, Config("mod.fixture = None\n"));
            Reload(config);
            object latest = Snapshot(config);
            object reportStart = Value(report, "StartSettings");
            object reportEnd = Value(report, "EndSettings");
            long startRevision = Convert.ToInt64(Value(atStart, "Revision"));
            long endRevision = Convert.ToInt64(Value(atEnd, "Revision"));
            long latestRevision = Convert.ToInt64(Value(latest, "Revision"));
            Check(startRevision < endRevision && endRevision < latestRevision, "Fixture edits did not create three distinct semantic settings revisions.");
            Check(Convert.ToInt64(Value(reportStart, "Revision")) == startRevision &&
                  Convert.ToInt64(Value(reportEnd, "Revision")) == endRevision,
                "The completed report reads current settings instead of its boundary revisions.");
            Check(Allows(reportStart, "mod.fixture", LogLevel.Warning) && !Allows(reportStart, "mod.fixture", LogLevel.Info) &&
                  Allows(reportEnd, "mod.fixture", LogLevel.Info) && !Allows(reportEnd, "mod.fixture", LogLevel.Debug),
                "A later reload changed the report's captured start or end logging policy.");
            Check((string)Value(Value(reportStart, "Logging"), "Description") == (string)Value(Value(atStart, "Logging"), "Description") &&
                  (string)Value(Value(reportEnd, "Logging"), "Description") == (string)Value(Value(atEnd, "Logging"), "Description"),
                "The report lost the policy descriptions captured at its boundaries.");
            Check((string)Value(report, "StartHooks") == startHooks && (string)Value(report, "EndHooks") == endHooks,
                "The report's hook metadata changed after completion.");
        }
        finally
        {
            configurationField.SetValue(null, previousConfig);
            DisposeConfig(config);
        }
    }
    private static void SnapshotConcurrency()
    {
        string path = PathFor("snapshot-concurrency");
        string left = Config("Left = Information\nRight = None\n");
        string right = Config("Left = None\nRight = Information\n");
        File.WriteAllText(path, left);
        object config = NewConfig(path);
        int stop = 0;
        int reads = 0;
        var started = new CountdownEvent(4);
        var begin = new ManualResetEventSlim(false);
        Task[] readers = Enumerable.Range(0, 4).Select(_ => Task.Run(() =>
        {
            started.Signal();
            begin.Wait();
            while (Volatile.Read(ref stop) == 0)
            {
                object snapshot = Snapshot(config);
                Check(Allows(snapshot, "Left", LogLevel.Info) != Allows(snapshot, "Right", LogLevel.Info), "A reader observed mixed configuration generations.");
                Interlocked.Increment(ref reads);
            }
        })).ToArray();
        try
        {
            Check(started.Wait(3000), "Snapshot readers did not start.");
            begin.Set();
            Check(WaitUntil(() => Volatile.Read(ref reads) > 0), "Snapshot reader assertions did not execute.");
            for (int i = 0; i < 40; i++) { File.WriteAllText(path, (i & 1) == 0 ? right : left); Reload(config); }
        }
        finally
        {
            Volatile.Write(ref stop, 1);
            begin.Set();
            try { Task.WaitAll(readers); }
            finally { DisposeConfig(config); started.Dispose(); begin.Dispose(); }
        }
    }

    private static void ReplacementSave()
    {
        string path = PathFor("replacement-save");
        string replacement = PathFor("replacement-save-edit");
        File.WriteAllText(path, Config());
        object config = NewConfig(path);
        try
        {
            Check(Allows(Snapshot(config), "Replaced", LogLevel.Warning), "Replacement fixture must begin with warnings enabled.");
            string changed = "# editor replacement save\n" + Config("Replaced = None\n");
            File.WriteAllText(replacement, changed);
            File.Replace(replacement, path, null);
            Check(WaitUntil(() => !Allows(Snapshot(config), "Replaced", LogLevel.Warning), 5000), "Automatic reload missed an atomic replacement save.");
            Check(File.ReadAllText(path) == changed, "Reload changed the replacement file.");
        }
        finally { DisposeConfig(config); }
    }
    private static void DeletedConfiguration()
    {
        string path = PathFor("deleted-recreated");
        File.WriteAllText(path, Config());
        object config = NewConfig(path);
        try
        {
            object previous = Snapshot(config);
            File.Delete(path);
            Check(!(bool)Invoke(config, "ReloadNow") && ReferenceEquals(previous, Snapshot(config)), "Missing configuration discarded the last valid snapshot.");
            File.WriteAllText(path, Config("mod.fixture = Errors, Warnings, Information, Debug\n"));
            Check(WaitUntil(() => Allows(Snapshot(config), "mod.fixture", LogLevel.Info), 5000), "Automatic reload did not resume after recreation.");
        }
        finally { DisposeConfig(config); }
    }
    private static void InvalidFileBytes()
    {
        string path = PathFor("invalid-bytes");
        File.WriteAllText(path, Config());
        object config = NewConfig(path);
        try
        {
            object previous = Snapshot(config);
            File.WriteAllBytes(path, new byte[] { 0xc3, 0x28 });
            Check(!(bool)Invoke(config, "ReloadNow") && ReferenceEquals(previous, Snapshot(config)), "Malformed UTF-8 replaced the valid settings.");
            File.WriteAllBytes(path, new byte[256 * 1024 + 1]);
            Check(!(bool)Invoke(config, "ReloadNow") && ReferenceEquals(previous, Snapshot(config)), "An oversized file replaced the valid settings.");
        }
        finally { DisposeConfig(config); }
        string initialPath = PathFor("invalid-initial-bytes");
        File.WriteAllBytes(initialPath, new byte[] { 0xc3, 0x28 });
        object initiallyUnreadable = NewConfig(initialPath);
        try
        {
            Check(Allows(Snapshot(initiallyUnreadable), "mod.invalid", LogLevel.Debug),
                "An unreadable initial document no longer preserves logging through fail-open behavior.");
            File.WriteAllText(initialPath, "[General]\nProfilingEnabled = invalid\n[Logging.Mods]\nmod.invalid = Bogus\nmod.valid = Information\n");
            Reload(initiallyUnreadable);
            Check((bool)Value(Snapshot(initiallyUnreadable), "ProfilingEnabled") &&
                Equals(Invoke(initiallyUnreadable, "GetModLogGroups", "mod.invalid"), Groups(3)) &&
                Equals(Invoke(initiallyUnreadable, "GetModLogGroups", "mod.valid"), Groups(4)),
                "A readable document inherited synthetic fail-open groups instead of per-entry defaults after initial read failure.");
        }
        finally { DisposeConfig(initiallyUnreadable); }
    }
    private static void DisposedConfiguration()
    {
        string path = PathFor("disposed");
        File.WriteAllText(path, Config());
        object config = NewConfig(path);
        object previous = Snapshot(config);
        DisposeConfig(config);
        File.WriteAllText(path, Config("mod.fixture = Errors, Warnings, Information, Debug\n"));
        Check(!(bool)Invoke(config, "ReloadNow"), "Disposed configuration accepted an explicit reload.");
        Thread.Sleep(1200); // More than the normal two-sample polling interval.
        Check(ReferenceEquals(previous, Snapshot(config)), "Disposed configuration published a later timer snapshot.");
    }

    private static void InstallFilter(string contents)
    {
        TryDisposeFilter();
        livePath = PathFor("live-" + Guid.NewGuid().ToString("N"));
        File.WriteAllText(livePath, contents);
        ownedLiveConfig = NewConfig(livePath);
        Call("LogFiltering", "Install", ownedLiveConfig);
    }
    private static object LiveConfig() => T("LogFiltering").GetField("_config", Any).GetValue(null);
    private static void UpdateFilter(string contents)
    {
        File.WriteAllText(livePath, contents);
        Reload(LiveConfig());
    }
    private static void TryDisposeFilter()
    {
        try { if (product != null) Call("LogFiltering", "Dispose"); }
        finally
        {
            if (ownedLiveConfig != null) DisposeConfig(ownedLiveConfig);
            ownedLiveConfig = null;
        }
    }
    private static void ManualEarlyDrop()
    {
        InstallFilter(Config());
        int events = 0;
        using (var source = Owned("Mod"))
        {
            source.LogEvent += (_, args) => { Interlocked.Increment(ref events); args.Data.ToString(); };
            var payload = new PoisonPayload();
            source.LogInfo(payload);
            source.LogDebug(payload);
            source.LogMessage(payload);
            Check(events == 0 && payload.Calls == 0, "Dropped log reached a listener or formatted its payload.");
        }
    }
    private static void ManualPayloadIdentity()
    {
        InstallFilter(Config());
        using (var source = Owned("Identity"))
        {
            object payload = new object();
            int events = 0;
            source.LogEvent += (sender, args) =>
            {
                events++;
                Check(ReferenceEquals(sender, source) && ReferenceEquals(args.Source, source), "The source identity changed.");
                Check(ReferenceEquals(args.Data, payload) && args.Level == LogLevel.Warning, "The payload or severity changed.");
            };
            source.LogWarning(payload);
            Check(events == 1, "An allowed log was dropped or duplicated.");
        }
    }
    private static void SeverityMasks()
    {
        InstallFilter(Config());
        var seen = new List<LogLevel>();
        using (var source = Owned("Mod"))
        {
            source.LogEvent += (_, args) => seen.Add(args.Level);
            foreach (LogLevel level in new[] { LogLevel.Fatal, LogLevel.Error, LogLevel.Warning, LogLevel.Message, LogLevel.Info, LogLevel.Debug }) source.Log(level, "fixture");
        }
        Check(seen.SequenceEqual(new[] { LogLevel.Fatal, LogLevel.Error, LogLevel.Warning }), "Default severity filtering changed.");
    }
    private static void RuntimeReload()
    {
        InstallFilter(Config("org.exact = Errors, Warnings\n"));
        using (var exact = new ManualLogSource("Same display name"))
        using (var other = new ManualLogSource("Same display name"))
        using (var unattributed = new ManualLogSource("Same display name"))
        {
            Bind(exact, "org.exact");
            Bind(other, "org.other");
            int exactCount = 0, otherCount = 0, unattributedCount = 0;
            exact.LogEvent += (_, args) => exactCount++;
            other.LogEvent += (_, args) => otherCount++;
            unattributed.LogEvent += (_, args) => unattributedCount++;
            exact.LogInfo("before");
            UpdateFilter(Config("org.exact = Information\n"));
            exact.LogInfo("after");
            other.LogInfo("unknown GUID uses errors/warnings");
            unattributed.LogInfo("unattributed always passes");
            Check(exactCount == 1 && otherCount == 0 && unattributedCount == 1,
                "Object/GUID mapping conflated same-name loggers or ignored policy reload.");
        }
    }

    private static void AutomaticReload()
    {
        InstallFilter(Config());
        using (var source = Owned("Watched", "org.watched"))
        {
            File.WriteAllText(livePath, Config("org.watched = Information\n"));
            Check(WaitUntil(() => (bool)Call("LogFiltering", "Allows", source, LogLevel.Info), 5000),
                "External GUID edit was not automatically applied within five seconds.");
        }
    }

    private static void OwnershipDisposal()
    {
        using (var source = new ManualLogSource("persistent fixture"))
        {
            InstallFilter(Config("org.fixture = None\n"));
            Bind(source, "org.fixture");
            Check(!(bool)Call("LogFiltering", "Allows", source, LogLevel.Info), "Registered policy did not apply.");
            TryDisposeFilter();
            InstallFilter(Config("org.fixture = None\n"));
            Check((bool)Call("LogFiltering", "Allows", source, LogLevel.Info), "A disposed registration survived into a new filter lifetime.");
        }
    }

    private static void LoggingConcurrency()
    {
        InstallFilter(Config());
        int warnings = 0, information = 0;
        int attempts = 0, stop = 0;
        using (var source = Owned("Concurrent"))
        using (var started = new CountdownEvent(4))
        using (var begin = new ManualResetEventSlim(false))
        {
            source.LogEvent += (_, args) =>
            {
                if (args.Level == LogLevel.Warning) Interlocked.Increment(ref warnings);
                else if (args.Level == LogLevel.Info) Interlocked.Increment(ref information);
                else throw new InvalidOperationException("Unexpected level during concurrent logging.");
            };
            Task[] workers = Enumerable.Range(0, 4).Select(_ => Task.Run(() =>
            {
                started.Signal();
                begin.Wait();
                while (Volatile.Read(ref stop) == 0)
                {
                    Interlocked.Increment(ref attempts);
                    source.LogWarning("required");
                    source.LogInfo("optional");
                    Thread.Yield();
                }
            })).ToArray();
            try
            {
                Check(started.Wait(3000), "Logging workers did not start.");
                begin.Set();
                Check(WaitUntil(() => Volatile.Read(ref warnings) > 0), "Concurrent log assertions did not execute.");
                for (int i = 0; i < 20; i++) UpdateFilter(Config((i & 1) == 0 ? "mod.fixture = Errors, Warnings, Information, Debug\n" : ""));
            }
            finally { Volatile.Write(ref stop, 1); begin.Set(); Task.WaitAll(workers); }
        }
        Check(attempts > 0 && warnings == attempts && information >= 0 && information <= attempts, "Concurrent filtering lost or duplicated events.");
    }
    private static void AllGroupsPassThrough()
    {
        InstallFilter(Config("mod.fixture = Errors, Warnings, Information, Debug\n"));
        int events = 0;
        using (var source = Owned("Mod"))
        {
            source.LogEvent += (_, args) => events++;
            foreach (LogLevel level in new[] { LogLevel.Fatal, LogLevel.Error, LogLevel.Warning, LogLevel.Message, LogLevel.Info, LogLevel.Debug, LogLevel.None, (LogLevel)64 }) source.Log(level, "fixture");
        }
        Check(events == 8, "Selecting all groups suppressed a known, None, or unknown event.");
    }


    private static void UnownedPassThrough()
    {
        InstallFilter(Config("org.bound = None\n"));
        PropertyInfo diagnostics = T("LoadTimeProfilerPatcher").GetProperty("Log", Any);
        object previous = diagnostics.GetValue(null);
        var source = new ManualLogSource("LoadTimeProfiler");
        diagnostics.SetValue(null, source);
        int own = 0, unowned = 0, bound = 0;
        EventHandler<LogEventArgs> handler = (_, args) => own++;
        source.LogEvent += handler;
        try
        {
            using (var sameName = new ManualLogSource(source.SourceName))
            using (var attributed = Owned(source.SourceName, "org.bound"))
            {
                sameName.LogEvent += (_, args) => unowned++;
                attributed.LogEvent += (_, args) => bound++;
                foreach (LogLevel level in new[] { LogLevel.Info, LogLevel.Debug, LogLevel.None, (LogLevel)64 })
                {
                    source.Log(level, "diagnostic");
                    sameName.Log(level, "unowned same-name source");
                    attributed.Log(level, "bound source remains filtered");
                }
            }
        }
        finally { source.LogEvent -= handler; diagnostics.SetValue(null, previous); source.Dispose(); }
        Check(own == 4 && unowned == 4 && bound == 0, "Diagnostics/unowned pass-through or known-mod filtering changed.");
    }

    private static void DisposeIsolation()
    {
        InstallFilter(Config());
        MethodInfo target = typeof(ManualLogSource).GetMethod("Log", new[] { typeof(LogLevel), typeof(object) });
        var foreign = new Harmony("loadtimeprofiler.tests.foreign");
        foreign.Patch(target, prefix: new HarmonyMethod(typeof(LogFilteringTests).GetMethod("ForeignPrefix", Any)));
        try
        {
            TryDisposeFilter();
            Check(Harmony.GetPatchInfo(target).Owners.Contains(foreign.Id), "Disposal removed another owner's patch.");
            int count = 0;
            foreignCalls = 0;
            using (var source = Owned("Mod"))
            {
                source.LogEvent += (_, args) => count++;
                source.LogInfo("restored");
            }
            Check(count == 1 && foreignCalls == 1, "Disposal did not restore the original log pipeline.");
        }
        finally { foreign.UnpatchSelf(); }
    }
    private static void SharedConfigurationLifetime()
    {
        InstallFilter(Config());
        object config = ownedLiveConfig;
        Call("LogFiltering", "Dispose");
        File.WriteAllText(livePath, Config("mod.fixture = Errors, Warnings, Information, Debug\n"));
        Reload(config);
        Check(Allows(Snapshot(config), "mod.fixture", LogLevel.Info), "Filter disposal also disposed the configuration shared with other features.");
        TryDisposeFilter();
    }
    private static void ForeignPrefix() => Interlocked.Increment(ref foreignCalls);
    private sealed class PoisonPayload
    {
        internal int Calls;
        public override string ToString() { Interlocked.Increment(ref Calls); throw new InvalidOperationException("A dropped payload was formatted."); }
    }

    // Equivalent managed ManualLogSource predicate observed in ShutUp.dll:
    // logLevel.TryGetValue(new StackFrame(3).GetMethod().DeclaringType.Assembly,
    // out ConfigEntry<LogLevel> entry) ? (entry.Value & level) > 0 : true.
    // This reproduces that predicate; it neither loads nor benchmarks the mod.
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool StackFramePrefix(ManualLogSource __instance, LogLevel level)
    {
        ConfigEntry<LogLevel> entry;
        return !((Dictionary<Assembly, ConfigEntry<LogLevel>>)stackLevels).TryGetValue(
            new StackFrame(3).GetMethod().DeclaringType.Assembly, out entry) || (entry.Value & level) != 0;
    }
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool PrefixRoute(Func<ManualLogSource, LogLevel, bool> prefix, ManualLogSource source, LogLevel level) => PrefixLevelOne(prefix, source, level);
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool PrefixLevelOne(Func<ManualLogSource, LogLevel, bool> prefix, ManualLogSource source, LogLevel level) => PrefixLevelTwo(prefix, source, level);
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool PrefixLevelTwo(Func<ManualLogSource, LogLevel, bool> prefix, ManualLogSource source, LogLevel level) => prefix(source, level);
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void PipelineRoute(ManualLogSource source, LogLevel level) => PipelineCall(source, level);
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void PipelineCall(ManualLogSource source, LogLevel level) => source.Log(level, "prebuilt benchmark payload");

    private static void Benchmark(int iterations)
    {
        Console.WriteLine("BENCHMARK: managed CLR microbenchmark; no disk/console listener I/O, no caller string construction, no Unity, and no full-mod startup measurement.");
        Console.WriteLine("Baseline is the reproduced ShutUp StackFrame(3) predicate, not execution of ShutUp.dll.");
        var fixtureConfig = new ConfigFile(PathFor("benchmark-levels"), false) { SaveOnConfigSet = false };
        ConfigEntry<LogLevel> entry = fixtureConfig.Bind("Benchmark", "Levels", LogLevel.Warning | LogLevel.Error | LogLevel.Fatal, "fixture only");
        stackLevels = new Dictionary<Assembly, ConfigEntry<LogLevel>> { [typeof(LogFilteringTests).Assembly] = entry };
        InstallFilter(Config());
        DisposeConfig(LiveConfig()); // Freeze the benchmark snapshot and stop unrelated timer allocation.
        var modern = (Func<ManualLogSource, LogLevel, bool>)T("LogFiltering").GetMethod("ManualLogPrefix", Any)
            .CreateDelegate(typeof(Func<ManualLogSource, LogLevel, bool>));
        Func<ManualLogSource, LogLevel, bool> baseline = StackFramePrefix;
        MethodInfo allocationMethod = typeof(GC).GetMethod("GetAllocatedBytesForCurrentThread", BindingFlags.Public | BindingFlags.Static);
        Func<long> allocated;
        if (allocationMethod != null) allocated = (Func<long>)allocationMethod.CreateDelegate(typeof(Func<long>));
        else
        {
            AppDomain.MonitoringIsEnabled = true;
            allocated = () => AppDomain.CurrentDomain.MonitoringTotalAllocatedMemorySize;
        }
        Console.WriteLine("Allocation metric: " + (allocationMethod != null ? "current-thread allocated bytes" : "AppDomain allocated bytes; no active fixture workers/timers") + ". Five trials, " + iterations + " operations each; median shown.");
        using (var source = Owned("Benchmark"))
        {
            using (var unowned = new ManualLogSource("Benchmark unowned"))
            {
                int unownedEvents = 0;
                unowned.LogEvent += (_, args) => unownedEvents++;
                PipelineRoute(unowned, LogLevel.Info);
                Check(unownedEvents == 1, "Unowned benchmark message was filtered.");
                Measurement unownedPredicate = Measure(() => PrefixRoute(modern, unowned, LogLevel.Info), allocated, iterations);
                Measurement unownedPipeline = Measure(() => { PipelineRoute(unowned, LogLevel.Info); return true; }, allocated, iterations);
                Console.WriteLine(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    "unowned ManualLogSource Info: predicate {0:F1} ns/op, {1:F1} B/op; patched pipeline {2:F1} ns/op, {3:F1} B/op",
                    unownedPredicate.Nanoseconds, unownedPredicate.Bytes, unownedPipeline.Nanoseconds, unownedPipeline.Bytes));
            }
            int delivered = 0;
            source.LogEvent += (_, args) => delivered++;
            Check(!PrefixRoute(baseline, source, LogLevel.Info) && PrefixRoute(baseline, source, LogLevel.Warning), "StackFrame baseline did not resolve the fixture caller assembly.");
            Check(!PrefixRoute(modern, source, LogLevel.Info) && PrefixRoute(modern, source, LogLevel.Warning), "LoadTimeProfiler benchmark policy differs from the baseline.");
            foreach (LogLevel level in new[] { LogLevel.Info, LogLevel.Warning })
            {
                string disposition = level == LogLevel.Info ? "drop" : "allow";
                PrintPair("predicate " + disposition,
                    Measure(() => PrefixRoute(baseline, source, level), allocated, iterations),
                    Measure(() => PrefixRoute(modern, source, level), allocated, iterations));
            }
            var newPipeline = new Dictionary<LogLevel, Measurement>();
            foreach (LogLevel level in new[] { LogLevel.Info, LogLevel.Warning })
                newPipeline[level] = Measure(() => { PipelineRoute(source, level); return true; }, allocated, iterations);
            TryDisposeFilter();
            int unpatchedBefore = delivered;
            PipelineRoute(source, LogLevel.Info);
            PipelineRoute(source, LogLevel.Warning);
            Check(delivered == unpatchedBefore + 2, "Unpatched benchmark did not deliver both severity levels.");
            foreach (LogLevel level in new[] { LogLevel.Info, LogLevel.Warning })
            {
                Measurement unpatched = Measure(() => { PipelineRoute(source, level); return true; }, allocated, iterations);
                Console.WriteLine(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    "unpatched ManualLogSource {0} (delivered): {1:F1} ns/op, {2:F1} B/op",
                    level, unpatched.Nanoseconds, unpatched.Bytes));
            }
            var oldHarmony = new Harmony("loadtimeprofiler.tests.stackframe-benchmark");
            MethodInfo target = typeof(ManualLogSource).GetMethod("Log", new[] { typeof(LogLevel), typeof(object) });
            oldHarmony.Patch(target, prefix: new HarmonyMethod(typeof(LogFilteringTests).GetMethod("StackFramePrefix", Any)));
            try
            {
                int before = delivered;
                PipelineRoute(source, LogLevel.Info);
                Check(delivered == before, "Patched StackFrame benchmark did not filter the fixture caller.");
                PipelineRoute(source, LogLevel.Warning);
                Check(delivered == before + 1, "Patched StackFrame benchmark dropped the allowed fixture event.");
                foreach (LogLevel level in new[] { LogLevel.Info, LogLevel.Warning })
                    PrintPair("patched ManualLogSource " + (level == LogLevel.Info ? "drop" : "allow"),
                        Measure(() => { PipelineRoute(source, level); return true; }, allocated, iterations), newPipeline[level]);
            }
            finally { oldHarmony.UnpatchSelf(); }
        }
        Console.WriteLine("Results describe these managed paths only; game-time savings and Mono/Unity allocation behavior require a game benchmark.");
    }
    private sealed class Measurement { internal double Nanoseconds; internal double Bytes; }
    private static Measurement Measure(Func<bool> operation, Func<long> allocated, int iterations)
    {
        for (int i = 0; i < 2000; i++) operation();
        var times = new List<double>();
        var bytes = new List<double>();
        int accepted = 0;
        for (int trial = 0; trial < 5; trial++)
        {
            GC.Collect(); GC.WaitForPendingFinalizers(); GC.Collect();
            long startBytes = allocated();
            long startTicks = Stopwatch.GetTimestamp();
            for (int i = 0; i < iterations; i++) if (operation()) accepted++;
            long ticks = Stopwatch.GetTimestamp() - startTicks;
            long consumed = allocated() - startBytes;
            times.Add(ticks * 1e9 / Stopwatch.Frequency / iterations);
            bytes.Add((double)consumed / iterations);
        }
        GC.KeepAlive(accepted);
        times.Sort(); bytes.Sort();
        return new Measurement { Nanoseconds = times[2], Bytes = bytes[2] };
    }
    private static void PrintPair(string label, Measurement baseline, Measurement modern) => Console.WriteLine(
        string.Format(System.Globalization.CultureInfo.InvariantCulture,
            "{0}: StackFrame {1:F1} ns/op, {2:F1} B/op; LoadTimeProfiler {3:F1} ns/op, {4:F1} B/op; ratio {5:F2}x",
            label, baseline.Nanoseconds, baseline.Bytes, modern.Nanoseconds, modern.Bytes, baseline.Nanoseconds / modern.Nanoseconds));
}
