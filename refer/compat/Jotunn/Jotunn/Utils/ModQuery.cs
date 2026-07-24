using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BepInEx;
using HarmonyLib;
using Jotunn.Entities;
using Jotunn.Managers;
using UnityEngine;

namespace Jotunn.Utils;

/// <summary>
///     Utility class to query metadata about added content of any loaded mod, including non-Jötunn ones.
///     It is disabled by default, as it unnecessary increases the loading time when not used.<br />
///     <see cref="M:Jotunn.Utils.ModQuery.Enable" /> has to be called anytime before FejdStartup.Awake, meaning in your plugin's Awake or Start.
/// </summary>
public class ModQuery
{
	private class ModPrefab : IModPrefab
	{
		public GameObject Prefab { get; }

		public BepInPlugin SourceMod { get; }

		public ModPrefab(GameObject prefab, BepInPlugin mod)
		{
			Prefab = prefab;
			SourceMod = mod;
		}
	}

	private class ZNetSceneState
	{
		public bool valid;

		public readonly Dictionary<int, GameObject> namedPrefabs;

		public readonly List<GameObject> prefabs;

		public ZNetSceneState(ZNetScene zNetScene)
		{
			valid = zNetScene;
			if (valid)
			{
				namedPrefabs = new Dictionary<int, GameObject>(zNetScene.m_namedPrefabs);
				prefabs = new List<GameObject>(zNetScene.m_prefabs);
			}
		}

		public void AddNewPrefabs(ZNetScene zNetScene, PluginInfo plugin)
		{
			if (valid && (bool)zNetScene)
			{
				AddPrefabs(namedPrefabs, zNetScene.m_namedPrefabs, plugin.Metadata);
				AddPrefabs(prefabs, zNetScene.m_prefabs, plugin.Metadata);
			}
		}
	}

	private class ObjectDBState
	{
		public bool valid;

		public List<GameObject> items;

		public List<Recipe> recipes;

		public Dictionary<int, GameObject> itemByHash;

		public ObjectDBState(ObjectDB objectDB)
		{
			valid = objectDB;
			if (valid)
			{
				items = new List<GameObject>(objectDB.m_items);
				recipes = new List<Recipe>(objectDB.m_recipes);
				itemByHash = new Dictionary<int, GameObject>(objectDB.m_itemByHash);
			}
		}

		public void AddNewPrefabs(ObjectDB objectDB, PluginInfo plugin)
		{
			if (valid && (bool)objectDB)
			{
				AddPrefabs(items, objectDB.m_items, plugin.Metadata);
				AddPrefabs(itemByHash, objectDB.m_itemByHash, plugin.Metadata);
				AddRecipes(recipes, objectDB.m_recipes, plugin.Metadata);
			}
		}
	}

	private static readonly Dictionary<string, Dictionary<int, ModPrefab>> Prefabs = new Dictionary<string, Dictionary<int, ModPrefab>>();

	private static readonly Dictionary<string, List<Recipe>> Recipes = new Dictionary<string, List<Recipe>>();

	private static Tuple<ZNetSceneState, ObjectDBState> state;

	private static readonly HashSet<MethodInfo> PatchedMethods = new HashSet<MethodInfo>();

	private static readonly HarmonyMethod PrePatch = new HarmonyMethod(AccessTools.Method(typeof(ModQuery), "BeforePatch"));

	private static readonly HarmonyMethod PostPatch = new HarmonyMethod(AccessTools.Method(typeof(ModQuery), "AfterPatch"));

	private static bool enabled = false;

	internal static void Init()
	{
		Main.LogInit("ModQuery");
		Main.Harmony.PatchAll(typeof(ModQuery));
	}

	/// <summary>
	///     Enables the collection of mod metadata.
	///     It is disabled by default, as it unnecessary increases the loading time when not used.<br />
	///     This method has to be called anytime before FejdStartup.Awake, meaning in your plugin's Awake or Start.
	/// </summary>
	public static void Enable()
	{
		if (!enabled)
		{
			Init();
		}
		enabled = true;
	}

	/// <summary>
	///     Get all prefabs that were added by mods. Does not include Vanilla prefabs.
	/// </summary>
	/// <returns></returns>
	public static IEnumerable<IModPrefab> GetPrefabs()
	{
		List<IModPrefab> list = new List<IModPrefab>();
		foreach (KeyValuePair<string, Dictionary<int, ModPrefab>> prefab in Prefabs)
		{
			list.AddRange(prefab.Value.Values);
		}
		list.AddRange(PrefabManager.Instance.Prefabs.Values);
		return list;
	}

	/// <summary>
	///     Get all prefabs that were added by a specific mod
	/// </summary>
	/// <param name="modGuid"></param>
	/// <returns></returns>
	public static IEnumerable<IModPrefab> GetPrefabs(string modGuid)
	{
		List<IModPrefab> list = new List<IModPrefab>();
		list.AddRange(Prefabs[modGuid].Values);
		list.AddRange(PrefabManager.Instance.Prefabs.Values.Where((CustomPrefab x) => x.SourceMod.GUID.Equals(modGuid)));
		return list;
	}

	/// <summary>
	///     Get an prefab by its name.
	///     Does not include Vanilla prefabs, see <see cref="M:Jotunn.Managers.PrefabManager.GetPrefab(System.String)">PrefabManager.GetPrefab(string)</see>
	///     for those.
	/// </summary>
	/// <param name="name"></param>
	/// <returns></returns>
	public static IModPrefab GetPrefab(string name)
	{
		int stableHashCode = StringExtensionMethods.GetStableHashCode(name);
		if (PrefabManager.Instance.Prefabs.TryGetValue(name, out var value))
		{
			return value;
		}
		foreach (KeyValuePair<string, Dictionary<int, ModPrefab>> prefab in Prefabs)
		{
			if (prefab.Value.ContainsKey(stableHashCode))
			{
				return prefab.Value[stableHashCode];
			}
		}
		return null;
	}

