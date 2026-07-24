using System;

namespace AzuAnticheat.Internal;

internal sealed class StubAuthentication : ConfigSetter
{
	public static readonly ConfigSetter m_PolicyAuthentication;

	private static StubAuthentication PopIssuer;

	[Obsolete("Use the Instance static field instead of creating new instances")]
	public StubAuthentication()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 == 0)
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
		return PredicateInvocation.FromCamelCase(value, DicSingleton.gE3WbyDVW(-1075938037 ^ -1075940969));
	}

	static StubAuthentication()
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				m_PolicyAuthentication = new StubAuthentication();
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb != 0)
				{
					num2 = 2;
				}
				break;
			case 2:
				return;
			}
		}
	}

	internal static bool PostIssuer()
	{
		return PopIssuer == null;
	}

	internal static StubAuthentication CallIssuer()
	{
		return PopIssuer;
	}
}
