using System;
using System.Collections.Generic;
using System.Reflection;
using Jotunn.Configs;
using Jotunn.Utils;
using UnityEngine;

namespace Jotunn.Entities;

/// <summary>
///     Main interface for adding custom piece tables to the game.<br />
///     All custom piece tables have to be wrapped inside this class 
///     to add it to Jötunns <see cref="T:Jotunn.Managers.PieceManager" />.<br />
///     Add strings to <see cref="P:Jotunn.Entities.CustomPieceTable.Categories" /> to use custom categories on your
///     piece table. All categories will be replaced so list vanilla categories, too.
/// </summary>
public class CustomPieceTable : CustomEntity
{
	private string fallbackPieceTableName;

	/// <summary>
	///     The prefab for this custom piece table.
	/// </summary>
	public GameObject PieceTablePrefab { get; }

	/// <summary>
	///     The <see cref="T:PieceTable" /> component for this custom piece table as a shortcut.
	/// </summary>
	public PieceTable PieceTable { get; }

	/// <summary>
	///     String array of categories used on the <see cref="T:PieceTable" />. 
	///     Will be ignored when m_useCategories is false.<br />
	///     All categories provided here will be used and displayed on the <see cref="T:Hud" />.
	/// </summary>
	public string[] Categories { get; set; } = Array.Empty<string>();

	private string PieceTableName
	{
		get
		{
			if (!PieceTablePrefab)
			{
				return fallbackPieceTableName;
			}
			return PieceTablePrefab.name;
		}
	}

	/// <summary>
	///     Custom piece table from a prefab.
	/// </summary>
	/// <param name="pieceTablePrefab">The prefab for this custom piece table. It has to have a <see cref="P:Jotunn.Entities.CustomPieceTable.PieceTable" /> component attached</param>
	public CustomPieceTable(GameObject pieceTablePrefab)
		: base(Assembly.GetCallingAssembly())
	{
		PieceTablePrefab = pieceTablePrefab;
		PieceTable = pieceTablePrefab.GetComponent<PieceTable>();
		if (PieceTable != null)
		{
			List<string> list = new List<string>();
			for (int i = 0; i < (int)PieceUtils.VanillaMaxPieceCategory; i++)
			{
				list.Add(Enum.GetName(typeof(Piece.PieceCategory), i));
			}
			Categories = list.ToArray();
		}
	}

	/// <summary>
	///     Custom piece table from a prefab with a <see cref="T:Jotunn.Configs.PieceTableConfig" /> attached.
	/// </summary>
	/// <param name="pieceTablePrefab">The prefab for this custom piece table. It has to have a <see cref="P:Jotunn.Entities.CustomPieceTable.PieceTable" /> component attached.</param>
	/// <param name="config">The <see cref="T:Jotunn.Configs.PieceTableConfig" /> for this custom piece table.</param>
	public CustomPieceTable(GameObject pieceTablePrefab, PieceTableConfig config)
		: base(Assembly.GetCallingAssembly())
	{
		PieceTablePrefab = pieceTablePrefab;
		config.Apply(pieceTablePrefab);
		PieceTable = pieceTablePrefab.GetComponent<PieceTable>();
		Categories = config.GetCategories();
	}

	/// <summary>
	///     "Empty" custom piece table with a <see cref="T:Jotunn.Configs.PieceTableConfig" /> attached.
	/// </summary>
	/// <param name="name">The name of the custom piece table.</param>
	/// <param name="config">The <see cref="T:Jotunn.Configs.PieceTableConfig" /> for this custom piece table.</param>
	public CustomPieceTable(string name, PieceTableConfig config)
		: base(Assembly.GetCallingAssembly())
	{
		PieceTablePrefab = new GameObject(name);
		PieceTable = PieceTablePrefab.AddComponent<PieceTable>();
		config.Apply(PieceTablePrefab);
		Categories = config.GetCategories();
	}

	/// <summary>
	///     Custom piece table from a prefab loaded from an <see cref="T:UnityEngine.AssetBundle" /> with a <see cref="T:Jotunn.Configs.PieceTableConfig" /> attached.
	/// </summary>
	/// <param name="assetBundle">A preloaded <see cref="T:UnityEngine.AssetBundle" /></param>
	/// <param name="assetName">Name of the prefab in the bundle. It has to have a <see cref="P:Jotunn.Entities.CustomPieceTable.PieceTable" /> component attached.</param>
	/// <param name="config">The <see cref="T:Jotunn.Configs.PieceTableConfig" /> for this custom piece table.</param>
	public CustomPieceTable(AssetBundle assetBundle, string assetName, PieceTableConfig config)
		: base(Assembly.GetCallingAssembly())
	{
		fallbackPieceTableName = assetName;
		if (AssetUtils.TryLoadPrefab(base.SourceMod, assetBundle, assetName, out var prefab))
		{
			PieceTablePrefab = prefab;
			config.Apply(PieceTablePrefab);
			PieceTable = PieceTablePrefab.GetComponent<PieceTable>();
			Categories = config.GetCategories();
		}
	}

	/// <summary>
	///     Checks if a custom piece table is valid (i.e. has a prefab and a PieceTable component).
	/// </summary>
	/// <returns>true if all criteria is met</returns>
	public bool IsValid()
	{
		bool result = true;
		if (!PieceTablePrefab)
		{
			Logger.LogError(base.SourceMod, $"CustomPieceTable '{this}' has no prefab");
			result = false;
		}
		if ((bool)PieceTablePrefab && !PieceTablePrefab.IsValid())
		{
			result = false;
		}
		if (PieceTable == null)
		{
			Logger.LogError(base.SourceMod, $"CustomPieceTable '{this}' has no PieceTable component");
			result = false;
		}
		return result;
	}

	/// <inheritdoc />
	public override bool Equals(object obj)
	{
		return obj.GetHashCode() == GetHashCode();
	}

	/// <inheritdoc />
	public override int GetHashCode()
	{
		return StringExtensionMethods.GetStableHashCode(PieceTableName);
	}

	/// <inheritdoc />
	public override string ToString()
	{
		return PieceTableName;
	}
}
