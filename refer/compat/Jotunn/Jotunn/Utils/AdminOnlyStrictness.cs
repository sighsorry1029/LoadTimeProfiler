namespace Jotunn.Utils;

/// <summary>
///     Enum used for telling whether AdminOnly settings for Config Entries should always be enforced
///     or if they should only be enforced when the mod is installed on the server.
/// </summary>
public enum AdminOnlyStrictness
{
	/// <summary>
	///     AdminOnly is always enforced for Config Entries even if the mod is not installed on the server.
	///     This means that AdminOnly configs cannot be edited in multiplayer if the mod is not on the server.
	/// </summary>
	Always,
	/// <summary>
	///     AdminOnly is only enforced for Config Entries if the mod is installed on the server.
	/// </summary>
	IfOnServer
}
