using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using BepInEx;
using HarmonyLib;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Jotunn.Managers;

/// <summary>
///     Manager for handling custom pieces added to the game.
/// </summary>
public class PieceManager : IManager
{
	/// <summary>
	///     Settings of the hammer UI tab selection.
	/// </summary>
	[Obsolete("No longer used")]
	public static class PieceCategorySettings
	{
		/// <summary>
		///     Piece table tab header width.
		/// </summary>
		[Obsolete("This setting is no longer used")]
		public static float HeaderWidth { get; set; } = 700f;

		/// <summary>
		///     Minimum size of a piece table tab. The tab can grow bigger than this the name doesn't fit.
		/// </summary>
		[Obsolete("This setting is no longer used")]
		public static float MinTabSize { get; set; } = 140f;

		/// <summary>
		///     Tab size per name character. This determines how fast the tab size grows.
		/// </summary>
		[Obsolete("This setting is no longer used")]
		public static float TabSizePerCharacter { get; set; } = 11f;

		/// <summary>
		///     Minimum left/right space that is visible for not selected adjacent tabs.
		/// </summary>
		[Obsolete("This setting is no longer used")]
		public static float TabMargin { get; set; } = 50f;
	}

	private static class Patches
	{
		[HarmonyPatch(typeof(Player), "SetPlaceMode")]
		[HarmonyPostfix]
		[HarmonyPriority(200)]
		public static void Player_SetPlaceMode()
		{
			Instance.RefreshCategories();
		}

		[HarmonyPatch(typeof(Hud), "Awake")]
		[HarmonyPostfix]
		[HarmonyPriority(200)]
		private static void Hud_Awake()
		{
			Instance.RefreshCategories();
		}

		[HarmonyPatch(typeof(Hud), "UpdateBuild")]
		[HarmonyPrefix]
		[HarmonyPriority(200)]
		private static void Hud_UpdateBuild()
		{
			Instance.RefreshCategoriesIfNeeded();
		}

		[HarmonyPatch(typeof(Hud), "LateUpdate")]
		[HarmonyPostfix]
		[HarmonyPriority(200)]
		private static void Hud_LateUpdate()
		{
			Instance.RefreshCategoriesIfNeeded();
		}

		[HarmonyPatch(typeof(ObjectDB), "Awake")]
		[HarmonyPostfix]
		[HarmonyPriority(200)]
		private static void RegisterCustomData(ObjectDB __instance)
		{
			Instance.RegisterCustomData(__instance);
		}

		[HarmonyPatch(typeof(ObjectDB), "Awake")]
		[HarmonyPostfix]
		[HarmonyPriority(0)]
		private static void InvokeOnPiecesRegistered(ObjectDB __instance)
		{
			Instance.InvokeOnPiecesRegistered(__instance);
		}

		[HarmonyPatch(typeof(Player), "OnSpawned")]
		[HarmonyPostfix]
		private static void ReloadKnownRecipes(Player __instance)
		{
			Instance.ReloadKnownRecipes(__instance);
		}

		[HarmonyPatch(typeof(PieceTable), "UpdateAvailable")]
		[HarmonyPrefix]
		public static void PieceTable_UpdateAvailable_Prefix(PieceTable __instance)
		{
			ExpandAvailablePieces(__instance);
		}

		[HarmonyPatch(typeof(PieceTable), "UpdateAvailable")]
		[HarmonyPostfix]
		public static void PieceTable_UpdateAvailable_Postfix(PieceTable __instance)
		{
			AdjustPieceTableArray(__instance);
			ReorderAllCategoryPieces(__instance);
		}

		[HarmonyPatch(typeof(PieceTable), "UpdateAvailable")]
		[HarmonyTranspiler]
		private static IEnumerable<CodeInstruction> UpdateAvailable_Transpiler(IEnumerable<CodeInstruction> instructions)
		{
			return TranspileMaxCategory(instructions, 0);
		}

		[HarmonyPatch(typeof(Enum), "GetValues")]
		[HarmonyPostfix]
		private static void EnumGetValuesPatch(Type enumType, ref Array __result)
		{
			Instance.EnumGetValuesPatch(enumType, ref __result);
		}

		[HarmonyPatch(typeof(Enum), "GetNames")]
		[HarmonyPostfix]
		private static void EnumGetNamesPatch(Type enumType, ref string[] __result)
		{
			Instance.EnumGetNamesPatch(enumType, ref __result);
		}
	}

