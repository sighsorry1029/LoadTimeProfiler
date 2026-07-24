using System;
using System.Collections.Generic;
using System.Linq;
using BepInEx;
using Jotunn.Entities;
using Jotunn.Managers;

namespace Jotunn.Utils;

/// <summary>
///     Utility class to query metadata about loaded Jötunn mods and their added content
/// </summary>
public static class ModRegistry
{
	/// <summary>
	///     Model class holding metadata of Jötunn mods.
	/// </summary>
	public class ModInfo
	{
		/// <summary>
		///     The mod GUID
		/// </summary>
		public string GUID { get; internal set; }

		/// <summary>
		///     Human readable name
		/// </summary>
		public string Name { get; internal set; }

		/// <summary>
		///     Current version
		/// </summary>
		public Version Version { get; internal set; }

		/// <summary>
		///     Custom prefabs added by that mod
		/// </summary>
		public IEnumerable<CustomPrefab> Prefabs => GetPrefabs(GUID);

		/// <summary>
		///     Custom items added by that mod
		/// </summary>
		public IEnumerable<CustomItem> Items => GetItems(GUID);

		/// <summary>
		///     Custom recipes added by that mod
		/// </summary>
		public IEnumerable<CustomRecipe> Recipes => GetRecipes(GUID);

		/// <summary>
		///     Custom item conversions added by that mod
		/// </summary>
		public IEnumerable<CustomItemConversion> ItemConversions => GetItemConversions(GUID);

		/// <summary>
		///     Custom status effects added by that mod
		/// </summary>
		public IEnumerable<CustomStatusEffect> StatusEffects => GetStatusEffects(GUID);

		/// <summary>
		///     Custom piece tables added by that mod
		/// </summary>
		public IEnumerable<CustomPieceTable> PieceTables => GetPieceTables(GUID);

		/// <summary>
		///     Custom pieces added by that mod
		/// </summary>
		public IEnumerable<CustomPiece> Pieces => GetPieces(GUID);

		/// <summary>
		///     Custom locations added by that mod
		/// </summary>
		public IEnumerable<CustomLocation> Locations => GetLocations(GUID);

		/// <summary>
		///     Custom Vegetation added by that mod
		/// </summary>
		public IEnumerable<CustomVegetation> Vegetation => GetVegetation(GUID);

		/// <summary>
		///     Custom Clutter added by that mod
		/// </summary>
		public IEnumerable<CustomClutter> Clutter => GetClutter(GUID);

		/// <summary>
		///     Custom Creatures added by that mod
		/// </summary>
		public IEnumerable<CustomCreature> Creatures => GetCreatures(GUID);

		/// <summary>
		///     Custom commands added by that mod
		/// </summary>
		public IEnumerable<ConsoleCommand> Commands => GetCommands(GUID);

		/// <summary>
		///     Custom commands added by that mod
		/// </summary>
		public IEnumerable<CustomLocalization> Translations => GetTranslations(GUID);
	}

	/// <summary>
	///     Get all loaded mod's metadata which are depending on Jötunn
	/// </summary>
	/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Jotunn.Utils.ModRegistry.ModInfo" /> for all loaded mods</returns>
	public static IEnumerable<ModInfo> GetMods(bool includingJotunn = false)
	{
		return BepInExUtils.GetDependentPlugins(includingJotunn).Values.Select((BaseUnityPlugin mod) => new ModInfo
		{
			GUID = mod.Info.Metadata.GUID,
			Name = mod.Info.Metadata.Name,
			Version = mod.Info.Metadata.Version
		});
	}

	/// <summary>
	///     Get all added <see cref="T:Jotunn.Entities.CustomPrefab">CustomPrefabs</see>
	/// </summary>
	/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Jotunn.Entities.CustomPrefab" /> from all loaded mods</returns>
	public static IEnumerable<CustomPrefab> GetPrefabs()
	{
		return PrefabManager.Instance.Prefabs.Values;
	}

	/// <summary>
	///     Get all added <see cref="T:Jotunn.Entities.CustomPrefab">CustomPrefabs</see> of a mod by GUID
	/// </summary>
	/// <param name="modGuid">GUID of the mod</param>
	/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Jotunn.Entities.CustomPrefab" /> from a specific mod</returns>
	public static IEnumerable<CustomPrefab> GetPrefabs(string modGuid)
	{
		return GetPrefabs().FilterByMod(modGuid);
	}

	/// <summary>
	///     Get all added <see cref="T:Jotunn.Entities.CustomItem">CustomItems</see>
	/// </summary>
	/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Jotunn.Entities.CustomItem" /> from all loaded mods</returns>
	public static IEnumerable<CustomItem> GetItems()
	{
		return ItemManager.Instance.Items.Values;
	}

