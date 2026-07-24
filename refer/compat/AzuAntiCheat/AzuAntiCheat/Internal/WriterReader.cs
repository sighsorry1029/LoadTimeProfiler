using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class WriterReader<T, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] TT> : IDictionary, ICollection, IEnumerable
{
	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
	private class AuthenticationReader : IDictionaryEnumerator, IEnumerator
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 1, 0, 1, 1 })]
		private readonly IEnumerator<KeyValuePair<T, TT>> attributeReader;

		internal static object InstantiateAuthentication;

		public DictionaryEntry Entry => new DictionaryEntry(Key, Value);

		public object Key
		{
			get
			{
				int num = 1;
				int num2 = num;
				KeyValuePair<T, TT> current = default(KeyValuePair<T, TT>);
				while (true)
				{
					switch (num2)
					{
					case 1:
						current = attributeReader.Current;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c2b9915913b8461884afdca5d98855ec != 0)
						{
							num2 = 0;
						}
						break;
					default:
						return current.Key;
					}
				}
			}
		}

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
		public object Value
		{
			[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
			get
			{
				int num = 1;
				int num2 = num;
				KeyValuePair<T, TT> current = default(KeyValuePair<T, TT>);
				while (true)
				{
					switch (num2)
					{
					case 1:
						current = attributeReader.Current;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf == 0)
						{
							num2 = 0;
						}
						break;
					default:
						return current.Value;
					}
				}
			}
		}

		public object Current => Entry;

		public AuthenticationReader([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 1, 0, 1, 1 })] IEnumerator<KeyValuePair<T, TT>> enumerator)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			attributeReader = enumerator;
		}

		public bool MoveNext()
		{
			return attributeReader.MoveNext();
		}

		public void Reset()
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
					attributeReader.Reset();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f != 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}

		internal static bool LoginAuthentication()
		{
			return InstantiateAuthentication == null;
		}

		internal static object ConnectAuthentication()
		{
			return InstantiateAuthentication;
		}
	}

	private readonly IDictionary<T, TT> m_InvocationReader;

	private static object DisableAuthentication;

	public bool IsFixedSize
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	public bool IsReadOnly
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	public ICollection Keys
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	public ICollection Values
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	public object this[object key]
	{
		[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
		get
		{
			throw new NotSupportedException();
		}
		[param: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
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
					m_InvocationReader[(T)key] = (TT)value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public int Count
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	public bool IsSynchronized
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	public object SyncRoot
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	public WriterReader(IDictionary<T, TT> genericDictionary)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		m_InvocationReader = genericDictionary ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(--1844849127 ^ 0x6DF65E4B));
	}

	public void Add(object key, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] object value)
	{
		throw new NotSupportedException();
	}

	public void Clear()
	{
		throw new NotSupportedException();
	}

	public bool Contains(object key)
	{
		throw new NotSupportedException();
	}

	public IDictionaryEnumerator GetEnumerator()
	{
		return new AuthenticationReader(m_InvocationReader.GetEnumerator());
	}

	public void Remove(object key)
	{
		throw new NotSupportedException();
	}

	public void CopyTo(Array array, int index)
	{
		throw new NotSupportedException();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	internal static bool QueryAuthentication()
	{
		return DisableAuthentication == null;
	}

	internal static object AwakeAuthentication()
	{
		return DisableAuthentication;
	}
}
