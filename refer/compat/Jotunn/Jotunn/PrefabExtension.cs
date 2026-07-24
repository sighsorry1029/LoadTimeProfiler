using System;
using System.Collections.Generic;
using System.Reflection;
using Jotunn.Managers;
using UnityEngine;

namespace Jotunn;

/// <summary>
///     Extends prefab GameObjects with functionality related to the mocking system.
/// </summary>
public static class PrefabExtension
{
	/// <summary>
	///     Will attempt to fix every field that are mocks gameObjects / Components from the given object.
	/// </summary>
	/// <param name="objectToFix"></param>
	public static void FixReferences(this object objectToFix)
	{
		MockResolveFailure.MockResolveFailures.Clear();
		MockManager.FixReferences(objectToFix, 0);
		UnityEngine.Object obj = objectToFix as UnityEngine.Object;
		string prefabName = (obj ? obj.name : objectToFix.ToString());
		MockResolveFailure.PrintMockResolveFailures(prefabName);
	}

	/// <summary>
	///     Resolves all references for mocks in this GameObject's components recursively
	/// </summary>
	/// <param name="gameObject"></param>
	public static void FixReferences(this GameObject gameObject)
	{
		MockResolveFailure.MockResolveFailures.Clear();
		gameObject.FixReferencesInternal(recursive: false);
		string prefabName = (gameObject ? gameObject.name : string.Empty);
		MockResolveFailure.PrintMockResolveFailures(prefabName);
	}

	/// <summary>
	///     Resolves all references for mocks in this GameObject recursively.
	///     Can additionally traverse the transforms hierarchy to fix child GameObjects recursively.
	/// </summary>
	/// <param name="gameObject">This GameObject</param>
	/// <param name="recursive">Traverse all child transforms</param>
	public static void FixReferences(this GameObject gameObject, bool recursive)
	{
		MockResolveFailure.MockResolveFailures.Clear();
		gameObject.FixReferencesInternal(recursive);
		string prefabName = (gameObject ? gameObject.name : string.Empty);
		MockResolveFailure.PrintMockResolveFailures(prefabName);
	}

	/// <summary>
	///     Resolves all references for mocks in this GameObject recursively.
	///     Can additionally traverse the transforms hierarchy to fix child GameObjects recursively.
	/// </summary>
	/// <param name="gameObject">This GameObject</param>
	/// <param name="recursive">Traverse all child transforms</param>
	private static void FixReferencesInternal(this GameObject gameObject, bool recursive)
	{
		Component[] components = gameObject.GetComponents<Component>();
		foreach (Component component in components)
		{
			if (!(component is Transform))
			{
				MockManager.FixReferences(component, 0);
			}
		}
		if (!recursive)
		{
			return;
		}
		List<Tuple<Transform, GameObject>> list = new List<Tuple<Transform, GameObject>>();
		foreach (Transform item in gameObject.transform)
		{
			GameObject realPrefabFromMock = MockManager.GetRealPrefabFromMock<GameObject>(item.gameObject);
			if ((bool)realPrefabFromMock)
			{
				list.Add(new Tuple<Transform, GameObject>(item, realPrefabFromMock));
			}
			else
			{
				item.gameObject.FixReferencesInternal(recursive: true);
			}
		}
		foreach (Tuple<Transform, GameObject> item2 in list)
		{
			MockManager.ReplaceMockGameObject(item2.Item1, item2.Item2, gameObject);
		}
	}

	/// <summary>
	///     Clones all fields from this GameObject to objectToClone.
	/// </summary>
	/// <param name="gameObject"></param>
	/// <param name="objectToClone"></param>
	public static void CloneFields(this GameObject gameObject, GameObject objectToClone)
	{
		Dictionary<FieldInfo, object> dictionary = new Dictionary<FieldInfo, object>();
		Component[] componentsInChildren = objectToClone.GetComponentsInChildren<Component>();
		Component[] array = componentsInChildren;
		foreach (Component component in array)
		{
			FieldInfo[] fields = component.GetType().GetFields((BindingFlags)(-1));
			foreach (FieldInfo fieldInfo in fields)
			{
				if (!fieldInfo.IsLiteral && !fieldInfo.IsInitOnly)
				{
					dictionary.Add(fieldInfo, fieldInfo.GetValue(component));
				}
			}
			if (!gameObject.GetComponent(component.GetType()))
			{
				gameObject.AddComponent(component.GetType());
			}
		}
		Component[] componentsInChildren2 = gameObject.GetComponentsInChildren<Component>();
		Component[] array2 = componentsInChildren2;
		foreach (Component component2 in array2)
		{
			FieldInfo[] fields2 = component2.GetType().GetFields((BindingFlags)(-1));
			foreach (FieldInfo fieldInfo2 in fields2)
			{
				if (dictionary.TryGetValue(fieldInfo2, out var value))
				{
					fieldInfo2.SetValue(component2, value);
				}
			}
		}
	}
}
