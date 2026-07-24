using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class ExceptionInterpreter
{
	[CompilerGenerated]
	private readonly int m_ContextInterpreter;

	[CompilerGenerated]
	private readonly string m_MapperInterpreter;

	[CompilerGenerated]
	private readonly bool m_IdentifierInterpreter;

	[CompilerGenerated]
	private bool tokenInterpreter;

	[CompilerGenerated]
	private readonly int callbackInterpreter;

	public static readonly ExceptionInterpreter m_GetterInterpreter;

	internal static ExceptionInterpreter PatchConsumer;

	public int BestIndent { get; }

	public int BestWidth
	{
		[CompilerGenerated]
		get
		{
			return m_ContextInterpreter;
		}
	}

	public string NewLine
	{
		[CompilerGenerated]
		get
		{
			return m_MapperInterpreter;
		}
	}

	public bool IsCanonical
	{
		[CompilerGenerated]
		get
		{
			return m_IdentifierInterpreter;
		}
	}

	public bool SkipAnchorName
	{
		[CompilerGenerated]
		get
		{
			return tokenInterpreter;
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
					tokenInterpreter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public int MaxSimpleKeyLength
	{
		[CompilerGenerated]
		get
		{
			return callbackInterpreter;
		}
	}

	public bool IndentSequences { get; }

	public ExceptionInterpreter()
	{
		GetterIssuer.DeleteInitializer();
		_ItemInterpreter = 2;
		m_ContextInterpreter = int.MaxValue;
		m_MapperInterpreter = Environment.NewLine;
		callbackInterpreter = 1024;
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public ExceptionInterpreter(int bestIndent, int bestWidth, bool isCanonical, int maxSimpleKeyLength, bool skipAnchorName = false, bool indentSequences = false, string? newLine = null)
	{
		GetterIssuer.DeleteInitializer();
		_ItemInterpreter = 2;
		m_ContextInterpreter = int.MaxValue;
		m_MapperInterpreter = Environment.NewLine;
		callbackInterpreter = 1024;
		base._002Ector();
		if (bestIndent < 2 || bestIndent > 9)
		{
			throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(-1335677307 ^ -1335667725), DicSingleton.gE3WbyDVW(0x5A8BEE ^ 0x5AF660));
		}
		if (bestWidth <= bestIndent * 2)
		{
			throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(0x4097B854 ^ 0x4097C5B8), DicSingleton.gE3WbyDVW(-1338893851 ^ -1338873881));
		}
		if (maxSimpleKeyLength < 0)
		{
			throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(-545065612 ^ -545092842), DicSingleton.gE3WbyDVW(0xB026CF2 ^ 0xB021278));
		}
		_ItemInterpreter = bestIndent;
		m_ContextInterpreter = bestWidth;
		m_IdentifierInterpreter = isCanonical;
		callbackInterpreter = maxSimpleKeyLength;
		SkipAnchorName = skipAnchorName;
		_RulesInterpreter = indentSequences;
		m_MapperInterpreter = newLine ?? Environment.NewLine;
	}

	public ExceptionInterpreter WithBestIndent(int bestIndent)
	{
		return new ExceptionInterpreter(bestIndent, BestWidth, IsCanonical, MaxSimpleKeyLength, SkipAnchorName, IndentSequences, NewLine);
	}

	public ExceptionInterpreter WithBestWidth(int bestWidth)
	{
		return new ExceptionInterpreter(BestIndent, bestWidth, IsCanonical, MaxSimpleKeyLength, SkipAnchorName, IndentSequences, NewLine);
	}

	public ExceptionInterpreter WithMaxSimpleKeyLength(int maxSimpleKeyLength)
	{
		return new ExceptionInterpreter(BestIndent, BestWidth, IsCanonical, maxSimpleKeyLength, SkipAnchorName, IndentSequences, NewLine);
	}

	public ExceptionInterpreter WithNewLine(string newLine)
	{
		return new ExceptionInterpreter(BestIndent, BestWidth, IsCanonical, MaxSimpleKeyLength, SkipAnchorName, IndentSequences, newLine);
	}

	public ExceptionInterpreter Canonical()
	{
		return new ExceptionInterpreter(BestIndent, BestWidth, isCanonical: true, MaxSimpleKeyLength, SkipAnchorName);
	}

	public ExceptionInterpreter WithoutAnchorName()
	{
		return new ExceptionInterpreter(BestIndent, BestWidth, IsCanonical, MaxSimpleKeyLength, skipAnchorName: true, IndentSequences, NewLine);
	}

	public ExceptionInterpreter WithIndentedSequences()
	{
		return new ExceptionInterpreter(BestIndent, BestWidth, IsCanonical, MaxSimpleKeyLength, SkipAnchorName, indentSequences: true, NewLine);
	}

	static ExceptionInterpreter()
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d != 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				m_GetterInterpreter = new ExceptionInterpreter();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal static bool AssetConsumer()
	{
		return PatchConsumer == null;
	}

	internal static ExceptionInterpreter ListConsumer()
	{
		return PatchConsumer;
	}
}
