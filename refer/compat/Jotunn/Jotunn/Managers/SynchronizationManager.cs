using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
using HarmonyLib;
using Jotunn.Entities;
using Jotunn.Extensions;
using Jotunn.Utils;
using UnityEngine;

namespace Jotunn.Managers;

/// <summary>
///    Manager for handling synchronisation between client and server instances.
/// </summary>
public class SynchronizationManager : IManager
{
	private static class Patches
	{
		[HarmonyPatch(typeof(ZNet), "Awake")]
		[HarmonyPostfix]
		private static void ZNet_Awake(ZNet __instance)
		{
			Instance.ZNet_Awake(__instance);
		}

		[HarmonyPatch(typeof(ZNet), "RPC_PeerInfo")]
		[HarmonyPrefix]
		private static void ZNet_RPC_Pre_PeerInfo(ZNet __instance, ZRpc rpc, ref SocketBuffer __state)
		{
			Instance.ZNet_RPC_Pre_PeerInfo(__instance, rpc, ref __state);
		}

		[HarmonyPatch(typeof(ZNet), "RPC_PeerInfo")]
		[HarmonyPostfix]
		private static void ZNet_RPC_Post_PeerInfo(ZNet __instance, ZRpc rpc, ref SocketBuffer __state)
		{
			Instance.ZNet_RPC_Post_PeerInfo(__instance, rpc, ref __state);
		}

		public static bool Socket_VersionMatch_Prefix(ISocket __instance, bool __runOriginal)
		{
			if (__runOriginal)
			{
				return Instance.Socket_VersionMatch(__instance);
			}
			return false;
		}

		public static bool Socket_Send_Prefix(ISocket __instance, ZPackage pkg, bool __runOriginal)
		{
			if (__runOriginal)
			{
				return Instance.Socket_Send(__instance, pkg);
			}
			return false;
		}

		[HarmonyPatch(typeof(SyncedList), "Load")]
		[HarmonyPostfix]
		private static void SyncedList_Load(SyncedList __instance)
		{
			Instance.SyncedList_Load(__instance);
		}

		[HarmonyPatch(typeof(SyncedList), "Save")]
		[HarmonyPostfix]
		private static void SyncedList_Save(SyncedList __instance)
		{
			Instance.SyncedList_Save(__instance);
		}

		[HarmonyPatch(typeof(Menu), "IsVisible")]
		[HarmonyPostfix]
		private static void Menu_IsVisible(ref bool __result)
		{
			Instance.Menu_IsVisible(ref __result);
		}

		/// <summary>
		///     Harmony patch BepInEx to ensure locked values are not overwritten.
		///     Return the cached local value of a bep config thats locked
		/// </summary>
		[HarmonyPatch(typeof(ConfigEntryBase), "GetSerializedValue")]
		[HarmonyPrefix]
		private static bool GetCachedValueForSyncedConfigs(ConfigEntryBase __instance, ref string __result)
		{
			return ConfigEntryBase_GetSerializedValue(__instance, ref __result);
		}

		/// <summary>
		///     Harmony patch BepInEx to ensure locked values are not overwritten.
		///     Prevent overwriting bep config value when the setting is locked on config file reload.
		/// </summary>
		[HarmonyPatch(typeof(ConfigEntryBase), "SetSerializedValue")]
		[HarmonyPrefix]
		private static bool BlockSetForSyncedConfigs(ConfigEntryBase __instance)
		{
			return ConfigEntryBase_SetSerializedValue(__instance);
		}

		[HarmonyPatch(typeof(ZNet), "Start")]
		[HarmonyPrefix]
		private static void ZNet_Start(ZNet __instance)
		{
			Instance.InitAdminState(__instance);
			Instance.SubscribeToConfigReload();
		}

		[HarmonyPatch(typeof(ZNet), "OnDestroy")]
		[HarmonyPrefix]
		private static void Znet_OnDestroy(ZNet __instance)
		{
			Instance.UnsubscribeToConfigReload();
			Instance.ResetAdminState(__instance);
		}
	}

	/// <summary>
	///     Holds up and preserves PeerInfo or RoutedRPC packages until
	///     the finished member is set to true. All other packages get sent. This will
	///     stop the client from completing the login handshake with the server until ready.
	/// </summary>
	private class SocketBuffer
	{
		public volatile bool finished;

		public volatile int versionMatchPackageIndex = -1;

		public List<ZPackage> packages = new List<ZPackage>();
	}

	private CustomRPC ConfigRPC;

	private CustomRPC AdminRPC;

	private List<Tuple<CustomRPC, Func<ZNetPeer, ZPackage>>> InitialSync = new List<Tuple<CustomRPC, Func<ZNetPeer, ZPackage>>>();

	internal readonly Dictionary<ConfigEntryBase, object> localValues = new Dictionary<ConfigEntryBase, object>();

	private readonly Dictionary<string, bool> CachedAdminStates = new Dictionary<string, bool>();

