using System.Runtime.CompilerServices;
using AzuAntiCheat;
using HarmonyLib;

namespace AzuAnticheat.Internal;

[HarmonyPatch(typeof(Minimap), "ExploreAll")]
internal class IteratorPublisher
{
	internal static IteratorPublisher DefineVisitor;

	[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
	[HarmonyPrefix]
	private static bool Prefix(Minimap __instance)
	{
		int num = 7;
		bool? exploreMapBypass = default(bool?);
		Dispatcher dispatcher = default(Dispatcher);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 7:
					if (!AzuAnticheatPlugin.serializer)
					{
						num2 = 6;
						continue;
					}
					goto case 12;
				case 3:
					exploreMapBypass = dispatcher.ExploreMapBypass;
					num2 = 13;
					continue;
				case 11:
					AzuAnticheatPlugin._Writer = Localization.instance.Localize(DicSingleton.gE3WbyDVW(-108820061 ^ -108808519));
					num2 = 8;
					continue;
				case 8:
					return false;
				case 10:
					if (!AzuAnticheatPlugin._Producer)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 5;
				case 5:
					dispatcher = AzuAnticheatPlugin._Helper[AzuAnticheatPlugin._Indexer];
					num2 = 3;
					continue;
				case 9:
					return true;
				default:
					AzuAnticheatPlugin.interpreter = true;
					num2 = 11;
					continue;
				case 1:
					if (exploreMapBypass.HasValue)
					{
						num2 = 10;
						continue;
					}
					goto default;
				case 13:
					if (exploreMapBypass.Value)
					{
						num2 = 9;
						continue;
					}
					goto default;
				case 2:
					exploreMapBypass = dispatcher.ExploreMapBypass;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 == 0)
					{
						num2 = 0;
					}
					continue;
				case 12:
					return true;
				case 6:
					if (AzuAnticheatPlugin._Helper.ContainsKey(AzuAnticheatPlugin._Indexer))
					{
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 == 0)
						{
							num2 = 3;
						}
						continue;
					}
					goto default;
				case 4:
					break;
				}
				break;
			}
			dispatcher = AzuAnticheatPlugin._Helper[AzuAnticheatPlugin._Indexer];
			num = 2;
		}
	}

	public IteratorPublisher()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool IncludeVisitor()
	{
		return DefineVisitor == null;
	}

	internal static IteratorPublisher CheckVisitor()
	{
		return DefineVisitor;
	}
}
