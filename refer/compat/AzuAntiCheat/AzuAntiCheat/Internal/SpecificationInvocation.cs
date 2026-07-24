using System;
using System.Collections;
using System.ComponentModel;

namespace AzuAnticheat.Internal;

internal sealed class SpecificationInvocation : MappingInvocation
{
	private readonly SchemaItemPropertyIndexes m_RefInvocation;

	private readonly PrinterSetter observerInvocation;

	private static SpecificationInvocation PublishImporter;

	public SpecificationInvocation(SchemaItemPropertyIndexes handling, ErrorSetter<MockInterpreter> nextVisitor, PrinterSetter factory)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(nextVisitor);
		m_RefInvocation = handling;
		observerInvocation = factory;
	}

	private object? GetDefault(Type type)
	{
		return observerInvocation.CreatePrimitive(type);
	}

	public override bool EnterMapping(RegSetter key, ImporterSetter value, MockInterpreter context)
	{
		int num = 16;
		object objB = default(object);
		SchemaItemPropertyIndexes schemaItemPropertyIndexes = default(SchemaItemPropertyIndexes);
		FilterInvocation customAttribute = default(FilterInvocation);
		IEnumerable enumerable = default(IEnumerable);
		bool flag = default(bool);
		IDisposable disposable = default(IDisposable);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				object obj;
				switch (num2)
				{
				case 10:
					if (value.Value != null)
					{
						num2 = 5;
						continue;
					}
					goto case 9;
				case 14:
					if (!object.Equals(value.Value, objB))
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 == 0)
						{
							num2 = 6;
						}
						continue;
					}
					goto case 23;
				case 2:
					schemaItemPropertyIndexes = customAttribute.DefaultValuesHandling;
					num2 = 21;
					continue;
				case 13:
					return false;
				case 16:
					schemaItemPropertyIndexes = m_RefInvocation;
					num2 = 15;
					continue;
				case 3:
					if (enumerable != null)
					{
						num2 = 19;
						continue;
					}
					goto IL_00e1;
				case 23:
					return false;
				case 6:
				case 11:
					return base.EnterMapping(key, value, context);
				case 20:
					enumerable = value.Value as IEnumerable;
					num2 = 3;
					continue;
				case 19:
				{
					IEnumerator enumerator = enumerable.GetEnumerator();
					flag = enumerator.MoveNext();
					disposable = enumerator as IDisposable;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0a707bb791e14c9e9a3ee77696a896b0 == 0)
					{
						num2 = 0;
					}
					continue;
				}
				case 18:
					disposable.Dispose();
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 == 0)
					{
						num2 = 22;
					}
					continue;
				case 9:
					return false;
				case 5:
					if ((schemaItemPropertyIndexes & (SchemaItemPropertyIndexes)4) != 0)
					{
						num2 = 20;
						continue;
					}
					goto IL_00e1;
				case 22:
					if (!flag)
					{
						num2 = 13;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d == 0)
						{
							num2 = 13;
						}
						continue;
					}
					goto IL_00e1;
				case 15:
					customAttribute = key.GetCustomAttribute<FilterInvocation>();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef != 0)
					{
						num2 = 1;
					}
					continue;
				case 1:
					if (customAttribute != null)
					{
						num2 = 7;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
						{
							num2 = 5;
						}
						continue;
					}
					goto case 8;
				case 8:
				case 21:
					if ((schemaItemPropertyIndexes & (SchemaItemPropertyIndexes)1) != 0)
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 != 0)
						{
							num2 = 10;
						}
						continue;
					}
					goto case 5;
				case 7:
					if (!customAttribute.IsDefaultValuesHandlingSpecified)
					{
						num2 = 8;
						continue;
					}
					goto case 2;
				default:
					if (disposable != null)
					{
						num2 = 18;
						continue;
					}
					goto case 22;
				case 4:
				{
					DefaultValueAttribute? customAttribute2 = key.GetCustomAttribute<DefaultValueAttribute>();
					if (customAttribute2 == null)
					{
						num2 = 12;
						continue;
					}
					obj = customAttribute2.Value;
					goto IL_02a6;
				}
				case 12:
					obj = null;
					goto IL_02a6;
				case 17:
					{
						obj = GetDefault(key.Type);
						break;
					}
					IL_00e1:
					if ((schemaItemPropertyIndexes & (SchemaItemPropertyIndexes)2) == 0)
					{
						num2 = 11;
						continue;
					}
					goto case 4;
					IL_02a6:
					if (obj != null)
					{
						break;
					}
					goto end_IL_0012;
				}
				objB = obj;
				num2 = 14;
				continue;
				end_IL_0012:
				break;
			}
			num = 17;
		}
	}

	internal static bool RegisterImporter()
	{
		return PublishImporter == null;
	}

	internal static SpecificationInvocation SetupImporter()
	{
		return PublishImporter;
	}
}
