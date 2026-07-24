using System.Collections.Generic;
using Jotunn.Entities;
using SimpleJson;

namespace Jotunn.Configs;

/// <summary>
///     Used to add new ItemConversions to the Fermenter
/// </summary>
public class FermenterConversionConfig : ConversionConfig
{
	private string station = Fermenters.Fermenter;

	/// <summary>
	///     The name of the station prefab this conversion is added to. Defaults to <see cref="P:Jotunn.Configs.Fermenters.Fermenter" />.
	/// </summary>
	public override string Station
	{
		get
		{
			return station;
		}
		set
		{
			station = Fermenters.GetInternalName(value);
		}
	}

	/// <summary>
	///     The amount of items one conversion yields. Defaults to 4.
	/// </summary>
	public int ProducedItems { get; set; } = 4;

	/// <summary>
	///     Turns the FermenterConversionConfig into a Valheim Fermenter.ItemConversion item.
	/// </summary>
	/// <returns>The Valheim Fermenter.ItemConversion</returns>
	public Fermenter.ItemConversion GetItemConversion()
	{
		return new Fermenter.ItemConversion
		{
			m_producedItems = ProducedItems,
			m_from = Mock<ItemDrop>.Create(FromItem),
			m_to = Mock<ItemDrop>.Create(base.ToItem)
		};
	}

	/// <summary>
	///     Loads a single FermenterConversionConfig from a JSON string
	/// </summary>
	/// <param name="json">JSON text</param>
	/// <returns>Loaded FermenterConversionConfig</returns>
	public static FermenterConversionConfig FromJson(string json)
	{
		return global::SimpleJson.SimpleJson.DeserializeObject<FermenterConversionConfig>(json);
	}

	/// <summary>
	///     Loads a list of FermenterConversionConfigs from a JSON string
	/// </summary>
	/// <param name="json">JSON text</param>
	/// <returns>Loaded list of FermenterConversionConfigs</returns>
	public static List<FermenterConversionConfig> ListFromJson(string json)
	{
		return global::SimpleJson.SimpleJson.DeserializeObject<List<FermenterConversionConfig>>(json);
	}
}
