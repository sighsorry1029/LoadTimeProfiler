using System;

namespace AzuAnticheat.Internal;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
internal sealed class InterceptorInvocation : Attribute
{
	internal static InterceptorInvocation ResolveOrder;

	public InterceptorInvocation()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool DefineOrder()
	{
		return ResolveOrder == null;
	}

	internal static InterceptorInvocation IncludeOrder()
	{
		return ResolveOrder;
	}
}
