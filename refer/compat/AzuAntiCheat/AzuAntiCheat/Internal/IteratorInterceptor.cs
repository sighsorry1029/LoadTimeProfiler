using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class IteratorInterceptor : OrderPrototype
{
	internal static IteratorInterceptor CountUtils;

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	public Type Resolve(Type staticType, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] object actualValue)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				return staticType;
			default:
				return actualValue.GetType();
			case 1:
				if (actualValue != null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 != 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 2;
			}
		}
	}

	public IteratorInterceptor()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae50b6e347494ff2973fbc64d1fc9236 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool SetUtils()
	{
		return CountUtils == null;
	}

	internal static IteratorInterceptor PushUtils()
	{
		return CountUtils;
	}
}
