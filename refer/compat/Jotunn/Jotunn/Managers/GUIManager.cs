using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;
using Jotunn.Configs;
using Jotunn.GUI;
using Jotunn.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;

namespace Jotunn.Managers;

/// <summary>
///     Manager for handling anything GUI related. Provides Valheim style 
///     GUI elements as well as an anchor for custom GUI prefabs.
/// </summary>
public class GUIManager : IManager
{
	private static class Patches
	{
		[HarmonyPostfix]
		[HarmonyPatch(typeof(PlayerController), "TakeInput")]
		[HarmonyPatch(typeof(Player), "TakeInput")]
		private static void TakeInputPatch(ref bool __result)
		{
			TakeInput(ref __result);
		}

		[HarmonyPatch(typeof(TextInput), "IsVisible")]
		[HarmonyPostfix]
		private static void TextInputPatch(ref bool __result)
		{
			TextInput_IsVisible(ref __result);
		}

		[HarmonyPatch(typeof(InventoryGui), "Update")]
		[HarmonyPatch(typeof(GameCamera), "UpdateCamera")]
		[HarmonyTranspiler]
		[HarmonyWrapSafe]
		private static IEnumerable<CodeInstruction> BlockUsePatch(IEnumerable<CodeInstruction> instructions)
		{
			return BlockUseTranspiler(instructions);
		}

		[HarmonyPatch(typeof(FejdStartup), "SetupGui")]
		[HarmonyPatch(typeof(Game), "Start")]
		[HarmonyPostfix]
		private static void CreateCustomGUI()
		{
			if (!Instance.TryCreateGUI())
			{
				Logger.LogError("Could not create custom GUI");
			}
		}
	}

	private static GUIManager _instance;

	private bool hasInitializedAssets;

	/// <summary>
	///     Unity layer constant for UI objects.
	/// </summary>
	public const int UILayer = 5;

	/// <summary>
	///     The default Valheim beige color.
	/// </summary>
	public Color ValheimBeige = new Color(0.8529f, 0.725f, 0.5331f, 1f);

	/// <summary>
	///     The default Valheim orange color.
	/// </summary>
	public Color ValheimOrange = new Color(1f, 0.631f, 0.235f, 1f);

	/// <summary>
	///     The default Valheim yellow color.
	/// </summary>
	public Color ValheimYellow = new Color(1f, 0.889f, 0f, 1f);

	/// <summary>
	///     Scrollbar handle color block in default Valheim orange.
	/// </summary>
	public ColorBlock ValheimScrollbarHandleColorBlock;

	/// <summary>
	///     Toggle color block in Valheim style.
	/// </summary>
	public ColorBlock ValheimToggleColorBlock;

	/// <summary>
	///     Button color block in Valheim style
	/// </summary>
	public ColorBlock ValheimButtonColorBlock;

	/// <summary>
	///     <see cref="T:UnityEngine.UI.DefaultControls.Resources" /> with default Valheim assets.
	/// </summary>
	public Resources ValheimControlResources;

	/// <summary>
	///     SpriteAtlas holding the references to the sprites used in the helper methods.
	/// </summary>
	private SpriteAtlas UIAtlas;

	/// <summary>
	///     SpriteAtlas holding the references to the sprites used in the helper methods.
	/// </summary>
	private SpriteAtlas IconAtlas;

	/// <summary>
	///     Indicates if the PixelFix must be created for the start or main scene.
	/// </summary>
	private bool GUIInStart;

	/// <summary>
	///     Global indicator if the input is currently blocked by the GUIManager.
	/// </summary>
	internal static bool InputBlocked;

	/// <summary>
	///     Counter to track multiple block requests.
	/// </summary>
	private static int InputBlockRequests;

	/// <summary>
	///     Singleton instance
	/// </summary>
	public static GUIManager Instance => _instance ?? (_instance = new GUIManager());

	/// <summary>
	///     GUI container with automatic scaling for high res displays.
	///     Gets rebuild at every scene change so make sure to add your custom
	///     GUI prefabs again on each scene change.
	/// </summary>
	[Obsolete("Use CustomGUIFront or CustomGUIBack")]
	public static GameObject PixelFix { get; private set; }

	/// <summary>
	///     GUI container in front of Valheim's GUI elements with automatic scaling for
	///     high res displays and pixel correction.
	///     Gets rebuild at every scene change so make sure to add your custom
	///     GUI prefabs again on each scene change.
	/// </summary>
	public static GameObject CustomGUIFront { get; private set; }

	/// <summary>
	///     GUI container behind Valheim's GUI elements with automatic scaling for
	///     high res displays and pixel correction.
	///     Gets rebuild at every scene change so make sure to add your custom
	///     GUI prefabs again on each scene change.
	/// </summary>
	public static GameObject CustomGUIBack { get; private set; }

	/// <summary>
	///     Valheim's standard font, normal faced.
	/// </summary>
	public Font AveriaSerif { get; private set; }

	/// <summary>
	///     Valheim's standard font, bold faced.
	/// </summary>
	public Font AveriaSerifBold { get; private set; }

	/// <summary>
	///     Valheim's rune-like font, normal faced.
	/// </summary>
	public Font Norse { get; private set; }

	/// <summary>
	///     Valheim's rune-like font, bold faced.
	/// </summary>
	public Font NorseBold { get; private set; }

	/// <summary>
	///     Valheim's standard font as a TMPro FontAsset
	/// </summary>
	public TMP_FontAsset TMP_AveriaSansLibre { get; private set; }

	/// <summary>
	///     Valheim's rune-like font as a TMPro FontAsset
	/// </summary>
	public TMP_FontAsset TMP_Norse { get; private set; }

	/// <summary>
	///     Event that gets fired every time the Unity scene changed and a new PixelFix
	///     object was created. Subscribe to this event to create your custom GUI objects
	///     and add them as a child to the <see cref="P:Jotunn.Managers.GUIManager.PixelFix" />.
	/// </summary>
	[Obsolete("Use OnCustomGUIAvailable")]
	public static event Action OnPixelFixCreated;

	/// <summary>
	///     Event that gets fired every time the Unity scene changed and new CustomGUI 
	///     objects were created. Subscribe to this event to create your custom GUI objects
	///     and add them as a child to either <see cref="P:Jotunn.Managers.GUIManager.CustomGUIFront" /> or <see cref="P:Jotunn.Managers.GUIManager.CustomGUIBack" />.
	/// </summary>
	public static event Action OnCustomGUIAvailable;

