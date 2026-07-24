using System;

namespace AzuAnticheat.Internal;

internal sealed class ProxyInterpreter
{
	private int m_ModelInterpreter;

	internal static ProxyInterpreter PrintProducer;

	public int Maximum { get; }

	public ProxyInterpreter(int maximum)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 == 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 0:
				return;
			case 1:
				_AdvisorInterpreter = maximum;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 != 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	public void Increment()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				throw new ParamInterpreter(DicSingleton.gE3WbyDVW(0x3C33E48 ^ 0x3C3B3CC));
			case 1:
				if (TryIncrement())
				{
					return;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public bool TryIncrement()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				return true;
			default:
				m_ModelInterpreter++;
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 != 0)
				{
					num2 = 2;
				}
				break;
			case 1:
				if (m_ModelInterpreter >= Maximum)
				{
					return false;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4e61b266153f422fa6c595cfef4d40d3 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public void Decrement()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				return;
			case 3:
				throw new InvalidOperationException(DicSingleton.gE3WbyDVW(0x1C9EFC64 ^ 0x1C9E71A8));
			default:
				m_ModelInterpreter--;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 == 0)
				{
					num2 = 2;
				}
				break;
			case 1:
				if (m_ModelInterpreter != 0)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 3;
			}
		}
	}

	internal static bool CompareProducer()
	{
		return PrintProducer == null;
	}

	internal static ProxyInterpreter CloneProducer()
	{
		return PrintProducer;
	}
}
