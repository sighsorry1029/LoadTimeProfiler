using System;

namespace AzuAnticheat.Internal;

internal interface ServerSetter
{
	bool Resolve(OrderSingleton? nodeEvent, ref Type currentType);
}
