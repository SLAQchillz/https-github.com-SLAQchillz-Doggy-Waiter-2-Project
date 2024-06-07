using UnityEngine;
using UnityEngine.Events;

public abstract class SingleEventProcess : MonoBehaviour
{
    [HideInInspector] public bool isWorking = false;

    public virtual void BeginProcess(UnityEvent onCompleteEvent)
    {
        if (!StartCheckPass()) return;
        ProcessSpecificOverride();
        CompleteProcess(onCompleteEvent);
    }

    public void CompleteProcess(UnityEvent onCompleteEvent)
    {
        isWorking = false;
        Debug.Log(this.GetType().ToString() + " process complete.");
        onCompleteEvent?.Invoke();
    }

    public bool StartCheckPass()
    {
        if (!isWorking)
        {
            isWorking = true;
            Debug.Log(this.GetType().ToString() + " process begun.");
            return true;
        }
        else
        {
            Debug.Log("Error: " + this.GetType().ToString() + " process begin attempt while process ongoing.");
            return false;
        }
    }

    public virtual void ProcessSpecificOverride()
    {

    }
}
