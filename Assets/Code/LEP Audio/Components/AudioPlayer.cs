using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource source;

    public void PlayFXClip(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
