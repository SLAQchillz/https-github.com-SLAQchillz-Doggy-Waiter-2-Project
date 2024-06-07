using UnityEngine;

public class Process_SleepRigidbody : SingleEventProcess
{
    public Rigidbody rb;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        rb.Sleep();
    }
}
