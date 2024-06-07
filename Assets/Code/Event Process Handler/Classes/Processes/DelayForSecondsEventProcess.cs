using System.Collections;
using UnityEngine;

public class DelayForSecondsEventProcess : IEnumeratorEventProcess
{
    public float delaySeconds;

    public override IEnumerator ProcessSpecificOverrideIEnumerator()
    {
        yield return new WaitForSeconds(delaySeconds);
    }
}
