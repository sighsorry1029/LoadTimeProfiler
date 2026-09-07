using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using BepInEx.Configuration;
using HarmonyLib;

// Runs production methods through reflection to avoid adding a test API to the mod.
// Unity objects are never constructed, rendered, or passed to native engine methods.
// Adapter fixtures exercise state/replay, not external producer discovery or Unity CSV execution.
internal static class RegressionTests
{
    private const BindingFlags Any = BindingFlags.Public | BindingFlags.NonPublic |
                                     BindingFlags.Static | BindingFlags.Instance;
    private static Assembly product;
    private static string scratch;
    private static int failures;

    private static int Main(string[] args)
    {
        AppDomain.CurrentDomain.AssemblyResolve += (_, request) =>
        {
            string name = new AssemblyName(request.Name).Name;
            if (name == "assembly_valheim")
                return Assembly.LoadFrom(Path.Combine(args[3], "assembly_valheim_publicized.dll"));
            foreach (string directory in new[] { args[1], args[2], args[3] })
            {
                string path = Path.Combine(directory, name + ".dll");
                if (File.Exists(path)) return Assembly.LoadFrom(path);
            }
            return null;
        };
        product = Assembly.LoadFrom(args[0]);
        scratch = args[4];
        InitializePaths();
        Run("automatic saves and repeated cleanup", AutomaticSaves);
        Run("explicit save remains immediate", ExplicitSave);
        Run("stale save completion preserves newer writes", StaleSaveCompletion);
        Run("skipped original preserves pending writes", SkippedSaveCompletion);
        Run("plugin Start instrumentation is installed once", StartInstrumentation);
        Run("unrelated lifecycle exit preserves deep scope", UnrelatedLifecycle);
        Run("nested deep scope preserves outer callback", NestedDeepScope);
        Run("recursive deep scope preserves outer callback", () => AssertNestedScope(DeepTarget));
        Run("mismatched tracked exit still clears corrupt scope", MismatchedDeepScope);
        Run("LocalizeKey exact supported identities", SupportedIdentities);
        Run("LocalizeKey replay, language isolation and invalidation", LocalizeKeyReplay);
        Run("LocalizeKey stale capture and alias bypass", LocalizeKeyMutation);
        System.Console.WriteLine(failures == 0 ? "All 12 regression cases passed." : failures + " regression case(s) failed.");
        System.Console.WriteLine("Unity CSV/native lifecycle and multiplayer behavior require in-game validation.");
        return failures == 0 ? 0 : 1;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void InitializePaths() => typeof(BepInEx.Paths).GetProperty("ConfigPath", Any).SetValue(null, scratch);

    private static void Run(string name, Action test)
    {
        try { test(); System.Console.WriteLine("PASS " + name); }
        catch (Exception ex)
        {
            failures++;
            System.Console.WriteLine("FAIL " + name + ": " + ex.GetBaseException());
        }
    }

    private static Type T(string name) => product.GetType("LoadTimeProfiler." + name, true);
    private static MethodInfo M(Type type, string name)
    {
        for (; type != null; type = type.BaseType)
        {
            MethodInfo method = type.GetMethod(name, Any | BindingFlags.DeclaredOnly);
            if (method != null) return method;
        }
        throw new MissingMethodException(name);
    }
    private static object Call(string type, string method, params object[] args) => M(T(type), method).Invoke(null, args);
    private static object Invoke(object instance, string method, params object[] args) => M(instance.GetType(), method).Invoke(instance, args);
    private static object Field(string type, string name) => T(type).GetField(name, Any).GetValue(null);
    private static void Set(string type, string name, object value) => T(type).GetField(name, Any).SetValue(null, value);
    private static object Property(object instance, string name) => instance.GetType().GetProperty(name, Any).GetValue(instance);
    private static object Create(Type type, params object[] args) => Activator.CreateInstance(type, Any, null, args, null);
    private static void Check(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
    }
    private static void Feature(string name, object value) => Set("LoadTimeProfilerPatcher", "<" + name + ">k__BackingField", value);

    private static ConfigFile BeginConfig(string name)
    {
        Call("StartupAcceleration", "EndChainloader");
        Feature("ConfigWriteCoalescingEnabled", true);
        bool installed = (bool)Call("StartupAcceleration", "InstallConfigHooks");
        Check(installed, "Actual BepInEx config hooks could not be installed.");
        Set("StartupAcceleration", "_boundaryInstalled", true);
        Set("StartupAcceleration", "_configHooksInstalled", true);
        Call("StartupAcceleration", "BeginChainloader");
        return new ConfigFile(Path.Combine(scratch, name + ".cfg"), false);
    }

    private static void AutomaticSaves()
    {
        ConfigFile config = BeginConfig("automatic");
        ConfigEntry<int> entry = config.Bind("Test", "Value", 1, "fixture");
        entry.Value = 2;
        entry.Value = 3;
        Check(!File.Exists(config.ConfigFilePath), "Automatic writes were not deferred.");
        Call("StartupAcceleration", "EndChainloader");
        Check(File.ReadAllText(config.ConfigFilePath).Contains("Value = 3"), "Final value was not flushed.");
        string saved = File.ReadAllText(config.ConfigFilePath) + "\n# repeated cleanup sentinel\n";
        File.WriteAllText(config.ConfigFilePath, saved);
        Call("StartupAcceleration", "EndChainloader");
        Check(File.ReadAllText(config.ConfigFilePath) == saved, "Repeated cleanup wrote the file again.");
    }

    private static void ExplicitSave()
    {
        ConfigFile config = BeginConfig("explicit");
        config.Bind("Test", "Value", 7, "fixture");
        config.Save();
        Check(File.ReadAllText(config.ConfigFilePath).Contains("Value = 7"), "Explicit save was delayed.");
        string saved = File.ReadAllText(config.ConfigFilePath) + "\n# explicit save sentinel\n";
        File.WriteAllText(config.ConfigFilePath, saved);
        Call("StartupAcceleration", "EndChainloader");
        Check(File.ReadAllText(config.ConfigFilePath) == saved, "Already persisted changes were flushed again.");
    }

    private static void StaleSaveCompletion()
    {
        ConfigFile config = BeginConfig("stale");
        ConfigEntry<int> entry = config.Bind("Test", "Value", 1, "fixture");
        object[] before = { config, null };
        Call("StartupAcceleration", "BeforeConfigSave", before);
        entry.Value = 9;
        Call("StartupAcceleration", "ConfigSaveCompleted", config, true, before[1]);
        Call("StartupAcceleration", "EndChainloader");
        Check(File.ReadAllText(config.ConfigFilePath).Contains("Value = 9"), "An old completion discarded a newer write.");
    }

    private static void SkippedSaveCompletion()
    {
        ConfigFile config = BeginConfig("skipped");
        config.Bind("Test", "Value", 4, "fixture");
        object[] before = { config, null };
        Call("StartupAcceleration", "BeforeConfigSave", before);
        Call("StartupAcceleration", "ConfigSaveCompleted", config, false, before[1]);
        Call("StartupAcceleration", "EndChainloader");
        Check(File.ReadAllText(config.ConfigFilePath).Contains("Value = 4"), "Skipped original cleared pending data.");
    }

    private static void StartInstrumentation()
    {
        object identity = Create(T("ChainloaderProfiler+PluginIdentity"), "fixture", "Fixture");
        Call("ChainloaderProfiler", "InstrumentStart", typeof(StartFixture), identity);
        Call("ChainloaderProfiler", "InstrumentStart", typeof(StartFixture), identity);
        Call("ChainloaderProfiler", "ResetSession");
        Call("ChainloaderProfiler", "InstrumentStart", typeof(StartFixture), identity);
        Patches patches = Harmony.GetPatchInfo(typeof(StartFixture).GetMethod("Start"));
        Check(patches != null && patches.Prefixes.Count == 1 && patches.Finalizers.Count == 1,
            "Duplicate discovery/session reset changed patch count.");
    }

    private static MethodInfo DeepTarget => typeof(ObjectDB).GetMethod("Awake", Any);
    private static MethodInfo InnerTarget => typeof(ZNetScene).GetMethod("Awake", Any);
    private static void BeginDeep()
    {
        Feature("ProfilingEnabled", true);
        Feature("IsDedicatedServer", false);
        Call("TimelineProfiler", "BeginConnection", "regression fixture", true);
        Call("DeepLobbyAttributionProfiler", "BeginTarget", DeepTarget);
    }
    private static int StackCount(string name) => ((ICollection)Field("DeepLobbyAttributionProfiler", name))?.Count ?? 0;
    private static object BeginCallback()
    {
        MethodInfo callback = typeof(RegressionTests).GetMethod("CallbackFixture", Any);
        object identity = Create(T("DeepLobbyAttributionProfiler+PluginIdentity"), "fixture", "Fixture");
        ((IDictionary)Field("DeepLobbyAttributionProfiler", "CallbackOwners"))[callback] = identity;
        object[] args = { callback, null };
        Call("DeepLobbyAttributionProfiler", "ProfiledCallbackPrefix", args);
        Check(args[1] != null, "Callback capture did not begin.");
        return args[1];
    }

    private static void UnrelatedLifecycle()
    {
        BeginDeep();
        object callback = BeginCallback();
        Call("DeepLobbyAttributionProfiler", "EndTarget", typeof(Game).GetMethod("RequestRespawn", Any));
        Check(StackCount("_activePhases") == 1 && StackCount("_activeCallbacks") == 1,
            "An unrelated lifecycle exit erased its enclosing deep scope.");
        Call("DeepLobbyAttributionProfiler", "ProfiledCallbackFinalizer", callback, null);
        Call("DeepLobbyAttributionProfiler", "EndTarget", DeepTarget);
        Check(StackCount("_activeCallbacks") == 0 && StackCount("_activePhases") == 0, "Scope did not close.");
    }

    private static void NestedDeepScope() => AssertNestedScope(InnerTarget);

    private static void AssertNestedScope(MethodBase nestedTarget)
    {
        BeginDeep();
        object outer = BeginCallback();
        Call("DeepLobbyAttributionProfiler", "BeginTarget", nestedTarget);
        object inner = BeginCallback();
        Call("DeepLobbyAttributionProfiler", "ProfiledCallbackFinalizer", inner, null);
        Call("DeepLobbyAttributionProfiler", "EndTarget", nestedTarget);
        Check(StackCount("_activeCallbacks") == 1 && StackCount("_activePhases") == 1,
            "Nested phase completion erased a still-running outer callback.");
        long previousChildTicks = (long)Property(outer, "ChildTicks");
        object subsequentChild = BeginCallback();
        System.Threading.Thread.SpinWait(1000);
        Call("DeepLobbyAttributionProfiler", "ProfiledCallbackFinalizer", subsequentChild, null);
        Check((long)Property(outer, "ChildTicks") > previousChildTicks,
            "A later child callback no longer contributes to the parent's exclusive-time accounting.");
        Exception original = new InvalidOperationException("fixture exception");
        Check(ReferenceEquals(Call("DeepLobbyAttributionProfiler", "ProfiledCallbackFinalizer", outer, original), original),
            "Callback finalizer changed the original exception.");
        Call("DeepLobbyAttributionProfiler", "EndTarget", DeepTarget);
        Check(StackCount("_activeCallbacks") == 0 && StackCount("_activePhases") == 0, "Nested scopes leaked.");
    }

    private static void MismatchedDeepScope()
    {
        BeginDeep();
        BeginCallback();
        Call("DeepLobbyAttributionProfiler", "EndTarget", InnerTarget);
        Check(StackCount("_activeCallbacks") == 0 && StackCount("_activePhases") == 0,
            "Mismatched tracked targets no longer clear corrupt state.");
    }

    private static void SupportedIdentities()
    {
        string[] names = { "ItemManager.LocalizeKey", "PieceManager.LocalizeKey", "CreatureManager.LocalizeKey",
            "StatusEffectManager.LocalizeKey", "SkillManager.Skill+LocalizeKey" };
        ModuleBuilder module = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("IdentityFixtures"), AssemblyBuilderAccess.Run)
            .DefineDynamicModule("main");
        foreach (string name in names.Concat(new[] { "itemmanager.LocalizeKey", "Other.LocalizeKey", "SkillManager.LocalizeKey" }))
        {
            Type fixture;
            int separator = name.IndexOf('+');
            if (separator >= 0)
            {
                TypeBuilder outer = module.DefineType(name.Substring(0, separator), TypeAttributes.Public);
                TypeBuilder nested = outer.DefineNestedType(name.Substring(separator + 1), TypeAttributes.NestedPublic);
                outer.CreateType();
                fixture = nested.CreateType();
            }
            else fixture = module.DefineType(name, TypeAttributes.Public).CreateType();
            bool accepted = (bool)M(T("LocalizeKeyLocalizationAdapter"), "IsKnownManagerLocalizeKey").Invoke(null, new object[] { fixture });
            Check(accepted == names.Contains(name), "Identity policy changed for " + name);
        }
    }

