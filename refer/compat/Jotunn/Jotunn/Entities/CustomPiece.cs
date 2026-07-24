using System;
using System.Reflection;
using Jotunn.Configs;
using Jotunn.Managers;
using Jotunn.Utils;
using UnityEngine;

namespace Jotunn.Entities;

/// <summary>
///     Main interface for adding custom pieces to the game.<br />
///     All custom pieces have to be wrapped inside this class to add it to Jötunns <see cref="T:Jotunn.Managers.PieceManager" />.
/// </summary>
public class CustomPiece : CustomEntity
{
	private string fallbackPieceName;

	private string category;

	/// <summary>
	///     The prefab for this custom piece.
	/// </summary>
	public GameObject PiecePrefab { get; }

	/// <summary>
	///     The <see cref="T:Piece" /> component for this custom piece as a shortcut. 
	/// </summary>
	public Piece Piece { get; }

	/// <summary>
	///     Name of the <see cref="T:PieceTable" /> this custom piece belongs to.
	/// </summary>
	public string PieceTable { get; set; }

	/// <summary>
	///     Name of the category this custom piece belongs to.<br />
	///     When setting this value, Piece.m_category will be updated as well.
	/// </summary>
	public string Category
	{
		get
		{
			return category;
		}
		set
		{
			category = value;
			if ((bool)Piece && !string.IsNullOrEmpty(category))
			{
				Piece.m_category = PieceManager.Instance.AddPieceCategory(category);
			}
		}
	}

	/// <summary>
	///     Indicator if references from <see cref="T:Jotunn.Entities.Mock`1" />s will be replaced at runtime.
	/// </summary>
	public bool FixReference { get; set; }

	/// <summary>
	///     Indicator if references from configs should get replaced
	/// </summary>
	internal bool FixConfig { get; set; }

	private string PieceName
	{
		get
		{
			if (!PiecePrefab)
			{
				return fallbackPieceName;
			}
			return PiecePrefab.name;
		}
	}

	/// <summary>
	///     Custom piece from a prefab.<br />
	///     Will be added to the <see cref="T:PieceTable" /> provided by name.<br />
	///     Can fix references from <see cref="T:Jotunn.Entities.Mock`1" />s or not.
	/// </summary>
	/// <param name="piecePrefab">The prefab for this custom piece.</param>
	/// <param name="pieceTable">
	///     Name of the <see cref="T:PieceTable" /> the custom piece should be added to.
	///     Can by the "internal" or the <see cref="T:UnityEngine.GameObject" />s name (e.g. "_PieceTableHammer" or "Hammer")
	/// </param>
	/// <param name="fixReference">If true references for <see cref="T:Jotunn.Entities.Mock`1" /> objects get resolved at runtime by Jötunn.</param>
	public CustomPiece(GameObject piecePrefab, string pieceTable, bool fixReference)
		: base(Assembly.GetCallingAssembly())
	{
		PiecePrefab = piecePrefab;
		Piece = piecePrefab.GetComponent<Piece>();
		PieceTable = pieceTable;
		FixReference = fixReference;
	}

	/// <summary>
	///     Custom piece from a prefab with a <see cref="T:Jotunn.Configs.PieceConfig" /> attached.<br />
	///     The members and references from the <see cref="T:Jotunn.Configs.PieceConfig" /> will be referenced by Jötunn at runtime.
	/// </summary>
	/// <param name="piecePrefab">The prefab for this custom piece.</param>
	/// <param name="pieceConfig">The <see cref="T:Jotunn.Configs.PieceConfig" /> for this custom piece.</param>
	[Obsolete("Use CustomPiece(GameObject, bool, PieceConfig) instead and define if references should be fixed")]
	public CustomPiece(GameObject piecePrefab, PieceConfig pieceConfig)
		: base(Assembly.GetCallingAssembly())
	{
		PiecePrefab = piecePrefab;
		Piece = piecePrefab.GetComponent<Piece>();
		PieceTable = pieceConfig.PieceTable;
		FixReference = false;
		FixConfig = true;
		Category = pieceConfig.Category;
		pieceConfig.Apply(piecePrefab);
	}

