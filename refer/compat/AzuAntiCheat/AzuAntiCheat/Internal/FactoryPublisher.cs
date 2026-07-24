using System.Runtime.CompilerServices;
using AzuAntiCheat;
using HarmonyLib;
using Splatform;

namespace AzuAnticheat.Internal;

[HarmonyPatch(typeof(ZNet), "RPC_PeerInfo")]
internal static class FactoryPublisher
{
	internal static FactoryPublisher PostVisitor;

	[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
	[HarmonyPrefix]
	private static bool Prefix(ZRpc rpc, ZPackage pkg, ref ZNet __instance)
	{
		int num = 20;
		ZPackage zPackage = default(ZPackage);
		PlatformUserID platformUserID = default(PlatformUserID);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 13:
					zPackage = new ZPackage();
					num2 = 12;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 == 0)
					{
						num2 = 12;
					}
					continue;
				case 3:
					rpc.Register<ZPackage>(DicSingleton.gE3WbyDVW(--650088194 ^ 0x26BFB40A), Property.SetUpErrorMessage);
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 != 0)
					{
						num2 = 23;
					}
					continue;
				case 17:
					return false;
				case 14:
					rpc.Register<ZPackage>(DicSingleton.gE3WbyDVW(-1335677307 ^ -1335683999), Info.RPC_ClientAdminStatus);
					num2 = 11;
					continue;
				case 8:
					AzuAnticheatPlugin._Template = Game.instance.GetPlayerProfile().GetName();
					num2 = 16;
					continue;
				case 23:
					if (!__instance.IsServer())
					{
						num2 = 13;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 != 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 10;
				case 18:
					rpc.Register<ZPackage>(DicSingleton.gE3WbyDVW(-2083714112 ^ -2083704176), Info.RPC_EventDifferentLoadedMods);
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 == 0)
					{
						num2 = 3;
					}
					continue;
				case 21:
					zPackage.Write(AzuAnticheatPlugin._Indexer);
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f == 0)
					{
						num2 = 9;
					}
					continue;
				case 11:
					rpc.Register<ZPackage>(DicSingleton.gE3WbyDVW(0x1679942F ^ 0x1679ACB3), Info.RPC_EventLoadedMods);
					num2 = 10;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 == 0)
					{
						num2 = 18;
					}
					continue;
				case 6:
					rpc.Register<ZPackage>(DicSingleton.gE3WbyDVW(-1389846755 ^ -1389838427), PublisherPublisher.RPC_ListCompare);
					num2 = 12;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc != 0)
					{
						num2 = 14;
					}
					continue;
				case 15:
					rpc.Invoke(DicSingleton.gE3WbyDVW(-1398029315 ^ -1398019115), 3);
					num2 = 17;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 == 0)
					{
						num2 = 14;
					}
					continue;
				case 2:
					platformUserID = PlatformManager.DistributionPlatform.LocalUser.PlatformUserID;
					num2 = 5;
					continue;
				case 10:
					if (!__instance.IsServer())
					{
						num2 = 4;
						continue;
					}
					goto case 1;
				case 1:
					if (!InvocationPublisher.authenticationPublisher.Contains(rpc))
					{
						num2 = 7;
						continue;
					}
					goto case 4;
				default:
					rpc.Invoke(DicSingleton.gE3WbyDVW(0x3C33E48 ^ 0x3C30484), zPackage);
					num2 = 10;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 != 0)
					{
						num2 = 8;
					}
					continue;
				case 20:
					rpc.Register<ZPackage>(DicSingleton.gE3WbyDVW(0x4F8CB66E ^ 0x4F8C8CA2), PublisherPublisher.RPC_AdminStatus);
					num2 = 19;
					continue;
				case 16:
					zPackage.Write(AzuAnticheatPlugin.mock);
					num = 21;
					break;
				case 12:
					AzuAnticheatPlugin.mock = PlatformManager.DistributionPlatform.LocalUser.DisplayName;
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 == 0)
					{
						num2 = 2;
					}
					continue;
				case 9:
					zPackage.Write(AzuAnticheatPlugin._Template);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 != 0)
					{
						num2 = 0;
					}
					continue;
				case 4:
				case 22:
					return true;
				case 7:
					AzuAnticheatPlugin.AcLogger.LogWarning(DicSingleton.gE3WbyDVW(0x9000142 ^ 0x9003A6E) + rpc.m_socket.GetHostName() + DicSingleton.gE3WbyDVW(-954365995 ^ -954352407));
					num2 = 15;
					continue;
				case 19:
					rpc.Register<ZPackage>(DicSingleton.gE3WbyDVW(0x4F8CB66E ^ 0x4F8C8156), Info.RPC_ClientAdminStatus);
					num2 = 6;
					continue;
				case 5:
					AzuAnticheatPlugin._Indexer = platformUserID.ToString();
					num = 8;
					break;
				}
				break;
			}
		}
	}

	internal static bool CallVisitor()
	{
		return PostVisitor == null;
	}

	internal static FactoryPublisher ConcatVisitor()
	{
		return PostVisitor;
	}
}
