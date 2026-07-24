using System;

namespace AzuAnticheat.Internal;

[AttributeUsage(AttributeTargets.Method)]
internal sealed class ReaderAttribute : Attribute
{
	private static ReaderAttribute DisableIssuer;

	public ReaderAttribute()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool QueryIssuer()
	{
		return DisableIssuer == null;
	}

	internal static ReaderAttribute AwakeIssuer()
	{
		return DisableIssuer;
	}
}
