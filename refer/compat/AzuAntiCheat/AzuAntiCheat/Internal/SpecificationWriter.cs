using System;
using System.Collections.Generic;
using System.Linq;

namespace AzuAnticheat.Internal;

internal sealed class SpecificationWriter : ConfigInvocation
{
	private readonly AdvisorSetter m_RefWriter;

	private static SpecificationWriter ComputeOrder;

	public SpecificationWriter(AdvisorSetter innerTypeDescriptor)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 1:
				return;
			}
			m_RefWriter = innerTypeDescriptor;
			num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 == 0)
			{
				num = 1;
			}
		}
	}

	public override IEnumerable<RegSetter> GetProperties(Type type, object? container)
	{
		return from p in (from p in m_RefWriter.GetProperties(type, container)
				where p.GetCustomAttribute<InterceptorInvocation>() == null
				select p).Select((Func<RegSetter, RegSetter>)delegate(RegSetter p)
			{
				int num = 4;
				ConfigurationSetter configurationSetter = default(ConfigurationSetter);
				FilterInvocation customAttribute = default(FilterInvocation);
				while (true)
				{
					int num2 = num;
					while (true)
					{
						switch (num2)
						{
						case 4:
							configurationSetter = new ConfigurationSetter(p);
							num2 = 3;
							continue;
						case 1:
							configurationSetter.Name = customAttribute.Alias;
							num2 = 10;
							continue;
						default:
							if (customAttribute.SerializeAs != null)
							{
								num2 = 2;
								continue;
							}
							goto case 6;
						case 5:
						case 10:
							return configurationSetter;
						case 2:
							break;
						case 9:
							if (customAttribute.Alias != null)
							{
								num2 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 == 0)
								{
									num2 = 1;
								}
								continue;
							}
							goto case 5;
						case 8:
							if (customAttribute == null)
							{
								num2 = 5;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 != 0)
								{
									num2 = 0;
								}
								continue;
							}
							goto default;
						case 6:
							configurationSetter.Order = customAttribute.Order;
							num2 = 7;
							continue;
						case 3:
							customAttribute = p.GetCustomAttribute<FilterInvocation>();
							num2 = 8;
							continue;
						case 7:
							configurationSetter.ScalarStyle = customAttribute.ScalarStyle;
							num2 = 9;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 == 0)
							{
								num2 = 9;
							}
							continue;
						}
						break;
					}
					configurationSetter.TypeOverride = customAttribute.SerializeAs;
					num = 6;
				}
			})
			orderby p.Order
			select p;
	}

	internal static bool DisableOrder()
	{
		return ComputeOrder == null;
	}

	internal static SpecificationWriter QueryOrder()
	{
		return ComputeOrder;
	}
}
