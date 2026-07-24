using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class IdentifierFilter : TaskPrototype
{
	internal static IdentifierFilter TestInstance;

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	bool TaskPrototype.Resolve([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] ListenerFactory nodeEvent, ref Type currentType)
	{
		int num = 4;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 6:
				if (!(nodeEvent is RefFactory))
				{
					num2 = 7;
					break;
				}
				goto case 2;
			case 4:
				if (!(currentType == typeof(object)))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb == 0)
					{
						num2 = 3;
					}
					break;
				}
				goto case 6;
			default:
				return true;
			case 3:
				return false;
			case 5:
				currentType = typeof(Dictionary<object, object>);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f == 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				currentType = typeof(List<object>);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 != 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				return true;
			case 7:
				if (nodeEvent is QueueFactory)
				{
					num2 = 5;
					break;
				}
				goto case 3;
			}
		}
	}

	public IdentifierFilter()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool RunInstance()
	{
		return TestInstance == null;
	}

	internal static IdentifierFilter VerifyInstance()
	{
		return TestInstance;
	}
}
