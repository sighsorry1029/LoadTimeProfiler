using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Jotunn.Entities;
using UnityEngine;

namespace Jotunn.Managers;

/// <summary>
///    Manager for handling all custom data added to the game related to creatures.
/// </summary>
public class CreatureManager : IManager
{
	private static class Patches
	{
		[HarmonyPatch(typeof(ObjectDB), "CopyOtherDB")]
		[HarmonyPrefix]
		private static void InvokeOnVanillaCreaturesAvailable()
		{
			Instance.InvokeOnVanillaCreaturesAvailable();
		}

		[HarmonyPatch(typeof(ZNetScene), "Awake")]
		[HarmonyPostfix]
		private static void FixReferences(ZNetScene __instance)
		{
			Instance.FixReferences(__instance);
		}

		[HarmonyPatch(typeof(SpawnSystem), "Awake")]
		[HarmonyPrefix]
		private static void AddSpawnListToSpawnSystem(SpawnSystem __instance)
		{
			Instance.AddSpawnListToSpawnSystem(__instance);
		}

		[HarmonyPatch(typeof(LevelEffects), "SetupLevelVisualization")]
		[HarmonyPostfix]
		private static void EnableCumulativeLevelEffects(LevelEffects __instance, int level)
		{
			Instance.EnableCumulativeLevelEffects(__instance, level);
		}
	}

	private static CreatureManager _instance;

	/// <summary>
	///     Unity "character" layer ID. 
	/// </summary>
	public static int CharacterLayer;

	/// <summary>
	///     Internal lists of all custom entities added
	/// </summary>
	internal readonly List<CustomCreature> Creatures = new List<CustomCreature>();

	/// <summary>
	///     Container for Jötunn's SpawnSystemList in the DontDestroyOnLoad scene.
	/// </summary>
	internal GameObject SpawnListContainer;

	/// <summary>
	///     Reference to the SpawnList component of the container.
	/// </summary>
	internal SpawnSystemList SpawnList;

	/// <summary>
	///     The singleton instance of this manager.
	/// </summary>
	public static CreatureManager Instance => _instance ?? (_instance = new CreatureManager());

	/// <summary>
	///     Event that gets fired after the vanilla creatures are in memory and available for cloning.
	///     Your code will execute every time before a new <see cref="T:ObjectDB" /> is copied (on every menu start).
	///     If you want to execute just once you will need to unregister from the event after execution.
	/// </summary>
	public static event Action OnVanillaCreaturesAvailable;

	/// <summary>
	///     Event that gets fired after registering all custom creatures to <see cref="T:ZNetScene" />.
	///     Your code will execute every time a new ZNetScene is created (on every game start).
	///     If you want to execute just once you will need to unregister from the event after execution.
	/// </summary>
	public static event Action OnCreaturesRegistered;

	/// <summary>
	///     Hide .ctor
	/// </summary>
	private CreatureManager()
	{
	}

	static CreatureManager()
	{
		CharacterLayer = LayerMask.NameToLayer("character");
		((IManager)Instance).Init();
	}

	/// <summary>
	///     Creates the spawner container and registers all hooks.
	/// </summary>
	void IManager.Init()
	{
		Main.LogInit("CreatureManager");
		SpawnListContainer = new GameObject("Creatures");
		SpawnListContainer.transform.parent = Main.RootObject.transform;
		SpawnListContainer.SetActive(value: false);
		SpawnList = SpawnListContainer.AddComponent<SpawnSystemList>();
		Main.Harmony.PatchAll(typeof(Patches));
	}

	/// <summary>
	///     Add a <see cref="T:Jotunn.Entities.CustomCreature" /> to the game.<br />
	///     Checks if the custom creature is valid and unique and adds it to the list of custom creatures.
	/// </summary>
	/// <param name="customCreature">The custom Creature to add.</param>
	/// <returns>true if the custom Creature was added to the manager.</returns>
	public bool AddCreature(CustomCreature customCreature)
	{
		if (!customCreature.IsValid())
		{
			Logger.LogWarning(customCreature.SourceMod, $"Custom creature '{customCreature}' is not valid");
			return false;
		}
		if (Creatures.Contains(customCreature))
		{
			Logger.LogWarning(customCreature.SourceMod, $"Custom creature '{customCreature}' already added");
			return false;
		}
		if (!PrefabManager.Instance.AddPrefab(customCreature.Prefab, customCreature.SourceMod))
		{
			return false;
		}
		if (customCreature.Prefab.layer != CharacterLayer)
		{
			customCreature.Prefab.layer = CharacterLayer;
			foreach (Transform item in customCreature.Prefab.transform)
			{
				item.gameObject.layer = CharacterLayer;
			}
		}
		customCreature.Prefab.transform.SetParent(SpawnListContainer.transform, worldPositionStays: false);
		Creatures.Add(customCreature);
		SpawnList.m_spawners.AddRange(customCreature.Spawns);
		return true;
	}

