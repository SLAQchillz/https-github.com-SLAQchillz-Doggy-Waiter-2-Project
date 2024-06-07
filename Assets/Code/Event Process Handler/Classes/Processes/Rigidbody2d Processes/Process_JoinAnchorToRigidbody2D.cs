using UnityEngine;

public class Process_JoinAnchorToRigidbody2D : SingleEventProcess
{
    public ContextHandler handler;
    public InputActionFlexCheckFirstStep myFirstStep;
    public Rigidbody2D anchor;
    public Behaviour_JoinToAnchor2D anchoredBehaviour;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        anchoredBehaviour = null;

        IAFCFS_2D myFirstStep2D = myFirstStep as IAFCFS_2D;
        if (myFirstStep2D != null)
        {
            anchoredBehaviour = myFirstStep2D.currentCollider.gameObject.GetComponent<Behaviour_JoinToAnchor2D>();
            if (anchoredBehaviour != null)
            {
                anchoredBehaviour.GetAnchor(anchor, handler.currentContext.screenWorldPosition);
            }
        }
    }
}
