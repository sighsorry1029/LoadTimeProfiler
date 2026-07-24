using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class PageFilter : WorkerPrototype
{
	private static PageFilter CheckInstance;

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	bool WorkerPrototype.Deserialize(StubReader parser, Type expectedType, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 1, 1, 1, 2 })] Func<StubReader, Type, object> nestedObjectDeserializer, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] out object value)
	{
		value = null;
		if (parser.Accept<ListenerFactory>(out var @event) && NodeIsNull(@event))
		{
			parser.SkipThisAndNestedEvents();
			return true;
		}
		return false;
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	private bool NodeIsNull(ListenerFactory nodeEvent)
	{
		int num = 10;
		int num2 = num;
		string value = default(string);
		ClassFactory classFactory = default(ClassFactory);
		while (true)
		{
			switch (num2)
			{
			default:
				if (!(value == ""))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 == 0)
					{
						num2 = 5;
					}
					break;
				}
				goto case 1;
			case 6:
				if (!(value == DicSingleton.gE3WbyDVW(-1244021215 ^ -1244006587)))
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 == 0)
					{
						num2 = 7;
					}
					break;
				}
				goto case 1;
			case 7:
				if (value == DicSingleton.gE3WbyDVW(0x120E76C ^ 0x1208CCC))
				{
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_49107028423047bfbf9c33e5a2ab8cf8 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 8;
			case 9:
				return true;
			case 3:
				value = classFactory.Value;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4e61b266153f422fa6c595cfef4d40d3 != 0)
				{
					num2 = 0;
				}
				break;
			case 4:
				if (classFactory.Style == (RuleFactory)1)
				{
					num2 = 3;
					break;
				}
				goto IL_0185;
			case 8:
				return value == DicSingleton.gE3WbyDVW(-25744665 ^ -25738933);
			case 1:
			case 2:
				return true;
			case 10:
				if (!(nodeEvent.Tag == DicSingleton.gE3WbyDVW(-1064640644 ^ -1064650110)))
				{
					classFactory = nodeEvent as ClassFactory;
					num2 = 11;
				}
				else
				{
					num2 = 9;
				}
				break;
			case 11:
				if (classFactory != null)
				{
					num2 = 4;
					break;
				}
				goto IL_0185;
			case 5:
				{
					if (value == DicSingleton.gE3WbyDVW(-1398029315 ^ -1398036377))
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e == 0)
						{
							num2 = 1;
						}
						break;
					}
					goto case 6;
				}
				IL_0185:
				return false;
			}
		}
	}

	public PageFilter()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool RateInstance()
	{
		return CheckInstance == null;
	}

	internal static PageFilter ResetInstance()
	{
		return CheckInstance;
	}
}
