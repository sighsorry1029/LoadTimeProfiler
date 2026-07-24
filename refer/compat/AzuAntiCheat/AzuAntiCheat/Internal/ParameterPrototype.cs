using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[Obsolete("Please use IYamlConvertible instead")]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal interface ParameterPrototype
{
	void ReadYaml(StubReader parser);

	void WriteYaml(ModelReader emitter);
}
