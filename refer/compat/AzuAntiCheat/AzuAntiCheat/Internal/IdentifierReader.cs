using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class IdentifierReader<T> where T : class, AdvisorReader
{
	[CompilerGenerated]
	private readonly T tokenReader;

	internal static object ViewService;

	public T Buffer
	{
		[CompilerGenerated]
		get
		{
			return tokenReader;
		}
	}

	public bool EndOfInput => Buffer.EndOfInput;

	public IdentifierReader(T buffer)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		tokenReader = buffer ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1244021215 ^ -1244018981));
	}

	public char Peek(int offset)
	{
		return Buffer.Peek(offset);
	}

	public void Skip(int length)
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
				Buffer.Skip(length);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public bool IsAlphaNumericDashOrUnderscore(int offset = 0)
	{
		int num = 5;
		int num2 = num;
		char c = default(char);
		while (true)
		{
			switch (num2)
			{
			case 6:
				if (c > 'Z')
				{
					num2 = 8;
					break;
				}
				goto default;
			case 10:
			case 13:
				if (c < 'A')
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_259acdc10a3c4fba8a4f129ba5346de2 == 0)
					{
						num2 = 2;
					}
					break;
				}
				goto case 6;
			case 12:
				if (c <= '9')
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 10;
			case 3:
				return c == '-';
			default:
				return true;
			case 2:
			case 8:
				if (c < 'a')
				{
					num2 = 7;
					break;
				}
				goto case 9;
			case 5:
				c = Buffer.Peek(offset);
				num2 = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab != 0)
				{
					num2 = 0;
				}
				break;
			case 1:
			case 7:
				if (c != '_')
				{
					num2 = 3;
					break;
				}
				goto default;
			case 4:
				if (c < '0')
				{
					num2 = 10;
					break;
				}
				goto case 12;
			case 9:
				if (c <= 'z')
				{
					num2 = 11;
					break;
				}
				goto case 1;
			}
		}
	}

	public bool IsAscii(int offset = 0)
	{
		return Buffer.Peek(offset) <= '\u007f';
	}

	public bool IsPrintable(int offset = 0)
	{
		int num = 9;
		char c = default(char);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 13:
					if (c > '~')
					{
						num2 = 6;
						break;
					}
					goto IL_0182;
				case 10:
					if (c > '\ud7ff')
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d == 0)
						{
							num2 = 0;
						}
						break;
					}
					goto IL_0182;
				case 4:
					if (c != '\n')
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_23f9d18f43004f488662f38dd306f6ec == 0)
						{
							num2 = 7;
						}
						break;
					}
					goto IL_0182;
				case 9:
					c = Buffer.Peek(offset);
					num2 = 8;
					break;
				case 3:
					if (c < ' ')
					{
						num2 = 2;
						break;
					}
					goto case 13;
				case 2:
				case 6:
					if (c != '\u0085')
					{
						num2 = 9;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 != 0)
						{
							num2 = 11;
						}
						break;
					}
					goto IL_0182;
				case 8:
					if (c != '\t')
					{
						goto end_IL_0012;
					}
					goto IL_0182;
				case 11:
					if (c < '\u00a0')
					{
						num2 = 5;
						break;
					}
					goto case 10;
				case 7:
					if (c != '\r')
					{
						num2 = 3;
						break;
					}
					goto IL_0182;
				case 12:
					return c <= '\ufffd';
				case 1:
					return false;
				default:
					{
						if (c < '\ue000')
						{
							num2 = 1;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 == 0)
							{
								num2 = 0;
							}
							break;
						}
						goto case 12;
					}
					IL_0182:
					return true;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 4;
		}
	}

	public bool IsDigit(int offset = 0)
	{
		int num = 1;
		int num2 = num;
		char c = default(char);
		while (true)
		{
			switch (num2)
			{
			case 1:
				c = Buffer.Peek(offset);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 == 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				return c <= '9';
			case 3:
				return false;
			default:
				if (c < '0')
				{
					num2 = 3;
					break;
				}
				goto case 2;
			}
		}
	}

	public int AsDigit(int offset = 0)
	{
		return Buffer.Peek(offset) - 48;
	}

	public bool IsHex(int offset)
	{
		int num = 4;
		int num2 = num;
		char c = default(char);
		while (true)
		{
			switch (num2)
			{
			case 6:
				if (c <= 'F')
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 != 0)
					{
						num2 = 1;
					}
					continue;
				}
				break;
			case 8:
				return c <= 'f';
			case 1:
				return true;
			case 3:
				if (c >= '0')
				{
					num2 = 7;
					continue;
				}
				goto default;
			default:
				if (c < 'A')
				{
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 == 0)
					{
						num2 = 2;
					}
					continue;
				}
				goto case 6;
			case 4:
				c = Buffer.Peek(offset);
				num2 = 3;
				continue;
			case 7:
				if (c > '9')
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 != 0)
					{
						num2 = 0;
					}
					continue;
				}
				goto case 1;
			case 2:
			case 5:
				break;
			}
			if (c < 'a')
			{
				break;
			}
			num2 = 8;
		}
		return false;
	}

	public int AsHex(int offset)
	{
		int num = 1;
		int num2 = num;
		char c = default(char);
		while (true)
		{
			switch (num2)
			{
			case 4:
				return c - 48;
			case 3:
				if (c > 'F')
				{
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec != 0)
					{
						num2 = 1;
					}
					break;
				}
				goto case 2;
			case 2:
				return c - 65 + 10;
			case 5:
				return c - 97 + 10;
			default:
				if (c > '9')
				{
					num2 = 3;
					break;
				}
				goto case 4;
			case 1:
				c = Buffer.Peek(offset);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public bool IsSpace(int offset = 0)
	{
		return Check(' ', offset);
	}

	public bool IsZero(int offset = 0)
	{
		return Check('\0', offset);
	}

	public bool IsTab(int offset = 0)
	{
		return Check('\t', offset);
	}

	public bool IsWhite(int offset = 0)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (IsSpace(offset))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 != 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 2;
			case 2:
				return IsTab(offset);
			default:
				return true;
			}
		}
	}

	public bool IsBreak(int offset = 0)
	{
		return Check(DicSingleton.gE3WbyDVW(0x21AFFB2B ^ 0x21AF8221), offset);
	}

	public bool IsCrLf(int offset = 0)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				return Check('\n', offset + 1);
			default:
				return false;
			case 1:
				if (!Check('\r', offset))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 2;
			}
		}
	}

	public bool IsBreakOrZero(int offset = 0)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return IsZero(offset);
			case 1:
				return true;
			case 2:
				if (IsBreak(offset))
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f011663d64054593978962dcc3a5ec1a == 0)
					{
						num2 = 1;
					}
					break;
				}
				goto default;
			}
		}
	}

	public bool IsWhiteBreakOrZero(int offset = 0)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				return IsBreakOrZero(offset);
			default:
				return true;
			case 1:
				if (IsWhite(offset))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 != 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 2;
			}
		}
	}

	public bool Check(char expected, int offset = 0)
	{
		return Buffer.Peek(offset) == expected;
	}

	public bool Check(string expectedCharacters, int offset = 0)
	{
		int num = 1;
		int num2 = num;
		char value = default(char);
		while (true)
		{
			switch (num2)
			{
			case 1:
				value = Buffer.Peek(offset);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return expectedCharacters.IndexOf(value) != -1;
			}
		}
	}

	internal static bool InitService()
	{
		return ViewService == null;
	}

	internal static object PatchService()
	{
		return ViewService;
	}
}
