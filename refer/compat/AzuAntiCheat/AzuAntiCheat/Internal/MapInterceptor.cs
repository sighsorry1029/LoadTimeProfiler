using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class MapInterceptor : StrategyInterceptor
{
	private readonly InstancePrototype m_HelperInterceptor;

	private static MapInterceptor DeleteMerchant;

	public MapInterceptor(InstancePrototype innerTypeDescriptor)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f011663d64054593978962dcc3a5ec1a == 0)
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
				m_HelperInterceptor = innerTypeDescriptor;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 != 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public override IEnumerable<RequestPrototype> GetProperties(Type type, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] object container)
	{
		return from p in (from p in m_HelperInterceptor.GetProperties(type, container)
				where p.GetCustomAttribute<CallbackInterceptor>() == null
				select p).Select((Func<RequestPrototype, RequestPrototype>)([_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)] (RequestPrototype p) =>
			{
				int num = 1;
				int num2 = num;
				ProcessPrototype processPrototype = default(ProcessPrototype);
				RulesInterceptor customAttribute = default(RulesInterceptor);
				while (true)
				{
					switch (num2)
					{
					case 7:
					case 10:
						return processPrototype;
					case 3:
						if (customAttribute.Alias == null)
						{
							num2 = 7;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_91887e48b8104e7da08b48f73b607337 == 0)
							{
								num2 = 1;
							}
							continue;
						}
						goto case 6;
					case 6:
						processPrototype.Name = customAttribute.Alias;
						num2 = 10;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
						{
							num2 = 6;
						}
						continue;
					default:
						customAttribute = p.GetCustomAttribute<RulesInterceptor>();
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
						{
							num2 = 2;
						}
						continue;
					case 4:
						processPrototype.TypeOverride = customAttribute.SerializeAs;
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab == 0)
						{
							num2 = 5;
						}
						continue;
					case 2:
						if (customAttribute != null)
						{
							num2 = 8;
							continue;
						}
						goto case 7;
					case 8:
						if (customAttribute.SerializeAs != null)
						{
							num2 = 4;
							continue;
						}
						break;
					case 1:
						processPrototype = new ProcessPrototype(p);
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb != 0)
						{
							num2 = 0;
						}
						continue;
					case 9:
						processPrototype.ScalarStyle = customAttribute.ScalarStyle;
						num2 = 3;
						continue;
					case 5:
						break;
					}
					processPrototype.Order = customAttribute.Order;
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c2b9915913b8461884afdca5d98855ec == 0)
					{
						num2 = 9;
					}
				}
			}))
			orderby p.Order
			select p;
	}

	internal static bool FillMerchant()
	{
		return DeleteMerchant == null;
	}

	internal static MapInterceptor FlushMerchant()
	{
		return DeleteMerchant;
	}
}
