using System;

namespace Jotunn;

/// <summary>
///     Extends StatusEffect with a TokenName and a check if the StatusEffect is valid so it can be added to the game.
/// </summary>
public static class RecipeExtension
{
	/// <summary>
	///     Check for validity
	/// </summary>
	/// <param name="self"></param>
	/// <returns></returns>
	public static bool IsValid(this Recipe self)
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
				throw new Exception("Recipe must have a name !");
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
