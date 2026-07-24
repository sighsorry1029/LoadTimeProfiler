using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[DebuggerStepThrough]
internal sealed class DescriptorAttribute
{
	[CompilerGenerated]
	private int dispatcherAttribute;

	[CompilerGenerated]
	private int m_ListAttribute;

	[CompilerGenerated]
	private int m_QueueAttribute;

	internal static DescriptorAttribute TestConsumer;

	public int Index
	{
		[CompilerGenerated]
		get
		{
			return dispatcherAttribute;
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
					dispatcherAttribute = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public int Line
	{
		[CompilerGenerated]
		get
		{
			return m_ListAttribute;
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
					m_ListAttribute = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public int LineOffset
	{
		[CompilerGenerated]
		get
		{
			return m_QueueAttribute;
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
					m_QueueAttribute = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public DescriptorAttribute()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 == 0)
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
			num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 != 0)
			{
				num = 1;
			}
		}
	}

	public DescriptorAttribute(DescriptorAttribute cursor)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 1:
				Index = cursor.Index;
				num = 2;
				break;
			case 3:
				return;
			default:
				LineOffset = cursor.LineOffset;
				num = 3;
				break;
			case 2:
				Line = cursor.Line;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3aab303a2946368dda3deef055dc93 == 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	public TestsInterpreter Mark()
	{
		return new TestsInterpreter(Index, Line, LineOffset + 1);
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
			default:
				return;
			case 3:
				Index = num3 + 1;
				num2 = 2;
				break;
			case 0:
				return;
			case 4:
				num3 = Index;
				num2 = 3;
				break;
			case 1:
				LineOffset = num3 + 1;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 != 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				num3 = LineOffset;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 != 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	public void SkipLineByOffset(int offset)
	{
		int num = 4;
		int num2 = num;
		int line = default(int);
		while (true)
		{
			switch (num2)
			{
			default:
				Line = line + 1;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d5c0c185d7b1430b897cb64adc93b81c == 0)
				{
					num2 = 1;
				}
				break;
			case 4:
				Index += offset;
				num2 = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 != 0)
				{
					num2 = 3;
				}
				break;
			case 1:
				LineOffset = 0;
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd == 0)
				{
					num2 = 2;
				}
				break;
			case 2:
				return;
			case 3:
				line = Line;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0a707bb791e14c9e9a3ee77696a896b0 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public void ForceSkipLineAfterNonBreak()
	{
		int num = 4;
		int num2 = num;
		int line = default(int);
		while (true)
		{
			switch (num2)
			{
			case 2:
				return;
			case 1:
				Line = line + 1;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				LineOffset = 0;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 != 0)
				{
					num2 = 2;
				}
				break;
			case 4:
				if (LineOffset == 0)
				{
					return;
				}
				num2 = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 == 0)
				{
					num2 = 0;
				}
				break;
			case 3:
				line = Line;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool RunConsumer()
	{
		return TestConsumer == null;
	}

	internal static DescriptorAttribute VerifyConsumer()
	{
		return TestConsumer;
	}
}
