using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class AdvisorInterceptor : StrategyInterceptor
{
	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
	private sealed class ProcessInterceptor : RequestPrototype
	{
		private readonly PropertyInfo m_RepositoryInterceptor;

		private readonly OrderPrototype m_TagInterceptor;

		[CompilerGenerated]
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
		private Type m_VisitorInterceptor;

		[CompilerGenerated]
		private int m_StubInterceptor;

		[CompilerGenerated]
		private RuleFactory m_PolicyInterceptor;

		private static ProcessInterceptor ReflectUtils;

		public string Name => m_RepositoryInterceptor.Name;

		public Type Type => m_RepositoryInterceptor.PropertyType;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
		public Type TypeOverride
		{
			[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
			[CompilerGenerated]
			get
			{
				return m_VisitorInterceptor;
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
						m_VisitorInterceptor = value;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba != 0)
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
				return m_StubInterceptor;
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
						m_StubInterceptor = value;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2aaca7da964541af9780eb37df39c3db != 0)
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

		public bool CanWrite => m_RepositoryInterceptor.CanWrite;

		public RuleFactory ScalarStyle
		{
			[CompilerGenerated]
			get
			{
				return m_PolicyInterceptor;
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
					case 0:
						return;
					case 1:
						m_PolicyInterceptor = value;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 == 0)
						{
							num2 = 0;
						}
						break;
					}
				}
			}
		}

		public ProcessInterceptor(PropertyInfo propertyInfo, OrderPrototype typeResolver)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 2;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 0:
					return;
				case 3:
					ScalarStyle = (RuleFactory)0;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 != 0)
					{
						num2 = 0;
					}
					break;
				case 2:
					m_RepositoryInterceptor = propertyInfo ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1741204886 ^ -1741213190));
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 == 0)
					{
						num2 = 1;
					}
					break;
				case 1:
					m_TagInterceptor = typeResolver ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x4BDBCDC0 ^ 0x4BDB98A6));
					num2 = 3;
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
				case 1:
					m_RepositoryInterceptor.SetValue(target, value, null);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 == 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}

		public T GetCustomAttribute<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] T>() where T : Attribute
		{
			return (T)CollectionBase.GetAllCustomAttributes<T>(m_RepositoryInterceptor).FirstOrDefault();
		}

		public UtilsPrototype Read(object target)
		{
			int num = 1;
			int num2 = num;
			object obj = default(object);
			Type type2 = default(Type);
			while (true)
			{
				Type type;
				switch (num2)
				{
				case 1:
					obj = ListenerBase.ReadValue(m_RepositoryInterceptor, target);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 != 0)
					{
						num2 = 0;
					}
					continue;
				case 3:
					return new ReponsePrototype(obj, type2, Type, ScalarStyle);
				default:
					type = TypeOverride;
					if ((object)type != null)
					{
						break;
					}
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 != 0)
					{
						num2 = 2;
					}
					continue;
				case 2:
					type = m_TagInterceptor.Resolve(Type, obj);
					break;
				}
				type2 = type;
				num2 = 3;
			}
		}

		internal static bool CollectUtils()
		{
			return ReflectUtils == null;
		}

		internal static ProcessInterceptor ManageUtils()
		{
			return ReflectUtils;
		}
	}

	private readonly OrderPrototype _ConnectionInterceptor;

	private readonly bool annotationInterceptor;

	internal static AdvisorInterceptor ResetUtils;

	public AdvisorInterceptor(OrderPrototype typeResolver)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(typeResolver, includeNonPublicProperties: false);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public AdvisorInterceptor(OrderPrototype typeResolver, bool includeNonPublicProperties)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac == 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			case 2:
				return;
			default:
				annotationInterceptor = includeNonPublicProperties;
				num = 2;
				break;
			case 1:
				_ConnectionInterceptor = typeResolver ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(--650088194 ^ 0x26BFDA64));
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 != 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	private static bool IsValidProperty(PropertyInfo property)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (!property.CanRead)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 2;
			case 2:
				return property.GetGetMethod(nonPublic: true).GetParameters().Length == 0;
			default:
				return false;
			}
		}
	}

	public override IEnumerable<RequestPrototype> GetProperties(Type type, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] object container)
	{
		return CollectionBase.GetProperties(type, annotationInterceptor).Where(IsValidProperty).Select((Func<PropertyInfo, RequestPrototype>)([_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)] (PropertyInfo p) => new ProcessInterceptor(p, _ConnectionInterceptor)));
	}

	internal static bool CustomizeUtils()
	{
		return ResetUtils == null;
	}

	internal static AdvisorInterceptor CancelUtils()
	{
		return ResetUtils;
	}
}
