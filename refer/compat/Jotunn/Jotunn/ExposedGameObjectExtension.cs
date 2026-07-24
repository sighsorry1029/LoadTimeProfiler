using System;
using System.Collections.Generic;
using System.Reflection;
using Jotunn.Extensions;
using UnityEngine;

namespace Jotunn;

/// <summary>
///     Extends GameObject with a shortcut for the Unity bool operator override.
/// </summary>
public static class ExposedGameObjectExtension
{
	/// <summary>
	///     Facilitates use of null propagation operator for unity GameObjects by respecting op_equality.
	/// </summary>
	/// <param name="this"> this </param>
	/// <returns>Returns null when GameObject.op_equality returns false.</returns>
	public static GameObject OrNull(this GameObject @this)
	{
		if (!@this)
		{
			return null;
		}
		return @this;
	}

	/// <summary>
	///     Facilitates use of null propagation operator for unity MonBehaviours by respecting op_equality.
	/// </summary>
	/// <typeparam name="T">Any type that inherits MonoBehaviour</typeparam>
	/// <param name="this">this</param>
	/// <returns>Returns null when MonoBehaviours.op_equality returns false.</returns>
	public static T OrNull<T>(this T @this) where T : UnityEngine.Object
	{
		if (!@this)
		{
			return null;
		}
		return @this;
	}

	/// <summary>
	///     Returns the component of Type type. If one doesn't already exist on the GameObject it will be added.
	/// </summary>
	/// <remarks>Source: https://wiki.unity3d.com/index.php/GetOrAddComponent</remarks>
	/// <typeparam name="T">The type of Component to return.</typeparam>
	/// <param name="gameObject">The GameObject this Component is attached to.</param>
	/// <returns>Component</returns>
	public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
	{
		if (!gameObject.TryGetComponent<T>(out var component))
		{
			return gameObject.AddComponent<T>();
		}
		return component;
	}

	/// <summary>
	///     Adds a new copy of the provided component to a gameObject
	/// </summary>
	/// <param name="gameObject"></param>
	/// <param name="duplicate"></param>
	/// <typeparam name="T"></typeparam>
	/// <returns></returns>
	public static Component AddComponentCopy<T>(this GameObject gameObject, T duplicate) where T : Component
	{
		Component component = gameObject.AddComponent(duplicate.GetType());
		PropertyInfo[] properties = duplicate.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (PropertyInfo propertyInfo in properties)
		{
			switch (propertyInfo.Name)
			{
			case "mesh":
				if (duplicate is MeshFilter)
				{
					continue;
				}
				break;
			case "material":
			case "materials":
				if (duplicate is Renderer)
				{
					continue;
				}
				break;
			case "bounds":
				if (duplicate is Renderer)
				{
					continue;
				}
				break;
			case "name":
			case "rayTracingMode":
			case "tag":
				continue;
			}
			if (propertyInfo.CanWrite && propertyInfo.GetMethod != null)
			{
				propertyInfo.SetValue(component, propertyInfo.GetValue(duplicate));
			}
		}
		FieldInfo[] fields = duplicate.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (FieldInfo fieldInfo in fields)
		{
			if (!(fieldInfo.Name == "rayTracingMode"))
			{
				fieldInfo.SetValue(component, fieldInfo.GetValue(duplicate));
			}
		}
		return component;
	}

	/// <summary>
	///     Check if GameObject has any of the specified components.
	/// </summary>
	/// <param name="gameObject"></param>
	/// <param name="components"></param>
	/// <returns></returns>
	public static bool HasAnyComponent(this GameObject gameObject, params Type[] components)
	{
		foreach (Type type in components)
		{
			if ((bool)gameObject.GetComponent(type))
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	///     Check if GameObject has any of the specified components.
	/// </summary>
	/// <param name="gameObject"></param>
	/// <param name="componentNames"></param>
	/// <returns></returns>
	public static bool HasAnyComponent(this GameObject gameObject, params string[] componentNames)
	{
		foreach (string type in componentNames)
		{
			if ((bool)gameObject.GetComponent(type))
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	///     Check if GameObject has all of the specified components.
	/// </summary>
	/// <param name="gameObject"></param>
	/// <param name="componentNames"></param>
	/// <returns></returns>
	public static bool HasAllComponents(this GameObject gameObject, params string[] componentNames)
	{
		foreach (string type in componentNames)
		{
			if (!gameObject.GetComponent(type))
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	///     Check if GameObject has all of the specified components.
	/// </summary>
	/// <param name="gameObject"></param>
	/// <param name="components"></param>
	/// <returns></returns>
	public static bool HasAllComponents(this GameObject gameObject, params Type[] components)
	{
		foreach (Type type in components)
		{
			if (!gameObject.GetComponent(type))
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	///     Check if GameObject or any of it's children
	///     have any of the specified components.
	/// </summary>
	/// <param name="gameObject"></param>
	/// <param name="includeInactive"></param>
	/// <param name="components"></param>
	/// <returns></returns>
	public static bool HasAnyComponentInChildren(this GameObject gameObject, bool includeInactive = false, params Type[] components)
	{
		foreach (Type type in components)
		{
			if ((bool)gameObject.GetComponentInChildren(type, includeInactive))
			{
				return true;
			}
		}
		return false;
	}

	public static Transform FindDeepChild(this GameObject gameObject, string childName, IterativeSearchType searchType = (IterativeSearchType)1)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return gameObject.transform.FindDeepChild(childName, searchType);
	}

	public static Transform FindDeepChild(this GameObject gameObject, IEnumerable<string> childNames, IterativeSearchType searchType = (IterativeSearchType)1)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		Transform transform = gameObject.transform;
		foreach (string childName in childNames)
		{
			transform = transform.FindDeepChild(childName, searchType);
			if (!transform)
			{
				return null;
			}
		}
		return transform;
	}
}
