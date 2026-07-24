using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace AzuAnticheat.Internal;

[DebuggerNonUserCode]
[ExcludeFromCodeCoverage]
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, Inherited = false)]
internal sealed class RepositorySingleton : Attribute
{
	private static RepositorySingleton AwakeGetter;

	public RepositorySingleton()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_259acdc10a3c4fba8a4f129ba5346de2 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool InstantiateGetter()
	{
		return AwakeGetter == null;
	}

	internal static RepositorySingleton LoginGetter()
	{
		return AwakeGetter;
	}
}
