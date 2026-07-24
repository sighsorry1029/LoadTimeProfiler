using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class InitializerFilter : WorkerPrototype
{
	internal static InitializerFilter ResolveInstance;

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	bool WorkerPrototype.Deserialize(StubReader parser, Type expectedType, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 1, 1, 1, 2 })] Func<StubReader, Type, object> nestedObjectDeserializer, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] out object value)
	{
		Type type;
		if (expectedType == typeof(IEnumerable))
		{
			type = typeof(object);
		}
		else
		{
			Type implementedGenericInterface = ParserInterceptor.GetImplementedGenericInterface(expectedType, typeof(IEnumerable<>));
			if (implementedGenericInterface != expectedType)
			{
				value = null;
				return false;
			}
			type = implementedGenericInterface.GetGenericArguments()[0];
		}
		Type arg = typeof(List<>).MakeGenericType(type);
		value = nestedObjectDeserializer(parser, arg);
		return true;
	}

	public InitializerFilter()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool DefineInstance()
	{
		return ResolveInstance == null;
	}

	internal static InitializerFilter IncludeInstance()
	{
		return ResolveInstance;
	}
}
