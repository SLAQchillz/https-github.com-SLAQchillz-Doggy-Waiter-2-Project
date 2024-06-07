using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class LinearEventProcess 
{
    public string stringID;
    public RecursiveUnityEvent DoThis;
    [HideInInspector]
    public UnityEvent OnComplete;
}
