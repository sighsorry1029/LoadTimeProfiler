using System;

namespace AzuAnticheat.Internal;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
internal sealed class CallbackInterceptor : Attribute
{
	private static CallbackInterceptor LoginMerchant;

	public CallbackInterceptor()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool ConnectMerchant()
	{
		return LoginMerchant == null;
	}

	internal static CallbackInterceptor StartMerchant()
	{
		return LoginMerchant;
	}
}
