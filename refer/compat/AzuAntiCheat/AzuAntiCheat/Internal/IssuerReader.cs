using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace AzuAnticheat.Internal;

[Serializable]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal class IssuerReader<T, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] TT> : InterpreterReader<T, TT>, IDictionary<T, TT>, ICollection<KeyValuePair<T, TT>>, IEnumerable<KeyValuePair<T, TT>>, IEnumerable
{
	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
	private class ProducerReader : ICollection<T>, IEnumerable<T>, IEnumerable
	{
		private readonly IssuerReader<T, TT> comparatorReader;

		internal static object CancelAuthentication;

		public int Count => comparatorReader.m_RuleReader.Count;

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
			return comparatorReader._FieldReader.Keys.Contains(item);
		}

		public ProducerReader(IssuerReader<T, TT> orderedDictionary)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			comparatorReader = orderedDictionary;
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
				case 2:
					num3 = 0;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 == 0)
					{
						num2 = 1;
					}
					break;
				case 5:
					array[num3] = comparatorReader.m_RuleReader[num3 + arrayIndex].Key;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 == 0)
					{
						num2 = 0;
					}
					break;
				default:
					num3++;
					num2 = 4;
					break;
				case 3:
					return;
				case 1:
				case 4:
					if (num3 >= comparatorReader.m_RuleReader.Count)
					{
						num2 = 3;
						break;
					}
					goto case 5;
				}
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			return comparatorReader.m_RuleReader.Select([_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)] (KeyValuePair<T, TT> kvp) => kvp.Key).GetEnumerator();
		}

		public bool Remove(T item)
		{
			throw new NotSupportedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		internal static bool ReflectAuthentication()
		{
			return CancelAuthentication == null;
		}

		internal static object CollectAuthentication()
		{
			return CancelAuthentication;
		}
	}

	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
	private class DefinitionReader : ICollection<TT>, IEnumerable<TT>, IEnumerable
	{
		private readonly IssuerReader<T, TT> m_ComposerReader;

		private static object GetAuthentication;

		public int Count => m_ComposerReader.m_RuleReader.Count;

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
			return m_ComposerReader._FieldReader.Values.Contains(item);
		}

		public DefinitionReader(IssuerReader<T, TT> orderedDictionary)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			m_ComposerReader = orderedDictionary;
		}

		public void CopyTo(TT[] array, int arrayIndex)
		{
			int num = 1;
			int num3 = default(int);
			while (true)
			{
				int num2 = num;
				while (true)
				{
					switch (num2)
					{
					case 5:
						num3++;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 != 0)
						{
							num2 = 2;
						}
						continue;
					default:
						if (num3 < m_ComposerReader.m_RuleReader.Count)
						{
							break;
						}
						goto end_IL_0012;
					case 3:
						return;
					case 1:
						num3 = 0;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
						{
							num2 = 0;
						}
						continue;
					case 4:
						break;
					}
					array[num3] = m_ComposerReader.m_RuleReader[num3 + arrayIndex].Value;
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a != 0)
					{
						num2 = 5;
					}
					continue;
					end_IL_0012:
					break;
				}
				num = 3;
			}
		}

		public IEnumerator<TT> GetEnumerator()
		{
			return m_ComposerReader.m_RuleReader.Select([_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)] (KeyValuePair<T, TT> kvp) => kvp.Value).GetEnumerator();
		}

		public bool Remove(TT item)
		{
			throw new NotSupportedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		internal static bool CalculateAuthentication()
		{
			return GetAuthentication == null;
		}

		internal static object MoveAuthentication()
		{
			return GetAuthentication;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public IssuerReader<T, TT> _003C_003E4__this;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public T key;

		private static object RegisterService;

		public _003C_003Ec__DisplayClass5_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3a460cd74a4c809e0f755964f2077b == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal bool _003Cset_Item_003Eb__0([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1, 1 })] KeyValuePair<T, TT> kvp)
		{
			return _003C_003E4__this._SerializerReader.Equals(kvp.Key, key);
		}

		internal static bool SetupService()
		{
			return RegisterService == null;
		}

		internal static object SelectService()
		{
			return RegisterService;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass27_0
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public IssuerReader<T, TT> _003C_003E4__this;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public T key;

		private static object ChangeService;

		public _003C_003Ec__DisplayClass27_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal bool _003CRemove_003Eb__0([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1, 1 })] KeyValuePair<T, TT> kvp)
		{
			return _003C_003E4__this._SerializerReader.Equals(kvp.Key, key);
		}

		internal static bool CreateService()
		{
			return ChangeService == null;
		}

		internal static object TestService()
		{
			return ChangeService;
		}
	}

	[NonSerialized]
	private Dictionary<T, TT> _FieldReader;

	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 1, 0, 1, 1 })]
	private readonly List<KeyValuePair<T, TT>> m_RuleReader;

	private readonly IEqualityComparer<T> _SerializerReader;

	internal static object RateAuthentication;

	public TT this[T key]
	{
		get
		{
			return _FieldReader[key];
		}
		set
		{
			_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass5_0();
			CS_0024_003C_003E8__locals8._003C_003E4__this = this;
			CS_0024_003C_003E8__locals8.key = key;
			if (_FieldReader.ContainsKey(CS_0024_003C_003E8__locals8.key))
			{
				int index = m_RuleReader.FindIndex(([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1, 1 })] KeyValuePair<T, TT> kvp) => CS_0024_003C_003E8__locals8._003C_003E4__this._SerializerReader.Equals(kvp.Key, CS_0024_003C_003E8__locals8.key));
				_FieldReader[CS_0024_003C_003E8__locals8.key] = value;
				m_RuleReader[index] = new KeyValuePair<T, TT>(CS_0024_003C_003E8__locals8.key, value);
			}
			else
			{
				Add(CS_0024_003C_003E8__locals8.key, value);
			}
		}
	}

	public ICollection<T> Keys => new ProducerReader(this);

	public ICollection<TT> Values => new DefinitionReader(this);

	public int Count => _FieldReader.Count;

	public bool IsReadOnly => false;

	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1, 1 })]
	public KeyValuePair<T, TT> this[int index]
	{
		[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1, 1 })]
		get
		{
			return m_RuleReader[index];
		}
		[param: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1, 1 })]
		set
		{
			m_RuleReader[index] = value;
		}
	}

	public IssuerReader()
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector((IEqualityComparer<T>)EqualityComparer<T>.Default);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4a2885c39dcc4cf1a32db39a2ed578f0 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public IssuerReader(IEqualityComparer<T> comparer)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		m_RuleReader = new List<KeyValuePair<T, TT>>();
		_FieldReader = new Dictionary<T, TT>(comparer);
		_SerializerReader = comparer;
	}

	public void Add(T key, TT value)
	{
		Add(new KeyValuePair<T, TT>(key, value));
	}

	public void Add([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1, 1 })] KeyValuePair<T, TT> item)
	{
		_FieldReader.Add(item.Key, item.Value);
		m_RuleReader.Add(item);
	}

	public void Clear()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				_FieldReader.Clear();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				m_RuleReader.Clear();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb == 0)
				{
					num2 = 2;
				}
				break;
			case 2:
				return;
			}
		}
	}

	public bool Contains([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1, 1 })] KeyValuePair<T, TT> item)
	{
		return _FieldReader.Contains(item);
	}

	public bool ContainsKey(T key)
	{
		return _FieldReader.ContainsKey(key);
	}

	public void CopyTo([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 1, 0, 1, 1 })] KeyValuePair<T, TT>[] array, int arrayIndex)
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
				m_RuleReader.CopyTo(array, arrayIndex);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0a707bb791e14c9e9a3ee77696a896b0 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 1, 0, 1, 1 })]
	public IEnumerator<KeyValuePair<T, TT>> GetEnumerator()
	{
		return m_RuleReader.GetEnumerator();
	}

	public void Insert(int index, T key, TT value)
	{
		_FieldReader.Add(key, value);
		m_RuleReader.Insert(index, new KeyValuePair<T, TT>(key, value));
	}

	public bool Remove(T key)
	{
		_003C_003Ec__DisplayClass27_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass27_0();
		CS_0024_003C_003E8__locals6._003C_003E4__this = this;
		CS_0024_003C_003E8__locals6.key = key;
		if (_FieldReader.ContainsKey(CS_0024_003C_003E8__locals6.key))
		{
			int index = m_RuleReader.FindIndex(([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1, 1 })] KeyValuePair<T, TT> kvp) => CS_0024_003C_003E8__locals6._003C_003E4__this._SerializerReader.Equals(kvp.Key, CS_0024_003C_003E8__locals6.key));
			m_RuleReader.RemoveAt(index);
			if (!_FieldReader.Remove(CS_0024_003C_003E8__locals6.key))
			{
				throw new InvalidOperationException();
			}
			return true;
		}
		return false;
	}

	public bool Remove([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1, 1 })] KeyValuePair<T, TT> item)
	{
		return Remove(item.Key);
	}

	public void RemoveAt(int index)
	{
		int num = 3;
		int num2 = num;
		KeyValuePair<T, TT> keyValuePair = default(KeyValuePair<T, TT>);
		T key = default(T);
		while (true)
		{
			switch (num2)
			{
			case 3:
				keyValuePair = m_RuleReader[index];
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf == 0)
				{
					num2 = 0;
				}
				break;
			default:
				m_RuleReader.RemoveAt(index);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 != 0)
				{
					num2 = 1;
				}
				break;
			case 2:
				key = keyValuePair.Key;
				num2 = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 == 0)
				{
					num2 = 2;
				}
				break;
			case 4:
				_FieldReader.Remove(key);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 == 0)
				{
					num2 = 0;
				}
				break;
			case 1:
				return;
			}
		}
	}

	public bool TryGetValue(T key, [StrategyBase(false)] out TT value)
	{
		return _FieldReader.TryGetValue(key, out value);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return m_RuleReader.GetEnumerator();
	}

	[OnDeserialized]
	internal void OnDeserializedMethod(StreamingContext context)
	{
		_FieldReader = new Dictionary<T, TT>();
		foreach (KeyValuePair<T, TT> item in m_RuleReader)
		{
			_FieldReader[item.Key] = item.Value;
		}
	}

	internal static bool ResetAuthentication()
	{
		return RateAuthentication == null;
	}

	internal static object CustomizeAuthentication()
	{
		return RateAuthentication;
	}
}
