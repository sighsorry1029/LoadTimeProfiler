using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class WrapperReader
{
	[CompilerGenerated]
	private readonly int m_ServerReader;

	[CompilerGenerated]
	private readonly int m_AlgoReader;

	[CompilerGenerated]
	private bool m_CreatorReader;

	[CompilerGenerated]
	private readonly bool m_DatabaseReader;

	public static readonly WrapperReader _ErrorReader;

	private static WrapperReader FlushService;

	public int BestIndent
	{
		[CompilerGenerated]
		get
		{
			return m_ServerReader;
		}
	}

	public int BestWidth
	{
		[CompilerGenerated]
		get
		{
			return m_AlgoReader;
		}
	}

	public bool IsCanonical { get; }

	public bool SkipAnchorName
	{
		[CompilerGenerated]
		get
		{
			return m_CreatorReader;
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
					m_CreatorReader = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3a460cd74a4c809e0f755964f2077b == 0)
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

	public int MaxSimpleKeyLength { get; }

	public bool IndentSequences
	{
		[CompilerGenerated]
		get
		{
			return m_DatabaseReader;
		}
	}

	public WrapperReader()
	{
		GetterIssuer.DeleteInitializer();
		m_ServerReader = 2;
		m_AlgoReader = int.MaxValue;
		_PrinterReader = 1024;
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public WrapperReader(int bestIndent, int bestWidth, bool isCanonical, int maxSimpleKeyLength, bool skipAnchorName = false, bool indentSequences = false)
	{
		GetterIssuer.DeleteInitializer();
		m_ServerReader = 2;
		m_AlgoReader = int.MaxValue;
		_PrinterReader = 1024;
		base._002Ector();
		int num = 5;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 == 0)
		{
			num = 5;
		}
		while (true)
		{
			switch (num)
			{
			default:
				throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(0x23D015CA ^ 0x23D06826), DicSingleton.gE3WbyDVW(0x47C77AB8 ^ 0x47C704BA));
			case 12:
				if (maxSimpleKeyLength < 0)
				{
					num = 9;
					break;
				}
				m_ServerReader = bestIndent;
				num = 4;
				break;
			case 10:
				m_DatabaseReader = indentSequences;
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 != 0)
				{
					num = 1;
				}
				break;
			case 11:
				SkipAnchorName = skipAnchorName;
				num = 10;
				break;
			case 4:
				m_AlgoReader = bestWidth;
				num = 8;
				break;
			case 8:
				_ImporterReader = isCanonical;
				num = 7;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
				{
					num = 2;
				}
				break;
			case 7:
				_PrinterReader = maxSimpleKeyLength;
				num = 11;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 == 0)
				{
					num = 11;
				}
				break;
			case 1:
				return;
			case 5:
				if (bestIndent < 2)
				{
					num = 6;
					break;
				}
				goto case 2;
			case 2:
				if (bestIndent > 9)
				{
					num = 3;
					break;
				}
				if (bestWidth > bestIndent * 2)
				{
					num = 12;
					break;
				}
				goto default;
			case 9:
				throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(0x554A128B ^ 0x554A6CE9), DicSingleton.gE3WbyDVW(-823738529 ^ -823737899));
			case 3:
			case 6:
				throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(0x270E0638 ^ 0x270E7B4E), DicSingleton.gE3WbyDVW(-1741204886 ^ -1741213724));
			}
		}
	}

	public WrapperReader WithBestIndent(int bestIndent)
	{
		return new WrapperReader(bestIndent, BestWidth, IsCanonical, MaxSimpleKeyLength, SkipAnchorName);
	}

	public WrapperReader WithBestWidth(int bestWidth)
	{
		return new WrapperReader(BestIndent, bestWidth, IsCanonical, MaxSimpleKeyLength, SkipAnchorName);
	}

	public WrapperReader WithMaxSimpleKeyLength(int maxSimpleKeyLength)
	{
		return new WrapperReader(BestIndent, BestWidth, IsCanonical, maxSimpleKeyLength, SkipAnchorName);
	}

	public WrapperReader Canonical()
	{
		return new WrapperReader(BestIndent, BestWidth, isCanonical: true, MaxSimpleKeyLength, SkipAnchorName);
	}

	public WrapperReader WithoutAnchorName()
	{
		return new WrapperReader(BestIndent, BestWidth, IsCanonical, MaxSimpleKeyLength, skipAnchorName: true);
	}

	public WrapperReader WithIndentedSequences()
	{
		return new WrapperReader(BestIndent, BestWidth, IsCanonical, MaxSimpleKeyLength, SkipAnchorName, indentSequences: true);
	}

	static WrapperReader()
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 2:
				GetterIssuer.DeleteInitializer();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 == 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				_ErrorReader = new WrapperReader();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal static bool DestroyService()
	{
		return FlushService == null;
	}

	internal static WrapperReader ComputeService()
	{
		return FlushService;
	}
}
