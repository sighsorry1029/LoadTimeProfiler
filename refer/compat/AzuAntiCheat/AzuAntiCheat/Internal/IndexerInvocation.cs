using System;

namespace AzuAnticheat.Internal;

internal class IndexerInvocation : TokenInvocation
{
	internal static IndexerInvocation ReadProxy;

	public object? ChangeType(object? value, Type expectedType)
	{
		return ResolverInvocation.ChangeType(value, expectedType);
	}

	public IndexerInvocation()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_35cf05af90cc4195a86c9ffc19bf78eb == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool ViewProxy()
	{
		return ReadProxy == null;
	}

	internal static IndexerInvocation InitProxy()
	{
		return ReadProxy;
	}
}
