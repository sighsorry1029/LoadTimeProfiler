using System;
using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace Jotunn.Utils;

/// <summary>
///     Util functions related to loading assets at runtime.
/// </summary>
public static class AssetUtils
{
	/// <summary>
	///     Path separator for AssetBundles
	/// </summary>
	public const char AssetBundlePathSeparator = '$';

	/// <summary>
	///     Method reference to <see cref="M:UnityEngine.ImageConversion.LoadImage(UnityEngine.Texture2D,System.Byte[])" />.
	///     Workaround for compiling a net 4.x mod against the nestandard 2.1 method reference.
	/// </summary>
	private static MethodInfo LoadImageMethod { get; } = AccessTools.Method(typeof(ImageConversion), "LoadImage", new Type[2]
	{
		typeof(Texture2D),
		typeof(byte[])
	});

	/// <summary>
	///     Loads a <see cref="T:UnityEngine.Texture2D" /> from file at runtime.
	/// </summary>
	/// <param name="texturePath">Texture path relative to "plugins" BepInEx folder</param>
	/// <param name="relativePath">Is the given path relative</param>
	/// <returns>Texture2D loaded, or null if invalid path</returns>
	public static Texture2D LoadTexture(string texturePath, bool relativePath = true)
	{
		string text = texturePath;
		if (relativePath)
		{
			text = Path.Combine(BepInEx.Paths.PluginPath, texturePath);
		}
		if (!File.Exists(text))
		{
			return null;
		}
		if (!text.EndsWith(".png") && !text.EndsWith(".jpg"))
		{
			throw new Exception("LoadTexture can only load png or jpg textures");
		}
		byte[] data = File.ReadAllBytes(text);
		return LoadImage(data);
	}

	/// <summary>
	///     Wrapper for https://docs.unity3d.com/ScriptReference/ImageConversion.LoadImage.html,
	///     creates a new <see cref="T:UnityEngine.Texture2D" />.
	/// </summary>
	/// <param name="data">The byte array containing the image data to load.</param>
	/// <returns>A new texture with the loaded image if the data can be loaded, null otherwise</returns>
	public static Texture2D LoadImage(byte[] data)
	{
		Texture2D texture2D = new Texture2D(2, 2);
		if (!LoadImage(texture2D, data))
		{
			return null;
		}
		return texture2D;
	}

	/// <summary>
	///     Wrapper for https://docs.unity3d.com/ScriptReference/ImageConversion.LoadImage.html.
	/// </summary>
	/// <param name="texture">The texture to load the image into.</param>
	/// <param name="data">The byte array containing the image data to load.</param>
	/// <returns>true if the data can be loaded, false otherwise</returns>
	public static bool LoadImage(Texture2D texture, byte[] data)
	{
		return (bool)LoadImageMethod.Invoke(null, new object[2] { texture, data });
	}

	/// <summary>
	///     Creates a readable copy of a rectangular region from a <see cref="T:UnityEngine.Texture2D" />.
	/// </summary>
	/// <param name="texture">Source texture.</param>
	/// <param name="textureRect">Region of the texture to copy.</param>
	/// <returns>A readable <see cref="T:UnityEngine.Texture2D" /> of the specified region, or null if the texture is null.</returns>
	public static Texture2D DuplicateTexture(Texture2D texture, Rect textureRect)
	{
		if (!texture)
		{
			return null;
		}
		int num = (int)textureRect.width;
		int num2 = (int)textureRect.height;
		int num3 = (int)textureRect.x;
		int num4 = (int)textureRect.y;
		RenderTexture active = RenderTexture.active;
		RenderTexture temporary = RenderTexture.GetTemporary(texture.width, texture.height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.sRGB);
		Graphics.Blit(texture, temporary);
		RenderTexture.active = temporary;
		Texture2D texture2D = new Texture2D(num, num2);
		texture2D.ReadPixels(new Rect(num3, num4, num, num2), 0, 0);
		texture2D.Apply();
		RenderTexture.active = active;
		RenderTexture.ReleaseTemporary(temporary);
		return texture2D;
	}

	/// <summary>
	///     Creates a readable copy of a <see cref="T:UnityEngine.Texture2D" />.
	/// </summary>
	/// <param name="texture">Source texture.</param>
	/// <returns>A readable copy of the texture, or null if the texture is null.</returns>
	public static Texture2D DuplicateTexture(Texture2D texture)
	{
		return DuplicateTexture(texture, new Rect(0f, 0f, texture.width, texture.height));
	}

