using System;

namespace AzuAnticheat.Internal;

[AttributeUsage(AttributeTargets.Method)]
internal sealed class WriterAttribute : Attribute
{
	internal static WriterAttribute DefineIssuer;

	public WriterAttribute()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool IncludeIssuer()
	{
		return DefineIssuer == null;
	}

	internal static WriterAttribute CheckIssuer()
	{
		return DefineIssuer;
	}
}
