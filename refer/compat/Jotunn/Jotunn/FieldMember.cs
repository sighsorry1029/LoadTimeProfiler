using System.Reflection;
using Jotunn.Utils;
using UnityEngine;

namespace Jotunn;

internal class FieldMember : MemberBase
{
	private readonly FieldInfo fieldInfo;

	public FieldMember(FieldInfo fieldInfo)
	{
		this.fieldInfo = fieldInfo;
		base.MemberType = fieldInfo.FieldType;
		base.IsUnityObject = base.MemberType.IsSameOrSubclass(typeof(Object));
		base.IsClass = base.MemberType.IsClass;
		base.HasGetMethod = true;
		base.HasSetMethod = true;
		base.EnumeratedType = base.MemberType.GetEnumeratedType();
		base.IsEnumerableOfUnityObjects = base.EnumeratedType?.IsSameOrSubclass(typeof(Object)) ?? false;
		base.IsEnumeratedClass = base.EnumeratedType?.IsClass ?? false;
	}

	public override object GetValue(object obj)
	{
		try
		{
			return fieldInfo.GetValue(obj);
		}
		catch
		{
			return null;
		}
	}

	public override void SetValue(object obj, object value)
	{
		fieldInfo.SetValue(obj, value);
	}

	public override bool HasCustomAttribute<T>()
	{
		return fieldInfo.GetCustomAttribute<T>() != null;
	}
}
