using System.Runtime.CompilerServices;
using AzuAntiCheat;
using HarmonyLib;

namespace AzuAnticheat.Internal;

[HarmonyPatch(typeof(ZNet), "OnNewConnection")]
internal static class ReaderPublisher
{
	private static ReaderPublisher RunVisitor;

	[HarmonyPrefix]
	[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
	private static void Prefix(ZNetPeer peer, ref ZNet __instance)
	{
		int num = 9;
		int num2 = num;
		ZPackage zPackage = default(ZPackage);
		while (true)
		{
			switch (num2)
			{
			case 13:
				AzuAnticheatPlugin._Producer = false;
				num2 = 11;
				break;
			case 11:
			case 12:
				peer.m_rpc.Register<ZPackage>(DicSingleton.gE3WbyDVW(-447849421 ^ -447846835), InvocationPublisher.RPC_AzuVerACcheck);
				num2 = 5;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f == 0)
				{
					num2 = 5;
				}
				break;
			case 4:
				peer.m_rpc.Invoke(DicSingleton.gE3WbyDVW(-1880453928 ^ -1880443226), zPackage);
				num2 = 10;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be == 0)
				{
					num2 = 9;
				}
				break;
			case 9:
				AzuAnticheatPlugin.AcLogger.LogDebug(DicSingleton.gE3WbyDVW(--708144185 ^ 0x2A3555E7));
				num2 = 8;
				break;
			case 3:
				zPackage.Write(AzuAnticheatPlugin.system);
				num2 = 4;
				break;
			case 6:
				if (!AzuAnticheatPlugin._Producer)
				{
					num2 = 12;
					break;
				}
				goto default;
			default:
				AzuAnticheatPlugin.AcLogger.LogDebug(DicSingleton.gE3WbyDVW(-1977574774 ^ -1977573196));
				num2 = 7;
				break;
			case 7:
				AzuAnticheatPlugin.serializer = false;
				num2 = 13;
				break;
			case 2:
				zPackage.Write(DicSingleton.gE3WbyDVW(-1866665889 ^ -1866668055));
				num2 = 3;
				break;
			case 1:
				zPackage = new ZPackage();
				num2 = 2;
				break;
			case 10:
				return;
			case 8:
				if (!AzuAnticheatPlugin.serializer)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb != 0)
					{
						num2 = 6;
					}
					break;
				}
				goto default;
			case 5:
				AzuAnticheatPlugin.AcLogger.LogMessage(DicSingleton.gE3WbyDVW(-428135557 ^ -428142105));
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa == 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	internal static bool VerifyVisitor()
	{
		return RunVisitor == null;
	}

	internal static ReaderPublisher PopVisitor()
	{
		return RunVisitor;
	}
}
