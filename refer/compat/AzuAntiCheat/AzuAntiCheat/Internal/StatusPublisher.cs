using System.Runtime.CompilerServices;
using AzuAntiCheat;
using HarmonyLib;

namespace AzuAnticheat.Internal;

[HarmonyPatch(typeof(Character), "Damage")]
internal class StatusPublisher
{
	private static StatusPublisher RegisterWrapper;

	[HarmonyPrefix]
	[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
	private static bool Prefix(ref Character __instance, HitData hit)
	{
		int num = 21;
		bool? damageBypass = default(bool?);
		Dispatcher dispatcher = default(Dispatcher);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 7:
					if (damageBypass.HasValue)
					{
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 == 0)
						{
							num2 = 4;
						}
						continue;
					}
					goto case 2;
				case 18:
					dispatcher = AzuAnticheatPlugin._Helper[AzuAnticheatPlugin._Indexer];
					num2 = 6;
					continue;
				case 10:
					return true;
				case 2:
				case 17:
					if (hit.m_damage.GetTotalDamage() > (float)AzuAnticheatPlugin.broadcaster.Value)
					{
						num2 = 19;
						continue;
					}
					goto IL_01a7;
				case 6:
					damageBypass = dispatcher.DamageBypass;
					num2 = 7;
					continue;
				case 1:
					if (!damageBypass.Value)
					{
						num2 = 2;
						continue;
					}
					goto case 10;
				case 12:
					dispatcher = AzuAnticheatPlugin._Helper[AzuAnticheatPlugin._Indexer];
					num = 13;
					break;
				default:
					if (__instance.m_nview.GetZDO().GetLong(DicSingleton.gE3WbyDVW(0xB967DC8 ^ 0xB963CDA), 0L) == Player.m_localPlayer.GetPlayerID())
					{
						num2 = 23;
						continue;
					}
					goto case 5;
				case 3:
					return false;
				case 9:
					AzuAnticheatPlugin._Writer = Localization.instance.Localize(DicSingleton.gE3WbyDVW(-940539791 ^ -940523643));
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add == 0)
					{
						num2 = 3;
					}
					continue;
				case 21:
					if (!(Player.m_localPlayer == null))
					{
						num2 = 20;
						continue;
					}
					goto case 8;
				case 14:
					return true;
				case 22:
					if (AzuAnticheatPlugin._Helper.ContainsKey(AzuAnticheatPlugin._Indexer))
					{
						num2 = 18;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e != 0)
						{
							num2 = 8;
						}
						continue;
					}
					goto case 2;
				case 13:
					damageBypass = dispatcher.DamageBypass;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb != 0)
					{
						num2 = 1;
					}
					continue;
				case 23:
					return true;
				case 5:
				case 11:
					Property.MsgDsc(string.Format(DicSingleton.gE3WbyDVW(0x4C23C86A ^ 0x4C23F73A), hit.m_damage.GetTotalDamage(), __instance.m_nview.GetPrefabName()), DicSingleton.gE3WbyDVW(0x9000142 ^ 0x9004064));
					num = 9;
					break;
				case 15:
					if (!__instance.IsPlayer())
					{
						num2 = 11;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 == 0)
						{
							num2 = 5;
						}
						continue;
					}
					goto case 16;
				case 19:
					if (hit.GetAttacker() is Player)
					{
						num2 = 15;
						continue;
					}
					goto IL_01a7;
				case 4:
					if (!AzuAnticheatPlugin._Producer)
					{
						num2 = 5;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3aab303a2946368dda3deef055dc93 == 0)
						{
							num2 = 17;
						}
						continue;
					}
					goto case 12;
				case 8:
					return true;
				case 20:
					if (!AzuAnticheatPlugin.serializer)
					{
						num2 = 22;
						continue;
					}
					goto case 14;
				case 16:
					{
						if (!__instance.m_nview.IsValid())
						{
							num = 5;
							break;
						}
						goto default;
					}
					IL_01a7:
					return true;
				}
				break;
			}
		}
	}

	public StatusPublisher()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7e7ae6cc25e34646baea4e1c2c087e7a != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool SetupWrapper()
	{
		return RegisterWrapper == null;
	}

	internal static StatusPublisher SelectWrapper()
	{
		return RegisterWrapper;
	}
}
