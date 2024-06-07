using UnityEngine;

public class InputActionFlexCheckEndStep : SingleEventProcess
{
    public InputActionFlexCheckFirstStep myFirstStep;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        ClearCurrentCollider();
    }

    public virtual void ClearCurrentCollider() { }
}
