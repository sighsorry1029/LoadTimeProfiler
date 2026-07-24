using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using HarmonyLib;
using Jotunn.Entities;
using Jotunn.GUI;
using Jotunn.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Jotunn.Managers;

/// <summary>
///     Manager for adding custom Map Overlays to the game.
/// </summary>
public class MinimapManager : IManager
{
	private static class Patches
	{
		[HarmonyPatch(typeof(Minimap), "Start")]
		[HarmonyPostfix]
		private static void Start()
		{
			Instance.Minimap_Start();
		}

		[HarmonyPatch(typeof(Minimap), "LoadMapData")]
		[HarmonyPostfix]
		private static void LoadMapData()
		{
			Instance.Minimap_LoadMapData();
		}

		[HarmonyPatch(typeof(Minimap), "CenterMap")]
		[HarmonyPostfix]
		private static void Minimap_CenterMap(Minimap __instance, Vector3 centerPoint)
		{
			Instance.Minimap_CenterMap(__instance, centerPoint);
		}

		[HarmonyPatch(typeof(Minimap), "OnDestroy")]
		[HarmonyPostfix]
		private static void Minimap_OnDestroy()
		{
			Instance.Minimap_OnDestroy();
		}
	}

	/// <summary>
	///     Object for modders to use to access and modify their Overlay.
	///     Modders should modify the texture directly.
	/// </summary>
	public class MapOverlay : MapOverlayBase
	{
		/// <summary>
		///     Flag to determine if this overlay should be hidden in unexplored areas
		/// </summary>
		internal bool IgnoreFog;

		private Texture2D _overlayTex;

		private bool _enabled;

		private bool _overlayDirty;

		/// <summary>
		///     Texture to draw overlay texture information to
		/// </summary>
		public Texture2D OverlayTex => _overlayTex ?? (_overlayTex = Create(Instance.TransparentTex));

		/// <summary>
		///     Set true to render this overlay, false to hide
		/// </summary>
		public bool Enabled
		{
			get
			{
				return _enabled;
			}
			set
			{
				if (_enabled != value)
				{
					_enabled = value;
					Dirty = true;
					if (!IgnoreFog)
					{
						Instance.SetFogDirty();
					}
					Toggle toggle = Toggle;
					if (toggle != null)
					{
						toggle.SetIsOnWithoutNotify(value);
					}
				}
			}
		}

		/// <summary>
		///     Flag to determine if this overlay had changes since its last draw
		/// </summary>
		internal bool Dirty
		{
			get
			{
				if (_overlayTex != null)
				{
					return _overlayDirty;
				}
				return false;
			}
			set
			{
				_overlayDirty = value;
			}
		}

		/// <summary>
		///     Hide .ctor
		/// </summary>
		internal MapOverlay()
		{
		}

		/// <summary>
		///     Function called on Texture2D.Apply to check if one of our member textures was changed
		/// </summary>
		/// <param name="tex"></param>
		internal void SetTextureDirty(Texture2D tex)
		{
			if (!(tex.name != base.Name) && tex == _overlayTex)
			{
				_overlayDirty = true;
				if (!IgnoreFog)
				{
					Instance.SetFogDirty();
				}
			}
		}

		/// <summary>
		///     Destroys the overlay texture
		/// </summary>
		internal void Destroy()
		{
			if (_overlayTex != null)
			{
				UnityEngine.Object.DestroyImmediate(_overlayTex);
			}
		}
	}

	/// <summary>
	///     Object for modders to use to access and modify their Overlay.
	///     Modders should modify the texture directly.
	///
	/// </summary>
	public class MapDrawing : MapOverlayBase
	{
		private Texture2D _mainTex;

		private Texture2D _heightFilter;

		private Texture2D _forestFilter;

		private Texture2D _fogFilter;

		private bool _enabled;

		private bool _mainDirty;

		private bool _heightDirty;

		private bool _forestDirty;

		private bool _fogDirty;

		/// <summary>
		///     Texture to draw main texture information to
		/// </summary>
		public Texture2D MainTex => _mainTex ?? (_mainTex = Create(Minimap.instance.m_mapTexture));

		/// <summary>
		///     Texture to draw height filter information to
		/// </summary>
		public Texture2D HeightFilter => _heightFilter ?? (_heightFilter = Create(Minimap.instance.m_heightTexture));

