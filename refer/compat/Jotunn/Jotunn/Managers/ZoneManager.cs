using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BepInEx;
using HarmonyLib;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Utils;
using UnityEngine;

namespace Jotunn.Managers;

/// <summary>
///     Manager for adding custom Locations, Vegetation and Clutter.
/// </summary>
public class ZoneManager : IManager
{
	private static class Patches
	{
		[HarmonyPatch(typeof(ZoneSystem), "SetupLocations")]
		[HarmonyPostfix]
		private static void ZoneSystem_SetupLocations(ZoneSystem __instance)
		{
			Instance.RegisterLocations(__instance);
			Instance.RegisterVegetation(__instance);
		}

		[HarmonyPatch(typeof(ClutterSystem), "Awake")]
		[HarmonyPostfix]
		private static void ClutterSystem_Awake(ClutterSystem __instance)
		{
			Instance.ClutterSystem_Awake(__instance);
		}
	}

	private static ZoneManager _instance;

	/// <summary>
	///     Container for custom locations in the DontDestroyOnLoad scene.
	/// </summary>
	internal GameObject LocationContainer;

	/// <summary>
	///     The singleton instance of this manager.
	/// </summary>
	public static ZoneManager Instance => _instance ?? (_instance = new ZoneManager());

	internal Dictionary<string, CustomLocation> Locations { get; } = new Dictionary<string, CustomLocation>();

	internal Dictionary<string, CustomVegetation> Vegetations { get; } = new Dictionary<string, CustomVegetation>();

	internal Dictionary<string, CustomClutter> Clutter { get; } = new Dictionary<string, CustomClutter>();

	/// <summary>
	///     Event that gets fired after the vanilla locations are in memory and available for cloning or editing.
	///     Your code will execute every time a new <see cref="T:ZoneSystem" /> is available.
	///     If you want to execute just once you will need to unregister from the event after execution.
	/// </summary>
	public static event Action OnVanillaLocationsAvailable;

	/// <summary>
	///     Event that gets fired after all <see cref="T:Jotunn.Entities.CustomLocation" /> are registered in the <see cref="T:ZoneSystem" />.
	///     Your code will execute every time a new <see cref="T:ZoneSystem" /> is available.
	///     If you want to execute just once you will need to unregister from the event after execution.
	/// </summary>
	public static event Action OnLocationsRegistered;

	/// <summary>
	///     Event that gets fired after the vanilla clutter is in memory and available obtain.
	///     Your code will execute every time a new <see cref="T:ClutterSystem" /> is available.
	///     If you want to execute just once you will need to unregister from the event after execution.
	/// </summary>
	public static event Action OnVanillaClutterAvailable;

	/// <summary>
	///     Event that gets fired after all <see cref="T:Jotunn.Entities.CustomClutter" /> are registered in the <see cref="T:ClutterSystem" />.
	///     Your code will execute every time a new <see cref="T:ClutterSystem" /> is available.
	///     If you want to execute just once you will need to unregister from the event after execution.
	/// </summary>
	public static event Action OnClutterRegistered;

	/// <summary>
	///     Event that gets fired after the vanilla vegetation is in memory and available obtain.
	///     Your code will execute every time a new <see cref="T:ZoneSystem" /> is available.
	///     If you want to execute just once you will need to unregister from the event after execution.
	/// </summary>
	public static event Action OnVanillaVegetationAvailable;

	/// <summary>
	///     Event that gets fired after all <see cref="T:Jotunn.Entities.CustomVegetation" /> are registered in the <see cref="T:ZoneSystem" />.
	///     Your code will execute every time a new <see cref="T:ZoneSystem" /> is available.
	///     If you want to execute just once you will need to unregister from the event after execution.
	/// </summary>
	public static event Action OnVegetationRegistered;

	/// <summary>
	///     Hide .ctor
	/// </summary>
	private ZoneManager()
	{
	}

	static ZoneManager()
	{
		((IManager)Instance).Init();
	}

