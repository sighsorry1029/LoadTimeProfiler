using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal abstract class ThreadBase<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] T> where T : ThreadBase<T>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass19_0
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public StatusPrototype typeConverter;

		internal static object VerifyConfiguration;

		public _003C_003Ec__DisplayClass19_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal StatusPrototype _003CWithTypeConverter_003Eb__0(RegPrototype _)
		{
			return typeConverter;
		}

		internal static bool PopConfiguration()
		{
			return VerifyConfiguration == null;
		}

		internal static object PostConfiguration()
		{
			return VerifyConfiguration;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass20_0<TYamlTypeConverter> where TYamlTypeConverter : StatusPrototype
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1, 1 })]
		public ConfigurationBase<StatusPrototype, StatusPrototype> typeConverterFactory;

		private static object CallConfiguration;

		public _003C_003Ec__DisplayClass20_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal StatusPrototype _003CWithTypeConverter_003Eb__0(StatusPrototype wrapped, RegPrototype _)
		{
			return typeConverterFactory(wrapped);
		}

		internal static bool ConcatConfiguration()
		{
			return CallConfiguration == null;
		}

		internal static object MapConfiguration()
		{
			return CallConfiguration;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass24_0<TTypeInspector> where TTypeInspector : InstancePrototype
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1, 0 })]
		public Func<InstancePrototype, TTypeInspector> typeInspectorFactory;

		private static object WriteConfiguration;

		public _003C_003Ec__DisplayClass24_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal InstancePrototype _003CWithTypeInspector_003Eb__0(InstancePrototype inner)
		{
			return typeInspectorFactory(inner);
		}

		internal static bool PrintConfiguration()
		{
			return WriteConfiguration == null;
		}

		internal static object CompareConfiguration()
		{
			return WriteConfiguration;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass25_0<TTypeInspector> where TTypeInspector : InstancePrototype
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1, 1, 0 })]
		public SpecificationBase<InstancePrototype, InstancePrototype, TTypeInspector> typeInspectorFactory;

		internal static object CloneConfiguration;

		public _003C_003Ec__DisplayClass25_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal InstancePrototype _003CWithTypeInspector_003Eb__0(InstancePrototype wrapped, InstancePrototype inner)
		{
			return typeInspectorFactory(wrapped, inner);
		}

		internal static bool ReadConfiguration()
		{
			return CloneConfiguration == null;
		}

		internal static object ViewConfiguration()
		{
			return CloneConfiguration;
		}
	}

	internal BroadcasterPrototype mappingBase;

	internal OrderPrototype schemaBase;

	internal readonly FactoryInterceptor structBase;

	internal readonly MerchantPrototype<RegPrototype, StatusPrototype> classBase;

	internal readonly MerchantPrototype<InstancePrototype, InstancePrototype> _ObjectBase;

	private bool consumerBase;

	private bool propertyBase;

	internal static object SetupConfiguration;

	protected abstract T Self { get; }

	internal ThreadBase(OrderPrototype typeResolver)
	{
		GetterIssuer.DeleteInitializer();
		mappingBase = WrapperFilter.m_ServerFilter;
		base._002Ector();
		int num = 2;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 2:
				structBase = new FactoryInterceptor();
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f == 0)
				{
					num = 1;
				}
				break;
			case 4:
				return;
			default:
				_ObjectBase = new MerchantPrototype<InstancePrototype, InstancePrototype>();
				num = 3;
				break;
			case 1:
				classBase = new MerchantPrototype<RegPrototype, StatusPrototype>
				{
					{
						typeof(TagFilter),
						(RegPrototype _) => new TagFilter(jsonCompatible: false)
					},
					{
						typeof(StubFilter),
						(RegPrototype _) => new StubFilter()
					}
				};
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 == 0)
				{
					num = 0;
				}
				break;
			case 3:
				schemaBase = typeResolver ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1544119467 ^ -1544106445));
				num = 4;
				break;
			}
		}
	}

	internal InstancePrototype BuildTypeInspector()
	{
		int num = 2;
		int num2 = num;
		InstancePrototype instancePrototype = default(InstancePrototype);
		while (true)
		{
			switch (num2)
			{
			case 2:
				instancePrototype = new AdvisorInterceptor(schemaBase, propertyBase);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba == 0)
				{
					num2 = 1;
				}
				continue;
			default:
				return _ObjectBase.BuildComponentChain(instancePrototype);
			case 1:
				if (consumerBase)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 != 0)
					{
						num2 = 0;
					}
					continue;
				}
				break;
			case 4:
				break;
			}
			instancePrototype = new MerchantInterceptor(new CreatorInterceptor(schemaBase), instancePrototype);
			num2 = 3;
		}
	}

	public T IgnoreFields()
	{
		consumerBase = true;
		return Self;
	}

	public T IncludeNonPublicProperties()
	{
		propertyBase = true;
		return Self;
	}

	public T WithNamingConvention(BroadcasterPrototype namingConvention)
	{
		mappingBase = namingConvention ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-166253478 ^ -166233640));
		return Self;
	}

	public T WithTypeResolver(OrderPrototype typeResolver)
	{
		schemaBase = typeResolver ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(--650088194 ^ 0x26BFDA64));
		return Self;
	}

	public abstract T WithTagMapping(ValueFactory tag, Type type);

	public T WithAttributeOverride<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] TClass>(Expression<Func<TClass, object>> propertyAccessor, Attribute attribute)
	{
		structBase.Add(propertyAccessor, attribute);
		return Self;
	}

	public T WithAttributeOverride(Type type, string member, Attribute attribute)
	{
		structBase.Add(type, member, attribute);
		return Self;
	}

	public T WithTypeConverter(StatusPrototype typeConverter)
	{
		return WithTypeConverter(typeConverter, delegate(ParamPrototype<StatusPrototype> w)
		{
			w.OnTop();
		});
	}

	public T WithTypeConverter(StatusPrototype typeConverter, Action<ParamPrototype<StatusPrototype>> where)
	{
		_003C_003Ec__DisplayClass19_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass19_0();
		CS_0024_003C_003E8__locals4.typeConverter = typeConverter;
		if (CS_0024_003C_003E8__locals4.typeConverter == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1931860206 ^ -1931840844));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x5A1F7167 ^ 0x5A1F24A3));
		}
		where(classBase.CreateRegistrationLocationSelector(CS_0024_003C_003E8__locals4.typeConverter.GetType(), (RegPrototype _) => CS_0024_003C_003E8__locals4.typeConverter));
		return Self;
	}

	public T WithTypeConverter<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] TYamlTypeConverter>(ConfigurationBase<StatusPrototype, StatusPrototype> typeConverterFactory, Action<FacadePrototype<StatusPrototype>> where) where TYamlTypeConverter : StatusPrototype
	{
		_003C_003Ec__DisplayClass20_0<TYamlTypeConverter> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass20_0<TYamlTypeConverter>();
		CS_0024_003C_003E8__locals3.typeConverterFactory = typeConverterFactory;
		if (CS_0024_003C_003E8__locals3.typeConverterFactory == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x6BAF1854 ^ 0x6BAF4D86));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1447578472 ^ -1447567012));
		}
		where(classBase.CreateTrackingRegistrationLocationSelector(typeof(TYamlTypeConverter), (StatusPrototype wrapped, RegPrototype _) => CS_0024_003C_003E8__locals3.typeConverterFactory(wrapped)));
		return Self;
	}

	public T WithoutTypeConverter<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] TYamlTypeConverter>() where TYamlTypeConverter : StatusPrototype
	{
		return WithoutTypeConverter(typeof(TYamlTypeConverter));
	}

	public T WithoutTypeConverter(Type converterType)
	{
		if (converterType == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1385030784 ^ -1385017730));
		}
		classBase.Remove(converterType);
		return Self;
	}

	public T WithTypeInspector<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] TTypeInspector>(Func<InstancePrototype, TTypeInspector> typeInspectorFactory) where TTypeInspector : InstancePrototype
	{
		return WithTypeInspector(typeInspectorFactory, delegate(ParamPrototype<InstancePrototype> w)
		{
			w.OnTop();
		});
	}

	public T WithTypeInspector<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] TTypeInspector>(Func<InstancePrototype, TTypeInspector> typeInspectorFactory, Action<ParamPrototype<InstancePrototype>> where) where TTypeInspector : InstancePrototype
	{
		_003C_003Ec__DisplayClass24_0<TTypeInspector> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass24_0<TTypeInspector>();
		CS_0024_003C_003E8__locals3.typeInspectorFactory = typeInspectorFactory;
		if (CS_0024_003C_003E8__locals3.typeInspectorFactory == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x21AFFB2B ^ 0x21AFAD37));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-32559551 ^ -32539771));
		}
		where(_ObjectBase.CreateRegistrationLocationSelector(typeof(TTypeInspector), (InstancePrototype inner) => CS_0024_003C_003E8__locals3.typeInspectorFactory(inner)));
		return Self;
	}

	public T WithTypeInspector<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] TTypeInspector>(SpecificationBase<InstancePrototype, InstancePrototype, TTypeInspector> typeInspectorFactory, Action<FacadePrototype<InstancePrototype>> where) where TTypeInspector : InstancePrototype
	{
		_003C_003Ec__DisplayClass25_0<TTypeInspector> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass25_0<TTypeInspector>();
		CS_0024_003C_003E8__locals3.typeInspectorFactory = typeInspectorFactory;
		if (CS_0024_003C_003E8__locals3.typeInspectorFactory == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x5A8BEE ^ 0x5ADDF2));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1064640644 ^ -1064662344));
		}
		where(_ObjectBase.CreateTrackingRegistrationLocationSelector(typeof(TTypeInspector), (InstancePrototype wrapped, InstancePrototype inner) => CS_0024_003C_003E8__locals3.typeInspectorFactory(wrapped, inner)));
		return Self;
	}

	public T WithoutTypeInspector<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] TTypeInspector>() where TTypeInspector : InstancePrototype
	{
		return WithoutTypeInspector(typeof(TTypeInspector));
	}

	public T WithoutTypeInspector(Type inspectorType)
	{
		if (inspectorType == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(--708144185 ^ 0x2A353A71));
		}
		_ObjectBase.Remove(inspectorType);
		return Self;
	}

	protected IEnumerable<StatusPrototype> BuildTypeConverters()
	{
		return classBase.BuildComponentList();
	}

	internal static bool SelectConfiguration()
	{
		return SetupConfiguration == null;
	}

	internal static object ChangeConfiguration()
	{
		return SetupConfiguration;
	}
}
