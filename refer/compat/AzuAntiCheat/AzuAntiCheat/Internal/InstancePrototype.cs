using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal interface InstancePrototype
{
	IEnumerable<RequestPrototype> GetProperties(Type type, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] object container);

	RequestPrototype GetProperty(Type type, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] object container, string name, [StrategyBase(true)] bool ignoreUnmatched);
}
