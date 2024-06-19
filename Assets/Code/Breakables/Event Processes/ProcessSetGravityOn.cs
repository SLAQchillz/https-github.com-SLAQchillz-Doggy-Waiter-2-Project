using UnityEngine;

public class ProcessSetGravityOn : SingleEventProcess
{
    public Rigidbody2D rb;
    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        rb.gravityScale = 1.0f;
    }
}
