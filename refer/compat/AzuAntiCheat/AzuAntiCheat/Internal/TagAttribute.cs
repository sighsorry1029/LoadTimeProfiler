using System.Collections.Generic;

namespace AzuAnticheat.Internal;

internal static class TagAttribute
{
	public static IReadOnlyList<T> AsReadonlyList<T>(this List<T> list)
	{
		return list;
	}

	public static IReadOnlyDictionary<TKey, TValue> AsReadonlyDictionary<TKey, TValue>(this Dictionary<TKey, TValue> dictionary) where TKey : notnull
	{
		return dictionary;
	}
}
