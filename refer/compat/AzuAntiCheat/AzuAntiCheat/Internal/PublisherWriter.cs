using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class PublisherWriter : WriterSetter<PublisherWriter>
{
	private class SingletonWriter : RepositorySetter
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass6_0
		{
			public SingletonWriter m_ComparatorWriter;

			public MockInterpreter _DefinitionWriter;

			public List<ErrorSetter<MappingSetter>> composerWriter;

			private static _003C_003Ec__DisplayClass6_0 ResolveStatus;

			public _003C_003Ec__DisplayClass6_0()
			{
				GetterIssuer.DeleteInitializer();
				base._002Ector();
				int num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba == 0)
				{
					num = 0;
				}
				switch (num)
				{
				case 0:
					break;
				}
			}

			internal ValueSetter _003CSerializeValue_003Eb__1(ErrorSetter<MockInterpreter> inner)
			{
				return new ValueSetter(inner, m_ComparatorWriter.m_FieldWriter, composerWriter, m_ComparatorWriter.m_RuleWriter, NestedObjectSerializer);
				void NestedObjectSerializer(object? v, Type? t)
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
							m_ComparatorWriter.SerializeValue(_DefinitionWriter, v, t);
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 == 0)
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

			internal static bool DefineStatus()
			{
				return ResolveStatus == null;
			}

			internal static _003C_003Ec__DisplayClass6_0 IncludeStatus()
			{
				return ResolveStatus;
			}
		}

		private readonly DatabaseSetter m_IssuerWriter;

		private readonly ValSetter m_FieldWriter;

		private readonly IEnumerable<StrategySetter> m_RuleWriter;

		private readonly ProcessorSetter<IEnumerable<StrategySetter>, ErrorSetter<MappingSetter>> _SerializerWriter;

		private readonly ProcessorSetter<ValueSetter, ErrorSetter<MockInterpreter>> producerWriter;

		internal static SingletonWriter ConnectStatus;

		public SingletonWriter(DatabaseSetter traversalStrategy, ValSetter eventEmitter, IEnumerable<StrategySetter> typeConverters, ProcessorSetter<IEnumerable<StrategySetter>, ErrorSetter<MappingSetter>> preProcessingPhaseObjectGraphVisitorFactories, ProcessorSetter<ValueSetter, ErrorSetter<MockInterpreter>> emissionPhaseObjectGraphVisitorFactories)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			m_IssuerWriter = traversalStrategy;
			m_FieldWriter = eventEmitter;
			m_RuleWriter = typeConverters;
			_SerializerWriter = preProcessingPhaseObjectGraphVisitorFactories;
			producerWriter = emissionPhaseObjectGraphVisitorFactories;
		}

		public void SerializeValue(MockInterpreter emitter, object? value, Type? type)
		{
			_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass6_0();
			CS_0024_003C_003E8__locals10.m_ComparatorWriter = this;
			CS_0024_003C_003E8__locals10._DefinitionWriter = emitter;
			Type type2 = type ?? ((value != null) ? value.GetType() : typeof(object));
			Type staticType = type ?? typeof(object);
			SchemaSetter graph = new SchemaSetter(value, type2, staticType);
			CS_0024_003C_003E8__locals10.composerWriter = _SerializerWriter.BuildComponentList(m_RuleWriter);
			foreach (ErrorSetter<MappingSetter> item in CS_0024_003C_003E8__locals10.composerWriter)
			{
				m_IssuerWriter.Traverse(graph, item, default(MappingSetter));
			}
			ErrorSetter<MockInterpreter> visitor = producerWriter.BuildComponentChain<ValueSetter, ErrorSetter<MockInterpreter>>(new AdapterInvocation(m_FieldWriter), (ErrorSetter<MockInterpreter> inner) => new ValueSetter(inner, CS_0024_003C_003E8__locals10.m_ComparatorWriter.m_FieldWriter, CS_0024_003C_003E8__locals10.composerWriter, CS_0024_003C_003E8__locals10.m_ComparatorWriter.m_RuleWriter, NestedObjectSerializer));
			m_IssuerWriter.Traverse(graph, visitor, CS_0024_003C_003E8__locals10._DefinitionWriter);
			void NestedObjectSerializer(object? v, Type? t)
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
						CS_0024_003C_003E8__locals10.m_ComparatorWriter.SerializeValue(CS_0024_003C_003E8__locals10._DefinitionWriter, v, t);
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 == 0)
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

		internal static bool StartStatus()
		{
			return ConnectStatus == null;
		}

		internal static SingletonWriter RemoveStatus()
		{
			return ConnectStatus;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass19_0<TEventEmitter> where TEventEmitter : notnull, ValSetter
	{
		public Func<ValSetter, TEventEmitter> eventEmitterFactory;

		private static object MoveStatus;

		public _003C_003Ec__DisplayClass19_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae50b6e347494ff2973fbc64d1fc9236 != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal ValSetter _003CWithEventEmitter_003Eb__0(ValSetter inner)
		{
			return eventEmitterFactory(inner);
		}

		internal static bool RevertStatus()
		{
			return MoveStatus == null;
		}

		internal static object InvokeBridge()
		{
			return MoveStatus;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass20_0<TEventEmitter> where TEventEmitter : notnull, ValSetter
	{
		public ComparatorSetter<ValSetter, ValSetter, TEventEmitter> eventEmitterFactory;

		private static object PublishBridge;

		public _003C_003Ec__DisplayClass20_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f92fb16082174ff29c1cf0085d4a3cb9 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal ValSetter _003CWithEventEmitter_003Eb__0(ValSetter wrapped, ValSetter inner)
		{
			return eventEmitterFactory(wrapped, inner);
		}

		internal static bool RegisterBridge()
		{
			return PublishBridge == null;
		}

		internal static object SetupBridge()
		{
			return PublishBridge;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass32_0<TObjectGraphVisitor> where TObjectGraphVisitor : notnull, ErrorSetter<MappingSetter>
	{
		public TObjectGraphVisitor objectGraphVisitor;

		internal static object SelectBridge;

		public _003C_003Ec__DisplayClass32_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_259acdc10a3c4fba8a4f129ba5346de2 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal ErrorSetter<MappingSetter> _003CWithPreProcessingPhaseObjectGraphVisitor_003Eb__0(IEnumerable<StrategySetter> _)
		{
			return objectGraphVisitor;
		}

		internal static bool ChangeBridge()
		{
			return SelectBridge == null;
		}

		internal static object CreateBridge()
		{
			return SelectBridge;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass33_0<TObjectGraphVisitor> where TObjectGraphVisitor : notnull, ErrorSetter<MappingSetter>
	{
		public ProducerSetter<ErrorSetter<MappingSetter>, TObjectGraphVisitor> objectGraphVisitorFactory;

		internal static object TestBridge;

		public _003C_003Ec__DisplayClass33_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal ErrorSetter<MappingSetter> _003CWithPreProcessingPhaseObjectGraphVisitor_003Eb__0(ErrorSetter<MappingSetter> wrapped, IEnumerable<StrategySetter> _)
		{
			return objectGraphVisitorFactory(wrapped);
		}

		internal static bool RunBridge()
		{
			return TestBridge == null;
		}

		internal static object VerifyBridge()
		{
			return TestBridge;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass38_0<TObjectGraphVisitor> where TObjectGraphVisitor : notnull, ErrorSetter<MockInterpreter>
	{
		public Func<ValueSetter, TObjectGraphVisitor> objectGraphVisitorFactory;

		private static object PopBridge;

		public _003C_003Ec__DisplayClass38_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4fda3adbb4ec45bdb14fe2ef97e570a8 != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal ErrorSetter<MockInterpreter> _003CWithEmissionPhaseObjectGraphVisitor_003Eb__0(ValueSetter args)
		{
			return objectGraphVisitorFactory(args);
		}

		internal static bool PostBridge()
		{
			return PopBridge == null;
		}

		internal static object CallBridge()
		{
			return PopBridge;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass39_0<TObjectGraphVisitor> where TObjectGraphVisitor : notnull, ErrorSetter<MockInterpreter>
	{
		public ComparatorSetter<ValueSetter, ErrorSetter<MockInterpreter>, TObjectGraphVisitor> objectGraphVisitorFactory;

		internal static object ConcatBridge;

		public _003C_003Ec__DisplayClass39_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal ErrorSetter<MockInterpreter> _003CWithEmissionPhaseObjectGraphVisitor_003Eb__0(ErrorSetter<MockInterpreter> wrapped, ValueSetter args)
		{
			return objectGraphVisitorFactory(wrapped, args);
		}

		internal static bool MapBridge()
		{
			return ConcatBridge == null;
		}

		internal static object NewBridge()
		{
			return ConcatBridge;
		}
	}

	private PropertySetter m_BaseWriter;

	private readonly ProcessorSetter<IEnumerable<StrategySetter>, ErrorSetter<MappingSetter>> m_PrototypeWriter;

	private readonly ProcessorSetter<ValueSetter, ErrorSetter<MockInterpreter>> interceptorWriter;

	private readonly ProcessorSetter<ValSetter, ValSetter> filterWriter;

	private readonly IDictionary<Type, RoleSingleton> m_ReaderWriter;

	private readonly PrinterSetter factoryWriter;

	private int m_SetterWriter;

	private ExceptionInterpreter _WriterWriter;

	private SchemaItemPropertyIndexes _InvocationWriter;

	private ConnectionInterpreter _AuthenticationWriter;

	private bool attributeWriter;

	private bool m_InterpreterWriter;

	internal static PublisherWriter AwakeStatus;

	protected override PublisherWriter Self => this;

	public PublisherWriter()
	{
		GetterIssuer.DeleteInitializer();
		m_ReaderWriter = new Dictionary<Type, RoleSingleton>();
		m_SetterWriter = 50;
		_WriterWriter = ExceptionInterpreter.m_GetterInterpreter;
		base._002Ector((ConnectionSetter)new CandidateInvocation());
		m_SingletonSetter.Add(typeof(ProductInvocation), (AdvisorSetter inner) => new ProductInvocation(inner));
		m_SingletonSetter.Add(typeof(TestsInvocation), delegate(AdvisorSetter inner)
		{
			int num = 1;
			AdvisorSetter result = default(AdvisorSetter);
			while (true)
			{
				int num2 = num;
				while (true)
				{
					switch (num2)
					{
					case 1:
						if (invocationSetter is InfoAuthentication)
						{
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac == 0)
							{
								num2 = 0;
							}
							continue;
						}
						break;
					case 2:
						break;
					case 3:
						return result;
					default:
						return inner;
					}
					break;
				}
				result = new TestsInvocation(inner, invocationSetter);
				num = 3;
			}
		});
		m_SingletonSetter.Add(typeof(SpecificationWriter), (AdvisorSetter inner) => new SpecificationWriter(inner));
		m_SingletonSetter.Add(typeof(ThreadWriter), delegate(AdvisorSetter inner)
		{
			int num = 2;
			int num2 = num;
			AdvisorSetter result = default(AdvisorSetter);
			while (true)
			{
				switch (num2)
				{
				case 2:
					if (_AttributeSetter == null)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 != 0)
						{
							num2 = 1;
						}
					}
					else
					{
						result = new ThreadWriter(inner, _AttributeSetter.Clone());
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 != 0)
						{
							num2 = 0;
						}
					}
					break;
				default:
					return result;
				case 1:
					return inner;
				}
			}
		});
		m_PrototypeWriter = new ProcessorSetter<IEnumerable<StrategySetter>, ErrorSetter<MappingSetter>> { 
		{
			typeof(DispatcherInvocation),
			(IEnumerable<StrategySetter> typeConverters) => new DispatcherInvocation(typeConverters)
		} };
		interceptorWriter = new ProcessorSetter<ValueSetter, ErrorSetter<MockInterpreter>>
		{
			{
				typeof(ClassInvocation),
				(ValueSetter args) => new ClassInvocation(args.InnerVisitor, args.TypeConverters, args.NestedObjectSerializer)
			},
			{
				typeof(TokenizerInvocation),
				(ValueSetter args) => new TokenizerInvocation(args.InnerVisitor, args.EventEmitter, args.GetPreProcessingPhaseObjectGraphVisitor<DispatcherInvocation>())
			},
			{
				typeof(SpecificationInvocation),
				(ValueSetter args) => new SpecificationInvocation(_InvocationWriter, args.InnerVisitor, new IssuerAuthentication())
			},
			{
				typeof(StructInvocation),
				(ValueSetter args) => new StructInvocation(args.InnerVisitor)
			}
		};
		filterWriter = new ProcessorSetter<ValSetter, ValSetter> { 
		{
			typeof(TokenizerAuthentication),
			(ValSetter inner) => new TokenizerAuthentication(inner, requireTagWhenStaticAndActualTypesAreDifferent: false, m_ReaderWriter, attributeWriter, m_InterpreterWriter, _AuthenticationWriter, _SerializerSetter)
		} };
		factoryWriter = new IssuerAuthentication();
		m_BaseWriter = (AdvisorSetter typeInspector, ConnectionSetter typeResolver, IEnumerable<StrategySetter> typeConverters, int maximumRecursion) => new PrototypeAuthentication(typeInspector, typeResolver, maximumRecursion, invocationSetter, factoryWriter);
	}

	public PublisherWriter WithQuotingNecessaryStrings(bool quoteYaml1_1Strings = false)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				attributeWriter = true;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				m_InterpreterWriter = quoteYaml1_1Strings;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 != 0)
				{
					num2 = 2;
				}
				break;
			case 2:
				return this;
			}
		}
	}

	public PublisherWriter WithDefaultScalarStyle(ConnectionInterpreter style)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return this;
			case 1:
				_AuthenticationWriter = style;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public PublisherWriter WithMaximumRecursion(int maximumRecursion)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 3:
				return this;
			default:
				throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(0x3FCF6129 ^ 0x3FCF3D85), string.Format(DicSingleton.gE3WbyDVW(-1817326817 ^ -1817339953), maximumRecursion));
			case 1:
				m_SetterWriter = maximumRecursion;
				num2 = 3;
				break;
			case 2:
				if (maximumRecursion > 0)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 != 0)
					{
						num2 = 1;
					}
					break;
				}
				goto default;
			}
		}
	}

	public PublisherWriter WithEventEmitter<TEventEmitter>(Func<ValSetter, TEventEmitter> eventEmitterFactory) where TEventEmitter : ValSetter
	{
		return WithEventEmitter(eventEmitterFactory, delegate(ReponseSetter<ValSetter> w)
		{
			w.OnTop();
		});
	}

	public PublisherWriter WithEventEmitter<TEventEmitter>(Func<ValSetter, TEventEmitter> eventEmitterFactory, Action<ReponseSetter<ValSetter>> where) where TEventEmitter : ValSetter
	{
		_003C_003Ec__DisplayClass19_0<TEventEmitter> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass19_0<TEventEmitter>();
		CS_0024_003C_003E8__locals3.eventEmitterFactory = eventEmitterFactory;
		if (CS_0024_003C_003E8__locals3.eventEmitterFactory == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x4C23C86A ^ 0x4C239512));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(--1182565251 ^ 0x467CD647));
		}
		where(filterWriter.CreateRegistrationLocationSelector(typeof(TEventEmitter), (ValSetter inner) => CS_0024_003C_003E8__locals3.eventEmitterFactory(inner)));
		return Self;
	}

	public PublisherWriter WithEventEmitter<TEventEmitter>(ComparatorSetter<ValSetter, ValSetter, TEventEmitter> eventEmitterFactory, Action<ProxySetter<ValSetter>> where) where TEventEmitter : ValSetter
	{
		_003C_003Ec__DisplayClass20_0<TEventEmitter> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass20_0<TEventEmitter>();
		CS_0024_003C_003E8__locals3.eventEmitterFactory = eventEmitterFactory;
		if (CS_0024_003C_003E8__locals3.eventEmitterFactory == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-228218718 ^ -228198950));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-598551743 ^ -598571387));
		}
		where(filterWriter.CreateTrackingRegistrationLocationSelector(typeof(TEventEmitter), (ValSetter wrapped, ValSetter inner) => CS_0024_003C_003E8__locals3.eventEmitterFactory(wrapped, inner)));
		return Self;
	}

	public PublisherWriter WithoutEventEmitter<TEventEmitter>() where TEventEmitter : ValSetter
	{
		return WithoutEventEmitter(typeof(TEventEmitter));
	}

	public PublisherWriter WithoutEventEmitter(Type eventEmitterType)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return this;
			case 2:
				if (eventEmitterType == null)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 == 0)
					{
						num2 = 1;
					}
					break;
				}
				filterWriter.Remove(eventEmitterType);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 == 0)
				{
					num2 = 0;
				}
				break;
			case 1:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-290181924 ^ -290164354));
			}
		}
	}

	public override PublisherWriter WithTagMapping(RoleSingleton tag, Type type)
	{
		int num = 3;
		int num2 = num;
		RoleSingleton value = default(RoleSingleton);
		while (true)
		{
			switch (num2)
			{
			default:
				throw new ArgumentException(string.Format(DicSingleton.gE3WbyDVW(-32257720 ^ -32271218), value, type.FullName), DicSingleton.gE3WbyDVW(-736996892 ^ -737015944));
			case 1:
				return this;
			case 2:
				throw new ArgumentException(DicSingleton.gE3WbyDVW(-1741204886 ^ -1741224544));
			case 3:
				if (!tag.IsEmpty)
				{
					if (!(type == null))
					{
						num2 = 5;
						break;
					}
					goto case 4;
				}
				num2 = 2;
				break;
			case 4:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-108820061 ^ -108798145));
			case 5:
				if (!m_ReaderWriter.TryGetValue(type, out value))
				{
					m_ReaderWriter.Add(type, tag);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 != 0)
					{
						num2 = 1;
					}
				}
				else
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 == 0)
					{
						num2 = 0;
					}
				}
				break;
			}
		}
	}

	public PublisherWriter WithoutTagMapping(Type type)
	{
		int num = 4;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 4:
				if (!(type == null))
				{
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 2;
			case 2:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1053593978 ^ -1053607910));
			case 3:
				if (m_ReaderWriter.Remove(type))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba == 0)
					{
						num2 = 1;
					}
					break;
				}
				goto default;
			default:
				throw new KeyNotFoundException(DicSingleton.gE3WbyDVW(0x69B67B3A ^ 0x69B6250C) + type.FullName + DicSingleton.gE3WbyDVW(-823738529 ^ -823729911));
			case 1:
				return this;
			}
		}
	}

	public PublisherWriter EnsureRoundtrip()
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				m_BaseWriter = (AdvisorSetter typeInspector, ConnectionSetter typeResolver, IEnumerable<StrategySetter> typeConverters, int maximumRecursion) => new AttributeAuthentication(typeConverters, typeInspector, typeResolver, maximumRecursion, invocationSetter, _RuleSetter, factoryWriter);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 == 0)
				{
					num2 = 0;
				}
				break;
			case 1:
				WithEventEmitter((ValSetter inner) => new TokenizerAuthentication(inner, requireTagWhenStaticAndActualTypesAreDifferent: true, m_ReaderWriter, attributeWriter, m_InterpreterWriter, _AuthenticationWriter, _SerializerSetter), delegate(ReponseSetter<ValSetter> loc)
				{
					loc.InsteadOf<TokenizerAuthentication>();
				});
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return WithTypeInspector((AdvisorSetter inner) => new ParserInvocation(inner), delegate(ReponseSetter<AdvisorSetter> loc)
				{
					loc.OnBottom();
				});
			}
		}
	}

	public PublisherWriter DisableAliases()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				return this;
			default:
				interceptorWriter.Remove(typeof(TokenizerInvocation));
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_35cf05af90cc4195a86c9ffc19bf78eb == 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				m_PrototypeWriter.Remove(typeof(DispatcherInvocation));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3ac5d604ebd547e7ac5b1603a0e85187 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	[Obsolete("The default behavior is now to always emit default values, thefore calling this method has no effect. This behavior is now controlled by ConfigureDefaultValuesHandling.", true)]
	public PublisherWriter EmitDefaults()
	{
		return ConfigureDefaultValuesHandling((SchemaItemPropertyIndexes)0);
	}

	public PublisherWriter ConfigureDefaultValuesHandling(SchemaItemPropertyIndexes configuration)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return this;
			case 1:
				_InvocationWriter = configuration;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public PublisherWriter JsonCompatible()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				_WriterWriter = _WriterWriter.WithMaxSimpleKeyLength(int.MaxValue).WithoutAnchorName();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return WithTypeConverter(new PrototypeAttribute(jsonCompatible: true), delegate(ReponseSetter<StrategySetter> w)
				{
					w.InsteadOf<PrototypeAttribute>();
				}).WithTypeConverter(new PropertyAuthentication(DateTimeKind.Utc, null, true)).WithEventEmitter((ValSetter inner) => new CollectionAuthentication(inner, _SerializerSetter), delegate(ReponseSetter<ValSetter> loc)
				{
					loc.InsteadOf<TokenizerAuthentication>();
				});
			}
		}
	}

	public PublisherWriter WithNewLine(string newLine)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				_WriterWriter = _WriterWriter.WithNewLine(newLine);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 != 0)
				{
					num2 = 0;
				}
				break;
			default:
				return this;
			}
		}
	}

	public PublisherWriter WithPreProcessingPhaseObjectGraphVisitor<TObjectGraphVisitor>(TObjectGraphVisitor objectGraphVisitor) where TObjectGraphVisitor : ErrorSetter<MappingSetter>
	{
		return WithPreProcessingPhaseObjectGraphVisitor(objectGraphVisitor, delegate(ReponseSetter<ErrorSetter<MappingSetter>> w)
		{
			w.OnTop();
		});
	}

	public PublisherWriter WithPreProcessingPhaseObjectGraphVisitor<TObjectGraphVisitor>(TObjectGraphVisitor objectGraphVisitor, Action<ReponseSetter<ErrorSetter<MappingSetter>>> where) where TObjectGraphVisitor : ErrorSetter<MappingSetter>
	{
		_003C_003Ec__DisplayClass32_0<TObjectGraphVisitor> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass32_0<TObjectGraphVisitor>();
		CS_0024_003C_003E8__locals3.objectGraphVisitor = objectGraphVisitor;
		if (CS_0024_003C_003E8__locals3.objectGraphVisitor == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x9000142 ^ 0x9005FC2));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1829625923 ^ -1829614983));
		}
		where(m_PrototypeWriter.CreateRegistrationLocationSelector(typeof(TObjectGraphVisitor), (IEnumerable<StrategySetter> _) => CS_0024_003C_003E8__locals3.objectGraphVisitor));
		return this;
	}

	public PublisherWriter WithPreProcessingPhaseObjectGraphVisitor<TObjectGraphVisitor>(ProducerSetter<ErrorSetter<MappingSetter>, TObjectGraphVisitor> objectGraphVisitorFactory, Action<ProxySetter<ErrorSetter<MappingSetter>>> where) where TObjectGraphVisitor : ErrorSetter<MappingSetter>
	{
		_003C_003Ec__DisplayClass33_0<TObjectGraphVisitor> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass33_0<TObjectGraphVisitor>();
		CS_0024_003C_003E8__locals3.objectGraphVisitorFactory = objectGraphVisitorFactory;
		if (CS_0024_003C_003E8__locals3.objectGraphVisitorFactory == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x7A125A0E ^ 0x7A1204A6));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1389846755 ^ -1389835559));
		}
		where(m_PrototypeWriter.CreateTrackingRegistrationLocationSelector(typeof(TObjectGraphVisitor), (ErrorSetter<MappingSetter> wrapped, IEnumerable<StrategySetter> _) => CS_0024_003C_003E8__locals3.objectGraphVisitorFactory(wrapped)));
		return this;
	}

	public PublisherWriter WithoutPreProcessingPhaseObjectGraphVisitor<TObjectGraphVisitor>() where TObjectGraphVisitor : ErrorSetter<MappingSetter>
	{
		return WithoutPreProcessingPhaseObjectGraphVisitor(typeof(TObjectGraphVisitor));
	}

	public PublisherWriter WithoutPreProcessingPhaseObjectGraphVisitor(Type objectGraphVisitorType)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x44072FB7 ^ 0x44077169));
			default:
				m_PrototypeWriter.Remove(objectGraphVisitorType);
				num2 = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 != 0)
				{
					num2 = 2;
				}
				break;
			case 1:
				if (!(objectGraphVisitorType == null))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 != 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 2;
			case 3:
				return this;
			}
		}
	}

	public PublisherWriter WithObjectGraphTraversalStrategyFactory(PropertySetter objectGraphTraversalStrategyFactory)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				m_BaseWriter = objectGraphTraversalStrategyFactory;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f != 0)
				{
					num2 = 0;
				}
				break;
			default:
				return this;
			}
		}
	}

	public PublisherWriter WithEmissionPhaseObjectGraphVisitor<TObjectGraphVisitor>(Func<ValueSetter, TObjectGraphVisitor> objectGraphVisitorFactory) where TObjectGraphVisitor : ErrorSetter<MockInterpreter>
	{
		return WithEmissionPhaseObjectGraphVisitor(objectGraphVisitorFactory, delegate(ReponseSetter<ErrorSetter<MockInterpreter>> w)
		{
			w.OnTop();
		});
	}

	public PublisherWriter WithEmissionPhaseObjectGraphVisitor<TObjectGraphVisitor>(Func<ValueSetter, TObjectGraphVisitor> objectGraphVisitorFactory, Action<ReponseSetter<ErrorSetter<MockInterpreter>>> where) where TObjectGraphVisitor : ErrorSetter<MockInterpreter>
	{
		_003C_003Ec__DisplayClass38_0<TObjectGraphVisitor> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass38_0<TObjectGraphVisitor>();
		CS_0024_003C_003E8__locals3.objectGraphVisitorFactory = objectGraphVisitorFactory;
		if (CS_0024_003C_003E8__locals3.objectGraphVisitorFactory == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x765D303 ^ 0x7658DAB));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0xB967DC8 ^ 0xB96280C));
		}
		where(interceptorWriter.CreateRegistrationLocationSelector(typeof(TObjectGraphVisitor), (ValueSetter args) => CS_0024_003C_003E8__locals3.objectGraphVisitorFactory(args)));
		return this;
	}

	public PublisherWriter WithEmissionPhaseObjectGraphVisitor<TObjectGraphVisitor>(ComparatorSetter<ValueSetter, ErrorSetter<MockInterpreter>, TObjectGraphVisitor> objectGraphVisitorFactory, Action<ProxySetter<ErrorSetter<MockInterpreter>>> where) where TObjectGraphVisitor : ErrorSetter<MockInterpreter>
	{
		_003C_003Ec__DisplayClass39_0<TObjectGraphVisitor> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass39_0<TObjectGraphVisitor>();
		CS_0024_003C_003E8__locals3.objectGraphVisitorFactory = objectGraphVisitorFactory;
		if (CS_0024_003C_003E8__locals3.objectGraphVisitorFactory == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x7B291245 ^ 0x7B294CED));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1053593978 ^ -1053607102));
		}
		where(interceptorWriter.CreateTrackingRegistrationLocationSelector(typeof(TObjectGraphVisitor), (ErrorSetter<MockInterpreter> wrapped, ValueSetter args) => CS_0024_003C_003E8__locals3.objectGraphVisitorFactory(wrapped, args)));
		return this;
	}

	public PublisherWriter WithoutEmissionPhaseObjectGraphVisitor<TObjectGraphVisitor>() where TObjectGraphVisitor : ErrorSetter<MockInterpreter>
	{
		return WithoutEmissionPhaseObjectGraphVisitor(typeof(TObjectGraphVisitor));
	}

	public PublisherWriter WithoutEmissionPhaseObjectGraphVisitor(Type objectGraphVisitorType)
	{
		int num = 1;
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 1:
					if (!(objectGraphVisitorType == null))
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea != 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 2;
				case 2:
					throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-490894496 ^ -490875458));
				case 3:
					return this;
				}
				break;
			}
			interceptorWriter.Remove(objectGraphVisitorType);
			num = 3;
		}
	}

	public PublisherWriter WithIndentedSequences()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return this;
			case 1:
				_WriterWriter = _WriterWriter.WithIndentedSequences();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3ac5d604ebd547e7ac5b1603a0e85187 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public ModelSetter Build()
	{
		return AdapterSetter.FromValueSerializer(BuildValueSerializer(), _WriterWriter);
	}

	public RepositorySetter BuildValueSerializer()
	{
		int num = 1;
		int num2 = num;
		AdvisorSetter typeInspector = default(AdvisorSetter);
		IEnumerable<StrategySetter> typeConverters = default(IEnumerable<StrategySetter>);
		while (true)
		{
			switch (num2)
			{
			case 2:
			{
				DatabaseSetter traversalStrategy = m_BaseWriter(typeInspector, m_AuthenticationSetter, typeConverters, m_SetterWriter);
				ValSetter eventEmitter = filterWriter.BuildComponentChain(new ConsumerAuthentication());
				return new SingletonWriter(traversalStrategy, eventEmitter, typeConverters, m_PrototypeWriter.Clone(), interceptorWriter.Clone());
			}
			case 1:
				typeConverters = BuildTypeConverters();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 != 0)
				{
					num2 = 0;
				}
				break;
			default:
				typeInspector = BuildTypeInspector();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 == 0)
				{
					num2 = 2;
				}
				break;
			}
		}
	}

	internal AdvisorSetter BuildTypeInspector()
	{
		int num = 1;
		int num2 = num;
		AdvisorSetter advisorSetter = default(AdvisorSetter);
		while (true)
		{
			switch (num2)
			{
			case 2:
				advisorSetter = new BroadcasterInvocation(new EventInvocation(m_AuthenticationSetter), advisorSetter);
				num2 = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				if (issuerSetter)
				{
					num2 = 4;
					break;
				}
				goto case 2;
			case 1:
				advisorSetter = new BridgeInvocation(m_AuthenticationSetter, fieldSetter);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 == 0)
				{
					num2 = 0;
				}
				break;
			case 3:
			case 4:
				return m_SingletonSetter.BuildComponentChain(advisorSetter);
			}
		}
	}

	internal static bool InstantiateStatus()
	{
		return AwakeStatus == null;
	}

	internal static PublisherWriter LoginStatus()
	{
		return AwakeStatus;
	}
}
