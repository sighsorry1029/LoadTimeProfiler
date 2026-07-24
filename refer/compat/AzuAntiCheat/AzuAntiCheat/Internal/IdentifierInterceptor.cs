using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal static class IdentifierInterceptor
{
	public static readonly NumberFormatInfo _TokenInterceptor;

	private static IdentifierInterceptor QueryMerchant;

	public static string FormatNumber(object number)
	{
		return Convert.ToString(number, _TokenInterceptor);
	}

	public static string FormatNumber(double number)
	{
		return number.ToString(DicSingleton.gE3WbyDVW(0x567B7B7F ^ 0x567B2481), _TokenInterceptor);
	}

	public static string FormatNumber(float number)
	{
		return number.ToString(DicSingleton.gE3WbyDVW(-1580624393 ^ -1580611063), _TokenInterceptor);
	}

	public static string FormatBoolean(object boolean)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return DicSingleton.gE3WbyDVW(-34102588 ^ -34094388);
			case 1:
				return DicSingleton.gE3WbyDVW(0x2BC349D6 ^ 0x2BC329C0);
			case 2:
				if (boolean.Equals(true))
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto default;
			}
		}
	}

	public static string FormatDateTime(object dateTime)
	{
		int num = 1;
		int num2 = num;
		DateTime dateTime2 = default(DateTime);
		while (true)
		{
			switch (num2)
			{
			case 1:
				dateTime2 = (DateTime)dateTime;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return dateTime2.ToString(DicSingleton.gE3WbyDVW(-1977574774 ^ -1977550168), CultureInfo.InvariantCulture);
			}
		}
	}

	public static string FormatTimeSpan(object timeSpan)
	{
		int num = 1;
		int num2 = num;
		TimeSpan timeSpan2 = default(TimeSpan);
		while (true)
		{
			switch (num2)
			{
			case 1:
				timeSpan2 = (TimeSpan)timeSpan;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return timeSpan2.ToString();
			}
		}
	}

	static IdentifierInterceptor()
	{
		int num = 7;
		NumberFormatInfo numberFormatInfo = default(NumberFormatInfo);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 12:
					return;
				case 1:
					numberFormatInfo.NumberDecimalDigits = 99;
					num2 = 10;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 == 0)
					{
						num2 = 9;
					}
					continue;
				case 6:
					numberFormatInfo = new NumberFormatInfo();
					num2 = 9;
					continue;
				case 8:
					_TokenInterceptor = numberFormatInfo;
					num2 = 12;
					continue;
				case 10:
					numberFormatInfo.NaNSymbol = DicSingleton.gE3WbyDVW(0x602C149E ^ 0x602C74B6);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 != 0)
					{
						num2 = 4;
					}
					continue;
				default:
					numberFormatInfo.CurrencyGroupSizes = new int[1] { 3 };
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb != 0)
					{
						num2 = 3;
					}
					continue;
				case 11:
					numberFormatInfo.NumberGroupSeparator = DicSingleton.gE3WbyDVW(-428135557 ^ -428121759);
					num2 = 13;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 == 0)
					{
						num2 = 2;
					}
					continue;
				case 14:
					numberFormatInfo.CurrencyGroupSeparator = DicSingleton.gE3WbyDVW(-1059662249 ^ -1059677107);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 == 0)
					{
						num2 = 0;
					}
					continue;
				case 9:
					numberFormatInfo.CurrencyDecimalSeparator = DicSingleton.gE3WbyDVW(0x6729A6D ^ 0x672D533);
					num2 = 14;
					continue;
				case 7:
					GetterIssuer.DeleteInitializer();
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 != 0)
					{
						num2 = 1;
					}
					continue;
				case 3:
					numberFormatInfo.CurrencySymbol = string.Empty;
					num2 = 5;
					continue;
				case 4:
					break;
				case 5:
					numberFormatInfo.CurrencyDecimalDigits = 99;
					num2 = 15;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 == 0)
					{
						num2 = 7;
					}
					continue;
				case 13:
					numberFormatInfo.NumberGroupSizes = new int[1] { 3 };
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 == 0)
					{
						num2 = 1;
					}
					continue;
				case 2:
					numberFormatInfo.NegativeInfinitySymbol = DicSingleton.gE3WbyDVW(0x6E29C0C0 ^ 0x6E29A080);
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 == 0)
					{
						num2 = 2;
					}
					continue;
				case 15:
					numberFormatInfo.NumberDecimalSeparator = DicSingleton.gE3WbyDVW(0x15823EC4 ^ 0x1582719A);
					num2 = 11;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba == 0)
					{
						num2 = 11;
					}
					continue;
				}
				break;
			}
			numberFormatInfo.PositiveInfinitySymbol = DicSingleton.gE3WbyDVW(0x69B67B3A ^ 0x69B61B0E);
			num = 2;
		}
	}

	internal static bool AwakeMerchant()
	{
		return QueryMerchant == null;
	}

	internal static IdentifierInterceptor InstantiateMerchant()
	{
		return QueryMerchant;
	}
}
