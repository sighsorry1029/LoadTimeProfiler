using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal abstract class MockWriter<T> where T : MockWriter<T>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public StrategySetter typeConverter;

		internal static object CalcBridge;

		public _003C_003Ec__DisplayClass14_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4e61b266153f422fa6c595cfef4d40d3 == 0)
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

		internal static bool LogoutBridge()
		{
			return CalcBridge == null;
		}

		internal static object CountBridge()
		{
			return CalcBridge;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass15_0<TYamlTypeConverter> where TYamlTypeConverter : notnull, StrategySetter
	{
		public ProducerSetter<StrategySetter, StrategySetter> typeConverterFactory;

		internal static object SetBridge;

		public _003C_003Ec__DisplayClass15_0()
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

		internal StrategySetter _003CWithTypeConverter_003Eb__0(StrategySetter wrapped, MappingSetter _)
		{
			return typeConverterFactory(wrapped);
		}

		internal static bool PushBridge()
		{
			return SetBridge == null;
		}

		internal static object ValidateBridge()
		{
			return SetBridge;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass19_0<TTypeInspector> where TTypeInspector : notnull, AdvisorSetter
	{
		public Func<AdvisorSetter, TTypeInspector> typeInspectorFactory;

		internal static object EnableBridge;

		public _003C_003Ec__DisplayClass19_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 != 0)
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

		internal static bool SortBridge()
		{
			return EnableBridge == null;
		}

		internal static object InsertBridge()
		{
			return EnableBridge;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass20_0<TTypeInspector> where TTypeInspector : notnull, AdvisorSetter
	{
		public ComparatorSetter<AdvisorSetter, AdvisorSetter, TTypeInspector> typeInspectorFactory;

		internal static object FindBridge;

		public _003C_003Ec__DisplayClass20_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 == 0)
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

		internal static bool VisitBridge()
		{
			return FindBridge == null;
		}

		internal static object OrderBridge()
		{
			return FindBridge;
		}
	}

	internal ConfigSetter m_MethodWriter;

	internal ConnectionSetter m_TemplateWriter;

	internal readonly ProcessorSetter<MappingSetter, StrategySetter> predicateWriter;

	internal readonly ProcessorSetter<AdvisorSetter, AdvisorSetter> _WatcherWriter;

	internal bool customerWriter;

	internal CodeWriter m_SystemWriter;

	internal PublisherInvocation m_ResolverWriter;

	private static object PrintBridge;

	protected abstract T Self { get; }

	internal MockWriter(ConnectionSetter typeResolver)
	{
		GetterIssuer.DeleteInitializer();
		m_MethodWriter = InfoAuthentication.m_DicAuthentication;
		m_ResolverWriter = PublisherInvocation.Default;
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 1:
				m_SystemWriter = new CodeWriter();
				num = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 == 0)
				{
					num = 3;
				}
				break;
			case 2:
				_WatcherWriter = new ProcessorSetter<AdvisorSetter, AdvisorSetter>();
				num = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c2b9915913b8461884afdca5d98855ec != 0)
				{
					num = 4;
				}
				break;
			case 3:
				return;
			default:
				predicateWriter = new ProcessorSetter<MappingSetter, StrategySetter> { 
				{
					typeof(PrototypeAttribute),
					(MappingSetter _) => new PrototypeAttribute(jsonCompatible: false)
				} };
				num = 2;
				break;
			case 4:
				m_TemplateWriter = typeResolver ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-823738529 ^ -823727559));
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 == 0)
				{
					num = 1;
				}
				break;
			}
		}
	}

	public T WithNamingConvention(ConfigSetter namingConvention)
	{
		m_MethodWriter = namingConvention ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x9000142 ^ 0x90054C0));
		return Self;
	}

	public T WithTypeResolver(ConnectionSetter typeResolver)
	{
		m_TemplateWriter = typeResolver ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-359091888 ^ -359078858));
		return Self;
	}

	public abstract T WithTagMapping(RoleSingleton tag, Type type);

	public T WithTypeConverter(StrategySetter typeConverter)
	{
		return WithTypeConverter(typeConverter, delegate(ReponseSetter<StrategySetter> w)
		{
			w.OnTop();
		});
	}

	public T WithTypeConverter(StrategySetter typeConverter, Action<ReponseSetter<StrategySetter>> where)
	{
		_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass14_0();
		CS_0024_003C_003E8__locals4.typeConverter = typeConverter;
		if (CS_0024_003C_003E8__locals4.typeConverter == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-948533799 ^ -948514689));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1741204886 ^ -1741224018));
		}
		where(predicateWriter.CreateRegistrationLocationSelector(CS_0024_003C_003E8__locals4.typeConverter.GetType(), (MappingSetter _) => CS_0024_003C_003E8__locals4.typeConverter));
		return Self;
	}

	public T WithTypeConverter<TYamlTypeConverter>(ProducerSetter<StrategySetter, StrategySetter> typeConverterFactory, Action<ProxySetter<StrategySetter>> where) where TYamlTypeConverter : StrategySetter
	{
		_003C_003Ec__DisplayClass15_0<TYamlTypeConverter> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass15_0<TYamlTypeConverter>();
		CS_0024_003C_003E8__locals3.typeConverterFactory = typeConverterFactory;
		if (CS_0024_003C_003E8__locals3.typeConverterFactory == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-428683152 ^ -428702302));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x166FBD ^ 0x163A79));
		}
		where(predicateWriter.CreateTrackingRegistrationLocationSelector(typeof(TYamlTypeConverter), (StrategySetter wrapped, MappingSetter _) => CS_0024_003C_003E8__locals3.typeConverterFactory(wrapped)));
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
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x540450D2 ^ 0x5404052C));
		}
		predicateWriter.Remove(converterType);
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
		_003C_003Ec__DisplayClass19_0<TTypeInspector> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass19_0<TTypeInspector>();
		CS_0024_003C_003E8__locals3.typeInspectorFactory = typeInspectorFactory;
		if (CS_0024_003C_003E8__locals3.typeInspectorFactory == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-34102588 ^ -34081576));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-545065612 ^ -545087312));
		}
		where(_WatcherWriter.CreateRegistrationLocationSelector(typeof(TTypeInspector), (AdvisorSetter inner) => CS_0024_003C_003E8__locals3.typeInspectorFactory(inner)));
		return Self;
	}

	public T WithTypeInspector<TTypeInspector>(ComparatorSetter<AdvisorSetter, AdvisorSetter, TTypeInspector> typeInspectorFactory, Action<ProxySetter<AdvisorSetter>> where) where TTypeInspector : AdvisorSetter
	{
		_003C_003Ec__DisplayClass20_0<TTypeInspector> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass20_0<TTypeInspector>();
		CS_0024_003C_003E8__locals3.typeInspectorFactory = typeInspectorFactory;
		if (CS_0024_003C_003E8__locals3.typeInspectorFactory == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-447849421 ^ -447870417));
		}
		if (where == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1447578472 ^ -1447567012));
		}
		where(_WatcherWriter.CreateTrackingRegistrationLocationSelector(typeof(TTypeInspector), (AdvisorSetter wrapped, AdvisorSetter inner) => CS_0024_003C_003E8__locals3.typeInspectorFactory(wrapped, inner)));
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
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x6DF53C90 ^ 0x6DF56AD8));
		}
		_WatcherWriter.Remove(inspectorType);
		return Self;
	}

	public T WithYamlFormatter(PublisherInvocation formatter)
	{
		m_ResolverWriter = formatter ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0xFB046CE ^ 0xFB0E8F6));
		return Self;
	}

	protected IEnumerable<StrategySetter> BuildTypeConverters()
	{
		return predicateWriter.BuildComponentList();
	}

	internal static bool CompareBridge()
	{
		return PrintBridge == null;
	}

	internal static object CloneBridge()
	{
		return PrintBridge;
	}
}
