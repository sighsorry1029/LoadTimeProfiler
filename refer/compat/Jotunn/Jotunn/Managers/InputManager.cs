using System;
using System.Collections.Generic;
using System.Linq;
using BepInEx.Configuration;
using HarmonyLib;
using Jotunn.Configs;
using Jotunn.Utils;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Jotunn.Managers;

/// <summary>
///    Manager for handling custom inputs registered by mods.
/// </summary>
public class InputManager : IManager
{
	/// <summary>
	///     Abstraction for gamepad buttons and axes used as inputs
	/// </summary>
	public enum GamepadButton
	{
		/// <summary>
		///     No gamepad button, internally treated as null
		/// </summary>
		None,
		/// <summary>
		///     Up direction on the directional pad
		/// </summary>
		DPadUp,
		/// <summary>
		///     Down direction on the directional pad
		/// </summary>
		DPadDown,
		/// <summary>
		///     Left direction on the directional pad
		/// </summary>
		DPadLeft,
		/// <summary>
		///     Right direction on the directional pad
		/// </summary>
		DPadRight,
		/// <summary>
		///     Southern button on the gamepad (A on XBox-like)
		/// </summary>
		ButtonSouth,
		/// <summary>
		///     Eastern button on the gamepad (B on XBox-like)
		/// </summary>
		ButtonEast,
		/// <summary>
		///     Western button on the gamepad (X on XBox-like)
		/// </summary>
		ButtonWest,
		/// <summary>
		///     Nothern button on the gamepad (Y on XBox-like)
		/// </summary>
		ButtonNorth,
		/// <summary>
		///     Left shoulder button
		/// </summary>
		LeftShoulder,
		/// <summary>
		///     Right shoulder button
		/// </summary>
		RightShoulder,
		/// <summary>
		///     Left trigger
		/// </summary>
		LeftTrigger,
		/// <summary>
		///     Right trigger
		/// </summary>
		RightTrigger,
		/// <summary>
		///     Left special button (Back on XBox-like)
		/// </summary>
		SelectButton,
		/// <summary>
		///     Right special button (Menu on XBox-like)
		/// </summary>
		StartButton,
		/// <summary>
		///     Left Joystick press
		/// </summary>
		LeftStickButton,
		/// <summary>
		///     Right Joystick press
		/// </summary>
		RightStickButton
	}

	private static class Patches
	{
		[HarmonyPatch(typeof(ZInput), "Load")]
		[HarmonyPostfix]
		private static void RegisterCustomInputs(ZInput __instance)
		{
			Instance.RegisterCustomInputs(__instance);
		}

		[HarmonyPatch(typeof(ZInput), "GetButtonDown")]
		[HarmonyPostfix]
		private static void ZInput_GetButtonDown(string name, ref bool __result)
		{
			__result = Instance.ZInput_GetButtonDown(name);
		}

		[HarmonyPatch(typeof(ZInput), "GetButton")]
		[HarmonyPostfix]
		private static void ZInput_GetButton(string name, ref bool __result)
		{
			__result = Instance.ZInput_GetButton(name);
		}

		[HarmonyPatch(typeof(ZInput), "GetButtonUp")]
		[HarmonyPostfix]
		private static void ZInput_GetButtonUp(string name, ref bool __result)
		{
			__result = Instance.ZInput_GetButtonUp(name);
		}

		[HarmonyPatch(typeof(ZInput), "GetButtonDown")]
		[HarmonyReversePatch(HarmonyReversePatchType.Original)]
		public static bool ZInput_GetButtonDown_Original(string name)
		{
			throw new NotImplementedException("It's a stub");
		}

		[HarmonyPatch(typeof(ZInput), "GetButton")]
		[HarmonyReversePatch(HarmonyReversePatchType.Original)]
		public static bool ZInput_GetButton_Original(string name)
		{
			throw new NotImplementedException("It's a stub");
		}

		[HarmonyPatch(typeof(ZInput), "GetButtonUp")]
		[HarmonyReversePatch(HarmonyReversePatchType.Original)]
		public static bool ZInput_GetButtonUp_Original(string name)
		{
			throw new NotImplementedException("It's a stub");
		}
	}

	internal static Dictionary<string, ButtonConfig> Buttons;

	internal static Dictionary<ConfigEntryBase, ButtonConfig> ButtonToConfigDict;

	private static InputManager _instance;

	/// <summary>
	///     Singleton instance
	/// </summary>
	public static InputManager Instance => _instance ?? (_instance = new InputManager());

	/// <summary>
	///     Translates a <see cref="T:Jotunn.Managers.InputManager.GamepadButton" /> to its <see cref="T:UnityEngine.KeyCode" /> value
	/// </summary>
	public static KeyCode GetGamepadKeyCode(GamepadButton @enum)
	{
		return InputUtils.GetGamepadKeyCode(@enum);
	}

