using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal interface InterpreterReader<T, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] TT> : IDictionary<T, TT>, ICollection<KeyValuePair<T, TT>>, IEnumerable<KeyValuePair<T, TT>>, IEnumerable
{
	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1, 1 })]
	KeyValuePair<T, TT> this[int index]
	{
		[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1, 1 })]
		get;
		[param: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1, 1 })]
		set;
	}

	void Insert(int index, T key, TT value);

	void RemoveAt(int index);
}
