using System.Runtime.CompilerServices;
using AzuAntiCheat;
using HarmonyLib;

namespace AzuAnticheat.Internal;

[HarmonyPatch(typeof(ZNet), "Disconnect")]
internal static class WriterPublisher
{
	private static WriterPublisher PrepareVisitor;

	[HarmonyPrefix]
	[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
	private static void Prefix(ZNetPeer peer, ref ZNet __instance)
	{
		int num = 3;
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 3:
					if (!__instance.IsServer())
					{
						return;
					}
					goto end_IL_0012;
				case 1:
					InvocationPublisher.authenticationPublisher.Remove(peer.m_rpc);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 != 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				case 4:
					return;
				case 2:
					AzuAnticheatPlugin.AcLogger.LogMessage(DicSingleton.gE3WbyDVW(0x44072FB7 ^ 0x4407149B) + peer.m_rpc.m_socket.GetHostName() + DicSingleton.gE3WbyDVW(-1611872559 ^ -1611858637));
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 != 0)
					{
						num2 = 1;
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

	internal static bool WriteVisitor()
	{
		return PrepareVisitor == null;
	}

	internal static WriterPublisher PrintVisitor()
	{
		return PrepareVisitor;
	}
}
