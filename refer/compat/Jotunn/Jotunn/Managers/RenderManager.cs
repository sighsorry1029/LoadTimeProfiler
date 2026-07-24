using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx;
using Jotunn.Utils;
using UnityEngine;

namespace Jotunn.Managers;

/// <summary>
///     Manager for rendering <see cref="T:UnityEngine.Sprite">Sprites</see> of <see cref="T:UnityEngine.GameObject">GameObjects</see>
/// </summary>
public class RenderManager : IManager
{
	private class RenderObject
	{
		public readonly GameObject Spawn;

		public readonly Vector3 Size;

		public RenderRequest Request;

		public RenderObject(GameObject spawn, Vector3 size)
		{
			Spawn = spawn;
			Size = size;
		}
	}

	/// <summary>
	///     Wrapper to create and set a short-lived RenderTexture to a Camera, which is cleaned up afterwards
	/// </summary>
	private class CreateTemporaryRenderTexture : IDisposable
	{
		private readonly Camera camera;

		private readonly RenderTexture previousRenderTexture;

		private readonly RenderTexture temporaryRenderTexture;

		public CreateTemporaryRenderTexture(Camera camera, int textureWidth, int textureHeight)
		{
			this.camera = camera;
			previousRenderTexture = RenderTexture.active;
			temporaryRenderTexture = RenderTexture.GetTemporary(textureWidth, textureHeight);
			camera.targetTexture = temporaryRenderTexture;
			RenderTexture.active = temporaryRenderTexture;
		}

		public void Dispose()
		{
			RenderTexture.active = previousRenderTexture;
			camera.targetTexture = null;
			RenderTexture.ReleaseTemporary(temporaryRenderTexture);
		}
	}

	/// <summary>
	///     Queues a new prefab to be rendered. The resulting <see cref="T:UnityEngine.Sprite" /> will be ready at the next frame. 
	/// </summary>
	/// <returns>Only true if the target was queued for rendering</returns>
	public class RenderRequest
	{
		/// <summary>
		///     Target GameObject to create a <see cref="T:UnityEngine.Sprite" /> from
		/// </summary>
		public readonly GameObject Target;

		/// <summary>
		///     Pixel width of the generated <see cref="T:UnityEngine.Sprite" />
		/// </summary>
		public int Width { get; set; } = 128;

		/// <summary>
		///     Pixel height of the generated <see cref="T:UnityEngine.Sprite" />
		/// </summary>
		public int Height { get; set; } = 128;

		/// <summary>
		///     Rotation of the prefab to capture
		/// </summary>
		public Quaternion Rotation { get; set; } = Quaternion.identity;

		/// <summary>
		///     Field of view of the camera used to create the <see cref="T:UnityEngine.Sprite" />. Default is small to simulate orthographic view. An orthographic camera is not possible because of shaders
		/// </summary>
		public float FieldOfView { get; set; } = 0.5f;

		/// <summary>
		///     Distance multiplier, should not be required with the default <see cref="P:Jotunn.Managers.RenderManager.RenderRequest.FieldOfView" />
		/// </summary>
		public float DistanceMultiplier { get; set; } = 1f;

		/// <summary>
		///     Callback for the generated <see cref="T:UnityEngine.Sprite" />
		/// </summary>
		[Obsolete]
		public Action<Sprite> Callback { get; internal set; }

		/// <summary>
		///     Optional, Used for <see cref="P:Jotunn.Managers.RenderManager.RenderRequest.UseCache" /> to determine a unique name-version combination
		/// </summary>
		public BepInPlugin TargetPlugin { get; set; }

		/// <summary>
		///     Save the render on the disc and reuse when called again. This reduces the time to re-render drastically.
		///     When the game version changes, a new render will be made. When a <see cref="P:Jotunn.Managers.RenderManager.RenderRequest.TargetPlugin" /> is set, the version and name
		///     will be used to determine if a new render should be made
		/// </summary>
		public bool UseCache { get; set; }

		/// <summary>
		///     Simulates the particle effects for this amount of seconds. Less than 0 for no particles.
		/// </summary>
		public float ParticleSimulationTime { get; set; } = 5f;