	private readonly Dictionary<string, ConfigFile> CustomConfigs = new Dictionary<string, ConfigFile>();

	private HashSet<Tuple<string, string, string, string>> CachedConfigValues = new HashSet<Tuple<string, string, string, string>>();

	private readonly Dictionary<string, string> CachedCustomConfigGUIDs = new Dictionary<string, string>();

	private bool ConfigurationManagerWindowShown;

	private Dictionary<string, SocketBuffer> socketBuffers = new Dictionary<string, SocketBuffer>();

	private HashSet<string> modNotLoadedConfigsWarnings = new HashSet<string>();

	private static SynchronizationManager _instance;

	private const byte INITIAL_CONFIG = 64;

	/// <summary>
	///     Singleton instance
	/// </summary>
	public static SynchronizationManager Instance => _instance ?? (_instance = new SynchronizationManager());

	/// <summary>
	///     Clientside indicator if the current player has admin status on
	///     the current world, always true on local games
	/// </summary>
	public bool PlayerIsAdmin { get; private set; } = true;

	/// <summary>
	///     Event triggered after configuration has been synced on either the server or client
	/// </summary>
	public static event EventHandler<ConfigurationSynchronizationEventArgs> OnConfigurationSynchronized;

	/// <summary>
	///     Event triggered before syncing configuration on either the server or client
	/// </summary>
	public static event EventHandler<SyncingConfigurationEventArgs> OnSyncingConfiguration;

	/// <summary>
	///     Event triggered after a clients admin status changed on the server
	/// </summary>
	public static event Action OnAdminStatusChanged;

	/// <summary>
	///     Event triggered after the in-game configuration manager window is closed
	/// </summary>
	public static event Action OnConfigurationWindowClosed;

	/// <summary>
	///     Hide .ctor
	/// </summary>
	private SynchronizationManager()
	{
	}

	/// <summary>
	///     Manager's main init
	/// </summary>
	void IManager.Init()
	{
		Main.LogInit("SynchronizationManager");
		AdminRPC = NetworkManager.Instance.AddRPC(Main.Instance.Info.Metadata, "AdminStatus", null, AdminRPC_OnClientReceive);
		ConfigRPC = NetworkManager.Instance.AddRPC(Main.Instance.Info.Metadata, "ConfigSync", ConfigRPC_OnServerReceive, ConfigRPC_OnClientReceive);
		Main.Harmony.PatchAll(typeof(Patches));
		HarmonyMethod prefix = new HarmonyMethod(typeof(Patches).GetMethod("Socket_Send_Prefix"));
		HarmonyMethod prefix2 = new HarmonyMethod(typeof(Patches).GetMethod("Socket_VersionMatch_Prefix"));
		Type type = typeof(Game).Assembly.GetType("ZSteamSocket");
		if (type != null)
		{
			Main.Harmony.Patch(type.GetMethod("Send", new Type[1] { typeof(ZPackage) }), prefix);
			Main.Harmony.Patch(type.GetMethod("VersionMatch"), prefix2);
		}
		Type type2 = typeof(Game).Assembly.GetType("ZPlayFabSocket");
		if (type2 != null)
		{
			Main.Harmony.Patch(type2.GetMethod("Send", new Type[1] { typeof(ZPackage) }), prefix);
			Main.Harmony.Patch(type2.GetMethod("VersionMatch"), prefix2);
		}
		if ((bool)ConfigManagerUtils.Plugin)
		{
			EventInfo eventInfo = ConfigManagerUtils.Plugin.GetType().GetEvent("DisplayingWindowChanged");
			if (eventInfo != null)
			{
				Action<object, object> action = ConfigurationManager_DisplayingWindowChanged;
				Delegate handler = Delegate.CreateDelegate(eventInfo.EventHandlerType, action.Target, action.Method);
				eventInfo.AddEventHandler(ConfigManagerUtils.Plugin, handler);
			}
		}
		AddInitialSynchronization(AdminRPC, delegate(ZNetPeer peer)
		{
			string hostName = peer.m_socket.GetHostName();
			bool flag = !string.IsNullOrEmpty(hostName) && ZNet.instance.ListContainsId(ZNet.instance.m_adminList, hostName);
			Logger.LogDebug("Admin status: " + (flag ? "Admin" : "No Admin"));
			ZPackage zPackage = new ZPackage();
			zPackage.Write(flag);
			return zPackage;
		});
		AddInitialSynchronization(ConfigRPC, () => GenerateConfigZPackage(initial: true, GetSyncConfigValues().ToList()));
	}

