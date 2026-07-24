using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class OrderFilter : WorkerPrototype
{
	private static OrderFilter RestartInstance;

	bool WorkerPrototype.Deserialize(StubReader parser, Type expectedType, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 1, 1, 1, 2 })] Func<StubReader, Type, object> nestedObjectDeserializer, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] out object value)
	{
		if (!parser.TryConsume<ClassFactory>(out var @event))
		{
			value = null;
			return false;
		}
		Type type = Nullable.GetUnderlyingType(expectedType) ?? expectedType;
		if (CollectionBase.IsEnum(type))
		{
			value = Enum.Parse(type, @event.Value, ignoreCase: true);
			return true;
		}
		TypeCode typeCode = CollectionBase.GetTypeCode(type);
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
			value = float.Parse(@event.Value, IdentifierInterceptor._TokenInterceptor);
			break;
		case TypeCode.Double:
			value = double.Parse(@event.Value, IdentifierInterceptor._TokenInterceptor);
			break;
		case TypeCode.Decimal:
			value = decimal.Parse(@event.Value, IdentifierInterceptor._TokenInterceptor);
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
				value = @event.Value;
			}
			else
			{
				value = ContainerInterceptor.ChangeType(@event.Value, expectedType);
			}
			break;
		}
		return true;
	}

	private object DeserializeBooleanHelper(string value)
	{
		int num = 7;
		int num2 = num;
		bool flag = default(bool);
		while (true)
		{
			switch (num2)
			{
			default:
				throw new FormatException(DicSingleton.gE3WbyDVW(-2083714112 ^ -2083690554) + value + DicSingleton.gE3WbyDVW(-1461449777 ^ -1461426193));
			case 1:
			case 4:
				return flag;
			case 7:
				if (!Regex.IsMatch(value, DicSingleton.gE3WbyDVW(0x33F6A245 ^ 0x33F6C9FD), RegexOptions.IgnoreCase))
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef == 0)
					{
						num2 = 6;
					}
					break;
				}
				goto case 2;
			case 8:
				flag = false;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				flag = true;
				num2 = 4;
				break;
			case 3:
			case 6:
				if (!Regex.IsMatch(value, DicSingleton.gE3WbyDVW(-379532028 ^ -379541798), RegexOptions.IgnoreCase))
				{
					num2 = 5;
					break;
				}
				goto case 8;
			}
		}
	}

	private object DeserializeIntegerHelper(TypeCode typeCode, string value)
	{
		int num = 48;
		int num2 = num;
		int num6 = default(int);
		ulong num5 = default(ulong);
		int num3 = default(int);
		int num4 = default(int);
		string[] array = default(string[]);
		StringBuilder stringBuilder = default(StringBuilder);
		bool flag = default(bool);
		while (true)
		{
			switch (num2)
			{
			case 16:
				num6 = 8;
				num2 = 46;
				break;
			case 20:
				if (value[0] == '+')
				{
					num2 = 19;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 == 0)
					{
						num2 = 49;
					}
					break;
				}
				goto case 30;
			case 3:
				return CastInteger(checked(-(long)num5), typeCode);
			case 7:
				return CastInteger(num5, typeCode);
			case 4:
				num3++;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ea4c8b68ad954c0fb4df33d6e06bd4a3 == 0)
				{
					num2 = 2;
				}
				break;
			case 34:
				if (num6 != 2)
				{
					num2 = 43;
					break;
				}
				goto case 9;
			default:
				if (value[num3] == 'b')
				{
					num2 = 50;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa == 0)
					{
						num2 = 52;
					}
					break;
				}
				goto case 22;
			case 51:
				num4++;
				num2 = 31;
				break;
			case 24:
				num3++;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac != 0)
				{
					num2 = 1;
				}
				break;
			case 30:
			case 50:
				if (value[num3] == '0')
				{
					num2 = 11;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 != 0)
					{
						num2 = 6;
					}
					break;
				}
				goto case 17;
			case 1:
			case 10:
			case 36:
			case 41:
			case 46:
				if (num3 >= value.Length)
				{
					num2 = 22;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac == 0)
					{
						num2 = 33;
					}
					break;
				}
				goto case 14;
			case 17:
				array = value.Substring(num3).Split(new char[1] { ':' });
				num2 = 29;
				break;
			case 11:
				if (num3 == value.Length - 1)
				{
					num2 = 32;
					break;
				}
				goto case 6;
			case 49:
				num3++;
				num2 = 30;
				break;
			case 26:
				num5 = 0uL;
				num2 = 36;
				break;
			case 12:
				if (num6 != 16)
				{
					num2 = 38;
					break;
				}
				goto case 37;
			case 23:
				num5 += ulong.Parse(array[num4].Replace(DicSingleton.gE3WbyDVW(-65056140 ^ -65070994), ""));
				num2 = 51;
				break;
			case 14:
				if (value[num3] != '_')
				{
					num2 = 8;
					break;
				}
				goto case 18;
			case 9:
				num5 = Convert.ToUInt64(stringBuilder.ToString(), num6);
				num2 = 44;
				break;
			case 32:
				num6 = 10;
				num2 = 18;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 == 0)
				{
					num2 = 26;
				}
				break;
			case 52:
				num6 = 2;
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 == 0)
				{
					num2 = 25;
				}
				break;
			case 22:
				if (value[num3] == 'x')
				{
					num2 = 25;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c2b9915913b8461884afdca5d98855ec == 0)
					{
						num2 = 39;
					}
					break;
				}
				goto case 16;
			case 2:
				flag = true;
				num2 = 35;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 != 0)
				{
					num2 = 50;
				}
				break;
			case 13:
			case 15:
				num5 *= 60;
				num2 = 23;
				break;
			case 33:
				if (num6 <= 8)
				{
					num2 = 21;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d != 0)
					{
						num2 = 34;
					}
					break;
				}
				goto case 35;
			case 28:
			case 31:
				if (num4 < array.Length)
				{
					num2 = 15;
					break;
				}
				goto case 5;
			case 48:
				stringBuilder = new StringBuilder();
				num2 = 47;
				break;
			case 25:
				num3++;
				num2 = 34;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec == 0)
				{
					num2 = 41;
				}
				break;
			case 47:
				num3 = 0;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef == 0)
				{
					num2 = 21;
				}
				break;
			case 6:
				num3++;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec != 0)
				{
					num2 = 0;
				}
				break;
			case 37:
				num5 = ulong.Parse(stringBuilder.ToString(), NumberStyles.HexNumber, IdentifierInterceptor._TokenInterceptor);
				num2 = 22;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 == 0)
				{
					num2 = 45;
				}
				break;
			case 39:
				num6 = 16;
				num2 = 10;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c == 0)
				{
					num2 = 24;
				}
				break;
			case 43:
				if (num6 != 8)
				{
					num2 = 5;
					break;
				}
				goto case 9;
			case 21:
				flag = false;
				num2 = 42;
				break;
			case 5:
			case 38:
			case 40:
			case 44:
			case 45:
				if (!flag)
				{
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 != 0)
					{
						num2 = 7;
					}
					break;
				}
				goto case 3;
			case 42:
				num5 = 0uL;
				num2 = 19;
				break;
			case 8:
				stringBuilder.Append(value[num3]);
				num2 = 18;
				break;
			case 18:
				num3++;
				num2 = 10;
				break;
			case 29:
				num5 = 0uL;
				num2 = 27;
				break;
			case 35:
				if (num6 != 10)
				{
					num2 = 12;
					break;
				}
				goto case 5;
			case 27:
				num4 = 0;
				num2 = 28;
				break;
			case 19:
				if (value[0] == '-')
				{
					num2 = 4;
					break;
				}
				goto case 20;
			}
		}
	}

	private static object CastInteger(long number, TypeCode typeCode)
	{
		int num = 8;
		int num2 = num;
		checked
		{
			object result = default(object);
			while (true)
			{
				switch (num2)
				{
				case 2:
					result = (ulong)number;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae50b6e347494ff2973fbc64d1fc9236 == 0)
					{
						num2 = 3;
					}
					break;
				case 19:
					goto IL_008f;
				case 4:
					goto IL_00a2;
				case 3:
				case 9:
				case 10:
				case 11:
				case 12:
				case 13:
				case 14:
				case 15:
				case 16:
					return result;
				case 18:
					goto IL_00c7;
				case 5:
					goto IL_0136;
				default:
					goto IL_0159;
				case 1:
				case 7:
					result = number;
					num2 = 15;
					break;
				case 17:
					goto IL_019d;
				case 6:
					goto IL_01bf;
				case 8:
					{
						switch (typeCode)
						{
						case TypeCode.UInt64:
							break;
						case TypeCode.Int32:
							goto IL_008f;
						case TypeCode.Int64:
							goto IL_00a2;
						case TypeCode.Byte:
							goto IL_00c7;
						case TypeCode.UInt32:
							goto IL_0136;
						case TypeCode.UInt16:
							goto IL_0159;
						case TypeCode.Int16:
							goto IL_019d;
						case TypeCode.SByte:
							goto IL_01bf;
						default:
							goto IL_0237;
						}
						goto case 2;
					}
					IL_0237:
					num2 = 7;
					break;
					IL_01bf:
					result = (sbyte)number;
					num2 = 16;
					break;
					IL_019d:
					result = (short)number;
					num2 = 13;
					break;
					IL_0159:
					result = (ushort)number;
					num2 = 9;
					break;
					IL_0136:
					result = (uint)number;
					num2 = 12;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb != 0)
					{
						num2 = 10;
					}
					break;
					IL_008f:
					result = (int)number;
					num2 = 14;
					break;
					IL_00c7:
					result = (byte)number;
					num2 = 10;
					break;
					IL_00a2:
					result = number;
					num2 = 11;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 != 0)
					{
						num2 = 2;
					}
					break;
				}
			}
		}
	}

	private static object CastInteger(ulong number, TypeCode typeCode)
	{
		int num = 10;
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
					case 2:
						result = (ushort)number;
						num2 = 7;
						continue;
					case 4:
						goto IL_007f;
					case 1:
						goto IL_00b1;
					default:
						return result;
					case 10:
						switch (typeCode)
						{
						case TypeCode.UInt16:
							break;
						case TypeCode.Int16:
							goto IL_007f;
						case TypeCode.Int32:
							goto IL_00b1;
						default:
							goto IL_012d;
						case TypeCode.Byte:
							goto IL_0146;
						case TypeCode.UInt64:
							goto end_IL_0012;
						case TypeCode.SByte:
							goto IL_0201;
						case TypeCode.UInt32:
							goto IL_0233;
						case TypeCode.Int64:
							goto end_IL_0012_2;
						}
						goto case 2;
					case 14:
						goto IL_0146;
					case 9:
					case 17:
						result = number;
						num2 = 18;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 == 0)
						{
							num2 = 1;
						}
						continue;
					case 15:
						goto end_IL_0012;
					case 19:
						goto IL_0201;
					case 6:
						goto IL_0233;
					case 11:
						break;
						IL_00b1:
						result = (int)number;
						num2 = 8;
						continue;
						IL_0233:
						result = (uint)number;
						num2 = 12;
						continue;
						IL_0201:
						result = (sbyte)number;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 == 0)
						{
							num2 = 0;
						}
						continue;
						IL_007f:
						result = (short)number;
						num2 = 11;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 == 0)
						{
							num2 = 13;
						}
						continue;
						IL_0146:
						result = (byte)number;
						num2 = 16;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
						{
							num2 = 15;
						}
						continue;
						IL_012d:
						num2 = 9;
						continue;
						end_IL_0012_2:
						break;
					}
					result = (long)number;
					num2 = 3;
					continue;
					end_IL_0012:
					break;
				}
				result = number;
				num = 5;
			}
		}
	}

	public OrderFilter()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool GetInstance()
	{
		return RestartInstance == null;
	}

	internal static OrderFilter CalculateInstance()
	{
		return RestartInstance;
	}
}
