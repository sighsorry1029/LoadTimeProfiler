using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class ParserFilter : WorkerPrototype
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public RequestPrototype _EventFilter;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public object m_InstanceFilter;

		private static _003C_003Ec__DisplayClass4_0 CollectInstance;

		public _003C_003Ec__DisplayClass4_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
		internal void _003CYamlDotNet_002ESerialization_002EINodeDeserializer_002EDeserialize_003Eb__0(object v)
		{
			int num = 2;
			int num2 = num;
			object value = default(object);
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 2:
					value = ContainerInterceptor.ChangeType(v, _EventFilter.Type);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3a460cd74a4c809e0f755964f2077b != 0)
					{
						num2 = 1;
					}
					break;
				case 0:
					return;
				case 1:
					_EventFilter.Write(m_InstanceFilter, value);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		internal static bool ManageInstance()
		{
			return CollectInstance == null;
		}

		internal static _003C_003Ec__DisplayClass4_0 ForgotInstance()
		{
			return CollectInstance;
		}
	}

	private readonly InitializerPrototype m_RequestFilter;

	private readonly InstancePrototype paramFilter;

	private readonly bool m_FacadeFilter;

	private static ParserFilter CustomizeInstance;

	public ParserFilter(InitializerPrototype objectFactory, InstancePrototype typeDescriptor, bool ignoreUnmatched)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 == 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			case 2:
				return;
			case 3:
				m_FacadeFilter = ignoreUnmatched;
				num = 2;
				break;
			case 1:
				m_RequestFilter = objectFactory ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-380885952 ^ -380865816));
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 != 0)
				{
					num = 0;
				}
				break;
			default:
				paramFilter = typeDescriptor ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-359091888 ^ -359082482));
				num = 3;
				break;
			}
		}
	}

	bool WorkerPrototype.Deserialize(StubReader parser, Type expectedType, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 1, 1, 1, 2 })] Func<StubReader, Type, object> nestedObjectDeserializer, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] out object value)
	{
		if (!parser.TryConsume<QueueFactory>(out var _))
		{
			value = null;
			return false;
		}
		Type type = Nullable.GetUnderlyingType(expectedType) ?? expectedType;
		value = m_RequestFilter.Create(type);
		ListFactory event2;
		while (!parser.TryConsume<ListFactory>(out event2))
		{
			_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass4_0();
			ClassFactory classFactory = parser.Consume<ClassFactory>();
			CS_0024_003C_003E8__locals9._EventFilter = paramFilter.GetProperty(type, null, classFactory.Value, m_FacadeFilter);
			if (CS_0024_003C_003E8__locals9._EventFilter == null)
			{
				parser.SkipThisAndNestedEvents();
				continue;
			}
			object obj = nestedObjectDeserializer(parser, CS_0024_003C_003E8__locals9._EventFilter.Type);
			if (obj is IteratorPrototype iteratorPrototype)
			{
				CS_0024_003C_003E8__locals9.m_InstanceFilter = value;
				iteratorPrototype.ValueAvailable += [_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)] (object v) =>
				{
					int num = 2;
					int num2 = num;
					object value3 = default(object);
					while (true)
					{
						switch (num2)
						{
						default:
							return;
						case 2:
							value3 = ContainerInterceptor.ChangeType(v, CS_0024_003C_003E8__locals9._EventFilter.Type);
							num2 = 1;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3a460cd74a4c809e0f755964f2077b != 0)
							{
								num2 = 1;
							}
							break;
						case 0:
							return;
						case 1:
							CS_0024_003C_003E8__locals9._EventFilter.Write(CS_0024_003C_003E8__locals9.m_InstanceFilter, value3);
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c != 0)
							{
								num2 = 0;
							}
							break;
						}
					}
				};
			}
			else
			{
				object value2 = ContainerInterceptor.ChangeType(obj, CS_0024_003C_003E8__locals9._EventFilter.Type);
				CS_0024_003C_003E8__locals9._EventFilter.Write(value, value2);
			}
		}
		return true;
	}

	internal static bool CancelInstance()
	{
		return CustomizeInstance == null;
	}

	internal static ParserFilter ReflectInstance()
	{
		return CustomizeInstance;
	}
}
