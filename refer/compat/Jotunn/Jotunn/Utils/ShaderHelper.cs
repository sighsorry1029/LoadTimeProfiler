using System;
using System.Collections.Generic;
using UnityEngine;

namespace Jotunn.Utils;

/// <summary>
///     Various static utility methods for working with Shaders
/// </summary>
public static class ShaderHelper
{
	/// <summary>
	///     Get a list of all <see cref="T:UnityEngine.MeshRenderer" /> and <see cref="T:UnityEngine.SkinnedMeshRenderer" /> in this GameObject and its childs.
	/// </summary>
	/// <param name="gameObject">Parent GameObject</param>
	/// <returns>List of <see cref="T:UnityEngine.MeshRenderer" /> and <see cref="T:UnityEngine.SkinnedMeshRenderer" /></returns>
	public static List<Renderer> GetRenderers(GameObject gameObject)
	{
		List<Renderer> list = new List<Renderer>();
		list.AddRange(gameObject.GetComponentsInChildren<MeshRenderer>(includeInactive: true));
		list.AddRange(gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true));
		return list;
	}

	/// <summary>
	///     Get a list of all renderer <see cref="T:UnityEngine.Material" /> of a GameObject and its childs
	/// </summary>
	/// <param name="gameObject">Parent GameObject</param>
	/// <returns>List of <see cref="T:UnityEngine.Material" /></returns>
	public static List<Material> GetRendererMaterials(GameObject gameObject)
	{
		List<Material> list = new List<Material>();
		foreach (Renderer renderer in GetRenderers(gameObject))
		{
			list.AddRange(renderer.materials);
		}
		return list;
	}

	/// <summary>
	///     Get a list of all shared renderer <see cref="T:UnityEngine.Material" /> of a GameObject and its childs
	/// </summary>
	/// <param name="gameObject">Parent GameObject</param>
	/// <returns>List of <see cref="T:UnityEngine.Material" /></returns>
	public static List<Material> GetRendererSharedMaterials(GameObject gameObject)
	{
		List<Material> list = new List<Material>();
		foreach (Renderer renderer in GetRenderers(gameObject))
		{
			list.AddRange(renderer.sharedMaterials);
		}
		return list;
	}

	/// <summary>
	///     Get a list of all normal and shared renderer <see cref="T:UnityEngine.Material" /> of a GameObject and its childs
	/// </summary>
	/// <param name="gameObject">Parent GameObject</param>
	/// <returns>List of <see cref="T:UnityEngine.Material" /></returns>
	public static List<Material> GetAllRendererMaterials(GameObject gameObject)
	{
		List<Material> list = new List<Material>();
		foreach (Renderer renderer in GetRenderers(gameObject))
		{
			list.AddRange(renderer.materials);
			list.AddRange(renderer.sharedMaterials);
		}
		return list;
	}

	/// <summary>
	///     Create a new, scaled texture from a given texture.
	/// </summary>
	/// <param name="texture">Source texture to scale</param>
	/// <param name="width">New width of the scaled texture</param>
	/// <returns></returns>
	public static Texture2D CreateScaledTexture(Texture2D texture, int width)
	{
		Texture2D texture2D = new Texture2D(texture.width, texture.height, texture.format, mipChain: false);
		texture2D.SetPixels(texture.GetPixels());
		texture2D.Apply();
		ScaleTexture(texture2D, width);
		return texture2D;
	}

	/// <summary>
	///     Scale a texture to a certain width, aspect ratio is preserved.
	/// </summary>
	/// <param name="texture">Texture to scale</param>
	/// <param name="width">New width of the scaled texture</param>
	public static void ScaleTexture(Texture2D texture, int width)
	{
		Texture2D texture2D = new Texture2D(texture.width, texture.height, texture.format, mipChain: false);
		texture2D.SetPixels(texture.GetPixels());
		texture2D.Apply();
		int num = (int)Math.Round((float)width * (float)texture.height / (float)texture.width);
		texture.Reinitialize(width, num);
		texture.Apply();
		Color[] pixels = texture.GetPixels(0);
		float num2 = 1f / (float)width;
		float num3 = 1f / (float)num;
		for (int i = 0; i < pixels.Length; i++)
		{
			pixels[i] = texture2D.GetPixelBilinear(num2 * ((float)i % (float)width), num3 * Mathf.Floor((float)i / (float)width));
		}
		texture.SetPixels(pixels, 0);
		texture.Apply();
		UnityEngine.Object.Destroy(texture2D);
	}

	/// <summary>
	///     Dumps all shader information of a GameObject and its childs onto debug log
	/// </summary>
	/// <param name="gameObject"></param>
	public static void ShaderDump(GameObject gameObject)
	{
		List<Material> rendererMaterials = GetRendererMaterials(gameObject);
		foreach (Material item in rendererMaterials)
		{
			Logger.LogDebug(item.shader.ToString());
			string[] shaderKeywords = item.shaderKeywords;
			foreach (string data in shaderKeywords)
			{
				Logger.LogDebug(data);
			}
			string[] texturePropertyNames = item.GetTexturePropertyNames();
			foreach (string data2 in texturePropertyNames)
			{
				Logger.LogDebug(data2);
			}
			for (int k = 0; k < item.shader.GetPropertyCount(); k++)
			{
				Logger.LogDebug(item.shader.GetPropertyName(k));
			}
		}
	}
}
