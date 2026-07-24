using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class ConfigurationFilter : IEqualityComparer<MappingFilter>
{
	private static ConfigurationFilter NewAuthentication;

	public bool Equals([ProcessBase] MappingFilter x, [ProcessBase] MappingFilter y)
	{
		return x == y;
	}

	public int GetHashCode(MappingFilter obj)
	{
		return obj.GetHashCode();
	}

	public ConfigurationFilter()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool AddAuthentication()
	{
		return NewAuthentication == null;
	}

	internal static ConfigurationFilter PrepareAuthentication()
	{
		return NewAuthentication;
	}
}
