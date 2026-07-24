using System;

namespace AzuAnticheat.Internal;

internal interface WrapperSetter
{
	bool Deserialize(CandidateInterpreter reader, Type expectedType, Func<CandidateInterpreter, Type, object?> nestedObjectDeserializer, out object? value);
}
