using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class CreatorInterceptor : StrategyInterceptor
{
	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
	private sealed class DatabaseInterceptor : RequestPrototype
	{
		private readonly FieldInfo _ErrorInterceptor;

		private readonly OrderPrototype m_RegInterceptor;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
		[CompilerGenerated]
		private Type m_ReponseInterceptor;

		[CompilerGenerated]
		private int _ProxyInterceptor;

		[CompilerGenerated]
		private RuleFactory m_ModelInterceptor;

		internal static DatabaseInterceptor IncludeUtils;

		public string Name => _ErrorInterceptor.Name;

		public Type Type => _ErrorInterceptor.FieldType;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
		public Type TypeOverride
		{
			[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
			[CompilerGenerated]
			get
			{
				return m_ReponseInterceptor;
			}
			[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
			[CompilerGenerated]
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
						m_ReponseInterceptor = value;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9c47a25d924946efb9e023473a095794 == 0)
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
			[CompilerGenerated]
			get
			{
				return _ProxyInterceptor;
			}
			[CompilerGenerated]
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
						_ProxyInterceptor = value;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 == 0)
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

		public bool CanWrite => !_ErrorInterceptor.IsInitOnly;

		public RuleFactory ScalarStyle
		{
			[CompilerGenerated]
			get
			{
				return m_ModelInterceptor;
			}
			[CompilerGenerated]
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
						m_ModelInterceptor = value;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 == 0)
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

		public DatabaseInterceptor(FieldInfo fieldInfo, OrderPrototype typeResolver)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 2;
			while (true)
			{
				switch (num)
				{
				case 1:
					ScalarStyle = (RuleFactory)0;
					num = 3;
					break;
				case 2:
					_ErrorInterceptor = fieldInfo;
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 == 0)
					{
						num = 0;
					}
					break;
				default:
					m_RegInterceptor = typeResolver;
					num = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 == 0)
					{
						num = 0;
					}
					break;
				case 3:
					return;
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
					_ErrorInterceptor.SetValue(target, value);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		public T GetCustomAttribute<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] T>() where T : Attribute
		{
			return (T)_ErrorInterceptor.GetCustomAttributes(typeof(T), inherit: true).FirstOrDefault();
		}

		public UtilsPrototype Read(object target)
		{
			int num = 2;
			int num2 = num;
			object value = default(object);
			Type type2 = default(Type);
			while (true)
			{
				Type type;
				switch (num2)
				{
				case 2:
					value = _ErrorInterceptor.GetValue(target);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 == 0)
					{
						num2 = 1;
					}
					continue;
				case 3:
					return new ReponsePrototype(value, type2, Type, ScalarStyle);
				case 1:
					type = TypeOverride;
					if ((object)type != null)
					{
						break;
					}
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b == 0)
					{
						num2 = 0;
					}
					continue;
				default:
					type = m_RegInterceptor.Resolve(Type, value);
					break;
				}
				type2 = type;
				num2 = 3;
			}
		}

		internal static bool CheckUtils()
		{
			return IncludeUtils == null;
		}

		internal static DatabaseInterceptor RateUtils()
		{
			return IncludeUtils;
		}
	}

	private readonly OrderPrototype m_PrinterInterceptor;

	private static CreatorInterceptor RemoveUtils;

	public CreatorInterceptor(OrderPrototype typeResolver)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_35cf05af90cc4195a86c9ffc19bf78eb == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 1:
				return;
			}
			m_PrinterInterceptor = typeResolver ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x4C23C86A ^ 0x4C239D0C));
			num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be != 0)
			{
				num = 1;
			}
		}
	}

	public override IEnumerable<RequestPrototype> GetProperties(Type type, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] object container)
	{
		return CollectionBase.GetPublicFields(type).Select((Func<FieldInfo, RequestPrototype>)([_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)] (FieldInfo p) => new DatabaseInterceptor(p, m_PrinterInterceptor)));
	}

	internal static bool ResolveUtils()
	{
		return RemoveUtils == null;
	}

	internal static CreatorInterceptor DefineUtils()
	{
		return RemoveUtils;
	}
}
