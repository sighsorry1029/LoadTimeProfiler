using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class HelperFilter : InitializerPrototype
{
	private readonly Dictionary<Type, Type> _ExceptionFilter;

	private readonly Dictionary<Type, Type> itemFilter;

	private static HelperFilter InvokeInstance;

	public HelperFilter()
	{
		GetterIssuer.DeleteInitializer();
		_ExceptionFilter = new Dictionary<Type, Type>
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
		itemFilter = new Dictionary<Type, Type>
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
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public HelperFilter(IDictionary<Type, Type> mappings)
	{
		GetterIssuer.DeleteInitializer();
		_ExceptionFilter = new Dictionary<Type, Type>
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
		itemFilter = new Dictionary<Type, Type>
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
				throw new InvalidOperationException(string.Format(DicSingleton.gE3WbyDVW(-381685266 ^ -381708206), mapping.Value, mapping.Key));
			}
			itemFilter.Add(mapping.Key, mapping.Value);
		}
	}

	public object Create(Type type)
	{
		int num = 7;
		object result = default(object);
		Type value = default(Type);
		Type value2 = default(Type);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 12:
					return result;
				default:
					if (!_ExceptionFilter.TryGetValue(type.GetGenericTypeDefinition(), out value))
					{
						num2 = 5;
						continue;
					}
					goto case 8;
				case 8:
					type = value.MakeGenericType(type.GetGenericArguments());
					num2 = 4;
					continue;
				case 2:
					if (CollectionBase.IsGenericType(type))
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb != 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 11;
				case 3:
					break;
				case 10:
					try
					{
						result = Activator.CreateInstance(type);
						int num3 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c != 0)
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
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 != 0)
						{
							num4 = 0;
						}
						switch (num4)
						{
						default:
							throw new InvalidOperationException(DicSingleton.gE3WbyDVW(0x5901407C ^ 0x59012A6E) + type.FullName + DicSingleton.gE3WbyDVW(-2133864647 ^ -2133878243), innerException);
						}
					}
					goto case 12;
				case 1:
				case 4:
				case 5:
				case 6:
				case 9:
					num2 = 10;
					continue;
				case 11:
					if (!itemFilter.TryGetValue(type, out value2))
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 == 0)
						{
							num2 = 1;
						}
						continue;
					}
					break;
				case 7:
					if (!CollectionBase.IsInterface(type))
					{
						num2 = 6;
						continue;
					}
					goto case 2;
				}
				break;
			}
			type = value2;
			num = 9;
		}
	}

	internal static bool PublishInstance()
	{
		return InvokeInstance == null;
	}

	internal static HelperFilter RegisterInstance()
	{
		return InvokeInstance;
	}
}
