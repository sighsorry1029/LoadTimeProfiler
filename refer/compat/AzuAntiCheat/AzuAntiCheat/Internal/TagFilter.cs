using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal class TagFilter : StatusPrototype
{
	private readonly bool _VisitorFilter;

	private static TagFilter FillAnnotation;

	public TagFilter(bool jsonCompatible)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b == 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 1:
				_VisitorFilter = jsonCompatible;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 == 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public bool Accepts(Type type)
	{
		return type == typeof(Guid);
	}

	public object ReadYaml(StubReader parser, Type type)
	{
		return new Guid(parser.Consume<ClassFactory>().Value);
	}

	public void WriteYaml(ModelReader emitter, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] object value, Type type)
	{
		int num = 1;
		int num2 = num;
		Guid guid = default(Guid);
		while (true)
		{
			switch (num2)
			{
			case 1:
				guid = (Guid)value;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a579dea83d2144838086d2d400bd0222 != 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				return;
			default:
				emitter.Emit(new ClassFactory(HelperReader._ExceptionReader, ValueFactory._DecoratorFactory, guid.ToString(DicSingleton.gE3WbyDVW(0x6CF51E1A ^ 0x6CF570F2)), _VisitorFilter ? ((RuleFactory)3) : ((RuleFactory)0), isPlainImplicit: true, isQuotedImplicit: false));
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 == 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	internal static bool FlushAnnotation()
	{
		return FillAnnotation == null;
	}

	internal static TagFilter DestroyAnnotation()
	{
		return FillAnnotation;
	}
}
