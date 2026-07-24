using System.Reflection;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal static class ListenerBase
{
	internal static ListenerBase CalculateSingleton;

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	public static object ReadValue(this PropertyInfo property, object target)
	{
		return property.GetValue(target, null);
	}

	internal static bool MoveSingleton()
	{
		return CalculateSingleton == null;
	}

	internal static ListenerBase RevertSingleton()
	{
		return CalculateSingleton;
	}
}
