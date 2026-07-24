using System.Reflection;
using BepInEx;
using BepInEx.Bootstrap;
using HarmonyLib;

namespace Jotunn.Utils;

/// <summary>
///     Utility class for the BepInEx ConfigurationManager plugin, without requiring a hard dependency
/// </summary>
public static class ConfigManagerUtils
{
	private static PropertyInfo displayingWindowInfo;

	private static MethodInfo buildSettingListMethodInfo;

	/// <summary>
	///     The ConfigurationManager plugin instance if installed, otherwise null
	/// </summary>
	public static BaseUnityPlugin Plugin { get; private set; }

	/// <summary>
	///     Is the config manager main window displayed on screen<br />
	///     Safe to use even if ConfigurationManager is not installed.
	/// </summary>
	public static bool DisplayingWindow
	{
		get
		{
			if ((bool)Plugin)
			{
				return (bool)displayingWindowInfo.GetValue(Plugin);
			}
			return false;
		}
		set
		{
			displayingWindowInfo?.SetValue(Plugin, value);
		}
	}

	static ConfigManagerUtils()
	{
		if (Chainloader.PluginInfos.TryGetValue("com.bepis.bepinex.configurationmanager", out var value) && (bool)value.Instance)
		{
			Plugin = value.Instance;
			displayingWindowInfo = AccessTools.Property(Plugin.GetType(), "DisplayingWindow");
			buildSettingListMethodInfo = AccessTools.Method(Plugin.GetType(), "BuildSettingList");
		}
		else if (Chainloader.PluginInfos.TryGetValue("_shudnal.ConfigurationManager", out value) && (bool)value.Instance)
		{
			Plugin = value.Instance;
			displayingWindowInfo = AccessTools.Property(Plugin.GetType(), "DisplayingWindow");
			buildSettingListMethodInfo = AccessTools.Method(Plugin.GetType(), "BuildSettingList");
		}
	}

	/// <summary>
	///     Rebuild the setting list. Use to update the config manager window if config settings were removed or added while it was open.<br />
	///     Safe to call even if ConfigurationManager is not installed.
	/// </summary>
	public static void BuildSettingList()
	{
		if ((bool)Plugin)
		{
			buildSettingListMethodInfo.Invoke(Plugin, null);
		}
	}
}
