using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SimpleJson;

/// <summary>
/// Represents the json object.
/// </summary>
[GeneratedCode("simple-json", "1.0.0")]
[EditorBrowsable(EditorBrowsableState.Never)]
public class JsonObject : IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable
{
	/// <summary>
	/// The internal member dictionary.
	/// </summary>
	private readonly Dictionary<string, object> _members;

	/// <summary>
	/// Gets the <see cref="T:System.Object" /> at the specified index.
	/// </summary>
	/// <value></value>
	public object this[int index] => GetAtIndex(_members, index);

	/// <summary>
	/// Gets the keys.
	/// </summary>
	/// <value>The keys.</value>
	public ICollection<string> Keys => _members.Keys;

	/// <summary>
	/// Gets the values.
	/// </summary>
	/// <value>The values.</value>
	public ICollection<object> Values => _members.Values;

	/// <summary>
	/// Gets or sets the <see cref="T:System.Object" /> with the specified key.
	/// </summary>
	/// <value></value>
	public object this[string key]
	{
		get
		{
			return _members[key];
		}
		set
		{
			_members[key] = value;
		}
	}

	/// <summary>
	/// Gets the count.
	/// </summary>
	/// <value>The count.</value>
	public int Count => _members.Count;

	/// <summary>
	/// Gets a value indicating whether this instance is read only.
	/// </summary>
	/// <value>
	/// 	<c>true</c> if this instance is read only; otherwise, <c>false</c>.
	/// </value>
	public bool IsReadOnly => false;

	/// <summary>
	/// Initializes a new instance of <see cref="T:SimpleJson.JsonObject" />.
	/// </summary>
	public JsonObject()
	{
		_members = new Dictionary<string, object>();
	}

	/// <summary>
	/// Initializes a new instance of <see cref="T:SimpleJson.JsonObject" />.
	/// </summary>
	/// <param name="comparer">The <see cref="T:System.Collections.Generic.IEqualityComparer`1" /> implementation to use when comparing keys, or null to use the default <see cref="T:System.Collections.Generic.EqualityComparer`1" /> for the type of the key.</param>
	public JsonObject(IEqualityComparer<string> comparer)
	{
		_members = new Dictionary<string, object>(comparer);
	}

	internal static object GetAtIndex(IDictionary<string, object> obj, int index)
	{
		if (obj == null)
		{
			throw new ArgumentNullException("obj");
		}
		if (index >= obj.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		int num = 0;
		foreach (KeyValuePair<string, object> item in obj)
		{
			if (num++ == index)
			{
				return item.Value;
			}
		}
		return null;
	}

	/// <summary>
	/// Adds the specified key.
	/// </summary>
	/// <param name="key">The key.</param>
	/// <param name="value">The value.</param>
	public void Add(string key, object value)
	{
		_members.Add(key, value);
	}

	/// <summary>
	/// Determines whether the specified key contains key.
	/// </summary>
	/// <param name="key">The key.</param>
	/// <returns>
	///     <c>true</c> if the specified key contains key; otherwise, <c>false</c>.
	/// </returns>
	public bool ContainsKey(string key)
	{
		return _members.ContainsKey(key);
	}

	/// <summary>
	/// Removes the specified key.
	/// </summary>
	/// <param name="key">The key.</param>
	/// <returns></returns>
	public bool Remove(string key)
	{
		return _members.Remove(key);
	}

	/// <summary>
	/// Tries the get value.
	/// </summary>
	/// <param name="key">The key.</param>
	/// <param name="value">The value.</param>
	/// <returns></returns>
	public bool TryGetValue(string key, out object value)
	{
		return _members.TryGetValue(key, out value);
	}

	/// <summary>
	/// Adds the specified item.
	/// </summary>
	/// <param name="item">The item.</param>
	public void Add(KeyValuePair<string, object> item)
	{
		_members.Add(item.Key, item.Value);
	}

	/// <summary>
	/// Clears this instance.
	/// </summary>
	public void Clear()
	{
		_members.Clear();
	}

	/// <summary>
	/// Determines whether [contains] [the specified item].
	/// </summary>
	/// <param name="item">The item.</param>
	/// <returns>
	/// 	<c>true</c> if [contains] [the specified item]; otherwise, <c>false</c>.
	/// </returns>
	public bool Contains(KeyValuePair<string, object> item)
	{
		if (_members.ContainsKey(item.Key))
		{
			return _members[item.Key] == item.Value;
		}
		return false;
	}

	/// <summary>
	/// Copies to.
	/// </summary>
	/// <param name="array">The array.</param>
	/// <param name="arrayIndex">Index of the array.</param>
	public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		int num = Count;
		using IEnumerator<KeyValuePair<string, object>> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			KeyValuePair<string, object> current = enumerator.Current;
			array[arrayIndex++] = current;
			if (--num <= 0)
			{
				break;
			}
		}
	}

	/// <summary>
	/// Removes the specified item.
	/// </summary>
	/// <param name="item">The item.</param>
	/// <returns></returns>
	public bool Remove(KeyValuePair<string, object> item)
	{
		return _members.Remove(item.Key);
	}

	/// <summary>
	/// Gets the enumerator.
	/// </summary>
	/// <returns></returns>
	public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
	{
		return _members.GetEnumerator();
	}

	/// <summary>
	/// Returns an enumerator that iterates through a collection.
	/// </summary>
	/// <returns>
	/// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
	/// </returns>
	IEnumerator IEnumerable.GetEnumerator()
	{
		return _members.GetEnumerator();
	}

	/// <summary>
	/// Returns a json <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
	/// </summary>
	/// <returns>
	/// A json <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
	/// </returns>
	public override string ToString()
	{
		return SimpleJson.SerializeObject(this);
	}
}
