using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
using BepInEx.Logging;
using BepInEx.Preloader;
using HarmonyLib;
using HarmonyLib.Public.Patching;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace StartupAccelerator;

public static class StartupAccelerator
{
	private enum Toggle
	{
		On,
		Off
	}

	[HarmonyPatch]
	private static class Patch_Preloader_PatchEntrypoint
	{
		private static readonly MethodInfo ChainloaderFinishedCallInstructionAdder = AccessTools.DeclaredMethod(typeof(Patch_Preloader_PatchEntrypoint), "AddChainloaderFinishedCall");

		private static readonly MethodInfo ChainloaderStart = AccessTools.DeclaredMethod(typeof(Patch_Preloader_PatchEntrypoint), "PreChainloader");

		private static readonly MethodInfo ILInstructionInserter = AccessTools.DeclaredMethod(typeof(ILProcessor), "InsertBefore");

		private static bool patched = false;

		private static IEnumerable<MethodInfo> TargetMethods()
		{
			return new MethodInfo[1] { AccessTools.DeclaredMethod(typeof(EnvVars).Assembly.GetType("BepInEx.Preloader.Preloader"), "PatchEntrypoint") };
		}

		private static void AddChainloaderFinishedCall(ILProcessor ilProcessor, Instruction instruction, AssemblyDefinition assembly)
		{
			ilProcessor.InsertBefore(instruction, ilProcessor.Create(Mono.Cecil.Cil.OpCodes.Call, assembly.MainModule.ImportReference(ChainloaderStart)));
		}

		private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
		{
			bool foundInitMethod = false;
			foreach (CodeInstruction instruction in instructions)
			{
				yield return instruction;
				if (instruction.opcode == System.Reflection.Emit.OpCodes.Ldloc_S && instruction.operand is LocalBuilder localBuilder && localBuilder.LocalIndex == 6)
				{
					foundInitMethod = true;
				}
				else if (foundInitMethod && instruction.Calls(ILInstructionInserter))
				{
					yield return new CodeInstruction(System.Reflection.Emit.OpCodes.Ldloc_S, 11);
					yield return new CodeInstruction(System.Reflection.Emit.OpCodes.Ldloc_S, 12);
					yield return new CodeInstruction(System.Reflection.Emit.OpCodes.Ldarg_0);
					yield return new CodeInstruction(System.Reflection.Emit.OpCodes.Ldind_Ref);
					yield return new CodeInstruction(System.Reflection.Emit.OpCodes.Call, ChainloaderFinishedCallInstructionAdder);
				}
			}
		}

		private static void PreChainloader()
		{
			if (!patched)
			{
				patched = true;
				if (delayedPatcher.Value == Toggle.On)
				{
					delayedPatcherHarmony.PatchAll(typeof(InterceptChainloader));
				}
				if (unifiedLocalization.Value == Toggle.On)
				{
					harmony.PatchAll(typeof(InterceptLocalization));
					harmony.PatchAll(typeof(InterceptLanguageLoad));
				}
				if (optimizeConfigSave.Value == Toggle.On)
				{
					harmony.PatchAll(typeof(DelayConfigSave));
					harmony.PatchAll(typeof(ChangeConfigSaveBack));
					harmony.PatchAll(typeof(SkipManuallyChangedSaveOnConfigSet));
				}
			}
		}
	}

	[HarmonyPatch]
	private static class InterceptLocalization
	{
		private static readonly Dictionary<string, Dictionary<string, string>> localizationCache = new Dictionary<string, Dictionary<string, string>>();

		private static readonly HashSet<MethodBase> alreadyAppliedEnglishLoadCSV = new HashSet<MethodBase>();

		private static MethodInfo TargetMethod()
		{
			return AccessTools.DeclaredMethod(Type.GetType("Localization, assembly_guiutils"), "SetupLanguage");
		}

