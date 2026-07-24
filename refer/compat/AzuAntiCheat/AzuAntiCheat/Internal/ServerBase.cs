using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
using HarmonyLib;
using JetBrains.Annotations;
using UnityEngine;

namespace AzuAnticheat.Internal;

[_003Cf6f8ff5f_002Dfa45_002D43ba_002D9489_002Db740a9e7c98b_003ENullable(0)]
[PublicAPI]
[_003Cbb5e3e5e_002D5c47_002D485a_002D88ef_002Dea5afd7f01c7_003ENullableContext(1)]
internal class ServerBase
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		[_003Cf6f8ff5f_002Dfa45_002D43ba_002D9489_002Db740a9e7c98b_003ENullable(0)]
		public string annotationBase;

		private static _003C_003Ec__DisplayClass15_0 AddSingleton;

		public _003C_003Ec__DisplayClass15_0()
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

		[_003Cbb5e3e5e_002D5c47_002D485a_002D88ef_002Dea5afd7f01c7_003ENullableContext(0)]
		internal bool _003CReadEmbeddedFileBytes_003Eb__0(string str)
		{
			return str.EndsWith(annotationBase, StringComparison.Ordinal);
		}

		internal static bool PrepareSingleton()
		{
			return AddSingleton == null;
		}

		internal static _003C_003Ec__DisplayClass15_0 WriteSingleton()
		{
			return AddSingleton;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0<T>
	{
		[_003Cf6f8ff5f_002Dfa45_002D43ba_002D9489_002Db740a9e7c98b_003ENullable(0)]
		public string key;

		[_003Cf6f8ff5f_002Dfa45_002D43ba_002D9489_002Db740a9e7c98b_003ENullable(0)]
		public string placeholder;

		[_003Cf6f8ff5f_002Dfa45_002D43ba_002D9489_002Db740a9e7c98b_003ENullable(new byte[] { 0, 0, 1 })]
		public Func<T, string> convertConfigValue;

		[_003Cf6f8ff5f_002Dfa45_002D43ba_002D9489_002Db740a9e7c98b_003ENullable(0)]
		public ConfigEntry<T> config;

		private static object PrintSingleton;

		public _003C_003Ec__DisplayClass9_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal string _003CAddPlaceholder_003Eb__3()
		{
			return convertConfigValue(config.Value);
		}

		[_003Cbb5e3e5e_002D5c47_002D485a_002D88ef_002Dea5afd7f01c7_003ENullableContext(0)]
		internal void _003CAddPlaceholder_003Eb__2(object _, EventArgs _)
		{
			UpdatePlaceholder();
			void UpdatePlaceholder()
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
						UpdatePlaceholderText(Localization.instance, key);
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c == 0)
						{
							num2 = 0;
						}
						break;
					case 2:
						algoBase[key][placeholder] = () => convertConfigValue(config.Value);
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f011663d64054593978962dcc3a5ec1a == 0)
						{
							num2 = 1;
						}
						break;
					case 0:
						return;
					}
				}
			}
		}

		internal static bool CompareSingleton()
		{
			return PrintSingleton == null;
		}

		internal static object CloneSingleton()
		{
			return PrintSingleton;
		}
	}

	private static readonly Dictionary<string, Dictionary<string, Func<string>>> algoBase;

	private static readonly Dictionary<string, Dictionary<string, string>> importerBase;

	private static readonly ConditionalWeakTable<Localization, string> creatorBase;

	private static readonly List<WeakReference<Localization>> _PrinterBase;

	[_003Cf6f8ff5f_002Dfa45_002D43ba_002D9489_002Db740a9e7c98b_003ENullable(2)]
	private static BaseUnityPlugin databaseBase;

	private static readonly List<string> errorBase;

	internal static ServerBase ChangeSingleton;

	private static BaseUnityPlugin plugin
	{
		get
		{
			int num = 1;
			int num2 = num;
			IEnumerable<TypeInfo> source = default(IEnumerable<TypeInfo>);
			while (true)
			{
				switch (num2)
				{
				case 2:
					return databaseBase;
				default:
					try
					{
						source = Assembly.GetExecutingAssembly().DefinedTypes.ToList();
						int num3 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d != 0)
						{
							num3 = 0;
						}
						switch (num3)
						{
						case 0:
							break;
						}
					}
					catch (ReflectionTypeLoadException ex)
					{
						source = from t in ex.Types
							where t != null
							select t.GetTypeInfo();
						int num4 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 != 0)
						{
							num4 = 0;
						}
						switch (num4)
						{
						case 0:
							break;
						}
					}
					break;
				case 1:
					if ((object)databaseBase == null)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a579dea83d2144838086d2d400bd0222 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 2;
				case 3:
					break;
				}
				databaseBase = (BaseUnityPlugin)Chainloader.ManagerObject.GetComponent(source.First([_003Cbb5e3e5e_002D5c47_002D485a_002D88ef_002Dea5afd7f01c7_003ENullableContext(0)] (TypeInfo t) =>
				{
					int num5 = 1;
					int num6 = num5;
					while (true)
					{
						switch (num6)
						{
						case 1:
							if (!t.IsClass)
							{
								return false;
							}
							num6 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 == 0)
							{
								num6 = 0;
							}
							break;
						default:
							return typeof(BaseUnityPlugin).IsAssignableFrom(t);
						}
					}
				}));
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 != 0)
				{
					num2 = 2;
				}
			}
		}
	}

	private static void UpdatePlaceholderText(Localization localization, string key)
	{
		int num = 4;
		int num2 = num;
		string text = default(string);
		Dictionary<string, Func<string>> value2 = default(Dictionary<string, Func<string>>);
		string value = default(string);
		while (true)
		{
			switch (num2)
			{
			default:
				localization.AddWord(key, text);
				num2 = 5;
				continue;
			case 1:
				if (!algoBase.TryGetValue(key, out value2))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf != 0)
					{
						num2 = 0;
					}
					continue;
				}
				break;
			case 5:
				return;
			case 4:
				creatorBase.TryGetValue(localization, out value);
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c2b9915913b8461884afdca5d98855ec == 0)
				{
					num2 = 3;
				}
				continue;
			case 3:
				text = importerBase[value][key];
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 == 0)
				{
					num2 = 1;
				}
				continue;
			case 2:
				break;
			}
			text = value2.Aggregate(text, [_003Cbb5e3e5e_002D5c47_002D485a_002D88ef_002Dea5afd7f01c7_003ENullableContext(0)] (string current, KeyValuePair<string, Func<string>> kv) => current.Replace(DicSingleton.gE3WbyDVW(-948533799 ^ -948514533) + kv.Key + DicSingleton.gE3WbyDVW(-849667636 ^ -849654524), kv.Value()));
			num2 = 6;
		}
	}

	public static void AddPlaceholder<T>(string key, string placeholder, ConfigEntry<T> config, [_003Cf6f8ff5f_002Dfa45_002D43ba_002D9489_002Db740a9e7c98b_003ENullable(new byte[] { 2, 1, 1 })] Func<T, string> convertConfigValue = null)
	{
		_003C_003Ec__DisplayClass9_0<T> CS_0024_003C_003E8__locals14 = new _003C_003Ec__DisplayClass9_0<T>();
		CS_0024_003C_003E8__locals14.key = key;
		CS_0024_003C_003E8__locals14.placeholder = placeholder;
		CS_0024_003C_003E8__locals14.convertConfigValue = convertConfigValue;
		CS_0024_003C_003E8__locals14.config = config;
		if (CS_0024_003C_003E8__locals14.convertConfigValue == null)
		{
			CS_0024_003C_003E8__locals14.convertConfigValue = [_003Cbb5e3e5e_002D5c47_002D485a_002D88ef_002Dea5afd7f01c7_003ENullableContext(0)] [return: _003Cf6f8ff5f_002Dfa45_002D43ba_002D9489_002Db740a9e7c98b_003ENullable(1)] (T val) => val.ToString();
		}
		if (!algoBase.ContainsKey(CS_0024_003C_003E8__locals14.key))
		{
			algoBase[CS_0024_003C_003E8__locals14.key] = new Dictionary<string, Func<string>>();
		}
		CS_0024_003C_003E8__locals14.config.SettingChanged += [_003Cbb5e3e5e_002D5c47_002D485a_002D88ef_002Dea5afd7f01c7_003ENullableContext(0)] (object _, EventArgs _) =>
		{
			UpdatePlaceholder();
		};
		if (importerBase.ContainsKey(Localization.instance.GetSelectedLanguage()))
		{
			UpdatePlaceholder();
		}
		void UpdatePlaceholder()
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
					UpdatePlaceholderText(Localization.instance, CS_0024_003C_003E8__locals14.key);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c == 0)
					{
						num2 = 0;
					}
					break;
				case 2:
					algoBase[CS_0024_003C_003E8__locals14.key][CS_0024_003C_003E8__locals14.placeholder] = () => CS_0024_003C_003E8__locals14.convertConfigValue(CS_0024_003C_003E8__locals14.config.Value);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f011663d64054593978962dcc3a5ec1a == 0)
					{
						num2 = 1;
					}
					break;
				case 0:
					return;
				}
			}
		}
	}

	public static void AddText(string key, string text)
	{
		List<WeakReference<Localization>> list = new List<WeakReference<Localization>>();
		foreach (WeakReference<Localization> item in _PrinterBase)
		{
			if (item.TryGetTarget(out var target))
			{
				Dictionary<string, string> dictionary = importerBase[creatorBase.GetOrCreateValue(target)];
				if (!target.m_translations.ContainsKey(key))
				{
					dictionary[key] = text;
					target.AddWord(key, text);
				}
			}
			else
			{
				list.Add(item);
			}
		}
		foreach (WeakReference<Localization> item2 in list)
		{
			_PrinterBase.Remove(item2);
		}
	}

	public static void Load()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 0:
				return;
			case 1:
				LoadLocalization(Localization.instance, Localization.instance.GetSelectedLanguage());
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	private static void LoadLocalization(Localization __instance, string language)
	{
		if (!creatorBase.Remove(__instance))
		{
			_PrinterBase.Add(new WeakReference<Localization>(__instance));
		}
		creatorBase.Add(__instance, language);
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (string item in from f in Directory.GetFiles(Path.GetDirectoryName(Paths.PluginPath), plugin.Info.Metadata.Name + DicSingleton.gE3WbyDVW(-360128320 ^ -360140514), SearchOption.AllDirectories)
			where errorBase.IndexOf(Path.GetExtension(f)) >= 0
			select f)
		{
			string text = Path.GetFileNameWithoutExtension(item).Split(new char[1] { '.' })[1];
			if (dictionary.ContainsKey(text))
			{
				Debug.LogWarning(DicSingleton.gE3WbyDVW(-1335677307 ^ -1335656605) + text + DicSingleton.gE3WbyDVW(-1735703950 ^ -1735716748) + plugin.Info.Metadata.Name + DicSingleton.gE3WbyDVW(-940539791 ^ -940518831) + item + DicSingleton.gE3WbyDVW(-1123846595 ^ -1123867555));
			}
			else
			{
				dictionary[text] = item;
			}
		}
		byte[] array = LoadTranslationFromAssembly(DicSingleton.gE3WbyDVW(-545065612 ^ -545065198));
		if (array == null)
		{
			throw new Exception(DicSingleton.gE3WbyDVW(-823738529 ^ -823726631) + plugin.Info.Metadata.Name + DicSingleton.gE3WbyDVW(0x1606DF07 ^ 0x16068DD1));
		}
		Dictionary<string, string> dictionary2 = new AdapterBase().IgnoreFields().Build().Deserialize<Dictionary<string, string>>(Encoding.UTF8.GetString(array));
		if (dictionary2 == null)
		{
			throw new Exception(DicSingleton.gE3WbyDVW(0x2D27936 ^ 0x2D22AB0) + plugin.Info.Metadata.Name + DicSingleton.gE3WbyDVW(0x59C84793 ^ 0x59C81427));
		}
		string text2 = null;
		if (language != DicSingleton.gE3WbyDVW(0x3353457 ^ 0x3353631))
		{
			if (dictionary.ContainsKey(language))
			{
				text2 = File.ReadAllText(dictionary[language]);
			}
			else
			{
				byte[] array2 = LoadTranslationFromAssembly(language);
				if (array2 != null)
				{
					text2 = Encoding.UTF8.GetString(array2);
				}
			}
		}
		if (text2 == null && dictionary.ContainsKey(DicSingleton.gE3WbyDVW(-32559551 ^ -32560089)))
		{
			text2 = File.ReadAllText(dictionary[DicSingleton.gE3WbyDVW(-1123846595 ^ -1123847077)]);
		}
		if (text2 != null)
		{
			foreach (KeyValuePair<string, string> item2 in new AdapterBase().IgnoreFields().Build().Deserialize<Dictionary<string, string>>(text2) ?? new Dictionary<string, string>())
			{
				dictionary2[item2.Key] = item2.Value;
			}
		}
		importerBase[language] = dictionary2;
		foreach (KeyValuePair<string, string> item3 in dictionary2)
		{
			UpdatePlaceholderText(__instance, item3.Key);
		}
	}

	static ServerBase()
	{
		int num = 2;
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 7:
					creatorBase = new ConditionalWeakTable<Localization, string>();
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0a707bb791e14c9e9a3ee77696a896b0 == 0)
					{
						num2 = 0;
					}
					continue;
				case 2:
					GetterIssuer.DeleteInitializer();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c != 0)
					{
						num2 = 0;
					}
					continue;
				case 3:
					importerBase = new Dictionary<string, Dictionary<string, string>>();
					num2 = 7;
					continue;
				case 1:
					algoBase = new Dictionary<string, Dictionary<string, Func<string>>>();
					num2 = 3;
					continue;
				case 6:
					new Harmony(DicSingleton.gE3WbyDVW(0x6729A6D ^ 0x672CE71)).Patch(AccessTools.DeclaredMethod(typeof(Localization), DicSingleton.gE3WbyDVW(0x5A1B57A3 ^ 0x5A1B03CD)), null, new HarmonyMethod(AccessTools.DeclaredMethod(typeof(ServerBase), DicSingleton.gE3WbyDVW(-1053593978 ^ -1053607418))));
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3ac5d604ebd547e7ac5b1603a0e85187 == 0)
					{
						num2 = 0;
					}
					continue;
				case 0:
					return;
				case 5:
					errorBase = new List<string>
					{
						DicSingleton.gE3WbyDVW(-32559551 ^ -32540093),
						DicSingleton.gE3WbyDVW(--1844849127 ^ 0x6DF67DF7)
					};
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 == 0)
					{
						num2 = 6;
					}
					continue;
				case 4:
					break;
				}
				break;
			}
			_PrinterBase = new List<WeakReference<Localization>>();
			num = 5;
		}
	}

	[return: _003Cf6f8ff5f_002Dfa45_002D43ba_002D9489_002Db740a9e7c98b_003ENullable(2)]
	private static byte[] LoadTranslationFromAssembly(string language)
	{
		foreach (string item in errorBase)
		{
			byte[] array = ReadEmbeddedFileBytes(DicSingleton.gE3WbyDVW(-1863475926 ^ -1863464562) + language + item);
			if (array != null)
			{
				return array;
			}
		}
		return null;
	}

	[_003Cbb5e3e5e_002D5c47_002D485a_002D88ef_002Dea5afd7f01c7_003ENullableContext(2)]
	public static byte[] ReadEmbeddedFileBytes([_003Cf6f8ff5f_002Dfa45_002D43ba_002D9489_002Db740a9e7c98b_003ENullable(1)] string resourceFileName, Assembly containingAssembly = null)
	{
		_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass15_0();
		CS_0024_003C_003E8__locals2.annotationBase = resourceFileName;
		using MemoryStream memoryStream = new MemoryStream();
		if ((object)containingAssembly == null)
		{
			containingAssembly = Assembly.GetCallingAssembly();
		}
		string text = containingAssembly.GetManifestResourceNames().FirstOrDefault([_003Cbb5e3e5e_002D5c47_002D485a_002D88ef_002Dea5afd7f01c7_003ENullableContext(0)] (string str) => str.EndsWith(CS_0024_003C_003E8__locals2.annotationBase, StringComparison.Ordinal));
		if (text != null)
		{
			containingAssembly.GetManifestResourceStream(text)?.CopyTo(memoryStream);
		}
		return (memoryStream.Length == 0L) ? null : memoryStream.ToArray();
	}

	public ServerBase()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool CreateSingleton()
	{
		return ChangeSingleton == null;
	}

	internal static ServerBase RunSingleton()
	{
		return ChangeSingleton;
	}
}
