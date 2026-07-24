using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BepInEx;
using BepInEx.Bootstrap;
using HarmonyLib;
using Jotunn.Entities;
using Jotunn.Extensions;
using Jotunn.Managers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Jotunn.Utils;

/// <summary>
///     Implementation of the mod compatibility features.
/// </summary>
public static class ModCompatibility
{
	/// <summary>
	///     Stores the last server message.
	/// </summary>
	private static ServerVersionData LastServerVersionData = new ServerVersionData();

	private static readonly Dictionary<string, ZPackage> ClientVersions = new Dictionary<string, ZPackage>();

	internal static void Init()
	{
		Main.LogInit("ModCompatibility");
		Main.Harmony.PatchAll(typeof(ModCompatibility));
	}

	/// <summary>
	///     Check if a mod is installed and loaded on the server.<br />
	///     Can be called from both client and server.
	/// </summary>
	/// <param name="plugin">BepInEx mod to check</param>
	/// <returns>true if the mod is loaded on the server.<br />false if the mod is not loaded on the server or no server connection is established</returns>
	public static bool IsModuleOnServer(BaseUnityPlugin plugin)
	{
		return IsModuleOnServer(plugin.Info.Metadata.GUID);
	}

	/// <summary>
	///     Check if a mod is installed and loaded on the server.<br />
	///     Can be called from both client and server.
	/// </summary>
	/// <param name="modGUID">BepInEx mod GUID to check</param>
	/// <returns>true if the mod is loaded on the server.<br />false if the mod is not loaded on the server or no server connection is established</returns>
	public static bool IsModuleOnServer(string modGUID)
	{
		if ((bool)ZNet.instance)
		{
			if (ZNet.instance.IsClientInstance())
			{
				if (LastServerVersionData.IsValid())
				{
					return LastServerVersionData.moduleGUIDs.Contains(modGUID);
				}
				return false;
			}
			if (ZNet.instance.IsServer())
			{
				return Chainloader.PluginInfos.ContainsKey(modGUID);
			}
		}
		return false;
	}

	/// <summary>
	///     Check if Jotunn is installed and loaded on the server.<br />
	///     Can be called from both client and server.
	/// </summary>
	/// <returns>true if Jotunn is loaded on the server.<br />false if Jotunn is not loaded on the server or no server connection is established</returns>
	public static bool IsJotunnOnServer()
	{
		return IsModuleOnServer("com.jotunn.jotunn");
	}

	[HarmonyPatch(typeof(ZNet), "OnNewConnection")]
	[HarmonyPrefix]
	[HarmonyPriority(800)]
	private static void ZNet_OnNewConnection(ZNet __instance, ZNetPeer peer)
	{
		LastServerVersionData.Reset();
		peer.m_rpc.Register<ZPackage>("RPC_Jotunn_ReceiveVersionData", RPC_Jotunn_ReceiveVersionData);
	}

	[HarmonyPatch(typeof(ZNet), "RPC_ClientHandshake")]
	[HarmonyPrefix]
	[HarmonyPriority(800)]
	private static void ZNet_RPC_ClientHandshake(ZNet __instance, ZRpc rpc)
	{
		rpc.Invoke("RPC_Jotunn_ReceiveVersionData", new ModuleVersionData(GetEnforcableMods().ToList()).ToZPackage());
	}

	[HarmonyPatch(typeof(ZNet), "RPC_ServerHandshake")]
	[HarmonyPrefix]
	[HarmonyPriority(800)]
	private static void ZNet_RPC_ServerHandshake(ZNet __instance, ZRpc rpc)
	{
		rpc.Invoke("RPC_Jotunn_ReceiveVersionData", new ModuleVersionData(GetEnforcableMods().ToList()).ToZPackage());
	}

	[HarmonyPatch(typeof(FejdStartup), "ShowConnectError")]
	[HarmonyPostfix]
	[HarmonyPriority(0)]
	private static void FejdStartup_ShowConnectError(FejdStartup __instance)
	{
		if (LastServerVersionData.IsValid() && ZNet.m_connectionStatus == ZNet.ConnectionStatus.ErrorVersion)
		{
			string text = __instance.m_connectionFailedError.text;
			__instance.StartCoroutine(ShowModCompatibilityErrorMessage(text));
			__instance.m_connectionFailedPanel.SetActive(value: false);
		}
	}

