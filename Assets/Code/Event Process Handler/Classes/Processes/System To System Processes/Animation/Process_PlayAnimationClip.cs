using UnityEngine;

public class Process_PlayAnimationClip : SingleEventProcess
{
    public Animator animator;
    public string clipName;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        animator.Play(clipName);
    }
}
