using UnityEngine;

public class Process_ToggleAnimator : SingleEventProcess
{
    public Animator anim;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        anim.enabled = !anim.enabled;
    }
}
