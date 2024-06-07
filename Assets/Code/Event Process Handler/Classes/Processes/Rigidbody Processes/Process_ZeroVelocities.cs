using UnityEngine;

public class Process_ZeroVelocities : SingleEventProcess
{
    public Rigidbody rb;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
