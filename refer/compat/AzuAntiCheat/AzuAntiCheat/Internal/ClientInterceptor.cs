using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class ClientInterceptor : OrderPrototype
{
	internal static ClientInterceptor ValidateUtils;

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	public Type Resolve(Type staticType, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] object actualValue)
	{
		return staticType;
	}

	public ClientInterceptor()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool EnableUtils()
	{
		return ValidateUtils == null;
	}

	internal static ClientInterceptor SortUtils()
	{
		return ValidateUtils;
	}
}
