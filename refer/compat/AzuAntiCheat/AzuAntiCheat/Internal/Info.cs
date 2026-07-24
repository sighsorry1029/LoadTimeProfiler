using System;
using System.Runtime.CompilerServices;
using AzuAntiCheat;
using HarmonyLib;

namespace AzuAnticheat.Internal;

[HarmonyPatch]
[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
internal class Info
{
	[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(0)]
	[HarmonyPatch(typeof(ZoneSystem), "Start")]
	private static class Dic
	{
		private static Dic FlushExpression;

		[HarmonyPrefix]
		[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
		private static void Prefix(ZoneSystem __instance)
		{
			int num = 2;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 2:
					if (ZNet.m_isServer)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c == 0)
						{
							num2 = 1;
						}
						break;
					}
					return;
				case 0:
					return;
				case 3:
					return;
				case 1:
					ZRoutedRpc.instance.Register<ZPackage>(DicSingleton.gE3WbyDVW(-1829625923 ^ -1829618297), Property.AzuCheaterRPC_SendMessage);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		internal static bool DestroyExpression()
		{
			return FlushExpression == null;
		}

		internal static Dic ComputeExpression()
		{
			return FlushExpression;
		}
	}

	internal static Info InterruptExpression;

	public static void RPC_ClientAdminStatus(ZRpc rpc, ZPackage z)
	{
		int num = 11;
		ZPackage zPackage = default(ZPackage);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 4:
					if (z.Size() > 0)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f011663d64054593978962dcc3a5ec1a != 0)
						{
							num2 = 2;
						}
						continue;
					}
					return;
				case 7:
					zPackage = new ZPackage();
					num2 = 3;
					continue;
				default:
					zPackage.Write(AzuAnticheatPlugin._Indexer);
					num2 = 14;
					continue;
				case 6:
					break;
				case 1:
					AzuAnticheatPlugin.AcLogger.LogInfo(string.Format(DicSingleton.gE3WbyDVW(-823738529 ^ -823746781), AzuAnticheatPlugin._Producer));
					num2 = 6;
					continue;
				case 10:
					return;
				case 12:
					return;
				case 2:
					AzuAnticheatPlugin.serializer = z.ReadBool();
					AzuAnticheatPlugin.AcLogger.LogInfo(string.Format(DicSingleton.gE3WbyDVW(0x270E0638 ^ 0x270E265C), AzuAnticheatPlugin.serializer));
					AzuAnticheatPlugin._Producer = z.ReadBool();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 == 0)
					{
						num2 = 1;
					}
					continue;
				case 9:
					return;
				case 3:
					zPackage.Write(Class.ToYAML(AzuAnticheatPlugin.m_Map));
					num2 = 13;
					continue;
				case 14:
					zPackage.Write(AzuAnticheatPlugin._Template);
					num2 = 8;
					continue;
				case 13:
					zPackage.Write(AzuAnticheatPlugin.mock);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_575e6bd686b54d028cdc3fc324b58a39 == 0)
					{
						num2 = 0;
					}
					continue;
				case 5:
					if (z == null)
					{
						return;
					}
					num2 = 4;
					continue;
				case 8:
					rpc.Invoke(DicSingleton.gE3WbyDVW(-428683152 ^ -428674872), zPackage);
					num2 = 9;
					continue;
				case 11:
					if (rpc == null)
					{
						num2 = 10;
						continue;
					}
					goto case 5;
				}
				break;
			}
			AzuAnticheatPlugin.AcLogger.LogDebug(DicSingleton.gE3WbyDVW(-1977574774 ^ -1977566698));
			num = 7;
		}
	}

	internal static void RPC_EventLoadedMods(ZRpc sender, ZPackage pkg)
	{
		int num = 6;
		int num2 = num;
		string composer = default(string);
		bool flag = default(bool);
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 2:
				AzuAnticheatPlugin._Composer = composer;
				num2 = 4;
				break;
			case 1:
				if (!flag)
				{
					num2 = 9;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_35cf05af90cc4195a86c9ffc19bf78eb == 0)
					{
						num2 = 4;
					}
				}
				else
				{
					AzuAnticheatPlugin.authentication = true;
					num2 = 2;
				}
				break;
			case 10:
				if (pkg.Size() <= 0)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4fda3adbb4ec45bdb14fe2ef97e570a8 == 0)
					{
						num2 = 0;
					}
					break;
				}
				flag = pkg.ReadBool();
				composer = pkg.ReadString();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f011663d64054593978962dcc3a5ec1a == 0)
				{
					num2 = 0;
				}
				break;
			case 3:
				return;
			case 8:
				if (pkg != null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 == 0)
					{
						num2 = 10;
					}
					break;
				}
				return;
			case 7:
				return;
			case 6:
				if (ZNet.instance.IsServerInstance())
				{
					num2 = 5;
					break;
				}
				if (sender == null)
				{
					num2 = 7;
					break;
				}
				goto case 8;
			case 4:
				AzuAnticheatPlugin._Writer = Localization.instance.Localize(DicSingleton.gE3WbyDVW(-992201216 ^ -992209194));
				num2 = 3;
				break;
			case 0:
				return;
			case 5:
				return;
			case 9:
				return;
			}
		}
	}

	internal static void RPC_EventDifferentLoadedMods(ZRpc sender, ZPackage pkg)
	{
		int num = 8;
		int num2 = num;
		bool flag = default(bool);
		string composer = default(string);
		while (true)
		{
			switch (num2)
			{
			case 15:
				if (AzuAnticheatPlugin._Producer)
				{
					num2 = 20;
					break;
				}
				goto case 25;
			case 14:
				if (flag)
				{
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba == 0)
					{
						num2 = 6;
					}
					break;
				}
				return;
			case 24:
				return;
			case 7:
				if (sender == null)
				{
					num2 = 11;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_23f9d18f43004f488662f38dd306f6ec == 0)
					{
						num2 = 12;
					}
					break;
				}
				goto case 3;
			case 10:
				AzuAnticheatPlugin.AcLogger.LogError(DicSingleton.gE3WbyDVW(-1011281439 ^ -1011273691) + Environment.NewLine + AzuAnticheatPlugin._Composer.Replace(DicSingleton.gE3WbyDVW(0x4C23C86A ^ 0x4C23DE16), Environment.NewLine));
				num2 = 23;
				break;
			case 26:
				return;
			case 6:
				AzuAnticheatPlugin.m_Attribute = true;
				num2 = 18;
				break;
			case 1:
				Property.MsgDsc(DicSingleton.gE3WbyDVW(-1447578472 ^ -1447586390) + Environment.NewLine + AzuAnticheatPlugin._Composer.Replace(DicSingleton.gE3WbyDVW(0x9000142 ^ 0x900173E), Environment.NewLine), DicSingleton.gE3WbyDVW(0x69B67B3A ^ 0x69B65A6C), isBad: false);
				num2 = 4;
				break;
			case 9:
				AzuAnticheatPlugin.AcLogger.LogError(DicSingleton.gE3WbyDVW(-992201216 ^ -992209102) + Environment.NewLine + AzuAnticheatPlugin._Composer.Replace(DicSingleton.gE3WbyDVW(-1908521178 ^ -1908518566), Environment.NewLine));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e == 0)
				{
					num2 = 1;
				}
				break;
			case 5:
				return;
			case 16:
				return;
			case 17:
				return;
			case 27:
				return;
			case 13:
				if (pkg.Size() > 0)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 == 0)
					{
						num2 = 0;
					}
					break;
				}
				return;
			case 3:
				if (pkg == null)
				{
					num2 = 11;
					break;
				}
				goto case 13;
			case 11:
				return;
			case 12:
				return;
			case 22:
				return;
			default:
				flag = pkg.ReadBool();
				composer = pkg.ReadString();
				num2 = 14;
				break;
			case 8:
				if (ZNet.instance.IsServerInstance())
				{
					return;
				}
				num2 = 7;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 == 0)
				{
					num2 = 0;
				}
				break;
			case 4:
				return;
			case 20:
				if (!AzuAnticheatPlugin._Producer)
				{
					num2 = 17;
					break;
				}
				goto case 19;
			case 19:
				AzuAnticheatPlugin._Writer = Localization.instance.Localize(DicSingleton.gE3WbyDVW(-1817326817 ^ -1817318753));
				num2 = 10;
				break;
			case 21:
				if (!AzuAnticheatPlugin.m_Attribute)
				{
					num2 = 5;
					break;
				}
				goto case 2;
			case 25:
				AzuAnticheatPlugin._Writer = Localization.instance.Localize(DicSingleton.gE3WbyDVW(-736996892 ^ -736988954));
				num2 = 9;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a == 0)
				{
					num2 = 9;
				}
				break;
			case 18:
				AzuAnticheatPlugin._Composer = composer;
				num2 = 21;
				break;
			case 2:
				if (AzuAnticheatPlugin.serializer)
				{
					num2 = 16;
					break;
				}
				goto case 15;
			case 23:
				Property.MsgDsc(DicSingleton.gE3WbyDVW(-1064640644 ^ -1064632648) + Environment.NewLine + AzuAnticheatPlugin._Composer.Replace(DicSingleton.gE3WbyDVW(-380885952 ^ -380882372), Environment.NewLine), DicSingleton.gE3WbyDVW(-525002617 ^ -524994181), isBad: false);
				num2 = 24;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_259acdc10a3c4fba8a4f129ba5346de2 == 0)
				{
					num2 = 27;
				}
				break;
			}
		}
	}

	public Info()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool DeleteExpression()
	{
		return InterruptExpression == null;
	}

	internal static Info FillExpression()
	{
		return InterruptExpression;
	}
}
