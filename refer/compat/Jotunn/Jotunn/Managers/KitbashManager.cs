using System;
using System.Collections.Generic;
using Jotunn.Configs;
using Jotunn.Entities;
using UnityEngine;

namespace Jotunn.Managers;

/// <summary>
///     Manager for handling Kitbashed objects
/// </summary>
public class KitbashManager : IManager
{
	private static KitbashManager _instance;

	/// <summary>
	///     Internal list of objects to which Kitbashing should be applied.
	/// </summary>
	private readonly List<KitbashObject> KitbashObjects = new List<KitbashObject>();

	/// <summary>
	///     The singleton instance of this manager.
	/// </summary>
	public static KitbashManager Instance => _instance ?? (_instance = new KitbashManager());

	/// <summary>
	///     Hide .ctor
	/// </summary>
	private KitbashManager()
	{
	}

	static KitbashManager()
	{
		((IManager)Instance).Init();
	}

	/// <summary>
	///     Registers all hooks.
	/// </summary>
	void IManager.Init()
	{
		Main.LogInit("KitbashManager");
		ItemManager.OnKitbashItemsAvailable += ApplyKitbashes;
	}

	/// <summary>
	///     Register a prefab with a KitbashConfig to be applied when the vanilla prefabs are available
	/// </summary>
	/// <param name="prefab">Prefab to add kitbashed parts to</param>
	/// <param name="kitbashConfig">KitbashConfig to apply to the prefab</param>
	/// <returns>The KitbashObject container for this prefab</returns>
	public KitbashObject AddKitbash(GameObject prefab, KitbashConfig kitbashConfig)
	{
		if (prefab.transform.parent == null)
		{
			string name = prefab.name;
			prefab = UnityEngine.Object.Instantiate(prefab, PrefabManager.Instance.PrefabContainer.transform);
			prefab.name = name;
		}
		KitbashObject kitbashObject = new KitbashObject
		{
			Config = kitbashConfig,
			Prefab = prefab
		};
		KitbashObjects.Add(kitbashObject);
		return kitbashObject;
	}

	/// <summary>
	///     Apply all Kitbashs to the objects registered in the manager.
	/// </summary>
	private void ApplyKitbashes()
	{
		if (KitbashObjects.Count <= 0)
		{
			return;
		}
		Logger.LogInfo($"Applying Kitbash in {KitbashObjects.Count} objects");
		foreach (KitbashObject kitbashObject in KitbashObjects)
		{
			try
			{
				if (kitbashObject.Config.FixReferences)
				{
					kitbashObject.Prefab.FixReferences();
				}
				ApplyKitbash(kitbashObject);
			}
			catch (Exception data)
			{
				Logger.LogError(kitbashObject.SourceMod, data);
			}
		}
		ItemManager.OnKitbashItemsAvailable -= ApplyKitbashes;
	}

	/// <summary>
	///     Apply kitbash to a single object.
	/// </summary>
	/// <param name="kitbashObject"></param>
	/// <returns></returns>
	private bool ApplyKitbash(KitbashObject kitbashObject)
	{
		foreach (KitbashSourceConfig kitbashSource in kitbashObject.Config.KitbashSources)
		{
			if (!Instance.Kitbash(kitbashObject, kitbashSource))
			{
				Logger.LogWarning(kitbashObject.SourceMod, $"Kitbash failed for {kitbashObject}");
				return false;
			}
		}
		if (kitbashObject.Config.Layer != null)
		{
			int layer = LayerMask.NameToLayer(kitbashObject.Config.Layer);
			Transform[] componentsInChildren = kitbashObject.Prefab.GetComponentsInChildren<Transform>();
			foreach (Transform transform in componentsInChildren)
			{
				transform.gameObject.layer = layer;
			}
		}
		kitbashObject.OnKitbashApplied?.SafeInvoke();
		return true;
	}

	private bool Kitbash(KitbashObject kitbashObject, KitbashSourceConfig config)
	{
		GameObject prefab = PrefabManager.Instance.GetPrefab(config.SourcePrefab);
		if (!prefab)
		{
			Logger.LogWarning(kitbashObject.SourceMod, "Prefab '" + config.SourcePrefab + "' not found for " + config.ToString());
			return false;
		}
		Transform transform = prefab.transform.Find(config.SourcePath);
		if (!transform)
		{
			Logger.LogWarning(kitbashObject.SourceMod, "Source path '" + config.SourcePath + "' not found for " + config.ToString());
			return false;
		}
		GameObject prefab2 = kitbashObject.Prefab;
		Transform transform2 = ((config.TargetParentPath != null) ? prefab2.transform.Find(config.TargetParentPath) : prefab2.transform);
		if (!transform2)
		{
			Logger.LogWarning(kitbashObject.SourceMod, "Target parent not found for " + config.ToString());
			return false;
		}
		GameObject gameObject = transform.gameObject;
		GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject, transform2);
		gameObject2.name = config.Name ?? gameObject.name;
		gameObject2.transform.localPosition = config.Position;
		gameObject2.transform.localRotation = config.Rotation;
		gameObject2.transform.localScale = config.Scale;
		if (config.Materials != null)
		{
			Material[] sourceMaterials = GetSourceMaterials(config);
			if (sourceMaterials == null)
			{
				Logger.LogWarning(kitbashObject.SourceMod, "No materials found for " + config.ToString());
				return false;
			}
			SkinnedMeshRenderer[] componentsInChildren = gameObject2.GetComponentsInChildren<SkinnedMeshRenderer>();
			SkinnedMeshRenderer[] array = componentsInChildren;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in array)
			{
				skinnedMeshRenderer.sharedMaterials = sourceMaterials;
				skinnedMeshRenderer.materials = sourceMaterials;
			}
			MeshRenderer[] componentsInChildren2 = gameObject2.GetComponentsInChildren<MeshRenderer>();
			MeshRenderer[] array2 = componentsInChildren2;
			foreach (MeshRenderer meshRenderer in array2)
			{
				meshRenderer.sharedMaterials = sourceMaterials;
				meshRenderer.materials = sourceMaterials;
			}
		}
		return true;
	}

	private Material[] GetSourceMaterials(KitbashSourceConfig config)
	{
		Material[] array = new Material[config.Materials.Length];
		for (int i = 0; i < config.Materials.Length; i++)
		{
			array[i] = (Material)PrefabManager.Cache.GetPrefab(typeof(Material), config.Materials[i]);
		}
		return array;
	}
}
