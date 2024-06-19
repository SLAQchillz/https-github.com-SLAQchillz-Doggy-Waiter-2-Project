using UnityEngine;

public class Process_UnparentObject : SingleEventProcess
{
    public GameObject objectToUnparent;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        objectToUnparent.transform.parent = null;
    }
}
