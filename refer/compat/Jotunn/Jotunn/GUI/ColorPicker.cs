using System;
using UnityEngine;
using UnityEngine.UI;

namespace Jotunn.GUI;

/// <summary>
///     Custom MonoBehaviour for the ColorPicker
/// </summary>
public class ColorPicker : MonoBehaviour
{
	/// <summary>
	/// Event that gets called by the ColorPicker
	/// </summary>
	/// <param name="c">received Color</param>
	public delegate void ColorEvent(Color c);

	/// <summary>
	///     HSV helper class
	/// </summary>
	private sealed class HSV
	{
		public double H;

		public double S = 1.0;

		public double V = 1.0;

		public byte A = byte.MaxValue;

		public HSV()
		{
		}

		public HSV(double h, double s, double v)
		{
			H = h;
			S = s;
			V = v;
		}

		public HSV(Color color)
		{
			float num = Mathf.Max(color.r, Mathf.Max(color.g, color.b));
			float num2 = Mathf.Min(color.r, Mathf.Min(color.g, color.b));
			float num3 = (float)H;
			if (num2 != num)
			{
				num3 = ((num == color.r) ? ((color.g - color.b) / (num - num2)) : ((num != color.g) ? (4f + (color.r - color.g) / (num - num2)) : (2f + (color.b - color.r) / (num - num2)))) * 60f;
				if (num3 < 0f)
				{
					num3 += 360f;
				}
			}
			H = num3;
			S = ((num == 0f) ? 0.0 : (1.0 - (double)num2 / (double)num));
			V = num;
			A = (byte)(color.a * 255f);
		}

		public Color32 ToColor()
		{
			int num = Convert.ToInt32(Math.Floor(H / 60.0)) % 6;
			double num2 = H / 60.0 - Math.Floor(H / 60.0);
			double num3 = V * 255.0;
			byte b = (byte)Convert.ToInt32(num3);
			byte b2 = (byte)Convert.ToInt32(num3 * (1.0 - S));
			byte b3 = (byte)Convert.ToInt32(num3 * (1.0 - num2 * S));
			byte b4 = (byte)Convert.ToInt32(num3 * (1.0 - (1.0 - num2) * S));
			return num switch
			{
				0 => new Color32(b, b4, b2, A), 
				1 => new Color32(b3, b, b2, A), 
				2 => new Color32(b2, b, b4, A), 
				3 => new Color32(b2, b3, b, A), 
				4 => new Color32(b4, b2, b, A), 
				5 => new Color32(b, b2, b3, A), 
				_ => default(Color32), 
			};
		}
	}

	/// <summary>
	///     Singeleton instance
	/// </summary>
	private static ColorPicker instance;

	/// <returns>
	///     True when the ColorPicker is closed
	/// </returns>
	public static bool done = true;

	/// <summary>
	///     OnColorChanged event
	/// </summary>
	private static ColorEvent onCC;

	/// <summary>
	///     OnColorSelected event
	/// </summary>
	private static ColorEvent onCS;

	/// <summary>
	///     Color before editing
	/// </summary>
	private static Color32 originalColor;

	/// <summary>
	///     Current Color
	/// </summary>
	private static Color32 modifiedColor;

	private static HSV modifiedHsv;

	/// <summary>
	///     UseAlpha bool
	/// </summary>
	private static bool useA;

	/// <summary>
	///     Interact bool
	/// </summary>
	private bool interact;

	/// <summary>
	///     Component ref
	/// </summary>
	public RectTransform positionIndicator;

	/// <summary>
	///     Component ref
	/// </summary>
	public Slider mainComponent;

	/// <summary>
	///     Component ref
	/// </summary>
	public Slider rComponent;

	/// <summary>
	///     Component ref
	/// </summary>
	public Slider gComponent;

	/// <summary>
	///     Component ref
	/// </summary>
	public Slider bComponent;

	/// <summary>
	///     Component ref
	/// </summary>
	public Slider aComponent;

	/// <summary>
	///     Component ref
	/// </summary>
	public InputField hexaComponent;

	/// <summary>
	///     Component ref
	/// </summary>
	public RawImage colorComponent;

	private void Awake()
	{
		instance = this;
		base.gameObject.SetActive(value: false);
	}

