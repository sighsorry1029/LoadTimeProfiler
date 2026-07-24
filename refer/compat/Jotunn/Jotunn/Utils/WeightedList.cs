using System;
using System.Collections.Generic;
using UnityEngine;

namespace Jotunn.Utils;

/// <summary>
///     Like a list but stores elements in the order specified by the weight.
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="ItemType"></typeparam>
public class WeightedList<T, ItemType> where T : WeightedItem<ItemType>
{
	public readonly List<T> List;

	public WeightedList()
	{
		List = new List<T>();
	}

	public void Add(T item)
	{
		List.Add(item);
	}

	public bool Remove(T item)
	{
		return List.Remove(item);
	}

	public ItemType GetRandomItem(List<T> list = null)
	{
		if (list == null)
		{
			list = List;
		}
		float num = 0f;
		foreach (T item in list)
		{
			num += item.Weight;
		}
		float num2 = UnityEngine.Random.Range(0f, num - 1f);
		foreach (T item2 in list)
		{
			if (num2 < item2.Weight)
			{
				return item2.Item;
			}
			num2 -= item2.Weight;
		}
		throw new Exception("No item in weighted list");
	}
}
