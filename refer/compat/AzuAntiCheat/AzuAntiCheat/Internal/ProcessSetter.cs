using System;

namespace AzuAnticheat.Internal;

internal interface ProcessSetter
{
	event Action<object?> ValueAvailable;
}