	/// <summary>
	///     Creates a readable copy of a <see cref="T:UnityEngine.Sprite" />'s texture region.
	///     If the sprite is part of an atlas, only its texture rectangle is copied.<br />
	///     Use <c>AssetUtils.DuplicateTexture(sprite.texture)</c> to copy the full texture.
	/// </summary>
	/// <param name="sprite">Source sprite.</param>
	/// <returns>A readable <see cref="T:UnityEngine.Texture2D" /> of the sprite’s texture region, or null if the texture is null.</returns>
	public static Texture2D DuplicateTexture(Sprite sprite)
	{
		return DuplicateTexture(sprite.texture, sprite.textureRect);
	}

	/// <summary>
	///     Creates a readable copy of a <see cref="T:UnityEngine.Sprite" />.
	/// </summary>
	/// <param name="sprite">Source sprite.</param>
	/// <returns>A new <see cref="T:UnityEngine.Sprite" /> with a readable copy of its texture region, or null if the texture is null.</returns>
	public static Sprite DuplicateSprite(Sprite sprite)
	{
		Texture2D texture2D = DuplicateTexture(sprite);
		if (!texture2D)
		{
			return null;
		}
		return Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
	}

	/// <summary>
	///     Loads a <see cref="T:UnityEngine.Sprite" /> from file at runtime.
	/// </summary>
	/// <param name="spritePath">Texture path relative to "plugins" BepInEx folder</param>
	/// <returns>Texture2D loaded, or null if invalid path</returns>
	public static Sprite LoadSpriteFromFile(string spritePath)
	{
		return LoadSpriteFromFile(spritePath, Vector2.zero);
	}

