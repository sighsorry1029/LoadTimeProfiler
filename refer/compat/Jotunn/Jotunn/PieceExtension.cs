namespace Jotunn;

/// <summary>
///     Extends Piece with a TokenName
/// </summary>
public static class PieceExtension
{
	/// <summary>
	///     m_name
	/// </summary>
	/// <param name="self"></param>
	/// <returns></returns>
	public static string TokenName(this Piece self)
	{
		return self.m_name;
	}
}
