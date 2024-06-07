using UnityEngine;

public class Process_StartEffectSystem : SingleEventProcess
{
    public ParticleSystem effectSystem;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        effectSystem.Play();
    }
}