	private static PieceManager _instance;

	internal readonly Dictionary<string, CustomPiece> Pieces = new Dictionary<string, CustomPiece>();

	internal readonly List<CustomPieceTable> PieceTables = new List<CustomPieceTable>();

	private readonly Dictionary<string, PieceTable> PieceTableMap = new Dictionary<string, PieceTable>();

	private readonly Dictionary<string, string> PieceTableNameMap = new Dictionary<string, string>();

	private readonly Dictionary<string, Piece.PieceCategory> PieceCategories = new Dictionary<string, Piece.PieceCategory>();

	private readonly Dictionary<string, Piece.PieceCategory> OtherPieceCategories = new Dictionary<string, Piece.PieceCategory>();

	private readonly Dictionary<Piece.PieceCategory, string> vanillaLabels = new Dictionary<Piece.PieceCategory, string>();

	private bool categoryRefreshNeeded = true;

	private static string hiddenCategoryMagic;

	/// <summary>
	///     The singleton instance of this manager.
	/// </summary>
	public static PieceManager Instance => _instance ?? (_instance = new PieceManager());

	/// <summary>
	///     Event that gets fired after all pieces were added to their respective PieceTables.
	///     Your code will execute every time a new ObjectDB is created (on every game start).
	///     If you want to execute just once you will need to unregister from the event after execution.
	/// </summary>
	public static event Action OnPiecesRegistered;

	/// <summary>
	///     Hide .ctor
	/// </summary>
	private PieceManager()
	{
	}

	static PieceManager()
	{
		hiddenCategoryMagic = "(HiddenCategory)";
		((IManager)Instance).Init();
	}

	/// <summary>
	///     Creates the piece table container and registers all hooks.
	/// </summary>
	void IManager.Init()
	{
		Main.LogInit("PieceManager");
		Main.Harmony.PatchAll(typeof(Patches));
		PrefabManager.Instance.Activate();
		if ((bool)ObjectDB.instance)
		{
			LoadPieceTables();
		}
	}

	/// <summary>
	///     Add a <see cref="T:Jotunn.Entities.CustomPieceTable" /> to the game.<br />
	///     Checks if the custom piece table is valid and unique and adds it to the list of custom piece tables.
	/// </summary>
	/// <param name="customPieceTable">The custom piece table to add.</param>
	/// <returns>true if the custom piece table was added to the manager.</returns>
	public bool AddPieceTable(CustomPieceTable customPieceTable)
	{
		if (!customPieceTable.IsValid())
		{
			Logger.LogWarning(customPieceTable.SourceMod, $"Custom piece {customPieceTable} is not valid");
			return false;
		}
		if (PieceTables.Contains(customPieceTable))
		{
			Logger.LogWarning(customPieceTable.SourceMod, $"Piece table {customPieceTable} already added");
			return false;
		}
		if (!PrefabManager.Instance.AddPrefab(customPieceTable.PieceTablePrefab, customPieceTable.SourceMod))
		{
			return false;
		}
		string[] categories = customPieceTable.Categories;
		foreach (string name in categories)
		{
			AddPieceCategory(name);
		}
		PieceTables.Add(customPieceTable);
		PieceTableMap.Add(customPieceTable.ToString(), customPieceTable.PieceTable);
		return true;
	}

	/// <summary>
	///     Add a new <see cref="T:PieceTable" /> from <see cref="T:UnityEngine.GameObject" />.<br />
	///     Creates a <see cref="T:Jotunn.Entities.CustomPieceTable" /> and adds it to the manager.
	/// </summary>
	/// <param name="prefab">The <see cref="T:UnityEngine.GameObject" /> to add.</param>
	[Obsolete("Use CustomPieceTable instead")]
	public void AddPieceTable(GameObject prefab)
	{
		AddPieceTable(new CustomPieceTable(prefab));
	}

	/// <summary>
	///     Add a new <see cref="T:PieceTable" /> from string.<br />
	///     Creates a <see cref="T:Jotunn.Entities.CustomPieceTable" /> and adds it to the manager.
	/// </summary>
	/// <param name="name">Name of the new piece table.</param>
	[Obsolete("Use CustomPieceTable instead")]
	public void AddPieceTable(string name)
	{
		GameObject gameObject = new GameObject(name);
		gameObject.AddComponent<PieceTable>();
		AddPieceTable(new CustomPieceTable(gameObject, new PieceTableConfig()));
	}

