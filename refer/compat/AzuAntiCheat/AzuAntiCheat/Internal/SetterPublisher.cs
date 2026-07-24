using System.Runtime.CompilerServices;
using AzuAntiCheat;
using HarmonyLib;
using UnityEngine.UI;

namespace AzuAnticheat.Internal;

[HarmonyPatch(typeof(FejdStartup), "ShowConnectError")]
internal class SetterPublisher
{
	private static SetterPublisher MapVisitor;

	[HarmonyPostfix]
	[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
	private static void Postfix(FejdStartup __instance)
	{
		int num = 4;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 5:
				__instance.m_connectionFailedError.fontSizeMax = 25f;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd == 0)
				{
					num2 = 1;
				}
				break;
			case 8:
				__instance.m_connectionFailedPanel.transform.Find(DicSingleton.gE3WbyDVW(0x5A1B57A3 ^ 0x5A1B6C77)).GetComponent<Image>().enabled = false;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c == 0)
				{
					num2 = 2;
				}
				break;
			case 7:
				return;
			default:
				if (ZNet.GetConnectionStatus() != (ZNet.ConnectionStatus)456789123)
				{
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f != 0)
					{
						num2 = 7;
					}
					break;
				}
				goto IL_00b6;
			case 4:
				if (ZNet.GetConnectionStatus() != (ZNet.ConnectionStatus)987654321)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f == 0)
					{
						num2 = 3;
					}
					break;
				}
				goto IL_00b6;
			case 1:
				__instance.m_connectionFailedError.fontSizeMin = 15f;
				num2 = 8;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 == 0)
				{
					num2 = 0;
				}
				break;
			case 6:
				__instance.m_connectionFailedError.text = Localization.instance.Localize(AzuAnticheatPlugin._Writer);
				num2 = 5;
				break;
			case 2:
				return;
			case 3:
				{
					if (ZNet.GetConnectionStatus() != (ZNet.ConnectionStatus)123456799)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e != 0)
						{
							num2 = 0;
						}
						break;
					}
					goto IL_00b6;
				}
				IL_00b6:
				if (__instance.m_connectionFailedPanel.activeSelf)
				{
					num2 = 6;
					break;
				}
				return;
			}
		}
	}

	public SetterPublisher()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool NewVisitor()
	{
		return MapVisitor == null;
	}

	internal static SetterPublisher AddVisitor()
	{
		return MapVisitor;
	}
}
