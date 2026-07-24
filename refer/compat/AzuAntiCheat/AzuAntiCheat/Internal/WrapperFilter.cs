using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class WrapperFilter : BroadcasterPrototype
{
	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(1)]
	public static readonly BroadcasterPrototype m_ServerFilter;

	internal static WrapperFilter ReadAnnotation;

	[Obsolete("Use the Instance static field instead of creating new instances")]
	public WrapperFilter()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd == 0)
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
		return value;
	}

	static WrapperFilter()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				m_ServerFilter = new WrapperFilter();
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 == 0)
				{
					num2 = 1;
				}
				break;
			case 2:
				return;
			case 1:
				GetterIssuer.DeleteInitializer();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool ViewAnnotation()
	{
		return ReadAnnotation == null;
	}

	internal static WrapperFilter InitAnnotation()
	{
		return ReadAnnotation;
	}
}
