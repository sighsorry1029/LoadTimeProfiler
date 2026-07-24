namespace AzuAnticheat.Internal;

internal static class ParamsAttribute
{
	public static readonly TemplateSingleton[] _PoolAttribute;

	internal static ParamsAttribute SelectConsumer;

	static ParamsAttribute()
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 0:
				return;
			case 2:
				GetterIssuer.DeleteInitializer();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e == 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				_PoolAttribute = new TemplateSingleton[2]
				{
					new TemplateSingleton(DicSingleton.gE3WbyDVW(-32559551 ^ -32549031), DicSingleton.gE3WbyDVW(0x270E0638 ^ 0x270E7F20)),
					new TemplateSingleton(DicSingleton.gE3WbyDVW(-1863475926 ^ -1863457740), DicSingleton.gE3WbyDVW(0x120E76C ^ 0x1209E4A))
				};
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool ChangeConsumer()
	{
		return SelectConsumer == null;
	}

	internal static ParamsAttribute CreateConsumer()
	{
		return SelectConsumer;
	}
}
