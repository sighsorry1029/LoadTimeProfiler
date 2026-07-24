using System;

namespace Jotunn.Utils;

internal static class PieceUtils
{
	public static Piece.PieceCategory VanillaMaxPieceCategory { get; } = GetVanillaPieceCategory("Max", Piece.PieceCategory.Max);

	public static Piece.PieceCategory VanillaAllPieceCategory { get; } = GetVanillaPieceCategory("All", Piece.PieceCategory.All);

	private static Piece.PieceCategory GetVanillaPieceCategory(string name, Piece.PieceCategory fallback)
	{
		try
		{
			return (Piece.PieceCategory)Enum.Parse(typeof(Piece.PieceCategory), name);
		}
		catch (Exception)
		{
			Logger.LogWarning($"Could not find Piece.PieceCategory {name}, using fallback value {fallback}");
			return fallback;
		}
	}
}
