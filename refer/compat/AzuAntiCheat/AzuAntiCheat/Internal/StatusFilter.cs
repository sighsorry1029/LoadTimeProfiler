using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class StatusFilter : WorkerPrototype
{
	private readonly InitializerPrototype m_MerchantFilter;

	private static StatusFilter PopAnnotation;

	public StatusFilter(InitializerPrototype objectFactory)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e == 0)
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
				m_MerchantFilter = objectFactory;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d5c0c185d7b1430b897cb64adc93b81c != 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public bool Deserialize(StubReader parser, Type expectedType, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 1, 1, 1, 2 })] Func<StubReader, Type, object> nestedObjectDeserializer, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] out object value)
	{
		if (typeof(ParameterPrototype).IsAssignableFrom(expectedType))
		{
			ParameterPrototype parameterPrototype = (ParameterPrototype)m_MerchantFilter.Create(expectedType);
			parameterPrototype.ReadYaml(parser);
			value = parameterPrototype;
			return true;
		}
		value = null;
		return false;
	}

	internal static bool PostAnnotation()
	{
		return PopAnnotation == null;
	}

	internal static StatusFilter CallAnnotation()
	{
		return PopAnnotation;
	}
}
