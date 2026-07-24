using System;

namespace AzuAnticheat.Internal;

internal sealed class ParamAuthentication : WrapperSetter
{
	internal static ParamAuthentication SetMock;

	public bool Deserialize(CandidateInterpreter parser, Type expectedType, Func<CandidateInterpreter, Type, object?> nestedObjectDeserializer, out object? value)
	{
		value = null;
		if (parser.Accept<OrderSingleton>(out var @event) && NodeIsNull(@event))
		{
			parser.SkipThisAndNestedEvents();
			return true;
		}
		return false;
	}

	private bool NodeIsNull(OrderSingleton nodeEvent)
	{
		int num = 1;
		string value = default(string);
		BridgeSingleton bridgeSingleton = default(BridgeSingleton);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 6:
					if (!(value == DicSingleton.gE3WbyDVW(0x9000142 ^ 0x9004826)))
					{
						num = 10;
						break;
					}
					goto IL_011b;
				case 11:
					value = bridgeSingleton.Value;
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d == 0)
					{
						num2 = 3;
					}
					continue;
				case 1:
					if (nodeEvent.Tag == DicSingleton.gE3WbyDVW(-525002617 ^ -524976775))
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					bridgeSingleton = nodeEvent as BridgeSingleton;
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 == 0)
					{
						num2 = 8;
					}
					continue;
				default:
					return true;
				case 5:
					return value == DicSingleton.gE3WbyDVW(-1180565667 ^ -1180592911);
				case 7:
					return false;
				case 4:
					if (!(value == ""))
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f == 0)
						{
							num2 = 2;
						}
						continue;
					}
					goto IL_011b;
				case 9:
					if (bridgeSingleton.Style == (ConnectionInterpreter)1)
					{
						num2 = 3;
						continue;
					}
					goto case 7;
				case 10:
					if (!(value == DicSingleton.gE3WbyDVW(0x4995986C ^ 0x4995F3CC)))
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 == 0)
						{
							num2 = 5;
						}
						continue;
					}
					goto IL_011b;
				case 2:
					if (!(value == DicSingleton.gE3WbyDVW(0x602C149E ^ 0x602C7F04)))
					{
						num2 = 6;
						continue;
					}
					goto IL_011b;
				case 3:
					if (bridgeSingleton.IsKey)
					{
						num = 7;
						break;
					}
					goto case 11;
				case 8:
					{
						if (bridgeSingleton != null)
						{
							num = 9;
							break;
						}
						goto case 7;
					}
					IL_011b:
					return true;
				}
				break;
			}
		}
	}

	public ParamAuthentication()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool PushMock()
	{
		return SetMock == null;
	}

	internal static ParamAuthentication ValidateMock()
	{
		return SetMock;
	}
}
