using UnityEngine;

public class IAFCES_2D : InputActionFlexCheckEndStep
{
    public override void ClearCurrentCollider()
    {
        base.ClearCurrentCollider();

        IAFCFS_2D my2DFirstStep = myFirstStep as IAFCFS_2D;
        if (my2DFirstStep != null)
        {
            my2DFirstStep.currentCollider = null;
        }
    }
}