	/// <summary>
	///     Registers a non default config file for possible synchronisation with all clients.
	///     Entries still need the IsAdminOnly attribute in order to be synchronized.<br />
	///     The file path must be saved under the executing BepInEx config folder, see <see cref="P:BepInEx.Paths.ConfigPath" />.
	///     This guarantees the same relative path for all clients.
	/// </summary>
	/// <param name="customFile">the file to synchronize</param>
	/// <exception cref="T:System.ArgumentException">The config file is not saved under the BepInEx config folder</exception>
	/// <exception cref="T:System.ArgumentException">The config file is already registered</exception>
	/// <exception cref="T:System.ArgumentException">The config file is a default mod config and is already implicitly synchronized</exception>
	public void RegisterCustomConfig(ConfigFile customFile)
	{
		if (!customFile.ConfigFilePath.StartsWith(BepInEx.Paths.ConfigPath))
		{
			throw new ArgumentException("Config file must be saved under the BepInEx config folder. " + customFile.ConfigFilePath);
		}
		string fileIdentifier = GetFileIdentifier(customFile);
		if (IsDefaultModConfig(fileIdentifier, out var modGUID))
		{
			throw new ArgumentException("Config file must not be a default mod config: " + modGUID + ". It is already synchronized");
		}
		if (CustomConfigs.ContainsKey(fileIdentifier))
		{
			throw new ArgumentException("Config file already registered. " + customFile.ConfigFilePath);
		}
		Logger.LogDebug("Registering custom config file " + fileIdentifier);
		CustomConfigs.Add(fileIdentifier, customFile);
		BepInPlugin sourceModMetadata = BepInExUtils.GetSourceModMetadata();
		CachedCustomConfigGUIDs.Add(fileIdentifier, sourceModMetadata.GUID);
	}

	/// <summary>
	///     Add a <see cref="T:Jotunn.Entities.CustomRPC" /> and a method for generating a <see cref="T:ZPackage" /> to the manager.<br />
	///     The RPC will be initiated on the server side after login to sync arbitrary data to the connecting client.
	///     The package is guaranteed to be received before the client's connection is fully established and the player loads into the world.
	/// </summary>
	/// <param name="rpc">RPC to be called</param>
	/// <param name="packageGenerator">Method generating the ZPackage payload, takes the client peer as its argument</param>
	public void AddInitialSynchronization(CustomRPC rpc, Func<ZNetPeer, ZPackage> packageGenerator)
	{
		InitialSync.Add(new Tuple<CustomRPC, Func<ZNetPeer, ZPackage>>(rpc, packageGenerator));
	}

	/// <summary>
	///     Add a <see cref="T:Jotunn.Entities.CustomRPC" /> and a method for generating a <see cref="T:ZPackage" /> to the manager.<br />
	///     The RPC will be initiated on the server side after login to sync arbitrary data to the connecting client.
	///     The package is guaranteed to be received before the client's connection is fully established and the player loads into the world.
	/// </summary>
	/// <param name="rpc">RPC to be called</param>
	/// <param name="packageGenerator">Method generating the ZPackage payload</param>
	public void AddInitialSynchronization(CustomRPC rpc, Func<ZPackage> packageGenerator)
	{
		AddInitialSynchronization(rpc, (ZNetPeer peer) => packageGenerator());
	}

	private void InitAdminState(ZNet zNet)
	{
		CacheConfigurationValues();
		if ((bool)zNet && zNet.IsServer())
		{
			PlayerIsAdmin = true;
			UnlockConfigurationEntries();
			return;
		}
		PlayerIsAdmin = false;
		InitAdminConfigs();
		LockConfigurationEntries();
		SetToDefaultConfigEntries();
	}

	private void ResetAdminState(ZNet zNet)
	{
		PlayerIsAdmin = true;
		UnlockConfigurationEntries();
		ResetAdminConfigs(zNet);
	}

	/// <summary>
	///     Cache local config values for synced entries.
	/// </summary>
	private void InitAdminConfigs()
	{
		foreach (ConfigFile configFile in GetConfigFiles())
		{
			foreach (ConfigDefinition key in configFile.Keys)
			{
				ConfigEntryBase configEntryBase = configFile[key.Section, key.Key];
				ConfigurationManagerAttributes configurationManagerAttributes = configEntryBase.GetConfigurationManagerAttributes();
				if (configurationManagerAttributes != null && configurationManagerAttributes.IsAdminOnly && configEntryBase.BoxedValue != null)
				{
					localValues[configEntryBase] = configEntryBase.BoxedValue;
				}
			}
		}
	}

	/// <summary>
	///     Reset configs which may have been overwritten with server values to the local value
	///     if this machine is not the server.
	/// </summary>
	private void ResetAdminConfigs(ZNet zNet)
	{
		if ((bool)zNet && !zNet.IsServer())
		{
			foreach (KeyValuePair<ConfigEntryBase, object> localValue in localValues)
			{
				localValue.Key.BoxedValue = localValue.Value;
			}
		}
		localValues.Clear();
	}

