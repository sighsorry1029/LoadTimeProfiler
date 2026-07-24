using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using AzuAntiCheat;
using BepInEx;
using BepInEx.Bootstrap;

namespace AzuAnticheat.Internal;

internal sealed class Observer
{
	[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(1)]
	internal static string _Adapter;

	internal static Observer ManageExpression;

	internal static void ModeratorListCreate()
	{
		int num = 3;
		int num2 = num;
		StreamWriter streamWriter = default(StreamWriter);
		while (true)
		{
			switch (num2)
			{
			case 4:
				return;
			case 2:
			{
				string configPath3 = Paths.ConfigPath;
				char directorySeparatorChar = Path.DirectorySeparatorChar;
				if (File.Exists(configPath3 + directorySeparatorChar + DicSingleton.gE3WbyDVW(-992201216 ^ -992199886)))
				{
					return;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 != 0)
				{
					num2 = 0;
				}
				break;
			}
			case 1:
				try
				{
					streamWriter.Write(new StringBuilder().AppendLine(DicSingleton.gE3WbyDVW(0x4995986C ^ 0x4995B0F6)).AppendLine(DicSingleton.gE3WbyDVW(0x1606DF07 ^ 0x1606F609)).AppendLine("")
						.AppendLine(DicSingleton.gE3WbyDVW(0x166FBD ^ 0x164671))
						.AppendLine(DicSingleton.gE3WbyDVW(-428135557 ^ -428146033))
						.AppendLine(DicSingleton.gE3WbyDVW(-1908521178 ^ -1908511236))
						.AppendLine(DicSingleton.gE3WbyDVW(-954365995 ^ -954356651))
						.AppendLine(DicSingleton.gE3WbyDVW(0x74FC52AF ^ 0x74FC7EB3))
						.AppendLine(DicSingleton.gE3WbyDVW(-243097544 ^ -243102472))
						.AppendLine(DicSingleton.gE3WbyDVW(-1829625923 ^ -1829621029))
						.AppendLine(DicSingleton.gE3WbyDVW(0x55F5513C ^ 0x55F57F2A))
						.AppendLine(DicSingleton.gE3WbyDVW(-293474990 ^ -293485600))
						.AppendLine(DicSingleton.gE3WbyDVW(-1977574774 ^ -1977567956))
						.AppendLine(DicSingleton.gE3WbyDVW(-1483531944 ^ -1483527710))
						.AppendLine(""));
					int num3 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 == 0)
					{
						num3 = 0;
					}
					while (true)
					{
						switch (num3)
						{
						case 1:
							return;
						}
						streamWriter.Close();
						num3 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_35cf05af90cc4195a86c9ffc19bf78eb != 0)
						{
							num3 = 1;
						}
					}
				}
				finally
				{
					int num4;
					if (streamWriter == null)
					{
						num4 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb != 0)
						{
							num4 = 2;
						}
						goto IL_0249;
					}
					goto IL_025f;
					IL_0249:
					switch (num4)
					{
					default:
						goto end_IL_0224;
					case 1:
						break;
					case 2:
						goto end_IL_0224;
					case 0:
						goto end_IL_0224;
					}
					goto IL_025f;
					IL_025f:
					((IDisposable)streamWriter).Dispose();
					num4 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef != 0)
					{
						num4 = 0;
					}
					goto IL_0249;
					end_IL_0224:;
				}
			default:
			{
				string configPath2 = Paths.ConfigPath;
				char directorySeparatorChar = Path.DirectorySeparatorChar;
				streamWriter = File.CreateText(configPath2 + directorySeparatorChar + DicSingleton.gE3WbyDVW(0x5901407C ^ 0x59014D4E));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 != 0)
				{
					num2 = 1;
				}
				break;
			}
			case 3:
			{
				string configPath = Paths.ConfigPath;
				char directorySeparatorChar = Path.DirectorySeparatorChar;
				AzuAnticheatPlugin.reader = configPath + directorySeparatorChar + DicSingleton.gE3WbyDVW(0x4F8CB66E ^ 0x4F8CBB5C);
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 == 0)
				{
					num2 = 0;
				}
				break;
			}
			}
		}
	}

	internal static void GetModList()
	{
		int num = 4;
		int num2 = num;
		Dictionary<string, PluginInfo>.ValueCollection.Enumerator enumerator = default(Dictionary<string, PluginInfo>.ValueCollection.Enumerator);
		SortedDictionary<string, string> sortedDictionary = default(SortedDictionary<string, string>);
		PluginInfo current = default(PluginInfo);
		string value = default(string);
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 2:
				enumerator = Chainloader.PluginInfos.Values.GetEnumerator();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 == 0)
				{
					num2 = 1;
				}
				break;
			case 4:
				sortedDictionary = new SortedDictionary<string, string>();
				num2 = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 == 0)
				{
					num2 = 3;
				}
				break;
			case 0:
				return;
			case 1:
				try
				{
					while (true)
					{
						IL_01e9:
						int num4;
						if (!enumerator.MoveNext())
						{
							int num3 = 2;
							num4 = num3;
							goto IL_0091;
						}
						goto IL_00b7;
						IL_0091:
						while (true)
						{
							switch (num4)
							{
							case 2:
								return;
							case 6:
								break;
							case 4:
							{
								string text = AzuAnticheatPlugin.TrustworthyTrygve(File.ReadAllBytes(current.Instance.GetType().Assembly.Location));
								string text2 = AzuAnticheatPlugin.TrustyBusty(text + DicSingleton.gE3WbyDVW(-108820061 ^ -108815849));
								value = AzuAnticheatPlugin.TrustyBusty(text + text2 + AzuAnticheatPlugin.TrustyBusty(DicSingleton.gE3WbyDVW(-2133864647 ^ -2133861149)));
								num4 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 != 0)
								{
									num4 = 0;
								}
								continue;
							}
							default:
								AzuAnticheatPlugin.m_Map.Add(string.Format(DicSingleton.gE3WbyDVW(0x3353457 ^ 0x3352039), current.Metadata.Name, current.Metadata.Version), value);
								num4 = 3;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
								{
									num4 = 2;
								}
								continue;
							case 3:
								sortedDictionary.Add(string.Format(DicSingleton.gE3WbyDVW(-525002617 ^ -525005591), current.Metadata.Name, current.Metadata.Version), value);
								num4 = 5;
								continue;
							case 1:
								goto IL_01e9;
							case 5:
								_Adapter = Class.ToYAML(sortedDictionary);
								num4 = 1;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a == 0)
								{
									num4 = 0;
								}
								continue;
							}
							break;
						}
						goto IL_00b7;
						IL_00b7:
						current = enumerator.Current;
						num4 = 4;
						goto IL_0091;
					}
				}
				finally
				{
					((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
					int num5 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec == 0)
					{
						num5 = 0;
					}
					switch (num5)
					{
					case 0:
						break;
					}
				}
			case 3:
				_Adapter = "";
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3ac5d604ebd547e7ac5b1603a0e85187 != 0)
				{
					num2 = 2;
				}
				break;
			}
		}
	}

	internal static void WebhookCreate()
	{
		AzuAnticheatPlugin._Definition.Clear();
		try
		{
			string configPath = Paths.ConfigPath;
			char directorySeparatorChar = Path.DirectorySeparatorChar;
			if (!File.Exists(configPath + directorySeparatorChar + DicSingleton.gE3WbyDVW(-1863475926 ^ -1863478844)))
			{
				string configPath2 = Paths.ConfigPath;
				directorySeparatorChar = Path.DirectorySeparatorChar;
				using StreamWriter streamWriter = File.CreateText(configPath2 + directorySeparatorChar + DicSingleton.gE3WbyDVW(-34102588 ^ -34099670));
				streamWriter.Write(new StringBuilder().AppendLine(DicSingleton.gE3WbyDVW(0xC23E82C ^ 0xC23D948)).AppendLine(DicSingleton.gE3WbyDVW(0x120E76C ^ 0x120D566)).AppendLine(DicSingleton.gE3WbyDVW(0x1C9EFC64 ^ 0x1C9ECEAE))
					.AppendLine("")
					.AppendLine(DicSingleton.gE3WbyDVW(0x7A125A0E ^ 0x7A12699A))
					.AppendLine("")
					.AppendLine(DicSingleton.gE3WbyDVW(-428135557 ^ -428138901))
					.AppendLine(DicSingleton.gE3WbyDVW(--650088194 ^ 0x26BFBA36)));
				streamWriter.Close();
			}
			string configPath3 = Paths.ConfigPath;
			directorySeparatorChar = Path.DirectorySeparatorChar;
			if (!File.Exists(configPath3 + directorySeparatorChar + DicSingleton.gE3WbyDVW(-1133601918 ^ -1133602964)))
			{
				return;
			}
			string configPath4 = Paths.ConfigPath;
			directorySeparatorChar = Path.DirectorySeparatorChar;
			Dictionary<string, Params> dictionary = Class.ParseHook(File.ReadAllText(configPath4 + directorySeparatorChar + DicSingleton.gE3WbyDVW(0x548F02D9 ^ 0x548F0E37)));
			if (dictionary != null)
			{
				foreach (KeyValuePair<string, Params> item in dictionary.Where((KeyValuePair<string, Params> hookDefinition) => hookDefinition.Value != null && hookDefinition.Key != null))
				{
					AzuAnticheatPlugin._Definition.Add(item.Value);
				}
			}
			AzuAnticheatPlugin.AcLogger.LogDebug(string.Format(DicSingleton.gE3WbyDVW(-736996892 ^ -736991266), AzuAnticheatPlugin._Definition.Count));
		}
		catch (Exception arg)
		{
			AzuAnticheatPlugin.AcLogger.LogError(string.Format(DicSingleton.gE3WbyDVW(0x7FAAD78F ^ 0x7FAAE1FD), arg));
		}
	}

	public Observer()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d5c0c185d7b1430b897cb64adc93b81c != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	static Observer()
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 1:
				_Adapter = "";
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			case 2:
				GetterIssuer.DeleteInitializer();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_91887e48b8104e7da08b48f73b607337 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool ForgotExpression()
	{
		return ManageExpression == null;
	}

	internal static Observer RestartExpression()
	{
		return ManageExpression;
	}
}
