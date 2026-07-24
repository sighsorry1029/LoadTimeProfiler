namespace Jotunn;

/// <summary>
///     Extends ItemDrop with a TokenName
/// </summary>
public static class ItemDropExtension
{
	/// <summary>
	///     m_itemData.m_shared.m_name
	/// </summary>
	/// <param name="self"></param>
	/// <returns></returns>
	public static string TokenName(this ItemDrop self)
	{
		return self.m_itemData.m_shared.m_name;
	}
}
