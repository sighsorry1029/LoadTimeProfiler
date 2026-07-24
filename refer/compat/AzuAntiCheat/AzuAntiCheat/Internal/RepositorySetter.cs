using System;

namespace AzuAnticheat.Internal;

internal interface RepositorySetter
{
	void SerializeValue(MockInterpreter emitter, object? value, Type? type);
}
