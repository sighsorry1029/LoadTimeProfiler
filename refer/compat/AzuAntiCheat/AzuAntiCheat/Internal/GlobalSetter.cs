using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class GlobalSetter : WriterSetter<GlobalSetter>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public PrinterSetter m_ProductSetter;

		internal static _003C_003Ec__DisplayClass14_0 FindParameter;

		public _003C_003Ec__DisplayClass14_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal PrinterSetter _003CWithObjectFactory_003Eb__0()
		{
			return m_ProductSetter;
		}

		internal static bool VisitParameter()
		{
			return FindParameter == null;
		}

		internal static _003C_003Ec__DisplayClass14_0 OrderParameter()
		{
			return FindParameter;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public WrapperSetter _RegistrySetter;

		private static _003C_003Ec__DisplayClass17_0 UpdateParameter;

		public _003C_003Ec__DisplayClass17_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal WrapperSetter _003CWithNodeDeserializer_003Eb__0(MappingSetter _)
		{
			return _RegistrySetter;
		}

		internal static bool SearchParameter()
		{
			return UpdateParameter == null;
		}

		internal static _003C_003Ec__DisplayClass17_0 StopParameter()
		{
			return UpdateParameter;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_0<TNodeDeserializer> where TNodeDeserializer : notnull, WrapperSetter
	{
		public ProducerSetter<WrapperSetter, TNodeDeserializer> nodeDeserializerFactory;

		private static object ExcludeParameter;

		public _003C_003Ec__DisplayClass18_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal WrapperSetter _003CWithNodeDeserializer_003Eb__0(WrapperSetter wrapped, MappingSetter _)
		{
			return nodeDeserializerFactory(wrapped);
		}

		internal static bool InterruptParameter()
		{
			return ExcludeParameter == null;
		}

		internal static object DeleteParameter()
		{
			return ExcludeParameter;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass23_0
	{
		public ServerSetter m_StateSetter;

		private static _003C_003Ec__DisplayClass23_0 FillParameter;

		public _003C_003Ec__DisplayClass23_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal ServerSetter _003CWithNodeTypeResolver_003Eb__0(MappingSetter _)
		{
			return m_StateSetter;
		}

		internal static bool FlushParameter()
		{
			return FillParameter == null;
		}

		internal static _003C_003Ec__DisplayClass23_0 DestroyParameter()
		{
			return FillParameter;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass24_0<TNodeTypeResolver> where TNodeTypeResolver : notnull, ServerSetter
	{
		public ProducerSetter<ServerSetter, TNodeTypeResolver> nodeTypeResolverFactory;

		private static object ComputeParameter;

		public _003C_003Ec__DisplayClass24_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal ServerSetter _003CWithNodeTypeResolver_003Eb__0(ServerSetter wrapped, MappingSetter _)
		{
			return nodeTypeResolverFactory(wrapped);
		}

		internal static bool DisableParameter()
		{
			return ComputeParameter == null;
		}

		internal static object QueryParameter()
		{
			return ComputeParameter;
		}
	}

	private Lazy<PrinterSetter> _MapSetter;

	private readonly ProcessorSetter<MappingSetter, WrapperSetter> m_HelperSetter;

	private readonly ProcessorSetter<MappingSetter, ServerSetter> exceptionSetter;

	private readonly Dictionary<RoleSingleton, Type> itemSetter;

	private readonly Dictionary<Type, Type> contextSetter;

	private readonly TokenInvocation _MapperSetter;

	private bool identifierSetter;

	private bool tokenSetter;

	private bool m_CallbackSetter;

	internal static GlobalSetter SetParameter;

	protected override GlobalSetter Self => this;

	public GlobalSetter()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector((ConnectionSetter)new ExpressionInvocation());
		int num = 5;
		while (true)
		{
			int num2 = num;
			ProcessorSetter<AdvisorSetter, AdvisorSetter> singletonSetter;
			Type typeFromHandle;
			Func<AdvisorSetter, AdvisorSetter> factory;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 8:
					_MapperSetter = new IndexerInvocation();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
					{
						num2 = 0;
					}
					break;
				case 10:
					itemSetter = new Dictionary<RoleSingleton, Type>
					{
						{
							AdvisorInvocation.ConnectionInvocation.annotationInvocation,
							typeof(Dictionary<object, object>)
						},
						{
							AdvisorInvocation.ConnectionInvocation.m_RepositoryInvocation,
							typeof(string)
						},
						{
							TagInvocation.VisitorInvocation._PolicyInvocation,
							typeof(bool)
						},
						{
							TagInvocation.VisitorInvocation.m_ProcessorInvocation,
							typeof(double)
						},
						{
							TagInvocation.VisitorInvocation.strategyInvocation,
							typeof(int)
						},
						{
							ParamsInvocation.PoolInvocation._DescriptorInvocation,
							typeof(DateTime)
						}
					};
					num2 = 9;
					break;
				case 1:
					m_SingletonSetter.Add(typeof(TestsInvocation), delegate(AdvisorSetter inner)
					{
						int num3 = 1;
						int num4 = num3;
						AdvisorSetter result = default(AdvisorSetter);
						while (true)
						{
							switch (num4)
							{
							case 1:
								if (invocationSetter is InfoAuthentication)
								{
									num4 = 0;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 == 0)
									{
										num4 = 0;
									}
									continue;
								}
								break;
							case 3:
								return result;
							default:
								return inner;
							case 2:
								break;
							}
							result = new TestsInvocation(inner, invocationSetter);
							num4 = 3;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba != 0)
							{
								num4 = 2;
							}
						}
					});
					num2 = 2;
					break;
				case 4:
					m_SingletonSetter.Add(typeof(ThreadWriter), delegate(AdvisorSetter inner)
					{
						int num3 = 1;
						int num4 = num3;
						AdvisorSetter result = default(AdvisorSetter);
						while (true)
						{
							switch (num4)
							{
							case 3:
								return inner;
							default:
								result = new ThreadWriter(inner, _AttributeSetter.Clone());
								num4 = 2;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9c47a25d924946efb9e023473a095794 != 0)
								{
									num4 = 2;
								}
								break;
							case 2:
								return result;
							case 1:
								if (_AttributeSetter != null)
								{
									num4 = 0;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a == 0)
									{
										num4 = 0;
									}
									break;
								}
								goto case 3;
							}
						}
					});
					num2 = 6;
					break;
				case 0:
					return;
				case 5:
					contextSetter = new Dictionary<Type, Type>();
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 != 0)
					{
						num2 = 7;
					}
					break;
				case 7:
					_MapSetter = new Lazy<PrinterSetter>(() => new IssuerAuthentication(contextSetter, _RuleSetter), isThreadSafe: true);
					num2 = 10;
					break;
				case 9:
					m_SingletonSetter.Add(typeof(ProductInvocation), (AdvisorSetter inner) => new ProductInvocation(inner));
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 == 0)
					{
						num2 = 1;
					}
					break;
				case 2:
					m_SingletonSetter.Add(typeof(SpecificationWriter), (AdvisorSetter inner) => new SpecificationWriter(inner));
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 == 0)
					{
						num2 = 2;
					}
					break;
				case 6:
					singletonSetter = m_SingletonSetter;
					typeFromHandle = typeof(ParserInvocation);
					factory = (AdvisorSetter inner) => new ParserInvocation(inner);
					goto end_IL_002c;
				case 3:
					m_HelperSetter = new ProcessorSetter<MappingSetter, WrapperSetter>
					{
						{
							typeof(ModelAuthentication),
							(MappingSetter _) => new ModelAuthentication(_MapSetter.Value)
						},
						{
							typeof(ProcessAuthentication),
							(MappingSetter _) => new ProcessAuthentication(_MapSetter.Value)
						},
						{
							typeof(RegAuthentication),
							(MappingSetter _) => new RegAuthentication(BuildTypeConverters())
						},
						{
							typeof(ParamAuthentication),
							(MappingSetter _) => new ParamAuthentication()
						},
						{
							typeof(BridgeAuthentication),
							(MappingSetter _) => new BridgeAuthentication(m_CallbackSetter, _MapperSetter, _SerializerSetter)
						},
						{
							typeof(GetterAuthentication),
							(MappingSetter _) => new GetterAuthentication()
						},
						{
							typeof(PageAuthentication),
							(MappingSetter _) => new PageAuthentication(_MapSetter.Value, tokenSetter)
						},
						{
							typeof(CustomerAuthentication),
							(MappingSetter _) => new CustomerAuthentication(_MapSetter.Value)
						},
						{
							typeof(RequestAuthentication),
							(MappingSetter _) => new RequestAuthentication()
						},
						{
							typeof(FacadeAuthentication),
							(MappingSetter _) => new FacadeAuthentication(_MapSetter.Value, BuildTypeInspector(), identifierSetter, tokenSetter, _MapperSetter)
						}
					};
					num2 = 11;
					break;
				case 11:
					exceptionSetter = new ProcessorSetter<MappingSetter, ServerSetter>
					{
						{
							typeof(ExceptionAuthentication),
							(MappingSetter _) => new ExceptionAuthentication(contextSetter)
						},
						{
							typeof(CallbackAuthentication),
							(MappingSetter _) => new CallbackAuthentication()
						},
						{
							typeof(RulesAuthentication),
							(MappingSetter _) => new RulesAuthentication()
						},
						{
							typeof(MapperAuthentication),
							(MappingSetter _) => new MapperAuthentication(itemSetter)
						},
						{
							typeof(ContextAuthentication),
							(MappingSetter _) => new ContextAuthentication()
						},
						{
							typeof(HelperAuthentication),
							(MappingSetter _) => new HelperAuthentication()
						}
					};
					num2 = 8;
					break;
				}
				continue;
				end_IL_002c:
				break;
			}
			singletonSetter.Add(typeFromHandle, factory);
			num = 3;
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
			default:
				if (issuerSetter)
				{
					num2 = 4;
					break;
				}
				goto case 3;
			case 3:
				advisorSetter = new BroadcasterInvocation(new EventInvocation(m_AuthenticationSetter), advisorSetter);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3aab303a2946368dda3deef055dc93 == 0)
				{
					num2 = 2;
				}
				break;
			case 2:
			case 4:
				return m_SingletonSetter.BuildComponentChain(advisorSetter);
			case 1:
				advisorSetter = new ImporterInvocation(m_AuthenticationSetter, fieldSetter);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public GlobalSetter WithAttemptingUnquotedStringTypeDeserialization()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				m_CallbackSetter = true;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return this;
			}
		}
	}

	public GlobalSetter WithObjectFactory(PrinterSetter objectFactory)
	{
		int num = 3;
		int num2 = num;
		_003C_003Ec__DisplayClass14_0 _003C_003Ec__DisplayClass14_ = default(_003C_003Ec__DisplayClass14_0);
		while (true)
		{
			switch (num2)
			{
			case 1:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x6729A6D ^ 0x672CCC5));
			case 4:
				return this;
			case 2:
				_003C_003Ec__DisplayClass14_.m_ProductSetter = objectFactory;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
				{
					num2 = 0;
				}
				continue;
			case 3:
				_003C_003Ec__DisplayClass14_ = new _003C_003Ec__DisplayClass14_0();
				num2 = 2;
				continue;
			}
			if (_003C_003Ec__DisplayClass14_.m_ProductSetter != null)
			{
				_MapSetter = new Lazy<PrinterSetter>(_003C_003Ec__DisplayClass14_._003CWithObjectFactory_003Eb__0, isThreadSafe: true);
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 != 0)
				{
					num2 = 4;
				}
			}
			else
			{
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 == 0)
				{
					num2 = 1;
				}
			}
		}
	}

	public GlobalSetter WithObjectFactory(Func<Type, object> objectFactory)
	{
		if (objectFactory == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-940539791 ^ -940517671));
		}
		return WithObjectFactory(new DefinitionAuthentication(objectFactory));
	}

	public GlobalSetter WithNodeDeserializer(WrapperSetter nodeDeserializer)
	{
		return WithNodeDeserializer(nodeDeserializer, delegate(ReponseSetter<WrapperSetter> w)
		{
			w.OnTop();
		});
	}

	public GlobalSetter WithNodeDeserializer(WrapperSetter nodeDeserializer, Action<ReponseSetter<WrapperSetter>> where)
	{
		_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass17_0();
		CS_0024_003C_003E8__locals4._RegistrySetter = nodeDeserializer;
		if (CS_0024_003C_003E8__locals4._RegistrySetter == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-475093377 ^ -475074375));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-380885952 ^ -380866172));
		}
		where(m_HelperSetter.CreateRegistrationLocationSelector(CS_0024_003C_003E8__locals4._RegistrySetter.GetType(), (MappingSetter _) => CS_0024_003C_003E8__locals4._RegistrySetter));
		return this;
	}

	public GlobalSetter WithNodeDeserializer<TNodeDeserializer>(ProducerSetter<WrapperSetter, TNodeDeserializer> nodeDeserializerFactory, Action<ProxySetter<WrapperSetter>> where) where TNodeDeserializer : WrapperSetter
	{
		_003C_003Ec__DisplayClass18_0<TNodeDeserializer> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass18_0<TNodeDeserializer>();
		CS_0024_003C_003E8__locals3.nodeDeserializerFactory = nodeDeserializerFactory;
		if (CS_0024_003C_003E8__locals3.nodeDeserializerFactory == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x30B55457 ^ 0x30B502BD));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-736996892 ^ -737016800));
		}
		where(m_HelperSetter.CreateTrackingRegistrationLocationSelector(typeof(TNodeDeserializer), (WrapperSetter wrapped, MappingSetter _) => CS_0024_003C_003E8__locals3.nodeDeserializerFactory(wrapped)));
		return this;
	}

	public GlobalSetter WithoutNodeDeserializer<TNodeDeserializer>() where TNodeDeserializer : WrapperSetter
	{
		return WithoutNodeDeserializer(typeof(TNodeDeserializer));
	}

	public GlobalSetter WithoutNodeDeserializer(Type nodeDeserializerType)
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
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x47C77AB8 ^ 0x47C72DA4));
			case 2:
				if (!(nodeDeserializerType == null))
				{
					m_HelperSetter.Remove(nodeDeserializerType);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 == 0)
					{
						num2 = 0;
					}
				}
				else
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f != 0)
					{
						num2 = 0;
					}
				}
				break;
			}
		}
	}

	public GlobalSetter WithTypeDiscriminatingNodeDeserializer(Action<InvocationAttribute> configureTypeDiscriminatingNodeDeserializerOptions, int maxDepth = -1, int maxLength = -1)
	{
		ComparatorAttribute comparatorAttribute = new ComparatorAttribute();
		configureTypeDiscriminatingNodeDeserializerOptions(comparatorAttribute);
		SingletonAttribute nodeDeserializer = new SingletonAttribute(m_HelperSetter.BuildComponentList(), comparatorAttribute.m_DefinitionAttribute, maxDepth, maxLength);
		return WithNodeDeserializer(nodeDeserializer, delegate(ReponseSetter<WrapperSetter> s)
		{
			s.Before<PageAuthentication>();
		});
	}

	public GlobalSetter WithNodeTypeResolver(ServerSetter nodeTypeResolver)
	{
		return WithNodeTypeResolver(nodeTypeResolver, delegate(ReponseSetter<ServerSetter> w)
		{
			w.OnTop();
		});
	}

	public GlobalSetter WithNodeTypeResolver(ServerSetter nodeTypeResolver, Action<ReponseSetter<ServerSetter>> where)
	{
		_003C_003Ec__DisplayClass23_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass23_0();
		CS_0024_003C_003E8__locals4.m_StateSetter = nodeTypeResolver;
		if (CS_0024_003C_003E8__locals4.m_StateSetter == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-948533799 ^ -948514159));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1053593978 ^ -1053607102));
		}
		where(exceptionSetter.CreateRegistrationLocationSelector(CS_0024_003C_003E8__locals4.m_StateSetter.GetType(), (MappingSetter _) => CS_0024_003C_003E8__locals4.m_StateSetter));
		return this;
	}

	public GlobalSetter WithNodeTypeResolver<TNodeTypeResolver>(ProducerSetter<ServerSetter, TNodeTypeResolver> nodeTypeResolverFactory, Action<ProxySetter<ServerSetter>> where) where TNodeTypeResolver : ServerSetter
	{
		_003C_003Ec__DisplayClass24_0<TNodeTypeResolver> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass24_0<TNodeTypeResolver>();
		CS_0024_003C_003E8__locals3.nodeTypeResolverFactory = nodeTypeResolverFactory;
		if (CS_0024_003C_003E8__locals3.nodeTypeResolverFactory == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x59C84793 ^ 0x59C810FF));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1549341817 ^ -1549353405));
		}
		where(exceptionSetter.CreateTrackingRegistrationLocationSelector(typeof(TNodeTypeResolver), (ServerSetter wrapped, MappingSetter _) => CS_0024_003C_003E8__locals3.nodeTypeResolverFactory(wrapped)));
		return this;
	}

	public GlobalSetter WithoutNodeTypeResolver<TNodeTypeResolver>() where TNodeTypeResolver : ServerSetter
	{
		return WithoutNodeTypeResolver(typeof(TNodeTypeResolver));
	}

	public GlobalSetter WithoutNodeTypeResolver(Type nodeTypeResolverType)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (nodeTypeResolverType == null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 == 0)
					{
						num2 = 0;
					}
					break;
				}
				exceptionSetter.Remove(nodeTypeResolverType);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 != 0)
				{
					num2 = 2;
				}
				break;
			case 2:
				return this;
			default:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1773869960 ^ -1773882394));
			}
		}
	}

	public override GlobalSetter WithTagMapping(RoleSingleton tag, Type type)
	{
		int num = 2;
		Type value = default(Type);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 3:
					return this;
				case 4:
					throw new ArgumentException(string.Format(DicSingleton.gE3WbyDVW(-614239580 ^ -614257996), value.FullName, tag), DicSingleton.gE3WbyDVW(-360128320 ^ -360138688));
				default:
					itemSetter.Add(tag, type);
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e != 0)
					{
						num2 = 3;
					}
					continue;
				case 2:
					if (!tag.IsEmpty)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc == 0)
						{
							num2 = 0;
						}
						continue;
					}
					break;
				case 6:
					throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1549341817 ^ -1549353701));
				case 5:
					break;
				case 1:
					if (type == null)
					{
						goto end_IL_0012;
					}
					if (!itemSetter.TryGetValue(tag, out value))
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 4;
				}
				throw new ArgumentException(DicSingleton.gE3WbyDVW(-1614185587 ^ -1614205881));
				continue;
				end_IL_0012:
				break;
			}
			num = 6;
		}
	}

	public GlobalSetter WithTypeMapping<TInterface, TConcrete>() where TConcrete : TInterface
	{
		Type typeFromHandle = typeof(TInterface);
		Type typeFromHandle2 = typeof(TConcrete);
		if (!typeFromHandle.IsAssignableFrom(typeFromHandle2))
		{
			throw new InvalidOperationException(DicSingleton.gE3WbyDVW(0x9000142 ^ 0x90059C8) + typeFromHandle2.Name + DicSingleton.gE3WbyDVW(-379532028 ^ -379546202) + typeFromHandle.Name + DicSingleton.gE3WbyDVW(-1447578472 ^ -1447566916));
		}
		if (contextSetter.ContainsKey(typeFromHandle))
		{
			contextSetter[typeFromHandle] = typeFromHandle2;
		}
		else
		{
			contextSetter.Add(typeFromHandle, typeFromHandle2);
		}
		return this;
	}

	public GlobalSetter WithoutTagMapping(RoleSingleton tag)
	{
		int num = 3;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				throw new KeyNotFoundException(string.Format(DicSingleton.gE3WbyDVW(-1483531944 ^ -1483521602), tag));
			default:
				return this;
			case 2:
				throw new ArgumentException(DicSingleton.gE3WbyDVW(-2075300707 ^ -2075313321));
			case 3:
				if (!tag.IsEmpty)
				{
					if (itemSetter.Remove(tag))
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4fda3adbb4ec45bdb14fe2ef97e570a8 != 0)
						{
							num2 = 0;
						}
						break;
					}
					goto case 1;
				}
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 == 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	public GlobalSetter IgnoreUnmatchedProperties()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				identifierSetter = true;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return this;
			}
		}
	}

	public GlobalSetter WithDuplicateKeyChecking()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				tokenSetter = true;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c2b9915913b8461884afdca5d98855ec != 0)
				{
					num2 = 0;
				}
				break;
			default:
				return this;
			}
		}
	}

	public ExporterSetter Build()
	{
		return DefinitionSetter.FromValueDeserializer(BuildValueDeserializer());
	}

	public AnnotationSetter BuildValueDeserializer()
	{
		return new IssuerInvocation(new GlobalInvocation(m_HelperSetter.BuildComponentList(), exceptionSetter.BuildComponentList(), _MapperSetter));
	}

	internal static bool PushParameter()
	{
		return SetParameter == null;
	}

	internal static GlobalSetter ValidateParameter()
	{
		return SetParameter;
	}
}
