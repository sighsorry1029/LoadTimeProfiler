using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class CandidateFactory : AdvisorReader
{
	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(1)]
	private readonly string expressionFactory;

	[CompilerGenerated]
	private int _ProductFactory;

	internal static CandidateFactory StartError;

	public int Position
	{
		[CompilerGenerated]
		get
		{
			return _ProductFactory;
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
					_ProductFactory = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public int Length => expressionFactory.Length;

	public bool EndOfInput => IsOutside(Position);

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	public CandidateFactory(string value)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d == 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 1:
				expressionFactory = value;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 == 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public char Peek(int offset)
	{
		int num = 2;
		int num2 = num;
		int index = default(int);
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (IsOutside(index))
				{
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto default;
			case 2:
				index = Position + offset;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e != 0)
				{
					num2 = 1;
				}
				break;
			default:
				return expressionFactory[index];
			case 3:
				return '\0';
			}
		}
	}

	private bool IsOutside(int index)
	{
		return index >= expressionFactory.Length;
	}

	public void Skip(int length)
	{
		int num = 3;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 1:
				throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(-1461449777 ^ -1461417199), DicSingleton.gE3WbyDVW(0x33F6A245 ^ 0x33F605C1));
			case 2:
				Position += length;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 != 0)
				{
					num2 = 0;
				}
				break;
			case 3:
				if (length >= 0)
				{
					num2 = 2;
					break;
				}
				goto case 1;
			case 0:
				return;
			}
		}
	}

	internal static bool RemoveError()
	{
		return StartError == null;
	}

	internal static CandidateFactory ResolveError()
	{
		return StartError;
	}
}
