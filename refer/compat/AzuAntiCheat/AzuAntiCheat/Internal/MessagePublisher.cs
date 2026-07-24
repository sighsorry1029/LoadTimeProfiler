using System.Runtime.CompilerServices;
using BepInEx.Logging;
using HarmonyLib;

namespace AzuAnticheat.Internal;

[HarmonyPatch(typeof(ConsoleLogListener), "LogEvent")]
internal static class MessagePublisher
{
	private static MessagePublisher MapWrapper;

	[HarmonyPrefix]
	[HarmonyPriority(800)]
	[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
	private static bool PrevenPointlessLogs(ConsoleLogListener __instance, object sender, LogEventArgs eventArgs)
	{
		int num = 2;
		int num2 = num;
		string text = default(string);
		while (true)
		{
			switch (num2)
			{
			case 3:
				return !text.Contains(DicSingleton.gE3WbyDVW(0x6DF53C90 ^ 0x6DF579E4));
			default:
				return false;
			case 1:
				if (text.Contains(DicSingleton.gE3WbyDVW(-1544119467 ^ -1544102381)))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea != 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 3;
			case 2:
				text = eventArgs.Data.ToString();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 != 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	internal static bool NewWrapper()
	{
		return MapWrapper == null;
	}

	internal static MessagePublisher AddWrapper()
	{
		return MapWrapper;
	}
}
