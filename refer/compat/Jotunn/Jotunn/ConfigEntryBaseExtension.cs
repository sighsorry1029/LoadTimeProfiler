using System;
using System.Linq;
using BepInEx.Configuration;
using Jotunn.Configs;
using Jotunn.Managers;
using UnityEngine;

namespace Jotunn;

/// <summary>
///     Extends <see cref="T:BepInEx.Configuration.ConfigEntryBase" /> with convenience functions.
/// </summary>
public static class ConfigEntryBaseExtension
{
	/// <summary>
	///     Check, if this config entry is "visible"
	/// </summary>
	/// <param name="configurationEntry"></param>
	/// <returns></returns>
	public static bool IsVisible(this ConfigEntryBase configurationEntry)
	{
		ConfigurationManagerAttributes configurationManagerAttributes = new ConfigurationManagerAttributes();
		configurationManagerAttributes.SetFromAttributes(configurationEntry.Description?.Tags);
		return configurationManagerAttributes.Browsable != false;
	}

	/// <summary>
	///     Check, if this config entry is "syncable"
	/// </summary>
	/// <param name="configurationEntry"></param>
	/// <returns></returns>
	public static bool IsSyncable(this ConfigEntryBase configurationEntry)
	{
		if (configurationEntry.Description.Tags.FirstOrDefault((object x) => x is ConfigurationManagerAttributes) is ConfigurationManagerAttributes configurationManagerAttributes)
		{
			return configurationManagerAttributes.IsAdminOnly;
		}
		return false;
	}

	/// <summary>
	///     Get bound button's name
	/// </summary>
	/// <param name="configurationEntry"></param>
	/// <returns></returns>
	/// <exception cref="T:System.ArgumentNullException"></exception>
	public static string GetBoundButtonName(this ConfigEntryBase configurationEntry)
	{
		if (configurationEntry == null)
		{
			throw new ArgumentNullException("configurationEntry");
		}
		if (configurationEntry.SettingType != typeof(KeyCode) && configurationEntry.SettingType != typeof(KeyboardShortcut) && configurationEntry.SettingType != typeof(InputManager.GamepadButton))
		{
			return null;
		}
		if (!InputManager.ButtonToConfigDict.TryGetValue(configurationEntry, out var value))
		{
			return null;
		}
		return value.Name;
	}

	/// <summary>
	///     Get bound button config
	/// </summary>
	/// <param name="configurationEntry"></param>
	/// <returns></returns>
	/// <exception cref="T:System.ArgumentNullException"></exception>
	public static ButtonConfig GetButtonConfig(this ConfigEntryBase configurationEntry)
	{
		if (configurationEntry == null)
		{
			throw new ArgumentNullException("configurationEntry");
		}
		if (configurationEntry.SettingType != typeof(KeyCode) && configurationEntry.SettingType != typeof(KeyboardShortcut) && configurationEntry.SettingType != typeof(InputManager.GamepadButton))
		{
			return null;
		}
		InputManager.ButtonToConfigDict.TryGetValue(configurationEntry, out var value);
		return value;
	}

	/// <summary>
	///     Get the local value of an admin config
	/// </summary>
	/// <param name="configurationEntry"></param>
	/// <returns></returns>
	internal static object GetLocalValue(this ConfigEntryBase configurationEntry)
	{
		if (SynchronizationManager.Instance.localValues.TryGetValue(configurationEntry, out var value))
		{
			return value;
		}
		return null;
	}

	/// <summary>
	///     Set the local value of an admin config
	/// </summary>
	/// <param name="configurationEntry"></param>
	/// <param name="value"></param>
	/// <returns></returns>
	internal static void SetLocalValue(this ConfigEntryBase configurationEntry, object value)
	{
		SynchronizationManager.Instance.localValues[configurationEntry] = value;
	}

	internal static ConfigurationManagerAttributes GetConfigurationManagerAttributes(this ConfigEntryBase configEntry)
	{
		return (ConfigurationManagerAttributes)configEntry.Description.Tags.FirstOrDefault((object x) => x is ConfigurationManagerAttributes);
	}
}
