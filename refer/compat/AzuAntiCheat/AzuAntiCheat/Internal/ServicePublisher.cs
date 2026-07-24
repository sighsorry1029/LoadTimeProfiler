using System.Runtime.CompilerServices;
using AzuAntiCheat;
using HarmonyLib;

namespace AzuAnticheat.Internal;

[HarmonyPatch(typeof(TreeBase), "Damage")]
internal class ServicePublisher
{
	internal static ServicePublisher ManageVisitor;

	[HarmonyPrefix]
	[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
	private static bool Prefix(ref TreeBase __instance, HitData hit)
	{
		int num = 14;
		bool? damageBypass = default(bool?);
		Dispatcher dispatcher = default(Dispatcher);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 1:
					if (!AzuAnticheatPlugin._Producer)
					{
						num = 15;
						break;
					}
					goto case 8;
				case 14:
					if (!(Player.m_localPlayer == null))
					{
						num2 = 13;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 11;
				case 4:
					if (damageBypass.Value)
					{
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 7;
				case 8:
					dispatcher = AzuAnticheatPlugin._Helper[AzuAnticheatPlugin._Indexer];
					num2 = 16;
					continue;
				case 19:
					damageBypass = dispatcher.DamageBypass;
					num = 12;
					break;
				case 12:
					if (!damageBypass.HasValue)
					{
						num2 = 18;
						continue;
					}
					goto case 1;
				case 10:
					Property.MsgDsc(string.Format(DicSingleton.gE3WbyDVW(-940539791 ^ -940523743), hit.m_damage.GetTotalDamage(), __instance.m_nview.GetPrefabName()), DicSingleton.gE3WbyDVW(-228218718 ^ -228202248));
					num2 = 9;
					continue;
				case 2:
					dispatcher = AzuAnticheatPlugin._Helper[AzuAnticheatPlugin._Indexer];
					num2 = 19;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be == 0)
					{
						num2 = 11;
					}
					continue;
				case 17:
					return false;
				case 5:
					return true;
				case 6:
					if (!(hit.GetAttacker() is Player))
					{
						num2 = 5;
						continue;
					}
					goto case 10;
				case 20:
					return true;
				default:
					if (!AzuAnticheatPlugin._Helper.ContainsKey(AzuAnticheatPlugin._Indexer))
					{
						num2 = 6;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb != 0)
						{
							num2 = 7;
						}
						continue;
					}
					goto case 2;
				case 3:
					return true;
				case 7:
				case 15:
				case 18:
					if (hit.m_damage.GetTotalDamage() > (float)AzuAnticheatPlugin.broadcaster.Value)
					{
						num2 = 6;
						continue;
					}
					goto case 5;
				case 9:
					AzuAnticheatPlugin._Writer = Localization.instance.Localize(DicSingleton.gE3WbyDVW(-823738529 ^ -823754581));
					num2 = 17;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba != 0)
					{
						num2 = 11;
					}
					continue;
				case 11:
					return true;
				case 13:
					if (!AzuAnticheatPlugin.serializer)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 20;
				case 16:
					damageBypass = dispatcher.DamageBypass;
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 != 0)
					{
						num2 = 4;
					}
					continue;
				}
				break;
			}
		}
	}

	public ServicePublisher()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool ForgotVisitor()
	{
		return ManageVisitor == null;
	}

	internal static ServicePublisher RestartVisitor()
	{
		return ManageVisitor;
	}
}
