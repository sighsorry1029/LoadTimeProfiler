using System.Runtime.CompilerServices;
using AzuAntiCheat;
using HarmonyLib;

namespace AzuAnticheat.Internal;

[HarmonyPatch(typeof(WearNTear), "Damage")]
internal class ClientPublisher
{
	internal static ClientPublisher RateVisitor;

	[HarmonyPrefix]
	[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
	private static bool Prefix(WearNTear __instance, HitData hit)
	{
		int num = 8;
		bool? damageBypass = default(bool?);
		Dispatcher dispatcher = default(Dispatcher);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 10:
					if (AzuAnticheatPlugin._Producer)
					{
						num2 = 15;
						break;
					}
					goto case 4;
				case 14:
					return true;
				case 7:
					if (AzuAnticheatPlugin.serializer)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 != 0)
						{
							num2 = 0;
						}
						break;
					}
					if (AzuAnticheatPlugin._Helper.ContainsKey(AzuAnticheatPlugin._Indexer))
					{
						goto end_IL_0012;
					}
					goto case 4;
				case 13:
					Property.MsgDsc(string.Format(DicSingleton.gE3WbyDVW(-992201216 ^ -992212656), hit.m_damage.GetTotalDamage(), __instance.m_nview.GetPrefabName()), DicSingleton.gE3WbyDVW(-316028230 ^ -316017408));
					num2 = 13;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c == 0)
					{
						num2 = 16;
					}
					break;
				case 17:
					damageBypass = dispatcher.DamageBypass;
					num2 = 2;
					break;
				case 8:
					if (!(Player.m_localPlayer == null))
					{
						num2 = 7;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 == 0)
						{
							num2 = 6;
						}
						break;
					}
					goto case 14;
				default:
					return true;
				case 2:
					if (damageBypass.HasValue)
					{
						num2 = 9;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 != 0)
						{
							num2 = 10;
						}
						break;
					}
					goto case 4;
				case 5:
					if (!(hit.GetAttacker() is Player))
					{
						num2 = 11;
						break;
					}
					goto case 13;
				case 6:
					return true;
				case 4:
					if (hit.m_damage.GetTotalDamage() > (float)AzuAnticheatPlugin.broadcaster.Value)
					{
						num2 = 5;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e != 0)
						{
							num2 = 5;
						}
						break;
					}
					goto case 11;
				case 15:
					dispatcher = AzuAnticheatPlugin._Helper[AzuAnticheatPlugin._Indexer];
					num2 = 9;
					break;
				case 9:
					damageBypass = dispatcher.DamageBypass;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 == 0)
					{
						num2 = 1;
					}
					break;
				case 16:
					AzuAnticheatPlugin._Writer = Localization.instance.Localize(DicSingleton.gE3WbyDVW(-379532028 ^ -379522320));
					num2 = 11;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba == 0)
					{
						num2 = 12;
					}
					break;
				case 12:
					return false;
				case 11:
					return true;
				case 3:
					dispatcher = AzuAnticheatPlugin._Helper[AzuAnticheatPlugin._Indexer];
					num2 = 17;
					break;
				case 1:
					if (!damageBypass.Value)
					{
						num2 = 4;
						break;
					}
					goto case 6;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 3;
		}
	}

	public ClientPublisher()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool ResetVisitor()
	{
		return RateVisitor == null;
	}

	internal static ClientPublisher CustomizeVisitor()
	{
		return RateVisitor;
	}
}
