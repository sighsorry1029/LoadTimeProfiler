using System;

namespace Jotunn.Utils;

/// <summary>
///     Mod compatibility attribute<br />
///     <br />
///     If your mod adds its own RPCs, EnforceModOnClients is likely a must (otherwise clients would just discard the messages from the server), same version you do have to determine, if your sent data changed.<br />
///     If your mod adds items, you always should enforce mods on client and same version (there could be nasty side effects with different versions of an item).<br />
///     If your mod is just GUI changes (for example bigger inventory, additional equip slots) there is no need to set this attribute
/// </summary>
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class)]
public class NetworkCompatibilityAttribute : Attribute
{
	/// <summary>
	///     Compatibility Level
	/// </summary>
	public CompatibilityLevel EnforceModOnClients { get; set; }

	/// <summary>
	///     Version Strictness
	/// </summary>
	public VersionStrictness EnforceSameVersion { get; set; }

	/// <summary>
	///     Network Compatibility Attribute
	/// </summary>
	/// <param name="enforceMod"></param>
	/// <param name="enforceVersion"></param>
	public NetworkCompatibilityAttribute(CompatibilityLevel enforceMod, VersionStrictness enforceVersion)
	{
		EnforceModOnClients = enforceMod;
		EnforceSameVersion = enforceVersion;
	}
}
