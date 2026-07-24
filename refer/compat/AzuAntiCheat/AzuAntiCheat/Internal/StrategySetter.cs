using System;

namespace AzuAnticheat.Internal;

internal interface StrategySetter
{
	bool Accepts(Type type);

	object? ReadYaml(CandidateInterpreter parser, Type type);

	void WriteYaml(MockInterpreter emitter, object? value, Type type);
}
