using UnityEngine;

public class IAFCES_3D : InputActionFlexCheckEndStep
{
    public override void ClearCurrentCollider()
    {
        base.ClearCurrentCollider();

        IAFCFS_3D my3DFirstStep = myFirstStep as IAFCFS_3D;
        if (my3DFirstStep != null)
        {
            my3DFirstStep.currentCollider = null;
        }
    }
}
