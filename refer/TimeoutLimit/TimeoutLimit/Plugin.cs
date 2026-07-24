using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;

namespace TimeoutLimit;

[BepInPlugin("com.maxsch.valheim.TimeoutLimit", "TimeoutLimit", "0.2.0")]
[HarmonyPatch]
public class Plugin : BaseUnityPlugin
{
	public const string ModName = "TimeoutLimit";

	public const string ModGuid = "com.maxsch.valheim.TimeoutLimit";

	public const string ModVersion = "0.2.0";

	public static Harmony harmony;

	public static HashSet<Assembly> patchedAssemblies = new HashSet<Assembly>();

	public static CodeInstruction[] loadTimeout = new CodeInstruction[2]
	{
		new CodeInstruction(OpCodes.Call, AccessTools.PropertyGetter(typeof(Plugin), "Timeout")),
		new CodeInstruction(OpCodes.Callvirt, AccessTools.PropertyGetter(typeof(ConfigEntry<float>), "Value"))
	};

	public static MethodInfo getTime = AccessTools.PropertyGetter(typeof(Time), "time");

	public static ConfigEntry<float> Timeout { get; set; }

	public void Awake()
	{
		Timeout = base.Config.Bind("General", "Timeout", 90f, "Timeout in seconds");
		Timeout.SettingChanged += delegate
		{
			if (Chainloader.PluginInfos.TryGetValue("com.jotunn.jotunn", out var value))
			{
				SetJotunnTimeout(value);
			}
		};
		harmony = new Harmony("com.maxsch.valheim.TimeoutLimit");
		harmony.PatchAll();
	}

