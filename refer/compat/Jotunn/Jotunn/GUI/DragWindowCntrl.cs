using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Jotunn.GUI;

/// <summary>
///     Simple dragging <see cref="T:UnityEngine.MonoBehaviour" />
/// </summary>
public class DragWindowCntrl : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler
{
	private RectTransform window;

	private Vector2 delta;

	/// <summary>
	///     Add this MonoBehaviour to a GameObject
	/// </summary>
	/// <param name="go"></param>
	[Obsolete("Use gameObject.AddComponent<DragWindowCntrl>() instead")]
	public static void ApplyDragWindowCntrl(GameObject go)
	{
		go.AddComponent<DragWindowCntrl>();
	}

	private void Awake()
	{
		window = (RectTransform)base.transform;
	}

	/// <summary>
	///     BeginDrag event trigger
	/// </summary>
	public void OnBeginDrag(PointerEventData eventData)
	{
		delta = Input.mousePosition - window.position;
	}

	/// <summary>
	///     Drag event trigger
	/// </summary>
	public void OnDrag(PointerEventData eventData)
	{
		Vector2 vector = eventData.position - delta;
		Rect rect = window.rect;
		Vector2 vector2 = window.lossyScale;
		float num = rect.width / 2f * vector2.x;
		float max = (float)Screen.width - num;
		float num2 = rect.height / 2f * vector2.y;
		float max2 = (float)Screen.height - num2;
		vector.x = Mathf.Clamp(vector.x, num, max);
		vector.y = Mathf.Clamp(vector.y, num2, max2);
		base.transform.position = vector;
	}
}
