using UnityEngine;

public class Process_MoveObjectToPointer : SingleEventProcess
{
    public ContextHandler handler;
    
    public GameObject go;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        go.transform.position = handler.currentContext.screenWorldPosition;
    }
}