		/// <summary>
		///     Texture to draw forest filter information to
		/// </summary>
		public Texture2D ForestFilter => _forestFilter ?? (_forestFilter = Create(Minimap.instance.m_forestMaskTexture));

		/// <summary>
		///     Texture to draw fog filter information to
		/// </summary>
		public Texture2D FogFilter => _fogFilter ?? (_fogFilter = Create(Minimap.instance.m_fogTexture));

		/// <summary>
		///     Set true to render this overlay, false to hide
		/// </summary>
		public bool Enabled
		{
			get
			{
				return _enabled;
			}
			set
			{
				if (_enabled != value)
				{
					_enabled = value;
					Dirty = true;
					if (FogEnabled)
					{
						Instance.SetFogDirty();
					}
					Toggle toggle = Toggle;
					if (toggle != null)
					{
						toggle.SetIsOnWithoutNotify(value);
					}
				}
			}
		}

		internal bool MainEnabled => _mainTex != null;

		internal bool HeightEnabled => _heightFilter != null;

		internal bool ForestEnabled => _forestFilter != null;

		internal bool FogEnabled => _fogFilter != null;

		/// <summary>
		///     Flag to determine if this overlay had changes since its last draw
		/// </summary>
		internal bool Dirty
		{
			get
			{
				if (!MainDirty && !HeightDirty && !ForestDirty)
				{
					return FogDirty;
				}
				return true;
			}
			set
			{
				_mainDirty = value;
				_heightDirty = value;
				_forestDirty = value;
				_fogDirty = value;
			}
		}

		internal bool MainDirty
		{
			get
			{
				if (_mainTex != null)
				{
					return _mainDirty;
				}
				return false;
			}
			set
			{
				_mainDirty = value;
			}
		}

		internal bool HeightDirty
		{
			get
			{
				if (_heightFilter != null)
				{
					return _heightDirty;
				}
				return false;
			}
			set
			{
				_heightDirty = value;
			}
		}

		internal bool ForestDirty
		{
			get
			{
				if (_forestFilter != null)
				{
					return _forestDirty;
				}
				return false;
			}
			set
			{
				_forestDirty = value;
			}
		}

		internal bool FogDirty
		{
			get
			{
				if (_fogFilter != null)
				{
					return _fogDirty;
				}
				return false;
			}
			set
			{
				_fogDirty = value;
			}
		}

		/// <summary>
		///     Hide .ctor
		/// </summary>
		internal MapDrawing()
		{
		}

		/// <summary>
		///     Function called on Texture2D.Apply to check if one of our member textures was changed
		/// </summary>
		/// <param name="tex"></param>
		internal void SetTextureDirty(Texture2D tex)
		{
			if (tex.name != base.Name)
			{
				return;
			}
			if (tex == _mainTex)
			{
				_mainDirty = true;
			}
			if (tex == _heightFilter)
			{
				_heightDirty = true;
			}
			if (tex == _forestFilter)
			{
				_forestDirty = true;
			}
			if (tex == _fogFilter)
			{
				_fogDirty = true;
				if (FogEnabled)
				{
					Instance.SetFogDirty();
				}
			}
		}

		/// <summary>
		///     Destroys all textures
		/// </summary>
		internal void Destroy()
		{
			if (_mainTex != null)
			{
				UnityEngine.Object.DestroyImmediate(_mainTex);
			}
			if (_heightFilter != null)
			{
				UnityEngine.Object.DestroyImmediate(_heightFilter);
			}
			if (_forestFilter != null)
			{
				UnityEngine.Object.DestroyImmediate(_forestFilter);
			}
			if (_fogFilter != null)
			{
				UnityEngine.Object.DestroyImmediate(_fogFilter);
			}
		}
	}

	/// <summary>
	///     Overlay Base to inherit from
	///
	/// </summary>
	public class MapOverlayBase : CustomEntity
	{
		/// <summary>
		///     Reference to the GUI toggle element to notify changes on the overlay state
		/// </summary>
		internal Toggle Toggle;

		/// <summary>
		///     Unique name per overlay
		/// </summary>
		public string Name { get; internal set; }

		/// <summary>
		///     Initial texture size to calculate the relative drawing position
		/// </summary>
		public int TextureSize { get; internal set; }

		/// <summary>
		///     Hide .ctor
		/// </summary>
		internal MapOverlayBase()
		{
		}