	/// <summary>
	///     Hook <see cref="M:ZNet.Awake" /> to start a watchdog Coroutine which monitors the admin list.
	/// </summary>
	/// <param name="self"></param>
	private void ZNet_Awake(ZNet self)
	{
		if (self.IsServer())
		{
			self.StartCoroutine(AdminListWatchdog(self));
		}
	}

	private IEnumerator AdminListWatchdog(ZNet znet)
	{
		while ((bool)znet && (bool)znet.gameObject)
		{
			yield return new WaitForSeconds(5f);
			SyncedList adminList = znet.m_adminList;
			if (adminList != null)
			{
				adminList.CheckLoad();
			}
		}
	}

	private void ZNet_RPC_Pre_PeerInfo(ZNet znet, ZRpc rpc, ref SocketBuffer __state)
	{
		if (znet.IsServer())
		{
			string endPointString = rpc.GetSocket().GetEndPointString();
			if (!string.IsNullOrEmpty(endPointString))
			{
				__state = new SocketBuffer();
				socketBuffers[endPointString] = __state;
			}
		}
	}

	private void ZNet_RPC_Post_PeerInfo(ZNet self, ZRpc rpc, ref SocketBuffer __state)
	{
		if (self.IsServer())
		{
			ZNetPeer peer = self.GetPeer(rpc);
			if (peer == null || !peer.IsReady())
			{
				Logger.LogInfo("Peer has disconnected. Skipping initial data send.");
			}
			else
			{
				self.StartCoroutine(SynchronizeInitialData(peer, __state));
			}
		}
	}

	private IEnumerator SynchronizeInitialData(ZNetPeer peer, SocketBuffer socketBuffer)
	{
		Logger.LogInfo($"Sending initial data to peer #{peer.m_uid}");
		foreach (Tuple<CustomRPC, Func<ZNetPeer, ZPackage>> item3 in InitialSync)
		{
			CustomRPC item = item3.Item1;
			Func<ZNetPeer, ZPackage> item2 = item3.Item2;
			ZPackage zPackage = item2(peer);
			if (zPackage != null && zPackage.Size() > 0)
			{
				yield return ZNet.instance.StartCoroutine(item.SendPackageRoutine(peer.m_uid, zPackage));
			}
		}
		if (socketBuffer == null)
		{
			yield break;
		}
		socketBuffer.finished = true;
		ISocket socket = peer.m_rpc.GetSocket();
		for (int i = 0; i < socketBuffer.packages.Count; i++)
		{
			if (i == socketBuffer.versionMatchPackageIndex)
			{
				socket.VersionMatch();
			}
			ZPackage pkg = socketBuffer.packages[i];
			socket.Send(pkg);
		}
		if (socketBuffer.packages.Count == socketBuffer.versionMatchPackageIndex)
		{
			socket.VersionMatch();
		}
	}

	private void SyncedList_Save(SyncedList self)
	{
		if (ZNet.instance != null && self == ZNet.instance.m_adminList)
		{
			SynchronizeAdminStatus();
		}
	}

	private void SyncedList_Load(SyncedList self)
	{
		if (ZNet.instance != null && self == ZNet.instance.m_adminList)
		{
			SynchronizeAdminStatus();
		}
	}

	/// <summary>
	///     Checks the ZNet.m_instance.m_adminList against the cached list and send any
	///     changes to the corresponding clients.
	/// </summary>
	private void SynchronizeAdminStatus()
	{
		if (!ZNet.instance.IsServerInstance() && !ZNet.instance.IsLocalInstance())
		{
			return;
		}
		List<string> list = ZNet.instance.m_adminList.m_list.ToList();
		foreach (string item in list)
		{
			if (!CachedAdminStates.ContainsKey(item))
			{
				SendAdminStateToClient(item, admin: true);
				CachedAdminStates.Add(item, value: true);
			}
			else if (!CachedAdminStates[item])
			{
				SendAdminStateToClient(item, admin: true);
			}
		}
		foreach (string item2 in CachedAdminStates.Keys.ToList())
		{
			if (!list.Contains(item2))
			{
				if (CachedAdminStates[item2])
				{
					SendAdminStateToClient(item2, admin: false);
				}
				CachedAdminStates.Remove(item2);
			}
		}
	}

	/// <summary>
	///     Sends the current admin state of a player on a server to the client
	/// </summary>
	/// <param name="entry">Socket host name of the peer</param>
	/// <param name="admin">Admin state to send to the client</param>
	private void SendAdminStateToClient(string entry, bool admin)
	{
		long? num = ZNet.instance.m_peers.FirstOrDefault((ZNetPeer x) => x.m_socket.GetHostName().EndsWith(entry))?.m_uid;
		if (num.HasValue)
		{
			Logger.LogInfo(string.Format("Sending admin status to {0}/{1} ({2})", entry, num, admin ? "is admin" : "is no admin"));
			ZPackage zPackage = new ZPackage();
			zPackage.Write(admin);
			AdminRPC.SendPackage(num.Value, zPackage);
		}
	}

