using System;
using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using Jotunn.Extensions;

namespace Jotunn.Utils;

/// <summary>
///     Watches a <see cref="T:BepInEx.Configuration.ConfigFile" /> for changes and raises events when the configuration file is modified.
/// </summary>
public class ConfigFileWatcher
{
	private const long TICKS_PER_MILISEC = 10000L;

	private DateTime lastReadTime = DateTime.MinValue;

	private readonly ConfigFile configFile;

	private readonly BepInPlugin sourceMod;

	private readonly string configFileDir;

	private readonly string configFileName;

	private readonly long reloadDelay;

	/// <summary>
	///     Event triggered after the file watcher reloads the configuration file.
	/// </summary>
	public event Action OnConfigFileReloaded;

	/// <summary>
	///     Create a file watcher to trigger reloads of the config file when it is changed, created, or renamed.
	/// </summary>
	/// <param name="configFile"></param>
	/// <param name="reloadDelay">Time in milliseconds before another event can be fired.</param>
	public ConfigFileWatcher(ConfigFile configFile, long reloadDelay = 1000L)
	{
		sourceMod = BepInExUtils.GetPluginInfoFromAssembly(Assembly.GetCallingAssembly())?.Metadata;
		if (sourceMod == null || sourceMod.GUID == Main.Instance.Info.Metadata.GUID)
		{
			sourceMod = BepInExUtils.GetSourceModMetadata();
		}
		this.configFile = configFile;
		this.reloadDelay = reloadDelay * 10000;
		configFileDir = Directory.GetParent(configFile.ConfigFilePath).FullName;
		configFileName = Path.GetFileName(configFile.ConfigFilePath);
		FileSystemWatcher fileSystemWatcher = new FileSystemWatcher(configFileDir, configFileName);
		fileSystemWatcher.Changed += ReloadConfigFile;
		fileSystemWatcher.Created += ReloadConfigFile;
		fileSystemWatcher.Renamed += ReloadConfigFile;
		fileSystemWatcher.IncludeSubdirectories = true;
		fileSystemWatcher.SynchronizingObject = ThreadingHelper.SynchronizingObject;
		fileSystemWatcher.EnableRaisingEvents = true;
	}

	/// <summary>
	///     Safely invoke the <see cref="E:Jotunn.Utils.ConfigFileWatcher.OnConfigFileReloaded" /> event
	/// </summary>
	private void InvokeOnConfigFileReloaded()
	{
		this.OnConfigFileReloaded?.SafeInvoke();
	}

	/// <summary>
	///     Reloads config file if and only if the last write time differs from the last read time.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="eventArgs"></param>
	internal void ReloadConfigFile(object sender, FileSystemEventArgs eventArgs)
	{
		DateTime now = DateTime.Now;
		long num = now.Ticks - lastReadTime.Ticks;
		if (!File.Exists(configFile.ConfigFilePath) || num < reloadDelay)
		{
			return;
		}
		try
		{
			Logger.LogInfo(sourceMod, "Reloading " + configFileName);
			bool saveOnConfigSet = configFile.SetSaveOnConfigSet(saveOnConfigSet: false);
			configFile.Reload();
			configFile.SaveOnConfigSet = saveOnConfigSet;
			lastReadTime = now;
			InvokeOnConfigFileReloaded();
		}
		catch
		{
			Logger.LogError(sourceMod, "There was an issue loading " + configFileName);
			Logger.LogError(sourceMod, "Please check your config entries for spelling and format!");
		}
	}
}
