using System.Reflection;
using Jotunn.Configs;
using Jotunn.Utils;
using UnityEngine;

namespace Jotunn.Entities;

/// <summary>
///     Main interface for adding custom clutter to the game.<br />
///     Clutter are client side only objects scattered on the ground.<br />
///     All custom clutter have to be wrapped inside this class to add it to Jötunns <see cref="T:Jotunn.Managers.ZoneManager" />.
/// </summary>
public class CustomClutter : CustomEntity
{
	/// <summary>
	///     The prefab for this custom clutter.
	/// </summary>
	public GameObject Prefab { get; }

	/// <summary>
	///     Associated <see cref="T:ClutterSystem.Clutter" /> class.
	/// </summary>
	public ClutterSystem.Clutter Clutter { get; }

	/// <summary>
	///     Name of this custom clutter.
	/// </summary>
	public string Name { get; }

	/// <summary>
	///     Indicator if references from <see cref="T:Jotunn.Entities.Mock`1" />s will be replaced at runtime.
	/// </summary>
	public bool FixReference { get; set; }

	/// <summary>
	///     Custom clutter from a prefab.<br />
	///     Can fix references for mocks.
	/// </summary>
	/// <param name="prefab">The prefab for this custom clutter.</param>
	/// <param name="fixReference">If true references for <see cref="T:Jotunn.Entities.Mock`1" /> objects get resolved at runtime by Jötunn.</param>
	/// <param name="config">The <see cref="T:Jotunn.Configs.ClutterConfig" /> for this custom vegation.</param>
	public CustomClutter(GameObject prefab, bool fixReference, ClutterConfig config)
		: base(Assembly.GetCallingAssembly())
	{
		Prefab = prefab;
		Name = prefab.name;
		Clutter = config.ToClutter();
		Clutter.m_prefab = prefab;
		FixReference = fixReference;
	}

	/// <summary>
	///     Custom clutter from a prefab loaded from an <see cref="T:UnityEngine.AssetBundle" />.<br />
	///     Can fix references for mocks.
	/// </summary>
	/// <param name="assetBundle">A preloaded <see cref="T:UnityEngine.AssetBundle" /></param>
	/// <param name="assetName">Name of the prefab in the bundle.</param>
	/// <param name="fixReference">If true references for <see cref="T:Jotunn.Entities.Mock`1" /> objects get resolved at runtime by Jötunn.</param>
	/// <param name="config">The <see cref="T:Jotunn.Configs.ClutterConfig" /> for this custom clutter.</param>
	public CustomClutter(AssetBundle assetBundle, string assetName, bool fixReference, ClutterConfig config)
		: base(Assembly.GetCallingAssembly())
	{
		Name = assetName;
		if (AssetUtils.TryLoadPrefab(base.SourceMod, assetBundle, assetName, out var prefab))
		{
			Prefab = prefab;
			Clutter = config.ToClutter();
			Clutter.m_prefab = Prefab;
			FixReference = fixReference;
		}
	}

	/// <summary>
	///     Checks if a custom clutter is valid (i.e. has a prefab).
	/// </summary>
	/// <returns>true if all criteria is met</returns>
	public bool IsValid()
	{
		bool result = true;
		if (!Prefab)
		{
			Logger.LogError(base.SourceMod, $"Custom Clutter '{this}' has no prefab");
			result = false;
		}
		return result;
	}

	/// <inheritdoc />
	public override string ToString()
	{
		return Name;
	}
}
