using System;

namespace Jotunn.Utils;

/// <summary>
///     This attribute is used to determine how Jotunn should enforce synchronization of Config Entries.<br />
///     Only relevant for Config Entries that have the <see cref="P:ConfigurationManagerAttributes.IsAdminOnly" /> applied.
/// </summary>
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class)]
public class SynchronizationModeAttribute : Attribute
{
	/// <summary>
	///     AdminOnly ConfigEntry Strictness
	/// </summary>
	public AdminOnlyStrictness EnforceAdminOnly { get; set; }

	/// <summary>
	///     Synchronization mode Attribute
	/// </summary>
	/// <param name="enforceAdminOnly"></param>
	public SynchronizationModeAttribute(AdminOnlyStrictness enforceAdminOnly)
	{
		EnforceAdminOnly = enforceAdminOnly;
	}

	/// <summary>
	///     Check if AdminOnly Config Entries should always be locked if player is not an admin.
	/// </summary>
	/// <returns></returns>
	public bool ShouldAlwaysEnforceAdminOnly()
	{
		return EnforceAdminOnly == AdminOnlyStrictness.Always;
	}
}
