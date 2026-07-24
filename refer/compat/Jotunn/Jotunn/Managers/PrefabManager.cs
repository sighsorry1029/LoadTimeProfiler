using System;
using System.Collections.Generic;
using System.Linq;
using BepInEx;
using HarmonyLib;
using Jotunn.Entities;
using SoftReferenceableAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Jotunn.Managers;

/// <summary>
///     Manager for handling custom prefabs added to the game.
/// </summary>
public class PrefabManager : IManager
{
	private static class Patches
	{
		[HarmonyPatch(typeof(ZNetScene), "Awake")]
		[HarmonyPostfix]
		private static void RegisterAllToZNetScene()
		{
			Instance.RegisterAllToZNetScene();
		}

		[HarmonyPatch(typeof(ObjectDB), "CopyOtherDB")]
		[HarmonyPrefix]
		[HarmonyPriority(0)]
		private static void InvokeOnVanillaObjectsAvailable(ObjectDB other)
		{
			Instance.MenuObjectDB = other;
			Instance.InvokeOnVanillaObjectsAvailable();
		}

		[HarmonyPatch(typeof(ZNetScene), "Awake")]
		[HarmonyPostfix]
		[HarmonyPriority(0)]
		private static void InvokeOnPrefabsRegistered()
		{
			Instance.InvokeOnPrefabsRegistered();
		}

		[HarmonyPatch(typeof(ZoneSystem), "SetupLocations")]
		[HarmonyPrefix]
		[HarmonyPriority(600)]
		private static void ZoneSystem_ClearPrefabCache(ZoneSystem __instance)
		{
			Cache.Clear();
		}
	}

	/// <summary>
	///     Global cache of Unity Objects by asset name.<br />
	///     Built on first access of every type and is cleared on scene change.
	/// </summary>
	public static class Cache
	{
		private static readonly Dictionary<Type, Dictionary<string, UnityEngine.Object>> dictionaryCache = new Dictionary<Type, Dictionary<string, UnityEngine.Object>>();

		/// <summary>
		///     Get an instance of an Unity Object from the current scene with the given name.
		/// </summary>
		/// <param name="type"><see cref="T:System.Type" /> to search for.</param>
		/// <param name="name">Name of the actual object to search for.</param>
		/// <returns></returns>
		public static UnityEngine.Object GetPrefab(Type type, string name)
		{
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			if (AssetManager.Instance.IsReady())
			{
				SoftReference<UnityEngine.Object> softReference = AssetManager.Instance.GetSoftReference(type, name);
				if (softReference.IsValid)
				{
					softReference.Load();
					if ((bool)softReference.Asset)
					{
						if (softReference.Asset.GetType() == type)
						{
							return softReference.Asset;
						}
						if (softReference.Asset is GameObject unityObject && TryFindAssetInSelfOrChildComponents(unityObject, type, out var asset))
						{
							return asset;
						}
					}
				}
			}
			if (GetCachedMap(type).TryGetValue(name, out var value))
			{
				return value;
			}
			return null;
		}

		/// <summary>
		///     Get an instance of an Unity Object from the current scene by name.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="name"></param>
		/// <returns></returns>
		public static T GetPrefab<T>(string name) where T : UnityEngine.Object
		{
			return (T)GetPrefab(typeof(T), name);
		}

		/// <summary>
		///     Get all instances of an Unity Object from the current scene by type.
		/// </summary>
		/// <param name="type"><see cref="T:System.Type" /> to search for.</param>
		/// <returns></returns>
		public static Dictionary<string, UnityEngine.Object> GetPrefabs(Type type)
		{
			return GetCachedMap(type);
		}

		private static Transform GetParent(UnityEngine.Object obj)
		{
			if (!(obj is GameObject gameObject))
			{
				return null;
			}
			return gameObject.transform.parent;
		}