		[HarmonyPriority(0)]
		private static bool Prefix(object __instance, string language, ref Dictionary<string, string> ___m_translations, ref bool __result)
		{
			if (localizationCache.TryGetValue(language, out Dictionary<string, string> value))
			{
				___m_translations = value;
				if (language == "English" && (string)AccessTools.DeclaredMethod(Type.GetType("UnityEngine.PlayerPrefs, UnityEngine.CoreModule"), "GetString", new Type[2]
				{
					typeof(string),
					typeof(string)
				}).Invoke(null, new object[2] { "language", "English" }) != "English")
				{
					Patch[] postfixes = AccessTools.DeclaredMethod(Type.GetType("Localization, assembly_guiutils"), "LoadCSV").ToPatchInfo().postfixes;
					foreach (Patch patch in postfixes)
					{
						if (alreadyAppliedEnglishLoadCSV.Contains(patch.PatchMethod))
						{
							continue;
						}
						ParameterInfo[] parameters = patch.PatchMethod.GetParameters();
						object[] array = new object[parameters.Length];
						int num = 0;
						ParameterInfo[] array2 = parameters;
						foreach (ParameterInfo parameterInfo in array2)
						{
							if (parameterInfo.Name == "__instance")
							{
								array[num] = __instance;
							}
							else if (parameterInfo.Name == "language")
							{
								array[num] = language;
							}
							else if (parameterInfo.Name == "__result")
							{
								array[num] = true;
							}
							else if (parameterInfo.Name.StartsWith("___"))
							{
								array[num] = AccessTools.Field(__instance.GetType(), parameterInfo.Name.Substring(3)).GetValue(__instance);
							}
							num++;
						}
						patch.PatchMethod.Invoke(null, array);
						alreadyAppliedEnglishLoadCSV.Add(patch.PatchMethod);
					}
				}
				__result = true;
				return false;
			}
			if (language != "English")
			{
				___m_translations = new Dictionary<string, string>(___m_translations);
			}
			return true;
		}

		[HarmonyPriority(0)]
		private static void Postfix(string language, Dictionary<string, string> ___m_translations, bool __result)
		{
			if (__result)
			{
				localizationCache[language] = ___m_translations;
			}
		}
	}

	[HarmonyPatch]
	private static class InterceptLanguageLoad
	{
		private static MethodInfo TargetMethod()
		{
			return AccessTools.DeclaredMethod(Type.GetType("Localization, assembly_guiutils"), "LoadLanguages");
		}

		[HarmonyPriority(0)]
		private static bool Prefix(ref List<string> __result)
		{
			Type type = Type.GetType("Localization, assembly_guiutils");
			object value = AccessTools.DeclaredField(type, "m_instance").GetValue(null);
			if (value != null)
			{
				__result = (List<string>)AccessTools.DeclaredMethod(type, "GetLanguages").Invoke(value, Array.Empty<object>());
				return false;
			}
			return true;
		}
	}

	[HarmonyPatch]
	private static class InterceptChainloader
	{
		private static bool postChainloader = false;

		private static bool doNotSkipUpdate = false;

		private static readonly HashSet<MethodBase> methods = new HashSet<MethodBase>();

		private static readonly MethodInfo patchSkip = AccessTools.DeclaredMethod(typeof(InterceptChainloader), "SkipUpdates");

		private static readonly MethodInfo addReplacementOriginal = AccessTools.DeclaredMethod(typeof(PatchManager), "AddReplacementOriginal");

		private static MethodInfo TargetMethod()
		{
			return postChainloader ? AccessTools.DeclaredMethod(Type.GetType("FejdStartup, assembly_valheim"), "Awake") : AccessTools.DeclaredMethod(typeof(Chainloader), "Start");
		}

		private static bool SkipUpdates(MethodBase original, ref MethodInfo? __result)
		{
			if (!doNotSkipUpdate)
			{
				Type declaringType = original.DeclaringType;
				if ((object)declaringType == null || !passthroughClasses.Contains(declaringType.FullName))
				{
					methods.Add(original);
					__result = null;
					return false;
				}
			}
			return true;
		}

		[HarmonyPriority(800)]
		public static void Prefix()
		{
			doNotSkipUpdate = false;
			delayedPatcherHarmony.Patch(harmonyPatcher, new HarmonyMethod(patchSkip));
		}

		[HarmonyPriority(0)]
		public static void Postfix()
		{
			doNotSkipUpdate = true;
			string arg;
			if (postChainloader)
			{
				delayedPatcherHarmony.UnpatchSelf();
				arg = "after FejdStartup.Awake";
			}
			else
			{
				delayedPatcherHarmony.Unpatch(TargetMethod(), HarmonyPatchType.All, delayedPatcherHarmony.Id);
				postChainloader = true;
				delayedPatcherHarmony.PatchAll(typeof(InterceptChainloader));
				arg = "after Chainloader end";
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			lock (AccessTools.DeclaredField(typeof(PatchProcessor), "locker").GetValue(null))
			{
				foreach (MethodBase method in methods)
				{
					object obj = harmonyPatcher.Invoke(null, new object[2]
					{
						method,
						method.ToPatchInfo()
					});
					addReplacementOriginal.Invoke(null, new object[2] { method, obj });
				}
			}
			logger.LogInfo($"Batch-patched {methods.Count} methods {arg} in {stopwatch.ElapsedMilliseconds} ms");
			methods.Clear();
		}
	}

