using System;

namespace AzuAnticheat.Internal;

internal sealed class ParamsAuthentication : ConfigSetter
{
	public static readonly ConfigSetter _PoolAuthentication;

	private static ParamsAuthentication CompareIssuer;

	[Obsolete("Use the Instance static field instead of creating new instances")]
	public ParamsAuthentication()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 != 0)
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
		return PredicateInvocation.ToPascalCase(value);
	}

	static ParamsAuthentication()
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
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 == 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				_PoolAuthentication = new ParamsAuthentication();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal static bool CloneIssuer()
	{
		return CompareIssuer == null;
	}

	internal static ParamsAuthentication ReadIssuer()
	{
		return CompareIssuer;
	}
}