	public void Start()
	{
		foreach (PluginInfo value in Chainloader.PluginInfos.Values)
		{
			if (value == null || !value.Instance || value.Metadata.GUID == "com.maxsch.valheim.TimeoutLimit")
			{
				continue;
			}
			if (value.Metadata.GUID == "com.jotunn.jotunn")
			{
				base.Logger.LogInfo("Patching " + value.Metadata.Name + " [" + value.Metadata.GUID + "]");
				SetJotunnTimeout(value);
				continue;
			}
			Assembly assembly = value.Instance.GetType().Assembly;
			if (!patchedAssemblies.Add(assembly))
			{
				continue;
			}
			List<Type> source = (from t in assembly.GetTypes()
				where t.IsClass && (t.Name == "ConfigSync" || t.Name == "ServerSync")
				select t).ToList();
			List<Type> list = (from t in source.SelectMany((Type t) => t.GetNestedTypes(BindingFlags.Instance | BindingFlags.NonPublic)).SelectMany((Type t) => t.GetNestedTypes(BindingFlags.Instance | BindingFlags.NonPublic))
				where t.IsClass && t.Name.Contains("waitForQueue")
				select t).ToList();
			bool flag = false;
			if (value.Metadata.GUID == "Azumatt.AzuAntiCheat" && list.Count == 0)
			{
				list = (from m in assembly.GetTypes().SelectMany((Type t) => t.GetNestedTypes(BindingFlags.Instance | BindingFlags.NonPublic)).SelectMany((Type t) => t.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic))
					where m.Name.Contains("waitForQueue")
					select m).SelectMany((MethodInfo m) => m.DeclaringType?.GetNestedTypes(BindingFlags.Instance | BindingFlags.NonPublic)).ToList();
				flag = list.Count == 1;
			}
			List<MethodInfo> list2 = (from m in list.SelectMany((Type t) => t.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic))
				where m.Name == "MoveNext"
				select m).ToList();
			if (list2.Count > 0)
			{
				if (value.Metadata.GUID == "Azumatt.AzuAntiCheat")
				{
					base.Logger.LogInfo("Patching " + value.Metadata.Name + " [" + value.Metadata.GUID + "] (special case: " + (flag ? "yes" : "no") + ")");
				}
				else
				{
					base.Logger.LogInfo("Patching " + value.Metadata.Name + " [" + value.Metadata.GUID + "]");
				}
			}
			else
			{
				base.Logger.LogInfo("Skipping " + value.Metadata.Name + " [" + value.Metadata.GUID + "]");
			}
			foreach (MethodInfo item in list2)
			{
				try
				{
					if (flag)
					{
						harmony.Patch(item, null, null, new HarmonyMethod(typeof(Plugin).GetMethod("AzuAntiCheatTranspiler")));
					}
					else
					{
						harmony.Patch(item, null, null, new HarmonyMethod(typeof(Plugin).GetMethod("ServerSyncTranspiler")));
					}
				}
				catch (Exception arg)
				{
					base.Logger.LogError($"Failed to patch {item?.DeclaringType?.FullName}.{item?.Name}: {arg}");
				}
			}
		}
	}

	public void SetJotunnTimeout(PluginInfo plugin)
	{
		if (plugin != null && plugin.Instance != null && plugin.Metadata.GUID == "com.jotunn.jotunn" && plugin.Metadata.Version >= new Version("2.24.0"))
		{
			Type type = AccessTools.TypeByName("Jotunn.Entities.CustomRPC, Jotunn");
			AccessTools.Field(type, "Timeout").SetValue(null, Timeout.Value);
		}
	}

	[HarmonyPatch(typeof(ZRpc), "SetLongTimeout")]
	[HarmonyTranspiler]
	public static IEnumerable<CodeInstruction> SetLongTimeoutTranspiler(IEnumerable<CodeInstruction> instructions)
	{
		CodeMatch[] matches = new CodeMatch[2]
		{
			new CodeMatch(OpCodes.Ldc_R4),
			new CodeMatch(OpCodes.Stsfld)
		};
		List<Label> label;
		return new CodeMatcher(instructions).MatchForward(useEnd: false, matches).RemoveInstructions(1).InsertAndAdvance(loadTimeout)
			.MatchForward(useEnd: false, matches)
			.GetLabels(out label)
			.RemoveInstructions(1)
			.Insert(loadTimeout)
			.AddLabels(label)
			.InstructionEnumeration();
	}

	[HarmonyPatch(typeof(Debug), "Log", new Type[] { typeof(object) })]
	[HarmonyPrefix]
	public static bool DebugContext(object message)
	{
		if (message is string text && text.Contains("seconds config sending timeout") && !text.StartsWith("["))
		{
			Assembly assembly;
			try
			{
				assembly = (new StackTrace().GetFrames() ?? Array.Empty<StackFrame>()).First((StackFrame x) => x.GetMethod().ReflectedType?.Assembly != typeof(Plugin).Assembly && x.GetMethod().ReflectedType?.Assembly != typeof(Debug).Assembly).GetMethod().ReflectedType?.Assembly;
			}
			catch (Exception)
			{
				return true;
			}
			if (assembly != null)
			{
				Debug.Log($"[{assembly.GetName().Name}] {message}");
				return false;
			}
		}
		return true;
	}

	public static IEnumerable<CodeInstruction> ServerSyncTranspiler(IEnumerable<CodeInstruction> instructions)
	{
		return new CodeMatcher(instructions).MatchForward(false, new CodeMatch((CodeInstruction i) => i.Calls(getTime)), new CodeMatch(OpCodes.Ldc_R4), new CodeMatch(OpCodes.Add)).ThrowIfNotMatch("Failed to match timeout calculation").Advance(1)
			.RemoveInstructions(1)
			.InsertAndAdvance(loadTimeout)
			.MatchForward(false, new CodeMatch(OpCodes.Ldstr, "Disconnecting {0} after 30 seconds config sending timeout"))
			.ThrowIfNotMatch("Failed to match disconnect message")
			.RemoveInstructions(1)
			.InsertAndAdvance(new CodeInstruction(OpCodes.Ldstr, "Disconnecting {0} after {1} seconds config sending timeout"))
			.MatchForward(false, new CodeMatch((CodeInstruction i) => i.opcode == OpCodes.Call && i.operand is MethodInfo methodInfo && methodInfo.Name == "Format"))
			.ThrowIfNotMatch("Failed to match string.Format")
			.RemoveInstructions(1)
			.InsertAndAdvance(loadTimeout)
			.InsertAndAdvance(new CodeInstruction(OpCodes.Box, typeof(float)))
			.InsertAndAdvance(new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(string), "Format", new Type[3]
			{
				typeof(string),
				typeof(object),
				typeof(object)
			})))
			.InstructionEnumeration();
	}

	public static IEnumerable<CodeInstruction> AzuAntiCheatTranspiler(IEnumerable<CodeInstruction> instructions)
	{
		return new CodeMatcher(instructions).Start().MatchForward(false, new CodeMatch((CodeInstruction i) => i.Calls(getTime)), new CodeMatch(OpCodes.Ldc_R4), new CodeMatch(OpCodes.Add)).ThrowIfNotMatch("Failed to match timeout calculation")
			.Advance(1)
			.RemoveInstructions(1)
			.InsertAndAdvance(loadTimeout)
			.Start()
			.MatchForward(true, new CodeMatch((CodeInstruction i) => i.opcode == OpCodes.Call && i.operand is MethodInfo methodInfo && methodInfo.Name == "Format"))
			.ThrowIfNotMatch("Failed to match string.Format")
			.Advance(1)
			.InsertAndAdvance(new CodeInstruction(OpCodes.Pop), new CodeInstruction(OpCodes.Ldstr, "Disconnecting peer after {0} seconds config sending timeout"), new CodeInstruction(OpCodes.Call, AccessTools.PropertyGetter(typeof(Plugin), "Timeout")), new CodeInstruction(OpCodes.Callvirt, AccessTools.PropertyGetter(typeof(ConfigEntry<float>), "Value")), new CodeInstruction(OpCodes.Box, typeof(float)), new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(string), "Format", new Type[2]
			{
				typeof(string),
				typeof(object)
			})))
			.InstructionEnumeration();
	}
}
