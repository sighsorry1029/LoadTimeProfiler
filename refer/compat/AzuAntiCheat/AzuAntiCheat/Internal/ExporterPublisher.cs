using System.Runtime.CompilerServices;
using AzuAntiCheat;
using HarmonyLib;

namespace AzuAnticheat.Internal;

[HarmonyPatch(typeof(Player), "Awake")]
internal static class ExporterPublisher
{
	private static ExporterPublisher PrepareWrapper;

	[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
	private static void Postfix(Player __instance)
	{
		int num = 4;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				return;
			case 5:
				return;
			case 6:
				return;
			case 4:
				if (!(Player.m_localPlayer == null))
				{
					num2 = 3;
					break;
				}
				return;
			default:
				if (!(ZNet.instance != null))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 == 0)
					{
						num2 = 6;
					}
					break;
				}
				goto case 7;
			case 7:
				AzuAnticheatPlugin.serializer = ZNet.instance.LocalPlayerIsAdminOrHost();
				num2 = 5;
				break;
			case 1:
				return;
			case 3:
				if (!(__instance == Player.m_localPlayer))
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba == 0)
					{
						num2 = 2;
					}
					break;
				}
				goto default;
			}
		}
	}

	internal static bool WriteWrapper()
	{
		return PrepareWrapper == null;
	}

	internal static ExporterPublisher PrintWrapper()
	{
		return PrepareWrapper;
	}
}
