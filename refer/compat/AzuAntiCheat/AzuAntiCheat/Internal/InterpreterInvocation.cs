using System;

namespace AzuAnticheat.Internal;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
internal sealed class InterpreterInvocation : Attribute
{
	internal static InterpreterInvocation CustomizeOrder;

	public InterpreterInvocation()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public InterpreterInvocation(Type serializableType)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool CancelOrder()
	{
		return CustomizeOrder == null;
	}

	internal static InterpreterInvocation ReflectOrder()
	{
		return CustomizeOrder;
	}
}
