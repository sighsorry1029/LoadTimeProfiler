using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class MethodFilter : TaskPrototype
{
	private static MethodFilter PatchInstance;

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	public bool Resolve([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] ListenerFactory nodeEvent, ref Type currentType)
	{
		return typeof(ParameterPrototype).IsAssignableFrom(currentType);
	}

	public MethodFilter()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9c47a25d924946efb9e023473a095794 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool AssetInstance()
	{
		return PatchInstance == null;
	}

	internal static MethodFilter ListInstance()
	{
		return PatchInstance;
	}
}
