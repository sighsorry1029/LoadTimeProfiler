using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[Serializable]
[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(2)]
internal class Params
{
	[FilterInvocation(Alias = "HookName", ApplyNamingConventions = false)]
	public string pool;

	[CompilerGenerated]
	private string descriptor;

	internal static Params DisableExpression;

	[FilterInvocation(Alias = "Hook", ApplyNamingConventions = false)]
	public string Hook
	{
		[CompilerGenerated]
		get
		{
			return descriptor;
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
					descriptor = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public Params()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool QueryExpression()
	{
		return DisableExpression == null;
	}

	internal static Params AwakeExpression()
	{
		return DisableExpression;
	}
}
