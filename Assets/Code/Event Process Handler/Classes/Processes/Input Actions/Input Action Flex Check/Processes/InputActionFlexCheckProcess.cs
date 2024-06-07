using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionFlexCheckProcess : SingleEventProcess
{
    public ContextHandler handler;
    public InputActionFlexCheckFirstStep myFirstStep;
    WhenInput whenInput = null;

    public override void ProcessSpecificOverride()
    {
        if (handler.currentContext == null) return;

        IAFCFS_2D myFirstStep2D = myFirstStep as IAFCFS_2D;
        if (myFirstStep2D != null)
        {
            whenInput = myFirstStep2D.currentCollider.gameObject.GetComponent<WhenInput>();
        }
        
        IAFCFS_3D myFirstStep3D = myFirstStep as IAFCFS_3D;
        if (myFirstStep3D != null)
        {
            whenInput = myFirstStep3D.currentCollider.gameObject.GetComponent<WhenInput>();
        }

        if (whenInput == null)
        {
            Debug.Log("WhenInput is null!");
            return;
        }

        whenInput.HasReceivedInput(handler.currentContext);
        whenInput = null;
    }
}
