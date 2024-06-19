using UnityEngine;

public class Process_PassScore : SingleEventProcess
{
    public ScoreTracker passFrom;
    public IntUnityEvent passTo;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        passTo?.Invoke(passFrom.score);
    }
}