    private static Localization NewLocalization()
    {
        var instance = (Localization)FormatterServices.GetUninitializedObject(typeof(Localization));
        typeof(Localization).GetField("m_translations", Any).SetValue(instance, new Dictionary<string, string>());
        return instance;
    }
    private static Dictionary<string, string> Words(Localization instance) =>
        (Dictionary<string, string>)typeof(Localization).GetField("m_translations", Any).GetValue(instance);
    private static object NewAdapter()
    {
        Feature("LocalizationCacheEnabled", true);
        Set("LocalizationAcceleration", "_installed", true);
        Set("LocalizationAcceleration", "_directReplaySafety", 1);
        Set("LocalizationAdapterRegistry", "_startupScopeActive", true);
        KeyFixture.Keys.Clear();
        return Create(T("LocalizeKeyLocalizationAdapter"), typeof(RegressionTests).GetMethod("CallbackFixture", Any),
            new MethodBase[0], typeof(KeyFixture).GetField("Keys"), typeof(KeyFixture).GetField("Localizations"));
    }
    private static object Capture(object adapter, Localization instance, string language)
    {
        object[] args = { instance, language, null };
        Check((bool)Invoke(adapter, "Before", args) && args[2] != null, "Expected an original producer capture.");
        return args[2];
    }
    private static void CompleteCapture(object adapter, object state, string value)
    {
        ((IList)Property(state, "Writes")).Add(Create(T("LocalizationAcceleration+WriteOperation"), "fixture", value));
        Invoke(adapter, "Complete", state, true);
    }

