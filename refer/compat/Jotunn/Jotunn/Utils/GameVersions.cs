using System;
using System.Reflection;

namespace Jotunn.Utils;

/// <summary>
///     Utility class for getting game versions
/// </summary>
public static class GameVersions
{
	/// <summary>
	///     The semantic version of the running Valheim game
	/// </summary>
	public static Version ValheimVersion { get; } = GetValheimVersion();

	/// <summary>
	///     The network version of the running Valheim game, determining compatibility with other clients
	/// </summary>
	public static uint NetworkVersion { get; } = GetNetworkVersion();

	private static Version GetValheimVersion()
	{
		return new Version(global::Version.CurrentVersion.m_major, global::Version.CurrentVersion.m_minor, global::Version.CurrentVersion.m_patch);
	}

	private static uint GetNetworkVersion()
	{
		FieldInfo fieldInfo = typeof(global::Version).GetField("m_networkVersion") ?? typeof(global::Version).GetField("c_networkVersion") ?? throw new Exception("Could not find network version field in Version class");
		return (uint)fieldInfo.GetValue(null);
	}
}