	/// <summary>
	///     Hide .ctor
	/// </summary>
	private GUIManager()
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		ColorBlock val = default(ColorBlock);
		((ColorBlock)(ref val)).normalColor = new Color(0.926f, 0.645f, 0.34f, 1f);
		((ColorBlock)(ref val)).highlightedColor = new Color(1f, 0.786f, 0.088f, 1f);
		((ColorBlock)(ref val)).pressedColor = new Color(0.838f, 0.647f, 0.03f, 1f);
		((ColorBlock)(ref val)).selectedColor = new Color(1f, 0.786f, 0.088f, 1f);
		((ColorBlock)(ref val)).disabledColor = new Color(0.784f, 0.784f, 0.784f, 0.502f);
		((ColorBlock)(ref val)).colorMultiplier = 1f;
		((ColorBlock)(ref val)).fadeDuration = 0.1f;
		ValheimScrollbarHandleColorBlock = val;
		val = default(ColorBlock);
		((ColorBlock)(ref val)).normalColor = new Color(0.61f, 0.61f, 0.61f, 1f);
		((ColorBlock)(ref val)).highlightedColor = new Color(1f, 1f, 1f, 1f);
		((ColorBlock)(ref val)).pressedColor = new Color(0.784f, 0.784f, 0.784f, 1f);
		((ColorBlock)(ref val)).selectedColor = new Color(1f, 1f, 1f, 1f);
		((ColorBlock)(ref val)).disabledColor = new Color(0.784f, 0.784f, 0.784f, 0.502f);
		((ColorBlock)(ref val)).colorMultiplier = 1f;
		((ColorBlock)(ref val)).fadeDuration = 0.1f;
		ValheimToggleColorBlock = val;
		val = default(ColorBlock);
		((ColorBlock)(ref val)).normalColor = new Color(0.824f, 0.824f, 0.824f, 1f);
		((ColorBlock)(ref val)).highlightedColor = new Color(1.3f, 1.3f, 1.3f, 1f);
		((ColorBlock)(ref val)).pressedColor = new Color(0.537f, 0.556f, 0.556f, 1f);
		((ColorBlock)(ref val)).selectedColor = new Color(0.824f, 0.824f, 0.824f, 1f);
		((ColorBlock)(ref val)).disabledColor = new Color(0.566f, 0.566f, 0.566f, 0.502f);
		((ColorBlock)(ref val)).colorMultiplier = 1f;
		((ColorBlock)(ref val)).fadeDuration = 0.1f;
		ValheimButtonColorBlock = val;
		base._002Ector();
	}

	static GUIManager()
	{
		((IManager)Instance).Init();
	}

	/// <summary>
	///     Detect headless mode (aka dedicated server)
	/// </summary>
	/// <returns></returns>
	public static bool IsHeadless()
	{
		return GUIUtils.IsHeadless;
	}

	/// <summary>
	///     Block all input except GUI
	/// </summary>
	/// <param name="state">Indicator if the input should be blocked or released</param>
	public static void BlockInput(bool state)
	{
		if (!IsHeadless() && SceneManager.GetActiveScene().name == "main")
		{
			if (state)
			{
				InputBlockRequests++;
			}
			else
			{
				InputBlockRequests = Math.Max(--InputBlockRequests, 0);
			}
			if (!InputBlocked && InputBlockRequests > 0)
			{
				EnableInputBlock();
			}
			if (InputBlocked && InputBlockRequests == 0)
			{
				ResetInputBlock();
			}
		}
	}

	private static bool IsInputBlocked()
	{
		return InputBlocked;
	}

	/// <summary>
	///     Enable the InputBlock
	/// </summary>
	private static void EnableInputBlock()
	{
		InputBlocked = true;
		if ((bool)GameCamera.instance)
		{
			GameCamera.instance.m_mouseCapture = false;
			GameCamera.instance.UpdateMouseCapture();
		}
	}

	/// <summary>
	///     Reset the InputBlock to its initial state (disabled)
	/// </summary>
	private static void ResetInputBlock()
	{
		InputBlocked = false;
		InputBlockRequests = 0;
		if ((bool)GameCamera.instance)
		{
			GameCamera.instance.m_mouseCapture = true;
			GameCamera.instance.UpdateMouseCapture();
		}
	}

	private static void TakeInput(ref bool __result)
	{
		if (InputBlocked)
		{
			__result = false;
		}
	}

	private static void TextInput_IsVisible(ref bool __result)
	{
		if (InputBlocked)
		{
			__result = true;
		}
	}

	/// <summary>
	///     Initialize the manager
	/// </summary>
	void IManager.Init()
	{
		Main.LogInit("GUIManager");
		if (!IsHeadless())
		{
			Instance.TryCreateGUI();
			Main.Harmony.PatchAll(typeof(Patches));
			InitializeAssets();
			SceneManager.sceneLoaded += delegate
			{
				InitializeAssets();
			};
			SceneManager.sceneLoaded += delegate
			{
				Instance.TryCreateGUI();
			};
		}
	}

	/// <summary>
	///     Prevents hiding the InventoryGui on an E press or similar when the GUIManager blocks the input
	/// </summary>
	/// <param name="instructions"></param>
	/// <returns></returns>
	private static IEnumerable<CodeInstruction> BlockUseTranspiler(IEnumerable<CodeInstruction> instructions)
	{
		Label? jumpLabel = null;
		return new CodeMatcher(instructions).MatchForward(true, new CodeMatch((CodeInstruction i) => i.Calls(AccessTools.Method(typeof(Menu), "IsVisible"))), new CodeMatch((CodeInstruction i) => i.Branches(out jumpLabel))).Advance(1).InsertAndAdvance(new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(GUIManager), "IsInputBlocked")), new CodeInstruction(OpCodes.Brtrue, jumpLabel))
			.InstructionEnumeration();
	}

	/// <summary>
	///     Load GUI assets on first start
	/// </summary>
	internal void InitializeAssets()
	{
		if (hasInitializedAssets)
		{
			return;
		}
		Scene activeScene = SceneManager.GetActiveScene();
		if (!(activeScene.name == "start") && !(activeScene.name == "main"))
		{
			return;
		}
		try
		{
			UIAtlas = PrefabManager.Cache.GetPrefab<SpriteAtlas>("UIAtlas");
			IconAtlas = PrefabManager.Cache.GetPrefab<SpriteAtlas>("IconAtlas");
			AssertMissingAsset(UIAtlas, "UIAtlas", "SpriteAtlas");
			AssertMissingAsset(IconAtlas, "IconAtlas", "SpriteAtlas");
			AveriaSerif = PrefabManager.Cache.GetPrefab<Font>("AveriaSerifLibre-Regular");
			AveriaSerifBold = PrefabManager.Cache.GetPrefab<Font>("AveriaSerifLibre-Bold");
			Norse = PrefabManager.Cache.GetPrefab<Font>("Norse");
			NorseBold = PrefabManager.Cache.GetPrefab<Font>("Norsebold");
			TMP_AveriaSansLibre = PrefabManager.Cache.GetPrefab<TMP_FontAsset>("Valheim-AveriaSansLibre");
			TMP_Norse = PrefabManager.Cache.GetPrefab<TMP_FontAsset>("Valheim-Norse");
			AssertMissingAsset((UnityEngine.Object)(object)AveriaSerif, "AveriaSerif", "Font");
			AssertMissingAsset((UnityEngine.Object)(object)AveriaSerifBold, "AveriaSerifBold", "Font");
			AssertMissingAsset((UnityEngine.Object)(object)Norse, "Norse", "Font");
			AssertMissingAsset((UnityEngine.Object)(object)NorseBold, "NorseBold", "Font");
			AssertMissingAsset((UnityEngine.Object)(object)TMP_AveriaSansLibre, "TMP_AveriaSansLibre", "TMP_FontAsset");
			AssertMissingAsset((UnityEngine.Object)(object)TMP_Norse, "TMP_Norse", "TMP_FontAsset");
			AssetBundle val = AssetUtils.LoadAssetBundleFromResources("jotunn", typeof(Main).Assembly);
			GameObject gameObject = val.LoadAsset<GameObject>("UIMaskStub");
			ValheimControlResources.standard = GetSprite("button");
			ValheimControlResources.background = GetSprite("text_field");
			ValheimControlResources.inputField = GetSprite("text_field");
			ValheimControlResources.knob = GetSprite("checkbox_marker");
			ValheimControlResources.checkmark = GetSprite("checkbox_marker");
			ValheimControlResources.dropdown = GetSprite("checkbox_marker");
			ValheimControlResources.mask = gameObject.GetComponent<Image>().sprite;
			val.Unload(false);
			AssetBundle val2 = AssetUtils.LoadAssetBundleFromResources("colorpicker", typeof(Main).Assembly);
			GameObject gameObject2 = val2.LoadAsset<GameObject>("ColorPicker");
			Image component = gameObject2.GetComponent<Image>();
			component.sprite = GetSprite("woodpanel_settings");
			component.type = (Type)1;
			component.pixelsPerUnitMultiplier = (GUIInStart ? 2f : 1f);
			((Graphic)component).material = PrefabManager.Cache.GetPrefab<Material>("litpanel");
			Text[] componentsInChildren = gameObject2.GetComponentsInChildren<Text>(includeInactive: true);
			foreach (Text val3 in componentsInChildren)
			{
				ApplyTextStyle(val3, ValheimOrange, val3.fontSize);
			}
			InputField[] componentsInChildren2 = gameObject2.GetComponentsInChildren<InputField>(includeInactive: true);
			foreach (InputField field in componentsInChildren2)
			{
				ApplyInputFieldStyle(field, 13);
			}
			Button[] componentsInChildren3 = gameObject2.GetComponentsInChildren<Button>(includeInactive: true);
			foreach (Button button in componentsInChildren3)
			{
				ApplyButtonStyle(button, 13);
			}
			PrefabManager.Instance.AddPrefab(gameObject2, Main.Instance.Info.Metadata);
			GameObject gameObject3 = val2.LoadAsset<GameObject>("GradientPicker");
			Image component2 = gameObject3.GetComponent<Image>();
			component2.sprite = GetSprite("woodpanel_settings");
			component2.type = (Type)1;
			component2.pixelsPerUnitMultiplier = (GUIInStart ? 2f : 1f);
			((Graphic)component2).material = PrefabManager.Cache.GetPrefab<Material>("litpanel");
			Text[] componentsInChildren4 = gameObject3.GetComponentsInChildren<Text>(includeInactive: true);
			foreach (Text val4 in componentsInChildren4)
			{
				ApplyTextStyle(val4, ValheimOrange, val4.fontSize);
			}
			InputField[] componentsInChildren5 = gameObject3.GetComponentsInChildren<InputField>(includeInactive: true);
			foreach (InputField field2 in componentsInChildren5)
			{
				ApplyInputFieldStyle(field2, 13);
			}
			Button[] componentsInChildren6 = gameObject3.GetComponentsInChildren<Button>(includeInactive: true);
			foreach (Button val5 in componentsInChildren6)
			{
				if (((UnityEngine.Object)(object)val5).name != "ColorButton")
				{
					ApplyButtonStyle(val5, 13);
				}
			}
			PrefabManager.Instance.AddPrefab(gameObject3, Main.Instance.Info.Metadata);
			val2.Unload(false);
		}
		catch (Exception data)
		{
			Logger.LogError(data);
		}
		finally
		{
			hasInitializedAssets = true;
		}
	}

	private void AssertMissingAsset(UnityEngine.Object asset, string name, string type)
	{
		if (!asset)
		{
			Logger.LogWarning(name + " (" + type + ") not found");
		}
	}

	private bool TryCreateGUI()
	{
		Scene activeScene = SceneManager.GetActiveScene();
		GUIInStart = activeScene.name == "start";
		ResetInputBlock();
		if (!activeScene.isLoaded)
		{
			return false;
		}
		if ((bool)CustomGUIFront && (bool)CustomGUIBack)
		{
			return true;
		}
		Transform transform = FindGUIRoot();
		if ((bool)transform)
		{
			CustomGUIFront = CreateCustomGUI("CustomGUIFront", 2000, transform);
			CustomGUIFront.transform.SetAsLastSibling();
			CustomGUIBack = CreateCustomGUI("CustomGUIBack", 0, transform);
			CustomGUIBack.transform.SetAsFirstSibling();
			PixelFix = CustomGUIFront;
			InvokeOnPixelFixCreated();
			InvokeOnCustomGUIAvailable();
			return true;
		}
		return false;
	}

	private static Transform FindGUIRoot()
	{
		GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
		GameObject[] array = rootGameObjects;
		foreach (GameObject gameObject in array)
		{
			string name = gameObject.name;
			if (name == "GuiRoot")
			{
				return gameObject.transform.Find("GUI");
			}
			if (name == "_GameMain")
			{
				return gameObject.transform.Find("LoadingGUI");
			}
		}
		return null;
	}

	/// <summary>
	///     Create GameObjects for mods to append their custom GUI to
	/// </summary>
	/// <param name="name"></param>
	/// <param name="sortingOrder"></param>
	/// <param name="parent"></param>
	private GameObject CreateCustomGUI(string name, int sortingOrder, Transform parent)
	{
		GameObject gameObject = new GameObject(name, typeof(RectTransform), typeof(GuiPixelFix), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
		gameObject.layer = 5;
		gameObject.transform.SetParent(parent.transform, worldPositionStays: false);
		RectTransform component = gameObject.GetComponent<RectTransform>();
		component.anchorMin = Vector2.zero;
		component.anchorMax = Vector2.one;
		component.offsetMin = Vector2.zero;
		component.offsetMax = Vector2.zero;
		component.anchoredPosition = Vector2.zero;
		Canvas component2 = gameObject.GetComponent<Canvas>();
		component2.additionalShaderChannels = (AdditionalCanvasShaderChannels)25;
		component2.renderMode = (RenderMode)0;
		component2.overrideSorting = true;
		component2.sortingOrder = sortingOrder;
		CanvasScaler component3 = gameObject.GetComponent<CanvasScaler>();
		component3.referencePixelsPerUnit = 50f;
		return gameObject;
	}

	[Obsolete]
	private void InvokeOnPixelFixCreated()
	{
		GUIManager.OnPixelFixCreated?.SafeInvoke();
	}

	private void InvokeOnCustomGUIAvailable()
	{
		GUIManager.OnCustomGUIAvailable?.SafeInvoke();
	}

	/// <summary>
	///     Add a <see cref="T:Jotunn.Configs.KeyHintConfig" /> to the manager.<br />
	///     Checks if the custom key hint is unique (i.e. the first one registered for an item).<br />
	///     Custom status effects are displayed in the game instead of the default 
	///     KeyHints for equipped tools or weapons they are registered for.
	/// </summary>
	/// <param name="hintConfig">The custom key hint config to add.</param>
	/// <returns>true if the custom key hint config was added to the manager.</returns>
	[Obsolete("Use KeyHintManager.AddKeyHint instead")]
	public bool AddKeyHint(KeyHintConfig hintConfig)
	{
		return KeyHintManager.Instance.AddKeyHint(hintConfig);
	}

	/// <summary>
	///     Removes a <see cref="T:Jotunn.Configs.KeyHintConfig" /> from the game.
	/// </summary>
	/// <param name="hintConfig">The custom key hint config to add.</param>
	[Obsolete("Use KeyHintManager.RemoveKeyHint instead")]
	public void RemoveKeyHint(KeyHintConfig hintConfig)
	{
		KeyHintManager.Instance.RemoveKeyHint(hintConfig);
	}

	/// <summary>
	///     Get a sprite by name.
	/// </summary>
	/// <param name="spriteName">The sprite name</param>
	/// <returns>The sprite with given name</returns>
	public Sprite GetSprite(string spriteName)
	{
		Sprite sprite = UIAtlas?.GetSprite(spriteName);
		if (sprite != null)
		{
			return sprite;
		}
		sprite = IconAtlas?.GetSprite(spriteName);
		if (sprite != null)
		{
			return sprite;
		}
		sprite = PrefabManager.Cache.GetPrefab<Sprite>(spriteName);
		if (sprite != null)
		{
			return sprite;
		}
		Logger.LogWarning("Sprite " + spriteName + " not found.");
		return null;
	}

	/// <summary>
	///     Creates and displays a Valheim style ColorPicker
	/// </summary>
	/// <param name="anchorMin">Min anchor on first instantiation</param>
	/// <param name="anchorMax">Max anchor on first instantiation</param>
	/// <param name="position">Position on first instantiation</param>
	/// <param name="original">Color before editing</param>
	/// <param name="message">Display message</param>
	/// <param name="onColorChanged">Event that gets called when the color gets modified</param>
	/// <param name="onColorSelected">Event that gets called when one of the buttons done or cancel get pressed</param>
	/// <param name="useAlpha">When set to false the colors used don't have an alpha channel</param>
	/// <returns></returns>
	public void CreateColorPicker(Vector2 anchorMin, Vector2 anchorMax, Vector2 position, Color original, string message, ColorPicker.ColorEvent onColorChanged, ColorPicker.ColorEvent onColorSelected, bool useAlpha = false)
	{
		if (CustomGUIFront == null)
		{
			Logger.LogError("GUIManager CustomGUIFront is null");
			return;
		}
		GameObject prefab = PrefabManager.Instance.GetPrefab("ColorPicker");
		if (prefab == null)
		{
			Logger.LogError("ColorPicker is null");
		}
		if (CustomGUIFront.transform.Find("ColorPicker") == null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(prefab, CustomGUIFront.transform, worldPositionStays: false);
			gameObject.name = "ColorPicker";
			gameObject.GetComponent<Image>().pixelsPerUnitMultiplier = (GUIInStart ? 2f : 1f);
			RectTransform component = gameObject.GetComponent<RectTransform>();
			component.anchoredPosition = position;
			component.anchorMin = anchorMin;
			component.anchorMax = anchorMax;
		}
		CustomGUIFront.transform.Find("ColorPicker").SetAsLastSibling();
		ColorPicker.Create(original, message, onColorChanged, onColorSelected, useAlpha);
	}

	/// <summary>
	///     Creates and displays a Valheim style GradientPicker
	/// </summary>
	/// <param name="anchorMin">Min anchor on first instantiation</param>
	/// <param name="anchorMax">Max anchor on first instantiation</param>
	/// <param name="position">Position on first instantiation</param>
	/// <param name="original">Color before editing</param>
	/// <param name="message">Display message</param>
	/// <param name="onGradientChanged">Event that gets called when the gradient gets modified</param>
	/// <param name="onGradientSelected">Event that gets called when one of the buttons done or cancel gets pressed</param>
	/// <returns></returns>
	public void CreateGradientPicker(Vector2 anchorMin, Vector2 anchorMax, Vector2 position, Gradient original, string message, GradientPicker.GradientEvent onGradientChanged, GradientPicker.GradientEvent onGradientSelected)
	{
		if (CustomGUIFront == null)
		{
			Logger.LogError("GUIManager CustomGUIFront is null");
			return;
		}
		GameObject prefab = PrefabManager.Instance.GetPrefab("GradientPicker");
		if (prefab == null)
		{
			Logger.LogError("GradientPicker is null");
		}
		GameObject prefab2 = PrefabManager.Instance.GetPrefab("ColorPicker");
		if (prefab2 == null)
		{
			Logger.LogError("ColorPicker is null");
		}
		if (CustomGUIFront.transform.Find("GradientPicker") == null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(prefab, CustomGUIFront.transform, worldPositionStays: false);
			gameObject.name = "GradientPicker";
			gameObject.GetComponent<Image>().pixelsPerUnitMultiplier = (GUIInStart ? 2f : 1f);
			RectTransform component = gameObject.GetComponent<RectTransform>();
			component.anchoredPosition = position;
			component.anchorMin = anchorMin;
			component.anchorMax = anchorMax;
		}
		CustomGUIFront.transform.Find("GradientPicker").SetAsLastSibling();
		if (CustomGUIFront.transform.Find("ColorPicker") == null)
		{
			GameObject gameObject2 = UnityEngine.Object.Instantiate(prefab2, CustomGUIFront.transform, worldPositionStays: false);
			gameObject2.name = "ColorPicker";
			gameObject2.GetComponent<Image>().pixelsPerUnitMultiplier = (GUIInStart ? 2f : 1f);
		}
		CustomGUIFront.transform.Find("ColorPicker").SetAsLastSibling();
		GradientPicker.Create(original, message, onGradientChanged, onGradientSelected);
	}

	/// <summary>
	///     Creates a Valheim style woodpanel which is draggable per default
	/// </summary>
	/// <param name="parent">Parent <see cref="T:UnityEngine.Transform" /></param>
	/// <param name="anchorMin">Minimal anchor</param>
	/// <param name="anchorMax">Maximal anchor</param>
	/// <param name="position">Anchored position</param>
	/// <param name="width">Optional width</param>
	/// <param name="height">Optional height</param>
	/// <returns>A <see cref="T:UnityEngine.GameObject" /> as a Valheim style woodpanel</returns>
	public GameObject CreateWoodpanel(Transform parent, Vector2 anchorMin, Vector2 anchorMax, Vector2 position, float width = 0f, float height = 0f)
	{
		return CreateWoodpanel(parent, anchorMin, anchorMax, position, width, height, draggable: true);
	}

	/// <summary>
	///     Creates a Valheim style woodpanel, can optionally be draggable
	/// </summary>
	/// <param name="parent">Parent <see cref="T:UnityEngine.Transform" /></param>
	/// <param name="anchorMin">Minimal anchor</param>
	/// <param name="anchorMax">Maximal anchor</param>
	/// <param name="position">Anchored position</param>
	/// <param name="width">Optional width</param>
	/// <param name="height">Optional height</param>
	/// <param name="draggable">Optional flag if the panel should be draggable (default true)</param>
	/// <returns>A <see cref="T:UnityEngine.GameObject" /> as a Valheim style woodpanel</returns>
	public GameObject CreateWoodpanel(Transform parent, Vector2 anchorMin, Vector2 anchorMax, Vector2 position, float width = 0f, float height = 0f, bool draggable = true)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		GameObject gameObject = DefaultControls.CreatePanel(ValheimControlResources);
		gameObject.transform.SetParent(parent, worldPositionStays: false);
		ApplyWoodpanelStyle(gameObject.transform);
		gameObject.GetComponent<Image>().pixelsPerUnitMultiplier = (GUIInStart ? 2f : 1f);
		RectTransform rectTransform = (RectTransform)gameObject.transform;
		rectTransform.anchoredPosition = position;
		rectTransform.anchorMin = anchorMin;
		rectTransform.anchorMax = anchorMax;
		if (width > 0f)
		{
			rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
		}
		if (height > 0f)
		{
			rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
		}
		if (draggable)
		{
			gameObject.AddComponent<DragWindowCntrl>();
		}
		return gameObject;
	}

	/// <summary>
	///     Create a complete scroll view
	/// </summary>
	/// <param name="parent">parent transform</param>
	/// <param name="showHorizontalScrollbar">show horizontal scrollbar</param>
	/// <param name="showVerticalScrollbar">show vertical scrollbar</param>
	/// <param name="handleSize">size of the handle</param>
	/// <param name="handleDistanceToBorder"></param>
	/// <param name="handleColors">Colorblock for the handle</param>
	/// <param name="slidingAreaBackgroundColor">Background color for the sliding area</param>
	/// <param name="width">rect width</param>
	/// <param name="height">rect height</param>
	/// <returns></returns>
	public GameObject CreateScrollView(Transform parent, bool showHorizontalScrollbar, bool showVerticalScrollbar, float handleSize, float handleDistanceToBorder, ColorBlock handleColors, Color slidingAreaBackgroundColor, float width, float height)
	{
		//IL_042c: Unknown result type (might be due to invalid IL or missing references)
		//IL_070d: Unknown result type (might be due to invalid IL or missing references)
		GameObject gameObject = new GameObject("Canvas", typeof(RectTransform), typeof(CanvasGroup), typeof(GraphicRaycaster));
		gameObject.GetComponent<Canvas>().sortingOrder = 0;
		gameObject.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
		gameObject.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
		gameObject.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
		gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 0f);
		gameObject.GetComponent<RectTransform>().position = new Vector3(0f, 0f, 0f);
		gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);
		gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
		gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
		gameObject.GetComponent<CanvasGroup>().interactable = true;
		gameObject.GetComponent<CanvasGroup>().ignoreParentGroups = true;
		gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
		gameObject.GetComponent<CanvasGroup>().alpha = 1f;
		gameObject.transform.SetParent(parent, worldPositionStays: false);
		GameObject gameObject2 = new GameObject("Scroll View", typeof(Image), typeof(ScrollRect), typeof(Mask)).SetUpperRight();
		gameObject2.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
		gameObject2.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
		((Graphic)gameObject2.GetComponent<Image>()).color = new Color(0f, 0f, 0f, 1f);
		gameObject2.GetComponent<ScrollRect>().horizontal = showHorizontalScrollbar;
		gameObject2.GetComponent<ScrollRect>().vertical = showVerticalScrollbar;
		gameObject2.GetComponent<ScrollRect>().horizontalScrollbarVisibility = (ScrollbarVisibility)1;
		gameObject2.GetComponent<ScrollRect>().verticalScrollbarVisibility = (ScrollbarVisibility)2;
		gameObject2.GetComponent<ScrollRect>().scrollSensitivity = 35f;
		gameObject2.GetComponent<Mask>().showMaskGraphic = false;
		gameObject2.transform.SetParent(gameObject.transform, worldPositionStays: false);
		GameObject gameObject3 = new GameObject("Viewport", typeof(RectTransform), typeof(CanvasRenderer), typeof(Image));
		gameObject3.GetComponent<RectTransform>().anchorMin = new Vector2(0f, 1f);
		gameObject3.GetComponent<RectTransform>().anchorMax = new Vector2(0f, 1f);
		gameObject3.GetComponent<RectTransform>().pivot = new Vector2(0f, 1f);
		gameObject3.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
		gameObject3.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
		((Graphic)gameObject3.GetComponent<Image>()).color = new Color(0f, 0f, 0f, 0f);
		gameObject3.transform.SetParent(gameObject2.transform, worldPositionStays: false);
		gameObject2.GetComponent<ScrollRect>().viewport = gameObject3.GetComponent<RectTransform>();
		if (showHorizontalScrollbar)
		{
			GameObject gameObject4 = new GameObject("Scrollbar horizontal", typeof(RectTransform), typeof(CanvasRenderer), typeof(Image), typeof(Scrollbar));
			gameObject4.transform.SetParent(gameObject2.transform, worldPositionStays: false);
			gameObject2.GetComponent<ScrollRect>().horizontalScrollbar = gameObject4.GetComponent<Scrollbar>();
			gameObject4.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 1f);
			gameObject4.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 1f);
			gameObject4.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1f);
			gameObject4.GetComponent<RectTransform>().anchoredPosition = new Vector2((0f - handleSize) / 2f, 0f - height + handleSize);
			gameObject4.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width - 2f * handleDistanceToBorder - handleSize);
			gameObject4.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, handleSize);
			((Graphic)gameObject4.GetComponent<Image>()).color = slidingAreaBackgroundColor;
			((Selectable)gameObject4.GetComponent<Scrollbar>()).colors = handleColors;
			GameObject gameObject5 = new GameObject("Sliding Area", typeof(RectTransform));
			gameObject5.GetComponent<RectTransform>().anchorMin = new Vector2(0f, 1f);
			gameObject5.GetComponent<RectTransform>().anchorMax = new Vector2(0f, 1f);
			gameObject5.GetComponent<RectTransform>().pivot = new Vector2(0f, 0.5f);
			gameObject5.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);
			gameObject5.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width - 2f * handleDistanceToBorder - handleSize);
			gameObject5.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, handleSize);
			gameObject5.transform.SetParent(gameObject4.transform, worldPositionStays: false);
			GameObject gameObject6 = new GameObject("Handle", typeof(RectTransform), typeof(Image));
			gameObject6.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, (0f - handleSize) / 2f);
			gameObject6.transform.SetParent(gameObject5.transform, worldPositionStays: false);
			gameObject6.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, handleSize / 2f);
			gameObject6.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, handleSize / 2f);
			gameObject6.GetComponent<Image>().sprite = GetSprite("UISprite");
			gameObject6.GetComponent<Image>().type = (Type)1;
			gameObject4.GetComponent<Scrollbar>().size = 0.4f;
			gameObject4.GetComponent<Scrollbar>().handleRect = gameObject6.GetComponent<RectTransform>();
			((Selectable)gameObject4.GetComponent<Scrollbar>()).targetGraphic = (Graphic)(object)gameObject6.GetComponent<Image>();
			gameObject4.GetComponent<Scrollbar>().direction = (Direction)0;
		}
		if (showVerticalScrollbar)
		{
			GameObject gameObject7 = new GameObject("Scrollbar Vertical", typeof(RectTransform), typeof(CanvasRenderer), typeof(Image), typeof(Scrollbar));
			gameObject7.transform.SetParent(gameObject2.transform, worldPositionStays: false);
			gameObject2.GetComponent<ScrollRect>().verticalScrollbar = gameObject7.GetComponent<Scrollbar>();
			gameObject7.GetComponent<RectTransform>().anchorMin = new Vector2(1f, 0.5f);
			gameObject7.GetComponent<RectTransform>().anchorMax = new Vector2(1f, 0.5f);
			gameObject7.GetComponent<RectTransform>().pivot = new Vector2(1f, 0.5f);
			gameObject7.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, (0f - handleSize) / 2f);
			gameObject7.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, handleSize);
			gameObject7.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height - 2f * handleDistanceToBorder - handleSize);
			((Graphic)gameObject7.GetComponent<Image>()).color = slidingAreaBackgroundColor;
			((Selectable)gameObject7.GetComponent<Scrollbar>()).colors = handleColors;
			GameObject gameObject8 = new GameObject("Sliding Area", typeof(RectTransform));
			gameObject8.GetComponent<RectTransform>().anchorMin = new Vector2(0f, 1f);
			gameObject8.GetComponent<RectTransform>().anchorMax = new Vector2(0f, 1f);
			gameObject8.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1f);
			gameObject8.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);
			gameObject8.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, handleSize);
			gameObject8.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height - 2f * handleDistanceToBorder - handleSize);
			gameObject8.transform.SetParent(gameObject7.transform, worldPositionStays: false);
			GameObject gameObject9 = new GameObject("Handle", typeof(RectTransform), typeof(Image));
			gameObject9.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
			gameObject9.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
			gameObject9.GetComponent<RectTransform>().anchoredPosition = new Vector2(handleSize / 2f, 0f);
			gameObject9.transform.SetParent(gameObject8.transform, worldPositionStays: false);
			gameObject9.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, handleSize / 2f);
			gameObject9.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, handleSize / 2f);
			gameObject9.GetComponent<Image>().sprite = GetSprite("UISprite");
			gameObject9.GetComponent<Image>().type = (Type)1;
			gameObject7.GetComponent<Scrollbar>().size = 0.4f;
			gameObject7.GetComponent<Scrollbar>().handleRect = gameObject9.GetComponent<RectTransform>();
			((Selectable)gameObject7.GetComponent<Scrollbar>()).targetGraphic = (Graphic)(object)gameObject9.GetComponent<Image>();
			gameObject7.GetComponent<Scrollbar>().size = handleSize;
			gameObject7.GetComponent<Scrollbar>().direction = (Direction)2;
			gameObject7.GetComponent<Scrollbar>().SetValueWithoutNotify(1f);
		}
		GameObject gameObject10 = new GameObject("Content", typeof(RectTransform), typeof(VerticalLayoutGroup), typeof(Canvas), typeof(GraphicRaycaster), typeof(ContentSizeFitter));
		gameObject10.GetComponent<Canvas>().planeDistance = 5.2f;
		gameObject10.GetComponent<RectTransform>().anchorMin = new Vector2(0f, 1f);
		gameObject10.GetComponent<RectTransform>().anchorMax = new Vector2(0f, 1f);
		gameObject10.GetComponent<RectTransform>().pivot = new Vector2(0f, 1f);
		gameObject10.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width - 2f * handleDistanceToBorder - handleSize);
		gameObject10.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height - 2f * handleDistanceToBorder - handleSize);
		((LayoutGroup)gameObject10.GetComponent<VerticalLayoutGroup>()).childAlignment = (TextAnchor)0;
		((HorizontalOrVerticalLayoutGroup)gameObject10.GetComponent<VerticalLayoutGroup>()).childForceExpandWidth = true;
		((HorizontalOrVerticalLayoutGroup)gameObject10.GetComponent<VerticalLayoutGroup>()).childForceExpandHeight = false;
		((HorizontalOrVerticalLayoutGroup)gameObject10.GetComponent<VerticalLayoutGroup>()).childControlHeight = true;
		((HorizontalOrVerticalLayoutGroup)gameObject10.GetComponent<VerticalLayoutGroup>()).childControlWidth = showHorizontalScrollbar;
		gameObject10.transform.SetParent(gameObject3.transform, worldPositionStays: false);
		gameObject10.GetComponent<ContentSizeFitter>().verticalFit = (FitMode)2;
		gameObject2.GetComponent<ScrollRect>().content = gameObject10.GetComponent<RectTransform>();
		return gameObject;
	}

	/// <summary>
	///     Create a <see cref="T:UnityEngine.GameObject" /> with a Text (and optional Outline and ContentSizeFitter) component
	/// </summary>
	/// <param name="text">Text to show</param>
	/// <param name="parent">Parent transform</param>
	/// <param name="anchorMin">Anchor min</param>
	/// <param name="anchorMax">Anchor max</param>
	/// <param name="position">Anchored position</param>
	/// <param name="font">Font</param>
	/// <param name="fontSize">Font size</param>
	/// <param name="color">Font color</param>
	/// <param name="outline">Add outline component</param>
	/// <param name="outlineColor">Outline color</param>
	/// <param name="width">Width</param>
	/// <param name="height">Height</param>
	/// <param name="addContentSizeFitter">Add ContentSizeFitter</param>
	/// <returns>A text <see cref="T:UnityEngine.GameObject" /></returns>
	public GameObject CreateText(string text, Transform parent, Vector2 anchorMin, Vector2 anchorMax, Vector2 position, Font font, int fontSize, Color color, bool outline, Color outlineColor, float width, float height, bool addContentSizeFitter)
	{
		GameObject gameObject = new GameObject("Text", typeof(RectTransform), typeof(Text));
		RectTransform component = gameObject.GetComponent<RectTransform>();
		component.anchorMin = anchorMin;
		component.anchorMax = anchorMax;
		component.anchoredPosition = position;
		if (!addContentSizeFitter)
		{
			component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
			component.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
		}
		else
		{
			gameObject.AddComponent<ContentSizeFitter>().verticalFit = (FitMode)2;
		}
		Text component2 = gameObject.GetComponent<Text>();
		component2.text = text;
		ApplyTextStyle(component2, font, color, fontSize, outline);
		if (gameObject.TryGetComponent<Outline>(out var component3))
		{
			((Shadow)component3).effectColor = outlineColor;
		}
		gameObject.transform.SetParent(parent, worldPositionStays: false);
		return gameObject;
	}

	/// <summary>
	///     Create a new button (Valheim style).
	/// </summary>
	/// <param name="text">Text to display on the button</param>
	/// <param name="parent">Parent transform</param>
	/// <param name="anchorMin">Min anchor</param>
	/// <param name="anchorMax">Max anchor</param>
	/// <param name="position">Position</param>
	/// <param name="width">Set width if &gt; 0</param>
	/// <param name="height">Set height if &gt; 0</param>
	/// <returns>Button GameObject in Valheim style</returns>
	public GameObject CreateButton(string text, Transform parent, Vector2 anchorMin, Vector2 anchorMax, Vector2 position, float width = 0f, float height = 0f)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		GameObject gameObject = DefaultControls.CreateButton(ValheimControlResources);
		gameObject.transform.SetParent(parent, worldPositionStays: false);
		ApplyButtonStyle(gameObject.GetComponent<Button>());
		Text componentInChildren = gameObject.GetComponentInChildren<Text>();
		componentInChildren.text = text;
		RectTransform rectTransform = gameObject.transform as RectTransform;
		rectTransform.anchoredPosition = position;
		rectTransform.anchorMin = anchorMin;
		rectTransform.anchorMax = anchorMax;
		if (width > 0f)
		{
			rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
			((Component)(object)componentInChildren).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
		}
		if (height > 0f)
		{
			rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
			((Component)(object)componentInChildren).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
		}
		return gameObject;
	}

	/// <summary>
	///     Create a new InputField (Valheim style).
	/// </summary>
	/// <param name="parent">Parent transform</param>
	/// <param name="anchorMin">Min anchor</param>
	/// <param name="anchorMax">Max anchor</param>
	/// <param name="position">Position</param>
	/// <param name="contentType">Content type for the input field</param>
	/// <param name="placeholderText">Text to display as a placeholder (can be null)</param>
	/// <param name="fontSize">Optional font size, defaults to 16</param>
	/// <param name="width">Set width if &gt; 0</param>
	/// <param name="height">Set height if &gt; 0</param>
	/// <returns>Input field GameObject in Valheim style</returns>
	public GameObject CreateInputField(Transform parent, Vector2 anchorMin, Vector2 anchorMax, Vector2 position, ContentType contentType = (ContentType)0, string placeholderText = null, int fontSize = 16, float width = 0f, float height = 0f)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		GameObject gameObject = DefaultControls.CreateInputField(ValheimControlResources);
		gameObject.transform.SetParent(parent, worldPositionStays: false);
		InputField component = gameObject.GetComponent<InputField>();
		ApplyInputFieldStyle(component, fontSize);
		component.contentType = contentType;
		if (!string.IsNullOrEmpty(placeholderText))
		{
			Graphic placeholder = component.placeholder;
			Text val = (Text)(object)((placeholder is Text) ? placeholder : null);
			if (val != null)
			{
				val.text = placeholderText;
			}
		}
		RectTransform rectTransform = gameObject.transform as RectTransform;
		rectTransform.anchoredPosition = position;
		rectTransform.anchorMin = anchorMin;
		rectTransform.anchorMax = anchorMax;
		if (width > 0f)
		{
			gameObject.SetWidth(width);
			((Component)(object)component.placeholder).gameObject.SetWidth(width - 20f);
			((Component)(object)component.textComponent).gameObject.SetWidth(width - 20f);
		}
		if (height > 0f)
		{
			gameObject.SetHeight(height);
			((Component)(object)component.placeholder).gameObject.SetHeight(height - 10f);
			((Component)(object)component.textComponent).gameObject.SetHeight(height - 10f);
		}
		return gameObject;
	}

	/// <summary>
	///     Create toggle field
	/// </summary>
	/// <param name="parent">Parent transform</param>
	/// <param name="width">Set width</param>
	/// <param name="height">Set height</param>
	/// <returns></returns>
	public GameObject CreateToggle(Transform parent, float width, float height)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		GameObject gameObject = DefaultControls.CreateToggle(ValheimControlResources);
		gameObject.transform.SetParent(parent);
		Toggle component = gameObject.GetComponent<Toggle>();
		ApplyToogleStyle(component);
		gameObject.SetSize(width, height);
		gameObject.transform.Find("Background").gameObject.SetSize(width, height);
		gameObject.transform.Find("Background/Checkmark").gameObject.SetSize(width, height);
		return gameObject;
	}

	/// <summary>
	///     Create dropdown field
	/// </summary>
	/// <param name="parent">Parent transform</param>
	/// <param name="anchorMin">Min anchor</param>
	/// <param name="anchorMax">Max anchor</param>
	/// <param name="position">Position</param>
	/// <param name="fontSize">Optional font size, defaults to 16</param>
	/// <param name="width">Set width if &gt; 0</param>
	/// <param name="height">Set height if &gt; 0</param>
	/// <returns></returns>
	public GameObject CreateDropDown(Transform parent, Vector2 anchorMin, Vector2 anchorMax, Vector2 position, int fontSize = 16, float width = 0f, float height = 0f)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		GameObject gameObject = DefaultControls.CreateDropdown(ValheimControlResources);
		gameObject.transform.SetParent(parent, worldPositionStays: false);
		Dropdown component = gameObject.GetComponent<Dropdown>();
		component.ClearOptions();
		ApplyDropdownStyle(component, fontSize);
		RectTransform rectTransform = gameObject.transform as RectTransform;
		rectTransform.anchoredPosition = position;
		rectTransform.anchorMin = anchorMin;
		rectTransform.anchorMax = anchorMax;
		if (width > 0f)
		{
			float width2 = width - 50f;
			gameObject.SetWidth(width);
			((Component)(object)component.captionText).gameObject.SetMiddleLeft();
			((Component)(object)component.captionText).gameObject.SetWidth(width2);
			((Component)(object)component.captionText).GetComponent<RectTransform>().anchoredPosition = new Vector3(10f, 0f);
			((Component)(object)component.itemText).gameObject.SetWidth(width2);
		}
		if (height > 0f)
		{
			gameObject.SetHeight(height);
			((Component)(object)component.captionText).gameObject.SetMiddleLeft();
			((Component)(object)component.captionText).gameObject.SetHeight(height);
			((Component)(object)component.captionText).GetComponent<RectTransform>().anchoredPosition = new Vector3(10f, 0f);
			((Component)(object)component.itemText).gameObject.SetHeight(height);
		}
		return gameObject;
	}

	/// <summary>
	///     Create key binding field
	/// </summary>
	/// <param name="text"></param>
	/// <param name="parent"></param>
	/// <param name="width"></param>
	/// <param name="height"></param>
	/// <returns></returns>
	public GameObject CreateKeyBindField(string text, Transform parent, float width, float height)
	{
		GameObject gameObject = new GameObject("KeyBinding", typeof(RectTransform), typeof(LayoutElement)).SetUpperLeft().SetSize(width, height);
		gameObject.GetComponent<LayoutElement>().preferredWidth = width;
		GameObject gameObject2 = CreateText(text, gameObject.transform, new Vector2(0f, 0f), new Vector2(0f, 0f), new Vector2(0f, 0f), AveriaSerifBold, 16, ValheimOrange, outline: true, Color.black, width - 150f, 0f, addContentSizeFitter: false);
		gameObject2.GetComponent<Text>().verticalOverflow = (VerticalWrapMode)1;
		gameObject2.SetUpperLeft().SetToTextHeight();
		gameObject.SetHeight(gameObject2.GetTextHeight());
		gameObject.transform.SetParent(parent, worldPositionStays: false);
		GameObject gameObject3 = new GameObject("Button", typeof(RectTransform), typeof(Image), typeof(Button)).SetUpperRight().SetSize(140f, gameObject2.GetTextHeight());
		gameObject3.transform.SetParent(gameObject.transform, worldPositionStays: false);
		((Selectable)gameObject3.GetComponent<Button>()).image = gameObject3.GetComponent<Image>();
		gameObject3.GetComponent<Image>().sprite = GetSprite("text_field");
		GameObject gameObject4 = new GameObject("Text", typeof(RectTransform), typeof(Text)).SetMiddleCenter();
		Text component = gameObject4.GetComponent<Text>();
		ApplyTextStyle(component, component.fontSize);
		component.text = "";
		gameObject4.SetHeight(gameObject4.GetTextHeight() + height - 2f).SetWidth(gameObject3.GetComponent<RectTransform>().rect.width);
		gameObject4.SetMiddleLeft().GetComponent<Text>().alignment = (TextAnchor)4;
		gameObject3.SetHeight(gameObject4.GetTextHeight() + height);
		gameObject4.transform.SetParent(gameObject3.transform, worldPositionStays: false);
		return gameObject;
	}

	/// <summary>
	///     Apply Valheim style to a woodpanel.
	/// </summary>
	/// <param name="woodpanel"></param>
	public void ApplyWoodpanelStyle(Transform woodpanel)
	{
		woodpanel.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
		woodpanel.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
		woodpanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);
		woodpanel.GetComponent<Image>().sprite = GetSprite("woodpanel_trophys");
		woodpanel.GetComponent<Image>().type = (Type)1;
		woodpanel.GetComponent<Image>().pixelsPerUnitMultiplier = (GUIInStart ? 2f : 1f);
		((Graphic)woodpanel.GetComponent<Image>()).material = PrefabManager.Cache.GetPrefab<Material>("litpanel");
		((Graphic)woodpanel.GetComponent<Image>()).color = Color.white;
		woodpanel.gameObject.layer = 5;
	}

	/// <summary>
	///     Apply Valheim style to a <see cref="T:UnityEngine.UI.Text" /> Component
	/// </summary>
	/// <param name="text">Target component</param>
	/// <param name="font">Own font or <code>GUIManager.Instance.AveriaSerifBold</code>/<code>GUIManager.Instance.AveriaSerif</code></param>
	/// <param name="color">Custom color or <code>GUIManager.Instance.ValheimOrange</code></param>
	/// <param name="createOutline">creates an <see cref="T:UnityEngine.UI.Outline" /> component when true</param>
	/// <param name="fontSize">Optional font size, defaults to 16</param>
	public void ApplyTextStyle(Text text, Font font, Color color, int fontSize = 16, bool createOutline = true)
	{
		text.font = font;
		text.fontSize = fontSize;
		((Graphic)text).color = color;
		if (createOutline)
		{
			Outline orAddComponent = ((Component)(object)text).gameObject.GetOrAddComponent<Outline>();
			((Shadow)orAddComponent).effectColor = Color.black;
		}
	}

	/// <summary>
	///     Apply Valheim style to a <see cref="T:UnityEngine.UI.Text" /> Component.
	///     Uses <code>GUIManager.Instance.AveriaSerifBold</code> by default
	/// </summary>
	/// <param name="text">Target component</param>
	/// <param name="color">Custom color or <code>GUIManager.Instance.ValheimOrange</code></param>
	/// <param name="createOutline">creates an <see cref="T:UnityEngine.UI.Outline" /> component when true</param>
	/// <param name="fontSize">Optional font size, defaults to 16</param>
	public void ApplyTextStyle(Text text, Color color, int fontSize = 16, bool createOutline = true)
	{
		ApplyTextStyle(text, AveriaSerifBold, color, fontSize, createOutline);
	}

	/// <summary>
	///     Apply Valheim style to a <see cref="T:UnityEngine.UI.Text" /> Component.
	///     Uses <code>GUIManager.Instance.AveriaSerifBold</code>, <code>Color.white</code> and creates an outline by default
	/// </summary>
	/// <param name="text">Target component</param>
	/// <param name="fontSize">Optional font size, defaults to 16</param>
	public void ApplyTextStyle(Text text, int fontSize = 16)
	{
		ApplyTextStyle(text, AveriaSerifBold, Color.white, fontSize);
	}

	/// <summary>
	///     Apply valheim style to a <see cref="T:UnityEngine.UI.Button" /> Component
	/// </summary>
	/// <param name="button">Component to apply the style to</param>
	/// <param name="fontSize">Optional font size, defaults to 16</param>
	public void ApplyButtonStyle(Button button, int fontSize = 16)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		GameObject gameObject = ((Component)(object)button).gameObject;
		Image component = gameObject.GetComponent<Image>();
		if ((bool)(UnityEngine.Object)(object)component)
		{
			component.sprite = GetSprite("button");
			component.type = (Type)1;
			component.pixelsPerUnitMultiplier = (GUIInStart ? 2f : 1f);
			((Selectable)button).image = component;
		}
		if (!gameObject.TryGetComponent<ButtonSfx>(out var component2))
		{
			component2 = gameObject.AddComponent<ButtonSfx>();
		}
		component2.m_sfxPrefab = PrefabManager.Cache.GetPrefab<GameObject>("sfx_gui_button");
		component2.m_selectSfxPrefab = PrefabManager.Cache.GetPrefab<GameObject>("sfx_gui_select");
		((Selectable)gameObject.GetComponent<Button>()).colors = ValheimButtonColorBlock;
		Text componentInChildren = gameObject.GetComponentInChildren<Text>(includeInactive: true);
		if ((bool)(UnityEngine.Object)(object)componentInChildren)
		{
			ApplyTextStyle(componentInChildren, ValheimOrange, fontSize);
			componentInChildren.alignment = (TextAnchor)4;
		}
	}

	/// <summary>
	///     Apply Valheim style to an <see cref="T:UnityEngine.UI.InputField" /> Component.
	/// </summary>
	/// <param name="field">Component to apply the style to</param>
	[Obsolete("Only here for backward compat")]
	public void ApplyInputFieldStyle(InputField field)
	{
		ApplyInputFieldStyle(field, 16);
	}

	/// <summary>
	///     Apply Valheim style to an <see cref="T:UnityEngine.UI.InputField" /> Component.
	/// </summary>
	/// <param name="field">Component to apply the style to</param>
	/// <param name="fontSize">Optional font size, defaults to 16</param>
	public void ApplyInputFieldStyle(InputField field, int fontSize = 16)
	{
		Graphic targetGraphic = ((Selectable)field).targetGraphic;
		Image val = (Image)(object)((targetGraphic is Image) ? targetGraphic : null);
		if (val != null)
		{
			((Graphic)val).color = Color.white;
			val.sprite = GetSprite("text_field");
			val.pixelsPerUnitMultiplier = (GUIInStart ? 2f : 1f);
		}
		Graphic placeholder = field.placeholder;
		Text val2 = (Text)(object)((placeholder is Text) ? placeholder : null);
		if (val2 != null)
		{
			val2.font = AveriaSerifBold;
			((Graphic)val2).color = Color.grey;
			val2.fontSize = fontSize;
		}
		if ((bool)(UnityEngine.Object)(object)field.textComponent)
		{
			ApplyTextStyle(field.textComponent, fontSize);
		}
	}

	/// <summary>
	///     Apply Valheim style to a <see cref="T:UnityEngine.UI.Toggle" /> component.
	/// </summary>
	/// <param name="toggle">Component to apply the style to</param>
	public void ApplyToogleStyle(Toggle toggle)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		toggle.toggleTransition = (ToggleTransition)1;
		((Selectable)toggle).colors = ValheimToggleColorBlock;
		Graphic targetGraphic = ((Selectable)toggle).targetGraphic;
		Image val = (Image)(object)((targetGraphic is Image) ? targetGraphic : null);
		if (val != null)
		{
			val.sprite = GetSprite("checkbox");
			val.pixelsPerUnitMultiplier = (GUIInStart ? 2f : 1f);
		}
		Graphic graphic = toggle.graphic;
		Image val2 = (Image)(object)((graphic is Image) ? graphic : null);
		if (val2 != null)
		{
			((Graphic)val2).color = new Color(1f, 0.678f, 0.103f, 1f);
			val2.sprite = GetSprite("checkbox_marker");
			val2.pixelsPerUnitMultiplier = (GUIInStart ? 2f : 1f);
			((MaskableGraphic)val2).maskable = true;
		}
	}

	/// <summary>
	///     Apply Valheim style to a <see cref="T:UnityEngine.UI.Dropdown" /> component.
	/// </summary>
	/// <param name="dropdown">Component to apply the style to</param>
	/// <param name="fontSize">Optional font size, defaults to 16</param>
	public void ApplyDropdownStyle(Dropdown dropdown, int fontSize = 16)
	{
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		((Component)(object)dropdown).gameObject.layer = 5;
		if (dropdown.template != null)
		{
			dropdown.template.gameObject.layer = 5;
		}
		if ((bool)(UnityEngine.Object)(object)dropdown.captionText)
		{
			ApplyTextStyle(dropdown.captionText, fontSize);
			dropdown.captionText.verticalOverflow = (VerticalWrapMode)1;
		}
		if ((bool)(UnityEngine.Object)(object)dropdown.itemText)
		{
			ApplyTextStyle(dropdown.itemText, fontSize);
			dropdown.captionText.verticalOverflow = (VerticalWrapMode)1;
		}
		if (((Component)(object)dropdown).TryGetComponent(out Image component))
		{
			component.sprite = GetSprite("text_field");
			component.pixelsPerUnitMultiplier = (GUIInStart ? 2f : 1f);
		}
		GameObject gameObject = ((Component)(object)dropdown).transform.Find("Arrow").gameObject;
		gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 180f));
		if (gameObject.TryGetComponent<Image>(out var component2))
		{
			gameObject.SetSize(25f, 25f);
			component2.sprite = GetSprite("map_marker");
			((Graphic)component2).color = Color.white;
			component2.pixelsPerUnitMultiplier = (GUIInStart ? 2f : 1f);
		}
		if ((bool)dropdown.template && dropdown.template.TryGetComponent<ScrollRect>(out var component3))
		{
			ApplyScrollRectStyle(component3);
		}
		if ((bool)dropdown.template && dropdown.template.TryGetComponent<Image>(out var component4))
		{
			component4.sprite = GetSprite("button_small");
			((Graphic)component4).color = Color.white;
			component4.pixelsPerUnitMultiplier = (GUIInStart ? 2f : 1f);
		}
		GameObject gameObject2 = dropdown.template.Find("Viewport/Content/Item").gameObject;
		if ((bool)gameObject2 && gameObject2.TryGetComponent<Toggle>(out var component5))
		{
			component5.toggleTransition = (ToggleTransition)0;
			((Selectable)component5).colors = ValheimToggleColorBlock;
			Toggle obj = component5;
			SpriteState spriteState = default(SpriteState);
			((SpriteState)(ref spriteState)).highlightedSprite = GetSprite("button_highlight");
			((Selectable)obj).spriteState = spriteState;
			Graphic targetGraphic = ((Selectable)component5).targetGraphic;
			Image val = (Image)(object)((targetGraphic is Image) ? targetGraphic : null);
			if (val != null)
			{
				((Behaviour)(object)val).enabled = false;
			}
			Graphic graphic = component5.graphic;
			Image val2 = (Image)(object)((graphic is Image) ? graphic : null);
			if (val2 != null)
			{
				val2.sprite = GetSprite("checkbox_marker");
				((Graphic)val2).color = Color.white;
				val2.type = (Type)0;
				((MaskableGraphic)val2).maskable = true;
				val2.pixelsPerUnitMultiplier = (GUIInStart ? 2f : 1f);
				((Shadow)((Component)(object)val2).gameObject.GetOrAddComponent<Outline>()).effectColor = Color.black;
			}
		}
	}

	/// <summary>
	///     Apply Valheim style to a <see cref="T:UnityEngine.UI.ScrollRect" /> component.
	/// </summary>
	/// <param name="scrollRect">Component to apply the style to</param>
	public void ApplyScrollRectStyle(ScrollRect scrollRect)
	{
		scrollRect.scrollSensitivity = 40f;
		if ((bool)(UnityEngine.Object)(object)scrollRect.horizontalScrollbar)
		{
			ApplyScrollbarStyle(scrollRect.horizontalScrollbar);
		}
		if ((bool)(UnityEngine.Object)(object)scrollRect.verticalScrollbar)
		{
			ApplyScrollbarStyle(scrollRect.verticalScrollbar);
		}
		if (((Component)(object)scrollRect).TryGetComponent(out Image component))
		{
			((Graphic)component).color = new Color(0f, 0f, 0f, 0.564f);
			component.pixelsPerUnitMultiplier = (GUIInStart ? 2f : 1f);
		}
	}

	/// <summary>
	///     Apply Valheim style to a <see cref="T:UnityEngine.UI.Scrollbar" /> component.
	/// </summary>
	/// <param name="scrollbar">Component to apply the style to</param>
	public void ApplyScrollbarStyle(Scrollbar scrollbar)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Invalid comparison between Unknown and I4
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Invalid comparison between Unknown and I4
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Invalid comparison between Unknown and I4
		((Selectable)scrollbar).transition = (Transition)1;
		((Selectable)scrollbar).colors = ValheimScrollbarHandleColorBlock;
		RectTransform rectTransform = (RectTransform)((Component)(object)scrollbar).transform;
		if ((int)scrollbar.direction == 0 || (int)scrollbar.direction == 1)
		{
			rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 10f);
		}
		if ((int)scrollbar.direction == 2 || (int)scrollbar.direction == 3)
		{
			rectTransform.sizeDelta = new Vector2(10f, rectTransform.sizeDelta.y);
		}
		Graphic targetGraphic = ((Selectable)scrollbar).targetGraphic;
		Image val = (Image)(object)((targetGraphic is Image) ? targetGraphic : null);
		if (val != null)
		{
			val.sprite = GetSprite("UISprite");
			val.pixelsPerUnitMultiplier = (GUIInStart ? 2f : 1f);
		}
		if (((Component)(object)scrollbar).TryGetComponent(out Image component))
		{
			component.sprite = GetSprite("Background");
			((Graphic)component).color = Color.black;
			((Graphic)component).raycastTarget = true;
			component.pixelsPerUnitMultiplier = (GUIInStart ? 2f : 1f);
		}
	}

	/// <summary>
	///     Apply Valheim style to a <see cref="T:UnityEngine.UI.Slider" /> component.
	/// </summary>
	/// <param name="slider"></param>
	public void ApplySliderStyle(Slider slider)
	{
		ApplySliderStyle(slider, new Vector2(40f, 10f));
	}

	/// <summary>
	///     Apply Valheim style to a <see cref="T:UnityEngine.UI.Slider" /> component.
	/// </summary>
	/// <param name="slider"></param>
	/// <param name="handleSize"></param>
	public void ApplySliderStyle(Slider slider, Vector2 handleSize)
	{
		slider.handleRect.sizeDelta = handleSize;
		if ((bool)slider.fillRect && slider.fillRect.TryGetComponent<Image>(out var component))
		{
			component.sprite = GetSprite("UISprite");
			((Graphic)component).color = ValheimOrange;
		}
		if ((bool)slider.handleRect && (bool)slider.handleRect.transform.parent)
		{
			RectTransform rectTransform = (RectTransform)slider.handleRect.transform.parent;
			rectTransform.offsetMin = new Vector2(5f, rectTransform.offsetMin.y);
			rectTransform.offsetMax = new Vector2(-5f, rectTransform.offsetMax.y);
		}
		if ((bool)slider.handleRect && (bool)slider.fillRect.transform.parent)
		{
			RectTransform rectTransform2 = (RectTransform)slider.fillRect.transform.parent;
			rectTransform2.offsetMin = new Vector2(5f, rectTransform2.offsetMin.y);
			rectTransform2.offsetMax = new Vector2(-5f, rectTransform2.offsetMax.y);
		}
	}
}
