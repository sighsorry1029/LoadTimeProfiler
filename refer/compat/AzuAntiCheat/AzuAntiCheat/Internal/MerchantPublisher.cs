using AzuAntiCheat;
using HarmonyLib;

namespace AzuAnticheat.Internal;

[HarmonyPatch(typeof(Chat), "InputText")]
internal static class MerchantPublisher
{
	internal static MerchantPublisher ChangeWrapper;

	[HarmonyPostfix]
	private static void Postfix()
	{
		int num = 33;
		bool? consoleUseBypass = default(bool?);
		Dispatcher dispatcher = default(Dispatcher);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 9:
					return;
				case 42:
					if (!Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-34102588 ^ -34086696)))
					{
						num2 = 44;
						continue;
					}
					goto case 1;
				case 16:
					consoleUseBypass = dispatcher.ConsoleUseBypass;
					num2 = 6;
					continue;
				case 7:
					if (!Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(--1844849127 ^ 0x6DF66847)))
					{
						num2 = 45;
						continue;
					}
					goto case 1;
				case 12:
					if (!(Chat.instance.m_input != null))
					{
						num2 = 30;
						continue;
					}
					goto case 26;
				case 20:
					if (!Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0x1C779450 ^ 0x1C77D53E)))
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 1;
				case 3:
					if (!Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0x4995986C ^ 0x4995DBEE)))
					{
						num2 = 5;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 == 0)
						{
							num2 = 3;
						}
						continue;
					}
					goto case 1;
				case 43:
					if (AzuAnticheatPlugin._Helper.ContainsKey(AzuAnticheatPlugin._Indexer))
					{
						num = 40;
						break;
					}
					goto IL_0a72;
				case 25:
					if (!Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-1053593978 ^ -1053610954)))
					{
						num2 = 22;
						continue;
					}
					goto case 1;
				case 52:
					if (!Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-992201216 ^ -992185132)))
					{
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef == 0)
						{
							num2 = 49;
						}
						continue;
					}
					goto case 1;
				case 24:
					if (!Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0x4F8CB66E ^ 0x4F8CF42C)))
					{
						num2 = 15;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab == 0)
						{
							num2 = 28;
						}
						continue;
					}
					goto case 1;
				case 47:
					if (!Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-1544119467 ^ -1544103225)))
					{
						num2 = 7;
						continue;
					}
					goto case 1;
				case 22:
					if (Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-447849421 ^ -447865103)))
					{
						num2 = 13;
						continue;
					}
					goto case 52;
				case 11:
					if (Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-1461449777 ^ -1461433909)))
					{
						num = 48;
						break;
					}
					goto case 42;
				case 17:
					if (Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0xFB046CE ^ 0xFB00448)))
					{
						num2 = 8;
						continue;
					}
					goto case 19;
				case 58:
					if (Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0xB967DC8 ^ 0xB963C4E)))
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef == 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 47;
				case 57:
					return;
				case 1:
				case 8:
				case 13:
				case 21:
				case 31:
				case 34:
				case 39:
				case 41:
				case 46:
				case 48:
				case 51:
				case 53:
				case 54:
				case 55:
					if (AzuAnticheatPlugin.serializer)
					{
						num2 = 5;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 != 0)
						{
							num2 = 9;
						}
						continue;
					}
					goto case 18;
				case 27:
					if (Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-380885952 ^ -380868830)))
					{
						num2 = 34;
						continue;
					}
					goto case 29;
				case 6:
					if (consoleUseBypass.Value)
					{
						num2 = 38;
						continue;
					}
					goto IL_0a72;
				case 14:
					if (Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-1908521178 ^ -1908538028)))
					{
						num2 = 31;
						continue;
					}
					goto case 17;
				case 30:
					return;
				case 4:
					AzuAnticheatPlugin._Writer = Localization.instance.Localize(DicSingleton.gE3WbyDVW(-108820061 ^ -108802677));
					num2 = 35;
					continue;
				case 5:
					if (!Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0x6729A6D ^ 0x672D9F3)))
					{
						num2 = 57;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a == 0)
						{
							num2 = 37;
						}
						continue;
					}
					goto case 1;
				case 10:
					if (Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0x3FCF6129 ^ 0x3FCF227D)))
					{
						num2 = 39;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f != 0)
						{
							num2 = 41;
						}
						continue;
					}
					goto case 27;
				case 2:
					if (!Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0xB967DC8 ^ 0xB963C14)))
					{
						num2 = 37;
						continue;
					}
					goto case 1;
				default:
					if (Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-1735703950 ^ -1735720184)))
					{
						num2 = 39;
						continue;
					}
					goto case 58;
				case 49:
					if (Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0x6DF53C90 ^ 0x6DF57E66)))
					{
						num = 21;
						break;
					}
					goto case 23;
				case 44:
					if (!Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0x4C73F208 ^ 0x4C73B026)))
					{
						num2 = 19;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 == 0)
						{
							num2 = 24;
						}
						continue;
					}
					goto case 1;
				case 15:
					if (!Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-1829625923 ^ -1829610361)))
					{
						num2 = 10;
						continue;
					}
					goto case 1;
				case 45:
					if (Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0x55F5513C ^ 0x55F5108C)))
					{
						num = 53;
						break;
					}
					goto case 56;
				case 35:
					return;
				case 26:
					if (string.IsNullOrWhiteSpace(Chat.instance.m_input.text))
					{
						num2 = 36;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 == 0)
						{
							num2 = 6;
						}
						continue;
					}
					if (!Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-1011281439 ^ -1011265405)))
					{
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 == 0)
						{
							num2 = 20;
						}
						continue;
					}
					goto case 1;
				case 37:
					if (Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-1863475926 ^ -1863459648)))
					{
						num2 = 46;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 == 0)
						{
							num2 = 26;
						}
						continue;
					}
					goto case 11;
				case 56:
					if (!Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-1385030784 ^ -1385014708)))
					{
						num2 = 2;
						continue;
					}
					goto case 1;
				case 32:
					return;
				case 36:
					return;
				case 18:
					if (AzuAnticheatPlugin._Producer)
					{
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e == 0)
						{
							num2 = 43;
						}
						continue;
					}
					goto IL_0a72;
				case 19:
					if (Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0x1606DF07 ^ 0x16069D9D)))
					{
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 == 0)
						{
							num2 = 51;
						}
						continue;
					}
					goto case 25;
				case 23:
					if (!Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-992201216 ^ -992185056)))
					{
						num2 = 15;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d == 0)
						{
							num2 = 10;
						}
						continue;
					}
					goto case 1;
				case 28:
					if (Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0x7742C60 ^ 0x7746E32)))
					{
						num2 = 54;
						continue;
					}
					goto case 50;
				case 40:
					dispatcher = AzuAnticheatPlugin._Helper[AzuAnticheatPlugin._Indexer];
					num2 = 16;
					continue;
				case 33:
					if (!(Chat.instance != null))
					{
						num = 32;
						break;
					}
					goto case 12;
				case 38:
					return;
				case 29:
					if (!Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(0x38262FC9 ^ 0x38266CBB)))
					{
						num = 3;
						break;
					}
					goto case 1;
				case 50:
					{
						if (Chat.instance.m_input.text.StartsWith(DicSingleton.gE3WbyDVW(-359091888 ^ -359075018)))
						{
							num2 = 55;
							continue;
						}
						goto case 14;
					}
					IL_0a72:
					Property.MsgDsc(DicSingleton.gE3WbyDVW(-1735703950 ^ -1735720510) + Chat.instance.m_input.text, DicSingleton.gE3WbyDVW(-1549341817 ^ -1549357177));
					num = 4;
					break;
				}
				break;
			}
		}
	}

	internal static bool CreateWrapper()
	{
		return ChangeWrapper == null;
	}

	internal static MerchantPublisher TestWrapper()
	{
		return ChangeWrapper;
	}
}
