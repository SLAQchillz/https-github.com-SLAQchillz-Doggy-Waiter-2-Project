using UnityEngine;
using UnityEngine.Events;

public class Process_UnityEventTrigger : SingleEventProcess
{
    public UnityEvent onTrigger;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        onTrigger?.Invoke();
    }
}
