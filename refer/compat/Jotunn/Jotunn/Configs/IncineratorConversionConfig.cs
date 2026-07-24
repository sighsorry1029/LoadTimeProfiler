using System.Collections.Generic;
using System.Linq;
using Jotunn.Entities;
using SimpleJson;

namespace Jotunn.Configs;

/// <summary>
///     Used to add new IncineratorConversions to the Incinerator
/// </summary>
public class IncineratorConversionConfig : ConversionConfig
{
	private string station = Incinerators.Incinerator;

	/// <summary>
	///     The name of the station prefab this conversion is added to. Defaults to <see cref="P:Jotunn.Configs.Incinerators.Incinerator" />.
	/// </summary>
	public override string Station
	{
		get
		{
			return station;
		}
		set
		{
			station = Incinerators.GetInternalName(value);
		}
	}

	/// <summary>
	///     List of requirements for this conversion.
	/// </summary>
	public List<IncineratorRequirementConfig> Requirements { get; set; } = new List<IncineratorRequirementConfig>();

	/// <summary>
	///     The amount of items one conversion yields. Defaults to 1.
	/// </summary>
	public int ProducedItems { get; set; } = 1;

	/// <summary>
	///     Priority of this conversion.
	///     Lower prioritized conversions will be incinerated first when mulitple conversions requirements are met.
	/// </summary>
	public int Priority { get; set; }

	/// <summary>
	///     True: Requires only one of the list of ingredients to be able to produce the result.
	///     False: All of the ingredients are required.
	///     Defaults to false.
	/// </summary>
	public bool RequireOnlyOneIngredient { get; set; }

	/// <summary>
	///     Turns the IncineratorConversionConfig into a Valheim Incinerator.IncineratorConversion item.
	/// </summary>
	/// <returns>The Valheim Incinerator.IncineratorConversion</returns>
	public Incinerator.IncineratorConversion GetIncineratorConversion()
	{
		FromItem = ((Requirements.Count > 0) ? string.Empty : null);
		return new Incinerator.IncineratorConversion
		{
			m_requirements = Requirements.Select((IncineratorRequirementConfig x) => x.GetRequirement()).ToList(),
			m_result = Mock<ItemDrop>.Create(base.ToItem),
			m_resultAmount = ProducedItems,
			m_priority = Priority,
			m_requireOnlyOneIngredient = RequireOnlyOneIngredient
		};
	}

	/// <summary>
	///     Loads a single IncineratorConversionConfig from a JSON string
	/// </summary>
	/// <param name="json">JSON text</param>
	/// <returns>Loaded IncineratorConversionConfig</returns>
	public static IncineratorConversionConfig FromJson(string json)
	{
		return global::SimpleJson.SimpleJson.DeserializeObject<IncineratorConversionConfig>(json);
	}

	/// <summary>
	///     Loads a list of IncineratorConversionConfigs from a JSON string
	/// </summary>
	/// <param name="json">JSON text</param>
	/// <returns>Loaded list of IncineratorConversionConfigs</returns>
	public static List<IncineratorConversionConfig> ListFromJson(string json)
	{
		return global::SimpleJson.SimpleJson.DeserializeObject<List<IncineratorConversionConfig>>(json);
	}
}
