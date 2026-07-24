using System;

namespace AzuAnticheat.Internal;

[AttributeUsage(AttributeTargets.Method)]
internal sealed class FactoryAttribute : Attribute
{
	internal static FactoryAttribute InstantiateIssuer;

	public FactoryAttribute()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9c47a25d924946efb9e023473a095794 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool LoginIssuer()
	{
		return InstantiateIssuer == null;
	}

	internal static FactoryAttribute ConnectIssuer()
	{
		return InstantiateIssuer;
	}
}