		/// <summary>
		///     Create a new RenderRequest
		/// </summary>
		/// <param name="target">Object to be rendered. A copy of the provided GameObject will be created for rendering</param> 
		public RenderRequest(GameObject target)
		{
			Target = target;
		}
	}

	/// <summary>
	///     Rotation of the prefab that will result in an isometric view
	/// </summary>
	public static readonly Quaternion IsometricRotation;

	private static RenderManager _instance;

	/// <summary>
	///     Appended string to file names to force a cache recreation, if changed
	/// </summary>
	private static string cacheRevision;

	private static Dictionary<Type, List<Type>> componentDependencies;

	/// <summary>
	///     Arbitrary unused Layer in the game
	/// </summary>
	private const int Layer = 31;

	private Camera Renderer;

	private Light Light;

	private Sprite EmptySprite { get; } = Sprite.Create(Texture2D.whiteTexture, Rect.zero, Vector2.one);

	/// <summary>
	///     Singleton instance
	/// </summary>
	public static RenderManager Instance => _instance ?? (_instance = new RenderManager());

	/// <summary>
	///     Hide .ctor
	/// </summary>
	private RenderManager()
	{
	}

	static RenderManager()
	{
		IsometricRotation = Quaternion.Euler(23f, 51f, 25.8f);
		cacheRevision = "c1";
		componentDependencies = new Dictionary<Type, List<Type>>();
		((IManager)Instance).Init();
	}

	/// <summary>
	///     Initialize the manager
	/// </summary>
	void IManager.Init()
	{
		Main.LogInit("RenderManager");
		if (!GUIUtils.IsHeadless)
		{
			Main.Instance.StartCoroutine(ClearRenderRoutine());
		}
	}

	/// <summary>
	///     Create a <see cref="T:UnityEngine.Sprite" /> of the <paramref name="target" />
	/// </summary>
	/// <param name="target">GameObject to render</param>
	/// <param name="callback">Callback for the generated <see cref="T:UnityEngine.Sprite" /></param>
	/// <returns>If no active visual component is attached to the target or any child, this method invokes the callback with null immediately and returns false.</returns>
	[Obsolete("Use Render instead")]
	public bool EnqueueRender(GameObject target, Action<Sprite> callback)
	{
		return EnqueueRender(new RenderRequest(target), callback);
	}

	/// <summary>
	///     Enqueue a render of the <see cref="T:Jotunn.Managers.RenderManager.RenderRequest" />
	/// </summary>
	/// <param name="renderRequest"></param>
	/// <param name="callback">Callback for the generated <see cref="T:UnityEngine.Sprite" /></param>
	/// <returns>If no active visual component is attached to the target or any child, this method invokes the callback with null immediately and returns false.</returns>
	[Obsolete("Use Render instead")]
	public bool EnqueueRender(RenderRequest renderRequest, Action<Sprite> callback)
	{
		if (!renderRequest.Target)
		{
			throw new ArgumentException("Target is required");
		}
		if (callback == null)
		{
			throw new ArgumentException("Callback is required");
		}
		if (!renderRequest.Target.GetComponentsInChildren<Component>(includeInactive: false).Any(IsVisualComponent))
		{
			callback(null);
			return false;
		}
		renderRequest.Callback = callback;
		callback?.Invoke(Render(renderRequest));
		return true;
	}

	/// <summary>
	///     Queues a new prefab to be rendered. The resulting <see cref="T:UnityEngine.Sprite" /> will be ready at the next frame.
	///     If there is no active visual Mesh attached to the target, this method invokes the callback with null immediately.
	/// </summary>
	/// <param name="target">Object to be rendered. A copy of the provided GameObject will be created for rendering</param>
	/// <param name="callback">Action that gets called when the rendering is complete</param>
	/// <param name="width">Width of the resulting <see cref="T:UnityEngine.Sprite" /></param>
	/// <param name="height">Height of the resulting <see cref="T:UnityEngine.Sprite" /></param>
	/// <returns>Only true if the target was queued for rendering</returns>
	[Obsolete("Use Render instead")]
	public bool EnqueueRender(GameObject target, Action<Sprite> callback, int width = 128, int height = 128)
	{
		return EnqueueRender(new RenderRequest(target)
		{
			Width = width,
			Height = height
		}, callback);
	}

