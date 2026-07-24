using BepInEx;
using HarmonyLib;
using Jotunn.Managers;
using Jotunn.Utils;
using SoftReferenceableAssets;
using UnityEngine;

namespace Jotunn;

/// <summary>
///     Main class implementing BaseUnityPlugin.
/// </summary>
[BepInPlugin("com.jotunn.jotunn", "Jotunn", "2.29.2")]
[BepInDependency("com.bepis.bepinex.configurationmanager", BepInDependency.DependencyFlags.SoftDependency)]
[BepInDependency("com.maxsch.valheim.LocalizationCache", BepInDependency.DependencyFlags.SoftDependency)]
[NetworkCompatibility(CompatibilityLevel.VersionCheckOnly, VersionStrictness.Patch)]
public class Main : BaseUnityPlugin
{
	/// <summary>
	///     The current version of the Jotunn library.
	/// </summary>
	public const string Version = "2.29.2";

	/// <summary>
	///     The name of the library.
	/// </summary>
	public const string ModName = "Jotunn";

	/// <summary>
	///     The BepInEx plugin Mod GUID being used (com.jotunn.jotunn).
	/// </summary>
	public const string ModGuid = "com.jotunn.jotunn";

	internal static Main Instance;

	internal static Harmony Harmony = new Harmony("com.jotunn.jotunn");

	private static GameObject rootObject;

	internal static GameObject RootObject => GetRootObject();

	private void Awake()
	{
		Instance = this;
		GetRootObject();
		ModCompatibility.Init();
		((IManager)SynchronizationManager.Instance).Init();
		Runtime.MakeAllAssetsLoadable();
		Game.isModded = true;
	}

	private void Start()
	{
		PatchInit.InitializePatches();
		AutomaticLocalizationsLoading.Init();
	}

	private void OnApplicationQuit()
	{
		AssetBundle.UnloadAllAssetBundles(false);
	}

	private static GameObject GetRootObject()
	{
		if ((bool)rootObject)
		{
			return rootObject;
		}
		rootObject = new GameObject("_JotunnRoot");
		Object.DontDestroyOnLoad(rootObject);
		return rootObject;
	}

	internal static void LogInit(string module)
	{
		Jotunn.Logger.LogInfo("Initializing " + module);
		if (!Instance)
		{
			string data = module + " was accessed before Jotunn Awake, this can cause unexpected behaviour. Please make sure to add `[BepInDependency(Jotunn.Main.ModGuid)]` next to your BaseUnityPlugin";
			Jotunn.Logger.LogWarning(BepInExUtils.GetSourceModMetadata(), data);
		}
	}
}
