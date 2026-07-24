using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class ExporterInterceptor : StrategyInterceptor
{
	private readonly InstancePrototype valInterceptor;

	private readonly BroadcasterPrototype configInterceptor;

	private static ExporterInterceptor DestroyUtils;

	public ExporterInterceptor(InstancePrototype innerTypeDescriptor, BroadcasterPrototype namingConvention)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 2;
		while (true)
		{
			switch (num)
			{
			case 1:
				return;
			case 2:
				valInterceptor = innerTypeDescriptor ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-736996892 ^ -737004894));
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 != 0)
				{
					num = 0;
				}
				break;
			default:
				configInterceptor = namingConvention ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-849667636 ^ -849654706));
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 == 0)
				{
					num = 1;
				}
				break;
			}
		}
	}

	public override IEnumerable<RequestPrototype> GetProperties(Type type, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] object container)
	{
		return valInterceptor.GetProperties(type, container).Select([_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)] (RequestPrototype p) =>
		{
			int num = 2;
			int num2 = num;
			RulesInterceptor customAttribute = default(RulesInterceptor);
			while (true)
			{
				switch (num2)
				{
				case 4:
					if (customAttribute.ApplyNamingConventions)
					{
						num2 = 5;
						break;
					}
					goto default;
				case 2:
					customAttribute = p.GetCustomAttribute<RulesInterceptor>();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf == 0)
					{
						num2 = 0;
					}
					break;
				default:
					return p;
				case 3:
				case 5:
					return new ProcessPrototype(p)
					{
						Name = configInterceptor.Apply(p.Name)
					};
				case 1:
					if (customAttribute == null)
					{
						num2 = 3;
						break;
					}
					goto case 4;
				}
			}
		});
	}

	internal static bool ComputeUtils()
	{
		return DestroyUtils == null;
	}

	internal static ExporterInterceptor DisableUtils()
	{
		return DestroyUtils;
	}
}
