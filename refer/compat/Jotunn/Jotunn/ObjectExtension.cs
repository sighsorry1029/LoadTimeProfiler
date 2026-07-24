using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Jotunn;

/// <summary>
///     Helpful Unity Object extensions.
/// </summary>
internal static class ObjectExtension
{
	public static string GetObjectString(this object obj)
	{
		if (obj == null)
		{
			return "null";
		}
		string text = $"{obj}";
		Type type = obj.GetType();
		IEnumerable<FieldInfo> enumerable = from f in type.GetFields()
			where f.IsPublic
			select f;
		foreach (FieldInfo item in enumerable)
		{
			object value = item.GetValue(obj);
			string text2 = ((value == null) ? "null" : value.ToString());
			text = text + "\n " + item.Name + ": " + text2;
		}
		PropertyInfo[] properties = type.GetProperties();
		PropertyInfo[] array = properties;
		foreach (PropertyInfo propertyInfo in array)
		{
			object value2 = propertyInfo.GetValue(obj, null);
			string text3 = ((value2 == null) ? "null" : value2.ToString());
			text = text + "\n " + propertyInfo.Name + ": " + text3;
		}
		return text;
	}
}
