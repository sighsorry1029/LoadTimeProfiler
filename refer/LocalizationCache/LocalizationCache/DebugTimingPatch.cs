using System.Diagnostics;
using HarmonyLib;

namespace LocalizationCache;

public static class DebugTimingPatch
{
	[HarmonyPatch(typeof(Localization), "SetupLanguage")]
	[HarmonyPrefix]
	[HarmonyPriority(800)]
	public static void SetupLanguage_Prefix(Localization __instance, ref Stopwatch __state)
	{
		__state = Stopwatch.StartNew();
	}

	[HarmonyPatch(typeof(Localization), "SetupLanguage")]
	[HarmonyPostfix]
	[HarmonyPriority(0)]
	public static void SetupLanguage_Postfix(Localization __instance, ref Stopwatch __state)
	{
		__state.Stop();
		if (Plugin.DebugTiming.Value)
		{
			Plugin.Log.LogInfo($"Localization.SetupLanguage took {__state.ElapsedMilliseconds}ms");
		}
		if (Plugin.DebugStacktrace.Value)
		{
			Plugin.Log.LogInfo($"Localization.SetupLanguage was called\n{new StackTrace()}");
		}
	}
}
