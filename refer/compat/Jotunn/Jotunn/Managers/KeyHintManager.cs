using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Jotunn.Configs;
using Jotunn.Utils;
using UnityEngine;

namespace Jotunn.Managers;

/// <summary>
///     Manager for handling custom key hints
/// </summary>
public class KeyHintManager : IManager
{
	private static class Patches
	{
		[HarmonyPatch(typeof(KeyHints), "Start")]
		[HarmonyPostfix]
		private static void KeyHints_Start(KeyHints __instance)
		{
			try
			{
				Instance.GetBaseGameObjects(__instance);
				Instance.KeyHints_Start(__instance);
			}
			catch (Exception arg)
			{
				Logger.LogWarning($"Exception caught while creating key hint objects: {arg}");
			}
		}

		[HarmonyPatch(typeof(KeyHints), "UpdateHints")]
		[HarmonyPrefix]
		private static bool KeyHints_UpdateHints(KeyHints __instance)
		{
			return Instance.KeyHints_UpdateHints(__instance);
		}

		[HarmonyPatch(typeof(ZInput), "Save")]
		[HarmonyPostfix]
		private static void ZInput_Save(ZInput __instance)
		{
			Instance.ZInput_Save(__instance);
		}
	}

	private static KeyHintManager _instance;

	/// <summary>
	///     Internal Dictionary holding the references to the custom key hints added to the manager
	/// </summary>
	private readonly Dictionary<string, KeyHintConfig> KeyHints = new Dictionary<string, KeyHintConfig>();

	/// <summary>
	///     Internal Dictionary holding the references to the key hint GameObjects created per KeyHintConfig
	/// </summary>
	private readonly Dictionary<string, GameObject> KeyHintObjects = new Dictionary<string, GameObject>();

	/// <summary>
	///     Reference to the current "KeyHints" instance
	/// </summary>
	private KeyHints KeyHintInstance;

	/// <summary>
	///     Reference to the games "KeyHint" GameObjects RectTransform
	/// </summary>
	private RectTransform KeyHintContainer;

	/// <summary>
	///     Base GameObjects of vanilla key hint parts
	/// </summary>
	private GameObject BaseKey;

	private GameObject BaseRotate;

	private GameObject BaseButton;

	private GameObject BaseTrigger;

	private GameObject BaseShoulder;

	private GameObject BaseStick;

	private GameObject BaseDPad;

	private bool HasInitBaseGameObjects;

	/// <summary>
	///     Singleton instance
	/// </summary>
	public static KeyHintManager Instance => _instance ?? (_instance = new KeyHintManager());

	/// <summary>
	///     Hide .ctor
	/// </summary>
	private KeyHintManager()
	{
	}

	static KeyHintManager()
	{
		((IManager)Instance).Init();
	}

	/// <summary>
	///     Initialize the manager
	/// </summary>
	void IManager.Init()
	{
		Main.LogInit("KeyHintManager");
		if (!GUIUtils.IsHeadless)
		{
			Main.Harmony.PatchAll(typeof(Patches));
		}
	}

	/// <summary>
	///     Add a <see cref="T:Jotunn.Configs.KeyHintConfig" /> to the manager.<br />
	///     Checks if the custom key hint is unique (i.e. the first one registered for an item).<br />
	///     Custom key hints are displayed in the game instead of the default 
	///     KeyHints for equipped tools or weapons they are registered for.
	/// </summary>
	/// <param name="hintConfig">The custom key hint config to add.</param>
	/// <returns>true if the custom key hint config was added to the manager.</returns>
	public bool AddKeyHint(KeyHintConfig hintConfig)
	{
		if (hintConfig.Item == null)
		{
			Logger.LogWarning($"Key hint config {hintConfig} is not valid");
			return false;
		}
		if (KeyHints.ContainsKey(hintConfig.ToString()))
		{
			Logger.LogWarning($"Key hint config for item {hintConfig} already added");
			return false;
		}
		foreach (ButtonConfig item in hintConfig.ButtonConfigs.Where((ButtonConfig x) => x.IsConfigBacked))
		{
			if (item.Config != null)
			{
				item.Config.SettingChanged += delegate
				{
					hintConfig.Dirty = true;
				};
			}
			if (item.ShortcutConfig != null)
			{
				item.ShortcutConfig.SettingChanged += delegate
				{
					hintConfig.Dirty = true;
				};
			}
			if (item.GamepadConfig != null)
			{
				item.GamepadConfig.SettingChanged += delegate
				{
					hintConfig.Dirty = true;
				};
			}
		}
		KeyHints.Add(hintConfig.ToString(), hintConfig);
		return true;
	}

