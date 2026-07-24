using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Jotunn.Utils;

/// <summary>
///     Various utility methods aiding Reflection tasks.
/// </summary>
public static class ReflectionHelper
{
	/// <summary>
	///     Cache for Reflection tasks.
	/// </summary>
	public static class Cache
	{
		private static MethodInfo _enumerableToArray;

		private static MethodInfo _enumerableToList;

		private static MethodInfo _enumerableCast;

		/// <summary>
		///     <see cref="T:System.Reflection.MethodInfo" /> of <see cref="M:System.Linq.Enumerable.ToArray``1(System.Collections.Generic.IEnumerable{``0})" />
		/// </summary>
		public static MethodInfo EnumerableToArray
		{
			get
			{
				if (_enumerableToArray == null)
				{
					_enumerableToArray = typeof(Enumerable).GetMethod("ToArray", (BindingFlags)(-1));
				}
				return _enumerableToArray;
			}
		}

		/// <summary>
		///     <see cref="T:System.Reflection.MethodInfo" /> of <see cref="M:System.Linq.Enumerable.ToList``1(System.Collections.Generic.IEnumerable{``0})" />
		/// </summary>
		public static MethodInfo EnumerableToList
		{
			get
			{
				if (_enumerableToList == null)
				{
					_enumerableToList = typeof(Enumerable).GetMethod("ToList", (BindingFlags)(-1));
				}
				return _enumerableToList;
			}
		}

		/// <summary>
		///     <see cref="T:System.Reflection.MethodInfo" /> of <see cref="M:System.Linq.Enumerable.Cast``1(System.Collections.IEnumerable)" />
		/// </summary>
		public static MethodInfo EnumerableCast
		{
			get
			{
				if (_enumerableCast == null)
				{
					_enumerableCast = typeof(Enumerable).GetMethod("Cast", (BindingFlags)(-1));
				}
				return _enumerableCast;
			}
		}
	}

	/// <summary>
	///     All possible binding flags
	/// </summary>
	public const BindingFlags AllBindingFlags = (BindingFlags)(-1);

	/// <summary>
	///     Determines whether this type is the same or a subclass of another type
	/// </summary>
	/// <param name="type">this type</param>
	/// <param name="base">Type against the type is checked</param>
	/// <returns>true if this type is the same or a subtype</returns>
	public static bool IsSameOrSubclass(this Type type, Type @base)
	{
		if (!type.IsSubclassOf(@base))
		{
			return type == @base;
		}
		return true;
	}

