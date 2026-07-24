using System;

namespace AzuAnticheat.Internal;

internal sealed class TagAuthentication : ConfigSetter
{
	public static readonly ConfigSetter m_VisitorAuthentication;

	private static TagAuthentication TestIssuer;

	[Obsolete("Use the Instance static field instead of creating new instances")]
	public TagAuthentication()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 != 0)
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
		return PredicateInvocation.ToCamelCase(value);
	}

	static TagAuthentication()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				GetterIssuer.DeleteInitializer();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b == 0)
				{
					num2 = 0;
				}
				break;
			default:
				m_VisitorAuthentication = new TagAuthentication();
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 != 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				return;
			}
		}
	}

	internal static bool RunIssuer()
	{
		return TestIssuer == null;
	}

	internal static TagAuthentication VerifyIssuer()
	{
		return TestIssuer;
	}
}
