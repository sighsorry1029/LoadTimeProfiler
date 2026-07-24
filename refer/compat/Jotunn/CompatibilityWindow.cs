using UnityEngine;
using UnityEngine.UI;

internal class CompatibilityWindow : MonoBehaviour
{
	public ScrollRect scrollRect;

	public Text failedConnection;

	public Text localVersion;

	public Text remoteVersion;

	public Text errorMessages;

	public Button continueButton;

	public Button logFileButton;

	public Button troubleshootingButton;

	public void UpdateTextPositions()
	{
		float preferredHeight = failedConnection.preferredHeight;
		float preferredHeight2 = localVersion.preferredHeight;
		float preferredHeight3 = remoteVersion.preferredHeight;
		float preferredHeight4 = errorMessages.preferredHeight;
		Vector2 anchoredPosition = ((Graphic)localVersion).rectTransform.anchoredPosition;
		Vector2 anchoredPosition2 = ((Graphic)remoteVersion).rectTransform.anchoredPosition;
		float num = preferredHeight + 32f;
		((Graphic)localVersion).rectTransform.anchoredPosition = new Vector2(anchoredPosition.x, 0f - num);
		((Graphic)remoteVersion).rectTransform.anchoredPosition = new Vector2(anchoredPosition2.x, 0f - num);
		Vector2 anchoredPosition3 = ((Graphic)errorMessages).rectTransform.anchoredPosition;
		float num2 = num + Mathf.Max(preferredHeight2, preferredHeight3) + 32f;
		((Graphic)errorMessages).rectTransform.anchoredPosition = new Vector2(anchoredPosition3.x, 0f - num2);
		RectTransform rectTransform = (RectTransform)scrollRect.content.transform;
		rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, num2 + preferredHeight4);
	}
}
