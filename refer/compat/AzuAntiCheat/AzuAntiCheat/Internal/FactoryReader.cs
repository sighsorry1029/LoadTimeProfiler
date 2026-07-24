using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
internal sealed class FactoryReader<T> : IList, ICollection, IEnumerable
{
	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(1)]
	private readonly ICollection<T> setterReader;

	internal static object FlushAuthentication;

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

	public object this[int index]
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
					((IList<T>)setterReader)[index] = (T)value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 != 0)
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

	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(1)]
	public object SyncRoot
	{
		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
		get
		{
			throw new NotSupportedException();
		}
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	public FactoryReader(ICollection<T> genericCollection)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		setterReader = genericCollection ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x4C23C86A ^ 0x4C23BFEC));
	}

	public int Add(object value)
	{
		int count = setterReader.Count;
		setterReader.Add((T)value);
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
				setterReader.Clear();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public bool Contains(object value)
	{
		throw new NotSupportedException();
	}

	public int IndexOf(object value)
	{
		throw new NotSupportedException();
	}

	public void Insert(int index, object value)
	{
		throw new NotSupportedException();
	}

	public void Remove(object value)
	{
		throw new NotSupportedException();
	}

	public void RemoveAt(int index)
	{
		throw new NotSupportedException();
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	public void CopyTo(Array array, int index)
	{
		throw new NotSupportedException();
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	public IEnumerator GetEnumerator()
	{
		return setterReader.GetEnumerator();
	}

	internal static bool DestroyAuthentication()
	{
		return FlushAuthentication == null;
	}

	internal static object ComputeAuthentication()
	{
		return FlushAuthentication;
	}
}
