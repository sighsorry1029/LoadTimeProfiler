using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class MessageFilter : BroadcasterPrototype
{
	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(1)]
	public static readonly BroadcasterPrototype m_ExporterFilter;

	private static MessageFilter AddAnnotation;

	[Obsolete("Use the Instance static field instead of creating new instances")]
	public MessageFilter()
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

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	public string Apply(string value)
	{
		return FacadeInterceptor.FromCamelCase(value, DicSingleton.gE3WbyDVW(0x3A437A88 ^ 0x3A437614));
	}

	static MessageFilter()
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 1:
				m_ExporterFilter = new MessageFilter();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			case 2:
				GetterIssuer.DeleteInitializer();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4fda3adbb4ec45bdb14fe2ef97e570a8 != 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	internal static bool PrepareAnnotation()
	{
		return AddAnnotation == null;
	}

	internal static MessageFilter WriteAnnotation()
	{
		return AddAnnotation;
	}
}
