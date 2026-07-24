using System;

namespace AzuAnticheat.Internal;

internal interface ImporterSetter
{
	object? Value { get; }

	Type Type { get; }

	Type StaticType { get; }

	ConnectionInterpreter ScalarStyle { get; }
}
