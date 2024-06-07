using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionFlexCheckFirstStep : SingleEventProcess
{
    public Camera mainCamera;
    public EventProcessHandler myHandler;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        if (!PassColliderCheck())
        {
            SendCompleteEventProcessNow();
        }
    }

    public virtual bool PassColliderCheck()
    {
        return false;
    }

    public void SendCompleteEventProcessNow()
    {
        myHandler.CompleteEventProcessNow();
    }
}
