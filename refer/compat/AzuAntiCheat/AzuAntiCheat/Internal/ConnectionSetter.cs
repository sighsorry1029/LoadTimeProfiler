using System;

namespace AzuAnticheat.Internal;

internal interface ConnectionSetter
{
	Type Resolve(Type staticType, object? actualValue);
}
