using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace AzuAnticheat.Internal;

[DebuggerNonUserCode]
[ExcludeFromCodeCoverage]
[AttributeUsage(AttributeTargets.Method, Inherited = false)]
internal sealed class PrinterSingleton : Attribute
{
	private static PrinterSingleton EnableGetter;

	public PrinterSingleton()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool SortGetter()
	{
		return EnableGetter == null;
	}

	internal static PrinterSingleton InsertGetter()
	{
		return EnableGetter;
	}
}
