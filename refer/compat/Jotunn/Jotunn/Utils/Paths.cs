using System.IO;
using BepInEx;

namespace Jotunn.Utils;

/// <summary>
///     Various Path constants used in Jötunn
/// </summary>
public static class Paths
{
	/// <summary>
	///     Path to the game's save path
	/// </summary>
	public static string JotunnFolder
	{
		get
		{
			string saveDataPath = Utils.GetSaveDataPath((FileSource)1);
			return Path.Combine(saveDataPath, "Jotunn");
		}
	}

	/// <summary>
	///     Path to the custom item folder
	/// </summary>
	public static string CustomItemDataFolder => Path.Combine(JotunnFolder, "CustomItemData");

	/// <summary>
	///     Path to the global translation folder
	/// </summary>
	public static string LanguageTranslationsFolder => BepInEx.Paths.PluginPath;

	/// <summary>
	///     Path to cached icons. See <see cref="T:Jotunn.Managers.RenderManager" />
	/// </summary>
	public static string IconCachePath => Path.Combine(JotunnFolder, "CachedIcons");
}
