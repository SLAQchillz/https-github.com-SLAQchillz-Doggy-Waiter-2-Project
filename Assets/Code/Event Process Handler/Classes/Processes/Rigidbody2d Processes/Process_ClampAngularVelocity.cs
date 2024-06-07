using System.Collections.Generic;
using UnityEngine;

public class Process_ClampAngularVelocity : IEnumeratorBinaryStateEventProcess
{
    public List<Rigidbody2D> rbs;
    public float maxAngularVelocity;

    public override System.Collections.IEnumerator BinaryOverrideRoutine()
    {
        foreach(Rigidbody2D rb in rbs)
        {
            rb.angularVelocity = Mathf.Clamp(rb.angularVelocity, -maxAngularVelocity, maxAngularVelocity);
        }
        yield return null;
    }
}