	[HarmonyPatch(typeof(ZNet), "SendPeerInfo")]
	[HarmonyPrefix]
	[HarmonyPriority(800)]
	private static bool ZNet_SendPeerInfo(ZNet __instance, ZRpc rpc, string password)
	{
		if (ZNet.instance.IsClientInstance() && !LastServerVersionData.IsValid() && GetEnforcableMods().Any((ModModule x) => x.IsNeededOnServer()))
		{
			string text = string.Join(Environment.NewLine, from x in GetEnforcableMods()
				where x.IsNeededOnServer()
				select x.ModName);
			Logger.LogWarning("Jötunn is not installed on the server. Client has mandatory mods, cancelling connection. Mods that need to be installed on the server:" + Environment.NewLine + text);
			rpc.Invoke("Disconnect");
			LastServerVersionData = new ServerVersionData(new List<ModModule>());
			ZNet.m_connectionStatus = ZNet.ConnectionStatus.ErrorVersion;
			return false;
		}
		return true;
	}

	[HarmonyPatch(typeof(ZNet), "RPC_PeerInfo")]
	[HarmonyPrefix]
	[HarmonyPriority(800)]
	private static bool ZNet_RPC_PeerInfo(ZNet __instance, ZRpc rpc, ZPackage pkg)
	{
		if (!ZNet.instance.IsClientInstance())
		{
			if (!ClientVersions.ContainsKey(rpc.GetSocket().GetEndPointString()))
			{
				if (GetEnforcableMods().Any((ModModule x) => x.IsNeededOnClient()))
				{
					string text = string.Join(Environment.NewLine, from x in GetEnforcableMods()
						where x.IsNeededOnClient()
						select x.ModName);
					Logger.LogWarning("Jötunn is not installed on the client. Server has mandatory mods, cancelling connection. Mods that need to be installed on the client:" + Environment.NewLine + text);
					rpc.Invoke("Error", 3);
					return false;
				}
			}
			else
			{
				ModuleVersionData serverData = new ModuleVersionData(GetEnforcableMods().ToList());
				ModuleVersionData clientData = new ModuleVersionData(ClientVersions[rpc.m_socket.GetEndPointString()]);
				if (!CompareVersionData(serverData, clientData))
				{
					Logger.LogWarning("RPC_PeerInfo: Disconnecting modded client with incompatible version message. Mods are not compatible");
					rpc.Invoke("Error", 3);
					return false;
				}
			}
		}
		return true;
	}

	/// <summary>
	///     Store server's message.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="data"></param>
	private static void RPC_Jotunn_ReceiveVersionData(ZRpc sender, ZPackage data)
	{
		Logger.LogDebug("Received Version package from " + sender.m_socket.GetEndPointString());
		if (!ZNet.instance.IsClientInstance())
		{
			ClientVersions[sender.m_socket.GetEndPointString()] = data;
			ModuleVersionData serverData = new ModuleVersionData(GetEnforcableMods().ToList());
			ModuleVersionData clientData = new ModuleVersionData(data);
			if (!CompareVersionData(serverData, clientData))
			{
				Logger.LogWarning("RPC_Jotunn_ReceiveVersionData: Disconnecting modded client with incompatible version message. Mods are not compatible");
				sender.Invoke("Error", 3);
			}
		}
		else
		{
			LastServerVersionData = new ServerVersionData(data);
		}
	}

	/// <summary>
	///     Compares version data on server and client.
	/// </summary>
	/// <param name="serverData"></param>
	/// <param name="clientData"></param>
	/// <returns></returns>
	internal static bool CompareVersionData(ModuleVersionData serverData, ModuleVersionData clientData)
	{
		if (serverData == clientData)
		{
			return true;
		}
		bool result = true;
		if (!clientData.IsSupportedDataLayout)
		{
			Logger.LogWarning("Jotunn version on client is higher than server version: 2.29.2");
			result = false;
		}
		if (!serverData.IsSupportedDataLayout)
		{
			Logger.LogWarning("Jotunn version on server is higher than client version: 2.29.2");
			result = false;
		}
		foreach (ModModule item in FindNotInstalledMods(serverData, clientData))
		{
			Logger.LogWarning("Missing mod on client: " + item.ModName);
			result = false;
		}
		foreach (ModModule item2 in FindAdditionalMods(serverData, clientData))
		{
			Logger.LogWarning("Client loaded additional mod: " + item2.ModName);
			result = false;
		}
		bool legacyDataLayout = Mathf.Min(serverData.ModModuleDataLayout, clientData.ModModuleDataLayout) == 0;
		foreach (ModModule item3 in FindLowerVersionMods(serverData, clientData).Union(FindHigherVersionMods(serverData, clientData)))
		{
			ModModule modModule = clientData.FindModule(item3, legacyDataLayout);
			Logger.LogWarning($"Mod version mismatch {item3.ModName}: Server {item3.Version}, Client {modModule.Version}");
			result = false;
		}
		return result;
	}