	/// <summary>
	///     Get a custom creature by its name.
	/// </summary>
	/// <param name="creatureName">Name of the custom creature to search.</param>
	/// <returns>The <see cref="T:Jotunn.Entities.CustomCreature" /> if found.</returns>
	public CustomCreature GetCreature(string creatureName)
	{
		return Creatures.FirstOrDefault((CustomCreature x) => x.Prefab.name.Equals(creatureName));
	}

	/// <summary>
	///     Get a custom or vanilla creature prefab by its name.
	/// </summary>
	/// <param name="creatureName">Name of the creature to search.</param>
	/// <returns>The prefab of the creature if found.</returns>
	public GameObject GetCreaturePrefab(string creatureName)
	{
		CustomCreature creature = GetCreature(creatureName);
		if (creature != null)
		{
			return creature.Prefab;
		}
		Character prefab = PrefabManager.Cache.GetPrefab<Character>(creatureName);
		if (prefab != null)
		{
			return prefab.gameObject;
		}
		return null;
	}

	/// <summary>
	///     Remove a custom creature by its name.
	/// </summary>
	/// <param name="creatureName">Name of the creature to remove.</param>
	public void RemoveCreature(string creatureName)
	{
		CustomCreature creature = GetCreature(creatureName);
		if (creature == null)
		{
			Logger.LogWarning("Could not remove Creature " + creatureName + ": Not found");
		}
		else
		{
			RemoveCreature(creature);
		}
	}

	/// <summary>
	///     Remove a custom creature by its ref. Removes the custom recipe, too.
	/// </summary>
	/// <param name="creature"><see cref="T:Jotunn.Entities.CustomCreature" /> to remove.</param>
	public void RemoveCreature(CustomCreature creature)
	{
		Creatures.Remove(creature);
		if ((bool)creature.Prefab)
		{
			PrefabManager.Instance.RemovePrefab(creature.Prefab.name);
		}
	}

	/// <summary>
	///     Safely invoke the <see cref="E:Jotunn.Managers.CreatureManager.OnVanillaCreaturesAvailable" /> event
	/// </summary>
	private void InvokeOnVanillaCreaturesAvailable()
	{
		CreatureManager.OnVanillaCreaturesAvailable?.SafeInvoke();
	}

	/// <summary>
	///     Resolve mocks of all custom creatures if necessary.
	/// </summary>
	private void FixReferences(ZNetScene self)
	{
		if (Creatures.Any())
		{
			Logger.LogInfo($"Adding {Creatures.Count} custom creatures");
			List<CustomCreature> list = new List<CustomCreature>();
			foreach (CustomCreature creature in Creatures)
			{
				try
				{
					creature.Prefab.GetComponent<CapsuleCollider>()?.FixReferences();
					if (creature.FixReference | creature.FixConfig)
					{
						creature.Prefab.FixReferences(creature.FixReference);
						creature.FixReference = false;
						creature.FixConfig = false;
					}
					Logger.LogDebug($"Added creature {creature} | Spawns: {creature.Spawns.Count}");
				}
				catch (Exception arg)
				{
					Logger.LogWarning(creature?.SourceMod, $"Error caught while adding creature {creature}: {arg}");
					list.Add(creature);
				}
			}
			foreach (CustomCreature item in list)
			{
				if ((bool)item.Prefab)
				{
					PrefabManager.Instance.DestroyPrefab(item.Prefab.name);
				}
				RemoveCreature(item);
			}
		}
		InvokeOnCreaturesRegistered();
	}

	/// <summary>
	///     Safely invoke the <see cref="E:Jotunn.Managers.CreatureManager.OnCreaturesRegistered" /> event.
	/// </summary>
	private void InvokeOnCreaturesRegistered()
	{
		CreatureManager.OnCreaturesRegistered?.SafeInvoke();
	}

	/// <summary>
	///     Add the internal <see cref="T:SpawnSystemList" /> to the awoken spawner if not already added.
	/// </summary>
	private void AddSpawnListToSpawnSystem(SpawnSystem self)
	{
		if (!self.m_spawnLists.Contains(SpawnList))
		{
			self.m_spawnLists.Add(SpawnList);
		}
	}

	/// <summary>
	///     Enable cumulative level effects for custom creatures requesting it. Thx ASP for the code.
	/// </summary>
	private void EnableCumulativeLevelEffects(LevelEffects self, int level)
	{
		if (level <= 2 || !Creatures.Any((CustomCreature x) => x.Prefab.name == self.m_character.m_nview.GetPrefabName() && x.UseCumulativeLevelEffects))
		{
			return;
		}
		for (int num = level - 2; num >= 0; num--)
		{
			if (num < self.m_levelSetups.Count)
			{
				LevelEffects.LevelSetup levelSetup = self.m_levelSetups[num];
				if ((bool)levelSetup.m_enableObject)
				{
					Logger.LogDebug($"Enabling {level - 1} star equipment: '{levelSetup.m_enableObject.name}'");
					levelSetup.m_enableObject.SetActive(value: true);
				}
			}
		}
	}
}
