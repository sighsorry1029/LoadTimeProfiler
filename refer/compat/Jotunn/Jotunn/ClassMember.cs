using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Jotunn;

internal class ClassMember
{
	private static readonly Dictionary<Type, ClassMember> CachedClassMembers = new Dictionary<Type, ClassMember>();

	public List<MemberBase> Members { get; private set; } = new List<MemberBase>();

	public Type Type { get; private set; }

	private ClassMember(Type type, IEnumerable<FieldInfo> fieldInfos, IEnumerable<PropertyInfo> propertyInfos)
	{
		Type = type;
		foreach (FieldInfo fieldInfo in fieldInfos)
		{
			AddMember(new FieldMember(fieldInfo));
		}
		foreach (PropertyInfo propertyInfo in propertyInfos)
		{
			AddMember(new PropertyMember(propertyInfo));
		}
	}

	private void AddMember(MemberBase member)
	{
		if (member.IsClass && !(member.MemberType == typeof(string)) && (!(member.EnumeratedType != null) || (member.IsEnumeratedClass && !(member.EnumeratedType == typeof(string)))) && !member.HasCustomAttribute<NonSerializedAttribute>())
		{
			Members.Add(member);
		}
	}

	private static T[] GetMembersFromType<T>(Type type, Func<Type, T[]> getMembers)
	{
		T[] array = getMembers(type);
		Type baseType = type.BaseType;
		while (baseType != null)
		{
			T[] second = getMembers(baseType);
			array = array.Union(second).ToArray();
			baseType = baseType.BaseType;
		}
		return array;
	}

	public static ClassMember GetClassMember(Type type)
	{
		if (CachedClassMembers.TryGetValue(type, out var value))
		{
			return value;
		}
		FieldInfo[] membersFromType = GetMembersFromType(type, (Type t) => t.GetFields(~BindingFlags.Static));
		PropertyInfo[] membersFromType2 = GetMembersFromType(type, (Type t) => t.GetProperties(~BindingFlags.Static));
		value = new ClassMember(type, membersFromType, membersFromType2);
		CachedClassMembers[type] = value;
		return value;
	}
}
