using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class RegistryPrototype : ContextPrototype
{
	internal static RegistryPrototype InvokeMethod;

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	public RegistryPrototype(UtilsPrototype source)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(source);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool PublishMethod()
	{
		return InvokeMethod == null;
	}

	internal static RegistryPrototype RegisterMethod()
	{
		return InvokeMethod;
	}
}