	/// <summary>
	///     Get a <see cref="T:PieceTable" /> by name.<br /><br />
	///     Search hierarchy:<br />
	///     <list type="number">
	///         <item>PieceTable with the exact name (e.g. "_HammerPieceTable")</item>
	///         <item>PieceTable via "item" name (e.g. "Hammer")</item>
	///     </list>
	/// </summary>
	/// <param name="name">Prefab or item name of the PieceTable</param>
	/// <returns><see cref="T:PieceTable" /> component</returns>
	public PieceTable GetPieceTable(string name)
	{
		if (PieceTableMap.ContainsKey(name))
		{
			return PieceTableMap[name];
		}
		if (PieceTableNameMap.ContainsKey(name))
		{
			return PieceTableMap[PieceTableNameMap[name]];
		}
		return null;
	}

	/// <summary>
	///     Returns all <see cref="T:PieceTable" /> instances in the game.
	///     The list is gathered on every ObjectDB.Awake() from all items in it,
	///     so depending on the timing of the call, the list might not be complete.
	/// </summary>
	/// <returns>A list of <see cref="T:PieceTable" /> instances</returns>
	public List<PieceTable> GetPieceTables()
	{
		return PieceTableMap.Values.ToList();
	}

	/// <summary>
	///     Add a new <see cref="T:Piece.PieceCategory" /> by name. A new category
	///     gets assigned a random integer for internal use. If you pass a vanilla category
	///     the actual integer value of the enum is returned.
	/// </summary>
	/// <param name="table">Prefab or item name of the PieceTable.</param>
	/// <param name="name">Name of the category.</param>
	/// <returns>int value of the vanilla or custom category</returns>
	[Obsolete("Use AddPieceCategory(string name) instead")]
	public Piece.PieceCategory AddPieceCategory(string table, string name)
	{
		return AddPieceCategory(name);
	}

	/// <summary>
	///     Add a new <see cref="T:Piece.PieceCategory" /> by name. A new category
	///     gets assigned a random integer for internal use. If you pass a vanilla category
	///     the actual integer value of the enum is returned.
	/// </summary>
	/// <param name="name">Name of the category.</param>
	/// <returns>int value of the vanilla or custom category</returns>
	public Piece.PieceCategory AddPieceCategory(string name)
	{
		bool isNew;
		Piece.PieceCategory orCreatePieceCategory = GetOrCreatePieceCategory(name, out isNew);
		if (isNew)
		{
			CreateCategoryTabs();
		}
		categoryRefreshNeeded = true;
		return orCreatePieceCategory;
	}

	/// <summary>
	///     Get a <see cref="T:Piece.PieceCategory" /> by name. Translates
	///     vanilla or custom Piece Categories to their current integer value.
	/// </summary>
	/// <param name="name">Name of the category.</param>
	/// <returns>int value of the vanilla or custom category</returns>
	public Piece.PieceCategory? GetPieceCategory(string name)
	{
		if (Enum.TryParse<Piece.PieceCategory>(name, ignoreCase: true, out var result))
		{
			return result;
		}
		if (PieceCategories.TryGetValue(name, out result))
		{
			return result;
		}
		if (OtherPieceCategories.TryGetValue(name, out result))
		{
			return result;
		}
		return null;
	}

	/// <summary>
	///     Remove a <see cref="T:Piece.PieceCategory" /> from a table by name.
	///     This does noting if a piece is still assigned to the category, remove it before calling this.
	/// </summary>
	/// <param name="table">Prefab or item name of the PieceTable.</param>
	/// <param name="name">Name of the category.</param>
	[Obsolete("Use RemovePieceCategory(string name) instead")]
	public void RemovePieceCategory(string table, string name)
	{
		RemovePieceCategory(name);
	}

	/// <summary>
	///     Remove a <see cref="T:Piece.PieceCategory" /> from a table by name.
	///     This does noting if a piece is still assigned to the category, remove it before calling this.
	/// </summary>
	/// <param name="name">Name of the category.</param>
	public void RemovePieceCategory(string name)
	{
		categoryRefreshNeeded = true;
	}

	/// <summary>
	///     Get a list of all custom Jötunn piece category names
	/// </summary>
	/// <returns></returns>
	[Obsolete("Use GetPieceCategoriesMap to get a complete map of all categories, not only Jötunn ones")]
	public List<string> GetPieceCategories()
	{
		return PieceCategories.Keys.ToList();
	}

