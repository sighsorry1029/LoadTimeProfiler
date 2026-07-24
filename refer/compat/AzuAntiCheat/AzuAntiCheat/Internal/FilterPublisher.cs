using System.Runtime.CompilerServices;
using AzuAntiCheat;
using HarmonyLib;

namespace AzuAnticheat.Internal;

[HarmonyPatch(typeof(ZNet), "Awake")]
internal static class FilterPublisher
{
	internal static FilterPublisher ChangeVisitor;

	[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
	[HarmonyPostfix]
	private static void Postfix(ZNet __instance)
	{
		int num = 3;
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 6:
					if (!ZNet.instance.IsLocalInstance())
					{
						num2 = 5;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f != 0)
						{
							num2 = 0;
						}
						break;
					}
					goto case 1;
				case 1:
					AzuAnticheatPlugin.AcLogger.LogInfo(DicSingleton.gE3WbyDVW(-992201216 ^ -992211064));
					num2 = 4;
					break;
				case 2:
					if (!AzuAnticheatPlugin._Producer)
					{
						num2 = 6;
						break;
					}
					return;
				case 3:
					if (AzuAnticheatPlugin.serializer)
					{
						goto end_IL_0012;
					}
					goto case 6;
				case 0:
					return;
				case 5:
					return;
				case 4:
					AzuAnticheatPlugin.serializer = true;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 == 0)
					{
						num2 = 0;
					}
					break;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 2;
		}
	}

	internal static bool CreateVisitor()
	{
		return ChangeVisitor == null;
	}

	internal static FilterPublisher TestVisitor()
	{
		return ChangeVisitor;
	}
}
