using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Jotunn.Configs;
using Jotunn.Managers;
using Jotunn.Utils;
using UnityEngine;

namespace Jotunn.Entities;

/// <summary>
///     Main interface for adding custom creatures to the game.<br />
///     All custom creatures have to be wrapped inside this class to add it to Jötunns <see cref="T:Jotunn.Managers.CreatureManager" />.
/// </summary>
public class CustomCreature : CustomEntity
{
	private string fallbackCreatureName;

	/// <summary>
	///     The creature prefab.
	/// </summary>
	public GameObject Prefab { get; }

	/// <summary>
	///     Associated list of <see cref="T:SpawnSystem.SpawnData" /> of the creature.
	/// </summary>
	public List<SpawnSystem.SpawnData> Spawns { get; } = new List<SpawnSystem.SpawnData>();

	/// <summary>
	///     Indicator if references from <see cref="T:Jotunn.Entities.Mock`1">mocks</see> will be replaced at runtime.
	/// </summary>
	public bool FixReference { get; set; }

	/// <summary>
	///     Indicator if references from configs should get replaced
	/// </summary>
	internal bool FixConfig { get; set; }

	/// <summary>
	///     Internal flag for the cumulative level effects hook. Value is set in the config.
	/// </summary>
	internal bool UseCumulativeLevelEffects { get; set; }

	private string CreatureName
	{
		get
		{
			if (!Prefab)
			{
				return fallbackCreatureName;
			}
			return Prefab.name;
		}
	}

	/// <summary>
	///     Custom creature from a prefab.
	/// </summary>
	/// <param name="creaturePrefab">The prefab of this custom creature.</param>
	/// <param name="fixReference">If true references for <see cref="T:Jotunn.Entities.Mock`1" /> objects get resolved at runtime by Jötunn.</param>
	public CustomCreature(GameObject creaturePrefab, bool fixReference)
		: base(Assembly.GetCallingAssembly())
	{
		Prefab = creaturePrefab;
		FixReference = fixReference;
	}

	/// <summary>
	///     Custom creature from a prefab with a <see cref="T:Jotunn.Configs.CreatureConfig" /> attached.
	/// </summary>
	/// <param name="creaturePrefab">The prefab of this custom creature.</param>
	/// <param name="fixReference">If true references for <see cref="T:Jotunn.Entities.Mock`1" /> objects get resolved at runtime by Jötunn.</param>
	/// <param name="creatureConfig">The <see cref="T:Jotunn.Configs.CreatureConfig" /> for this custom creature.</param>
	public CustomCreature(GameObject creaturePrefab, bool fixReference, CreatureConfig creatureConfig)
		: base(Assembly.GetCallingAssembly())
	{
		Prefab = creaturePrefab;
		ApplyCreatureConfig(creatureConfig);
		FixReference = fixReference;
	}

	/// <summary>
	///     Custom creature created as a copy of a vanilla Valheim creature.<br />
	///     SpawnData is not cloned, you will have to add <see cref="T:Jotunn.Configs.SpawnConfig">SpawnConfigs</see>
	///     to your <see cref="T:Jotunn.Configs.CreatureConfig" /> if you want to spawn the cloned creature automatically.
	/// </summary>
	/// <param name="name">The new name of the creature after cloning.</param>
	/// <param name="basePrefabName">The name of the base prefab the custom creature is cloned from.</param>
	/// <param name="creatureConfig">The <see cref="T:Jotunn.Configs.CreatureConfig" /> for this custom creature.</param>
	public CustomCreature(string name, string basePrefabName, CreatureConfig creatureConfig)
		: base(Assembly.GetCallingAssembly())
	{
		GameObject creaturePrefab = CreatureManager.Instance.GetCreaturePrefab(basePrefabName);
		if ((bool)creaturePrefab)
		{
			Prefab = PrefabManager.Instance.CreateClonedPrefab(name, creaturePrefab);
			creatureConfig.Name = name;
			ApplyCreatureConfig(creatureConfig);
		}
	}

