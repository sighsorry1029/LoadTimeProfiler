using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal class PublisherInvocation
{
	[CompilerGenerated]
	private static readonly PublisherInvocation m_BaseInvocation;

	[CompilerGenerated]
	private NumberFormatInfo prototypeInvocation;

	internal static PublisherInvocation ConnectOrder;

	public static PublisherInvocation Default
	{
		[CompilerGenerated]
		get
		{
			return m_BaseInvocation;
		}
	}

	public NumberFormatInfo NumberFormat
	{
		[CompilerGenerated]
		get
		{
			return prototypeInvocation;
		}
		[CompilerGenerated]
		set
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 1:
					prototypeInvocation = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 == 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}
	}

	public string FormatNumber(object number)
	{
		return Convert.ToString(number, NumberFormat);
	}

	public string FormatNumber(double number)
	{
		return number.ToString(DicSingleton.gE3WbyDVW(0x166FBD ^ 0x16015F), NumberFormat);
	}

	public string FormatNumber(float number)
	{
		return number.ToString(DicSingleton.gE3WbyDVW(0x38262FC9 ^ 0x3826412B), NumberFormat);
	}

	public string FormatBoolean(object boolean)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				return DicSingleton.gE3WbyDVW(-1830690703 ^ -1830715271);
			default:
				return DicSingleton.gE3WbyDVW(0x9000142 ^ 0x9006154);
			case 1:
				if (boolean.Equals(true))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 2;
			}
		}
	}

	public string FormatDateTime(object dateTime)
	{
		int num = 1;
		int num2 = num;
		DateTime dateTime2 = default(DateTime);
		while (true)
		{
			switch (num2)
			{
			default:
				return dateTime2.ToString(DicSingleton.gE3WbyDVW(-833481355 ^ -833456809), CultureInfo.InvariantCulture);
			case 1:
				dateTime2 = (DateTime)dateTime;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public string FormatTimeSpan(object timeSpan)
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return timeSpan2.ToString();
			}
		}
	}

	public PublisherInvocation()
	{
		GetterIssuer.DeleteInitializer();
		prototypeInvocation = new NumberFormatInfo
		{
			CurrencyDecimalSeparator = DicSingleton.gE3WbyDVW(0x270E0638 ^ 0x270E4966),
			CurrencyGroupSeparator = DicSingleton.gE3WbyDVW(-1580624393 ^ -1580605459),
			CurrencyGroupSizes = new int[1] { 3 },
			CurrencySymbol = string.Empty,
			CurrencyDecimalDigits = 99,
			NumberDecimalSeparator = DicSingleton.gE3WbyDVW(-1133601918 ^ -1133587236),
			NumberGroupSeparator = DicSingleton.gE3WbyDVW(-1244021215 ^ -1244007365),
			NumberGroupSizes = new int[1] { 3 },
			NumberDecimalDigits = 99,
			NaNSymbol = DicSingleton.gE3WbyDVW(0x3C33E48 ^ 0x3C35E60),
			PositiveInfinitySymbol = DicSingleton.gE3WbyDVW(-1447578472 ^ -1447570260),
			NegativeInfinitySymbol = DicSingleton.gE3WbyDVW(0x74FC52AF ^ 0x74FC32EF)
		};
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	static PublisherInvocation()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				return;
			case 1:
				GetterIssuer.DeleteInitializer();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 != 0)
				{
					num2 = 0;
				}
				break;
			default:
				m_BaseInvocation = new PublisherInvocation();
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d == 0)
				{
					num2 = 2;
				}
				break;
			}
		}
	}

	internal static bool StartOrder()
	{
		return ConnectOrder == null;
	}

	internal static PublisherInvocation RemoveOrder()
	{
		return ConnectOrder;
	}
}