	/// <summary>
	///     Creates a new Colorpicker
	/// </summary>
	/// <param name="original">Color before editing</param>
	/// <param name="message">Display message</param>
	/// <param name="onColorChanged">Event that gets called when the color gets modified</param>
	/// <param name="onColorSelected">Event that gets called when one of the buttons done or cancel get pressed</param>
	/// <param name="useAlpha">When set to false the colors used don't have an alpha channel</param>
	/// <returns>
	///     False if the instance is already running
	/// </returns>
	public static bool Create(Color original, string message, ColorEvent onColorChanged, ColorEvent onColorSelected, bool useAlpha = false)
	{
		if ((object)instance == null)
		{
			Debug.LogError("No Colorpicker prefab active on 'Start' in scene");
			return false;
		}
		if (done)
		{
			done = false;
			originalColor = original;
			modifiedColor = original;
			onCC = onColorChanged;
			onCS = onColorSelected;
			useA = useAlpha;
			instance.gameObject.SetActive(value: true);
			instance.transform.GetChild(0).GetComponent<Text>().text = message;
			((Component)(object)instance.aComponent).gameObject.SetActive(useAlpha);
			instance.RecalculateMenu(recalculateHSV: true);
			((Component)(object)instance.hexaComponent.placeholder).GetComponent<Text>().text = "RRGGBB" + (useAlpha ? "AA" : "");
			return true;
		}
		Done();
		return false;
	}

	/// <summary>
	///     Called when color is modified, to update other UI components
	/// </summary>
	/// <param name="recalculateHSV"></param>
	private void RecalculateMenu(bool recalculateHSV)
	{
		interact = false;
		if (recalculateHSV)
		{
			modifiedHsv = new HSV(modifiedColor);
		}
		else
		{
			modifiedColor = modifiedHsv.ToColor();
		}
		rComponent.value = (int)modifiedColor.r;
		((Component)(object)rComponent).transform.GetChild(3).GetComponent<InputField>().text = modifiedColor.r.ToString();
		gComponent.value = (int)modifiedColor.g;
		((Component)(object)gComponent).transform.GetChild(3).GetComponent<InputField>().text = modifiedColor.g.ToString();
		bComponent.value = (int)modifiedColor.b;
		((Component)(object)bComponent).transform.GetChild(3).GetComponent<InputField>().text = modifiedColor.b.ToString();
		if (useA)
		{
			aComponent.value = (int)modifiedColor.a;
			((Component)(object)aComponent).transform.GetChild(3).GetComponent<InputField>().text = modifiedColor.a.ToString();
		}
		mainComponent.value = (float)modifiedHsv.H;
		((Graphic)((Component)(object)rComponent).transform.GetChild(0).GetComponent<RawImage>()).color = new Color32(byte.MaxValue, modifiedColor.g, modifiedColor.b, byte.MaxValue);
		((Graphic)((Component)(object)rComponent).transform.GetChild(0).GetChild(0).GetComponent<RawImage>()).color = new Color32(0, modifiedColor.g, modifiedColor.b, byte.MaxValue);
		((Graphic)((Component)(object)gComponent).transform.GetChild(0).GetComponent<RawImage>()).color = new Color32(modifiedColor.r, byte.MaxValue, modifiedColor.b, byte.MaxValue);
		((Graphic)((Component)(object)gComponent).transform.GetChild(0).GetChild(0).GetComponent<RawImage>()).color = new Color32(modifiedColor.r, 0, modifiedColor.b, byte.MaxValue);
		((Graphic)((Component)(object)bComponent).transform.GetChild(0).GetComponent<RawImage>()).color = new Color32(modifiedColor.r, modifiedColor.g, byte.MaxValue, byte.MaxValue);
		((Graphic)((Component)(object)bComponent).transform.GetChild(0).GetChild(0).GetComponent<RawImage>()).color = new Color32(modifiedColor.r, modifiedColor.g, 0, byte.MaxValue);
		if (useA)
		{
			((Graphic)((Component)(object)aComponent).transform.GetChild(0).GetChild(0).GetComponent<RawImage>()).color = new Color32(modifiedColor.r, modifiedColor.g, modifiedColor.b, byte.MaxValue);
		}
		((Graphic)positionIndicator.parent.GetChild(0).GetComponent<RawImage>()).color = new HSV(modifiedHsv.H, 1.0, 1.0).ToColor();
		positionIndicator.anchorMin = new Vector2((float)modifiedHsv.S, (float)modifiedHsv.V);
		positionIndicator.anchorMax = positionIndicator.anchorMin;
		hexaComponent.text = (useA ? ColorUtility.ToHtmlStringRGBA(modifiedColor) : ColorUtility.ToHtmlStringRGB(modifiedColor));
		((Graphic)colorComponent).color = modifiedColor;
		onCC?.Invoke(modifiedColor);
		interact = true;
	}