	/// <summary>
	///     Create a <see cref="T:UnityEngine.Sprite" /> of the <paramref name="target" />
	/// </summary>
	/// <param name="target">Can be a prefab or any existing GameObject in the world</param>
	/// <returns>If no active visual component is attached to the target or any child, this method returns null.</returns>
	public Sprite Render(GameObject target)
	{
		return Render(new RenderRequest(target));
	}

	/// <summary>
	///     Create a <see cref="T:UnityEngine.Sprite" /> of the <paramref name="target" />
	/// </summary>
	/// <param name="target">Can be a prefab or any existing GameObject in the world</param>
	/// <param name="rotation">Rotation while rendering of the GameObject. See <code>RenderManager.IsometricRotation</code> for example/&gt;</param>
	/// <returns>If no active visual component is attached to the target or any child, this method returns null.</returns>
	public Sprite Render(GameObject target, Quaternion rotation)
	{
		return Render(new RenderRequest(target)
		{
			Rotation = rotation
		});
	}

	/// <summary>
	///     Create a <see cref="T:UnityEngine.Sprite" /> from a <see cref="T:Jotunn.Managers.RenderManager.RenderRequest" />/&gt;
	/// </summary>
	/// <param name="renderRequest"></param>
	/// <returns>If no active visual component is attached to the target or any child, this method returns null.</returns>
	public Sprite Render(RenderRequest renderRequest)
	{
		if (!renderRequest.Target)
		{
			throw new ArgumentException("Target is required");
		}
		if (!renderRequest.Target.GetComponentsInChildren<Component>(includeInactive: false).Any(IsVisualComponent))
		{
			return null;
		}
		if (GUIUtils.IsHeadless)
		{
			return EmptySprite;
		}
		if (renderRequest.UseCache && ContainsIconCache(renderRequest.Target, renderRequest.TargetPlugin, out var sprite))
		{
			return sprite;
		}
		if (!Renderer)
		{
			SetupRendering();
		}
		RenderObject renderObject = SpawnRenderClone(renderRequest);
		if (renderObject == null)
		{
			return null;
		}
		Sprite sprite2 = RenderSprite(renderObject);
		if (renderRequest.UseCache)
		{
			CacheIcon(renderRequest.Target, renderRequest.TargetPlugin, sprite2);
		}
		return sprite2;
	}

