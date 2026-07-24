using System;

namespace AzuAnticheat.Internal;

internal sealed class CallbackAuthentication : ServerSetter
{
	private static CallbackAuthentication ConnectImporter;

	public bool Resolve(OrderSingleton? nodeEvent, ref Type currentType)
	{
		return typeof(TagSetter).IsAssignableFrom(currentType);
	}

	public CallbackAuthentication()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool StartImporter()
	{
		return ConnectImporter == null;
	}

	internal static CallbackAuthentication RemoveImporter()
	{
		return ConnectImporter;
	}
}
