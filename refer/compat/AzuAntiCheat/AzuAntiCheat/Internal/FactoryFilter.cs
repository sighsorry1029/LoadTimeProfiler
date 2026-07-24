using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class FactoryFilter : RoleFilter
{
	private static FactoryFilter DestroyProcess;

	public FactoryFilter(ParserPrototype<ModelReader> nextVisitor)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(nextVisitor);
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
			case 2:
				return null;
			default:
				return Activator.CreateInstance(type);
			case 1:
				if (CollectionBase.IsValueType(type))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 2;
			}
		}
	}

	public override bool EnterMapping(UtilsPrototype key, UtilsPrototype value, ModelReader context)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				if (object.Equals(value.Value, GetDefault(value.Type)))
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 != 0)
					{
						num2 = 1;
					}
					break;
				}
				goto default;
			default:
				return base.EnterMapping(key, value, context);
			case 1:
				return false;
			}
		}
	}

	public override bool EnterMapping(RequestPrototype key, UtilsPrototype value, ModelReader context)
	{
		int num = 4;
		int num2 = num;
		object objB = default(object);
		DefaultValueAttribute customAttribute = default(DefaultValueAttribute);
		while (true)
		{
			object obj;
			switch (num2)
			{
			default:
				if (object.Equals(value.Value, objB))
				{
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 != 0)
					{
						num2 = 4;
					}
					continue;
				}
				goto case 1;
			case 1:
				return base.EnterMapping(key, value, context);
			case 5:
				return false;
			case 4:
				customAttribute = key.GetCustomAttribute<DefaultValueAttribute>();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 == 0)
				{
					num2 = 3;
				}
				continue;
			case 3:
				if (customAttribute == null)
				{
					num2 = 2;
					continue;
				}
				obj = customAttribute.Value;
				break;
			case 2:
				obj = GetDefault(key.Type);
				break;
			}
			objB = obj;
			num2 = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae50b6e347494ff2973fbc64d1fc9236 == 0)
			{
				num2 = 0;
			}
		}
	}

	internal static bool ComputeProcess()
	{
		return DestroyProcess == null;
	}

	internal static FactoryFilter DisableProcess()
	{
		return DestroyProcess;
	}
}
