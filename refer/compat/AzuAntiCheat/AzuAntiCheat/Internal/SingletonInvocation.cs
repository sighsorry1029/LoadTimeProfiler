using System;

namespace AzuAnticheat.Internal;

internal sealed class SingletonInvocation : Attribute
{
	private static SingletonInvocation CollectOrder;

	public SingletonInvocation()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool ManageOrder()
	{
		return CollectOrder == null;
	}

	internal static SingletonInvocation ForgotOrder()
	{
		return CollectOrder;
	}
}
