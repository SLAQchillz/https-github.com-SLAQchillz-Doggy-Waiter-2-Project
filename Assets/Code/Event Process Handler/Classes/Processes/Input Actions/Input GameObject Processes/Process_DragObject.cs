using System.Collections;
using UnityEngine;

public class Process_DragObject : IEnumeratorEventProcess
{
    public Rigidbody2D rb;
    public InputRouter router;
    public bool inputNotCanceled = true;
    public float smoothing = 5f;

    private Vector2 currentMousePosition;
    private Vector2 smoothedMousePosition;


    public override IEnumerator ProcessSpecificOverrideIEnumerator()
    {
        inputNotCanceled = true;
        currentMousePosition = rb.position;
        smoothedMousePosition = currentMousePosition;

        while (inputNotCanceled)
        {
            Vector2 targetMousePosition = Camera.main.ScreenToWorldPoint(router.pointerPosition);
            smoothedMousePosition = Vector2.Lerp(smoothedMousePosition, targetMousePosition, smoothing * Time.deltaTime);
            rb.MovePosition(smoothedMousePosition);
            yield return null;
        }
        yield break;
    }

    public void AcceptInputCanceled()
    {
        inputNotCanceled = false;
    }
}
