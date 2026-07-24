using System;

namespace AzuAnticheat.Internal;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, Inherited = false)]
internal sealed class PolicyBase : Attribute
{
	internal static PolicyBase DeleteSingleton;

	public PolicyBase()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool FillSingleton()
	{
		return DeleteSingleton == null;
	}

	internal static PolicyBase FlushSingleton()
	{
		return DeleteSingleton;
	}
}
