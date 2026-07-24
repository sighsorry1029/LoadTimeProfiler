using System;
using System.Reflection;
using Jotunn.Configs;
using Jotunn.Managers;
using SoftReferenceableAssets;
using UnityEngine;

namespace Jotunn.Entities;

/// <summary>
///     Main interface for adding custom dungeon rooms to the game.<br />
///     All custom rooms have to be wrapped inside this class to add it to Jötunns <see cref="T:Jotunn.Managers.DungeonManager" />.
/// </summary>
public class CustomRoom : CustomEntity
{
	/// <summary>
	///     The prefab for this custom room.
	/// </summary>
	public GameObject Prefab { get; }

	/// <summary>
	///     The <see cref="T:Room" /> component for this custom room as a shortcut.
	/// </summary>
	public Room Room { get; }

	/// <summary>
	///     The name of this custom room as a shortcut.
	/// </summary>
	public string Name { get; }

	/// <summary>
	///     Indicator if references from <see cref="T:Jotunn.Entities.Mock`1" />s will be replaced at runtime.
	/// </summary>
	public bool FixReference { get; set; }

	/// <summary>
	///     Theme name of this room.
	/// </summary>
	public string ThemeName { get; set; }

	/// <summary>
	///     Indicator if room is added from SoftReferenceableAssets.<br />
	///     Used to delay mocking prefabs until DungeonGenerator loads the room.
	/// </summary>
	public bool SoftReference { get; set; }

	/// <summary>
	///     Associated <see cref="T:DungeonDB.RoomData" /> holding data used during generation.
	/// </summary>
	public DungeonDB.RoomData RoomData { get; private set; }

	/// <summary>
	///     Custom room from a prefab loaded from an <see cref="T:UnityEngine.AssetBundle" /> with a <see cref="T:Room" /> made from a <see cref="T:Jotunn.Configs.RoomConfig" />.<br />
	///     Can fix references for <see cref="T:Jotunn.Entities.Mock`1" />s.
	/// </summary>
	/// <param name="assetBundle">A preloaded <see cref="T:UnityEngine.AssetBundle" /></param>
	/// <param name="assetName">Name of the prefab in the bundle.</param>
	/// <param name="fixReference">If true references for <see cref="T:Jotunn.Entities.Mock`1" /> objects get resolved at runtime by Jötunn.</param>
	/// <param name="roomConfig">The config for this custom room.</param>
	public CustomRoom(AssetBundle assetBundle, string assetName, bool fixReference, RoomConfig roomConfig)
		: base(Assembly.GetCallingAssembly())
	{
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		Prefab = assetBundle.LoadAsset<GameObject>(assetName);
		Name = Prefab.name;
		ThemeName = roomConfig.ThemeName;
		if (Prefab != null && Prefab.TryGetComponent<Room>(out var component))
		{
			Room room = component;
			Room = roomConfig.Apply(room);
		}
		else
		{
			Room room2 = Prefab.AddComponent<Room>();
			Room = roomConfig.Apply(room2);
		}
		FixReference = fixReference;
		RoomData = new DungeonDB.RoomData
		{
			m_prefab = new SoftReference<GameObject>(AssetManager.Instance.AddAsset(Prefab)),
			m_loadedRoom = Room,
			m_enabled = Room.m_enabled,
			m_theme = GetRoomTheme(ThemeName)
		};
	}