	private static CompatibilityWindow LoadCompatWindow()
	{
		CustomLocalization jotunnLocalization = LocalizationManager.Instance.JotunnLocalization;
		jotunnLocalization.AddJsonFile("English", AssetUtils.LoadTextFromResources("English.json", typeof(Main).Assembly));
		jotunnLocalization.AddJsonFile("German", AssetUtils.LoadTextFromResources("German.json", typeof(Main).Assembly));
		AssetBundle val = AssetUtils.LoadAssetBundleFromResources("modcompat", typeof(Main).Assembly);
		GameObject gameObject = UnityEngine.Object.Instantiate(val.LoadAsset<GameObject>("CompatibilityWindow"), GUIManager.CustomGUIFront.transform);
		val.Unload(false);
		CompatibilityWindow component = gameObject.GetComponent<CompatibilityWindow>();
		RectTransform rectTransform = (RectTransform)component.transform;
		Text[] componentsInChildren = component.GetComponentsInChildren<Text>();
		foreach (Text val2 in componentsInChildren)
		{
			GUIManager.Instance.ApplyTextStyle(val2, 18);
			val2.text = Localization.instance.Localize(val2.text);
		}
		GUIManager.Instance.ApplyWoodpanelStyle(component.transform);
		GUIManager.Instance.ApplyScrollRectStyle(component.scrollRect);
		GUIManager.Instance.ApplyButtonStyle(component.continueButton);
		GUIManager.Instance.ApplyButtonStyle(component.logFileButton);
		GUIManager.Instance.ApplyButtonStyle(component.troubleshootingButton);
		rectTransform.anchoredPosition = new Vector2(25f, 0f);
		component.gameObject.SetWidth(1000f);
		component.gameObject.SetHeight(600f);
		return component;
	}

	/// <summary>
	///     Create and show mod compatibility error message
	/// </summary>
	private static IEnumerator ShowModCompatibilityErrorMessage(string failedConnectionText)
	{
		CompatibilityWindow compatWindow = LoadCompatWindow();
		ModuleVersionData moduleVersionData = LastServerVersionData.moduleVersionData;
		ModuleVersionData moduleVersionData2 = new ModuleVersionData(GetEnforcableMods().ToList());
		CompareVersionData(moduleVersionData, moduleVersionData2);
		compatWindow.failedConnection.text = ColoredLine(GUIManager.Instance.ValheimOrange, "$mod_compat_header_failed_connection") + failedConnectionText.Trim();
		compatWindow.localVersion.text = ColoredLine(GUIManager.Instance.ValheimOrange, "$mod_compat_header_local_version") + moduleVersionData2.ToString(showEnforce: false).Trim();
		compatWindow.remoteVersion.text = ColoredLine(GUIManager.Instance.ValheimOrange, "$mod_compat_header_remote_version") + moduleVersionData.ToString(showEnforce: false).Trim();
		compatWindow.errorMessages.text = CreateErrorMessage(moduleVersionData, moduleVersionData2).Trim();
		compatWindow.transform.localScale = Vector3.zero;
		yield return null;
		compatWindow.transform.localScale = Vector3.one;
		compatWindow.UpdateTextPositions();
		((UnityEvent)(object)compatWindow.continueButton.onClick).AddListener((UnityAction)delegate
		{
			UnityEngine.Object.Destroy(compatWindow.gameObject);
		});
		((UnityEvent)(object)compatWindow.logFileButton.onClick).AddListener((UnityAction)OpenLogFile);
		((UnityEvent)(object)compatWindow.troubleshootingButton.onClick).AddListener((UnityAction)OpenTroubleshootingPage);
		compatWindow.scrollRect.verticalNormalizedPosition = 1f;
		LastServerVersionData.Reset();
	}

