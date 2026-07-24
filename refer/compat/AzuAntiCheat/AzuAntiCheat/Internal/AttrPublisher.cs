using System.Runtime.CompilerServices;
using HarmonyLib;

namespace AzuAnticheat.Internal;

[HarmonyPatch(typeof(ZLog), "LogWarning")]
internal static class AttrPublisher
{
	internal static AttrPublisher PostWrapper;

	[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
	[HarmonyPrefix]
	private static bool Prefix(ZLog __instance, object o)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return false;
			case 1:
				return true;
			case 3:
				if (o.ToString().Contains(DicSingleton.gE3WbyDVW(0x554A128B ^ 0x554A57BF)))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a579dea83d2144838086d2d400bd0222 != 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 1;
			case 2:
				if (o == null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 == 0)
					{
						num2 = 1;
					}
					break;
				}
				goto case 3;
			}
		}
	}

	internal static bool CallWrapper()
	{
		return PostWrapper == null;
	}

	internal static AttrPublisher ConcatWrapper()
	{
		return PostWrapper;
	}
}
