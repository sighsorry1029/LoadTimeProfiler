using BepInEx;
using UnityEngine;

namespace Jotunn.Utils;

/// <summary>
///     Interface to match a prefab to the mod that has created it. 
/// </summary>
public interface IModPrefab
{
	/// <summary>
	///     The target prefab.
	/// </summary>
	GameObject Prefab { get; }

	/// <summary>
	///     Reference to the <see cref="T:BepInEx.BepInPlugin" /> which added this prefab.
	/// </summary>
	BepInPlugin SourceMod { get; }
}
