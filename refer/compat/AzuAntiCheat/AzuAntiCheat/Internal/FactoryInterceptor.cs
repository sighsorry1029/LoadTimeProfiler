using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class FactoryInterceptor
{
	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
	private struct WriterInterceptor
	{
		public readonly Type m_InvocationInterceptor;

		public readonly string authenticationInterceptor;

		private static object CountMerchant;

		public WriterInterceptor(Type attributeType, string propertyName)
		{
			GetterIssuer.DeleteInitializer();
			m_InvocationInterceptor = attributeType;
			authenticationInterceptor = propertyName;
		}

		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
		public override bool Equals(object obj)
		{
			int num = 3;
			int num2 = num;
			WriterInterceptor writerInterceptor = default(WriterInterceptor);
			while (true)
			{
				switch (num2)
				{
				case 1:
					return authenticationInterceptor.Equals(writerInterceptor.authenticationInterceptor);
				case 2:
					return false;
				default:
					if (m_InvocationInterceptor.Equals(writerInterceptor.m_InvocationInterceptor))
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 != 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 2;
				case 3:
					if (!(obj is WriterInterceptor))
					{
						num2 = 2;
						continue;
					}
					break;
				case 4:
					break;
				}
				writerInterceptor = (WriterInterceptor)obj;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 != 0)
				{
					num2 = 0;
				}
			}
		}

		public override int GetHashCode()
		{
			return ProxyReader.CombineHashCodes(m_InvocationInterceptor.GetHashCode(), authenticationInterceptor.GetHashCode());
		}

		internal static bool SetMerchant()
		{
			return CountMerchant == null;
		}

		internal static object PushMerchant()
		{
			return CountMerchant;
		}
	}

	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
	private sealed class AttributeInterceptor
	{
		public readonly Type _InterpreterInterceptor;

		public readonly Attribute _SingletonInterceptor;

		internal static AttributeInterceptor ValidateMerchant;

		public AttributeInterceptor(Type registeredType, Attribute attribute)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 == 0)
			{
				num = 0;
			}
			while (true)
			{
				switch (num)
				{
				default:
					_SingletonInterceptor = attribute;
					num = 2;
					break;
				case 1:
					_InterpreterInterceptor = registeredType;
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 == 0)
					{
						num = 0;
					}
					break;
				case 2:
					return;
				}
			}
		}

		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
		public override bool Equals(object obj)
		{
			int num = 1;
			int num2 = num;
			AttributeInterceptor attributeInterceptor = default(AttributeInterceptor);
			while (true)
			{
				switch (num2)
				{
				case 4:
					if (_InterpreterInterceptor.Equals(attributeInterceptor._InterpreterInterceptor))
					{
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c == 0)
						{
							num2 = 3;
						}
						break;
					}
					goto case 2;
				case 1:
					attributeInterceptor = obj as AttributeInterceptor;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea != 0)
					{
						num2 = 0;
					}
					break;
				case 3:
					return _SingletonInterceptor.Equals(attributeInterceptor._SingletonInterceptor);
				case 2:
					return false;
				default:
					if (attributeInterceptor == null)
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc == 0)
						{
							num2 = 1;
						}
						break;
					}
					goto case 4;
				}
			}
		}

		public override int GetHashCode()
		{
			return ProxyReader.CombineHashCodes(_InterpreterInterceptor.GetHashCode(), _SingletonInterceptor.GetHashCode());
		}

		public int Matches(Type matchType)
		{
			int num = 10;
			int num2 = num;
			int num3 = default(int);
			Type type = default(Type);
			while (true)
			{
				switch (num2)
				{
				case 7:
					return num3;
				case 5:
				case 6:
					if (type != null)
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 != 0)
						{
							num2 = 2;
						}
						break;
					}
					goto case 1;
				case 9:
					type = matchType;
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 != 0)
					{
						num2 = 5;
					}
					break;
				case 1:
					if (!matchType.GetInterfaces().Contains(_InterpreterInterceptor))
					{
						return 0;
					}
					num2 = 7;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 != 0)
					{
						num2 = 5;
					}
					break;
				case 2:
				case 8:
					num3++;
					num2 = 4;
					break;
				case 10:
					num3 = 0;
					num2 = 9;
					break;
				default:
					return num3;
				case 3:
					type = CollectionBase.BaseType(type);
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 != 0)
					{
						num2 = 3;
					}
					break;
				case 4:
					if (!(type == _InterpreterInterceptor))
					{
						num2 = 3;
						break;
					}
					goto default;
				}
			}
		}

		internal static bool EnableMerchant()
		{
			return ValidateMerchant == null;
		}

		internal static AttributeInterceptor SortMerchant()
		{
			return ValidateMerchant;
		}
	}

	private readonly Dictionary<WriterInterceptor, List<AttributeInterceptor>> m_SetterInterceptor;

	private static FactoryInterceptor ListMerchant;

	[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	public T GetAttribute<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] T>(Type type, string member) where T : Attribute
	{
		if (m_SetterInterceptor.TryGetValue(new WriterInterceptor(typeof(T), member), out var value))
		{
			int num = 0;
			AttributeInterceptor attributeInterceptor = null;
			foreach (AttributeInterceptor item in value)
			{
				int num2 = item.Matches(type);
				if (num2 > num)
				{
					num = num2;
					attributeInterceptor = item;
				}
			}
			if (num > 0)
			{
				return (T)attributeInterceptor._SingletonInterceptor;
			}
		}
		return null;
	}

	public void Add(Type type, string member, Attribute attribute)
	{
		int num = 4;
		int num2 = num;
		WriterInterceptor key = default(WriterInterceptor);
		List<AttributeInterceptor> value = default(List<AttributeInterceptor>);
		AttributeInterceptor item = default(AttributeInterceptor);
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 1:
				m_SetterInterceptor.Add(key, value);
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 != 0)
				{
					num2 = 5;
				}
				continue;
			case 0:
				return;
			case 3:
				key = new WriterInterceptor(attribute.GetType(), member);
				num2 = 7;
				continue;
			case 2:
				if (value.Contains(item))
				{
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 != 0)
					{
						num2 = 5;
					}
					continue;
				}
				break;
			case 4:
				item = new AttributeInterceptor(type, attribute);
				num2 = 3;
				continue;
			case 8:
				value = new List<AttributeInterceptor>();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 == 0)
				{
					num2 = 1;
				}
				continue;
			case 7:
				if (!m_SetterInterceptor.TryGetValue(key, out value))
				{
					num2 = 8;
					continue;
				}
				goto case 2;
			case 6:
				throw new InvalidOperationException(string.Format(DicSingleton.gE3WbyDVW(0x23D015CA ^ 0x23D04A58), attribute, type.FullName, member));
			case 5:
				break;
			}
			value.Add(item);
			num2 = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 != 0)
			{
				num2 = 0;
			}
		}
	}

	public FactoryInterceptor Clone()
	{
		FactoryInterceptor factoryInterceptor = new FactoryInterceptor();
		foreach (KeyValuePair<WriterInterceptor, List<AttributeInterceptor>> item in m_SetterInterceptor)
		{
			foreach (AttributeInterceptor item2 in item.Value)
			{
				factoryInterceptor.Add(item2._InterpreterInterceptor, item.Key.authenticationInterceptor, item2._SingletonInterceptor);
			}
		}
		return factoryInterceptor;
	}

	public void Add<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] TClass>(Expression<Func<TClass, object>> propertyAccessor, Attribute attribute)
	{
		PropertyInfo propertyInfo = ReaderReader.AsProperty(propertyAccessor);
		Add(typeof(TClass), propertyInfo.Name, attribute);
	}

	public FactoryInterceptor()
	{
		GetterIssuer.DeleteInitializer();
		m_SetterInterceptor = new Dictionary<WriterInterceptor, List<AttributeInterceptor>>();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool CalcMerchant()
	{
		return ListMerchant == null;
	}

	internal static FactoryInterceptor LogoutMerchant()
	{
		return ListMerchant;
	}
}
