using System;
using System.Diagnostics;
using System.IO;

namespace AzuAnticheat.Internal;

[DebuggerStepThrough]
internal sealed class ProductInterpreter : MethodInterpreter
{
	private readonly TextReader registryInterpreter;

	private readonly char[] m_StateInterpreter;

	private readonly int valueInterpreter;

	private readonly int decoratorInterpreter;

	private int broadcasterInterpreter;

	private int workerInterpreter;

	private int m_TaskInterpreter;

	private bool m_UtilsInterpreter;

	private static ProductInterpreter ConnectConsumer;

	public bool EndOfInput
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
					if (m_UtilsInterpreter)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 != 0)
						{
							num2 = 0;
						}
						break;
					}
					return false;
				default:
					return m_TaskInterpreter == 0;
				}
			}
		}
	}

	public ProductInterpreter(TextReader input, int capacity)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 5;
		while (true)
		{
			switch (num)
			{
			default:
				m_StateInterpreter = new char[capacity * 2];
				num = 2;
				break;
			case 3:
				valueInterpreter = capacity;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4a2885c39dcc4cf1a32db39a2ed578f0 == 0)
				{
					num = 0;
				}
				break;
			case 5:
				if (capacity < 1)
				{
					num = 6;
					break;
				}
				if (!WrapperAttribute.IsPowerOfTwo(capacity))
				{
					num = 4;
					break;
				}
				registryInterpreter = input ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-2103041941 ^ -2103009093));
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 == 0)
				{
					num = 3;
				}
				break;
			case 2:
				decoratorInterpreter = capacity * 2 - 1;
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
				{
					num = 0;
				}
				break;
			case 6:
				throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(--1509395337 ^ 0x59F70BBD), DicSingleton.gE3WbyDVW(-293474990 ^ -293507814));
			case 1:
				return;
			case 4:
				throw new ArgumentException(DicSingleton.gE3WbyDVW(0x540450D2 ^ 0x5404D05A), DicSingleton.gE3WbyDVW(0x6BAF1854 ^ 0x6BAF9860));
			}
		}
	}

	private int GetIndexForOffset(int offset)
	{
		return (broadcasterInterpreter + offset) & decoratorInterpreter;
	}

	public char Peek(int offset)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 3:
				return m_StateInterpreter[(broadcasterInterpreter + offset) & decoratorInterpreter];
			case 4:
				FillBuffer();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 == 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				if (offset < m_TaskInterpreter)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 == 0)
					{
						num2 = 1;
					}
					break;
				}
				goto case 4;
			default:
				if (offset >= m_TaskInterpreter)
				{
					return '\0';
				}
				num2 = 3;
				break;
			}
		}
	}

	public void Cache(int length)
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
				FillBuffer();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			case 2:
				if (length < m_TaskInterpreter)
				{
					return;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4e61b266153f422fa6c595cfef4d40d3 == 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	private void FillBuffer()
	{
		int num = 13;
		int num3 = default(int);
		int num4 = default(int);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 3:
					return;
				case 8:
					if (num3 > 0)
					{
						num2 = 4;
						break;
					}
					goto case 7;
				case 2:
				case 4:
					num4 = registryInterpreter.Read(m_StateInterpreter, workerInterpreter, num3);
					num2 = 6;
					break;
				case 11:
					m_TaskInterpreter += num4;
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_575e6bd686b54d028cdc3fc324b58a39 != 0)
					{
						num2 = 8;
					}
					break;
				default:
					workerInterpreter += num4;
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 != 0)
					{
						num2 = 11;
					}
					break;
				case 7:
					if (workerInterpreter != m_StateInterpreter.Length)
					{
						return;
					}
					goto end_IL_0012;
				case 13:
					if (m_UtilsInterpreter)
					{
						num2 = 12;
						break;
					}
					num3 = valueInterpreter;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 != 0)
					{
						num2 = 2;
					}
					break;
				case 6:
					if (num4 != 0)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 == 0)
						{
							num2 = 1;
						}
						break;
					}
					goto case 10;
				case 10:
					m_UtilsInterpreter = true;
					num2 = 5;
					break;
				case 12:
					return;
				case 5:
					return;
				case 1:
					num3 -= num4;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 != 0)
					{
						num2 = 0;
					}
					break;
				case 9:
					workerInterpreter = 0;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb != 0)
					{
						num2 = 3;
					}
					break;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 9;
		}
	}

	public void Skip(int length)
	{
		int num = 6;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 0:
				return;
			case 3:
				if (length <= valueInterpreter)
				{
					num2 = 2;
					break;
				}
				goto case 1;
			case 1:
			case 5:
				throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(-1891833728 ^ -1891866530), DicSingleton.gE3WbyDVW(-34102588 ^ -34135510));
			case 2:
				broadcasterInterpreter = GetIndexForOffset(length);
				num2 = 4;
				break;
			case 4:
				m_TaskInterpreter -= length;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 != 0)
				{
					num2 = 0;
				}
				break;
			case 6:
				if (length < 1)
				{
					num2 = 5;
					break;
				}
				goto case 3;
			}
		}
	}

	internal static bool StartConsumer()
	{
		return ConnectConsumer == null;
	}

	internal static ProductInterpreter RemoveConsumer()
	{
		return ConnectConsumer;
	}
}
