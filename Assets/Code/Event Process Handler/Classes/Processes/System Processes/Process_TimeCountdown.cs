using UnityEngine;

public class Process_TimeCountdown : FixedUpdateEventProcess
{
    public float seconds;
    public IntUnityEvent onTimerUpdate;
    public override void SpecificFixedUpdateOverrideProcess()
    {
        base.SpecificFixedUpdateOverrideProcess();

        seconds -= Time.deltaTime;
        onTimerUpdate?.Invoke(Mathf.RoundToInt(seconds));
        if (seconds <= 0) isComplete = true;
    }
}