	/// <summary>
	///     Get a complete map of all piece categories.
	///     This includes vanilla, Jötunn and other modded categories that use the same system
	/// </summary>
	/// <returns></returns>
	public Dictionary<Piece.PieceCategory, string> GetPieceCategoriesMap()
	{
		Array values = Enum.GetValues(typeof(Piece.PieceCategory));
		string[] names = Enum.GetNames(typeof(Piece.PieceCategory));
		Dictionary<Piece.PieceCategory, string> dictionary = new Dictionary<Piece.PieceCategory, string>();
		for (int i = 0; i < values.Length; i++)
		{
			dictionary[(Piece.PieceCategory)values.GetValue(i)] = names[i];
		}
		return dictionary;
	}

	/// <summary>
	///     Add a <see cref="T:Jotunn.Entities.CustomPiece" /> to the game.<br />
	///     Checks if the custom piece is valid and unique and adds it to the list of custom pieces.<br />
	///     Custom pieces are added to their respective <see cref="T:PieceTable" />s after <see cref="M:ObjectDB.Awake" />.
	/// </summary>
	/// <param name="customPiece">The custom piece to add.</param>
	/// <returns>true if the custom piece was added to the manager.</returns>
	public bool AddPiece(CustomPiece customPiece)
	{
		if (!customPiece.IsValid())
		{
			Logger.LogWarning(customPiece.SourceMod, $"Custom piece {customPiece} is not valid");
			return false;
		}
		if (Pieces.ContainsKey(customPiece.PiecePrefab.name))
		{
			Logger.LogWarning(customPiece.SourceMod, $"Custom piece {customPiece} already added");
			return false;
		}
		if (!PrefabManager.Instance.AddPrefab(customPiece.PiecePrefab, customPiece.SourceMod))
		{
			return false;
		}
		if (customPiece.PiecePrefab.layer == 0)
		{
			customPiece.PiecePrefab.layer = LayerMask.NameToLayer("piece");
		}
		Pieces.Add(customPiece.PiecePrefab.name, customPiece);
		return true;
	}

	/// <summary>
	///     Get a custom piece by its name.
	/// </summary>
	/// <param name="pieceName">Name of the piece to search.</param>
	/// <returns></returns>
	public CustomPiece GetPiece(string pieceName)
	{
		if (!Pieces.TryGetValue(pieceName, out var value))
		{
			return null;
		}
		return value;
	}

	/// <summary>
	///     Remove a custom piece by its name.
	/// </summary>
	/// <param name="pieceName">Name of the piece to remove.</param>
	public void RemovePiece(string pieceName)
	{
		CustomPiece piece = GetPiece(pieceName);
		if (piece == null)
		{
			Logger.LogWarning("Could not remove piece " + pieceName + ": Not found");
		}
		else
		{
			RemovePiece(piece);
		}
	}

	/// <summary>
	///     Remove a custom piece by its ref.
	/// </summary>
	/// <param name="piece"><see cref="T:Jotunn.Entities.CustomPiece" /> to remove.</param>
	public void RemovePiece(CustomPiece piece)
	{
		string name = piece.PiecePrefab.name;
		if (!Pieces.ContainsKey(name))
		{
			Logger.LogWarning(piece.SourceMod, $"Could not remove piece {piece}: Not found");
			return;
		}
		Pieces.Remove(name);
		if ((bool)piece.PiecePrefab && (bool)PrefabManager.Instance.GetPrefab(piece.PiecePrefab.name))
		{
			PrefabManager.Instance.RemovePrefab(piece.PiecePrefab.name);
		}
	}

	/// <summary>
	///     Loop all items in the game and get all PieceTables used (vanilla and custom ones).
	/// </summary>
	private void LoadPieceTables()
	{
		foreach (GameObject item in ObjectDB.instance.m_items)
		{
			PieceTable pieceTable = item.GetComponent<ItemDrop>()?.m_itemData.m_shared.m_buildPieces;
			if (pieceTable != null)
			{
				PieceTableMap[pieceTable.name] = pieceTable;
				PieceTableNameMap[item.name] = pieceTable.name;
			}
		}
	}

