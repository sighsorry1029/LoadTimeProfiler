using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class CreatorFilter : BroadcasterPrototype
{
	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(1)]
	public static readonly BroadcasterPrototype m_PrinterFilter;

	private static CreatorFilter CalcAnnotation;

	[Obsolete("Use the Instance static field instead of creating new instances")]
	public CreatorFilter()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 != 0)
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
		return FacadeInterceptor.FromCamelCase(value, DicSingleton.gE3WbyDVW(-1011281439 ^ -1011262469));
	}

	static CreatorFilter()
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 != 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				return;
			default:
				m_PrinterFilter = new CreatorFilter();
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 == 0)
				{
					num2 = 2;
				}
				break;
			}
		}
	}

	internal static bool LogoutAnnotation()
	{
		return CalcAnnotation == null;
	}

	internal static CreatorFilter CountAnnotation()
	{
		return CalcAnnotation;
	}
}
