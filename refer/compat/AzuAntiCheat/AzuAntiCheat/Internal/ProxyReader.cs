using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal static class ProxyReader
{
	private static ProxyReader StartService;

	public static int CombineHashCodes(int h1, int h2)
	{
		return ((h1 << 5) + h1) ^ h2;
	}

	public static int CombineHashCodes(int h1, object o2)
	{
		return CombineHashCodes(h1, GetHashCode(o2));
	}

	public static int CombineHashCodes(object first, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 1, 2 })] params object[] others)
	{
		int num = 3;
		int num2 = num;
		int num3 = default(int);
		int num4 = default(int);
		object[] array = default(object[]);
		object o = default(object);
		while (true)
		{
			switch (num2)
			{
			default:
				return num3;
			case 6:
				num4 = 0;
				num2 = 4;
				break;
			case 2:
				array = others;
				num2 = 5;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c == 0)
				{
					num2 = 6;
				}
				break;
			case 5:
				num4++;
				num2 = 7;
				break;
			case 4:
			case 7:
				if (num4 >= array.Length)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 8;
			case 8:
				o = array[num4];
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 == 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				num3 = CombineHashCodes(num3, o);
				num2 = 5;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 == 0)
				{
					num2 = 2;
				}
				break;
			case 3:
				num3 = GetHashCode(first);
				num2 = 2;
				break;
			}
		}
	}

	private static int GetHashCode(object obj)
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
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 == 0)
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

	internal static bool RemoveService()
	{
		return StartService == null;
	}

	internal static ProxyReader ResolveService()
	{
		return StartService;
	}
}
