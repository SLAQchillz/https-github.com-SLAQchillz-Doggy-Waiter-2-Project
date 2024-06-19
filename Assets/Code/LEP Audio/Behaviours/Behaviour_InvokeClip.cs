using UnityEngine;

public class Behaviour_InvokeClip : MonoBehaviour
{
    public AudioClip fx;
    public AudioClipEvent onTriggerClip;

    public void PlayClip()
    {
        onTriggerClip?.Invoke(fx);
    }
}