	/// <summary>
	///     Registers all custom pieces to their respective piece tables.
	///     Removes erroneous ones from the manager.
	/// </summary>
	private void RegisterInPieceTables()
	{
		if (!Pieces.Any())
		{
			return;
		}
		Logger.LogInfo($"Adding {Pieces.Count} custom pieces to the PieceTables");
		List<CustomPiece> list = new List<CustomPiece>();
		foreach (KeyValuePair<string, CustomPiece> piece in Pieces)
		{
			CustomPiece value = piece.Value;
			try
			{
				RegisterCustomPiece(value);
			}
			catch (Exception arg)
			{
				Logger.LogWarning(value?.SourceMod, $"Error caught while adding piece {value}: {arg}");
				list.Add(value);
			}
		}
		foreach (CustomPiece item in list)
		{
			if ((bool)item.PiecePrefab)
			{
				PrefabManager.Instance.DestroyPrefab(item.PiecePrefab.name);
			}
			RemovePiece(item);
		}
	}

	private void RegisterCustomPiece(CustomPiece customPiece)
	{
		if (customPiece.FixReference || customPiece.FixConfig)
		{
			customPiece.PiecePrefab.FixReferences(customPiece.FixReference);
			customPiece.FixReference = false;
			customPiece.FixConfig = false;
		}
		StationExtension component = customPiece.PiecePrefab.GetComponent<StationExtension>();
		if (component != null && !component.m_connectionPrefab)
		{
			component.m_connectionPrefab = PrefabManager.Cache.GetPrefab<GameObject>("vfx_ExtensionConnection");
		}
		RegisterPieceInPieceTable(customPiece.PiecePrefab, customPiece.PieceTable, null, customPiece.SourceMod);
	}

	/// <summary>
	///     Register a single piece prefab into a piece table by name.<br />
	///     Also adds the prefab to the <see cref="T:Jotunn.Managers.PrefabManager" /> and <see cref="T:ZNetScene" /> if necessary.<br />
	///     Custom categories can be referenced if they have been added to the manager before.<br />
	///     No mock references are fixed.
	/// </summary>
	/// <param name="prefab"><see cref="T:UnityEngine.GameObject" /> with a <see cref="T:Piece" /> component to add to the table</param>
	/// <param name="pieceTable">Prefab or item name of the PieceTable</param>
	/// <param name="category">Optional category string, does not create new custom categories</param>
	public void RegisterPieceInPieceTable(GameObject prefab, string pieceTable, string category = null)
	{
		RegisterPieceInPieceTable(prefab, pieceTable, category, BepInExUtils.GetSourceModMetadata());
	}

	/// <summary>
	///     Internal method for adding a prefab to a piece table.
	/// </summary>
	private void RegisterPieceInPieceTable(GameObject prefab, string pieceTable, string category, BepInPlugin sourceMod)
	{
		Piece component = prefab.GetComponent<Piece>();
		if (component == null)
		{
			throw new Exception("Prefab " + prefab.name + " has no Piece component attached");
		}
		PieceTable pieceTable2 = GetPieceTable(pieceTable);
		if (pieceTable2 == null)
		{
			throw new Exception("Could not find PieceTable " + pieceTable);
		}
		if (pieceTable2.m_pieces.Contains(prefab))
		{
			Logger.LogDebug("Already added piece " + prefab.name);
			return;
		}
		string name = prefab.name;
		int stableHashCode = StringExtensionMethods.GetStableHashCode(name);
		if (!PrefabManager.Instance.Prefabs.ContainsKey(name))
		{
			PrefabManager.Instance.AddPrefab(prefab, sourceMod);
		}
		if (ZNetScene.instance != null && !ZNetScene.instance.m_namedPrefabs.ContainsKey(stableHashCode))
		{
			PrefabManager.Instance.RegisterToZNetScene(prefab);
		}
		if (!string.IsNullOrEmpty(category))
		{
			component.m_category = AddPieceCategory(category);
		}
		pieceTable2.m_pieces.Add(prefab);
		Logger.LogDebug("Added piece " + prefab.name + " | Token: " + component.TokenName());
	}

	private void RegisterCustomData(ObjectDB self)
	{
		if (SceneManager.GetActiveScene().name == "main")
		{
			LoadPieceTables();
			RegisterInPieceTables();
		}
	}

	private void InvokeOnPiecesRegistered(ObjectDB self)
	{
		if (SceneManager.GetActiveScene().name == "main")
		{
			PieceManager.OnPiecesRegistered?.SafeInvoke();
		}
	}

