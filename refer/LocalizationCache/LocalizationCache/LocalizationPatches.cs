using System;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using HarmonyLib.Public.Patching;
using UnityEngine;

namespace LocalizationCache;

[HarmonyPatch]
public static class LocalizationPatches
{
	private static Dictionary<Tuple<string, string>, Dictionary<string, string>> languageTranslations = new Dictionary<Tuple<string, string>, Dictionary<string, string>>();

	private static List<Patch> patchedMods = new List<Patch>();

	private static MethodInfo LoadCSVMethod { get; } = AccessTools.Method(typeof(Localization), "LoadCSV");

	[HarmonyPatch(typeof(Localization), "LoadCSV")]
	[HarmonyPrefix]
	[HarmonyPriority(800)]
	public static bool SetupLanguage_Prefix(Localization __instance, TextAsset file, string language, ref bool __result)
	{
		if (!file)
		{
			return true;
		}
		Tuple<string, string> key = new Tuple<string, string>(file.name, language);
		if (!languageTranslations.TryGetValue(key, out var value))
		{
			return true;
		}
		__instance.m_translations = value;
		__result = true;
		return false;
	}

	[HarmonyPatch(typeof(Localization), "LoadCSV")]
	[HarmonyPostfix]
	[HarmonyPriority(0)]
	public static void SetupLanguage_Postfix(Localization __instance, TextAsset file, string language, bool __result)
	{
		if (__result && (bool)file)
		{
			Tuple<string, string> key = new Tuple<string, string>(file.name, language);
			languageTranslations[key] = __instance.m_translations;
			CacheOtherMods();
		}
	}

	private static void CacheOtherMods()
	{
		if (!Plugin.CacheMods.Value)
		{
			return;
		}
		Patch[] postfixes = LoadCSVMethod.ToPatchInfo().postfixes;
		foreach (Patch patch in postfixes)
		{
			if (!(patch.owner == "com.maxsch.valheim.LocalizationCache") && !patchedMods.Contains(patch))
			{
				Plugin.harmony.Patch(patch.PatchMethod, new HarmonyMethod(typeof(LocalizationPatches), "SkipLoad"));
				patchedMods.Add(patch);
			}
		}
	}

	private static bool SkipLoad()
	{
		return false;
	}
}