	private IEnumerator AdminRPC_OnClientReceive(long sender, ZPackage package)
	{
		bool flag = package.ReadBool();
		Logger.LogInfo("Received admin status from server: " + (flag ? "Admin" : "No Admin"));
		Instance.PlayerIsAdmin = flag;
		InvokeOnAdminStatusChanged();
		if (flag)
		{
			UnlockConfigurationEntries();
		}
		else
		{
			LockConfigurationEntries();
		}
		yield break;
	}

	/// <summary>
	///     Safely invoke the <see cref="E:Jotunn.Managers.SynchronizationManager.OnAdminStatusChanged" /> event
	/// </summary>
	private void InvokeOnAdminStatusChanged()
	{
		SynchronizationManager.OnAdminStatusChanged?.SafeInvoke();
	}

	/// <summary>
	///     Gets an IEnumerable of all default and custom config files that associated with plugins that have Jotunn as a dependency.
	/// </summary>
	/// <returns></returns>
	private IEnumerable<ConfigFile> GetConfigFiles()
	{
		Dictionary<string, BaseUnityPlugin> dependentPlugins = BepInExUtils.GetDependentPlugins(includeJotunn: true);
		foreach (BaseUnityPlugin value in dependentPlugins.Values)
		{
			yield return value.Config;
		}
		foreach (ConfigFile value2 in CustomConfigs.Values)
		{
			yield return value2;
		}
	}

	/// <summary>
	///     Checks if AdminOnly config entries should be locked based the AdminOnlyStrictness value for the plugin that the
	///     config file is attached to (including custom config files) and whether the plugin is installed on the server or not.
	/// </summary>
	/// <param name="config"></param>
	/// <returns></returns>
	private bool ShouldManageConfig(ConfigFile config)
	{
		if (!GetPluginGUID(config, out var pluginGUID))
		{
			return false;
		}
		if (!BepInExUtils.GetDependentPlugins().TryGetValue(pluginGUID, out var value))
		{
			return false;
		}
		return ShouldManageConfig(value);
	}

	/// <summary>
	///     Checks if AdminOnly config entries should be locked based the AdminOnlyStrictness value for the plugin
	///     and whether the plugin is installed on the server or not.
	/// </summary>
	/// <param name="plugin"></param>
	/// <returns></returns>
	private bool ShouldManageConfig(BaseUnityPlugin plugin)
	{
		if (ModCompatibility.IsModuleOnServer(plugin))
		{
			return true;
		}
		return plugin.GetSynchronizationModeAttribute()?.ShouldAlwaysEnforceAdminOnly() ?? true;
	}

	private static string GetFileIdentifier(ConfigFile config)
	{
		return config.ConfigFilePath.Replace(BepInEx.Paths.ConfigPath, "").Replace("\\", "/").Trim('/');
	}

	/// <summary>
	///     Gets the corresponding Plugin GUID for a config file (works for custom config files) 
	///     and returns a boolean indicating success or failure.
	/// </summary>
	/// <param name="config"></param>
	/// <param name="pluginGUID"></param>
	private bool GetPluginGUID(ConfigFile config, out string pluginGUID)
	{
		string fileIdentifier = GetFileIdentifier(config);
		return GetPluginGUID(fileIdentifier, out pluginGUID);
	}

	/// <summary>
	///     Gets the corresponding Plugin GUID for a config file identifier (works for custom config files) 
	///     and returns a boolean indicating success or failure.
	/// </summary>
	/// <param name="configFileIdentifier"></param>
	/// <param name="pluginGUID"></param>
	private bool GetPluginGUID(string configFileIdentifier, out string pluginGUID)
	{
		if (IsDefaultModConfig(configFileIdentifier, out pluginGUID))
		{
			return true;
		}
		if (CachedCustomConfigGUIDs.ContainsKey(configFileIdentifier))
		{
			pluginGUID = CachedCustomConfigGUIDs[configFileIdentifier];
			return true;
		}
		return false;
	}

	private ConfigFile GetConfigFile(string identifier)
	{
		if (CustomConfigs.TryGetValue(identifier, out var value))
		{
			return value;
		}
		Dictionary<string, BaseUnityPlugin> dependentPlugins = BepInExUtils.GetDependentPlugins(includeJotunn: true);
		if (IsDefaultModConfig(identifier, out var modGUID) && dependentPlugins.TryGetValue(modGUID, out var value2))
		{
			return value2.Config;
		}
		return null;
	}

	private static bool IsDefaultModConfig(string identifier, out string modGUID)
	{
		if (identifier.EndsWith(".cfg"))
		{
			modGUID = identifier.Substring(0, identifier.Length - 4);
			return Chainloader.PluginInfos.ContainsKey(modGUID);
		}
		modGUID = string.Empty;
		return false;
	}