	/// <summary>
	///     Translate a <see cref="T:Jotunn.Managers.InputManager.GamepadButton" /> to its axis string value
	/// </summary>
	public static GamepadInput GetGamepadInput(GamepadButton @enum)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return InputUtils.GetGamepadInput(@enum);
	}

	/// <summary>
	///     Translate an axis string to its
	///     <see cref="P:UnityEngine.InputSystem.InputBinding.path">UnityEngine.InputSystem.InputBinding.path</see> value
	/// </summary>
	/// <param name="axis"></param>
	/// <returns></returns>
	public static string GetAxisPath(string axis)
	{
		return InputUtils.GetAxisPath(axis);
	}

	public static string GetGamepadInputPath(GamepadInput input)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return InputUtils.GetGamepadInputPath(input);
	}

	/// <summary>
	///     Translates a <see cref="T:Jotunn.Managers.InputManager.GamepadButton" /> to its printable string value
	/// </summary>
	public static string GetGamepadString(GamepadButton @enum)
	{
		return InputUtils.GetGamepadString(@enum);
	}

	public static GamepadButton GetGamepadButton(GamepadInput input)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return InputUtils.GetGamepadButton(input);
	}

	/// <summary>
	///     Translate an axis string to its <see cref="T:Jotunn.Managers.InputManager.GamepadButton" /> value
	/// </summary>
	public static GamepadButton GetGamepadButton(string axis)
	{
		return InputUtils.GetGamepadButton(axis);
	}

	/// <summary>
	///     Translate a <see cref="T:UnityEngine.KeyCode" /> to its <see cref="T:Jotunn.Managers.InputManager.GamepadButton" /> value
	/// </summary>
	public static GamepadButton GetGamepadButton(KeyCode key)
	{
		return InputUtils.GetGamepadButton(key);
	}

	/// <summary>
	///     Hide .ctor
	/// </summary>
	private InputManager()
	{
	}

	static InputManager()
	{
		Buttons = new Dictionary<string, ButtonConfig>();
		ButtonToConfigDict = new Dictionary<ConfigEntryBase, ButtonConfig>();
		((IManager)Instance).Init();
	}

	/// <summary>
	///     Initialize the manager
	/// </summary>
	void IManager.Init()
	{
		Main.LogInit("InputManager");
		if (!GUIUtils.IsHeadless)
		{
			Main.Harmony.PatchAll(typeof(Patches));
		}
	}

	/// <summary>
	///     Add a Button to Valheim
	/// </summary>
	/// <param name="modGuid">Mod GUID</param>
	/// <param name="buttonConfig">Button config</param>
	public void AddButton(string modGuid, ButtonConfig buttonConfig)
	{
		if (buttonConfig == null)
		{
			throw new ArgumentNullException("buttonConfig");
		}
		if (string.IsNullOrEmpty(modGuid))
		{
			throw new ArgumentException("modGuid can not be empty or null", "modGuid");
		}
		if (buttonConfig.Config == null && buttonConfig.Key == KeyCode.None && buttonConfig.ShortcutConfig == null && buttonConfig.Shortcut.MainKey == KeyCode.None && buttonConfig.GamepadConfig == null && buttonConfig.GamepadButton == GamepadButton.None && string.IsNullOrEmpty(buttonConfig.Axis))
		{
			throw new ArgumentException("buttonConfig needs either Axis, Key, Gamepad, Shortcut or a Config set.", "buttonConfig");
		}
		if (Buttons.ContainsKey(buttonConfig.Name + "!" + modGuid))
		{
			Logger.LogWarning("Cannot have duplicate button: " + buttonConfig.Name + " (Mod " + modGuid + ")");
			return;
		}
		if (buttonConfig.Key != KeyCode.None && buttonConfig.Shortcut.MainKey != KeyCode.None)
		{
			Logger.LogWarning("Cannot have both a Key and Shortcut in button config " + buttonConfig.Name + " (Mod " + modGuid + ")");
			return;
		}
		if (buttonConfig.Config != null && buttonConfig.ShortcutConfig != null)
		{
			Logger.LogWarning("Cannot have both a Key and Shortcut config in button config " + buttonConfig.Name + " (Mod " + modGuid + ")");
			return;
		}
		if (buttonConfig.Config != null)
		{
			ButtonToConfigDict.Add(buttonConfig.Config, buttonConfig);
		}
		if (buttonConfig.ShortcutConfig != null)
		{
			ButtonToConfigDict.Add(buttonConfig.ShortcutConfig, buttonConfig);
		}
		if (buttonConfig.GamepadConfig != null)
		{
			ButtonToConfigDict.Add(buttonConfig.GamepadConfig, buttonConfig);
		}
		buttonConfig.Name = buttonConfig.Name + "!" + modGuid;
		Buttons.Add(buttonConfig.Name, buttonConfig);
		if (ZInput.m_instance != null)
		{
			RegisterButton(ZInput.instance, buttonConfig.Name, buttonConfig);
		}
	}

	private void RegisterCustomInputs(ZInput self)
	{
		if (!Buttons.Any())
		{
			return;
		}
		Logger.LogInfo($"Registering {Buttons.Count} custom inputs");
		foreach (KeyValuePair<string, ButtonConfig> button in Buttons)
		{
			RegisterButton(self, button.Key, button.Value);
		}
	}

	private static void RegisterButton(ZInput self, string key, ButtonConfig btn)
	{
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		bool flag = false;
		if (!string.IsNullOrEmpty(btn.Axis))
		{
			self.AddButton(btn.Name, GetAxisPath(btn.Axis), false, true, true, btn.RepeatDelay, btn.RepeatInterval);
			flag = true;
		}
		else if (btn.Key != KeyCode.None)
		{
			self.AddButton(btn.Name, ZInput.KeyCodeToPath(btn.Key, false), false, true, true, btn.RepeatDelay, btn.RepeatInterval);
			flag = true;
		}
		else if (btn.Shortcut.MainKey != KeyCode.None)
		{
			self.AddButton(btn.Name, ZInput.KeyCodeToPath(btn.Shortcut.MainKey, false), false, true, true, btn.RepeatDelay, btn.RepeatInterval);
			flag = true;
		}
		if (btn.GamepadButton != GamepadButton.None)
		{
			GamepadInput gamepadInput = GetGamepadInput(btn.GamepadButton);
			if ((int)gamepadInput != 0)
			{
				string text = "Joy!" + btn.Name;
				self.AddButton(text, GetGamepadInputPath(gamepadInput), false, true, true, btn.RepeatDelay, btn.RepeatInterval);
				flag = true;
			}
		}
		if (!flag)
		{
			Logger.LogWarning("Could not register input " + key + " because it has no valid input set");
		}
	}

	private bool ZInput_GetButtonDown(string name)
	{
		if (!Patches.ZInput_GetButtonDown_Original(name) && !Patches.ZInput_GetButtonDown_Original("Joy!" + name))
		{
			return false;
		}
		if (!Buttons.TryGetValue(name, out var value))
		{
			return true;
		}
		if (value.Shortcut.MainKey != KeyCode.None && !value.Shortcut.IsDown())
		{
			return false;
		}
		return TakeInput(value);
	}

	private bool ZInput_GetButton(string name)
	{
		if (!Patches.ZInput_GetButton_Original(name) && !Patches.ZInput_GetButton_Original("Joy!" + name))
		{
			return false;
		}
		if (!Buttons.TryGetValue(name, out var value))
		{
			return true;
		}
		if (value.Shortcut.MainKey != KeyCode.None && !value.Shortcut.IsPressed())
		{
			return false;
		}
		return TakeInput(value);
	}

	private bool ZInput_GetButtonUp(string name)
	{
		if (!Patches.ZInput_GetButtonUp_Original(name) && !Patches.ZInput_GetButtonUp_Original("Joy!" + name))
		{
			return false;
		}
		if (!Buttons.TryGetValue(name, out var value))
		{
			return true;
		}
		if (value.Shortcut.MainKey != KeyCode.None && !value.Shortcut.IsUp())
		{
			return false;
		}
		return TakeInput(value);
	}

	private bool TakeInput(ButtonConfig button)
	{
		if (Player.m_localPlayer == null)
		{
			return true;
		}
		if (button.BlockOtherInputs && ZInput.instance.m_buttons.TryGetValue(button.Name, out var def))
		{
			foreach (KeyValuePair<string, ButtonDef> item in ZInput.instance.m_buttons.Where((KeyValuePair<string, ButtonDef> pair) => IsSameButton(def, pair.Value)))
			{
				ZInput.ResetButtonStatus(item.Key);
				item.Value.m_pressedDynamic = false;
				item.Value.m_pressedFixed = false;
			}
		}
		if (button.ActiveInGUI && !GUIManager.InputBlocked)
		{
			return true;
		}
		if (button.ActiveInCustomGUI && GUIManager.InputBlocked)
		{
			return true;
		}
		return ((Character)Player.m_localPlayer).TakeInput();
	}

	private static bool IsSameButton(ButtonDef buttonA, ButtonDef buttonB)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		IEnumerable<string> first = ((IEnumerable<InputBinding>)(object)buttonA.ButtonAction.bindings).Select((InputBinding binding) => ((InputBinding)(ref binding)).path);
		IEnumerable<string> second = ((IEnumerable<InputBinding>)(object)buttonB.ButtonAction.bindings).Select((InputBinding binding) => ((InputBinding)(ref binding)).path);
		return first.Intersect(second).Any();
	}
}