	/// <summary>
	///     Custom room from a prefab loaded from an <see cref="T:UnityEngine.AssetBundle" /> with a <see cref="T:Room" /> made from a <see cref="T:Jotunn.Configs.RoomConfig" />.<br />
	///     Can fix references for <see cref="T:Jotunn.Entities.Mock`1" />s.
	/// </summary>
	/// <param name="prefab">The prefab for this custom room.</param>
	/// <param name="fixReference">If true references for <see cref="T:Jotunn.Entities.Mock`1" /> objects get resolved at runtime by Jötunn.</param>
	/// <param name="roomConfig">The config for this custom room.</param>
	public CustomRoom(GameObject prefab, bool fixReference, RoomConfig roomConfig)
		: base(Assembly.GetCallingAssembly())
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		Prefab = prefab;
		Name = prefab.name;
		ThemeName = roomConfig.ThemeName;
		if (prefab != null && prefab.TryGetComponent<Room>(out var component))
		{
			Room room = component;
			Room = roomConfig.Apply(room);
		}
		else
		{
			Room room2 = prefab.AddComponent<Room>();
			Room = roomConfig.Apply(room2);
		}
		FixReference = fixReference;
		RoomData = new DungeonDB.RoomData
		{
			m_prefab = new SoftReference<GameObject>(AssetManager.Instance.AddAsset(Prefab)),
			m_loadedRoom = Room,
			m_enabled = Room.m_enabled,
			m_theme = GetRoomTheme(ThemeName)
		};
	}

	/// <summary>
	///     Custom room from a SoftReference prefab with a <see cref="T:Jotunn.Configs.RoomConfig" /> attached. Using SoftReference system.<br />
	///     The prefab is not loaded until the DungeonGenerator needs it during generation.
	/// </summary>
	/// <param name="softReferencePrefab">A <see cref="T:SoftReferenceableAssets.SoftReference`1" /> to the room prefab registered in a SoftRef manifest.</param>
	/// <param name="fixReference">If true references for <see cref="T:Jotunn.Entities.Mock`1" /> objects get resolved at runtime by Jötunn.</param>
	/// <param name="roomConfig">The config for this custom room.</param>
	public CustomRoom(SoftReference<GameObject> softReferencePrefab, bool fixReference, RoomConfig roomConfig)
		: base(Assembly.GetCallingAssembly())
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		if (!softReferencePrefab.IsValid)
		{
			Logger.LogError("SoftReference invalid for room prefab: " + softReferencePrefab.Name);
			return;
		}
		AssetManager.Instance.ResolveMocksOnLoad<GameObject>(softReferencePrefab, DungeonManager.Instance.DungeonRoomContainer.transform, OnRoomResolve);
		Name = softReferencePrefab.Name;
		ThemeName = roomConfig.ThemeName;
		FixReference = fixReference;
		SoftReference = true;
		RoomData = new DungeonDB.RoomData
		{
			m_prefab = softReferencePrefab,
			m_loadedRoom = null,
			m_enabled = (roomConfig.Enabled ?? true),
			m_theme = GetRoomTheme(ThemeName)
		};
	}

	private void OnRoomResolve(GameObject gameObject)
	{
	}

	/// <summary>
	///     Helper method to determine if a prefab with a given name is a custom room created with Jötunn.
	/// </summary>
	/// <param name="prefabName">Name of the prefab to test.</param>
	/// <returns>true if the prefab is added as a custom item to the <see cref="T:Jotunn.Managers.DungeonManager" />.</returns>
	public static bool IsCustomRoom(string prefabName)
	{
		return DungeonManager.Instance.Rooms.ContainsKey(prefabName);
	}

	/// <summary>
	///     Helper method to determine if a given themeName matches any vanilla <see cref="T:Room.Theme" /> values.
	/// </summary>
	/// <param name="themeName">Name of the theme to test.</param>
	/// <returns>true if the themeName matches a built-in value, or false.</returns>
	public static bool IsVanillaTheme(string themeName)
	{
		Room.Theme result;
		return Enum.TryParse<Room.Theme>(themeName, ignoreCase: false, out result);
	}

	/// <summary>
	///     Helper method to get the <see cref="T:Room.Theme" /> value, if the given themeName matches any vanilla values.
	/// </summary>
	/// <param name="themeName">Name of the theme.</param>
	/// <returns>The <see cref="T:Room.Theme" /> value, or Room.Theme.None if no match is found.</returns>        
	public static Room.Theme GetRoomTheme(string themeName)
	{
		if (Enum.TryParse<Room.Theme>(themeName, ignoreCase: false, out var result))
		{
			return result;
		}
		return Room.Theme.None;
	}
}
