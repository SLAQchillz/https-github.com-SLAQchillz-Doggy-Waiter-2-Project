using UnityEngine;
using UnityEngine.Events;

public class Parser_EventToInt : MonoBehaviour
{
    public SO_StringIntPair passValue;
    public IntUnityEvent passTo;

    public void AcceptTrigger() { passTo?.Invoke(passValue.pair.number); }
}