	/// <summary>
	///     Custom piece from a prefab with a <see cref="T:Jotunn.Configs.PieceConfig" /> attached.<br />
	///     The members and references from the <see cref="T:Jotunn.Configs.PieceConfig" /> will be referenced by Jötunn at runtime.
	/// </summary>
	/// <param name="piecePrefab">The prefab for this custom piece.</param>
	/// <param name="fixReference">If true references for <see cref="T:Jotunn.Entities.Mock`1" /> objects get resolved at runtime by Jötunn.</param>
	/// <param name="pieceConfig">The <see cref="T:Jotunn.Configs.PieceConfig" /> for this custom piece.</param>
	public CustomPiece(GameObject piecePrefab, bool fixReference, PieceConfig pieceConfig)
		: base(Assembly.GetCallingAssembly())
	{
		PiecePrefab = piecePrefab;
		Piece = piecePrefab.GetComponent<Piece>();
		PieceTable = pieceConfig.PieceTable;
		FixReference = fixReference;
		FixConfig = true;
		Category = pieceConfig.Category;
		pieceConfig.Apply(piecePrefab);
	}

	/// <summary>
	///     Custom piece from a prefab loaded from an <see cref="T:UnityEngine.AssetBundle" />.<br />
	///     Will be added to the <see cref="T:PieceTable" /> provided by name.<br />
	///     Can fix references from <see cref="T:Jotunn.Entities.Mock`1" />s or not.
	/// </summary>
	/// <param name="assetBundle">A preloaded <see cref="T:UnityEngine.AssetBundle" /></param>
	/// <param name="assetName">Name of the prefab in the bundle.</param>
	/// <param name="pieceTable">
	///     Name of the <see cref="T:PieceTable" /> the custom piece should be added to.
	///     Can by the "internal" or the <see cref="T:UnityEngine.GameObject" />s name (e.g. "_PieceTableHammer" or "Hammer")
	/// </param>
	/// <param name="fixReference">If true references for <see cref="T:Jotunn.Entities.Mock`1" /> objects get resolved at runtime by Jötunn.</param>
	public CustomPiece(AssetBundle assetBundle, string assetName, string pieceTable, bool fixReference)
		: base(Assembly.GetCallingAssembly())
	{
		fallbackPieceName = assetName;
		if (AssetUtils.TryLoadPrefab(base.SourceMod, assetBundle, assetName, out var prefab))
		{
			PiecePrefab = prefab;
			Piece = PiecePrefab.GetComponent<Piece>();
			PieceTable = pieceTable;
			FixReference = fixReference;
		}
	}

	/// <summary>
	///     Custom piece from a prefab loaded from an <see cref="T:UnityEngine.AssetBundle" /> with a <see cref="T:Jotunn.Configs.PieceConfig" /> attached.<br />
	///     The members and references from the <see cref="T:Jotunn.Configs.PieceConfig" /> will be referenced by Jötunn at runtime.
	/// </summary>
	/// <param name="assetBundle">A preloaded <see cref="T:UnityEngine.AssetBundle" /></param>
	/// <param name="assetName">Name of the prefab in the bundle.</param>
	/// <param name="pieceConfig">The <see cref="T:Jotunn.Configs.PieceConfig" /> for this custom piece.</param>
	[Obsolete("Use CustomPiece(AssetBundle, string, bool, PieceConfig) instead and define if references should be fixed")]
	public CustomPiece(AssetBundle assetBundle, string assetName, PieceConfig pieceConfig)
		: base(Assembly.GetCallingAssembly())
	{
		fallbackPieceName = assetName;
		if (AssetUtils.TryLoadPrefab(base.SourceMod, assetBundle, assetName, out var prefab))
		{
			PiecePrefab = prefab;
			Piece = PiecePrefab.GetComponent<Piece>();
			PieceTable = pieceConfig.PieceTable;
			FixReference = false;
			FixConfig = true;
			Category = pieceConfig.Category;
			pieceConfig.Apply(PiecePrefab);
		}
	}

