using System.Runtime.CompilerServices;
using AzuAntiCheat;
using HarmonyLib;

namespace AzuAnticheat.Internal;

[HarmonyPatch(typeof(Destructible), "Damage")]
internal class ParameterPublisher
{
	private static ParameterPublisher RevertVisitor;

	[HarmonyPrefix]
	[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
	private static bool Prefix(ref Destructible __instance, HitData hit)
	{
		int num = 16;
		bool? damageBypass = default(bool?);
		Dispatcher dispatcher = default(Dispatcher);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 16:
					if (!(Player.m_localPlayer == null))
					{
						num2 = 15;
						continue;
					}
					goto case 14;
				case 1:
					if (!(hit.GetAttacker() is Player))
					{
						num2 = 9;
						continue;
					}
					goto case 7;
				case 3:
					damageBypass = dispatcher.DamageBypass;
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 == 0)
					{
						num2 = 2;
					}
					continue;
				default:
					damageBypass = dispatcher.DamageBypass;
					num2 = 11;
					continue;
				case 12:
					dispatcher = AzuAnticheatPlugin._Helper[AzuAnticheatPlugin._Indexer];
					num2 = 3;
					continue;
				case 5:
					return false;
				case 9:
					return true;
				case 14:
					return true;
				case 15:
					if (AzuAnticheatPlugin.serializer)
					{
						num2 = 4;
						continue;
					}
					if (!AzuAnticheatPlugin._Helper.ContainsKey(AzuAnticheatPlugin._Indexer))
					{
						num2 = 6;
						continue;
					}
					goto case 12;
				case 17:
					AzuAnticheatPlugin._Writer = Localization.instance.Localize(DicSingleton.gE3WbyDVW(0x7FAAD78F ^ 0x7FAAE87B));
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 == 0)
					{
						num2 = 5;
					}
					continue;
				case 7:
					Property.MsgDsc(string.Format(DicSingleton.gE3WbyDVW(0x4995986C ^ 0x4995A73C), hit.m_damage.GetTotalDamage(), __instance.m_nview.GetPrefabName()), DicSingleton.gE3WbyDVW(-1123846595 ^ -1123862803));
					num2 = 17;
					continue;
				case 2:
					if (damageBypass.HasValue)
					{
						num2 = 10;
						continue;
					}
					goto case 6;
				case 8:
					dispatcher = AzuAnticheatPlugin._Helper[AzuAnticheatPlugin._Indexer];
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 == 0)
					{
						num2 = 0;
					}
					continue;
				case 10:
					if (!AzuAnticheatPlugin._Producer)
					{
						num2 = 13;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 != 0)
						{
							num2 = 9;
						}
						continue;
					}
					goto case 8;
				case 11:
					if (!damageBypass.Value)
					{
						break;
					}
					goto case 18;
				case 18:
					return true;
				case 6:
				case 13:
				case 19:
					if (hit.m_damage.GetTotalDamage() > (float)AzuAnticheatPlugin.broadcaster.Value)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 == 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 9;
				case 4:
					return true;
				}
				break;
			}
			num = 19;
		}
	}

	public ParameterPublisher()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool InvokeWrapper()
	{
		return RevertVisitor == null;
	}

	internal static ParameterPublisher PublishWrapper()
	{
		return RevertVisitor;
	}
}
