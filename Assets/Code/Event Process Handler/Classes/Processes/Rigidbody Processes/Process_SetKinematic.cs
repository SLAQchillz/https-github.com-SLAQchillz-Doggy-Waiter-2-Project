using UnityEngine;

public class Process_SetKinematic : SingleEventProcess
{
    public Rigidbody Rigidbody;
    public bool turnOn = false;
    public bool turnOff = false;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        if (turnOn == turnOff) Rigidbody.isKinematic = !Rigidbody.isKinematic;
        else if (turnOn) Rigidbody.isKinematic = true;
        else Rigidbody.isKinematic = false;
    }
}
