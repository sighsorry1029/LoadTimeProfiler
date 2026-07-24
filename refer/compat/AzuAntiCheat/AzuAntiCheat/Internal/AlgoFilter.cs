using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class AlgoFilter : BroadcasterPrototype
{
	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(1)]
	public static readonly BroadcasterPrototype m_ImporterFilter;

	internal static AlgoFilter PatchAnnotation;

	[Obsolete("Use the Instance static field instead of creating new instances")]
	public AlgoFilter()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	public string Apply(string value)
	{
		return FacadeInterceptor.ToPascalCase(value);
	}

	static AlgoFilter()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				m_ImporterFilter = new AlgoFilter();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add == 0)
				{
					num2 = 2;
				}
				break;
			case 2:
				return;
			case 1:
				GetterIssuer.DeleteInitializer();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool AssetAnnotation()
	{
		return PatchAnnotation == null;
	}

	internal static AlgoFilter ListAnnotation()
	{
		return PatchAnnotation;
	}
}