	/// <summary>
	///     Removes a <see cref="T:Jotunn.Configs.KeyHintConfig" /> from the game.
	/// </summary>
	/// <param name="hintConfig">The custom key hint config to add.</param>
	public void RemoveKeyHint(KeyHintConfig hintConfig)
	{
		if (KeyHints.ContainsKey(hintConfig.ToString()))
		{
			KeyHints.Remove(hintConfig.ToString());
		}
		if (KeyHintObjects.TryGetValue(hintConfig.ToString(), out var value))
		{
			UnityEngine.Object.Destroy(value);
			KeyHintObjects.Remove(hintConfig.ToString());
		}
	}

	/// <summary>
	///     Instantiate base GameObjects from vanilla KeyHints to use in our custom key hints
	/// </summary>
	private void GetBaseGameObjects(KeyHints self)
	{
		if (HasInitBaseGameObjects)
		{
			return;
		}
		GameObject buildHints = self.m_buildHints;
		UIInputHint component = buildHints.GetComponent<UIInputHint>();
		Transform transform = component?.m_mouseKeyboardHint?.transform;
		Transform transform2 = component?.m_gamepadHint?.transform;
		if (transform == null || transform2 == null)
		{
			Logger.LogWarning("Could not find child objects for KeyHints");
			return;
		}
		GameObject gameObject = transform.transform.Find("Place")?.gameObject;
		GameObject gameObject2 = transform.transform.Find("rotate")?.gameObject;
		GameObject gameObject3 = transform2.transform.Find("Text - BuildMenu")?.gameObject;
		GameObject gameObject4 = transform2.transform.Find("Text - Place")?.gameObject;
		GameObject gameObject5 = transform2.transform.Find("Text - Remove")?.gameObject;
		GameObject gameObject6 = transform2.transform.Find("Text - Rotate")?.gameObject;
		if (!gameObject || !gameObject2 || !gameObject3 || !gameObject4 || !gameObject5 || !gameObject6)
		{
			Logger.LogWarning("Could not find child objects for KeyHints");
			return;
		}
		BaseKey = UnityEngine.Object.Instantiate(gameObject);
		BaseKey.name = "JotunnKeyHintBaseKey";
		PrefabManager.Instance.AddPrefab(BaseKey);
		BaseRotate = UnityEngine.Object.Instantiate(gameObject2);
		BaseRotate.name = "JotunnKeyHintBaseRotate";
		PrefabManager.Instance.AddPrefab(BaseRotate);
		BaseButton = UnityEngine.Object.Instantiate(gameObject3);
		BaseButton.name = "JotunnKeyHintBaseButton";
		PrefabManager.Instance.AddPrefab(BaseButton);
		BaseTrigger = UnityEngine.Object.Instantiate(gameObject4);
		BaseTrigger.name = "JotunnKeyHintBaseTrigger";
		PrefabManager.Instance.AddPrefab(BaseTrigger);
		BaseShoulder = UnityEngine.Object.Instantiate(gameObject5);
		BaseShoulder.name = "JotunnKeyHintBaseShoulder";
		PrefabManager.Instance.AddPrefab(BaseShoulder);
		BaseStick = UnityEngine.Object.Instantiate(gameObject6);
		BaseStick.name = "JotunnKeyHintBaseStick";
		PrefabManager.Instance.AddPrefab(BaseStick);
		BaseDPad = UnityEngine.Object.Instantiate(BaseTrigger);
		BaseDPad.name = "JotunnKeyHintBaseDPad";
		PrefabManager.Instance.AddPrefab(BaseDPad);
		HasInitBaseGameObjects = true;
	}

	/// <summary>
	///     Extract base key hint elements and create key hint objects.
	/// </summary>
	private void KeyHints_Start(KeyHints self)
	{
		if (HasInitBaseGameObjects)
		{
			KeyHintInstance = self;
			KeyHintContainer = self.transform as RectTransform;
			KeyHintObjects.Clear();
		}
	}

