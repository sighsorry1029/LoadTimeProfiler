using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AzuAntiCheat;
using HarmonyLib;

namespace AzuAnticheat.Internal;

[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
[HarmonyPatch]
internal class PublisherPublisher
{
	internal static PublisherPublisher RevertExpression;

	internal static void RPC_AdminStatus(ZRpc rpc, ZPackage z)
	{
		int num = 11;
		string text3 = default(string);
		ZPackage zPackage = default(ZPackage);
		bool data2 = default(bool);
		bool data = default(bool);
		string text2 = default(string);
		string text = default(string);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 1:
					return;
				case 8:
					if (!AzuAnticheatPlugin._Helper.ContainsKey(text3))
					{
						num2 = 9;
						continue;
					}
					goto case 3;
				case 2:
					AzuAnticheatPlugin.AcLogger.LogDebug(DicSingleton.gE3WbyDVW(-2103041941 ^ -2103044415));
					num = 15;
					break;
				case 11:
					if (ZNet.instance.IsServerInstance())
					{
						num2 = 10;
						continue;
					}
					return;
				case 12:
					return;
				case 6:
					if (ZNet.instance.IsAdmin(rpc))
					{
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba == 0)
						{
							num2 = 16;
						}
						continue;
					}
					goto case 4;
				case 19:
					rpc.Invoke(DicSingleton.gE3WbyDVW(-447849421 ^ -447845621), zPackage);
					num2 = 12;
					continue;
				case 5:
					data2 = true;
					num2 = 4;
					continue;
				case 9:
				case 17:
				{
					ZPackage zPackage2 = new ZPackage();
					zPackage2.Write(data2);
					zPackage2.Write(data);
					zPackage = zPackage2;
					num2 = 19;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 == 0)
					{
						num2 = 19;
					}
					continue;
				}
				case 4:
					AzuAnticheatPlugin.oasdfouasdkfj(null, null);
					num2 = 8;
					continue;
				case 18:
					text2 = z.ReadString();
					num2 = 6;
					continue;
				case 10:
					if (z.Size() <= 0)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a != 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 7;
				default:
					data = true;
					num2 = 13;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a != 0)
					{
						num2 = 17;
					}
					continue;
				case 13:
					data = false;
					num = 2;
					break;
				case 14:
					text3 = z.ReadString();
					num2 = 18;
					continue;
				case 16:
					AzuAnticheatPlugin.AcLogger.LogInfo(DicSingleton.gE3WbyDVW(-381685266 ^ -381696244) + text + DicSingleton.gE3WbyDVW(-1385030784 ^ -1385026432) + text2 + DicSingleton.gE3WbyDVW(0x55F5513C ^ 0x55F57654) + text3 + DicSingleton.gE3WbyDVW(0x14AB6F1E ^ 0x14AB4BF0));
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 != 0)
					{
						num2 = 4;
					}
					continue;
				case 15:
					text = z.ReadString();
					num2 = 14;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be == 0)
					{
						num2 = 14;
					}
					continue;
				case 3:
					AzuAnticheatPlugin.AcLogger.LogInfo(DicSingleton.gE3WbyDVW(-1863475926 ^ -1863472584) + text + DicSingleton.gE3WbyDVW(-849667636 ^ -849662260) + text2 + DicSingleton.gE3WbyDVW(-598551743 ^ -598543319) + text3 + DicSingleton.gE3WbyDVW(0x6DF53C90 ^ 0x6DF5187E));
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9c47a25d924946efb9e023473a095794 == 0)
					{
						num2 = 0;
					}
					continue;
				case 7:
					data2 = false;
					num2 = 10;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 != 0)
					{
						num2 = 13;
					}
					continue;
				}
				break;
			}
		}
	}

	internal static void RPC_ListCompare(ZRpc rpc, ZPackage z)
	{
		if (!ZNet.instance.IsServerInstance() || z.Size() <= 0)
		{
			return;
		}
		ZPackage zPackage = new ZPackage();
		ZPackage zPackage2 = new ZPackage();
		new ZPackage();
		List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		AzuAnticheatPlugin.AcLogger.LogInfo(DicSingleton.gE3WbyDVW(0x540450D2 ^ 0x5404678E));
		string yaml = z.ReadString();
		string text = z.ReadString();
		string text2 = z.ReadString();
		string text3 = z.ReadString();
		SortedDictionary<string, string> sortedDictionary = Class.FromYAML(yaml) ?? new SortedDictionary<string, string>();
		SortedDictionary<string, string> sortedDictionary2 = Class.FromYAML(AzuAnticheatPlugin.m_Rules) ?? new SortedDictionary<string, string>();
		SortedDictionary<string, string> sortedDictionary3 = Class.FromYAML(AzuAnticheatPlugin.getter) ?? new SortedDictionary<string, string>();
		foreach (KeyValuePair<string, string> item in sortedDictionary)
		{
			list2.Add(item.Key + DicSingleton.gE3WbyDVW(0x602C149E ^ 0x602C33F6) + item.Value + DicSingleton.gE3WbyDVW(0x5A1F7167 ^ 0x5A1F5589));
			if ((!sortedDictionary2.TryGetValue(item.Key, out var value) || !(item.Value == value)) && (!sortedDictionary3.TryGetValue(item.Key, out var value2) || !(value2 == item.Value)))
			{
				list.Add(item);
			}
		}
		AzuAnticheatPlugin.AcLogger.LogInfo(DicSingleton.gE3WbyDVW(0x6E29C0C0 ^ 0x6E29F746) + text + DicSingleton.gE3WbyDVW(0x7A125A0E ^ 0x7A126D0E) + text3 + DicSingleton.gE3WbyDVW(-1614185587 ^ -1614193435) + text2 + DicSingleton.gE3WbyDVW(-359091888 ^ -359102776) + Environment.NewLine + string.Join(Environment.NewLine, list2));
		bool flag = ZNet.instance.ListContainsId(ZNet.instance.m_adminList, text2) || AzuAnticheatPlugin._Helper.ContainsKey(text2);
		if (list.Any() && !flag)
		{
			zPackage.Write(data: true);
			List<string> values = list.Select([_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(0)] (KeyValuePair<string, string> allBannedMod) => allBannedMod.Key).ToList();
			AzuAnticheatPlugin.AcLogger.LogInfo(DicSingleton.gE3WbyDVW(-1011281439 ^ -1011276185) + text + DicSingleton.gE3WbyDVW(-228218718 ^ -228221022) + text3 + DicSingleton.gE3WbyDVW(-736996892 ^ -736987508) + text2 + DicSingleton.gE3WbyDVW(0xDA293E6 ^ 0xDA2A408) + Environment.NewLine + string.Join(Environment.NewLine, values));
			zPackage.Write(string.Join(Environment.NewLine, values));
			Property.PostToDiscord(text, text3, text2, string.Join(Environment.NewLine, values), DicSingleton.gE3WbyDVW(-1908521178 ^ -1908506776), isBad: true, DicSingleton.gE3WbyDVW(-1338893851 ^ -1338884379));
			rpc.Invoke(DicSingleton.gE3WbyDVW(0x1C779450 ^ 0x1C77ACCC), zPackage);
			rpc.Invoke(DicSingleton.gE3WbyDVW(0x2BC349D6 ^ 0x2BC361FE), 456789123);
		}
		IEnumerable<KeyValuePair<string, string>> source = sortedDictionary2.Except(sortedDictionary);
		if (source.Any())
		{
			list3.AddRange(source.Select([_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(0)] (KeyValuePair<string, string> pair) => pair.Key));
		}
		if (list3.Any() && !ZNet.instance.IsAdmin(text2))
		{
			zPackage2.Write(data: true);
			AzuAnticheatPlugin.AcLogger.LogError(DicSingleton.gE3WbyDVW(--1509395337 ^ 0x59F7BC0F) + text + DicSingleton.gE3WbyDVW(0x2BC53863 ^ 0x2BC50F63) + text3 + DicSingleton.gE3WbyDVW(-2075300707 ^ -2075309067) + text2 + DicSingleton.gE3WbyDVW(-1075938037 ^ -1075952183) + Environment.NewLine + string.Join(Environment.NewLine, list3));
			zPackage2.Write(string.Join(Environment.NewLine, list3));
			Property.PostToDiscord(text, text3, text2, string.Join(Environment.NewLine, list3), DicSingleton.gE3WbyDVW(-379532028 ^ -379522026), isBad: false, DicSingleton.gE3WbyDVW(0x3FCF6129 ^ 0x3FCF4629));
			rpc.Invoke(DicSingleton.gE3WbyDVW(-34102588 ^ -34104428), zPackage2);
			rpc.Invoke(DicSingleton.gE3WbyDVW(0x4995986C ^ 0x4995B044), 456789123);
		}
	}

	public PublisherPublisher()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool InvokeVisitor()
	{
		return RevertExpression == null;
	}

	internal static PublisherPublisher PublishVisitor()
	{
		return RevertExpression;
	}
}
