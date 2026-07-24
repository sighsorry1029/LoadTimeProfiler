using System;

namespace AzuAnticheat.Internal;

internal class CallbackInvocation : TokenInvocation
{
	internal static CallbackInvocation AddProxy;

	public object? ChangeType(object? value, Type expectedType)
	{
		return value;
	}

	public CallbackInvocation()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool PrepareProxy()
	{
		return AddProxy == null;
	}

	internal static CallbackInvocation WriteProxy()
	{
		return AddProxy;
	}
}
