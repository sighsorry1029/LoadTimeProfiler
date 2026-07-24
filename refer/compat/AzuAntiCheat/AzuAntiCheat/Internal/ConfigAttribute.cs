using System.Collections;
using System.Collections.Generic;

namespace AzuAnticheat.Internal;

internal interface ConfigAttribute<T, TT> : IDictionary<T, TT>, ICollection<KeyValuePair<T, TT>>, IEnumerable<KeyValuePair<T, TT>>, IEnumerable where T : notnull
{
	KeyValuePair<T, TT> this[int index] { get; set; }

	void Insert(int index, T key, TT value);

	void RemoveAt(int index);
}