	/// <summary>
	///     Hook on <see cref="M:Player.OnSpawned(System.Boolean)" /> to refresh recipes for the custom items.
	/// </summary>
	/// <param name="self"></param>
	private void ReloadKnownRecipes(Player self)
	{
		if (!Pieces.Any())
		{
			return;
		}
		try
		{
			self.UpdateKnownRecipesList();
		}
		catch (Exception arg)
		{
			Logger.LogWarning($"Exception caught while reloading player recipes: {arg}");
		}
	}

	private static int MaxCategory()
	{
		int num = Enum.GetValues(typeof(Piece.PieceCategory)).Length - 1;
		if (num >= (int)PieceUtils.VanillaAllPieceCategory)
		{
			return num + 1;
		}
		return num;
	}

	private static IEnumerable<CodeInstruction> TranspileMaxCategory(IEnumerable<CodeInstruction> instructions, int maxOffset)
	{
		int number = (int)(PieceUtils.VanillaMaxPieceCategory + maxOffset);
		foreach (CodeInstruction instruction in instructions)
		{
			if (instruction.opcode == OpCodes.Call && instruction.operand is MethodInfo methodInfo && methodInfo.Name.Contains("MaxCategory"))
			{
				yield return new CodeInstruction(OpCodes.Call, AccessTools.DeclaredMethod(typeof(PieceManager), "MaxCategory"));
			}
			else if (instruction.LoadsConstant(number))
			{
				yield return new CodeInstruction(OpCodes.Call, AccessTools.DeclaredMethod(typeof(PieceManager), "MaxCategory"));
				if (maxOffset != 0)
				{
					yield return new CodeInstruction(OpCodes.Ldc_I4, maxOffset);
					yield return new CodeInstruction(OpCodes.Add);
				}
			}
			else
			{
				yield return instruction;
			}
		}
	}

	private void EnumGetValuesPatch(Type enumType, ref Array __result)
	{
		if (!(enumType != typeof(Piece.PieceCategory)) && PieceCategories.Count != 0)
		{
			Piece.PieceCategory[] array = new Piece.PieceCategory[__result.Length + PieceCategories.Count];
			__result.CopyTo(array, 0);
			PieceCategories.Values.CopyTo(array, __result.Length);
			__result = array;
		}
	}

	private void EnumGetNamesPatch(Type enumType, ref string[] __result)
	{
		if (!(enumType != typeof(Piece.PieceCategory)) && PieceCategories.Count != 0)
		{
			__result = __result.AddRangeToArray(PieceCategories.Keys.ToArray());
		}
	}

	private static void ExpandAvailablePieces(PieceTable __instance)
	{
		if (__instance.m_availablePieces.Count > 0)
		{
			int num = MaxCategory() - __instance.m_availablePieces.Count;
			for (int i = 0; i < num; i++)
			{
				__instance.m_availablePieces.Add(new List<Piece>());
			}
		}
	}

	private static void AdjustPieceTableArray(PieceTable pieceTable)
	{
		Array.Resize(ref pieceTable.m_selectedPiece, pieceTable.m_availablePieces.Count);
		Array.Resize(ref pieceTable.m_lastSelectedPiece, pieceTable.m_availablePieces.Count);
	}

	private static void ReorderAllCategoryPieces(PieceTable pieceTable)
	{
		List<Piece> list = pieceTable.m_pieces.Select((GameObject i) => i.GetComponent<Piece>()).ToList();
		List<Piece> list2 = list.FindAll((Piece i) => (bool)i && i.m_category == PieceUtils.VanillaAllPieceCategory);
		foreach (List<Piece> availablePiece in pieceTable.m_availablePieces)
		{
			int num = 0;
			foreach (Piece item in list2)
			{
				availablePiece.Remove(item);
				availablePiece.Insert(Mathf.Min(num, pieceTable.m_availablePieces.Count), item);
				num++;
			}
		}
	}

	private static void SetTabActive(GameObject tab, string tabName, bool active)
	{
		tab.SetActive(active);
		if (active)
		{
			tab.name = tabName.Replace(hiddenCategoryMagic, "");
		}
		else
		{
			tab.name = tabName + hiddenCategoryMagic;
		}
	}

	private static HashSet<Piece.PieceCategory> CategoriesInPieceTable(PieceTable pieceTable)
	{
		HashSet<Piece.PieceCategory> hashSet = new HashSet<Piece.PieceCategory>();
		foreach (GameObject piece in pieceTable.m_pieces)
		{
			hashSet.Add(piece.GetComponent<Piece>().m_category);
		}
		return hashSet;
	}

