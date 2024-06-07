using UnityEngine;

public class Process_ActivatePoolObjects : SingleEventProcess
{
    public ObjectTracker objectTracker;
    public bool isTurnOn = true;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        foreach(GameObject go in objectTracker.MyObjectList)
        {
            go.SetActive(isTurnOn);
        }
    }
}
