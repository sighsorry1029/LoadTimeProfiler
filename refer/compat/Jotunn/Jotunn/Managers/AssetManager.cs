using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using BepInEx;
using HarmonyLib;
using Jotunn.Extensions;
using Jotunn.Utils;
using SoftReferenceableAssets;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

namespace Jotunn.Managers;

/// <summary>
///     Manager to handle interactions with the vanilla asset system, called SoftReferenceableAssets.
///     See the <a href="https://valheim.com/support/modding-faq-for-the-asset-bundle-update-0-217-40/">Vanilla FAQ</a> for more information.
/// </summary>
public class AssetManager : IManager
{
	private static class Patches
	{
		[HarmonyPatch(typeof(AssetBundleLoader), "OnInitCompleted")]
		[HarmonyPostfix]
		private static void AssetBundleLoader_Load(AssetBundleLoader __instance)
		{
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			foreach (KeyValuePair<AssetID, AssetRef> asset in Instance.assets)
			{
				AddAssetToBundleLoader(__instance, asset.Key, asset.Value);
			}
			AssetManager.OnSoftReferenceableAssetsReady?.SafeInvoke();
		}

		[HarmonyPatch(typeof(AssetBundleLoader), "InitializeDataSide")]
		[HarmonyPrefix]
		private static void AssetBundleLoader_InitializeDataSide(ref bool allAssetsLoadable)
		{
			allAssetsLoadable = true;
		}

		public static void AddSafe(Dictionary<string, AssetID> pathsMappedToAssetId, string key, AssetID value)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (key != null && !pathsMappedToAssetId.ContainsKey(key))
			{
				pathsMappedToAssetId.Add(key, value);
			}
		}

		[HarmonyPatch(typeof(AssetBundleLoader), "GetAllAssetPathsMappedToAssetID")]
		[HarmonyTranspiler]
		private static IEnumerable<CodeInstruction> AssetBundleLoader_GetAllAssetPathsMappedToAssetID(IEnumerable<CodeInstruction> instructions)
		{
			MethodInfo addMethod = AccessTools.Method(typeof(Dictionary<string, AssetID>), "Add");
			MethodInfo operand = AccessTools.Method(typeof(Patches), "AddSafe");
			return new CodeMatcher(instructions).MatchForward(false, new CodeMatch((CodeInstruction i) => i.Calls(addMethod))).SetInstruction(new CodeInstruction(OpCodes.Call, operand)).InstructionEnumeration();
		}

