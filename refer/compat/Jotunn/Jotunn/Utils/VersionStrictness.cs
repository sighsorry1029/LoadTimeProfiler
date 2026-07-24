namespace Jotunn.Utils;

/// <summary>
///     Enum used for telling whether or not the same mod version should be used by both the server and the clients.
///     This enum is only useful with certain CompatibilityLevel values.
/// </summary>
public enum VersionStrictness
{
	/// <summary>
	///     No version check is done
	/// </summary>
	None,
	/// <summary>
	///     Mod must have the same Major version
	/// </summary>
	Major,
	/// <summary>
	///     Mods must have the same Minor version
	/// </summary>
	Minor,
	/// <summary>
	///     Mods must have the same Patch version
	/// </summary>
	Patch
}
