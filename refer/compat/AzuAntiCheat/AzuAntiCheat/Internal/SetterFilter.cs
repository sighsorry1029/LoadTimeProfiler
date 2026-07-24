using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class SetterFilter : RoleFilter
{
	private readonly TestDisplayGroup m_WriterFilter;

	private static SetterFilter QueryProcess;

	public SetterFilter(TestDisplayGroup handling, ParserPrototype<ModelReader> nextVisitor)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(nextVisitor);
		m_WriterFilter = handling;
	}

	[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	private static object GetDefault(Type type)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return null;
			case 1:
				if (CollectionBase.IsValueType(type))
				{
					return Activator.CreateInstance(type);
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public override bool EnterMapping(RequestPrototype key, UtilsPrototype value, ModelReader context)
	{
		int num = 25;
		TestDisplayGroup testDisplayGroup = default(TestDisplayGroup);
		IEnumerable enumerable = default(IEnumerable);
		bool flag = default(bool);
		IDisposable disposable = default(IDisposable);
		object objB = default(object);
		RulesInterceptor customAttribute2 = default(RulesInterceptor);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				object obj;
				switch (num2)
				{
				case 25:
					testDisplayGroup = m_WriterFilter;
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_23f9d18f43004f488662f38dd306f6ec == 0)
					{
						num2 = 24;
					}
					continue;
				case 3:
				{
					IEnumerator enumerator = enumerable.GetEnumerator();
					flag = enumerator.MoveNext();
					disposable = enumerator as IDisposable;
					num2 = 5;
					continue;
				}
				case 2:
					return false;
				case 15:
					return base.EnterMapping(key, value, context);
				case 12:
					if (!object.Equals(value.Value, objB))
					{
						num2 = 15;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f == 0)
						{
							num2 = 12;
						}
						continue;
					}
					goto case 2;
				case 13:
					if (customAttribute2 != null)
					{
						num2 = 7;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 == 0)
						{
							num2 = 6;
						}
						continue;
					}
					goto case 6;
				case 5:
					if (disposable == null)
					{
						num2 = 8;
						continue;
					}
					goto case 22;
				case 8:
				case 9:
					if (!flag)
					{
						num2 = 19;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 != 0)
						{
							num2 = 2;
						}
						continue;
					}
					goto case 14;
				case 21:
					enumerable = value.Value as IEnumerable;
					num2 = 17;
					continue;
				case 16:
					testDisplayGroup = customAttribute2.DefaultValuesHandling;
					num2 = 6;
					continue;
				case 17:
					if (enumerable == null)
					{
						num2 = 20;
						continue;
					}
					goto case 3;
				case 10:
					return false;
				default:
					if ((testDisplayGroup & (TestDisplayGroup)4) == 0)
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea != 0)
						{
							num2 = 14;
						}
						continue;
					}
					goto case 21;
				case 7:
					if (customAttribute2.IsDefaultValuesHandlingSpecified)
					{
						num2 = 16;
						continue;
					}
					goto case 6;
				case 22:
					disposable.Dispose();
					num2 = 9;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d5c0c185d7b1430b897cb64adc93b81c == 0)
					{
						num2 = 8;
					}
					continue;
				case 19:
					return false;
				case 14:
				case 20:
					if ((testDisplayGroup & (TestDisplayGroup)2) != 0)
					{
						num2 = 4;
						continue;
					}
					goto case 15;
				case 11:
					if (value.Value != null)
					{
						num2 = 18;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 10;
				case 6:
					if ((testDisplayGroup & (TestDisplayGroup)1) == 0)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 11;
				case 24:
					goto end_IL_0012;
				case 4:
				{
					DefaultValueAttribute customAttribute = key.GetCustomAttribute<DefaultValueAttribute>();
					if (customAttribute == null)
					{
						num2 = 23;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 == 0)
						{
							num2 = 5;
						}
						continue;
					}
					obj = customAttribute.Value;
					goto IL_032c;
				}
				case 23:
					obj = null;
					goto IL_032c;
				case 1:
					{
						obj = GetDefault(key.Type);
						break;
					}
					IL_032c:
					if (obj == null)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 == 0)
						{
							num2 = 1;
						}
						continue;
					}
					break;
				}
				objB = obj;
				num2 = 12;
				continue;
				end_IL_0012:
				break;
			}
			customAttribute2 = key.GetCustomAttribute<RulesInterceptor>();
			num = 13;
		}
	}

	internal static bool AwakeProcess()
	{
		return QueryProcess == null;
	}

	internal static SetterFilter InstantiateProcess()
	{
		return QueryProcess;
	}
}
