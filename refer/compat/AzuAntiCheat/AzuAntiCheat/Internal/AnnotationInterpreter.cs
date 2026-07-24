using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace AzuAnticheat.Internal;

internal class AnnotationInterpreter : ExpressionInterpreter
{
	private static readonly SortedDictionary<char, char> processInterpreter;

	private readonly Stack<int> _RepositoryInterpreter;

	private readonly TemplateInterpreter<SystemSingleton> m_TagInterpreter;

	private readonly Stack<ClassInterpreter> _VisitorInterpreter;

	private readonly InfoAttribute<ProductInterpreter> _StubInterpreter;

	private readonly DescriptorAttribute m_PolicyInterpreter;

	private bool strategyInterpreter;

	private bool processorInterpreter;

	private bool m_InfoInterpreter;

	private int dicInterpreter;

	private bool m_ParamsInterpreter;

	private bool poolInterpreter;

	private int m_DescriptorInterpreter;

	private bool m_DispatcherInterpreter;

	private bool listInterpreter;

	private int m_QueueInterpreter;

	private int collectionInterpreter;

	private bool managerInterpreter;

	private SystemSingleton? m_TokenizerInterpreter;

	private WriterSingleton? _ListenerInterpreter;

	private IdentifierSingleton? accountInterpreter;

	[CompilerGenerated]
	private bool threadInterpreter;

	[CompilerGenerated]
	private SystemSingleton? m_MappingInterpreter;

	private static readonly byte[] _SchemaInterpreter;

	private static AnnotationInterpreter PatchProducer;

