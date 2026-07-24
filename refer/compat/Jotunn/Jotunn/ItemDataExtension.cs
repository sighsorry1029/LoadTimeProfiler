namespace Jotunn;

/// <summary>
///     Extends ItemData with a TokenName.
/// </summary>
public static class ItemDataExtension
{
	/// <summary>
	///     m_shared.m_name
	/// </summary>
	/// <param name="self"></param>
	/// <returns></returns>
	public static string TokenName(this ItemDrop.ItemData self)
	{
		return self.m_shared.m_name;
	}
}
