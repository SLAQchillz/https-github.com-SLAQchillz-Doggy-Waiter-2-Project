using System.Collections;
using UnityEngine.Events;

public class IEnumeratorEventProcess : SingleEventProcess
{
    public override void BeginProcess(UnityEvent onCompleteEvent)
    {
        StartCoroutine(IEnumeratorProcess(onCompleteEvent));
    }

    private IEnumerator IEnumeratorProcess(UnityEvent onCompleteEvent)
    {
        if (!StartCheckPass()) yield break;
        yield return StartCoroutine(ProcessSpecificOverrideIEnumerator());
        CompleteProcess(onCompleteEvent);
    }

    public virtual IEnumerator ProcessSpecificOverrideIEnumerator()
    {
        yield break;
    }
}