	private void CreateCategoryTabs()
	{
		if ((bool)Hud.instance)
		{
			int num = MaxCategory();
			for (int i = Hud.instance.m_pieceCategoryTabs.Length; i < num; i++)
			{
				GameObject item = CreateCategoryTab();
				Hud.instance.m_pieceCategoryTabs = Hud.instance.m_pieceCategoryTabs.AddItem(item).ToArray();
			}
			if ((bool)Player.m_localPlayer && (bool)Player.m_localPlayer.m_buildPieces)
			{
				Player.m_localPlayer.UpdateAvailablePiecesList();
			}
		}
	}

	private string GetCategoryToken(string name)
	{
		char[] separator = " (){}[]+-!?/\\\\&%,.:-=<>\n".ToCharArray();
		string text = string.Join("_", name.ToLower().Split(separator));
		return "jotunn_cat_" + text;
	}

	private Piece.PieceCategory GetOrCreatePieceCategory(string name, out bool isNew)
	{
		Piece.PieceCategory? pieceCategory = GetPieceCategory(name);
		if (pieceCategory.HasValue)
		{
			isNew = false;
			return pieceCategory.Value;
		}
		Dictionary<Piece.PieceCategory, string> pieceCategoriesMap = GetPieceCategoriesMap();
		Piece.PieceCategory key;
		foreach (KeyValuePair<Piece.PieceCategory, string> item in pieceCategoriesMap)
		{
			if (item.Value == name)
			{
				key = item.Key;
				OtherPieceCategories[name] = key;
				isNew = false;
				return key;
			}
		}
		key = (Piece.PieceCategory)(pieceCategoriesMap.Count - 1);
		if (key >= PieceUtils.VanillaAllPieceCategory)
		{
			key++;
		}
		PieceCategories[name] = key;
		string token = GetCategoryToken(name);
		LocalizationManager.Instance.JotunnLocalization.AddTranslation(in token, name);
		isNew = true;
		return key;
	}