	/// <summary>
	///     Initialize the manager
	/// </summary>
	void IManager.Init()
	{
		Main.LogInit("ZoneManager");
		LocationContainer = new GameObject("Locations");
		LocationContainer.transform.parent = Main.RootObject.transform;
		LocationContainer.SetActive(value: false);
		Main.Harmony.PatchAll(typeof(Patches));
		PrefabManager.Instance.Activate();
	}

	/// <summary>
	///     Return a <see cref="T:Heightmap.Biome" /> that matches any of the provided Biomes
	/// </summary>
	/// <param name="biomes">Biomes that should match</param> 
	public static Heightmap.Biome AnyBiomeOf(params Heightmap.Biome[] biomes)
	{
		Heightmap.Biome biome = Heightmap.Biome.None;
		foreach (Heightmap.Biome biome2 in biomes)
		{
			biome |= biome2;
		}
		return biome;
	}

	/// <summary>
	///     Returns a list of all <see cref="T:Heightmap.Biome" /> that match <paramref name="biome" />
	/// </summary>
	/// <param name="biome"></param>
	/// <returns></returns>
	public static List<Heightmap.Biome> GetMatchingBiomes(Heightmap.Biome biome)
	{
		List<Heightmap.Biome> list = new List<Heightmap.Biome>();
		foreach (Heightmap.Biome value in Enum.GetValues(typeof(Heightmap.Biome)))
		{
			if ((biome & value) != Heightmap.Biome.None)
			{
				list.Add(value);
			}
		}
		return list;
	}

	/// <summary>
	///     Create an empty GameObject that is disabled, so any Components in instantiated GameObjects will not start their lifecycle.
	/// </summary>
	/// <param name="name">Name of the location</param>
	/// <returns>Empty and hierarchy disabled GameObject</returns>
	public GameObject CreateLocationContainer(string name)
	{
		GameObject gameObject = new GameObject
		{
			name = name
		};
		gameObject.transform.SetParent(LocationContainer.transform);
		return gameObject;
	}

