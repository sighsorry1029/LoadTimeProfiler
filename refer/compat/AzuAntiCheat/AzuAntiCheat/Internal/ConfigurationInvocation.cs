using System;
using System.ComponentModel;

namespace AzuAnticheat.Internal;

internal sealed class ConfigurationInvocation : MappingInvocation
{
	private static ConfigurationInvocation MoveReg;

	public ConfigurationInvocation(ErrorSetter<MockInterpreter> nextVisitor)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(nextVisitor);
	}

	private static object? GetDefault(Type type)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				if (InterceptorSetter.IsValueType(type))
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc != 0)
					{
						num2 = 1;
					}
					break;
				}
				goto default;
			default:
				return null;
			case 1:
				return Activator.CreateInstance(type);
			}
		}
	}

	public override bool EnterMapping(ImporterSetter key, ImporterSetter value, MockInterpreter context)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (!object.Equals(value.Value, GetDefault(value.Type)))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 == 0)
					{
						num2 = 0;
					}
					break;
				}
				return false;
			default:
				return base.EnterMapping(key, value, context);
			}
		}
	}

	public override bool EnterMapping(RegSetter key, ImporterSetter value, MockInterpreter context)
	{
		int num = 1;
		int num2 = num;
		object objB = default(object);
		DefaultValueAttribute customAttribute = default(DefaultValueAttribute);
		while (true)
		{
			object? obj;
			switch (num2)
			{
			case 4:
				if (object.Equals(value.Value, objB))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 == 0)
					{
						num2 = 5;
					}
					continue;
				}
				goto case 2;
			case 2:
				return base.EnterMapping(key, value, context);
			case 5:
				return false;
			case 1:
				customAttribute = key.GetCustomAttribute<DefaultValueAttribute>();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 == 0)
				{
					num2 = 0;
				}
				continue;
			default:
				if (customAttribute == null)
				{
					num2 = 3;
					continue;
				}
				obj = customAttribute.Value;
				break;
			case 3:
				obj = GetDefault(key.Type);
				break;
			}
			objB = obj;
			num2 = 4;
		}
	}

	internal static bool RevertReg()
	{
		return MoveReg == null;
	}

	internal static ConfigurationInvocation InvokeImporter()
	{
		return MoveReg;
	}
}