	[HarmonyPatch]
	private static class DelayConfigSave
	{
		private static MethodBase TargetMethod()
		{
			return AccessTools.DeclaredConstructor(typeof(ConfigFile), new Type[3]
			{
				typeof(string),
				typeof(bool),
				typeof(BepInPlugin)
			});
		}

		private static void Postfix(ConfigFile __instance)
		{
			__instance.SaveOnConfigSet = false;
			changedConfigFiles.Add(__instance);
		}
	}

	[HarmonyPatch]
	private static class ChangeConfigSaveBack
	{
		private static MethodInfo TargetMethod()
		{
			return AccessTools.DeclaredMethod(Type.GetType("FejdStartup, assembly_valheim"), "Awake");
		}

		private static void Prefix()
		{
			List<ConfigFile> changedConfigFiles = StartupAccelerator.changedConfigFiles;
			StartupAccelerator.changedConfigFiles = new List<ConfigFile>();
			foreach (ConfigFile item in changedConfigFiles)
			{
				item.Save();
				item.SaveOnConfigSet = true;
			}
		}
	}

	[HarmonyPatch]
	private static class SkipManuallyChangedSaveOnConfigSet
	{
		private static MethodBase TargetMethod()
		{
			return AccessTools.DeclaredPropertySetter(typeof(ConfigFile), "SaveOnConfigSet");
		}

		private static void Prefix(ConfigFile __instance)
		{
			if (changedConfigFiles.Remove(__instance))
			{
				__instance.Save();
			}
		}
	}

	private const string CONFIG_FILE_NAME = "StartupAccelerator.cfg";

	private static readonly ConfigFile Config = new ConfigFile(Path.Combine(Paths.ConfigPath, "StartupAccelerator.cfg"), saveOnInit: true);

	private static readonly ManualLogSource logger = Logger.CreateLogSource("StartupAccelerator");

	private static readonly Harmony delayedPatcherHarmony = new Harmony("org.bepinex.patchers.startupaccelerator.delayed_patcher");

	private static readonly Harmony harmony = new Harmony("org.bepinex.patchers.startupaccelerator");

	private static readonly MethodInfo harmonyPatcher = AccessTools.DeclaredMethod(typeof(Harmony).Assembly.GetType("HarmonyLib.PatchFunctions"), "UpdateWrapper");

	private static readonly string[] hardcodedPassthrough = new string[4]
	{
		typeof(Assembly).FullName,
		"BepInEx.Preloader.RuntimeFixes.HarmonyInteropFix",
		"BepInEx.PluginInfo",
		typeof(Enum).FullName
	};

	private static HashSet<string> passthroughClasses = new HashSet<string>();

	private static readonly ConfigEntry<Toggle> delayedPatcher = Config.Bind("General", "Delay Patching", Toggle.On, new ConfigDescription("Delay Harmony patching until after Chainloader and after FejdStartup.Awake respectively.", null));

	private static readonly ConfigEntry<Toggle> unifiedLocalization = Config.Bind("General", "Merge Localization Data", Toggle.On, new ConfigDescription("Merge localization data to avoid re-reading it over and over.", null));

	private static readonly ConfigEntry<Toggle> optimizeConfigSave = Config.Bind("General", "Delay Config Save", Toggle.On, new ConfigDescription("Delay config save so that it saves the config once after start up and not over and over again.", null));

	private static List<ConfigFile> changedConfigFiles = new List<ConfigFile>();

	public static IEnumerable<string> TargetDLLs { get; } = Array.Empty<string>();

	public static void Patch(AssemblyDefinition assembly)
	{
	}

	public static void Initialize()
	{
		ConfigEntry<string> passthrough = Config.Bind("General", "Passthrough Patched Classes", "", new ConfigDescription("Comma-separated list of classes to unconditionally patch immediately.", null));
		passthrough.SettingChanged += delegate
		{
			calcPassthrough();
		};
		calcPassthrough();
		harmony.PatchAll(typeof(Patch_Preloader_PatchEntrypoint));
		void calcPassthrough()
		{
			HashSet<string> hashSet = new HashSet<string>();
			foreach (string item in hardcodedPassthrough.Concat<string>((unifiedLocalization.Value != Toggle.On) ? Array.Empty<string>() : new string[1] { "Localization" }).Concat(passthrough.Value.Split(',')))
			{
				hashSet.Add(item);
			}
			passthroughClasses = hashSet;
		}
	}
}
