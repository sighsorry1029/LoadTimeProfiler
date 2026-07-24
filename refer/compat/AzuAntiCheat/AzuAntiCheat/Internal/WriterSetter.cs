using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal abstract class WriterSetter<T> where T : WriterSetter<T>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public StrategySetter typeConverter;

		internal static object ConcatParameter;

		public _003C_003Ec__DisplayClass21_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal StrategySetter _003CWithTypeConverter_003Eb__0(MappingSetter _)
		{
			return typeConverter;
		}

		internal static bool MapParameter()
		{
			return ConcatParameter == null;
		}

		internal static object NewParameter()
		{
			return ConcatParameter;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass22_0<TYamlTypeConverter> where TYamlTypeConverter : notnull, StrategySetter
	{
		public ProducerSetter<StrategySetter, StrategySetter> typeConverterFactory;

		private static object AddParameter;

		public _003C_003Ec__DisplayClass22_0()
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

		internal StrategySetter _003CWithTypeConverter_003Eb__0(StrategySetter wrapped, MappingSetter _)
		{
			return typeConverterFactory(wrapped);
		}

		internal static bool PrepareParameter()
		{
			return AddParameter == null;
		}

		internal static object WriteParameter()
		{
			return AddParameter;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass26_0<TTypeInspector> where TTypeInspector : notnull, AdvisorSetter
	{
		public Func<AdvisorSetter, TTypeInspector> typeInspectorFactory;

		private static object PrintParameter;

		public _003C_003Ec__DisplayClass26_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9c47a25d924946efb9e023473a095794 != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal AdvisorSetter _003CWithTypeInspector_003Eb__0(AdvisorSetter inner)
		{
			return typeInspectorFactory(inner);
		}

		internal static bool CompareParameter()
		{
			return PrintParameter == null;
		}

		internal static object CloneParameter()
		{
			return PrintParameter;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass27_0<TTypeInspector> where TTypeInspector : notnull, AdvisorSetter
	{
		public ComparatorSetter<AdvisorSetter, AdvisorSetter, TTypeInspector> typeInspectorFactory;

		private static object ReadParameter;

		public _003C_003Ec__DisplayClass27_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal AdvisorSetter _003CWithTypeInspector_003Eb__0(AdvisorSetter wrapped, AdvisorSetter inner)
		{
			return typeInspectorFactory(wrapped, inner);
		}

		internal static bool ViewParameter()
		{
			return ReadParameter == null;
		}

		internal static object InitParameter()
		{
			return ReadParameter;
		}
	}

	internal ConfigSetter invocationSetter;

	internal ConnectionSetter m_AuthenticationSetter;

	internal readonly DispatcherWriter _AttributeSetter;

	internal readonly ProcessorSetter<MappingSetter, StrategySetter> interpreterSetter;

	internal readonly ProcessorSetter<AdvisorSetter, AdvisorSetter> m_SingletonSetter;

	internal bool issuerSetter;

	internal bool fieldSetter;

	internal CodeWriter _RuleSetter;

	internal PublisherInvocation _SerializerSetter;

	internal static object SelectParameter;

	protected abstract T Self { get; }

	internal WriterSetter(ConnectionSetter typeResolver)
	{
		GetterIssuer.DeleteInitializer();
		invocationSetter = InfoAuthentication.m_DicAuthentication;
		_SerializerSetter = PublisherInvocation.Default;
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 == 0)
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
				_AttributeSetter = new DispatcherWriter();
				num = 5;
				break;
			case 0:
				return;
			case 2:
				_RuleSetter = new CodeWriter();
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 != 0)
				{
					num = 0;
				}
				break;
			case 3:
				m_SingletonSetter = new ProcessorSetter<AdvisorSetter, AdvisorSetter>();
				num = 4;
				break;
			case 5:
				interpreterSetter = new ProcessorSetter<MappingSetter, StrategySetter>
				{
					{
						typeof(PrototypeAttribute),
						(MappingSetter _) => new PrototypeAttribute(jsonCompatible: false)
					},
					{
						typeof(FilterAttribute),
						(MappingSetter _) => new FilterAttribute()
					}
				};
				num = 3;
				break;
			case 4:
				m_AuthenticationSetter = typeResolver ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1133601918 ^ -1133588764));
				num = 2;
				break;
			}
		}
	}

	public T IgnoreFields()
	{
		issuerSetter = true;
		return Self;
	}

	public T IncludeNonPublicProperties()
	{
		fieldSetter = true;
		return Self;
	}

	public T EnablePrivateConstructors()
	{
		_RuleSetter.AllowPrivateConstructors = true;
		return Self;
	}

	public T WithNamingConvention(ConfigSetter namingConvention)
	{
		invocationSetter = namingConvention ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1741204886 ^ -1741223960));
		return Self;
	}

	public T WithTypeResolver(ConnectionSetter typeResolver)
	{
		m_AuthenticationSetter = typeResolver ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x408F2744 ^ 0x408F7222));
		return Self;
	}

	public abstract T WithTagMapping(RoleSingleton tag, Type type);

	public T WithAttributeOverride<TClass>(Expression<Func<TClass, object>> propertyAccessor, Attribute attribute)
	{
		_AttributeSetter.Add(propertyAccessor, attribute);
		return Self;
	}

	public T WithAttributeOverride(Type type, string member, Attribute attribute)
	{
		_AttributeSetter.Add(type, member, attribute);
		return Self;
	}

	public T WithTypeConverter(StrategySetter typeConverter)
	{
		return WithTypeConverter(typeConverter, delegate(ReponseSetter<StrategySetter> w)
		{
			w.OnTop();
		});
	}

	public T WithTypeConverter(StrategySetter typeConverter, Action<ReponseSetter<StrategySetter>> where)
	{
		_003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass21_0();
		CS_0024_003C_003E8__locals4.typeConverter = typeConverter;
		if (CS_0024_003C_003E8__locals4.typeConverter == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x408F2744 ^ 0x408F72E2));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x14AB6F1E ^ 0x14AB3ADA));
		}
		where(interpreterSetter.CreateRegistrationLocationSelector(CS_0024_003C_003E8__locals4.typeConverter.GetType(), (MappingSetter _) => CS_0024_003C_003E8__locals4.typeConverter));
		return Self;
	}

	public T WithTypeConverter<TYamlTypeConverter>(ProducerSetter<StrategySetter, StrategySetter> typeConverterFactory, Action<ProxySetter<StrategySetter>> where) where TYamlTypeConverter : StrategySetter
	{
		_003C_003Ec__DisplayClass22_0<TYamlTypeConverter> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass22_0<TYamlTypeConverter>();
		CS_0024_003C_003E8__locals3.typeConverterFactory = typeConverterFactory;
		if (CS_0024_003C_003E8__locals3.typeConverterFactory == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x69B67B3A ^ 0x69B62EE8));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(--1509395337 ^ 0x59F7DE4D));
		}
		where(interpreterSetter.CreateTrackingRegistrationLocationSelector(typeof(TYamlTypeConverter), (StrategySetter wrapped, MappingSetter _) => CS_0024_003C_003E8__locals3.typeConverterFactory(wrapped)));
		return Self;
	}

	public T WithoutTypeConverter<TYamlTypeConverter>() where TYamlTypeConverter : StrategySetter
	{
		return WithoutTypeConverter(typeof(TYamlTypeConverter));
	}

	public T WithoutTypeConverter(Type converterType)
	{
		if (converterType == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-940539791 ^ -940518001));
		}
		interpreterSetter.Remove(converterType);
		return Self;
	}

	public T WithTypeInspector<TTypeInspector>(Func<AdvisorSetter, TTypeInspector> typeInspectorFactory) where TTypeInspector : AdvisorSetter
	{
		return WithTypeInspector(typeInspectorFactory, delegate(ReponseSetter<AdvisorSetter> w)
		{
			w.OnTop();
		});
	}

	public T WithTypeInspector<TTypeInspector>(Func<AdvisorSetter, TTypeInspector> typeInspectorFactory, Action<ReponseSetter<AdvisorSetter>> where) where TTypeInspector : AdvisorSetter
	{
		_003C_003Ec__DisplayClass26_0<TTypeInspector> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass26_0<TTypeInspector>();
		CS_0024_003C_003E8__locals3.typeInspectorFactory = typeInspectorFactory;
		if (CS_0024_003C_003E8__locals3.typeInspectorFactory == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x3C33E48 ^ 0x3C36854));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x7A125A0E ^ 0x7A120FCA));
		}
		where(m_SingletonSetter.CreateRegistrationLocationSelector(typeof(TTypeInspector), (AdvisorSetter inner) => CS_0024_003C_003E8__locals3.typeInspectorFactory(inner)));
		return Self;
	}

	public T WithTypeInspector<TTypeInspector>(ComparatorSetter<AdvisorSetter, AdvisorSetter, TTypeInspector> typeInspectorFactory, Action<ProxySetter<AdvisorSetter>> where) where TTypeInspector : AdvisorSetter
	{
		_003C_003Ec__DisplayClass27_0<TTypeInspector> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass27_0<TTypeInspector>();
		CS_0024_003C_003E8__locals3.typeInspectorFactory = typeInspectorFactory;
		if (CS_0024_003C_003E8__locals3.typeInspectorFactory == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1338893851 ^ -1338880007));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x2BC349D6 ^ 0x2BC31C12));
		}
		where(m_SingletonSetter.CreateTrackingRegistrationLocationSelector(typeof(TTypeInspector), (AdvisorSetter wrapped, AdvisorSetter inner) => CS_0024_003C_003E8__locals3.typeInspectorFactory(wrapped, inner)));
		return Self;
	}

	public T WithoutTypeInspector<TTypeInspector>() where TTypeInspector : AdvisorSetter
	{
		return WithoutTypeInspector(typeof(TTypeInspector));
	}

	public T WithoutTypeInspector(Type inspectorType)
	{
		if (inspectorType == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-359091888 ^ -359078120));
		}
		m_SingletonSetter.Remove(inspectorType);
		return Self;
	}

	public T WithYamlFormatter(PublisherInvocation formatter)
	{
		_SerializerSetter = formatter ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x1679942F ^ 0x16793A17));
		return Self;
	}

	protected IEnumerable<StrategySetter> BuildTypeConverters()
	{
		return interpreterSetter.BuildComponentList();
	}

	internal static bool ChangeParameter()
	{
		return SelectParameter == null;
	}

	internal static object CreateParameter()
	{
		return SelectParameter;
	}
}
