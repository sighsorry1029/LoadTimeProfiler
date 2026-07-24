using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal class StubFilter : StatusPrototype
{
	internal static StubFilter ComputeAnnotation;

	public bool Accepts(Type type)
	{
		return typeof(Type).IsAssignableFrom(type);
	}

	public object ReadYaml(StubReader parser, Type type)
	{
		return Type.GetType(parser.Consume<ClassFactory>().Value, throwOnError: true);
	}

	public void WriteYaml(ModelReader emitter, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] object value, Type type)
	{
		int num = 1;
		int num2 = num;
		Type type2 = default(Type);
		while (true)
		{
			switch (num2)
			{
			default:
				emitter.Emit(new ClassFactory(HelperReader._ExceptionReader, ValueFactory._DecoratorFactory, type2.AssemblyQualifiedName, (RuleFactory)0, isPlainImplicit: true, isQuotedImplicit: false));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 != 0)
				{
					num2 = 2;
				}
				break;
			case 2:
				return;
			case 1:
				type2 = (Type)value;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public StubFilter()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool DisableAnnotation()
	{
		return ComputeAnnotation == null;
	}

	internal static StubFilter QueryAnnotation()
	{
		return ComputeAnnotation;
	}
}
