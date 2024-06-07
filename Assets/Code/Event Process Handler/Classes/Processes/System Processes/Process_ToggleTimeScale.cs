using UnityEngine;

public class Process_ToggleTimeScale : SingleEventProcess
{
    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        if (Time.timeScale != 0f) { Time.timeScale = 0f; }
        else { Time.timeScale = 1f; }
    }
}