	private static void OpenLogFile()
	{
		Application.OpenURL(BepInEx.Paths.BepInExRootPath);
	}

	private static void OpenTroubleshootingPage()
	{
		Application.OpenURL("https://github.com/Valheim-Modding/Wiki/wiki/Server-Troubleshooting");
	}

	/// <summary>
	///     Create the error message(s) from the server and client message data
	/// </summary>
	/// <param name="serverData">server data</param>
	/// <param name="clientData">client data</param>
	/// <returns></returns>
	private static string CreateErrorMessage(ModuleVersionData serverData, ModuleVersionData clientData)
	{
		return CreateVanillaVersionErrorMessage(serverData, clientData) + CreateNotInstalledErrorMessage(serverData, clientData) + CreateLowerVersionErrorMessage(serverData, clientData) + CreateHigherVersionErrorMessage(serverData, clientData) + CreateAdditionalModsErrorMessage(serverData, clientData) + CreateFurtherStepsMessage();
	}

	private static string CreateModModuleLayoutErrorMessage(ModuleVersionData serverData, ModuleVersionData clientData)
	{
		if (!clientData.IsSupportedDataLayout)
		{
			return ColoredLine(Color.red, "Jotunn version on client is higher than server version: 2.29.2");
		}
		if (!serverData.IsSupportedDataLayout)
		{
			return ColoredLine(Color.red, "Jotunn version on server is higher than client version: 2.29.2");
		}
		if (serverData.ModModuleDataLayout != clientData.ModModuleDataLayout)
		{
			return ColoredLine(Color.red, "Jotunn versions on server and client are not compatible.");
		}
		return string.Empty;
	}

	private static string CreateVanillaVersionErrorMessage(ModuleVersionData serverData, ModuleVersionData clientData)
	{
		if (serverData.NetworkVersion == 0 || clientData.NetworkVersion == 0)
		{
			return string.Empty;
		}
		if (serverData.NetworkVersion > clientData.NetworkVersion)
		{
			return ColoredLine(Color.red, "$mod_compat_header_valheim_version") + ColoredLine(GUIManager.Instance.ValheimOrange, "$mod_compat_valheim_version_error_description", $"{serverData.NetworkVersion}", $"{clientData.NetworkVersion}") + ColoredLine(Color.white, "$mod_compat_valheim_version_upgrade") + Environment.NewLine;
		}
		if (serverData.NetworkVersion < clientData.NetworkVersion)
		{
			return ColoredLine(Color.red, "$mod_compat_header_valheim_version") + ColoredLine(GUIManager.Instance.ValheimOrange, "$mod_compat_valheim_version_error_description", $"{serverData.NetworkVersion}", $"{clientData.NetworkVersion}") + ColoredLine(Color.white, "$mod_compat_valheim_version_downgrade") + Environment.NewLine;
		}
		return string.Empty;
	}

	private static string CreateNotInstalledErrorMessage(ModuleVersionData serverData, ModuleVersionData clientData)
	{
		List<ModModule> list = FindNotInstalledMods(serverData, clientData);
		if (list.Count == 0)
		{
			return string.Empty;
		}
		return ColoredLine(Color.red, "$mod_compat_header_missing_mods") + ColoredLine(GUIManager.Instance.ValheimOrange, "$mod_compat_missing_mods_description") + string.Join("", list.Select((ModModule serverModule) => ColoredLine(Color.white, "$mod_compat_missing_mod", serverModule.ModName ?? "", $"{serverModule.Version}"))) + Environment.NewLine;
	}

	private static string CreateLowerVersionErrorMessage(ModuleVersionData serverData, ModuleVersionData clientData)
	{
		List<ModModule> list = FindLowerVersionMods(serverData, clientData);
		if (list.Count == 0)
		{
			return string.Empty;
		}
		return ColoredLine(Color.red, "$mod_compat_header_update_needed") + string.Join("", list.Select((ModModule serverModule) => ColoredLine(Color.white, "$mod_compat_mod_update", serverModule.ModName, serverModule.GetVersionString()))) + Environment.NewLine;
	}

