using System;

namespace Jotunn.Utils;

/// <summary>
///     Determines the level of compatibility of a mod which is enforced by Jötunn.
///     Servers disconnect clients with mods which enforce their compatibility when 
///     the version does not match as defined by the VersionStrictness attribute.
/// </summary>
public enum CompatibilityLevel
{
	/// <summary>
	///     Mod is not checked at all, VersionsStrictness does not apply.
	/// </summary>
	[Obsolete("Use NotEnforced instead")]
	NoNeedForSync,
	/// <summary>
	///     Mod is checked only if the client and server have loaded it and ignores if just one side has it.
	/// </summary>
	[Obsolete("Use VersionCheckOnly")]
	OnlySyncWhenInstalled,
	/// <summary>
	///     Mod must be loaded on server and client. Version checking depends on the VersionStrictness.
	/// </summary>
	EveryoneMustHaveMod,
	/// <summary>
	///     If mod is installed on the server, every client has to have it. VersionStrictness does apply when both sides have it.
	/// </summary>
	ClientMustHaveMod,
	/// <summary>
	///     If mod is installed on the client, the server has to have it. VersionStrictness does apply when both sides have it.
	/// </summary>
	ServerMustHaveMod,
	/// <summary>
	///     Version check is performed when both server and client have the mod, no check if the mod is actually installed.
	/// </summary>
	VersionCheckOnly,
	/// <summary>
	///     Mod is not checked at all, VersionsStrictness does not apply.
	/// </summary>
	NotEnforced
}