		/// <summary>
		///     Determines the best matching asset for a given name.
		///     Only one asset can be associated with a name, this ties to find the best match if there is already a cached one present.
		/// </summary>
		/// <param name="map"></param>
		/// <param name="newObject"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		private static UnityEngine.Object FindBestAsset(IDictionary<string, UnityEngine.Object> map, UnityEngine.Object newObject, string name)
		{
			if (!map.TryGetValue(name, out var value))
			{
				return newObject;
			}
			if (name == "_NetScene" && value is GameObject gameObject && newObject is GameObject gameObject2 && !gameObject.activeInHierarchy && gameObject2.activeInHierarchy)
			{
				return gameObject2;
			}
			if (value is Material cachedMaterial && newObject is Material newMaterial && FindBestMaterial(cachedMaterial, newMaterial, out var material))
			{
				return material;
			}
			bool flag = GetParent(value);
			bool flag2 = GetParent(newObject);
			if (!flag && flag2)
			{
				return value;
			}
			if (flag)
			{
				return newObject;
			}
			return newObject;
		}

		private static bool FindBestMaterial(Material cachedMaterial, Material newMaterial, out UnityEngine.Object material)
		{
			string name = cachedMaterial.shader.name;
			string name2 = newMaterial.shader.name;
			if (name == "Hidden/InternalErrorShader" && name2 != "Hidden/InternalErrorShader")
			{
				material = newMaterial;
				return true;
			}
			if (name != "Hidden/InternalErrorShader" && name2 == "Hidden/InternalErrorShader")
			{
				material = cachedMaterial;
				return true;
			}
			material = null;
			return false;
		}

		private static Dictionary<string, UnityEngine.Object> GetCachedMap(Type type)
		{
			if (dictionaryCache.TryGetValue(type, out var value))
			{
				return value;
			}
			return InitCache(type);
		}

		private static Dictionary<string, UnityEngine.Object> InitCache(Type type)
		{
			Dictionary<string, UnityEngine.Object> dictionary = new Dictionary<string, UnityEngine.Object>();
			UnityEngine.Object[] array = Resources.FindObjectsOfTypeAll(type);
			foreach (UnityEngine.Object obj in array)
			{
				string name = obj.name;
				dictionary[name] = FindBestAsset(dictionary, obj, name);
			}
			dictionaryCache[type] = dictionary;
			return dictionary;
		}

		/// <summary>
		///     Clears the entire cache, resulting in a rebuilt on the next access.<br />
		///     This can be useful if an asset is loaded late after a scene change and might be missing in the cache.
		///     Rebuilding can be an expensive operation, so use with caution.
		/// </summary>
		public static void Clear()
		{
			dictionaryCache.Clear();
		}

		/// <summary>
		///     Clears the cache for a specific type, resulting in a rebuilt on the next access.<br />
		///     This can be useful if an asset is loaded late after a scene change and might be missing in the cache.
		///     Rebuilding can be an expensive operation, so use with caution.
		/// </summary>
		/// <typeparam name="T">The type of object to clear the cache for</typeparam>
		public static void Clear<T>() where T : UnityEngine.Object
		{
			dictionaryCache.Remove(typeof(T));
		}
	}

	private static PrefabManager _instance;

	/// <summary>
	///     The singleton instance of this manager.
	/// </summary>
	public static PrefabManager Instance => _instance ?? (_instance = new PrefabManager());

	/// <summary>
	///     Container for custom prefabs in the DontDestroyOnLoad scene.
	/// </summary>
	internal GameObject PrefabContainer { get; private set; }

	/// <summary>
	///     Dictionary of all added custom prefabs by name hash.
	/// </summary>
	internal Dictionary<string, CustomPrefab> Prefabs { get; } = new Dictionary<string, CustomPrefab>();

	internal ObjectDB MenuObjectDB { get; private set; }

	/// <summary>
	///     Event that gets fired after the vanilla prefabs are in memory and available for cloning.
	///     Your code will execute every time before a new <see cref="T:ObjectDB" /> is copied (on every menu start).
	///     If you want to execute just once you will need to unregister from the event after execution.
	/// </summary>
	public static event Action OnVanillaPrefabsAvailable;

	/// <summary>
	///     Event that gets fired after registering all custom prefabs to <see cref="T:ZNetScene" />.
	///     Your code will execute every time a new ZNetScene is created (on every game start).
	///     If you want to execute just once you will need to unregister from the event after execution.
	/// </summary>
	public static event Action OnPrefabsRegistered;