	/// <summary>
	///     Custom piece from a prefab loaded from an <see cref="T:UnityEngine.AssetBundle" /> with a <see cref="T:Jotunn.Configs.PieceConfig" /> attached.<br />
	///     The members and references from the <see cref="T:Jotunn.Configs.PieceConfig" /> will be referenced by Jötunn at runtime.
	/// </summary>
	/// <param name="assetBundle">A preloaded <see cref="T:UnityEngine.AssetBundle" /></param>
	/// <param name="assetName">Name of the prefab in the bundle.</param>
	/// <param name="fixReference">If true references for <see cref="T:Jotunn.Entities.Mock`1" /> objects get resolved at runtime by Jötunn.</param>
	/// <param name="pieceConfig">The <see cref="T:Jotunn.Configs.PieceConfig" /> for this custom piece.</param>
	public CustomPiece(AssetBundle assetBundle, string assetName, bool fixReference, PieceConfig pieceConfig)
		: base(Assembly.GetCallingAssembly())
	{
		fallbackPieceName = assetName;
		if (AssetUtils.TryLoadPrefab(base.SourceMod, assetBundle, assetName, out var prefab))
		{
			PiecePrefab = prefab;
			Piece = PiecePrefab.GetComponent<Piece>();
			PieceTable = pieceConfig.PieceTable;
			FixReference = fixReference;
			FixConfig = true;
			Category = pieceConfig.Category;
			pieceConfig.Apply(PiecePrefab);
		}
	}

	/// <summary>
	///     Custom piece created as an "empty" primitive.<br />
	///     Will be added to the <see cref="T:PieceTable" /> provided by name.
	/// </summary>
	/// <param name="name">Name of the new prefab. Must be unique.</param>
	/// <param name="addZNetView">If true a ZNetView component will be added to the prefab for network sync.</param>
	/// <param name="pieceTable">
	///     Name of the <see cref="T:PieceTable" /> the custom piece should be added to.
	///     Can by the "internal" or the <see cref="T:UnityEngine.GameObject" />s name (e.g. "_PieceTableHammer" or "Hammer")
	/// </param>
	public CustomPiece(string name, bool addZNetView, string pieceTable)
		: base(Assembly.GetCallingAssembly())
	{
		PiecePrefab = PrefabManager.Instance.CreateEmptyPrefab(name, addZNetView);
		if (!PiecePrefab)
		{
			fallbackPieceName = name;
			return;
		}
		Piece = PiecePrefab.AddComponent<Piece>();
		Piece.m_name = name;
		PieceTable = pieceTable;
	}

	/// <summary>
	///     Custom piece created as an "empty" primitive with a <see cref="T:Jotunn.Configs.PieceConfig" /> attached.<br />
	///     The members and references from the <see cref="T:Jotunn.Configs.PieceConfig" /> will be referenced by Jötunn at runtime.
	/// </summary>
	/// <param name="name">Name of the new prefab. Must be unique.</param>
	/// <param name="addZNetView">If true a ZNetView component will be added to the prefab for network sync.</param>
	/// <param name="pieceConfig">The <see cref="T:Jotunn.Configs.PieceConfig" /> for this custom piece.</param>
	public CustomPiece(string name, bool addZNetView, PieceConfig pieceConfig)
		: base(Assembly.GetCallingAssembly())
	{
		PiecePrefab = PrefabManager.Instance.CreateEmptyPrefab(name, addZNetView);
		if (!PiecePrefab)
		{
			fallbackPieceName = name;
			return;
		}
		Piece = PiecePrefab.AddComponent<Piece>();
		PieceTable = pieceConfig.PieceTable;
		FixConfig = true;
		Category = pieceConfig.Category;
		pieceConfig.Apply(PiecePrefab);
	}