	/// <summary>
	///     Unlock configuration entries.
	/// </summary>
	private void UnlockConfigurationEntries()
	{
		foreach (ConfigFile configFile in GetConfigFiles())
		{
			foreach (ConfigDefinition key in configFile.Keys)
			{
				ConfigEntryBase configEntry = configFile[key.Section, key.Key];
				ConfigurationManagerAttributes configurationManagerAttributes = configEntry.GetConfigurationManagerAttributes();
				if (configurationManagerAttributes != null && configurationManagerAttributes.IsAdminOnly)
				{
					configurationManagerAttributes.IsUnlocked = true;
				}
			}
		}
	}

	/// <summary>
	///     Lock configuration entries.
	/// </summary>
	private void LockConfigurationEntries()
	{
		foreach (ConfigFile configFile in GetConfigFiles())
		{
			if (!ShouldManageConfig(configFile))
			{
				continue;
			}
			foreach (ConfigDefinition key in configFile.Keys)
			{
				ConfigEntryBase configEntry = configFile[key.Section, key.Key];
				ConfigurationManagerAttributes configurationManagerAttributes = configEntry.GetConfigurationManagerAttributes();
				if (configurationManagerAttributes != null && configurationManagerAttributes.IsAdminOnly)
				{
					configurationManagerAttributes.IsUnlocked = false;
				}
			}
		}
	}

	/// <summary>
	///     Hook <see cref="M:Menu.IsVisible" /> to unlock cursor properly and disable camera rotation
	/// </summary>
	/// <param name="result"></param>
	/// <returns></returns>
	private void Menu_IsVisible(ref bool result)
	{
		result = result || ConfigurationManagerWindowShown;
	}

	/// <summary>
	///     Window display state changed event.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void ConfigurationManager_DisplayingWindowChanged(object sender, object e)
	{
		ConfigurationManagerWindowShown = ConfigManagerUtils.DisplayingWindow;
		if (!ConfigurationManagerWindowShown)
		{
			InvokeOnConfigurationWindowClosed();
			SynchronizeChangedConfig();
		}
	}

	/// <summary>
	///     Safely invoke the <see cref="E:Jotunn.Managers.SynchronizationManager.OnConfigurationWindowClosed" /> event
	/// </summary>
	private void InvokeOnConfigurationWindowClosed()
	{
		SynchronizationManager.OnConfigurationWindowClosed?.SafeInvoke();
	}

	/// <summary>
	///     Register ourself to config reload events to trigger synchronizing configs
	/// </summary>
	private void SubscribeToConfigReload()
	{
		foreach (ConfigFile configFile in GetConfigFiles())
		{
			configFile.ConfigReloaded += Config_ConfigReloaded;
		}
	}

	/// <summary>
	///     Un-Register ourself to config reload events to trigger synchronizing configs
	/// </summary>
	private void UnsubscribeToConfigReload()
	{
		foreach (ConfigFile configFile in GetConfigFiles())
		{
			configFile.ConfigReloaded -= Config_ConfigReloaded;
		}
	}

	/// <summary>
	///     Sync the local bep config on reload
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void Config_ConfigReloaded(object sender, EventArgs e)
	{
		SynchronizeChangedConfig();
	}

	/// <summary>
	///     Return the cached local value of a bep config thats locked
	/// </summary>
	private static bool ConfigEntryBase_GetSerializedValue(ConfigEntryBase __instance, ref string __result)
	{
		if (ReadWriteConfigFromDisk() || !__instance.IsSyncable() || __instance.GetLocalValue() == null)
		{
			return true;
		}
		__result = TomlTypeConverter.ConvertToString(__instance.GetLocalValue(), __instance.SettingType);
		return false;
	}

	/// <summary>
	///     Prevent overwriting bep config value when the setting is locked on config file reload
	/// </summary>
	private static bool ConfigEntryBase_SetSerializedValue(ConfigEntryBase __instance)
	{
		if (!ReadWriteConfigFromDisk())
		{
			return !__instance.IsSyncable();
		}
		return true;
	}

	private static bool ReadWriteConfigFromDisk()
	{
		if ((bool)ZNet.instance)
		{
			return ZNet.instance.IsServer();
		}
		return true;
	}

	/// <summary>
	///     Cache the current synchronizable configuration values for comparison
	/// </summary>
	internal void CacheConfigurationValues()
	{
		CachedConfigValues = GetSyncConfigValues();
	}

