using System.Runtime.CompilerServices;
using AzuAntiCheat;
using HarmonyLib;

namespace AzuAnticheat.Internal;

[HarmonyPatch(typeof(Terminal), "InputText")]
internal static class TestPublisher
{
	private static TestPublisher RunWrapper;

	[HarmonyPostfix]
	[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
	private static void Postfix(Terminal __instance)
	{
		int num = 13;
		Dispatcher dispatcher = default(Dispatcher);
		bool? consoleUseBypass = default(bool?);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 40:
					if (__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0x1606DF07 ^ 0x16069DD3)))
					{
						num2 = 34;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a579dea83d2144838086d2d400bd0222 != 0)
						{
							num2 = 52;
						}
						continue;
					}
					goto case 39;
				case 32:
					if (!__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0x1C779450 ^ 0x1C77D722)))
					{
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 != 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto default;
				case 27:
					if (!__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0x38262FC9 ^ 0x38266EAB)))
					{
						num2 = 21;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
						{
							num2 = 8;
						}
						continue;
					}
					goto default;
				case 9:
					if (__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-1133601918 ^ -1133585936)))
					{
						num2 = 6;
						continue;
					}
					goto case 14;
				case 4:
					dispatcher = AzuAnticheatPlugin._Helper[AzuAnticheatPlugin._Indexer];
					num2 = 56;
					continue;
				case 49:
					if (!__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-1931860206 ^ -1931844468)))
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 != 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto default;
				case 20:
					if (__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-1931860206 ^ -1931843874)))
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 != 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 30;
				case 30:
					if (__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0x33F6A245 ^ 0x33F6E399)))
					{
						num = 34;
						break;
					}
					goto case 29;
				case 12:
					if (__instance.m_input != null)
					{
						num = 55;
						break;
					}
					return;
				case 35:
					if (__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-381685266 ^ -381701142)))
					{
						num2 = 46;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
						{
							num2 = 41;
						}
						continue;
					}
					goto case 53;
				case 7:
					return;
				case 25:
					return;
				case 26:
				case 37:
					Property.MsgDsc(DicSingleton.gE3WbyDVW(-1866665889 ^ -1866681311) + __instance.m_input.text, DicSingleton.gE3WbyDVW(-428135557 ^ -428118099));
					num2 = 58;
					continue;
				case 5:
					if (!__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-1123846595 ^ -1123863201)))
					{
						num2 = 32;
						continue;
					}
					goto default;
				case 28:
					if (!__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0x21AFFB2B ^ 0x21AFBA51)))
					{
						num2 = 43;
						continue;
					}
					goto default;
				case 47:
					if (!__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-1830690703 ^ -1830706637)))
					{
						num2 = 45;
						continue;
					}
					goto default;
				case 13:
					if (__instance != null)
					{
						num = 12;
						break;
					}
					return;
				case 60:
					if (!__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0x6DF53C90 ^ 0x6DF578C2)))
					{
						num2 = 12;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c2b9915913b8461884afdca5d98855ec == 0)
						{
							num2 = 42;
						}
						continue;
					}
					goto default;
				case 55:
					if (string.IsNullOrWhiteSpace(__instance.m_input.text))
					{
						num2 = 48;
						continue;
					}
					if (!__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0x2D27936 ^ 0x2D238FA)))
					{
						num = 27;
						break;
					}
					goto default;
				case 50:
					if (__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0x5A1F7167 ^ 0x5A1F33D7)))
					{
						num2 = 27;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 != 0)
						{
							num2 = 41;
						}
						continue;
					}
					goto case 22;
				case 38:
					return;
				case 58:
					AzuAnticheatPlugin._Writer = Localization.instance.Localize(DicSingleton.gE3WbyDVW(-381685266 ^ -381700886));
					num2 = 38;
					continue;
				case 42:
					if (!__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0x2D27936 ^ 0x2D23D56)))
					{
						num2 = 11;
						continue;
					}
					goto default;
				case 11:
					if (__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0x4C23C86A ^ 0x4C238C18)))
					{
						num2 = 15;
						continue;
					}
					goto case 47;
				case 48:
					return;
				case 29:
					if (__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-1817326817 ^ -1817343243)))
					{
						num2 = 36;
						continue;
					}
					goto case 35;
				case 45:
					if (!__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0x2BB207E4 ^ 0x2BB245B6)))
					{
						num2 = 23;
						continue;
					}
					goto default;
				case 18:
					if (!__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-1244021215 ^ -1244004429)))
					{
						num2 = 31;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 == 0)
						{
							num2 = 24;
						}
						continue;
					}
					goto default;
				case 17:
					if (consoleUseBypass.Value)
					{
						num2 = 25;
						continue;
					}
					goto case 26;
				case 59:
					if (!AzuAnticheatPlugin._Helper.ContainsKey(AzuAnticheatPlugin._Indexer))
					{
						num2 = 37;
						continue;
					}
					goto case 4;
				case 10:
					if (!__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-1180565667 ^ -1180582163)))
					{
						num2 = 20;
						continue;
					}
					goto default;
				case 16:
					if (!AzuAnticheatPlugin._Producer)
					{
						num2 = 26;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 != 0)
						{
							num2 = 26;
						}
						continue;
					}
					goto case 59;
				case 19:
					if (!__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-830028630 ^ -830044162)))
					{
						num2 = 5;
						continue;
					}
					goto default;
				case 8:
					if (__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-316028230 ^ -316045280)))
					{
						num2 = 51;
						continue;
					}
					goto case 50;
				case 56:
					consoleUseBypass = dispatcher.ConsoleUseBypass;
					num = 17;
					break;
				case 53:
					if (!__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-1829625923 ^ -1829610079)))
					{
						num2 = 60;
						continue;
					}
					goto default;
				case 23:
					if (!__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0x2BC349D6 ^ 0x2BC30BB0)))
					{
						num2 = 9;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 != 0)
						{
							num2 = 8;
						}
						continue;
					}
					goto default;
				case 14:
					if (!__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-1614185587 ^ -1614202613)))
					{
						num2 = 7;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d != 0)
						{
							num2 = 8;
						}
						continue;
					}
					goto default;
				case 24:
					if (__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-2133864647 ^ -2133881853)))
					{
						num2 = 54;
						continue;
					}
					goto case 19;
				case 31:
					if (!__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-1507873642 ^ -1507857098)))
					{
						num2 = 10;
						continue;
					}
					goto default;
				case 1:
					return;
				default:
					if (AzuAnticheatPlugin.serializer)
					{
						num2 = 7;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 == 0)
						{
							num2 = 7;
						}
						continue;
					}
					goto case 16;
				case 39:
					if (!__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0x1C9EFC64 ^ 0x1C9EBE92)))
					{
						num2 = 57;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef != 0)
						{
							num2 = 50;
						}
						continue;
					}
					goto default;
				case 43:
					if (__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0xB026CF2 ^ 0xB022D74)))
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2aaca7da964541af9780eb37df39c3db == 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 18;
				case 22:
					if (__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0xDA293E6 ^ 0xDA2D124)))
					{
						num2 = 44;
						continue;
					}
					goto case 40;
				case 3:
					if (!__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-1011281439 ^ -1011264925)))
					{
						num2 = 49;
						continue;
					}
					goto default;
				case 21:
					if (!__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-1931860206 ^ -1931843972)))
					{
						num2 = 28;
						continue;
					}
					goto default;
				case 57:
					if (__instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0x567B7B7F ^ 0x567B385F)))
					{
						num2 = 33;
						continue;
					}
					goto case 24;
				}
				break;
			}
		}
	}

	internal static bool VerifyWrapper()
	{
		return RunWrapper == null;
	}

	internal static TestPublisher PopWrapper()
	{
		return RunWrapper;
	}
}
