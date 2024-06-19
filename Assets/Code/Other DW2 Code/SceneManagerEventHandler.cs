using UnityEngine;
using UnityEngine.Events;

public class SceneManagerEventHandler : MonoBehaviour
{
    public UnityEvent onGameplayStart;
    public UnityEvent onTimerComplete;

    public void AcceptStartupComplete()
    {
        onGameplayStart?.Invoke();
    }

    public void AcceptTimerComplete()
    {
        onTimerComplete?.Invoke();
    }
}
