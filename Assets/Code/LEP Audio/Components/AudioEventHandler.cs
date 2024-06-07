using UnityEngine;

public class AudioEventHandler : MonoBehaviour
{
    public AudioPlayer player;
    public void AsAudioTriggers(AudioClip clip)
    {
        player.PlayFXClip(clip);
    }
}
