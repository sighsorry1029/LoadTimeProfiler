namespace AzuAnticheat.Internal;

internal class GetterIssuer
{
	private static bool m_CodeIssuer;

	private static GetterIssuer PopInitializer;

	internal static void DeleteInitializer()
	{
	}

	internal static bool PostInitializer()
	{
		return PopInitializer == null;
	}

	internal static GetterIssuer CallInitializer()
	{
		return PopInitializer;
	}
}
