using UnityEngine;
using System.Collections;

public class Routine_MoveUIToWorldPoint : IEnumeratorEventProcess
{
    public RectTransform uiElement;
    public Canvas parentCanvas;
    public Vector3 targetPosition;
    public float duration;

    //update this code to be used with a UI object if necessary
    public override IEnumerator ProcessSpecificOverrideIEnumerator()
    {
        Vector3 startPosition = uiElement.anchoredPosition;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            uiElement.anchoredPosition = Vector3.Lerp(startPosition, targetPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        uiElement.anchoredPosition = targetPosition;
    }

    public void AcceptWorldPoint(Vector3 worldPoint)
    {
        targetPosition = WorldToCanvasPosition(worldPoint);
    }

    private Vector3 WorldToCanvasPosition(Vector3 worldPos)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        Vector2 movePos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, screenPos, parentCanvas.worldCamera, out movePos);
        return parentCanvas.transform.TransformPoint(movePos);
    }

    public void AcceptWorldYPoint(float worldY)
    {
        // Get the current screen space position of the UI element
        Vector3 screenPos = Camera.main.WorldToScreenPoint(new Vector3(0, worldY, 0));

        // Convert screen position to local position within the canvas
        Vector2 localCanvasPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, screenPos, parentCanvas.worldCamera, out localCanvasPos);

        // Since the canvas is an overlay and the pivot is at the center, we can directly assign the y value
        targetPosition = new Vector3(uiElement.anchoredPosition.x, localCanvasPos.y, 0);
    }
}
