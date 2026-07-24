using System;
using System.Diagnostics;

namespace AzuAnticheat.Internal;

[DebuggerStepThrough]
internal sealed class InfoAttribute<T> where T : class, MethodInterpreter
{
	private static object PublishConsumer;

	public T Buffer { get; }

	public bool EndOfInput => Buffer.EndOfInput;

	public InfoAttribute(T buffer)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		_DicAttribute = buffer ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1580624393 ^ -1580602099));
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
			case 1:
				Buffer.Skip(length);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public bool IsAlphaNumericDashOrUnderscore(int offset = 0)
	{
		int num = 10;
		char c = default(char);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 3:
					if (c > '9')
					{
						num2 = 5;
						continue;
					}
					break;
				case 10:
					c = Buffer.Peek(offset);
					num2 = 9;
					continue;
				case 4:
				case 5:
					if (c >= 'A')
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc != 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 8;
				case 8:
					if (c < 'a')
					{
						goto end_IL_0012;
					}
					goto case 6;
				case 6:
					if (c <= 'z')
					{
						num2 = 2;
						continue;
					}
					goto default;
				case 1:
					if (c > 'Z')
					{
						num2 = 8;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 == 0)
						{
							num2 = 5;
						}
						continue;
					}
					break;
				case 9:
					if (c < '0')
					{
						num2 = 4;
						continue;
					}
					goto case 3;
				default:
					if (c != '_')
					{
						num2 = 7;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 != 0)
						{
							num2 = 7;
						}
						continue;
					}
					break;
				case 7:
					return c == '-';
				case 2:
					break;
				}
				return true;
				continue;
				end_IL_0012:
				break;
			}
			num = 11;
		}
	}

	public bool IsAscii(int offset = 0)
	{
		return Buffer.Peek(offset) <= '\u007f';
	}

	public bool IsPrintable(int offset = 0)
	{
		int num = 2;
		int num2 = num;
		char c = default(char);
		while (true)
		{
			switch (num2)
			{
			default:
				if (c <= '~')
				{
					num2 = 4;
					break;
				}
				goto case 5;
			case 3:
				if (c >= '\ue000')
				{
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec == 0)
					{
						num2 = 3;
					}
					break;
				}
				return false;
			case 8:
				return c <= '\ufffd';
			case 4:
				return true;
			case 2:
				c = Buffer.Peek(offset);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7e7ae6cc25e34646baea4e1c2c087e7a == 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				if (c != '\t')
				{
					num2 = 12;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 != 0)
					{
						num2 = 1;
					}
					break;
				}
				goto case 4;
			case 6:
				if (c >= '\u00a0')
				{
					num2 = 7;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 != 0)
					{
						num2 = 7;
					}
					break;
				}
				goto case 3;
			case 12:
				if (c != '\n')
				{
					num2 = 10;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 4;
			case 5:
			case 11:
				if (c != '\u0085')
				{
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_91887e48b8104e7da08b48f73b607337 == 0)
					{
						num2 = 4;
					}
					break;
				}
				goto case 4;
			case 10:
				if (c != '\r')
				{
					num2 = 9;
					break;
				}
				goto case 4;
			case 9:
				if (c < ' ')
				{
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto default;
			case 7:
				if (c > '\ud7ff')
				{
					num2 = 3;
					break;
				}
				goto case 4;
			}
		}
	}

	public bool IsDigit(int offset = 0)
	{
		int num = 2;
		int num2 = num;
		char c = default(char);
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (c < '0')
				{
					num2 = 3;
					break;
				}
				goto default;
			default:
				return c <= '9';
			case 3:
				return false;
			case 2:
				c = Buffer.Peek(offset);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 == 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	public int AsDigit(int offset = 0)
	{
		return Buffer.Peek(offset) - 48;
	}

	public bool IsHex(int offset)
	{
		int num = 2;
		int num2 = num;
		char c = default(char);
		while (true)
		{
			switch (num2)
			{
			case 10:
				if (c <= 'F')
				{
					num2 = 4;
					break;
				}
				goto case 6;
			case 3:
			case 9:
				if (c < 'A')
				{
					num2 = 7;
					break;
				}
				goto case 10;
			case 6:
			case 7:
				if (c < 'a')
				{
					num2 = 5;
					break;
				}
				goto case 11;
			case 11:
				return c <= 'f';
			case 5:
				return false;
			default:
				return true;
			case 8:
				if (c <= '9')
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae50b6e347494ff2973fbc64d1fc9236 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 3;
			case 1:
				if (c < '0')
				{
					num2 = 3;
					break;
				}
				goto case 8;
			case 2:
				c = Buffer.Peek(offset);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 == 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	public int AsHex(int offset)
	{
		int num = 2;
		int num2 = num;
		char c = default(char);
		while (true)
		{
			switch (num2)
			{
			default:
				return c - 48;
			case 3:
				if (c > 'F')
				{
					num2 = 5;
					break;
				}
				goto case 4;
			case 4:
				return c - 65 + 10;
			case 5:
				return c - 97 + 10;
			case 2:
				c = Buffer.Peek(offset);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 == 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				if (c > '9')
				{
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 != 0)
					{
						num2 = 2;
					}
					break;
				}
				goto default;
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
			default:
				return IsTab(offset);
			case 1:
				if (IsSpace(offset))
				{
					return true;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_49107028423047bfbf9c33e5a2ab8cf8 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public bool IsBreak(int offset = 0)
	{
		return Check(DicSingleton.gE3WbyDVW(-1398029315 ^ -1398031625), offset);
	}

	public bool IsCrLf(int offset = 0)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (Check('\r', offset))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4fda3adbb4ec45bdb14fe2ef97e570a8 == 0)
					{
						num2 = 0;
					}
					break;
				}
				return false;
			default:
				return Check('\n', offset + 1);
			}
		}
	}

	public bool IsBreakOrZero(int offset = 0)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return IsZero(offset);
			case 1:
				if (IsBreak(offset))
				{
					return true;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 == 0)
				{
					num2 = 0;
				}
				break;
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
			default:
				return IsBreakOrZero(offset);
			case 1:
				if (IsWhite(offset))
				{
					return true;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 == 0)
				{
					num2 = 0;
				}
				break;
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
			default:
				return expectedCharacters.IndexOf(value) != -1;
			case 1:
				value = Buffer.Peek(offset);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool RegisterConsumer()
	{
		return PublishConsumer == null;
	}

	internal static object SetupConsumer()
	{
		return PublishConsumer;
	}
}
