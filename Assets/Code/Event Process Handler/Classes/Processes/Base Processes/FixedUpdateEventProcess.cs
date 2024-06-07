using UnityEngine;
using UnityEngine.Events;

public class FixedUpdateEventProcess : SingleEventProcess
{
    //[HideInInspector]
    public bool isOn = false;
    //[HideInInspector]
    public bool isComplete = false;
    private UnityEvent onCompleteEventReference;

    private void FixedUpdate()
    {
        if (isComplete && isOn) EndFixedUpdateProcess();
        else if (!isOn) return;
        SpecificFixedUpdateOverrideProcess();
    }

    public virtual void SpecificFixedUpdateOverrideProcess()
    {

    }

    public override void BeginProcess(UnityEvent onCompleteEvent)
    {
        if (!StartCheckPass()) return;
        onCompleteEventReference = onCompleteEvent;
        BeginFixedUpdateProcess();
    }

    private void BeginFixedUpdateProcess()
    {
        isComplete = false;
        isOn = true;
    }

    private void EndFixedUpdateProcess()
    {
        if (isComplete)
        {
            isOn = false;
            CompleteProcess(onCompleteEventReference);
        }
    }
}
