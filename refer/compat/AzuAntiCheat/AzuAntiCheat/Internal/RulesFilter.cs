using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal class RulesFilter : TaskPrototype
{
	private static RulesFilter ConcatInstance;

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	bool TaskPrototype.Resolve([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] ListenerFactory nodeEvent, ref Type currentType)
	{
		int num = 5;
		int num2 = num;
		ValueFactory tag = default(ValueFactory);
		while (true)
		{
			switch (num2)
			{
			case 3:
				tag = nodeEvent.Tag;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae50b6e347494ff2973fbc64d1fc9236 != 0)
				{
					num2 = 1;
				}
				break;
			case 2:
				throw new TestsFactory(nodeEvent.Start, nodeEvent.End, string.Format(DicSingleton.gE3WbyDVW(0x6CF51E1A ^ 0x6CF57492), nodeEvent.Tag));
			default:
				return false;
			case 5:
				if (nodeEvent == null)
				{
					num2 = 4;
					break;
				}
				goto case 3;
			case 1:
				if (tag.IsEmpty)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f != 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 2;
			}
		}
	}

	public RulesFilter()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool MapInstance()
	{
		return ConcatInstance == null;
	}

	internal static RulesFilter NewInstance()
	{
		return ConcatInstance;
	}
}
