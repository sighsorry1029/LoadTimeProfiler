using System;
using System.Collections;
using System.Collections.Generic;

namespace AzuAnticheat.Internal;

internal sealed class AttrAttribute<T, TT> : IDictionary, ICollection, IEnumerable where T : notnull
{
	private class ExporterAttribute : IDictionaryEnumerator, IEnumerator
	{
		private readonly IEnumerator<KeyValuePair<T, TT>> valAttribute;

		internal static object AddAttribute;

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
						current = valAttribute.Current;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4e61b266153f422fa6c595cfef4d40d3 == 0)
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

		public object? Value
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
					default:
						return current.Value;
					case 1:
						current = valAttribute.Current;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf != 0)
						{
							num2 = 0;
						}
						break;
					}
				}
			}
		}

		public object Current => Entry;

		public ExporterAttribute(IEnumerator<KeyValuePair<T, TT>> enumerator)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			valAttribute = enumerator;
		}

		public bool MoveNext()
		{
			return valAttribute.MoveNext();
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
					valAttribute.Reset();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 == 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}

		internal static bool PrepareAttribute()
		{
			return AddAttribute == null;
		}

		internal static object WriteAttribute()
		{
			return AddAttribute;
		}
	}

	private readonly IDictionary<T, TT> _MessageAttribute;

	private static object CallAttribute;

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

	public object? this[object key]
	{
		get
		{
			throw new NotSupportedException();
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
					_MessageAttribute[(T)key] = (TT)value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 == 0)
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

	public AttrAttribute(IDictionary<T, TT> genericDictionary)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		_MessageAttribute = genericDictionary ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1053593978 ^ -1053615830));
	}

	public void Add(object key, object? value)
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
		return new ExporterAttribute(_MessageAttribute.GetEnumerator());
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

	internal static bool ConcatAttribute()
	{
		return CallAttribute == null;
	}

	internal static object NewAttribute()
	{
		return CallAttribute;
	}
}
