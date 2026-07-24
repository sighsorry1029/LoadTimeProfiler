using System;
using System.Collections.Generic;

namespace AzuAnticheat.Internal;

internal interface AdvisorSetter
{
	IEnumerable<RegSetter> GetProperties(Type type, object? container);

	RegSetter GetProperty(Type type, object? container, string name, [ReponseSingleton(true)] bool ignoreUnmatched);
}