	/// <summary>
	///     Used by EventTrigger to calculate the chosen value in color box
	/// </summary>
	public void SetChooser()
	{
		Vector2 point = default(Vector2);
		RectTransformUtility.ScreenPointToLocalPointInRectangle(positionIndicator.parent as RectTransform, (Vector2)Input.mousePosition, GetComponentInParent<Canvas>().worldCamera, ref point);
		point = Rect.PointToNormalized((positionIndicator.parent as RectTransform).rect, point);
		if (positionIndicator.anchorMin != point)
		{
			positionIndicator.anchorMin = point;
			positionIndicator.anchorMax = point;
			modifiedHsv.S = point.x;
			modifiedHsv.V = point.y;
			RecalculateMenu(recalculateHSV: false);
		}
	}

	/// <summary>
	///     Gets main Slider value
	/// </summary>
	/// <param name="value"></param>
	public void SetMain(float value)
	{
		if (interact)
		{
			modifiedHsv.H = value;
			RecalculateMenu(recalculateHSV: false);
		}
	}

	/// <summary>
	///     Gets r Slider value
	/// </summary>
	/// <param name="value"></param>
	public void SetR(float value)
	{
		if (interact)
		{
			modifiedColor.r = (byte)value;
			RecalculateMenu(recalculateHSV: true);
		}
	}

	/// <summary>
	///     Gets r InputField value
	/// </summary>
	/// <param name="value"></param>
	public void SetR(string value)
	{
		if (interact)
		{
			modifiedColor.r = (byte)Mathf.Clamp(int.Parse(value), 0, 255);
			RecalculateMenu(recalculateHSV: true);
		}
	}

	/// <summary>
	///     Gets g Slider value
	/// </summary>
	/// <param name="value"></param>
	public void SetG(float value)
	{
		if (interact)
		{
			modifiedColor.g = (byte)value;
			RecalculateMenu(recalculateHSV: true);
		}
	}

	/// <summary>
	///     Gets g InputField value
	/// </summary>
	/// <param name="value"></param>
	public void SetG(string value)
	{
		if (interact)
		{
			modifiedColor.g = (byte)Mathf.Clamp(int.Parse(value), 0, 255);
			RecalculateMenu(recalculateHSV: true);
		}
	}

	/// <summary>
	///     Gets b Slider value
	/// </summary>
	/// <param name="value"></param>
	public void SetB(float value)
	{
		if (interact)
		{
			modifiedColor.b = (byte)value;
			RecalculateMenu(recalculateHSV: true);
		}
	}

	/// <summary>
	///     Gets b InputField value
	/// </summary>
	/// <param name="value"></param>
	public void SetB(string value)
	{
		if (interact)
		{
			modifiedColor.b = (byte)Mathf.Clamp(int.Parse(value), 0, 255);
			RecalculateMenu(recalculateHSV: true);
		}
	}

	/// <summary>
	///     Gets a Slider value
	/// </summary>
	/// <param name="value"></param>
	public void SetA(float value)
	{
		if (interact)
		{
			modifiedHsv.A = (byte)value;
			RecalculateMenu(recalculateHSV: false);
		}
	}

	/// <summary>
	///     Gets a InputField value
	/// </summary>
	/// <param name="value"></param>
	public void SetA(string value)
	{
		if (interact)
		{
			modifiedHsv.A = (byte)Mathf.Clamp(int.Parse(value), 0, 255);
			RecalculateMenu(recalculateHSV: false);
		}
	}

	/// <summary>
	///     Gets hexa InputField value
	/// </summary>
	/// <param name="value"></param>
	public void SetHexa(string value)
	{
		if (!interact)
		{
			return;
		}
		if (ColorUtility.TryParseHtmlString("#" + value, out var color))
		{
			if (!useA)
			{
				color.a = 1f;
			}
			modifiedColor = color;
			RecalculateMenu(recalculateHSV: true);
		}
		else
		{
			hexaComponent.text = (useA ? ColorUtility.ToHtmlStringRGBA(modifiedColor) : ColorUtility.ToHtmlStringRGB(modifiedColor));
		}
	}

	/// <summary>
	///     Cancel button call
	/// </summary>
	public void CCancel()
	{
		Cancel();
	}

	/// <summary>
	///     Manually cancel the ColorPicker and recover the default value
	/// </summary>
	public static void Cancel()
	{
		modifiedColor = originalColor;
		Done();
	}

	/// <summary>
	///     Done button call
	/// </summary>
	public void CDone()
	{
		Done();
	}

	/// <summary>
	///     Manually close the ColorPicker and apply the selected color
	/// </summary>
	public static void Done()
	{
		done = true;
		onCC?.Invoke(modifiedColor);
		onCS?.Invoke(modifiedColor);
		instance.transform.gameObject.SetActive(value: false);
	}
}
