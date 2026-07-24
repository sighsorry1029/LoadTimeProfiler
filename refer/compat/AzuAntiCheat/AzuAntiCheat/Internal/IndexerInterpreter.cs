namespace AzuAnticheat.Internal;

internal static class IndexerInterpreter
{
	private static IndexerInterpreter? EnableConsumer;

	public static int CombineHashCodes(int h1, int h2)
	{
		return ((h1 << 5) + h1) ^ h2;
	}

	public static int CombineHashCodes(int h1, object? o2)
	{
		return CombineHashCodes(h1, GetHashCode(o2));
	}

	private static int GetHashCode(object? obj)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				if (obj != null)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 != 0)
					{
						num2 = 1;
					}
					break;
				}
				goto default;
			default:
				return 0;
			case 1:
				return obj.GetHashCode();
			}
		}
	}

	internal static bool SortConsumer()
	{
		return EnableConsumer == null;
	}

	internal static IndexerInterpreter? InsertConsumer()
	{
		return EnableConsumer;
	}
}
