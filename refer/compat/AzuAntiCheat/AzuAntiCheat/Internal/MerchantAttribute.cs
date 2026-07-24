using System;
using System.Collections;
using System.Collections.Generic;

namespace AzuAnticheat.Internal;

internal sealed class MerchantAttribute<T> : IList, ICollection, IEnumerable
{
	private readonly ICollection<T> testAttribute;

	private static object? VerifyAttribute;

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

	public object? this[int index]
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
				case 1:
					((IList<T>)testAttribute)[index] = (T)value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0a707bb791e14c9e9a3ee77696a896b0 != 0)
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

	public MerchantAttribute(ICollection<T> genericCollection)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		testAttribute = genericCollection ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-25744665 ^ -25731743));
	}

	public int Add(object? value)
	{
		int count = testAttribute.Count;
		testAttribute.Add((T)value);
		return count;
	}

	public void Clear()
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
				testAttribute.Clear();
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

	public bool Contains(object? value)
	{
		throw new NotSupportedException();
	}

	public int IndexOf(object? value)
	{
		throw new NotSupportedException();
	}

	public void Insert(int index, object? value)
	{
		throw new NotSupportedException();
	}

	public void Remove(object? value)
	{
		throw new NotSupportedException();
	}

	public void RemoveAt(int index)
	{
		throw new NotSupportedException();
	}

	public void CopyTo(Array array, int index)
	{
		throw new NotSupportedException();
	}

	public IEnumerator GetEnumerator()
	{
		return testAttribute.GetEnumerator();
	}

	internal static bool PopAttribute()
	{
		return VerifyAttribute == null;
	}

	internal static object? PostAttribute()
	{
		return VerifyAttribute;
	}
}
