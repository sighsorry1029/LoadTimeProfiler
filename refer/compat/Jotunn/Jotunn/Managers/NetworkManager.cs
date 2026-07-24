using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BepInEx;
using HarmonyLib;
using Jotunn.Entities;
using Jotunn.Utils;

namespace Jotunn.Managers;

/// <summary>
///     Manager handling all network related code
/// </summary>
public class NetworkManager : IManager
{
	/// <summary>
	///     Delegate for receiving <see cref="T:ZPackage">ZPackages</see>.
	///     Gets called inside a <see cref="T:UnityEngine.Coroutine" />.
	/// </summary>
	/// <param name="sender">Sender ID of the package</param>
	/// <param name="package">Package sent</param>
	/// <returns></returns>
	public delegate IEnumerator CoroutineHandler(long sender, ZPackage package);

	private static class Patches
	{
		[HarmonyPatch(typeof(Game), "Start")]
		[HarmonyPostfix]
		private static void Game_Start()
		{
			Instance.Game_Start();
		}
	}

	private static NetworkManager _instance;

	/// <summary>
	///     Internal list of registered RPCs
	/// </summary>
	internal readonly List<CustomRPC> RPCs = new List<CustomRPC>();

	/// <summary>
	///     Singleton instance
	/// </summary>
	public static NetworkManager Instance => _instance ?? (_instance = new NetworkManager());

	/// <summary>
	///     Hide .ctor
	/// </summary>
	private NetworkManager()
	{
	}

	static NetworkManager()
	{
		((IManager)Instance).Init();
	}

	/// <summary>
	///     Manager's main init
	/// </summary>
	void IManager.Init()
	{
		Main.LogInit("NetworkManager");
		Main.Harmony.PatchAll(typeof(Patches));
	}

	/// <summary>
	///     Get a <see cref="T:Jotunn.Entities.CustomRPC" /> for your mod
	/// </summary>
	/// <param name="name">Unique name for your RPC</param>
	/// <param name="serverReceive">Delegate which gets called on client instances when packages are received</param>
	/// <param name="clientReceive">Delegate which gets called on server instances when packages are received</param>
	/// <returns>Existing or newly created <see cref="T:Jotunn.Entities.CustomRPC" /></returns>
	public CustomRPC AddRPC(string name, CoroutineHandler serverReceive, CoroutineHandler clientReceive)
	{
		return AddRPC(BepInExUtils.GetSourceModMetadata(), name, serverReceive, clientReceive);
	}

	/// <summary>
	///     Get the <see cref="T:Jotunn.Entities.CustomRPC" /> for a given mod.
	/// </summary>
	/// <param name="sourceMod">Reference to the <see cref="T:BepInEx.BepInPlugin" /> which added this entity</param>
	/// <param name="name">Unique name for your RPC</param>
	/// <param name="serverReceive">Delegate which gets called on client instances when packages are received</param>
	/// <param name="clientReceive">Delegate which gets called on server instances when packages are received</param>
	/// <returns>Existing or newly created <see cref="T:Jotunn.Entities.CustomRPC" />.</returns>
	internal CustomRPC AddRPC(BepInPlugin sourceMod, string name, CoroutineHandler serverReceive, CoroutineHandler clientReceive)
	{
		CustomRPC customRPC = RPCs.FirstOrDefault((CustomRPC x) => x.SourceMod == sourceMod && x.Name == name);
		if (customRPC != null)
		{
			return customRPC;
		}
		customRPC = new CustomRPC(sourceMod, name, serverReceive, clientReceive);
		RPCs.Add(customRPC);
		return customRPC;
	}

	/// <summary>
	///     Register all custom RPCs as <see cref="T:ZRoutedRpc">ZRoutedRPCs</see>
	/// </summary>
	private void Game_Start()
	{
		if (!RPCs.Any())
		{
			return;
		}
		Logger.LogInfo($"Registering {RPCs.Count} custom RPCs");
		foreach (CustomRPC rPC in RPCs)
		{
			ZRoutedRpc.instance.Register<ZPackage>(rPC.ID, rPC.ReceivePackage);
		}
	}
}
