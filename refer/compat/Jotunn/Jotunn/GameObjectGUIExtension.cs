using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Jotunn;

/// <summary>
///     Use only, if you know what you do.
///     There are no checks if a component exists.
/// </summary>
internal static class GameObjectGUIExtension
{
	internal static GameObject SetToTextHeight(this GameObject go)
	{
		go.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, go.GetComponentInChildren<Text>().preferredHeight + 3f);
		return go;
	}

	internal static GameObject SetUpperLeft(this GameObject go)
	{
		RectTransform component = go.GetComponent<RectTransform>();
		component.anchorMax = new Vector2(0f, 1f);
		component.anchorMin = new Vector2(0f, 1f);
		component.pivot = new Vector2(0f, 1f);
		component.anchoredPosition = new Vector2(0f, 0f);
		return go;
	}

	internal static GameObject SetMiddleLeft(this GameObject go)
	{
		RectTransform component = go.GetComponent<RectTransform>();
		component.anchorMax = new Vector2(0f, 0.5f);
		component.anchorMin = new Vector2(0f, 0.5f);
		component.pivot = new Vector2(0f, 0.5f);
		component.anchoredPosition = new Vector2(0f, 0f);
		return go;
	}

	internal static GameObject SetBottomLeft(this GameObject go)
	{
		RectTransform component = go.GetComponent<RectTransform>();
		component.anchorMax = new Vector2(0f, 0f);
		component.anchorMin = new Vector2(0f, 0f);
		component.pivot = new Vector2(0f, 0f);
		component.anchoredPosition = new Vector2(0f, 0f);
		return go;
	}

	internal static GameObject SetUpperRight(this GameObject go)
	{
		RectTransform component = go.GetComponent<RectTransform>();
		component.anchorMax = new Vector2(1f, 1f);
		component.anchorMin = new Vector2(1f, 1f);
		component.pivot = new Vector2(1f, 1f);
		component.anchoredPosition = new Vector2(0f, 0f);
		return go;
	}

	internal static GameObject SetMiddleRight(this GameObject go)
	{
		RectTransform component = go.GetComponent<RectTransform>();
		component.anchorMax = new Vector2(1f, 0.5f);
		component.anchorMin = new Vector2(1f, 0.5f);
		component.pivot = new Vector2(1f, 0.5f);
		component.anchoredPosition = new Vector2(0f, 0f);
		return go;
	}

	internal static GameObject SetBottomRight(this GameObject go)
	{
		RectTransform component = go.GetComponent<RectTransform>();
		component.anchorMax = new Vector2(1f, 0f);
		component.anchorMin = new Vector2(1f, 0f);
		component.pivot = new Vector2(1f, 0f);
		component.anchoredPosition = new Vector2(0f, 0f);
		return go;
	}

	internal static GameObject SetUpperCenter(this GameObject go)
	{
		RectTransform component = go.GetComponent<RectTransform>();
		component.anchorMax = new Vector2(0.5f, 1f);
		component.anchorMin = new Vector2(0.5f, 1f);
		component.pivot = new Vector2(0.5f, 1f);
		component.anchoredPosition = new Vector2(0f, 0f);
		return go;
	}

	internal static GameObject SetMiddleCenter(this GameObject go)
	{
		RectTransform component = go.GetComponent<RectTransform>();
		component.anchorMax = new Vector2(0.5f, 0.5f);
		component.anchorMin = new Vector2(0.5f, 0.5f);
		component.pivot = new Vector2(0.5f, 0.5f);
		component.anchoredPosition = new Vector2(0f, 0f);
		return go;
	}

	internal static GameObject SetBottomCenter(this GameObject go)
	{
		RectTransform component = go.GetComponent<RectTransform>();
		component.anchorMax = new Vector2(0.5f, 0f);
		component.anchorMin = new Vector2(0.5f, 0f);
		component.pivot = new Vector2(0.5f, 0f);
		component.anchoredPosition = new Vector2(0f, 0f);
		return go;
	}

	internal static GameObject SetSize(this GameObject go, float width, float height)
	{
		RectTransform component = go.GetComponent<RectTransform>();
		component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
		component.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
		return go;
	}

	internal static GameObject SetWidth(this GameObject go, float width)
	{
		RectTransform component = go.GetComponent<RectTransform>();
		component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
		return go;
	}

	internal static GameObject SetHeight(this GameObject go, float height)
	{
		RectTransform component = go.GetComponent<RectTransform>();
		component.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
		return go;
	}

	internal static float GetWidth(this GameObject go)
	{
		RectTransform component = go.GetComponent<RectTransform>();
		return component.rect.width;
	}

	internal static float GetHeight(this GameObject go)
	{
		RectTransform component = go.GetComponent<RectTransform>();
		return component.rect.height;
	}

	internal static float GetTextHeight(this GameObject go)
	{
		return go.GetComponent<Text>().preferredHeight;
	}

	internal static GameObject SetText(this GameObject go, string text)
	{
		Text component = go.GetComponent<Text>();
		if ((Object)(object)component != null)
		{
			component.text = text;
		}
		TMP_Text component2 = go.GetComponent<TMP_Text>();
		if ((Object)(object)component2 != null)
		{
			component2.text = text;
		}
		return go;
	}
}