	/// <summary>
	///     Copy vanilla BuildHints object and create a custom one from a KeyHintConfig.
	/// </summary>
	/// <param name="config"></param>
	private GameObject CreateKeyHintObject(KeyHintConfig config)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(KeyHintInstance.m_buildHints, KeyHintContainer, worldPositionStays: false);
		gameObject.name = config.ToString();
		UIInputHint component = gameObject.GetComponent<UIInputHint>();
		Transform transform = component?.m_mouseKeyboardHint?.transform;
		Transform transform2 = component?.m_gamepadHint?.transform;
		if (transform == null || transform2 == null)
		{
			throw new Exception("Could not find child objects for KeyHints");
		}
		foreach (Transform item in transform)
		{
			UnityEngine.Object.Destroy(item.gameObject);
		}
		foreach (Transform item2 in transform2)
		{
			UnityEngine.Object.Destroy(item2.gameObject);
		}
		component?.m_inputLayoutSettings.Clear();
		ButtonConfig[] buttonConfigs = config.ButtonConfigs;
		foreach (ButtonConfig buttonConfig in buttonConfigs)
		{
			string text = ZInput.instance.GetBoundKeyString(buttonConfig.Name, true);
			if (string.IsNullOrEmpty(text))
			{
				text = buttonConfig.Name;
				string boundKeyString = ZInput.instance.GetBoundKeyString(buttonConfig.Name, false);
				Logger.LogDebug("Missing key for " + buttonConfig.Name + ": " + boundKeyString);
			}
			if (text[0].Equals('$'))
			{
				text = LocalizationManager.Instance.TryTranslate(text);
			}
			string text2 = buttonConfig.Hint ?? LocalizationManager.Instance.TryTranslate(buttonConfig.HintToken);
			if (string.IsNullOrEmpty(buttonConfig.Axis) || !buttonConfig.Axis.Equals("Mouse ScrollWheel"))
			{
				GameObject gameObject2 = UnityEngine.Object.Instantiate(BaseKey, transform, worldPositionStays: false);
				gameObject2.name = buttonConfig.Name;
				gameObject2.transform.Find("key_bkg/Key").gameObject.SetText(text);
				gameObject2.transform.Find("Text").gameObject.SetText(text2);
				gameObject2.SetActive(value: true);
			}
			else
			{
				GameObject gameObject3 = UnityEngine.Object.Instantiate(BaseRotate, transform, worldPositionStays: false);
				gameObject3.transform.Find("Text").gameObject.SetText(text2);
				gameObject3.SetActive(value: true);
			}
			InputManager.GamepadButton gamepadButton = buttonConfig.GamepadButton;
			if (gamepadButton == InputManager.GamepadButton.None && ZInput.instance.m_buttons.TryGetValue("Joy" + buttonConfig.Name, out var _))
			{
				gamepadButton = InputManager.GamepadButton.None;
			}
			if (gamepadButton != InputManager.GamepadButton.None)
			{
				string gamepadString = InputManager.GetGamepadString(gamepadButton);
				switch (gamepadButton)
				{
				case InputManager.GamepadButton.DPadLeft:
				case InputManager.GamepadButton.DPadRight:
				{
					GameObject gameObject10 = UnityEngine.Object.Instantiate(BaseDPad, transform2, worldPositionStays: false);
					gameObject10.name = buttonConfig.Name;
					gameObject10.SetActive(value: true);
					break;
				}
				case InputManager.GamepadButton.DPadUp:
				case InputManager.GamepadButton.DPadDown:
				{
					GameObject gameObject9 = UnityEngine.Object.Instantiate(BaseDPad, transform2, worldPositionStays: false);
					gameObject9.name = buttonConfig.Name;
					gameObject9.SetActive(value: true);
					break;
				}
				case InputManager.GamepadButton.SelectButton:
				case InputManager.GamepadButton.StartButton:
				{
					GameObject gameObject8 = UnityEngine.Object.Instantiate(BaseKey, transform2, worldPositionStays: false);
					gameObject8.name = buttonConfig.Name;
					gameObject8.SetActive(value: true);
					break;
				}
				case InputManager.GamepadButton.ButtonSouth:
				case InputManager.GamepadButton.ButtonEast:
				case InputManager.GamepadButton.ButtonWest:
				case InputManager.GamepadButton.ButtonNorth:
				{
					GameObject gameObject7 = UnityEngine.Object.Instantiate(BaseButton, transform2, worldPositionStays: false);
					gameObject7.name = buttonConfig.Name;
					gameObject7.SetActive(value: true);
					break;
				}
				case InputManager.GamepadButton.LeftShoulder:
				case InputManager.GamepadButton.RightShoulder:
				{
					GameObject gameObject6 = UnityEngine.Object.Instantiate(BaseShoulder, transform2, worldPositionStays: false);
					gameObject6.name = buttonConfig.Name;
					gameObject6.SetActive(value: true);
					break;
				}
				case InputManager.GamepadButton.LeftTrigger:
				case InputManager.GamepadButton.RightTrigger:
				{
					GameObject gameObject5 = UnityEngine.Object.Instantiate(BaseTrigger, transform2, worldPositionStays: false);
					gameObject5.name = buttonConfig.Name;
					gameObject5.SetActive(value: true);
					break;
				}
				case InputManager.GamepadButton.LeftStickButton:
				case InputManager.GamepadButton.RightStickButton:
				{
					GameObject gameObject4 = UnityEngine.Object.Instantiate(BaseStick, transform2, worldPositionStays: false);
					gameObject4.name = buttonConfig.Name;
					gameObject4.SetActive(value: true);
					break;
				}
				default:
					throw new ArgumentOutOfRangeException("gamepadButton", gamepadButton, null);
				}
			}
		}
		KeyHintObjects[config.ToString()] = gameObject;
		config.Dirty = false;
		return gameObject;
	}

	/// <summary>
	///     Hook on <see cref="M:KeyHints.UpdateHints" /> to show custom key hints instead of the vanilla ones.
	/// </summary>
	private bool KeyHints_UpdateHints(KeyHints self)
	{
		if (!HasInitBaseGameObjects || KeyHintInstance == null || KeyHintContainer == null)
		{
			return true;
		}
		if (!UseCustomKeyHint())
		{
			KeyHintObjects.Values.Where((GameObject x) => x.activeSelf).Do(delegate(GameObject x)
			{
				x.SetActive(value: false);
			});
			return true;
		}
		return false;
		bool UseCustomKeyHint()
		{
			if (!self.m_keyHintsEnabled || !Player.m_localPlayer || Player.m_localPlayer.IsDead() || Chat.instance.IsChatDialogWindowVisible() || Game.IsPaused() || (InventoryGui.instance != null && (InventoryGui.instance.IsSkillsPanelOpen || InventoryGui.instance.IsTrophisPanelOpen || InventoryGui.instance.IsTextPanelOpen || InventoryGui.instance.m_animator.GetBool("visible"))))
			{
				return false;
			}
			ItemDrop.ItemData itemData = null;
			if (((Humanoid)Player.m_localPlayer).m_rightItem != null)
			{
				itemData = ((Humanoid)Player.m_localPlayer).m_rightItem;
			}
			else if (((Humanoid)Player.m_localPlayer).m_leftItem != null && ((Humanoid)Player.m_localPlayer).m_leftItem.m_shared.m_itemType != ItemDrop.ItemData.ItemType.Torch)
			{
				itemData = ((Humanoid)Player.m_localPlayer).m_leftItem;
			}
			else if ((bool)Player.m_localPlayer.m_unarmedWeapon)
			{
				itemData = Player.m_localPlayer.m_unarmedWeapon.m_itemData;
			}
			if (itemData == null || (!itemData.IsWeapon() && !(itemData.m_shared?.m_buildPieces != null)))
			{
				return false;
			}
			string text = itemData.m_dropPrefab?.name;
			if (string.IsNullOrEmpty(text))
			{
				return false;
			}
			string text2 = Player.m_localPlayer.m_buildPieces?.GetSelectedPiece()?.name;
			KeyHintConfig value = null;
			if (!string.IsNullOrEmpty(text2))
			{
				KeyHints.TryGetValue(text + ":" + text2, out value);
			}
			if (value == null)
			{
				KeyHints.TryGetValue(text, out value);
			}
			if (value == null)
			{
				return false;
			}
			if (KeyHintObjects.TryGetValue(value.ToString(), out var value2) && value.Dirty)
			{
				UnityEngine.Object.DestroyImmediate(value2);
			}
			if (!value2)
			{
				try
				{
					value2 = CreateKeyHintObject(value);
				}
				catch (Exception arg)
				{
					Logger.LogWarning($"Exception caught while creating KeyHint {value}: {arg}");
					KeyHints.Remove(value.ToString());
					return false;
				}
			}
			if (!value2.activeSelf)
			{
				self.m_buildHints.SetActive(value: false);
				self.m_combatHints.SetActive(value: false);
				self.m_inventoryHints.SetActive(value: false);
				self.m_inventoryWithContainerHints.SetActive(value: false);
				self.m_fishingHints.SetActive(value: false);
				KeyHintObjects.Values.Where((GameObject x) => x.activeSelf).Do(delegate(GameObject x)
				{
					x.SetActive(value: false);
				});
				value2.SetActive(value: true);
			}
			return true;
		}
	}

	private void ZInput_Save(ZInput self)
	{
		foreach (KeyHintConfig item in KeyHints.Values.Where((KeyHintConfig x) => x.ButtonConfigs.Any((ButtonConfig y) => !y.IsConfigBacked)))
		{
			item.Dirty = true;
		}
	}
}
