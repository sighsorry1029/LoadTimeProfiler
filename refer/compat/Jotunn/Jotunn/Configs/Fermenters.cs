using System.Collections.Generic;
using System.Linq;
using BepInEx.Configuration;

namespace Jotunn.Configs;

/// <summary>
///     Helper to get existing fermenter names
/// </summary>
public class Fermenters
{
	private static readonly Dictionary<string, string> NamesMap = new Dictionary<string, string> { { "Fermenter", Fermenter } };

	private static readonly AcceptableValueList<string> AcceptableValues = new AcceptableValueList<string>(NamesMap.Keys.ToArray());

	/// <summary>
	///     Fermenter
	/// </summary>
	public static string Fermenter => "fermenter";

	/// <summary>
	///     Gets the human readable name to internal names map
	/// </summary>
	/// <returns></returns>
	public static Dictionary<string, string> GetNames()
	{
		return NamesMap;
	}

	/// <summary>
	///     Get a <see cref="T:BepInEx.Configuration.AcceptableValueList`1" /> of all fermenter names.
	///     This can be used to create a <see cref="T:BepInEx.Configuration.ConfigEntry`1" /> where only valid fermenter can be selected.<br /><br />
	///     Example:
	///     <code>
	///         var fermenterConfig = Config.Bind("Section", "Key", nameof(Fermenters.Fermenter), new ConfigDescription("Description", Fermenters.GetAcceptableValueList()));
	///     </code>
	/// </summary>
	/// <returns></returns>
	public static AcceptableValueList<string> GetAcceptableValueList()
	{
		return AcceptableValues;
	}

	/// <summary>
	///     Get the internal name for a fermenter from its human readable name.
	/// </summary>
	/// <param name="fermenter"></param>
	/// <returns>
	///     The matched internal name.
	///     If the fermenter parameter is null or empty, an empty string is returned.
	///     Otherwise the unchanged fermenter parameter is returned.
	/// </returns>
	public static string GetInternalName(string fermenter)
	{
		if (string.IsNullOrEmpty(fermenter))
		{
			return string.Empty;
		}
		if (NamesMap.TryGetValue(fermenter, out var value))
		{
			return value;
		}
		return fermenter;
	}
}
