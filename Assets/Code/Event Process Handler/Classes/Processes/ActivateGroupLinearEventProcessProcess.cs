using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGroupLinearEventProcessProcess : SingleEventProcess
{
    public ObjectTracker tracker;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        foreach (GameObject go in tracker.MyObjectList)
        {
            EventProcessHandler handler = go.GetComponent<EventProcessHandler>();
            if (handler != null)
            {
                handler.BeginProcessLogic();
            }
        }
    }
}