		[HarmonyPatch(typeof(AssetLoader), "InvokeCallbacks")]
		[HarmonyPrefix]
		private static void SwapResolvedAsset(ref AssetLoader __instance, LoadResult result)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			if ((int)result == 0 && Instance.assetsToResolve.TryGetValue(__instance.m_assetID, out var value))
			{
				if (!__instance.m_asset)
				{
					Logger.LogWarning($"AssetLoader.m_asset == null for AssetID {__instance.m_assetID} at path {__instance.m_assetPathInBundle}, skipping mocking");
					return;
				}
				value.InstantiateAndResolveAsset(__instance.m_asset);
				__instance.m_asset = value.Asset;
			}
		}

		[HarmonyPatch(typeof(AssetLoader), "Release")]
		[HarmonyPostfix]
		private static void AssetLoader_Release(ref AssetLoader __instance)
		{
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			if (((AssetLoader)(ref __instance)).ReferenceCount == 0 && Instance.assetsToResolve.TryGetValue(__instance.m_assetID, out var value))
			{
				value.DestroyAsset();
			}
		}
	}

	private struct AssetRef
	{
		public BepInPlugin sourceMod;

		public UnityEngine.Object asset;

		public AssetID originalID;

		public AssetRef(BepInPlugin sourceMod, UnityEngine.Object asset, UnityEngine.Object original)
		{
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			this.sourceMod = sourceMod;
			this.asset = asset;
			originalID = (AssetID)(((bool)original && Instance.IsReady()) ? Instance.GetAssetID(original.GetType(), original.name) : default(AssetID));
		}
	}

	internal class MockResolutionContext
	{
		public UnityEngine.Object Asset { get; private set; }

		public Transform Parent { get; set; }

		public Action<UnityEngine.Object> ResolveCallback { get; set; }

		public bool IsResolved => Asset;

		public MockResolutionContext(Transform parent, Action<UnityEngine.Object> resolveCallback)
		{
			Parent = parent;
			ResolveCallback = (Action<UnityEngine.Object>)Delegate.Combine(ResolveCallback, resolveCallback);
		}

		public void InstantiateAndResolveAsset(UnityEngine.Object realAsset)
		{
			if (!IsResolved)
			{
				Asset = UnityEngine.Object.Instantiate(realAsset, Parent);
				Asset.name = realAsset.name;
				if (Asset is GameObject gameObject)
				{
					gameObject.FixReferences(recursive: true);
				}
				else
				{
					Asset.FixReferences();
				}
				ResolveCallback?.SafeInvoke(Asset);
			}
		}

		public void DestroyAsset()
		{
			if ((bool)Asset)
			{
				UnityEngine.Object.Destroy(Asset);
			}
			Asset = null;
		}
	}

	private static AssetManager instance;

	private Dictionary<AssetID, AssetRef> assets = new Dictionary<AssetID, AssetRef>();

	private Dictionary<Type, Dictionary<string, AssetID>> mapNameToAssetID;

	private GameObject ResolvedAssetsContainer;

	private Dictionary<AssetID, MockResolutionContext> assetsToResolve = new Dictionary<AssetID, MockResolutionContext>();

	/// <summary>
	///     The singleton instance of this manager.
	/// </summary>
	public static AssetManager Instance => instance ?? (instance = new AssetManager());

	internal Dictionary<Type, Dictionary<string, AssetID>> MapNameToAssetID => mapNameToAssetID ?? (mapNameToAssetID = CreateNameToAssetID());

	/// <summary>
	///     Event that is invoked when the soft referenceable system is ready to be used.
	/// </summary>
	public static event Action OnSoftReferenceableAssetsReady;

	/// <summary>
	///     Hide .ctor
	/// </summary>
	private AssetManager()
	{
	}

	static AssetManager()
	{
		((IManager)Instance).Init();
	}

	void IManager.Init()
	{
		Main.LogInit("AssetManager");
		ResolvedAssetsContainer = new GameObject("Resolved Assets");
		ResolvedAssetsContainer.transform.parent = Main.RootObject.transform;
		ResolvedAssetsContainer.SetActive(value: false);
		Main.Harmony.PatchAll(typeof(Patches));
	}

	/// <summary>
	///     Checks if the vanilla loader is ready.
	///     If false, <see cref="P:SoftReferenceableAssets.Runtime.Loader">Runtime.Loader</see> must not be accessed and no assets may be loaded.
	///     If the vanilla loader is initialized too early, mods can become incompatible.
	/// </summary>
	/// <returns>true if the vanilla asset loader is ready, false otherwise</returns>
	public bool IsReady()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (Runtime.s_assetLoader != null)
		{
			return ((AssetBundleLoader)Runtime.s_assetLoader).Initialized;
		}
		return false;
	}

	/// <summary>
	///     Registers a new asset with the same asset dependencies as the original asset and generates a unique AssetID.<br />
	///     Assets can be added at any time and will be registered as soon as the vanilla loader is ready.
	/// </summary>
	/// <param name="asset">The asset to register</param>
	/// <param name="original">Assets to copy dependencies from</param>
	/// <returns>AssetID generated from the prefab's name</returns>
	public AssetID AddAsset(UnityEngine.Object asset, UnityEngine.Object original)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		AssetID val = GenerateAssetID(asset);
		if (assets.ContainsKey(val))
		{
			return val;
		}
		AssetRef assetRef = new AssetRef(BepInExUtils.GetSourceModMetadata(), asset, original);
		assets.Add(val, assetRef);
		if (IsReady() && AssetBundleLoader.Instance != null)
		{
			AddAssetToBundleLoader(AssetBundleLoader.Instance, val, assetRef);
		}
		return val;
	}

	/// <summary>
	///     Registers a new asset and generates a unique AssetID.<br />
	///     Assets can be added at any time and will be registered as soon as the vanilla loader is ready.
	/// </summary>
	/// <param name="asset">The asset to register</param>
	/// <returns>AssetID generated from the prefab's name</returns>
	public AssetID AddAsset(UnityEngine.Object asset)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		return AddAsset(asset, null);
	}

	/// <summary>
	///     Registers an asset to be instantiated and have its mock references resolved on load.<br />
	///     Must be called before the asset is loaded the first time.
	/// </summary>
	/// <param name="assetID">The <see cref="T:SoftReferenceableAssets.AssetID" /> of the asset to instantiate and resolve mocks for on load</param>
	public void ResolveMocksOnLoad(AssetID assetID)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		ResolveMocksOnLoad(assetID, null, null);
	}

	/// <summary>
	///     Registers an asset to be instantiated under the given parent and have its mock references resolved on load.<br />
	///     Must be called before the asset is loaded the first time.
	/// </summary>
	/// <param name="assetID">The <see cref="T:SoftReferenceableAssets.AssetID" /> of the asset to instantiate and resolve mocks for on load</param>
	/// <param name="parent">Optional transform under which the asset will be instantiated, otherwise a default container is used</param>
	public void ResolveMocksOnLoad(AssetID assetID, Transform parent)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		ResolveMocksOnLoad(assetID, parent, null);
	}

	/// <summary>
	///     Registers an asset to be instantiated under the given parent and have its mock references resolved on load.<br />
	///     Must be called before the asset is loaded the first time.<br />
	///     The callback will be invoked when the asset is already resolved and instantiated. Multiple callbacks can be registed for the same asset.<br />
	/// </summary>
	/// <param name="softReference">The <see cref="T:SoftReferenceableAssets.SoftReference`1" /> to instantiate and resolve mocks for on load</param>
	/// <param name="parent">Optional transform under which the asset will be instantiated, otherwise a default container is used</param>
	/// <param name="resolveCallback">Adds a callback when the asset was resolved and instantiated</param>
	public void ResolveMocksOnLoad<T>(SoftReference<T> softReference, Transform parent, Action<T> resolveCallback) where T : UnityEngine.Object
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		ResolveMocksOnLoad(softReference.m_assetID, parent, delegate(UnityEngine.Object asset)
		{
			resolveCallback?.Invoke(asset as T);
		});
	}

	/// <summary>
	///     Registers an asset to be instantiated under the given parent and have its mock references resolved on load.<br />
	///     Must be called before the asset is loaded the first time.<br />
	///     The callback will be invoked when the asset is already resolved and instantiated. Multiple callbacks can be registed for the same asset.<br />
	/// </summary>
	/// <param name="assetID">The <see cref="T:SoftReferenceableAssets.AssetID" /> of the asset to instantiate and resolve mocks for on load</param>
	/// <param name="parent">Optional transform under which the asset will be instantiated, otherwise a default container is used</param>
	/// <param name="resolveCallback">Adds a callback when the asset was resolved and instantiated</param>
	public void ResolveMocksOnLoad(AssetID assetID, Transform parent, Action<UnityEngine.Object> resolveCallback)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		if (assetsToResolve.TryGetValue(assetID, out var value))
		{
			value.Parent = parent ?? value.Parent ?? ResolvedAssetsContainer.transform;
			MockResolutionContext mockResolutionContext = value;
			mockResolutionContext.ResolveCallback = (Action<UnityEngine.Object>)Delegate.Combine(mockResolutionContext.ResolveCallback, resolveCallback);
		}
		else
		{
			assetsToResolve.Add(assetID, new MockResolutionContext(parent ?? ResolvedAssetsContainer.transform, resolveCallback));
		}
	}

	private static void AddAssetToBundleLoader(AssetBundleLoader assetBundleLoader, AssetID assetID, AssetRef assetRef)
	{
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		string text = "JVL_BundleWrapper_" + assetRef.asset.name;
		string text2 = assetRef.sourceMod.GUID + "/Prefabs/" + assetRef.asset.name;
		if (assetBundleLoader.m_bundleNameToLoaderIndex.ContainsKey(text))
		{
			return;
		}
		AssetLocation val = default(AssetLocation);
		((AssetLocation)(ref val))._002Ector(text, text2);
		BundleLoader val2 = default(BundleLoader);
		((BundleLoader)(ref val2))._002Ector(text, "");
		((BundleLoader)(ref val2)).HoldReference();
		assetBundleLoader.m_bundleNameToLoaderIndex.Add(text, assetBundleLoader.m_bundleLoaders.Length);
		assetBundleLoader.m_bundleLoaders = assetBundleLoader.m_bundleLoaders.AddItem(val2).ToArray();
		int originalBundleLoaderIndex = assetBundleLoader.m_assetLoaders.FirstOrDefault((AssetLoader l) => l.m_assetID == assetRef.originalID).m_bundleLoaderIndex;
		if (((AssetID)(ref assetRef.originalID)).IsValid && originalBundleLoaderIndex > 0)
		{
			BundleLoader val3 = assetBundleLoader.m_bundleLoaders[originalBundleLoaderIndex];
			val2.m_bundleLoaderIndicesOfThisAndDependencies = (from i in val3.m_bundleLoaderIndicesOfThisAndDependencies.Where((int i) => i != originalBundleLoaderIndex).AddItem(assetBundleLoader.m_bundleNameToLoaderIndex[text])
				orderby i
				select i).ToArray();
		}
		else
		{
			((BundleLoader)(ref val2)).SetDependencies(Array.Empty<string>());
		}
		assetBundleLoader.m_bundleLoaders[assetBundleLoader.m_bundleNameToLoaderIndex[text]] = val2;
		AssetLoader item = default(AssetLoader);
		((AssetLoader)(ref item))._002Ector(assetID, val);
		item.m_asset = assetRef.asset;
		((AssetLoader)(ref item)).HoldReference();
		assetBundleLoader.m_assetIDToLoaderIndex.Add(assetID, assetBundleLoader.m_assetLoaders.Length);
		assetBundleLoader.m_assetLoaders = assetBundleLoader.m_assetLoaders.AddItem(item).ToArray();
		Instance.MapNameToAssetID[assetRef.asset.GetType()][assetRef.asset.name] = assetID;
	}

	/// <summary>
	///     Generates a unique AssetID, based on the asset name
	/// </summary>
	/// <param name="asset"></param>
	/// <returns>AssetID generated from the prefab's name</returns>
	public AssetID GenerateAssetID(UnityEngine.Object asset)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		uint stableHashCode = (uint)StringExtensionMethods.GetStableHashCode(asset.name);
		return new AssetID(stableHashCode, stableHashCode, stableHashCode, stableHashCode);
	}

	/// <summary>
	///     Generates a unique AssetID, from a given string
	/// </summary>
	/// <param name="asset"></param>
	/// <returns>AssetID generated from the prefab's name</returns>
	public AssetID GenerateAssetID(string asset)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		uint stableHashCode = (uint)StringExtensionMethods.GetStableHashCode(asset);
		return new AssetID(stableHashCode, stableHashCode, stableHashCode, stableHashCode);
	}

	/// <summary>
	///     Clones a prefab and registers it in the SoftReference system with the same dependencies as the original asset
	/// </summary>
	/// <param name="asset"></param>
	/// <param name="newName"></param>
	/// <param name="parent"></param>
	/// <returns></returns>
	public GameObject ClonePrefab(GameObject asset, string newName, Transform parent)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		GameObject gameObject = UnityEngine.Object.Instantiate(asset, parent);
		gameObject.name = newName;
		AddAsset(gameObject, asset);
		return gameObject;
	}

	/// <summary>
	///     Finds the AssetID by an asset name at runtime.<br />
	///     The closed matching base type must be used.
	///     E.g. for prefabs use <see cref="T:UnityEngine.GameObject" />, for Textures use <see cref="T:UnityEngine.Texture2D" /> etc.<br />
	///     If no asset is found, an invalid AssetID is returned.
	/// </summary>
	/// <param name="type">Asset type to search for</param>
	/// <param name="name">Asset name to search for</param>
	/// <returns>The AssetID of the searched asset if found, otherwise an invalid AssetID</returns>
	/// <exception cref="T:System.InvalidOperationException">Thrown if the vanilla asset system is not initialized yet</exception>
	public AssetID GetAssetID(Type type, string name)
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		if (!IsReady())
		{
			throw new InvalidOperationException("The vanilla asset system is not initialized yet");
		}
		if (MapNameToAssetID.TryGetValue(type, out var value) && value.TryGetValue(name, out var value2))
		{
			return value2;
		}
		if (MapNameToAssetID.TryGetValue(typeof(UnityEngine.Object), out value) && value.TryGetValue(name, out value2))
		{
			return value2;
		}
		return default(AssetID);
	}

	/// <summary>
	///     Finds the AssetID by an asset name at runtime.<br />
	///     The closed matching base type must be used.
	///     E.g. for prefabs use <see cref="T:UnityEngine.GameObject" />, for Textures use <see cref="T:UnityEngine.Texture2D" /> etc.<br />
	///     If no asset is found, an invalid AssetID is returned.
	/// </summary>
	/// <param name="name">Asset name to search for</param>
	/// <typeparam name="T">Asset type to search for</typeparam>
	/// <returns></returns>
	/// <exception cref="T:System.InvalidOperationException">Thrown if the vanilla asset system is not initialized yet</exception>
	public AssetID GetAssetID<T>(string name) where T : UnityEngine.Object
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		return GetAssetID(typeof(T), name);
	}

	/// <summary>
	///     Finds the AssetID by an asset name at runtime and returns a SoftReference to the asset.<br />
	/// </summary>
	/// <param name="type">Asset type to search for</param>
	/// <param name="name">Asset name to search for</param>
	/// <returns></returns>
	public SoftReference<UnityEngine.Object> GetSoftReference(Type type, string name)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		AssetID assetID = GetAssetID(type, name);
		if (!((AssetID)(ref assetID)).IsValid)
		{
			return default(SoftReference<UnityEngine.Object>);
		}
		return new SoftReference<UnityEngine.Object>(assetID);
	}

	/// <summary>
	///     Finds the AssetID by an asset name at runtime and returns a SoftReference to the asset.<br />
	/// </summary>
	/// <param name="name">Asset name to search for</param>
	/// <typeparam name="T">Asset type to search for</typeparam>
	/// <returns></returns>
	public SoftReference<T> GetSoftReference<T>(string name) where T : UnityEngine.Object
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		AssetID assetID = GetAssetID<T>(name);
		if (!((AssetID)(ref assetID)).IsValid)
		{
			return default(SoftReference<T>);
		}
		return new SoftReference<T>(assetID);
	}

	private static Dictionary<Type, Dictionary<string, AssetID>> CreateNameToAssetID()
	{
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		if (!Instance.IsReady())
		{
			throw new InvalidOperationException("The vanilla asset system is not initialized yet");
		}
		Dictionary<Type, Dictionary<string, AssetID>> dictionary = new Dictionary<Type, Dictionary<string, AssetID>>();
		Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
		foreach (KeyValuePair<string, AssetID> item in Runtime.GetAllAssetPathsInBundleMappedToAssetID().ToList())
		{
			string text = item.Key.Split('/').Last();
			string text2 = text.Split('.').Last();
			string key = text.RemoveSuffix("." + text2);
			if (!(item.Key == "Assets/UI/prefabs/radials/elements/Hammer.prefab") && !(item.Key == "Assets/UI/prefabs/Radial/elements/Hammer.prefab"))
			{
				Type type = Instance.TypeFromExtension(text2);
				if (type == null && text2 == "asset" && text.StartsWith("Recipe_"))
				{
					type = typeof(Recipe);
				}
				if (type == null)
				{
					type = typeof(UnityEngine.Object);
				}
				if (!dictionary.ContainsKey(type))
				{
					dictionary.Add(type, new Dictionary<string, AssetID>());
				}
				if (!dictionary[type].ContainsKey(key) || !SkipAmbiguousPath(dictionary2[key], item.Key, text2))
				{
					dictionary[type][key] = item.Value;
					dictionary2[key] = item.Key;
				}
			}
		}
		return dictionary;
	}

	private static bool SkipAmbiguousPath(string oldPath, string newPath, string extension)
	{
		if (extension == "prefab")
		{
			if (oldPath.StartsWith("Assets/world/Locations"))
			{
				return false;
			}
			if (newPath.StartsWith("Assets/world/Locations"))
			{
				return true;
			}
			Logger.LogWarning("Ambiguous asset name for path. old: " + oldPath + ", new: " + newPath + ", using old path");
		}
		return true;
	}

	private Type TypeFromExtension(string extension)
	{
		switch (extension.ToLower())
		{
		case "prefab":
			return typeof(GameObject);
		case "mat":
			return typeof(Material);
		case "obj":
		case "fbx":
			return typeof(Mesh);
		case "png":
		case "jpg":
		case "tga":
		case "tif":
			return typeof(Texture2D);
		case "wav":
		case "mp3":
			return typeof(AudioClip);
		case "controller":
			return typeof(RuntimeAnimatorController);
		case "physicmaterial":
		case "physicsmaterial":
			return typeof(PhysicsMaterial);
		case "shader":
			return typeof(Shader);
		case "anim":
			return typeof(AnimationClip);
		case "mixer":
			return typeof(AudioMixer);
		case "txt":
			return typeof(TextAsset);
		case "ttf":
		case "otf":
			return typeof(TMP_FontAsset);
		case "rendertexture":
			return typeof(RenderTexture);
		case "lighting":
			return typeof(LightingSettings);
		default:
			return null;
		}
	}
}
