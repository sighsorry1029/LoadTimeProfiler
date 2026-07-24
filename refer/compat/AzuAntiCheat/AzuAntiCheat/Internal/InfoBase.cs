using System;

namespace AzuAnticheat.Internal;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, Inherited = false)]
internal sealed class InfoBase : Attribute
{
	internal static InfoBase QuerySingleton;

	public InfoBase()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool AwakeSingleton()
	{
		return QuerySingleton == null;
	}

	internal static InfoBase InstantiateSingleton()
	{
		return QuerySingleton;
	}
}
