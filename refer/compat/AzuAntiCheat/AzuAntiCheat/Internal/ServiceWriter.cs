using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class ServiceWriter : MockWriter<ServiceWriter>
{
	private class ImporterWriter : RepositorySetter
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass6_0
		{
			public ImporterWriter m_ReponseWriter;

			public MockInterpreter proxyWriter;

			public List<ErrorSetter<MappingSetter>> modelWriter;

			private static _003C_003Ec__DisplayClass6_0 CollectBridge;

			public _003C_003Ec__DisplayClass6_0()
			{
				GetterIssuer.DeleteInitializer();
				base._002Ector();
				int num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 == 0)
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
				return new ValueSetter(inner, m_ReponseWriter.m_PrinterWriter, modelWriter, m_ReponseWriter.m_DatabaseWriter, NestedObjectSerializer);
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
							m_ReponseWriter.SerializeValue(proxyWriter, v, t);
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec == 0)
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

			internal static bool ManageBridge()
			{
				return CollectBridge == null;
			}

			internal static _003C_003Ec__DisplayClass6_0 ForgotBridge()
			{
				return CollectBridge;
			}
		}

		private readonly DatabaseSetter m_CreatorWriter;

		private readonly ValSetter m_PrinterWriter;

		private readonly IEnumerable<StrategySetter> m_DatabaseWriter;

		private readonly ProcessorSetter<IEnumerable<StrategySetter>, ErrorSetter<MappingSetter>> m_ErrorWriter;

		private readonly ProcessorSetter<ValueSetter, ErrorSetter<MockInterpreter>> regWriter;

		private static ImporterWriter CustomizeBridge;

		public ImporterWriter(DatabaseSetter traversalStrategy, ValSetter eventEmitter, IEnumerable<StrategySetter> typeConverters, ProcessorSetter<IEnumerable<StrategySetter>, ErrorSetter<MappingSetter>> preProcessingPhaseObjectGraphVisitorFactories, ProcessorSetter<ValueSetter, ErrorSetter<MockInterpreter>> emissionPhaseObjectGraphVisitorFactories)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			m_CreatorWriter = traversalStrategy;
			m_PrinterWriter = eventEmitter;
			m_DatabaseWriter = typeConverters;
			m_ErrorWriter = preProcessingPhaseObjectGraphVisitorFactories;
			regWriter = emissionPhaseObjectGraphVisitorFactories;
		}

		public void SerializeValue(MockInterpreter emitter, object? value, Type? type)
		{
			_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass6_0();
			CS_0024_003C_003E8__locals10.m_ReponseWriter = this;
			CS_0024_003C_003E8__locals10.proxyWriter = emitter;
			Type type2 = type ?? ((value != null) ? value.GetType() : typeof(object));
			Type staticType = type ?? typeof(object);
			SchemaSetter graph = new SchemaSetter(value, type2, staticType);
			CS_0024_003C_003E8__locals10.modelWriter = m_ErrorWriter.BuildComponentList(m_DatabaseWriter);
			foreach (ErrorSetter<MappingSetter> item in CS_0024_003C_003E8__locals10.modelWriter)
			{
				m_CreatorWriter.Traverse(graph, item, default(MappingSetter));
			}
			ErrorSetter<MockInterpreter> visitor = regWriter.BuildComponentChain<ValueSetter, ErrorSetter<MockInterpreter>>(new AdapterInvocation(m_PrinterWriter), (ErrorSetter<MockInterpreter> inner) => new ValueSetter(inner, CS_0024_003C_003E8__locals10.m_ReponseWriter.m_PrinterWriter, CS_0024_003C_003E8__locals10.modelWriter, CS_0024_003C_003E8__locals10.m_ReponseWriter.m_DatabaseWriter, NestedObjectSerializer));
			m_CreatorWriter.Traverse(graph, visitor, CS_0024_003C_003E8__locals10.proxyWriter);
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
						CS_0024_003C_003E8__locals10.m_ReponseWriter.SerializeValue(CS_0024_003C_003E8__locals10.proxyWriter, v, t);
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec == 0)
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

		internal static bool CancelBridge()
		{
			return CustomizeBridge == null;
		}

		internal static ImporterWriter ReflectBridge()
		{
			return CustomizeBridge;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass21_0<TEventEmitter> where TEventEmitter : notnull, ValSetter
	{
		public Func<ValSetter, TEventEmitter> eventEmitterFactory;

		internal static object TestOrder;

		public _003C_003Ec__DisplayClass21_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 == 0)
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

		internal static bool RunOrder()
		{
			return TestOrder == null;
		}

		internal static object VerifyOrder()
		{
			return TestOrder;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass22_0<TEventEmitter> where TEventEmitter : notnull, ValSetter
	{
		public ComparatorSetter<ValSetter, ValSetter, TEventEmitter> eventEmitterFactory;

		private static object PopOrder;

		public _003C_003Ec__DisplayClass22_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 == 0)
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

		internal static bool PostOrder()
		{
			return PopOrder == null;
		}

		internal static object CallOrder()
		{
			return PopOrder;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass34_0<TObjectGraphVisitor> where TObjectGraphVisitor : notnull, ErrorSetter<MappingSetter>
	{
		public TObjectGraphVisitor objectGraphVisitor;

		internal static object ConcatOrder;

		public _003C_003Ec__DisplayClass34_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f != 0)
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

		internal static bool MapOrder()
		{
			return ConcatOrder == null;
		}

		internal static object NewOrder()
		{
			return ConcatOrder;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass35_0<TObjectGraphVisitor> where TObjectGraphVisitor : notnull, ErrorSetter<MappingSetter>
	{
		public ProducerSetter<ErrorSetter<MappingSetter>, TObjectGraphVisitor> objectGraphVisitorFactory;

		internal static object AddOrder;

		public _003C_003Ec__DisplayClass35_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4e61b266153f422fa6c595cfef4d40d3 != 0)
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

		internal static bool PrepareOrder()
		{
			return AddOrder == null;
		}

		internal static object WriteOrder()
		{
			return AddOrder;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass40_0<TObjectGraphVisitor> where TObjectGraphVisitor : notnull, ErrorSetter<MockInterpreter>
	{
		public Func<ValueSetter, TObjectGraphVisitor> objectGraphVisitorFactory;

		private static object PrintOrder;

		public _003C_003Ec__DisplayClass40_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 != 0)
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

		internal static bool CompareOrder()
		{
			return PrintOrder == null;
		}

		internal static object CloneOrder()
		{
			return PrintOrder;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass41_0<TObjectGraphVisitor> where TObjectGraphVisitor : notnull, ErrorSetter<MockInterpreter>
	{
		public ComparatorSetter<ValueSetter, ErrorSetter<MockInterpreter>, TObjectGraphVisitor> objectGraphVisitorFactory;

		private static object ReadOrder;

		public _003C_003Ec__DisplayClass41_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd == 0)
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

		internal static bool ViewOrder()
		{
			return ReadOrder == null;
		}

		internal static object InitOrder()
		{
			return ReadOrder;
		}
	}

	private readonly CandidateWriter _BridgeWriter;

	private readonly MapAuthentication _ParameterWriter;

	private PropertySetter m_StatusWriter;

	private readonly ProcessorSetter<IEnumerable<StrategySetter>, ErrorSetter<MappingSetter>> merchantWriter;

	private readonly ProcessorSetter<ValueSetter, ErrorSetter<MockInterpreter>> m_TestWriter;

	private readonly ProcessorSetter<ValSetter, ValSetter> m_AttrWriter;

	private readonly IDictionary<Type, RoleSingleton> messageWriter;

	private int m_ExporterWriter;

	private ExceptionInterpreter _ValWriter;

	private SchemaItemPropertyIndexes _ConfigWriter;

	private bool m_WrapperWriter;

	private bool serverWriter;

	private ConnectionInterpreter algoWriter;

	internal static ServiceWriter CheckBridge;

	protected override ServiceWriter Self => this;

	public ServiceWriter(CandidateWriter context)
	{
		GetterIssuer.DeleteInitializer();
		messageWriter = new Dictionary<Type, RoleSingleton>();
		m_ExporterWriter = 50;
		_ValWriter = ExceptionInterpreter.m_GetterInterpreter;
		base._002Ector((ConnectionSetter)new CandidateInvocation());
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 3:
				return;
			default:
				_BridgeWriter = context;
				num = 8;
				break;
			case 2:
				_WatcherWriter.Add(typeof(TestsInvocation), delegate(AdvisorSetter inner)
				{
					int num2 = 3;
					int num3 = num2;
					AdvisorSetter result = default(AdvisorSetter);
					while (true)
					{
						switch (num3)
						{
						case 3:
							if (m_MethodWriter is InfoAuthentication)
							{
								num3 = 2;
								break;
							}
							goto default;
						default:
							result = new TestsInvocation(inner, m_MethodWriter);
							num3 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 == 0)
							{
								num3 = 1;
							}
							break;
						case 1:
							return result;
						case 2:
							return inner;
						}
					}
				});
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 != 0)
				{
					num = 1;
				}
				break;
			case 8:
				_ParameterWriter = context.GetFactory();
				num = 4;
				break;
			case 5:
				m_StatusWriter = (AdvisorSetter typeInspector, ConnectionSetter typeResolver, IEnumerable<StrategySetter> typeConverters, int maximumRecursion) => new PrototypeAuthentication(typeInspector, typeResolver, maximumRecursion, m_MethodWriter, _ParameterWriter);
				num = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 == 0)
				{
					num = 3;
				}
				break;
			case 9:
				m_AttrWriter = new ProcessorSetter<ValSetter, ValSetter> { 
				{
					typeof(TokenizerAuthentication),
					(ValSetter inner) => new TokenizerAuthentication(inner, requireTagWhenStaticAndActualTypesAreDifferent: false, messageWriter, m_WrapperWriter, serverWriter, algoWriter, m_ResolverWriter)
				} };
				num = 5;
				break;
			case 4:
				_WatcherWriter.Add(typeof(ProductInvocation), (AdvisorSetter inner) => new ProductInvocation(inner));
				num = 2;
				break;
			case 1:
				_WatcherWriter.Add(typeof(SpecificationWriter), (AdvisorSetter inner) => new SpecificationWriter(inner));
				num = 7;
				break;
			case 7:
				merchantWriter = new ProcessorSetter<IEnumerable<StrategySetter>, ErrorSetter<MappingSetter>> { 
				{
					typeof(DispatcherInvocation),
					(IEnumerable<StrategySetter> typeConverters) => new DispatcherInvocation(typeConverters)
				} };
				num = 6;
				break;
			case 6:
				m_TestWriter = new ProcessorSetter<ValueSetter, ErrorSetter<MockInterpreter>>
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
						(ValueSetter args) => new SpecificationInvocation(_ConfigWriter, args.InnerVisitor, _ParameterWriter)
					},
					{
						typeof(StructInvocation),
						(ValueSetter args) => new StructInvocation(args.InnerVisitor)
					}
				};
				num = 9;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 == 0)
				{
					num = 1;
				}
				break;
			}
		}
	}

	public ServiceWriter WithQuotingNecessaryStrings(bool quoteYaml1_1Strings = false)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				serverWriter = quoteYaml1_1Strings;
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 == 0)
				{
					num2 = 0;
				}
				break;
			case 1:
				m_WrapperWriter = true;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 != 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				return this;
			}
		}
	}

	public ServiceWriter WithQuotingNecessaryStrings()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				m_WrapperWriter = true;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return this;
			}
		}
	}

	public ServiceWriter WithDefaultScalarStyle(ConnectionInterpreter style)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				algoWriter = style;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return this;
			}
		}
	}

	public ServiceWriter WithMaximumRecursion(int maximumRecursion)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				if (maximumRecursion <= 0)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 == 0)
					{
						num2 = 1;
					}
					break;
				}
				m_ExporterWriter = maximumRecursion;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return this;
			case 1:
				throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(0x3FCF6129 ^ 0x3FCF3D85), string.Format(DicSingleton.gE3WbyDVW(-65056140 ^ -65073500), maximumRecursion));
			}
		}
	}

	public ServiceWriter WithEventEmitter<TEventEmitter>(Func<ValSetter, TEventEmitter> eventEmitterFactory) where TEventEmitter : ValSetter
	{
		return WithEventEmitter(eventEmitterFactory, delegate(ReponseSetter<ValSetter> w)
		{
			w.OnTop();
		});
	}

	public ServiceWriter WithEventEmitter<TEventEmitter>(Func<ValSetter, TEventEmitter> eventEmitterFactory, Action<ReponseSetter<ValSetter>> where) where TEventEmitter : ValSetter
	{
		_003C_003Ec__DisplayClass21_0<TEventEmitter> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass21_0<TEventEmitter>();
		CS_0024_003C_003E8__locals3.eventEmitterFactory = eventEmitterFactory;
		if (CS_0024_003C_003E8__locals3.eventEmitterFactory == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-228218718 ^ -228198950));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1773869960 ^ -1773882948));
		}
		where(m_AttrWriter.CreateRegistrationLocationSelector(typeof(TEventEmitter), (ValSetter inner) => CS_0024_003C_003E8__locals3.eventEmitterFactory(inner)));
		return Self;
	}

	public ServiceWriter WithEventEmitter<TEventEmitter>(ComparatorSetter<ValSetter, ValSetter, TEventEmitter> eventEmitterFactory, Action<ProxySetter<ValSetter>> where) where TEventEmitter : ValSetter
	{
		_003C_003Ec__DisplayClass22_0<TEventEmitter> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass22_0<TEventEmitter>();
		CS_0024_003C_003E8__locals3.eventEmitterFactory = eventEmitterFactory;
		if (CS_0024_003C_003E8__locals3.eventEmitterFactory == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0xB967DC8 ^ 0xB9620B0));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x9000142 ^ 0x9005486));
		}
		where(m_AttrWriter.CreateTrackingRegistrationLocationSelector(typeof(TEventEmitter), (ValSetter wrapped, ValSetter inner) => CS_0024_003C_003E8__locals3.eventEmitterFactory(wrapped, inner)));
		return Self;
	}

	public ServiceWriter WithoutEventEmitter<TEventEmitter>() where TEventEmitter : ValSetter
	{
		return WithoutEventEmitter(typeof(TEventEmitter));
	}

	public ServiceWriter WithoutEventEmitter(Type eventEmitterType)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				if (eventEmitterType == null)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
					{
						num2 = 0;
					}
					break;
				}
				m_AttrWriter.Remove(eventEmitterType);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return this;
			case 1:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-614239580 ^ -614256890));
			}
		}
	}

	public override ServiceWriter WithTagMapping(RoleSingleton tag, Type type)
	{
		int num = 6;
		int num2 = num;
		RoleSingleton value = default(RoleSingleton);
		while (true)
		{
			switch (num2)
			{
			case 1:
				throw new ArgumentException(string.Format(DicSingleton.gE3WbyDVW(-1741204886 ^ -1741221972), value, type.FullName), DicSingleton.gE3WbyDVW(0x166FBD ^ 0x163921));
			default:
				messageWriter.Add(type, tag);
				num2 = 4;
				break;
			case 5:
				throw new ArgumentException(DicSingleton.gE3WbyDVW(0x1C779450 ^ 0x1C77C39A));
			case 2:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1180565667 ^ -1180587583));
			case 3:
				if (!messageWriter.TryGetValue(type, out value))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 != 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 1;
			case 4:
				return this;
			case 6:
				if (!tag.IsEmpty)
				{
					if (!(type == null))
					{
						num2 = 3;
						break;
					}
					goto case 2;
				}
				num2 = 5;
				break;
			}
		}
	}

	public ServiceWriter WithoutTagMapping(Type type)
	{
		int num = 3;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				throw new KeyNotFoundException(DicSingleton.gE3WbyDVW(-1385030784 ^ -1385019978) + type.FullName + DicSingleton.gE3WbyDVW(-381685266 ^ -381702216));
			case 3:
				if (!(type == null))
				{
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c != 0)
					{
						num2 = 2;
					}
					break;
				}
				goto default;
			default:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1977574774 ^ -1977562090));
			case 2:
				if (messageWriter.Remove(type))
				{
					return this;
				}
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a == 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	public ServiceWriter EnsureRoundtrip()
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				m_StatusWriter = (AdvisorSetter typeInspector, ConnectionSetter typeResolver, IEnumerable<StrategySetter> typeConverters, int maximumRecursion) => new AttributeAuthentication(typeConverters, typeInspector, typeResolver, maximumRecursion, m_MethodWriter, m_SystemWriter, _ParameterWriter);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f == 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				WithEventEmitter((ValSetter inner) => new TokenizerAuthentication(inner, requireTagWhenStaticAndActualTypesAreDifferent: true, messageWriter, m_WrapperWriter), delegate(ReponseSetter<ValSetter> loc)
				{
					loc.InsteadOf<TokenizerAuthentication>();
				});
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 == 0)
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

	public ServiceWriter DisableAliases()
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				merchantWriter.Remove(typeof(DispatcherInvocation));
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 != 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				m_TestWriter.Remove(typeof(TokenizerInvocation));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a != 0)
				{
					num2 = 0;
				}
				break;
			default:
				return this;
			}
		}
	}

	[Obsolete("The default behavior is now to always emit default values, thefore calling this method has no effect. This behavior is now controlled by ConfigureDefaultValuesHandling.", true)]
	public ServiceWriter EmitDefaults()
	{
		return ConfigureDefaultValuesHandling((SchemaItemPropertyIndexes)0);
	}

	public ServiceWriter ConfigureDefaultValuesHandling(SchemaItemPropertyIndexes configuration)
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
				_ConfigWriter = configuration;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public ServiceWriter JsonCompatible()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				_ValWriter = _ValWriter.WithMaxSimpleKeyLength(int.MaxValue).WithoutAnchorName();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return WithTypeConverter(new PrototypeAttribute(jsonCompatible: true), delegate(ReponseSetter<StrategySetter> w)
				{
					w.InsteadOf<PrototypeAttribute>();
				}).WithTypeConverter(new PropertyAuthentication(DateTimeKind.Utc, null, true)).WithEventEmitter((ValSetter inner) => new CollectionAuthentication(inner, m_ResolverWriter), delegate(ReponseSetter<ValSetter> loc)
				{
					loc.InsteadOf<TokenizerAuthentication>();
				});
			}
		}
	}

	public ServiceWriter WithNewLine(string newLine)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				_ValWriter = _ValWriter.WithNewLine(newLine);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return this;
			}
		}
	}

	public ServiceWriter WithPreProcessingPhaseObjectGraphVisitor<TObjectGraphVisitor>(TObjectGraphVisitor objectGraphVisitor) where TObjectGraphVisitor : ErrorSetter<MappingSetter>
	{
		return WithPreProcessingPhaseObjectGraphVisitor(objectGraphVisitor, delegate(ReponseSetter<ErrorSetter<MappingSetter>> w)
		{
			w.OnTop();
		});
	}

	public ServiceWriter WithPreProcessingPhaseObjectGraphVisitor<TObjectGraphVisitor>(TObjectGraphVisitor objectGraphVisitor, Action<ReponseSetter<ErrorSetter<MappingSetter>>> where) where TObjectGraphVisitor : ErrorSetter<MappingSetter>
	{
		_003C_003Ec__DisplayClass34_0<TObjectGraphVisitor> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass34_0<TObjectGraphVisitor>();
		CS_0024_003C_003E8__locals3.objectGraphVisitor = objectGraphVisitor;
		if (CS_0024_003C_003E8__locals3.objectGraphVisitor == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x3353457 ^ 0x3356AD7));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x15823EC4 ^ 0x15826B00));
		}
		where(merchantWriter.CreateRegistrationLocationSelector(typeof(TObjectGraphVisitor), (IEnumerable<StrategySetter> _) => CS_0024_003C_003E8__locals3.objectGraphVisitor));
		return this;
	}

	public ServiceWriter WithPreProcessingPhaseObjectGraphVisitor<TObjectGraphVisitor>(ProducerSetter<ErrorSetter<MappingSetter>, TObjectGraphVisitor> objectGraphVisitorFactory, Action<ProxySetter<ErrorSetter<MappingSetter>>> where) where TObjectGraphVisitor : ErrorSetter<MappingSetter>
	{
		_003C_003Ec__DisplayClass35_0<TObjectGraphVisitor> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass35_0<TObjectGraphVisitor>();
		CS_0024_003C_003E8__locals3.objectGraphVisitorFactory = objectGraphVisitorFactory;
		if (CS_0024_003C_003E8__locals3.objectGraphVisitorFactory == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-428683152 ^ -428699944));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-849667636 ^ -849654776));
		}
		where(merchantWriter.CreateTrackingRegistrationLocationSelector(typeof(TObjectGraphVisitor), (ErrorSetter<MappingSetter> wrapped, IEnumerable<StrategySetter> _) => CS_0024_003C_003E8__locals3.objectGraphVisitorFactory(wrapped)));
		return this;
	}

	public ServiceWriter WithoutPreProcessingPhaseObjectGraphVisitor<TObjectGraphVisitor>() where TObjectGraphVisitor : ErrorSetter<MappingSetter>
	{
		return WithoutPreProcessingPhaseObjectGraphVisitor(typeof(TObjectGraphVisitor));
	}

	public ServiceWriter WithoutPreProcessingPhaseObjectGraphVisitor(Type objectGraphVisitorType)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-166253478 ^ -166235516));
			case 1:
				if (!(objectGraphVisitorType == null))
				{
					merchantWriter.Remove(objectGraphVisitorType);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f == 0)
					{
						num2 = 2;
					}
				}
				else
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb == 0)
					{
						num2 = 0;
					}
				}
				break;
			case 2:
				return this;
			}
		}
	}

	public ServiceWriter WithObjectGraphTraversalStrategyFactory(PropertySetter objectGraphTraversalStrategyFactory)
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
				m_StatusWriter = objectGraphTraversalStrategyFactory;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public ServiceWriter WithEmissionPhaseObjectGraphVisitor<TObjectGraphVisitor>(Func<ValueSetter, TObjectGraphVisitor> objectGraphVisitorFactory) where TObjectGraphVisitor : ErrorSetter<MockInterpreter>
	{
		return WithEmissionPhaseObjectGraphVisitor(objectGraphVisitorFactory, delegate(ReponseSetter<ErrorSetter<MockInterpreter>> w)
		{
			w.OnTop();
		});
	}

	public ServiceWriter WithEmissionPhaseObjectGraphVisitor<TObjectGraphVisitor>(Func<ValueSetter, TObjectGraphVisitor> objectGraphVisitorFactory, Action<ReponseSetter<ErrorSetter<MockInterpreter>>> where) where TObjectGraphVisitor : ErrorSetter<MockInterpreter>
	{
		_003C_003Ec__DisplayClass40_0<TObjectGraphVisitor> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass40_0<TObjectGraphVisitor>();
		CS_0024_003C_003E8__locals3.objectGraphVisitorFactory = objectGraphVisitorFactory;
		if (CS_0024_003C_003E8__locals3.objectGraphVisitorFactory == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x4C23C86A ^ 0x4C2396C2));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-228218718 ^ -228197018));
		}
		where(m_TestWriter.CreateRegistrationLocationSelector(typeof(TObjectGraphVisitor), (ValueSetter args) => CS_0024_003C_003E8__locals3.objectGraphVisitorFactory(args)));
		return this;
	}

	public ServiceWriter WithEmissionPhaseObjectGraphVisitor<TObjectGraphVisitor>(ComparatorSetter<ValueSetter, ErrorSetter<MockInterpreter>, TObjectGraphVisitor> objectGraphVisitorFactory, Action<ProxySetter<ErrorSetter<MockInterpreter>>> where) where TObjectGraphVisitor : ErrorSetter<MockInterpreter>
	{
		_003C_003Ec__DisplayClass41_0<TObjectGraphVisitor> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass41_0<TObjectGraphVisitor>();
		CS_0024_003C_003E8__locals3.objectGraphVisitorFactory = objectGraphVisitorFactory;
		if (CS_0024_003C_003E8__locals3.objectGraphVisitorFactory == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1507873642 ^ -1507855810));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1133601918 ^ -1133588922));
		}
		where(m_TestWriter.CreateTrackingRegistrationLocationSelector(typeof(TObjectGraphVisitor), (ErrorSetter<MockInterpreter> wrapped, ValueSetter args) => CS_0024_003C_003E8__locals3.objectGraphVisitorFactory(wrapped, args)));
		return this;
	}

	public ServiceWriter WithoutEmissionPhaseObjectGraphVisitor<TObjectGraphVisitor>() where TObjectGraphVisitor : ErrorSetter<MockInterpreter>
	{
		return WithoutEmissionPhaseObjectGraphVisitor(typeof(TObjectGraphVisitor));
	}

	public ServiceWriter WithoutEmissionPhaseObjectGraphVisitor(Type objectGraphVisitorType)
	{
		int num = 3;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				return this;
			case 3:
				if (!(objectGraphVisitorType == null))
				{
					num2 = 2;
					break;
				}
				goto default;
			default:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-2103041941 ^ -2103017803));
			case 2:
				m_TestWriter.Remove(objectGraphVisitorType);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 == 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	public ServiceWriter WithIndentedSequences()
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
				_ValWriter = _ValWriter.WithIndentedSequences();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public ModelSetter Build()
	{
		return AdapterSetter.FromValueSerializer(BuildValueSerializer(), _ValWriter);
	}

	public RepositorySetter BuildValueSerializer()
	{
		int num = 1;
		int num2 = num;
		IEnumerable<StrategySetter> typeConverters = default(IEnumerable<StrategySetter>);
		AdvisorSetter typeInspector = default(AdvisorSetter);
		while (true)
		{
			switch (num2)
			{
			case 1:
				typeConverters = BuildTypeConverters();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 == 0)
				{
					num2 = 0;
				}
				break;
			case 2:
			{
				DatabaseSetter traversalStrategy = m_StatusWriter(typeInspector, m_TemplateWriter, typeConverters, m_ExporterWriter);
				ValSetter eventEmitter = m_AttrWriter.BuildComponentChain(new ConsumerAuthentication());
				return new ImporterWriter(traversalStrategy, eventEmitter, typeConverters, merchantWriter.Clone(), m_TestWriter.Clone());
			}
			default:
				typeInspector = BuildTypeInspector();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 == 0)
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
		AdvisorSetter typeInspector = default(AdvisorSetter);
		while (true)
		{
			switch (num2)
			{
			default:
				return _WatcherWriter.BuildComponentChain(typeInspector);
			case 1:
				typeInspector = _BridgeWriter.GetTypeInspector();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_91887e48b8104e7da08b48f73b607337 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool RateBridge()
	{
		return CheckBridge == null;
	}

	internal static ServiceWriter ResetBridge()
	{
		return CheckBridge;
	}
}
