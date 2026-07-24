using System;

namespace AzuAnticheat.Internal;

internal interface TokenInvocation
{
	object? ChangeType(object? value, Type expectedType);
}
