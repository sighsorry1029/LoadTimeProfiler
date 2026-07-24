using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace AzuAnticheat.Internal;

[ExcludeFromCodeCoverage]
[DebuggerNonUserCode]
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, Inherited = false)]
internal sealed class ImporterSingleton : Attribute
{
	private static ImporterSingleton CalcGetter;

	public ImporterSingleton()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_575e6bd686b54d028cdc3fc324b58a39 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool LogoutGetter()
	{
		return CalcGetter == null;
	}

	internal static ImporterSingleton CountGetter()
	{
		return CalcGetter;
	}
}
