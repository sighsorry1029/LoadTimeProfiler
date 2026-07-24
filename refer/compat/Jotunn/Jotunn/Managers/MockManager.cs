using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using Jotunn.Extensions;
using Jotunn.Utils;
using UnityEngine;

namespace Jotunn.Managers;

/// <summary>
///     Handles all logic to do with managing mocked prefabs added into the game.
/// </summary>
internal class MockManager : IManager
{
	private static class Patches
	{
		[HarmonyPatch(typeof(ZoneSystem), "Start")]
		[HarmonyPostfix]
		private static void ZoneSystem_Start(ZoneSystem __instance)
		{
			FixQueuedMaterials();
		}
	}

	private static MockManager _instance;

	/// <summary>
	///     Legacy ValheimLib prefix used by the Mock System to recognize Mock gameObject that must be replaced at some point.
	/// </summary>
	[Obsolete("Legacy ValheimLib mock prefix. Use JVLMockPrefix \"JVLmock_\" instead.")]
	public const string MockPrefix = "VLmock_";

	/// <summary>
	///     Prefix used by the Mock System to recognize Mock gameObject that must be replaced at some point.
	/// </summary>
	public const string JVLMockPrefix = "JVLmock_";

	/// <summary>
	///     String used by the Mock System to recognize start of a relative path of a replacement for a Mock gameObject.
	/// </summary>
	public const string JVLMockSeparator = "__";

	/// <summary>
	///     Internal container for mocked prefabs
	/// </summary>
	internal GameObject MockPrefabContainer;

	private Dictionary<string, GameObject> mockedPrefabs = new Dictionary<string, GameObject>();

	private static HashSet<Material> fixedMaterials = new HashSet<Material>();

	private static HashSet<Material> queuedToFixMaterials = new HashSet<Material>();

	private static bool allVanillaObjectsAvailable;

	/// <summary>
	///     The singleton instance of this manager.
	/// </summary>
	public static MockManager Instance => _instance ?? (_instance = new MockManager());

	private static MethodInfo Object_IsPersistent { get; } = AccessTools.Method(typeof(UnityEngine.Object), "IsPersistent");

	/// <summary>
	///     Hide .ctor
	/// </summary>
	private MockManager()
	{
		((IManager)this).Init();
	}

	/// <summary>
	///     Creates the container and registers all hooks
	/// </summary>
	void IManager.Init()
	{
		Main.LogInit("MockManager");
		MockPrefabContainer = new GameObject("MockPrefabs");
		MockPrefabContainer.transform.parent = Main.RootObject.transform;
		MockPrefabContainer.SetActive(value: false);
		Main.Harmony.PatchAll(typeof(Patches));
	}

	/// <summary>
	///     Create an empty GameObject with the mock string prepended
	/// </summary>
	/// <param name="prefabName">Name of the mocked vanilla prefab</param>
	/// <returns>Mocked GameObject reference</returns>
	public GameObject CreateMockedGameObject(string prefabName)
	{
		string text = "JVLmock_" + prefabName;
		if (mockedPrefabs.TryGetValue(text, out var value) && (bool)value)
		{
			return value;
		}
		GameObject gameObject = new GameObject(text);
		gameObject.transform.parent = MockPrefabContainer.transform;
		gameObject.SetActive(value: false);
		mockedPrefabs[text] = gameObject;
		return gameObject;
	}

	/// <summary>
	///     Create a mocked component on an empty GameObject
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="prefabName"></param>
	/// <returns></returns>
	public T CreateMockedPrefab<T>(string prefabName) where T : Component
	{
		GameObject gameObject = CreateMockedGameObject(prefabName);
		string name = gameObject.name;
		T orAddComponent = gameObject.GetOrAddComponent<T>();
		if (!orAddComponent)
		{
			Logger.LogWarning($"Could not create mock for prefab {prefabName} of type {typeof(T)}");
			return null;
		}
		orAddComponent.name = name;
		return orAddComponent;
	}

	/// <summary>
	///     Will try to find the real vanilla prefab from the given mock
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="unityObject"></param>
	/// <returns>the real prefab</returns>
	public static T GetRealPrefabFromMock<T>(UnityEngine.Object unityObject) where T : UnityEngine.Object
	{
		return (T)GetRealPrefabFromMock(unityObject, typeof(T));
	}

