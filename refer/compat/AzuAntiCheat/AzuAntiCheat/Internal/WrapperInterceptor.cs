using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class WrapperInterceptor : StrategyInterceptor
{
	private readonly InstancePrototype serverInterceptor;

	private static WrapperInterceptor QueryUtils;

	public WrapperInterceptor(InstancePrototype innerTypeDescriptor)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb != 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 0:
				return;
			case 1:
				serverInterceptor = innerTypeDescriptor ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1544119467 ^ -1544095725));
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 == 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	public override IEnumerable<RequestPrototype> GetProperties(Type type, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] object container)
	{
		return from p in serverInterceptor.GetProperties(type, container)
			where p.CanWrite
			select p;
	}

	internal static bool AwakeUtils()
	{
		return QueryUtils == null;
	}

	internal static WrapperInterceptor InstantiateUtils()
	{
		return QueryUtils;
	}
}