		/// <summary>
		///     Helper function to create and copy overlay texture instances
		/// </summary>
		internal Texture2D Create(Texture2D van)
		{
			Texture2D texture2D = new Texture2D(van.width, van.height, van.format, mipChain: false)
			{
				wrapMode = TextureWrapMode.Clamp,
				name = Name
			};
			if (texture2D.format != TextureFormat.RGB24)
			{
				Graphics.CopyTexture(Instance.TransparentTex, texture2D);
			}
			else
			{
				Graphics.CopyTexture(Minimap.instance.m_mapTexture, texture2D);
			}
			return texture2D;
		}
	}

	private static MinimapManager _instance;

	/// <summary>
	///     Colour which sets a filter on. Used for ForestFilter and FogFilter.
	///     A full alpha value enables this pixel, and then the red value is written to the result texture.
	/// </summary>
	public static Color FilterOn;

	/// <summary>
	///     Colour which sets a filter off. See FilterOn.
	/// </summary>
	public static Color FilterOff;

	/// <summary>
	///     Height "Colour" used for the base height of "Meadows"
	/// </summary>
	public static Color MeadowHeight;

	private const int TextureSize = 2048;

	/// <summary>
	///     Container to hold all live Overlays.
	/// </summary>
	private readonly Dictionary<string, MapOverlay> Overlays = new Dictionary<string, MapOverlay>();

	/// <summary>
	///     Container to hold all live Drawings.
	/// </summary>
	private readonly Dictionary<string, MapDrawing> Drawings = new Dictionary<string, MapDrawing>();

	private Texture2D TransparentTex;

	private Sprite CircleMask;

	private Texture2D OverlayTex;

	private Texture2D MainTex;

	private Texture2D HeightFilter;

	private Texture2D ForestFilter;

	private Texture2D FogFilter;

	private Material ComposeOverlayMaterial;

	private Material ComposeMainMaterial;

	private Material ComposeHeightMaterial;

	private Material ComposeForestMaterial;

	private Material ComposeFogMaterial;

	private MinimapOverlayPanel OverlayPanel;

	private GameObject OverlayLarge;

	private GameObject OverlaySmall;

	/// <summary>
	///     The singleton instance of this manager.
	/// </summary>
	public static MinimapManager Instance => _instance ?? (_instance = new MinimapManager());

	/// <summary>
	///     Event that gets fired once the Map for a World has started and Mods can begin to draw.
	/// </summary>
	public static event Action OnVanillaMapAvailable;

	/// <summary>
	///     Event that gets fired once data for a specific Map for a world has been loaded. Eg, Pins are available after this has fired.
	/// </summary>
	public static event Action OnVanillaMapDataLoaded;

	/// <summary>
	///     Hide .ctor
	/// </summary>
	private MinimapManager()
	{
	}

	static MinimapManager()
	{
		FilterOn = new Color(1f, 0f, 0f, 255f);
		FilterOff = new Color(0f, 0f, 0f, 255f);
		MeadowHeight = new Color(32f, 0f, 0f, 255f);
		((IManager)Instance).Init();
	}

	/// <summary>
	///     Creates the Overlays and registers hooks.
	/// </summary>
	void IManager.Init()
	{
		Main.LogInit("MinimapManager");
		if (!GUIUtils.IsHeadless)
		{
			Main.Harmony.PatchAll(typeof(Patches));
			AssetBundle val = AssetUtils.LoadAssetBundleFromResources("minimapmanager", typeof(MinimapManager).Assembly);
			TransparentTex = val.LoadAsset<Texture2D>("2048x2048_clear");
			GameObject prefab = val.LoadAsset<GameObject>("MinimapOverlayPanel");
			PrefabManager.Instance.AddPrefab(new CustomPrefab(prefab, fixReference: false));
			val.Unload(false);
			Main.Harmony.Patch(AccessTools.DeclaredMethod(typeof(Texture2D), "Apply", new Type[2]
			{
				typeof(bool),
				typeof(bool)
			}), new HarmonyMethod(AccessTools.DeclaredMethod(typeof(MinimapManager), "Texture2D_Apply")));
		}
	}

