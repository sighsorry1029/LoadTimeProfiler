using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class PrototypeInterceptor : RecordPrototype
{
	private readonly List<MappingFactory> m_InterceptorInterceptor;

	private static PrototypeInterceptor CloneMerchant;

	public IList<MappingFactory> Events => m_InterceptorInterceptor;

	void RecordPrototype.Read(StubReader parser, Type expectedType, ServicePrototype nestedObjectDeserializer)
	{
		int num = 2;
		int num2 = num;
		MappingFactory current = default(MappingFactory);
		int num3 = default(int);
		while (true)
		{
			switch (num2)
			{
			default:
				m_InterceptorInterceptor.Add(current);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b == 0)
				{
					num2 = 4;
				}
				break;
			case 7:
				if (!parser.MoveNext())
				{
					num2 = 5;
					break;
				}
				current = parser.Current;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 != 0)
				{
					num2 = 0;
				}
				break;
			case 5:
				throw new InvalidOperationException(DicSingleton.gE3WbyDVW(--798431903 ^ 0x2F974591));
			case 3:
				return;
			case 2:
				m_InterceptorInterceptor.Clear();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb != 0)
				{
					num2 = 1;
				}
				break;
			case 4:
				num3 += current.NestingIncrease;
				num2 = 6;
				break;
			case 1:
				num3 = 0;
				num2 = 7;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb == 0)
				{
					num2 = 0;
				}
				break;
			case 6:
				if (num3 <= 0)
				{
					num2 = 3;
					break;
				}
				goto case 7;
			}
		}
	}

	void RecordPrototype.Write(ModelReader emitter, BridgePrototype nestedObjectSerializer)
	{
		foreach (MappingFactory item in m_InterceptorInterceptor)
		{
			emitter.Emit(item);
		}
	}

	public PrototypeInterceptor()
	{
		GetterIssuer.DeleteInitializer();
		m_InterceptorInterceptor = new List<MappingFactory>();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool ReadMerchant()
	{
		return CloneMerchant == null;
	}

	internal static PrototypeInterceptor ViewMerchant()
	{
		return CloneMerchant;
	}
}
