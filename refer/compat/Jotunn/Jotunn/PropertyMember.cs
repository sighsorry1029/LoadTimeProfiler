using System.Reflection;
using Jotunn.Utils;
using UnityEngine;

namespace Jotunn;

internal class PropertyMember : MemberBase
{
	private readonly PropertyInfo propertyInfo;

	public PropertyMember(PropertyInfo propertyInfo)
	{
		this.propertyInfo = propertyInfo;
		base.MemberType = propertyInfo.PropertyType;
		base.IsUnityObject = base.MemberType.IsSameOrSubclass(typeof(Object));
		base.IsClass = base.MemberType.IsClass;
		base.HasGetMethod = propertyInfo.GetIndexParameters().Length == 0 && propertyInfo.GetMethod != null;
		base.HasSetMethod = propertyInfo.SetMethod != null;
		base.EnumeratedType = base.MemberType.GetEnumeratedType();
		base.IsEnumerableOfUnityObjects = base.EnumeratedType?.IsSameOrSubclass(typeof(Object)) ?? false;
		base.IsEnumeratedClass = base.EnumeratedType?.IsClass ?? false;
	}

	public override object GetValue(object obj)
	{
		try
		{
			return propertyInfo.GetValue(obj);
		}
		catch
		{
			return null;
		}
	}

	public override void SetValue(object obj, object value)
	{
		propertyInfo.SetValue(obj, value);
	}

	public override bool HasCustomAttribute<T>()
	{
		return propertyInfo.GetCustomAttribute<T>() != null;
	}
}