	/// <summary>
	///     Create a new MapOverlay with a custom overlay name
	/// </summary>
	/// <param name="name">Custom name for the MapOverlay</param>
	/// <param name="ignoreFog">When set to true, that layer will be drawn regardless of exploration status, defaults to false</param>
	/// <returns>Reference to MapOverlay for modder to edit</returns>
	public MapOverlay GetMapOverlay(string name, bool ignoreFog = false)
	{
		if (Overlays.ContainsKey(name))
		{
			Logger.LogDebug("Returning existing overlay with name " + name);
			return Overlays[name];
		}
		if (Overlays.Count == 0)
		{
			SetupOverlays();
		}
		MapOverlay mapOverlay = new MapOverlay
		{
			Name = name,
			Enabled = true,
			TextureSize = 2048,
			IgnoreFog = ignoreFog
		};
		Overlays.Add(name, mapOverlay);
		AddOverlayToGUI(mapOverlay);
		return mapOverlay;
	}

	/// <summary>
	///     Create a new MapDrawing with a custom overlay name
	/// </summary>
	/// <param name="name">Custom name for the MapDrawing</param>
	/// <returns>Reference to MapDrawing for modder to edit</returns>
	public MapDrawing GetMapDrawing(string name)
	{
		if (Drawings.ContainsKey(name))
		{
			Logger.LogDebug("Returning existing overlay with name " + name);
			return Drawings[name];
		}
		if (Drawings.Count == 0)
		{
			SetupDrawings();
		}
		MapDrawing mapDrawing = new MapDrawing
		{
			Name = name,
			Enabled = true,
			TextureSize = 2048
		};
		Drawings.Add(name, mapDrawing);
		AddDrawingToGUI(mapDrawing);
		return mapDrawing;
	}

	/// <summary>
	///     Causes MapManager to stop updating the MapOverlay object and removes this Manager's reference to that overlay.
	/// </summary>
	/// <param name="name">The name of the MapOverlay to be removed</param>
	/// <returns>True if removal was successful. False if there was an error removing the object from the internal dict.</returns>
	public bool RemoveMapOverlay(string name)
	{
		return Overlays.Remove(name);
	}

	/// <summary>
	///     Causes MapManager to stop updating the MapDrawing object and removes this Manager's reference to that drawing.
	/// </summary>
	/// <param name="name">The name of the MapDrawing to be removed</param>
	/// <returns>True if removal was successful. False if there was an error removing the object from the internal dict.</returns>
	public bool RemoveMapDrawing(string name)
	{
		return Drawings.Remove(name);
	}