	/// <summary>
	///     Get all added <see cref="T:Jotunn.Entities.CustomItem">CustomItems</see> of a mod by GUID
	/// </summary>
	/// <param name="modGuid">GUID of the mod</param>
	/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Jotunn.Entities.CustomItem" /> from a specific mod</returns>
	public static IEnumerable<CustomItem> GetItems(string modGuid)
	{
		return GetItems().FilterByMod(modGuid);
	}

	/// <summary>
	///     Get all added <see cref="T:Jotunn.Entities.CustomRecipe">CustomRecipes</see>
	/// </summary>
	/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Jotunn.Entities.CustomRecipe" /> from all loaded mods</returns>
	public static IEnumerable<CustomRecipe> GetRecipes()
	{
		return ItemManager.Instance.Recipes;
	}

	/// <summary>
	///     Get all added <see cref="T:Jotunn.Entities.CustomRecipe">CustomRecipes</see> of a mod by GUID
	/// </summary>
	/// <param name="modGuid">GUID of the mod</param>
	/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Jotunn.Entities.CustomRecipe" /> from a specific mod</returns>
	public static IEnumerable<CustomRecipe> GetRecipes(string modGuid)
	{
		return GetRecipes().FilterByMod(modGuid);
	}

	/// <summary>
	///     Get all added <see cref="T:Jotunn.Entities.CustomItemConversion">CustomItemConversions</see>
	/// </summary>
	/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Jotunn.Entities.CustomItemConversion" /> from all loaded mods</returns>
	public static IEnumerable<CustomItemConversion> GetItemConversions()
	{
		return ItemManager.Instance.ItemConversions;
	}

	/// <summary>
	///     Get all added <see cref="T:Jotunn.Entities.CustomItemConversion">CustomItemConversions</see> of a mod by GUID
	/// </summary>
	/// <param name="modGuid">GUID of the mod</param>
	/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Jotunn.Entities.CustomItemConversion" /> from a specific mod</returns>
	public static IEnumerable<CustomItemConversion> GetItemConversions(string modGuid)
	{
		return GetItemConversions().FilterByMod(modGuid);
	}

	/// <summary>
	///     Get all added <see cref="T:Jotunn.Entities.CustomStatusEffect">CustomStatusEffects</see>
	/// </summary>
	/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Jotunn.Entities.CustomStatusEffect" /> from all loaded mods</returns>
	public static IEnumerable<CustomStatusEffect> GetStatusEffects()
	{
		return ItemManager.Instance.StatusEffects;
	}

	/// <summary>
	///     Get all added <see cref="T:Jotunn.Entities.CustomStatusEffect">CustomStatusEffects</see> of a mod by GUID
	/// </summary>
	/// <param name="modGuid">GUID of the mod</param>
	/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Jotunn.Entities.CustomStatusEffect" /> from a specific mod</returns>
	public static IEnumerable<CustomStatusEffect> GetStatusEffects(string modGuid)
	{
		return GetStatusEffects().FilterByMod(modGuid);
	}

	/// <summary>
	///     Get all added <see cref="T:Jotunn.Entities.CustomPieceTable">CustomPieceTables</see>
	/// </summary>
	/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Jotunn.Entities.CustomPieceTable" /> from all loaded mods</returns>
	public static IEnumerable<CustomPieceTable> GetPieceTables()
	{
		return PieceManager.Instance.PieceTables.AsReadOnly();
	}

	/// <summary>
	///     Get all added <see cref="T:Jotunn.Entities.CustomPieceTable">CustomPieceTables</see> of a mod by GUID
	/// </summary>
	/// <param name="modGuid">GUID of the mod</param>
	/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Jotunn.Entities.CustomPieceTable" /> from a specific mod</returns>
	public static IEnumerable<CustomPieceTable> GetPieceTables(string modGuid)
	{
		return GetPieceTables().FilterByMod(modGuid);
	}

	/// <summary>
	///     Get all added <see cref="T:Jotunn.Entities.CustomPiece">CustomPieces</see>
	/// </summary>
	/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Jotunn.Entities.CustomPiece" /> from all loaded mods</returns>
	public static IEnumerable<CustomPiece> GetPieces()
	{
		return PieceManager.Instance.Pieces.Values;
	}

	/// <summary>
	///     Get all added <see cref="T:Jotunn.Entities.CustomPiece">CustomPieces</see> of a mod by GUID
	/// </summary>
	/// <param name="modGuid">GUID of the mod</param>
	/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Jotunn.Entities.CustomPiece" /> from a specific mod</returns>
	public static IEnumerable<CustomPiece> GetPieces(string modGuid)
	{
		return GetPieces().FilterByMod(modGuid);
	}

	/// <summary>
	///     Get all added <see cref="T:Jotunn.Entities.CustomLocation">CustomLocations</see>
	/// </summary>
	/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Jotunn.Entities.CustomLocation" /> from all loaded mods</returns>
	public static IEnumerable<CustomLocation> GetLocations()
	{
		return ZoneManager.Instance.Locations.Values;
	}

