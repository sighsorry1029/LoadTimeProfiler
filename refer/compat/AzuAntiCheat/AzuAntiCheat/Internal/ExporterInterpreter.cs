using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal class ExporterInterpreter : CandidateInterpreter
{
	private class DatabaseInterpreter
	{
		private readonly Queue<ClientSingleton> m_ErrorInterpreter;

		private readonly Queue<ClientSingleton> m_RegInterpreter;

		internal static DatabaseInterpreter PopProducer;

		public int Count => m_ErrorInterpreter.Count + m_RegInterpreter.Count;

		public void Enqueue(ClientSingleton @event)
		{
			int num = 5;
			int num2 = num;
			TreeNodeStates type = default(TreeNodeStates);
			while (true)
			{
				switch (num2)
				{
				case 4:
					if (type != (TreeNodeStates)1)
					{
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 == 0)
						{
							num2 = 0;
						}
						break;
					}
					goto default;
				case 3:
					if (type == (TreeNodeStates)3)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 == 0)
						{
							num2 = 0;
						}
						break;
					}
					m_RegInterpreter.Enqueue(@event);
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 != 0)
					{
						num2 = 0;
					}
					break;
				case 2:
					return;
				case 1:
					return;
				default:
					m_ErrorInterpreter.Enqueue(@event);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_259acdc10a3c4fba8a4f129ba5346de2 == 0)
					{
						num2 = 1;
					}
					break;
				case 5:
					type = @event.Type;
					num2 = 4;
					break;
				}
			}
		}

		public ClientSingleton Dequeue()
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return m_RegInterpreter.Dequeue();
				case 1:
					if (m_ErrorInterpreter.Count > 0)
					{
						return m_ErrorInterpreter.Dequeue();
					}
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		public DatabaseInterpreter()
		{
			GetterIssuer.DeleteInitializer();
			m_ErrorInterpreter = new Queue<ClientSingleton>();
			m_RegInterpreter = new Queue<ClientSingleton>();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2aaca7da964541af9780eb37df39c3db == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal static bool PostProducer()
		{
			return PopProducer == null;
		}

		internal static DatabaseInterpreter CallProducer()
		{
			return PopProducer;
		}
	}

	private readonly Stack<ImageKind> valInterpreter;

	private readonly ProcInterpreter _ConfigInterpreter;

	private ImageKind wrapperInterpreter;

	private readonly ExpressionInterpreter m_ServerInterpreter;

	private SystemSingleton? _AlgoInterpreter;

	private ProductSingleton? m_ImporterInterpreter;

	[CompilerGenerated]
	private ClientSingleton? _CreatorInterpreter;

	private readonly DatabaseInterpreter _PrinterInterpreter;

	internal static ExporterInterpreter TestProducer;

	public ClientSingleton? Current
	{
		[CompilerGenerated]
		get
		{
			return _CreatorInterpreter;
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
					_CreatorInterpreter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b == 0)
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

	private SystemSingleton? GetCurrentToken()
	{
		int num = 9;
		int num2 = num;
		RuleSingleton ruleSingleton = default(RuleSingleton);
		while (true)
		{
			switch (num2)
			{
			case 1:
			case 8:
				if (m_ServerInterpreter.MoveNextWithoutConsuming())
				{
					num2 = 6;
					continue;
				}
				goto default;
			default:
				return _AlgoInterpreter;
			case 9:
				if (_AlgoInterpreter == null)
				{
					num2 = 8;
					continue;
				}
				goto default;
			case 7:
				m_ServerInterpreter.ConsumeCurrent();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 == 0)
				{
					num2 = 1;
				}
				continue;
			case 3:
				ruleSingleton = _AlgoInterpreter as RuleSingleton;
				num2 = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb != 0)
				{
					num2 = 2;
				}
				continue;
			case 4:
				if (ruleSingleton == null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 != 0)
					{
						num2 = 0;
					}
					continue;
				}
				break;
			case 5:
			case 6:
				_AlgoInterpreter = m_ServerInterpreter.Current;
				num2 = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 != 0)
				{
					num2 = 0;
				}
				continue;
			case 10:
				break;
			}
			_PrinterInterpreter.Enqueue(new DecoratorSingleton(ruleSingleton.Value, ruleSingleton.IsInline, ruleSingleton.Start, ruleSingleton.End));
			num2 = 7;
		}
	}

	public ExporterInterpreter(TextReader input)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(new AnnotationInterpreter(input));
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public ExporterInterpreter(ExpressionInterpreter scanner)
	{
		GetterIssuer.DeleteInitializer();
		valInterpreter = new Stack<ImageKind>();
		_ConfigInterpreter = new ProcInterpreter();
		_PrinterInterpreter = new DatabaseInterpreter();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4a2885c39dcc4cf1a32db39a2ed578f0 != 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 0:
				return;
			case 1:
				m_ServerInterpreter = scanner;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 != 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	public bool MoveNext()
	{
		int num = 4;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return true;
			case 1:
			case 2:
				Current = _PrinterInterpreter.Dequeue();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c != 0)
				{
					num2 = 0;
				}
				break;
			case 5:
				return false;
			case 3:
				Current = null;
				num2 = 5;
				break;
			case 6:
				_PrinterInterpreter.Enqueue(StateMachine());
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 == 0)
				{
					num2 = 1;
				}
				break;
			case 4:
				if (wrapperInterpreter != (ImageKind)1)
				{
					if (_PrinterInterpreter.Count != 0)
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 == 0)
						{
							num2 = 2;
						}
						break;
					}
					goto case 6;
				}
				num2 = 3;
				break;
			}
		}
	}

	private ClientSingleton StateMachine()
	{
		int num = 3;
		int num2 = num;
		ImageKind imageKind = default(ImageKind);
		while (true)
		{
			switch (num2)
			{
			case 2:
				switch (imageKind)
				{
				case (ImageKind)0:
					goto IL_00cc;
				case (ImageKind)2:
					return ParseDocumentStart(isImplicit: true);
				case (ImageKind)3:
					return ParseDocumentStart(isImplicit: false);
				case (ImageKind)4:
					return ParseDocumentContent();
				case (ImageKind)5:
					return ParseDocumentEnd();
				case (ImageKind)6:
					return ParseNode(isBlock: true, isIndentlessSequence: false);
				case (ImageKind)7:
					return ParseNode(isBlock: true, isIndentlessSequence: true);
				case (ImageKind)8:
					return ParseNode(isBlock: false, isIndentlessSequence: false);
				case (ImageKind)9:
					return ParseBlockSequenceEntry(isFirst: true);
				case (ImageKind)10:
					return ParseBlockSequenceEntry(isFirst: false);
				case (ImageKind)11:
					return ParseIndentlessSequenceEntry();
				case (ImageKind)12:
					return ParseBlockMappingKey(isFirst: true);
				case (ImageKind)13:
					return ParseBlockMappingKey(isFirst: false);
				case (ImageKind)14:
					return ParseBlockMappingValue();
				case (ImageKind)15:
					return ParseFlowSequenceEntry(isFirst: true);
				case (ImageKind)16:
					return ParseFlowSequenceEntry(isFirst: false);
				case (ImageKind)17:
					return ParseFlowSequenceEntryMappingKey();
				case (ImageKind)18:
					return ParseFlowSequenceEntryMappingValue();
				case (ImageKind)19:
					return ParseFlowSequenceEntryMappingEnd();
				case (ImageKind)20:
					return ParseFlowMappingKey(isFirst: true);
				case (ImageKind)21:
					return ParseFlowMappingKey(isFirst: false);
				case (ImageKind)22:
					return ParseFlowMappingValue(isEmpty: false);
				case (ImageKind)23:
					return ParseFlowMappingValue(isEmpty: true);
				case (ImageKind)1:
					goto IL_017f;
				}
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 != 0)
				{
					num2 = 0;
				}
				break;
			default:
				goto IL_00cc;
			case 1:
				goto IL_017f;
			case 3:
				{
					imageKind = wrapperInterpreter;
					num2 = 2;
					break;
				}
				IL_017f:
				throw new InvalidOperationException();
				IL_00cc:
				return ParseStreamStart();
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
			case 3:
				return;
			case 2:
				m_ServerInterpreter.ConsumeCurrent();
				num2 = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f != 0)
				{
					num2 = 3;
				}
				break;
			default:
				_AlgoInterpreter = null;
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb == 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				if (_AlgoInterpreter == null)
				{
					return;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	private ClientSingleton ParseStreamStart()
	{
		int num = 5;
		int num2 = num;
		CodeSingleton codeSingleton = default(CodeSingleton);
		SystemSingleton currentToken = default(SystemSingleton);
		TestsInterpreter start = default(TestsInterpreter);
		while (true)
		{
			TestsInterpreter testsInterpreter;
			switch (num2)
			{
			case 4:
				codeSingleton = currentToken as CodeSingleton;
				num2 = 9;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4a2885c39dcc4cf1a32db39a2ed578f0 != 0)
				{
					num2 = 6;
				}
				break;
			case 5:
				currentToken = GetCurrentToken();
				num2 = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d5c0c185d7b1430b897cb64adc93b81c == 0)
				{
					num2 = 0;
				}
				break;
			default:
				if (currentToken == null)
				{
					num2 = 7;
					break;
				}
				testsInterpreter = currentToken.Start;
				goto IL_0127;
			case 9:
				if (codeSingleton != null)
				{
					num2 = 3;
					break;
				}
				goto default;
			case 2:
				wrapperInterpreter = (ImageKind)2;
				num2 = 6;
				break;
			case 1:
				return new ServerSingleton(in start, codeSingleton.End);
			case 7:
				testsInterpreter = TestsInterpreter._InitializerInterpreter;
				goto IL_0127;
			case 6:
				start = codeSingleton.Start;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba != 0)
				{
					num2 = 0;
				}
				break;
			case 8:
				throw new StructInterpreter(in start, currentToken?.End ?? TestsInterpreter._InitializerInterpreter, DicSingleton.gE3WbyDVW(-2083714112 ^ -2083680300));
			case 3:
				{
					Skip();
					num2 = 2;
					break;
				}
				IL_0127:
				start = testsInterpreter;
				num2 = 8;
				break;
			}
		}
	}

	private ClientSingleton ParseDocumentStart(bool isImplicit)
	{
		int num = 40;
		TestsInterpreter start = default(TestsInterpreter);
		ProcInterpreter tags = default(ProcInterpreter);
		TestsInterpreter start2 = default(TestsInterpreter);
		ProcInterpreter tags2 = default(ProcInterpreter);
		SystemSingleton systemSingleton = default(SystemSingleton);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 33:
					if (systemSingleton is ComparatorSingleton)
					{
						num2 = 24;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 21;
				case 26:
					start = systemSingleton.Start;
					num2 = 34;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 == 0)
					{
						num2 = 9;
					}
					continue;
				case 39:
					throw new AdapterInterpreter(DicSingleton.gE3WbyDVW(-823738529 ^ -823772355));
				case 36:
					Skip();
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 != 0)
					{
						num2 = 6;
					}
					continue;
				case 1:
					valInterpreter.Push((ImageKind)5);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc != 0)
					{
						num2 = 0;
					}
					continue;
				case 13:
					if (wrapperInterpreter == (ImageKind)3)
					{
						num2 = 35;
						continue;
					}
					goto case 10;
				case 2:
				case 6:
					wrapperInterpreter = (ImageKind)1;
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba != 0)
					{
						num2 = 0;
					}
					continue;
				case 30:
				case 41:
					if (systemSingleton is ComparatorSingleton)
					{
						num2 = 5;
						continue;
					}
					goto case 7;
				case 8:
					if (!(systemSingleton is ComparatorSingleton))
					{
						num2 = 25;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f92fb16082174ff29c1cf0085d4a3cb9 != 0)
						{
							num2 = 7;
						}
						continue;
					}
					goto case 31;
				case 17:
					if (!isImplicit)
					{
						goto case 30;
					}
					num2 = 7;
					continue;
				case 12:
					if (wrapperInterpreter != (ImageKind)2)
					{
						num = 13;
						break;
					}
					goto case 35;
				case 10:
					if (!isImplicit)
					{
						num2 = 28;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 != 0)
						{
							num2 = 14;
						}
						continue;
					}
					goto case 27;
				case 21:
					tags = new ProcInterpreter();
					num2 = 22;
					continue;
				case 37:
					if (!(systemSingleton is TemplateSingleton))
					{
						num2 = 4;
						continue;
					}
					goto case 11;
				case 20:
					systemSingleton = GetCurrentToken();
					num2 = 41;
					continue;
				case 5:
				case 15:
					Skip();
					num2 = 20;
					continue;
				case 25:
					start2 = systemSingleton.Start;
					num2 = 18;
					continue;
				case 11:
				case 24:
				case 28:
				case 29:
					if (systemSingleton is IssuerSingleton)
					{
						num2 = 21;
						continue;
					}
					if (systemSingleton is GetterSingleton)
					{
						num = 31;
						break;
					}
					goto case 8;
				case 9:
					throw new AdapterInterpreter(DicSingleton.gE3WbyDVW(0x30B55457 ^ 0x30B5D17F));
				case 14:
					if (systemSingleton is IdentifierSingleton)
					{
						num2 = 12;
						continue;
					}
					goto case 10;
				case 27:
					if (systemSingleton is ProductSingleton)
					{
						num2 = 11;
						continue;
					}
					goto case 37;
				case 18:
					tags2 = new ProcInterpreter();
					num2 = 32;
					continue;
				case 35:
					isImplicit = true;
					num2 = 10;
					continue;
				case 40:
					if (!(_AlgoInterpreter is ProductSingleton))
					{
						systemSingleton = GetCurrentToken();
						num2 = 17;
					}
					else
					{
						num2 = 39;
					}
					continue;
				case 16:
					return new TestsSingleton(null, tags, isImplicit: true, systemSingleton.Start, systemSingleton.End);
				case 7:
				case 19:
					if (systemSingleton != null)
					{
						num2 = 14;
						continue;
					}
					goto case 9;
				case 23:
					if (!(systemSingleton is GetterSingleton))
					{
						num2 = 33;
						continue;
					}
					goto case 11;
				default:
					wrapperInterpreter = (ImageKind)6;
					num2 = 16;
					continue;
				case 4:
					if (systemSingleton is DefinitionSingleton)
					{
						num2 = 29;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2aaca7da964541af9780eb37df39c3db == 0)
						{
							num2 = 23;
						}
						continue;
					}
					goto case 23;
				case 22:
					ProcessDirectives(tags);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 != 0)
					{
						num2 = 1;
					}
					continue;
				case 32:
				{
					ProductSingleton? version = ProcessDirectives(tags2);
					systemSingleton = GetCurrentToken() ?? throw new StructInterpreter(DicSingleton.gE3WbyDVW(0x602C149E ^ 0x602C9138));
					if (!(systemSingleton is DefinitionSingleton))
					{
						throw new StructInterpreter(systemSingleton.Start, systemSingleton.End, DicSingleton.gE3WbyDVW(-1735703950 ^ -1735670704));
					}
					valInterpreter.Push((ImageKind)5);
					wrapperInterpreter = (ImageKind)4;
					TestsInterpreter end = systemSingleton.End;
					Skip();
					return new TestsSingleton(version, tags2, isImplicit: false, start2, end);
				}
				case 31:
					if (!(systemSingleton is ComparatorSingleton))
					{
						num2 = 2;
						continue;
					}
					goto case 36;
				case 3:
				{
					SystemSingleton? currentToken = GetCurrentToken();
					if (currentToken == null)
					{
						num2 = 38;
						continue;
					}
					systemSingleton = currentToken;
					num2 = 26;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 != 0)
					{
						num2 = 22;
					}
					continue;
				}
				case 38:
					throw new StructInterpreter(DicSingleton.gE3WbyDVW(-992201216 ^ -992169050));
				case 34:
				{
					WrapperSingleton result = new WrapperSingleton(in start, systemSingleton.End);
					if (m_ServerInterpreter.MoveNextWithoutConsuming())
					{
						throw new InvalidOperationException(DicSingleton.gE3WbyDVW(-1011281439 ^ -1011247211));
					}
					return result;
				}
				}
				break;
			}
		}
	}

	private ProductSingleton? ProcessDirectives(ProcInterpreter tags)
	{
		int num = 33;
		TemplateSingleton templateSingleton = default(TemplateSingleton);
		TestsInterpreter start = default(TestsInterpreter);
		ProductSingleton productSingleton = default(ProductSingleton);
		ProductSingleton productSingleton2 = default(ProductSingleton);
		bool flag = default(bool);
		ProductSingleton result = default(ProductSingleton);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 7:
					if (templateSingleton == null)
					{
						num = 10;
						break;
					}
					goto case 25;
				case 23:
					start = productSingleton.Start;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 != 0)
					{
						num2 = 19;
					}
					continue;
				case 10:
				case 38:
					if (!(GetCurrentToken() is DefinitionSingleton))
					{
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ea4c8b68ad954c0fb4df33d6e06bd4a3 == 0)
						{
							num2 = 20;
						}
						continue;
					}
					goto case 8;
				case 2:
				case 20:
				case 37:
					AddTagDirectives(tags, ParamsAttribute._PoolAttribute);
					num2 = 30;
					continue;
				case 12:
				case 17:
					productSingleton = GetCurrentToken() as ProductSingleton;
					num2 = 18;
					continue;
				case 31:
					if (m_ImporterInterpreter.Version.Major == 1)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 != 0)
						{
							num2 = 13;
						}
						continue;
					}
					goto case 2;
				case 18:
					if (productSingleton == null)
					{
						num2 = 27;
						continue;
					}
					goto case 35;
				case 14:
					if (productSingleton.Version.Minor > 3)
					{
						num2 = 34;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 != 0)
						{
							num2 = 30;
						}
					}
					else
					{
						productSingleton2 = (m_ImporterInterpreter = productSingleton);
						num2 = 24;
					}
					continue;
				case 13:
					if (m_ImporterInterpreter.Version.Minor > 1)
					{
						num2 = 5;
						continue;
					}
					goto case 2;
				case 25:
					if (!tags.Contains(templateSingleton.Handle))
					{
						num2 = 22;
						continue;
					}
					goto case 29;
				case 9:
				case 36:
					AddTagDirectives(_ConfigInterpreter, tags);
					num2 = 42;
					continue;
				case 30:
					if (!flag)
					{
						num2 = 36;
						continue;
					}
					goto default;
				case 4:
				case 11:
					flag = true;
					num2 = 37;
					continue;
				case 3:
					throw new StructInterpreter(in start, templateSingleton.End, DicSingleton.gE3WbyDVW(-1335677307 ^ -1335645741));
				case 22:
					tags.Add(templateSingleton);
					num2 = 28;
					continue;
				case 28:
					flag = true;
					num2 = 14;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 == 0)
					{
						num2 = 15;
					}
					continue;
				case 21:
					if (m_ImporterInterpreter == null)
					{
						num2 = 16;
						continue;
					}
					goto case 4;
				case 35:
					if (m_ImporterInterpreter != null)
					{
						num2 = 23;
						continue;
					}
					if (productSingleton.Version.Major == 1)
					{
						num2 = 8;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 == 0)
						{
							num2 = 14;
						}
						continue;
					}
					goto case 34;
				case 26:
				case 27:
					templateSingleton = GetCurrentToken() as TemplateSingleton;
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb != 0)
					{
						num2 = 7;
					}
					continue;
				case 42:
					return result;
				case 5:
				case 6:
					if (!(GetCurrentToken() is DefinitionSingleton))
					{
						num = 11;
						break;
					}
					goto case 21;
				case 32:
					result = null;
					num2 = 13;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 != 0)
					{
						num2 = 17;
					}
					continue;
				case 8:
					if (m_ImporterInterpreter == null)
					{
						num2 = 6;
						continue;
					}
					goto case 31;
				case 15:
				case 40:
				case 41:
					Skip();
					num2 = 12;
					continue;
				case 29:
					start = templateSingleton.Start;
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 == 0)
					{
						num2 = 2;
					}
					continue;
				case 16:
					m_ImporterInterpreter = new ProductSingleton(new PrototypeSingleton(1, 2));
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab != 0)
					{
						num2 = 0;
					}
					continue;
				case 33:
					flag = false;
					num2 = 32;
					continue;
				case 34:
					start = productSingleton.Start;
					num2 = 39;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd != 0)
					{
						num2 = 16;
					}
					continue;
				case 19:
					throw new StructInterpreter(in start, productSingleton.End, DicSingleton.gE3WbyDVW(0x5A8BEE ^ 0x5A0D22));
				default:
					_ConfigInterpreter.Clear();
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 == 0)
					{
						num2 = 9;
					}
					continue;
				case 1:
					flag = true;
					num2 = 40;
					continue;
				case 24:
					result = productSingleton2;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 == 0)
					{
						num2 = 1;
					}
					continue;
				case 39:
					throw new StructInterpreter(in start, productSingleton.End, DicSingleton.gE3WbyDVW(0x408F2744 ^ 0x408FA054));
				}
				break;
			}
		}
	}

	private static void AddTagDirectives(ProcInterpreter directives, IEnumerable<TemplateSingleton> source)
	{
		foreach (TemplateSingleton item in source)
		{
			if (!directives.Contains(item))
			{
				directives.Add(item);
			}
		}
	}

	private ClientSingleton ParseDocumentContent()
	{
		int num = 7;
		TestsInterpreter position = default(TestsInterpreter);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 7:
					if (GetCurrentToken() is ProductSingleton)
					{
						num2 = 6;
						continue;
					}
					goto case 12;
				default:
					wrapperInterpreter = valInterpreter.Pop();
					num = 4;
					break;
				case 4:
					position = m_ServerInterpreter.CurrentPosition;
					num = 8;
					break;
				case 9:
					if (!(GetCurrentToken() is GetterSingleton))
					{
						num2 = 10;
						continue;
					}
					goto default;
				case 3:
					if (GetCurrentToken() is ComparatorSingleton)
					{
						num2 = 5;
						continue;
					}
					goto case 9;
				case 12:
					if (GetCurrentToken() is TemplateSingleton)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba == 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 2;
				case 8:
					return ProcessEmptyScalar(in position);
				case 10:
					return ParseNode(isBlock: true, isIndentlessSequence: false);
				case 2:
					if (GetCurrentToken() is DefinitionSingleton)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 3;
				}
				break;
			}
		}
	}

	private static ClientSingleton ProcessEmptyScalar(in TestsInterpreter position)
	{
		return new BridgeSingleton(VisitorAttribute._StubAttribute, RoleSingleton.publisherSingleton, string.Empty, (ConnectionInterpreter)1, isPlainImplicit: true, isQuotedImplicit: false, position, position);
	}

	private ClientSingleton ParseNode(bool isBlock, bool isIndentlessSequence)
	{
		int num = 49;
		RoleSingleton tag = default(RoleSingleton);
		IndexerSingleton indexerSingleton = default(IndexerSingleton);
		SystemSingleton systemSingleton = default(SystemSingleton);
		IdentifierSingleton identifierSingleton = default(IdentifierSingleton);
		WriterSingleton writerSingleton = default(WriterSingleton);
		AuthenticationSingleton authenticationSingleton = default(AuthenticationSingleton);
		ComposerSingleton composerSingleton2 = default(ComposerSingleton);
		FieldSingleton fieldSingleton = default(FieldSingleton);
		AuthenticationSingleton authenticationSingleton2 = default(AuthenticationSingleton);
		IssuerSingleton issuerSingleton = default(IssuerSingleton);
		bool isPlainImplicit = default(bool);
		VisitorAttribute anchor = default(VisitorAttribute);
		ContextSingleton contextSingleton = default(ContextSingleton);
		bool isEmpty = default(bool);
		TestsInterpreter start = default(TestsInterpreter);
		TestsInterpreter start2 = default(TestsInterpreter);
		ExceptionSingleton exceptionSingleton = default(ExceptionSingleton);
		WriterSingleton writerSingleton2 = default(WriterSingleton);
		IndexerSingleton indexerSingleton2 = default(IndexerSingleton);
		bool isQuotedImplicit = default(bool);
		WriterSingleton writerSingleton3 = default(WriterSingleton);
		ComposerSingleton composerSingleton = default(ComposerSingleton);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 40:
				case 51:
					if (!tag.IsEmpty)
					{
						num2 = 91;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_23f9d18f43004f488662f38dd306f6ec != 0)
						{
							num2 = 46;
						}
						continue;
					}
					goto case 25;
				case 7:
					indexerSingleton = systemSingleton as IndexerSingleton;
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba == 0)
					{
						num2 = 56;
					}
					continue;
				case 18:
					if (identifierSingleton.Style == (ConnectionInterpreter)1)
					{
						num2 = 43;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 == 0)
						{
							num2 = 16;
						}
						continue;
					}
					goto case 14;
				case 77:
					wrapperInterpreter = valInterpreter.Pop();
					num2 = 30;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 == 0)
					{
						num2 = 80;
					}
					continue;
				case 13:
					tag = new RoleSingleton(_ConfigInterpreter[indexerSingleton.Handle].Prefix + indexerSingleton.Suffix);
					num2 = 82;
					continue;
				case 33:
					if (!(GetCurrentToken() is SingletonSingleton))
					{
						num2 = 35;
						continue;
					}
					goto case 58;
				case 14:
					if (!tag.IsNonSpecific)
					{
						num2 = 40;
						continue;
					}
					goto case 70;
				case 66:
					writerSingleton = null;
					num2 = 50;
					continue;
				case 6:
					if (authenticationSingleton != null)
					{
						num2 = 65;
						continue;
					}
					composerSingleton2 = systemSingleton as ComposerSingleton;
					num2 = 16;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
					{
						num2 = 3;
					}
					continue;
				case 4:
					fieldSingleton = systemSingleton as FieldSingleton;
					num2 = 83;
					continue;
				case 53:
				{
					StateSingleton result2 = new StateSingleton(authenticationSingleton2.Value, authenticationSingleton2.Start, authenticationSingleton2.End);
					Skip();
					return result2;
				}
				case 44:
					if (issuerSingleton != null)
					{
						num2 = 45;
						continue;
					}
					goto case 9;
				case 49:
					composerSingleton = GetCurrentToken() as ComposerSingleton;
					num2 = 48;
					continue;
				case 16:
					if (composerSingleton2 != null)
					{
						num2 = 71;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 != 0)
						{
							num2 = 76;
						}
						continue;
					}
					goto case 54;
				case 70:
				case 72:
					isPlainImplicit = true;
					num2 = 78;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 != 0)
					{
						num2 = 6;
					}
					continue;
				case 47:
					if (!anchor.IsEmpty)
					{
						num2 = 92;
						continue;
					}
					goto case 86;
				case 56:
					if (indexerSingleton != null)
					{
						num2 = 2;
						continue;
					}
					goto case 31;
				case 85:
					if (contextSingleton == null)
					{
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 == 0)
						{
							num2 = 59;
						}
						continue;
					}
					goto case 3;
				case 71:
					anchor = VisitorAttribute._StubAttribute;
					num2 = 60;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 == 0)
					{
						num2 = 61;
					}
					continue;
				case 80:
					return new BridgeSingleton(anchor, tag, string.Empty, (ConnectionInterpreter)1, isEmpty, isQuotedImplicit: false, start, systemSingleton.End);
				case 79:
					start2 = systemSingleton.Start;
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 != 0)
					{
						num2 = 27;
					}
					continue;
				case 17:
					tag = new RoleSingleton(indexerSingleton.Suffix);
					num = 38;
					break;
				case 73:
					if (!isIndentlessSequence)
					{
						num2 = 28;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 == 0)
						{
							num2 = 52;
						}
						continue;
					}
					goto case 33;
				case 29:
					return new FacadeSingleton(anchor, tag, isEmpty, (Level)2, start, exceptionSingleton.End);
				case 55:
					if (!isBlock)
					{
						num2 = 9;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 == 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 4;
				case 15:
					start2 = writerSingleton2.Start;
					num2 = 51;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 != 0)
					{
						num2 = 63;
					}
					continue;
				case 89:
					Skip();
					num2 = 52;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 == 0)
					{
						num2 = 69;
					}
					continue;
				case 27:
					throw new StructInterpreter(in start2, systemSingleton.End, DicSingleton.gE3WbyDVW(-598551743 ^ -598582537));
				case 43:
					if (tag.IsEmpty)
					{
						num2 = 72;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 != 0)
						{
							num2 = 13;
						}
						continue;
					}
					goto case 14;
				case 3:
					wrapperInterpreter = (ImageKind)15;
					num2 = 60;
					continue;
				default:
					throw new StructInterpreter(in start2, authenticationSingleton.End, DicSingleton.gE3WbyDVW(-1447578472 ^ -1447609260));
				case 92:
					return new BridgeSingleton(anchor, default(RoleSingleton), string.Empty, (ConnectionInterpreter)0, isPlainImplicit: false, isQuotedImplicit: false, writerSingleton.Start, writerSingleton.End);
				case 86:
					start2 = composerSingleton2.Start;
					num2 = 22;
					continue;
				case 76:
					if (indexerSingleton2 != null)
					{
						num2 = 14;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 != 0)
						{
							num2 = 90;
						}
						continue;
					}
					goto case 86;
				case 83:
					if (fieldSingleton == null)
					{
						num2 = 11;
						continue;
					}
					goto case 10;
				case 19:
					if (authenticationSingleton2 == null)
					{
						start = systemSingleton.Start;
						num2 = 71;
						continue;
					}
					num2 = 10;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f != 0)
					{
						num2 = 95;
					}
					continue;
				case 95:
					wrapperInterpreter = valInterpreter.Pop();
					num2 = 53;
					continue;
				case 48:
					if (composerSingleton == null)
					{
						num = 39;
						break;
					}
					goto case 26;
				case 25:
					isQuotedImplicit = true;
					num = 62;
					break;
				case 34:
					if (!string.IsNullOrEmpty(indexerSingleton.Handle))
					{
						num2 = 5;
						continue;
					}
					goto case 17;
				case 61:
					tag = RoleSingleton.publisherSingleton;
					num2 = 66;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 == 0)
					{
						num2 = 61;
					}
					continue;
				case 24:
					isQuotedImplicit = false;
					num2 = 12;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 != 0)
					{
						num2 = 18;
					}
					continue;
				case 62:
				case 78:
				case 91:
					wrapperInterpreter = valInterpreter.Pop();
					num2 = 25;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4e61b266153f422fa6c595cfef4d40d3 == 0)
					{
						num2 = 89;
					}
					continue;
				case 88:
					if (tag.IsEmpty)
					{
						num2 = 79;
						continue;
					}
					goto case 77;
				case 58:
					wrapperInterpreter = (ImageKind)11;
					num2 = 10;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc != 0)
					{
						num2 = 93;
					}
					continue;
				case 87:
					anchor = writerSingleton3.Value;
					num2 = 67;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc == 0)
					{
						num2 = 46;
					}
					continue;
				case 60:
					return new ExporterSingleton(anchor, tag, isEmpty, (DockingBehavior)2, start, contextSingleton.End);
				case 59:
					exceptionSingleton = systemSingleton as ExceptionSingleton;
					num2 = 32;
					continue;
				case 84:
					throw new StructInterpreter(in start2, indexerSingleton.End, DicSingleton.gE3WbyDVW(-228218718 ^ -228253534));
				case 38:
				case 82:
					Skip();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 != 0)
					{
						num2 = 1;
					}
					continue;
				case 45:
					wrapperInterpreter = (ImageKind)12;
					num2 = 23;
					continue;
				case 63:
					throw new StructInterpreter(in start2, writerSingleton2.End, DicSingleton.gE3WbyDVW(0x47C77AB8 ^ 0x47C7F2DE));
				case 37:
					if (tag.IsEmpty)
					{
						num = 7;
						break;
					}
					goto case 31;
				case 2:
					indexerSingleton2 = indexerSingleton;
					num2 = 34;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf == 0)
					{
						num2 = 4;
					}
					continue;
				case 54:
					isEmpty = tag.IsEmpty;
					num2 = 73;
					continue;
				case 30:
					if (writerSingleton3 != null)
					{
						num2 = 21;
						continue;
					}
					goto case 37;
				case 21:
					writerSingleton = writerSingleton3;
					num2 = 87;
					continue;
				case 94:
					wrapperInterpreter = (ImageKind)20;
					num2 = 22;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 == 0)
					{
						num2 = 29;
					}
					continue;
				case 65:
					start2 = authenticationSingleton.Start;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 == 0)
					{
						num2 = 0;
					}
					continue;
				case 93:
					return new ExporterSingleton(anchor, tag, isEmpty, (DockingBehavior)1, start, systemSingleton.End);
				case 35:
				case 52:
					identifierSingleton = systemSingleton as IdentifierSingleton;
					num2 = 42;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb == 0)
					{
						num2 = 42;
					}
					continue;
				case 31:
					writerSingleton2 = systemSingleton as WriterSingleton;
					num2 = 15;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 == 0)
					{
						num2 = 20;
					}
					continue;
				case 8:
				case 75:
					if (anchor.IsEmpty)
					{
						num2 = 68;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 != 0)
						{
							num2 = 55;
						}
						continue;
					}
					goto case 37;
				case 81:
					return new ExporterSingleton(anchor, tag, isEmpty, (DockingBehavior)1, start, fieldSingleton.End);
				case 11:
					issuerSingleton = systemSingleton as IssuerSingleton;
					num2 = 44;
					continue;
				case 50:
					indexerSingleton2 = null;
					num2 = 75;
					continue;
				case 10:
					wrapperInterpreter = (ImageKind)9;
					num = 81;
					break;
				case 90:
					if (writerSingleton == null)
					{
						num2 = 86;
						continue;
					}
					goto case 47;
				case 23:
					return new FacadeSingleton(anchor, tag, isEmpty, (Level)1, start, issuerSingleton.End);
				case 9:
					if (anchor.IsEmpty)
					{
						num = 88;
						break;
					}
					goto case 77;
				case 41:
					start2 = indexerSingleton.Start;
					num2 = 84;
					continue;
				case 68:
					writerSingleton3 = systemSingleton as WriterSingleton;
					num2 = 30;
					continue;
				case 32:
					if (exceptionSingleton == null)
					{
						num2 = 55;
						continue;
					}
					goto case 94;
				case 20:
					if (writerSingleton2 == null)
					{
						authenticationSingleton = systemSingleton as AuthenticationSingleton;
						num = 6;
						break;
					}
					num2 = 15;
					continue;
				case 67:
					Skip();
					num2 = 57;
					continue;
				case 74:
					authenticationSingleton2 = systemSingleton as AuthenticationSingleton;
					num2 = 19;
					continue;
				case 28:
					isPlainImplicit = false;
					num2 = 24;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 == 0)
					{
						num2 = 18;
					}
					continue;
				case 42:
					if (identifierSingleton != null)
					{
						num2 = 28;
						continue;
					}
					contextSingleton = systemSingleton as ContextSingleton;
					num2 = 85;
					continue;
				case 5:
				case 64:
					if (_ConfigInterpreter.Contains(indexerSingleton.Handle))
					{
						num2 = 13;
						continue;
					}
					goto case 41;
				case 26:
					start2 = composerSingleton.Start;
					num2 = 46;
					continue;
				case 46:
					throw new StructInterpreter(in start2, composerSingleton.End, composerSingleton.Value);
				case 39:
				{
					SystemSingleton? currentToken2 = GetCurrentToken();
					if (currentToken2 == null)
					{
						num2 = 36;
						continue;
					}
					systemSingleton = currentToken2;
					num = 74;
					break;
				}
				case 36:
					throw new StructInterpreter(DicSingleton.gE3WbyDVW(-1931860206 ^ -1931829110));
				case 22:
					throw new StructInterpreter(in start2, composerSingleton2.End, composerSingleton2.Value);
				case 1:
				case 57:
				{
					SystemSingleton? currentToken = GetCurrentToken();
					if (currentToken == null)
					{
						num2 = 12;
						continue;
					}
					systemSingleton = currentToken;
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 != 0)
					{
						num2 = 8;
					}
					continue;
				}
				case 12:
					throw new StructInterpreter(DicSingleton.gE3WbyDVW(-525002617 ^ -524968161));
				case 69:
				{
					BridgeSingleton result = new BridgeSingleton(anchor, tag, identifierSingleton.Value, identifierSingleton.Style, isPlainImplicit, isQuotedImplicit, start, identifierSingleton.End, identifierSingleton.IsKey);
					if (!anchor.IsEmpty && m_ServerInterpreter.MoveNextWithoutConsuming())
					{
						_AlgoInterpreter = m_ServerInterpreter.Current;
						if (_AlgoInterpreter is ComposerSingleton)
						{
							composerSingleton = _AlgoInterpreter as ComposerSingleton;
							throw new StructInterpreter(composerSingleton.Start, composerSingleton.End, composerSingleton.Value);
						}
					}
					if (wrapperInterpreter == (ImageKind)21 && m_ServerInterpreter.MoveNextWithoutConsuming())
					{
						_AlgoInterpreter = m_ServerInterpreter.Current;
						if (_AlgoInterpreter != null && !(_AlgoInterpreter is MapSingleton) && !(_AlgoInterpreter is HelperSingleton))
						{
							throw new StructInterpreter(_AlgoInterpreter.Start, _AlgoInterpreter.End, DicSingleton.gE3WbyDVW(-1549341817 ^ -1549376845));
						}
					}
					return result;
				}
				}
				break;
			}
		}
	}

	private ClientSingleton ParseDocumentEnd()
	{
		int num = 9;
		TestsInterpreter end = default(TestsInterpreter);
		SystemSingleton systemSingleton = default(SystemSingleton);
		TestsInterpreter start = default(TestsInterpreter);
		bool isImplicit = default(bool);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 18:
					end = systemSingleton.End;
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f011663d64054593978962dcc3a5ec1a == 0)
					{
						num2 = 3;
					}
					continue;
				case 13:
					if (_AlgoInterpreter is DefinitionSingleton)
					{
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 != 0)
						{
							num2 = 12;
						}
						continue;
					}
					goto case 6;
				case 23:
					if (!(systemSingleton is ComparatorSingleton))
					{
						num2 = 3;
						continue;
					}
					goto case 18;
				case 19:
					wrapperInterpreter = (ImageKind)3;
					num2 = 4;
					continue;
				case 10:
				case 21:
					throw new StructInterpreter(in start, in end, DicSingleton.gE3WbyDVW(0x6E29C0C0 ^ 0x6E294A64));
				case 12:
				case 17:
				case 22:
					if (m_ImporterInterpreter != null)
					{
						num2 = 7;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 == 0)
						{
							num2 = 2;
						}
						continue;
					}
					goto case 19;
				case 20:
					m_ImporterInterpreter = null;
					num2 = 19;
					continue;
				case 4:
					return new TaskSingleton(isImplicit, start, end);
				case 9:
				{
					SystemSingleton? currentToken = GetCurrentToken();
					if (currentToken == null)
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 == 0)
						{
							num2 = 8;
						}
					}
					else
					{
						systemSingleton = currentToken;
						num2 = 11;
					}
					continue;
				}
				case 24:
					if (!(_AlgoInterpreter is ProductSingleton))
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 12;
				case 15:
					if (!(_AlgoInterpreter is ComposerSingleton))
					{
						num2 = 21;
						continue;
					}
					goto case 12;
				case 3:
				case 14:
					if (!(_AlgoInterpreter is GetterSingleton))
					{
						num2 = 13;
						continue;
					}
					goto case 12;
				case 2:
					start = systemSingleton.Start;
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 == 0)
					{
						num2 = 16;
					}
					continue;
				case 6:
					if (_AlgoInterpreter is ItemSingleton)
					{
						num2 = 22;
						continue;
					}
					goto case 24;
				case 1:
					if (m_ImporterInterpreter.Version.Minor > 1)
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 != 0)
						{
							num2 = 20;
						}
						continue;
					}
					goto case 19;
				case 7:
					if (m_ImporterInterpreter.Version.Major == 1)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac != 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 19;
				case 25:
					isImplicit = false;
					num2 = 17;
					continue;
				case 11:
					break;
				case 16:
					end = start;
					num2 = 23;
					continue;
				default:
					if (!(Current is BridgeSingleton))
					{
						num2 = 10;
						continue;
					}
					goto case 15;
				case 5:
					Skip();
					num2 = 22;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 == 0)
					{
						num2 = 25;
					}
					continue;
				case 8:
					throw new StructInterpreter(DicSingleton.gE3WbyDVW(0x6CF51E1A ^ 0x6CF59436));
				}
				break;
			}
			isImplicit = true;
			num = 2;
		}
	}

	private ClientSingleton ParseBlockSequenceEntry(bool isFirst)
	{
		int num = 12;
		SingletonSingleton singletonSingleton = default(SingletonSingleton);
		SystemSingleton currentToken = default(SystemSingleton);
		TestsInterpreter start = default(TestsInterpreter);
		InterpreterSingleton interpreterSingleton = default(InterpreterSingleton);
		TestsInterpreter position = default(TestsInterpreter);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				TestsInterpreter testsInterpreter;
				switch (num2)
				{
				case 10:
					singletonSingleton = currentToken as SingletonSingleton;
					num2 = 5;
					continue;
				case 4:
					return ParseNode(isBlock: true, isIndentlessSequence: false);
				case 13:
					currentToken = GetCurrentToken();
					num2 = 21;
					continue;
				case 6:
					Skip();
					num2 = 16;
					continue;
				case 1:
					wrapperInterpreter = valInterpreter.Pop();
					num2 = 20;
					continue;
				case 12:
					if (isFirst)
					{
						num2 = 11;
						continue;
					}
					goto case 16;
				case 5:
					if (singletonSingleton == null)
					{
						num = 7;
						break;
					}
					goto case 17;
				case 8:
					Skip();
					num2 = 13;
					continue;
				case 20:
					start = interpreterSingleton.Start;
					num2 = 3;
					continue;
				case 15:
					if (!(currentToken is InterpreterSingleton))
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e == 0)
						{
							num2 = 2;
						}
						continue;
					}
					goto IL_0090;
				case 2:
					valInterpreter.Push((ImageKind)10);
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3ac5d604ebd547e7ac5b1603a0e85187 != 0)
					{
						num2 = 3;
					}
					continue;
				case 3:
				{
					MessageSingleton result = new MessageSingleton(in start, interpreterSingleton.End);
					Skip();
					return result;
				}
				case 18:
					if (interpreterSingleton == null)
					{
						if (currentToken != null)
						{
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 == 0)
							{
								num2 = 0;
							}
							continue;
						}
						goto case 9;
					}
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 == 0)
					{
						num2 = 1;
					}
					continue;
				case 21:
					if (!(currentToken is SingletonSingleton))
					{
						num = 15;
						break;
					}
					goto IL_0090;
				case 11:
					GetCurrentToken();
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4a2885c39dcc4cf1a32db39a2ed578f0 != 0)
					{
						num2 = 3;
					}
					continue;
				case 16:
					currentToken = GetCurrentToken();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 != 0)
					{
						num2 = 10;
					}
					continue;
				case 9:
					testsInterpreter = TestsInterpreter._InitializerInterpreter;
					goto IL_02ce;
				case 19:
					return ProcessEmptyScalar(in position);
				case 7:
					interpreterSingleton = currentToken as InterpreterSingleton;
					num2 = 18;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e != 0)
					{
						num2 = 12;
					}
					continue;
				case 17:
					position = singletonSingleton.End;
					num2 = 8;
					continue;
				default:
					testsInterpreter = currentToken.Start;
					goto IL_02ce;
				case 14:
					{
						throw new StructInterpreter(in start, currentToken?.End ?? TestsInterpreter._InitializerInterpreter, DicSingleton.gE3WbyDVW(-1817326817 ^ -1817361939));
					}
					IL_0090:
					wrapperInterpreter = (ImageKind)10;
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 != 0)
					{
						num2 = 19;
					}
					continue;
					IL_02ce:
					start = testsInterpreter;
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb != 0)
					{
						num2 = 14;
					}
					continue;
				}
				break;
			}
		}
	}

	private ClientSingleton ParseIndentlessSequenceEntry()
	{
		int num = 4;
		TestsInterpreter position = default(TestsInterpreter);
		SingletonSingleton singletonSingleton = default(SingletonSingleton);
		SystemSingleton currentToken = default(SystemSingleton);
		TestsInterpreter start = default(TestsInterpreter);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				TestsInterpreter testsInterpreter;
				switch (num2)
				{
				case 18:
					position = singletonSingleton.End;
					num2 = 14;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f == 0)
					{
						num2 = 14;
					}
					continue;
				case 12:
					return ProcessEmptyScalar(in position);
				default:
					currentToken = GetCurrentToken();
					num2 = 17;
					continue;
				case 14:
					Skip();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be == 0)
					{
						num2 = 0;
					}
					continue;
				case 8:
					valInterpreter.Push((ImageKind)11);
					num2 = 11;
					continue;
				case 6:
					testsInterpreter = TestsInterpreter._InitializerInterpreter;
					goto IL_0258;
				case 17:
					if (currentToken is SingletonSingleton)
					{
						num2 = 10;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd == 0)
						{
							num2 = 16;
						}
						continue;
					}
					goto case 10;
				case 2:
					if (currentToken is ExpressionSingleton)
					{
						num2 = 5;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 != 0)
						{
							num2 = 5;
						}
						continue;
					}
					goto case 7;
				case 7:
					if (!(currentToken is InterpreterSingleton))
					{
						num2 = 8;
						continue;
					}
					goto case 5;
				case 3:
					singletonSingleton = currentToken as SingletonSingleton;
					num = 15;
					break;
				case 11:
					return ParseNode(isBlock: true, isIndentlessSequence: false);
				case 5:
				case 16:
					wrapperInterpreter = (ImageKind)11;
					num2 = 12;
					continue;
				case 10:
					if (!(currentToken is MapperSingleton))
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_575e6bd686b54d028cdc3fc324b58a39 != 0)
						{
							num2 = 2;
						}
						continue;
					}
					goto case 5;
				case 15:
					if (singletonSingleton == null)
					{
						wrapperInterpreter = valInterpreter.Pop();
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 == 0)
						{
							num2 = 1;
						}
					}
					else
					{
						num2 = 18;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3aab303a2946368dda3deef055dc93 != 0)
						{
							num2 = 18;
						}
					}
					continue;
				case 4:
					currentToken = GetCurrentToken();
					num2 = 3;
					continue;
				case 1:
					if (currentToken != null)
					{
						num2 = 13;
						continue;
					}
					goto case 6;
				case 13:
					testsInterpreter = currentToken.Start;
					goto IL_0258;
				case 9:
					{
						return new MessageSingleton(in start, currentToken?.End ?? TestsInterpreter._InitializerInterpreter);
					}
					IL_0258:
					start = testsInterpreter;
					num = 9;
					break;
				}
				break;
			}
		}
	}

	private ClientSingleton ParseBlockMappingKey(bool isFirst)
	{
		int num = 5;
		TestsInterpreter position = default(TestsInterpreter);
		SystemSingleton currentToken = default(SystemSingleton);
		TestsInterpreter start = default(TestsInterpreter);
		InterpreterSingleton interpreterSingleton = default(InterpreterSingleton);
		AuthenticationSingleton authenticationSingleton = default(AuthenticationSingleton);
		MapperSingleton mapperSingleton = default(MapperSingleton);
		ExpressionSingleton expressionSingleton = default(ExpressionSingleton);
		ComposerSingleton composerSingleton = default(ComposerSingleton);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				TestsInterpreter testsInterpreter;
				switch (num2)
				{
				case 8:
					return ProcessEmptyScalar(in position);
				case 25:
					valInterpreter.Push((ImageKind)14);
					num2 = 24;
					continue;
				case 29:
					if (currentToken is MapperSingleton)
					{
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 == 0)
						{
							num2 = 23;
						}
						continue;
					}
					goto case 35;
				case 19:
					return ProcessEmptyScalar(in start);
				case 12:
					currentToken = GetCurrentToken();
					num2 = 29;
					continue;
				case 27:
					currentToken = GetCurrentToken();
					num2 = 32;
					continue;
				case 31:
					testsInterpreter = TestsInterpreter._InitializerInterpreter;
					goto IL_0494;
				case 28:
				{
					ParamSingleton result = new ParamSingleton(in start, interpreterSingleton.End);
					Skip();
					return result;
				}
				case 34:
					if (authenticationSingleton == null)
					{
						num2 = 7;
						continue;
					}
					goto case 11;
				case 4:
					GetCurrentToken();
					num2 = 22;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a579dea83d2144838086d2d400bd0222 == 0)
					{
						num2 = 8;
					}
					continue;
				case 9:
					if (mapperSingleton == null)
					{
						expressionSingleton = currentToken as ExpressionSingleton;
						num2 = 14;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 == 0)
						{
							num2 = 4;
						}
					}
					else
					{
						num2 = 16;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
						{
							num2 = 1;
						}
					}
					continue;
				case 5:
					if (isFirst)
					{
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 27;
				case 13:
					if (interpreterSingleton == null)
					{
						composerSingleton = GetCurrentToken() as ComposerSingleton;
						num2 = 3;
						continue;
					}
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a == 0)
					{
						num2 = 0;
					}
					continue;
				case 3:
					if (composerSingleton == null)
					{
						num2 = 15;
						continue;
					}
					goto default;
				case 35:
					if (currentToken is ExpressionSingleton)
					{
						num = 6;
						break;
					}
					goto case 30;
				case 33:
					Skip();
					num2 = 12;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add == 0)
					{
						num2 = 12;
					}
					continue;
				case 2:
					wrapperInterpreter = valInterpreter.Pop();
					num = 17;
					break;
				case 24:
					return ParseNode(isBlock: true, isIndentlessSequence: true);
				case 6:
				case 23:
					wrapperInterpreter = (ImageKind)14;
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 == 0)
					{
						num2 = 5;
					}
					continue;
				case 30:
					if (!(currentToken is InterpreterSingleton))
					{
						num2 = 19;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e == 0)
						{
							num2 = 25;
						}
						continue;
					}
					goto case 6;
				case 17:
					start = interpreterSingleton.Start;
					num = 28;
					break;
				case 14:
					if (expressionSingleton == null)
					{
						authenticationSingleton = currentToken as AuthenticationSingleton;
						num2 = 34;
					}
					else
					{
						num2 = 21;
					}
					continue;
				case 21:
					Skip();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 == 0)
					{
						num2 = 1;
					}
					continue;
				default:
					start = composerSingleton.Start;
					num2 = 26;
					continue;
				case 32:
					mapperSingleton = currentToken as MapperSingleton;
					num2 = 9;
					continue;
				case 11:
					Skip();
					num2 = 17;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf != 0)
					{
						num2 = 20;
					}
					continue;
				case 1:
					start = expressionSingleton.End;
					num2 = 19;
					continue;
				case 16:
					position = mapperSingleton.End;
					num2 = 33;
					continue;
				case 20:
					return new StateSingleton(authenticationSingleton.Value, authenticationSingleton.Start, authenticationSingleton.End);
				case 7:
					interpreterSingleton = currentToken as InterpreterSingleton;
					num2 = 13;
					continue;
				case 26:
					throw new AdapterInterpreter(in start, composerSingleton.End, composerSingleton.Value);
				case 15:
					if (currentToken != null)
					{
						num2 = 7;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 != 0)
						{
							num2 = 10;
						}
						continue;
					}
					goto case 31;
				case 22:
					Skip();
					num2 = 27;
					continue;
				case 10:
					testsInterpreter = currentToken.Start;
					goto IL_0494;
				case 18:
					{
						throw new StructInterpreter(in start, currentToken?.End ?? TestsInterpreter._InitializerInterpreter, DicSingleton.gE3WbyDVW(--650088194 ^ 0x26BF0480));
					}
					IL_0494:
					start = testsInterpreter;
					num2 = 18;
					continue;
				}
				break;
			}
		}
	}

	private ClientSingleton ParseBlockMappingValue()
	{
		int num = 19;
		SystemSingleton currentToken = default(SystemSingleton);
		ExpressionSingleton expressionSingleton = default(ExpressionSingleton);
		TestsInterpreter position = default(TestsInterpreter);
		ComposerSingleton composerSingleton = default(ComposerSingleton);
		TestsInterpreter start = default(TestsInterpreter);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				TestsInterpreter testsInterpreter;
				switch (num2)
				{
				case 20:
					if (currentToken is MapperSingleton)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9c47a25d924946efb9e023473a095794 != 0)
						{
							num2 = 22;
						}
						continue;
					}
					goto case 13;
				case 13:
					if (!(currentToken is ExpressionSingleton))
					{
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 == 0)
						{
							num2 = 14;
						}
						continue;
					}
					goto case 2;
				case 19:
					currentToken = GetCurrentToken();
					num2 = 18;
					continue;
				case 12:
					valInterpreter.Push((ImageKind)13);
					num2 = 21;
					continue;
				case 9:
					if (expressionSingleton == null)
					{
						num2 = 11;
						continue;
					}
					goto case 17;
				case 8:
					if (currentToken != null)
					{
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f == 0)
						{
							num2 = 4;
						}
						continue;
					}
					goto case 6;
				case 7:
					goto end_IL_0012;
				case 6:
					testsInterpreter = TestsInterpreter._InitializerInterpreter;
					break;
				case 14:
					if (currentToken is InterpreterSingleton)
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 != 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 12;
				case 16:
					currentToken = GetCurrentToken();
					num2 = 20;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec == 0)
					{
						num2 = 13;
					}
					continue;
				case 1:
					return ProcessEmptyScalar(in position);
				case 11:
					composerSingleton = currentToken as ComposerSingleton;
					num2 = 15;
					continue;
				case 3:
					throw new StructInterpreter(in start, composerSingleton.End, composerSingleton.Value);
				case 10:
					wrapperInterpreter = (ImageKind)13;
					num2 = 8;
					continue;
				case 18:
					expressionSingleton = currentToken as ExpressionSingleton;
					num2 = 9;
					continue;
				case 21:
					return ParseNode(isBlock: true, isIndentlessSequence: true);
				case 2:
				case 22:
					wrapperInterpreter = (ImageKind)13;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 == 0)
					{
						num2 = 0;
					}
					continue;
				case 17:
					position = expressionSingleton.End;
					num2 = 7;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 == 0)
					{
						num2 = 7;
					}
					continue;
				default:
					start = composerSingleton.Start;
					num2 = 3;
					continue;
				case 15:
					if (composerSingleton == null)
					{
						num2 = 10;
						continue;
					}
					goto default;
				case 5:
					return ProcessEmptyScalar(in start);
				case 4:
					testsInterpreter = currentToken.Start;
					break;
				}
				start = testsInterpreter;
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 == 0)
				{
					num2 = 5;
				}
				continue;
				end_IL_0012:
				break;
			}
			Skip();
			num = 16;
		}
	}

	private ClientSingleton ParseFlowSequenceEntry(bool isFirst)
	{
		int num = 9;
		SystemSingleton currentToken = default(SystemSingleton);
		TestsInterpreter start = default(TestsInterpreter);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				TestsInterpreter testsInterpreter;
				TestsInterpreter testsInterpreter2;
				switch (num2)
				{
				case 19:
					wrapperInterpreter = (ImageKind)17;
					num = 21;
					break;
				case 20:
					testsInterpreter = TestsInterpreter._InitializerInterpreter;
					goto IL_034e;
				case 14:
					return ParseNode(isBlock: false, isIndentlessSequence: false);
				case 5:
					wrapperInterpreter = valInterpreter.Pop();
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb != 0)
					{
						num2 = 3;
					}
					continue;
				case 16:
				case 18:
					if (currentToken != null)
					{
						num = 7;
						break;
					}
					goto case 15;
				case 6:
					if (currentToken == null)
					{
						num2 = 20;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 == 0)
						{
							num2 = 10;
						}
						continue;
					}
					testsInterpreter = currentToken.Start;
					goto IL_034e;
				case 22:
					if (!(currentToken is ItemSingleton))
					{
						num2 = 10;
						continue;
					}
					goto case 5;
				case 21:
				{
					FacadeSingleton result2 = new FacadeSingleton(VisitorAttribute._StubAttribute, RoleSingleton.publisherSingleton, isImplicit: true, (Level)2);
					Skip();
					return result2;
				}
				case 1:
					Skip();
					num2 = 11;
					continue;
				case 11:
					currentToken = GetCurrentToken();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e != 0)
					{
						num2 = 3;
					}
					continue;
				case 4:
					currentToken = GetCurrentToken();
					num2 = 22;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 == 0)
					{
						num2 = 13;
					}
					continue;
				case 9:
					if (isFirst)
					{
						num2 = 7;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba == 0)
						{
							num2 = 8;
						}
						continue;
					}
					goto case 4;
				case 8:
					GetCurrentToken();
					num2 = 23;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 != 0)
					{
						num2 = 5;
					}
					continue;
				case 23:
					Skip();
					num2 = 4;
					continue;
				case 17:
					if (!(currentToken is MapSingleton))
					{
						num2 = 18;
						continue;
					}
					goto case 1;
				case 10:
					if (isFirst)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 17;
				case 2:
					valInterpreter.Push((ImageKind)16);
					num2 = 14;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf == 0)
					{
						num2 = 12;
					}
					continue;
				case 15:
					testsInterpreter2 = TestsInterpreter._InitializerInterpreter;
					goto IL_02e6;
				case 7:
					testsInterpreter2 = currentToken.Start;
					goto IL_02e6;
				case 12:
					throw new StructInterpreter(in start, currentToken?.End ?? TestsInterpreter._InitializerInterpreter, DicSingleton.gE3WbyDVW(0x7B291245 ^ 0x7B2999BD));
				default:
					if (!(currentToken is MapperSingleton))
					{
						if (currentToken is ItemSingleton)
						{
							num2 = 5;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 != 0)
							{
								num2 = 5;
							}
							continue;
						}
						goto case 2;
					}
					num2 = 19;
					continue;
				case 13:
					{
						MessageSingleton result = new MessageSingleton(in start, currentToken?.End ?? TestsInterpreter._InitializerInterpreter);
						Skip();
						return result;
					}
					IL_034e:
					start = testsInterpreter;
					num = 13;
					break;
					IL_02e6:
					start = testsInterpreter2;
					num2 = 12;
					continue;
				}
				break;
			}
		}
	}

	private ClientSingleton ParseFlowSequenceEntryMappingKey()
	{
		int num = 9;
		SystemSingleton currentToken = default(SystemSingleton);
		TestsInterpreter position = default(TestsInterpreter);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				TestsInterpreter testsInterpreter;
				switch (num2)
				{
				case 11:
					if (!(currentToken is ItemSingleton))
					{
						num = 4;
						break;
					}
					goto default;
				case 10:
					return ParseNode(isBlock: false, isIndentlessSequence: false);
				default:
					if (currentToken != null)
					{
						num2 = 7;
						continue;
					}
					goto case 3;
				case 8:
					if (currentToken is ExpressionSingleton)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 5;
				case 5:
					if (!(currentToken is MapSingleton))
					{
						num2 = 10;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb != 0)
						{
							num2 = 11;
						}
						continue;
					}
					goto default;
				case 1:
					wrapperInterpreter = (ImageKind)18;
					num2 = 6;
					continue;
				case 9:
					currentToken = GetCurrentToken();
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 == 0)
					{
						num2 = 2;
					}
					continue;
				case 3:
					testsInterpreter = TestsInterpreter._InitializerInterpreter;
					goto IL_017b;
				case 6:
					return ProcessEmptyScalar(in position);
				case 4:
					valInterpreter.Push((ImageKind)18);
					num = 10;
					break;
				case 2:
					Skip();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a != 0)
					{
						num2 = 1;
					}
					continue;
				case 7:
					{
						testsInterpreter = currentToken.End;
						goto IL_017b;
					}
					IL_017b:
					position = testsInterpreter;
					num = 2;
					break;
				}
				break;
			}
		}
	}

	private ClientSingleton ParseFlowSequenceEntryMappingValue()
	{
		int num = 6;
		SystemSingleton currentToken = default(SystemSingleton);
		TestsInterpreter position = default(TestsInterpreter);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				TestsInterpreter testsInterpreter;
				switch (num2)
				{
				case 8:
					if (currentToken == null)
					{
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 != 0)
						{
							num2 = 0;
						}
						continue;
					}
					testsInterpreter = currentToken.Start;
					break;
				case 9:
					if (!(currentToken is MapSingleton))
					{
						num2 = 11;
						continue;
					}
					goto case 2;
				case 5:
					if (!(currentToken is ExpressionSingleton))
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 == 0)
						{
							num2 = 2;
						}
						continue;
					}
					goto case 1;
				case 11:
					if (!(currentToken is ItemSingleton))
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f != 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 2;
				default:
					valInterpreter.Push((ImageKind)19);
					num2 = 7;
					continue;
				case 6:
					goto end_IL_0012;
				case 10:
					return ProcessEmptyScalar(in position);
				case 3:
					currentToken = GetCurrentToken();
					num2 = 9;
					continue;
				case 7:
					return ParseNode(isBlock: false, isIndentlessSequence: false);
				case 2:
					wrapperInterpreter = (ImageKind)19;
					num2 = 8;
					continue;
				case 4:
					testsInterpreter = TestsInterpreter._InitializerInterpreter;
					break;
				case 1:
					Skip();
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 == 0)
					{
						num2 = 0;
					}
					continue;
				}
				position = testsInterpreter;
				num2 = 10;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 != 0)
				{
					num2 = 10;
				}
				continue;
				end_IL_0012:
				break;
			}
			currentToken = GetCurrentToken();
			num = 5;
		}
	}

	private ClientSingleton ParseFlowSequenceEntryMappingEnd()
	{
		int num = 1;
		int num2 = num;
		SystemSingleton currentToken = default(SystemSingleton);
		TestsInterpreter start = default(TestsInterpreter);
		while (true)
		{
			TestsInterpreter testsInterpreter;
			switch (num2)
			{
			case 1:
				wrapperInterpreter = (ImageKind)16;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 == 0)
				{
					num2 = 0;
				}
				break;
			case 5:
				if (currentToken != null)
				{
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
					{
						num2 = 1;
					}
					break;
				}
				goto case 3;
			case 3:
				testsInterpreter = TestsInterpreter._InitializerInterpreter;
				goto IL_00be;
			default:
				currentToken = GetCurrentToken();
				num2 = 5;
				break;
			case 2:
				testsInterpreter = currentToken.Start;
				goto IL_00be;
			case 4:
				{
					return new ParamSingleton(in start, currentToken?.End ?? TestsInterpreter._InitializerInterpreter);
				}
				IL_00be:
				start = testsInterpreter;
				num2 = 4;
				break;
			}
		}
	}

	private ClientSingleton ParseFlowMappingKey(bool isFirst)
	{
		int num = 24;
		SystemSingleton currentToken = default(SystemSingleton);
		TestsInterpreter start = default(TestsInterpreter);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				TestsInterpreter testsInterpreter3;
				TestsInterpreter testsInterpreter2;
				TestsInterpreter testsInterpreter;
				switch (num2)
				{
				case 23:
					GetCurrentToken();
					num2 = 18;
					break;
				case 37:
					currentToken = GetCurrentToken();
					num2 = 34;
					break;
				case 22:
					currentToken = GetCurrentToken();
					num2 = 11;
					break;
				case 33:
					return ProcessEmptyScalar(in start);
				case 7:
					if (currentToken != null)
					{
						num2 = 29;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 == 0)
						{
							num2 = 19;
						}
						break;
					}
					goto case 32;
				default:
					return ParseNode(isBlock: false, isIndentlessSequence: false);
				case 16:
					if (!(currentToken is HelperSingleton))
					{
						num2 = 17;
						break;
					}
					goto case 30;
				case 4:
					if (currentToken != null)
					{
						num2 = 12;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd != 0)
						{
							num2 = 8;
						}
						break;
					}
					goto case 20;
				case 38:
					currentToken = GetCurrentToken();
					num2 = 8;
					break;
				case 18:
					Skip();
					num2 = 22;
					break;
				case 28:
					if (!(currentToken is HelperSingleton))
					{
						num2 = 13;
						break;
					}
					goto case 10;
				case 34:
					if (currentToken is ExpressionSingleton)
					{
						goto end_IL_0012;
					}
					goto case 6;
				case 26:
					return ParseNode(isBlock: false, isIndentlessSequence: false);
				case 10:
				case 31:
					wrapperInterpreter = (ImageKind)22;
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 == 0)
					{
						num2 = 1;
					}
					break;
				case 36:
					valInterpreter.Push((ImageKind)22);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec == 0)
					{
						num2 = 0;
					}
					break;
				case 2:
					Skip();
					num2 = 38;
					break;
				case 27:
					if (!(currentToken is IdentifierSingleton))
					{
						num2 = 7;
						break;
					}
					goto case 8;
				case 32:
					testsInterpreter3 = TestsInterpreter._InitializerInterpreter;
					goto IL_047e;
				case 24:
					if (isFirst)
					{
						num2 = 23;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 == 0)
						{
							num2 = 13;
						}
						break;
					}
					goto case 22;
				case 20:
					testsInterpreter2 = TestsInterpreter._InitializerInterpreter;
					goto IL_04f1;
				case 25:
					if (isFirst)
					{
						num2 = 19;
						break;
					}
					goto case 39;
				case 13:
					valInterpreter.Push((ImageKind)22);
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 == 0)
					{
						num2 = 26;
					}
					break;
				case 11:
					if (currentToken is HelperSingleton)
					{
						num2 = 30;
						break;
					}
					goto case 25;
				case 6:
					if (currentToken is MapSingleton)
					{
						num2 = 10;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3a460cd74a4c809e0f755964f2077b != 0)
						{
							num2 = 5;
						}
						break;
					}
					goto case 28;
				case 39:
					if (currentToken is MapSingleton)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add == 0)
						{
							num2 = 2;
						}
						break;
					}
					goto case 27;
				case 14:
					testsInterpreter = TestsInterpreter._InitializerInterpreter;
					goto IL_0514;
				case 3:
					if (currentToken != null)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 != 0)
						{
							num2 = 0;
						}
						break;
					}
					goto case 14;
				case 15:
					Skip();
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 != 0)
					{
						num2 = 37;
					}
					break;
				case 21:
					Skip();
					num2 = 3;
					break;
				case 17:
					valInterpreter.Push((ImageKind)23);
					num2 = 9;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
					{
						num2 = 0;
					}
					break;
				case 9:
					return ParseNode(isBlock: false, isIndentlessSequence: false);
				case 30:
					wrapperInterpreter = valInterpreter.Pop();
					num2 = 21;
					break;
				case 29:
					testsInterpreter3 = currentToken.Start;
					goto IL_047e;
				case 35:
					throw new StructInterpreter(in start, currentToken?.End ?? TestsInterpreter._InitializerInterpreter, DicSingleton.gE3WbyDVW(-447849421 ^ -447819697));
				case 8:
				case 19:
					if (!(currentToken is MapperSingleton))
					{
						if (!(currentToken is IdentifierSingleton))
						{
							num2 = 16;
							break;
						}
						goto case 36;
					}
					num2 = 15;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ea4c8b68ad954c0fb4df33d6e06bd4a3 != 0)
					{
						num2 = 3;
					}
					break;
				case 12:
					testsInterpreter2 = currentToken.Start;
					goto IL_04f1;
				case 1:
					testsInterpreter = currentToken.Start;
					goto IL_0514;
				case 5:
					{
						return new ParamSingleton(in start, currentToken?.End ?? TestsInterpreter._InitializerInterpreter);
					}
					IL_0514:
					start = testsInterpreter;
					num2 = 5;
					break;
					IL_047e:
					start = testsInterpreter3;
					num2 = 35;
					break;
					IL_04f1:
					start = testsInterpreter2;
					num2 = 28;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea != 0)
					{
						num2 = 33;
					}
					break;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 31;
		}
	}

	private ClientSingleton ParseFlowMappingValue(bool isEmpty)
	{
		int num = 5;
		SystemSingleton currentToken = default(SystemSingleton);
		IdentifierSingleton identifierSingleton = default(IdentifierSingleton);
		TestsInterpreter position = default(TestsInterpreter);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				TestsInterpreter testsInterpreter;
				switch (num2)
				{
				case 5:
					currentToken = GetCurrentToken();
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_35cf05af90cc4195a86c9ffc19bf78eb != 0)
					{
						num2 = 4;
					}
					continue;
				case 13:
					if (isEmpty)
					{
						num2 = 15;
						continue;
					}
					goto case 11;
				case 4:
					if (!isEmpty)
					{
						num2 = 10;
						continue;
					}
					goto default;
				case 8:
					if (currentToken is HelperSingleton)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add != 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 1;
				case 14:
					Skip();
					num = 3;
					break;
				case 1:
					valInterpreter.Push((ImageKind)21);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 != 0)
					{
						num2 = 6;
					}
					continue;
				case 19:
					if (currentToken is MapSingleton)
					{
						num2 = 6;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 != 0)
						{
							num2 = 20;
						}
						continue;
					}
					goto case 8;
				case 11:
					identifierSingleton = currentToken as IdentifierSingleton;
					num2 = 17;
					continue;
				case 9:
					return new BridgeSingleton(VisitorAttribute._StubAttribute, RoleSingleton.publisherSingleton, identifierSingleton.Value, identifierSingleton.Style, isPlainImplicit: false, isQuotedImplicit: false, currentToken.Start, identifierSingleton.End);
				case 15:
				case 18:
					if (currentToken != null)
					{
						num2 = 2;
						continue;
					}
					goto case 7;
				case 17:
					if (identifierSingleton == null)
					{
						num = 18;
						break;
					}
					goto case 16;
				case 10:
					if (currentToken is ExpressionSingleton)
					{
						num2 = 14;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 != 0)
						{
							num2 = 12;
						}
						continue;
					}
					goto default;
				case 12:
					return ProcessEmptyScalar(in position);
				case 16:
					Skip();
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 != 0)
					{
						num2 = 9;
					}
					continue;
				case 3:
					currentToken = GetCurrentToken();
					num2 = 19;
					continue;
				case 6:
					return ParseNode(isBlock: false, isIndentlessSequence: false);
				default:
					wrapperInterpreter = (ImageKind)21;
					num2 = 13;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 == 0)
					{
						num2 = 10;
					}
					continue;
				case 7:
					testsInterpreter = TestsInterpreter._InitializerInterpreter;
					goto IL_029d;
				case 2:
					{
						testsInterpreter = currentToken.Start;
						goto IL_029d;
					}
					IL_029d:
					position = testsInterpreter;
					num2 = 12;
					continue;
				}
				break;
			}
		}
	}

	internal static bool RunProducer()
	{
		return TestProducer == null;
	}

	internal static ExporterInterpreter VerifyProducer()
	{
		return TestProducer;
	}
}