    private static void LocalizeKeyReplay()
    {
        object adapter = NewAdapter();
        Localization instance = NewLocalization();
        CompleteCapture(adapter, Capture(adapter, instance, "English"), "hello");
        CompleteCapture(adapter, Capture(adapter, instance, "Korean"), "annyeong");
        foreach (string language in new[] { "English", "Korean" })
        {
            object[] args = { instance, language, null };
            Check(!(bool)Invoke(adapter, "Before", args), "Cached producer was not replayed.");
            Check(Words(instance)["fixture"] == (language == "English" ? "hello" : "annyeong"), "Language caches mixed.");
        }
        Invoke(adapter, "ClearStartupCache");
        Capture(adapter, instance, "English");
        Set("LocalizationAdapterRegistry", "_startupScopeActive", false);
        object[] closed = { instance, "English", null };
        Check((bool)Invoke(adapter, "Before", closed) && closed[2] == null, "Closed startup scope still captures.");
    }

    private static void LocalizeKeyMutation()
    {
        object adapter = NewAdapter();
        Localization instance = NewLocalization();
        object old = Capture(adapter, instance, "English");
        Invoke(adapter, "Invalidate");
        CompleteCapture(adapter, old, "stale");
        object current = Capture(adapter, instance, "English");
        CompleteCapture(adapter, current, "current");
        KeyFixture.Keys.Add(new KeyFixture());
        KeyFixture.Keys[0].Localizations["alias"] = "other";
        Invoke(adapter, "Invalidate");
        object[] alias = { instance, "English", null };
        Check((bool)Invoke(adapter, "Before", alias) && alias[2] == null, "Alias generation was cached.");
        Invoke(adapter, "ClearStartupCache");
        alias[2] = null;
        Check((bool)Invoke(adapter, "Before", alias) && alias[2] == null, "Cache cleanup forgot the active alias policy.");
        KeyFixture.Keys[0].Localizations.Remove("alias");
        Invoke(adapter, "Invalidate");
        Capture(adapter, instance, "English");
    }

    public sealed class StartFixture { [MethodImpl(MethodImplOptions.NoInlining)] public void Start() { } }
    public sealed class KeyFixture
    {
        public static List<KeyFixture> Keys = new List<KeyFixture>();
        public Dictionary<string, string> Localizations = new Dictionary<string, string>();
    }
    [MethodImpl(MethodImplOptions.NoInlining)] private static void CallbackFixture() { }
}
