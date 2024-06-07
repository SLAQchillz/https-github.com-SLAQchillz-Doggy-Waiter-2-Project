using UnityEngine;

public class Process_BreakAnchorJoint2D : SingleEventProcess
{
    public Process_JoinAnchorToRigidbody2D joiner;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        Behaviour_JoinToAnchor2D anchoredBehaviour = joiner.anchoredBehaviour;
        if (anchoredBehaviour != null)
        {
            anchoredBehaviour.BreakJoint();
        }
    }
}
