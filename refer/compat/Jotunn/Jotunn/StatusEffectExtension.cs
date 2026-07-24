using System;

namespace Jotunn;

/// <summary>
///     Extends StatusEffect with a TokenName and a check if the StatusEffect is valid so it can be added to the game.
/// </summary>
public static class StatusEffectExtension
{
	/// <summary>
	///     m_name
	/// </summary>
	/// <param name="self"></param>
	/// <returns></returns>
	public static string TokenName(this StatusEffect self)
	{
		return self.m_name;
	}

	/// <summary>
	///     Check for validity
	/// </summary>
	/// <param name="self"></param>
	/// <returns></returns>
	public static bool IsValid(this StatusEffect self)
	{
		try
		{
			string text = self.name;
			if (text.IndexOf('(') > 0)
			{
				text = text.Substring(self.name.IndexOf('(')).Trim();
			}
			if (string.IsNullOrEmpty(text))
			{
				throw new Exception("StatusEffect must have a name !");
			}
			return true;
		}
		catch (Exception data)
		{
			Logger.LogError(data);
			return false;
		}
	}
}
