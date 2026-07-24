using System.Collections.Generic;
using Jotunn.Entities;
using SimpleJson;

namespace Jotunn.Configs;

/// <summary>
///     Used to add new ItemConversions to the CookingStation
/// </summary>
public class CookingConversionConfig : ConversionConfig
{
	private string station = CookingStations.CookingStation;

	/// <summary>
	///     The name of the station prefab this conversion is added to. Defaults to <see cref="P:Jotunn.Configs.CookingStations.CookingStation" />.
	/// </summary>
	public override string Station
	{
		get
		{
			return station;
		}
		set
		{
			station = CookingStations.GetInternalName(value);
		}
	}

	/// <summary>
	///     Amount of time it takes to perform the conversion. Defaults to 10f.
	/// </summary>
	public float CookTime { get; set; } = 10f;

	/// <summary>
	///     Turns the CookingConversionConfig into a Valheim CookingStation.ItemConversion item.
	/// </summary>
	/// <returns>The Valheim CookingStation.ItemConversion</returns>
	public CookingStation.ItemConversion GetItemConversion()
	{
		return new CookingStation.ItemConversion
		{
			m_cookTime = CookTime,
			m_from = Mock<ItemDrop>.Create(FromItem),
			m_to = Mock<ItemDrop>.Create(base.ToItem)
		};
	}

	/// <summary>
	///     Loads a single CookingConversionConfig from a JSON string
	/// </summary>
	/// <param name="json">JSON text</param>
	/// <returns>Loaded CookingConversionConfig</returns>
	public static CookingConversionConfig FromJson(string json)
	{
		return global::SimpleJson.SimpleJson.DeserializeObject<CookingConversionConfig>(json);
	}

	/// <summary>
	///     Loads a list of CookingConversionConfigs from a JSON string
	/// </summary>
	/// <param name="json">JSON text</param>
	/// <returns>Loaded list of CookingConversionConfigs</returns>
	public static List<CookingConversionConfig> ListFromJson(string json)
	{
		return global::SimpleJson.SimpleJson.DeserializeObject<List<CookingConversionConfig>>(json);
	}
}
