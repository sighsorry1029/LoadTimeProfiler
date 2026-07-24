using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal class RulesAttribute
{
	[CompilerGenerated]
	private readonly HashSet<VisitorAttribute> getterAttribute;

	internal static RulesAttribute MapToken;

	public HashSet<VisitorAttribute> EmittedAnchors
	{
		[CompilerGenerated]
		get
		{
			return getterAttribute;
		}
	}

	public RulesAttribute()
	{
		GetterIssuer.DeleteInitializer();
		getterAttribute = new HashSet<VisitorAttribute>();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool NewToken()
	{
		return MapToken == null;
	}

	internal static RulesAttribute AddToken()
	{
		return MapToken;
	}
}
