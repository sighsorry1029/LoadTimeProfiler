using System.Collections.Generic;
using System.Linq;
using BepInEx.Configuration;

namespace Jotunn.Configs;

/// <summary>
///     Helper to get existing crafting station names
/// </summary>
public static class CraftingStations
{
	private static readonly Dictionary<string, string> NamesMap = new Dictionary<string, string>
	{
		{ "None", None },
		{ "Workbench", Workbench },
		{ "Forge", Forge },
		{ "Stonecutter", Stonecutter },
		{ "Cauldron", Cauldron },
		{ "ArtisanTable", ArtisanTable },
		{ "BlackForge", BlackForge },
		{ "GaldrTable", GaldrTable },
		{ "MeadKetill", MeadKetill },
		{ "FoodPreparationTable", FoodPreparationTable }
	};

	private static readonly AcceptableValueList<string> AcceptableValues = new AcceptableValueList<string>(NamesMap.Keys.ToArray());

	/// <summary>
	///     No crafting station
	/// </summary>
	public static string None => string.Empty;

	/// <summary>
	///    Workbench crafting station
	/// </summary>
	public static string Workbench => "piece_workbench";

	/// <summary>
	///    Forge crafting station
	/// </summary>
	public static string Forge => "forge";

	/// <summary>
	///     Stonecutter crafting station
	/// </summary>
	public static string Stonecutter => "piece_stonecutter";

	/// <summary>
	///     Cauldron crafting station
	/// </summary>
	public static string Cauldron => "piece_cauldron";

	/// <summary>
	///     Artisan table crafting station
	/// </summary>
	public static string ArtisanTable => "piece_artisanstation";

	/// <summary>
	///     Black forge crafting station
	/// </summary>
	public static string BlackForge => "blackforge";

	/// <summary>
	///     Galdr table crafting station
	/// </summary>
	public static string GaldrTable => "piece_magetable";

	/// <summary>
	///     Mead Ketill crafting station
	/// </summary>
	public static string MeadKetill => "piece_MeadCauldron";

	/// <summary>
	///     Food Preparation Table crafting station
	/// </summary>
	public static string FoodPreparationTable => "piece_preptable";

	/// <summary>
	///     Gets the human readable name to internal names map
	/// </summary>
	/// <returns></returns>
	public static Dictionary<string, string> GetNames()
	{
		return NamesMap;
	}

	/// <summary>
	///     Get a <see cref="T:BepInEx.Configuration.AcceptableValueList`1" /> of all crafting station names.
	///     This can be used to create a <see cref="T:BepInEx.Configuration.ConfigEntry`1" /> where only valid crafting stations can be selected.<br /><br />
	///     Example:
	///     <code>
	///         var stationConfig = Config.Bind("Section", "Key", nameof(CraftingStations.Workbench), new ConfigDescription("Description", CraftingStations.GetAcceptableValueList()));
	///     </code>
	/// </summary>
	/// <returns></returns>
	public static AcceptableValueList<string> GetAcceptableValueList()
	{
		return AcceptableValues;
	}

	/// <summary>
	///     Get the internal name for a crafting station from its human readable name.
	/// </summary>
	/// <param name="craftingStation"></param>
	/// <returns>
	///     The matched internal name.
	///     If the craftingStation parameter is null or empty, <see cref="P:Jotunn.Configs.CraftingStations.None" /> is returned.
	///     Otherwise the unchanged craftingStation parameter is returned.
	/// </returns>
	public static string GetInternalName(string craftingStation)
	{
		if (string.IsNullOrEmpty(craftingStation))
		{
			return None;
		}
		if (NamesMap.TryGetValue(craftingStation, out var value))
		{
			return value;
		}
		return craftingStation;
	}
}
