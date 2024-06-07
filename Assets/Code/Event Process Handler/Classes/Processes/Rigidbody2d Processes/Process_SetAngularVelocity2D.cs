using UnityEngine;
using System.Collections.Generic;

public class Process_SetAngularVelocity2D : SingleEventProcess
{
    public List<Rigidbody2D> rbs;
    public float angularVelocity = 0f;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        foreach (Rigidbody2D rb in rbs)
        {
            rb.angularVelocity = angularVelocity;
        }
    }
}