	/// <summary>
	///     Will try to find the real vanilla prefab from the given mock
	/// </summary>
	/// <param name="unityObject"></param>
	/// <param name="mockObjectType"></param>
	/// <returns>the real prefab</returns>
	public static UnityEngine.Object GetRealPrefabFromMock(UnityEngine.Object unityObject, Type mockObjectType)
	{
		if (!unityObject)
		{
			return null;
		}
		if (GUIUtils.IsHeadless && mockObjectType == typeof(Texture))
		{
			return null;
		}
		if (!IsMockName(GetCleanedName(mockObjectType, unityObject.name), out var assetName, out var childNames))
		{
			return null;
		}
		if (childNames.Count == 0 && TryGetAsset(mockObjectType, assetName, out var asset))
		{
			return asset;
		}
		GameObject gameObject = PrefabManager.Cache.GetPrefab<GameObject>(assetName);
		if (!gameObject)
		{
			if (childNames.Count > 0)
			{
				MockResolveFailure.MockResolveFailures.Add(new MockResolveFailure("GameObject with name '" + assetName + "' was not found.", assetName, childNames, mockObjectType));
			}
			else
			{
				MockResolveFailure.MockResolveFailures.Add(new MockResolveFailure("", assetName, "", mockObjectType));
			}
			return null;
		}
		if (childNames.Count > 0)
		{
			Transform transform = gameObject.FindDeepChild(childNames, (IterativeSearchType)1);
			if (!transform || transform.name != childNames.Last())
			{
				MockResolveFailure.MockResolveFailures.Add(new MockResolveFailure("Child '" + childNames.Last() + "' not found with the specified path.", assetName, childNames, mockObjectType));
				return null;
			}
			gameObject = transform.gameObject;
		}
		if (PrefabManager.TryFindAssetInSelfOrChildComponents(gameObject, mockObjectType, out asset))
		{
			return asset;
		}
		if (childNames.Count > 0)
		{
			string text = Utils.GetPath(gameObject.transform).TrimStart('/');
			MockResolveFailure.MockResolveFailures.Add(new MockResolveFailure(mockObjectType.Name + " not found at child '" + text + "'.", assetName, childNames, mockObjectType));
		}
		else
		{
			MockResolveFailure.MockResolveFailures.Add(new MockResolveFailure(mockObjectType.Name + " not found at prefab '" + assetName + "'.", assetName, "", mockObjectType));
		}
		return null;
	}

	private static bool TryGetAsset(Type mockObjectType, string assetName, out UnityEngine.Object asset)
	{
		asset = PrefabManager.Cache.GetPrefab(mockObjectType, assetName);
		return asset;
	}

	internal static void FixReferences(object objectToFix, int depth)
	{
		if (depth == 5 || objectToFix == null)
		{
			return;
		}
		Type type = objectToFix.GetType();
		ClassMember classMember = ClassMember.GetClassMember(type);
		foreach (MemberBase member in classMember.Members)
		{
			FixMemberReferences(member, objectToFix, depth + 1);
		}
	}

