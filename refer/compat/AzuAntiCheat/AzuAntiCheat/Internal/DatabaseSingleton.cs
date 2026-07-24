using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[ExcludeFromCodeCoverage]
[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
[DebuggerNonUserCode]
internal sealed class DatabaseSingleton : Attribute
{
	[CompilerGenerated]
	private readonly bool errorSingleton;

	internal static DatabaseSingleton FindGetter;

	public bool ParameterValue
	{
		[CompilerGenerated]
		get
		{
			return errorSingleton;
		}
	}

	public DatabaseSingleton(bool parameterValue)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 0:
				return;
			case 1:
				errorSingleton = parameterValue;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add != 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	internal static bool VisitGetter()
	{
		return FindGetter == null;
	}

	internal static DatabaseSingleton OrderGetter()
	{
		return FindGetter;
	}
}
