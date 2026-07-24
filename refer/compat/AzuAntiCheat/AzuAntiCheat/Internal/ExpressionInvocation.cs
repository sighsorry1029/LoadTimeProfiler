using System;

namespace AzuAnticheat.Internal;

internal class ExpressionInvocation : ConnectionSetter
{
	private static ExpressionInvocation AwakeProxy;

	public virtual Type Resolve(Type staticType, object? actualValue)
	{
		int num = 1;
		int num2 = num;
		TypeCode typeCode = default(TypeCode);
		while (true)
		{
			switch (num2)
			{
			case 6:
				return staticType;
			case 3:
				typeCode = InterceptorSetter.GetTypeCode(actualValue.GetType());
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c == 0)
				{
					num2 = 4;
				}
				break;
			case 5:
				if (!actualValue.GetType().IsEnum)
				{
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 != 0)
					{
						num2 = 2;
					}
					break;
				}
				goto case 6;
			case 2:
				return typeof(bool);
			default:
				goto IL_0143;
			case 4:
				switch (typeCode)
				{
				case TypeCode.Boolean:
					break;
				case TypeCode.Char:
					return typeof(char);
				case TypeCode.SByte:
					return typeof(sbyte);
				case TypeCode.Byte:
					return typeof(byte);
				case TypeCode.Int16:
					return typeof(short);
				case TypeCode.UInt16:
					return typeof(ushort);
				case TypeCode.Int32:
					return typeof(int);
				case TypeCode.UInt32:
					return typeof(uint);
				case TypeCode.Int64:
					return typeof(long);
				case TypeCode.UInt64:
					return typeof(ulong);
				case TypeCode.Single:
					return typeof(float);
				case TypeCode.Double:
					return typeof(double);
				case TypeCode.Decimal:
					return typeof(decimal);
				case TypeCode.String:
					return typeof(string);
				case TypeCode.DateTime:
					return typeof(DateTime);
				case (TypeCode)17:
					goto IL_0143;
				default:
					goto IL_018e;
				}
				goto case 2;
			case 1:
				{
					if (actualValue == null)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d5c0c185d7b1430b897cb64adc93b81c == 0)
						{
							num2 = 0;
						}
						break;
					}
					goto case 5;
				}
				IL_018e:
				num2 = 7;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 == 0)
				{
					num2 = 0;
				}
				break;
				IL_0143:
				return staticType;
			}
		}
	}

	public ExpressionInvocation()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool InstantiateProxy()
	{
		return AwakeProxy == null;
	}

	internal static ExpressionInvocation LoginProxy()
	{
		return AwakeProxy;
	}
}
