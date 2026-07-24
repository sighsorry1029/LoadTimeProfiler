using System;
using System.Runtime.CompilerServices;
using HarmonyLib;

namespace AzuAnticheat.Internal;

[Serializable]
[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
[HarmonyPatch]
internal class StatePublisher
{
	[CompilerGenerated]
	private string valuePublisher;

	[CompilerGenerated]
	private string m_DecoratorPublisher;

	[CompilerGenerated]
	private string _BroadcasterPublisher;

	[CompilerGenerated]
	private string _WorkerPublisher;

	private static StatePublisher FlushVisitor;

	[FilterInvocation(Alias = "url")]
	public string Url
	{
		[CompilerGenerated]
		get
		{
			return valuePublisher;
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
					valuePublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	[FilterInvocation(Alias = "proxy_url", ApplyNamingConventions = false)]
	public string ProxyIcon
	{
		[CompilerGenerated]
		get
		{
			return m_DecoratorPublisher;
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
					m_DecoratorPublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	[FilterInvocation(Alias = "width")]
	public string Width
	{
		[CompilerGenerated]
		get
		{
			return _BroadcasterPublisher;
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
					_BroadcasterPublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae50b6e347494ff2973fbc64d1fc9236 != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	[FilterInvocation(Alias = "height")]
	public string Height
	{
		[CompilerGenerated]
		get
		{
			return _WorkerPublisher;
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
					_WorkerPublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public StatePublisher()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool DestroyVisitor()
	{
		return FlushVisitor == null;
	}

	internal static StatePublisher ComputeVisitor()
	{
		return FlushVisitor;
	}
}
