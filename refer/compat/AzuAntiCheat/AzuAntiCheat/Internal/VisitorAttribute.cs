using System;
using System.Text.RegularExpressions;

namespace AzuAnticheat.Internal;

internal struct VisitorAttribute : IEquatable<VisitorAttribute>
{
	public static readonly VisitorAttribute _StubAttribute;

	private static readonly Regex m_PolicyAttribute;

	private readonly string? strategyAttribute;

	private static object ForgotAttribute;

	public string Value
	{
		get
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 1:
				{
					string? text = strategyAttribute;
					if (text == null)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 == 0)
						{
							num2 = 0;
						}
						break;
					}
					return text;
				}
				default:
					throw new InvalidOperationException(DicSingleton.gE3WbyDVW(0x2BC53863 ^ 0x2BC54FB1));
				}
			}
		}
	}

	public bool IsEmpty => strategyAttribute == null;

	public VisitorAttribute(string value)
	{
		GetterIssuer.DeleteInitializer();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c == 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			default:
				throw new ArgumentException(DicSingleton.gE3WbyDVW(--1509395337 ^ 0x59F7F3AF) + value + DicSingleton.gE3WbyDVW(0x940D407 ^ 0x9408123), DicSingleton.gE3WbyDVW(-1891833728 ^ -1891851480));
			case 2:
				if (m_PolicyAttribute.IsMatch(value))
				{
					return;
				}
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4e61b266153f422fa6c595cfef4d40d3 == 0)
				{
					num = 0;
				}
				break;
			case 1:
			{
				strategyAttribute = value ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x1679942F ^ 0x1679DF87));
				int num2 = 2;
				num = num2;
				break;
			}
			}
		}
	}

	public override string ToString()
	{
		int num = 1;
		int num2 = num;
		string text;
		while (true)
		{
			switch (num2)
			{
			case 1:
				text = strategyAttribute;
				if (text != null)
				{
					break;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 != 0)
				{
					num2 = 0;
				}
				continue;
			default:
				text = DicSingleton.gE3WbyDVW(-1466472923 ^ -1466491165);
				break;
			}
			break;
		}
		return text;
	}

	public bool Equals(VisitorAttribute other)
	{
		return object.Equals(strategyAttribute, other.strategyAttribute);
	}

	public override bool Equals(object? obj)
	{
		int num = 1;
		VisitorAttribute other = default(VisitorAttribute);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 2:
					break;
				case 3:
					return Equals(other);
				default:
					return false;
				case 1:
					if (!(obj is VisitorAttribute))
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					break;
				}
				break;
			}
			other = (VisitorAttribute)obj;
			num = 3;
		}
	}

	public override int GetHashCode()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
			{
				string? text = strategyAttribute;
				if (text == null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d == 0)
					{
						num2 = 0;
					}
					break;
				}
				return text.GetHashCode();
			}
			default:
				return 0;
			}
		}
	}

	public static bool operator ==(VisitorAttribute left, VisitorAttribute right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(VisitorAttribute left, VisitorAttribute right)
	{
		return !(left == right);
	}

	public static implicit operator VisitorAttribute(string? value)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (value != null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba != 0)
					{
						num2 = 0;
					}
					break;
				}
				return _StubAttribute;
			default:
				return new VisitorAttribute(value);
			}
		}
	}

	static VisitorAttribute()
	{
		int num = 1;
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 3:
					return;
				case 2:
					break;
				default:
					_StubAttribute = default(VisitorAttribute);
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 != 0)
					{
						num2 = 0;
					}
					continue;
				case 1:
					GetterIssuer.DeleteInitializer();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 == 0)
					{
						num2 = 0;
					}
					continue;
				}
				break;
			}
			m_PolicyAttribute = new Regex(DicSingleton.gE3WbyDVW(0x55F5513C ^ 0x55F529E4), RegexOptions.Compiled);
			num = 3;
		}
	}

	internal static bool RestartAttribute()
	{
		return ForgotAttribute == null;
	}

	internal static object CalculateAttribute()
	{
		return ForgotAttribute;
	}
}
