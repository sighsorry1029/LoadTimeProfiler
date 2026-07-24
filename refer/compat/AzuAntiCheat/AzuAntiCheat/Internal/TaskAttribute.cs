using System.Collections.Generic;

namespace AzuAnticheat.Internal;

internal sealed class TaskAttribute : IEqualityComparer<ProductAttribute>
{
	internal static TaskAttribute FlushToken;

	public bool Equals([ImporterSingleton] ProductAttribute x, [ImporterSingleton] ProductAttribute y)
	{
		return x == y;
	}

	public int GetHashCode(ProductAttribute obj)
	{
		return obj.GetHashCode();
	}

	public TaskAttribute()
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

	internal static bool DestroyToken()
	{
		return FlushToken == null;
	}

	internal static TaskAttribute ComputeToken()
	{
		return FlushToken;
	}
}
