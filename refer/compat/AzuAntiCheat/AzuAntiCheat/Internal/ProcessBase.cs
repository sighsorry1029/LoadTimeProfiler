using System;

namespace AzuAnticheat.Internal;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, Inherited = false)]
internal sealed class ProcessBase : Attribute
{
	internal static ProcessBase PushSingleton;

	public ProcessBase()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool ValidateSingleton()
	{
		return PushSingleton == null;
	}

	internal static ProcessBase EnableSingleton()
	{
		return PushSingleton;
	}
}
