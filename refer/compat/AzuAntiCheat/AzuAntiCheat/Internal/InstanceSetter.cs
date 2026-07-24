using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class InstanceSetter : ParamSetter
{
	[CompilerGenerated]
	private string _OrderSetter;

	[CompilerGenerated]
	private ConnectionInterpreter _ContainerSetter;

	[CompilerGenerated]
	private bool _IteratorSetter;

	[CompilerGenerated]
	private bool m_ClientSetter;

	private static InstanceSetter CustomizeParameter;

	public string RenderedValue
	{
		[CompilerGenerated]
		get
		{
			return _OrderSetter;
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
					_OrderSetter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public ConnectionInterpreter Style
	{
		[CompilerGenerated]
		get
		{
			return _ContainerSetter;
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
					_ContainerSetter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public bool IsPlainImplicit
	{
		[CompilerGenerated]
		get
		{
			return _IteratorSetter;
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
					_IteratorSetter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public bool IsQuotedImplicit
	{
		[CompilerGenerated]
		get
		{
			return m_ClientSetter;
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
					m_ClientSetter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 == 0)
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

	public InstanceSetter(ImporterSetter source)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(source);
		int num = 2;
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 2:
				Style = source.ScalarStyle;
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 == 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			case 1:
				RenderedValue = string.Empty;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d == 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	internal static bool CancelParameter()
	{
		return CustomizeParameter == null;
	}

	internal static InstanceSetter ReflectParameter()
	{
		return CustomizeParameter;
	}
}
