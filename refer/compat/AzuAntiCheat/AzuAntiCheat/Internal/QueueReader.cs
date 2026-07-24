using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
internal sealed class QueueReader : IEquatable<QueueReader>, IComparable<QueueReader>, IComparable
{
	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(1)]
	public static readonly QueueReader m_CollectionReader;

	[CompilerGenerated]
	private readonly int managerReader;

	[CompilerGenerated]
	private readonly int tokenizerReader;

	private static QueueReader ChangeError;

	public int Index
	{
		[CompilerGenerated]
		get
		{
			return managerReader;
		}
	}

	public int Line
	{
		[CompilerGenerated]
		get
		{
			return tokenizerReader;
		}
	}

	public int Column { get; }

	public QueueReader()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 != 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 2:
				_ListenerReader = 1;
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 != 0)
				{
					num = 1;
				}
				break;
			default:
				tokenizerReader = 1;
				num = 2;
				break;
			case 1:
				return;
			}
		}
	}

	public QueueReader(int index, int line, int column)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		if (index < 0)
		{
			throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(-1483531944 ^ -1483499358), DicSingleton.gE3WbyDVW(-1338893851 ^ -1338860563));
		}
		if (line < 1)
		{
			throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(-1389846755 ^ -1389879943), DicSingleton.gE3WbyDVW(0x40385DA3 ^ 0x4038DFD3));
		}
		if (column < 1)
		{
			throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(0xB026CF2 ^ 0xB02EE36), DicSingleton.gE3WbyDVW(-992201216 ^ -992168748));
		}
		managerReader = index;
		tokenizerReader = line;
		_ListenerReader = column;
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	public override string ToString()
	{
		return string.Format(DicSingleton.gE3WbyDVW(--1844849127 ^ 0x6DF6AACB), Line, Column, Index);
	}

	public override bool Equals(object obj)
	{
		return Equals(obj as QueueReader);
	}

	public bool Equals(QueueReader other)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				if (Index == other.Index)
				{
					num2 = 3;
					continue;
				}
				break;
			case 1:
				if (other != null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 == 0)
					{
						num2 = 0;
					}
					continue;
				}
				break;
			case 3:
				if (Line == other.Line)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 == 0)
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return ProxyReader.CombineHashCodes(index.GetHashCode(), ProxyReader.CombineHashCodes(Line.GetHashCode(), Column.GetHashCode()));
			}
		}
	}

	public int CompareTo(object obj)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				if (obj != null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 == 0)
					{
						num2 = 1;
					}
					break;
				}
				goto default;
			default:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x1C9EFC64 ^ 0x1C9E7F0E));
			case 1:
				return CompareTo(obj as QueueReader);
			}
		}
	}

	public int CompareTo(QueueReader other)
	{
		int num = 1;
		int num2 = num;
		int num3 = default(int);
		int num4 = default(int);
		while (true)
		{
			switch (num2)
			{
			case 4:
				num3 = Column;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 == 0)
				{
					num2 = 3;
				}
				break;
			case 6:
				return num4;
			default:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-32559551 ^ -32527051));
			case 2:
				num4 = num3.CompareTo(other.Line);
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 == 0)
				{
					num2 = 5;
				}
				break;
			case 5:
				if (num4 == 0)
				{
					num2 = 4;
					break;
				}
				goto case 6;
			case 3:
				num4 = num3.CompareTo(other.Column);
				num2 = 6;
				break;
			case 1:
				if (other != null)
				{
					num3 = Line;
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 == 0)
					{
						num2 = 2;
					}
				}
				else
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f011663d64054593978962dcc3a5ec1a != 0)
					{
						num2 = 0;
					}
				}
				break;
			}
		}
	}

	static QueueReader()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				m_CollectionReader = new QueueReader();
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac == 0)
				{
					num2 = 2;
				}
				break;
			case 1:
				GetterIssuer.DeleteInitializer();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 == 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				return;
			}
		}
	}

	internal static bool CreateError()
	{
		return ChangeError == null;
	}

	internal static QueueReader TestError()
	{
		return ChangeError;
	}
}