	/// <summary>
	///     Hide .ctor
	/// </summary>
	private PrefabManager()
	{
	}

	static PrefabManager()
	{
		((IManager)Instance).Init();
	}

	/// <summary>
	///     Creates the prefab container and registers all hooks.
	/// </summary>
	void IManager.Init()
	{
		Main.LogInit("PrefabManager");
		PrefabContainer = new GameObject("Prefabs");
		PrefabContainer.transform.parent = Main.RootObject.transform;
		PrefabContainer.SetActive(value: false);
		Main.Harmony.PatchAll(typeof(Patches));
		SceneManager.sceneUnloaded += delegate
		{
			Cache.Clear();
			Instance.MenuObjectDB = null;
		};
	}

	/// <summary>
	///     Makes sure the PrefabManager initializes. Only needed if timing is important.
	/// </summary>
	internal void Activate()
	{
	}

	/// <summary>
	///     Add a custom prefab to the manager with known source mod metadata. Don't fix references.
	/// </summary>
	/// <param name="prefab">Prefab to add</param>
	/// <param name="sourceMod">Metadata of the mod adding this prefab</param>
	/// <returns>true if the custom prefab was added to the manager.</returns>
	internal bool AddPrefab(GameObject prefab, BepInPlugin sourceMod)
	{
		CustomPrefab customPrefab = new CustomPrefab(prefab, sourceMod);
		AddPrefab(customPrefab);
		return Prefabs.ContainsKey(prefab.name);
	}

	/// <summary>
	///     Add a custom prefab to the manager.<br />
	///     Checks if a prefab with the same name is already added.<br />
	///     Added prefabs get registered to the <see cref="T:ZNetScene" /> on <see cref="M:ZNetScene.Awake" />.
	/// </summary>
	/// <param name="prefab">Prefab to add</param>
	public void AddPrefab(GameObject prefab)
	{
		CustomPrefab customPrefab = new CustomPrefab(prefab, fixReference: false);
		AddPrefab(customPrefab);
	}

	/// <summary>
	///     Add a custom prefab to the manager.<br />
	///     Checks if a prefab with the same name is already added.<br />
	///     Added prefabs get registered to the <see cref="T:ZNetScene" /> on <see cref="M:ZNetScene.Awake" />.
	/// </summary>
	/// <param name="customPrefab">Prefab to add</param>
	public void AddPrefab(CustomPrefab customPrefab)
	{
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		if (!customPrefab.IsValid())
		{
			Logger.LogWarning(customPrefab.SourceMod, $"Custom prefab {customPrefab} is not valid");
			return;
		}
		string name = customPrefab.Prefab.name;
		if (Prefabs.ContainsKey(name))
		{
			Logger.LogWarning(customPrefab.SourceMod, $"Prefab '{customPrefab}' already exists");
			return;
		}
		customPrefab.Prefab.transform.SetParent(PrefabContainer.transform, worldPositionStays: false);
		Prefabs.Add(name, customPrefab);
		AssetManager.Instance.AddAsset(customPrefab.Prefab, null);
	}

	/// <summary>
	///     Create a new prefab from an empty primitive.
	/// </summary>
	/// <param name="name">The name of the new GameObject</param>
	/// <param name="addZNetView">
	///     When true a ZNetView component is added to the new GameObject for ZDO generation and networking. Default: true
	/// </param>
	/// <returns>The newly created empty prefab</returns>
	public GameObject CreateEmptyPrefab(string name, bool addZNetView = true)
	{
		if (string.IsNullOrEmpty(name))
		{
			Logger.LogWarning("Failed to create prefab with invalid name: " + name);
			return null;
		}
		if ((bool)GetPrefab(name))
		{
			Logger.LogWarning("Failed to create prefab, name already exists: " + name);
			return null;
		}
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		gameObject.name = name;
		gameObject.transform.parent = PrefabContainer.transform;
		if (addZNetView)
		{
			ZNetView zNetView = gameObject.AddComponent<ZNetView>();
			zNetView.m_persistent = true;
		}
		return gameObject;
	}

