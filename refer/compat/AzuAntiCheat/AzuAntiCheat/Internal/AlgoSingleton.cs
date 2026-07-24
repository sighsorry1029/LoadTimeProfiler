using System.Collections.Generic;

namespace AzuAnticheat.Internal;

internal static class AlgoSingleton
{
	public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> pair, out TKey key, out TValue value)
	{
		key = pair.Key;
		value = pair.Value;
	}
}
