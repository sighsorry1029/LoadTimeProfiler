using System;
using System.Runtime.CompilerServices;
using HarmonyLib;

namespace AzuAnticheat.Internal;

[Serializable]
[HarmonyPatch]
[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
internal class CandidatePublisher
{
	[CompilerGenerated]
	private string expressionPublisher;

	[CompilerGenerated]
	private string m_ProductPublisher;

	[CompilerGenerated]
	private string registryPublisher;

	private static CandidatePublisher InterruptVisitor;

	[FilterInvocation(Alias = "text")]
	public string Text
	{
		[CompilerGenerated]
		get
		{
			return expressionPublisher;
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
					expressionPublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 != 0)
					{
						num2 = 0;
					}
					break;
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
			return m_ProductPublisher;
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
					m_ProductPublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 != 0)
					{
						num2 = 0;
					}
					break;
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
			return registryPublisher;
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
					registryPublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be != 0)
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

	public CandidatePublisher()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool DeleteVisitor()
	{
		return InterruptVisitor == null;
	}

	internal static CandidatePublisher FillVisitor()
	{
		return InterruptVisitor;
	}
}
