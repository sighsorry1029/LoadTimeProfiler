using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class SpecificationInterpreter : MethodInterpreter
{
	private readonly string _RefInterpreter;

	[CompilerGenerated]
	private int m_ObserverInterpreter;

	internal static SpecificationInterpreter EnableProducer;

	public int Position
	{
		[CompilerGenerated]
		get
		{
			return m_ObserverInterpreter;
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
					m_ObserverInterpreter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9c47a25d924946efb9e023473a095794 == 0)
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

	public int Length => _RefInterpreter.Length;

	public bool EndOfInput => IsOutside(Position);

	public SpecificationInterpreter(string value)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 == 0)
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
			_RefInterpreter = value;
			num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 != 0)
			{
				num = 0;
			}
		}
	}

	public char Peek(int offset)
	{
		int num = 1;
		int num2 = num;
		int index = default(int);
		while (true)
		{
			switch (num2)
			{
			default:
				if (IsOutside(index))
				{
					num2 = 3;
					break;
				}
				goto case 2;
			case 2:
				return _RefInterpreter[index];
			case 3:
				return '\0';
			case 1:
				index = Position + offset;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	private bool IsOutside(int index)
	{
		return index >= _RefInterpreter.Length;
	}

	public void Skip(int length)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(-1338893851 ^ -1338861253), DicSingleton.gE3WbyDVW(-360128320 ^ -360167612));
			default:
				Position += length;
				num2 = 3;
				break;
			case 3:
				return;
			case 1:
				if (length >= 0)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 2;
			}
		}
	}

	internal static bool SortProducer()
	{
		return EnableProducer == null;
	}

	internal static SpecificationInterpreter InsertProducer()
	{
		return EnableProducer;
	}
}
