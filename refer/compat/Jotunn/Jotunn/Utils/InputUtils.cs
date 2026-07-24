using BepInEx.Configuration;
using Jotunn.Managers;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

namespace Jotunn.Utils;

/// <summary>
///     Utility class for converting inputs to different formats
/// </summary>
internal static class InputUtils
{
	/// <summary>
	///     Translates a Unity <see cref="T:UnityEngine.KeyCode" /> KeyCode to a InputSystem <see cref="T:UnityEngine.InputSystem.Key" />
	/// </summary>
	/// <param name="key"></param>
	/// <returns>The matching Key or Key.None, if not assignable</returns>
	public static Key KeyCodeToKey(KeyCode key)
	{
		switch (key)
		{
		case KeyCode.None:
			return (Key)0;
		case KeyCode.Backspace:
			return (Key)65;
		case KeyCode.Delete:
			return (Key)71;
		case KeyCode.Tab:
			return (Key)3;
		case KeyCode.Return:
			return (Key)2;
		case KeyCode.Pause:
			return (Key)76;
		case KeyCode.Escape:
			return (Key)60;
		case KeyCode.Space:
			return (Key)1;
		case KeyCode.Keypad0:
			return (Key)84;
		case KeyCode.Keypad1:
			return (Key)85;
		case KeyCode.Keypad2:
			return (Key)86;
		case KeyCode.Keypad3:
			return (Key)87;
		case KeyCode.Keypad4:
			return (Key)88;
		case KeyCode.Keypad5:
			return (Key)89;
		case KeyCode.Keypad6:
			return (Key)90;
		case KeyCode.Keypad7:
			return (Key)91;
		case KeyCode.Keypad8:
			return (Key)92;
		case KeyCode.Keypad9:
			return (Key)93;
		case KeyCode.KeypadPeriod:
			return (Key)82;
		case KeyCode.KeypadDivide:
			return (Key)78;
		case KeyCode.KeypadMultiply:
			return (Key)79;
		case KeyCode.KeypadMinus:
			return (Key)81;
		case KeyCode.KeypadPlus:
			return (Key)80;
		case KeyCode.KeypadEnter:
			return (Key)77;
		case KeyCode.KeypadEquals:
			return (Key)83;
		case KeyCode.UpArrow:
			return (Key)63;
		case KeyCode.DownArrow:
			return (Key)64;
		case KeyCode.RightArrow:
			return (Key)62;
		case KeyCode.LeftArrow:
			return (Key)61;
		case KeyCode.Insert:
			return (Key)70;
		case KeyCode.Home:
			return (Key)68;
		case KeyCode.End:
			return (Key)69;
		case KeyCode.PageUp:
			return (Key)67;
		case KeyCode.PageDown:
			return (Key)66;
		case KeyCode.F1:
			return (Key)94;
		case KeyCode.F2:
			return (Key)95;
		case KeyCode.F3:
			return (Key)96;
		case KeyCode.F4:
			return (Key)97;
		case KeyCode.F5:
			return (Key)98;
		case KeyCode.F6:
			return (Key)99;
		case KeyCode.F7:
			return (Key)100;
		case KeyCode.F8:
			return (Key)101;
		case KeyCode.F9:
			return (Key)102;
		case KeyCode.F10:
			return (Key)103;
		case KeyCode.F11:
			return (Key)104;
		case KeyCode.F12:
			return (Key)105;
		case KeyCode.Alpha0:
			return (Key)50;
		case KeyCode.Alpha1:
			return (Key)41;
		case KeyCode.Alpha2:
			return (Key)42;
		case KeyCode.Alpha3:
			return (Key)43;
		case KeyCode.Alpha4:
			return (Key)44;
		case KeyCode.Alpha5:
			return (Key)45;
		case KeyCode.Alpha6:
			return (Key)46;
		case KeyCode.Alpha7:
			return (Key)47;
		case KeyCode.Alpha8:
			return (Key)48;
		case KeyCode.Alpha9:
			return (Key)49;
		case KeyCode.A:
			return (Key)15;
		case KeyCode.B:
			return (Key)16;
		case KeyCode.C:
			return (Key)17;
		case KeyCode.D:
			return (Key)18;
		case KeyCode.E:
			return (Key)19;
		case KeyCode.F:
			return (Key)20;
		case KeyCode.G:
			return (Key)21;
		case KeyCode.H:
			return (Key)22;
		case KeyCode.I:
			return (Key)23;
		case KeyCode.J:
			return (Key)24;
		case KeyCode.K:
			return (Key)25;
		case KeyCode.L:
			return (Key)26;
		case KeyCode.M:
			return (Key)27;
		case KeyCode.N:
			return (Key)28;
		case KeyCode.O:
			return (Key)29;
		case KeyCode.P:
			return (Key)30;
		case KeyCode.Q:
			return (Key)31;
		case KeyCode.R:
			return (Key)32;
		case KeyCode.S:
			return (Key)33;
		case KeyCode.T:
			return (Key)34;
		case KeyCode.U:
			return (Key)35;
		case KeyCode.V:
			return (Key)36;
		case KeyCode.W:
			return (Key)37;
		case KeyCode.X:
			return (Key)38;
		case KeyCode.Y:
			return (Key)39;
		case KeyCode.Z:
			return (Key)40;
		case KeyCode.CapsLock:
			return (Key)72;
		case KeyCode.ScrollLock:
			return (Key)75;
		case KeyCode.RightShift:
			return (Key)52;
		case KeyCode.LeftShift:
			return (Key)51;
		case KeyCode.RightControl:
			return (Key)56;
		case KeyCode.LeftControl:
			return (Key)55;
		case KeyCode.RightAlt:
			return (Key)54;
		case KeyCode.LeftAlt:
			return (Key)53;
		case KeyCode.LeftMeta:
			return (Key)57;
		case KeyCode.LeftWindows:
			return (Key)57;
		case KeyCode.RightMeta:
			return (Key)58;
		case KeyCode.RightWindows:
			return (Key)58;
		case KeyCode.AltGr:
			return (Key)54;
		default:
			Logger.LogWarning($"Key {key} not found in the new input system");
			return (Key)0;
		}
	}

