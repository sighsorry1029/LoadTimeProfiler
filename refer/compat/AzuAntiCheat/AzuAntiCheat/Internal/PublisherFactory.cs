using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal class PublisherFactory : StubReader
{
	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
	private class InvocationFactory
	{
		private readonly Queue<MappingFactory> m_AuthenticationFactory;

		private readonly Queue<MappingFactory> m_AttributeFactory;

		private static InvocationFactory PushError;

		public int Count => m_AuthenticationFactory.Count + m_AttributeFactory.Count;

		public void Enqueue(MappingFactory @event)
		{
			int num = 5;
			int num2 = num;
			SchemaCompareFilterSetting type = default(SchemaCompareFilterSetting);
			while (true)
			{
				switch (num2)
				{
				case 1:
					if (type == (SchemaCompareFilterSetting)3)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_49107028423047bfbf9c33e5a2ab8cf8 != 0)
						{
							num2 = 0;
						}
					}
					else
					{
						m_AttributeFactory.Enqueue(@event);
						num2 = 2;
					}
					break;
				case 5:
					type = @event.Type;
					num2 = 4;
					break;
				default:
					m_AuthenticationFactory.Enqueue(@event);
					num2 = 3;
					break;
				case 4:
					if (type != (SchemaCompareFilterSetting)1)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_35cf05af90cc4195a86c9ffc19bf78eb != 0)
						{
							num2 = 1;
						}
						break;
					}
					goto default;
				case 3:
					return;
				case 2:
					return;
				}
			}
		}

		public MappingFactory Dequeue()
		{
			int num = 2;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 2:
					if (m_AuthenticationFactory.Count > 0)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 != 0)
						{
							num2 = 1;
						}
						break;
					}
					goto default;
				default:
					return m_AttributeFactory.Dequeue();
				case 1:
					return m_AuthenticationFactory.Dequeue();
				}
			}
		}

		public InvocationFactory()
		{
			GetterIssuer.DeleteInitializer();
			m_AuthenticationFactory = new Queue<MappingFactory>();
			m_AttributeFactory = new Queue<MappingFactory>();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal static bool ValidateError()
		{
			return PushError == null;
		}

		internal static InvocationFactory EnableError()
		{
			return PushError;
		}
	}

	private readonly Stack<XmlBinaryNodeType> m_BaseFactory;

	private readonly StateFactory _PrototypeFactory;

	private XmlBinaryNodeType _InterceptorFactory;

	private readonly PolicyReader _FilterFactory;

	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	private ModelFactory _ReaderFactory;

	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	private ProcessFactory factoryFactory;

	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	[CompilerGenerated]
	private MappingFactory setterFactory;

	private readonly InvocationFactory m_WriterFactory;

	private static PublisherFactory LogoutError;

	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	public MappingFactory Current
	{
		[CompilerGenerated]
		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
		get
		{
			return setterFactory;
		}
		[CompilerGenerated]
		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
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
					setterFactory = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 != 0)
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

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
	private ModelFactory GetCurrentToken()
	{
		int num = 2;
		IteratorFactory iteratorFactory = default(IteratorFactory);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 8:
				case 11:
					_ReaderFactory = _FilterFactory.Current;
					num2 = 3;
					continue;
				default:
					if (iteratorFactory == null)
					{
						num2 = 9;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 != 0)
						{
							num2 = 2;
						}
						continue;
					}
					goto end_IL_0012;
				case 3:
					iteratorFactory = _ReaderFactory as IteratorFactory;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 == 0)
					{
						num2 = 0;
					}
					continue;
				case 2:
					if (_ReaderFactory != null)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 == 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 7;
				case 5:
					_FilterFactory.ConsumeCurrent();
					num2 = 10;
					continue;
				case 7:
				case 10:
					if (_FilterFactory.MoveNextWithoutConsuming())
					{
						num2 = 8;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba != 0)
						{
							num2 = 4;
						}
						continue;
					}
					break;
				case 4:
					goto end_IL_0012;
				case 1:
				case 6:
				case 9:
					break;
				}
				return _ReaderFactory;
				continue;
				end_IL_0012:
				break;
			}
			m_WriterFactory.Enqueue(new StubFactory(iteratorFactory.Value, iteratorFactory.IsInline, iteratorFactory.Start, iteratorFactory.End));
			num = 5;
		}
	}

	public PublisherFactory(TextReader input)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(new SerializerFactory(input));
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public PublisherFactory(PolicyReader scanner)
	{
		GetterIssuer.DeleteInitializer();
		m_BaseFactory = new Stack<XmlBinaryNodeType>();
		_PrototypeFactory = new StateFactory();
		m_WriterFactory = new InvocationFactory();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 != 0)
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
				_FilterFactory = scanner;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 != 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public bool MoveNext()
	{
		int num = 5;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 6:
				return false;
			default:
				Current = m_WriterFactory.Dequeue();
				num2 = 3;
				break;
			case 3:
				return true;
			case 4:
				Current = null;
				num2 = 6;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_35cf05af90cc4195a86c9ffc19bf78eb == 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				m_WriterFactory.Enqueue(StateMachine());
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e != 0)
				{
					num2 = 0;
				}
				break;
			case 5:
				if (_InterceptorFactory != (XmlBinaryNodeType)1)
				{
					if (m_WriterFactory.Count != 0)
					{
						num2 = 2;
						break;
					}
					goto case 1;
				}
				num2 = 4;
				break;
			}
		}
	}

	private MappingFactory StateMachine()
	{
		int num = 2;
		int num2 = num;
		XmlBinaryNodeType interceptorFactory = default(XmlBinaryNodeType);
		while (true)
		{
			switch (num2)
			{
			case 2:
				interceptorFactory = _InterceptorFactory;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 != 0)
				{
					num2 = 1;
				}
				break;
			case 3:
				return ParseStreamStart();
			default:
				goto IL_0101;
			case 1:
				{
					switch (interceptorFactory)
					{
					case (XmlBinaryNodeType)0:
						break;
					case (XmlBinaryNodeType)2:
						return ParseDocumentStart(isImplicit: true);
					case (XmlBinaryNodeType)3:
						return ParseDocumentStart(isImplicit: false);
					case (XmlBinaryNodeType)4:
						return ParseDocumentContent();
					case (XmlBinaryNodeType)5:
						return ParseDocumentEnd();
					case (XmlBinaryNodeType)6:
						return ParseNode(isBlock: true, isIndentlessSequence: false);
					case (XmlBinaryNodeType)7:
						return ParseNode(isBlock: true, isIndentlessSequence: true);
					case (XmlBinaryNodeType)8:
						return ParseNode(isBlock: false, isIndentlessSequence: false);
					case (XmlBinaryNodeType)9:
						return ParseBlockSequenceEntry(isFirst: true);
					case (XmlBinaryNodeType)10:
						return ParseBlockSequenceEntry(isFirst: false);
					case (XmlBinaryNodeType)11:
						return ParseIndentlessSequenceEntry();
					case (XmlBinaryNodeType)12:
						return ParseBlockMappingKey(isFirst: true);
					case (XmlBinaryNodeType)13:
						return ParseBlockMappingKey(isFirst: false);
					case (XmlBinaryNodeType)14:
						return ParseBlockMappingValue();
					case (XmlBinaryNodeType)15:
						return ParseFlowSequenceEntry(isFirst: true);
					case (XmlBinaryNodeType)16:
						return ParseFlowSequenceEntry(isFirst: false);
					case (XmlBinaryNodeType)17:
						return ParseFlowSequenceEntryMappingKey();
					case (XmlBinaryNodeType)18:
						return ParseFlowSequenceEntryMappingValue();
					case (XmlBinaryNodeType)19:
						return ParseFlowSequenceEntryMappingEnd();
					case (XmlBinaryNodeType)20:
						return ParseFlowMappingKey(isFirst: true);
					case (XmlBinaryNodeType)21:
						return ParseFlowMappingKey(isFirst: false);
					case (XmlBinaryNodeType)22:
						return ParseFlowMappingValue(isEmpty: false);
					case (XmlBinaryNodeType)23:
						return ParseFlowMappingValue(isEmpty: true);
					case (XmlBinaryNodeType)1:
						goto IL_0101;
					default:
						goto IL_016e;
					}
					goto case 3;
				}
				IL_016e:
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb == 0)
				{
					num2 = 0;
				}
				break;
				IL_0101:
				throw new InvalidOperationException();
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
			default:
				return;
			case 1:
				if (_ReaderFactory == null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 4;
			case 4:
				_ReaderFactory = null;
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 != 0)
				{
					num2 = 2;
				}
				break;
			case 2:
				_FilterFactory.ConsumeCurrent();
				num2 = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			case 3:
				return;
			}
		}
	}

	private MappingFactory ParseStreamStart()
	{
		int num = 1;
		int num2 = num;
		ImporterFactory importerFactory = default(ImporterFactory);
		ModelFactory currentToken = default(ModelFactory);
		object obj;
		while (true)
		{
			switch (num2)
			{
			case 8:
				if (importerFactory == null)
				{
					num2 = 6;
					continue;
				}
				Skip();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba == 0)
				{
					num2 = 2;
				}
				continue;
			case 5:
				return new PublisherSetter(importerFactory.Start, importerFactory.End);
			case 2:
				_InterceptorFactory = (XmlBinaryNodeType)2;
				num2 = 5;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 == 0)
				{
					num2 = 0;
				}
				continue;
			case 6:
				if (currentToken != null)
				{
					num2 = 7;
					continue;
				}
				goto case 3;
			case 1:
				currentToken = GetCurrentToken();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 != 0)
				{
					num2 = 0;
				}
				continue;
			default:
				importerFactory = currentToken as ImporterFactory;
				num2 = 8;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 == 0)
				{
					num2 = 7;
				}
				continue;
			case 3:
				obj = null;
				goto IL_00fd;
			case 7:
				obj = currentToken.Start;
				goto IL_00fd;
			case 4:
				{
					obj = QueueReader.m_CollectionReader;
					break;
				}
				IL_00fd:
				if (obj == null)
				{
					num2 = 4;
					continue;
				}
				break;
			}
			break;
		}
		throw new TemplateFactory((QueueReader)obj, currentToken?.End ?? QueueReader.m_CollectionReader, DicSingleton.gE3WbyDVW(--650088194 ^ 0x26BF0B16));
	}

	private MappingFactory ParseDocumentStart(bool isImplicit)
	{
		int num = 20;
		int num2 = num;
		StateFactory tags = default(StateFactory);
		QueueReader start = default(QueueReader);
		StateFactory tags2 = default(StateFactory);
		ModelFactory modelFactory = default(ModelFactory);
		while (true)
		{
			switch (num2)
			{
			case 33:
				_InterceptorFactory = (XmlBinaryNodeType)1;
				num2 = 34;
				break;
			case 38:
				if (_InterceptorFactory == (XmlBinaryNodeType)3)
				{
					num2 = 7;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 != 0)
					{
						num2 = 1;
					}
					break;
				}
				goto case 13;
			case 7:
				isImplicit = true;
				num2 = 32;
				break;
			case 3:
				if (modelFactory is ProcessFactory)
				{
					num2 = 13;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d != 0)
					{
						num2 = 22;
					}
					break;
				}
				goto case 26;
			case 20:
				if (_ReaderFactory is ProcessFactory)
				{
					num2 = 19;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 == 0)
					{
						num2 = 2;
					}
				}
				else
				{
					modelFactory = GetCurrentToken();
					num2 = 6;
				}
				break;
			case 29:
				Skip();
				num2 = 23;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 == 0)
				{
					num2 = 17;
				}
				break;
			case 18:
				if (_InterceptorFactory != (XmlBinaryNodeType)2)
				{
					num2 = 38;
					break;
				}
				goto case 7;
			case 10:
			case 22:
			case 35:
				if (modelFactory is OrderFactory)
				{
					num2 = 11;
					break;
				}
				if (!(modelFactory is AlgoFactory))
				{
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 != 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 21;
			case 27:
				if (!(modelFactory is ServiceFactory))
				{
					num2 = 12;
					break;
				}
				goto case 10;
			case 8:
				throw new RegistryFactory(DicSingleton.gE3WbyDVW(-65056140 ^ -65022116));
			case 30:
				if (!(modelFactory is ConfigFactory))
				{
					num2 = 13;
					break;
				}
				goto case 18;
			case 23:
				modelFactory = GetCurrentToken();
				num2 = 28;
				break;
			case 14:
				m_BaseFactory.Push((XmlBinaryNodeType)5);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 == 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				_InterceptorFactory = (XmlBinaryNodeType)6;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf != 0)
				{
					num2 = 5;
				}
				break;
			case 31:
				tags = new StateFactory();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d == 0)
				{
					num2 = 0;
				}
				break;
			case 25:
				start = modelFactory.Start;
				num2 = 31;
				break;
			case 11:
			case 12:
				tags2 = new StateFactory();
				num2 = 9;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 != 0)
				{
					num2 = 9;
				}
				break;
			case 13:
			case 32:
				if (isImplicit)
				{
					num2 = 3;
					break;
				}
				goto case 10;
			case 37:
				if (!(modelFactory is AlgoFactory))
				{
					num2 = 27;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_35cf05af90cc4195a86c9ffc19bf78eb == 0)
					{
						num2 = 1;
					}
					break;
				}
				goto case 10;
			case 19:
				throw new RegistryFactory(DicSingleton.gE3WbyDVW(-823738529 ^ -823772355));
			case 2:
				Skip();
				num2 = 33;
				break;
			case 17:
				if (modelFactory != null)
				{
					num2 = 30;
					break;
				}
				goto case 8;
			case 6:
				if (!isImplicit)
				{
					num2 = 36;
					break;
				}
				goto case 17;
			case 26:
				if (modelFactory is ErrorFactory)
				{
					num2 = 35;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4e61b266153f422fa6c595cfef4d40d3 != 0)
					{
						num2 = 29;
					}
					break;
				}
				goto case 15;
			case 4:
				if (modelFactory is ServiceFactory)
				{
					num2 = 21;
					break;
				}
				goto case 25;
			case 9:
				ProcessDirectives(tags2);
				num2 = 14;
				break;
			case 5:
				return new DicFactory(null, tags2, isImplicit: true, modelFactory.Start, modelFactory.End);
			case 28:
			case 36:
				if (!(modelFactory is ServiceFactory))
				{
					num2 = 17;
					break;
				}
				goto case 29;
			case 15:
				if (!(modelFactory is BridgeFactory))
				{
					num2 = 37;
					break;
				}
				goto case 10;
			default:
			{
				ProcessFactory version = ProcessDirectives(tags);
				modelFactory = GetCurrentToken() ?? throw new TemplateFactory(DicSingleton.gE3WbyDVW(-1053593978 ^ -1053562080));
				if (!(modelFactory is BridgeFactory))
				{
					throw new TemplateFactory(modelFactory.Start, modelFactory.End, DicSingleton.gE3WbyDVW(0x33F6A245 ^ 0x33F62467));
				}
				m_BaseFactory.Push((XmlBinaryNodeType)5);
				_InterceptorFactory = (XmlBinaryNodeType)4;
				QueueReader end = modelFactory.End;
				Skip();
				return new DicFactory(version, tags, isImplicit: false, start, end);
			}
			case 21:
				if (modelFactory is ServiceFactory)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ea4c8b68ad954c0fb4df33d6e06bd4a3 == 0)
					{
						num2 = 2;
					}
					break;
				}
				goto case 33;
			case 34:
			{
				ModelFactory currentToken = GetCurrentToken();
				if (currentToken == null)
				{
					num2 = 16;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 == 0)
					{
						num2 = 1;
					}
				}
				else
				{
					modelFactory = currentToken;
					num2 = 24;
				}
				break;
			}
			case 16:
				throw new TemplateFactory(DicSingleton.gE3WbyDVW(-1931860206 ^ -1931828556));
			case 24:
			{
				RoleSetter result = new RoleSetter(modelFactory.Start, modelFactory.End);
				if (_FilterFactory.MoveNextWithoutConsuming())
				{
					throw new InvalidOperationException(DicSingleton.gE3WbyDVW(0x5A1B57A3 ^ 0x5A1BD1D7));
				}
				return result;
			}
			}
		}
	}

	[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	private ProcessFactory ProcessDirectives(StateFactory tags)
	{
		int num = 2;
		ProcessFactory processFactory = default(ProcessFactory);
		ErrorFactory errorFactory = default(ErrorFactory);
		ProcessFactory processFactory2 = default(ProcessFactory);
		bool flag = default(bool);
		ProcessFactory result = default(ProcessFactory);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 9:
				case 23:
					processFactory = GetCurrentToken() as ProcessFactory;
					num2 = 37;
					continue;
				case 8:
				case 16:
					errorFactory = GetCurrentToken() as ErrorFactory;
					num2 = 40;
					continue;
				case 29:
					throw new TemplateFactory(processFactory.Start, processFactory.End, DicSingleton.gE3WbyDVW(-293474990 ^ -293508542));
				case 21:
					processFactory2 = (factoryFactory = processFactory);
					num2 = 26;
					continue;
				case 32:
					throw new TemplateFactory(processFactory.Start, processFactory.End, DicSingleton.gE3WbyDVW(0x540450D2 ^ 0x5404D61E));
				case 6:
					if (processFactory.Version.Major == 1)
					{
						num2 = 22;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 == 0)
						{
							num2 = 24;
						}
						continue;
					}
					goto case 29;
				case 34:
					_PrototypeFactory.Clear();
					num2 = 31;
					continue;
				case 3:
				case 17:
				case 19:
				case 20:
					AddTagDirectives(tags, CallbackReader.rulesReader);
					num2 = 27;
					continue;
				case 35:
					flag = true;
					num2 = 25;
					continue;
				case 14:
					flag = true;
					num = 33;
					break;
				case 1:
					result = null;
					num2 = 23;
					continue;
				case 5:
					if (!tags.Contains(errorFactory.Handle))
					{
						num2 = 6;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec == 0)
						{
							num2 = 15;
						}
						continue;
					}
					goto case 30;
				default:
					if (!(GetCurrentToken() is BridgeFactory))
					{
						num2 = 7;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3aab303a2946368dda3deef055dc93 == 0)
						{
							num2 = 10;
						}
						continue;
					}
					goto case 22;
				case 12:
					if (factoryFactory.Version.Major == 1)
					{
						num2 = 28;
						continue;
					}
					goto case 3;
				case 28:
					if (factoryFactory.Version.Minor <= 1)
					{
						num2 = 19;
						continue;
					}
					goto default;
				case 36:
					if (factoryFactory == null)
					{
						num2 = 6;
						continue;
					}
					goto case 32;
				case 11:
					factoryFactory = new ProcessFactory(new WorkerFactory(1, 2));
					num2 = 4;
					continue;
				case 37:
					if (processFactory == null)
					{
						num2 = 8;
						continue;
					}
					goto case 36;
				case 22:
					if (factoryFactory != null)
					{
						num2 = 13;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 != 0)
						{
							num2 = 11;
						}
						continue;
					}
					goto case 11;
				case 2:
					flag = false;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e != 0)
					{
						num2 = 1;
					}
					continue;
				case 25:
				case 33:
				case 41:
					Skip();
					num2 = 9;
					continue;
				case 18:
					if (factoryFactory == null)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 12;
				case 27:
					if (flag)
					{
						num2 = 34;
						continue;
					}
					goto case 31;
				case 38:
					return result;
				case 26:
					result = processFactory2;
					num = 35;
					break;
				case 24:
					if (processFactory.Version.Minor <= 3)
					{
						num2 = 21;
						continue;
					}
					goto case 29;
				case 39:
					if (!(GetCurrentToken() is BridgeFactory))
					{
						num2 = 3;
						continue;
					}
					goto case 18;
				case 30:
					throw new TemplateFactory(errorFactory.Start, errorFactory.End, DicSingleton.gE3WbyDVW(-65056140 ^ -65022686));
				case 15:
					tags.Add(errorFactory);
					num2 = 14;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e == 0)
					{
						num2 = 8;
					}
					continue;
				case 40:
					if (errorFactory != null)
					{
						num2 = 5;
						continue;
					}
					goto case 39;
				case 31:
					AddTagDirectives(_PrototypeFactory, tags);
					num2 = 38;
					continue;
				case 4:
				case 10:
				case 13:
					flag = true;
					num2 = 20;
					continue;
				}
				break;
			}
		}
	}

	private static void AddTagDirectives(StateFactory directives, IEnumerable<ErrorFactory> source)
	{
		foreach (ErrorFactory item in source)
		{
			if (!directives.Contains(item))
			{
				directives.Add(item);
			}
		}
	}

	private MappingFactory ParseDocumentContent()
	{
		int num = 7;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 3:
				if (!(GetCurrentToken() is ErrorFactory))
				{
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 != 0)
					{
						num2 = 1;
					}
					break;
				}
				goto case 2;
			case 5:
				if (!(GetCurrentToken() is BridgeFactory))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_49107028423047bfbf9c33e5a2ab8cf8 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 2;
			case 1:
				if (!(GetCurrentToken() is AlgoFactory))
				{
					num2 = 9;
					break;
				}
				goto case 2;
			case 2:
			case 4:
			case 6:
				_InterceptorFactory = m_BaseFactory.Pop();
				num2 = 8;
				break;
			case 7:
				if (GetCurrentToken() is ProcessFactory)
				{
					num2 = 6;
					break;
				}
				goto case 3;
			case 8:
				return ProcessEmptyScalar(_FilterFactory.CurrentPosition);
			case 9:
				return ParseNode(isBlock: true, isIndentlessSequence: false);
			default:
				if (GetCurrentToken() is ServiceFactory)
				{
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 != 0)
					{
						num2 = 2;
					}
					break;
				}
				goto case 1;
			}
		}
	}

	private static MappingFactory ProcessEmptyScalar(QueueReader position)
	{
		return new ClassFactory(HelperReader._ExceptionReader, ValueFactory._DecoratorFactory, string.Empty, (RuleFactory)1, isPlainImplicit: true, isQuotedImplicit: false, position, position);
	}

	private MappingFactory ParseNode(bool isBlock, bool isIndentlessSequence)
	{
		int num = 67;
		ParserFactory parserFactory2 = default(ParserFactory);
		ModelFactory modelFactory = default(ModelFactory);
		ParserFactory parserFactory3 = default(ParserFactory);
		ParamFactory paramFactory = default(ParamFactory);
		HelperReader anchor = default(HelperReader);
		ValueFactory tag = default(ValueFactory);
		bool isEmpty = default(bool);
		QueueReader start = default(QueueReader);
		AttrFactory attrFactory = default(AttrFactory);
		ParserFactory parserFactory = default(ParserFactory);
		CreatorFactory creatorFactory2 = default(CreatorFactory);
		ContainerFactory containerFactory = default(ContainerFactory);
		OrderFactory orderFactory = default(OrderFactory);
		ConfigFactory configFactory = default(ConfigFactory);
		bool isPlainImplicit = default(bool);
		ParamFactory paramFactory2 = default(ParamFactory);
		ExporterFactory exporterFactory = default(ExporterFactory);
		ParameterFactory parameterFactory2 = default(ParameterFactory);
		CreatorFactory creatorFactory = default(CreatorFactory);
		bool isQuotedImplicit = default(bool);
		ParameterFactory parameterFactory = default(ParameterFactory);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 67:
					parameterFactory = GetCurrentToken() as ParameterFactory;
					num2 = 66;
					continue;
				case 34:
					parserFactory2 = modelFactory as ParserFactory;
					num2 = 14;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 == 0)
					{
						num2 = 9;
					}
					continue;
				case 58:
					throw new TemplateFactory(parserFactory3.Start, parserFactory3.End, DicSingleton.gE3WbyDVW(0x30B55457 ^ 0x30B5DC31));
				case 81:
					paramFactory = modelFactory as ParamFactory;
					num2 = 46;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba == 0)
					{
						num2 = 85;
					}
					continue;
				case 50:
					return new QueueFactory(anchor, tag, isEmpty, (TokenizerFactory)2, start, attrFactory.End);
				case 56:
					parserFactory = null;
					num2 = 35;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 != 0)
					{
						num2 = 24;
					}
					continue;
				case 90:
					if (!string.IsNullOrEmpty(creatorFactory2.Handle))
					{
						num = 10;
						break;
					}
					goto case 19;
				case 70:
					if (tag.IsNonSpecific)
					{
						num2 = 43;
						continue;
					}
					goto case 51;
				case 33:
					return new RefFactory(anchor, tag, isEmpty, (ProcFactory)1, start, containerFactory.End);
				case 68:
					if (containerFactory == null)
					{
						orderFactory = modelFactory as OrderFactory;
						num = 83;
						break;
					}
					num2 = 17;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 != 0)
					{
						num2 = 26;
					}
					continue;
				case 91:
					if (configFactory == null)
					{
						num2 = 21;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 != 0)
						{
							num2 = 3;
						}
						continue;
					}
					goto case 42;
				case 59:
					if (creatorFactory2 == null)
					{
						num2 = 5;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3a460cd74a4c809e0f755964f2077b == 0)
						{
							num2 = 6;
						}
						continue;
					}
					goto case 38;
				case 43:
					isPlainImplicit = true;
					num2 = 39;
					continue;
				case 84:
				{
					TagFactory result2 = new TagFactory(paramFactory2.Value, paramFactory2.Start, paramFactory2.End);
					Skip();
					return result2;
				}
				case 44:
					start = modelFactory.Start;
					num2 = 15;
					continue;
				case 87:
					_InterceptorFactory = (XmlBinaryNodeType)15;
					num2 = 2;
					continue;
				case 92:
					Skip();
					num2 = 32;
					continue;
				case 66:
				{
					if (parameterFactory != null)
					{
						num2 = 25;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 == 0)
						{
							num2 = 19;
						}
						continue;
					}
					ModelFactory currentToken2 = GetCurrentToken();
					if (currentToken2 == null)
					{
						num2 = 37;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 == 0)
						{
							num2 = 47;
						}
					}
					else
					{
						modelFactory = currentToken2;
						num2 = 28;
					}
					continue;
				}
				case 52:
					return new ClassFactory(anchor, tag, string.Empty, (RuleFactory)1, isEmpty, isQuotedImplicit: false, start, modelFactory.End);
				case 86:
					throw new TemplateFactory(modelFactory.Start, modelFactory.End, DicSingleton.gE3WbyDVW(-1338893851 ^ -1338863533));
				case 30:
					if (GetCurrentToken() is InstanceFactory)
					{
						num2 = 37;
						continue;
					}
					goto IL_098b;
				case 6:
				case 60:
					parserFactory3 = modelFactory as ParserFactory;
					num2 = 80;
					continue;
				case 36:
					if (anchor.IsEmpty)
					{
						num = 18;
						break;
					}
					goto case 24;
				case 13:
					if (attrFactory == null)
					{
						if (!isBlock)
						{
							num2 = 22;
							continue;
						}
						goto case 20;
					}
					num2 = 53;
					continue;
				case 77:
					parserFactory = parserFactory2;
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
					{
						num2 = 8;
					}
					continue;
				case 42:
					isPlainImplicit = false;
					num2 = 74;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb != 0)
					{
						num2 = 89;
					}
					continue;
				case 2:
					return new RefFactory(anchor, tag, isEmpty, (ProcFactory)2, start, exporterFactory.End);
				case 23:
					attrFactory = modelFactory as AttrFactory;
					num2 = 13;
					continue;
				case 15:
					anchor = HelperReader._ExceptionReader;
					num2 = 41;
					continue;
				case 3:
					_InterceptorFactory = (XmlBinaryNodeType)12;
					num2 = 40;
					continue;
				case 57:
					_InterceptorFactory = m_BaseFactory.Pop();
					num2 = 84;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 == 0)
					{
						num2 = 59;
					}
					continue;
				case 72:
					if (parameterFactory2 == null)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be != 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 75;
				case 40:
					return new QueueFactory(anchor, tag, isEmpty, (TokenizerFactory)1, start, orderFactory.End);
				case 22:
					if (!anchor.IsEmpty)
					{
						num2 = 64;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba != 0)
						{
							num2 = 6;
						}
						continue;
					}
					goto case 5;
				case 5:
					if (tag.IsEmpty)
					{
						num2 = 52;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea != 0)
						{
							num2 = 86;
						}
						continue;
					}
					goto case 4;
				case 45:
					if (isIndentlessSequence)
					{
						num = 30;
						break;
					}
					goto IL_098b;
				case 20:
					containerFactory = modelFactory as ContainerFactory;
					num2 = 53;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 == 0)
					{
						num2 = 68;
					}
					continue;
				case 7:
				case 27:
					if (anchor.IsEmpty)
					{
						num = 34;
						break;
					}
					goto case 29;
				case 9:
					if (!tag.IsEmpty)
					{
						num2 = 70;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 == 0)
						{
							num2 = 64;
						}
						continue;
					}
					goto case 43;
				case 80:
					if (parserFactory3 == null)
					{
						num2 = 81;
						continue;
					}
					goto case 58;
				case 53:
					_InterceptorFactory = (XmlBinaryNodeType)20;
					num2 = 50;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
					{
						num2 = 42;
					}
					continue;
				case 14:
					if (parserFactory2 == null)
					{
						num2 = 53;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb == 0)
						{
							num2 = 88;
						}
						continue;
					}
					goto case 77;
				case 85:
					if (paramFactory == null)
					{
						num2 = 69;
						continue;
					}
					goto case 73;
				case 35:
					creatorFactory = null;
					num2 = 7;
					continue;
				case 16:
					tag = new ValueFactory(_PrototypeFactory[creatorFactory2.Handle].Prefix + creatorFactory2.Suffix);
					num2 = 71;
					continue;
				case 29:
				case 88:
					if (tag.IsEmpty)
					{
						num2 = 76;
						continue;
					}
					goto case 6;
				case 26:
					_InterceptorFactory = (XmlBinaryNodeType)9;
					num2 = 33;
					continue;
				case 39:
				case 65:
				case 78:
					_InterceptorFactory = m_BaseFactory.Pop();
					num2 = 18;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa == 0)
					{
						num2 = 63;
					}
					continue;
				case 38:
					creatorFactory = creatorFactory2;
					num2 = 90;
					continue;
				case 37:
					_InterceptorFactory = (XmlBinaryNodeType)11;
					num2 = 55;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 == 0)
					{
						num2 = 44;
					}
					continue;
				case 41:
					tag = ValueFactory._DecoratorFactory;
					num2 = 56;
					continue;
				case 31:
					isQuotedImplicit = true;
					num2 = 65;
					continue;
				case 83:
					if (orderFactory != null)
					{
						num2 = 3;
						continue;
					}
					goto case 22;
				default:
					throw new TemplateFactory(creatorFactory2.Start, creatorFactory2.End, DicSingleton.gE3WbyDVW(0x3A437A88 ^ 0x3A43F288));
				case 17:
				case 71:
					Skip();
					num2 = 35;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 == 0)
					{
						num2 = 46;
					}
					continue;
				case 8:
					anchor = parserFactory2.Value;
					num2 = 92;
					continue;
				case 19:
					tag = new ValueFactory(creatorFactory2.Suffix);
					num2 = 17;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 == 0)
					{
						num2 = 0;
					}
					continue;
				case 1:
				case 74:
					isEmpty = tag.IsEmpty;
					num = 45;
					break;
				case 75:
					if (creatorFactory == null)
					{
						num2 = 79;
						continue;
					}
					goto case 82;
				case 76:
					creatorFactory2 = modelFactory as CreatorFactory;
					num2 = 17;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e != 0)
					{
						num2 = 59;
					}
					continue;
				case 55:
					return new RefFactory(anchor, tag, isEmpty, (ProcFactory)1, start, modelFactory.End);
				case 82:
					if (parserFactory != null)
					{
						num2 = 36;
						continue;
					}
					goto case 18;
				case 63:
					Skip();
					num2 = 61;
					continue;
				case 4:
				case 64:
					_InterceptorFactory = m_BaseFactory.Pop();
					num2 = 52;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 == 0)
					{
						num2 = 43;
					}
					continue;
				case 12:
					if (configFactory.Style == (RuleFactory)1)
					{
						num2 = 9;
						continue;
					}
					goto case 70;
				case 73:
					throw new TemplateFactory(paramFactory.Start, paramFactory.End, DicSingleton.gE3WbyDVW(-1614185587 ^ -1614154943));
				case 69:
					parameterFactory2 = modelFactory as ParameterFactory;
					num2 = 72;
					continue;
				case 10:
				case 62:
					if (!_PrototypeFactory.Contains(creatorFactory2.Handle))
					{
						num = 48;
						break;
					}
					goto case 16;
				case 28:
					paramFactory2 = modelFactory as ParamFactory;
					num2 = 54;
					continue;
				case 54:
					if (paramFactory2 == null)
					{
						num2 = 44;
						continue;
					}
					goto case 57;
				case 89:
					isQuotedImplicit = false;
					num2 = 12;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 == 0)
					{
						num2 = 0;
					}
					continue;
				case 51:
					if (!tag.IsEmpty)
					{
						num2 = 13;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac == 0)
						{
							num2 = 78;
						}
						continue;
					}
					goto case 31;
				case 11:
					if (exporterFactory == null)
					{
						num2 = 23;
						continue;
					}
					goto case 87;
				case 25:
					throw new TemplateFactory(parameterFactory.Start, parameterFactory.End, parameterFactory.Value);
				case 47:
					throw new TemplateFactory(DicSingleton.gE3WbyDVW(0x59C84793 ^ 0x59C8C00B));
				case 24:
					return new ClassFactory(anchor, default(ValueFactory), string.Empty, (RuleFactory)0, isPlainImplicit: false, isQuotedImplicit: false, parserFactory.Start, parserFactory.End);
				case 18:
				case 79:
					throw new TemplateFactory(parameterFactory2.Start, parameterFactory2.End, parameterFactory2.Value);
				case 32:
				case 46:
				{
					ModelFactory currentToken = GetCurrentToken();
					if (currentToken == null)
					{
						num2 = 49;
						continue;
					}
					modelFactory = currentToken;
					num2 = 27;
					continue;
				}
				case 49:
					throw new TemplateFactory(DicSingleton.gE3WbyDVW(-2103041941 ^ -2103007245));
				case 61:
				{
					ClassFactory result = new ClassFactory(anchor, tag, configFactory.Value, configFactory.Style, isPlainImplicit, isQuotedImplicit, start, configFactory.End);
					if (!anchor.IsEmpty && _FilterFactory.MoveNextWithoutConsuming())
					{
						_ReaderFactory = _FilterFactory.Current;
						if (_ReaderFactory is ParameterFactory)
						{
							parameterFactory = _ReaderFactory as ParameterFactory;
							throw new TemplateFactory(parameterFactory.Start, parameterFactory.End, parameterFactory.Value);
						}
					}
					if (_InterceptorFactory == (XmlBinaryNodeType)21 && _FilterFactory.MoveNextWithoutConsuming())
					{
						_ReaderFactory = _FilterFactory.Current;
						if (_ReaderFactory != null && !(_ReaderFactory is MerchantFactory) && !(_ReaderFactory is TestFactory))
						{
							throw new TemplateFactory(_ReaderFactory.Start, _ReaderFactory.End, DicSingleton.gE3WbyDVW(-1133601918 ^ -1133636938));
						}
					}
					return result;
				}
				case 21:
					{
						exporterFactory = modelFactory as ExporterFactory;
						num2 = 11;
						continue;
					}
					IL_098b:
					configFactory = modelFactory as ConfigFactory;
					num2 = 62;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab == 0)
					{
						num2 = 91;
					}
					continue;
				}
				break;
			}
		}
	}

	private MappingFactory ParseDocumentEnd()
	{
		int num = 12;
		bool isImplicit = default(bool);
		QueueReader start = default(QueueReader);
		QueueReader end = default(QueueReader);
		ModelFactory modelFactory = default(ModelFactory);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 19:
					if (factoryFactory.Version.Minor > 1)
					{
						num = 18;
						break;
					}
					goto case 2;
				case 5:
					Skip();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f == 0)
					{
						num2 = 3;
					}
					continue;
				case 20:
					if (Current is ClassFactory)
					{
						num2 = 25;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_575e6bd686b54d028cdc3fc324b58a39 == 0)
						{
							num2 = 10;
						}
						continue;
					}
					goto case 17;
				case 25:
					if (!(_ReaderFactory is ParameterFactory))
					{
						num2 = 17;
						continue;
					}
					goto case 4;
				case 6:
					return new ProcessorFactory(isImplicit, start, end);
				case 18:
					factoryFactory = null;
					num2 = 2;
					continue;
				default:
					isImplicit = true;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 == 0)
					{
						num2 = 13;
					}
					continue;
				case 22:
					if (_ReaderFactory is ProcessFactory)
					{
						num2 = 4;
						continue;
					}
					goto case 20;
				case 16:
					if (_ReaderFactory is BridgeFactory)
					{
						num2 = 8;
						continue;
					}
					goto case 9;
				case 24:
					end = start;
					num2 = 14;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 == 0)
					{
						num2 = 1;
					}
					continue;
				case 9:
					if (_ReaderFactory is MessageFactory)
					{
						num = 10;
						break;
					}
					goto case 22;
				case 13:
					start = modelFactory.Start;
					num = 24;
					break;
				case 2:
					_InterceptorFactory = (XmlBinaryNodeType)3;
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 != 0)
					{
						num2 = 6;
					}
					continue;
				case 17:
					throw new TemplateFactory(start, end, DicSingleton.gE3WbyDVW(0x1606DF07 ^ 0x160655A3));
				case 4:
				case 7:
				case 8:
				case 10:
				case 15:
					if (factoryFactory != null)
					{
						num2 = 21;
						continue;
					}
					goto case 2;
				case 14:
					if (modelFactory is ServiceFactory)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9c47a25d924946efb9e023473a095794 != 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 23;
				case 21:
					if (factoryFactory.Version.Major == 1)
					{
						num2 = 19;
						continue;
					}
					goto case 2;
				case 23:
					if (_ReaderFactory is AlgoFactory)
					{
						num2 = 14;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 == 0)
						{
							num2 = 15;
						}
						continue;
					}
					goto case 16;
				case 3:
					isImplicit = false;
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 == 0)
					{
						num2 = 7;
					}
					continue;
				case 1:
					end = modelFactory.End;
					num2 = 5;
					continue;
				case 12:
				{
					ModelFactory currentToken = GetCurrentToken();
					if (currentToken == null)
					{
						num2 = 11;
						continue;
					}
					modelFactory = currentToken;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 != 0)
					{
						num2 = 0;
					}
					continue;
				}
				case 11:
					throw new TemplateFactory(DicSingleton.gE3WbyDVW(-2103041941 ^ -2103006649));
				}
				break;
			}
		}
	}

	private MappingFactory ParseBlockSequenceEntry(bool isFirst)
	{
		int num = 1;
		EventFactory eventFactory = default(EventFactory);
		ModelFactory currentToken = default(ModelFactory);
		QueueReader end = default(QueueReader);
		InstanceFactory instanceFactory = default(InstanceFactory);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				object obj;
				switch (num2)
				{
				case 5:
					return ParseNode(isBlock: true, isIndentlessSequence: false);
				case 20:
					if (eventFactory != null)
					{
						num = 8;
						break;
					}
					if (currentToken == null)
					{
						num2 = 9;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 == 0)
						{
							num2 = 17;
						}
						continue;
					}
					obj = currentToken.Start;
					goto IL_02a0;
				case 4:
					return ProcessEmptyScalar(end);
				case 19:
					eventFactory = currentToken as EventFactory;
					num = 20;
					break;
				case 2:
					instanceFactory = currentToken as InstanceFactory;
					num2 = 18;
					continue;
				case 13:
					GetCurrentToken();
					num = 16;
					break;
				case 1:
					if (!isFirst)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 13;
				case 8:
					_InterceptorFactory = m_BaseFactory.Pop();
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 == 0)
					{
						num2 = 1;
					}
					continue;
				case 12:
					end = instanceFactory.End;
					num2 = 14;
					continue;
				case 18:
					if (instanceFactory == null)
					{
						num2 = 19;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
						{
							num2 = 10;
						}
						continue;
					}
					goto case 12;
				default:
					currentToken = GetCurrentToken();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0a707bb791e14c9e9a3ee77696a896b0 != 0)
					{
						num2 = 2;
					}
					continue;
				case 10:
					if (!(currentToken is EventFactory))
					{
						num2 = 11;
						continue;
					}
					goto IL_0079;
				case 11:
					m_BaseFactory.Push((XmlBinaryNodeType)10);
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 == 0)
					{
						num2 = 1;
					}
					continue;
				case 17:
					obj = null;
					goto IL_02a0;
				case 9:
					currentToken = GetCurrentToken();
					num = 7;
					break;
				case 16:
					Skip();
					num = 6;
					break;
				case 14:
					Skip();
					num2 = 9;
					continue;
				case 3:
				{
					SpecificationFactory result = new SpecificationFactory(eventFactory.Start, eventFactory.End);
					Skip();
					return result;
				}
				case 7:
					if (!(currentToken is InstanceFactory))
					{
						num2 = 10;
						continue;
					}
					goto IL_0079;
				case 15:
					{
						obj = QueueReader.m_CollectionReader;
						goto IL_02c6;
					}
					IL_02c6:
					throw new TemplateFactory((QueueReader)obj, currentToken?.End ?? QueueReader.m_CollectionReader, DicSingleton.gE3WbyDVW(0x6E29C0C0 ^ 0x6E294A32));
					IL_02a0:
					if (obj == null)
					{
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 == 0)
						{
							num2 = 15;
						}
						continue;
					}
					goto IL_02c6;
					IL_0079:
					_InterceptorFactory = (XmlBinaryNodeType)10;
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb != 0)
					{
						num2 = 4;
					}
					continue;
				}
				break;
			}
		}
	}

	private MappingFactory ParseIndentlessSequenceEntry()
	{
		int num = 4;
		InstanceFactory instanceFactory = default(InstanceFactory);
		ModelFactory currentToken = default(ModelFactory);
		QueueReader end = default(QueueReader);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				object obj;
				switch (num2)
				{
				case 16:
					if (instanceFactory == null)
					{
						goto end_IL_0012;
					}
					goto default;
				case 5:
					return ParseNode(isBlock: true, isIndentlessSequence: false);
				case 6:
				case 9:
				case 12:
					_InterceptorFactory = (XmlBinaryNodeType)11;
					num2 = 13;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 != 0)
					{
						num2 = 11;
					}
					continue;
				case 19:
					if (currentToken != null)
					{
						num2 = 11;
						continue;
					}
					goto case 18;
				case 8:
					if (currentToken is AnnotationFactory)
					{
						num2 = 12;
						continue;
					}
					goto case 15;
				case 3:
					instanceFactory = currentToken as InstanceFactory;
					num2 = 16;
					continue;
				case 4:
					currentToken = GetCurrentToken();
					num2 = 3;
					continue;
				case 17:
					currentToken = GetCurrentToken();
					num2 = 10;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 == 0)
					{
						num2 = 8;
					}
					continue;
				case 1:
					Skip();
					num2 = 17;
					continue;
				case 15:
					if (currentToken is EventFactory)
					{
						num2 = 6;
						continue;
					}
					goto case 7;
				case 13:
					return ProcessEmptyScalar(end);
				case 2:
					_InterceptorFactory = m_BaseFactory.Pop();
					num2 = 19;
					continue;
				case 10:
					if (currentToken is InstanceFactory)
					{
						num2 = 9;
						continue;
					}
					goto case 20;
				default:
					end = instanceFactory.End;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef == 0)
					{
						num2 = 1;
					}
					continue;
				case 18:
					obj = null;
					goto IL_024a;
				case 7:
					m_BaseFactory.Push((XmlBinaryNodeType)11);
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c != 0)
					{
						num2 = 5;
					}
					continue;
				case 20:
					if (!(currentToken is ValFactory))
					{
						num2 = 8;
						continue;
					}
					goto case 6;
				case 11:
					obj = currentToken.Start;
					goto IL_024a;
				case 14:
					{
						obj = QueueReader.m_CollectionReader;
						break;
					}
					IL_024a:
					if (obj != null)
					{
						break;
					}
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 == 0)
					{
						num2 = 14;
					}
					continue;
				}
				return new SpecificationFactory((QueueReader)obj, currentToken?.End ?? QueueReader.m_CollectionReader);
				continue;
				end_IL_0012:
				break;
			}
			num = 2;
		}
	}

	private MappingFactory ParseBlockMappingKey(bool isFirst)
	{
		int num = 11;
		ModelFactory currentToken = default(ModelFactory);
		EventFactory eventFactory = default(EventFactory);
		ParamFactory paramFactory = default(ParamFactory);
		ValFactory valFactory = default(ValFactory);
		AnnotationFactory annotationFactory = default(AnnotationFactory);
		QueueReader end = default(QueueReader);
		ParameterFactory parameterFactory = default(ParameterFactory);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				object obj;
				switch (num2)
				{
				case 10:
					GetCurrentToken();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 == 0)
					{
						num2 = 14;
					}
					continue;
				case 25:
					return ParseNode(isBlock: true, isIndentlessSequence: true);
				case 4:
				case 32:
					_InterceptorFactory = (XmlBinaryNodeType)14;
					num2 = 31;
					continue;
				case 21:
					if (currentToken is AnnotationFactory)
					{
						num2 = 4;
						continue;
					}
					goto case 8;
				case 5:
				{
					ListFactory result = new ListFactory(eventFactory.Start, eventFactory.End);
					Skip();
					return result;
				}
				case 17:
					if (paramFactory == null)
					{
						num2 = 16;
						continue;
					}
					goto case 6;
				case 14:
					Skip();
					num2 = 22;
					continue;
				case 26:
					if (valFactory != null)
					{
						num = 28;
						break;
					}
					annotationFactory = currentToken as AnnotationFactory;
					num2 = 3;
					continue;
				case 2:
					valFactory = currentToken as ValFactory;
					num2 = 26;
					continue;
				case 31:
					return ProcessEmptyScalar(end);
				case 22:
					currentToken = GetCurrentToken();
					num2 = 2;
					continue;
				case 30:
					obj = null;
					goto IL_044e;
				case 9:
					if (eventFactory == null)
					{
						parameterFactory = GetCurrentToken() as ParameterFactory;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 == 0)
						{
							num2 = 0;
						}
					}
					else
					{
						num2 = 29;
					}
					continue;
				case 13:
					return new TagFactory(paramFactory.Value, paramFactory.Start, paramFactory.End);
				case 16:
					eventFactory = currentToken as EventFactory;
					num2 = 9;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 != 0)
					{
						num2 = 0;
					}
					continue;
				case 11:
					if (isFirst)
					{
						num2 = 10;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba != 0)
						{
							num2 = 2;
						}
						continue;
					}
					goto case 22;
				case 15:
					return ProcessEmptyScalar(annotationFactory.End);
				case 7:
					paramFactory = currentToken as ParamFactory;
					num2 = 17;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 != 0)
					{
						num2 = 12;
					}
					continue;
				case 23:
					Skip();
					num2 = 15;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb != 0)
					{
						num2 = 15;
					}
					continue;
				case 18:
					currentToken = GetCurrentToken();
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 != 0)
					{
						num2 = 20;
					}
					continue;
				case 27:
					throw new RegistryFactory(parameterFactory.Start, parameterFactory.End, parameterFactory.Value);
				case 28:
					end = valFactory.End;
					num2 = 19;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab != 0)
					{
						num2 = 16;
					}
					continue;
				case 1:
					m_BaseFactory.Push((XmlBinaryNodeType)14);
					num = 25;
					break;
				case 3:
					if (annotationFactory == null)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef == 0)
						{
							num2 = 7;
						}
						continue;
					}
					goto case 23;
				case 8:
					if (!(currentToken is EventFactory))
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 != 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 4;
				case 19:
					Skip();
					num2 = 18;
					continue;
				default:
					if (parameterFactory == null)
					{
						if (currentToken != null)
						{
							num2 = 24;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 != 0)
							{
								num2 = 7;
							}
							continue;
						}
						goto case 30;
					}
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e != 0)
					{
						num2 = 27;
					}
					continue;
				case 29:
					_InterceptorFactory = m_BaseFactory.Pop();
					num2 = 5;
					continue;
				case 6:
					Skip();
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 == 0)
					{
						num2 = 13;
					}
					continue;
				case 20:
					if (currentToken is ValFactory)
					{
						num2 = 32;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 != 0)
						{
							num2 = 13;
						}
						continue;
					}
					goto case 21;
				case 24:
					obj = currentToken.Start;
					goto IL_044e;
				case 12:
					{
						obj = QueueReader.m_CollectionReader;
						goto IL_0464;
					}
					IL_044e:
					if (obj == null)
					{
						num2 = 12;
						continue;
					}
					goto IL_0464;
					IL_0464:
					throw new TemplateFactory((QueueReader)obj, currentToken?.End ?? QueueReader.m_CollectionReader, DicSingleton.gE3WbyDVW(-948533799 ^ -948564389));
				}
				break;
			}
		}
	}

	private MappingFactory ParseBlockMappingValue()
	{
		int num = 19;
		ParameterFactory parameterFactory = default(ParameterFactory);
		ModelFactory currentToken = default(ModelFactory);
		QueueReader end = default(QueueReader);
		AnnotationFactory annotationFactory = default(AnnotationFactory);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				object obj;
				switch (num2)
				{
				case 11:
					if (parameterFactory != null)
					{
						num2 = 8;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f != 0)
						{
							num2 = 6;
						}
					}
					else
					{
						_InterceptorFactory = (XmlBinaryNodeType)13;
						num2 = 13;
					}
					continue;
				case 8:
					throw new TemplateFactory(parameterFactory.Start, parameterFactory.End, parameterFactory.Value);
				case 13:
					if (currentToken != null)
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto default;
				case 6:
					Skip();
					num = 9;
					break;
				case 3:
					if (currentToken is ValFactory)
					{
						num2 = 12;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 != 0)
						{
							num2 = 6;
						}
						continue;
					}
					goto case 10;
				case 14:
					end = annotationFactory.End;
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 != 0)
					{
						num2 = 5;
					}
					continue;
				case 9:
					currentToken = GetCurrentToken();
					num2 = 3;
					continue;
				case 19:
					currentToken = GetCurrentToken();
					num2 = 18;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 == 0)
					{
						num2 = 4;
					}
					continue;
				case 15:
					return ProcessEmptyScalar(end);
				case 4:
					parameterFactory = currentToken as ParameterFactory;
					num = 11;
					break;
				case 7:
					if (!(currentToken is EventFactory))
					{
						num2 = 17;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 != 0)
						{
							num2 = 17;
						}
						continue;
					}
					goto case 5;
				case 17:
					m_BaseFactory.Push((XmlBinaryNodeType)13);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 != 0)
					{
						num2 = 0;
					}
					continue;
				default:
					obj = null;
					goto IL_02cf;
				case 18:
					annotationFactory = currentToken as AnnotationFactory;
					num2 = 18;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef == 0)
					{
						num2 = 20;
					}
					continue;
				case 20:
					if (annotationFactory == null)
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 == 0)
						{
							num2 = 4;
						}
						continue;
					}
					goto case 14;
				case 1:
					return ParseNode(isBlock: true, isIndentlessSequence: true);
				case 5:
				case 12:
					_InterceptorFactory = (XmlBinaryNodeType)13;
					num2 = 12;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 == 0)
					{
						num2 = 15;
					}
					continue;
				case 10:
					if (currentToken is AnnotationFactory)
					{
						num2 = 5;
						continue;
					}
					goto case 7;
				case 2:
					obj = currentToken.Start;
					goto IL_02cf;
				case 16:
					{
						obj = QueueReader.m_CollectionReader;
						goto IL_02e5;
					}
					IL_02cf:
					if (obj == null)
					{
						num2 = 16;
						continue;
					}
					goto IL_02e5;
					IL_02e5:
					return ProcessEmptyScalar((QueueReader)obj);
				}
				break;
			}
		}
	}

	private MappingFactory ParseFlowSequenceEntry(bool isFirst)
	{
		int num = 2;
		int num2 = num;
		object obj;
		ModelFactory currentToken = default(ModelFactory);
		while (true)
		{
			object obj2;
			switch (num2)
			{
			case 20:
			{
				QueueFactory result = new QueueFactory(HelperReader._ExceptionReader, ValueFactory._DecoratorFactory, isImplicit: true, (TokenizerFactory)2);
				Skip();
				return result;
			}
			case 3:
				obj = null;
				goto IL_0338;
			case 22:
				currentToken = GetCurrentToken();
				num2 = 16;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b != 0)
				{
					num2 = 5;
				}
				continue;
			case 8:
				GetCurrentToken();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 == 0)
				{
					num2 = 0;
				}
				continue;
			case 7:
				if (currentToken is MessageFactory)
				{
					num2 = 24;
					continue;
				}
				goto case 13;
			case 1:
			case 18:
				currentToken = GetCurrentToken();
				num2 = 7;
				continue;
			case 6:
				if (!(currentToken is MerchantFactory))
				{
					num2 = 12;
					continue;
				}
				goto case 14;
			case 13:
				if (isFirst)
				{
					num2 = 15;
					continue;
				}
				goto case 6;
			case 14:
				Skip();
				num2 = 22;
				continue;
			case 5:
			case 12:
				if (currentToken == null)
				{
					num2 = 7;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 == 0)
					{
						num2 = 9;
					}
					continue;
				}
				obj2 = currentToken.Start;
				goto IL_02c5;
			case 23:
				if (currentToken == null)
				{
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 != 0)
					{
						num2 = 2;
					}
					continue;
				}
				obj = currentToken.Start;
				goto IL_0338;
			case 9:
				obj2 = null;
				goto IL_02c5;
			case 19:
				return ParseNode(isBlock: false, isIndentlessSequence: false);
			case 21:
			case 24:
				_InterceptorFactory = m_BaseFactory.Pop();
				num2 = 23;
				continue;
			default:
				Skip();
				num2 = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3a460cd74a4c809e0f755964f2077b == 0)
				{
					num2 = 18;
				}
				continue;
			case 4:
				_InterceptorFactory = (XmlBinaryNodeType)17;
				num2 = 20;
				continue;
			case 10:
				m_BaseFactory.Push((XmlBinaryNodeType)16);
				num2 = 19;
				continue;
			case 2:
				if (!isFirst)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f == 0)
					{
						num2 = 0;
					}
					continue;
				}
				goto case 8;
			case 17:
				obj2 = QueueReader.m_CollectionReader;
				goto IL_02db;
			case 15:
			case 16:
				if (!(currentToken is ValFactory))
				{
					if (currentToken is MessageFactory)
					{
						num2 = 21;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 != 0)
						{
							num2 = 21;
						}
						continue;
					}
					goto case 10;
				}
				num2 = 4;
				continue;
			case 11:
				{
					obj = QueueReader.m_CollectionReader;
					break;
				}
				IL_02c5:
				if (obj2 == null)
				{
					num2 = 17;
					continue;
				}
				goto IL_02db;
				IL_02db:
				throw new TemplateFactory((QueueReader)obj2, currentToken?.End ?? QueueReader.m_CollectionReader, DicSingleton.gE3WbyDVW(-1544119467 ^ -1544154963));
				IL_0338:
				if (obj == null)
				{
					num2 = 11;
					continue;
				}
				break;
			}
			break;
		}
		SpecificationFactory result2 = new SpecificationFactory((QueueReader)obj, currentToken?.End ?? QueueReader.m_CollectionReader);
		Skip();
		return result2;
	}

	private MappingFactory ParseFlowSequenceEntryMappingKey()
	{
		int num = 9;
		int num2 = num;
		ModelFactory currentToken = default(ModelFactory);
		object obj;
		while (true)
		{
			switch (num2)
			{
			case 9:
				currentToken = GetCurrentToken();
				num2 = 8;
				continue;
			case 4:
				obj = null;
				goto IL_0119;
			case 8:
				if (!(currentToken is AnnotationFactory))
				{
					num2 = 2;
					continue;
				}
				goto case 7;
			case 2:
				if (!(currentToken is MerchantFactory))
				{
					num2 = 5;
					continue;
				}
				goto case 7;
			case 5:
				if (currentToken is MessageFactory)
				{
					num2 = 7;
					continue;
				}
				goto case 6;
			case 1:
				return ParseNode(isBlock: false, isIndentlessSequence: false);
			case 7:
				if (currentToken != null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab != 0)
					{
						num2 = 0;
					}
					continue;
				}
				goto case 4;
			case 6:
				m_BaseFactory.Push((XmlBinaryNodeType)18);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_91887e48b8104e7da08b48f73b607337 == 0)
				{
					num2 = 1;
				}
				continue;
			default:
				obj = currentToken.End;
				goto IL_0119;
			case 3:
				{
					obj = QueueReader.m_CollectionReader;
					break;
				}
				IL_0119:
				if (obj == null)
				{
					num2 = 3;
					continue;
				}
				break;
			}
			break;
		}
		Skip();
		_InterceptorFactory = (XmlBinaryNodeType)18;
		return ProcessEmptyScalar((QueueReader)obj);
	}

	private MappingFactory ParseFlowSequenceEntryMappingValue()
	{
		int num = 10;
		ModelFactory currentToken = default(ModelFactory);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				object obj;
				switch (num2)
				{
				case 10:
					currentToken = GetCurrentToken();
					num2 = 9;
					continue;
				case 3:
					return ParseNode(isBlock: false, isIndentlessSequence: false);
				case 5:
					_InterceptorFactory = (XmlBinaryNodeType)19;
					num2 = 11;
					continue;
				case 4:
					if (!(currentToken is MessageFactory))
					{
						num2 = 7;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
						{
							num2 = 2;
						}
						continue;
					}
					goto case 5;
				case 9:
					if (!(currentToken is AnnotationFactory))
					{
						num2 = 5;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 == 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 8;
				case 6:
					obj = null;
					goto IL_016a;
				case 7:
					m_BaseFactory.Push((XmlBinaryNodeType)19);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 == 0)
					{
						num2 = 3;
					}
					continue;
				case 11:
					if (currentToken == null)
					{
						num2 = 6;
						continue;
					}
					obj = currentToken.Start;
					goto IL_016a;
				case 8:
					Skip();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 == 0)
					{
						num2 = 1;
					}
					continue;
				case 2:
					if (!(currentToken is MerchantFactory))
					{
						num2 = 4;
						continue;
					}
					goto case 5;
				case 1:
					goto end_IL_0012;
				default:
					{
						obj = QueueReader.m_CollectionReader;
						break;
					}
					IL_016a:
					if (obj == null)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 != 0)
						{
							num2 = 0;
						}
						continue;
					}
					break;
				}
				return ProcessEmptyScalar((QueueReader)obj);
				continue;
				end_IL_0012:
				break;
			}
			currentToken = GetCurrentToken();
			num = 2;
		}
	}

	private MappingFactory ParseFlowSequenceEntryMappingEnd()
	{
		int num = 2;
		int num2 = num;
		ModelFactory currentToken = default(ModelFactory);
		object obj;
		while (true)
		{
			switch (num2)
			{
			case 2:
				_InterceptorFactory = (XmlBinaryNodeType)16;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb == 0)
				{
					num2 = 1;
				}
				continue;
			case 1:
				currentToken = GetCurrentToken();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
				{
					num2 = 0;
				}
				continue;
			default:
				if (currentToken == null)
				{
					num2 = 4;
					continue;
				}
				obj = currentToken.Start;
				goto IL_0097;
			case 4:
				obj = null;
				goto IL_0097;
			case 3:
				{
					obj = QueueReader.m_CollectionReader;
					break;
				}
				IL_0097:
				if (obj == null)
				{
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a == 0)
					{
						num2 = 2;
					}
					continue;
				}
				break;
			}
			break;
		}
		return new ListFactory((QueueReader)obj, currentToken?.End ?? QueueReader.m_CollectionReader);
	}

	private MappingFactory ParseFlowMappingKey(bool isFirst)
	{
		int num = 10;
		ModelFactory currentToken = default(ModelFactory);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				object obj;
				object obj3;
				object obj2;
				switch (num2)
				{
				case 35:
					return ParseNode(isBlock: false, isIndentlessSequence: false);
				case 2:
				case 12:
				case 33:
					_InterceptorFactory = (XmlBinaryNodeType)22;
					num2 = 26;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 == 0)
					{
						num2 = 29;
					}
					continue;
				case 32:
					if (currentToken is MerchantFactory)
					{
						num2 = 33;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 != 0)
						{
							num2 = 33;
						}
						continue;
					}
					goto case 11;
				case 3:
					Skip();
					num = 13;
					break;
				case 25:
					obj = null;
					goto IL_0527;
				case 11:
					if (currentToken is TestFactory)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 != 0)
						{
							num2 = 2;
						}
						continue;
					}
					goto case 28;
				case 40:
					Skip();
					num2 = 37;
					continue;
				case 13:
					if (currentToken == null)
					{
						num2 = 25;
						continue;
					}
					obj = currentToken.Start;
					goto IL_0527;
				case 15:
					obj3 = null;
					goto IL_044c;
				case 23:
					if (currentToken != null)
					{
						num2 = 31;
						continue;
					}
					goto case 15;
				case 7:
					return ParseNode(isBlock: false, isIndentlessSequence: false);
				default:
					if (!(currentToken is TestFactory))
					{
						num2 = 6;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 != 0)
						{
							num2 = 34;
						}
						continue;
					}
					goto case 5;
				case 27:
					m_BaseFactory.Push((XmlBinaryNodeType)22);
					num = 7;
					break;
				case 17:
					Skip();
					num2 = 4;
					continue;
				case 21:
					Skip();
					num2 = 24;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab == 0)
					{
						num2 = 39;
					}
					continue;
				case 14:
					return ParseNode(isBlock: false, isIndentlessSequence: false);
				case 5:
					_InterceptorFactory = m_BaseFactory.Pop();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb != 0)
					{
						num2 = 3;
					}
					continue;
				case 6:
					GetCurrentToken();
					num = 40;
					break;
				case 16:
					if (currentToken is MerchantFactory)
					{
						num = 17;
						break;
					}
					goto case 23;
				case 29:
					if (currentToken != null)
					{
						num2 = 26;
						continue;
					}
					goto case 38;
				case 34:
					m_BaseFactory.Push((XmlBinaryNodeType)23);
					num2 = 14;
					continue;
				case 10:
					if (!isFirst)
					{
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 == 0)
						{
							num2 = 9;
						}
						continue;
					}
					goto case 6;
				case 4:
					currentToken = GetCurrentToken();
					num2 = 8;
					continue;
				case 39:
					currentToken = GetCurrentToken();
					num2 = 19;
					continue;
				case 19:
					if (currentToken is AnnotationFactory)
					{
						num2 = 12;
						continue;
					}
					goto case 32;
				case 36:
					if (currentToken is TestFactory)
					{
						num2 = 5;
						continue;
					}
					goto case 20;
				case 38:
					obj2 = null;
					goto IL_04de;
				case 9:
				case 37:
					currentToken = GetCurrentToken();
					num2 = 36;
					continue;
				case 28:
					m_BaseFactory.Push((XmlBinaryNodeType)22);
					num2 = 35;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e != 0)
					{
						num2 = 6;
					}
					continue;
				case 20:
					if (isFirst)
					{
						num2 = 22;
						continue;
					}
					goto case 16;
				case 31:
					obj3 = currentToken.Start;
					goto IL_044c;
				case 30:
					obj3 = QueueReader.m_CollectionReader;
					goto IL_046b;
				case 8:
				case 22:
					if (!(currentToken is ValFactory))
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 == 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 21;
				case 26:
					obj2 = currentToken.Start;
					goto IL_04de;
				case 24:
					obj2 = QueueReader.m_CollectionReader;
					goto IL_04f4;
				case 1:
					if (!(currentToken is ConfigFactory))
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 27;
				case 18:
					{
						obj = QueueReader.m_CollectionReader;
						goto IL_053d;
					}
					IL_044c:
					if (obj3 != null)
					{
						goto IL_046b;
					}
					num = 30;
					break;
					IL_046b:
					throw new TemplateFactory((QueueReader)obj3, currentToken?.End ?? QueueReader.m_CollectionReader, DicSingleton.gE3WbyDVW(-1483531944 ^ -1483500252));
					IL_053d:
					return new ListFactory((QueueReader)obj, currentToken?.End ?? QueueReader.m_CollectionReader);
					IL_04de:
					if (obj2 == null)
					{
						num2 = 24;
						continue;
					}
					goto IL_04f4;
					IL_04f4:
					return ProcessEmptyScalar((QueueReader)obj2);
					IL_0527:
					if (obj == null)
					{
						num2 = 18;
						continue;
					}
					goto IL_053d;
				}
				break;
			}
		}
	}

	private MappingFactory ParseFlowMappingValue(bool isEmpty)
	{
		int num = 3;
		int num2 = num;
		ModelFactory currentToken = default(ModelFactory);
		object obj;
		while (true)
		{
			object obj2;
			switch (num2)
			{
			case 13:
				_InterceptorFactory = (XmlBinaryNodeType)21;
				num2 = 7;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 == 0)
				{
					num2 = 11;
				}
				continue;
			case 8:
				if (!(currentToken is MerchantFactory))
				{
					num2 = 14;
					continue;
				}
				goto case 12;
			case 9:
				currentToken = GetCurrentToken();
				num2 = 8;
				continue;
			case 2:
				if (isEmpty)
				{
					num2 = 13;
					continue;
				}
				if (!(currentToken is AnnotationFactory))
				{
					num2 = 12;
					continue;
				}
				goto case 7;
			case 11:
				if (currentToken == null)
				{
					num2 = 15;
					continue;
				}
				obj2 = currentToken.Start;
				goto IL_019e;
			case 3:
				currentToken = GetCurrentToken();
				num2 = 2;
				continue;
			case 7:
				Skip();
				num2 = 9;
				continue;
			case 14:
				if (!(currentToken is TestFactory))
				{
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 != 0)
					{
						num2 = 0;
					}
					continue;
				}
				goto case 12;
			case 6:
				m_BaseFactory.Push((XmlBinaryNodeType)21);
				num2 = 5;
				continue;
			case 5:
				return ParseNode(isBlock: false, isIndentlessSequence: false);
			case 12:
				_InterceptorFactory = (XmlBinaryNodeType)21;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f != 0)
				{
					num2 = 1;
				}
				continue;
			case 10:
				obj = null;
				goto IL_01e7;
			case 1:
				if (currentToken == null)
				{
					num2 = 10;
					continue;
				}
				obj = currentToken.Start;
				goto IL_01e7;
			case 15:
				obj2 = null;
				goto IL_019e;
			case 4:
				obj2 = QueueReader.m_CollectionReader;
				goto IL_01c4;
			default:
				{
					obj = QueueReader.m_CollectionReader;
					break;
				}
				IL_019e:
				if (obj2 == null)
				{
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 == 0)
					{
						num2 = 1;
					}
					continue;
				}
				goto IL_01c4;
				IL_01e7:
				if (obj != null)
				{
					break;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd != 0)
				{
					num2 = 0;
				}
				continue;
				IL_01c4:
				return ProcessEmptyScalar((QueueReader)obj2);
			}
			break;
		}
		return ProcessEmptyScalar((QueueReader)obj);
	}

	internal static bool CountError()
	{
		return LogoutError == null;
	}

	internal static PublisherFactory SetError()
	{
		return LogoutError;
	}
}
