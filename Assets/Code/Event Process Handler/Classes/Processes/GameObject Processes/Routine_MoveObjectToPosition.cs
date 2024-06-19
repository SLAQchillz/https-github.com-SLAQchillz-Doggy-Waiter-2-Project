using UnityEngine;
using System.Collections;

public class Routine_MoveObjectToPosition : IEnumeratorEventProcess
{
    public GameObject go;
    public Vector3 target;
    public float duration;
    public FloatUnityEvent onHeightChange;

    public override IEnumerator ProcessSpecificOverrideIEnumerator()
    {
        Vector3 startPosition = go.transform.position;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            Vector3 newPosition = Vector3.Lerp(startPosition, target, timeElapsed / duration);
            go.transform.position = Vector3.Lerp(startPosition, target, timeElapsed / duration);

            float heightChange = newPosition.y - startPosition.y;
            onHeightChange.Invoke(heightChange);

            timeElapsed += Time.deltaTime;
            yield return null;
        }
        go.transform.position = target;
    }

    public void AcceptYPosition(float yPos)
    {
        target = new Vector3(go.transform.position.x, yPos, go.transform.position.z);
    }
}
