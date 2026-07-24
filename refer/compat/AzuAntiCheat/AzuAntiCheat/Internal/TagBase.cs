using System;

namespace AzuAnticheat.Internal;

[AttributeUsage(AttributeTargets.Method, Inherited = false)]
internal sealed class TagBase : Attribute
{
	internal static TagBase VisitSingleton;

	public TagBase()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool UpdateSingleton()
	{
		return VisitSingleton == null;
	}

	internal static TagBase SearchSingleton()
	{
		return VisitSingleton;
	}
}
