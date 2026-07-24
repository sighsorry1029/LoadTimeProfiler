using System;

namespace AzuAnticheat.Internal;

internal class FilterAttribute : StrategySetter
{
	internal static FilterAttribute FlushIssuer;

	public bool Accepts(Type type)
	{
		return typeof(Type).IsAssignableFrom(type);
	}

	public object ReadYaml(CandidateInterpreter parser, Type type)
	{
		return Type.GetType(parser.Consume<BridgeSingleton>().Value, throwOnError: true);
	}

	public void WriteYaml(MockInterpreter emitter, object? value, Type type)
	{
		int num = 1;
		int num2 = num;
		Type type2 = default(Type);
		while (true)
		{
			switch (num2)
			{
			case 2:
				return;
			case 1:
				type2 = (Type)value;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb != 0)
				{
					num2 = 0;
				}
				break;
			default:
				emitter.Emit(new BridgeSingleton(VisitorAttribute._StubAttribute, RoleSingleton.publisherSingleton, type2.AssemblyQualifiedName, (ConnectionInterpreter)0, isPlainImplicit: true, isQuotedImplicit: false));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 == 0)
				{
					num2 = 2;
				}
				break;
			}
		}
	}

	public FilterAttribute()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool DestroyIssuer()
	{
		return FlushIssuer == null;
	}

	internal static FilterAttribute ComputeIssuer()
	{
		return FlushIssuer;
	}
}