	/// <summary>
	///     Get all added <see cref="T:Jotunn.Entities.CustomLocation">CustomLocations</see> of a mod by GUID
	/// </summary>
	/// <param name="modGuid">GUID of the mod</param>
	/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Jotunn.Entities.CustomLocation" /> from a specific mod</returns>
	public static IEnumerable<CustomLocation> GetLocations(string modGuid)
	{
		return GetLocations().FilterByMod(modGuid);
	}

	/// <summary>
	///     Get all added <see cref="T:Jotunn.Entities.CustomVegetation">CustomVegetations</see>
	/// </summary>
	/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Jotunn.Entities.CustomVegetation" /> from all loaded mods</returns>
	public static IEnumerable<CustomVegetation> GetVegetation()
	{
		return ZoneManager.Instance.Vegetations.Values;
	}

	/// <summary>
	///     Get all added <see cref="T:Jotunn.Entities.CustomVegetation">CustomVegetations</see> of a mod by GUID
	/// </summary>
	/// <param name="modGuid">GUID of the mod</param>
	/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Jotunn.Entities.CustomVegetation" /> from a specific mod</returns>
	public static IEnumerable<CustomVegetation> GetVegetation(string modGuid)
	{
		return ZoneManager.Instance.Vegetations.Values.Where((CustomVegetation x) => x.SourceMod.GUID.Equals(modGuid));
	}

	/// <summary>
	///     Get all added <see cref="T:Jotunn.Entities.CustomClutter">CustomClutter</see>
	/// </summary>
	/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Jotunn.Entities.CustomClutter" /> from all loaded mods</returns>
	public static IEnumerable<CustomClutter> GetClutter()
	{
		return ZoneManager.Instance.Clutter.Values;
	}

	/// <summary>
	///     Get all added <see cref="T:Jotunn.Entities.CustomClutter">CustomClutter</see> of a mod by GUID
	/// </summary>
	/// <param name="modGuid">GUID of the mod</param>
	/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Jotunn.Entities.CustomClutter" /> from a specific mod</returns>
	public static IEnumerable<CustomClutter> GetClutter(string modGuid)
	{
		return GetClutter().FilterByMod(modGuid);
	}

	/// <summary>
	///     Get all added <see cref="T:Jotunn.Entities.CustomCreature">CustomCreatures</see>
	/// </summary>
	/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Jotunn.Entities.CustomCreature" /> from all loaded mods</returns>
	public static IEnumerable<CustomCreature> GetCreatures()
	{
		return CreatureManager.Instance.Creatures.AsReadOnly();
	}

	/// <summary>
	///     Get all added <see cref="T:Jotunn.Entities.CustomCreature">CustomCreatures</see> of a mod by GUID
	/// </summary>
	/// <param name="modGuid">GUID of the mod</param>
	/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Jotunn.Entities.CustomCreature" /> from a specific mod</returns>
	public static IEnumerable<CustomCreature> GetCreatures(string modGuid)
	{
		return GetCreatures().FilterByMod(modGuid);
	}

	/// <summary>
	///     Get all added <see cref="T:Jotunn.Entities.ConsoleCommand">ConsoleCommands</see>
	/// </summary>
	/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Jotunn.Entities.ConsoleCommand" /> from all loaded mods</returns>
	public static IEnumerable<ConsoleCommand> GetCommands()
	{
		return CommandManager.Instance.CustomCommands;
	}

	/// <summary>
	///     Get all added <see cref="T:Jotunn.Entities.ConsoleCommand">ConsoleCommands</see> of a mod by GUID
	/// </summary>
	/// <param name="modGuid">GUID of the mod</param>
	/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Jotunn.Entities.ConsoleCommand" /> from a specific mod</returns>
	public static IEnumerable<ConsoleCommand> GetCommands(string modGuid)
	{
		return GetCommands().FilterByMod(modGuid);
	}

	/// <summary>
	///     Get all added <see cref="T:Jotunn.Entities.CustomLocalization">CustomLocalizations</see>
	/// </summary>
	/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Jotunn.Entities.CustomLocalization" /> from all loaded mods</returns>
	public static IEnumerable<CustomLocalization> GetTranslations()
	{
		return LocalizationManager.Instance.Localizations.Values;
	}

	/// <summary>
	///     Get all added <see cref="T:Jotunn.Entities.CustomLocalization">CustomLocalizations</see> of a mod by GUID
	/// </summary>
	/// <param name="modGuid">GUID of the mod</param>
	/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Jotunn.Entities.CustomLocalization" /> from a specific mod</returns>
	public static IEnumerable<CustomLocalization> GetTranslations(string modGuid)
	{
		return GetTranslations().FilterByMod(modGuid);
	}

	private static IEnumerable<T> FilterByMod<T>(this IEnumerable<T> list, string modGuid) where T : CustomEntity
	{
		return list.Where((T x) => x.SourceMod.GUID == modGuid);
	}
}
