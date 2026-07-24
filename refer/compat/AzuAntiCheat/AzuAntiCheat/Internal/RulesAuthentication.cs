using System;

namespace AzuAnticheat.Internal;

internal sealed class RulesAuthentication : ServerSetter
{
	internal static RulesAuthentication ResolveImporter;

	public bool Resolve(OrderSingleton? nodeEvent, ref Type currentType)
	{
		return typeof(PolicySetter).IsAssignableFrom(currentType);
	}

	public RulesAuthentication()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool DefineImporter()
	{
		return ResolveImporter == null;
	}

	internal static RulesAuthentication IncludeImporter()
	{
		return ResolveImporter;
	}
}
