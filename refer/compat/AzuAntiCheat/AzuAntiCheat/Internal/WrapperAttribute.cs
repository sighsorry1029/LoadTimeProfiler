namespace AzuAnticheat.Internal;

internal static class WrapperAttribute
{
	internal static WrapperAttribute ReadAttribute;

	public static bool IsPowerOfTwo(this int value)
	{
		return (value & (value - 1)) == 0;
	}

	internal static bool ViewAttribute()
	{
		return ReadAttribute == null;
	}

	internal static WrapperAttribute InitAttribute()
	{
		return ReadAttribute;
	}
}
