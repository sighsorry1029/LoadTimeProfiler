using System;
using System.Collections.Generic;
using System.Linq;

namespace AzuAnticheat.Internal;

internal sealed class TestsInvocation : ConfigInvocation
{
	private readonly AdvisorSetter m_InitializerInvocation;

	private readonly ConfigSetter _PageInvocation;

	internal static TestsInvocation CollectProxy;

	public TestsInvocation(AdvisorSetter innerTypeDescriptor, ConfigSetter namingConvention)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 == 0)
		{
			num = 0;
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
				m_InitializerInvocation = innerTypeDescriptor ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x38262FC9 ^ 0x38264C8F));
				num = 2;
				break;
			case 2:
				_PageInvocation = namingConvention ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x6DF53C90 ^ 0x6DF56912));
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add != 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	public override IEnumerable<RegSetter> GetProperties(Type type, object? container)
	{
		return m_InitializerInvocation.GetProperties(type, container).Select(delegate(RegSetter p)
		{
			int num = 3;
			int num2 = num;
			FilterInvocation customAttribute = default(FilterInvocation);
			while (true)
			{
				switch (num2)
				{
				case 2:
					if (customAttribute != null)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 != 0)
						{
							num2 = 0;
						}
						break;
					}
					goto case 1;
				default:
					if (customAttribute.ApplyNamingConventions)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 == 0)
						{
							num2 = 1;
						}
						break;
					}
					goto case 4;
				case 4:
					return p;
				case 1:
					return new ConfigurationSetter(p)
					{
						Name = _PageInvocation.Apply(p.Name)
					};
				case 3:
					customAttribute = p.GetCustomAttribute<FilterInvocation>();
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
					{
						num2 = 1;
					}
					break;
				}
			}
		});
	}

	internal static bool ManageProxy()
	{
		return CollectProxy == null;
	}

	internal static TestsInvocation ForgotProxy()
	{
		return CollectProxy;
	}
}
