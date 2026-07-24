using System.Reflection;
using BepInEx;
using Jotunn.Managers;
using Jotunn.Utils;
using UnityEngine;

namespace Jotunn.Entities;

/// <summary>
///     Wrapper for custom added GameObjects holding the mod reference.
/// </summary>
public class CustomPrefab : CustomEntity, IModPrefab
{
	private string fallbackPrefabName;

	/// <summary>
	///     Original prefab
	/// </summary>
	public GameObject Prefab { get; }

	/// <summary>
	///     Indicator if references from <see cref="T:Jotunn.Entities.Mock`1" />s will be replaced at runtime.
	/// </summary>
	public bool FixReference { get; set; }

	private string PrefabName
	{
		get
		{
			if (!Prefab)
			{
				return fallbackPrefabName;
			}
			return Prefab.name;
		}
	}

	/// <summary>
	///     Internal ctor with provided <see cref="T:BepInEx.BepInPlugin" /> metadata.<br />
	///     Does not fix references.
	/// </summary>
	/// <param name="prefab">Prefab added</param>
	/// <param name="sourceMod">Metadata of the mod adding this prefab</param>
	internal CustomPrefab(GameObject prefab, BepInPlugin sourceMod)
		: base(sourceMod)
	{
		Prefab = prefab;
	}

	/// <summary>
	///     Custom prefab.<br />
	///     Can fix references for <see cref="T:Jotunn.Entities.Mock`1" />s.
	/// </summary>
	/// <param name="prefab">The prefab for this custom item.</param>
	/// <param name="fixReference">If true references for <see cref="T:Jotunn.Entities.Mock`1" /> objects get resolved at runtime by Jötunn.</param>
	public CustomPrefab(GameObject prefab, bool fixReference)
		: base(Assembly.GetCallingAssembly())
	{
		Prefab = prefab;
		FixReference = fixReference;
	}

	/// <summary>
	///     Custom prefab loaded from an <see cref="T:UnityEngine.AssetBundle" />.<br />
	///     Can fix references for <see cref="T:Jotunn.Entities.Mock`1" />s.
	/// </summary>
	/// <param name="assetBundle">A preloaded <see cref="T:UnityEngine.AssetBundle" /></param>
	/// <param name="assetName">Name of the prefab in the bundle.</param>
	/// <param name="fixReference">If true references for <see cref="T:Jotunn.Entities.Mock`1" /> objects get resolved at runtime by Jötunn.</param>
	public CustomPrefab(AssetBundle assetBundle, string assetName, bool fixReference)
		: base(Assembly.GetCallingAssembly())
	{
		fallbackPrefabName = assetName;
		if (AssetUtils.TryLoadPrefab(base.SourceMod, assetBundle, assetName, out var prefab))
		{
			Prefab = prefab;
			FixReference = fixReference;
		}
	}

	/// <summary>
	///     Checks if a custom item is valid (i.e. has a prefab, an <see cref="T:ItemDrop" /> and an icon, if it should be craftable).
	/// </summary>
	/// <returns>true if all criteria is met</returns>
	public bool IsValid()
	{
		bool result = true;
		if (!Prefab)
		{
			Logger.LogError(base.SourceMod, $"CustomPrefab '{this}' has no prefab");
			result = false;
		}
		return result;
	}

	/// <summary>
	///     Helper method to determine if a prefab with a given name is a custom prefab created with Jötunn.
	/// </summary>
	/// <param name="prefabName">Name of the prefab to test.</param>
	/// <returns>true if the prefab is added as a custom prefab to the <see cref="T:Jotunn.Managers.PrefabManager" />.</returns>
	public static bool IsCustomPrefab(string prefabName)
	{
		return PrefabManager.Instance.Prefabs.ContainsKey(prefabName);
	}

	/// <inheritdoc />
	public override string ToString()
	{
		return PrefabName;
	}
}
