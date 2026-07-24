using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace AzuAnticheat.Internal;

[ExcludeFromCodeCoverage]
[DebuggerNonUserCode]
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, Inherited = false)]
internal sealed class RegSingleton : Attribute
{
	private static RegSingleton UpdateGetter;

	public RegSingleton()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool SearchGetter()
	{
		return UpdateGetter == null;
	}

	internal static RegSingleton StopGetter()
	{
		return UpdateGetter;
	}
}
