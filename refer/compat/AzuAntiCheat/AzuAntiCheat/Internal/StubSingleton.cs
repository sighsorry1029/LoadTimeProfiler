using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[DebuggerNonUserCode]
[ExcludeFromCodeCoverage]
[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
internal sealed class StubSingleton : Attribute
{
	[CompilerGenerated]
	private readonly bool m_PolicySingleton;

	internal static StubSingleton ResolveGetter;

	public bool ReturnValue
	{
		[CompilerGenerated]
		get
		{
			return m_PolicySingleton;
		}
	}

	public StubSingleton(bool returnValue)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa != 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 1:
				return;
			}
			m_PolicySingleton = returnValue;
			num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e == 0)
			{
				num = 0;
			}
		}
	}

	internal static bool DefineGetter()
	{
		return ResolveGetter == null;
	}

	internal static StubSingleton IncludeGetter()
	{
		return ResolveGetter;
	}
}
