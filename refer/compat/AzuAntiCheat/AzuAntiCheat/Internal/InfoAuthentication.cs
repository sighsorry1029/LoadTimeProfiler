using System;

namespace AzuAnticheat.Internal;

internal sealed class InfoAuthentication : ConfigSetter
{
	public static readonly ConfigSetter m_DicAuthentication;

	private static InfoAuthentication PrepareIssuer;

	[Obsolete("Use the Instance static field instead of creating new instances")]
	public InfoAuthentication()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 != 0)
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
		return value;
	}

	static InfoAuthentication()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				return;
			default:
				m_DicAuthentication = new InfoAuthentication();
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 == 0)
				{
					num2 = 0;
				}
				break;
			case 1:
				GetterIssuer.DeleteInitializer();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool WriteIssuer()
	{
		return PrepareIssuer == null;
	}

	internal static InfoAuthentication PrintIssuer()
	{
		return PrepareIssuer;
	}
}
