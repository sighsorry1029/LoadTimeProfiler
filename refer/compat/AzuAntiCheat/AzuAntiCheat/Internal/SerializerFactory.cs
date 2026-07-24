using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal class SerializerFactory : PolicyReader
{
	private static readonly IDictionary<char, char> m_ProducerFactory;

	private readonly Stack<int> _ComparatorFactory;

	private readonly ConnectionReader<ModelFactory> _DefinitionFactory;

	private readonly Stack<PredicateFactory> _ComposerFactory;

	private readonly IdentifierReader<StrategyReader> globalFactory;

	private readonly GetterReader mapFactory;

	private bool helperFactory;

	private bool _ExceptionFactory;

	private bool m_ItemFactory;

	private int m_ContextFactory;

	private int mapperFactory;

	private bool m_IdentifierFactory;

	private int _TokenFactory;

	private int callbackFactory;

	private bool m_RulesFactory;

	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	private ModelFactory getterFactory;

	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	private ParserFactory _CodeFactory;

	[CompilerGenerated]
	private bool indexerFactory;

	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	[CompilerGenerated]
	private ModelFactory _MockFactory;

	private static readonly byte[] m_MethodFactory;

	internal static SerializerFactory FlushError;

	public bool SkipComments
	{
		[CompilerGenerated]
		get
		{
			return indexerFactory;
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
					indexerFactory = value;
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

	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	public ModelFactory Current
	{
		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
		[CompilerGenerated]
		get
		{
			return _MockFactory;
		}
		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
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
					_MockFactory = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public QueueReader CurrentPosition => mapFactory.Mark();

	private bool IsDocumentStart()
	{
		int num = 5;
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 4:
					if (mapFactory.LineOffset != 0)
					{
						goto end_IL_0012;
					}
					goto case 7;
				default:
					return globalFactory.IsWhiteBreakOrZero(3);
				case 1:
				case 2:
					return false;
				case 6:
					if (globalFactory.Check('-', 1))
					{
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e != 0)
						{
							num2 = 3;
						}
						break;
					}
					goto case 1;
				case 7:
					if (!globalFactory.Check('-'))
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 == 0)
						{
							num2 = 1;
						}
						break;
					}
					goto case 6;
				case 5:
					if (!globalFactory.EndOfInput)
					{
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 == 0)
						{
							num2 = 4;
						}
						break;
					}
					goto case 1;
				case 3:
					if (globalFactory.Check('-', 2))
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec != 0)
						{
							num2 = 0;
						}
						break;
					}
					goto case 1;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 2;
		}
	}

	private bool IsDocumentEnd()
	{
		int num = 7;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				if (!globalFactory.Check('.', 2))
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 4;
			case 4:
				return globalFactory.IsWhiteBreakOrZero(3);
			case 1:
			case 3:
				return false;
			case 7:
				if (!globalFactory.EndOfInput)
				{
					num2 = 6;
					break;
				}
				goto case 1;
			case 6:
				if (mapFactory.LineOffset == 0)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 1;
			default:
				if (!globalFactory.Check('.'))
				{
					num2 = 3;
					break;
				}
				goto case 5;
			case 5:
				if (globalFactory.Check('.', 1))
				{
					num2 = 2;
					break;
				}
				goto case 1;
			}
		}
	}

	private bool IsDocumentIndicator()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return IsDocumentEnd();
			case 1:
				if (IsDocumentStart())
				{
					return true;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public SerializerFactory(TextReader input, bool skipComments = true)
	{
		GetterIssuer.DeleteInitializer();
		_ComparatorFactory = new Stack<int>();
		_DefinitionFactory = new ConnectionReader<ModelFactory>();
		_ComposerFactory = new Stack<PredicateFactory>();
		mapperFactory = -1;
		base._002Ector();
		int num = 3;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 != 0)
		{
			num = 2;
		}
		while (true)
		{
			switch (num)
			{
			default:
				SkipComments = skipComments;
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 != 0)
				{
					num = 2;
				}
				break;
			case 2:
				return;
			case 1:
				mapFactory = new GetterReader();
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2aaca7da964541af9780eb37df39c3db != 0)
				{
					num = 0;
				}
				break;
			case 3:
				globalFactory = new IdentifierReader<StrategyReader>(new StrategyReader(input, 1024));
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa != 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	public bool MoveNext()
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return MoveNextWithoutConsuming();
			case 3:
				ConsumeCurrent();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f == 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				if (Current == null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f011663d64054593978962dcc3a5ec1a != 0)
					{
						num2 = 1;
					}
					break;
				}
				goto case 3;
			}
		}
	}

	public bool MoveNextWithoutConsuming()
	{
		int num = 4;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (!_ExceptionFactory)
				{
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 != 0)
					{
						num2 = 0;
					}
					break;
				}
				goto default;
			case 2:
				FetchMoreTokens();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 != 0)
				{
					num2 = 0;
				}
				break;
			case 5:
				Current = _DefinitionFactory.Dequeue();
				num2 = 8;
				break;
			case 7:
				return true;
			case 4:
				if (m_RulesFactory)
				{
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f92fb16082174ff29c1cf0085d4a3cb9 == 0)
					{
						num2 = 3;
					}
					break;
				}
				goto case 1;
			default:
				if (_DefinitionFactory.Count <= 0)
				{
					Current = null;
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 != 0)
					{
						num2 = 4;
					}
				}
				else
				{
					num2 = 5;
				}
				break;
			case 6:
				return false;
			case 8:
				m_RulesFactory = false;
				num2 = 7;
				break;
			}
		}
	}

	public void ConsumeCurrent()
	{
		int num = 4;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				return;
			case 2:
				getterFactory = Current;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba != 0)
				{
					num2 = 0;
				}
				break;
			default:
				Current = null;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 == 0)
				{
					num2 = 1;
				}
				break;
			case 4:
				callbackFactory++;
				num2 = 3;
				break;
			case 3:
				m_RulesFactory = false;
				num2 = 2;
				break;
			}
		}
	}

	private char ReadCurrentCharacter()
	{
		char result = globalFactory.Peek(0);
		Skip();
		return result;
	}

	private char ReadLine()
	{
		int num = 3;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				return '\n';
			case 2:
			{
				char result = globalFactory.Peek(0);
				SkipLine();
				return result;
			}
			case 3:
				if (!globalFactory.Check(DicSingleton.gE3WbyDVW(0x40385DA3 ^ 0x4038D3E1)))
				{
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 == 0)
					{
						num2 = 2;
					}
					continue;
				}
				break;
			}
			SkipLine();
			num2 = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 != 0)
			{
				num2 = 1;
			}
		}
	}

	private void FetchMoreTokens()
	{
		int num = 11;
		int num2 = num;
		bool flag = default(bool);
		Stack<PredicateFactory>.Enumerator enumerator = default(Stack<PredicateFactory>.Enumerator);
		PredicateFactory current = default(PredicateFactory);
		while (true)
		{
			switch (num2)
			{
			case 10:
				if (_DefinitionFactory.Count == 0)
				{
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 == 0)
					{
						num2 = 1;
					}
					break;
				}
				goto case 9;
			case 5:
			case 11:
				flag = false;
				num2 = 10;
				break;
			case 6:
				FetchNextToken();
				num2 = 5;
				break;
			case 9:
				enumerator = _ComposerFactory.GetEnumerator();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd == 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				try
				{
					while (true)
					{
						IL_019a:
						int num4;
						if (!enumerator.MoveNext())
						{
							int num3 = 5;
							num4 = num3;
							goto IL_00fc;
						}
						goto IL_0135;
						IL_00fc:
						while (true)
						{
							switch (num4)
							{
							case 7:
								goto IL_0135;
							case 0:
								break;
							case 3:
								if (!current.IsPossible)
								{
									num4 = 2;
									continue;
								}
								goto case 6;
							case 4:
								flag = true;
								num4 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3ac5d604ebd547e7ac5b1603a0e85187 == 0)
								{
									num4 = 0;
								}
								continue;
							case 1:
							case 2:
								goto IL_019a;
							case 6:
								if (current.TokenNumber == callbackFactory)
								{
									num4 = 4;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a579dea83d2144838086d2d400bd0222 != 0)
									{
										num4 = 4;
									}
									continue;
								}
								goto IL_019a;
							case 5:
								break;
							}
							break;
						}
						break;
						IL_0135:
						current = enumerator.Current;
						num4 = 3;
						goto IL_00fc;
					}
				}
				finally
				{
					((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
					int num5 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 == 0)
					{
						num5 = 0;
					}
					switch (num5)
					{
					case 0:
						break;
					}
				}
				goto default;
			case 7:
				return;
			default:
				if (!flag)
				{
					num2 = 4;
					break;
				}
				goto case 6;
			case 2:
				flag = true;
				num2 = 8;
				break;
			case 3:
			case 4:
				m_RulesFactory = true;
				num2 = 7;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ea4c8b68ad954c0fb4df33d6e06bd4a3 != 0)
				{
					num2 = 5;
				}
				break;
			}
		}
	}

	private static bool StartsWith(StringBuilder what, char start)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (what.Length > 0)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 != 0)
					{
						num2 = 0;
					}
					break;
				}
				return false;
			default:
				return what[0] == start;
			}
		}
	}

	private void StaleSimpleKeys()
	{
		int num = 1;
		int num2 = num;
		Stack<PredicateFactory>.Enumerator enumerator = default(Stack<PredicateFactory>.Enumerator);
		PredicateFactory current = default(PredicateFactory);
		QueueReader queueReader = default(QueueReader);
		while (true)
		{
			switch (num2)
			{
			case 2:
				return;
			case 1:
				enumerator = _ComposerFactory.GetEnumerator();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f != 0)
				{
					num2 = 0;
				}
				continue;
			}
			try
			{
				while (true)
				{
					IL_0151:
					int num3;
					if (!enumerator.MoveNext())
					{
						num3 = 6;
						goto IL_003d;
					}
					goto IL_0107;
					IL_003d:
					while (true)
					{
						switch (num3)
						{
						case 6:
							return;
						case 7:
							if (current.Line >= mapFactory.Line)
							{
								num3 = 5;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae50b6e347494ff2973fbc64d1fc9236 != 0)
								{
									num3 = 5;
								}
								continue;
							}
							goto case 2;
						case 5:
							if (current.Index + 1024 >= mapFactory.Index)
							{
								num3 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b != 0)
								{
									num3 = 0;
								}
								continue;
							}
							goto case 2;
						case 2:
							if (current.IsRequired)
							{
								num3 = 3;
								continue;
							}
							goto case 8;
						case 10:
							if (current.IsPossible)
							{
								num3 = 7;
								continue;
							}
							goto IL_0151;
						case 4:
							break;
						case 3:
							queueReader = mapFactory.Mark();
							num3 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 != 0)
							{
								num3 = 1;
							}
							continue;
						default:
							goto IL_0151;
						case 1:
							_DefinitionFactory.Enqueue(new ParameterFactory(DicSingleton.gE3WbyDVW(0x33F6A245 ^ 0x33F62C09), queueReader, queueReader));
							num3 = 8;
							continue;
						case 8:
						{
							current.MarkAsImpossible();
							int num4 = 9;
							num3 = num4;
							continue;
						}
						}
						break;
					}
					goto IL_0107;
					IL_0107:
					current = enumerator.Current;
					num3 = 10;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 == 0)
					{
						num3 = 1;
					}
					goto IL_003d;
				}
			}
			finally
			{
				((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
				int num5 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 == 0)
				{
					num5 = 0;
				}
				switch (num5)
				{
				case 0:
					break;
				}
			}
		}
	}

	private void FetchNextToken()
	{
		if (!helperFactory)
		{
			FetchStreamStart();
			return;
		}
		ScanToNextToken();
		StaleSimpleKeys();
		UnrollIndent(mapFactory.LineOffset);
		globalFactory.Buffer.Cache(4);
		if (globalFactory.Buffer.EndOfInput)
		{
			FetchStreamEnd();
			return;
		}
		if (mapFactory.LineOffset == 0 && globalFactory.Check('%'))
		{
			FetchDirective();
			return;
		}
		if (IsDocumentStart())
		{
			FetchDocumentIndicator(isStartToken: true);
			return;
		}
		if (IsDocumentEnd())
		{
			FetchDocumentIndicator(isStartToken: false);
			return;
		}
		if (globalFactory.Check('['))
		{
			FetchFlowCollectionStart(isSequenceToken: true);
			return;
		}
		if (globalFactory.Check('{'))
		{
			FetchFlowCollectionStart(isSequenceToken: false);
			return;
		}
		if (globalFactory.Check(']'))
		{
			FetchFlowCollectionEnd(isSequenceToken: true);
			return;
		}
		if (globalFactory.Check('}'))
		{
			FetchFlowCollectionEnd(isSequenceToken: false);
			return;
		}
		if (globalFactory.Check(','))
		{
			FetchFlowEntry();
			return;
		}
		if (globalFactory.Check('-') && globalFactory.IsWhiteBreakOrZero(1))
		{
			FetchBlockEntry();
			return;
		}
		if (globalFactory.Check('?') && (_TokenFactory > 0 || globalFactory.IsWhiteBreakOrZero(1)))
		{
			FetchKey();
			return;
		}
		if (globalFactory.Check(':') && (_TokenFactory > 0 || globalFactory.IsWhiteBreakOrZero(1)) && (!m_IdentifierFactory || _TokenFactory <= 0))
		{
			FetchValue();
			return;
		}
		if (globalFactory.Check('*'))
		{
			FetchAnchor(isAlias: true);
			return;
		}
		if (globalFactory.Check('&'))
		{
			FetchAnchor(isAlias: false);
			return;
		}
		if (globalFactory.Check('!'))
		{
			FetchTag();
			return;
		}
		if (globalFactory.Check('|') && _TokenFactory == 0)
		{
			FetchBlockScalar(isLiteral: true);
			return;
		}
		if (globalFactory.Check('>') && _TokenFactory == 0)
		{
			FetchBlockScalar(isLiteral: false);
			return;
		}
		if (globalFactory.Check('\''))
		{
			FetchFlowScalar(isSingleQuoted: true);
			return;
		}
		if (globalFactory.Check('"'))
		{
			FetchFlowScalar(isSingleQuoted: false);
			return;
		}
		if ((!globalFactory.IsWhiteBreakOrZero() && !globalFactory.Check(DicSingleton.gE3WbyDVW(0x120E76C ^ 0x12069AE))) || (globalFactory.Check('-') && !globalFactory.IsWhite(1)) || (_TokenFactory == 0 && globalFactory.Check(DicSingleton.gE3WbyDVW(0x15823EC4 ^ 0x1582474C)) && !globalFactory.IsWhiteBreakOrZero(1)) || (m_IdentifierFactory && _TokenFactory > 0 && globalFactory.Check(DicSingleton.gE3WbyDVW(-1483531944 ^ -1483513648))))
		{
			if (m_ItemFactory)
			{
				QueueReader queueReader = mapFactory.Mark();
				_DefinitionFactory.Enqueue(new ParameterFactory(DicSingleton.gE3WbyDVW(-1880453928 ^ -1880489420), queueReader, queueReader));
			}
			m_ItemFactory = false;
			FetchPlainScalar();
			return;
		}
		if (m_IdentifierFactory && mapperFactory >= mapFactory.LineOffset && globalFactory.IsTab())
		{
			throw new RegistryFactory(DicSingleton.gE3WbyDVW(0x7FAAD78F ^ 0x7FAA58F3));
		}
		if (globalFactory.IsWhiteBreakOrZero())
		{
			Skip();
			return;
		}
		QueueReader start = mapFactory.Mark();
		Skip();
		QueueReader end = mapFactory.Mark();
		throw new RegistryFactory(start, end, DicSingleton.gE3WbyDVW(0x21AFFB2B ^ 0x21AF74DD));
	}

	private bool CheckWhiteSpace()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (!globalFactory.Check(' '))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 == 0)
					{
						num2 = 0;
					}
					break;
				}
				return true;
			case 3:
				return globalFactory.Check('\t');
			case 2:
				if (m_IdentifierFactory)
				{
					return false;
				}
				num2 = 3;
				break;
			default:
				if (_TokenFactory <= 0)
				{
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 == 0)
					{
						num2 = 1;
					}
					break;
				}
				goto case 3;
			}
		}
	}

	private void Skip()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				return;
			default:
				globalFactory.Buffer.Skip(1);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c == 0)
				{
					num2 = 2;
				}
				break;
			case 1:
				mapFactory.Skip();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	private void SkipLine()
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 5:
				globalFactory.Buffer.Skip(2);
				num2 = 3;
				break;
			case 3:
				return;
			case 4:
				mapFactory.SkipLineByOffset(1);
				num2 = 7;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
				{
					num2 = 2;
				}
				break;
			case 7:
				globalFactory.Buffer.Skip(1);
				num2 = 6;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
				{
					num2 = 6;
				}
				break;
			case 1:
				mapFactory.SkipLineByOffset(2);
				num2 = 5;
				break;
			case 6:
				return;
			default:
				throw new InvalidOperationException(DicSingleton.gE3WbyDVW(-1273961441 ^ -1273990009));
			case 2:
				if (!globalFactory.IsCrLf())
				{
					if (globalFactory.IsBreak())
					{
						num2 = 4;
						break;
					}
					if (globalFactory.IsZero())
					{
						return;
					}
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab == 0)
					{
						num2 = 0;
					}
				}
				else
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
					{
						num2 = 1;
					}
				}
				break;
			}
		}
	}

	private void ScanToNextToken()
	{
		int num = 4;
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					if (globalFactory.IsBreak())
					{
						num2 = 5;
						continue;
					}
					return;
				case 1:
				case 2:
				case 4:
				case 11:
					if (CheckWhiteSpace())
					{
						num2 = 9;
						continue;
					}
					goto case 6;
				case 3:
				case 9:
					Skip();
					num2 = 2;
					continue;
				case 7:
					if (_TokenFactory != 0)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e == 0)
						{
							num2 = 1;
						}
						continue;
					}
					break;
				case 6:
					ProcessComment();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2aaca7da964541af9780eb37df39c3db != 0)
					{
						num2 = 0;
					}
					continue;
				case 5:
					SkipLine();
					num2 = 7;
					continue;
				case 10:
					break;
				case 8:
					return;
				}
				break;
			}
			m_IdentifierFactory = true;
			num = 11;
		}
	}

	private void ProcessComment()
	{
		int num = 11;
		QueueReader queueReader = default(QueueReader);
		StringBuilder stringBuilder = default(StringBuilder);
		bool isInline = default(bool);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				int num3;
				switch (num2)
				{
				case 13:
					num3 = ((!(getterFactory is ImporterFactory)) ? 1 : 0);
					goto IL_0275;
				case 6:
					if (getterFactory.End.Line == queueReader.Line)
					{
						num2 = 17;
						continue;
					}
					goto IL_0274;
				case 2:
					stringBuilder.Append(ReadCurrentCharacter());
					num2 = 3;
					continue;
				case 16:
					Skip();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 != 0)
					{
						num2 = 0;
					}
					continue;
				case 8:
					if (!SkipComments)
					{
						num2 = 12;
						continue;
					}
					return;
				default:
					if (globalFactory.IsSpace())
					{
						num2 = 7;
						continue;
					}
					goto case 9;
				case 11:
					if (globalFactory.Check('#'))
					{
						num2 = 10;
						continue;
					}
					return;
				case 17:
					if (getterFactory.End.Column != 1)
					{
						num2 = 13;
						continue;
					}
					goto IL_0274;
				case 12:
					if (getterFactory != null)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb != 0)
						{
							num2 = 6;
						}
						continue;
					}
					goto IL_0274;
				case 15:
					_DefinitionFactory.Enqueue(new IteratorFactory(stringBuilder.ToString(), isInline, queueReader, mapFactory.Mark()));
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 == 0)
					{
						num2 = 1;
					}
					continue;
				case 9:
					stringBuilder = new StringBuilder();
					num2 = 5;
					continue;
				case 1:
					return;
				case 7:
				case 14:
					Skip();
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a == 0)
					{
						num2 = 0;
					}
					continue;
				case 10:
					queueReader = mapFactory.Mark();
					num = 16;
					break;
				case 3:
				case 5:
					{
						if (globalFactory.IsBreakOrZero())
						{
							num2 = 8;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9c47a25d924946efb9e023473a095794 == 0)
							{
								num2 = 7;
							}
							continue;
						}
						goto case 2;
					}
					IL_0275:
					isInline = (byte)num3 != 0;
					num = 15;
					break;
					IL_0274:
					num3 = 0;
					goto IL_0275;
				}
				break;
			}
		}
	}

	private void FetchStreamStart()
	{
		int num = 3;
		int num2 = num;
		QueueReader queueReader = default(QueueReader);
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 1:
				queueReader = mapFactory.Mark();
				num2 = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e == 0)
				{
					num2 = 3;
				}
				break;
			case 0:
				return;
			case 3:
				_ComposerFactory.Push(new PredicateFactory());
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e != 0)
				{
					num2 = 2;
				}
				break;
			case 2:
				m_IdentifierFactory = true;
				num2 = 5;
				break;
			case 5:
				helperFactory = true;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd != 0)
				{
					num2 = 0;
				}
				break;
			case 4:
				_DefinitionFactory.Enqueue(new ImporterFactory(queueReader, queueReader));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	private void UnrollIndent(int column)
	{
		int num = 6;
		QueueReader queueReader = default(QueueReader);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 6:
					if (_TokenFactory != 0)
					{
						goto end_IL_0012;
					}
					goto case 4;
				case 1:
					mapperFactory = _ComparatorFactory.Pop();
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a == 0)
					{
						num2 = 1;
					}
					break;
				case 5:
					return;
				case 2:
					queueReader = mapFactory.Mark();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 != 0)
					{
						num2 = 0;
					}
					break;
				case 4:
					if (mapperFactory > column)
					{
						num2 = 2;
						break;
					}
					return;
				default:
					_DefinitionFactory.Enqueue(new EventFactory(queueReader, queueReader));
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 != 0)
					{
						num2 = 1;
					}
					break;
				case 3:
					return;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 5;
		}
	}

	private void FetchStreamEnd()
	{
		int num = 2;
		QueueReader queueReader = default(QueueReader);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 3:
					break;
				case 4:
					m_IdentifierFactory = false;
					num2 = 5;
					continue;
				case 7:
					return;
				case 6:
					queueReader = mapFactory.Mark();
					num2 = 3;
					continue;
				case 5:
					_ExceptionFactory = true;
					num2 = 6;
					continue;
				default:
					RemoveSimpleKey();
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 == 0)
					{
						num2 = 4;
					}
					continue;
				case 1:
					UnrollIndent(-1);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 == 0)
					{
						num2 = 0;
					}
					continue;
				case 2:
					mapFactory.ForceSkipLineAfterNonBreak();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be != 0)
					{
						num2 = 1;
					}
					continue;
				}
				break;
			}
			_DefinitionFactory.Enqueue(new AlgoFactory(queueReader, queueReader));
			num = 7;
		}
	}

	private void FetchDirective()
	{
		int num = 6;
		int num2 = num;
		ModelFactory modelFactory = default(ModelFactory);
		while (true)
		{
			switch (num2)
			{
			case 5:
				RemoveSimpleKey();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2aaca7da964541af9780eb37df39c3db != 0)
				{
					num2 = 3;
				}
				break;
			case 3:
				m_IdentifierFactory = false;
				num2 = 2;
				break;
			case 1:
				return;
			case 4:
				if (modelFactory == null)
				{
					return;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e != 0)
				{
					num2 = 0;
				}
				break;
			default:
				_DefinitionFactory.Enqueue(modelFactory);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd != 0)
				{
					num2 = 1;
				}
				break;
			case 2:
				modelFactory = ScanDirective();
				num2 = 4;
				break;
			case 6:
				UnrollIndent(-1);
				num2 = 5;
				break;
			}
		}
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
	private ModelFactory ScanDirective()
	{
		int num = 22;
		ModelFactory result = default(ModelFactory);
		QueueReader start = default(QueueReader);
		string text = default(string);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 9:
					if (!(getterFactory is ServiceFactory))
					{
						num2 = 5;
						continue;
					}
					goto case 13;
				case 13:
				case 15:
					result = ScanVersionDirectiveValue(start);
					num2 = 20;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3ac5d604ebd547e7ac5b1603a0e85187 != 0)
					{
						num2 = 4;
					}
					continue;
				case 12:
				case 17:
				case 20:
					if (globalFactory.IsWhite())
					{
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 == 0)
						{
							num2 = 28;
						}
						continue;
					}
					goto case 3;
				case 25:
				case 29:
					if (globalFactory.Check('#'))
					{
						num2 = 30;
						continue;
					}
					goto case 7;
				case 4:
					if (globalFactory.IsBreakOrZero())
					{
						num2 = 19;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 == 0)
						{
							num2 = 12;
						}
						continue;
					}
					goto case 27;
				case 22:
					start = mapFactory.Mark();
					num2 = 21;
					continue;
				case 5:
				case 11:
					throw new TemplateFactory(start, mapFactory.Mark(), DicSingleton.gE3WbyDVW(-490894496 ^ -490923088));
				case 14:
					result = ScanTagDirectiveValue(start);
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 != 0)
					{
						num2 = 17;
					}
					continue;
				default:
					if (!(getterFactory is ImporterFactory))
					{
						num2 = 9;
						continue;
					}
					goto case 13;
				case 7:
					if (globalFactory.IsBreak())
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea != 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 16;
				case 2:
					if (!(text == DicSingleton.gE3WbyDVW(-1483531944 ^ -1483503202)))
					{
						goto case 25;
					}
					num = 14;
					break;
				case 8:
					SkipLine();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 == 0)
					{
						num2 = 6;
					}
					continue;
				case 26:
					if (text == DicSingleton.gE3WbyDVW(-1507873642 ^ -1507902420))
					{
						num2 = 10;
						continue;
					}
					goto case 2;
				case 21:
					Skip();
					num = 23;
					break;
				case 10:
				case 18:
					if (getterFactory is BridgeFactory)
					{
						num2 = 15;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 != 0)
						{
							num2 = 7;
						}
						continue;
					}
					goto default;
				case 1:
				case 30:
					return null;
				case 28:
					Skip();
					num2 = 12;
					continue;
				case 27:
					throw new RegistryFactory(start, mapFactory.Mark(), DicSingleton.gE3WbyDVW(0x7B291245 ^ 0x7B29832D));
				case 19:
					if (!globalFactory.IsBreak())
					{
						num2 = 24;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 != 0)
						{
							num2 = 14;
						}
						continue;
					}
					goto case 8;
				case 16:
					Skip();
					num = 29;
					break;
				case 23:
					text = ScanDirectiveName(start);
					num2 = 26;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 != 0)
					{
						num2 = 20;
					}
					continue;
				case 3:
					ProcessComment();
					num2 = 4;
					continue;
				case 6:
				case 24:
					return result;
				}
				break;
			}
		}
	}

	private void FetchDocumentIndicator(bool isStartToken)
	{
		int num = 9;
		ModelFactory modelFactory = default(ModelFactory);
		QueueReader queueReader = default(QueueReader);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 9:
					UnrollIndent(-1);
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
					{
						num2 = 1;
					}
					continue;
				case 24:
					modelFactory = new ParameterFactory(DicSingleton.gE3WbyDVW(-428683152 ^ -428719732), queueReader, mapFactory.Mark());
					num2 = 11;
					continue;
				case 5:
					if (modelFactory == null)
					{
						num2 = 7;
						continue;
					}
					goto case 18;
				case 8:
					RemoveSimpleKey();
					num2 = 11;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 != 0)
					{
						num2 = 16;
					}
					continue;
				case 10:
				case 13:
					Skip();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 != 0)
					{
						num2 = 1;
					}
					continue;
				case 25:
					return;
				case 14:
					modelFactory = null;
					num2 = 20;
					continue;
				case 7:
					return;
				case 2:
					Skip();
					num2 = 22;
					continue;
				case 18:
					_DefinitionFactory.Enqueue(modelFactory);
					num2 = 3;
					continue;
				default:
					Skip();
					num2 = 17;
					continue;
				case 21:
					if (!globalFactory.IsBreak())
					{
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec != 0)
						{
							num2 = 6;
						}
						continue;
					}
					goto case 11;
				case 23:
				case 26:
					if (globalFactory.IsWhite())
					{
						num2 = 13;
						continue;
					}
					goto case 24;
				case 16:
					m_IdentifierFactory = false;
					num2 = 14;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add == 0)
					{
						num2 = 15;
					}
					continue;
				case 11:
				case 12:
				case 19:
					_DefinitionFactory.Enqueue(new ServiceFactory(queueReader, queueReader));
					num2 = 5;
					continue;
				case 1:
				case 20:
					if (globalFactory.EndOfInput)
					{
						num2 = 12;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb != 0)
						{
							num2 = 12;
						}
						continue;
					}
					goto case 21;
				case 15:
					queueReader = mapFactory.Mark();
					num2 = 2;
					continue;
				case 6:
					if (!globalFactory.Check('#'))
					{
						num2 = 23;
						continue;
					}
					goto case 11;
				case 22:
					Skip();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 == 0)
					{
						num2 = 0;
					}
					continue;
				case 17:
					if (isStartToken)
					{
						break;
					}
					goto end_IL_0012;
				case 3:
					return;
				case 4:
					break;
				}
				_DefinitionFactory.Enqueue(new BridgeFactory(queueReader, mapFactory.Mark()));
				num2 = 24;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 == 0)
				{
					num2 = 25;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 14;
		}
	}

	private void FetchFlowCollectionStart(bool isSequenceToken)
	{
		int num = 7;
		int num2 = num;
		ModelFactory modelFactory = default(ModelFactory);
		QueueReader queueReader = default(QueueReader);
		while (true)
		{
			switch (num2)
			{
			case 3:
				if (isSequenceToken)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 == 0)
					{
						num2 = 2;
					}
					break;
				}
				goto case 9;
			case 4:
				return;
			case 6:
				IncreaseFlowLevel();
				num2 = 8;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac != 0)
				{
					num2 = 3;
				}
				break;
			case 10:
				Skip();
				num2 = 3;
				break;
			case 8:
				m_IdentifierFactory = true;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa == 0)
				{
					num2 = 0;
				}
				break;
			case 5:
				m_ContextFactory = modelFactory.Start.Line;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 == 0)
				{
					num2 = 1;
				}
				break;
			case 2:
				modelFactory = new ExporterFactory(queueReader, queueReader);
				num2 = 5;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be == 0)
				{
					num2 = 1;
				}
				break;
			case 7:
				SaveSimpleKey();
				num2 = 6;
				break;
			case 9:
				modelFactory = new AttrFactory(queueReader, queueReader);
				num2 = 11;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 != 0)
				{
					num2 = 10;
				}
				break;
			case 1:
			case 11:
				_DefinitionFactory.Enqueue(modelFactory);
				num2 = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 == 0)
				{
					num2 = 3;
				}
				break;
			default:
				queueReader = mapFactory.Mark();
				num2 = 10;
				break;
			}
		}
	}

	private void IncreaseFlowLevel()
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
			case 1:
				_TokenFactory++;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 == 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				_ComposerFactory.Push(new PredicateFactory());
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 == 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	private void FetchFlowCollectionEnd(bool isSequenceToken)
	{
		int num = 2;
		QueueReader queueReader = default(QueueReader);
		ModelFactory item = default(ModelFactory);
		ModelFactory modelFactory = default(ModelFactory);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 5:
					_DefinitionFactory.Enqueue(new ParameterFactory(DicSingleton.gE3WbyDVW(-1954645236 ^ -1954617328), queueReader, queueReader));
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 != 0)
					{
						num2 = 0;
					}
					break;
				case 11:
					if (getterFactory is ImporterFactory)
					{
						num2 = 8;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 == 0)
						{
							num2 = 19;
						}
						break;
					}
					goto default;
				case 8:
					queueReader = mapFactory.Mark();
					num2 = 17;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 == 0)
					{
						num2 = 14;
					}
					break;
				case 15:
					return;
				case 19:
					if (m_ContextFactory != queueReader.Line)
					{
						num2 = 5;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 != 0)
						{
							num2 = 4;
						}
						break;
					}
					goto default;
				case 16:
					return;
				case 10:
				case 14:
					_DefinitionFactory.Enqueue(item);
					num2 = 9;
					break;
				case 12:
					if (globalFactory.Check('#'))
					{
						goto end_IL_0012;
					}
					goto case 11;
				case 13:
					if (isSequenceToken)
					{
						num2 = 12;
						break;
					}
					goto case 6;
				case 3:
					m_IdentifierFactory = false;
					num2 = 8;
					break;
				case 4:
					modelFactory = new ParameterFactory(DicSingleton.gE3WbyDVW(-316028230 ^ -316057558), queueReader, queueReader);
					num2 = 11;
					break;
				case 6:
					item = new TestFactory(queueReader, queueReader);
					num2 = 14;
					break;
				default:
					item = new MessageFactory(queueReader, queueReader);
					num2 = 10;
					break;
				case 9:
					if (modelFactory == null)
					{
						num2 = 15;
						break;
					}
					goto case 7;
				case 1:
					DecreaseFlowLevel();
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 != 0)
					{
						num2 = 3;
					}
					break;
				case 7:
					_DefinitionFactory.Enqueue(modelFactory);
					num2 = 16;
					break;
				case 18:
					modelFactory = null;
					num2 = 13;
					break;
				case 2:
					RemoveSimpleKey();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 == 0)
					{
						num2 = 0;
					}
					break;
				case 17:
					Skip();
					num2 = 18;
					break;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 4;
		}
	}

	private void DecreaseFlowLevel()
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
			case 2:
				return;
			case 3:
				_TokenFactory--;
				num2 = 4;
				break;
			case 1:
				if (_TokenFactory <= 0)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 != 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 3;
			case 4:
				_ComposerFactory.Pop();
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	private void FetchFlowEntry()
	{
		int num = 6;
		QueueReader start = default(QueueReader);
		QueueReader end = default(QueueReader);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 0:
					return;
				case 6:
					RemoveSimpleKey();
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef == 0)
					{
						num2 = 5;
					}
					break;
				case 5:
					m_IdentifierFactory = true;
					num2 = 4;
					break;
				case 3:
					if (!globalFactory.Check('#'))
					{
						_DefinitionFactory.Enqueue(new MerchantFactory(start, end));
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a != 0)
						{
							num2 = 0;
						}
						break;
					}
					goto end_IL_0012;
				case 1:
					Skip();
					num2 = 7;
					break;
				case 2:
					_DefinitionFactory.Enqueue(new ParameterFactory(DicSingleton.gE3WbyDVW(-1064640644 ^ -1064678218), start, end));
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e == 0)
					{
						num2 = 5;
					}
					break;
				case 4:
					start = mapFactory.Mark();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 == 0)
					{
						num2 = 0;
					}
					break;
				case 7:
					end = mapFactory.Mark();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 == 0)
					{
						num2 = 3;
					}
					break;
				case 8:
					return;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 2;
		}
	}

	private void FetchBlockEntry()
	{
		int num = 10;
		QueueReader start = default(QueueReader);
		QueueReader queueReader = default(QueueReader);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 3:
					m_IdentifierFactory = true;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c == 0)
					{
						num2 = 7;
					}
					continue;
				case 4:
					break;
				case 10:
					if (_TokenFactory != 0)
					{
						num2 = 9;
						continue;
					}
					goto default;
				case 11:
					if (_CodeFactory.End.Line == mapFactory.Line)
					{
						num2 = 14;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f == 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto IL_01c8;
				default:
					if (m_IdentifierFactory)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab == 0)
						{
							num2 = 13;
						}
						continue;
					}
					goto case 12;
				case 6:
				case 13:
					RollIndent(mapFactory.LineOffset, -1, isSequence: true, mapFactory.Mark());
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_49107028423047bfbf9c33e5a2ab8cf8 == 0)
					{
						num2 = 1;
					}
					continue;
				case 12:
					if (_CodeFactory != null)
					{
						num2 = 11;
						continue;
					}
					goto IL_01c8;
				case 7:
					start = mapFactory.Mark();
					num2 = 8;
					continue;
				case 8:
					Skip();
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd == 0)
					{
						num2 = 4;
					}
					continue;
				case 14:
					throw new TemplateFactory(_CodeFactory.Start, _CodeFactory.End, DicSingleton.gE3WbyDVW(-1011281439 ^ -1011251795));
				case 1:
				case 9:
					RemoveSimpleKey();
					num2 = 3;
					continue;
				case 2:
					return;
				case 5:
					{
						_DefinitionFactory.Enqueue(new ParameterFactory(DicSingleton.gE3WbyDVW(-243097544 ^ -243124998), queueReader, queueReader));
						num2 = 6;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9c47a25d924946efb9e023473a095794 == 0)
						{
							num2 = 2;
						}
						continue;
					}
					IL_01c8:
					queueReader = mapFactory.Mark();
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_91887e48b8104e7da08b48f73b607337 == 0)
					{
						num2 = 2;
					}
					continue;
				}
				break;
			}
			_DefinitionFactory.Enqueue(new InstanceFactory(start, mapFactory.Mark()));
			num = 2;
		}
	}

	private void FetchKey()
	{
		int num = 4;
		QueueReader start = default(QueueReader);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 5:
					Skip();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 != 0)
					{
						num2 = 1;
					}
					break;
				case 7:
					return;
				case 3:
				case 8:
					RemoveSimpleKey();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba == 0)
					{
						num2 = 6;
					}
					break;
				case 1:
					_DefinitionFactory.Enqueue(new ValFactory(start, mapFactory.Mark()));
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 != 0)
					{
						num2 = 7;
					}
					break;
				case 2:
					start = mapFactory.Mark();
					num2 = 5;
					break;
				case 4:
					if (_TokenFactory != 0)
					{
						goto end_IL_0012;
					}
					goto default;
				case 9:
				{
					QueueReader queueReader = mapFactory.Mark();
					throw new RegistryFactory(queueReader, queueReader, DicSingleton.gE3WbyDVW(-2103041941 ^ -2103003809));
				}
				default:
					if (m_IdentifierFactory)
					{
						RollIndent(mapFactory.LineOffset, -1, isSequence: false, mapFactory.Mark());
						num2 = 8;
					}
					else
					{
						num2 = 9;
					}
					break;
				case 6:
					m_IdentifierFactory = _TokenFactory == 0;
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb != 0)
					{
						num2 = 2;
					}
					break;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 3;
		}
	}

	private void FetchValue()
	{
		int num = 16;
		bool flag = default(bool);
		QueueReader start = default(QueueReader);
		PredicateFactory predicateFactory = default(PredicateFactory);
		QueueReader queueReader = default(QueueReader);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 9:
					m_IdentifierFactory = flag;
					num = 7;
					break;
				case 3:
					if (m_IdentifierFactory)
					{
						num2 = 13;
						continue;
					}
					goto case 19;
				case 22:
					return;
				case 7:
				case 14:
					start = mapFactory.Mark();
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 == 0)
					{
						num2 = 3;
					}
					continue;
				case 17:
					_DefinitionFactory.Insert(predicateFactory.TokenNumber - callbackFactory, new ValFactory(predicateFactory.Mark, predicateFactory.Mark));
					num2 = 21;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 == 0)
					{
						num2 = 21;
					}
					continue;
				case 20:
					if (flag)
					{
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec == 0)
						{
							num2 = 2;
						}
						continue;
					}
					goto case 9;
				case 19:
					queueReader = mapFactory.Mark();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 == 0)
					{
						num2 = 1;
					}
					continue;
				case 2:
					predicateFactory.MarkAsImpossible();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 == 0)
					{
						num2 = 0;
					}
					continue;
				case 21:
					RollIndent(predicateFactory.LineOffset, predicateFactory.TokenNumber, isSequence: false, predicateFactory.Mark);
					num2 = 2;
					continue;
				case 4:
					Skip();
					num2 = 11;
					continue;
				default:
					m_IdentifierFactory = false;
					num2 = 14;
					continue;
				case 6:
					flag = _TokenFactory == 0;
					num2 = 20;
					continue;
				case 11:
					_DefinitionFactory.Enqueue(new AnnotationFactory(start, mapFactory.Mark()));
					num2 = 22;
					continue;
				case 12:
					if (predicateFactory.LineOffset == 0)
					{
						num2 = 10;
						continue;
					}
					goto case 9;
				case 15:
					if (predicateFactory.IsPossible)
					{
						num2 = 6;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 != 0)
						{
							num2 = 17;
						}
						continue;
					}
					goto case 6;
				case 16:
					predicateFactory = _ComposerFactory.Peek();
					num2 = 15;
					continue;
				case 5:
					return;
				case 13:
					RollIndent(mapFactory.LineOffset, -1, isSequence: false, mapFactory.Mark());
					num2 = 18;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
					{
						num2 = 1;
					}
					continue;
				case 8:
					flag = false;
					num2 = 9;
					continue;
				case 18:
					if (mapFactory.LineOffset == 0)
					{
						num2 = 12;
						continue;
					}
					goto case 9;
				case 1:
					_DefinitionFactory.Enqueue(new ParameterFactory(DicSingleton.gE3WbyDVW(--798431903 ^ 0x2F978F0D), queueReader, queueReader));
					num = 5;
					break;
				case 10:
					_DefinitionFactory.Insert(_DefinitionFactory.Count, new ValFactory(predicateFactory.Mark, predicateFactory.Mark));
					num = 8;
					break;
				}
				break;
			}
		}
	}

	private void RollIndent(int column, int number, bool isSequence, QueueReader position)
	{
		int num = 4;
		ModelFactory item = default(ModelFactory);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 1:
					if (isSequence)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
						{
							num2 = 0;
						}
						break;
					}
					goto case 6;
				case 12:
					_DefinitionFactory.Enqueue(item);
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 == 0)
					{
						num2 = 9;
					}
					break;
				case 5:
					return;
				case 8:
				case 10:
					if (number == -1)
					{
						num2 = 12;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 == 0)
						{
							num2 = 5;
						}
						break;
					}
					_DefinitionFactory.Insert(number - callbackFactory, item);
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 != 0)
					{
						num2 = 5;
					}
					break;
				case 2:
					_ComparatorFactory.Push(mapperFactory);
					num2 = 11;
					break;
				case 7:
					return;
				case 3:
					if (mapperFactory >= column)
					{
						return;
					}
					goto end_IL_0012;
				case 11:
					mapperFactory = column;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 == 0)
					{
						num2 = 1;
					}
					break;
				default:
					item = new ContainerFactory(position, position);
					num2 = 10;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7e7ae6cc25e34646baea4e1c2c087e7a == 0)
					{
						num2 = 4;
					}
					break;
				case 9:
					return;
				case 6:
					item = new OrderFactory(position, position);
					num2 = 8;
					break;
				case 4:
					if (_TokenFactory > 0)
					{
						return;
					}
					num2 = 3;
					break;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 2;
		}
	}

	private void FetchAnchor(bool isAlias)
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
				SaveSimpleKey();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3aab303a2946368dda3deef055dc93 == 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				m_IdentifierFactory = false;
				num2 = 3;
				break;
			case 3:
				_DefinitionFactory.Enqueue(ScanAnchor(isAlias));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	private ModelFactory ScanAnchor(bool isAlias)
	{
		int num = 14;
		int num2 = num;
		ParserFactory result = default(ParserFactory);
		bool flag = default(bool);
		QueueReader start = default(QueueReader);
		PredicateFactory predicateFactory = default(PredicateFactory);
		HelperReader value = default(HelperReader);
		StringBuilder stringBuilder = default(StringBuilder);
		while (true)
		{
			int num3;
			switch (num2)
			{
			case 1:
				if (!globalFactory.IsWhiteBreakOrZero())
				{
					num2 = 22;
					continue;
				}
				goto IL_0157;
			case 6:
				if (!globalFactory.Check(':'))
				{
					num2 = 15;
					continue;
				}
				goto case 17;
			case 21:
				return result;
			case 17:
				if (globalFactory.IsWhiteBreakOrZero(1))
				{
					num2 = 12;
					continue;
				}
				goto case 8;
			case 3:
			case 10:
				if (!globalFactory.IsWhiteBreakOrZero())
				{
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a == 0)
					{
						num2 = 1;
					}
					continue;
				}
				goto case 12;
			case 7:
				if (flag)
				{
					num2 = 6;
					continue;
				}
				goto case 8;
			case 11:
				throw new RegistryFactory(start, mapFactory.Mark(), DicSingleton.gE3WbyDVW(-1931860206 ^ -1931824892));
			case 18:
				num3 = (predicateFactory.IsPossible ? 1 : 0);
				break;
			case 20:
				flag = false;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 == 0)
				{
					num2 = 0;
				}
				continue;
			case 22:
				if (!globalFactory.Check(DicSingleton.gE3WbyDVW(--1182565251 ^ 0x467C1581)))
				{
					num2 = 11;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 == 0)
					{
						num2 = 8;
					}
					continue;
				}
				goto IL_0157;
			case 14:
				start = mapFactory.Mark();
				num2 = 13;
				continue;
			case 16:
				return new ParamFactory(value, start, mapFactory.Mark());
			case 12:
			case 23:
				if (stringBuilder.Length != 0)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 != 0)
					{
						num2 = 1;
					}
					continue;
				}
				goto case 11;
			case 9:
				if (!isAlias)
				{
					result = (_CodeFactory = new ParserFactory(value, start, mapFactory.Mark()));
					num2 = 21;
				}
				else
				{
					num2 = 16;
				}
				continue;
			case 19:
				if (predicateFactory.IsRequired)
				{
					num2 = 18;
					continue;
				}
				num3 = 0;
				break;
			case 5:
			case 24:
				if (!globalFactory.Check(DicSingleton.gE3WbyDVW(-545065612 ^ -545103744)))
				{
					num2 = 7;
					continue;
				}
				goto case 12;
			case 25:
				predicateFactory = _ComposerFactory.Peek();
				num2 = 19;
				continue;
			default:
				if (!isAlias)
				{
					num2 = 2;
					continue;
				}
				goto case 25;
			case 2:
			case 4:
				stringBuilder = new StringBuilder();
				num2 = 3;
				continue;
			case 8:
			case 15:
				stringBuilder.Append(ReadCurrentCharacter());
				num2 = 10;
				continue;
			case 13:
				{
					Skip();
					num2 = 20;
					continue;
				}
				IL_0157:
				value = new HelperReader(stringBuilder.ToString());
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f == 0)
				{
					num2 = 9;
				}
				continue;
			}
			flag = (byte)num3 != 0;
			num2 = 4;
		}
	}

	private void FetchTag()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				m_IdentifierFactory = false;
				num2 = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c == 0)
				{
					num2 = 3;
				}
				break;
			case 3:
				_DefinitionFactory.Enqueue(ScanTag());
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb != 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				SaveSimpleKey();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4a2885c39dcc4cf1a32db39a2ed578f0 != 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				return;
			}
		}
	}

	private ModelFactory ScanTag()
	{
		int num = 20;
		string text = default(string);
		QueueReader start = default(QueueReader);
		string text3 = default(string);
		string text2 = default(string);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					text = ScanTagUri(null, start);
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 == 0)
					{
						num2 = 16;
					}
					break;
				case 15:
					Skip();
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3ac5d604ebd547e7ac5b1603a0e85187 != 0)
					{
						num2 = 3;
					}
					break;
				case 1:
					text3 = string.Empty;
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 == 0)
					{
						num2 = 17;
					}
					break;
				case 8:
					text3 = text2;
					num2 = 13;
					break;
				case 6:
					text3 = DicSingleton.gE3WbyDVW(-525002617 ^ -524983905);
					num2 = 14;
					break;
				case 23:
					if (globalFactory.Check(','))
					{
						num2 = 5;
						break;
					}
					goto case 18;
				case 12:
					text = text3;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f == 0)
					{
						num2 = 1;
					}
					break;
				case 18:
					throw new RegistryFactory(start, mapFactory.Mark(), DicSingleton.gE3WbyDVW(-32257720 ^ -32285100));
				case 5:
					return new CreatorFactory(text3, text, start, mapFactory.Mark());
				case 14:
					if (text.Length != 0)
					{
						num2 = 4;
						break;
					}
					goto case 12;
				case 16:
					if (globalFactory.Check('>'))
					{
						goto end_IL_0012;
					}
					num2 = 7;
					break;
				case 7:
					throw new RegistryFactory(start, mapFactory.Mark(), DicSingleton.gE3WbyDVW(-1244021215 ^ -1244059503));
				case 19:
					if (!globalFactory.Check('<', 1))
					{
						num2 = 21;
						break;
					}
					goto case 25;
				case 10:
					text = ScanTagUri(text2, start);
					num2 = 6;
					break;
				case 25:
					text3 = string.Empty;
					num2 = 15;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 == 0)
					{
						num2 = 7;
					}
					break;
				case 9:
					if (text2[text2.Length - 1] == '!')
					{
						num2 = 6;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 != 0)
						{
							num2 = 8;
						}
						break;
					}
					goto case 10;
				case 2:
				case 4:
				case 17:
				case 26:
					if (!globalFactory.IsWhiteBreakOrZero())
					{
						num2 = 23;
						break;
					}
					goto case 5;
				case 11:
				case 21:
					text2 = ScanTagHandle(isDirective: false, start);
					num2 = 22;
					break;
				case 20:
					start = mapFactory.Mark();
					num2 = 19;
					break;
				case 13:
					text = ScanTagUri(null, start);
					num2 = 7;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 != 0)
					{
						num2 = 26;
					}
					break;
				case 22:
					if (text2.Length > 1)
					{
						num2 = 24;
						break;
					}
					goto case 10;
				case 24:
					if (text2[0] == '!')
					{
						num2 = 9;
						break;
					}
					goto case 10;
				case 3:
					Skip();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 == 0)
					{
						num2 = 0;
					}
					break;
				}
				continue;
				end_IL_0012:
				break;
			}
			Skip();
			num = 2;
		}
	}

	private void FetchBlockScalar(bool isLiteral)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				RemoveSimpleKey();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb != 0)
				{
					num2 = 0;
				}
				break;
			default:
				m_IdentifierFactory = true;
				num2 = 3;
				break;
			case 3:
				_DefinitionFactory.Enqueue(ScanBlockScalar(isLiteral));
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa != 0)
				{
					num2 = 1;
				}
				break;
			case 2:
				return;
			}
		}
	}

	private ModelFactory ScanBlockScalar(bool isLiteral)
	{
		int num = 86;
		bool? isFirstLine = default(bool?);
		StringBuilder stringBuilder2 = default(StringBuilder);
		int num5 = default(int);
		bool flag3 = default(bool);
		StringBuilder stringBuilder3 = default(StringBuilder);
		int num7 = default(int);
		int num6 = default(int);
		QueueReader end = default(QueueReader);
		bool? flag4 = default(bool?);
		bool flag2 = default(bool);
		bool flag = default(bool);
		QueueReader start = default(QueueReader);
		StringBuilder stringBuilder = default(StringBuilder);
		char c = default(char);
		RuleFactory style = default(RuleFactory);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				int num9;
				int num4;
				int num3;
				int num8;
				switch (num2)
				{
				case 63:
					if (!isFirstLine.HasValue)
					{
						num2 = 56;
						continue;
					}
					goto case 8;
				case 21:
				case 40:
					if (!globalFactory.IsBreakOrZero())
					{
						num2 = 57;
						continue;
					}
					goto case 38;
				case 20:
					stringBuilder2 = new StringBuilder();
					num2 = 29;
					continue;
				case 79:
					if (num5 == 1)
					{
						num2 = 76;
						continue;
					}
					goto case 4;
				case 70:
					Skip();
					num2 = 18;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a != 0)
					{
						num2 = 49;
					}
					continue;
				case 68:
					if (flag3)
					{
						num2 = 33;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0a707bb791e14c9e9a3ee77696a896b0 == 0)
						{
							num2 = 14;
						}
						continue;
					}
					goto case 5;
				case 56:
					isFirstLine = true;
					num2 = 87;
					continue;
				case 44:
				case 90:
					stringBuilder3.Append(stringBuilder2.ToString());
					num2 = 30;
					continue;
				case 73:
					if (globalFactory.Check('0'))
					{
						num = 89;
						break;
					}
					num7 = globalFactory.AsDigit();
					num2 = 31;
					continue;
				case 27:
					if (!isLiteral)
					{
						num2 = 83;
						continue;
					}
					goto case 11;
				case 81:
					if (globalFactory.IsDigit())
					{
						num2 = 73;
						continue;
					}
					goto case 58;
				case 22:
					if (num5 != -1)
					{
						num2 = 72;
						continue;
					}
					goto case 79;
				case 7:
					if (globalFactory.Check(DicSingleton.gE3WbyDVW(0xFB046CE ^ 0xFB0D176)))
					{
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa == 0)
						{
							num2 = 28;
						}
						continue;
					}
					goto case 12;
				case 13:
					if (mapperFactory < 0)
					{
						num2 = 88;
						continue;
					}
					num9 = mapperFactory + num7;
					goto IL_0b8d;
				case 51:
					num4 = -1;
					goto IL_0b68;
				case 17:
					SkipLine();
					num = 63;
					break;
				case 48:
					num6 = 0;
					num2 = 35;
					continue;
				case 76:
					stringBuilder3.Append((object)stringBuilder2);
					num2 = 4;
					continue;
				case 1:
				case 66:
					num6 = ScanBlockScalarBreaks(num6, stringBuilder2, isLiteral, ref end, ref isFirstLine);
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 == 0)
					{
						num2 = 10;
					}
					continue;
				case 71:
					isFirstLine = null;
					num2 = 19;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 == 0)
					{
						num2 = 34;
					}
					continue;
				case 45:
					if (flag4 != flag2)
					{
						num2 = 43;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 == 0)
						{
							num2 = 55;
						}
						continue;
					}
					goto case 77;
				case 36:
					if (IsDocumentEnd())
					{
						num2 = 22;
						continue;
					}
					goto case 60;
				case 39:
					flag = globalFactory.IsWhite();
					num2 = 12;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e == 0)
					{
						num2 = 21;
					}
					continue;
				case 42:
					throw new RegistryFactory(start, mapFactory.Mark(), DicSingleton.gE3WbyDVW(-1075938037 ^ -1075911665));
				case 2:
					if (!globalFactory.IsBreak())
					{
						num = 84;
						break;
					}
					goto case 17;
				case 65:
					stringBuilder.Length = 0;
					num2 = 11;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 == 0)
					{
						num2 = 90;
					}
					continue;
				case 77:
					isFirstLine = false;
					num2 = 43;
					continue;
				case 60:
					flag3 = globalFactory.IsWhite();
					num2 = 27;
					continue;
				case 11:
				case 19:
				case 33:
				case 41:
					stringBuilder3.Append(stringBuilder.ToString());
					num2 = 18;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 != 0)
					{
						num2 = 17;
					}
					continue;
				case 89:
					throw new RegistryFactory(start, mapFactory.Mark(), DicSingleton.gE3WbyDVW(-1466472923 ^ -1466437147));
				case 52:
					throw new RegistryFactory(start, mapFactory.Mark(), DicSingleton.gE3WbyDVW(0x2BC53863 ^ 0x2BC5AFA3));
				case 14:
					num7 = globalFactory.AsDigit();
					num2 = 70;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 != 0)
					{
						num2 = 40;
					}
					continue;
				case 54:
					num3 = 5;
					goto IL_0baa;
				case 12:
					if (globalFactory.IsDigit())
					{
						num2 = 23;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 == 0)
						{
							num2 = 22;
						}
						continue;
					}
					goto case 58;
				case 82:
					Skip();
					num2 = 56;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 != 0)
					{
						num2 = 81;
					}
					continue;
				case 86:
					stringBuilder3 = new StringBuilder();
					num2 = 85;
					continue;
				case 61:
					ProcessComment();
					num2 = 13;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa == 0)
					{
						num2 = 26;
					}
					continue;
				case 10:
				case 32:
					if (mapFactory.LineOffset == num6)
					{
						num2 = 62;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e != 0)
						{
							num2 = 22;
						}
						continue;
					}
					goto case 22;
				case 53:
				case 57:
					stringBuilder3.Append(ReadCurrentCharacter());
					num2 = 40;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7e7ae6cc25e34646baea4e1c2c087e7a == 0)
					{
						num2 = 12;
					}
					continue;
				case 74:
					if (globalFactory.Check('+'))
					{
						num2 = 3;
						continue;
					}
					goto case 51;
				case 64:
					Skip();
					num2 = 58;
					continue;
				case 38:
					c = ReadLine();
					num2 = 9;
					continue;
				case 18:
					stringBuilder.Length = 0;
					num2 = 44;
					continue;
				case 29:
					num5 = 0;
					num2 = 50;
					continue;
				case 30:
					stringBuilder2.Length = 0;
					num2 = 39;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 == 0)
					{
						num2 = 38;
					}
					continue;
				case 62:
					if (!globalFactory.IsZero())
					{
						num2 = 17;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba == 0)
						{
							num2 = 36;
						}
						continue;
					}
					goto case 22;
				case 37:
					num6 = ScanBlockScalarBreaks(num6, stringBuilder2, isLiteral, ref end, ref isFirstLine);
					num2 = 36;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab == 0)
					{
						num2 = 78;
					}
					continue;
				case 34:
					start = mapFactory.Mark();
					num2 = 24;
					continue;
				case 35:
					flag = false;
					num2 = 71;
					continue;
				case 5:
					if (stringBuilder2.Length == 0)
					{
						num2 = 69;
						continue;
					}
					goto case 65;
				case 69:
					stringBuilder3.Append(' ');
					num2 = 65;
					continue;
				case 49:
					if (!globalFactory.Check(DicSingleton.gE3WbyDVW(0x5A1B57A3 ^ 0x5A1BC01B)))
					{
						num2 = 62;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 != 0)
						{
							num2 = 80;
						}
						continue;
					}
					goto case 74;
				case 8:
					flag4 = isFirstLine;
					num2 = 47;
					continue;
				case 25:
					return new ConfigFactory(stringBuilder3.ToString(), style, start, end);
				case 28:
					if (!globalFactory.Check('+'))
					{
						num = 67;
						break;
					}
					num8 = 1;
					goto IL_0b57;
				case 24:
					Skip();
					num = 7;
					break;
				case 78:
					isFirstLine = false;
					num2 = 32;
					continue;
				case 16:
					throw new RegistryFactory(start, mapFactory.Mark(), DicSingleton.gE3WbyDVW(0x6CF51E1A ^ 0x6CF5864C));
				case 58:
				case 75:
				case 80:
					if (globalFactory.Check('#'))
					{
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 == 0)
						{
							num2 = 16;
						}
						continue;
					}
					goto case 59;
				case 50:
					num7 = 0;
					num2 = 48;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 != 0)
					{
						num2 = 36;
					}
					continue;
				case 85:
					stringBuilder = new StringBuilder();
					num2 = 11;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 != 0)
					{
						num2 = 20;
					}
					continue;
				case 43:
				case 55:
				case 84:
				case 87:
					end = mapFactory.Mark();
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3ac5d604ebd547e7ac5b1603a0e85187 != 0)
					{
						num2 = 3;
					}
					continue;
				case 31:
					Skip();
					num = 75;
					break;
				case 4:
					if (isLiteral)
					{
						num2 = 46;
						continue;
					}
					goto case 54;
				case 9:
					if (c == '\0')
					{
						num2 = 66;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 == 0)
						{
							num2 = 3;
						}
						continue;
					}
					goto case 15;
				case 15:
					stringBuilder.Append(c);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac != 0)
					{
						num2 = 1;
					}
					continue;
				case 59:
					if (globalFactory.IsWhite())
					{
						Skip();
						num2 = 59;
						continue;
					}
					num2 = 61;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef != 0)
					{
						num2 = 52;
					}
					continue;
				case 23:
					if (!globalFactory.Check('0'))
					{
						num = 14;
						break;
					}
					goto case 52;
				case 88:
					num9 = num7;
					goto IL_0b8d;
				case 67:
					num8 = -1;
					goto IL_0b57;
				case 72:
					stringBuilder3.Append((object)stringBuilder);
					num2 = 79;
					continue;
				case 6:
					if (num7 != 0)
					{
						num2 = 13;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec == 0)
						{
							num2 = 7;
						}
						continue;
					}
					goto case 37;
				case 47:
					flag2 = true;
					num2 = 45;
					continue;
				default:
					if (flag)
					{
						num2 = 11;
						continue;
					}
					goto case 68;
				case 83:
					if (!StartsWith(stringBuilder, '\n'))
					{
						num2 = 19;
						continue;
					}
					goto default;
				case 26:
					if (globalFactory.IsBreakOrZero())
					{
						num2 = 2;
						continue;
					}
					goto case 42;
				case 3:
					num4 = 1;
					goto IL_0b68;
				case 46:
					{
						num3 = 4;
						goto IL_0baa;
					}
					IL_0b68:
					num5 = num4;
					num2 = 64;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c != 0)
					{
						num2 = 0;
					}
					continue;
					IL_0b8d:
					num6 = num9;
					num2 = 18;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd == 0)
					{
						num2 = 37;
					}
					continue;
					IL_0b57:
					num5 = num8;
					num = 82;
					break;
					IL_0baa:
					style = (RuleFactory)num3;
					num2 = 25;
					continue;
				}
				break;
			}
		}
	}

	private int ScanBlockScalarBreaks(int currentIndent, StringBuilder breaks, bool isLiteral, ref QueueReader end, ref bool? isFirstLine)
	{
		int num = 27;
		int num2 = num;
		int num6 = default(int);
		int num5 = default(int);
		bool flag2 = default(bool);
		int num3 = default(int);
		int num4 = default(int);
		bool? flag = default(bool?);
		while (true)
		{
			switch (num2)
			{
			case 39:
				num6 = mapFactory.LineOffset;
				num2 = 29;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7e7ae6cc25e34646baea4e1c2c087e7a != 0)
				{
					num2 = 54;
				}
				continue;
			case 37:
				isFirstLine = false;
				num2 = 51;
				continue;
			case 1:
			case 33:
			case 40:
				if (currentIndent != 0)
				{
					num2 = 46;
					continue;
				}
				goto case 21;
			case 26:
				num5 = -1;
				num2 = 13;
				continue;
			case 53:
				end = mapFactory.Mark();
				num2 = 17;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb == 0)
				{
					num2 = 33;
				}
				continue;
			case 3:
				flag2 = true;
				num2 = 8;
				continue;
			case 45:
				if (mapperFactory > -1)
				{
					num2 = 35;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 == 0)
					{
						num2 = 20;
					}
					continue;
				}
				goto case 12;
			case 16:
			case 42:
				breaks.Append(ReadLine());
				num2 = 53;
				continue;
			case 46:
				if (mapFactory.LineOffset < currentIndent)
				{
					num2 = 21;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 == 0)
					{
						num2 = 19;
					}
					continue;
				}
				goto case 18;
			case 6:
				if (globalFactory.IsBreak(num3))
				{
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 != 0)
					{
						num2 = 15;
					}
					continue;
				}
				goto case 14;
			case 9:
			case 10:
				if (!globalFactory.IsBreak(num3))
				{
					num2 = 9;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2aaca7da964541af9780eb37df39c3db != 0)
					{
						num2 = 48;
					}
					continue;
				}
				goto case 6;
			case 14:
			case 22:
			case 43:
				if (!isLiteral)
				{
					num2 = 52;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add == 0)
					{
						num2 = 52;
					}
					continue;
				}
				goto case 29;
			case 24:
				if (!isLiteral)
				{
					num2 = 22;
					continue;
				}
				goto case 2;
			case 44:
				num4++;
				num2 = 9;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 == 0)
				{
					num2 = 3;
				}
				continue;
			case 7:
				if (flag == flag2)
				{
					num2 = 32;
					continue;
				}
				goto case 14;
			case 30:
				throw new TemplateFactory(end, mapFactory.Mark(), DicSingleton.gE3WbyDVW(-1931860206 ^ -1931821792));
			case 49:
				if (currentIndent != 0)
				{
					num2 = 12;
					continue;
				}
				goto case 41;
			case 25:
				throw new TemplateFactory(end, mapFactory.Mark(), DicSingleton.gE3WbyDVW(0x59C84793 ^ 0x59C8DE0D));
			case 23:
			case 52:
				if (!isLiteral)
				{
					num2 = 28;
					continue;
				}
				goto case 49;
			case 17:
			case 54:
				if (globalFactory.IsBreak())
				{
					num2 = 20;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f == 0)
					{
						num2 = 0;
					}
					continue;
				}
				goto case 24;
			case 11:
				if (currentIndent >= num5 - 1)
				{
					num2 = 23;
					continue;
				}
				goto case 25;
			case 4:
			case 50:
				num3++;
				num2 = 44;
				continue;
			case 2:
				flag = isFirstLine;
				num2 = 19;
				continue;
			case 13:
				end = mapFactory.Mark();
				num2 = 40;
				continue;
			case 5:
				num3 = 0;
				num2 = 10;
				continue;
			case 41:
				if (mapFactory.LineOffset <= 0)
				{
					num2 = 10;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba == 0)
					{
						num2 = 45;
					}
					continue;
				}
				goto case 35;
			case 28:
				if (num6 <= mapFactory.LineOffset)
				{
					num2 = 45;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c == 0)
					{
						num2 = 49;
					}
					continue;
				}
				goto case 31;
			case 47:
				num5 = mapFactory.LineOffset;
				num2 = 42;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 == 0)
				{
					num2 = 17;
				}
				continue;
			case 27:
				num6 = 0;
				num2 = 26;
				continue;
			case 51:
				num5 = num4;
				num2 = 14;
				continue;
			case 32:
				num4 = mapFactory.LineOffset;
				num2 = 5;
				continue;
			case 36:
				Skip();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba == 0)
				{
					num2 = 1;
				}
				continue;
			case 31:
				if (num5 > -1)
				{
					num2 = 30;
					continue;
				}
				goto case 49;
			case 35:
				currentIndent = Math.Max(num6, Math.Max(mapperFactory + 1, 1));
				num2 = 34;
				continue;
			case 18:
				if (mapFactory.LineOffset <= num6)
				{
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 != 0)
					{
						num2 = 17;
					}
					continue;
				}
				goto case 39;
			default:
				flag = isFirstLine;
				num2 = 3;
				continue;
			case 19:
				flag2 = true;
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef == 0)
				{
					num2 = 7;
				}
				continue;
			case 21:
				if (!globalFactory.IsSpace())
				{
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb == 0)
					{
						num2 = 18;
					}
					continue;
				}
				goto case 36;
			case 29:
				if (num5 > 1)
				{
					num2 = 11;
					continue;
				}
				goto case 23;
			case 15:
				if (num4 > mapFactory.LineOffset)
				{
					num2 = 37;
					continue;
				}
				goto case 14;
			case 12:
			case 34:
				return currentIndent;
			case 8:
				if (flag != flag2)
				{
					num2 = 16;
					continue;
				}
				break;
			case 48:
				if (globalFactory.IsSpace(num3))
				{
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf != 0)
					{
						num2 = 4;
					}
					continue;
				}
				goto case 6;
			case 38:
				break;
			}
			isFirstLine = false;
			num2 = 44;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 == 0)
			{
				num2 = 47;
			}
		}
	}

	private void FetchFlowScalar(bool isSingleQuoted)
	{
		int num = 1;
		QueueReader queueReader = default(QueueReader);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 6:
					if (!globalFactory.Check('#'))
					{
						num2 = 4;
						continue;
					}
					goto case 8;
				case 4:
					return;
				case 5:
					return;
				case 8:
					queueReader = mapFactory.Mark();
					num2 = 7;
					continue;
				case 1:
					SaveSimpleKey();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3aab303a2946368dda3deef055dc93 != 0)
					{
						num2 = 0;
					}
					continue;
				case 2:
					if (isSingleQuoted)
					{
						return;
					}
					num2 = 6;
					continue;
				case 3:
					_DefinitionFactory.Enqueue(ScanFlowScalar(isSingleQuoted));
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 == 0)
					{
						num2 = 1;
					}
					continue;
				case 7:
					_DefinitionFactory.Enqueue(new ParameterFactory(DicSingleton.gE3WbyDVW(-948533799 ^ -948560075), queueReader, queueReader));
					num2 = 5;
					continue;
				}
				break;
			}
			m_IdentifierFactory = false;
			num = 3;
		}
	}

	private ModelFactory ScanFlowScalar(bool isSingleQuoted)
	{
		int num = 42;
		bool flag = default(bool);
		QueueReader start = default(QueueReader);
		StringBuilder stringBuilder4 = default(StringBuilder);
		StringBuilder stringBuilder = default(StringBuilder);
		int num5 = default(int);
		StringBuilder stringBuilder3 = default(StringBuilder);
		int num4 = default(int);
		StringBuilder stringBuilder2 = default(StringBuilder);
		char c = default(char);
		int num3 = default(int);
		char value = default(char);
		int num6 = default(int);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 26:
					if (!flag)
					{
						num2 = 47;
						continue;
					}
					goto case 4;
				case 61:
					throw new RegistryFactory(start, mapFactory.Mark(), DicSingleton.gE3WbyDVW(0x55F5513C ^ 0x55F5CC7C));
				case 28:
				case 81:
				case 91:
				case 92:
					Skip();
					num2 = 111;
					continue;
				case 44:
				case 68:
				case 103:
				case 113:
					if (globalFactory.IsWhiteBreakOrZero())
					{
						num2 = 40;
						continue;
					}
					goto case 53;
				case 86:
					stringBuilder4.Append(ReadLine());
					num2 = 96;
					continue;
				case 67:
					flag = true;
					num2 = 94;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 == 0)
					{
						num2 = 80;
					}
					continue;
				case 15:
					if (!globalFactory.Check('\'', 1))
					{
						num2 = 8;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 == 0)
						{
							num2 = 9;
						}
						continue;
					}
					goto case 112;
				case 3:
					throw new RegistryFactory(start, mapFactory.Mark(), DicSingleton.gE3WbyDVW(-1461449777 ^ -1461414505));
				case 72:
					stringBuilder.Append(char.ConvertFromUtf32(num5));
					num2 = 36;
					continue;
				case 106:
					throw new RegistryFactory(start, mapFactory.Mark(), DicSingleton.gE3WbyDVW(-1447578472 ^ -1447614118));
				case 17:
					throw new RegistryFactory(start, mapFactory.Mark(), DicSingleton.gE3WbyDVW(0x55F5513C ^ 0x55F5CD1A));
				case 65:
					if (!flag)
					{
						num2 = 23;
						continue;
					}
					goto case 7;
				case 6:
				case 39:
				case 70:
				case 107:
				case 114:
					if (!globalFactory.IsWhite())
					{
						num2 = 59;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae50b6e347494ff2973fbc64d1fc9236 != 0)
						{
							num2 = 51;
						}
						continue;
					}
					goto case 55;
				case 14:
					stringBuilder.Append(stringBuilder3.ToString());
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 == 0)
					{
						num2 = 0;
					}
					continue;
				case 35:
					num4++;
					num2 = 27;
					continue;
				case 45:
					stringBuilder.Append(stringBuilder2.ToString());
					num2 = 9;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 == 0)
					{
						num2 = 48;
					}
					continue;
				case 31:
					c = globalFactory.Peek(1);
					num2 = 13;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 == 0)
					{
						num2 = 13;
					}
					continue;
				case 50:
					Skip();
					num2 = 33;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f == 0)
					{
						num2 = 85;
					}
					continue;
				case 64:
					if (!globalFactory.IsBreak(1))
					{
						num2 = 22;
						continue;
					}
					goto case 57;
				case 109:
					Skip();
					num2 = 32;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 != 0)
					{
						num2 = 69;
					}
					continue;
				case 95:
					if (mapperFactory < mapFactory.LineOffset)
					{
						num2 = 5;
						continue;
					}
					goto case 52;
				case 18:
					stringBuilder3.Append(ReadCurrentCharacter());
					num2 = 39;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 == 0)
					{
						num2 = 29;
					}
					continue;
				case 57:
					Skip();
					num2 = 110;
					continue;
				case 66:
					stringBuilder = new StringBuilder();
					num2 = 61;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 == 0)
					{
						num2 = 83;
					}
					continue;
				case 8:
					stringBuilder3.Length = 0;
					num2 = 43;
					continue;
				case 52:
					throw new RegistryFactory(start, mapFactory.Mark(), DicSingleton.gE3WbyDVW(-166253478 ^ -166219534));
				case 5:
				case 21:
				case 23:
					flag = false;
					num2 = 44;
					continue;
				case 87:
					if (isSingleQuoted)
					{
						num2 = 28;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd == 0)
						{
							num2 = 84;
						}
						continue;
					}
					goto case 51;
				case 13:
					if (c != 'U')
					{
						num = 77;
						break;
					}
					goto case 89;
				case 36:
					num3 = 0;
					num2 = 100;
					continue;
				default:
					if (globalFactory.Check('\\'))
					{
						num2 = 99;
						continue;
					}
					goto case 11;
				case 112:
					stringBuilder.Append('\'');
					num2 = 72;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 != 0)
					{
						num2 = 109;
					}
					continue;
				case 111:
					Skip();
					num = 88;
					break;
				case 33:
					if (stringBuilder2.Length == 0)
					{
						num2 = 54;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 != 0)
						{
							num2 = 25;
						}
						continue;
					}
					goto case 45;
				case 49:
					stringBuilder.Append(value);
					num2 = 28;
					continue;
				case 79:
					stringBuilder2 = new StringBuilder();
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be != 0)
					{
						num2 = 29;
					}
					continue;
				case 78:
					throw new RegistryFactory(start, mapFactory.Mark(), DicSingleton.gE3WbyDVW(0x5901407C ^ 0x5901DBE6));
				case 38:
				case 48:
				case 56:
					stringBuilder4.Length = 0;
					num2 = 25;
					continue;
				case 25:
					stringBuilder2.Length = 0;
					num2 = 58;
					continue;
				case 19:
					stringBuilder4 = new StringBuilder();
					num2 = 79;
					continue;
				case 10:
				case 22:
				case 84:
				case 104:
					if (!isSingleQuoted)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb != 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 11;
				case 41:
					Skip();
					num2 = 66;
					continue;
				case 93:
					if (num5 > 57343)
					{
						num2 = 97;
						continue;
					}
					goto case 3;
				case 63:
					if (flag)
					{
						num2 = 30;
						continue;
					}
					goto case 18;
				case 88:
					if (num6 > 0)
					{
						num2 = 34;
						continue;
					}
					goto case 44;
				case 83:
					stringBuilder3 = new StringBuilder();
					num2 = 19;
					continue;
				case 71:
					num6 = 4;
					num2 = 81;
					continue;
				case 47:
					stringBuilder3.Length = 0;
					num2 = 86;
					continue;
				case 75:
					if (!StartsWith(stringBuilder4, '\n'))
					{
						num = 105;
						break;
					}
					goto case 33;
				case 54:
					stringBuilder.Append(' ');
					num = 56;
					break;
				case 34:
					num5 = 0;
					num2 = 73;
					continue;
				case 20:
				case 105:
					stringBuilder.Append(stringBuilder4.ToString());
					num = 76;
					break;
				case 24:
					if (flag)
					{
						num2 = 38;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_23f9d18f43004f488662f38dd306f6ec == 0)
						{
							num2 = 75;
						}
						continue;
					}
					goto case 14;
				case 46:
				case 98:
					Skip();
					num2 = 16;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 == 0)
					{
						num2 = 8;
					}
					continue;
				case 110:
					SkipLine();
					num = 67;
					break;
				case 27:
				case 32:
					if (num4 < num6)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e != 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 2;
				case 7:
					if (isSingleQuoted)
					{
						num2 = 21;
						continue;
					}
					goto case 95;
				case 42:
					start = mapFactory.Mark();
					num2 = 41;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 == 0)
					{
						num2 = 16;
					}
					continue;
				case 59:
					if (globalFactory.IsBreak())
					{
						num2 = 32;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a != 0)
						{
							num2 = 60;
						}
						continue;
					}
					goto case 24;
				case 85:
					num3++;
					num2 = 102;
					continue;
				case 29:
					flag = false;
					num2 = 62;
					continue;
				case 82:
					num6 = 2;
					num2 = 92;
					continue;
				case 90:
					if (m_ProducerFactory.TryGetValue(c, out value))
					{
						num2 = 49;
						continue;
					}
					goto case 61;
				case 43:
				case 58:
				case 62:
					if (!IsDocumentIndicator())
					{
						if (!globalFactory.IsZero())
						{
							num2 = 16;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a != 0)
							{
								num2 = 65;
							}
							continue;
						}
						goto case 17;
					}
					num2 = 78;
					continue;
				case 73:
					num4 = 0;
					num2 = 32;
					continue;
				case 11:
					stringBuilder.Append(ReadCurrentCharacter());
					num2 = 103;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 != 0)
					{
						num2 = 14;
					}
					continue;
				case 74:
				case 97:
					if (num5 <= 1114111)
					{
						num2 = 67;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef == 0)
						{
							num2 = 72;
						}
						continue;
					}
					goto case 3;
				case 89:
					num6 = 8;
					num2 = 91;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
					{
						num2 = 5;
					}
					continue;
				case 2:
					if (num5 < 55296)
					{
						num2 = 74;
						continue;
					}
					goto case 93;
				case 80:
					if (globalFactory.Check('\''))
					{
						num2 = 15;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e != 0)
						{
							num2 = 15;
						}
						continue;
					}
					goto case 9;
				case 69:
					Skip();
					num2 = 113;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd != 0)
					{
						num2 = 104;
					}
					continue;
				case 76:
					stringBuilder.Append(stringBuilder2.ToString());
					num2 = 38;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 == 0)
					{
						num2 = 37;
					}
					continue;
				case 99:
					num6 = 0;
					num2 = 24;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c == 0)
					{
						num2 = 31;
					}
					continue;
				case 96:
					flag = true;
					num2 = 70;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ea4c8b68ad954c0fb4df33d6e06bd4a3 != 0)
					{
						num2 = 35;
					}
					continue;
				case 30:
				case 101:
					Skip();
					num2 = 114;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_91887e48b8104e7da08b48f73b607337 == 0)
					{
						num2 = 66;
					}
					continue;
				case 100:
				case 102:
					if (num3 >= num6)
					{
						num2 = 68;
						continue;
					}
					goto case 50;
				case 51:
					if (!globalFactory.Check('\\'))
					{
						num2 = 10;
						continue;
					}
					goto case 64;
				case 4:
					stringBuilder2.Append(ReadLine());
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 == 0)
					{
						num2 = 6;
					}
					continue;
				case 53:
					if (isSingleQuoted)
					{
						num2 = 80;
						continue;
					}
					goto case 9;
				case 12:
					if (c == 'x')
					{
						num2 = 82;
						continue;
					}
					goto case 90;
				case 55:
				case 60:
					if (globalFactory.IsWhite())
					{
						num = 63;
						break;
					}
					goto case 26;
				case 1:
				case 37:
					if (globalFactory.IsHex(num4))
					{
						num5 = (num5 << 4) + globalFactory.AsHex(num4);
						num = 35;
						break;
					}
					num2 = 106;
					continue;
				case 77:
					if (c != 'u')
					{
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be != 0)
						{
							num2 = 12;
						}
						continue;
					}
					goto case 71;
				case 9:
				case 108:
					if (!globalFactory.Check(isSingleQuoted ? '\'' : '"'))
					{
						num2 = 65;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add == 0)
						{
							num2 = 87;
						}
						continue;
					}
					goto case 40;
				case 40:
				case 94:
					if (globalFactory.Check(isSingleQuoted ? '\'' : '"'))
					{
						goto case 46;
					}
					num2 = 107;
					continue;
				case 16:
					return new ConfigFactory(stringBuilder.ToString(), isSingleQuoted ? ((RuleFactory)2) : ((RuleFactory)3), start, mapFactory.Mark());
				}
				break;
			}
		}
	}

	private void FetchPlainScalar()
	{
		int num = 1;
		ConfigFactory item = default(ConfigFactory);
		bool isMultiline = default(bool);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 1:
					SaveSimpleKey();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 == 0)
					{
						num2 = 0;
					}
					continue;
				case 9:
					goto end_IL_0012;
				case 4:
					if (_TokenFactory == 0)
					{
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 != 0)
						{
							num2 = 8;
						}
						continue;
					}
					break;
				case 11:
					_DefinitionFactory.Enqueue(new ParameterFactory(DicSingleton.gE3WbyDVW(-1338893851 ^ -1338865903), mapFactory.Mark(), mapFactory.Mark()));
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 == 0)
					{
						num2 = 3;
					}
					continue;
				case 10:
					item = ScanPlainScalar(ref isMultiline);
					num2 = 5;
					continue;
				case 8:
					if (mapperFactory < mapFactory.LineOffset)
					{
						num2 = 11;
						continue;
					}
					break;
				case 2:
					return;
				case 7:
					if (globalFactory.Check(':'))
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 != 0)
						{
							num2 = 4;
						}
						continue;
					}
					break;
				default:
					m_IdentifierFactory = false;
					num2 = 9;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a579dea83d2144838086d2d400bd0222 == 0)
					{
						num2 = 8;
					}
					continue;
				case 5:
					if (!isMultiline)
					{
						num2 = 6;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e == 0)
						{
							num2 = 5;
						}
						continue;
					}
					goto case 7;
				case 3:
				case 6:
					break;
				}
				_DefinitionFactory.Enqueue(item);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 != 0)
				{
					num2 = 2;
				}
				continue;
				end_IL_0012:
				break;
			}
			isMultiline = false;
			num = 10;
		}
	}

	private ConfigFactory ScanPlainScalar(ref bool isMultiline)
	{
		int num = 74;
		StringBuilder stringBuilder4 = default(StringBuilder);
		bool flag2 = default(bool);
		PredicateFactory predicateFactory = default(PredicateFactory);
		StringBuilder stringBuilder3 = default(StringBuilder);
		StringBuilder stringBuilder = default(StringBuilder);
		StringBuilder stringBuilder2 = default(StringBuilder);
		int num4 = default(int);
		bool flag = default(bool);
		QueueReader queueReader = default(QueueReader);
		QueueReader end = default(QueueReader);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				int num3;
				switch (num2)
				{
				case 43:
					stringBuilder4 = new StringBuilder();
					num2 = 41;
					continue;
				case 84:
					if (flag2)
					{
						num = 86;
						break;
					}
					goto case 5;
				case 5:
					if (!globalFactory.IsWhiteBreakOrZero(1))
					{
						num2 = 41;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 == 0)
						{
							num2 = 42;
						}
						continue;
					}
					goto case 2;
				case 75:
					if (_TokenFactory == 0)
					{
						num2 = 56;
						continue;
					}
					goto case 27;
				case 97:
					num3 = ((!predicateFactory.IsRequired) ? 1 : 0);
					goto IL_0be7;
				case 6:
					if (globalFactory.IsBreak())
					{
						num2 = 65;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3aab303a2946368dda3deef055dc93 != 0)
						{
							num2 = 60;
						}
						continue;
					}
					goto case 75;
				case 13:
					if (StartsWith(stringBuilder4, '\n'))
					{
						num2 = 27;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 == 0)
						{
							num2 = 33;
						}
						continue;
					}
					goto case 24;
				default:
					if (stringBuilder3.Length <= 0)
					{
						num2 = 57;
						continue;
					}
					goto case 3;
				case 41:
					stringBuilder = new StringBuilder();
					num2 = 90;
					continue;
				case 93:
					stringBuilder3.Length = 0;
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 == 0)
					{
						num2 = 40;
					}
					continue;
				case 25:
					throw new Exception();
				case 19:
					stringBuilder2.Append(ReadCurrentCharacter());
					num2 = 17;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 != 0)
					{
						num2 = 81;
					}
					continue;
				case 15:
					if (globalFactory.Check(',', 1))
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 != 0)
						{
							num2 = 2;
						}
						continue;
					}
					goto case 18;
				case 18:
				case 68:
				case 86:
					if (_TokenFactory <= 0)
					{
						num2 = 7;
						continue;
					}
					goto case 16;
				case 91:
					stringBuilder3.Length = 0;
					num2 = 72;
					continue;
				case 20:
				case 36:
				case 52:
					if (globalFactory.IsWhite())
					{
						num2 = 37;
						continue;
					}
					goto case 22;
				case 54:
					if (mapFactory.LineOffset < num4)
					{
						num2 = 34;
						continue;
					}
					goto case 94;
				case 35:
					m_ItemFactory = true;
					num2 = 23;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 == 0)
					{
						num2 = 9;
					}
					continue;
				case 11:
					stringBuilder2.Append((object)stringBuilder);
					num2 = 89;
					continue;
				case 92:
					stringBuilder2.Append(' ');
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f92fb16082174ff29c1cf0085d4a3cb9 != 0)
					{
						num2 = 1;
					}
					continue;
				case 37:
				case 53:
				case 59:
				case 67:
				case 95:
					if (!globalFactory.IsWhite())
					{
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 == 0)
						{
							num2 = 6;
						}
						continue;
					}
					goto case 9;
				case 69:
					if (!predicateFactory.IsPossible)
					{
						num2 = 55;
						continue;
					}
					goto case 20;
				case 9:
				case 65:
					if (globalFactory.IsWhite())
					{
						num2 = 32;
						continue;
					}
					goto case 88;
				case 2:
				case 64:
					if (_TokenFactory != 0)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 == 0)
						{
							num2 = 52;
						}
						continue;
					}
					goto case 69;
				case 42:
					if (_TokenFactory <= 0)
					{
						num2 = 18;
						continue;
					}
					goto case 15;
				case 22:
					if (!globalFactory.IsBreak())
					{
						num2 = 76;
						continue;
					}
					goto case 37;
				case 88:
					isMultiline = true;
					num2 = 77;
					continue;
				case 3:
				case 39:
					if (flag)
					{
						num2 = 13;
						continue;
					}
					goto case 79;
				case 32:
					if (!flag)
					{
						num2 = 94;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a == 0)
						{
							num2 = 40;
						}
						continue;
					}
					goto case 54;
				case 34:
					if (globalFactory.IsTab())
					{
						num2 = 30;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a == 0)
						{
							num2 = 8;
						}
						continue;
					}
					goto case 94;
				case 40:
					stringBuilder4.Append(ReadLine());
					num2 = 46;
					continue;
				case 8:
				case 50:
					return new ConfigFactory(stringBuilder2.ToString(), (RuleFactory)1, queueReader, end);
				case 63:
					m_IdentifierFactory = true;
					num2 = 50;
					continue;
				case 73:
					stringBuilder3 = new StringBuilder();
					num2 = 43;
					continue;
				case 4:
				case 60:
					if (globalFactory.Check(':'))
					{
						num2 = 84;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 != 0)
						{
							num2 = 19;
						}
						continue;
					}
					goto case 18;
				case 80:
					if (!globalFactory.Check('#'))
					{
						num2 = 29;
						continue;
					}
					goto case 31;
				case 46:
					flag = true;
					num2 = 53;
					continue;
				case 33:
					if (stringBuilder.Length == 0)
					{
						num2 = 92;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 != 0)
						{
							num2 = 15;
						}
						continue;
					}
					goto case 11;
				case 78:
					stringBuilder2.Append((object)stringBuilder);
					num2 = 64;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 != 0)
					{
						num2 = 87;
					}
					continue;
				case 31:
					if (mapperFactory < 0)
					{
						num2 = 96;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb == 0)
						{
							num2 = 2;
						}
						continue;
					}
					goto case 23;
				case 55:
					_DefinitionFactory.Enqueue(new ParameterFactory(DicSingleton.gE3WbyDVW(0x3FCF6129 ^ 0x3FCFFE5F), mapFactory.Mark(), mapFactory.Mark()));
					num2 = 20;
					continue;
				case 1:
				case 87:
				case 89:
					stringBuilder4.Length = 0;
					num = 28;
					break;
				case 14:
				case 57:
				case 72:
					if (_TokenFactory <= 0)
					{
						num2 = 19;
						continue;
					}
					goto case 49;
				case 96:
					if (_TokenFactory != 0)
					{
						num2 = 45;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 != 0)
						{
							num2 = 12;
						}
						continue;
					}
					goto case 35;
				case 44:
					stringBuilder3.Append(ReadCurrentCharacter());
					num2 = 95;
					continue;
				case 28:
					stringBuilder.Length = 0;
					num2 = 71;
					continue;
				case 62:
					end = queueReader;
					num2 = 85;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 == 0)
					{
						num2 = 79;
					}
					continue;
				case 21:
				case 29:
					if (globalFactory.Check('*'))
					{
						num2 = 17;
						continue;
					}
					num3 = 0;
					goto IL_0be7;
				case 24:
					stringBuilder2.Append((object)stringBuilder4);
					num = 78;
					break;
				case 90:
					flag = false;
					num2 = 26;
					continue;
				case 30:
					throw new RegistryFactory(queueReader, mapFactory.Mark(), DicSingleton.gE3WbyDVW(-833481355 ^ -833451387));
				case 94:
					if (flag)
					{
						num2 = 51;
						continue;
					}
					goto case 44;
				case 26:
					num4 = mapperFactory + 1;
					num2 = 47;
					continue;
				case 77:
					if (flag)
					{
						num2 = 66;
						continue;
					}
					goto case 93;
				case 49:
					if (mapFactory.LineOffset < num4)
					{
						num2 = 7;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac == 0)
						{
							num2 = 25;
						}
						continue;
					}
					goto case 19;
				case 82:
				case 83:
					if (!globalFactory.IsWhiteBreakOrZero())
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e == 0)
						{
							num2 = 60;
						}
						continue;
					}
					goto case 20;
				case 27:
				case 58:
					if (IsDocumentIndicator())
					{
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ea4c8b68ad954c0fb4df33d6e06bd4a3 == 0)
						{
							num2 = 61;
						}
						continue;
					}
					goto case 80;
				case 17:
					if (!predicateFactory.IsPossible)
					{
						num2 = 48;
						continue;
					}
					goto case 97;
				case 23:
				case 45:
				case 61:
				case 70:
				case 76:
					if (!flag)
					{
						num2 = 8;
						continue;
					}
					goto case 63;
				case 56:
					if (mapFactory.LineOffset >= num4)
					{
						num = 27;
						break;
					}
					goto case 23;
				case 10:
				case 51:
					Skip();
					num2 = 53;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 == 0)
					{
						num2 = 67;
					}
					continue;
				case 81:
					end = mapFactory.Mark();
					num2 = 82;
					continue;
				case 71:
					flag = false;
					num2 = 14;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0a707bb791e14c9e9a3ee77696a896b0 == 0)
					{
						num2 = 10;
					}
					continue;
				case 79:
					stringBuilder2.Append((object)stringBuilder3);
					num2 = 91;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
					{
						num2 = 67;
					}
					continue;
				case 47:
					queueReader = mapFactory.Mark();
					num2 = 62;
					continue;
				case 74:
					stringBuilder2 = new StringBuilder();
					num2 = 73;
					continue;
				case 12:
				case 66:
					stringBuilder.Append(ReadLine());
					num2 = 50;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 != 0)
					{
						num2 = 59;
					}
					continue;
				case 85:
					predicateFactory = _ComposerFactory.Peek();
					num2 = 58;
					continue;
				case 7:
				case 38:
					if (flag)
					{
						num2 = 39;
						continue;
					}
					goto default;
				case 16:
					if (globalFactory.Check(DicSingleton.gE3WbyDVW(-1891833728 ^ -1891856112)))
					{
						num2 = 64;
						continue;
					}
					goto case 7;
				case 48:
					{
						num3 = 1;
						goto IL_0be7;
					}
					IL_0be7:
					flag2 = (byte)num3 != 0;
					num2 = 83;
					continue;
				}
				break;
			}
		}
	}

	private void RemoveSimpleKey()
	{
		int num = 2;
		PredicateFactory predicateFactory = default(PredicateFactory);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 5:
					throw new RegistryFactory(predicateFactory.Mark, predicateFactory.Mark, DicSingleton.gE3WbyDVW(0x554A128B ^ 0x554A9CC7));
				default:
					predicateFactory.MarkAsImpossible();
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 == 0)
					{
						num2 = 1;
					}
					break;
				case 3:
					return;
				case 2:
					predicateFactory = _ComposerFactory.Peek();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb == 0)
					{
						num2 = 1;
					}
					break;
				case 1:
					if (!predicateFactory.IsPossible)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 == 0)
						{
							num2 = 0;
						}
						break;
					}
					goto case 4;
				case 4:
					if (!predicateFactory.IsRequired)
					{
						goto end_IL_0012;
					}
					goto case 5;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 6;
		}
	}

	private string ScanDirectiveName(QueueReader start)
	{
		int num = 1;
		StringBuilder stringBuilder = default(StringBuilder);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					if (globalFactory.IsAlphaNumericDashOrUnderscore())
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 == 0)
						{
							num2 = 2;
						}
						break;
					}
					goto case 3;
				case 8:
					throw new RegistryFactory(start, mapFactory.Mark(), DicSingleton.gE3WbyDVW(0x9000142 ^ 0x900A1D2));
				case 7:
					if (!globalFactory.IsWhiteBreakOrZero())
					{
						num2 = 4;
						break;
					}
					return stringBuilder.ToString();
				case 4:
					throw new RegistryFactory(start, mapFactory.Mark(), DicSingleton.gE3WbyDVW(-1880453928 ^ -1880478270));
				case 1:
					stringBuilder = new StringBuilder();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc == 0)
					{
						num2 = 0;
					}
					break;
				case 3:
					if (stringBuilder.Length != 0)
					{
						goto end_IL_0012;
					}
					goto case 8;
				case 2:
				case 6:
					stringBuilder.Append(ReadCurrentCharacter());
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_575e6bd686b54d028cdc3fc324b58a39 != 0)
					{
						num2 = 5;
					}
					break;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 7;
		}
	}

	private void SkipWhitespaces()
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				Skip();
				num2 = 3;
				break;
			case 4:
				return;
			case 2:
			case 3:
				if (!globalFactory.IsWhite())
				{
					return;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	private ModelFactory ScanVersionDirectiveValue(QueueReader start)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				SkipWhitespaces();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec == 0)
				{
					num2 = 0;
				}
				continue;
			}
			int major = ScanVersionDirectiveNumber(start);
			if (!globalFactory.Check('.'))
			{
				throw new RegistryFactory(start, mapFactory.Mark(), DicSingleton.gE3WbyDVW(-1385030784 ^ -1384990162));
			}
			Skip();
			int minor = ScanVersionDirectiveNumber(start);
			return new ProcessFactory(new WorkerFactory(major, minor), start, start);
		}
	}

	private ModelFactory ScanTagDirectiveValue(QueueReader start)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				SkipWhitespaces();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_23f9d18f43004f488662f38dd306f6ec == 0)
				{
					num2 = 0;
				}
				continue;
			}
			string handle = ScanTagHandle(isDirective: true, start);
			if (!globalFactory.IsWhite())
			{
				throw new RegistryFactory(start, mapFactory.Mark(), DicSingleton.gE3WbyDVW(0x7FAAD78F ^ 0x7FAA75DF));
			}
			SkipWhitespaces();
			string prefix = ScanTagUri(null, start);
			if (!globalFactory.IsWhiteBreakOrZero())
			{
				throw new RegistryFactory(start, mapFactory.Mark(), DicSingleton.gE3WbyDVW(-32559551 ^ -32535399));
			}
			return new ErrorFactory(handle, prefix, start, start);
		}
	}

	private string ScanTagUri([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] string head, QueueReader start)
	{
		int num = 14;
		int num2 = num;
		StringBuilder stringBuilder = default(StringBuilder);
		while (true)
		{
			switch (num2)
			{
			case 19:
				if (!globalFactory.Check(DicSingleton.gE3WbyDVW(--1509395337 ^ 0x59F728F5)))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 5;
			case 1:
				stringBuilder.Append(' ');
				num2 = 17;
				break;
			case 11:
				return string.Empty;
			case 4:
				return stringBuilder.ToString();
			case 15:
				if (head.Length <= 1)
				{
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 12;
			default:
				if (globalFactory.Check(','))
				{
					num2 = 18;
					break;
				}
				goto case 7;
			case 13:
				if (head != null)
				{
					num2 = 15;
					break;
				}
				goto case 2;
			case 7:
				if (stringBuilder.Length != 0)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a != 0)
					{
						num2 = 4;
					}
					break;
				}
				goto case 11;
			case 18:
				if (globalFactory.IsBreak(1))
				{
					num2 = 7;
					break;
				}
				goto case 5;
			case 14:
				stringBuilder = new StringBuilder();
				num2 = 13;
				break;
			case 5:
			case 23:
				if (!globalFactory.Check('%'))
				{
					num2 = 16;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f == 0)
					{
						num2 = 8;
					}
					break;
				}
				goto case 10;
			case 16:
			case 22:
				if (!globalFactory.Check('+'))
				{
					num2 = 9;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba != 0)
					{
						num2 = 6;
					}
					break;
				}
				goto case 1;
			case 2:
			case 3:
			case 6:
			case 20:
			case 21:
				if (globalFactory.IsAlphaNumericDashOrUnderscore())
				{
					num2 = 5;
					break;
				}
				goto case 19;
			case 10:
				stringBuilder.Append(ScanUriEscapes(start));
				num2 = 6;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c != 0)
				{
					num2 = 1;
				}
				break;
			case 12:
				stringBuilder.Append(head.Substring(1));
				num2 = 20;
				break;
			case 8:
			case 9:
				stringBuilder.Append(ReadCurrentCharacter());
				num2 = 2;
				break;
			case 17:
				Skip();
				num2 = 9;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 == 0)
				{
					num2 = 21;
				}
				break;
			}
		}
	}

	private string ScanUriEscapes(QueueReader start)
	{
		byte[] array = m_MethodFactory;
		int count = 0;
		int num = 0;
		do
		{
			if (!globalFactory.Check('%') || !globalFactory.IsHex(1) || !globalFactory.IsHex(2))
			{
				throw new RegistryFactory(start, mapFactory.Mark(), DicSingleton.gE3WbyDVW(0xFB046CE ^ 0xFB0E568));
			}
			int num2 = (globalFactory.AsHex(1) << 4) + globalFactory.AsHex(2);
			if (num == 0)
			{
				num = (((num2 & 0x80) == 0) ? 1 : (((num2 & 0xE0) == 192) ? 2 : (((num2 & 0xF0) == 224) ? 3 : (((num2 & 0xF8) == 240) ? 4 : 0))));
				if (num == 0)
				{
					throw new RegistryFactory(start, mapFactory.Mark(), DicSingleton.gE3WbyDVW(0x6CF51E1A ^ 0x6CF5BA0E));
				}
				array = new byte[num];
			}
			else if ((num2 & 0xC0) != 128)
			{
				throw new RegistryFactory(start, mapFactory.Mark(), DicSingleton.gE3WbyDVW(-1053593978 ^ -1053570540));
			}
			array[count++] = (byte)num2;
			Skip();
			Skip();
			Skip();
		}
		while (--num > 0);
		string text = Encoding.UTF8.GetString(array, 0, count);
		if (text.Length == 0 || text.Length > 2)
		{
			throw new RegistryFactory(start, mapFactory.Mark(), DicSingleton.gE3WbyDVW(-1830690703 ^ -1830730397));
		}
		return text;
	}

	private string ScanTagHandle(bool isDirective, QueueReader start)
	{
		int num = 2;
		StringBuilder stringBuilder = default(StringBuilder);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 3:
					if (stringBuilder.Length == 1)
					{
						num2 = 6;
						continue;
					}
					goto case 5;
				case 2:
					if (globalFactory.Check('!'))
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 != 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 12;
				case 11:
				case 13:
					if (isDirective)
					{
						num2 = 3;
						continue;
					}
					goto case 10;
				case 14:
					if (!globalFactory.Check('!'))
					{
						num2 = 11;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 != 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 7;
				case 7:
					stringBuilder.Append(ReadCurrentCharacter());
					num2 = 10;
					continue;
				case 4:
				case 9:
					if (!globalFactory.IsAlphaNumericDashOrUnderscore())
					{
						num2 = 14;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 != 0)
						{
							num2 = 13;
						}
						continue;
					}
					goto default;
				case 5:
					throw new RegistryFactory(start, mapFactory.Mark(), DicSingleton.gE3WbyDVW(-1123846595 ^ -1123822633));
				case 10:
					return stringBuilder.ToString();
				default:
					stringBuilder.Append(ReadCurrentCharacter());
					num2 = 9;
					continue;
				case 12:
					throw new RegistryFactory(start, mapFactory.Mark(), DicSingleton.gE3WbyDVW(0x3FCF6129 ^ 0x3FCFC4AF));
				case 1:
					stringBuilder = new StringBuilder();
					num2 = 8;
					continue;
				case 8:
					stringBuilder.Append(ReadCurrentCharacter());
					num2 = 4;
					continue;
				case 6:
					if (stringBuilder[0] != '!')
					{
						break;
					}
					goto case 10;
				}
				break;
			}
			num = 5;
		}
	}

	private int ScanVersionDirectiveNumber(QueueReader start)
	{
		int num = 8;
		int num2 = num;
		int num4 = default(int);
		int num3 = default(int);
		while (true)
		{
			switch (num2)
			{
			case 1:
			case 4:
				if (!globalFactory.IsDigit())
				{
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 == 0)
					{
						num2 = 9;
					}
					break;
				}
				goto case 2;
			case 7:
				num4 = 0;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 != 0)
				{
					num2 = 1;
				}
				break;
			case 8:
				num3 = 0;
				num2 = 7;
				break;
			case 9:
				if (num4 != 0)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c != 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 6;
			case 2:
				if (++num4 > 9)
				{
					num2 = 3;
					break;
				}
				num3 = num3 * 10 + globalFactory.AsDigit();
				num2 = 5;
				break;
			case 5:
				Skip();
				num2 = 4;
				break;
			case 6:
				throw new RegistryFactory(start, mapFactory.Mark(), DicSingleton.gE3WbyDVW(0x602C149E ^ 0x602CB26C));
			default:
				return num3;
			case 3:
				throw new RegistryFactory(start, mapFactory.Mark(), DicSingleton.gE3WbyDVW(-1735703950 ^ -1735662576));
			}
		}
	}

	private void SaveSimpleKey()
	{
		int num = 1;
		int num2 = num;
		PredicateFactory item = default(PredicateFactory);
		bool isRequired = default(bool);
		while (true)
		{
			int num3;
			switch (num2)
			{
			default:
				num3 = ((mapperFactory == mapFactory.LineOffset) ? 1 : 0);
				break;
			case 1:
				if (_TokenFactory == 0)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d5c0c185d7b1430b897cb64adc93b81c == 0)
					{
						num2 = 0;
					}
					continue;
				}
				num3 = 0;
				break;
			case 3:
				_ComposerFactory.Push(item);
				num2 = 6;
				continue;
			case 6:
				return;
			case 5:
				_ComposerFactory.Pop();
				num2 = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 != 0)
				{
					num2 = 0;
				}
				continue;
			case 7:
				RemoveSimpleKey();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea != 0)
				{
					num2 = 5;
				}
				continue;
			case 4:
				item = new PredicateFactory(isRequired, callbackFactory + _DefinitionFactory.Count, mapFactory);
				num2 = 7;
				continue;
			case 2:
				if (!m_IdentifierFactory)
				{
					return;
				}
				num2 = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c == 0)
				{
					num2 = 4;
				}
				continue;
			}
			isRequired = (byte)num3 != 0;
			num2 = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 == 0)
			{
				num2 = 2;
			}
		}
	}

	static SerializerFactory()
	{
		int num = 3;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				m_MethodFactory = new byte[0];
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 != 0)
				{
					num2 = 1;
				}
				break;
			case 2:
				m_ProducerFactory = new SortedDictionary<char, char>
				{
					{ '0', '\0' },
					{ 'a', '\a' },
					{ 'b', '\b' },
					{ 't', '\t' },
					{ '\t', '\t' },
					{ 'n', '\n' },
					{ 'v', '\v' },
					{ 'f', '\f' },
					{ 'r', '\r' },
					{ 'e', '\u001b' },
					{ ' ', ' ' },
					{ '"', '"' },
					{ '\\', '\\' },
					{ '/', '/' },
					{ 'N', '\u0085' },
					{ '_', '\u00a0' },
					{ 'L', '\u2028' },
					{ 'P', '\u2029' }
				};
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 == 0)
				{
					num2 = 0;
				}
				break;
			case 3:
				GetterIssuer.DeleteInitializer();
				num2 = 2;
				break;
			case 1:
				return;
			}
		}
	}

	internal static bool DestroyError()
	{
		return FlushError == null;
	}

	internal static SerializerFactory ComputeError()
	{
		return FlushError;
	}
}
