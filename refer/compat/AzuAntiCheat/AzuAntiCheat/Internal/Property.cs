using System;
using System.Linq;
using System.Runtime.CompilerServices;
using AzuAntiCheat;
using BepInEx;
using BepInEx.Bootstrap;
using HarmonyLib;
using UnityEngine;

namespace AzuAnticheat.Internal;

[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
[HarmonyPatch]
internal class Property
{
	private static Property RateExpression;

	internal static void PostToDiscord(string playerPersona, string playerName, string peerSteamID, string message, string title, bool isBad = false, string playerLocation = "Unknown")
	{
		if (!ZNet.instance.IsServerInstance())
		{
			return;
		}
		if (AzuAnticheatPlugin._Definition == null || !AzuAnticheatPlugin._Definition.Any() || AzuAnticheatPlugin._Definition.Count <= 0)
		{
			AzuAnticheatPlugin.AcLogger.LogError(Localization.instance.Localize(DicSingleton.gE3WbyDVW(-1741204886 ^ -1741197292)));
			AzuAnticheatPlugin.AcLogger.LogError(Localization.instance.Localize(DicSingleton.gE3WbyDVW(-954365995 ^ -954358431) + playerName + DicSingleton.gE3WbyDVW(-1549341817 ^ -1549350551) + peerSteamID + DicSingleton.gE3WbyDVW(0x4C73F208 ^ 0x4C73D104) + playerPersona + DicSingleton.gE3WbyDVW(-1398029315 ^ -1398021933) + message));
			if (isBad)
			{
				CheckBan(peerSteamID, playerName, playerPersona);
			}
			if (AzuAnticheatPlugin.bridge.Value)
			{
				SendToMeIfTheyAllow(playerPersona, playerName, peerSteamID, message, title, isBad, playerLocation);
			}
			return;
		}
		int color = (isBad ? 15406156 : 53380);
		if (isBad)
		{
			CheckBan(peerSteamID, playerName, playerPersona);
		}
		foreach (string item in AzuAnticheatPlugin._Definition.Select([_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(0)] (Params link) => link.Hook.Trim()))
		{
			new SerializerPublisher().SetUsername(DicSingleton.gE3WbyDVW(0x3FCF6129 ^ 0x3FCF4275)).SetAvatar(DicSingleton.gE3WbyDVW(-428683152 ^ -428674056)).AddEmbed()
				.SetTimestamp(DateTime.UtcNow)
				.SetColor(color)
				.SetTitle(Localization.instance.Localize(title))
				.SetDescription(DicSingleton.gE3WbyDVW(0x74FC52AF ^ 0x74FC7165) + Environment.NewLine + Environment.NewLine)
				.AddField(Localization.instance.Localize(DicSingleton.gE3WbyDVW(-1123846595 ^ -1123855801)), DicSingleton.gE3WbyDVW(0x47C77AB8 ^ 0x47C75E2C) + playerPersona + DicSingleton.gE3WbyDVW(0x554A128B ^ 0x554A3615) + peerSteamID + DicSingleton.gE3WbyDVW(0x5901407C ^ 0x59016492), inline: true)
				.AddField(Localization.instance.Localize(DicSingleton.gE3WbyDVW(-1611872559 ^ -1611865563)), DicSingleton.gE3WbyDVW(0x602C149E ^ 0x602C3194) + peerSteamID, inline: true)
				.AddField(Localization.instance.Localize(DicSingleton.gE3WbyDVW(0xC23E82C ^ 0xC23CD3E)), DicSingleton.gE3WbyDVW(-1338893851 ^ -1338884881) + playerName, inline: true)
				.AddField(Localization.instance.Localize(DicSingleton.gE3WbyDVW(-1549341817 ^ -1549349207)), DicSingleton.gE3WbyDVW(-1133601918 ^ -1133592952) + ZNet.m_ServerName)
				.AddField(Localization.instance.Localize(DicSingleton.gE3WbyDVW(-1549341817 ^ -1549349171)), DicSingleton.gE3WbyDVW(0x74FC52AF ^ 0x74FC77A5) + ZNet.m_world.m_name, inline: true)
				.AddField(Localization.instance.Localize(DicSingleton.gE3WbyDVW(-598551743 ^ -598542807)), DicSingleton.gE3WbyDVW(0x4995986C ^ 0x4995BD66) + playerLocation, inline: true)
				.AddField(Localization.instance.Localize(DicSingleton.gE3WbyDVW(-1011281439 ^ -1011272595)), Localization.instance.Localize(DicSingleton.gE3WbyDVW(-1273961441 ^ -1273970257) + message))
				.Build()
				.SendMessageAsync(item);
		}
		if (AzuAnticheatPlugin.bridge.Value)
		{
			SendToMeIfTheyAllow(playerPersona, playerName, peerSteamID, message, title, isBad, playerLocation, webNotDefined: false);
		}
	}

	internal static void SendToMeIfTheyAllow(string playerPersona, string playerName, string peerSteamID, string message, string title, bool isBad, string playerLocation, bool webNotDefined = true)
	{
		int num = 3;
		int num2 = num;
		string text = default(string);
		int color = default(int);
		string text2 = default(string);
		while (true)
		{
			object obj;
			int num3;
			switch (num2)
			{
			default:
				return;
			case 11:
				obj = "";
				break;
			case 14:
				text = DicSingleton.gE3WbyDVW(0x408F2744 ^ 0x408F02B4) + Environment.NewLine;
				num2 = 10;
				continue;
			case 18:
				PlayerPrefs.SetString(DicSingleton.gE3WbyDVW(-614239580 ^ -614246632), AzuAnticheatPlugin._Status.Value);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 == 0)
				{
					num2 = 0;
				}
				continue;
			case 6:
				num3 = 53380;
				goto IL_04ed;
			case 16:
				if (isBad)
				{
					num2 = 9;
					continue;
				}
				goto case 11;
			case 7:
				_ = AzuAnticheatPlugin._Task.Value;
				num2 = 12;
				continue;
			case 17:
				if (!isBad)
				{
					num2 = 13;
					continue;
				}
				goto case 7;
			case 12:
			case 13:
				text = "";
				num2 = 15;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 == 0)
				{
					num2 = 19;
				}
				continue;
			case 2:
				PlayerPrefs.SetString(DicSingleton.gE3WbyDVW(-1507873642 ^ -1507882710), DicSingleton.gE3WbyDVW(0x7A125A0E ^ 0x7A125868));
				num2 = 8;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e == 0)
				{
					num2 = 4;
				}
				continue;
			case 8:
				if (isBad)
				{
					num2 = 15;
					continue;
				}
				goto case 6;
			case 1:
			case 10:
				new SerializerPublisher().SetUsername(DicSingleton.gE3WbyDVW(-2133864647 ^ -2133857179)).SetAvatar(DicSingleton.gE3WbyDVW(-428135557 ^ -428144397)).AddEmbed()
					.SetTimestamp(DateTime.UtcNow)
					.SetColor(color)
					.SetTitle(Localization.instance.Localize(DicSingleton.gE3WbyDVW(-379532028 ^ -379524322) + Environment.NewLine + text + title))
					.SetDescription(DicSingleton.gE3WbyDVW(0x1A7A0414 ^ 0x1A7A27DE) + Environment.NewLine + Environment.NewLine + text2)
					.AddField(DicSingleton.gE3WbyDVW(0x44072FB7 ^ 0x44070985), DicSingleton.gE3WbyDVW(-598551743 ^ -598542379) + playerPersona + DicSingleton.gE3WbyDVW(-379532028 ^ -379524710) + peerSteamID + DicSingleton.gE3WbyDVW(0xB967DC8 ^ 0xB965926), inline: true)
					.AddField(DicSingleton.gE3WbyDVW(-830028630 ^ -830020896), DicSingleton.gE3WbyDVW(--1182565251 ^ 0x467CA689) + peerSteamID, inline: true)
					.AddField(DicSingleton.gE3WbyDVW(0x2BC53863 ^ 0x2BC51E3D), DicSingleton.gE3WbyDVW(-1611872559 ^ -1611865125) + playerName, inline: true)
					.AddField(DicSingleton.gE3WbyDVW(0x3353457 ^ 0x335122F), DicSingleton.gE3WbyDVW(0xDA293E6 ^ 0xDA2B6EC) + ZNet.m_ServerName)
					.AddField(DicSingleton.gE3WbyDVW(-1398029315 ^ -1398020753), DicSingleton.gE3WbyDVW(-1866665889 ^ -1866672811) + ZNet.m_world.m_name, inline: true)
					.AddField(DicSingleton.gE3WbyDVW(0x4C23C86A ^ 0x4C23EEC4), DicSingleton.gE3WbyDVW(-475093377 ^ -475102347) + playerLocation, inline: true)
					.AddField(DicSingleton.gE3WbyDVW(-525002617 ^ -524992937), Localization.instance.Localize(DicSingleton.gE3WbyDVW(-1977574774 ^ -1977565382) + message))
					.Build()
					.SendMessageAsync(AzuAnticheatPlugin.m_Predicate.Trim());
				num2 = 5;
				continue;
			case 5:
				Localization.instance.SetupLanguage(AzuAnticheatPlugin._Status.Value);
				num2 = 16;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc != 0)
				{
					num2 = 18;
				}
				continue;
			case 0:
				return;
			case 3:
				Localization.instance.SetupLanguage(DicSingleton.gE3WbyDVW(-475093377 ^ -475093991));
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb == 0)
				{
					num2 = 2;
				}
				continue;
			case 9:
				if (AzuAnticheatPlugin._Task.Value)
				{
					num2 = 4;
					continue;
				}
				goto case 11;
			case 19:
				if (!webNotDefined)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 != 0)
					{
						num2 = 1;
					}
					continue;
				}
				goto case 14;
			case 15:
				num3 = 15406156;
				goto IL_04ed;
			case 4:
				{
					obj = DicSingleton.gE3WbyDVW(0x38262FC9 ^ 0x38260A19);
					break;
				}
				IL_04ed:
				color = num3;
				num2 = 16;
				continue;
			}
			text2 = (string)obj;
			num2 = 17;
		}
	}

	internal static void MsgDsc(string s, string title, bool isBad = true)
	{
		int num = 19;
		ZPackage zPackage = default(ZPackage);
		ZPackage zPackage2 = default(ZPackage);
		Player localPlayer = default(Player);
		Vector3 position = default(Vector3);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 2:
					zPackage = new ZPackage();
					num2 = 20;
					continue;
				case 11:
					ZRoutedRpc.instance.InvokeRoutedRPC(ZRoutedRpc.instance.GetServerPeerID(), DicSingleton.gE3WbyDVW(-379532028 ^ -379523266), zPackage);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f != 0)
					{
						num2 = 0;
					}
					continue;
				case 9:
					zPackage2.Write(isBad);
					num2 = 4;
					continue;
				case 6:
					zPackage.Write(AzuAnticheatPlugin._Indexer);
					num2 = 8;
					continue;
				case 18:
					if (localPlayer != null)
					{
						num2 = 2;
						continue;
					}
					zPackage2 = new ZPackage();
					num2 = 15;
					continue;
				case 15:
					zPackage2.Write(AzuAnticheatPlugin.mock);
					num2 = 12;
					continue;
				case 5:
					zPackage2.Write(title);
					num2 = 12;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 == 0)
					{
						num2 = 14;
					}
					continue;
				case 21:
					zPackage.Write(isBad);
					num2 = 11;
					continue;
				case 16:
					zPackage.Write(AzuAnticheatPlugin._Template);
					num = 6;
					break;
				case 17:
					zPackage2.Write(AzuAnticheatPlugin._Indexer);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 != 0)
					{
						num2 = 0;
					}
					continue;
				case 3:
					zPackage.Write(AzuAnticheatPlugin.mock);
					num = 16;
					break;
				case 13:
					return;
				case 20:
					position = localPlayer.transform.position;
					num2 = 3;
					continue;
				case 10:
					zPackage.Write(position.ToString());
					num = 21;
					break;
				case 8:
					zPackage.Write(s);
					num = 7;
					break;
				default:
					zPackage2.Write(s);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_91887e48b8104e7da08b48f73b607337 != 0)
					{
						num2 = 5;
					}
					continue;
				case 12:
					zPackage2.Write(AzuAnticheatPlugin._Template);
					num = 17;
					break;
				case 1:
					return;
				case 14:
					zPackage2.Write(DicSingleton.gE3WbyDVW(-1741204886 ^ -1741195926));
					num = 9;
					break;
				case 4:
					ZRoutedRpc.instance.InvokeRoutedRPC(ZRoutedRpc.instance.GetServerPeerID(), DicSingleton.gE3WbyDVW(0x6BAF1854 ^ 0x6BAF3A6E), zPackage2);
					num2 = 13;
					continue;
				case 19:
					localPlayer = Player.m_localPlayer;
					num2 = 18;
					continue;
				case 7:
					zPackage.Write(title);
					num2 = 10;
					continue;
				}
				break;
			}
		}
	}

	private static void CheckBan(string hostName, string playerName, string persona)
	{
		int num = 9;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 3:
				return;
			default:
				AzuAnticheatPlugin.AcLogger.LogError(DicSingleton.gE3WbyDVW(-992201216 ^ -992210576) + playerName + DicSingleton.gE3WbyDVW(0x55F5513C ^ 0x55F5769C) + hostName + DicSingleton.gE3WbyDVW(-166253478 ^ -166261834));
				num2 = 4;
				break;
			case 9:
				if (AzuAnticheatPlugin._Task.Value)
				{
					num2 = 8;
					break;
				}
				return;
			case 5:
				if (!(hostName != ""))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 1;
			case 2:
				AzuAnticheatPlugin.AcLogger.LogInfo(DicSingleton.gE3WbyDVW(0x59C84793 ^ 0x59C860B3) + playerName + DicSingleton.gE3WbyDVW(-1461449777 ^ -1461441379) + persona + DicSingleton.gE3WbyDVW(-380885952 ^ -380894424) + hostName + DicSingleton.gE3WbyDVW(-1075938037 ^ -1075947035));
				num2 = 3;
				break;
			case 4:
				return;
			case 6:
				if (hostName != DicSingleton.gE3WbyDVW(-316028230 ^ -316019294))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 == 0)
					{
						num2 = 5;
					}
					break;
				}
				goto default;
			case 1:
				ZNet.instance.Ban(hostName);
				num2 = 2;
				break;
			case 7:
				return;
			case 8:
				if (hostName != DicSingleton.gE3WbyDVW(-1338893851 ^ -1338884361))
				{
					num2 = 6;
					break;
				}
				goto default;
			}
		}
	}

	internal static void SetUpErrorMessage(ZRpc rpc, ZPackage pkg)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 7:
				if (pkg.Size() <= 0)
				{
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 == 0)
					{
						num2 = 1;
					}
					break;
				}
				AzuAnticheatPlugin._Writer = pkg.ReadString();
				num2 = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb != 0)
				{
					num2 = 6;
				}
				break;
			case 2:
				if (ZNet.instance.IsServerInstance())
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f == 0)
					{
						num2 = 1;
					}
					break;
				}
				if (rpc == null)
				{
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf == 0)
					{
						num2 = 4;
					}
					break;
				}
				goto case 5;
			case 0:
				return;
			case 4:
				return;
			case 5:
				if (pkg == null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 7;
			case 1:
				return;
			case 3:
				return;
			case 6:
				return;
			}
		}
	}

	internal static void AzuCheaterRPC_SendMessage(long sender, ZPackage pkg)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 1:
			{
				ZNetPeer peer = ZNet.instance.GetPeer(sender);
				string playerPersona = pkg.ReadString();
				string playerName = pkg.ReadString();
				string peerSteamID = pkg.ReadString();
				string message = pkg.ReadString();
				string title = pkg.ReadString();
				string playerLocation = pkg.ReadString();
				bool isBad = pkg.ReadBool();
				PostToDiscord(playerPersona, playerName, peerSteamID, message, title, isBad, playerLocation);
				peer.m_rpc.Invoke(DicSingleton.gE3WbyDVW(0xFB046CE ^ 0xFB06EE6), 456789123);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 != 0)
				{
					num2 = 0;
				}
				break;
			}
			case 0:
				return;
			}
		}
	}

	internal static bool CanGhost(Player player)
	{
		int num = 1;
		int num2 = num;
		PluginInfo value = default(PluginInfo);
		while (true)
		{
			switch (num2)
			{
			case 3:
				if (player.m_customData.ContainsKey(DicSingleton.gE3WbyDVW(0x6729A6D ^ 0x672B21B)))
				{
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 == 0)
					{
						num2 = 1;
					}
					continue;
				}
				break;
			case 1:
				Chainloader.PluginInfos.TryGetValue(DicSingleton.gE3WbyDVW(-2103041941 ^ -2103048099), out value);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 != 0)
				{
					num2 = 0;
				}
				continue;
			default:
				if (player.IsDead())
				{
					num2 = 4;
					continue;
				}
				goto case 3;
			case 2:
				return value != null;
			case 4:
				break;
			}
			break;
		}
		return false;
	}

	public Property()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool ResetExpression()
	{
		return RateExpression == null;
	}

	internal static Property CustomizeExpression()
	{
		return RateExpression;
	}
}
