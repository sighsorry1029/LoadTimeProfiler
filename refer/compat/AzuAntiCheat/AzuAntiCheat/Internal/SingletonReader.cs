namespace AzuAnticheat.Internal;

internal static class SingletonReader
{
	private static SingletonReader DefineAuthentication;

	public static bool IsPowerOfTwo(this int value)
	{
		return (value & (value - 1)) == 0;
	}

	internal static bool IncludeAuthentication()
	{
		return DefineAuthentication == null;
	}

	internal static SingletonReader CheckAuthentication()
	{
		return DefineAuthentication;
	}
}
