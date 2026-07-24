using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using AzuAntiCheat;
using HarmonyLib;

namespace AzuAnticheat.Internal;

[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
[HarmonyPatch]
[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
internal static class InvocationPublisher
{
	internal static List<ZRpc> authenticationPublisher;

	internal static InvocationPublisher CompareVisitor;

	internal static void RPC_AzuVerACcheck(ZRpc rpc, ZPackage pkg)
	{
		int num = 5;
		int num2 = num;
		string text2 = default(string);
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 5:
				text2 = pkg.ReadString();
				num2 = 4;
				break;
			case 9:
				authenticationPublisher.Add(rpc);
				num2 = 13;
				break;
			case 1:
			case 12:
				AzuAnticheatPlugin._Writer = DicSingleton.gE3WbyDVW(0x55F5513C ^ 0x55F56DF8) + text2;
				num2 = 7;
				break;
			case 0:
				return;
			case 14:
				rpc.Invoke(DicSingleton.gE3WbyDVW(0x7B291245 ^ 0x7B293A6D), 3);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 != 0)
				{
					num2 = 0;
				}
				break;
			case 10:
				return;
			case 8:
				AzuAnticheatPlugin.AcLogger.LogWarning(DicSingleton.gE3WbyDVW(-379532028 ^ -379521496) + rpc.m_socket.GetHostName() + DicSingleton.gE3WbyDVW(0xB026CF2 ^ 0xB0251EA));
				num2 = 14;
				break;
			case 3:
				if (!(text2 != DicSingleton.gE3WbyDVW(-428135557 ^ -428131123)))
				{
					if (!ZNet.instance.IsServer())
					{
						num2 = 6;
						break;
					}
					AzuAnticheatPlugin.AcLogger.LogMessage(DicSingleton.gE3WbyDVW(-1398029315 ^ -1398014519) + rpc.m_socket.GetHostName() + DicSingleton.gE3WbyDVW(0x4097B854 ^ 0x40978606));
					num2 = 9;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec == 0)
					{
						num2 = 9;
					}
				}
				else
				{
					num2 = 12;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 == 0)
					{
						num2 = 10;
					}
				}
				break;
			case 6:
				AzuAnticheatPlugin.AcLogger.LogMessage(DicSingleton.gE3WbyDVW(0x14AB6F1E ^ 0x14AB526A));
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c != 0)
				{
					num2 = 0;
				}
				break;
			case 13:
				return;
			case 7:
				if (!ZNet.instance.IsServer())
				{
					return;
				}
				num2 = 8;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 == 0)
				{
					num2 = 8;
				}
				break;
			case 11:
				return;
			case 2:
				AzuAnticheatPlugin.AcLogger.LogMessage(DicSingleton.gE3WbyDVW(0x3353457 ^ 0x33509EB) + text2);
				num2 = 11;
				break;
			case 4:
			{
				string text = pkg.ReadString();
				string system = AzuAnticheatPlugin.system;
				if (ZNet.instance.IsServer())
				{
					AzuAnticheatPlugin.AcLogger.LogMessage(DicSingleton.gE3WbyDVW(-447849421 ^ -447848435) + text2 + DicSingleton.gE3WbyDVW(-525002617 ^ -524999433));
				}
				else
				{
					AzuAnticheatPlugin.AcLogger.LogMessage(DicSingleton.gE3WbyDVW(--1182565251 ^ 0x467CBF11) + text2 + DicSingleton.gE3WbyDVW(0x6BAF1854 ^ 0x6BAF2424));
				}
				if (text != system)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 == 0)
					{
						num2 = 1;
					}
					break;
				}
				goto case 3;
			}
			}
		}
	}

	public static string ComputeHashForMod()
	{
		int num = 1;
		int num2 = num;
		SHA256 sHA = default(SHA256);
		int num4 = default(int);
		string result = default(string);
		byte b = default(byte);
		while (true)
		{
			switch (num2)
			{
			case 1:
				sHA = SHA256.Create();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 == 0)
				{
					num2 = 0;
				}
				continue;
			default:
				try
				{
					byte[] array = sHA.ComputeHash(File.ReadAllBytes(Assembly.GetExecutingAssembly().Location));
					StringBuilder stringBuilder = new StringBuilder();
					byte[] array2 = array;
					int num3 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 != 0)
					{
						num3 = 2;
					}
					while (true)
					{
						switch (num3)
						{
						case 4:
						case 5:
							if (num4 < array2.Length)
							{
								num3 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a != 0)
								{
									num3 = 0;
								}
								continue;
							}
							goto case 1;
						case 1:
							result = stringBuilder.ToString();
							num3 = 8;
							continue;
						case 7:
							stringBuilder.Append(b.ToString(DicSingleton.gE3WbyDVW(-1385030784 ^ -1385034038)));
							num3 = 2;
							continue;
						case 6:
							num4 = 0;
							num3 = 4;
							continue;
						case 2:
							num4++;
							num3 = 5;
							continue;
						default:
							b = array2[num4];
							num3 = 7;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 == 0)
							{
								num3 = 6;
							}
							continue;
						case 8:
							break;
						}
						break;
					}
				}
				finally
				{
					if (sHA != null)
					{
						int num5 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add != 0)
						{
							num5 = 1;
						}
						while (true)
						{
							switch (num5)
							{
							case 1:
								((IDisposable)sHA).Dispose();
								num5 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_259acdc10a3c4fba8a4f129ba5346de2 != 0)
								{
									num5 = 0;
								}
								continue;
							case 0:
								break;
							}
							break;
						}
					}
				}
				break;
			case 2:
				break;
			}
			break;
		}
		return result;
	}

	static InvocationPublisher()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				GetterIssuer.DeleteInitializer();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				authenticationPublisher = new List<ZRpc>();
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 == 0)
				{
					num2 = 1;
				}
				break;
			case 2:
				return;
			}
		}
	}

	internal static bool CloneVisitor()
	{
		return CompareVisitor == null;
	}

	internal static InvocationPublisher ReadVisitor()
	{
		return CompareVisitor;
	}
}
