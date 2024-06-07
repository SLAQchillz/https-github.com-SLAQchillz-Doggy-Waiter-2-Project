using System.Collections;
using UnityEngine;

public class Routine_MoveObjectToPoint : IEnumeratorEventProcess
{
    public GameObject go;
    public Transform movePoint;
    public float duration;

    public override IEnumerator ProcessSpecificOverrideIEnumerator()
    {
        Vector3 startPosition = go.transform.position;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            go.transform.position = Vector3.Lerp(startPosition, movePoint.position, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        go.transform.position = movePoint.position;
    }
}