	internal static void ReplaceMockGameObject(Transform child, GameObject realPrefab, GameObject parent)
	{
		if (IsPersistent(parent))
		{
			Logger.LogWarning("Cannot replace mock child " + child.name + " in persistent prefab " + parent.name + ". Clone the prefab before replacing mocks, i.e. with PrefabManager.Instance.CreateClonedPrefab or ZoneManager.Instance.CreateLocationContainer for locations");
		}
		else
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(realPrefab, parent.transform);
			gameObject.name = realPrefab.name;
			gameObject.SetActive(child.gameObject.activeSelf);
			gameObject.transform.position = child.gameObject.transform.position;
			gameObject.transform.rotation = child.gameObject.transform.rotation;
			gameObject.transform.localScale = child.gameObject.transform.localScale;
			int siblingIndex = child.GetSiblingIndex();
			UnityEngine.Object.DestroyImmediate(child.gameObject);
			gameObject.transform.SetSiblingIndex(siblingIndex);
		}
	}

	private static bool IsPersistent(GameObject parent)
	{
		return (bool)Object_IsPersistent.Invoke(null, new object[1] { parent });
	}

	private static bool IsMockName(string name, out string assetName, out List<string> childNames)
	{
		name = name.Trim();
		if (name.StartsWith("JVLmock_", StringComparison.Ordinal))
		{
			string text = name.Substring("JVLmock_".Length);
			string[] array = text.Split(new string[1] { "__" }, StringSplitOptions.RemoveEmptyEntries);
			assetName = array[0];
			childNames = (from splitName in array.Skip(1)
				select splitName.Trim()).ToList();
			return true;
		}
		if (name.StartsWith("VLmock_", StringComparison.Ordinal))
		{
			assetName = name.Substring("VLmock_".Length);
			childNames = new List<string>();
			return true;
		}
		assetName = name;
		childNames = new List<string>();
		return false;
	}

	private static string GetCleanedName(Type objectType, string name)
	{
		if (objectType == typeof(Material))
		{
			return name.RemoveSuffix("(Instance)");
		}
		if (objectType == typeof(Mesh))
		{
			return name.RemoveSuffix("Instance");
		}
		return name.Trim();
	}

	private static void FixMemberReferences(MemberBase member, object objectToFix, int depth)
	{
		if (member.MemberType == typeof(DropTable))
		{
			FixDropTable(member, objectToFix);
		}
		else if (member.IsUnityObject && member.HasGetMethod && member.HasSetMethod)
		{
			UnityEngine.Object obj = (UnityEngine.Object)member.GetValue(objectToFix);
			UnityEngine.Object realPrefabFromMock = GetRealPrefabFromMock(obj, member.MemberType);
			if ((bool)realPrefabFromMock)
			{
				member.SetValue(objectToFix, realPrefabFromMock);
			}
			else if (obj is Material material)
			{
				TryFixMaterial(material);
			}
		}
		else if (member.IsEnumeratedClass && member.IsEnumerableOfUnityObjects && member.HasSetMethod)
		{
			bool isArray = member.MemberType.IsArray;
			bool flag = member.MemberType.IsGenericType && member.MemberType.GetGenericTypeDefinition() == typeof(List<>);
			bool flag2 = member.MemberType.IsGenericType && member.MemberType.GetGenericTypeDefinition() == typeof(HashSet<>);
			bool flag3 = member.MemberType.IsGenericType && member.MemberType.GetGenericTypeDefinition() == typeof(Dictionary<, >);
			if (!(isArray || flag || flag2))
			{
				if (!flag3 || !(member.EnumeratedType == typeof(ParticleSystem)))
				{
					Logger.LogWarning($"Not fixing potential mock references for field {member.MemberType.Name} : {member.MemberType} is not supported.");
				}
				return;
			}
			IEnumerable<UnityEngine.Object> enumerable = (IEnumerable<UnityEngine.Object>)member.GetValue(objectToFix);
			if (enumerable == null)
			{
				return;
			}
			List<UnityEngine.Object> list = new List<UnityEngine.Object>();
			bool flag4 = false;
			foreach (UnityEngine.Object item in enumerable)
			{
				UnityEngine.Object realPrefabFromMock2 = GetRealPrefabFromMock(item, member.EnumeratedType);
				list.Add(realPrefabFromMock2 ? realPrefabFromMock2 : item);
				flag4 = flag4 || (bool)realPrefabFromMock2;
				if (!realPrefabFromMock2 && item is Material material2)
				{
					TryFixMaterial(material2);
				}
			}
			if (list.Count > 0 && flag4)
			{
				MethodInfo enumerableCast = ReflectionHelper.Cache.EnumerableCast;
				MethodInfo methodInfo = enumerableCast.MakeGenericMethod(member.EnumeratedType);
				object obj2 = methodInfo.Invoke(null, new object[1] { list });
				if (isArray)
				{
					MethodInfo enumerableToArray = ReflectionHelper.Cache.EnumerableToArray;
					MethodInfo methodInfo2 = enumerableToArray.MakeGenericMethod(member.EnumeratedType);
					object value = methodInfo2.Invoke(null, new object[1] { obj2 });
					member.SetValue(objectToFix, value);
				}
				else if (flag)
				{
					MethodInfo enumerableToList = ReflectionHelper.Cache.EnumerableToList;
					MethodInfo methodInfo3 = enumerableToList.MakeGenericMethod(member.EnumeratedType);
					object value2 = methodInfo3.Invoke(null, new object[1] { obj2 });
					member.SetValue(objectToFix, value2);
				}
				else if (flag2)
				{
					Type type = typeof(HashSet<>).MakeGenericType(member.EnumeratedType);
					object value3 = Activator.CreateInstance(type, obj2);
					member.SetValue(objectToFix, value3);
				}
			}
		}
		else
		{
			if (member.IsEnumeratedClass)
			{
				if (member.MemberType.IsGenericType && member.MemberType.GetGenericTypeDefinition() == typeof(Dictionary<, >))
				{
					Logger.LogWarning("Not fixing potential mock references for field " + member.MemberType.Name + " : Dictionary is not supported.");
					return;
				}
				IEnumerable<object> enumerable2 = (IEnumerable<object>)member.GetValue(objectToFix);
				if (enumerable2 == null)
				{
					return;
				}
				{
					foreach (object item2 in enumerable2)
					{
						FixReferences(item2, depth);
					}
					return;
				}
			}
			if (member.IsClass && member.HasGetMethod)
			{
				FixReferences(member.GetValue(objectToFix), depth);
			}
		}
	}

	private static void FixDropTable(MemberBase member, object objectToFix)
	{
		List<DropTable.DropData> drops = ((DropTable)member.GetValue(objectToFix)).m_drops;
		for (int i = 0; i < drops.Count; i++)
		{
			DropTable.DropData value = drops[i];
			GameObject realPrefabFromMock = GetRealPrefabFromMock<GameObject>(value.m_item);
			if ((bool)realPrefabFromMock)
			{
				value.m_item = realPrefabFromMock;
			}
			drops[i] = value;
		}
	}

	private static void TryFixMaterial(Material material)
	{
		if (!GUIUtils.IsHeadless && (bool)material && !fixedMaterials.Contains(material) && !queuedToFixMaterials.Contains(material))
		{
			FixMaterial(material);
		}
	}

	private static void FixQueuedMaterials()
	{
		MockResolveFailure.MockResolveFailures.Clear();
		PrefabManager.Cache.Clear<Texture>();
		allVanillaObjectsAvailable = true;
		foreach (Material item in new HashSet<Material>(queuedToFixMaterials))
		{
			queuedToFixMaterials.Remove(item);
			FixMaterial(item);
		}
		MockResolveFailure.PrintMockResolveFailures(string.Empty);
	}

	private static void FixMaterial(Material material)
	{
		if ((bool)material && !fixedMaterials.Contains(material))
		{
			bool flag = FixTextures(material);
			bool flag2 = true;
			if (!GUIUtils.IsHeadless)
			{
				flag2 = FixShader(material);
			}
			if (flag && flag2)
			{
				fixedMaterials.Add(material);
			}
			else
			{
				queuedToFixMaterials.Add(material);
			}
		}
	}

	/// <summary>
	///     Replaces all mock Textures with the real Texture
	/// </summary>
	/// <param name="material"></param>
	/// <returns>true if no mocks were found or all mock could be resolved</returns>
	private static bool FixTextures(Material material)
	{
		bool result = true;
		int count = MockResolveFailure.MockResolveFailures.Count;
		int[] texturePropertyNameIDs = material.GetTexturePropertyNameIDs();
		foreach (int nameID in texturePropertyNameIDs)
		{
			Texture texture = material.GetTexture(nameID);
			if ((bool)texture)
			{
				Texture realPrefabFromMock = GetRealPrefabFromMock<Texture>(texture);
				if (MockResolveFailure.MockResolveFailures.Count > count)
				{
					result = false;
					count = MockResolveFailure.MockResolveFailures.Count;
				}
				else if ((bool)realPrefabFromMock)
				{
					material.SetTexture(nameID, realPrefabFromMock);
				}
			}
		}
		return result;
	}

	/// <summary>
	///     Replaces a potential mock Shader with the real Shader
	/// </summary>
	/// <param name="material"></param>
	/// <returns>true if no mock was found or the mock could be resolved</returns>
	private static bool FixShader(Material material)
	{
		Shader shader = material.shader;
		if (!shader || !IsMockName(shader.name, out var assetName, out var _))
		{
			return true;
		}
		Shader prefab = PrefabManager.Cache.GetPrefab<Shader>(assetName);
		if ((bool)prefab)
		{
			material.shader = prefab;
			return true;
		}
		if (allVanillaObjectsAvailable)
		{
			Logger.LogWarning("Could not find shader " + shader.name);
		}
		return false;
	}
}
