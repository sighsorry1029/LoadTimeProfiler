using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class ExpressionWriter : MockWriter<ExpressionWriter>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public WrapperSetter m_ClientWriter;

		internal static _003C_003Ec__DisplayClass16_0 ComputeBridge;

		public _003C_003Ec__DisplayClass16_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb != 0)
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
			return m_ClientWriter;
		}

		internal static bool DisableBridge()
		{
			return ComputeBridge == null;
		}

		internal static _003C_003Ec__DisplayClass16_0 QueryBridge()
		{
			return ComputeBridge;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass17_0<TNodeDeserializer> where TNodeDeserializer : notnull, WrapperSetter
	{
		public ProducerSetter<WrapperSetter, TNodeDeserializer> nodeDeserializerFactory;

		private static object AwakeBridge;

		public _003C_003Ec__DisplayClass17_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add == 0)
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

		internal static bool InstantiateBridge()
		{
			return AwakeBridge == null;
		}

		internal static object LoginBridge()
		{
			return AwakeBridge;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public ServerSetter _RecordWriter;

		internal static _003C_003Ec__DisplayClass22_0 ConnectBridge;

		public _003C_003Ec__DisplayClass22_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 == 0)
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
			return _RecordWriter;
		}

		internal static bool StartBridge()
		{
			return ConnectBridge == null;
		}

		internal static _003C_003Ec__DisplayClass22_0 RemoveBridge()
		{
			return ConnectBridge;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass23_0<TNodeTypeResolver> where TNodeTypeResolver : notnull, ServerSetter
	{
		public ProducerSetter<ServerSetter, TNodeTypeResolver> nodeTypeResolverFactory;

		internal static object ResolveBridge;

		public _003C_003Ec__DisplayClass23_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 != 0)
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

		internal static bool DefineBridge()
		{
			return ResolveBridge == null;
		}

		internal static object IncludeBridge()
		{
			return ResolveBridge;
		}
	}

	private readonly CandidateWriter m_ProductWriter;

	private readonly MapAuthentication _RegistryWriter;

	private readonly ProcessorSetter<MappingSetter, WrapperSetter> _StateWriter;

	private readonly ProcessorSetter<MappingSetter, ServerSetter> _ValueWriter;

	private readonly Dictionary<RoleSingleton, Type> m_DecoratorWriter;

	private readonly TokenInvocation broadcasterWriter;

	private readonly Dictionary<Type, Type> m_WorkerWriter;

	private bool taskWriter;

	private bool m_UtilsWriter;

	private bool m_TestsWriter;

	private static ExpressionWriter ExcludeBridge;

	protected override ExpressionWriter Self => this;

	public ExpressionWriter(CandidateWriter context)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(context.GetTypeResolver());
		int num = 4;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 10:
				m_DecoratorWriter = new Dictionary<RoleSingleton, Type>
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
				num2 = 6;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb != 0)
				{
					num2 = 2;
				}
				break;
			case 4:
				m_ProductWriter = context;
				num2 = 7;
				break;
			case 8:
				m_WorkerWriter = new Dictionary<Type, Type>();
				num2 = 10;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 != 0)
				{
					num2 = 10;
				}
				break;
			case 7:
				_RegistryWriter = context.GetFactory();
				num2 = 8;
				break;
			case 2:
				_WatcherWriter.Add(typeof(TestsInvocation), delegate(AdvisorSetter inner)
				{
					int num3 = 3;
					int num4 = num3;
					AdvisorSetter result = default(AdvisorSetter);
					while (true)
					{
						switch (num4)
						{
						default:
							result = new TestsInvocation(inner, m_MethodWriter);
							num4 = 1;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 != 0)
							{
								num4 = 1;
							}
							break;
						case 1:
							return result;
						case 2:
							return inner;
						case 3:
							if (m_MethodWriter is InfoAuthentication)
							{
								num4 = 2;
								break;
							}
							goto default;
						}
					}
				});
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 == 0)
				{
					num2 = 1;
				}
				break;
			case 5:
				return;
			case 9:
				broadcasterWriter = new CallbackInvocation();
				num2 = 5;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 == 0)
				{
					num2 = 3;
				}
				break;
			case 6:
				_WatcherWriter.Add(typeof(ProductInvocation), (AdvisorSetter inner) => new ProductInvocation(inner));
				num2 = 2;
				break;
			case 1:
				_WatcherWriter.Add(typeof(SpecificationWriter), (AdvisorSetter inner) => new SpecificationWriter(inner));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb != 0)
				{
					num2 = 0;
				}
				break;
			default:
				_StateWriter = new ProcessorSetter<MappingSetter, WrapperSetter>
				{
					{
						typeof(ModelAuthentication),
						(MappingSetter _) => new ModelAuthentication(_RegistryWriter)
					},
					{
						typeof(ProcessAuthentication),
						(MappingSetter _) => new ProcessAuthentication(_RegistryWriter)
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
						(MappingSetter _) => new BridgeAuthentication(m_TestsWriter, broadcasterWriter, m_ResolverWriter)
					},
					{
						typeof(MessageAuthentication),
						(MappingSetter _) => new MessageAuthentication(_RegistryWriter)
					},
					{
						typeof(DatabaseAuthentication),
						(MappingSetter _) => new DatabaseAuthentication(_RegistryWriter, m_UtilsWriter)
					},
					{
						typeof(ServerAuthentication),
						(MappingSetter _) => new ServerAuthentication(_RegistryWriter)
					},
					{
						typeof(FacadeAuthentication),
						(MappingSetter _) => new FacadeAuthentication(_RegistryWriter, BuildTypeInspector(), taskWriter, m_UtilsWriter, broadcasterWriter)
					}
				};
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 != 0)
				{
					num2 = 3;
				}
				break;
			case 3:
				_ValueWriter = new ProcessorSetter<MappingSetter, ServerSetter>
				{
					{
						typeof(ExceptionAuthentication),
						(MappingSetter _) => new ExceptionAuthentication(m_WorkerWriter)
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
						(MappingSetter _) => new MapperAuthentication(m_DecoratorWriter)
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
				num2 = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 != 0)
				{
					num2 = 9;
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
				typeInspector = m_ProductWriter.GetTypeInspector();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public ExpressionWriter WithAttemptingUnquotedStringTypeDeserialization()
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
				m_TestsWriter = true;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public ExpressionWriter WithNodeDeserializer(WrapperSetter nodeDeserializer)
	{
		return WithNodeDeserializer(nodeDeserializer, delegate(ReponseSetter<WrapperSetter> w)
		{
			w.OnTop();
		});
	}

	public ExpressionWriter WithNodeDeserializer(WrapperSetter nodeDeserializer, Action<ReponseSetter<WrapperSetter>> where)
	{
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass16_0();
		CS_0024_003C_003E8__locals4.m_ClientWriter = nodeDeserializer;
		if (CS_0024_003C_003E8__locals4.m_ClientWriter == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1743264324 ^ -1743277190));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(--708144185 ^ 0x2A3539FD));
		}
		where(_StateWriter.CreateRegistrationLocationSelector(CS_0024_003C_003E8__locals4.m_ClientWriter.GetType(), (MappingSetter _) => CS_0024_003C_003E8__locals4.m_ClientWriter));
		return this;
	}

	public ExpressionWriter WithNodeDeserializer<TNodeDeserializer>(ProducerSetter<WrapperSetter, TNodeDeserializer> nodeDeserializerFactory, Action<ProxySetter<WrapperSetter>> where) where TNodeDeserializer : WrapperSetter
	{
		_003C_003Ec__DisplayClass17_0<TNodeDeserializer> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass17_0<TNodeDeserializer>();
		CS_0024_003C_003E8__locals3.nodeDeserializerFactory = nodeDeserializerFactory;
		if (CS_0024_003C_003E8__locals3.nodeDeserializerFactory == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-598551743 ^ -598571605));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1614185587 ^ -1614205367));
		}
		where(_StateWriter.CreateTrackingRegistrationLocationSelector(typeof(TNodeDeserializer), (WrapperSetter wrapped, MappingSetter _) => CS_0024_003C_003E8__locals3.nodeDeserializerFactory(wrapped)));
		return this;
	}

	public ExpressionWriter WithoutNodeDeserializer<TNodeDeserializer>() where TNodeDeserializer : WrapperSetter
	{
		return WithoutNodeDeserializer(typeof(TNodeDeserializer));
	}

	public ExpressionWriter WithoutNodeDeserializer(Type nodeDeserializerType)
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
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1244021215 ^ -1244010179));
			case 2:
				if (!(nodeDeserializerType == null))
				{
					_StateWriter.Remove(nodeDeserializerType);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba != 0)
					{
						num2 = 0;
					}
				}
				else
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 != 0)
					{
						num2 = 1;
					}
				}
				break;
			}
		}
	}

	public ExpressionWriter WithTypeDiscriminatingNodeDeserializer(Action<InvocationAttribute> configureTypeDiscriminatingNodeDeserializerOptions, int maxDepth = -1, int maxLength = -1)
	{
		ComparatorAttribute comparatorAttribute = new ComparatorAttribute();
		configureTypeDiscriminatingNodeDeserializerOptions(comparatorAttribute);
		SingletonAttribute nodeDeserializer = new SingletonAttribute(_StateWriter.BuildComponentList(), comparatorAttribute.m_DefinitionAttribute, maxDepth, maxLength);
		return WithNodeDeserializer(nodeDeserializer, delegate(ReponseSetter<WrapperSetter> s)
		{
			s.Before<PageAuthentication>();
		});
	}

	public ExpressionWriter WithNodeTypeResolver(ServerSetter nodeTypeResolver)
	{
		return WithNodeTypeResolver(nodeTypeResolver, delegate(ReponseSetter<ServerSetter> w)
		{
			w.OnTop();
		});
	}

	public ExpressionWriter WithNodeTypeResolver(ServerSetter nodeTypeResolver, Action<ReponseSetter<ServerSetter>> where)
	{
		_003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass22_0();
		CS_0024_003C_003E8__locals4._RecordWriter = nodeTypeResolver;
		if (CS_0024_003C_003E8__locals4._RecordWriter == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1244021215 ^ -1244010135));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x7A125A0E ^ 0x7A120FCA));
		}
		where(_ValueWriter.CreateRegistrationLocationSelector(CS_0024_003C_003E8__locals4._RecordWriter.GetType(), (MappingSetter _) => CS_0024_003C_003E8__locals4._RecordWriter));
		return this;
	}

	public ExpressionWriter WithNodeTypeResolver<TNodeTypeResolver>(ProducerSetter<ServerSetter, TNodeTypeResolver> nodeTypeResolverFactory, Action<ProxySetter<ServerSetter>> where) where TNodeTypeResolver : ServerSetter
	{
		_003C_003Ec__DisplayClass23_0<TNodeTypeResolver> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass23_0<TNodeTypeResolver>();
		CS_0024_003C_003E8__locals3.nodeTypeResolverFactory = nodeTypeResolverFactory;
		if (CS_0024_003C_003E8__locals3.nodeTypeResolverFactory == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-545065612 ^ -545086952));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1743264324 ^ -1743277960));
		}
		where(_ValueWriter.CreateTrackingRegistrationLocationSelector(typeof(TNodeTypeResolver), (ServerSetter wrapped, MappingSetter _) => CS_0024_003C_003E8__locals3.nodeTypeResolverFactory(wrapped)));
		return this;
	}

	public ExpressionWriter WithoutNodeTypeResolver<TNodeTypeResolver>() where TNodeTypeResolver : ServerSetter
	{
		return WithoutNodeTypeResolver(typeof(TNodeTypeResolver));
	}

	public ExpressionWriter WithoutNodeTypeResolver(Type nodeTypeResolverType)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 3:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-228218718 ^ -228196548));
			default:
				_ValueWriter.Remove(nodeTypeResolverType);
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb != 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				if (!(nodeTypeResolverType == null))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 == 0)
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

	public override ExpressionWriter WithTagMapping(RoleSingleton tag, Type type)
	{
		int num = 6;
		int num2 = num;
		Type value = default(Type);
		while (true)
		{
			switch (num2)
			{
			case 1:
				throw new ArgumentException(string.Format(DicSingleton.gE3WbyDVW(-545065612 ^ -545084060), value.FullName, tag), DicSingleton.gE3WbyDVW(0x7742C60 ^ 0x77474E0));
			default:
				m_DecoratorWriter.Add(tag, type);
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 != 0)
				{
					num2 = 4;
				}
				break;
			case 2:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x166FBD ^ 0x163921));
			case 3:
				if (!m_DecoratorWriter.TryGetValue(tag, out value))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 1;
			case 7:
				throw new ArgumentException(DicSingleton.gE3WbyDVW(0x55F5513C ^ 0x55F506F6));
			case 5:
				if (!(type == null))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 == 0)
					{
						num2 = 3;
					}
					break;
				}
				goto case 2;
			case 6:
				if (!tag.IsEmpty)
				{
					num2 = 5;
					break;
				}
				goto case 7;
			case 4:
				return this;
			}
		}
	}

	public ExpressionWriter WithTypeMapping<TInterface, TConcrete>() where TConcrete : TInterface
	{
		Type typeFromHandle = typeof(TInterface);
		Type typeFromHandle2 = typeof(TConcrete);
		if (!typeFromHandle.IsAssignableFrom(typeFromHandle2))
		{
			throw new InvalidOperationException(DicSingleton.gE3WbyDVW(0x540450D2 ^ 0x54040858) + typeFromHandle2.Name + DicSingleton.gE3WbyDVW(0x3353457 ^ 0x3356CF5) + typeFromHandle.Name + DicSingleton.gE3WbyDVW(--798431903 ^ 0x2F974FBB));
		}
		if (m_WorkerWriter.ContainsKey(typeFromHandle))
		{
			m_WorkerWriter[typeFromHandle] = typeFromHandle2;
		}
		else
		{
			m_WorkerWriter.Add(typeFromHandle, typeFromHandle2);
		}
		return this;
	}

	public ExpressionWriter WithoutTagMapping(RoleSingleton tag)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				throw new KeyNotFoundException(string.Format(DicSingleton.gE3WbyDVW(-1580624393 ^ -1580610287), tag));
			case 1:
				if (tag.IsEmpty)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 != 0)
					{
						num2 = 0;
					}
					break;
				}
				if (m_DecoratorWriter.Remove(tag))
				{
					return this;
				}
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f != 0)
				{
					num2 = 2;
				}
				break;
			default:
				throw new ArgumentException(DicSingleton.gE3WbyDVW(0x1A7A0414 ^ 0x1A7A53DE));
			}
		}
	}

	public ExpressionWriter IgnoreUnmatchedProperties()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				taskWriter = true;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4fda3adbb4ec45bdb14fe2ef97e570a8 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return this;
			}
		}
	}

	public ExpressionWriter WithDuplicateKeyChecking()
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
				m_UtilsWriter = true;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public ExporterSetter Build()
	{
		return DefinitionSetter.FromValueDeserializer(BuildValueDeserializer());
	}

	public AnnotationSetter BuildValueDeserializer()
	{
		return new IssuerInvocation(new GlobalInvocation(_StateWriter.BuildComponentList(), _ValueWriter.BuildComponentList(), broadcasterWriter));
	}

	internal static bool InterruptBridge()
	{
		return ExcludeBridge == null;
	}

	internal static ExpressionWriter DeleteBridge()
	{
		return ExcludeBridge;
	}
}
