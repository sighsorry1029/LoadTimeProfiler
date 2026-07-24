using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace AzuAnticheat.Internal;

[Serializable]
internal sealed class ServerAttribute<T, TT> : ConfigAttribute<T, TT>, IDictionary<T, TT>, ICollection<KeyValuePair<T, TT>>, IEnumerable<KeyValuePair<T, TT>>, IEnumerable where T : notnull
{
	private class PrinterAttribute : ICollection<T>, IEnumerable<T>, IEnumerable
	{
		private readonly ServerAttribute<T, TT> m_DatabaseAttribute;

		private static object LogoutAttribute;

		public int Count => m_DatabaseAttribute._ImporterAttribute.Count;

		public bool IsReadOnly => true;

		public void Add(T item)
		{
			throw new NotSupportedException();
		}

		public void Clear()
		{
			throw new NotSupportedException();
		}

		public bool Contains(T item)
		{
			return m_DatabaseAttribute.m_AlgoAttribute.Keys.Contains(item);
		}

		public PrinterAttribute(ServerAttribute<T, TT> orderedDictionary)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			m_DatabaseAttribute = orderedDictionary;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			int num = 2;
			int num2 = num;
			int num3 = default(int);
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 0:
					return;
				case 5:
					num3++;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a579dea83d2144838086d2d400bd0222 != 0)
					{
						num2 = 6;
					}
					break;
				case 1:
				case 6:
					if (num3 >= m_DatabaseAttribute._ImporterAttribute.Count)
					{
						return;
					}
					num2 = 3;
					break;
				case 2:
					num3 = 0;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef != 0)
					{
						num2 = 0;
					}
					break;
				case 3:
				case 4:
					array[num3] = m_DatabaseAttribute._ImporterAttribute[num3 + arrayIndex].Key;
					num2 = 5;
					break;
				}
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			return m_DatabaseAttribute._ImporterAttribute.Select((KeyValuePair<T, TT> kvp) => kvp.Key).GetEnumerator();
		}

		public bool Remove(T item)
		{
			throw new NotSupportedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		internal static bool CountAttribute()
		{
			return LogoutAttribute == null;
		}

		internal static object SetAttribute()
		{
			return LogoutAttribute;
		}
	}

	private class ErrorAttribute : ICollection<TT>, IEnumerable<TT>, IEnumerable
	{
		private readonly ServerAttribute<T, TT> regAttribute;

		internal static object SortAttribute;

		public int Count => regAttribute._ImporterAttribute.Count;

		public bool IsReadOnly => true;

		public void Add(TT item)
		{
			throw new NotSupportedException();
		}

		public void Clear()
		{
			throw new NotSupportedException();
		}

		public bool Contains(TT item)
		{
			return regAttribute.m_AlgoAttribute.Values.Contains(item);
		}

		public ErrorAttribute(ServerAttribute<T, TT> orderedDictionary)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			regAttribute = orderedDictionary;
		}

		public void CopyTo(TT[] array, int arrayIndex)
		{
			int num = 4;
			int num2 = num;
			int num3 = default(int);
			while (true)
			{
				switch (num2)
				{
				case 5:
					num3++;
					num2 = 2;
					break;
				case 2:
				case 3:
					if (num3 < regAttribute._ImporterAttribute.Count)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 != 0)
						{
							num2 = 0;
						}
						break;
					}
					return;
				default:
					array[num3] = regAttribute._ImporterAttribute[num3 + arrayIndex].Value;
					num2 = 5;
					break;
				case 6:
					return;
				case 4:
					num3 = 0;
					num2 = 3;
					break;
				}
			}
		}

		public IEnumerator<TT> GetEnumerator()
		{
			return regAttribute._ImporterAttribute.Select((KeyValuePair<T, TT> kvp) => kvp.Value).GetEnumerator();
		}

		public bool Remove(TT item)
		{
			throw new NotSupportedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		internal static bool InsertAttribute()
		{
			return SortAttribute == null;
		}

		internal static object FindAttribute()
		{
			return SortAttribute;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass27_0
	{
		public ServerAttribute<T, TT> _003C_003E4__this;

		public T key;

		internal static object StopAttribute;

		public _003C_003Ec__DisplayClass27_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal bool _003CRemove_003Eb__0(KeyValuePair<T, TT> kvp)
		{
			return _003C_003E4__this.m_CreatorAttribute.Equals(kvp.Key, key);
		}

		internal static bool ExcludeAttribute()
		{
			return StopAttribute == null;
		}

		internal static object InterruptAttribute()
		{
			return StopAttribute;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public ServerAttribute<T, TT> _003C_003E4__this;

		public T key;

		private static object DeleteAttribute;

		public _003C_003Ec__DisplayClass5_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal bool _003Cset_Item_003Eb__0(KeyValuePair<T, TT> kvp)
		{
			return _003C_003E4__this.m_CreatorAttribute.Equals(kvp.Key, key);
		}

		internal static bool FillAttribute()
		{
			return DeleteAttribute == null;
		}

		internal static object FlushAttribute()
		{
			return DeleteAttribute;
		}
	}

	[NonSerialized]
	private Dictionary<T, TT> m_AlgoAttribute;

	private readonly List<KeyValuePair<T, TT>> _ImporterAttribute;

	private readonly IEqualityComparer<T> m_CreatorAttribute;

	internal static object PatchAttribute;

	public TT this[T key]
	{
		get
		{
			return m_AlgoAttribute[key];
		}
		set
		{
			_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass5_0();
			CS_0024_003C_003E8__locals8._003C_003E4__this = this;
			CS_0024_003C_003E8__locals8.key = key;
			if (m_AlgoAttribute.ContainsKey(CS_0024_003C_003E8__locals8.key))
			{
				int index = _ImporterAttribute.FindIndex((KeyValuePair<T, TT> kvp) => CS_0024_003C_003E8__locals8._003C_003E4__this.m_CreatorAttribute.Equals(kvp.Key, CS_0024_003C_003E8__locals8.key));
				m_AlgoAttribute[CS_0024_003C_003E8__locals8.key] = value;
				_ImporterAttribute[index] = new KeyValuePair<T, TT>(CS_0024_003C_003E8__locals8.key, value);
			}
			else
			{
				Add(CS_0024_003C_003E8__locals8.key, value);
			}
		}
	}

	public ICollection<T> Keys => new PrinterAttribute(this);

	public ICollection<TT> Values => new ErrorAttribute(this);

	public int Count => m_AlgoAttribute.Count;

	public bool IsReadOnly => false;

	public KeyValuePair<T, TT> this[int index]
	{
		get
		{
			return _ImporterAttribute[index];
		}
		set
		{
			_ImporterAttribute[index] = value;
		}
	}

	public ServerAttribute()
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector((IEqualityComparer<T>)EqualityComparer<T>.Default);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public ServerAttribute(IEqualityComparer<T> comparer)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		_ImporterAttribute = new List<KeyValuePair<T, TT>>();
		m_AlgoAttribute = new Dictionary<T, TT>(comparer);
		m_CreatorAttribute = comparer;
	}

	public void Add(T key, TT value)
	{
		Add(new KeyValuePair<T, TT>(key, value));
	}

	public void Add(KeyValuePair<T, TT> item)
	{
		m_AlgoAttribute.Add(item.Key, item.Value);
		_ImporterAttribute.Add(item);
	}

	public void Clear()
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 2:
				m_AlgoAttribute.Clear();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 == 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				_ImporterAttribute.Clear();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public bool Contains(KeyValuePair<T, TT> item)
	{
		return m_AlgoAttribute.Contains(item);
	}

	public bool ContainsKey(T key)
	{
		return m_AlgoAttribute.ContainsKey(key);
	}

	public void CopyTo(KeyValuePair<T, TT>[] array, int arrayIndex)
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
				_ImporterAttribute.CopyTo(array, arrayIndex);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public IEnumerator<KeyValuePair<T, TT>> GetEnumerator()
	{
		return _ImporterAttribute.GetEnumerator();
	}

	public void Insert(int index, T key, TT value)
	{
		m_AlgoAttribute.Add(key, value);
		_ImporterAttribute.Insert(index, new KeyValuePair<T, TT>(key, value));
	}

	public bool Remove(T key)
	{
		_003C_003Ec__DisplayClass27_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass27_0();
		CS_0024_003C_003E8__locals6._003C_003E4__this = this;
		CS_0024_003C_003E8__locals6.key = key;
		if (m_AlgoAttribute.ContainsKey(CS_0024_003C_003E8__locals6.key))
		{
			int index = _ImporterAttribute.FindIndex((KeyValuePair<T, TT> kvp) => CS_0024_003C_003E8__locals6._003C_003E4__this.m_CreatorAttribute.Equals(kvp.Key, CS_0024_003C_003E8__locals6.key));
			_ImporterAttribute.RemoveAt(index);
			if (!m_AlgoAttribute.Remove(CS_0024_003C_003E8__locals6.key))
			{
				throw new InvalidOperationException();
			}
			return true;
		}
		return false;
	}

	public bool Remove(KeyValuePair<T, TT> item)
	{
		return Remove(item.Key);
	}

	public void RemoveAt(int index)
	{
		int num = 4;
		int num2 = num;
		T key = default(T);
		KeyValuePair<T, TT> keyValuePair = default(KeyValuePair<T, TT>);
		while (true)
		{
			switch (num2)
			{
			case 2:
				_ImporterAttribute.RemoveAt(index);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 == 0)
				{
					num2 = 1;
				}
				break;
			case 3:
				key = keyValuePair.Key;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 != 0)
				{
					num2 = 0;
				}
				break;
			case 1:
				return;
			default:
				m_AlgoAttribute.Remove(key);
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 != 0)
				{
					num2 = 1;
				}
				break;
			case 4:
				keyValuePair = _ImporterAttribute[index];
				num2 = 3;
				break;
			}
		}
	}

	public bool TryGetValue(T key, [ReponseSingleton(false)] out TT value)
	{
		return m_AlgoAttribute.TryGetValue(key, out value);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _ImporterAttribute.GetEnumerator();
	}

	[OnDeserialized]
	internal void OnDeserializedMethod(StreamingContext context)
	{
		int num = 3;
		List<KeyValuePair<T, TT>>.Enumerator enumerator = default(List<KeyValuePair<T, TT>>.Enumerator);
		KeyValuePair<T, TT> current = default(KeyValuePair<T, TT>);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 1:
					return;
				case 3:
					break;
				default:
					try
					{
						while (true)
						{
							int num4;
							if (!enumerator.MoveNext())
							{
								int num3 = 3;
								num4 = num3;
								goto IL_006a;
							}
							goto IL_009e;
							IL_006a:
							while (true)
							{
								switch (num4)
								{
								case 3:
									return;
								case 1:
									goto IL_009e;
								case 2:
									m_AlgoAttribute[current.Key] = current.Value;
									num4 = 0;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4a2885c39dcc4cf1a32db39a2ed578f0 == 0)
									{
										num4 = 0;
									}
									continue;
								}
								break;
							}
							continue;
							IL_009e:
							current = enumerator.Current;
							num4 = 2;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba != 0)
							{
								num4 = 0;
							}
							goto IL_006a;
						}
					}
					finally
					{
						((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
						int num5 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b == 0)
						{
							num5 = 0;
						}
						switch (num5)
						{
						case 0:
							break;
						}
					}
				case 2:
					enumerator = _ImporterAttribute.GetEnumerator();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 == 0)
					{
						num2 = 0;
					}
					continue;
				}
				break;
			}
			m_AlgoAttribute = new Dictionary<T, TT>();
			num = 2;
		}
	}

	internal static bool AssetAttribute()
	{
		return PatchAttribute == null;
	}

	internal static object CalcAttribute()
	{
		return PatchAttribute;
	}
}
