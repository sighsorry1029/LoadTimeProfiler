using System.Runtime.CompilerServices;
using AzuAntiCheat;
using HarmonyLib;

namespace AzuAnticheat.Internal;

[HarmonyPatch(typeof(MineRock5), "Damage")]
internal class BridgePublisher
{
	private static BridgePublisher GetVisitor;

	[HarmonyPrefix]
	[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
	private static bool Prefix(ref MineRock5 __instance, HitData hit)
	{
		int num = 13;
		bool? damageBypass = default(bool?);
		Dispatcher dispatcher = default(Dispatcher);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 8:
					if (!damageBypass.Value)
					{
						goto end_IL_0012;
					}
					goto case 18;
				case 15:
					Property.MsgDsc(string.Format(DicSingleton.gE3WbyDVW(--650088194 ^ 0x26BFB052), hit.m_damage.GetTotalDamage(), __instance.m_nview.GetPrefabName()), DicSingleton.gE3WbyDVW(-25744665 ^ -25728397));
					num2 = 3;
					break;
				case 6:
					if (!AzuAnticheatPlugin._Producer)
					{
						num2 = 17;
						break;
					}
					goto case 9;
				case 1:
					damageBypass = dispatcher.DamageBypass;
					num2 = 8;
					break;
				case 10:
					if (!damageBypass.HasValue)
					{
						num2 = 7;
						break;
					}
					goto case 6;
				case 13:
					if (!(Player.m_localPlayer == null))
					{
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 == 0)
						{
							num2 = 12;
						}
						break;
					}
					goto case 20;
				case 16:
					if (!(hit.GetAttacker() is Player))
					{
						num2 = 5;
						break;
					}
					goto case 15;
				case 9:
					dispatcher = AzuAnticheatPlugin._Helper[AzuAnticheatPlugin._Indexer];
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 == 0)
					{
						num2 = 0;
					}
					break;
				case 19:
					return true;
				case 4:
					if (AzuAnticheatPlugin._Helper.ContainsKey(AzuAnticheatPlugin._Indexer))
					{
						num2 = 14;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac != 0)
						{
							num2 = 7;
						}
						break;
					}
					goto case 2;
				case 14:
					dispatcher = AzuAnticheatPlugin._Helper[AzuAnticheatPlugin._Indexer];
					num2 = 11;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 != 0)
					{
						num2 = 11;
					}
					break;
				case 11:
					damageBypass = dispatcher.DamageBypass;
					num2 = 10;
					break;
				default:
					return false;
				case 5:
					return true;
				case 20:
					return true;
				case 12:
					if (!AzuAnticheatPlugin.serializer)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 != 0)
						{
							num2 = 4;
						}
						break;
					}
					goto case 19;
				case 18:
					return true;
				case 2:
				case 7:
				case 17:
					if (hit.m_damage.GetTotalDamage() > (float)AzuAnticheatPlugin.broadcaster.Value)
					{
						num2 = 13;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_23f9d18f43004f488662f38dd306f6ec == 0)
						{
							num2 = 16;
						}
						break;
					}
					goto case 5;
				case 3:
					AzuAnticheatPlugin._Writer = Localization.instance.Localize(DicSingleton.gE3WbyDVW(-1244021215 ^ -1244036651));
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 != 0)
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

	public BridgePublisher()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool CalculateVisitor()
	{
		return GetVisitor == null;
	}

	internal static BridgePublisher MoveVisitor()
	{
		return GetVisitor;
	}
}
