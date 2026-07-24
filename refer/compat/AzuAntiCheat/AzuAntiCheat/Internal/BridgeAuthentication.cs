using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace AzuAnticheat.Internal;

internal sealed class BridgeAuthentication : WrapperSetter
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public string testAuthentication;

		public BridgeAuthentication attrAuthentication;

		private static _003C_003Ec__DisplayClass11_0 ExcludeMock;

		public _003C_003Ec__DisplayClass11_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal object _003CAttemptUnknownTypeDeserialization_003Eb__0()
		{
			return Convert.ToByte(testAuthentication, 16);
		}

		internal object _003CAttemptUnknownTypeDeserialization_003Eb__1()
		{
			return Convert.ToInt16(testAuthentication, 16);
		}

		internal object _003CAttemptUnknownTypeDeserialization_003Eb__2()
		{
			return Convert.ToInt32(testAuthentication, 16);
		}

		internal object _003CAttemptUnknownTypeDeserialization_003Eb__3()
		{
			return Convert.ToInt64(testAuthentication, 16);
		}

		internal object _003CAttemptUnknownTypeDeserialization_003Eb__4()
		{
			return Convert.ToUInt64(testAuthentication, 16);
		}

		internal object _003CAttemptUnknownTypeDeserialization_003Eb__5()
		{
			return Convert.ToByte(testAuthentication, 8);
		}

		internal object _003CAttemptUnknownTypeDeserialization_003Eb__6()
		{
			return Convert.ToInt16(testAuthentication, 8);
		}

		internal object _003CAttemptUnknownTypeDeserialization_003Eb__7()
		{
			return Convert.ToInt32(testAuthentication, 8);
		}

		internal object _003CAttemptUnknownTypeDeserialization_003Eb__8()
		{
			return Convert.ToInt64(testAuthentication, 8);
		}

		internal object _003CAttemptUnknownTypeDeserialization_003Eb__9()
		{
			return Convert.ToUInt64(testAuthentication, 8);
		}

		internal object _003CAttemptUnknownTypeDeserialization_003Eb__10()
		{
			return byte.Parse(testAuthentication, attrAuthentication.merchantAuthentication.NumberFormat);
		}

		internal object _003CAttemptUnknownTypeDeserialization_003Eb__11()
		{
			return short.Parse(testAuthentication, attrAuthentication.merchantAuthentication.NumberFormat);
		}

		internal object _003CAttemptUnknownTypeDeserialization_003Eb__12()
		{
			return int.Parse(testAuthentication, attrAuthentication.merchantAuthentication.NumberFormat);
		}

		internal object _003CAttemptUnknownTypeDeserialization_003Eb__13()
		{
			return long.Parse(testAuthentication, attrAuthentication.merchantAuthentication.NumberFormat);
		}

		internal object _003CAttemptUnknownTypeDeserialization_003Eb__14()
		{
			return ulong.Parse(testAuthentication, attrAuthentication.merchantAuthentication.NumberFormat);
		}

		internal object _003CAttemptUnknownTypeDeserialization_003Eb__15()
		{
			return float.Parse(testAuthentication, attrAuthentication.merchantAuthentication.NumberFormat);
		}

		internal object _003CAttemptUnknownTypeDeserialization_003Eb__16()
		{
			return double.Parse(testAuthentication, attrAuthentication.merchantAuthentication.NumberFormat);
		}

		internal static bool InterruptMock()
		{
			return ExcludeMock == null;
		}

		internal static _003C_003Ec__DisplayClass11_0 DeleteMock()
		{
			return ExcludeMock;
		}
	}

	private readonly bool m_ParameterAuthentication;

	private readonly TokenInvocation statusAuthentication;

	private readonly PublisherInvocation merchantAuthentication;

	private static BridgeAuthentication UpdateMock;

	public BridgeAuthentication(bool attemptUnknownTypeDeserialization, TokenInvocation typeConverter, PublisherInvocation formatter)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ea4c8b68ad954c0fb4df33d6e06bd4a3 == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 3:
				merchantAuthentication = formatter;
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
				{
					num = 0;
				}
				break;
			case 1:
				return;
			default:
				m_ParameterAuthentication = attemptUnknownTypeDeserialization;
				num = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a579dea83d2144838086d2d400bd0222 != 0)
				{
					num = 2;
				}
				break;
			case 2:
				statusAuthentication = typeConverter ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1880453928 ^ -1880434306));
				num = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b != 0)
				{
					num = 3;
				}
				break;
			}
		}
	}

	public bool Deserialize(CandidateInterpreter parser, Type expectedType, Func<CandidateInterpreter, Type, object?> nestedObjectDeserializer, out object? value)
	{
		if (!parser.TryConsume<BridgeSingleton>(out var @event))
		{
			value = null;
			return false;
		}
		Type type = Nullable.GetUnderlyingType(expectedType) ?? expectedType;
		if (InterceptorSetter.IsEnum(type))
		{
			value = Enum.Parse(type, @event.Value, ignoreCase: true);
			return true;
		}
		TypeCode typeCode = InterceptorSetter.GetTypeCode(type);
		switch (typeCode)
		{
		case TypeCode.Boolean:
			value = DeserializeBooleanHelper(@event.Value);
			break;
		case TypeCode.SByte:
		case TypeCode.Byte:
		case TypeCode.Int16:
		case TypeCode.UInt16:
		case TypeCode.Int32:
		case TypeCode.UInt32:
		case TypeCode.Int64:
		case TypeCode.UInt64:
			value = DeserializeIntegerHelper(typeCode, @event.Value);
			break;
		case TypeCode.Single:
			value = float.Parse(@event.Value, merchantAuthentication.NumberFormat);
			break;
		case TypeCode.Double:
			value = double.Parse(@event.Value, merchantAuthentication.NumberFormat);
			break;
		case TypeCode.Decimal:
			value = decimal.Parse(@event.Value, merchantAuthentication.NumberFormat);
			break;
		case TypeCode.String:
			value = @event.Value;
			break;
		case TypeCode.Char:
			value = @event.Value[0];
			break;
		case TypeCode.DateTime:
			value = DateTime.Parse(@event.Value, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
			break;
		default:
			if (expectedType == typeof(object))
			{
				if (!@event.IsKey && m_ParameterAuthentication)
				{
					value = AttemptUnknownTypeDeserialization(@event);
				}
				else
				{
					value = @event.Value;
				}
			}
			else
			{
				value = statusAuthentication.ChangeType(@event.Value, expectedType);
			}
			break;
		}
		return true;
	}

	private object DeserializeBooleanHelper(string value)
	{
		int num = 8;
		int num2 = num;
		bool flag = default(bool);
		while (true)
		{
			switch (num2)
			{
			case 8:
				if (!Regex.IsMatch(value, DicSingleton.gE3WbyDVW(0x4E8C8248 ^ 0x4E8CE9F0), RegexOptions.IgnoreCase))
				{
					num2 = 7;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd != 0)
					{
						num2 = 2;
					}
					break;
				}
				goto case 5;
			case 6:
				flag = false;
				num2 = 4;
				break;
			case 5:
				flag = true;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 != 0)
				{
					num2 = 1;
				}
				break;
			default:
				if (!Regex.IsMatch(value, DicSingleton.gE3WbyDVW(-293474990 ^ -293501300), RegexOptions.IgnoreCase))
				{
					num2 = 3;
					break;
				}
				goto case 6;
			case 2:
			case 3:
				throw new FormatException(DicSingleton.gE3WbyDVW(-1075938037 ^ -1075965683) + value + DicSingleton.gE3WbyDVW(-2083714112 ^ -2083690528));
			case 1:
			case 4:
				return flag;
			}
		}
	}

	private object DeserializeIntegerHelper(TypeCode typeCode, string value)
	{
		ReponseAttribute.ModelAttribute modelAttribute = ReponseAttribute.Rent();
		try
		{
			StringBuilder advisorAttribute = modelAttribute.m_AdvisorAttribute;
			int i = 0;
			bool flag = false;
			ulong num = 0uL;
			if (value[0] == '-')
			{
				i++;
				flag = true;
			}
			else if (value[0] == '+')
			{
				i++;
			}
			if (value[i] == '0')
			{
				int num2;
				if (i == value.Length - 1)
				{
					num2 = 10;
					num = 0uL;
				}
				else
				{
					i++;
					if (value[i] == 'b')
					{
						num2 = 2;
						i++;
					}
					else if (value[i] == 'x')
					{
						num2 = 16;
						i++;
					}
					else
					{
						num2 = 8;
					}
				}
				for (; i < value.Length; i++)
				{
					if (value[i] != '_')
					{
						advisorAttribute.Append(value[i]);
					}
				}
				switch (num2)
				{
				case 2:
				case 8:
					num = Convert.ToUInt64(advisorAttribute.ToString(), num2);
					break;
				case 16:
					num = ulong.Parse(advisorAttribute.ToString(), NumberStyles.HexNumber, merchantAuthentication.NumberFormat);
					break;
				}
			}
			else
			{
				string[] array = value.Substring(i).Split(new char[1] { ':' });
				num = 0uL;
				for (int j = 0; j < array.Length; j++)
				{
					num *= 60;
					num += ulong.Parse(array[j].Replace(DicSingleton.gE3WbyDVW(--798431903 ^ 0x2F975085), ""));
				}
			}
			if (flag)
			{
				long number = ((num != 9223372036854775808uL) ? checked(-(long)num) : long.MinValue);
				return CastInteger(number, typeCode);
			}
			return CastInteger(num, typeCode);
		}
		finally
		{
			((IDisposable)modelAttribute/*cast due to .constrained prefix*/).Dispose();
		}
	}

	private static object CastInteger(long number, TypeCode typeCode)
	{
		int num = 11;
		checked
		{
			object result = default(object);
			while (true)
			{
				int num2 = num;
				while (true)
				{
					switch (num2)
					{
					case 13:
						result = (short)number;
						num = 2;
						break;
					case 5:
						goto IL_0083;
					case 10:
					case 12:
						result = number;
						num = 18;
						break;
					case 11:
						switch (typeCode)
						{
						case TypeCode.Int16:
							break;
						case TypeCode.UInt64:
							goto IL_0083;
						default:
							goto IL_0101;
						case TypeCode.UInt32:
							goto IL_011a;
						case TypeCode.Byte:
							goto IL_0150;
						case TypeCode.Int64:
							goto IL_0182;
						case TypeCode.SByte:
							goto IL_01d5;
						case TypeCode.Int32:
							goto IL_01f8;
						case TypeCode.UInt16:
							goto IL_023a;
						}
						goto case 13;
					case 6:
						goto IL_011a;
					case 19:
						goto IL_0150;
					case 7:
						goto IL_0182;
					case 1:
					case 2:
					case 4:
					case 8:
					case 9:
					case 15:
					case 16:
					case 17:
					case 18:
						return result;
					case 3:
						goto IL_01d5;
					default:
						goto IL_01f8;
					case 14:
						goto IL_023a;
						IL_023a:
						result = (ushort)number;
						num2 = 16;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 == 0)
						{
							num2 = 12;
						}
						continue;
						IL_01f8:
						result = (int)number;
						num2 = 10;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb != 0)
						{
							num2 = 17;
						}
						continue;
						IL_0101:
						num2 = 10;
						continue;
						IL_01d5:
						result = (sbyte)number;
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 == 0)
						{
							num2 = 8;
						}
						continue;
						IL_0182:
						result = number;
						num2 = 4;
						continue;
						IL_0150:
						result = (byte)number;
						num2 = 9;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e == 0)
						{
							num2 = 6;
						}
						continue;
						IL_0083:
						result = (ulong)number;
						num2 = 15;
						continue;
						IL_011a:
						result = (uint)number;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 == 0)
						{
							num2 = 1;
						}
						continue;
					}
					break;
				}
			}
		}
	}

	private static object CastInteger(ulong number, TypeCode typeCode)
	{
		int num = 13;
		int num2 = num;
		checked
		{
			object result = default(object);
			while (true)
			{
				switch (num2)
				{
				case 1:
					result = (sbyte)number;
					num2 = 17;
					continue;
				case 18:
					goto IL_009e;
				case 16:
					goto IL_00c1;
				case 8:
					goto IL_00e3;
				default:
					goto IL_0106;
				case 11:
					goto IL_0157;
				case 5:
				case 12:
					result = number;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb == 0)
					{
						num2 = 15;
					}
					continue;
				case 2:
				case 4:
				case 6:
				case 9:
				case 10:
				case 14:
				case 15:
				case 17:
				case 19:
					return result;
				case 13:
					switch (typeCode)
					{
					case TypeCode.SByte:
						break;
					case TypeCode.Byte:
						goto IL_009e;
					case TypeCode.UInt64:
						goto IL_00c1;
					case TypeCode.UInt16:
						goto IL_00e3;
					case TypeCode.Int64:
						goto IL_0106;
					case TypeCode.Int16:
						goto IL_0157;
					default:
						goto IL_0242;
					case TypeCode.Int32:
						goto IL_024c;
					case TypeCode.UInt32:
						goto end_IL_0012;
					}
					goto case 1;
				case 7:
					goto IL_024c;
				case 3:
					break;
					IL_024c:
					result = (int)number;
					num2 = 19;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 == 0)
					{
						num2 = 16;
					}
					continue;
					IL_00e3:
					result = (ushort)number;
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_49107028423047bfbf9c33e5a2ab8cf8 != 0)
					{
						num2 = 10;
					}
					continue;
					IL_0242:
					num2 = 12;
					continue;
					IL_009e:
					result = (byte)number;
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd == 0)
					{
						num2 = 4;
					}
					continue;
					IL_0157:
					result = (short)number;
					num2 = 9;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c != 0)
					{
						num2 = 7;
					}
					continue;
					IL_00c1:
					result = number;
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 == 0)
					{
						num2 = 4;
					}
					continue;
					IL_0106:
					result = (long)number;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ea4c8b68ad954c0fb4df33d6e06bd4a3 == 0)
					{
						num2 = 14;
					}
					continue;
					end_IL_0012:
					break;
				}
				result = (uint)number;
				num2 = 2;
			}
		}
	}

	private object? AttemptUnknownTypeDeserialization(BridgeSingleton value)
	{
		int num = 44;
		_003C_003Ec__DisplayClass11_0 _003C_003Ec__DisplayClass11_ = default(_003C_003Ec__DisplayClass11_0);
		object value2 = default(object);
		string text = default(string);
		int length = default(int);
		char c = default(char);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 57:
					if (Regex.IsMatch(_003C_003Ec__DisplayClass11_.testAuthentication, DicSingleton.gE3WbyDVW(0xDA293E6 ^ 0xDA223CC)))
					{
						num = 30;
						break;
					}
					goto case 81;
				case 37:
					value2 = _003C_003Ec__DisplayClass11_.testAuthentication;
					num2 = 70;
					continue;
				case 81:
					value2 = _003C_003Ec__DisplayClass11_.testAuthentication;
					num2 = 82;
					continue;
				case 66:
					value2 = _003C_003Ec__DisplayClass11_.testAuthentication;
					num2 = 73;
					continue;
				case 36:
					if (TryAndSwallow(_003C_003Ec__DisplayClass11_._003CAttemptUnknownTypeDeserialization_003Eb__2, out value2))
					{
						num2 = 56;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
						{
							num2 = 26;
						}
						continue;
					}
					goto case 55;
				case 29:
					value2 = float.NegativeInfinity;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb != 0)
					{
						num2 = 0;
					}
					continue;
				case 45:
					if (!(text == DicSingleton.gE3WbyDVW(-1273961441 ^ -1273983041)))
					{
						num2 = 25;
						continue;
					}
					goto IL_0b8d;
				case 24:
					length = text.Length;
					num2 = 63;
					continue;
				case 79:
					if (c != 'n')
					{
						num2 = 5;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 == 0)
						{
							num2 = 5;
						}
						continue;
					}
					goto case 15;
				case 26:
					return value.Value;
				case 74:
					if (TryAndSwallow(_003C_003Ec__DisplayClass11_._003CAttemptUnknownTypeDeserialization_003Eb__5, out value2))
					{
						num2 = 7;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 != 0)
						{
							num2 = 8;
						}
						continue;
					}
					goto case 42;
				case 54:
					if (!(text == DicSingleton.gE3WbyDVW(-1549341817 ^ -1549366383)))
					{
						num2 = 65;
						continue;
					}
					goto IL_0b8f;
				case 49:
					if (c != 'F')
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 != 0)
						{
							num2 = 32;
						}
						continue;
					}
					goto case 33;
				case 19:
				case 20:
					if (!Regex.IsMatch(_003C_003Ec__DisplayClass11_.testAuthentication, DicSingleton.gE3WbyDVW(0x7742C60 ^ 0x77483E8)))
					{
						num2 = 22;
						continue;
					}
					goto case 1;
				default:
					return value2;
				case 39:
					if (c != 'N')
					{
						num2 = 11;
						continue;
					}
					goto case 45;
				case 33:
					if (!(text == DicSingleton.gE3WbyDVW(-1866665889 ^ -1866702989)))
					{
						num = 10;
						break;
					}
					goto case 23;
				case 32:
					if (c != 'f')
					{
						num2 = 60;
						continue;
					}
					goto case 40;
				case 75:
					if (!TryAndSwallow(_003C_003Ec__DisplayClass11_._003CAttemptUnknownTypeDeserialization_003Eb__15, out value2))
					{
						num2 = 86;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 != 0)
						{
							num2 = 74;
						}
						continue;
					}
					goto default;
				case 4:
					if (!TryAndSwallow(_003C_003Ec__DisplayClass11_._003CAttemptUnknownTypeDeserialization_003Eb__7, out value2))
					{
						num2 = 16;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 == 0)
						{
							num2 = 6;
						}
						continue;
					}
					goto default;
				case 11:
					if (c != 'T')
					{
						num2 = 64;
						continue;
					}
					goto case 28;
				case 48:
					value2 = _003C_003Ec__DisplayClass11_.testAuthentication;
					num2 = 72;
					continue;
				case 40:
					if (!(text == DicSingleton.gE3WbyDVW(0x940D407 ^ 0x940B40F)))
					{
						goto IL_0b9d;
					}
					num2 = 23;
					continue;
				case 34:
					if (!(text == DicSingleton.gE3WbyDVW(--650088194 ^ 0x26BF2022)))
					{
						num = 7;
						break;
					}
					goto IL_0b8f;
				case 63:
					switch (length)
					{
					case 5:
						goto IL_0859;
					case 1:
						goto IL_09fa;
					case 4:
						goto IL_0abc;
					case 0:
						goto IL_0b8d;
					case 2:
					case 3:
						goto IL_0b9d;
					}
					num2 = 47;
					continue;
				case 6:
					if (TryAndSwallow(_003C_003Ec__DisplayClass11_._003CAttemptUnknownTypeDeserialization_003Eb__9, out value2))
					{
						num2 = 78;
						continue;
					}
					goto case 48;
				case 76:
					if (!Regex.IsMatch(_003C_003Ec__DisplayClass11_.testAuthentication, DicSingleton.gE3WbyDVW(--1844849127 ^ 0x6DF6868F)))
					{
						num2 = 19;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be == 0)
						{
							num2 = 15;
						}
						continue;
					}
					goto case 74;
				case 30:
					value2 = float.NaN;
					num2 = 69;
					continue;
				case 25:
					if (!(text == DicSingleton.gE3WbyDVW(0x2BB207E4 ^ 0x2BB26C48)))
					{
						num2 = 52;
						continue;
					}
					goto IL_0b8d;
				case 46:
					if (_003C_003Ec__DisplayClass11_.testAuthentication.StartsWith(DicSingleton.gE3WbyDVW(0x7742C60 ^ 0x77420FC)))
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 == 0)
						{
							num2 = 29;
						}
						continue;
					}
					goto case 80;
				case 55:
					if (!TryAndSwallow(_003C_003Ec__DisplayClass11_._003CAttemptUnknownTypeDeserialization_003Eb__3, out value2))
					{
						num2 = 14;
						continue;
					}
					goto default;
				case 14:
					if (!TryAndSwallow(_003C_003Ec__DisplayClass11_._003CAttemptUnknownTypeDeserialization_003Eb__4, out value2))
					{
						num2 = 66;
						continue;
					}
					goto default;
				case 71:
					if (value.Style != (ConnectionInterpreter)2)
					{
						num2 = 24;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 != 0)
						{
							num2 = 51;
						}
						continue;
					}
					goto case 26;
				case 86:
					if (TryAndSwallow(_003C_003Ec__DisplayClass11_._003CAttemptUnknownTypeDeserialization_003Eb__16, out value2))
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f == 0)
						{
							num2 = 41;
						}
						continue;
					}
					goto case 37;
				case 61:
					if (text == null)
					{
						num = 18;
						break;
					}
					goto case 24;
				case 51:
					if (value.Style != (ConnectionInterpreter)3)
					{
						num2 = 13;
						continue;
					}
					goto case 26;
				case 1:
					if (!TryAndSwallow(_003C_003Ec__DisplayClass11_._003CAttemptUnknownTypeDeserialization_003Eb__10, out value2))
					{
						num2 = 44;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f011663d64054593978962dcc3a5ec1a != 0)
						{
							num2 = 50;
						}
						continue;
					}
					goto default;
				case 87:
					text = _003C_003Ec__DisplayClass11_.testAuthentication;
					num2 = 61;
					continue;
				case 84:
					goto IL_0859;
				case 15:
					if (!(text == DicSingleton.gE3WbyDVW(-1447578472 ^ -1447559684)))
					{
						goto IL_0b9d;
					}
					num2 = 77;
					continue;
				case 44:
					_003C_003Ec__DisplayClass11_ = new _003C_003Ec__DisplayClass11_0();
					num2 = 43;
					continue;
				case 83:
					if (TryAndSwallow(_003C_003Ec__DisplayClass11_._003CAttemptUnknownTypeDeserialization_003Eb__14, out value2))
					{
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 == 0)
						{
							num2 = 58;
						}
						continue;
					}
					goto case 75;
				case 80:
					value2 = float.PositiveInfinity;
					num2 = 89;
					continue;
				case 5:
					if (c != 't')
					{
						num2 = 17;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e != 0)
						{
							num2 = 4;
						}
						continue;
					}
					goto case 54;
				case 10:
					if (!(text == DicSingleton.gE3WbyDVW(-490894496 ^ -490920870)))
					{
						num2 = 53;
						continue;
					}
					goto case 23;
				case 42:
					if (!TryAndSwallow(_003C_003Ec__DisplayClass11_._003CAttemptUnknownTypeDeserialization_003Eb__6, out value2))
					{
						num = 4;
						break;
					}
					goto default;
				case 28:
					if (!(text == DicSingleton.gE3WbyDVW(-1830690703 ^ -1830727835)))
					{
						num2 = 34;
						continue;
					}
					goto IL_0b8f;
				case 12:
					goto IL_09fa;
				case 59:
					if (!TryAndSwallow(_003C_003Ec__DisplayClass11_._003CAttemptUnknownTypeDeserialization_003Eb__13, out value2))
					{
						num2 = 83;
						continue;
					}
					goto default;
				case 50:
					if (TryAndSwallow(_003C_003Ec__DisplayClass11_._003CAttemptUnknownTypeDeserialization_003Eb__11, out value2))
					{
						num2 = 3;
						continue;
					}
					goto case 68;
				case 68:
					if (!TryAndSwallow(_003C_003Ec__DisplayClass11_._003CAttemptUnknownTypeDeserialization_003Eb__12, out value2))
					{
						num2 = 6;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 != 0)
						{
							num2 = 59;
						}
						continue;
					}
					goto default;
				case 16:
					if (!TryAndSwallow(_003C_003Ec__DisplayClass11_._003CAttemptUnknownTypeDeserialization_003Eb__8, out value2))
					{
						num2 = 6;
						continue;
					}
					goto default;
				case 31:
					goto IL_0abc;
				case 21:
					if ((uint)c <= 84u)
					{
						num2 = 39;
						continue;
					}
					goto case 79;
				case 22:
				case 85:
					if (Regex.IsMatch(_003C_003Ec__DisplayClass11_.testAuthentication, DicSingleton.gE3WbyDVW(0xB026CF2 ^ 0xB02C300)))
					{
						num2 = 12;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba == 0)
						{
							num2 = 46;
						}
						continue;
					}
					goto case 57;
				case 13:
					if (value.Style != (ConnectionInterpreter)5)
					{
						_003C_003Ec__DisplayClass11_.testAuthentication = value.Value;
						num2 = 87;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 == 0)
						{
							num2 = 47;
						}
						continue;
					}
					num = 26;
					break;
				case 67:
					if (TryAndSwallow(_003C_003Ec__DisplayClass11_._003CAttemptUnknownTypeDeserialization_003Eb__1, out value2))
					{
						num = 38;
						break;
					}
					goto case 36;
				case 2:
				case 9:
				case 77:
					goto IL_0b8d;
				case 23:
					return false;
				case 7:
				case 17:
				case 18:
				case 27:
				case 47:
				case 52:
				case 53:
				case 60:
				case 62:
				case 64:
				case 65:
				case 88:
					goto IL_0b9d;
				case 35:
					if (!TryAndSwallow(_003C_003Ec__DisplayClass11_._003CAttemptUnknownTypeDeserialization_003Eb__0, out value2))
					{
						num2 = 67;
						continue;
					}
					goto default;
				case 43:
					{
						_003C_003Ec__DisplayClass11_.attrAuthentication = this;
						num2 = 71;
						continue;
					}
					IL_0b8d:
					return null;
					IL_0b9d:
					if (Regex.IsMatch(_003C_003Ec__DisplayClass11_.testAuthentication, DicSingleton.gE3WbyDVW(0x1679942F ^ 0x16793B67)))
					{
						num2 = 35;
						continue;
					}
					goto case 76;
					IL_0abc:
					c = text[0];
					num2 = 21;
					continue;
					IL_09fa:
					if (!(text == DicSingleton.gE3WbyDVW(0x3FCF6129 ^ 0x3FCF0AB3)))
					{
						goto IL_0b9d;
					}
					num2 = 9;
					continue;
					IL_0859:
					c = text[0];
					num2 = 49;
					continue;
					IL_0b8f:
					return true;
				}
				break;
			}
		}
	}

	private static bool TryAndSwallow(Func<object> attempt, out object? value)
	{
		try
		{
			value = attempt();
			return true;
		}
		catch
		{
			value = null;
			return false;
		}
	}

	internal static bool SearchMock()
	{
		return UpdateMock == null;
	}

	internal static BridgeAuthentication StopMock()
	{
		return UpdateMock;
	}
}
