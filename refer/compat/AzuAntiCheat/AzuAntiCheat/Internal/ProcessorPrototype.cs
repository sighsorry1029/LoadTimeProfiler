using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1 })]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class ProcessorPrototype : ThreadBase<ProcessorPrototype>
{
	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
	private class CollectionPrototype : ClientPrototype
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass6_0
		{
			[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
			public CollectionPrototype mappingPrototype;

			[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
			public ModelReader schemaPrototype;

			[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
			public List<ParserPrototype<RegPrototype>> _StructPrototype;

			internal static _003C_003Ec__DisplayClass6_0 RateRole;

			public _003C_003Ec__DisplayClass6_0()
			{
				GetterIssuer.DeleteInitializer();
				base._002Ector();
				int num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7e7ae6cc25e34646baea4e1c2c087e7a == 0)
				{
					num = 0;
				}
				switch (num)
				{
				case 0:
					break;
				}
			}

			[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)]
			internal ComposerPrototype _003CSerializeValue_003Eb__1(ParserPrototype<ModelReader> inner)
			{
				return new ComposerPrototype(inner, mappingPrototype.tokenizerPrototype, _StructPrototype, mappingPrototype.m_ListenerPrototype, NestedObjectSerializer);
				[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
				void NestedObjectSerializer(object v, Type t)
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
							mappingPrototype.SerializeValue(schemaPrototype, v, t);
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 == 0)
							{
								num2 = 0;
							}
							break;
						}
					}
				}
			}

			internal static bool ResetRole()
			{
				return RateRole == null;
			}

			internal static _003C_003Ec__DisplayClass6_0 CustomizeRole()
			{
				return RateRole;
			}
		}

		private readonly PagePrototype m_ManagerPrototype;

		private readonly DecoratorPrototype tokenizerPrototype;

		private readonly IEnumerable<StatusPrototype> m_ListenerPrototype;

		private readonly MerchantPrototype<IEnumerable<StatusPrototype>, ParserPrototype<RegPrototype>> m_AccountPrototype;

		private readonly MerchantPrototype<ComposerPrototype, ParserPrototype<ModelReader>> m_ThreadPrototype;

		internal static CollectionPrototype DefineRole;

		public CollectionPrototype(PagePrototype traversalStrategy, DecoratorPrototype eventEmitter, IEnumerable<StatusPrototype> typeConverters, MerchantPrototype<IEnumerable<StatusPrototype>, ParserPrototype<RegPrototype>> preProcessingPhaseObjectGraphVisitorFactories, MerchantPrototype<ComposerPrototype, ParserPrototype<ModelReader>> emissionPhaseObjectGraphVisitorFactories)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			m_ManagerPrototype = traversalStrategy;
			tokenizerPrototype = eventEmitter;
			m_ListenerPrototype = typeConverters;
			m_AccountPrototype = preProcessingPhaseObjectGraphVisitorFactories;
			m_ThreadPrototype = emissionPhaseObjectGraphVisitorFactories;
		}

		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
		public void SerializeValue([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(1)] ModelReader emitter, object value, Type type)
		{
			_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass6_0();
			CS_0024_003C_003E8__locals10.mappingPrototype = this;
			CS_0024_003C_003E8__locals10.schemaPrototype = emitter;
			Type type2 = type ?? ((value != null) ? value.GetType() : typeof(object));
			Type staticType = type ?? typeof(object);
			ReponsePrototype graph = new ReponsePrototype(value, type2, staticType);
			CS_0024_003C_003E8__locals10._StructPrototype = m_AccountPrototype.BuildComponentList(m_ListenerPrototype);
			foreach (ParserPrototype<RegPrototype> item in CS_0024_003C_003E8__locals10._StructPrototype)
			{
				m_ManagerPrototype.Traverse(graph, item, default(RegPrototype));
			}
			ParserPrototype<ModelReader> visitor = m_ThreadPrototype.BuildComponentChain(new InvocationFilter(tokenizerPrototype), [_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)] (ParserPrototype<ModelReader> inner) => new ComposerPrototype(inner, CS_0024_003C_003E8__locals10.mappingPrototype.tokenizerPrototype, CS_0024_003C_003E8__locals10._StructPrototype, CS_0024_003C_003E8__locals10.mappingPrototype.m_ListenerPrototype, NestedObjectSerializer));
			m_ManagerPrototype.Traverse(graph, visitor, CS_0024_003C_003E8__locals10.schemaPrototype);
			[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
			void NestedObjectSerializer(object v, Type t)
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
						CS_0024_003C_003E8__locals10.mappingPrototype.SerializeValue(CS_0024_003C_003E8__locals10.schemaPrototype, v, t);
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 == 0)
						{
							num2 = 0;
						}
						break;
					}
				}
			}
		}

		internal static bool IncludeRole()
		{
			return DefineRole == null;
		}

		internal static CollectionPrototype CheckRole()
		{
			return DefineRole;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_0<TEventEmitter> where TEventEmitter : DecoratorPrototype
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1, 0 })]
		public Func<DecoratorPrototype, TEventEmitter> eventEmitterFactory;

		internal static object CalculateRole;

		public _003C_003Ec__DisplayClass13_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal DecoratorPrototype _003CWithEventEmitter_003Eb__0(DecoratorPrototype inner)
		{
			return eventEmitterFactory(inner);
		}

		internal static bool MoveRole()
		{
			return CalculateRole == null;
		}

		internal static object RevertRole()
		{
			return CalculateRole;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0<TEventEmitter> where TEventEmitter : DecoratorPrototype
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1, 1, 0 })]
		public SpecificationBase<DecoratorPrototype, DecoratorPrototype, TEventEmitter> eventEmitterFactory;

		internal static object InvokeMerchant;

		public _003C_003Ec__DisplayClass14_0()
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

		internal DecoratorPrototype _003CWithEventEmitter_003Eb__0(DecoratorPrototype wrapped, DecoratorPrototype inner)
		{
			return eventEmitterFactory(wrapped, inner);
		}

		internal static bool PublishMerchant()
		{
			return InvokeMerchant == null;
		}

		internal static object RegisterMerchant()
		{
			return InvokeMerchant;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass25_0<TObjectGraphVisitor> where TObjectGraphVisitor : ParserPrototype<RegPrototype>
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public TObjectGraphVisitor objectGraphVisitor;

		internal static object CreateMerchant;

		public _003C_003Ec__DisplayClass25_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal ParserPrototype<RegPrototype> _003CWithPreProcessingPhaseObjectGraphVisitor_003Eb__0(IEnumerable<StatusPrototype> _)
		{
			return objectGraphVisitor;
		}

		internal static bool TestMerchant()
		{
			return CreateMerchant == null;
		}

		internal static object RunMerchant()
		{
			return CreateMerchant;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass26_0<TObjectGraphVisitor> where TObjectGraphVisitor : ParserPrototype<RegPrototype>
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1, 0 })]
		public ConfigurationBase<ParserPrototype<RegPrototype>, TObjectGraphVisitor> objectGraphVisitorFactory;

		private static object VerifyMerchant;

		public _003C_003Ec__DisplayClass26_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal ParserPrototype<RegPrototype> _003CWithPreProcessingPhaseObjectGraphVisitor_003Eb__0(ParserPrototype<RegPrototype> wrapped, IEnumerable<StatusPrototype> _)
		{
			return objectGraphVisitorFactory(wrapped);
		}

		internal static bool PopMerchant()
		{
			return VerifyMerchant == null;
		}

		internal static object PostMerchant()
		{
			return VerifyMerchant;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass31_0<TObjectGraphVisitor> where TObjectGraphVisitor : ParserPrototype<ModelReader>
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1, 0 })]
		public Func<ComposerPrototype, TObjectGraphVisitor> objectGraphVisitorFactory;

		internal static object NewMerchant;

		public _003C_003Ec__DisplayClass31_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal ParserPrototype<ModelReader> _003CWithEmissionPhaseObjectGraphVisitor_003Eb__0(ComposerPrototype args)
		{
			return objectGraphVisitorFactory(args);
		}

		internal static bool AddMerchant()
		{
			return NewMerchant == null;
		}

		internal static object PrepareMerchant()
		{
			return NewMerchant;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass32_0<TObjectGraphVisitor> where TObjectGraphVisitor : ParserPrototype<ModelReader>
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1, 1, 1, 0 })]
		public SpecificationBase<ComposerPrototype, ParserPrototype<ModelReader>, TObjectGraphVisitor> objectGraphVisitorFactory;

		private static object WriteMerchant;

		public _003C_003Ec__DisplayClass32_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal ParserPrototype<ModelReader> _003CWithEmissionPhaseObjectGraphVisitor_003Eb__0(ParserPrototype<ModelReader> wrapped, ComposerPrototype args)
		{
			return objectGraphVisitorFactory(wrapped, args);
		}

		internal static bool PrintMerchant()
		{
			return WriteMerchant == null;
		}

		internal static object CompareMerchant()
		{
			return WriteMerchant;
		}
	}

	private AnnotationPrototype infoPrototype;

	private readonly MerchantPrototype<IEnumerable<StatusPrototype>, ParserPrototype<RegPrototype>> dicPrototype;

	private readonly MerchantPrototype<ComposerPrototype, ParserPrototype<ModelReader>> paramsPrototype;

	private readonly MerchantPrototype<DecoratorPrototype, DecoratorPrototype> m_PoolPrototype;

	private readonly IDictionary<Type, ValueFactory> _DescriptorPrototype;

	private int m_DispatcherPrototype;

	private WrapperReader listPrototype;

	private TestDisplayGroup _QueuePrototype;

	internal static ProcessorPrototype StartRole;

	protected override ProcessorPrototype Self => this;

	public ProcessorPrototype()
	{
		GetterIssuer.DeleteInitializer();
		_DescriptorPrototype = new Dictionary<Type, ValueFactory>();
		m_DispatcherPrototype = 50;
		listPrototype = WrapperReader._ErrorReader;
		base._002Ector((OrderPrototype)new IteratorInterceptor());
		_ObjectBase.Add(typeof(RecordInterceptor), (InstancePrototype inner) => new RecordInterceptor(inner));
		_ObjectBase.Add(typeof(ExporterInterceptor), delegate(InstancePrototype inner)
		{
			int num = 2;
			int num2 = num;
			InstancePrototype result = default(InstancePrototype);
			while (true)
			{
				switch (num2)
				{
				case 2:
					if (mappingBase is WrapperFilter)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 != 0)
						{
							num2 = 1;
						}
						break;
					}
					goto default;
				default:
					result = new ExporterInterceptor(inner, mappingBase);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 != 0)
					{
						num2 = 3;
					}
					break;
				case 3:
					return result;
				case 1:
					return inner;
				}
			}
		});
		_ObjectBase.Add(typeof(MapInterceptor), (InstancePrototype inner) => new MapInterceptor(inner));
		_ObjectBase.Add(typeof(IssuerInterceptor), delegate(InstancePrototype inner)
		{
			int num = 2;
			int num2 = num;
			InstancePrototype result = default(InstancePrototype);
			while (true)
			{
				switch (num2)
				{
				case 2:
					if (structBase == null)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 == 0)
						{
							num2 = 0;
						}
					}
					else
					{
						result = new IssuerInterceptor(inner, structBase.Clone());
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 == 0)
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
		dicPrototype = new MerchantPrototype<IEnumerable<StatusPrototype>, ParserPrototype<RegPrototype>> { 
		{
			typeof(ObjectInterceptor),
			(IEnumerable<StatusPrototype> typeConverters) => new ObjectInterceptor(typeConverters)
		} };
		paramsPrototype = new MerchantPrototype<ComposerPrototype, ParserPrototype<ModelReader>>
		{
			{
				typeof(PrototypeFilter),
				(ComposerPrototype args) => new PrototypeFilter(args.InnerVisitor, args.TypeConverters, args.NestedObjectSerializer)
			},
			{
				typeof(RefInterceptor),
				(ComposerPrototype args) => new RefInterceptor(args.InnerVisitor, args.EventEmitter, args.GetPreProcessingPhaseObjectGraphVisitor<ObjectInterceptor>())
			},
			{
				typeof(SetterFilter),
				(ComposerPrototype args) => new SetterFilter(_QueuePrototype, args.InnerVisitor)
			},
			{
				typeof(BaseFilter),
				(ComposerPrototype args) => new BaseFilter(args.InnerVisitor)
			}
		};
		m_PoolPrototype = new MerchantPrototype<DecoratorPrototype, DecoratorPrototype> { 
		{
			typeof(ReponseFilter),
			(DecoratorPrototype inner) => new ReponseFilter(inner, requireTagWhenStaticAndActualTypesAreDifferent: false, _DescriptorPrototype)
		} };
		infoPrototype = (InstancePrototype typeInspector, OrderPrototype typeResolver, IEnumerable<StatusPrototype> typeConverters, int maximumRecursion) => new IssuerFilter(typeInspector, typeResolver, maximumRecursion, mappingBase);
	}

	public ProcessorPrototype WithMaximumRecursion(int maximumRecursion)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 3:
				throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(-1735703950 ^ -1735713058), string.Format(DicSingleton.gE3WbyDVW(-1580624393 ^ -1580611289), maximumRecursion));
			default:
				m_DispatcherPrototype = maximumRecursion;
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f != 0)
				{
					num2 = 2;
				}
				break;
			case 1:
				if (maximumRecursion > 0)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 3;
			case 2:
				return this;
			}
		}
	}

	public ProcessorPrototype WithEventEmitter<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] TEventEmitter>(Func<DecoratorPrototype, TEventEmitter> eventEmitterFactory) where TEventEmitter : DecoratorPrototype
	{
		return WithEventEmitter(eventEmitterFactory, delegate(ParamPrototype<DecoratorPrototype> w)
		{
			w.OnTop();
		});
	}

	public ProcessorPrototype WithEventEmitter<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] TEventEmitter>(Func<DecoratorPrototype, TEventEmitter> eventEmitterFactory, Action<ParamPrototype<DecoratorPrototype>> where) where TEventEmitter : DecoratorPrototype
	{
		_003C_003Ec__DisplayClass13_0<TEventEmitter> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass13_0<TEventEmitter>();
		CS_0024_003C_003E8__locals3.eventEmitterFactory = eventEmitterFactory;
		if (CS_0024_003C_003E8__locals3.eventEmitterFactory == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-316028230 ^ -316041278));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1180565667 ^ -1180587367));
		}
		where(m_PoolPrototype.CreateRegistrationLocationSelector(typeof(TEventEmitter), (DecoratorPrototype inner) => CS_0024_003C_003E8__locals3.eventEmitterFactory(inner)));
		return Self;
	}

	public ProcessorPrototype WithEventEmitter<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] TEventEmitter>(SpecificationBase<DecoratorPrototype, DecoratorPrototype, TEventEmitter> eventEmitterFactory, Action<FacadePrototype<DecoratorPrototype>> where) where TEventEmitter : DecoratorPrototype
	{
		_003C_003Ec__DisplayClass14_0<TEventEmitter> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass14_0<TEventEmitter>();
		CS_0024_003C_003E8__locals3.eventEmitterFactory = eventEmitterFactory;
		if (CS_0024_003C_003E8__locals3.eventEmitterFactory == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-359091888 ^ -359076824));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-525002617 ^ -524989117));
		}
		where(m_PoolPrototype.CreateTrackingRegistrationLocationSelector(typeof(TEventEmitter), (DecoratorPrototype wrapped, DecoratorPrototype inner) => CS_0024_003C_003E8__locals3.eventEmitterFactory(wrapped, inner)));
		return Self;
	}

	public ProcessorPrototype WithoutEventEmitter<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] TEventEmitter>() where TEventEmitter : DecoratorPrototype
	{
		return WithoutEventEmitter(typeof(TEventEmitter));
	}

	public ProcessorPrototype WithoutEventEmitter(Type eventEmitterType)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return this;
			case 1:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x38262FC9 ^ 0x3826726B));
			case 2:
				if (!(eventEmitterType == null))
				{
					m_PoolPrototype.Remove(eventEmitterType);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 != 0)
					{
						num2 = 0;
					}
				}
				else
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 == 0)
					{
						num2 = 0;
					}
				}
				break;
			}
		}
	}

	public override ProcessorPrototype WithTagMapping(ValueFactory tag, Type type)
	{
		int num = 3;
		ValueFactory value = default(ValueFactory);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 7:
					throw new ArgumentException(DicSingleton.gE3WbyDVW(--1509395337 ^ 0x59F7DC43));
				case 2:
					if (!(type == null))
					{
						goto end_IL_0012;
					}
					goto case 1;
				case 3:
					if (!tag.IsEmpty)
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb == 0)
						{
							num2 = 2;
						}
						break;
					}
					goto case 7;
				default:
					throw new ArgumentException(string.Format(DicSingleton.gE3WbyDVW(-360128320 ^ -360137466), value, type.FullName), DicSingleton.gE3WbyDVW(0x6CF51E1A ^ 0x6CF54886));
				case 5:
					_DescriptorPrototype.Add(type, tag);
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa == 0)
					{
						num2 = 6;
					}
					break;
				case 1:
					throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-381685266 ^ -381704334));
				case 4:
					if (!_DescriptorPrototype.TryGetValue(type, out value))
					{
						num2 = 5;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af != 0)
						{
							num2 = 5;
						}
						break;
					}
					goto default;
				case 6:
					return this;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 4;
		}
	}

	public ProcessorPrototype WithoutTagMapping(Type type)
	{
		int num = 4;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				throw new KeyNotFoundException(DicSingleton.gE3WbyDVW(0x23D015CA ^ 0x23D04BFC) + type.FullName + DicSingleton.gE3WbyDVW(0x3FCF6129 ^ 0x3FCF3F7F));
			case 1:
				return this;
			case 4:
				if (!(type == null))
				{
					num2 = 3;
					break;
				}
				goto default;
			default:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x4C73F208 ^ 0x4C73A494));
			case 3:
				if (_DescriptorPrototype.Remove(type))
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 == 0)
					{
						num2 = 1;
					}
					break;
				}
				goto case 2;
			}
		}
	}

	public ProcessorPrototype EnsureRoundtrip()
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				infoPrototype = (InstancePrototype typeInspector, OrderPrototype typeResolver, IEnumerable<StatusPrototype> typeConverters, int maximumRecursion) => new GlobalFilter(typeConverters, typeInspector, typeResolver, maximumRecursion, mappingBase);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 != 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				WithEventEmitter([_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)] ([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(1)] DecoratorPrototype inner) => new ReponseFilter(inner, requireTagWhenStaticAndActualTypesAreDifferent: true, _DescriptorPrototype), delegate(ParamPrototype<DecoratorPrototype> loc)
				{
					loc.InsteadOf<ReponseFilter>();
				});
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return WithTypeInspector([_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)] ([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(1)] InstancePrototype inner) => new WrapperInterceptor(inner), delegate(ParamPrototype<InstancePrototype> loc)
				{
					loc.OnBottom();
				});
			}
		}
	}

	public ProcessorPrototype DisableAliases()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				paramsPrototype.Remove(typeof(RefInterceptor));
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_575e6bd686b54d028cdc3fc324b58a39 != 0)
				{
					num2 = 2;
				}
				break;
			case 1:
				dicPrototype.Remove(typeof(ObjectInterceptor));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba != 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				return this;
			}
		}
	}

	[Obsolete("The default behavior is now to always emit default values, thefore calling this method has no effect. This behavior is now controlled by ConfigureDefaultValuesHandling.", true)]
	public ProcessorPrototype EmitDefaults()
	{
		return ConfigureDefaultValuesHandling((TestDisplayGroup)0);
	}

	public ProcessorPrototype ConfigureDefaultValuesHandling(TestDisplayGroup configuration)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				_QueuePrototype = configuration;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return this;
			}
		}
	}

	public ProcessorPrototype JsonCompatible()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				listPrototype = listPrototype.WithMaxSimpleKeyLength(int.MaxValue).WithoutAnchorName();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a579dea83d2144838086d2d400bd0222 != 0)
				{
					num2 = 0;
				}
				break;
			default:
				return WithTypeConverter(new TagFilter(jsonCompatible: true), delegate(ParamPrototype<StatusPrototype> w)
				{
					w.InsteadOf<TagFilter>();
				}).WithEventEmitter([_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)] ([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(1)] DecoratorPrototype inner) => new RegFilter(inner), delegate(ParamPrototype<DecoratorPrototype> loc)
				{
					loc.InsteadOf<ReponseFilter>();
				});
			}
		}
	}

	public ProcessorPrototype WithPreProcessingPhaseObjectGraphVisitor<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] TObjectGraphVisitor>(TObjectGraphVisitor objectGraphVisitor) where TObjectGraphVisitor : ParserPrototype<RegPrototype>
	{
		return WithPreProcessingPhaseObjectGraphVisitor(objectGraphVisitor, delegate(ParamPrototype<ParserPrototype<RegPrototype>> w)
		{
			w.OnTop();
		});
	}

	public ProcessorPrototype WithPreProcessingPhaseObjectGraphVisitor<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] TObjectGraphVisitor>(TObjectGraphVisitor objectGraphVisitor, Action<ParamPrototype<ParserPrototype<RegPrototype>>> where) where TObjectGraphVisitor : ParserPrototype<RegPrototype>
	{
		_003C_003Ec__DisplayClass25_0<TObjectGraphVisitor> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass25_0<TObjectGraphVisitor>();
		CS_0024_003C_003E8__locals3.objectGraphVisitor = objectGraphVisitor;
		if (CS_0024_003C_003E8__locals3.objectGraphVisitor == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-228218718 ^ -228198878));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x69B67B3A ^ 0x69B62EFE));
		}
		where(dicPrototype.CreateRegistrationLocationSelector(typeof(TObjectGraphVisitor), (IEnumerable<StatusPrototype> _) => CS_0024_003C_003E8__locals3.objectGraphVisitor));
		return this;
	}

	public ProcessorPrototype WithPreProcessingPhaseObjectGraphVisitor<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] TObjectGraphVisitor>(ConfigurationBase<ParserPrototype<RegPrototype>, TObjectGraphVisitor> objectGraphVisitorFactory, Action<FacadePrototype<ParserPrototype<RegPrototype>>> where) where TObjectGraphVisitor : ParserPrototype<RegPrototype>
	{
		_003C_003Ec__DisplayClass26_0<TObjectGraphVisitor> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass26_0<TObjectGraphVisitor>();
		CS_0024_003C_003E8__locals3.objectGraphVisitorFactory = objectGraphVisitorFactory;
		if (CS_0024_003C_003E8__locals3.objectGraphVisitorFactory == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1977574774 ^ -1977564126));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(--1844849127 ^ 0x6DF67C23));
		}
		where(dicPrototype.CreateTrackingRegistrationLocationSelector(typeof(TObjectGraphVisitor), (ParserPrototype<RegPrototype> wrapped, IEnumerable<StatusPrototype> _) => CS_0024_003C_003E8__locals3.objectGraphVisitorFactory(wrapped)));
		return this;
	}

	public ProcessorPrototype WithoutPreProcessingPhaseObjectGraphVisitor<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] TObjectGraphVisitor>() where TObjectGraphVisitor : ParserPrototype<RegPrototype>
	{
		return WithoutPreProcessingPhaseObjectGraphVisitor(typeof(TObjectGraphVisitor));
	}

	public ProcessorPrototype WithoutPreProcessingPhaseObjectGraphVisitor(Type objectGraphVisitorType)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				if (objectGraphVisitorType == null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9c47a25d924946efb9e023473a095794 != 0)
					{
						num2 = 1;
					}
					break;
				}
				dicPrototype.Remove(objectGraphVisitorType);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return this;
			case 1:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x5A8BEE ^ 0x5AD530));
			}
		}
	}

	public ProcessorPrototype WithObjectGraphTraversalStrategyFactory(AnnotationPrototype objectGraphTraversalStrategyFactory)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				infoPrototype = objectGraphTraversalStrategyFactory;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return this;
			}
		}
	}

	public ProcessorPrototype WithEmissionPhaseObjectGraphVisitor<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] TObjectGraphVisitor>(Func<ComposerPrototype, TObjectGraphVisitor> objectGraphVisitorFactory) where TObjectGraphVisitor : ParserPrototype<ModelReader>
	{
		return WithEmissionPhaseObjectGraphVisitor(objectGraphVisitorFactory, delegate(ParamPrototype<ParserPrototype<ModelReader>> w)
		{
			w.OnTop();
		});
	}

	public ProcessorPrototype WithEmissionPhaseObjectGraphVisitor<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] TObjectGraphVisitor>(Func<ComposerPrototype, TObjectGraphVisitor> objectGraphVisitorFactory, Action<ParamPrototype<ParserPrototype<ModelReader>>> where) where TObjectGraphVisitor : ParserPrototype<ModelReader>
	{
		_003C_003Ec__DisplayClass31_0<TObjectGraphVisitor> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass31_0<TObjectGraphVisitor>();
		CS_0024_003C_003E8__locals3.objectGraphVisitorFactory = objectGraphVisitorFactory;
		if (CS_0024_003C_003E8__locals3.objectGraphVisitorFactory == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x15823EC4 ^ 0x1582606C));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1180565667 ^ -1180587367));
		}
		where(paramsPrototype.CreateRegistrationLocationSelector(typeof(TObjectGraphVisitor), (ComposerPrototype args) => CS_0024_003C_003E8__locals3.objectGraphVisitorFactory(args)));
		return this;
	}

	public ProcessorPrototype WithEmissionPhaseObjectGraphVisitor<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] TObjectGraphVisitor>(SpecificationBase<ComposerPrototype, ParserPrototype<ModelReader>, TObjectGraphVisitor> objectGraphVisitorFactory, Action<FacadePrototype<ParserPrototype<ModelReader>>> where) where TObjectGraphVisitor : ParserPrototype<ModelReader>
	{
		_003C_003Ec__DisplayClass32_0<TObjectGraphVisitor> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass32_0<TObjectGraphVisitor>();
		CS_0024_003C_003E8__locals3.objectGraphVisitorFactory = objectGraphVisitorFactory;
		if (CS_0024_003C_003E8__locals3.objectGraphVisitorFactory == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1389846755 ^ -1389837899));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x3C33E48 ^ 0x3C36B8C));
		}
		where(paramsPrototype.CreateTrackingRegistrationLocationSelector(typeof(TObjectGraphVisitor), (ParserPrototype<ModelReader> wrapped, ComposerPrototype args) => CS_0024_003C_003E8__locals3.objectGraphVisitorFactory(wrapped, args)));
		return this;
	}

	public ProcessorPrototype WithoutEmissionPhaseObjectGraphVisitor<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] TObjectGraphVisitor>() where TObjectGraphVisitor : ParserPrototype<ModelReader>
	{
		return WithoutEmissionPhaseObjectGraphVisitor(typeof(TObjectGraphVisitor));
	}

	public ProcessorPrototype WithoutEmissionPhaseObjectGraphVisitor(Type objectGraphVisitorType)
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
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x765D303 ^ 0x7658DDD));
			case 1:
				if (!(objectGraphVisitorType == null))
				{
					paramsPrototype.Remove(objectGraphVisitorType);
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 == 0)
					{
						num2 = 2;
					}
				}
				else
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
					{
						num2 = 0;
					}
				}
				break;
			}
		}
	}

	public ProcessorPrototype WithIndentedSequences()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				listPrototype = listPrototype.WithIndentedSequences();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return this;
			}
		}
	}

	public EventPrototype Build()
	{
		return StubPrototype.FromValueSerializer(BuildValueSerializer(), listPrototype);
	}

	public ClientPrototype BuildValueSerializer()
	{
		int num = 2;
		int num2 = num;
		IEnumerable<StatusPrototype> typeConverters = default(IEnumerable<StatusPrototype>);
		InstancePrototype typeInspector = default(InstancePrototype);
		while (true)
		{
			switch (num2)
			{
			case 2:
				typeConverters = BuildTypeConverters();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f == 0)
				{
					num2 = 1;
				}
				break;
			default:
			{
				PagePrototype traversalStrategy = infoPrototype(typeInspector, schemaBase, typeConverters, m_DispatcherPrototype);
				DecoratorPrototype eventEmitter = m_PoolPrototype.BuildComponentChain(new AdvisorFilter());
				return new CollectionPrototype(traversalStrategy, eventEmitter, typeConverters, dicPrototype.Clone(), paramsPrototype.Clone());
			}
			case 1:
				typeInspector = BuildTypeInspector();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_259acdc10a3c4fba8a4f129ba5346de2 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool RemoveRole()
	{
		return StartRole == null;
	}

	internal static ProcessorPrototype ResolveRole()
	{
		return StartRole;
	}
}
