using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal readonly struct TestsInterpreter : IEquatable<TestsInterpreter>, IComparable<TestsInterpreter>, IComparable
{
	public static readonly TestsInterpreter _InitializerInterpreter;

	[CompilerGenerated]
	private readonly int m_PageInterpreter;

	private static object ResolveConsumer;

	public int Index
	{
		[CompilerGenerated]
		get
		{
			return m_PageInterpreter;
		}
	}

	public int Line { get; }

	public int Column { get; }

	public TestsInterpreter(int index, int line, int column)
	{
		GetterIssuer.DeleteInitializer();
		if (index < 0)
		{
			ProcessAttribute.ThrowArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(-1059662249 ^ -1059694675), DicSingleton.gE3WbyDVW(-1829625923 ^ -1829593675));
		}
		if (line < 1)
		{
			ProcessAttribute.ThrowArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(-1735703950 ^ -1735671786), DicSingleton.gE3WbyDVW(-34102588 ^ -34135884));
		}
		if (column < 1)
		{
			ProcessAttribute.ThrowArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(0x4E8C8248 ^ 0x4E8C008C), DicSingleton.gE3WbyDVW(-1133601918 ^ -1133635242));
		}
		m_PageInterpreter = index;
		_ParserInterpreter = line;
		_RequestInterpreter = column;
	}

	public override string ToString()
	{
		return string.Format(DicSingleton.gE3WbyDVW(0x55F5513C ^ 0x55F5D210), Line, Column, Index);
	}

	public override bool Equals(object? obj)
	{
		return Equals((TestsInterpreter)(obj ?? ((object)_InitializerInterpreter)));
	}

	public bool Equals(TestsInterpreter other)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (Index == other.Index)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 == 0)
					{
						num2 = 0;
					}
					continue;
				}
				break;
			default:
				if (Line == other.Line)
				{
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 == 0)
					{
						num2 = 2;
					}
					continue;
				}
				break;
			case 2:
				return Column == other.Column;
			}
			break;
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = 1;
		int num2 = num;
		int index = default(int);
		while (true)
		{
			switch (num2)
			{
			case 1:
				index = Index;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 != 0)
				{
					num2 = 0;
				}
				break;
			default:
				return IndexerInterpreter.CombineHashCodes(index.GetHashCode(), IndexerInterpreter.CombineHashCodes(Line.GetHashCode(), Column.GetHashCode()));
			}
		}
	}

	public int CompareTo(object? obj)
	{
		return CompareTo((TestsInterpreter)(obj ?? ((object)_InitializerInterpreter)));
	}

	public int CompareTo(TestsInterpreter other)
	{
		int num = 3;
		int num2 = num;
		int num4 = default(int);
		int num3 = default(int);
		while (true)
		{
			switch (num2)
			{
			case 3:
				num4 = Line;
				num2 = 2;
				break;
			case 2:
				num3 = num4.CompareTo(other.Line);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0a707bb791e14c9e9a3ee77696a896b0 != 0)
				{
					num2 = 1;
				}
				break;
			case 5:
				num4 = Column;
				num2 = 4;
				break;
			case 4:
				num3 = num4.CompareTo(other.Column);
				num2 = 6;
				break;
			case 1:
				if (num3 != 0)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 != 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 5;
			default:
				return num3;
			}
		}
	}

	static TestsInterpreter()
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 0:
				return;
			case 2:
				GetterIssuer.DeleteInitializer();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 == 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				_InitializerInterpreter = new TestsInterpreter(0, 1, 1);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool DefineConsumer()
	{
		return ResolveConsumer == null;
	}

	internal static object IncludeConsumer()
	{
		return ResolveConsumer;
	}
}
