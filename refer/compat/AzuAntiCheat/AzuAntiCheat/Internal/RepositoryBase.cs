using System;

namespace AzuAnticheat.Internal;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, Inherited = false)]
internal sealed class RepositoryBase : Attribute
{
	internal static RepositoryBase SortSingleton;

	public RepositoryBase()
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

	internal static bool InsertSingleton()
	{
		return SortSingleton == null;
	}

	internal static RepositoryBase FindSingleton()
	{
		return SortSingleton;
	}
}
