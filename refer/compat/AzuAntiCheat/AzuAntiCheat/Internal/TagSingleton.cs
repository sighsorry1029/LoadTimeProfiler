using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[ExcludeFromCodeCoverage]
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = true, Inherited = false)]
[DebuggerNonUserCode]
internal sealed class TagSingleton : Attribute
{
	[CompilerGenerated]
	private readonly string visitorSingleton;

	private static TagSingleton ConnectGetter;

	public string ParameterName
	{
		[CompilerGenerated]
		get
		{
			return visitorSingleton;
		}
	}

	public TagSingleton(string parameterName)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 == 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 1:
				visitorSingleton = parameterName;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 != 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal static bool StartGetter()
	{
		return ConnectGetter == null;
	}

	internal static TagSingleton RemoveGetter()
	{
		return ConnectGetter;
	}
}
