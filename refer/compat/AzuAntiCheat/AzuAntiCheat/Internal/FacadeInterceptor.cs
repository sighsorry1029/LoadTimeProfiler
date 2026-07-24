using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal static class FacadeInterceptor
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public string m_OrderInterceptor;

		internal static _003C_003Ec__DisplayClass3_0 CloneUtils;

		public _003C_003Ec__DisplayClass3_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)]
		internal string _003CFromCamelCase_003Eb__0(Match match)
		{
			return m_OrderInterceptor + match.Groups[DicSingleton.gE3WbyDVW(-1863475926 ^ -1863450664)].Value.ToLowerInvariant();
		}

		internal static bool ReadUtils()
		{
			return CloneUtils == null;
		}

		internal static _003C_003Ec__DisplayClass3_0 ViewUtils()
		{
			return CloneUtils;
		}
	}

	internal static FacadeInterceptor NewUtils;

	private static string ToCamelOrPascalCase(string str, Func<char, char> firstLetterTransform)
	{
		string text = Regex.Replace(str, DicSingleton.gE3WbyDVW(0x7A125A0E ^ 0x7A1238AA), [_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)] (Match match) => match.Groups[DicSingleton.gE3WbyDVW(-948533799 ^ -948508885)].Value.ToUpperInvariant(), RegexOptions.IgnoreCase);
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
		int num = 5;
		int num2 = num;
		char c = default(char);
		_003C_003Ec__DisplayClass3_0 _003C_003Ec__DisplayClass3_ = default(_003C_003Ec__DisplayClass3_0);
		while (true)
		{
			switch (num2)
			{
			case 2:
				c = char.ToLower(str[0]);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 == 0)
				{
					num2 = 0;
				}
				break;
			case 4:
				_003C_003Ec__DisplayClass3_.m_OrderInterceptor = separator;
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 == 0)
				{
					num2 = 1;
				}
				break;
			default:
				return str;
			case 5:
				_003C_003Ec__DisplayClass3_ = new _003C_003Ec__DisplayClass3_0();
				num2 = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 != 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				str = c + str.Substring(1);
				num2 = 3;
				break;
			case 3:
				str = Regex.Replace(ToCamelCase(str), DicSingleton.gE3WbyDVW(-1461449777 ^ -1461425891), _003C_003Ec__DisplayClass3_._003CFromCamelCase_003Eb__0);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool AddUtils()
	{
		return NewUtils == null;
	}

	internal static FacadeInterceptor PrepareUtils()
	{
		return NewUtils;
	}
}
