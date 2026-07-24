using System;
using System.Runtime.CompilerServices;
using HarmonyLib;

namespace AzuAnticheat.Internal;

[Serializable]
[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
[HarmonyPatch]
[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
internal class InterpreterPublisher
{
	[CompilerGenerated]
	private string singletonPublisher;

	[CompilerGenerated]
	private string issuerPublisher;

	[CompilerGenerated]
	private string m_FieldPublisher;

	[CompilerGenerated]
	private string rulePublisher;

	private static InterpreterPublisher LogoutVisitor;

	[FilterInvocation(Alias = "name")]
	public string Name
	{
		[CompilerGenerated]
		get
		{
			return singletonPublisher;
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
					singletonPublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 == 0)
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

	[FilterInvocation(Alias = "url")]
	public string Url
	{
		[CompilerGenerated]
		get
		{
			return issuerPublisher;
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
					issuerPublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f == 0)
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

	[FilterInvocation(Alias = "icon_url", ApplyNamingConventions = false)]
	public string Icon
	{
		[CompilerGenerated]
		get
		{
			return m_FieldPublisher;
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
					m_FieldPublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4e61b266153f422fa6c595cfef4d40d3 != 0)
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

	[FilterInvocation(Alias = "proxy_icon_url", ApplyNamingConventions = false)]
	public string ProxyIcon
	{
		[CompilerGenerated]
		get
		{
			return rulePublisher;
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
					rulePublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public InterpreterPublisher()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool CountVisitor()
	{
		return LogoutVisitor == null;
	}

	internal static InterpreterPublisher SetVisitor()
	{
		return LogoutVisitor;
	}
}