	/// <summary>
	///     Return a list of all current overlay names
	/// </summary>
	/// <returns>List of names</returns>
	public List<string> GetOverlayNames()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, MapOverlay> overlay in Overlays)
		{
			list.Add(overlay.Value.Name);
		}
		return list;
	}

	/// <summary>
	///     Return a list of all current MapDrawing names
	/// </summary>
	/// <returns>List of names</returns>
	public List<string> GetDrawingNames()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, MapDrawing> drawing in Drawings)
		{
			list.Add(drawing.Value.Name);
		}
		return list;
	}

	/// <summary>
	///     Input a World Coordinate and the size of the overlay texture to retrieve the translated overlay coordinates. 
	/// </summary>
	/// <param name="input">World Coordinates</param>
	/// <param name="texSize">Size of the image from your MapOverlay</param>
	/// <returns>The 2D coordinate space on the MapOverlay</returns>
	public Vector2 WorldToOverlayCoords(Vector3 input, int texSize)
	{
		Minimap.instance.WorldToMapPoint(input, out float mx, out float my);
		return new Vector2((float)Math.Round(mx * (float)texSize), (float)Math.Round(my * (float)texSize));
	}

	/// <summary>
	///     Input a MapOverlay Coordinate and the size of the overlay texture to retrieve the translated World coordinates.
	/// </summary>
	/// <param name="input">The 2D Overlay coordinate</param>
	/// <param name="texSize">The size of the Overlay</param>
	/// <returns>The 3D World coordinate that corresponds to the input Vector</returns>
	public Vector3 OverlayToWorldCoords(Vector2 input, int texSize)
	{
		input.x /= texSize;
		input.y /= texSize;
		return Minimap.instance.MapPointToWorld(input.x, input.y);
	}

	/// <summary>
	///     Setup GUI on <see cref="M:Minimap.Start" />.
	/// </summary>
	private void Minimap_Start()
	{
		SetupGUI();
		StartWatchdog();
		InvokeOnVanillaMapAvailable();
	}

	/// <summary>
	///     Safely invoke OnVanillaMapAvailable event.
	/// </summary>
	private void InvokeOnVanillaMapAvailable()
	{
		MinimapManager.OnVanillaMapAvailable?.SafeInvoke();
	}

	/// <summary>
	///     Setup textures and GUI on <see cref="M:Minimap.LoadMapData" />
	/// </summary>
	private void Minimap_LoadMapData()
	{
		InvokeOnVanillaMapDataLoaded();
	}

	/// <summary>
	///     Safely invoke InvokeOnVanillaMapDataLoaded event.
	/// </summary>
	private void InvokeOnVanillaMapDataLoaded()
	{
		MinimapManager.OnVanillaMapDataLoaded?.SafeInvoke();
	}

	private void StartWatchdog()
	{
		Minimap.instance.StartCoroutine(watchdog());
		IEnumerator watchdog()
		{
			WaitForEndOfFrame wait = new WaitForEndOfFrame();
			while (true)
			{
				yield return wait;
				if (Overlays.Values.Any((MapOverlay x) => x.Dirty) || Drawings.Values.Any((MapDrawing x) => x.Dirty))
				{
					if (Overlays.Values.Any((MapOverlay x) => !x.IgnoreFog && x.Dirty) || Drawings.Values.Any((MapDrawing x) => x.FogEnabled && x.FogDirty))
					{
						Graphics.CopyTexture(Minimap.instance.m_fogTexture, FogFilter);
					}
					if (Drawings.Values.Any((MapDrawing x) => x.FogDirty))
					{
						yield return DrawFogFilter();
					}
					if (Overlays.Values.Any((MapOverlay x) => x.Dirty))
					{
						yield return DrawOverlay();
					}
					if (Drawings.Values.Any((MapDrawing x) => x.MainDirty))
					{
						yield return DrawMain();
					}
					if (Drawings.Values.Any((MapDrawing x) => x.HeightDirty))
					{
						yield return DrawHeightFilter();
					}
					if (Drawings.Values.Any((MapDrawing x) => x.ForestDirty))
					{
						yield return DrawForestFilter();
					}
				}
			}
		}
	}

	private IEnumerator DrawFogFilter()
	{
		Logger.LogDebug("Redraw Fog");
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		foreach (MapDrawing value in Drawings.Values)
		{
			if (value.Enabled && value.FogEnabled)
			{
				DrawLayer(value.FogFilter, FogFilter, ComposeFogMaterial);
			}
			value.FogDirty = false;
		}
		stopwatch.Stop();
		Logger.LogDebug($"DrawFog loop took {stopwatch.ElapsedMilliseconds}ms time");
		yield return null;
	}

	private IEnumerator DrawOverlay()
	{
		Logger.LogDebug("Redraw Overlay");
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		Graphics.CopyTexture(TransparentTex, OverlayTex);
		foreach (MapOverlay item in Overlays.Values.OrderBy((MapOverlay x) => x.IgnoreFog ? 1 : 0))
		{
			if (item.Enabled)
			{
				ComposeOverlayMaterial.SetTexture("_FogTex", item.IgnoreFog ? TransparentTex : FogFilter);
				DrawLayer(item.OverlayTex, OverlayTex, ComposeOverlayMaterial);
			}
			item.Dirty = false;
		}
		stopwatch.Stop();
		Logger.LogDebug($"DrawOverlay loop took {stopwatch.ElapsedMilliseconds}ms time");
		yield return null;
	}

	private IEnumerator DrawMain()
	{
		Logger.LogDebug("Redraw Main");
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		Graphics.CopyTexture(Minimap.instance.m_mapTexture, MainTex);
		foreach (MapDrawing value in Drawings.Values)
		{
			if (value.Enabled && value.MainEnabled)
			{
				DrawLayer(value.MainTex, MainTex, ComposeMainMaterial);
			}
			value.MainDirty = false;
		}
		stopwatch.Stop();
		Logger.LogDebug($"DrawMain loop took {stopwatch.ElapsedMilliseconds}ms time");
		yield return null;
	}

	private IEnumerator DrawHeightFilter()
	{
		Logger.LogDebug("Redraw Height");
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		Graphics.CopyTexture(Minimap.instance.m_heightTexture, HeightFilter);
		foreach (MapDrawing value in Drawings.Values)
		{
			if (value.Enabled && value.HeightEnabled)
			{
				DrawLayer(value.HeightFilter, HeightFilter, ComposeHeightMaterial, RenderTextureFormat.RFloat);
			}
			value.HeightDirty = false;
		}
		stopwatch.Stop();
		Logger.LogDebug($"DrawHeight loop took {stopwatch.ElapsedMilliseconds}ms time");
		yield return null;
	}

	private IEnumerator DrawForestFilter()
	{
		Logger.LogDebug("Redraw Forest");
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		Graphics.CopyTexture(Minimap.instance.m_forestMaskTexture, ForestFilter);
		foreach (MapDrawing value in Drawings.Values)
		{
			if (value.Enabled && value.ForestEnabled)
			{
				DrawLayer(value.ForestFilter, ForestFilter, ComposeForestMaterial);
			}
			value.ForestDirty = false;
		}
		stopwatch.Stop();
		Logger.LogDebug($"DrawForest loop took {stopwatch.ElapsedMilliseconds}ms time");
		yield return null;
	}

	private void DrawLayer(Texture2D layer, Texture2D dest, Material mat, RenderTextureFormat format = RenderTextureFormat.Default)
	{
		RenderTexture temporary = RenderTexture.GetTemporary(2048, 2048, 0, format, RenderTextureReadWrite.Default);
		if (mat != null)
		{
			Graphics.Blit(layer, temporary, mat);
		}
		else
		{
			Graphics.Blit(layer, temporary);
		}
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = temporary;
		dest.ReadPixels(new Rect(0f, 0f, temporary.width, temporary.height), 0, 0);
		dest.Apply();
		RenderTexture.active = active;
		RenderTexture.ReleaseTemporary(temporary);
	}

	/// <summary>
	///     Return whether the Drawings functionality is active.
	/// </summary>
	/// <returns></returns>
	private bool DrawingsActive()
	{
		return Drawings.Count > 0;
	}

	/// <summary>
	///     Called when the first MapDraw object is created.
	///     Initializes all variables required for MapDraw objects to be rendered.
	///     Changes the behaviour of some vanilla shaders.
	/// </summary>
	private void SetupDrawings()
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		Logger.LogDebug("Setting up MapDrawings");
		MainTex = new Texture2D(2048, 2048, Minimap.instance.m_mapTexture.format, mipChain: false);
		HeightFilter = new Texture2D(2048, 2048, Minimap.instance.m_heightTexture.format, mipChain: false);
		ForestFilter = new Texture2D(2048, 2048, Minimap.instance.m_forestMaskTexture.format, mipChain: false);
		if ((object)FogFilter == null)
		{
			FogFilter = new Texture2D(2048, 2048, Minimap.instance.m_fogTexture.format, mipChain: false);
		}
		AssetBundle val = AssetUtils.LoadAssetBundleFromResources("minimapmanager", typeof(MinimapManager).Assembly);
		Shader shader = val.LoadAsset<Shader>("MinimapComposeMain");
		Shader shader2 = val.LoadAsset<Shader>("MinimapComposeHeight");
		Shader shader3 = val.LoadAsset<Shader>("MinimapComposeForest");
		Shader shader4 = val.LoadAsset<Shader>("MinimapComposeFog");
		val.Unload(false);
		ComposeMainMaterial = new Material(shader);
		ComposeHeightMaterial = new Material(shader2);
		ComposeForestMaterial = new Material(shader3);
		ComposeFogMaterial = new Material(shader4);
		ComposeMainMaterial.SetTexture("_VanillaTex", MainTex);
		ComposeHeightMaterial.SetTexture("_VanillaTex", HeightFilter);
		ComposeForestMaterial.SetTexture("_VanillaTex", ForestFilter);
		ComposeFogMaterial.SetTexture("_VanillaTex", FogFilter);
		Graphics.CopyTexture(Minimap.instance.m_mapTexture, MainTex);
		Graphics.CopyTexture(Minimap.instance.m_heightTexture, HeightFilter);
		Graphics.CopyTexture(Minimap.instance.m_forestMaskTexture, ForestFilter);
		Graphics.CopyTexture(Minimap.instance.m_fogTexture, FogFilter);
		Minimap.instance.m_mapLargeShader.SetTexture("_MainTex", MainTex);
		Minimap.instance.m_mapSmallShader.SetTexture("_MainTex", MainTex);
		Minimap.instance.m_mapLargeShader.SetTexture("_HeightTex", HeightFilter);
		Minimap.instance.m_mapSmallShader.SetTexture("_HeightTex", HeightFilter);
		Minimap.instance.m_mapLargeShader.SetTexture("_MaskTex", ForestFilter);
		Minimap.instance.m_mapSmallShader.SetTexture("_MaskTex", ForestFilter);
		Minimap.instance.m_mapLargeShader.SetTexture("_FogTex", FogFilter);
		Minimap.instance.m_mapSmallShader.SetTexture("_FogTex", FogFilter);
		stopwatch.Stop();
		Logger.LogDebug($"Setup took {stopwatch.ElapsedMilliseconds}ms time");
	}

	private void SetupOverlays()
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		Logger.LogDebug("Setting up MapOverlays");
		OverlayTex = new Texture2D(2048, 2048, TextureFormat.RGBA32, mipChain: false);
		if ((object)FogFilter == null)
		{
			FogFilter = new Texture2D(2048, 2048, Minimap.instance.m_fogTexture.format, mipChain: false);
		}
		AssetBundle val = AssetUtils.LoadAssetBundleFromResources("minimapmanager", typeof(MinimapManager).Assembly);
		CircleMask = val.LoadAsset<Sprite>("CircleMask");
		Shader shader = val.LoadAsset<Shader>("MinimapComposeOverlay");
		ComposeOverlayMaterial = new Material(shader);
		ComposeOverlayMaterial.SetTexture("_VanillaTex", OverlayTex);
		ComposeOverlayMaterial.SetTexture("_FogTex", FogFilter);
		val.Unload(false);
		Graphics.CopyTexture(TransparentTex, OverlayTex);
		Graphics.CopyTexture(Minimap.instance.m_fogTexture, FogFilter);
		OverlayLarge = new GameObject("CustomLayerLarge");
		RectTransform rectTransform = OverlayLarge.AddComponent<RectTransform>();
		rectTransform.SetParent(((Component)(object)Minimap.instance.m_mapImageLarge).transform, worldPositionStays: false);
		rectTransform.SetAsFirstSibling();
		rectTransform.anchorMin = Vector2.zero;
		rectTransform.anchorMax = Vector2.one;
		rectTransform.offsetMin = Vector2.zero;
		rectTransform.offsetMax = Vector2.zero;
		Image val2 = OverlayLarge.AddComponent<Image>();
		val2.sprite = CircleMask;
		val2.preserveAspect = true;
		((Graphic)val2).raycastTarget = false;
		Mask val3 = OverlayLarge.AddComponent<Mask>();
		val3.showMaskGraphic = false;
		GameObject gameObject = new GameObject("RawImageLarge");
		RectTransform rectTransform2 = gameObject.AddComponent<RectTransform>();
		rectTransform2.SetParent(rectTransform, worldPositionStays: false);
		rectTransform2.anchorMin = Vector2.zero;
		rectTransform2.anchorMax = Vector2.one;
		rectTransform2.offsetMin = Vector2.zero;
		rectTransform2.offsetMax = Vector2.zero;
		RawImage val4 = gameObject.AddComponent<RawImage>();
		val4.texture = OverlayTex;
		((Graphic)val4).material = null;
		((Graphic)val4).raycastTarget = false;
		((MaskableGraphic)val4).maskable = true;
		Rect uvRect = val4.uvRect;
		uvRect.width = rectTransform.rect.width / rectTransform.rect.height;
		uvRect.height = 1f;
		uvRect.center = new Vector2(0.5f, 0.5f);
		val4.uvRect = uvRect;
		OverlaySmall = new GameObject("CustomLayerSmall");
		RectTransform rectTransform3 = OverlaySmall.AddComponent<RectTransform>();
		rectTransform3.SetParent(((Component)(object)Minimap.instance.m_mapImageSmall).transform, worldPositionStays: false);
		rectTransform3.SetAsFirstSibling();
		rectTransform3.anchorMin = Vector2.zero;
		rectTransform3.anchorMax = Vector2.one;
		RawImage val5 = OverlaySmall.AddComponent<RawImage>();
		val5.texture = OverlayTex;
		((Graphic)val5).material = null;
		((Graphic)val5).raycastTarget = false;
		stopwatch.Stop();
		Logger.LogDebug($"Setup took {stopwatch.ElapsedMilliseconds}ms time");
	}

	private void SetupGUI()
	{
		GameObject prefab = PrefabManager.Instance.GetPrefab("MinimapOverlayPanel");
		GameObject gameObject = UnityEngine.Object.Instantiate(prefab, Minimap.instance.m_mapLarge.transform, worldPositionStays: false);
		gameObject.SetActive(value: false);
		OverlayPanel = gameObject.GetComponent<MinimapOverlayPanel>();
		GUIManager.Instance.ApplyButtonStyle(OverlayPanel.Button);
		GUIManager.Instance.ApplyToogleStyle(OverlayPanel.BaseToggle);
		GUIManager.Instance.ApplyTextStyle(OverlayPanel.BaseModText);
	}

	private void AddOverlayToGUI(MapOverlay ovl)
	{
		Toggle val = OverlayPanel?.AddOverlayToggle(ovl.SourceMod.Name, ovl.Name);
		if (val != null)
		{
			val.SetIsOnWithoutNotify(ovl.Enabled);
		}
		((UnityEvent<bool>)(object)val?.onValueChanged).AddListener((UnityAction<bool>)delegate(bool active)
		{
			ovl.Enabled = active;
		});
		ovl.Toggle = val;
		OverlayPanel?.gameObject.SetActive(value: true);
	}

	private void AddDrawingToGUI(MapDrawing ovl)
	{
		Toggle val = OverlayPanel?.AddOverlayToggle(ovl.SourceMod.Name, ovl.Name);
		if (val != null)
		{
			val.SetIsOnWithoutNotify(ovl.Enabled);
		}
		((UnityEvent<bool>)(object)val?.onValueChanged).AddListener((UnityAction<bool>)delegate(bool active)
		{
			ovl.Enabled = active;
		});
		ovl.Toggle = val;
		OverlayPanel?.gameObject.SetActive(value: true);
	}

	private void Minimap_CenterMap(Minimap self, Vector3 centerpoint)
	{
		if ((bool)OverlayLarge)
		{
			self.WorldToMapPoint(centerpoint, out float mx, out float my);
			RectTransform rectTransform = OverlayLarge.transform as RectTransform;
			float num = rectTransform.rect.width / rectTransform.rect.height;
			float num2 = 1f / self.m_largeZoom;
			OverlayLarge.transform.localScale = new Vector2(num2, num2);
			int num3 = self.m_textureSize / 2;
			float num4 = centerpoint.x / self.m_pixelSize + (float)num3;
			float num5 = centerpoint.z / self.m_pixelSize + (float)num3;
			Vector2 anchoredPosition = new Vector2
			{
				x = 1024f - num4
			};
			anchoredPosition.x *= rectTransform.rect.width / 2048f / num;
			anchoredPosition.x *= num2;
			anchoredPosition.y = 1024f - num5;
			anchoredPosition.y *= rectTransform.rect.height / 2048f;
			anchoredPosition.y *= num2;
			rectTransform.anchoredPosition = anchoredPosition;
			Rect uvRect = self.m_mapImageSmall.uvRect;
			uvRect.width += self.m_smallZoom / 2f;
			uvRect.height += self.m_smallZoom / 2f;
			uvRect.center = new Vector2(mx, my);
			OverlaySmall.GetComponent<RawImage>().uvRect = uvRect;
		}
	}

	private void Minimap_OnDestroy()
	{
		foreach (MapOverlay value in Overlays.Values)
		{
			value.Destroy();
		}
		Instance.Overlays.Clear();
		foreach (MapDrawing value2 in Drawings.Values)
		{
			value2.Destroy();
		}
		Instance.Drawings.Clear();
	}

	[HarmonyPatch(typeof(Texture2D), "Apply", new Type[]
	{
		typeof(bool),
		typeof(bool)
	})]
	[HarmonyPostfix]
	private static void Texture2D_Apply(Texture2D __instance)
	{
		if (__instance == Minimap.instance?.m_fogTexture && !Instance.Drawings.Values.Any((MapDrawing x) => x.FogEnabled && x.Enabled) && Instance.Overlays.Values.Any((MapOverlay x) => !x.IgnoreFog))
		{
			Instance.SetFogDirty();
		}
		foreach (MapOverlay value in Instance.Overlays.Values)
		{
			value.SetTextureDirty(__instance);
		}
		foreach (MapDrawing value2 in Instance.Drawings.Values)
		{
			value2.SetTextureDirty(__instance);
		}
	}

	private void SetFogDirty()
	{
		foreach (MapOverlay item in Overlays.Values.Where((MapOverlay x) => !x.IgnoreFog))
		{
			item.Dirty = true;
		}
		foreach (MapDrawing item2 in Drawings.Values.Where((MapDrawing x) => x.FogEnabled))
		{
			item2.FogDirty = true;
		}
	}
}