	/// <summary>
	///     Loads a <see cref="T:UnityEngine.Sprite" /> from file at runtime.
	/// </summary>
	/// <param name="spritePath">Texture path relative to "plugins" BepInEx folder</param>
	/// <param name="pivot">The pivot to use in the resulting Sprite</param>
	/// <returns>Texture2D loaded, or null if invalid path</returns>
	public static Sprite LoadSpriteFromFile(string spritePath, Vector2 pivot)
	{
		Texture2D texture2D = LoadTexture(spritePath);
		if (texture2D != null)
		{
			return Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), pivot);
		}
		return null;
	}

	/// <summary>
	///     Loads a mesh from a .obj file at runtime.
	/// </summary>
	/// <param name="meshPath">Mesh path relative to "plugins" BepInEx folder</param>
	/// <returns>Texture2D loaded, or null if invalid path</returns>
	public static Mesh LoadMesh(string meshPath)
	{
		string text = Path.Combine(BepInEx.Paths.PluginPath, meshPath);
		if (!File.Exists(text))
		{
			return null;
		}
		return ObjImporter.ImportFile(text);
	}

	/// <summary>
	///     Loads an asset bundle at runtime.
	/// </summary>
	/// <param name="bundlePath">Asset bundle path relative to "plugins" BepInEx folder</param>
	/// <returns>AssetBundle loaded, or null if invalid path</returns>
	public static AssetBundle LoadAssetBundle(string bundlePath)
	{
		string text = Path.Combine(BepInEx.Paths.PluginPath, bundlePath);
		if (!File.Exists(text))
		{
			return null;
		}
		return AssetBundle.LoadFromFile(text);
	}

	/// <summary>
	///     Load an assembly-embedded <see cref="T:UnityEngine.AssetBundle" />. Use this if the automatic detection of the assembly fails.
	/// </summary>
	/// <param name="bundleName">Name of the bundle. Folders are point-seperated e.g. folder/bundle becomes folder.bundle</param>
	/// <param name="resourceAssembly">Executing assembly</param>
	/// <returns></returns>
	public static AssetBundle LoadAssetBundleFromResources(string bundleName, Assembly resourceAssembly)
	{
		if (resourceAssembly == null)
		{
			throw new ArgumentNullException("Parameter resourceAssembly can not be null.");
		}
		string text = null;
		try
		{
			text = resourceAssembly.GetManifestResourceNames().Single((string str) => str.EndsWith(bundleName));
		}
		catch (Exception)
		{
		}
		if (text == null)
		{
			Logger.LogError("AssetBundle " + bundleName + " not found in assembly manifest");
			return null;
		}
		using Stream stream = resourceAssembly.GetManifestResourceStream(text);
		return AssetBundle.LoadFromStream(stream);
	}

	/// <summary>
	///     Load an assembly-embedded <see cref="T:UnityEngine.AssetBundle" />. The calling assembly is automatically detected.
	/// </summary>
	/// <param name="bundleName">Name of the bundle. Folders are point-seperated e.g. folder/bundle becomes folder.bundle</param>
	/// <returns></returns>
	public static AssetBundle LoadAssetBundleFromResources(string bundleName)
	{
		return LoadAssetBundleFromResources(bundleName, ReflectionHelper.GetCallingAssembly());
	}

	/// <summary>
	///     Load an assembly-embedded file as a <see cref="T:System.String" />. Use this if the automatic detection of the assembly fails.
	/// </summary>
	/// <param name="fileName">Name of the file. Folders are point-seperated e.g. folder/file.json becomes folder.file.json</param>
	/// <param name="resourceAssembly">Executing assembly</param>
	/// <returns></returns>
	public static string LoadTextFromResources(string fileName, Assembly resourceAssembly)
	{
		if (resourceAssembly == null)
		{
			throw new ArgumentNullException("Parameter resourceAssembly can not be null.");
		}
		string text = null;
		try
		{
			text = resourceAssembly.GetManifestResourceNames().Single((string str) => str.EndsWith(fileName));
		}
		catch (Exception)
		{
		}
		if (text == null)
		{
			Logger.LogError("File " + fileName + " not found in assembly manifest");
			return null;
		}
		using Stream stream = resourceAssembly.GetManifestResourceStream(text);
		using StreamReader streamReader = new StreamReader(stream);
		return streamReader.ReadToEnd();
	}

	/// <summary>
	///     Load an assembly-embedded file as a <see cref="T:System.String" />. The calling assembly is automatically detected.
	/// </summary>
	/// <param name="fileName">Name of the file. Folders are point-seperated e.g. folder/file.json becomes folder.file.json</param>
	/// <returns></returns>
	public static string LoadTextFromResources(string fileName)
	{
		return LoadTextFromResources(fileName, ReflectionHelper.GetCallingAssembly());
	}

	/// <summary>
	///     Loads the contents of a file as a char string
	/// </summary>
	/// <param name="path"></param>
	/// <returns></returns>
	public static string LoadText(string path)
	{
		string text = Path.Combine(BepInEx.Paths.PluginPath, path);
		if (!File.Exists(text))
		{
			Logger.LogError("Error, failed to load contents from non-existant path: $" + text);
			return null;
		}
		return File.ReadAllText(text);
	}

	/// <summary>
	///     Loads a <see cref="T:UnityEngine.Sprite" /> from a file path or an asset bundle (separated by <see cref="F:Jotunn.Utils.AssetUtils.AssetBundlePathSeparator" />)
	/// </summary>
	/// <param name="assetPath"></param>
	/// <returns></returns>
	public static Sprite LoadSprite(string assetPath)
	{
		string text = Path.Combine(BepInEx.Paths.PluginPath, assetPath);
		if (!File.Exists(text))
		{
			return null;
		}
		if (text.Contains('$'.ToString()))
		{
			string[] array = text.Split('$');
			string text2 = array[0];
			string text3 = array[1];
			AssetBundle val = AssetBundle.LoadFromFile(text2);
			Sprite result = val.LoadAsset<Sprite>(text3);
			val.Unload(false);
			return result;
		}
		Texture2D texture2D = LoadTexture(text, relativePath: false);
		if (!texture2D)
		{
			return null;
		}
		return Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), Vector2.zero);
	}

	internal static bool TryLoadPrefab(BepInPlugin sourceMod, AssetBundle assetBundle, string assetName, out GameObject prefab)
	{
		try
		{
			prefab = assetBundle.LoadAsset<GameObject>(assetName);
		}
		catch (Exception arg)
		{
			prefab = null;
			Logger.LogError(sourceMod, $"Failed to load prefab '{assetName}' from AssetBundle {assetBundle}:\n{arg}");
			return false;
		}
		if (!prefab)
		{
			Logger.LogError(sourceMod, $"Failed to load prefab '{assetName}' from AssetBundle {assetBundle}");
			return false;
		}
		return true;
	}
}
