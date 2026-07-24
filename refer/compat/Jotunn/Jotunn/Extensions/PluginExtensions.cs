using System.Linq;
using BepInEx;
using Jotunn.Utils;

namespace Jotunn.Extensions;

internal static class PluginExtensions
{
	internal static NetworkCompatibilityAttribute GetNetworkCompatibilityAttribute(this BaseUnityPlugin plugin)
	{
		return plugin.GetType().GetCustomAttributes(typeof(NetworkCompatibilityAttribute), inherit: true).Cast<NetworkCompatibilityAttribute>()
			.FirstOrDefault();
	}

	internal static SynchronizationModeAttribute GetSynchronizationModeAttribute(this BaseUnityPlugin plugin)
	{
		return plugin.GetType().GetCustomAttributes(typeof(SynchronizationModeAttribute), inherit: true).Cast<SynchronizationModeAttribute>()
			.FirstOrDefault();
	}
}