	/// <summary>
	///     Create a copy that is disabled, so any Components in instantiated child GameObjects will not start their lifecycle.<br />
	///     Use this if you plan to alter your location prefab in code after importing it. <br />
	///     Don't create a separate container if you won't alter the prefab afterwards as it creates a new instance for the container.
	/// </summary>
	/// <param name="gameObject">Instantiated and hierarchy disabled location prefab</param>
	public GameObject CreateLocationContainer(GameObject gameObject)
	{
		GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject, LocationContainer.transform);
		gameObject2.name = gameObject.name;
		return gameObject2;
	}

	/// <summary>
	///     Loads and spawns a GameObject from an AssetBundle as a location container.<br />
	///     The copy is disabled, so any Components in instantiated child GameObjects will not start their lifecycle.<br />
	///     Use this if you plan to alter your location prefab in code after importing it. <br />
	///     Don't create a separate container if you won't alter the prefab afterwards as it creates a new instance for the container.
	/// </summary>
	/// <param name="assetBundle">A preloaded <see cref="T:UnityEngine.AssetBundle" /></param>
	/// <param name="assetName">Name of the prefab in the bundle to be instantiated as the location cotainer</param>
	public GameObject CreateLocationContainer(AssetBundle assetBundle, string assetName)
	{
		BepInPlugin bepInPlugin = BepInExUtils.GetPluginInfoFromAssembly(Assembly.GetCallingAssembly())?.Metadata;
		if (bepInPlugin == null || bepInPlugin.GUID == Main.Instance.Info.Metadata.GUID)
		{
			bepInPlugin = BepInExUtils.GetSourceModMetadata();
		}
		if (!AssetUtils.TryLoadPrefab(bepInPlugin, assetBundle, assetName, out var prefab))
		{
			Logger.LogError(bepInPlugin, "Failed to create location container for '" + assetName + "'");
			return null;
		}
		return CreateLocationContainer(prefab);
	}

	/// <summary>
	///     Create a copy that is disabled, so any Components in instantiated GameObjects will not start their lifecycle     
	/// </summary>
	/// <param name="gameObject">Prefab to copy</param>
	/// <param name="fixLocationReferences">Replace JVLmock GameObjects with a copy of their real prefab</param>
	/// <returns></returns>
	[Obsolete("Use CreateLocationContainer(GameObject) instead and define if references should be fixed in CustomLocation")]
	public GameObject CreateLocationContainer(GameObject gameObject, bool fixLocationReferences = false)
	{
		GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject, LocationContainer.transform);
		gameObject2.name = gameObject.name;
		if (fixLocationReferences)
		{
			gameObject2.FixReferences(recursive: true);
		}
		return gameObject2;
	}

	/// <summary>
	///     Register a CustomLocation to be added to the ZoneSystem
	/// </summary>
	/// <param name="customLocation"></param>
	/// <returns>true if the custom location could be added to the manager</returns>
	public bool AddCustomLocation(CustomLocation customLocation)
	{
		if (Locations.ContainsKey(customLocation.Name))
		{
			Logger.LogWarning(customLocation.SourceMod, "Location " + customLocation.Name + " already exists");
			return false;
		}
		if (!customLocation.SoftReference)
		{
			customLocation.Prefab.SetActive(value: true);
		}
		Locations.Add(customLocation.Name, customLocation);
		return true;
	}

	/// <summary>
	///     Get a custom location by name.
	/// </summary>
	/// <param name="name">Name of the location (normally the prefab name)</param>
	/// <returns>The <see cref="T:Jotunn.Entities.CustomLocation" /> object with the given name if found</returns>
	public CustomLocation GetCustomLocation(string name)
	{
		return Locations[name];
	}

	/// <summary>
	///     Get a ZoneLocation by its name.<br /><br />
	///     Search hierarchy:
	///     <list type="number">
	///         <item>Custom Location with the exact name</item>
	///         <item>Vanilla Location with the exact name from <see cref="T:ZoneSystem" /></item>
	///     </list>
	/// </summary>
	/// <param name="name">Name of the ZoneLocation to search for.</param>
	/// <returns>The existing ZoneLocation, or null if none exists with given name</returns>
	public ZoneSystem.ZoneLocation GetZoneLocation(string name)
	{
		if (Locations.TryGetValue(name, out var value))
		{
			return value.ZoneLocation;
		}
		int stableHashCode = StringExtensionMethods.GetStableHashCode(name);
		if ((bool)ZoneSystem.instance && ZoneSystem.instance.m_locationsByHash.TryGetValue(stableHashCode, out var value2))
		{
			return value2;
		}
		return null;
	}

	/// <summary>
	///     Create a CustomLocation that is a deep copy of the original.<br />
	///     Changes will not affect the original. The CustomLocation is already registered in the manager.
	/// </summary>
	/// <param name="name">name of the custom location</param>
	/// <param name="baseName">name of the existing location to copy</param>
	/// <returns>A CustomLocation object with the cloned location prefab</returns>
	public CustomLocation CreateClonedLocation(string name, string baseName)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		ZoneSystem.ZoneLocation zoneLocation = GetZoneLocation(baseName);
		zoneLocation.m_prefab.Load();
		GameObject exteriorPrefab = AssetManager.Instance.ClonePrefab(zoneLocation.m_prefab.Asset, name, LocationContainer.transform);
		CustomLocation customLocation = new CustomLocation(exteriorPrefab, fixReference: false, new LocationConfig(zoneLocation));
		AddCustomLocation(customLocation);
		zoneLocation.m_prefab.Release();
		return customLocation;
	}

	/// <summary>
	///     Remove a CustomLocation by its name.<br />
	///     Removes the CustomLocation from the manager.
	///     Does not remove the location from any current ZoneSystem instance.
	/// </summary>
	/// <param name="name">Name of the CustomLocation to search for.</param>
	public bool RemoveCustomLocation(string name)
	{
		return Locations.Remove(name);
	}

	/// <summary>
	///     Destroy a CustomLocation by its name.<br />
	///     Removes the CustomLocation from the manager and from the <see cref="T:ZoneSystem" /> if instantiated.
	/// </summary>
	/// <param name="name">Name of the CustomLocation to search for.</param>
	public bool DestroyCustomLocation(string name)
	{
		if (!Locations.TryGetValue(name, out var value))
		{
			return false;
		}
		int stableHashCode = StringExtensionMethods.GetStableHashCode(name);
		if ((bool)ZoneSystem.instance && ZoneSystem.instance.m_locationsByHash.TryGetValue(stableHashCode, out var value2))
		{
			ZoneSystem.instance.m_locationsByHash.Remove(stableHashCode);
			ZoneSystem.instance.m_locations.Remove(value2);
		}
		if ((bool)value.Prefab)
		{
			UnityEngine.Object.Destroy(value.Prefab);
		}
		return Locations.Remove(name);
	}

	/// <summary>
	///     Register a CustomVegetation to be added to the ZoneSystem
	/// </summary>
	/// <param name="customVegetation"></param>
	/// <returns></returns>
	public bool AddCustomVegetation(CustomVegetation customVegetation)
	{
		if (!customVegetation.IsValid())
		{
			return false;
		}
		if (!PrefabManager.Instance.AddPrefab(customVegetation.Prefab, customVegetation.SourceMod))
		{
			return false;
		}
		Vegetations.Add(customVegetation.Name, customVegetation);
		return true;
	}

	/// <summary>
	///     Get a ZoneVegetation by its name.<br /><br />
	///     Search hierarchy:
	///     <list type="number">
	///         <item>Custom Vegetation with the exact name</item>
	///         <item>Vanilla Vegetation with the exact name from <see cref="T:ZoneSystem" /></item>
	///     </list>
	/// </summary>
	/// <param name="name">Name of the ZoneVegetation to search for.</param>
	/// <returns>The existing ZoneVegetation, or null if none exists with given name</returns>
	public ZoneSystem.ZoneVegetation GetZoneVegetation(string name)
	{
		if (Vegetations.TryGetValue(name, out var value))
		{
			return value.Vegetation;
		}
		return ZoneSystem.instance.m_vegetation.DefaultIfEmpty(null).FirstOrDefault((ZoneSystem.ZoneVegetation zv) => (bool)zv.m_prefab && zv.m_prefab.name == name);
	}

	/// <summary>
	///     Remove a CustomVegetation from this manager by its name.<br />
	///     Does not remove it from any current ZoneSystem instance.
	/// </summary>
	/// <param name="name">Name of the CustomVegetation to search for.</param>
	public bool RemoveCustomVegetation(string name)
	{
		return Vegetations.Remove(name);
	}

	/// <summary>
	///     Register a CustomClutter to be added to the ClutterSystem
	/// </summary>
	/// <param name="customClutter"></param>
	/// <returns></returns>
	public bool AddCustomClutter(CustomClutter customClutter)
	{
		if (!customClutter.IsValid())
		{
			Logger.LogWarning(customClutter.SourceMod, $"Custom clutter '{customClutter}' is not valid");
			return false;
		}
		if (Clutter.ContainsKey(customClutter.Name))
		{
			return false;
		}
		Clutter.Add(customClutter.Name, customClutter);
		return true;
	}

	/// <summary>
	///     Get a Clutter by its name.<br /><br />
	///     Search hierarchy:
	///     <list type="number">
	///         <item>Custom Clutter with the exact name</item>
	///         <item>Vanilla Clutter with the exact name from <see cref="T:ClutterSystem" /></item>
	///     </list>
	/// </summary>
	/// <param name="name">Name of the Clutter to search for.</param>
	/// <returns>The existing Clutter, or null if none exists with given name</returns>
	public ClutterSystem.Clutter GetClutter(string name)
	{
		if (Clutter.TryGetValue(name, out var value))
		{
			return value.Clutter;
		}
		if (!ClutterSystem.instance)
		{
			return null;
		}
		return ClutterSystem.instance.m_clutter.DefaultIfEmpty(null).FirstOrDefault((ClutterSystem.Clutter zv) => zv?.m_name == name);
	}

	/// <summary>
	///     Remove a CustomClutter from this manager by its name.<br />
	///     Does not remove it from any current ClutterSystem instance.
	/// </summary>
	/// <param name="name">Name of the CustomClutter to search for.</param>
	public bool RemoveCustomClutter(string name)
	{
		return Clutter.Remove(name);
	}

	private void ClutterSystem_Awake(ClutterSystem instance)
	{
		InvokeOnVanillaClutterAvailable();
		if (Clutter.Count > 0)
		{
			Logger.LogInfo($"Injecting {Clutter.Count} custom clutter");
			List<string> list = new List<string>();
			foreach (CustomClutter value in Clutter.Values)
			{
				try
				{
					if (value.FixReference)
					{
						value.Prefab.FixReferences(recursive: true);
						value.FixReference = false;
					}
					instance.m_clutter.Add(value.Clutter);
				}
				catch (Exception arg)
				{
					Logger.LogWarning(value?.SourceMod, $"Exception caught while adding clutter: {arg}");
					list.Add(value.Name);
				}
			}
			foreach (string item in list)
			{
				Clutter.Remove(item);
			}
		}
		InvokeOnClutterRegistered();
	}

	private void RegisterLocations(ZoneSystem self)
	{
		InvokeOnVanillaLocationsAvailable();
		if (Locations.Count > 0)
		{
			List<string> list = new List<string>();
			Logger.LogInfo($"Injecting {Locations.Count} custom locations");
			foreach (CustomLocation value in Locations.Values)
			{
				try
				{
					Logger.LogDebug(string.Format("Adding custom location {0} in {1}", value, string.Join(", ", GetMatchingBiomes(value.ZoneLocation.m_biome))));
					if (value.FixReference && !value.SoftReference)
					{
						value.Prefab.FixReferences(recursive: true);
						value.FixReference = false;
					}
					if (!value.SoftReference)
					{
						PrepareLocation(value.ZoneLocation, value.SourceMod);
					}
					RegisterLocationInZoneSystem(self, value.ZoneLocation);
				}
				catch (Exception arg)
				{
					Logger.LogWarning(value?.SourceMod, $"Exception caught while adding location: {arg}");
					list.Add(value?.Name);
				}
			}
			foreach (string item in list)
			{
				Locations.Remove(item);
			}
		}
		InvokeOnLocationsRegistered();
	}

	private void RegisterVegetation(ZoneSystem self)
	{
		InvokeOnVanillaVegetationAvailable();
		if (Vegetations.Count > 0)
		{
			List<string> list = new List<string>();
			Logger.LogInfo($"Injecting {Vegetations.Count} custom vegetation");
			foreach (CustomVegetation value in Vegetations.Values)
			{
				try
				{
					Logger.LogDebug(string.Format("Adding custom vegetation {0} in {1}", value, string.Join(", ", GetMatchingBiomes(value.Vegetation.m_biome))));
					if (value.FixReference)
					{
						value.Prefab.FixReferences(recursive: true);
						value.FixReference = false;
					}
					self.m_vegetation.Add(value.Vegetation);
				}
				catch (Exception arg)
				{
					Logger.LogWarning(value?.SourceMod, $"Exception caught while adding vegetation: {arg}");
					list.Add(value.Name);
				}
			}
			foreach (string item in list)
			{
				Vegetations.Remove(item);
			}
		}
		InvokeOnVegetationRegistered();
	}

	/// <summary>
	///     Register a single ZoneLocaton in the current ZoneSystem.
	///     Also adds the location prefabs to the <see cref="T:Jotunn.Managers.PrefabManager" /> and <see cref="T:ZNetScene" /> if necessary.<br />
	///     No mock references are fixed.
	/// </summary>
	/// <param name="zoneLocation"><see cref="T:ZoneSystem.ZoneLocation" /> to add to the <see cref="T:ZoneSystem" /></param>
	public void RegisterLocationInZoneSystem(ZoneSystem.ZoneLocation zoneLocation)
	{
		PrepareLocation(zoneLocation, BepInExUtils.GetSourceModMetadata());
		RegisterLocationInZoneSystem(ZoneSystem.instance, zoneLocation);
	}

	internal void PrepareLocation(ZoneSystem.ZoneLocation zoneLocation, BepInPlugin sourceMod)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		zoneLocation.m_prefab.Load();
		ZNetView[] enabledComponentsInChildren = Utils.GetEnabledComponentsInChildren<ZNetView>(zoneLocation.m_prefab.Asset);
		foreach (ZNetView znet in enabledComponentsInChildren)
		{
			RegisterUnknownPrefab(sourceMod, znet);
		}
		RandomSpawn[] enabledComponentsInChildren2 = Utils.GetEnabledComponentsInChildren<RandomSpawn>(zoneLocation.m_prefab.Asset);
		RandomSpawn[] array = enabledComponentsInChildren2;
		foreach (RandomSpawn randomSpawn in array)
		{
			randomSpawn.Prepare();
		}
		foreach (ZNetView item in enabledComponentsInChildren2.SelectMany((RandomSpawn x) => x.m_childNetViews))
		{
			RegisterUnknownPrefab(sourceMod, item);
		}
	}

	private static void RegisterUnknownPrefab(BepInPlugin sourceMod, ZNetView znet)
	{
		string prefabName = znet.GetPrefabName();
		if (!prefabName.StartsWith("JVLmock_") && !ZNetScene.instance.m_namedPrefabs.ContainsKey(StringExtensionMethods.GetStableHashCode(prefabName)))
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(znet.gameObject, PrefabManager.Instance.PrefabContainer.transform);
			gameObject.name = prefabName;
			CustomPrefab customPrefab = new CustomPrefab(gameObject, sourceMod);
			PrefabManager.Instance.AddPrefab(customPrefab);
			PrefabManager.Instance.RegisterToZNetScene(customPrefab.Prefab);
		}
	}

	private void RegisterLocationInZoneSystem(ZoneSystem zoneSystem, ZoneSystem.ZoneLocation zoneLocation)
	{
		if (!zoneSystem.m_locationsByHash.ContainsKey(zoneLocation.Hash))
		{
			zoneSystem.m_locationsByHash.Add(zoneLocation.Hash, zoneLocation);
			zoneSystem.m_locations.Add(zoneLocation);
		}
		if (zoneLocation.m_prefab.IsLoaded)
		{
			zoneLocation.m_prefab.Release();
		}
	}

	private static void InvokeOnVanillaLocationsAvailable()
	{
		ZoneManager.OnVanillaLocationsAvailable?.SafeInvoke();
	}

	private static void InvokeOnLocationsRegistered()
	{
		ZoneManager.OnLocationsRegistered?.SafeInvoke();
	}

	private static void InvokeOnVanillaVegetationAvailable()
	{
		ZoneManager.OnVanillaVegetationAvailable?.SafeInvoke();
	}

	private static void InvokeOnVegetationRegistered()
	{
		ZoneManager.OnVegetationRegistered?.SafeInvoke();
	}

	private static void InvokeOnVanillaClutterAvailable()
	{
		ZoneManager.OnVanillaClutterAvailable?.SafeInvoke();
	}

	private static void InvokeOnClutterRegistered()
	{
		ZoneManager.OnClutterRegistered?.SafeInvoke();
	}
}