	/// <summary>
	///     Custom piece created as a copy of a vanilla Valheim prefab.<br />
	///     Will be added to the <see cref="T:PieceTable" /> provided by name.
	/// </summary>
	/// <param name="name">The new name of the prefab after cloning.</param>
	/// <param name="baseName">The name of the base prefab the custom item is cloned from.</param>
	/// <param name="pieceTable">
	///     Name of the <see cref="T:PieceTable" /> the custom piece should be added to.
	///     Can by the "internal" or the <see cref="T:UnityEngine.GameObject" />s name (e.g. "_PieceTableHammer" or "Hammer")
	/// </param>
	public CustomPiece(string name, string baseName, string pieceTable)
		: base(Assembly.GetCallingAssembly())
	{
		PiecePrefab = PrefabManager.Instance.CreateClonedPrefab(name, baseName);
		if (!PiecePrefab)
		{
			fallbackPieceName = name;
			return;
		}
		Piece = PiecePrefab.GetComponent<Piece>();
		PieceTable = pieceTable;
	}

	/// <summary>
	///     Custom piece created as a copy of a vanilla Valheim prefab with a <see cref="T:Jotunn.Configs.PieceConfig" /> attached.<br />
	///     The members and references from the <see cref="T:Jotunn.Configs.PieceConfig" /> will be referenced by Jötunn at runtime.
	/// </summary>
	/// <param name="name">The new name of the prefab after cloning.</param>
	/// <param name="baseName">The name of the base prefab the custom item is cloned from.</param>
	/// <param name="pieceConfig">The <see cref="T:Jotunn.Configs.PieceConfig" /> for this custom piece.</param>
	public CustomPiece(string name, string baseName, PieceConfig pieceConfig)
		: base(Assembly.GetCallingAssembly())
	{
		PiecePrefab = PrefabManager.Instance.CreateClonedPrefab(name, baseName);
		if (!PiecePrefab)
		{
			fallbackPieceName = name;
			return;
		}
		Piece = PiecePrefab.GetComponent<Piece>();
		PieceTable = pieceConfig.PieceTable;
		FixConfig = true;
		Category = pieceConfig.Category;
		pieceConfig.Apply(PiecePrefab);
	}

	/// <summary>
	///     Checks if a custom piece is valid (i.e. has a prefab, a target PieceTable is set,
	///     has a <see cref="T:Piece" /> component and that component has an icon).
	/// </summary>
	/// <returns>true if all criteria is met</returns>
	public bool IsValid()
	{
		bool result = true;
		if (!PiecePrefab)
		{
			Logger.LogError(base.SourceMod, $"CustomPiece '{this}' has no prefab");
			result = false;
		}
		if ((bool)PiecePrefab && !PiecePrefab.IsValid())
		{
			result = false;
		}
		if (!Piece)
		{
			Logger.LogError(base.SourceMod, $"CustomPiece '{this}' has no Piece component");
			result = false;
		}
		if ((bool)Piece && !Piece.m_icon)
		{
			Logger.LogError(base.SourceMod, $"CustomPiece '{this}' has no icon");
			result = false;
		}
		if (string.IsNullOrEmpty(PieceTable))
		{
			Logger.LogError(base.SourceMod, $"CustomPiece '{this}' has no PieceTable");
			result = false;
		}
		return result;
	}

	/// <summary>
	///     Helper method to determine if a prefab with a given name is a custom piece created with Jötunn.
	/// </summary>
	/// <param name="prefabName">Name of the prefab to test.</param>
	/// <returns>true if the prefab is added as a custom piece to the <see cref="T:Jotunn.Managers.PieceManager" />.</returns>
	public static bool IsCustomPiece(string prefabName)
	{
		return PieceManager.Instance.Pieces.ContainsKey(prefabName);
	}

	/// <inheritdoc />
	public override bool Equals(object obj)
	{
		return obj.GetHashCode() == GetHashCode();
	}

	/// <inheritdoc />
	public override int GetHashCode()
	{
		return StringExtensionMethods.GetStableHashCode(PieceName);
	}

	/// <inheritdoc />
	public override string ToString()
	{
		return PieceName;
	}
}
