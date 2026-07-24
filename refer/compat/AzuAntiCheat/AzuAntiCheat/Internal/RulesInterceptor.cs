using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class RulesInterceptor : Attribute
{
	[CompilerGenerated]
	private string m_GetterInterceptor;

	[CompilerGenerated]
	private Type m_CodeInterceptor;

	[CompilerGenerated]
	private int _IndexerInterceptor;

	[CompilerGenerated]
	private string m_MockInterceptor;

	[CompilerGenerated]
	private bool m_MethodInterceptor;

	[CompilerGenerated]
	private RuleFactory m_TemplateInterceptor;

	private TestDisplayGroup? predicateInterceptor;

	internal static RulesInterceptor RemoveMerchant;

	public string Description
	{
		[CompilerGenerated]
		get
		{
			return m_GetterInterceptor;
		}
		[CompilerGenerated]
		set
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 0:
					return;
				case 1:
					m_GetterInterceptor = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public Type SerializeAs
	{
		[CompilerGenerated]
		get
		{
			return m_CodeInterceptor;
		}
		[CompilerGenerated]
		set
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 1:
					m_CodeInterceptor = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e == 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}
	}

	public int Order
	{
		[CompilerGenerated]
		get
		{
			return _IndexerInterceptor;
		}
		[CompilerGenerated]
		set
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 1:
					_IndexerInterceptor = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9c47a25d924946efb9e023473a095794 != 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}
	}

	public string Alias
	{
		[CompilerGenerated]
		get
		{
			return m_MockInterceptor;
		}
		[CompilerGenerated]
		set
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 0:
					return;
				case 1:
					m_MockInterceptor = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public bool ApplyNamingConventions
	{
		[CompilerGenerated]
		get
		{
			return m_MethodInterceptor;
		}
		[CompilerGenerated]
		set
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 0:
					return;
				case 1:
					m_MethodInterceptor = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public RuleFactory ScalarStyle
	{
		[CompilerGenerated]
		get
		{
			return m_TemplateInterceptor;
		}
		[CompilerGenerated]
		set
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 0:
					return;
				case 1:
					m_TemplateInterceptor = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public TestDisplayGroup DefaultValuesHandling
	{
		get
		{
			return predicateInterceptor.GetValueOrDefault();
		}
		set
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 0:
					return;
				case 1:
					predicateInterceptor = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public bool IsDefaultValuesHandlingSpecified => predicateInterceptor.HasValue;

	public RulesInterceptor()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 2;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 2:
				ScalarStyle = (RuleFactory)0;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c == 0)
				{
					num = 1;
				}
				break;
			case 1:
				ApplyNamingConventions = true;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e == 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	public RulesInterceptor(Type serializeAs)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a579dea83d2144838086d2d400bd0222 == 0)
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
				SerializeAs = serializeAs ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1829625923 ^ -1829601293));
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0a707bb791e14c9e9a3ee77696a896b0 == 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	internal static bool ResolveMerchant()
	{
		return RemoveMerchant == null;
	}

	internal static RulesInterceptor DefineMerchant()
	{
		return RemoveMerchant;
	}
}