	/// <summary>
	///     Create a copy of a given prefab without modifying the original.
	/// </summary>
	/// <param name="name">Name of the new prefab.</param>
	/// <param name="baseName">Name of the vanilla prefab to copy from.</param>
	/// <returns>Newly created prefab object</returns>
	public GameObject CreateClonedPrefab(string name, string baseName)
	{
		if (string.IsNullOrEmpty(baseName))
		{
			Logger.LogWarning("Failed to clone prefab with invalid baseName: " + baseName);
			return null;
		}
		GameObject prefab = GetPrefab(baseName);
		if (!prefab)
		{
			Logger.LogWarning("Failed to clone prefab, can not find base prefab with name: " + baseName);
			return null;
		}
		return CreateClonedPrefab(name, prefab);
	}

	/// <summary>
	///     Create a copy of a given prefab without modifying the original.
	/// </summary>
	/// <param name="name">Name of the new prefab.</param>
	/// <param name="prefab">Prefab instance to copy.</param>
	/// <returns>Newly created prefab object</returns>
	public GameObject CreateClonedPrefab(string name, GameObject prefab)
	{
		if (string.IsNullOrEmpty(name))
		{
			Logger.LogWarning("Failed to clone prefab with invalid name: " + name);
			return null;
		}
		if (!prefab)
		{
			Logger.LogWarning("Failed to clone prefab, base prefab is not valid");
			return null;
		}
		if ((bool)GetPrefab(name))
		{
			Logger.LogWarning("Failed to clone prefab, name already exists: " + name);
			return null;
		}
		return AssetManager.Instance.ClonePrefab(prefab, name, PrefabContainer.transform);
	}

	/// <summary>
	///     Get a prefab by its name.<br /><br />
	///     Search hierarchy:
	///     <list type="number">
	///         <item>Custom prefab with the exact name</item>
	///         <item>Vanilla prefab with the exact name from <see cref="T:ZNetScene" /> if already instantiated</item>
	///         <item>Vanilla prefab from the prefab cache</item>
	///     </list>
	/// </summary>
	/// <param name="name">Name of the prefab to search for.</param>
	/// <returns>The existing prefab, or null if none exists with given name</returns>
	public GameObject GetPrefab(string name)
	{
		if (Prefabs.TryGetValue(name, out var value))
		{
			return value.Prefab;
		}
		int stableHashCode = StringExtensionMethods.GetStableHashCode(name);
		if ((bool)ZNetScene.instance && ZNetScene.instance.m_namedPrefabs.TryGetValue(stableHashCode, out var value2))
		{
			return value2;
		}
		if ((bool)ObjectDB.instance && ObjectDB.instance.m_itemByHash.TryGetValue(stableHashCode, out var value3))
		{
			return value3;
		}
		return Cache.GetPrefab<GameObject>(name);
	}

	/// <summary>
	///     Remove a custom prefab from the manager.
	/// </summary>
	/// <param name="name">Name of the prefab to remove</param>
	public void RemovePrefab(string name)
	{
		Prefabs.Remove(name);
	}

	/// <summary>
	///     Destroy a custom prefab.<br />
	///     Removes it from the manager and if already instantiated also from the <see cref="T:ZNetScene" />.
	/// </summary>
	/// <param name="name">The name of the prefab to destroy</param>
	public void DestroyPrefab(string name)
	{
		if (!Prefabs.TryGetValue(name, out var value))
		{
			return;
		}
		if ((bool)ZNetScene.instance)
		{
			int stableHashCode = StringExtensionMethods.GetStableHashCode(name);
			if (ZNetScene.instance.m_namedPrefabs.TryGetValue(stableHashCode, out var value2))
			{
				ZNetScene.instance.m_prefabs.Remove(value2);
				ZNetScene.instance.m_nonNetViewPrefabs.Remove(value2);
				ZNetScene.instance.m_namedPrefabs.Remove(stableHashCode);
				ZNetScene.instance.Destroy(value2);
			}
		}
		if ((bool)value.Prefab)
		{
			UnityEngine.Object.Destroy(value.Prefab);
		}
		Prefabs.Remove(name);
	}