	public bool SkipComments
	{
		[CompilerGenerated]
		get
		{
			return threadInterpreter;
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
					threadInterpreter = value;
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

	public SystemSingleton? Current
	{
		[CompilerGenerated]
		get
		{
			return m_MappingInterpreter;
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
					m_MappingInterpreter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f == 0)
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

	public TestsInterpreter CurrentPosition => m_PolicyInterpreter.Mark();

	private bool IsDocumentStart()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				return _StubInterpreter.IsWhiteBreakOrZero(3);
			case 3:
			case 5:
				return false;
			case 6:
				if (!_StubInterpreter.Check('-', 1))
				{
					num2 = 3;
					break;
				}
				goto case 7;
			case 4:
				if (!_StubInterpreter.Check('-'))
				{
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e != 0)
					{
						num2 = 5;
					}
					break;
				}
				goto case 6;
			default:
				if (m_PolicyInterpreter.LineOffset == 0)
				{
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 == 0)
					{
						num2 = 4;
					}
					break;
				}
				goto case 3;
			case 1:
				if (!_StubInterpreter.EndOfInput)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 3;
			case 7:
				if (_StubInterpreter.Check('-', 2))
				{
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d5c0c185d7b1430b897cb64adc93b81c == 0)
					{
						num2 = 2;
					}
					break;
				}
				goto case 3;
			}
		}
	}

	private bool IsDocumentEnd()
	{
		int num = 5;
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 6:
					if (m_PolicyInterpreter.LineOffset != 0)
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_49107028423047bfbf9c33e5a2ab8cf8 == 0)
						{
							num2 = 1;
						}
						break;
					}
					goto case 1;
				case 1:
					if (_StubInterpreter.Check('.'))
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 != 0)
						{
							num2 = 0;
						}
						break;
					}
					goto case 2;
				case 3:
					if (_StubInterpreter.Check('.', 2))
					{
						num2 = 7;
						break;
					}
					goto case 2;
				case 7:
					return _StubInterpreter.IsWhiteBreakOrZero(3);
				case 2:
				case 4:
					return false;
				case 5:
					if (_StubInterpreter.EndOfInput)
					{
						goto end_IL_0012;
					}
					goto case 6;
				default:
					if (_StubInterpreter.Check('.', 1))
					{
						num2 = 3;
						break;
					}
					goto case 2;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 4;
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public AnnotationInterpreter(TextReader input, bool skipComments = true)
	{
		GetterIssuer.DeleteInitializer();
		_RepositoryInterpreter = new Stack<int>();
		m_TagInterpreter = new TemplateInterpreter<SystemSingleton>();
		_VisitorInterpreter = new Stack<ClassInterpreter>();
		m_DescriptorInterpreter = -1;
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 == 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			default:
				m_PolicyInterpreter = new DescriptorAttribute();
				num = 3;
				break;
			case 1:
				_StubInterpreter = new InfoAttribute<ProductInterpreter>(new ProductInterpreter(input, 1024));
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a579dea83d2144838086d2d400bd0222 != 0)
				{
					num = 0;
				}
				break;
			case 2:
				return;
			case 3:
				SkipComments = skipComments;
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 == 0)
				{
					num = 2;
				}
				break;
			}
		}
	}

	public bool MoveNext()
	{
		int num = 3;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
			case 2:
				return MoveNextWithoutConsuming();
			case 3:
				if (Current == null)
				{
					num2 = 2;
					continue;
				}
				break;
			}
			ConsumeCurrent();
			num2 = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 == 0)
			{
				num2 = 1;
			}
		}
	}

	public bool MoveNextWithoutConsuming()
	{
		int num = 8;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 4:
				return true;
			case 6:
				Current = null;
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 == 0)
				{
					num2 = 2;
				}
				break;
			default:
				Current = m_TagInterpreter.Dequeue();
				num2 = 9;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae50b6e347494ff2973fbc64d1fc9236 != 0)
				{
					num2 = 4;
				}
				break;
			case 8:
				if (!managerInterpreter)
				{
					num2 = 7;
					break;
				}
				goto case 1;
			case 1:
			case 5:
				if (m_TagInterpreter.Count <= 0)
				{
					num2 = 6;
					break;
				}
				goto default;
			case 7:
				if (processorInterpreter)
				{
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9c47a25d924946efb9e023473a095794 == 0)
					{
						num2 = 1;
					}
					break;
				}
				goto case 3;
			case 3:
				FetchMoreTokens();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 != 0)
				{
					num2 = 1;
				}
				break;
			case 2:
				return false;
			case 9:
				managerInterpreter = false;
				num2 = 4;
				break;
			}
		}
	}

	public void ConsumeCurrent()
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				managerInterpreter = false;
				num2 = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba != 0)
				{
					num2 = 2;
				}
				break;
			case 2:
				collectionInterpreter++;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 != 0)
				{
					num2 = 1;
				}
				break;
			case 3:
				m_TokenizerInterpreter = Current;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 != 0)
				{
					num2 = 0;
				}
				break;
			case 4:
				return;
			default:
				Current = null;
				num2 = 4;
				break;
			}
		}
	}

	private char ReadCurrentCharacter()
	{
		char result = _StubInterpreter.Peek(0);
		Skip();
		return result;
	}

	private char ReadLine()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				return '\n';
			case 1:
				if (!_StubInterpreter.Check(DicSingleton.gE3WbyDVW(0x5A1B57A3 ^ 0x5A1BD9E1)))
				{
					char result = _StubInterpreter.Peek(0);
					SkipLine();
					return result;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c != 0)
				{
					num2 = 0;
				}
				break;
			default:
				SkipLine();
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 == 0)
				{
					num2 = 2;
				}
				break;
			}
		}
	}

	private void FetchMoreTokens()
	{
		while (true)
		{
			bool flag = false;
			if (m_TagInterpreter.Count == 0)
			{
				flag = true;
			}
			else
			{
				foreach (ClassInterpreter item in _VisitorInterpreter)
				{
					if (!item.IsPossible || item.TokenNumber != collectionInterpreter)
					{
						continue;
					}
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				break;
			}
			FetchNextToken();
		}
		managerInterpreter = true;
	}

	private static bool StartsWith(StringBuilder what, char start)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return what[0] == start;
			case 1:
				if (what.Length <= 0)
				{
					return false;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	private void StaleSimpleKeys()
	{
		int num = 2;
		int num2 = num;
		Stack<ClassInterpreter>.Enumerator enumerator = default(Stack<ClassInterpreter>.Enumerator);
		ClassInterpreter current = default(ClassInterpreter);
		TestsInterpreter testsInterpreter = default(TestsInterpreter);
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 0:
				return;
			case 2:
				enumerator = _VisitorInterpreter.GetEnumerator();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb == 0)
				{
					num2 = 0;
				}
				break;
			case 1:
				try
				{
					while (true)
					{
						IL_01ae:
						int num3;
						if (!enumerator.MoveNext())
						{
							num3 = 6;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 == 0)
							{
								num3 = 5;
							}
							goto IL_0064;
						}
						goto IL_009a;
						IL_009a:
						current = enumerator.Current;
						num3 = 2;
						goto IL_0064;
						IL_0064:
						while (true)
						{
							int num4;
							switch (num3)
							{
							case 6:
								return;
							case 10:
								break;
							case 4:
								m_TagInterpreter.Enqueue(new ComposerSingleton(DicSingleton.gE3WbyDVW(0x6BAF1854 ^ 0x6BAF9618), testsInterpreter, testsInterpreter));
								num3 = 7;
								continue;
							case 1:
							case 3:
								if (current.IsRequired)
								{
									num3 = 9;
									continue;
								}
								goto case 7;
							default:
								if (current.Line < m_PolicyInterpreter.Line)
								{
									num3 = 1;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd != 0)
									{
										num3 = 1;
									}
									continue;
								}
								goto case 5;
							case 9:
								testsInterpreter = m_PolicyInterpreter.Mark();
								num3 = 4;
								continue;
							case 5:
								if (current.Index + 1024 >= m_PolicyInterpreter.Index)
								{
									goto IL_01ae;
								}
								num4 = 3;
								goto IL_0060;
							case 2:
								if (current.IsPossible)
								{
									num3 = 0;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 == 0)
									{
										num3 = 0;
									}
									continue;
								}
								goto IL_01ae;
							case 7:
								current.MarkAsImpossible();
								num4 = 8;
								goto IL_0060;
							case 8:
								goto IL_01ae;
								IL_0060:
								num3 = num4;
								continue;
							}
							break;
						}
						goto IL_009a;
					}
				}
				finally
				{
					((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
					int num5 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec == 0)
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
	}

	private void FetchNextToken()
	{
		int num = 33;
		TestsInterpreter end = default(TestsInterpreter);
		TestsInterpreter start = default(TestsInterpreter);
		TestsInterpreter testsInterpreter = default(TestsInterpreter);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 90:
					return;
				case 36:
					if (_StubInterpreter.Check('{'))
					{
						num2 = 134;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4fda3adbb4ec45bdb14fe2ef97e570a8 == 0)
						{
							num2 = 50;
						}
						continue;
					}
					if (_StubInterpreter.Check(']'))
					{
						num2 = 61;
						continue;
					}
					if (!_StubInterpreter.Check('}'))
					{
						num2 = 31;
						continue;
					}
					goto case 43;
				case 20:
					if (_StubInterpreter.IsWhiteBreakOrZero(1))
					{
						num2 = 123;
						continue;
					}
					goto case 40;
				case 28:
					return;
				case 118:
					if (!_StubInterpreter.Check('"'))
					{
						num2 = 45;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c2b9915913b8461884afdca5d98855ec != 0)
						{
							num2 = 19;
						}
						continue;
					}
					goto case 21;
				case 64:
					FetchDirective();
					num2 = 98;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 == 0)
					{
						num2 = 75;
					}
					continue;
				case 113:
					if (_StubInterpreter.Check(DicSingleton.gE3WbyDVW(-1931860206 ^ -1931833070), 1))
					{
						num2 = 122;
						continue;
					}
					goto case 22;
				case 70:
					if (m_QueueInterpreter <= 0)
					{
						num = 56;
						break;
					}
					goto case 44;
				case 121:
					FetchBlockEntry();
					num2 = 27;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a == 0)
					{
						num2 = 18;
					}
					continue;
				case 10:
					throw new AdapterInterpreter(DicSingleton.gE3WbyDVW(-1817326817 ^ -1817361309));
				case 128:
					if (!_StubInterpreter.IsWhiteBreakOrZero())
					{
						num2 = 9;
						continue;
					}
					goto case 14;
				case 108:
					FetchFlowCollectionEnd(isSequenceToken: true);
					num2 = 45;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ea4c8b68ad954c0fb4df33d6e06bd4a3 == 0)
					{
						num2 = 75;
					}
					continue;
				case 54:
					FetchValue();
					num2 = 107;
					continue;
				case 83:
					if (m_QueueInterpreter <= 0)
					{
						goto case 62;
					}
					goto case 40;
				case 52:
					if (!_StubInterpreter.IsWhite(1))
					{
						num2 = 87;
						continue;
					}
					goto case 6;
				case 101:
					return;
				case 98:
					return;
				case 4:
					if (IsDocumentStart())
					{
						num2 = 34;
						continue;
					}
					if (!IsDocumentEnd())
					{
						num2 = 73;
						continue;
					}
					goto case 53;
				case 79:
					return;
				case 11:
				case 132:
					if (!_StubInterpreter.Check(':'))
					{
						num = 110;
						break;
					}
					goto case 81;
				case 120:
					end = m_PolicyInterpreter.Mark();
					num2 = 88;
					continue;
				case 107:
					return;
				case 23:
				case 110:
				case 127:
					if (!_StubInterpreter.Check('*'))
					{
						num2 = 103;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 == 0)
						{
							num2 = 95;
						}
						continue;
					}
					goto case 65;
				case 104:
					if (_StubInterpreter.IsWhiteBreakOrZero(1))
					{
						num2 = 19;
						continue;
					}
					goto case 23;
				case 82:
					FetchFlowCollectionStart(isSequenceToken: false);
					num2 = 101;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f011663d64054593978962dcc3a5ec1a == 0)
					{
						num2 = 7;
					}
					continue;
				case 38:
					FetchTag();
					num2 = 17;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 == 0)
					{
						num2 = 95;
					}
					continue;
				case 111:
					if (!m_ParamsInterpreter)
					{
						num2 = 26;
						continue;
					}
					goto case 30;
				case 91:
					if (_StubInterpreter.IsTab())
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 == 0)
						{
							num2 = 10;
						}
						continue;
					}
					goto case 128;
				case 12:
					return;
				case 9:
					start = m_PolicyInterpreter.Mark();
					num2 = 50;
					continue;
				case 63:
					if (m_QueueInterpreter != 0)
					{
						num2 = 41;
						continue;
					}
					goto case 77;
				case 60:
					if (!m_DispatcherInterpreter)
					{
						num2 = 105;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a != 0)
						{
							num2 = 135;
						}
						continue;
					}
					goto case 72;
				case 133:
					accountInterpreter.IsKey = true;
					num2 = 55;
					continue;
				case 71:
					return;
				case 41:
					if (!_StubInterpreter.Check('\''))
					{
						num2 = 118;
						continue;
					}
					goto case 89;
				case 80:
					return;
				case 58:
					if (_StubInterpreter.Check('>'))
					{
						num2 = 63;
						continue;
					}
					goto case 41;
				case 15:
					m_InfoInterpreter = false;
					num2 = 74;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e == 0)
					{
						num2 = 66;
					}
					continue;
				case 19:
					if (listInterpreter)
					{
						num2 = 37;
						continue;
					}
					goto case 60;
				case 78:
					FetchFlowCollectionEnd(isSequenceToken: false);
					num = 16;
					break;
				case 72:
					if (!_StubInterpreter.Check(':', 1))
					{
						num2 = 105;
						continue;
					}
					goto case 23;
				case 34:
					accountInterpreter = null;
					num2 = 109;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 == 0)
					{
						num2 = 96;
					}
					continue;
				case 109:
					FetchDocumentIndicator(isStartToken: true);
					num2 = 129;
					continue;
				case 68:
					accountInterpreter = null;
					num2 = 33;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 != 0)
					{
						num2 = 125;
					}
					continue;
				case 88:
					throw new AdapterInterpreter(in start, in end, DicSingleton.gE3WbyDVW(-2133864647 ^ -2133901105));
				case 8:
					FetchKey();
					num2 = 79;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac != 0)
					{
						num2 = 22;
					}
					continue;
				case 14:
					Skip();
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 == 0)
					{
						num2 = 12;
					}
					continue;
				case 57:
					_StubInterpreter.Buffer.Cache(4);
					num = 49;
					break;
				case 6:
				case 137:
					if (_StubInterpreter.Check(DicSingleton.gE3WbyDVW(-1931860206 ^ -1931845990)))
					{
						num2 = 20;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 != 0)
						{
							num2 = 8;
						}
						continue;
					}
					goto case 123;
				case 117:
					FetchBlockScalar(isLiteral: true);
					num2 = 80;
					continue;
				case 124:
					return;
				case 45:
					if (_StubInterpreter.IsWhiteBreakOrZero())
					{
						num2 = 136;
						continue;
					}
					goto case 130;
				case 114:
					FetchStreamEnd();
					num2 = 58;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 == 0)
					{
						num2 = 59;
					}
					continue;
				case 130:
					if (!_StubInterpreter.Check(DicSingleton.gE3WbyDVW(0x5A1F7167 ^ 0x5A1FFFA5)))
					{
						num2 = 40;
						continue;
					}
					goto case 51;
				case 123:
					if (!listInterpreter)
					{
						num2 = 62;
						continue;
					}
					goto case 83;
				case 3:
				case 131:
					if (_StubInterpreter.Check(':'))
					{
						num = 116;
						break;
					}
					goto case 29;
				case 84:
					return;
				case 62:
					if (listInterpreter)
					{
						num2 = 67;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 != 0)
						{
							num2 = 56;
						}
						continue;
					}
					goto case 128;
				case 29:
				case 100:
					m_DispatcherInterpreter = false;
					num2 = 13;
					continue;
				case 21:
					FetchQuotedScalar(isSingleQuoted: false);
					num2 = 124;
					continue;
				case 32:
					FetchStreamStart();
					num2 = 2;
					continue;
				case 18:
					if (_StubInterpreter.Check('%'))
					{
						num = 119;
						break;
					}
					goto case 4;
				case 116:
					Skip();
					num2 = 100;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a == 0)
					{
						num2 = 60;
					}
					continue;
				case 126:
					StaleSimpleKeys();
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 == 0)
					{
						num2 = 47;
					}
					continue;
				case 48:
					accountInterpreter = null;
					num = 39;
					break;
				case 77:
					FetchBlockScalar(isLiteral: false);
					num2 = 71;
					continue;
				case 74:
					FetchPlainScalar();
					num2 = 84;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e == 0)
					{
						num2 = 47;
					}
					continue;
				case 115:
					return;
				case 46:
					if (!_StubInterpreter.Check('!'))
					{
						num2 = 91;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 == 0)
						{
							num2 = 106;
						}
						continue;
					}
					goto case 38;
				case 51:
				case 136:
					if (!_StubInterpreter.Check('-'))
					{
						num2 = 137;
						continue;
					}
					goto case 52;
				default:
					if (!_StubInterpreter.IsWhiteBreakOrZero(1))
					{
						num = 66;
						break;
					}
					goto case 121;
				case 39:
					FetchFlowCollectionStart(isSequenceToken: true);
					num = 90;
					break;
				case 42:
					if (m_QueueInterpreter != 0)
					{
						num2 = 58;
						continue;
					}
					goto case 117;
				case 85:
					m_TagInterpreter.Enqueue(new ComposerSingleton(DicSingleton.gE3WbyDVW(-1335677307 ^ -1335648151), testsInterpreter, testsInterpreter));
					num2 = 92;
					continue;
				case 17:
					if (!m_ParamsInterpreter)
					{
						num2 = 29;
						continue;
					}
					goto case 1;
				case 37:
					if (m_QueueInterpreter > 0)
					{
						num2 = 72;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd == 0)
						{
							num2 = 127;
						}
						continue;
					}
					goto case 60;
				case 134:
					accountInterpreter = null;
					num2 = 82;
					continue;
				case 59:
					if (m_PolicyInterpreter.LineOffset != 0)
					{
						num2 = 4;
						continue;
					}
					goto case 18;
				case 105:
				case 135:
					if (_StubInterpreter.IsWhiteBreakOrZero(1))
					{
						num2 = 102;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 != 0)
						{
							num2 = 3;
						}
						continue;
					}
					goto case 97;
				case 7:
					return;
				case 5:
					return;
				case 103:
					if (!_StubInterpreter.Check('&'))
					{
						num2 = 46;
						continue;
					}
					goto case 93;
				case 76:
					if (m_DispatcherInterpreter)
					{
						num2 = 30;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e != 0)
						{
							num2 = 22;
						}
						continue;
					}
					goto case 111;
				case 89:
					FetchQuotedScalar(isSingleQuoted: true);
					num2 = 28;
					continue;
				case 55:
					accountInterpreter = null;
					num2 = 12;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 == 0)
					{
						num2 = 54;
					}
					continue;
				case 96:
					if (m_InfoInterpreter)
					{
						num2 = 69;
						continue;
					}
					goto case 92;
				case 112:
					return;
				case 73:
					if (!_StubInterpreter.Check('['))
					{
						num = 36;
						break;
					}
					goto case 48;
				case 16:
					return;
				case 31:
					if (!_StubInterpreter.Check(','))
					{
						if (!_StubInterpreter.Check('-'))
						{
							num = 24;
							break;
						}
						goto default;
					}
					num2 = 68;
					continue;
				case 61:
					accountInterpreter = null;
					num2 = 108;
					continue;
				case 26:
					if (!poolInterpreter)
					{
						num2 = 23;
						continue;
					}
					goto case 30;
				case 27:
					return;
				case 66:
					if (m_QueueInterpreter <= 0)
					{
						num2 = 35;
						continue;
					}
					goto case 113;
				case 22:
				case 24:
				case 35:
					if (_StubInterpreter.Check('?'))
					{
						num2 = 70;
						continue;
					}
					goto case 11;
				case 25:
					FetchDocumentIndicator(isStartToken: false);
					num2 = 112;
					continue;
				case 49:
					if (_StubInterpreter.Buffer.EndOfInput)
					{
						num2 = 86;
						continue;
					}
					goto case 59;
				case 125:
					FetchFlowEntry();
					num2 = 7;
					continue;
				case 56:
					if (!_StubInterpreter.IsWhiteBreakOrZero(1))
					{
						num = 132;
						break;
					}
					goto case 44;
				case 1:
					if (!poolInterpreter)
					{
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 != 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 29;
				case 43:
					accountInterpreter = null;
					num2 = 78;
					continue;
				case 53:
					accountInterpreter = null;
					num2 = 19;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e == 0)
					{
						num2 = 25;
					}
					continue;
				case 81:
					if (m_QueueInterpreter <= 0)
					{
						num2 = 104;
						continue;
					}
					goto case 19;
				case 47:
					UnrollIndent(m_PolicyInterpreter.LineOffset);
					num2 = 57;
					continue;
				case 67:
					if (m_DescriptorInterpreter < m_PolicyInterpreter.LineOffset)
					{
						num2 = 65;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac == 0)
						{
							num2 = 128;
						}
						continue;
					}
					goto case 91;
				case 65:
					FetchAnchor(isAlias: true);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 != 0)
					{
						num2 = 5;
					}
					continue;
				case 129:
					return;
				case 97:
					if (!_StubInterpreter.Check(',', 1))
					{
						num2 = 60;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 == 0)
						{
							num2 = 76;
						}
						continue;
					}
					goto case 30;
				case 122:
					m_TagInterpreter.Enqueue(new ComposerSingleton(DicSingleton.gE3WbyDVW(0x4E8C8248 ^ 0x4E8C3446), m_PolicyInterpreter.Mark(), m_PolicyInterpreter.Mark()));
					num2 = 22;
					continue;
				case 13:
					m_ParamsInterpreter = false;
					num2 = 99;
					continue;
				case 69:
					testsInterpreter = m_PolicyInterpreter.Mark();
					num2 = 85;
					continue;
				case 75:
					return;
				case 92:
					if (m_DispatcherInterpreter)
					{
						num2 = 131;
						continue;
					}
					goto case 17;
				case 95:
					return;
				case 106:
					if (_StubInterpreter.Check('|'))
					{
						num2 = 6;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 != 0)
						{
							num2 = 42;
						}
						continue;
					}
					goto case 58;
				case 33:
					if (!strategyInterpreter)
					{
						num2 = 32;
						continue;
					}
					ScanToNextToken();
					num2 = 126;
					continue;
				case 99:
					poolInterpreter = false;
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 == 0)
					{
						num2 = 15;
					}
					continue;
				case 93:
					FetchAnchor(isAlias: false);
					num2 = 115;
					continue;
				case 2:
					return;
				case 86:
					accountInterpreter = null;
					num2 = 114;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_91887e48b8104e7da08b48f73b607337 == 0)
					{
						num2 = 25;
					}
					continue;
				case 30:
				case 94:
				case 102:
					if (accountInterpreter != null)
					{
						num2 = 133;
						continue;
					}
					goto case 54;
				case 119:
					accountInterpreter = null;
					num2 = 64;
					continue;
				case 50:
					Skip();
					num2 = 120;
					continue;
				case 44:
					if (!_StubInterpreter.IsWhiteBreakOrZero(1))
					{
						num2 = 11;
						continue;
					}
					goto case 8;
				case 40:
				case 87:
					num2 = 96;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 == 0)
					{
						num2 = 20;
					}
					continue;
				}
				break;
			}
		}
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
				if (!_StubInterpreter.Check(' '))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 != 0)
					{
						num2 = 0;
					}
					break;
				}
				return true;
			default:
				if (m_QueueInterpreter <= 0)
				{
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 == 0)
					{
						num2 = 1;
					}
					break;
				}
				goto case 2;
			case 2:
				return _StubInterpreter.Check('\t');
			case 3:
				if (listInterpreter)
				{
					return false;
				}
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba == 0)
				{
					num2 = 2;
				}
				break;
			}
		}
	}

	private void Skip()
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 1:
				_StubInterpreter.Buffer.Skip(1);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 == 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				m_PolicyInterpreter.Skip();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 == 0)
				{
					num2 = 1;
				}
				break;
			case 0:
				return;
			}
		}
	}

	private void SkipLine()
	{
		int num = 4;
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 4:
					if (!_StubInterpreter.IsCrLf())
					{
						goto end_IL_0012;
					}
					goto case 9;
				default:
					m_PolicyInterpreter.SkipLineByOffset(1);
					num2 = 8;
					continue;
				case 10:
					return;
				case 1:
					return;
				case 5:
					if (_StubInterpreter.IsZero())
					{
						num2 = 10;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 == 0)
						{
							num2 = 8;
						}
						continue;
					}
					break;
				case 9:
					m_PolicyInterpreter.SkipLineByOffset(2);
					num2 = 6;
					continue;
				case 6:
					_StubInterpreter.Buffer.Skip(2);
					num2 = 2;
					continue;
				case 8:
					_StubInterpreter.Buffer.Skip(1);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 == 0)
					{
						num2 = 1;
					}
					continue;
				case 2:
					return;
				case 3:
					if (!_StubInterpreter.IsBreak())
					{
						num2 = 5;
						continue;
					}
					goto default;
				case 7:
					break;
				}
				throw new InvalidOperationException(DicSingleton.gE3WbyDVW(-849667636 ^ -849639084));
				continue;
				end_IL_0012:
				break;
			}
			num = 3;
		}
	}

	private void ScanToNextToken()
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 8:
				SkipLine();
				num2 = 10;
				continue;
			default:
				if (CheckWhiteSpace())
				{
					num2 = 7;
					continue;
				}
				break;
			case 4:
				listInterpreter = true;
				num2 = 5;
				continue;
			case 9:
				return;
			case 1:
			case 7:
				Skip();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 == 0)
				{
					num2 = 0;
				}
				continue;
			case 3:
				if (!_StubInterpreter.IsBreak())
				{
					return;
				}
				num2 = 8;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 == 0)
				{
					num2 = 2;
				}
				continue;
			case 10:
				if (m_QueueInterpreter == 0)
				{
					num2 = 4;
					continue;
				}
				goto default;
			case 6:
				break;
			}
			ProcessComment();
			num2 = 3;
		}
	}

	private void ProcessComment()
	{
		if (!_StubInterpreter.Check('#'))
		{
			return;
		}
		TestsInterpreter start = m_PolicyInterpreter.Mark();
		Skip();
		while (_StubInterpreter.IsSpace())
		{
			Skip();
		}
		ReponseAttribute.ModelAttribute modelAttribute = ReponseAttribute.Rent();
		try
		{
			StringBuilder advisorAttribute = modelAttribute.m_AdvisorAttribute;
			while (!_StubInterpreter.IsBreakOrZero())
			{
				advisorAttribute.Append(ReadCurrentCharacter());
			}
			if (!SkipComments)
			{
				bool isInline = m_TokenizerInterpreter != null && m_TokenizerInterpreter.End.Line == start.Line && m_TokenizerInterpreter.End.Column != 1 && !(m_TokenizerInterpreter is CodeSingleton);
				m_TagInterpreter.Enqueue(new RuleSingleton(advisorAttribute.ToString(), isInline, start, m_PolicyInterpreter.Mark()));
			}
		}
		finally
		{
			((IDisposable)modelAttribute/*cast due to .constrained prefix*/).Dispose();
		}
	}

	private void FetchStreamStart()
	{
		int num = 4;
		int num2 = num;
		TestsInterpreter start = default(TestsInterpreter);
		while (true)
		{
			switch (num2)
			{
			default:
				m_TagInterpreter.Enqueue(new CodeSingleton(in start, in start));
				num2 = 5;
				break;
			case 1:
				strategyInterpreter = true;
				num2 = 2;
				break;
			case 5:
				return;
			case 2:
				start = m_PolicyInterpreter.Mark();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2aaca7da964541af9780eb37df39c3db != 0)
				{
					num2 = 0;
				}
				break;
			case 4:
				_VisitorInterpreter.Push(new ClassInterpreter());
				num2 = 3;
				break;
			case 3:
				listInterpreter = true;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	private void UnrollIndent(int column)
	{
		int num = 5;
		int num2 = num;
		TestsInterpreter start = default(TestsInterpreter);
		while (true)
		{
			switch (num2)
			{
			case 6:
				return;
			case 3:
			case 4:
				if (m_DescriptorInterpreter > column)
				{
					start = m_PolicyInterpreter.Mark();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e == 0)
					{
						num2 = 1;
					}
				}
				else
				{
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 == 0)
					{
						num2 = 0;
					}
				}
				break;
			case 5:
				if (m_QueueInterpreter != 0)
				{
					return;
				}
				num2 = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 != 0)
				{
					num2 = 3;
				}
				break;
			case 2:
				return;
			case 1:
				m_TagInterpreter.Enqueue(new InterpreterSingleton(in start, in start));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				m_DescriptorInterpreter = _RepositoryInterpreter.Pop();
				num2 = 3;
				break;
			}
		}
	}

	private void FetchStreamEnd()
	{
		int num = 6;
		TestsInterpreter start = default(TestsInterpreter);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 3:
					return;
				case 2:
					start = m_PolicyInterpreter.Mark();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 == 0)
					{
						num2 = 0;
					}
					continue;
				case 7:
					processorInterpreter = true;
					num2 = 2;
					continue;
				case 6:
					m_PolicyInterpreter.ForceSkipLineAfterNonBreak();
					num2 = 5;
					continue;
				case 5:
					UnrollIndent(-1);
					num2 = 4;
					continue;
				case 4:
					RemoveSimpleKey();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
					{
						num2 = 0;
					}
					continue;
				case 1:
					listInterpreter = false;
					num2 = 7;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
					{
						num2 = 3;
					}
					continue;
				}
				break;
			}
			m_TagInterpreter.Enqueue(new GetterSingleton(in start, in start));
			num = 3;
		}
	}

	private void FetchDirective()
	{
		int num = 1;
		int num2 = num;
		SystemSingleton systemSingleton = default(SystemSingleton);
		while (true)
		{
			switch (num2)
			{
			case 3:
				m_TagInterpreter.Enqueue(systemSingleton);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 != 0)
				{
					num2 = 2;
				}
				break;
			default:
				RemoveSimpleKey();
				num2 = 7;
				break;
			case 4:
				if (systemSingleton == null)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb != 0)
					{
						num2 = 5;
					}
					break;
				}
				goto case 3;
			case 1:
				UnrollIndent(-1);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 != 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				return;
			case 5:
				return;
			case 6:
				systemSingleton = ScanDirective();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 == 0)
				{
					num2 = 4;
				}
				break;
			case 7:
				listInterpreter = false;
				num2 = 6;
				break;
			}
		}
	}

	private SystemSingleton? ScanDirective()
	{
		int num = 24;
		string text = default(string);
		TestsInterpreter start = default(TestsInterpreter);
		SystemSingleton result = default(SystemSingleton);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 11:
					if (text == DicSingleton.gE3WbyDVW(0x4E8C8248 ^ 0x4E8C128E))
					{
						num2 = 10;
						continue;
					}
					goto case 9;
				case 2:
					text = ScanDirectiveName(in start);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 != 0)
					{
						num2 = 20;
					}
					continue;
				case 24:
					start = m_PolicyInterpreter.Mark();
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 != 0)
					{
						num2 = 23;
					}
					continue;
				case 6:
					if (m_TokenizerInterpreter is ComparatorSingleton)
					{
						num2 = 5;
						continue;
					}
					goto default;
				default:
					throw new StructInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(-1273961441 ^ -1273989937));
				case 10:
					result = ScanTagDirectiveValue(in start);
					num2 = 7;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a != 0)
					{
						num2 = 21;
					}
					continue;
				case 13:
					ProcessComment();
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 != 0)
					{
						num2 = 19;
					}
					continue;
				case 17:
				case 21:
				case 25:
					if (!_StubInterpreter.IsWhite())
					{
						num2 = 6;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c == 0)
						{
							num2 = 13;
						}
						continue;
					}
					Skip();
					num2 = 25;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
					{
						num2 = 10;
					}
					continue;
				case 7:
					SkipLine();
					num2 = 3;
					continue;
				case 20:
					if (!(text == DicSingleton.gE3WbyDVW(0x1606DF07 ^ 0x16064FBD)))
					{
						num = 11;
						break;
					}
					goto case 4;
				case 15:
				case 18:
					return null;
				case 14:
					if (!(m_TokenizerInterpreter is CodeSingleton))
					{
						num2 = 6;
						continue;
					}
					goto case 5;
				case 3:
					return result;
				case 4:
					if (m_TokenizerInterpreter is DefinitionSingleton)
					{
						num2 = 12;
						continue;
					}
					goto case 14;
				case 8:
					Skip();
					num2 = 16;
					continue;
				case 26:
					throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(-447849421 ^ -447820453));
				case 1:
					if (_StubInterpreter.IsBreak())
					{
						num = 7;
						break;
					}
					goto case 3;
				case 27:
					if (_StubInterpreter.Check('#'))
					{
						num2 = 15;
						continue;
					}
					goto case 22;
				case 9:
				case 16:
					if (!_StubInterpreter.EndOfInput)
					{
						num2 = 27;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 != 0)
						{
							num2 = 19;
						}
						continue;
					}
					goto case 15;
				case 23:
					Skip();
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 == 0)
					{
						num2 = 0;
					}
					continue;
				case 22:
					if (_StubInterpreter.IsBreak())
					{
						num2 = 18;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 != 0)
						{
							num2 = 5;
						}
						continue;
					}
					goto case 8;
				case 5:
				case 12:
					result = ScanVersionDirectiveValue(in start);
					num2 = 17;
					continue;
				case 19:
					if (_StubInterpreter.IsBreakOrZero())
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 != 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 26;
				}
				break;
			}
		}
	}

	private void FetchDocumentIndicator(bool isStartToken)
	{
		int num = 21;
		SystemSingleton systemSingleton = default(SystemSingleton);
		TestsInterpreter start = default(TestsInterpreter);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 21:
					UnrollIndent(-1);
					num2 = 12;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 != 0)
					{
						num2 = 20;
					}
					continue;
				case 7:
					break;
				case 16:
					return;
				case 9:
					systemSingleton = null;
					num2 = 14;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef != 0)
					{
						num2 = 14;
					}
					continue;
				case 19:
					if (!isStartToken)
					{
						num2 = 9;
						continue;
					}
					goto case 22;
				case 14:
				case 23:
					if (!_StubInterpreter.EndOfInput)
					{
						num2 = 5;
						continue;
					}
					goto default;
				case 4:
					m_TagInterpreter.Enqueue(systemSingleton);
					num2 = 13;
					continue;
				case 3:
					if (systemSingleton != null)
					{
						num2 = 4;
						continue;
					}
					return;
				default:
					m_TagInterpreter.Enqueue(new ComparatorSingleton(in start, in start));
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 != 0)
					{
						num2 = 3;
					}
					continue;
				case 22:
					m_TagInterpreter.Enqueue(new DefinitionSingleton(in start, m_PolicyInterpreter.Mark()));
					num2 = 16;
					continue;
				case 11:
					start = m_PolicyInterpreter.Mark();
					num2 = 8;
					continue;
				case 12:
					Skip();
					num2 = 19;
					continue;
				case 5:
					if (!_StubInterpreter.IsBreak())
					{
						num2 = 17;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2aaca7da964541af9780eb37df39c3db != 0)
						{
							num2 = 17;
						}
						continue;
					}
					goto default;
				case 2:
				case 18:
					if (!_StubInterpreter.IsWhite())
					{
						num2 = 15;
						continue;
					}
					goto case 1;
				case 1:
					Skip();
					num2 = 23;
					continue;
				case 8:
					Skip();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 == 0)
					{
						num2 = 7;
					}
					continue;
				case 10:
					listInterpreter = false;
					num2 = 11;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f92fb16082174ff29c1cf0085d4a3cb9 == 0)
					{
						num2 = 11;
					}
					continue;
				case 17:
					if (!_StubInterpreter.Check('#'))
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 != 0)
						{
							num2 = 18;
						}
						continue;
					}
					goto default;
				case 20:
					RemoveSimpleKey();
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 != 0)
					{
						num2 = 10;
					}
					continue;
				case 13:
					return;
				case 15:
					systemSingleton = new ComposerSingleton(DicSingleton.gE3WbyDVW(-1385030784 ^ -1385002372), start, m_PolicyInterpreter.Mark());
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_91887e48b8104e7da08b48f73b607337 == 0)
					{
						num2 = 0;
					}
					continue;
				}
				break;
			}
			Skip();
			num = 12;
		}
	}

	private void FetchFlowCollectionStart(bool isSequenceToken)
	{
		int num = 6;
		int num2 = num;
		TestsInterpreter start = default(TestsInterpreter);
		SystemSingleton systemSingleton = default(SystemSingleton);
		while (true)
		{
			switch (num2)
			{
			case 9:
				start = m_PolicyInterpreter.Mark();
				num2 = 3;
				break;
			case 7:
				listInterpreter = true;
				num2 = 9;
				break;
			case 2:
				return;
			case 3:
				Skip();
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd == 0)
				{
					num2 = 4;
				}
				break;
			default:
				m_TagInterpreter.Enqueue(systemSingleton);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
				{
					num2 = 1;
				}
				break;
			case 10:
				systemSingleton = new ContextSingleton(in start, in start);
				num2 = 12;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba != 0)
				{
					num2 = 10;
				}
				break;
			case 12:
				dicInterpreter = systemSingleton.Start.Line;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 == 0)
				{
					num2 = 0;
				}
				break;
			case 8:
			case 13:
				systemSingleton = new ExceptionSingleton(in start, in start);
				num2 = 11;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_259acdc10a3c4fba8a4f129ba5346de2 != 0)
				{
					num2 = 9;
				}
				break;
			case 6:
				SaveSimpleKey();
				num2 = 5;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 == 0)
				{
					num2 = 5;
				}
				break;
			case 4:
				if (!isSequenceToken)
				{
					num2 = 13;
					break;
				}
				goto case 10;
			case 1:
				poolInterpreter = true;
				num2 = 2;
				break;
			case 5:
				IncreaseFlowLevel();
				num2 = 5;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac == 0)
				{
					num2 = 7;
				}
				break;
			}
		}
	}

	private void IncreaseFlowLevel()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				return;
			case 1:
				_VisitorInterpreter.Push(new ClassInterpreter());
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				m_QueueInterpreter++;
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 != 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	private void FetchFlowCollectionEnd(bool isSequenceToken)
	{
		int num = 13;
		SystemSingleton systemSingleton = default(SystemSingleton);
		SystemSingleton item = default(SystemSingleton);
		TestsInterpreter start = default(TestsInterpreter);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 10:
					return;
				case 16:
					if (systemSingleton != null)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 15;
				case 2:
					systemSingleton = null;
					num2 = 8;
					continue;
				case 12:
					DecreaseFlowLevel();
					num2 = 11;
					continue;
				case 13:
					RemoveSimpleKey();
					num2 = 12;
					continue;
				case 7:
					item = new ItemSingleton(in start, in start);
					num2 = 4;
					continue;
				case 3:
				case 17:
					item = new HelperSingleton(in start, in start);
					num2 = 5;
					continue;
				case 11:
					listInterpreter = false;
					num2 = 14;
					continue;
				case 4:
				case 5:
					m_TagInterpreter.Enqueue(item);
					num2 = 16;
					continue;
				case 8:
					if (!isSequenceToken)
					{
						num2 = 3;
						continue;
					}
					goto case 1;
				case 9:
					Skip();
					num2 = 2;
					continue;
				case 14:
					start = m_PolicyInterpreter.Mark();
					num2 = 9;
					continue;
				case 15:
					m_ParamsInterpreter = true;
					num2 = 10;
					continue;
				case 6:
					systemSingleton = new ComposerSingleton(DicSingleton.gE3WbyDVW(0x14AB6F1E ^ 0x14ABFD8E), start, start);
					num2 = 7;
					continue;
				case 1:
					if (_StubInterpreter.Check('#'))
					{
						num2 = 6;
						continue;
					}
					goto case 7;
				}
				break;
			}
			m_TagInterpreter.Enqueue(systemSingleton);
			num = 15;
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
			case 3:
				return;
			default:
				m_QueueInterpreter--;
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec != 0)
				{
					num2 = 1;
				}
				break;
			case 2:
				_VisitorInterpreter.Pop();
				num2 = 3;
				break;
			case 1:
				if (m_QueueInterpreter <= 0)
				{
					return;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	private void FetchFlowEntry()
	{
		int num = 5;
		TestsInterpreter start = default(TestsInterpreter);
		TestsInterpreter end = default(TestsInterpreter);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 4:
					break;
				case 5:
					RemoveSimpleKey();
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3ac5d604ebd547e7ac5b1603a0e85187 != 0)
					{
						num2 = 4;
					}
					continue;
				case 3:
					return;
				case 8:
					m_TagInterpreter.Enqueue(new ComposerSingleton(DicSingleton.gE3WbyDVW(-381685266 ^ -381722076), start, end));
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4fda3adbb4ec45bdb14fe2ef97e570a8 == 0)
					{
						num2 = 2;
					}
					continue;
				case 6:
					start = m_PolicyInterpreter.Mark();
					num2 = 7;
					continue;
				case 1:
					end = m_PolicyInterpreter.Mark();
					num2 = 9;
					continue;
				case 2:
					return;
				default:
					m_TagInterpreter.Enqueue(new MapSingleton(in start, in end));
					num2 = 3;
					continue;
				case 7:
					Skip();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9c47a25d924946efb9e023473a095794 == 0)
					{
						num2 = 0;
					}
					continue;
				case 9:
					if (!_StubInterpreter.Check('#'))
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 8;
				}
				break;
			}
			listInterpreter = true;
			num = 6;
		}
	}

	private void FetchBlockEntry()
	{
		int num = 13;
		int num2 = num;
		TestsInterpreter start2 = default(TestsInterpreter);
		TestsInterpreter start = default(TestsInterpreter);
		TestsInterpreter testsInterpreter = default(TestsInterpreter);
		while (true)
		{
			switch (num2)
			{
			case 15:
				start2 = m_PolicyInterpreter.Mark();
				num2 = 11;
				continue;
			case 5:
				if (_ListenerInterpreter == null)
				{
					num2 = 9;
					continue;
				}
				goto case 8;
			case 11:
				Skip();
				num2 = 10;
				continue;
			case 8:
				start = _ListenerInterpreter.End;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e == 0)
				{
					num2 = 1;
				}
				continue;
			case 12:
				if (listInterpreter)
				{
					num2 = 7;
					continue;
				}
				goto case 5;
			case 1:
				if (start.Line == m_PolicyInterpreter.Line)
				{
					num2 = 3;
					continue;
				}
				break;
			case 14:
				m_TagInterpreter.Enqueue(new ComposerSingleton(DicSingleton.gE3WbyDVW(0x1C779450 ^ 0x1C770092), testsInterpreter, testsInterpreter));
				num2 = 16;
				continue;
			case 7:
			case 16:
				RollIndent(m_PolicyInterpreter.LineOffset, -1, isSequence: true, m_PolicyInterpreter.Mark());
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 == 0)
				{
					num2 = 0;
				}
				continue;
			default:
				RemoveSimpleKey();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e == 0)
				{
					num2 = 2;
				}
				continue;
			case 2:
				listInterpreter = true;
				num2 = 15;
				continue;
			case 10:
			{
				TemplateInterpreter<SystemSingleton> tagInterpreter = m_TagInterpreter;
				start = m_PolicyInterpreter.Mark();
				tagInterpreter.Enqueue(new SingletonSingleton(in start2, in start));
				num2 = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab != 0)
				{
					num2 = 4;
				}
				continue;
			}
			case 13:
				if (m_QueueInterpreter == 0)
				{
					num2 = 12;
					continue;
				}
				goto default;
			case 3:
				start = _ListenerInterpreter.Start;
				num2 = 6;
				continue;
			case 4:
				return;
			case 6:
				throw new StructInterpreter(in start, _ListenerInterpreter.End, DicSingleton.gE3WbyDVW(0x4097B854 ^ 0x40972C18));
			case 9:
				break;
			}
			testsInterpreter = m_PolicyInterpreter.Mark();
			num2 = 14;
		}
	}

	private void FetchKey()
	{
		int num = 6;
		int num2 = num;
		TestsInterpreter start2 = default(TestsInterpreter);
		TestsInterpreter start = default(TestsInterpreter);
		while (true)
		{
			switch (num2)
			{
			case 9:
				return;
			case 6:
				if (m_QueueInterpreter == 0)
				{
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf == 0)
					{
						num2 = 4;
					}
					break;
				}
				goto case 3;
			case 3:
				RemoveSimpleKey();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec != 0)
				{
					num2 = 0;
				}
				break;
			case 1:
				throw new AdapterInterpreter(in start2, in start2, DicSingleton.gE3WbyDVW(-1817326817 ^ -1817354709));
			case 10:
				RollIndent(m_PolicyInterpreter.LineOffset, -1, isSequence: false, m_PolicyInterpreter.Mark());
				num2 = 3;
				break;
			case 8:
				Skip();
				num2 = 4;
				break;
			case 5:
				if (listInterpreter)
				{
					num2 = 10;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 == 0)
					{
						num2 = 10;
					}
					break;
				}
				goto case 2;
			case 4:
				m_TagInterpreter.Enqueue(new MapperSingleton(in start, m_PolicyInterpreter.Mark()));
				num2 = 9;
				break;
			case 2:
				start2 = m_PolicyInterpreter.Mark();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2aaca7da964541af9780eb37df39c3db == 0)
				{
					num2 = 1;
				}
				break;
			default:
				listInterpreter = m_QueueInterpreter == 0;
				num2 = 7;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 != 0)
				{
					num2 = 3;
				}
				break;
			case 7:
				start = m_PolicyInterpreter.Mark();
				num2 = 8;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 == 0)
				{
					num2 = 8;
				}
				break;
			}
		}
	}

	private void FetchValue()
	{
		int num = 1;
		ClassInterpreter classInterpreter = default(ClassInterpreter);
		bool flag = default(bool);
		TestsInterpreter start = default(TestsInterpreter);
		TestsInterpreter testsInterpreter = default(TestsInterpreter);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 12:
					if (m_PolicyInterpreter.LineOffset != 0)
					{
						num2 = 24;
						continue;
					}
					goto case 7;
				case 13:
					m_TagInterpreter.Insert(classInterpreter.TokenNumber - collectionInterpreter, new MapperSingleton(classInterpreter.Mark, classInterpreter.Mark));
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba != 0)
					{
						num2 = 6;
					}
					continue;
				case 2:
					flag = false;
					num2 = 19;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab == 0)
					{
						num2 = 20;
					}
					continue;
				case 18:
					m_TagInterpreter.Insert(m_TagInterpreter.Count, new MapperSingleton(classInterpreter.Mark, classInterpreter.Mark));
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 != 0)
					{
						num2 = 2;
					}
					continue;
				case 22:
					return;
				case 8:
					RollIndent(classInterpreter.LineOffset, classInterpreter.TokenNumber, isSequence: false, classInterpreter.Mark);
					num2 = 23;
					continue;
				case 7:
					if (classInterpreter.LineOffset == 0)
					{
						num2 = 12;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c == 0)
						{
							num2 = 18;
						}
						continue;
					}
					goto case 3;
				case 23:
					classInterpreter.MarkAsImpossible();
					num2 = 21;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 == 0)
					{
						num2 = 14;
					}
					continue;
				default:
					if (!classInterpreter.IsPossible)
					{
						num2 = 16;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 == 0)
						{
							num2 = 14;
						}
						continue;
					}
					goto case 13;
				case 21:
					listInterpreter = false;
					num2 = 17;
					continue;
				case 11:
					if (!listInterpreter)
					{
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4fda3adbb4ec45bdb14fe2ef97e570a8 == 0)
						{
							num2 = 4;
						}
					}
					else
					{
						RollIndent(m_PolicyInterpreter.LineOffset, -1, isSequence: false, m_PolicyInterpreter.Mark());
						num2 = 12;
					}
					continue;
				case 14:
				case 17:
					start = m_PolicyInterpreter.Mark();
					num = 19;
					break;
				case 15:
					return;
				case 3:
				case 20:
				case 24:
					listInterpreter = flag;
					num2 = 14;
					continue;
				case 1:
					classInterpreter = _VisitorInterpreter.Peek();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be == 0)
					{
						num2 = 0;
					}
					continue;
				case 9:
					m_TagInterpreter.Enqueue(new ComposerSingleton(DicSingleton.gE3WbyDVW(--708144185 ^ 0x2A35F9AB), testsInterpreter, testsInterpreter));
					num = 15;
					break;
				case 5:
					m_TagInterpreter.Enqueue(new ExpressionSingleton(in start, m_PolicyInterpreter.Mark()));
					num2 = 22;
					continue;
				case 6:
				case 16:
					flag = m_QueueInterpreter == 0;
					num2 = 10;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3ac5d604ebd547e7ac5b1603a0e85187 != 0)
					{
						num2 = 8;
					}
					continue;
				case 10:
					if (!flag)
					{
						num2 = 3;
						continue;
					}
					goto case 11;
				case 4:
					testsInterpreter = m_PolicyInterpreter.Mark();
					num = 9;
					break;
				case 19:
					Skip();
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d5c0c185d7b1430b897cb64adc93b81c == 0)
					{
						num2 = 2;
					}
					continue;
				}
				break;
			}
		}
	}

	private void RollIndent(int column, int number, bool isSequence, TestsInterpreter position)
	{
		int num = 2;
		int num2 = num;
		SystemSingleton item = default(SystemSingleton);
		while (true)
		{
			switch (num2)
			{
			case 9:
			case 11:
				if (number == -1)
				{
					num2 = 10;
					break;
				}
				m_TagInterpreter.Insert(number - collectionInterpreter, item);
				num2 = 5;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 == 0)
				{
					num2 = 4;
				}
				break;
			case 2:
				if (m_QueueInterpreter > 0)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb == 0)
					{
						num2 = 1;
					}
					break;
				}
				if (m_DescriptorInterpreter >= column)
				{
					return;
				}
				num2 = 5;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc != 0)
				{
					num2 = 7;
				}
				break;
			case 7:
				_RepositoryInterpreter.Push(m_DescriptorInterpreter);
				num2 = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f011663d64054593978962dcc3a5ec1a != 0)
				{
					num2 = 4;
				}
				break;
			case 10:
				m_TagInterpreter.Enqueue(item);
				num2 = 3;
				break;
			case 5:
				return;
			case 3:
				return;
			case 1:
				return;
			case 4:
				m_DescriptorInterpreter = column;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 == 0)
				{
					num2 = 0;
				}
				break;
			case 8:
				item = new IssuerSingleton(in position, in position);
				num2 = 11;
				break;
			default:
				if (isSequence)
				{
					num2 = 6;
					break;
				}
				goto case 8;
			case 6:
				item = new FieldSingleton(in position, in position);
				num2 = 9;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 == 0)
				{
					num2 = 4;
				}
				break;
			}
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
				m_TagInterpreter.Enqueue(ScanAnchor(isAlias));
				num2 = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c != 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				SaveSimpleKey();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 == 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				listInterpreter = false;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e != 0)
				{
					num2 = 0;
				}
				break;
			case 3:
				return;
			}
		}
	}

	private SystemSingleton ScanAnchor(bool isAlias)
	{
		int num = 5;
		SystemSingleton result = default(SystemSingleton);
		ClassInterpreter classInterpreter = default(ClassInterpreter);
		ReponseAttribute.ModelAttribute modelAttribute = default(ReponseAttribute.ModelAttribute);
		bool flag = default(bool);
		VisitorAttribute value = default(VisitorAttribute);
		TestsInterpreter start = default(TestsInterpreter);
		WriterSingleton writerSingleton = default(WriterSingleton);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				int num3;
				switch (num2)
				{
				case 7:
					return result;
				case 2:
					num3 = (classInterpreter.IsPossible ? 1 : 0);
					goto IL_04e6;
				default:
					modelAttribute = ReponseAttribute.Rent();
					num2 = 11;
					continue;
				case 4:
					Skip();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 == 0)
					{
						num2 = 1;
					}
					continue;
				case 1:
					flag = false;
					num2 = 9;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a579dea83d2144838086d2d400bd0222 == 0)
					{
						num2 = 0;
					}
					continue;
				case 10:
					classInterpreter = _VisitorInterpreter.Peek();
					num = 6;
					break;
				case 11:
					try
					{
						StringBuilder advisorAttribute = modelAttribute.m_AdvisorAttribute;
						int num4 = 12;
						while (true)
						{
							switch (num4)
							{
							case 15:
								if (_StubInterpreter.IsWhiteBreakOrZero())
								{
									num4 = 18;
									continue;
								}
								goto case 10;
							case 4:
								result = new AuthenticationSingleton(value, start, m_PolicyInterpreter.Mark());
								num4 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae50b6e347494ff2973fbc64d1fc9236 == 0)
								{
									num4 = 0;
								}
								continue;
							case 8:
								if (_StubInterpreter.IsWhiteBreakOrZero(1))
								{
									num4 = 1;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae50b6e347494ff2973fbc64d1fc9236 != 0)
									{
										num4 = 0;
									}
									continue;
								}
								goto case 11;
							case 14:
								if (!flag)
								{
									num4 = 2;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 == 0)
									{
										num4 = 11;
									}
									continue;
								}
								goto case 3;
							case 1:
							case 9:
								if (advisorAttribute.Length != 0)
								{
									num4 = 15;
									continue;
								}
								goto case 2;
							case 5:
								writerSingleton = (_ListenerInterpreter = new WriterSingleton(value, start, m_PolicyInterpreter.Mark()));
								num4 = 7;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea != 0)
								{
									num4 = 17;
								}
								continue;
							case 11:
							case 13:
							case 20:
								advisorAttribute.Append(ReadCurrentCharacter());
								num4 = 16;
								continue;
							case 6:
								if (isAlias)
								{
									num4 = 4;
									continue;
								}
								goto case 5;
							case 10:
								if (_StubInterpreter.Check(DicSingleton.gE3WbyDVW(-1483531944 ^ -1483501734)))
								{
									num4 = 7;
									continue;
								}
								goto case 2;
							case 17:
								result = writerSingleton;
								num4 = 21;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 != 0)
								{
									num4 = 9;
								}
								continue;
							case 0:
								break;
							case 2:
								throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(-290181924 ^ -290145590));
							case 7:
							case 18:
								value = new VisitorAttribute(advisorAttribute.ToString());
								num4 = 6;
								continue;
							case 12:
							case 16:
								if (_StubInterpreter.IsWhiteBreakOrZero())
								{
									num4 = 9;
									continue;
								}
								goto case 19;
							case 19:
								if (!_StubInterpreter.Check(DicSingleton.gE3WbyDVW(-830028630 ^ -830058146)))
								{
									num4 = 14;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f != 0)
									{
										num4 = 4;
									}
									continue;
								}
								goto case 1;
							case 3:
								if (!_StubInterpreter.Check(':'))
								{
									num4 = 20;
									continue;
								}
								goto case 8;
							case 21:
								break;
							}
							break;
						}
					}
					finally
					{
						((IDisposable)modelAttribute/*cast due to .constrained prefix*/).Dispose();
						int num5 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 == 0)
						{
							num5 = 0;
						}
						switch (num5)
						{
						case 0:
							break;
						}
					}
					goto case 7;
				case 5:
					start = m_PolicyInterpreter.Mark();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 == 0)
					{
						num2 = 4;
					}
					continue;
				case 9:
					if (!isAlias)
					{
						num2 = 8;
						continue;
					}
					goto case 10;
				case 6:
					if (!classInterpreter.IsRequired)
					{
						num = 3;
						break;
					}
					goto case 2;
				case 3:
					{
						num3 = 0;
						goto IL_04e6;
					}
					IL_04e6:
					flag = (byte)num3 != 0;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 == 0)
					{
						num2 = 0;
					}
					continue;
				}
				break;
			}
		}
	}

	private void FetchTag()
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 3:
				m_TagInterpreter.Enqueue(ScanTag());
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2aaca7da964541af9780eb37df39c3db != 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				SaveSimpleKey();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea != 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				listInterpreter = false;
				num2 = 3;
				break;
			case 0:
				return;
			}
		}
	}

	private SystemSingleton ScanTag()
	{
		int num = 1;
		int num2 = num;
		string text3 = default(string);
		string text2 = default(string);
		string text = default(string);
		TestsInterpreter start = default(TestsInterpreter);
		while (true)
		{
			switch (num2)
			{
			case 12:
				if (text3.Length <= 1)
				{
					num2 = 3;
					break;
				}
				goto case 6;
			case 26:
				text2 = text3;
				num2 = 13;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
				{
					num2 = 0;
				}
				break;
			case 14:
				if (text.Length == 0)
				{
					num2 = 9;
					break;
				}
				goto case 5;
			case 3:
			case 8:
				text = ScanTagUri(text3, start);
				num2 = 15;
				break;
			case 11:
				text2 = string.Empty;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 == 0)
				{
					num2 = 5;
				}
				break;
			case 9:
				text = text2;
				num2 = 11;
				break;
			case 6:
				if (text3[0] == '!')
				{
					num2 = 10;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 != 0)
					{
						num2 = 23;
					}
					break;
				}
				goto case 3;
			case 19:
				if (_StubInterpreter.Check('>'))
				{
					num2 = 25;
					break;
				}
				goto case 18;
			case 4:
				Skip();
				num2 = 22;
				break;
			case 15:
				text2 = DicSingleton.gE3WbyDVW(-1338893851 ^ -1338875651);
				num2 = 14;
				break;
			case 5:
			case 16:
			case 21:
				if (!_StubInterpreter.IsWhiteBreakOrZero())
				{
					num2 = 7;
					break;
				}
				goto case 2;
			case 1:
				start = m_PolicyInterpreter.Mark();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 != 0)
				{
					num2 = 0;
				}
				break;
			case 7:
				if (_StubInterpreter.Check(','))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3a460cd74a4c809e0f755964f2077b == 0)
					{
						num2 = 2;
					}
					break;
				}
				goto case 17;
			case 13:
				text = ScanTagUri(null, start);
				num2 = 21;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf != 0)
				{
					num2 = 21;
				}
				break;
			case 23:
				if (text3[text3.Length - 1] == '!')
				{
					num2 = 26;
					break;
				}
				goto case 3;
			case 17:
				throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(-1447578472 ^ -1447615612));
			case 2:
				return new IndexerSingleton(text2, text, start, m_PolicyInterpreter.Mark());
			case 20:
				text2 = string.Empty;
				num2 = 27;
				break;
			case 10:
			case 24:
				text3 = ScanTagHandle(isDirective: false, start);
				num2 = 12;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 == 0)
				{
					num2 = 7;
				}
				break;
			case 27:
				Skip();
				num2 = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7e7ae6cc25e34646baea4e1c2c087e7a == 0)
				{
					num2 = 0;
				}
				break;
			default:
				if (!_StubInterpreter.Check('<', 1))
				{
					num2 = 10;
					break;
				}
				goto case 20;
			case 22:
				text = ScanTagUri(null, start);
				num2 = 19;
				break;
			case 18:
				throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(0x4C73F208 ^ 0x4C7364B8));
			case 25:
				Skip();
				num2 = 16;
				break;
			}
		}
	}

	private void FetchBlockScalar(bool isLiteral)
	{
		int num = 3;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 2:
				listInterpreter = true;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			case 1:
				m_TagInterpreter.Enqueue(ScanBlockScalar(isLiteral));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 == 0)
				{
					num2 = 0;
				}
				break;
			case 3:
				SaveSimpleKey();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 == 0)
				{
					num2 = 2;
				}
				break;
			}
		}
	}

	private SystemSingleton ScanBlockScalar(bool isLiteral)
	{
		ReponseAttribute.ModelAttribute modelAttribute = ReponseAttribute.Rent();
		try
		{
			StringBuilder advisorAttribute = modelAttribute.m_AdvisorAttribute;
			ReponseAttribute.ModelAttribute modelAttribute2 = ReponseAttribute.Rent();
			try
			{
				StringBuilder advisorAttribute2 = modelAttribute2.m_AdvisorAttribute;
				ReponseAttribute.ModelAttribute modelAttribute3 = ReponseAttribute.Rent();
				try
				{
					StringBuilder advisorAttribute3 = modelAttribute3.m_AdvisorAttribute;
					int num = 0;
					int num2 = 0;
					int currentIndent = 0;
					bool flag = false;
					bool? isFirstLine = null;
					TestsInterpreter start = m_PolicyInterpreter.Mark();
					Skip();
					if (_StubInterpreter.Check(DicSingleton.gE3WbyDVW(-1743264324 ^ -1743293948)))
					{
						num = (_StubInterpreter.Check('+') ? 1 : (-1));
						Skip();
						if (_StubInterpreter.IsDigit())
						{
							if (_StubInterpreter.Check('0'))
							{
								throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(-1483531944 ^ -1483501928));
							}
							num2 = _StubInterpreter.AsDigit();
							Skip();
						}
					}
					else if (_StubInterpreter.IsDigit())
					{
						if (_StubInterpreter.Check('0'))
						{
							throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(0x6BAF1854 ^ 0x6BAF8F94));
						}
						num2 = _StubInterpreter.AsDigit();
						Skip();
						if (_StubInterpreter.Check(DicSingleton.gE3WbyDVW(0x3C33E48 ^ 0x3C3A9F0)))
						{
							num = (_StubInterpreter.Check('+') ? 1 : (-1));
							Skip();
						}
					}
					if (_StubInterpreter.Check('#'))
					{
						throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(-1133601918 ^ -1133640748));
					}
					while (_StubInterpreter.IsWhite())
					{
						Skip();
					}
					ProcessComment();
					if (!_StubInterpreter.IsBreakOrZero())
					{
						throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(0x4BDBCDC0 ^ 0x4BDB54C4));
					}
					if (_StubInterpreter.IsBreak())
					{
						SkipLine();
						if (!isFirstLine.HasValue)
						{
							isFirstLine = true;
						}
						else if (isFirstLine == true)
						{
							isFirstLine = false;
						}
					}
					TestsInterpreter end = m_PolicyInterpreter.Mark();
					if (num2 != 0)
					{
						currentIndent = ((m_DescriptorInterpreter >= 0) ? (m_DescriptorInterpreter + num2) : num2);
					}
					currentIndent = ScanBlockScalarBreaks(currentIndent, advisorAttribute3, isLiteral, ref end, ref isFirstLine);
					isFirstLine = false;
					while (m_PolicyInterpreter.LineOffset == currentIndent && !_StubInterpreter.IsZero() && !IsDocumentEnd())
					{
						bool flag2 = _StubInterpreter.IsWhite();
						if (!isLiteral && StartsWith(advisorAttribute2, '\n') && !flag && !flag2)
						{
							if (advisorAttribute3.Length == 0)
							{
								advisorAttribute.Append(' ');
							}
							advisorAttribute2.Length = 0;
						}
						else
						{
							advisorAttribute.Append(advisorAttribute2.ToString());
							advisorAttribute2.Length = 0;
						}
						advisorAttribute.Append(advisorAttribute3.ToString());
						advisorAttribute3.Length = 0;
						flag = _StubInterpreter.IsWhite();
						while (!_StubInterpreter.IsBreakOrZero())
						{
							advisorAttribute.Append(ReadCurrentCharacter());
						}
						char c = ReadLine();
						if (c != 0)
						{
							advisorAttribute2.Append(c);
						}
						currentIndent = ScanBlockScalarBreaks(currentIndent, advisorAttribute3, isLiteral, ref end, ref isFirstLine);
					}
					if (num != -1)
					{
						advisorAttribute.Append((object)advisorAttribute2);
					}
					if (num == 1)
					{
						advisorAttribute.Append((object)advisorAttribute3);
					}
					ConnectionInterpreter style = (isLiteral ? ((ConnectionInterpreter)4) : ((ConnectionInterpreter)5));
					return new IdentifierSingleton(advisorAttribute.ToString(), style, start, end);
				}
				finally
				{
					((IDisposable)modelAttribute3/*cast due to .constrained prefix*/).Dispose();
				}
			}
			finally
			{
				((IDisposable)modelAttribute2/*cast due to .constrained prefix*/).Dispose();
			}
		}
		finally
		{
			((IDisposable)modelAttribute/*cast due to .constrained prefix*/).Dispose();
		}
	}

	private int ScanBlockScalarBreaks(int currentIndent, StringBuilder breaks, bool isLiteral, ref TestsInterpreter end, ref bool? isFirstLine)
	{
		int num = 53;
		int num3 = default(int);
		int num6 = default(int);
		bool? flag2 = default(bool?);
		bool flag = default(bool);
		int num5 = default(int);
		int num4 = default(int);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 14:
				case 23:
				case 41:
				case 45:
					if (!isLiteral)
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ea4c8b68ad954c0fb4df33d6e06bd4a3 != 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 7;
				case 37:
					end = m_PolicyInterpreter.Mark();
					num = 18;
					break;
				case 16:
					end = m_PolicyInterpreter.Mark();
					num2 = 54;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec != 0)
					{
						num2 = 51;
					}
					continue;
				case 12:
					if (currentIndent < num3 - 1)
					{
						num2 = 8;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 != 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 2;
				case 15:
				case 19:
					breaks.Append(ReadLine());
					num2 = 10;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 == 0)
					{
						num2 = 37;
					}
					continue;
				case 30:
					if (!_StubInterpreter.IsSpace())
					{
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 != 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 24;
				case 46:
					num6 = m_PolicyInterpreter.LineOffset;
					num2 = 25;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0a707bb791e14c9e9a3ee77696a896b0 == 0)
					{
						num2 = 13;
					}
					continue;
				case 28:
					if (m_PolicyInterpreter.LineOffset < currentIndent)
					{
						num2 = 30;
						continue;
					}
					goto case 4;
				case 34:
					if (flag2 != flag)
					{
						num = 15;
						break;
					}
					goto case 29;
				case 9:
					flag = true;
					num2 = 21;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e == 0)
					{
						num2 = 6;
					}
					continue;
				case 21:
					if (flag2 != flag)
					{
						num2 = 23;
						continue;
					}
					goto case 3;
				case 47:
					if (_StubInterpreter.IsBreak(num5))
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 14;
				case 4:
					if (m_PolicyInterpreter.LineOffset > num6)
					{
						num2 = 46;
						continue;
					}
					goto case 25;
				case 22:
					isFirstLine = false;
					num2 = 27;
					continue;
				case 36:
					if (m_PolicyInterpreter.LineOffset <= 0)
					{
						num2 = 11;
						continue;
					}
					goto case 39;
				default:
					if (num4 <= m_PolicyInterpreter.LineOffset)
					{
						num2 = 14;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 != 0)
						{
							num2 = 7;
						}
						continue;
					}
					goto case 22;
				case 1:
					flag2 = isFirstLine;
					num2 = 9;
					continue;
				case 51:
					num5++;
					num2 = 35;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba != 0)
					{
						num2 = 23;
					}
					continue;
				case 53:
					num6 = 0;
					num2 = 52;
					continue;
				case 20:
					if (num3 <= -1)
					{
						num2 = 49;
						continue;
					}
					goto case 10;
				case 26:
				case 32:
					flag2 = isFirstLine;
					num2 = 33;
					continue;
				case 33:
					flag = true;
					num2 = 34;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4e61b266153f422fa6c595cfef4d40d3 != 0)
					{
						num2 = 18;
					}
					continue;
				case 5:
					if (!_StubInterpreter.IsSpace(num5))
					{
						num2 = 47;
						continue;
					}
					goto case 51;
				case 31:
					if (num6 > m_PolicyInterpreter.LineOffset)
					{
						num2 = 20;
						continue;
					}
					goto case 49;
				case 42:
					num5 = 0;
					num2 = 35;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd == 0)
					{
						num2 = 43;
					}
					continue;
				case 17:
					if (isLiteral)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 != 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 14;
				case 24:
					Skip();
					num2 = 31;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 == 0)
					{
						num2 = 38;
					}
					continue;
				case 10:
					throw new StructInterpreter(in end, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(-1977574774 ^ -1977614152));
				case 49:
					if (currentIndent != 0)
					{
						num2 = 44;
						continue;
					}
					goto case 36;
				case 18:
				case 38:
				case 54:
					if (currentIndent != 0)
					{
						num2 = 28;
						continue;
					}
					goto case 30;
				case 25:
					if (_StubInterpreter.IsBreak())
					{
						num2 = 32;
						continue;
					}
					goto case 17;
				case 3:
					num4 = m_PolicyInterpreter.LineOffset;
					num2 = 42;
					continue;
				case 43:
				case 50:
					if (!_StubInterpreter.IsBreak(num5))
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 == 0)
						{
							num2 = 5;
						}
						continue;
					}
					goto case 47;
				case 48:
					num3 = m_PolicyInterpreter.LineOffset;
					num2 = 19;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
					{
						num2 = 1;
					}
					continue;
				case 11:
					if (m_DescriptorInterpreter <= -1)
					{
						num = 40;
						break;
					}
					goto case 39;
				case 8:
					throw new StructInterpreter(in end, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(-243097544 ^ -243123802));
				case 2:
				case 13:
					if (!isLiteral)
					{
						num2 = 31;
						continue;
					}
					goto case 49;
				case 27:
					num3 = num4;
					num2 = 41;
					continue;
				case 39:
					currentIndent = Math.Max(num6, Math.Max(m_DescriptorInterpreter + 1, 1));
					num2 = 6;
					continue;
				case 35:
					num4++;
					num2 = 50;
					continue;
				case 7:
					if (num3 <= 1)
					{
						num2 = 13;
						continue;
					}
					goto case 12;
				case 29:
					isFirstLine = false;
					num2 = 48;
					continue;
				case 6:
				case 40:
				case 44:
					return currentIndent;
				case 52:
					num3 = -1;
					num2 = 16;
					continue;
				}
				break;
			}
		}
	}

	private void FetchQuotedScalar(bool isSingleQuoted)
	{
		int num = 6;
		IdentifierSingleton item = default(IdentifierSingleton);
		TestsInterpreter testsInterpreter = default(TestsInterpreter);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					m_DispatcherInterpreter = m_QueueInterpreter > 0;
					num2 = 12;
					continue;
				case 4:
					return;
				case 7:
					return;
				case 11:
					return;
				case 6:
					SaveSimpleKey();
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 == 0)
					{
						num2 = 5;
					}
					continue;
				case 5:
					listInterpreter = false;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 == 0)
					{
						num2 = 0;
					}
					continue;
				case 8:
					accountInterpreter = item;
					num2 = 9;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 == 0)
					{
						num2 = 10;
					}
					continue;
				case 1:
					m_TagInterpreter.Enqueue(new ComposerSingleton(DicSingleton.gE3WbyDVW(0x1C9EFC64 ^ 0x1C9E6688), testsInterpreter, testsInterpreter));
					num2 = 11;
					continue;
				case 3:
					m_TagInterpreter.Enqueue(item);
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_23f9d18f43004f488662f38dd306f6ec != 0)
					{
						num2 = 2;
					}
					continue;
				case 10:
					if (isSingleQuoted)
					{
						num2 = 7;
						continue;
					}
					goto case 9;
				case 9:
					if (_StubInterpreter.Check('#'))
					{
						break;
					}
					goto end_IL_0012;
				case 12:
					item = ScanFlowScalar(isSingleQuoted);
					num2 = 3;
					continue;
				case 2:
					break;
				}
				testsInterpreter = m_PolicyInterpreter.Mark();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 == 0)
				{
					num2 = 1;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 4;
		}
	}

	private IdentifierSingleton ScanFlowScalar(bool isSingleQuoted)
	{
		TestsInterpreter start = m_PolicyInterpreter.Mark();
		Skip();
		ReponseAttribute.ModelAttribute modelAttribute = ReponseAttribute.Rent();
		try
		{
			StringBuilder advisorAttribute = modelAttribute.m_AdvisorAttribute;
			ReponseAttribute.ModelAttribute modelAttribute2 = ReponseAttribute.Rent();
			try
			{
				StringBuilder advisorAttribute2 = modelAttribute2.m_AdvisorAttribute;
				ReponseAttribute.ModelAttribute modelAttribute3 = ReponseAttribute.Rent();
				try
				{
					StringBuilder advisorAttribute3 = modelAttribute3.m_AdvisorAttribute;
					ReponseAttribute.ModelAttribute modelAttribute4 = ReponseAttribute.Rent();
					try
					{
						StringBuilder advisorAttribute4 = modelAttribute4.m_AdvisorAttribute;
						bool flag = false;
						while (true)
						{
							if (IsDocumentIndicator())
							{
								throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(0x7742C60 ^ 0x774B7FA));
							}
							if (_StubInterpreter.IsZero())
							{
								throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(0x44072FB7 ^ 0x4407B391));
							}
							if (flag && !isSingleQuoted && m_DescriptorInterpreter >= m_PolicyInterpreter.LineOffset)
							{
								throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(0x4097B854 ^ 0x409724FC));
							}
							flag = false;
							while (!_StubInterpreter.IsWhiteBreakOrZero())
							{
								if (isSingleQuoted && _StubInterpreter.Check('\'') && _StubInterpreter.Check('\'', 1))
								{
									advisorAttribute.Append('\'');
									Skip();
									Skip();
									continue;
								}
								if (_StubInterpreter.Check(isSingleQuoted ? '\'' : '"'))
								{
									break;
								}
								if (!isSingleQuoted && _StubInterpreter.Check('\\') && _StubInterpreter.IsBreak(1))
								{
									Skip();
									SkipLine();
									flag = true;
									break;
								}
								if (!isSingleQuoted && _StubInterpreter.Check('\\'))
								{
									int num = 0;
									char c = _StubInterpreter.Peek(1);
									switch (c)
									{
									case 'x':
										num = 2;
										break;
									case 'u':
										num = 4;
										break;
									case 'U':
										num = 8;
										break;
									default:
									{
										if (processInterpreter.TryGetValue(c, out var value))
										{
											advisorAttribute.Append(value);
											break;
										}
										throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(--798431903 ^ 0x2F9787DF));
									}
									}
									Skip();
									Skip();
									if (num <= 0)
									{
										continue;
									}
									int num2 = 0;
									for (int i = 0; i < num; i++)
									{
										if (!_StubInterpreter.IsHex(i))
										{
											throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(-736996892 ^ -736965594));
										}
										num2 = (num2 << 4) + _StubInterpreter.AsHex(i);
									}
									if (num2 >= 55296 && num2 <= 57343)
									{
										for (int j = 0; j < num; j++)
										{
											Skip();
										}
										if (_StubInterpreter.Peek(0) != '\\' || (_StubInterpreter.Peek(1) != 'u' && _StubInterpreter.Peek(1) != 'U'))
										{
											throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(-1398029315 ^ -1398049359));
										}
										Skip();
										num = ((_StubInterpreter.Peek(0) != 'u') ? 8 : 4);
										Skip();
										int num3 = 0;
										for (int k = 0; k < num; k++)
										{
											if (!_StubInterpreter.IsHex(0))
											{
												throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(-428135557 ^ -428099911));
											}
											num3 = (num3 << 4) + _StubInterpreter.AsHex(k);
										}
										for (int l = 0; l < num; l++)
										{
											Skip();
										}
										num2 = char.ConvertToUtf32((char)num2, (char)num3);
									}
									else
									{
										if (num2 > 1114111)
										{
											throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(-2083714112 ^ -2083678824));
										}
										for (int m = 0; m < num; m++)
										{
											Skip();
										}
									}
									advisorAttribute.Append(char.ConvertFromUtf32(num2));
								}
								else
								{
									advisorAttribute.Append(ReadCurrentCharacter());
								}
							}
							if (_StubInterpreter.Check(isSingleQuoted ? '\'' : '"'))
							{
								break;
							}
							while (_StubInterpreter.IsWhite() || _StubInterpreter.IsBreak())
							{
								if (_StubInterpreter.IsWhite())
								{
									if (!flag)
									{
										advisorAttribute2.Append(ReadCurrentCharacter());
									}
									else
									{
										Skip();
									}
								}
								else if (!flag)
								{
									advisorAttribute2.Length = 0;
									advisorAttribute3.Append(ReadLine());
									flag = true;
								}
								else
								{
									advisorAttribute4.Append(ReadLine());
								}
							}
							if (flag)
							{
								if (StartsWith(advisorAttribute3, '\n'))
								{
									if (advisorAttribute4.Length == 0)
									{
										advisorAttribute.Append(' ');
									}
									else
									{
										advisorAttribute.Append(advisorAttribute4.ToString());
									}
								}
								else
								{
									advisorAttribute.Append(advisorAttribute3.ToString());
									advisorAttribute.Append(advisorAttribute4.ToString());
								}
								advisorAttribute3.Length = 0;
								advisorAttribute4.Length = 0;
							}
							else
							{
								advisorAttribute.Append(advisorAttribute2.ToString());
								advisorAttribute2.Length = 0;
							}
						}
						Skip();
						return new IdentifierSingleton(advisorAttribute.ToString(), isSingleQuoted ? ((ConnectionInterpreter)2) : ((ConnectionInterpreter)3), start, m_PolicyInterpreter.Mark());
					}
					finally
					{
						((IDisposable)modelAttribute4/*cast due to .constrained prefix*/).Dispose();
					}
				}
				finally
				{
					((IDisposable)modelAttribute3/*cast due to .constrained prefix*/).Dispose();
				}
			}
			finally
			{
				((IDisposable)modelAttribute2/*cast due to .constrained prefix*/).Dispose();
			}
		}
		finally
		{
			((IDisposable)modelAttribute/*cast due to .constrained prefix*/).Dispose();
		}
	}

	private void FetchPlainScalar()
	{
		int num = 11;
		bool isMultiline = default(bool);
		IdentifierSingleton item = default(IdentifierSingleton);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 7:
					isMultiline = false;
					num = 6;
					break;
				case 13:
					return;
				case 5:
					m_TagInterpreter.Enqueue(new ComposerSingleton(DicSingleton.gE3WbyDVW(-1931860206 ^ -1931822618), m_PolicyInterpreter.Mark(), m_PolicyInterpreter.Mark()));
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d == 0)
					{
						num2 = 0;
					}
					continue;
				case 10:
					listInterpreter = false;
					num2 = 7;
					continue;
				default:
					m_TagInterpreter.Enqueue(item);
					num2 = 13;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 == 0)
					{
						num2 = 9;
					}
					continue;
				case 12:
					if (m_DescriptorInterpreter >= m_PolicyInterpreter.LineOffset)
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 == 0)
						{
							num2 = 2;
						}
						continue;
					}
					goto case 5;
				case 11:
					SaveSimpleKey();
					num2 = 9;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 == 0)
					{
						num2 = 10;
					}
					continue;
				case 6:
					item = ScanPlainScalar(ref isMultiline);
					num = 3;
					break;
				case 14:
					if (m_QueueInterpreter == 0)
					{
						num2 = 12;
						continue;
					}
					goto default;
				case 3:
					accountInterpreter = item;
					num2 = 4;
					continue;
				case 9:
					if (!_StubInterpreter.Check(':'))
					{
						num = 8;
						break;
					}
					goto case 14;
				case 4:
					if (!isMultiline)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 9;
				}
				break;
			}
		}
	}

	private IdentifierSingleton ScanPlainScalar(ref bool isMultiline)
	{
		ReponseAttribute.ModelAttribute modelAttribute = ReponseAttribute.Rent();
		try
		{
			StringBuilder advisorAttribute = modelAttribute.m_AdvisorAttribute;
			ReponseAttribute.ModelAttribute modelAttribute2 = ReponseAttribute.Rent();
			try
			{
				StringBuilder advisorAttribute2 = modelAttribute2.m_AdvisorAttribute;
				ReponseAttribute.ModelAttribute modelAttribute3 = ReponseAttribute.Rent();
				try
				{
					StringBuilder advisorAttribute3 = modelAttribute3.m_AdvisorAttribute;
					ReponseAttribute.ModelAttribute modelAttribute4 = ReponseAttribute.Rent();
					try
					{
						StringBuilder advisorAttribute4 = modelAttribute4.m_AdvisorAttribute;
						bool flag = false;
						int num = m_DescriptorInterpreter + 1;
						TestsInterpreter start = m_PolicyInterpreter.Mark();
						TestsInterpreter end = start;
						ClassInterpreter classInterpreter = _VisitorInterpreter.Peek();
						while (!IsDocumentIndicator())
						{
							if (_StubInterpreter.Check('#'))
							{
								if (m_DescriptorInterpreter < 0 && m_QueueInterpreter == 0)
								{
									m_InfoInterpreter = true;
								}
								break;
							}
							bool flag2 = _StubInterpreter.Check('*') && (!classInterpreter.IsPossible || !classInterpreter.IsRequired);
							while (!_StubInterpreter.IsWhiteBreakOrZero())
							{
								if ((_StubInterpreter.Check(':') && !flag2 && (_StubInterpreter.IsWhiteBreakOrZero(1) || (m_QueueInterpreter > 0 && _StubInterpreter.Check(',', 1)))) || (m_QueueInterpreter > 0 && _StubInterpreter.Check(DicSingleton.gE3WbyDVW(-1011281439 ^ -1011243039))))
								{
									if (m_QueueInterpreter == 0 && !classInterpreter.IsPossible)
									{
										m_TagInterpreter.Enqueue(new ComposerSingleton(DicSingleton.gE3WbyDVW(-1741204886 ^ -1741173476), m_PolicyInterpreter.Mark(), m_PolicyInterpreter.Mark()));
									}
									break;
								}
								if (flag || advisorAttribute2.Length > 0)
								{
									if (flag)
									{
										if (StartsWith(advisorAttribute3, '\n'))
										{
											if (advisorAttribute4.Length == 0)
											{
												advisorAttribute.Append(' ');
											}
											else
											{
												advisorAttribute.Append((object)advisorAttribute4);
											}
										}
										else
										{
											advisorAttribute.Append((object)advisorAttribute3);
											advisorAttribute.Append((object)advisorAttribute4);
										}
										advisorAttribute3.Length = 0;
										advisorAttribute4.Length = 0;
										flag = false;
									}
									else
									{
										advisorAttribute.Append((object)advisorAttribute2);
										advisorAttribute2.Length = 0;
									}
								}
								if (m_QueueInterpreter > 0 && m_PolicyInterpreter.LineOffset < num)
								{
									throw new Exception();
								}
								advisorAttribute.Append(ReadCurrentCharacter());
								end = m_PolicyInterpreter.Mark();
							}
							if (!_StubInterpreter.IsWhite() && !_StubInterpreter.IsBreak())
							{
								break;
							}
							while (_StubInterpreter.IsWhite() || _StubInterpreter.IsBreak())
							{
								if (_StubInterpreter.IsWhite())
								{
									if (flag && m_PolicyInterpreter.LineOffset < num && _StubInterpreter.IsTab())
									{
										throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(0x21AFFB2B ^ 0x21AF64DB));
									}
									if (!flag)
									{
										advisorAttribute2.Append(ReadCurrentCharacter());
									}
									else
									{
										Skip();
									}
								}
								else
								{
									isMultiline = true;
									if (!flag)
									{
										advisorAttribute2.Length = 0;
										advisorAttribute3.Append(ReadLine());
										flag = true;
									}
									else
									{
										advisorAttribute4.Append(ReadLine());
									}
								}
							}
							if (m_QueueInterpreter == 0 && m_PolicyInterpreter.LineOffset < num)
							{
								break;
							}
						}
						if (flag)
						{
							listInterpreter = true;
						}
						return new IdentifierSingleton(advisorAttribute.ToString(), (ConnectionInterpreter)1, start, end);
					}
					finally
					{
						((IDisposable)modelAttribute4/*cast due to .constrained prefix*/).Dispose();
					}
				}
				finally
				{
					((IDisposable)modelAttribute3/*cast due to .constrained prefix*/).Dispose();
				}
			}
			finally
			{
				((IDisposable)modelAttribute2/*cast due to .constrained prefix*/).Dispose();
			}
		}
		finally
		{
			((IDisposable)modelAttribute/*cast due to .constrained prefix*/).Dispose();
		}
	}

	private void RemoveSimpleKey()
	{
		int num = 5;
		int num2 = num;
		ClassInterpreter classInterpreter = default(ClassInterpreter);
		TestsInterpreter start = default(TestsInterpreter);
		while (true)
		{
			switch (num2)
			{
			case 5:
				classInterpreter = _VisitorInterpreter.Peek();
				num2 = 4;
				continue;
			default:
				throw new AdapterInterpreter(in start, classInterpreter.Mark, DicSingleton.gE3WbyDVW(0x1606DF07 ^ 0x1606514B));
			case 6:
				classInterpreter.MarkAsImpossible();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 != 0)
				{
					num2 = 1;
				}
				continue;
			case 4:
				if (classInterpreter.IsPossible)
				{
					num2 = 3;
					continue;
				}
				goto case 6;
			case 1:
				return;
			case 3:
				if (!classInterpreter.IsRequired)
				{
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2aaca7da964541af9780eb37df39c3db == 0)
					{
						num2 = 5;
					}
					continue;
				}
				break;
			case 2:
				break;
			}
			start = classInterpreter.Mark;
			num2 = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 == 0)
			{
				num2 = 0;
			}
		}
	}

	private string ScanDirectiveName(in TestsInterpreter start)
	{
		int num = 2;
		int num2 = num;
		ReponseAttribute.ModelAttribute modelAttribute = default(ReponseAttribute.ModelAttribute);
		string result = default(string);
		while (true)
		{
			switch (num2)
			{
			case 1:
				try
				{
					StringBuilder advisorAttribute = modelAttribute.m_AdvisorAttribute;
					int num3 = 8;
					while (true)
					{
						switch (num3)
						{
						default:
							if (_StubInterpreter.IsAlphaNumericDashOrUnderscore())
							{
								num3 = 5;
								continue;
							}
							goto case 7;
						case 2:
							throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(--1844849127 ^ 0x6DF69F35));
						case 7:
							if (advisorAttribute.Length == 0)
							{
								num3 = 3;
								continue;
							}
							if (!_StubInterpreter.EndOfInput)
							{
								if (_StubInterpreter.IsWhiteBreakOrZero())
								{
									num3 = 1;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a == 0)
									{
										num3 = 0;
									}
									continue;
								}
								goto case 4;
							}
							num3 = 2;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 != 0)
							{
								num3 = 2;
							}
							continue;
						case 4:
							throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(0x5901407C ^ 0x5901E166));
						case 1:
							result = advisorAttribute.ToString();
							num3 = 6;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 == 0)
							{
								num3 = 2;
							}
							continue;
						case 3:
							throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(-1335677307 ^ -1335652843));
						case 5:
						case 9:
							advisorAttribute.Append(ReadCurrentCharacter());
							num3 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf != 0)
							{
								num3 = 0;
							}
							continue;
						case 6:
							break;
						}
						break;
					}
				}
				finally
				{
					((IDisposable)modelAttribute/*cast due to .constrained prefix*/).Dispose();
					int num4 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb == 0)
					{
						num4 = 0;
					}
					switch (num4)
					{
					case 0:
						break;
					}
				}
				goto default;
			default:
				return result;
			case 2:
				modelAttribute = ReponseAttribute.Rent();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec == 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	private void SkipWhitespaces()
	{
		int num = 3;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 2:
				Skip();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f92fb16082174ff29c1cf0085d4a3cb9 != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			case 1:
			case 3:
				if (!_StubInterpreter.IsWhite())
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb != 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 2;
			}
		}
	}

	private SystemSingleton ScanVersionDirectiveValue(in TestsInterpreter start)
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 == 0)
				{
					num2 = 0;
				}
				continue;
			}
			int major = ScanVersionDirectiveNumber(in start);
			if (!_StubInterpreter.Check('.'))
			{
				throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(-1244021215 ^ -1244061809));
			}
			Skip();
			int minor = ScanVersionDirectiveNumber(in start);
			return new ProductSingleton(new PrototypeSingleton(major, minor), start, start);
		}
	}

	private SystemSingleton ScanTagDirectiveValue(in TestsInterpreter start)
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c != 0)
				{
					num2 = 0;
				}
				continue;
			}
			string handle = ScanTagHandle(isDirective: true, start);
			if (!_StubInterpreter.IsWhite())
			{
				throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(0xB967DC8 ^ 0xB96DF98));
			}
			SkipWhitespaces();
			string prefix = ScanTagUri(null, start);
			if (!_StubInterpreter.IsWhiteBreakOrZero())
			{
				throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(0x6BAF1854 ^ 0x6BAFBA8C));
			}
			return new TemplateSingleton(handle, prefix, start, start);
		}
	}

	private string ScanTagUri(string? head, TestsInterpreter start)
	{
		int num = 1;
		int num2 = num;
		ReponseAttribute.ModelAttribute modelAttribute = default(ReponseAttribute.ModelAttribute);
		string result = default(string);
		while (true)
		{
			switch (num2)
			{
			default:
				try
				{
					StringBuilder advisorAttribute = modelAttribute.m_AdvisorAttribute;
					int num3 = 10;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f == 0)
					{
						num3 = 7;
					}
					while (true)
					{
						switch (num3)
						{
						case 8:
						case 16:
							if (!_StubInterpreter.Check('+'))
							{
								num3 = 20;
								continue;
							}
							goto case 14;
						default:
							if (advisorAttribute.Length != 0)
							{
								num3 = 23;
								continue;
							}
							goto case 9;
						case 22:
							if (!_StubInterpreter.Check(DicSingleton.gE3WbyDVW(-293474990 ^ -293515730)))
							{
								num3 = 2;
								continue;
							}
							goto case 6;
						case 26:
							advisorAttribute.Append(head.Substring(1));
							num3 = 21;
							continue;
						case 24:
							break;
						case 10:
							if (head == null)
							{
								num3 = 13;
								continue;
							}
							goto case 1;
						case 15:
							if (_StubInterpreter.IsBreak(1))
							{
								num3 = 4;
								continue;
							}
							goto case 6;
						case 14:
							advisorAttribute.Append(' ');
							num3 = 25;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
							{
								num3 = 12;
							}
							continue;
						case 12:
							advisorAttribute.Append(ScanUriEscapes(in start));
							num3 = 5;
							continue;
						case 1:
							if (head.Length <= 1)
							{
								num3 = 8;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 == 0)
								{
									num3 = 11;
								}
								continue;
							}
							goto case 26;
						case 3:
						case 5:
						case 11:
						case 13:
						case 17:
						case 21:
							if (!_StubInterpreter.IsAlphaNumericDashOrUnderscore())
							{
								num3 = 10;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd == 0)
								{
									num3 = 22;
								}
								continue;
							}
							goto case 6;
						case 25:
							Skip();
							num3 = 3;
							continue;
						case 18:
						case 20:
							advisorAttribute.Append(ReadCurrentCharacter());
							num3 = 17;
							continue;
						case 2:
							if (!_StubInterpreter.Check(','))
							{
								num3 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 == 0)
								{
									num3 = 0;
								}
								continue;
							}
							goto case 15;
						case 6:
							if (!_StubInterpreter.Check('%'))
							{
								num3 = 16;
								continue;
							}
							goto case 12;
						case 9:
							result = string.Empty;
							num3 = 24;
							continue;
						case 19:
						case 23:
						{
							string text = advisorAttribute.ToString();
							if (text.EndsWith(DicSingleton.gE3WbyDVW(-34102588 ^ -34087376)))
							{
								throw new AdapterInterpreter(m_PolicyInterpreter.Mark(), m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(-34102588 ^ -34138744));
							}
							result = text;
							num3 = 3;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf != 0)
							{
								num3 = 7;
							}
							continue;
						}
						case 7:
							break;
						}
						break;
					}
				}
				finally
				{
					((IDisposable)modelAttribute/*cast due to .constrained prefix*/).Dispose();
					int num4 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 != 0)
					{
						num4 = 0;
					}
					switch (num4)
					{
					case 0:
						break;
					}
				}
				break;
			case 1:
				modelAttribute = ReponseAttribute.Rent();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae50b6e347494ff2973fbc64d1fc9236 == 0)
				{
					num2 = 0;
				}
				continue;
			case 2:
				break;
			}
			break;
		}
		return result;
	}

	private string ScanUriEscapes(in TestsInterpreter start)
	{
		int num = 25;
		string text = default(string);
		byte[] array = default(byte[]);
		int count = default(int);
		int num4 = default(int);
		int num5 = default(int);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				int num3;
				switch (num2)
				{
				case 1:
					text = Encoding.UTF8.GetString(array, 0, count);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 == 0)
					{
						num2 = 2;
					}
					continue;
				case 23:
					throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(0x2BB207E4 ^ 0x2BB2A376));
				case 28:
					array[count++] = (byte)num4;
					num2 = 19;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb == 0)
					{
						num2 = 0;
					}
					continue;
				case 17:
					num5 = 0;
					num2 = 6;
					continue;
				case 11:
					if (_StubInterpreter.IsHex(2))
					{
						num2 = 5;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f != 0)
						{
							num2 = 3;
						}
						continue;
					}
					goto case 8;
				case 29:
					if ((num4 & 0xF0) != 224)
					{
						num2 = 15;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3ac5d604ebd547e7ac5b1603a0e85187 != 0)
						{
							num2 = 10;
						}
						continue;
					}
					num3 = 3;
					goto IL_0486;
				case 13:
					if (--num5 > 0)
					{
						num2 = 12;
						continue;
					}
					goto case 1;
				case 25:
					array = _SchemaInterpreter;
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 == 0)
					{
						num2 = 24;
					}
					continue;
				case 22:
					throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(0x6729A6D ^ 0x6723F7F));
				case 6:
				case 12:
					if (!_StubInterpreter.Check('%'))
					{
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add == 0)
						{
							num2 = 14;
						}
						continue;
					}
					goto case 26;
				case 26:
					if (_StubInterpreter.IsHex(1))
					{
						num2 = 9;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a != 0)
						{
							num2 = 11;
						}
						continue;
					}
					goto case 8;
				case 3:
					throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(0xFB046CE ^ 0xFB0E2DA));
				case 27:
					if ((num4 & 0xE0) != 192)
					{
						num2 = 29;
						continue;
					}
					num3 = 2;
					goto IL_0486;
				case 7:
					if (num5 == 0)
					{
						num2 = 18;
						continue;
					}
					goto default;
				default:
					if ((num4 & 0xC0) != 128)
					{
						num2 = 23;
						continue;
					}
					goto case 28;
				case 19:
					Skip();
					num2 = 21;
					continue;
				case 9:
					if (num5 != 0)
					{
						array = new byte[num5];
						num2 = 28;
						continue;
					}
					num = 3;
					break;
				case 15:
					if ((num4 & 0xF8) == 240)
					{
						num3 = 4;
						goto IL_0486;
					}
					num2 = 20;
					continue;
				case 24:
					count = 0;
					num2 = 17;
					continue;
				case 20:
					num3 = 0;
					goto IL_0486;
				case 8:
				case 14:
					throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(0x44072FB7 ^ 0x44078C11));
				case 5:
					num4 = (_StubInterpreter.AsHex(1) << 4) + _StubInterpreter.AsHex(2);
					num = 7;
					break;
				case 18:
					if ((num4 & 0x80) == 0)
					{
						num = 10;
						break;
					}
					goto case 27;
				case 16:
					Skip();
					num2 = 13;
					continue;
				case 4:
					if (text.Length <= 2)
					{
						return text;
					}
					num2 = 22;
					continue;
				case 21:
					Skip();
					num2 = 16;
					continue;
				case 2:
					if (text.Length != 0)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 != 0)
						{
							num2 = 4;
						}
						continue;
					}
					goto case 22;
				case 10:
					{
						num3 = 1;
						goto IL_0486;
					}
					IL_0486:
					num5 = num3;
					num2 = 9;
					continue;
				}
				break;
			}
		}
	}

	private string ScanTagHandle(bool isDirective, TestsInterpreter start)
	{
		int num = 3;
		int num2 = num;
		ReponseAttribute.ModelAttribute modelAttribute = default(ReponseAttribute.ModelAttribute);
		string result = default(string);
		while (true)
		{
			switch (num2)
			{
			default:
				try
				{
					StringBuilder advisorAttribute = modelAttribute.m_AdvisorAttribute;
					int num3 = 12;
					while (true)
					{
						switch (num3)
						{
						case 9:
							throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(-545065612 ^ -545107810));
						case 6:
						case 10:
							result = advisorAttribute.ToString();
							num3 = 4;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af != 0)
							{
								num3 = 8;
							}
							continue;
						case 4:
							if (!isDirective)
							{
								num3 = 10;
								continue;
							}
							goto case 7;
						case 7:
							if (advisorAttribute.Length == 1)
							{
								num3 = 5;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 != 0)
								{
									num3 = 11;
								}
								continue;
							}
							goto case 9;
						case 11:
							if (advisorAttribute[0] != '!')
							{
								num3 = 7;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d != 0)
								{
									num3 = 9;
								}
								continue;
							}
							goto case 6;
						case 12:
							advisorAttribute.Append(ReadCurrentCharacter());
							num3 = 2;
							continue;
						case 3:
							if (_StubInterpreter.Check('!'))
							{
								num3 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 != 0)
								{
									num3 = 0;
								}
								continue;
							}
							goto case 4;
						default:
							advisorAttribute.Append(ReadCurrentCharacter());
							num3 = 6;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
							{
								num3 = 2;
							}
							continue;
						case 2:
						case 5:
							if (!_StubInterpreter.IsAlphaNumericDashOrUnderscore())
							{
								num3 = 3;
								continue;
							}
							break;
						case 1:
							break;
						case 8:
							goto end_IL_0044;
						}
						advisorAttribute.Append(ReadCurrentCharacter());
						num3 = 5;
						continue;
						end_IL_0044:
						break;
					}
				}
				finally
				{
					((IDisposable)modelAttribute/*cast due to .constrained prefix*/).Dispose();
					int num4 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 != 0)
					{
						num4 = 0;
					}
					switch (num4)
					{
					case 0:
						break;
					}
				}
				goto case 1;
			case 2:
				throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(0x44072FB7 ^ 0x44078A31));
			case 1:
				return result;
			case 3:
				if (_StubInterpreter.Check('!'))
				{
					modelAttribute = ReponseAttribute.Rent();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3ac5d604ebd547e7ac5b1603a0e85187 == 0)
					{
						num2 = 0;
					}
				}
				else
				{
					num2 = 2;
				}
				break;
			}
		}
	}

	private int ScanVersionDirectiveNumber(in TestsInterpreter start)
	{
		int num = 4;
		int num3 = default(int);
		int num4 = default(int);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 6:
				case 7:
					if (!_StubInterpreter.IsDigit())
					{
						break;
					}
					goto end_IL_0012;
				case 2:
					Skip();
					num2 = 7;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef != 0)
					{
						num2 = 5;
					}
					continue;
				case 3:
					num3 = 0;
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 != 0)
					{
						num2 = 6;
					}
					continue;
				case 1:
					throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(-1059662249 ^ -1059688283));
				case 4:
					num4 = 0;
					num2 = 3;
					continue;
				case 5:
				case 9:
					if (++num3 > 9)
					{
						num2 = 8;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd != 0)
						{
							num2 = 7;
						}
					}
					else
					{
						num4 = num4 * 10 + _StubInterpreter.AsDigit();
						num2 = 2;
					}
					continue;
				case 8:
					throw new AdapterInterpreter(in start, m_PolicyInterpreter.Mark(), DicSingleton.gE3WbyDVW(-614239580 ^ -614214458));
				}
				if (num3 != 0)
				{
					return num4;
				}
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e == 0)
				{
					num2 = 1;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 9;
		}
	}

	private void SaveSimpleKey()
	{
		int num = 7;
		ClassInterpreter item = default(ClassInterpreter);
		bool isRequired = default(bool);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				int num3;
				switch (num2)
				{
				case 1:
					if (listInterpreter)
					{
						num2 = 2;
						continue;
					}
					return;
				case 6:
					num3 = ((m_DescriptorInterpreter == m_PolicyInterpreter.LineOffset) ? 1 : 0);
					break;
				case 5:
					RemoveSimpleKey();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_35cf05af90cc4195a86c9ffc19bf78eb == 0)
					{
						num2 = 0;
					}
					continue;
				case 7:
					if (m_QueueInterpreter != 0)
					{
						num3 = 0;
						break;
					}
					goto end_IL_0012;
				case 2:
					item = new ClassInterpreter(isRequired, collectionInterpreter + m_TagInterpreter.Count, m_PolicyInterpreter);
					num2 = 5;
					continue;
				default:
					_VisitorInterpreter.Pop();
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 == 0)
					{
						num2 = 2;
					}
					continue;
				case 4:
					return;
				case 3:
					_VisitorInterpreter.Push(item);
					num2 = 4;
					continue;
				}
				isRequired = (byte)num3 != 0;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc != 0)
				{
					num2 = 1;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 6;
		}
	}

	static AnnotationInterpreter()
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 3:
				_SchemaInterpreter = new byte[0];
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			case 1:
				processInterpreter = new SortedDictionary<char, char>
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
				num2 = 3;
				break;
			case 2:
				GetterIssuer.DeleteInitializer();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef == 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	internal static bool AssetProducer()
	{
		return PatchProducer == null;
	}

	internal static AnnotationInterpreter ListProducer()
	{
		return PatchProducer;
	}
}