	private static string CreateHigherVersionErrorMessage(ModuleVersionData serverData, ModuleVersionData clientData)
	{
		List<ModModule> list = FindHigherVersionMods(serverData, clientData);
		if (list.Count == 0)
		{
			return string.Empty;
		}
		return ColoredLine(Color.red, "$mod_compat_header_downgrade_needed") + string.Join("", list.Select((ModModule serverModule) => ColoredLine(Color.white, "$mod_compat_mod_downgrade", serverModule.ModName, serverModule.GetVersionString()))) + Environment.NewLine;
	}

	private static string CreateAdditionalModsErrorMessage(ModuleVersionData serverData, ModuleVersionData clientData)
	{
		List<ModModule> list = FindAdditionalMods(serverData, clientData);
		if (list.Count == 0)
		{
			return string.Empty;
		}
		return ColoredLine(Color.red, "$mod_compat_header_additional_mods") + ColoredLine(GUIManager.Instance.ValheimOrange, "$mod_compat_additional_mods_description") + string.Join("", list.Select((ModModule clientModule) => ColoredLine(Color.white, "$mod_compat_additional_mod", clientModule.ModName, $"{clientModule.Version}"))) + Environment.NewLine;
	}

	private static string CreateFurtherStepsMessage()
	{
		return ColoredLine(GUIManager.Instance.ValheimOrange, "$mod_compat_header_further_steps") + ColoredLine(Color.white, "$mod_compat_further_steps_description") + Environment.NewLine;
	}

	private static List<ModModule> FindNotInstalledMods(ModuleVersionData serverData, ModuleVersionData clientData)
	{
		return FindMods(serverData, clientData, (ModModule serverModule, ModModule clientModule) => serverModule.IsNeededOnClient() && clientModule == null).ToList();
	}

	private static List<ModModule> FindAdditionalMods(ModuleVersionData serverData, ModuleVersionData clientData)
	{
		return FindMods(clientData, serverData, (ModModule clientModule, ModModule serverModule) => clientModule.IsNeededOnServer() && serverModule == null).ToList();
	}

	private static List<ModModule> FindLowerVersionMods(ModuleVersionData serverData, ModuleVersionData clientData)
	{
		return FindMods(serverData, clientData, (ModModule serverModule, ModModule clientModule) => clientModule != null && ModModule.IsLowerVersion(serverModule, clientModule, serverModule.VersionStrictness)).ToList();
	}

	private static List<ModModule> FindHigherVersionMods(ModuleVersionData serverData, ModuleVersionData clientData)
	{
		return FindMods(serverData, clientData, (ModModule serverModule, ModModule clientModule) => clientModule != null && ModModule.IsLowerVersion(clientModule, serverModule, serverModule.VersionStrictness)).ToList();
	}

	private static IEnumerable<ModModule> FindMods(ModuleVersionData baseModules, ModuleVersionData additionalModules, Func<ModModule, ModModule, bool> predicate)
	{
		bool legacyDataLayout = Mathf.Min(baseModules.ModModuleDataLayout, additionalModules.ModModuleDataLayout) == 0;
		foreach (ModModule module in baseModules.Modules)
		{
			ModModule arg = additionalModules.FindModule(module, legacyDataLayout);
			if (predicate(module, arg))
			{
				yield return module;
			}
		}
	}

	/// <summary>
	///     Get module.
	/// </summary>
	/// <returns></returns>
	internal static IEnumerable<ModModule> GetEnforcableMods()
	{
		foreach (KeyValuePair<string, BaseUnityPlugin> item in from x in BepInExUtils.GetDependentPlugins(includeJotunn: true)
			orderby x.Key
			select x)
		{
			NetworkCompatibilityAttribute networkCompatibilityAttribute = item.Value.GetNetworkCompatibilityAttribute();
			if (networkCompatibilityAttribute != null)
			{
				yield return new ModModule(item.Value.Info.Metadata, networkCompatibilityAttribute);
			}
			else
			{
				yield return new ModModule(item.Value.Info.Metadata);
			}
		}
	}

	private static string ColoredLine(Color color, string inner, params string[] words)
	{
		return "<color=#" + ColorUtility.ToHtmlStringRGB(color) + ">" + Localization.instance.Localize(inner, words) + "</color>" + Environment.NewLine;
	}
}
