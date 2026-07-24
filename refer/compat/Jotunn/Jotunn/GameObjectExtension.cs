using UnityEngine;

namespace Jotunn;

/// <summary>
///     Extends GameObject with a check if the GameObject is valid
/// </summary>
public static class GameObjectExtension
{
	/// <summary>
	///     Check for validity
	/// </summary>
	/// <param name="self"></param>
	/// <returns></returns>
	public static bool IsValid(this GameObject self)
	{
		string text = self.name;
		if (text.IndexOf('(') > 0)
		{
			text = text.Substring(self.name.IndexOf('(')).Trim();
		}
		if (string.IsNullOrEmpty(text))
		{
			Logger.LogError("GameObject must have a name!");
			return false;
		}
		if ((bool)self.GetComponent<ZNetView>() && self.name.IndexOfAny(new char[2] { ')', ' ' }) > 0)
		{
			Logger.LogError("GameObject name '" + self.name + "' must not contain parenthesis or spaces!");
			return false;
		}
		return true;
	}
}
