using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class ResolverPrototype : ContextPrototype
{
	private static ResolverPrototype ForgotConfiguration;

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	public ResolverPrototype(UtilsPrototype source)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(source);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool RestartConfiguration()
	{
		return ForgotConfiguration == null;
	}

	internal static ResolverPrototype GetConfiguration()
	{
		return ForgotConfiguration;
	}
}
