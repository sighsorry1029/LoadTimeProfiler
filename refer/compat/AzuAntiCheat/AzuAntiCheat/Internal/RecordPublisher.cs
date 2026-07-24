using System.Runtime.CompilerServices;
using AzuAntiCheat;
using HarmonyLib;

namespace AzuAnticheat.Internal;

[HarmonyPatch(typeof(TreeLog), "Damage")]
internal class RecordPublisher
{
	internal static RecordPublisher CancelVisitor;

	[HarmonyPrefix]
	[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
	private static bool Prefix(ref TreeLog __instance, HitData hit)
	{
		int num = 7;
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
					damageBypass = dispatcher.DamageBypass;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 != 0)
					{
						num2 = 0;
					}
					continue;
				case 8:
					AzuAnticheatPlugin._Writer = Localization.instance.Localize(DicSingleton.gE3WbyDVW(-948533799 ^ -948520403));
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 == 0)
					{
						num2 = 1;
					}
					continue;
				case 7:
					if (!(Player.m_localPlayer == null))
					{
						num2 = 6;
						continue;
					}
					goto case 4;
				case 1:
					if (AzuAnticheatPlugin._Producer)
					{
						num2 = 5;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 == 0)
						{
							num2 = 12;
						}
						continue;
					}
					goto case 16;
				case 12:
					dispatcher = AzuAnticheatPlugin._Helper[AzuAnticheatPlugin._Indexer];
					num = 15;
					break;
				case 15:
					damageBypass = dispatcher.DamageBypass;
					num2 = 11;
					continue;
				case 3:
					return true;
				case 16:
					if (hit.m_damage.GetTotalDamage() > (float)AzuAnticheatPlugin.broadcaster.Value)
					{
						num2 = 5;
						continue;
					}
					goto IL_0296;
				default:
					if (damageBypass.HasValue)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 == 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 16;
				case 4:
					return true;
				case 6:
					if (AzuAnticheatPlugin.serializer)
					{
						num2 = 13;
						continue;
					}
					if (!AzuAnticheatPlugin._Helper.ContainsKey(AzuAnticheatPlugin._Indexer))
					{
						num2 = 16;
						continue;
					}
					goto case 14;
				case 13:
					return true;
				case 11:
					if (damageBypass.Value)
					{
						num = 3;
						break;
					}
					goto case 16;
				case 5:
					if (hit.GetAttacker() is Player)
					{
						num2 = 9;
						continue;
					}
					goto IL_0296;
				case 14:
					dispatcher = AzuAnticheatPlugin._Helper[AzuAnticheatPlugin._Indexer];
					num2 = 10;
					continue;
				case 9:
					Property.MsgDsc(string.Format(DicSingleton.gE3WbyDVW(-1389846755 ^ -1389846451), hit.m_damage.GetTotalDamage(), __instance.m_nview.GetPrefabName()), DicSingleton.gE3WbyDVW(-1385030784 ^ -1385014366));
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
					{
						num2 = 1;
					}
					continue;
				case 2:
					{
						return false;
					}
					IL_0296:
					return true;
				}
				break;
			}
		}
	}

	public RecordPublisher()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool ReflectVisitor()
	{
		return CancelVisitor == null;
	}

	internal static RecordPublisher CollectVisitor()
	{
		return CancelVisitor;
	}
}
