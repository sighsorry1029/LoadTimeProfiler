using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx;
using BepInEx.Bootstrap;

namespace Jotunn.Utils;

/// <summary>
///     Helper methods to access BepInEx plugin information
/// </summary>
public static class BepInExUtils
{
	/// <summary>
	///     Cached plugin list
	/// </summary>
	private static BaseUnityPlugin[] Plugins;

	private static Dictionary<PluginInfo, string> PluginInfoTypeNameCache { get; } = new Dictionary<PluginInfo, string>();

	private static Dictionary<Assembly, PluginInfo> AssemblyToPluginInfoCache { get; } = new Dictionary<Assembly, PluginInfo>();

	private static Dictionary<Type, PluginInfo> TypeToPluginInfoCache { get; } = new Dictionary<Type, PluginInfo>();

	/// <summary>
	///     Cache loaded plugins which depend on Jotunn.
	/// </summary>
	/// <returns></returns>
	private static BaseUnityPlugin[] CacheDependentPlugins()
	{
		List<BaseUnityPlugin> list = new List<BaseUnityPlugin>();
		foreach (BaseUnityPlugin loadedPlugin in GetLoadedPlugins())
		{
			if (loadedPlugin.Info == null)
			{
				Logger.LogWarning("Plugin without Info found: " + loadedPlugin.GetType().Assembly.FullName);
				continue;
			}
			if (loadedPlugin.Info.Metadata == null)
			{
				Logger.LogWarning("Plugin without Metadata found: " + loadedPlugin.GetType().Assembly.FullName);
				continue;
			}
			if (loadedPlugin.Info.Metadata.GUID == "com.jotunn.jotunn")
			{
				list.Add(loadedPlugin);
				continue;
			}
			foreach (BepInDependency item in loadedPlugin.GetType().GetCustomAttributes(typeof(BepInDependency), inherit: false).Cast<BepInDependency>())
			{
				if (item.DependencyGUID == "com.jotunn.jotunn")
				{
					list.Add(loadedPlugin);
				}
			}
		}
		return list.ToArray();
	}

	/// <summary>
	///     Get a dictionary of loaded plugins which depend on Jotunn.
	/// </summary>
	/// <returns>Dictionary of plugin GUID and <see cref="T:BepInEx.BaseUnityPlugin" /></returns>
	public static Dictionary<string, BaseUnityPlugin> GetDependentPlugins(bool includeJotunn = false)
	{
		if (Plugins == null)
		{
			if (!ReflectionHelper.GetPrivateField<bool>(typeof(Chainloader), "_loaded"))
			{
				return new Dictionary<string, BaseUnityPlugin>();
			}
			Plugins = CacheDependentPlugins();
		}
		return Plugins.Where((BaseUnityPlugin plugin) => includeJotunn || plugin.Info.Metadata.GUID != "com.jotunn.jotunn").ToDictionary((BaseUnityPlugin plugin) => plugin.Info.Metadata.GUID);
	}

	/// <summary>
	///     Get a dictionary of all plugins loaded by BepInEx
	/// </summary>
	/// <returns>Dictionary of plugin GUID and <see cref="T:BepInEx.BaseUnityPlugin" /></returns>
	public static Dictionary<string, BaseUnityPlugin> GetPlugins(bool includeJotunn = false)
	{
		return (from plugin in GetLoadedPlugins()
			where includeJotunn || plugin.Info.Metadata.GUID != "com.jotunn.jotunn"
			select plugin).ToDictionary((BaseUnityPlugin plugin) => plugin.Info.Metadata.GUID);
	}

	/// <summary>
	///     Get <see cref="T:BepInEx.PluginInfo" /> from a <see cref="T:System.Type" />
	/// </summary>
	/// <param name="type"><see cref="T:System.Type" /> of the plugin main class</param>
	/// <returns></returns>
	public static PluginInfo GetPluginInfoFromType(Type type)
	{
		if (TypeToPluginInfoCache.TryGetValue(type, out var value))
		{
			return value;
		}
		foreach (PluginInfo value2 in Chainloader.PluginInfos.Values)
		{
			string privateProperty = ReflectionHelper.GetPrivateProperty<string>(value2, "TypeName");
			if (privateProperty.Equals(type.FullName))
			{
				TypeToPluginInfoCache[type] = value2;
				return value2;
			}
		}
		return null;
	}

	private static string GetPluginInfoTypeName(PluginInfo info)
	{
		if (PluginInfoTypeNameCache.TryGetValue(info, out var value))
		{
			return value;
		}
		value = ReflectionHelper.GetPrivateProperty<string>(info, "TypeName");
		PluginInfoTypeNameCache.Add(info, value);
		return value;
	}

	/// <summary>
	///     Get <see cref="T:BepInEx.PluginInfo" /> from an <see cref="T:System.Reflection.Assembly" />
	/// </summary>
	/// <param name="assembly"><see cref="T:System.Reflection.Assembly" /> of the plugin</param>
	/// <returns></returns>
	public static PluginInfo GetPluginInfoFromAssembly(Assembly assembly)
	{
		if (AssemblyToPluginInfoCache.TryGetValue(assembly, out var value))
		{
			return value;
		}
		foreach (PluginInfo value2 in Chainloader.PluginInfos.Values)
		{
			if (assembly.GetType(GetPluginInfoTypeName(value2)) != null)
			{
				AssemblyToPluginInfoCache[assembly] = value2;
				return value2;
			}
		}
		AssemblyToPluginInfoCache[assembly] = null;
		return null;
	}

	/// <summary>
	///     Get <see cref="T:BepInEx.PluginInfo" /> from a path, also matches subfolder paths
	/// </summary>
	/// <param name="fileInfo"><see cref="T:System.IO.FileInfo" /> object of the plugin path</param>
	/// <returns></returns>
	public static PluginInfo GetPluginInfoFromPath(FileInfo fileInfo)
	{
		return Chainloader.PluginInfos.Values.Where((PluginInfo pi) => pi.Location != null).FirstOrDefault((PluginInfo pi) => fileInfo.DirectoryName != null && fileInfo.DirectoryName.Contains(new FileInfo(pi.Location).DirectoryName) && new FileInfo(pi.Location).DirectoryName != BepInEx.Paths.PluginPath);
	}

	/// <summary>
	///     Get metadata information from the current calling mod
	/// </summary>
	/// <returns></returns>
	public static BepInPlugin GetSourceModMetadata()
	{
		Type callingType = ReflectionHelper.GetCallingType();
		return GetPluginInfoFromType(callingType)?.Metadata ?? GetPluginInfoFromAssembly(callingType.Assembly)?.Metadata ?? Main.Instance.Info.Metadata;
	}

	private static IEnumerable<BaseUnityPlugin> GetLoadedPlugins()
	{
		return from x in Chainloader.PluginInfos
			where x.Value != null && x.Value.Instance != null
			select x.Value.Instance;
	}
}
