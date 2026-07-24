namespace AzuAnticheat.Internal;

internal sealed class StrategyAuthentication : ConfigSetter
{
	public static readonly ConfigSetter _ProcessorAuthentication;

	internal static StrategyAuthentication ConcatIssuer;

	private StrategyAuthentication()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public string Apply(string value)
	{
		return PredicateInvocation.ToCamelCase(value).ToLower();
	}

	static StrategyAuthentication()
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 2:
				GetterIssuer.DeleteInitializer();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb != 0)
				{
					num2 = 1;
				}
				break;
			case 0:
				return;
			case 1:
				_ProcessorAuthentication = new StrategyAuthentication();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool NewIssuer()
	{
		return ConcatIssuer == null;
	}

	internal static StrategyAuthentication AddIssuer()
	{
		return ConcatIssuer;
	}
}
