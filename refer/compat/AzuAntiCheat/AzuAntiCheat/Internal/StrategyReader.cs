using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class StrategyReader : AdvisorReader
{
	private readonly TextReader _ProcessorReader;

	private readonly char[] _InfoReader;

	private readonly int m_DicReader;

	private readonly int _ParamsReader;

	private int poolReader;

	private int _DescriptorReader;

	private int m_DispatcherReader;

	private bool m_ListReader;

	private static StrategyReader RegisterError;

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
				default:
					return m_DispatcherReader == 0;
				case 1:
					if (!m_ListReader)
					{
						return false;
					}
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public StrategyReader(TextReader input, int capacity)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 2;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d5c0c185d7b1430b897cb64adc93b81c != 0)
		{
			num = 7;
		}
		while (true)
		{
			switch (num)
			{
			case 2:
				m_DicReader = capacity;
				num = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f == 0)
				{
					num = 2;
				}
				break;
			case 3:
				_InfoReader = new char[capacity * 2];
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 != 0)
				{
					num = 0;
				}
				break;
			case 1:
				throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(-1398029315 ^ -1398062135), DicSingleton.gE3WbyDVW(0xC23E82C ^ 0xC236864));
			case 4:
				if (!SingletonReader.IsPowerOfTwo(capacity))
				{
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab == 0)
					{
						num = 5;
					}
					break;
				}
				_ProcessorReader = input ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x540450D2 ^ 0x5404D002));
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 == 0)
				{
					num = 2;
				}
				break;
			case 6:
				return;
			default:
				_ParamsReader = capacity * 2 - 1;
				num = 6;
				break;
			case 7:
				if (capacity >= 1)
				{
					num = 4;
					break;
				}
				goto case 1;
			case 5:
				throw new ArgumentException(DicSingleton.gE3WbyDVW(-1880453928 ^ -1880486832), DicSingleton.gE3WbyDVW(-1385030784 ^ -1384997964));
			}
		}
	}

	private int GetIndexForOffset(int offset)
	{
		return (poolReader + offset) & _ParamsReader;
	}

	public char Peek(int offset)
	{
		int num = 5;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				return _InfoReader[(poolReader + offset) & _ParamsReader];
			case 3:
				return '\0';
			case 1:
			case 4:
				if (offset >= m_DispatcherReader)
				{
					num2 = 3;
					break;
				}
				goto case 2;
			default:
				FillBuffer();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4a2885c39dcc4cf1a32db39a2ed578f0 == 0)
				{
					num2 = 1;
				}
				break;
			case 5:
				if (offset < m_DispatcherReader)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 != 0)
					{
						num2 = 4;
					}
					break;
				}
				goto default;
			}
		}
	}

	public void Cache(int length)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (length >= m_DispatcherReader)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f == 0)
					{
						num2 = 0;
					}
					break;
				}
				return;
			case 2:
				return;
			default:
				FillBuffer();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c2b9915913b8461884afdca5d98855ec == 0)
				{
					num2 = 2;
				}
				break;
			}
		}
	}

	private void FillBuffer()
	{
		int num = 11;
		int num3 = default(int);
		int num4 = default(int);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 1:
					break;
				case 9:
					num3 = _ProcessorReader.Read(_InfoReader, _DescriptorReader, num4);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 != 0)
					{
						num2 = 0;
					}
					continue;
				case 12:
					if (num4 <= 0)
					{
						num2 = 8;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c != 0)
						{
							num2 = 7;
						}
						continue;
					}
					goto case 9;
				default:
					if (num3 == 0)
					{
						num2 = 7;
						continue;
					}
					num4 -= num3;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c == 0)
					{
						num2 = 1;
					}
					continue;
				case 5:
					_DescriptorReader = 0;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd == 0)
					{
						num2 = 2;
					}
					continue;
				case 7:
					m_ListReader = true;
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 != 0)
					{
						num2 = 2;
					}
					continue;
				case 2:
					return;
				case 8:
					if (_DescriptorReader != _InfoReader.Length)
					{
						return;
					}
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e == 0)
					{
						num2 = 5;
					}
					continue;
				case 6:
					return;
				case 11:
					if (!m_ListReader)
					{
						num2 = 10;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d5c0c185d7b1430b897cb64adc93b81c == 0)
						{
							num2 = 0;
						}
						continue;
					}
					return;
				case 4:
					return;
				case 10:
					num4 = m_DicReader;
					num2 = 9;
					continue;
				case 3:
					m_DispatcherReader += num3;
					num2 = 12;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 == 0)
					{
						num2 = 9;
					}
					continue;
				}
				break;
			}
			_DescriptorReader += num3;
			num = 3;
		}
	}

	public void Skip(int length)
	{
		int num = 6;
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 6:
					if (length < 1)
					{
						num2 = 5;
						continue;
					}
					goto default;
				case 3:
				case 5:
					throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(0x5A1B57A3 ^ 0x5A1BD77D), DicSingleton.gE3WbyDVW(-1891833728 ^ -1891866514));
				case 1:
					poolReader = GetIndexForOffset(length);
					num2 = 4;
					continue;
				case 2:
					return;
				case 4:
					break;
				default:
					if (length <= m_DicReader)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 == 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 3;
				}
				break;
			}
			m_DispatcherReader -= length;
			num = 2;
		}
	}

	internal static bool SetupError()
	{
		return RegisterError == null;
	}

	internal static StrategyReader SelectError()
	{
		return RegisterError;
	}
}
