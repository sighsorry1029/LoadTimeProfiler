using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class IssuerInterceptor : StrategyInterceptor
{
	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
	public sealed class SerializerInterceptor : RequestPrototype
	{
		private readonly RequestPrototype producerInterceptor;

		private readonly FactoryInterceptor comparatorInterceptor;

		private readonly Type _DefinitionInterceptor;

		private static SerializerInterceptor OrderMerchant;

		public string Name => producerInterceptor.Name;

		public bool CanWrite => producerInterceptor.CanWrite;

		public Type Type => producerInterceptor.Type;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
		public Type TypeOverride
		{
			[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
			get
			{
				return producerInterceptor.TypeOverride;
			}
			[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
			set
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
						producerInterceptor.TypeOverride = value;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add != 0)
						{
							num2 = 0;
						}
						break;
					}
				}
			}
		}

		public int Order
		{
			get
			{
				return producerInterceptor.Order;
			}
			set
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
						producerInterceptor.Order = value;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa != 0)
						{
							num2 = 0;
						}
						break;
					}
				}
			}
		}

		public RuleFactory ScalarStyle
		{
			get
			{
				return producerInterceptor.ScalarStyle;
			}
			set
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
						producerInterceptor.ScalarStyle = value;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 != 0)
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

		public SerializerInterceptor(RequestPrototype baseDescriptor, FactoryInterceptor overrides, Type classType)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 2;
			while (true)
			{
				switch (num)
				{
				default:
					return;
				case 1:
					_DefinitionInterceptor = classType;
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 != 0)
					{
						num = 0;
					}
					break;
				case 3:
					comparatorInterceptor = overrides;
					num = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 == 0)
					{
						num = 1;
					}
					break;
				case 0:
					return;
				case 2:
					producerInterceptor = baseDescriptor;
					num = 3;
					break;
				}
			}
		}

		public void Write(object target, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] object value)
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
					producerInterceptor.Write(target, value);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		public T GetCustomAttribute<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] T>() where T : Attribute
		{
			return comparatorInterceptor.GetAttribute<T>(_DefinitionInterceptor, Name) ?? producerInterceptor.GetCustomAttribute<T>();
		}

		public UtilsPrototype Read(object target)
		{
			return producerInterceptor.Read(target);
		}

		internal static bool UpdateMerchant()
		{
			return OrderMerchant == null;
		}

		internal static SerializerInterceptor SearchMerchant()
		{
			return OrderMerchant;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public IssuerInterceptor m_ComposerInterceptor;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public Type m_GlobalInterceptor;

		private static _003C_003Ec__DisplayClass3_0 StopMerchant;

		public _003C_003Ec__DisplayClass3_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 != 0)
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
		internal RequestPrototype _003CGetProperties_003Eb__0(RequestPrototype p)
		{
			return new SerializerInterceptor(p, m_ComposerInterceptor.ruleInterceptor, m_GlobalInterceptor);
		}

		internal static bool ExcludeMerchant()
		{
			return StopMerchant == null;
		}

		internal static _003C_003Ec__DisplayClass3_0 InterruptMerchant()
		{
			return StopMerchant;
		}
	}

	private readonly InstancePrototype fieldInterceptor;

	private readonly FactoryInterceptor ruleInterceptor;

	internal static IssuerInterceptor InsertMerchant;

	public IssuerInterceptor(InstancePrototype innerTypeDescriptor, FactoryInterceptor overrides)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 2;
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 2:
				fieldInterceptor = innerTypeDescriptor;
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 == 0)
				{
					num = 1;
				}
				break;
			case 0:
				return;
			case 1:
				ruleInterceptor = overrides;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 != 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	public override IEnumerable<RequestPrototype> GetProperties(Type type, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] object container)
	{
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass3_0();
		CS_0024_003C_003E8__locals5.m_ComposerInterceptor = this;
		CS_0024_003C_003E8__locals5.m_GlobalInterceptor = type;
		IEnumerable<RequestPrototype> enumerable = fieldInterceptor.GetProperties(CS_0024_003C_003E8__locals5.m_GlobalInterceptor, container);
		if (ruleInterceptor != null)
		{
			enumerable = enumerable.Select((Func<RequestPrototype, RequestPrototype>)([_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)] (RequestPrototype p) => new SerializerInterceptor(p, CS_0024_003C_003E8__locals5.m_ComposerInterceptor.ruleInterceptor, CS_0024_003C_003E8__locals5.m_GlobalInterceptor)));
		}
		return enumerable;
	}

	internal static bool FindMerchant()
	{
		return InsertMerchant == null;
	}

	internal static IssuerInterceptor VisitMerchant()
	{
		return InsertMerchant;
	}
}
