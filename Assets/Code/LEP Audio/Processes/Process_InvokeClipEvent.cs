using UnityEngine;

public class Process_InvokeClipEvent : SingleEventProcess
{
    public AudioClip fx;
    public AudioClipEvent onTriggerClip;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        onTriggerClip?.Invoke(fx);
    }
}
