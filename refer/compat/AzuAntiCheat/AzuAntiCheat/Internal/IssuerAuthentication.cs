using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class IssuerAuthentication : GlobalAuthentication
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public Type comparatorAuthentication;

		internal static _003C_003Ec__DisplayClass13_0 CalcImporter;

		public _003C_003Ec__DisplayClass13_0()
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

		internal bool _003CGetStateMethods_003Eb__0(MethodInfo x)
		{
			return x.GetCustomAttributes(comparatorAuthentication, inherit: true).Any();
		}

		internal static bool LogoutImporter()
		{
			return CalcImporter == null;
		}

		internal static _003C_003Ec__DisplayClass13_0 CountImporter()
		{
			return CalcImporter;
		}
	}

	private readonly Dictionary<Type, Dictionary<Type, MethodInfo[]>> m_FieldAuthentication;

	private readonly Dictionary<Type, Type> m_RuleAuthentication;

	private readonly Dictionary<Type, Type> _SerializerAuthentication;

	private readonly CodeWriter m_ProducerAuthentication;

	private static IssuerAuthentication PatchImporter;

	public IssuerAuthentication()
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(new Dictionary<Type, Type>(), new CodeWriter());
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public IssuerAuthentication(IDictionary<Type, Type> mappings)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(mappings, new CodeWriter());
	}

	public IssuerAuthentication(IDictionary<Type, Type> mappings, CodeWriter settings)
	{
		GetterIssuer.DeleteInitializer();
		m_FieldAuthentication = new Dictionary<Type, Dictionary<Type, MethodInfo[]>>
		{
			{
				typeof(ReaderAttribute),
				new Dictionary<Type, MethodInfo[]>()
			},
			{
				typeof(FactoryAttribute),
				new Dictionary<Type, MethodInfo[]>()
			},
			{
				typeof(SetterAttribute),
				new Dictionary<Type, MethodInfo[]>()
			},
			{
				typeof(WriterAttribute),
				new Dictionary<Type, MethodInfo[]>()
			}
		};
		m_RuleAuthentication = new Dictionary<Type, Type>
		{
			{
				typeof(IEnumerable<>),
				typeof(List<>)
			},
			{
				typeof(ICollection<>),
				typeof(List<>)
			},
			{
				typeof(IList<>),
				typeof(List<>)
			},
			{
				typeof(IDictionary<, >),
				typeof(Dictionary<, >)
			}
		};
		_SerializerAuthentication = new Dictionary<Type, Type>
		{
			{
				typeof(IEnumerable),
				typeof(List<object>)
			},
			{
				typeof(ICollection),
				typeof(List<object>)
			},
			{
				typeof(IList),
				typeof(List<object>)
			},
			{
				typeof(IDictionary),
				typeof(Dictionary<object, object>)
			}
		};
		base._002Ector();
		foreach (KeyValuePair<Type, Type> mapping in mappings)
		{
			if (!mapping.Key.IsAssignableFrom(mapping.Value))
			{
				throw new InvalidOperationException(string.Format(DicSingleton.gE3WbyDVW(0xFB046CE ^ 0xFB02F72), mapping.Value, mapping.Key));
			}
			_SerializerAuthentication.Add(mapping.Key, mapping.Value);
		}
		m_ProducerAuthentication = settings;
	}

	public override object Create(Type type)
	{
		int num = 10;
		Type value = default(Type);
		object result = default(object);
		Type value2 = default(Type);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					if (!m_RuleAuthentication.TryGetValue(type.GetGenericTypeDefinition(), out value))
					{
						num2 = 8;
						break;
					}
					goto case 6;
				case 6:
					type = value.MakeGenericType(type.GetGenericArguments());
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb != 0)
					{
						num2 = 0;
					}
					break;
				case 7:
					if (!InterceptorSetter.IsGenericType(type))
					{
						goto end_IL_0012;
					}
					goto default;
				case 1:
				case 2:
				case 8:
				case 9:
					num2 = 4;
					break;
				case 12:
					return result;
				case 5:
				case 11:
					if (_SerializerAuthentication.TryGetValue(type, out value2))
					{
						num2 = 3;
						break;
					}
					goto case 1;
				case 4:
					try
					{
						result = Activator.CreateInstance(type, m_ProducerAuthentication.AllowPrivateConstructors);
						int num3 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 != 0)
						{
							num3 = 0;
						}
						switch (num3)
						{
						case 0:
							break;
						}
					}
					catch (Exception innerException)
					{
						int num4 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e != 0)
						{
							num4 = 0;
						}
						switch (num4)
						{
						default:
							throw new InvalidOperationException(DicSingleton.gE3WbyDVW(-1580624393 ^ -1580597275) + type.FullName + DicSingleton.gE3WbyDVW(-1059662249 ^ -1059683469), innerException);
						}
					}
					goto case 12;
				case 3:
					type = value2;
					num2 = 2;
					break;
				case 10:
					if (!InterceptorSetter.IsInterface(type))
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 != 0)
						{
							num2 = 9;
						}
						break;
					}
					goto case 7;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 11;
		}
	}

	public override void ExecuteOnDeserialized(object value)
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
				ExecuteState(typeof(ReaderAttribute), value);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public override void ExecuteOnDeserializing(object value)
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
				ExecuteState(typeof(FactoryAttribute), value);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4a2885c39dcc4cf1a32db39a2ed578f0 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public override void ExecuteOnSerialized(object value)
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
				ExecuteState(typeof(SetterAttribute), value);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public override void ExecuteOnSerializing(object value)
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
				ExecuteState(typeof(WriterAttribute), value);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	private void ExecuteState(Type attributeType, object value)
	{
		int num = 8;
		int num2 = num;
		MethodInfo[] stateMethods = default(MethodInfo[]);
		Type type = default(Type);
		int num3 = default(int);
		while (true)
		{
			switch (num2)
			{
			case 9:
				stateMethods = GetStateMethods(attributeType, type);
				num2 = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a == 0)
				{
					num2 = 2;
				}
				break;
			case 5:
				num3++;
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd != 0)
				{
					num2 = 2;
				}
				break;
			case 2:
			case 6:
				if (num3 < stateMethods.Length)
				{
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 == 0)
					{
						num2 = 3;
					}
					break;
				}
				return;
			case 8:
				if (value == null)
				{
					num2 = 7;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 != 0)
					{
						num2 = 6;
					}
				}
				else
				{
					type = value.GetType();
					num2 = 9;
				}
				break;
			case 4:
				num3 = 0;
				num2 = 6;
				break;
			case 7:
				return;
			case 1:
				return;
			default:
				stateMethods[num3].Invoke(value, null);
				num2 = 5;
				break;
			}
		}
	}

	private MethodInfo[] GetStateMethods(Type attributeType, Type valueType)
	{
		int num = 2;
		int num2 = num;
		MethodInfo[] value = default(MethodInfo[]);
		_003C_003Ec__DisplayClass13_0 _003C_003Ec__DisplayClass13_ = default(_003C_003Ec__DisplayClass13_0);
		Dictionary<Type, MethodInfo[]> dictionary = default(Dictionary<Type, MethodInfo[]>);
		while (true)
		{
			switch (num2)
			{
			case 7:
				return value;
			case 1:
				_003C_003Ec__DisplayClass13_.comparatorAuthentication = attributeType;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e == 0)
				{
					num2 = 0;
				}
				break;
			case 6:
				dictionary[valueType] = value;
				num2 = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 != 0)
				{
					num2 = 7;
				}
				break;
			default:
				dictionary = m_FieldAuthentication[_003C_003Ec__DisplayClass13_.comparatorAuthentication];
				num2 = 5;
				break;
			case 5:
				if (dictionary.TryGetValue(valueType, out value))
				{
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 == 0)
					{
						num2 = 0;
					}
				}
				else
				{
					value = valueType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					num2 = 4;
				}
				break;
			case 4:
				value = value.Where(_003C_003Ec__DisplayClass13_._003CGetStateMethods_003Eb__0).ToArray();
				num2 = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 != 0)
				{
					num2 = 6;
				}
				break;
			case 2:
				_003C_003Ec__DisplayClass13_ = new _003C_003Ec__DisplayClass13_0();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 == 0)
				{
					num2 = 1;
				}
				break;
			case 3:
				return value;
			}
		}
	}

	internal static bool AssetImporter()
	{
		return PatchImporter == null;
	}

	internal static IssuerAuthentication ListImporter()
	{
		return PatchImporter;
	}
}
