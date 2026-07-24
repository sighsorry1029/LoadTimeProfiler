using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AzuAnticheat.Internal;

internal sealed class DispatcherWriter
{
	private struct QueueWriter
	{
		public readonly Type collectionWriter;

		public readonly string m_ManagerWriter;

		internal static object EnableOrder;

		public QueueWriter(Type attributeType, string propertyName)
		{
			GetterIssuer.DeleteInitializer();
			collectionWriter = attributeType;
			m_ManagerWriter = propertyName;
		}

		public override bool Equals(object? obj)
		{
			int num = 2;
			int num2 = num;
			QueueWriter queueWriter = default(QueueWriter);
			while (true)
			{
				switch (num2)
				{
				case 3:
					return m_ManagerWriter.Equals(queueWriter.m_ManagerWriter);
				case 1:
					queueWriter = (QueueWriter)obj;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 == 0)
					{
						num2 = 0;
					}
					break;
				default:
					if (collectionWriter.Equals(queueWriter.collectionWriter))
					{
						num2 = 3;
						break;
					}
					goto IL_003f;
				case 2:
					{
						if (obj is QueueWriter)
						{
							num2 = 1;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 != 0)
							{
								num2 = 1;
							}
							break;
						}
						goto IL_003f;
					}
					IL_003f:
					return false;
				}
			}
		}

		public override int GetHashCode()
		{
			return IndexerInterpreter.CombineHashCodes(collectionWriter.GetHashCode(), m_ManagerWriter.GetHashCode());
		}

		internal static bool SortOrder()
		{
			return EnableOrder == null;
		}

		internal static object InsertOrder()
		{
			return EnableOrder;
		}
	}

	private sealed class TokenizerWriter
	{
		public readonly Type m_ListenerWriter;

		public readonly Attribute _AccountWriter;

		private static TokenizerWriter FindOrder;

		public TokenizerWriter(Type registeredType, Attribute attribute)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 != 0)
			{
				num = 0;
			}
			while (true)
			{
				switch (num)
				{
				default:
					return;
				case 0:
					return;
				case 2:
					_AccountWriter = attribute;
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 != 0)
					{
						num = 0;
					}
					break;
				case 1:
					m_ListenerWriter = registeredType;
					num = 2;
					break;
				}
			}
		}

		public override bool Equals(object? obj)
		{
			int num = 3;
			int num2 = num;
			TokenizerWriter tokenizerWriter = default(TokenizerWriter);
			while (true)
			{
				switch (num2)
				{
				case 1:
					if (!m_ListenerWriter.Equals(tokenizerWriter.m_ListenerWriter))
					{
						num2 = 4;
						break;
					}
					goto default;
				default:
					return _AccountWriter.Equals(tokenizerWriter._AccountWriter);
				case 4:
					return false;
				case 2:
					if (tokenizerWriter != null)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 == 0)
						{
							num2 = 0;
						}
						break;
					}
					goto case 4;
				case 3:
					tokenizerWriter = obj as TokenizerWriter;
					num2 = 2;
					break;
				}
			}
		}

		public override int GetHashCode()
		{
			return IndexerInterpreter.CombineHashCodes(m_ListenerWriter.GetHashCode(), _AccountWriter.GetHashCode());
		}

		public int Matches(Type matchType)
		{
			int num = 3;
			int num2 = num;
			Type type = default(Type);
			int num3 = default(int);
			while (true)
			{
				switch (num2)
				{
				case 8:
					if (type == m_ListenerWriter)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 == 0)
						{
							num2 = 0;
						}
						break;
					}
					type = InterceptorSetter.BaseType(type);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec != 0)
					{
						num2 = 9;
					}
					break;
				case 6:
					return num3;
				case 4:
					return 0;
				case 2:
					type = matchType;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd == 0)
					{
						num2 = 0;
					}
					break;
				default:
					if (!(type != null))
					{
						num2 = 5;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc == 0)
						{
							num2 = 0;
						}
						break;
					}
					goto case 7;
				case 5:
					if (!matchType.GetInterfaces().Contains<Type>(m_ListenerWriter))
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7e7ae6cc25e34646baea4e1c2c087e7a != 0)
						{
							num2 = 4;
						}
						break;
					}
					goto case 6;
				case 3:
					num3 = 0;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 == 0)
					{
						num2 = 2;
					}
					break;
				case 7:
					num3++;
					num2 = 8;
					break;
				case 1:
					return num3;
				}
			}
		}

		internal static bool VisitOrder()
		{
			return FindOrder == null;
		}

		internal static TokenizerWriter OrderOrder()
		{
			return FindOrder;
		}
	}

	private readonly Dictionary<QueueWriter, List<TokenizerWriter>> m_ListWriter;

	private static DispatcherWriter SetOrder;

	[return: RegSingleton]
	public T GetAttribute<T>(Type type, string member) where T : Attribute
	{
		if (m_ListWriter.TryGetValue(new QueueWriter(typeof(T), member), out List<TokenizerWriter> value))
		{
			int num = 0;
			TokenizerWriter tokenizerWriter = null;
			foreach (TokenizerWriter item in value)
			{
				int num2 = item.Matches(type);
				if (num2 > num)
				{
					num = num2;
					tokenizerWriter = item;
				}
			}
			if (num > 0)
			{
				return (T)tokenizerWriter._AccountWriter;
			}
		}
		return null;
	}

	public void Add(Type type, string member, Attribute attribute)
	{
		int num = 6;
		List<TokenizerWriter> value = default(List<TokenizerWriter>);
		TokenizerWriter item = default(TokenizerWriter);
		QueueWriter key = default(QueueWriter);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 1:
				case 4:
					if (!value.Contains(item))
					{
						num2 = 9;
						continue;
					}
					goto case 7;
				case 5:
					key = new QueueWriter(attribute.GetType(), member);
					num2 = 3;
					continue;
				case 7:
					throw new InvalidOperationException(string.Format(DicSingleton.gE3WbyDVW(0x166FBD ^ 0x16302F), attribute, type.FullName, member));
				case 9:
				case 10:
					value.Add(item);
					num2 = 2;
					continue;
				case 6:
					item = new TokenizerWriter(type, attribute);
					num2 = 5;
					continue;
				case 8:
					value = new List<TokenizerWriter>();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 == 0)
					{
						num2 = 0;
					}
					continue;
				case 2:
					return;
				case 3:
					if (m_ListWriter.TryGetValue(key, out value))
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac != 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 8;
				}
				break;
			}
			m_ListWriter.Add(key, value);
			num = 10;
		}
	}

	public DispatcherWriter Clone()
	{
		DispatcherWriter dispatcherWriter = new DispatcherWriter();
		foreach (KeyValuePair<QueueWriter, List<TokenizerWriter>> item in m_ListWriter)
		{
			foreach (TokenizerWriter item2 in item.Value)
			{
				dispatcherWriter.Add(item2.m_ListenerWriter, item.Key.m_ManagerWriter, item2._AccountWriter);
			}
		}
		return dispatcherWriter;
	}

	public void Add<TClass>(Expression<Func<TClass, object>> propertyAccessor, Attribute attribute)
	{
		PropertyInfo propertyInfo = StatusAttribute.AsProperty(propertyAccessor);
		Add(typeof(TClass), propertyInfo.Name, attribute);
	}

	public DispatcherWriter()
	{
		GetterIssuer.DeleteInitializer();
		m_ListWriter = new Dictionary<QueueWriter, List<TokenizerWriter>>();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool PushOrder()
	{
		return SetOrder == null;
	}

	internal static DispatcherWriter ValidateOrder()
	{
		return SetOrder;
	}
}