	/// <summary>
	///     Custom creature from a prefab loaded from an <see cref="T:UnityEngine.AssetBundle" /> with a <see cref="T:Jotunn.Configs.PieceConfig" /> attached.<br />
	///     The members and references from the <see cref="T:Jotunn.Configs.PieceConfig" /> will be referenced by Jötunn at runtime.
	/// </summary>
	/// <param name="assetBundle">A preloaded <see cref="T:UnityEngine.AssetBundle" /></param>
	/// <param name="assetName">Name of the prefab in the bundle.</param>
	/// <param name="fixReference">If true references for <see cref="T:Jotunn.Entities.Mock`1" /> objects get resolved at runtime by Jötunn.</param>
	/// <param name="creatureConfig">The <see cref="T:Jotunn.Configs.CreatureConfig" /> for this custom creature.</param>
	public CustomCreature(AssetBundle assetBundle, string assetName, bool fixReference, CreatureConfig creatureConfig)
		: base(Assembly.GetCallingAssembly())
	{
		fallbackCreatureName = assetName;
		if (AssetUtils.TryLoadPrefab(base.SourceMod, assetBundle, assetName, out var prefab))
		{
			Prefab = prefab;
			ApplyCreatureConfig(creatureConfig);
			FixReference = fixReference;
		}
	}

	/// <summary>
	///     Checks if a custom creature is valid (i.e. has a prefab and all required components).
	/// </summary>
	/// <returns>true if all criteria is met</returns>
	public bool IsValid()
	{
		bool result = true;
		if (!Prefab)
		{
			Logger.LogError(base.SourceMod, $"CustomCreature '{this}' has no prefab");
			result = false;
		}
		Type[] array = new Type[5]
		{
			typeof(Character),
			typeof(BaseAI),
			typeof(CapsuleCollider),
			typeof(Rigidbody),
			typeof(ZSyncAnimation)
		};
		Type[] array2 = array;
		foreach (Type type in array2)
		{
			if ((bool)Prefab && !Prefab.GetComponent(type))
			{
				Logger.LogError(base.SourceMod, $"CustomCreature '{this}' has no {type} component");
				result = false;
			}
		}
		if ((bool)Prefab && !(UnityEngine.Object)(object)Prefab.GetComponentInChildren<Animator>())
		{
			Logger.LogError(base.SourceMod, $"CustomCreature '{this}' has no Animator component");
			result = false;
		}
		if ((bool)Prefab && !Prefab.GetComponentInChildren<CharacterAnimEvent>())
		{
			Logger.LogError(base.SourceMod, $"CustomCreature '{this}' has no CharacterAnimEvent component");
			result = false;
		}
		return result;
	}

	/// <summary>
	///     Helper method to determine if a prefab with a given name is a custom creature created with Jötunn.
	/// </summary>
	/// <param name="prefabName">Name of the prefab to test.</param>
	/// <returns>true if the prefab is added as a custom creature to the <see cref="T:Jotunn.Managers.CreatureManager" />.</returns>
	public static bool IsCustomCreature(string prefabName)
	{
		return CreatureManager.Instance.Creatures.Any((CustomCreature x) => x.Prefab.name == prefabName);
	}

	/// <inheritdoc />
	public override bool Equals(object obj)
	{
		return obj.GetHashCode() == GetHashCode();
	}

	/// <inheritdoc />
	public override int GetHashCode()
	{
		return StringExtensionMethods.GetStableHashCode(CreatureName);
	}

	/// <inheritdoc />
	public override string ToString()
	{
		return CreatureName;
	}

	private void ApplyCreatureConfig(CreatureConfig creatureConfig)
	{
		creatureConfig.Apply(Prefab);
		FixConfig = creatureConfig.DropConfigs.Any() || creatureConfig.Consumables.Any();
		UseCumulativeLevelEffects = creatureConfig.UseCumulativeLevelEffects;
		Spawns.AddRange(creatureConfig.GetSpawns());
		foreach (SpawnSystem.SpawnData spawn in Spawns)
		{
			spawn.m_prefab = Prefab;
		}
	}
}
