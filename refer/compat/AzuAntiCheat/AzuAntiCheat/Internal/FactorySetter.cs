using System.Reflection;

namespace AzuAnticheat.Internal;

internal static class FactorySetter
{
	internal static FactorySetter MoveObject;

	public static object? ReadValue(this PropertyInfo property, object target)
	{
		return property.GetValue(target, null);
	}

	internal static bool RevertObject()
	{
		return MoveObject == null;
	}

	internal static FactorySetter InvokeParameter()
	{
		return MoveObject;
	}
}
