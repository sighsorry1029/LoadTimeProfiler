using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class ValFilter : BroadcasterPrototype
{
	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(1)]
	public static readonly BroadcasterPrototype configFilter;

	internal static ValFilter PrintAnnotation;

	private ValFilter()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0a707bb791e14c9e9a3ee77696a896b0 != 0)
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
		return FacadeInterceptor.ToCamelCase(value).ToLower();
	}

	static ValFilter()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				return;
			default:
				configFilter = new ValFilter();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4e61b266153f422fa6c595cfef4d40d3 == 0)
				{
					num2 = 2;
				}
				break;
			case 1:
				GetterIssuer.DeleteInitializer();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool CompareAnnotation()
	{
		return PrintAnnotation == null;
	}

	internal static ValFilter CloneAnnotation()
	{
		return PrintAnnotation;
	}
}
