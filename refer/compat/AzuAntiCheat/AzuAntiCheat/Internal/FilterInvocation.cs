using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
internal sealed class FilterInvocation : Attribute
{
	[CompilerGenerated]
	private string? _ReaderInvocation;

	[CompilerGenerated]
	private Type? _FactoryInvocation;

	[CompilerGenerated]
	private int setterInvocation;

	[CompilerGenerated]
	private string? m_WriterInvocation;

	[CompilerGenerated]
	private bool m_InvocationInvocation;

	[CompilerGenerated]
	private ConnectionInterpreter m_AuthenticationInvocation;

	private SchemaItemPropertyIndexes? m_AttributeInvocation;

	private static FilterInvocation? CheckOrder;

	public string? Description
	{
		[CompilerGenerated]
		get
		{
			return _ReaderInvocation;
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
					_ReaderInvocation = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4a2885c39dcc4cf1a32db39a2ed578f0 == 0)
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

	public Type? SerializeAs
	{
		[CompilerGenerated]
		get
		{
			return _FactoryInvocation;
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
					_FactoryInvocation = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public int Order
	{
		[CompilerGenerated]
		get
		{
			return setterInvocation;
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
					setterInvocation = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public string? Alias
	{
		[CompilerGenerated]
		get
		{
			return m_WriterInvocation;
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
					m_WriterInvocation = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 != 0)
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

	public bool ApplyNamingConventions
	{
		[CompilerGenerated]
		get
		{
			return m_InvocationInvocation;
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
					m_InvocationInvocation = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 != 0)
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

	public ConnectionInterpreter ScalarStyle
	{
		[CompilerGenerated]
		get
		{
			return m_AuthenticationInvocation;
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
					m_AuthenticationInvocation = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a579dea83d2144838086d2d400bd0222 != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public SchemaItemPropertyIndexes DefaultValuesHandling
	{
		get
		{
			return m_AttributeInvocation.GetValueOrDefault();
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
				case 1:
					m_AttributeInvocation = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 != 0)
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

	public bool IsDefaultValuesHandlingSpecified => m_AttributeInvocation.HasValue;

	public FilterInvocation()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a != 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			case 2:
				return;
			case 1:
				ScalarStyle = (ConnectionInterpreter)0;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 != 0)
				{
					num = 0;
				}
				break;
			default:
				ApplyNamingConventions = true;
				num = 2;
				break;
			}
		}
	}

	public FilterInvocation(Type serializeAs)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 == 0)
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
			SerializeAs = serializeAs ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x5A8BEE ^ 0x5AEBA0));
			num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab == 0)
			{
				num = 1;
			}
		}
	}

	internal static bool RateOrder()
	{
		return CheckOrder == null;
	}

	internal static FilterInvocation? ResetOrder()
	{
		return CheckOrder;
	}
}