	/// <summary>
	///     Tries to convert a <see cref="T:UnityEngine.KeyCode" /> KeyCode to a InputSystem <see cref="T:UnityEngine.InputSystem.LowLevel.MouseButton" />
	/// </summary>
	/// <param name="key"></param>
	/// <param name="mouseButton"></param>
	/// <returns></returns>
	public static bool TryKeyCodeToMouseButton(KeyCode key, out MouseButton mouseButton)
	{
		switch (key)
		{
		case KeyCode.Mouse0:
			mouseButton = (MouseButton)0;
			return true;
		case KeyCode.Mouse1:
			mouseButton = (MouseButton)1;
			return true;
		case KeyCode.Mouse2:
			mouseButton = (MouseButton)2;
			return true;
		case KeyCode.Mouse3:
			mouseButton = (MouseButton)3;
			return true;
		case KeyCode.Mouse4:
			mouseButton = (MouseButton)4;
			return true;
		default:
			mouseButton = (MouseButton)0;
			return false;
		}
	}

	/// <summary>
	///     Translates a <see cref="T:Jotunn.Managers.InputManager.GamepadButton" /> to its <see cref="T:UnityEngine.KeyCode" /> value
	/// </summary>
	public static KeyCode GetGamepadKeyCode(InputManager.GamepadButton @enum)
	{
		return @enum switch
		{
			InputManager.GamepadButton.ButtonSouth => KeyCode.JoystickButton0, 
			InputManager.GamepadButton.ButtonEast => KeyCode.JoystickButton1, 
			InputManager.GamepadButton.ButtonWest => KeyCode.JoystickButton2, 
			InputManager.GamepadButton.ButtonNorth => KeyCode.JoystickButton3, 
			InputManager.GamepadButton.LeftShoulder => KeyCode.JoystickButton4, 
			InputManager.GamepadButton.RightShoulder => KeyCode.JoystickButton5, 
			InputManager.GamepadButton.SelectButton => KeyCode.JoystickButton6, 
			InputManager.GamepadButton.StartButton => KeyCode.JoystickButton7, 
			InputManager.GamepadButton.LeftStickButton => KeyCode.JoystickButton8, 
			InputManager.GamepadButton.RightStickButton => KeyCode.JoystickButton9, 
			_ => KeyCode.None, 
		};
	}