	/// <summary>
	///     Determine whether the specified type <paramref name="type" /> is a subtype of the specified generic type or implements the specified generic interface.
	/// </summary>
	/// <param name="type">the type to be tested.</param>
	/// <param name="generic">generic interface type, passing in typeof (IXxx&lt;&gt;)</param>
	/// <returns>returns true if it is a subtype of the generic interface, or false.</returns>
	public static bool HasImplementedRawGeneric(this Type type, Type generic)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (generic == null)
		{
			throw new ArgumentNullException("generic");
		}
		if (type.GetInterfaces().Any(IsTheRawGenericType))
		{
			return true;
		}
		while (type != null && type != typeof(object))
		{
			if (IsTheRawGenericType(type))
			{
				return true;
			}
			type = type.BaseType;
		}
		return false;
		bool IsTheRawGenericType(Type test)
		{
			return generic == (test.IsGenericType ? test.GetGenericTypeDefinition() : test);
		}
	}

	/// <summary>
	///     Determines if this type inherits from <see cref="T:System.Collections.IEnumerable" />
	/// </summary>
	/// <param name="type">this type</param>
	/// <returns></returns>
	public static bool IsEnumerable(this Type type)
	{
		if (typeof(IEnumerable).IsAssignableFrom(type))
		{
			return type != typeof(string);
		}
		return false;
	}

	/// <summary>
	///     Get the generic <see cref="T:System.Collections.IEnumerable" /> type of this type.<br />
	///     https://stackoverflow.com/a/21995826
	/// </summary>
	/// <param name="type">this type</param>
	/// <returns></returns>
	public static Type GetEnumeratedType(this Type type)
	{
		object obj = type?.GetElementType();
		if (obj == null)
		{
			if (!typeof(IEnumerable).IsAssignableFrom(type))
			{
				return null;
			}
			obj = type.GetGenericArguments().FirstOrDefault();
		}
		return (Type)obj;
	}

	/// <summary>
	///     Get the <see cref="P:System.Type.ReflectedType" /> of the first caller outside of this assembly
	/// </summary>
	/// <returns>The reflected type of the first caller outside of this assembly</returns>
	public static Type GetCallingType()
	{
		return (new StackTrace().GetFrames() ?? Array.Empty<StackFrame>()).First((StackFrame x) => x.GetMethod().ReflectedType?.Assembly != typeof(Main).Assembly).GetMethod().ReflectedType;
	}

	/// <summary>
	///     Get the <see cref="T:System.Reflection.Assembly" /> of the first caller outside of this assembly
	/// </summary>
	/// <returns>The assembly of the first caller outside of this assembly</returns>
	public static Assembly GetCallingAssembly()
	{
		return (new StackTrace().GetFrames() ?? Array.Empty<StackFrame>()).First((StackFrame x) => x.GetMethod().ReflectedType?.Assembly != typeof(Main).Assembly).GetMethod().ReflectedType?.Assembly;
	}

	/// <summary>
	///     Invoke a private method of any class instance
	/// </summary>
	/// <param name="instance">Instance of the class</param>
	/// <param name="name">Name of the method</param>
	/// <param name="args">Argument values (if any) of the method</param>
	/// <returns>The return of the method as an <see cref="T:System.Object" /></returns>
	public static object InvokePrivate(object instance, string name, object[] args = null)
	{
		MethodInfo method = instance.GetType().GetMethod(name, BindingFlags.Instance | BindingFlags.NonPublic);
		if (method == null)
		{
			Type[] types = ((args == null) ? Type.EmptyTypes : args.Select((object arg) => arg.GetType()).ToArray());
			method = instance.GetType().GetMethod(name, types);
		}
		if (method == null)
		{
			Logger.LogError("Method " + name + " does not exist on type: " + instance.GetType());
			return null;
		}
		return method.Invoke(instance, args);
	}

	/// <summary>
	///     Get the value of a private property of any class instance
	/// </summary>
	/// <typeparam name="T">Generic property type</typeparam>
	/// <param name="instance">Instance of the class</param>
	/// <param name="name">Name of the property</param>
	/// <returns>The value of the property</returns>
	public static T GetPrivateProperty<T>(object instance, string name)
	{
		PropertyInfo property = instance.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.NonPublic);
		if (property == null)
		{
			Logger.LogError("Property " + name + " does not exist on type: " + instance.GetType());
			return default(T);
		}
		return (T)property.GetValue(instance);
	}

	/// <summary>
	///     Get the value of a private field of any class instance
	/// </summary>
	/// <typeparam name="T">Generic field type</typeparam>
	/// <param name="instance">Instance of the class</param>
	/// <param name="name">Name of the field</param>
	/// <returns>The value of the field</returns>
	public static T GetPrivateField<T>(object instance, string name)
	{
		FieldInfo field = instance.GetType().GetField(name, BindingFlags.Instance | BindingFlags.NonPublic);
		if (field == null)
		{
			Logger.LogError("Variable " + name + " does not exist on type: " + instance.GetType());
			return default(T);
		}
		return (T)field.GetValue(instance);
	}

	/// <summary>
	///     Get the value of a private static field of any class
	/// </summary>
	/// <typeparam name="T">Generic field type</typeparam>
	/// <param name="type">Type of the class</param>
	/// <param name="name">Name of the field</param>
	/// <returns>The value of the field</returns>
	public static T GetPrivateField<T>(Type type, string name)
	{
		FieldInfo field = type.GetField(name, BindingFlags.Static | BindingFlags.NonPublic);
		if (field == null)
		{
			Logger.LogError("Variable " + name + " does not exist on type: " + type);
			return default(T);
		}
		return (T)field.GetValue(null);
	}

	/// <summary>
	///     Set a value of a private field of any class instance
	/// </summary>
	/// <param name="instance">Instance of the class</param>
	/// <param name="name">Name of the field</param>
	/// <param name="value">New value of the field</param>
	public static void SetPrivateField(object instance, string name, object value)
	{
		FieldInfo field = instance.GetType().GetField(name, BindingFlags.Instance | BindingFlags.NonPublic);
		if (field == null)
		{
			Logger.LogError("Variable " + name + " does not exist on type: " + instance.GetType());
		}
		else
		{
			field.SetValue(instance, value);
		}
	}
}