	private bool ContainsIconCache(GameObject target, BepInPlugin plugin, out Sprite sprite)
	{
		string version = GetVersion(plugin);
		string cachePath = GetCachePath(target.name, version);
		if (!File.Exists(cachePath))
		{
			sprite = null;
			return false;
		}
		byte[] data = File.ReadAllBytes(cachePath);
		Texture2D texture2D = AssetUtils.LoadImage(data);
		sprite = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), Vector2.one / 2f);
		return true;
	}

	private void CacheIcon(GameObject target, BepInPlugin plugin, Sprite rendered)
	{
		string version = GetVersion(plugin);
		Directory.CreateDirectory(Jotunn.Utils.Paths.IconCachePath);
		File.WriteAllBytes(GetCachePath(target.name, version), ImageConversion.EncodeToPNG(rendered.texture));
	}

	private string GetCachePath(string name, string version)
	{
		return Path.Combine(Jotunn.Utils.Paths.IconCachePath, name + "-" + version + "-" + cacheRevision + ".png");
	}

	private string GetVersion(BepInPlugin plugin)
	{
		if (plugin != null)
		{
			return plugin.GUID + "-" + plugin.Version;
		}
		return GameVersions.ValheimVersion.ToString();
	}

	private Sprite RenderSprite(RenderObject renderObject)
	{
		int width = renderObject.Request.Width;
		int height = renderObject.Request.Height;
		using (new CreateTemporaryRenderTexture(Renderer, width, height))
		{
			Renderer.fieldOfView = renderObject.Request.FieldOfView;
			renderObject.Spawn.SetActive(value: true);
			float num = Mathf.Max(renderObject.Size.x, renderObject.Size.y) + 0.1f;
			float z = num / Mathf.Tan(Renderer.fieldOfView * ((float)Math.PI / 180f)) * renderObject.Request.DistanceMultiplier;
			Renderer.transform.position = new Vector3(0f, 0f, z);
			Renderer.Render();
			renderObject.Spawn.SetActive(value: false);
			UnityEngine.Object.Destroy(renderObject.Spawn);
			Texture2D texture2D = new Texture2D(width, height, TextureFormat.RGBA32, mipChain: false);
			texture2D.ReadPixels(new Rect(0f, 0f, width, height), 0, 0);
			texture2D.Apply();
			return Sprite.Create(texture2D, new Rect(0f, 0f, width, height), Vector2.one / 2f);
		}
	}

	private IEnumerator ClearRenderRoutine()
	{
		while (true)
		{
			if ((bool)Renderer)
			{
				ClearRendering();
			}
			yield return null;
		}
	}

	private void SetupRendering()
	{
		Renderer = new GameObject("Render Camera", typeof(Camera)).GetComponent<Camera>();
		Renderer.backgroundColor = new Color(0f, 0f, 0f, 0f);
		Renderer.clearFlags = CameraClearFlags.Color;
		Renderer.transform.position = Vector3.zero;
		Renderer.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
		Renderer.fieldOfView = 0.5f;
		Renderer.farClipPlane = 100000f;
		Renderer.cullingMask = int.MinValue;
		Light = new GameObject("Render Light", typeof(Light)).GetComponent<Light>();
		Light.transform.position = Vector3.zero;
		Light.transform.rotation = Quaternion.Euler(5f, 180f, 5f);
		Light.type = LightType.Directional;
		Light.cullingMask = int.MinValue;
	}

	private void ClearRendering()
	{
		UnityEngine.Object.Destroy(Renderer.gameObject);
		UnityEngine.Object.Destroy(Light.gameObject);
	}

	private static bool IsVisualComponent(Component component)
	{
		if (!(component is Renderer))
		{
			return component is MeshFilter;
		}
		return true;
	}

	private static bool IsRenderComponent(Component component)
	{
		if (!(component is MeshRenderer) && !(component is SkinnedMeshRenderer) && !(component is MeshFilter))
		{
			return component is Transform;
		}
		return true;
	}

	private static bool IsParticleComponent(Component component)
	{
		if (!(component is ParticleSystemRenderer))
		{
			return component is ParticleSystem;
		}
		return true;
	}

	/// <summary>
	///     Spawn a prefab without any Components except visuals. Also prevents calling Awake methods of the prefab.
	/// </summary>
	/// <param name="request"></param>
	/// <returns></returns>
	private static RenderObject SpawnRenderClone(RenderRequest request)
	{
		GameObject gameObject = new GameObject();
		gameObject.SetActive(value: false);
		GameObject gameObject2 = UnityEngine.Object.Instantiate(request.Target, gameObject.transform);
		if (!RecursivelyRemoveComponents(gameObject.transform, request))
		{
			Logger.LogWarning($"Sprite could not be rendered for {request.Target} due to components not being removed.");
			return null;
		}
		SetLayerRecursive(gameObject2);
		gameObject2.transform.SetParent(null);
		UnityEngine.Object.DestroyImmediate(gameObject);
		gameObject2.transform.position = Vector3.zero;
		gameObject2.transform.rotation = request.Rotation;
		gameObject2.name = request.Target.name;
		Vector3 vector = new Vector3(1000f, 1000f, 1000f);
		Vector3 vector2 = new Vector3(-1000f, -1000f, -1000f);
		Renderer[] componentsInChildren = gameObject2.GetComponentsInChildren<Renderer>();
		foreach (Renderer renderer in componentsInChildren)
		{
			if (renderer is MeshRenderer || renderer is SkinnedMeshRenderer)
			{
				vector = Vector3.Min(vector, renderer.bounds.min);
				vector2 = Vector3.Max(vector2, renderer.bounds.max);
			}
		}
		gameObject2.transform.position = -(vector + vector2) / 2f;
		Vector3 size = new Vector3(Mathf.Abs(vector.x) + Mathf.Abs(vector2.x), Mathf.Abs(vector.y) + Mathf.Abs(vector2.y), Mathf.Abs(vector.z) + Mathf.Abs(vector2.z));
		ParticleSystem[] componentsInChildren2 = gameObject2.GetComponentsInChildren<ParticleSystem>(includeInactive: true);
		foreach (ParticleSystem val in componentsInChildren2)
		{
			val.Simulate(request.ParticleSimulationTime);
		}
		TimedDestruction timedDestruction = gameObject2.AddComponent<TimedDestruction>();
		timedDestruction.Trigger(1f);
		return new RenderObject(gameObject2, size)
		{
			Request = request
		};
	}

	/// <summary>
	///     Recursively remove all components not needed for rendering in order of their dependencies.
	/// </summary>
	/// <param name="parentTransform"></param>
	/// <param name="request"></param>
	/// <returns>false if components could not be removed, true otherwise</returns>
	private static bool RecursivelyRemoveComponents(Transform parentTransform, RenderRequest request)
	{
		GameObject gameObject = parentTransform.gameObject;
		for (int i = 0; i < parentTransform.childCount; i++)
		{
			RecursivelyRemoveComponents(parentTransform.GetChild(i), request);
		}
		List<Type> topolocialSort = GetTopolocialSort(parentTransform);
		if (topolocialSort == null)
		{
			return false;
		}
		foreach (Type item in topolocialSort)
		{
			Component[] components = gameObject.GetComponents(item);
			foreach (Component component in components)
			{
				if (!IsRenderComponent(component) && (!(request.ParticleSimulationTime >= 0f) || !IsParticleComponent(component)))
				{
					try
					{
						UnityEngine.Object.DestroyImmediate(component);
					}
					catch (Exception ex)
					{
						Logger.LogError($"Component {component} could not be removed. Exception caught: {ex.Message}");
						return false;
					}
				}
			}
		}
		return true;
	}

	/// <summary>
	///     Topological sort (regarding dependencies between components) of all components of this transforms gameobject
	/// </summary>
	/// <param name="tranform"></param>
	/// <returns>A topologically sorted list of types. Null if cycles have been detected.</returns>
	private static List<Type> GetTopolocialSort(Transform tranform)
	{
		List<Type> list = new List<Type>();
		HashSet<Type> visited = new HashSet<Type>();
		HashSet<Type> recursionStack = new HashSet<Type>();
		if (!tranform || !tranform.gameObject)
		{
			return list;
		}
		Component[] components = tranform.gameObject.GetComponents<Component>();
		foreach (Component component in components)
		{
			if ((bool)component && !TopologicalSortUtil(component.GetType(), visited, recursionStack, list))
			{
				Logger.LogWarning($"Cycles detected in component dependencies for type {component.GetType()}. Unable to determine deletion order for {tranform}.");
				return null;
			}
		}
		list.Reverse();
		return list;
	}

	private static bool TopologicalSortUtil(Type node, HashSet<Type> visited, HashSet<Type> recursionStack, List<Type> result)
	{
		if (visited.Contains(node))
		{
			return true;
		}
		List<Type> list = null;
		int num = result.FindIndex(node.IsSubclassOf);
		if (num != -1)
		{
			list = result.Skip(num).ToList();
			result.RemoveRange(num, result.Count - num);
		}
		if (recursionStack.Contains(node))
		{
			return false;
		}
		recursionStack.Add(node);
		List<Type> list2 = GetComponentDependencies(node);
		foreach (Type item in list2)
		{
			if (!TopologicalSortUtil(item, visited, recursionStack, result))
			{
				return false;
			}
		}
		if (list != null)
		{
			result.AddRange(list);
		}
		else
		{
			result.Add(node);
		}
		recursionStack.Remove(node);
		visited.Add(node);
		return true;
	}

	private static List<Type> GetComponentDependencies(Type node)
	{
		if (!componentDependencies.TryGetValue(node, out var value))
		{
			value = new List<Type>();
			foreach (RequireComponent customAttribute in node.GetCustomAttributes<RequireComponent>(inherit: true))
			{
				value.Add(customAttribute.m_Type0);
				value.Add(customAttribute.m_Type1);
				value.Add(customAttribute.m_Type2);
			}
			value = value.Where((Type t) => t != null).Distinct().ToList();
			componentDependencies[node] = value;
		}
		return value;
	}

	private static void SetLayerRecursive(GameObject root)
	{
		root.layer = 31;
		foreach (Transform item in root.transform)
		{
			SetLayerRecursive(item.gameObject);
		}
	}
}
