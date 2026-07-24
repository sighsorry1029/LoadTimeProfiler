using System;

namespace AzuAnticheat.Internal;

[AttributeUsage(AttributeTargets.Method)]
internal sealed class SetterAttribute : Attribute
{
	private static SetterAttribute StartIssuer;

	public SetterAttribute()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool RemoveIssuer()
	{
		return StartIssuer == null;
	}

	internal static SetterAttribute ResolveIssuer()
	{
		return StartIssuer;
	}
}
