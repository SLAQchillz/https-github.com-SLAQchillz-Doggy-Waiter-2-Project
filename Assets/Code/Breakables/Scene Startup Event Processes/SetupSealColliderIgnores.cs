using UnityEngine;

//Creates collisions ignore for all layers except itself, for
//Seal Layer Colliders
public class SetupSealColliderIgnores : SingleEventProcess
{
    public int layer;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        for (int i = 0; i < 32; i++)
        {
            if (i != layer)
            {
                Physics2D.IgnoreLayerCollision(layer, i, true);
            }
        }
    }
}