	private GameObject CreateCategoryTab()
	{
		GameObject gameObject = Hud.instance.m_pieceCategoryTabs[0];
		GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject, gameObject.transform.parent);
		gameObject2.SetActive(value: false);
		UIInputHandler orAddComponent = gameObject2.GetOrAddComponent<UIInputHandler>();
		orAddComponent.m_onLeftDown = (Action<UIInputHandler>)Delegate.Combine(orAddComponent.m_onLeftDown, new Action<UIInputHandler>(Hud.instance.OnLeftClickCategory));
		TMP_Text[] componentsInChildren = gameObject2.GetComponentsInChildren<TMP_Text>(includeInactive: true);
		foreach (TMP_Text val in componentsInChildren)
		{
			val.rectTransform.offsetMin = new Vector2(3f, 1f);
			val.rectTransform.offsetMax = new Vector2(-3f, -1f);
			val.enableAutoSizing = true;
			val.fontSizeMin = 10f;
			val.fontSizeMax = 20f;
			val.lineSpacing = 0.8f;
			val.textWrappingMode = (TextWrappingModes)1;
			val.overflowMode = (TextOverflowModes)3;
		}
		return gameObject2;
	}

	private void RefreshCategoriesIfNeeded()
	{
		if (categoryRefreshNeeded)
		{
			categoryRefreshNeeded = false;
			RefreshCategories();
		}
	}

	/// <summary>
	///     Updates the piece categories, should be called after setting the m_category field of a piece.
	/// </summary>
	private void RefreshCategories()
	{
		CreateCategoryTabs();
		if (!Player.m_localPlayer)
		{
			return;
		}
		PieceTable buildPieces = Player.m_localPlayer.m_buildPieces;
		if ((bool)buildPieces)
		{
			RectTransform rectTransform = (RectTransform)Hud.instance.m_pieceCategoryTabs[0].transform;
			RectTransform rectTransform2 = (RectTransform)Hud.instance.m_pieceCategoryRoot.transform;
			RectTransform rectTransform3 = (RectTransform)Hud.instance.m_pieceSelectionWindow.transform;
			if (rectTransform.parent.TryGetComponent<HorizontalLayoutGroup>(out var component))
			{
				((Behaviour)(object)component).enabled = false;
			}
			Vector2 size = rectTransform.rect.size;
			HashSet<Piece.PieceCategory> visibleCategories = CategoriesInPieceTable(buildPieces);
			UpdatePieceTableCategories(buildPieces, visibleCategories);
			int num = Mathf.Max((int)(rectTransform2.rect.width / size.x), 1);
			int count = buildPieces.m_categories.Count;
			if (rectTransform.parent.TryGetComponent<GridLayoutGroup>(out var component2))
			{
				component2.constraintCount = num;
			}
			float x = (0f - size.x) * (float)num / 2f + size.x / 2f;
			float y = (size.y + 1f) * Mathf.Floor((float)(count - 1) / (float)num) + 5f;
			Vector2 vector = new Vector2(x, y);
			int num2 = 0;
			for (int i = 0; i < buildPieces.m_categories.Count; i++)
			{
				GameObject gameObject = Hud.instance.m_pieceCategoryTabs[i];
				RectTransform component3 = gameObject.GetComponent<RectTransform>();
				float x2 = size.x * (float)(num2 % num);
				float y2 = (0f - (size.y + 1f)) * (Mathf.Floor((float)num2 / (float)num) + 0.5f);
				component3.anchoredPosition = vector + new Vector2(x2, y2);
				component3.anchorMin = new Vector2(0.5f, 1f);
				component3.anchorMax = new Vector2(0.5f, 1f);
				num2++;
			}
			RectTransform rectTransform4 = (RectTransform)(rectTransform3.Find("Bkg2")?.transform);
			if ((bool)rectTransform4)
			{
				float y3 = (size.y + 1f) * (float)Mathf.Max(0, Mathf.FloorToInt((float)(num2 - 1) / (float)num));
				rectTransform4.offsetMax = new Vector2(rectTransform4.offsetMax.x, y3);
			}
			else
			{
				Logger.LogWarning("Category Refresh: Could not find background image, skipping resize");
			}
			Hud.instance.GetComponentInParent<Localize>().RefreshLocalization();
		}
	}

	private void UpdatePieceTableCategories(PieceTable pieceTable, HashSet<Piece.PieceCategory> visibleCategories)
	{
		for (int i = 0; i < (int)PieceUtils.VanillaMaxPieceCategory; i++)
		{
			Piece.PieceCategory pieceCategory = (Piece.PieceCategory)i;
			if (visibleCategories.Contains(pieceCategory) && !pieceTable.m_categories.Contains(pieceCategory))
			{
				pieceTable.m_categories.Add(pieceCategory);
				pieceTable.m_categoryLabels.Add(GetVanillaLabel(pieceCategory));
			}
			if (!visibleCategories.Contains(pieceCategory) && pieceTable.m_categories.Contains(pieceCategory))
			{
				int index = pieceTable.m_categories.IndexOf(pieceCategory);
				pieceTable.m_categories.RemoveAt(index);
				pieceTable.m_categoryLabels.RemoveAt(index);
			}
		}
		foreach (KeyValuePair<string, Piece.PieceCategory> pieceCategory2 in PieceCategories)
		{
			string key = pieceCategory2.Key;
			Piece.PieceCategory value = pieceCategory2.Value;
			if (visibleCategories.Contains(value) && !pieceTable.m_categories.Contains(value))
			{
				pieceTable.m_categories.Add(value);
				pieceTable.m_categoryLabels.Add("$" + GetCategoryToken(key));
			}
			if (!visibleCategories.Contains(value) && pieceTable.m_categories.Contains(value))
			{
				int index2 = pieceTable.m_categories.IndexOf(value);
				pieceTable.m_categories.RemoveAt(index2);
				pieceTable.m_categoryLabels.RemoveAt(index2);
			}
		}
	}

	private string GetVanillaLabel(Piece.PieceCategory category)
	{
		if (!vanillaLabels.ContainsKey(category))
		{
			SearchVanillaLabels();
		}
		if (!vanillaLabels.TryGetValue(category, out var value))
		{
			return string.Empty;
		}
		return value;
	}

	private void SearchVanillaLabels()
	{
		PieceTable[] array = Resources.FindObjectsOfTypeAll<PieceTable>();
		foreach (PieceTable pieceTable in array)
		{
			for (int j = 0; j < pieceTable.m_categories.Count; j++)
			{
				Piece.PieceCategory key = pieceTable.m_categories[j];
				if (j < pieceTable.m_categoryLabels.Count && !vanillaLabels.ContainsKey(key) && !string.IsNullOrEmpty(pieceTable.m_categoryLabels[j]))
				{
					vanillaLabels[key] = pieceTable.m_categoryLabels[j];
				}
			}
		}
	}
}