	/// <summary>
	///     Get syncable configuration values as tuples
	/// </summary>
	/// <returns></returns>
	private HashSet<Tuple<string, string, string, string>> GetSyncConfigValues()
	{
		Logger.LogDebug("Gathering config values");
		HashSet<Tuple<string, string, string, string>> hashSet = new HashSet<Tuple<string, string, string, string>>();
		foreach (ConfigFile configFile in GetConfigFiles())
		{
			string fileIdentifier = GetFileIdentifier(configFile);
			foreach (ConfigDefinition key in configFile.Keys)
			{
				ConfigEntryBase configEntryBase = configFile[key.Section, key.Key];
				ConfigurationManagerAttributes configurationManagerAttributes = configEntryBase.GetConfigurationManagerAttributes();
				if (configurationManagerAttributes != null && configurationManagerAttributes.IsAdminOnly)
				{
					string item = TomlTypeConverter.ConvertToString(configEntryBase.BoxedValue, configEntryBase.SettingType);
					Tuple<string, string, string, string> item2 = new Tuple<string, string, string, string>(fileIdentifier, key.Section, key.Key, item);
					hashSet.Add(item2);
				}
			}
		}
		return hashSet;
	}

	/// <summary>
	///     Syncs the changed configuration of a client to the server
	/// </summary>
	internal void SynchronizeChangedConfig()
	{
		HashSet<Tuple<string, string, string, string>> hashSet = new HashSet<Tuple<string, string, string, string>>();
		foreach (ConfigFile configFile in GetConfigFiles())
		{
			string fileIdentifier = GetFileIdentifier(configFile);
			foreach (ConfigDefinition key in configFile.Keys)
			{
				ConfigEntryBase configEntryBase = configFile[key];
				ConfigurationManagerAttributes configurationManagerAttributes = configEntryBase.GetConfigurationManagerAttributes();
				if (configurationManagerAttributes != null && configurationManagerAttributes.IsAdminOnly)
				{
					string item = TomlTypeConverter.ConvertToString(configEntryBase.BoxedValue, configEntryBase.SettingType);
					Tuple<string, string, string, string> item2 = new Tuple<string, string, string, string>(fileIdentifier, key.Section, key.Key, item);
					hashSet.Add(item2);
				}
				InputUtils.SetInputButtons(configEntryBase);
			}
		}
		hashSet = new HashSet<Tuple<string, string, string, string>>(hashSet.Where((Tuple<string, string, string, string> x) => !CachedConfigValues.Contains(x)));
		if (hashSet.Count <= 0)
		{
			return;
		}
		if (ZNet.instance != null)
		{
			ZPackage package = GenerateConfigZPackage(initial: false, hashSet.ToList());
			if (ZNet.instance.IsClientInstance())
			{
				InvokeOnSyncingConfiguration();
				ConfigRPC.SendPackage(ZRoutedRpc.instance.GetServerPeerID(), package);
				HashSet<string> hashSet2 = new HashSet<string>();
				foreach (Tuple<string, string, string, string> item3 in hashSet)
				{
					if (GetPluginGUID(item3.Item1, out var pluginGUID))
					{
						hashSet2.Add(pluginGUID);
					}
				}
				InvokeOnConfigurationSynchronized(initial: false, hashSet2);
			}
			else
			{
				ConfigRPC.SendPackage(ZNet.instance.m_peers, package);
			}
		}
		CacheConfigurationValues();
	}

	private void SetToDefaultConfigEntries()
	{
		foreach (ConfigFile configFile in GetConfigFiles())
		{
			if (!ShouldManageConfig(configFile))
			{
				continue;
			}
			foreach (ConfigDefinition key in configFile.Keys)
			{
				ConfigEntryBase configEntryBase = configFile[key.Section, key.Key];
				ConfigurationManagerAttributes configurationManagerAttributes = configEntryBase.GetConfigurationManagerAttributes();
				if (configurationManagerAttributes != null && configurationManagerAttributes.IsAdminOnly)
				{
					configEntryBase.BoxedValue = configEntryBase.DefaultValue;
				}
			}
		}
	}

	private IEnumerator ConfigRPC_OnClientReceive(long sender, ZPackage package)
	{
		InvokeOnSyncingConfiguration();
		package.ReadByte();
		package.SetPos(0);
		ApplyConfigZPackage(package, out var initial, out var pluginGUIDs);
		InvokeOnConfigurationSynchronized(initial, pluginGUIDs);
		yield break;
	}

	private IEnumerator ConfigRPC_OnServerReceive(long sender, ZPackage package)
	{
		if (ZNet.instance.IsAdmin(sender))
		{
			Logger.LogInfo($"Received configuration data from client {sender}");
			InvokeOnSyncingConfiguration();
			ApplyConfigZPackage(package, out var initial, out var pluginGUIDs);
			InvokeOnConfigurationSynchronized(initial, pluginGUIDs);
			ConfigRPC.SendPackage(ZNet.instance.m_peers.Where((ZNetPeer x) => x.m_uid != sender).ToList(), package);
		}
		yield break;
	}

	/// <summary>
	///     Safely invoke the <see cref="E:Jotunn.Managers.SynchronizationManager.OnConfigurationSynchronized" /> event
	/// </summary>
	private void InvokeOnConfigurationSynchronized(bool initial, HashSet<string> pluginGUIDs)
	{
		SynchronizationManager.OnConfigurationSynchronized?.SafeInvoke(this, new ConfigurationSynchronizationEventArgs
		{
			InitialSynchronization = initial,
			UpdatedPluginGUIDs = pluginGUIDs
		});
	}

