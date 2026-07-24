using System;
using System.Runtime.CompilerServices;
using HarmonyLib;

namespace AzuAnticheat.Internal;

[Serializable]
[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
[HarmonyPatch]
[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
internal class WatcherPublisher
{
	[CompilerGenerated]
	private string _CustomerPublisher;

	[CompilerGenerated]
	private string systemPublisher;

	[CompilerGenerated]
	private bool _ResolverPublisher;

	private static WatcherPublisher SearchVisitor;

	[FilterInvocation(Alias = "name")]
	public string Key
	{
		[CompilerGenerated]
		get
		{
			return _CustomerPublisher;
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
					_CustomerPublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 != 0)
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

	[FilterInvocation(Alias = "value")]
	public string Value
	{
		[CompilerGenerated]
		get
		{
			return systemPublisher;
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
					systemPublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	[FilterInvocation(Alias = "inline")]
	public bool Inline
	{
		[CompilerGenerated]
		get
		{
			return _ResolverPublisher;
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
					_ResolverPublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 == 0)
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

	public WatcherPublisher()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool StopVisitor()
	{
		return SearchVisitor == null;
	}

	internal static WatcherPublisher ExcludeVisitor()
	{
		return SearchVisitor;
	}
}
