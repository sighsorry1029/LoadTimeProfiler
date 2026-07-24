using System;
using BepInEx.Configuration;
using Jotunn.Managers;
using Jotunn.Utils;
using UnityEngine;

namespace Jotunn.Configs;

/// <summary>
///     Configuration class for adding custom inputs and custom key hints.<br />
///     See <a href="https://docs.unity3d.com/2019.4/Documentation/ScriptReference/Input.html" />
///     for more information on Unity Input handling.
/// </summary>
public class ButtonConfig
{
	/// <summary>
	///     Private store for the Key property
	/// </summary>
	private KeyCode _key;

	private ConfigEntry<KeyCode> config;

	/// <summary>
	///     Private store for the shortcut
	/// </summary>
	private KeyboardShortcut _shortcut = KeyboardShortcut.Empty;

	/// <summary>
	///     Private store for the GamepadButton property
	/// </summary>
	private InputManager.GamepadButton _gamepadButton;

	/// <summary>
	///     Name of the config. Use this to react to the button press bound by this config.
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	///     Axis string this config should be bound to.<br />
	///     Use special Axis "Mouse ScrollWheel" to display the scroll icon as the key hint.
	/// </summary>
	public string Axis { get; set; } = string.Empty;

	/// <summary>
	///     Unity KeyCode this config should be bound to.
	/// </summary>
	public KeyCode Key
	{
		get
		{
			if (_key != KeyCode.None)
			{
				return _key;
			}
			return Config?.Value ?? KeyCode.None;
		}
		set
		{
			InputManager.GamepadButton gamepadButton = InputManager.GetGamepadButton(value);
			if (gamepadButton != InputManager.GamepadButton.None)
			{
				Logger.LogWarning($"ButtonConfig: Key {value} is a GamepadButton, setting GamepadButton instead");
				GamepadButton = gamepadButton;
			}
			else
			{
				_key = value;
			}
		}
	}

	/// <summary>
	///     BepInEx configuration entry of a KeyCode that should be used.
	///     Overrides the <see cref="P:Jotunn.Configs.ButtonConfig.Key" /> value of this config.
	/// </summary>
	public ConfigEntry<KeyCode> Config
	{
		get
		{
			return config;
		}
		set
		{
			if (config != null)
			{
				config.SettingChanged -= OnConfigOnSettingChanged;
			}
			config = value;
			config.SettingChanged += OnConfigOnSettingChanged;
		}
	}

	/// <summary>
	///     BepInEx KeyboardShortcut this config should be bound to.
	/// </summary>
	public KeyboardShortcut Shortcut
	{
		get
		{
			if (_shortcut.MainKey != KeyCode.None)
			{
				return _shortcut;
			}
			return ShortcutConfig?.Value ?? KeyboardShortcut.Empty;
		}
		set
		{
			InputManager.GamepadButton gamepadButton = InputManager.GetGamepadButton(value.MainKey);
			if (gamepadButton != InputManager.GamepadButton.None)
			{
				Logger.LogWarning($"ButtonConfig: Shortcut {value.MainKey} is a GamepadButton, setting GamepadButton instead");
				GamepadButton = gamepadButton;
			}
			else
			{
				_shortcut = value;
			}
		}
	}

	/// <summary>
	///     BepInEx configuration entry of a KeyCode that should be used.
	///     Overrides the <see cref="P:Jotunn.Configs.ButtonConfig.Shortcut" /> value of this config.
	/// </summary>
	public ConfigEntry<KeyboardShortcut> ShortcutConfig { get; set; }

	/// <summary>
	///     GamepadButton this config should be bound to for gamepads.
	/// </summary>
	public InputManager.GamepadButton GamepadButton
	{
		get
		{
			if (_gamepadButton != InputManager.GamepadButton.None)
			{
				return _gamepadButton;
			}
			return GamepadConfig?.Value ?? InputManager.GamepadButton.None;
		}
		set
		{
			_gamepadButton = value;
		}
	}

	/// <summary>
	///     BepInEx configuration entry of a GamepadButton that should be used.
	///     Overrides the <see cref="P:Jotunn.Configs.ButtonConfig.GamepadButton" /> value of this config.
	/// </summary>
	public ConfigEntry<InputManager.GamepadButton> GamepadConfig { get; set; }

	/// <summary>
	///     Should the Axis value be inverted?
	/// </summary>
	public bool Inverted { get; set; }

	/// <summary>
	///     Delay until a constantly pressed key is considered "pressed" again.
	/// </summary>
	public float RepeatDelay { get; set; }

	/// <summary>
	///     Interval in which the check timer for the repeat delay is decremented.
	/// </summary>
	public float RepeatInterval { get; set; }

	/// <summary>
	///     Key hint text, overrides HintToken when set
	/// </summary>
	public string Hint { get; set; }

	/// <summary>
	///     Token for translating the key hint text.
	/// </summary>
	public string HintToken { get; set; }

	/// <summary>
	///     Should this button react on key presses when a Valheim GUI is open? Defaults to <c>false</c>.
	/// </summary>
	public bool ActiveInGUI { get; set; }

	/// <summary>
	///     Should this button react on key presses when a custom GUI is open and requested to block input? Defaults to <c>false</c>.
	/// </summary>
	public bool ActiveInCustomGUI { get; set; }

	/// <summary>
	///     Should this button block all other inputs using the same key or button? Defaults to <c>false</c>.<br />
	///     <b>Warning:</b> If set to <c>true</c>, all other input using the same key or axis is reset when queried via ZInput.
	///     Make sure to gate your usage properly.
	/// </summary>
	public bool BlockOtherInputs { get; set; }

	/// <summary>
	///     Internal flag if this button config is backed by any BepInEx ConfigEntry
	/// </summary>
	internal bool IsConfigBacked
	{
		get
		{
			if (Config == null && ShortcutConfig == null)
			{
				return GamepadConfig != null;
			}
			return true;
		}
	}

	private void OnConfigOnSettingChanged(object sender, EventArgs args)
	{
		InputUtils.SetInputButtons(config);
	}
}
