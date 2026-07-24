using System;
using System.Collections.Generic;
using HarmonyLib;
using Jotunn.Entities;
using Jotunn.Managers;
using SimpleJson;
using UnityEngine;

namespace Jotunn.Configs;

/// <summary>
///     Configuration class for adding custom pieces.<br />
///     Use this in a constructor of <see cref="T:Jotunn.Entities.CustomPiece" /> and 
///     Jötunn resolves the references to the game objects at runtime.
/// </summary>
public class PieceConfig
{
	private string pieceTable = string.Empty;

	private string category = string.Empty;

	private string craftingStation = string.Empty;

	private string extendStation = string.Empty;

	/// <summary>
	///     The name for your piece. May be tokenized.
	/// </summary>
	public string Name { get; set; } = string.Empty;

	/// <summary>
	///     The description of your piece. May be tokenized.
	/// </summary>
	public string Description { get; set; } = string.Empty;

	/// <summary>
	///     Whether this piece is buildable or not. Defaults to <c>true</c>.
	/// </summary>
	public bool Enabled { get; set; } = true;

	/// <summary>
	///     Can this piece be built in dungeons? Defaults to <c>false</c>.
	/// </summary>
	public bool AllowedInDungeons { get; set; }

	/// <summary>
	///     The name of the piece table where this piece will be added.
	/// </summary>
	public string PieceTable
	{
		get
		{
			return pieceTable;
		}
		set
		{
			pieceTable = PieceTables.GetInternalName(value);
		}
	}

	/// <summary>
	///     The name of the category this piece will appear on. If categories are disabled on the 
	///     target <see cref="T:PieceTable" />, this setting will be ignored.<br />
	///     If categories are enabled but the given category can't be found, a new 
	///     <see cref="T:Piece.PieceCategory" /> will be added to the table.
	/// </summary>
	public string Category
	{
		get
		{
			return category;
		}
		set
		{
			category = PieceCategories.GetInternalName(value);
		}
	}

	/// <summary>
	///     The name of the crafting station prefab which needs to be in close proximity to build this piece.
	/// </summary>
	public string CraftingStation
	{
		get
		{
			return craftingStation;
		}
		set
		{
			craftingStation = CraftingStations.GetInternalName(value);
		}
	}

	/// <summary>
	///     The name of the crafting station prefab to which this piece will be an upgrade to.
	/// </summary>
	public string ExtendStation
	{
		get
		{
			return extendStation;
		}
		set
		{
			extendStation = CraftingStations.GetInternalName(value);
		}
	}

	/// <summary>
	///     Icon which is displayed in the crafting GUI.
	/// </summary>
	public Sprite Icon { get; set; }

	/// <summary>
	///     Array of <see cref="T:Jotunn.Configs.RequirementConfig" />s for all crafting materials it takes to craft the recipe.
	/// </summary>
	public RequirementConfig[] Requirements { get; set; } = Array.Empty<RequirementConfig>();

	/// <summary>
	///     Apply this configs values to a piece GameObject.
	/// </summary>
	/// <param name="prefab"></param>
	public void Apply(GameObject prefab)
	{
		Piece component = prefab.GetComponent<Piece>();
		if (component == null)
		{
			Logger.LogWarning("GameObject has no Piece attached");
			return;
		}
		component.m_enabled = Enabled;
		component.m_allowedInDungeons = AllowedInDungeons;
		if (!string.IsNullOrEmpty(Name))
		{
			component.m_name = Name;
		}
		if (!string.IsNullOrEmpty(Description))
		{
			component.m_description = Description;
		}
		if (Icon != null)
		{
			component.m_icon = Icon;
		}
		if (Requirements.Length != 0)
		{
			component.m_resources = GetRequirements();
		}
		if (!string.IsNullOrEmpty(CraftingStation))
		{
			component.m_craftingStation = Mock<global::CraftingStation>.Create(CraftingStation);
		}
		if (!string.IsNullOrEmpty(ExtendStation))
		{
			StationExtension orAddComponent = prefab.GetOrAddComponent<StationExtension>();
			orAddComponent.m_craftingStation = Mock<global::CraftingStation>.Create(ExtendStation);
		}
		if (!string.IsNullOrEmpty(Category))
		{
			component.m_category = PieceManager.Instance.AddPieceCategory(Category);
		}
	}

	/// <summary>
	///     Converts the <see cref="T:Jotunn.Configs.RequirementConfig">RequirementConfigs</see> to Valheim style <see cref="T:Piece.Requirement" /> array.
	/// </summary>
	/// <returns>The Valheim <see cref="T:Piece.Requirement" /> array</returns>
	public Piece.Requirement[] GetRequirements()
	{
		List<Piece.Requirement> list = new List<Piece.Requirement>();
		RequirementConfig[] requirements = Requirements;
		foreach (RequirementConfig requirementConfig in requirements)
		{
			if (requirementConfig != null && requirementConfig.IsValid())
			{
				list.Add(requirementConfig.GetRequirement());
			}
		}
		return list.ToArray();
	}

	/// <summary>
	///     Loads a single PieceConfig from a JSON string
	/// </summary>
	/// <param name="json">JSON text</param>
	/// <returns>Loaded PieceConfig</returns>
	public static PieceConfig FromJson(string json)
	{
		return global::SimpleJson.SimpleJson.DeserializeObject<PieceConfig>(json);
	}

	/// <summary>
	///     Loads a list of PieceConfigs from a JSON string
	/// </summary>
	/// <param name="json">JSON text</param>
	/// <returns>Loaded list of PieceConfigs</returns>
	public static List<PieceConfig> ListFromJson(string json)
	{
		return global::SimpleJson.SimpleJson.DeserializeObject<List<PieceConfig>>(json);
	}

	/// <summary>
	///     Appends a new <see cref="T:Jotunn.Configs.RequirementConfig" /> to the array of existing ones.<br />
	///     If the requirement is null or is not valid (has not item name or amount set) nothing will be added.
	/// </summary>
	/// <param name="requirementConfig"></param>
	public void AddRequirement(RequirementConfig requirementConfig)
	{
		if (requirementConfig != null && requirementConfig.IsValid())
		{
			Requirements = Requirements.AddToArray(requirementConfig);
		}
	}

	/// <summary>
	///     Appends a new <see cref="T:Jotunn.Configs.RequirementConfig" /> to the array of existing ones.<br />
	///     If the item name is null or empty or the amount is less than 1 nothing will be added.
	/// </summary>
	/// <param name="item">The internal item prefab id, see https://valheim-modding.github.io/Jotunn/data/objects/item-list.html or the Valheim Wiki</param>
	/// <param name="amount">The amount of items needed to place this piece</param>
	/// <param name="recover">Whether the item is dropped after deconstructing a piece</param>
	public void AddRequirement(string item, int amount, bool recover = true)
	{
		AddRequirement(new RequirementConfig(item, amount, 0, recover));
	}
}
