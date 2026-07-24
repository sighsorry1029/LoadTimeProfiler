using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AzuAntiCheat;
using HarmonyLib;
using UnityEngine;
using UnityEngine.Rendering;

namespace AzuAnticheat.Internal;

[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
[HarmonyPatch(typeof(FejdStartup), "SetupGui")]
internal static class ValPublisher
{
	private static string _ConfigPublisher;

	internal static ValPublisher CompareWrapper;

	private static void Postfix(FejdStartup __instance)
	{
		int num = 1;
		HashSet<string> hashSet = default(HashSet<string>);
		string text = default(string);
		List<string>.Enumerator enumerator = default(List<string>.Enumerator);
		string current = default(string);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 9:
					return;
				default:
					hashSet = new HashSet<string>(Localization.instance.m_languages.ToList());
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb != 0)
					{
						num2 = 6;
					}
					continue;
				case 2:
					text = PlayerPrefs.GetString(DicSingleton.gE3WbyDVW(-1385030784 ^ -1385021892), _ConfigPublisher);
					num = 8;
					break;
				case 12:
					Localization.instance.m_languages.AddRange(hashSet);
					num2 = 11;
					continue;
				case 1:
					if (SystemInfo.graphicsDeviceType == GraphicsDeviceType.Null)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f011663d64054593978962dcc3a5ec1a == 0)
						{
							num2 = 0;
						}
						continue;
					}
					return;
				case 8:
					if (!(text != _ConfigPublisher))
					{
						num2 = 9;
						continue;
					}
					goto case 7;
				case 7:
					if (!string.IsNullOrEmpty(text))
					{
						num2 = 6;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 == 0)
						{
							num2 = 13;
						}
						continue;
					}
					return;
				case 13:
					Localization.instance.SetupLanguage(text);
					num2 = 4;
					continue;
				case 11:
					Localization.instance.SetupLanguage(_ConfigPublisher);
					num2 = 10;
					continue;
				case 4:
					return;
				case 10:
					PlayerPrefs.SetString(DicSingleton.gE3WbyDVW(0x1679942F ^ 0x1679B193), AzuAnticheatPlugin._Status.Value);
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac != 0)
					{
						num2 = 2;
					}
					continue;
				case 3:
					try
					{
						while (true)
						{
							IL_0228:
							int num3;
							if (!enumerator.MoveNext())
							{
								num3 = 3;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 == 0)
								{
									num3 = 2;
								}
								goto IL_01d3;
							}
							goto IL_0211;
							IL_0211:
							current = enumerator.Current;
							int num4 = 2;
							num3 = num4;
							goto IL_01d3;
							IL_01d3:
							while (true)
							{
								switch (num3)
								{
								case 2:
									hashSet.Add(current);
									num3 = 0;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 == 0)
									{
										num3 = 0;
									}
									continue;
								case 1:
									break;
								default:
									goto IL_0228;
								case 3:
									goto end_IL_0228;
								}
								break;
							}
							goto IL_0211;
							continue;
							end_IL_0228:
							break;
						}
					}
					finally
					{
						((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
						int num5 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_575e6bd686b54d028cdc3fc324b58a39 != 0)
						{
							num5 = 0;
						}
						switch (num5)
						{
						case 0:
							break;
						}
					}
					goto case 5;
				case 6:
					enumerator = Localization.instance.LoadLanguages().GetEnumerator();
					num = 3;
					break;
				case 5:
					Localization.instance.m_languages.Clear();
					num2 = 12;
					continue;
				}
				break;
			}
		}
	}

	static ValPublisher()
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 0:
				return;
			case 2:
				GetterIssuer.DeleteInitializer();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb != 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				_ConfigPublisher = DicSingleton.gE3WbyDVW(0x6729A6D ^ 0x672980B);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool CloneWrapper()
	{
		return CompareWrapper == null;
	}

	internal static ValPublisher ReadWrapper()
	{
		return CompareWrapper;
	}
}