	/// <summary>
	///     Translates a <see cref="T:Jotunn.Managers.InputManager.GamepadButton" /> to its axis string value
	/// </summary>
	public static GamepadInput GetGamepadInput(InputManager.GamepadButton @enum)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		return (GamepadInput)(@enum switch
		{
			InputManager.GamepadButton.DPadUp => 4, 
			InputManager.GamepadButton.DPadDown => 3, 
			InputManager.GamepadButton.DPadLeft => 1, 
			InputManager.GamepadButton.DPadRight => 2, 
			InputManager.GamepadButton.ButtonSouth => 5, 
			InputManager.GamepadButton.ButtonEast => 6, 
			InputManager.GamepadButton.ButtonWest => 7, 
			InputManager.GamepadButton.ButtonNorth => 8, 
			InputManager.GamepadButton.LeftShoulder => 15, 
			InputManager.GamepadButton.RightShoulder => 16, 
			InputManager.GamepadButton.LeftTrigger => 17, 
			InputManager.GamepadButton.RightTrigger => 18, 
			InputManager.GamepadButton.SelectButton => 19, 
			InputManager.GamepadButton.StartButton => 20, 
			InputManager.GamepadButton.LeftStickButton => 11, 
			InputManager.GamepadButton.RightStickButton => 14, 
			_ => 0, 
		});
	}

	/// <summary>
	///     Translates a <see cref="T:Jotunn.Managers.InputManager.GamepadButton" /> to its printable string value
	/// </summary>
	public static string GetGamepadString(InputManager.GamepadButton @enum)
	{
		return @enum switch
		{
			InputManager.GamepadButton.None => string.Empty, 
			InputManager.GamepadButton.DPadLeft => "<", 
			InputManager.GamepadButton.DPadUp => ">", 
			InputManager.GamepadButton.DPadRight => ">", 
			InputManager.GamepadButton.DPadDown => "<", 
			InputManager.GamepadButton.ButtonNorth => "Y", 
			InputManager.GamepadButton.ButtonSouth => "A", 
			InputManager.GamepadButton.ButtonWest => "X", 
			InputManager.GamepadButton.ButtonEast => "B", 
			InputManager.GamepadButton.LeftShoulder => "LB", 
			InputManager.GamepadButton.RightShoulder => "RB", 
			InputManager.GamepadButton.LeftTrigger => "LT", 
			InputManager.GamepadButton.RightTrigger => "RT", 
			InputManager.GamepadButton.StartButton => "Menu", 
			InputManager.GamepadButton.SelectButton => "Back", 
			InputManager.GamepadButton.LeftStickButton => "L", 
			InputManager.GamepadButton.RightStickButton => "R", 
			_ => string.Empty, 
		};
	}

	public static InputManager.GamepadButton GetGamepadButton(GamepadInput input)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected I4, but got Unknown
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Invalid comparison between Unknown and I4
		switch (input - 1)
		{
		default:
			if ((int)input != 17)
			{
				if ((int)input == 18)
				{
					return InputManager.GamepadButton.RightTrigger;
				}
				return InputManager.GamepadButton.None;
			}
			return InputManager.GamepadButton.LeftTrigger;
		case 3:
			return InputManager.GamepadButton.DPadUp;
		case 2:
			return InputManager.GamepadButton.DPadDown;
		case 0:
			return InputManager.GamepadButton.DPadLeft;
		case 1:
			return InputManager.GamepadButton.DPadRight;
		}
	}

	/// <summary>
	///     Translate an axis string to its <see cref="T:Jotunn.Managers.InputManager.GamepadButton" /> value
	/// </summary>
	public static InputManager.GamepadButton GetGamepadButton(string axis)
	{
		return axis switch
		{
			"JoyAxis 7" => InputManager.GamepadButton.DPadUp, 
			"-JoyAxis 7" => InputManager.GamepadButton.DPadDown, 
			"-JoyAxis 6" => InputManager.GamepadButton.DPadLeft, 
			"JoyAxis 6" => InputManager.GamepadButton.DPadRight, 
			"-JoyAxis 3" => InputManager.GamepadButton.LeftTrigger, 
			"JoyAxis 3" => InputManager.GamepadButton.RightTrigger, 
			_ => InputManager.GamepadButton.None, 
		};
	}

	/// <summary>
	///     Translate an axis string to its <see cref="P:UnityEngine.InputSystem.InputBinding.path">UnityEngine.InputSystem.InputBinding.path</see> value
	/// </summary>
	/// <param name="axis"></param>
	/// <returns></returns>
	public static string GetAxisPath(string axis)
	{
		return axis switch
		{
			"Mouse ScrollWheel" => "<Mouse>/scroll", 
			"JoyAxis 7" => "<Gamepad>/dpad/up", 
			"-JoyAxis 7" => "<Gamepad>/dpad/down", 
			"-JoyAxis 6" => "<Gamepad>/dpad/left", 
			"JoyAxis 6" => "<Gamepad>/dpad/right", 
			"-JoyAxis 3" => "<Gamepad>/leftTrigger", 
			"JoyAxis 3" => "<Gamepad>/rightTrigger", 
			_ => string.Empty, 
		};
	}

	public static string GetGamepadInputPath(GamepadInput input)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected I4, but got Unknown
		return (input - 1) switch
		{
			0 => "<Gamepad>/dpad/left", 
			1 => "<Gamepad>/dpad/right", 
			2 => "<Gamepad>/dpad/down", 
			3 => "<Gamepad>/dpad/up", 
			4 => "<Gamepad>/buttonSouth", 
			5 => "<Gamepad>/buttonEast", 
			6 => "<Gamepad>/buttonWest", 
			7 => "<Gamepad>/buttonNorth", 
			8 => "<Gamepad>/leftStick/x", 
			9 => "<Gamepad>/leftStick/y", 
			10 => "<Gamepad>/leftStickPress", 
			11 => "<Gamepad>/rightStick/x", 
			12 => "<Gamepad>/rightStick/y", 
			13 => "<Gamepad>/rightStickPress", 
			14 => "<Gamepad>/leftShoulder", 
			15 => "<Gamepad>/rightShoulder", 
			16 => "<Gamepad>/leftTrigger", 
			17 => "<Gamepad>/rightTrigger", 
			18 => "<Gamepad>/select", 
			19 => "<Gamepad>/start", 
			20 => "<Gamepad>/touchpadButton", 
			21 => "<Gamepad>/rightStick/up", 
			22 => "<Gamepad>/rightStick/down", 
			23 => "<Gamepad>/rightStick/left", 
			24 => "<Gamepad>/rightStick/right", 
			25 => "<Gamepad>/leftStick/up", 
			26 => "<Gamepad>/leftStick/down", 
			27 => "<Gamepad>/leftStick/left", 
			28 => "<Gamepad>/leftStick/right", 
			29 => "<Gamepad>/rightStick", 
			30 => "<Gamepad>/leftStick", 
			_ => string.Empty, 
		};
	}

	/// <summary>
	///     Translates a <see cref="T:UnityEngine.KeyCode" /> to its <see cref="T:Jotunn.Managers.InputManager.GamepadButton" /> value
	/// </summary>
	public static InputManager.GamepadButton GetGamepadButton(KeyCode key)
	{
		return key switch
		{
			KeyCode.JoystickButton0 => InputManager.GamepadButton.ButtonSouth, 
			KeyCode.JoystickButton1 => InputManager.GamepadButton.ButtonEast, 
			KeyCode.JoystickButton2 => InputManager.GamepadButton.ButtonWest, 
			KeyCode.JoystickButton3 => InputManager.GamepadButton.ButtonNorth, 
			KeyCode.JoystickButton4 => InputManager.GamepadButton.LeftShoulder, 
			KeyCode.JoystickButton5 => InputManager.GamepadButton.RightShoulder, 
			KeyCode.JoystickButton6 => InputManager.GamepadButton.SelectButton, 
			KeyCode.JoystickButton7 => InputManager.GamepadButton.StartButton, 
			KeyCode.JoystickButton8 => InputManager.GamepadButton.LeftStickButton, 
			KeyCode.JoystickButton9 => InputManager.GamepadButton.RightStickButton, 
			_ => InputManager.GamepadButton.None, 
		};
	}

	internal static void SetInputButtons(ConfigEntryBase entry)
	{
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		if (ZInput.instance == null)
		{
			return;
		}
		string boundButtonName = entry.GetBoundButtonName();
		if (string.IsNullOrEmpty(boundButtonName))
		{
			return;
		}
		if (entry.SettingType == typeof(KeyCode) && ZInput.instance.m_buttons.TryGetValue(boundButtonName, out var value))
		{
			value.Rebind(ZInput.KeyCodeToPath((KeyCode)entry.BoxedValue, false));
		}
		if (entry.SettingType == typeof(KeyboardShortcut) && ZInput.instance.m_buttons.TryGetValue(boundButtonName, out value))
		{
			value.Rebind(ZInput.KeyCodeToPath(((KeyboardShortcut)entry.BoxedValue).MainKey, false));
		}
		if (entry.SettingType == typeof(InputManager.GamepadButton) && ZInput.instance.m_buttons.TryGetValue("Joy!" + boundButtonName, out value))
		{
			GamepadInput gamepadInput = GetGamepadInput((InputManager.GamepadButton)entry.BoxedValue);
			KeyCode gamepadKeyCode = GetGamepadKeyCode((InputManager.GamepadButton)entry.BoxedValue);
			if ((int)gamepadInput != 0)
			{
				value.Rebind(GetGamepadInputPath(gamepadInput));
			}
			else
			{
				value.Rebind(ZInput.KeyCodeToPath(gamepadKeyCode, false));
			}
		}
	}
}
