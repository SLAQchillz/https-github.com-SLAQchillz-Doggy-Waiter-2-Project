using UnityEngine;
using System.Collections;

public class Routine_RotateObject : IEnumeratorEventProcess
{
    public GameObject Object;
    public Vector3 TargetRotations;
    public float StartDelay = 0f;
    public float Duration;

    public override IEnumerator ProcessSpecificOverrideIEnumerator()
    {
        Quaternion startRotation = Object.transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(TargetRotations);
        float timeElapsed = 0f;

        yield return new WaitForSeconds(StartDelay);

        while (timeElapsed < Duration)
        {
            Object.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, timeElapsed / Duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        Object.transform.rotation = targetRotation;
    }
}
