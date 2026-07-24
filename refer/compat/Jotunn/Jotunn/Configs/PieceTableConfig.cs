using System;
using System.Collections.Generic;
using Jotunn.Utils;
using UnityEngine;

namespace Jotunn.Configs;

/// <summary>
///     Configuration class for adding custom piece tables.
/// </summary>
public class PieceTableConfig
{
	/// <summary>
	///     Indicator if the <see cref="T:PieceTable" /> uses the vanilla categories. Defaults to <c>true</c>.
	/// </summary>
	public bool UseCategories { get; set; } = true;

	/// <summary>
	///     Indicator if the <see cref="T:PieceTable" /> uses custom categories. Defaults to <c>false</c>.
	/// </summary>
	public bool UseCustomCategories { get; set; }

	/// <summary>
	///     Array of custom categories the <see cref="T:PieceTable" /> uses. 
	///     Will be ignored when <see cref="P:Jotunn.Configs.PieceTableConfig.UseCustomCategories" /> is false.
	/// </summary>
	public string[] CustomCategories { get; set; } = Array.Empty<string>();

	/// <summary>
	///     Indicator if the <see cref="T:PieceTable" /> can also remove pieces. Defaults to <c>true</c>.
	/// </summary>
	public bool CanRemovePieces { get; set; } = true;

	/// <summary>
	///     Creates the final categories array for this <see cref="T:PieceTable" />. 
	///     Adds vanilla categories when <see cref="P:Jotunn.Configs.PieceTableConfig.UseCategories" /> is true.
	///     Adds custom categories when <see cref="P:Jotunn.Configs.PieceTableConfig.UseCustomCategories" /> is true.
	/// </summary>
	/// <returns>Array of category strings.</returns>
	public string[] GetCategories()
	{
		List<string> list = new List<string>();
		if (UseCategories)
		{
			for (int i = 0; i < (int)PieceUtils.VanillaMaxPieceCategory; i++)
			{
				list.Add(Enum.GetName(typeof(Piece.PieceCategory), i));
			}
		}
		if (UseCustomCategories)
		{
			string[] customCategories = CustomCategories;
			foreach (string item in customCategories)
			{
				list.Add(item);
			}
		}
		return list.ToArray();
	}

	/// <summary>
	///     Apply this configs values to a piece table GameObject.
	/// </summary>
	/// <param name="prefab"></param>
	public void Apply(GameObject prefab)
	{
		PieceTable component = prefab.GetComponent<PieceTable>();
		if (component == null)
		{
			Logger.LogWarning("GameObject has no PieceTable attached");
		}
		else
		{
			component.m_canRemovePieces = CanRemovePieces;
		}
	}
}
