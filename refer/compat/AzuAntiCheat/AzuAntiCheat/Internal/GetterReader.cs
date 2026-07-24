using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class GetterReader
{
	[CompilerGenerated]
	private int _CodeReader;

	[CompilerGenerated]
	private int _IndexerReader;

	[CompilerGenerated]
	private int m_MockReader;

	private static GetterReader LogoutService;

	public int Index
	{
		[CompilerGenerated]
		get
		{
			return _CodeReader;
		}
		[CompilerGenerated]
		private set
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
					_CodeReader = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af != 0)
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

	public int Line
	{
		[CompilerGenerated]
		get
		{
			return _IndexerReader;
		}
		[CompilerGenerated]
		private set
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
					_IndexerReader = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba == 0)
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

	public int LineOffset
	{
		[CompilerGenerated]
		get
		{
			return m_MockReader;
		}
		[CompilerGenerated]
		private set
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
					m_MockReader = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public GetterReader()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e != 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 1:
				return;
			}
			Line = 1;
			num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 != 0)
			{
				num = 1;
			}
		}
	}

	public GetterReader(GetterReader cursor)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e != 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			default:
				Line = cursor.Line;
				num = 3;
				break;
			case 2:
				return;
			case 3:
				LineOffset = cursor.LineOffset;
				num = 2;
				break;
			case 1:
				Index = cursor.Index;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 != 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	public QueueReader Mark()
	{
		return new QueueReader(Index, Line, LineOffset + 1);
	}

	public void Skip()
	{
		int num = 4;
		int num2 = num;
		int num3 = default(int);
		while (true)
		{
			switch (num2)
			{
			case 3:
				Index = num3 + 1;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 == 0)
				{
					num2 = 0;
				}
				break;
			case 1:
				return;
			case 4:
				num3 = Index;
				num2 = 3;
				break;
			case 2:
				LineOffset = num3 + 1;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 == 0)
				{
					num2 = 1;
				}
				break;
			default:
				num3 = LineOffset;
				num2 = 2;
				break;
			}
		}
	}

	public void SkipLineByOffset(int offset)
	{
		int num = 2;
		int num2 = num;
		int line = default(int);
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 3:
				LineOffset = 0;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e == 0)
				{
					num2 = 0;
				}
				break;
			case 4:
				Line = line + 1;
				num2 = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 == 0)
				{
					num2 = 2;
				}
				break;
			case 0:
				return;
			case 2:
				Index += offset;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 != 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				line = Line;
				num2 = 4;
				break;
			}
		}
	}

	public void ForceSkipLineAfterNonBreak()
	{
		int num = 2;
		int num2 = num;
		int line = default(int);
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 3:
				Line = line + 1;
				num2 = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba != 0)
				{
					num2 = 1;
				}
				break;
			case 2:
				if (LineOffset != 0)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c == 0)
					{
						num2 = 1;
					}
					break;
				}
				return;
			case 4:
				LineOffset = 0;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
				{
					num2 = 0;
				}
				break;
			case 1:
				line = Line;
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 == 0)
				{
					num2 = 3;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal static bool CountService()
	{
		return LogoutService == null;
	}

	internal static GetterReader SetService()
	{
		return LogoutService;
	}
}
