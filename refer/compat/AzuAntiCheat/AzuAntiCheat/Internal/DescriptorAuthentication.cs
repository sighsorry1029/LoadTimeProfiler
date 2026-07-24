using System;

namespace AzuAnticheat.Internal;

internal sealed class DescriptorAuthentication : ConfigSetter
{
	public static readonly ConfigSetter m_DispatcherAuthentication;

	internal static DescriptorAuthentication ViewIssuer;

	[Obsolete("Use the Instance static field instead of creating new instances")]
	public DescriptorAuthentication()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 == 0)
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
		return PredicateInvocation.FromCamelCase(value, DicSingleton.gE3WbyDVW(--1509395337 ^ 0x59F7C193));
	}

	static DescriptorAuthentication()
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb != 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				return;
			default:
				m_DispatcherAuthentication = new DescriptorAuthentication();
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 == 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	internal static bool InitIssuer()
	{
		return ViewIssuer == null;
	}

	internal static DescriptorAuthentication PatchIssuer()
	{
		return ViewIssuer;
	}
}