	/// <summary>
	///     Safely invoke the <see cref="E:Jotunn.Managers.SynchronizationManager.OnSyncingConfiguration" /> event
	/// </summary>
	private void InvokeOnSyncingConfiguration()
	{
		SynchronizationManager.OnSyncingConfiguration?.SafeInvoke(this, new SyncingConfigurationEventArgs());
	}

	/// <summary>
	///     Apply received configuration values locally and regenerate the cache
	/// </summary>
	/// <param name="configPkg">Package of config tuples</param>
	/// <param name="initial">Indicator if this was an initial config package</param>
	/// <param name="pluginGUIDs">Indicator if this was an initial config package</param>
	private void ApplyConfigZPackage(ZPackage configPkg, out bool initial, out HashSet<string> pluginGUIDs)
	{
		initial = (configPkg.ReadByte() & 0x40) != 0;
		pluginGUIDs = new HashSet<string>();
		Logger.LogDebug("Applying" + (initial ? " initial" : null) + " configuration data package");
		int num = configPkg.ReadInt();
		if (num == 0)
		{
			return;
		}
		while (num > 0)
		{
			string text = configPkg.ReadString();
			string text2 = configPkg.ReadString();
			string text3 = configPkg.ReadString();
			string value = configPkg.ReadString();
			if (GetPluginGUID(text, out var pluginGUID))
			{
				pluginGUIDs.Add(pluginGUID);
			}
			ConfigFile configFile = GetConfigFile(text);
			if (configFile != null)
			{
				if (configFile.Keys.Contains(new ConfigDefinition(text2, text3)))
				{
					ConfigEntryBase configEntryBase = configFile[text2, text3];
					if (configEntryBase.IsSyncable())
					{
						configEntryBase.BoxedValue = TomlTypeConverter.ConvertToValue(value, configEntryBase.SettingType);
						InputUtils.SetInputButtons(configEntryBase);
					}
					else
					{
						Logger.LogWarning("Setting for Identifier: " + text + ", Section " + text2 + ", Key " + text3 + " is not syncable");
					}
				}
				else
				{
					Logger.LogWarning("Did not find Value for Identifier: " + text + ", Section " + text2 + ", Key " + text3);
				}
			}
			else if (modNotLoadedConfigsWarnings.Add(text))
			{
				Logger.LogWarning("No config file with Identifier " + text + " is loaded, cannot apply synced values");
			}
			num--;
		}
		CacheConfigurationValues();
	}

	/// <summary>
	///     Generate ZPackage from configuration tuples
	/// </summary>
	/// <param name="initial">Indicator if this is the initial config package</param>
	/// <param name="values">List of config tuples to include in the package</param>
	/// <returns></returns>
	private ZPackage GenerateConfigZPackage(bool initial, List<Tuple<string, string, string, string>> values)
	{
		ZPackage zPackage = new ZPackage();
		zPackage.Write((byte)(initial ? 64 : 0));
		int count = values.Count;
		zPackage.Write(count);
		foreach (Tuple<string, string, string, string> value in values)
		{
			zPackage.Write(value.Item1);
			zPackage.Write(value.Item2);
			zPackage.Write(value.Item3);
			zPackage.Write(value.Item4);
		}
		return zPackage;
	}

	private bool Socket_VersionMatch(ISocket __instance)
	{
		string endPointString = __instance.GetEndPointString();
		if (string.IsNullOrEmpty(endPointString) || !socketBuffers.TryGetValue(endPointString, out var value) || value.finished)
		{
			return true;
		}
		value.versionMatchPackageIndex = value.packages.Count;
		return false;
	}

	private bool Socket_Send(ISocket __instance, ZPackage pkg)
	{
		string endPointString = __instance.GetEndPointString();
		if (string.IsNullOrEmpty(endPointString) || !socketBuffers.TryGetValue(endPointString, out var value) || value.finished)
		{
			return true;
		}
		int methodHash = GetMethodHash(pkg);
		if (methodHash == StringExtensionMethods.GetStableHashCode("PeerInfo") || methodHash == StringExtensionMethods.GetStableHashCode("RoutedRPC") || methodHash == StringExtensionMethods.GetStableHashCode("ZDOData"))
		{
			value.packages.Add(CopyZPackage(pkg));
			return false;
		}
		return true;
	}

	internal static int GetMethodHash(ZPackage pkg)
	{
		int pos = pkg.GetPos();
		pkg.SetPos(0);
		int result = pkg.ReadInt();
		pkg.SetPos(pos);
		return result;
	}

	internal static ZPackage CopyZPackage(ZPackage pkg)
	{
		ZPackage zPackage = new ZPackage(pkg.GetArray());
		zPackage.SetPos(pkg.GetPos());
		return zPackage;
	}
}
