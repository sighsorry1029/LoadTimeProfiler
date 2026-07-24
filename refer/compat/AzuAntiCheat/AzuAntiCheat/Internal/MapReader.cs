using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal static class MapReader
{
	public static IReadOnlyList<T> AsReadonlyList<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] T>(this List<T> list)
	{
		return list;
	}

	public static IReadOnlyDictionary<TKey, TValue> AsReadonlyDictionary<TKey, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] TValue>(this Dictionary<TKey, TValue> dictionary)
	{
		return dictionary;
	}
}