	/// <summary>
	///     Register all custom prefabs to m_prefabs/m_namedPrefabs in <see cref="T:ZNetScene" />.
	/// </summary>
	private void RegisterAllToZNetScene()
	{
		if (!Prefabs.Any())
		{
			return;
		}
		Logger.LogInfo($"Adding {Prefabs.Count} custom prefabs to the ZNetScene");
		List<CustomPrefab> list = new List<CustomPrefab>();
		foreach (CustomPrefab value in Prefabs.Values)
		{
			try
			{
				if (value.FixReference)
				{
					value.Prefab.FixReferences(recursive: true);
					value.FixReference = false;
				}
				RegisterToZNetScene(value.Prefab);
			}
			catch (Exception arg)
			{
				Logger.LogWarning(value?.SourceMod, $"Error caught while adding prefab {value}: {arg}");
				list.Add(value);
			}
		}
		foreach (CustomPrefab item in list)
		{
			if ((bool)item.Prefab)
			{
				DestroyPrefab(item.Prefab.name);
			}
		}
	}

	/// <summary>
	///     Register a single prefab to the current <see cref="T:ZNetScene" />.<br />
	///     Checks for existence of the object via GetStableHashCode() and adds the prefab if it is not already added.
	/// </summary>
	/// <param name="gameObject"></param>
	public void RegisterToZNetScene(GameObject gameObject)
	{
		ZNetScene instance = ZNetScene.instance;
		if (!instance)
		{
			return;
		}
		string name = gameObject.name;
		if (gameObject.name.StartsWith("JVLmock_"))
		{
			return;
		}
		int stableHashCode = StringExtensionMethods.GetStableHashCode(name);
		if (instance.m_namedPrefabs.ContainsKey(stableHashCode))
		{
			Logger.LogDebug("Prefab " + name + " already in ZNetScene");
			return;
		}
		if (gameObject.GetComponent<ZNetView>() != null)
		{
			instance.m_prefabs.Add(gameObject);
		}
		else
		{
			instance.m_nonNetViewPrefabs.Add(gameObject);
		}
		instance.m_namedPrefabs.Add(stableHashCode, gameObject);
		Logger.LogDebug("Added prefab " + name);
	}

	/// <summary>
	///     Safely invoke the <see cref="E:Jotunn.Managers.PrefabManager.OnVanillaPrefabsAvailable" /> event
	/// </summary>
	private void InvokeOnVanillaObjectsAvailable()
	{
		PrefabManager.OnVanillaPrefabsAvailable?.SafeInvoke();
	}

	private void InvokeOnPrefabsRegistered()
	{
		PrefabManager.OnPrefabsRegistered?.SafeInvoke();
	}

	private static bool TryFindAssetOfComponent(Component unityObject, Type objectType, out UnityEngine.Object asset)
	{
		Type type = unityObject.GetType();
		ClassMember classMember = ClassMember.GetClassMember(type);
		foreach (MemberBase member in classMember.Members)
		{
			if (member.MemberType == objectType && member.HasGetMethod)
			{
				asset = (UnityEngine.Object)member.GetValue(unityObject);
				if (asset != null)
				{
					return asset;
				}
			}
		}
		asset = null;
		return false;
	}

	internal static bool TryFindAssetInSelfOrChildComponents(GameObject unityObject, Type objectType, out UnityEngine.Object asset)
	{
		if (!unityObject)
		{
			asset = null;
			return false;
		}
		if (objectType.IsSubclassOf(typeof(Component)))
		{
			Component component = unityObject.GetComponent(objectType);
			if ((bool)component)
			{
				asset = component;
				return true;
			}
		}
		Component[] components = unityObject.GetComponents<Component>();
		foreach (Component component2 in components)
		{
			if (!(component2 is Transform) && TryFindAssetOfComponent(component2, objectType, out asset))
			{
				return asset;
			}
		}
		foreach (Transform item in unityObject.transform)
		{
			if (TryFindAssetInSelfOrChildComponents(item.gameObject, objectType, out asset))
			{
				return asset;
			}
		}
		asset = null;
		return false;
	}
}
