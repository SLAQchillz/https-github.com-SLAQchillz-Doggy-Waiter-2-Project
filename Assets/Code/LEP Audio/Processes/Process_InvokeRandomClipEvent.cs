using UnityEngine;

public class Process_InvokeRandomClipEvent : SingleEventProcess
{
    public AudioClip[] randomFX;
    public AudioClipEvent onTriggerClip;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        AudioClip fx = randomFX[UnityEngine.Random.Range(0, randomFX.Length)];
        onTriggerClip?.Invoke(fx);
    }
}
