using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AzuAnticheat.Internal;

internal static class PredicateInvocation
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public string systemInvocation;

		internal static _003C_003Ec__DisplayClass3_0 UpdateProxy;

		public _003C_003Ec__DisplayClass3_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9c47a25d924946efb9e023473a095794 != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal string _003CFromCamelCase_003Eb__0(Match match)
		{
			return systemInvocation + match.Groups[DicSingleton.gE3WbyDVW(0xB026CF2 ^ 0xB020E00)].Value.ToLowerInvariant();
		}

		internal static bool SearchProxy()
		{
			return UpdateProxy == null;
		}

		internal static _003C_003Ec__DisplayClass3_0 StopProxy()
		{
			return UpdateProxy;
		}
	}

	internal static PredicateInvocation EnableProxy;

	private static string ToCamelOrPascalCase(string str, Func<char, char> firstLetterTransform)
	{
		string text = Regex.Replace(str, DicSingleton.gE3WbyDVW(-428683152 ^ -428690732), (Match match) => match.Groups[DicSingleton.gE3WbyDVW(--798431903 ^ 0x2F97786D)].Value.ToUpperInvariant(), RegexOptions.IgnoreCase);
		return firstLetterTransform(text[0]) + text.Substring(1);
	}

	public static string ToCamelCase(this string str)
	{
		return ToCamelOrPascalCase(str, char.ToLowerInvariant);
	}

	public static string ToPascalCase(this string str)
	{
		return ToCamelOrPascalCase(str, char.ToUpperInvariant);
	}

	public static string FromCamelCase(this string str, string separator)
	{
		int num = 3;
		char c = default(char);
		_003C_003Ec__DisplayClass3_0 _003C_003Ec__DisplayClass3_ = default(_003C_003Ec__DisplayClass3_0);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 2:
					break;
				case 5:
					str = c + str.Substring(1);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb == 0)
					{
						num2 = 0;
					}
					continue;
				case 1:
					return str;
				default:
					str = Regex.Replace(ToCamelCase(str), DicSingleton.gE3WbyDVW(0xDA293E6 ^ 0xDA2F134), _003C_003Ec__DisplayClass3_._003CFromCamelCase_003Eb__0);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 == 0)
					{
						num2 = 1;
					}
					continue;
				case 3:
					_003C_003Ec__DisplayClass3_ = new _003C_003Ec__DisplayClass3_0();
					num2 = 2;
					continue;
				case 4:
					c = char.ToLower(str[0]);
					num2 = 5;
					continue;
				}
				break;
			}
			_003C_003Ec__DisplayClass3_.systemInvocation = separator;
			num = 4;
		}
	}

	internal static bool SortProxy()
	{
		return EnableProxy == null;
	}

	internal static PredicateInvocation InsertProxy()
	{
		return EnableProxy;
	}
}
