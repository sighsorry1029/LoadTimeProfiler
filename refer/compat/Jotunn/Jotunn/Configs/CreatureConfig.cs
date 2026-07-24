using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Jotunn.Entities;
using UnityEngine;

namespace Jotunn.Configs;

/// <summary>
///     Configuration class for adding custom creature spawns.<br />
///     Use this in a constructor of <see cref="T:Jotunn.Entities.CustomCreature" /> 
/// </summary>
public class CreatureConfig
{
	/// <summary>
	///     Array of <see cref="T:Jotunn.Configs.DropConfig">DropConfigs</see> to use for this creature's <see cref="T:CharacterDrop" />.<br />
	///     A <see cref="T:CharacterDrop" /> component will automatically be added if not present.<br />
	///     The drop table of an existing component will be replaced.
	/// </summary>
	public DropConfig[] DropConfigs = Array.Empty<DropConfig>();

	/// <summary>
	///     Array of <see cref="T:Jotunn.Configs.SpawnConfig">SpawnConfigs</see> used for world spawns of your custom creature.<br />
	///     Leave empty if you don't want your creature to spawn in the world automatically.<br />
	/// </summary>
	public SpawnConfig[] SpawnConfigs = Array.Empty<SpawnConfig>();

	/// <summary>
	///     String array of items this creature can consume to use in the <see cref="T:MonsterAI" /> component.<br />
	///     Jötunn will try to resolve all strings to <see cref="T:ItemDrop">ItemDrops</see> at runtime.<br />
	///     An existing consumeItems table will be replaced.
	/// </summary>
	public string[] Consumables = Array.Empty<string>();

	/// <summary>
	///     The unique name for your custom creature. May be tokenized.
	/// </summary>
	public string Name { get; set; } = string.Empty;

	/// <summary>
	///     Group tag of this creature.<br />
	///     Creatures in the same group don't attack each other, regardless of faction.
	/// </summary>
	public string Group { get; set; } = string.Empty;

	/// <summary>
	///     <see cref="T:Character.Faction" /> of this creature.
	/// </summary>
	public Character.Faction? Faction { get; set; }

	/// <summary>
	///     If set to true, <see cref="T:LevelEffects" /> stack the "EnableObject" action for all levels
	///     instead of only activating the GameObject of the highest level matched.
	/// </summary>
	public bool UseCumulativeLevelEffects { get; set; }

	/// <summary>
	///     Apply this config's values to a creature GameObject.
	/// </summary>
	/// <param name="prefab">Prefab to apply this config to</param>
	public void Apply(GameObject prefab)
	{
		if (!prefab.TryGetComponent<Character>(out var component))
		{
			Logger.LogError("GameObject " + prefab.name + " has no Character component attached");
			return;
		}
		if (!string.IsNullOrEmpty(Name))
		{
			component.m_name = Name;
		}
		if (string.IsNullOrEmpty(component.m_name))
		{
			component.m_name = prefab.name;
		}
		if (!string.IsNullOrEmpty(Group))
		{
			component.m_group = Group;
		}
		if (Faction.HasValue)
		{
			component.m_faction = Faction.Value;
		}
		List<CharacterDrop.Drop> list = GetDrops().ToList();
		if (list.Any())
		{
			CharacterDrop orAddComponent = prefab.GetOrAddComponent<CharacterDrop>();
			orAddComponent.m_drops = list;
		}
		List<ItemDrop> list2 = GetConsumeItems().ToList();
		if (list2.Any() && prefab.TryGetComponent<MonsterAI>(out var component2))
		{
			component2.m_consumeItems = list2;
		}
	}

	/// <summary>
	///     Converts the <see cref="T:Jotunn.Configs.DropConfig">DropConfigs</see> to Valheim style <see cref="T:CharacterDrop.Drop" /> array.
	/// </summary>
	/// <returns>The Valheim <see cref="T:CharacterDrop.Drop" /> array</returns>
	public CharacterDrop.Drop[] GetDrops()
	{
		CharacterDrop.Drop[] array = new CharacterDrop.Drop[DropConfigs.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = DropConfigs[i].GetDrop();
		}
		return array;
	}

	/// <summary>
	///     Converts the <see cref="T:Jotunn.Configs.SpawnConfig">SpawnConfigs</see> to Valheim style <see cref="T:SpawnSystem.SpawnData" /> array.
	/// </summary>
	/// <returns>The Valheim <see cref="T:SpawnSystem.SpawnData" /> array</returns>
	public SpawnSystem.SpawnData[] GetSpawns()
	{
		SpawnSystem.SpawnData[] array = new SpawnSystem.SpawnData[SpawnConfigs.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = SpawnConfigs[i].GetSpawnData();
		}
		return array;
	}

	/// <summary>
	///     Creates an array of <see cref="T:ItemDrop" /> mocks for the consumeItem list of the creature.
	/// </summary>
	/// <returns>An array of <see cref="T:ItemDrop" /> mocks</returns>
	public ItemDrop[] GetConsumeItems()
	{
		ItemDrop[] array = new ItemDrop[Consumables.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = Mock<ItemDrop>.Create(Consumables[i]);
		}
		return array;
	}

	/// <summary>
	///     Appends a new <see cref="T:Jotunn.Configs.DropConfig" /> to the array of existing ones.
	/// </summary>
	/// <param name="dropConfig"></param>
	public void AddDropConfig(DropConfig dropConfig)
	{
		DropConfigs = DropConfigs.AddToArray(dropConfig);
	}

	/// <summary>
	///     Appends a new <see cref="T:Jotunn.Configs.SpawnConfig" /> to the array of existing ones.
	/// </summary>
	/// <param name="spawnConfig"></param>
	public void AddSpawnConfig(SpawnConfig spawnConfig)
	{
		SpawnConfigs = SpawnConfigs.AddToArray(spawnConfig);
	}

	/// <summary>
	///     Appends a new consumable to the array of existing ones.
	/// </summary>
	/// <param name="consumable"></param>
	public void AddConsumable(string consumable)
	{
		Consumables = Consumables.AddToArray(consumable);
	}
}