	[HarmonyPatch(typeof(ZNetScene), "OnDestroy")]
	[HarmonyPostfix]
	private static void ZNetSceneOnDestroy()
	{
		Prefabs.Clear();
		Recipes.Clear();
	}

	[HarmonyPatch(typeof(FejdStartup), "Awake")]
	[HarmonyPostfix]
	private static void FejdStartup_Awake_Postfix()
	{
		FindAndPatchPatches(AccessTools.Method(typeof(ZNetScene), "Awake"));
		FindAndPatchPatches(AccessTools.Method(typeof(ObjectDB), "Awake"));
		FindAndPatchPatches(AccessTools.Method(typeof(ObjectDB), "CopyOtherDB"));
		FindAndPatchPatches(AccessTools.Method(typeof(ObjectDB), "UpdateRegisters"));
	}

	[HarmonyPatch(typeof(ObjectDB), "Awake")]
	[HarmonyPrefix]
	[HarmonyPriority(1000)]
	private static void ObjectDBAwake(ObjectDB __instance)
	{
		__instance.UpdateRegisters();
	}

	private static void FindAndPatchPatches(MethodBase methodInfo)
	{
		PatchPatches(Harmony.GetPatchInfo(methodInfo)?.Prefixes);
		PatchPatches(Harmony.GetPatchInfo(methodInfo)?.Postfixes);
		PatchPatches(Harmony.GetPatchInfo(methodInfo)?.Finalizers);
	}

	private static void PatchPatches(ICollection<Patch> patches)
	{
		if (patches == null)
		{
			return;
		}
		foreach (Patch patch in patches)
		{
			if (!(patch.owner == "com.jotunn.jotunn") && !PatchedMethods.Contains(patch.PatchMethod))
			{
				PatchedMethods.Add(patch.PatchMethod);
				try
				{
					Main.Harmony.Patch(patch.PatchMethod, PrePatch, PostPatch);
				}
				catch (Exception)
				{
					Logger.LogWarning($"Failed to patch {patch.PatchMethod} from {patch.owner}");
				}
			}
		}
	}

	private static void BeforePatch(object[] __args)
	{
		ObjectDB objectDB = GetObjectDB(__args);
		ZNetScene zNetScene = GetZNetScene(__args);
		state = new Tuple<ZNetSceneState, ObjectDBState>(new ZNetSceneState(zNetScene), new ObjectDBState(objectDB));
	}

	private static void AfterPatch(object[] __args)
	{
		if (state != null && (state.Item1.valid || state.Item2.valid))
		{
			PluginInfo pluginInfoFromAssembly = BepInExUtils.GetPluginInfoFromAssembly(ReflectionHelper.GetCallingAssembly());
			if (pluginInfoFromAssembly != null)
			{
				state.Item1.AddNewPrefabs(GetZNetScene(__args), pluginInfoFromAssembly);
				state.Item2.AddNewPrefabs(GetObjectDB(__args), pluginInfoFromAssembly);
			}
		}
	}

	private static void AddPrefabs(IEnumerable<GameObject> before, IEnumerable<GameObject> after, BepInPlugin plugin)
	{
		AddPrefabs(new HashSet<GameObject>(before), new HashSet<GameObject>(after), plugin);
	}

	private static void AddPrefabs(Dictionary<int, GameObject> before, Dictionary<int, GameObject> after, BepInPlugin plugin)
	{
		AddPrefabs(new HashSet<GameObject>(before.Values), new HashSet<GameObject>(after.Values), plugin);
	}

	private static void AddPrefabs(HashSet<GameObject> before, HashSet<GameObject> after, BepInPlugin plugin)
	{
		if (!Prefabs.ContainsKey(plugin.GUID))
		{
			Prefabs.Add(plugin.GUID, new Dictionary<int, ModPrefab>());
		}
		foreach (GameObject item in after)
		{
			if ((bool)item && !before.Contains(item))
			{
				int stableHashCode = StringExtensionMethods.GetStableHashCode(item.name);
				if (!Prefabs[plugin.GUID].ContainsKey(stableHashCode))
				{
					Prefabs[plugin.GUID].Add(stableHashCode, new ModPrefab(item, plugin));
				}
			}
		}
	}

	private static void AddRecipes(IEnumerable<Recipe> before, IEnumerable<Recipe> after, BepInPlugin plugin)
	{
		AddRecipes(new HashSet<Recipe>(before), new HashSet<Recipe>(after), plugin);
	}

	private static void AddRecipes(HashSet<Recipe> before, HashSet<Recipe> after, BepInPlugin plugin)
	{
		if (!Recipes.ContainsKey(plugin.GUID))
		{
			Recipes.Add(plugin.GUID, new List<Recipe>());
		}
		foreach (Recipe item in after)
		{
			if (!before.Contains(item) && !Recipes[plugin.GUID].Contains(item))
			{
				Recipes[plugin.GUID].Add(item);
			}
		}
	}

	private static ZNetScene GetZNetScene(object[] __args)
	{
		foreach (object obj in __args)
		{
			if (obj is ZNetScene result)
			{
				return result;
			}
		}
		return ZNetScene.instance;
	}

	private static ObjectDB GetObjectDB(object[] __args)
	{
		foreach (object obj in __args)
		{
			if (obj is ObjectDB result)
			{
				return result;
			}
		}
		return ObjectDB.instance;
	}
}
