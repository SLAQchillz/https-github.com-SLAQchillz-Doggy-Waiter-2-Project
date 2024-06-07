using UnityEngine;
using UnityEngine.Events;

public class WhenInput : MonoBehaviour
{   
    public bool isDoOnce = false;
    public bool isDone { get; private set; } = false;

    public InputActionContextEvent onTapped;
    public InputActionContextEvent onHoldStarted;
    public InputActionContextEvent onHoldPerformed;
    public InputActionContextEvent onHoldCanceled;
    public UnityEvent onAny;

    public void HasReceivedInput(InputActionContextData context)
    {
        Debug.Log("WhenInput has received input.");
        if (!PassDoOnceCheck()) return;

        if (context.actionType == InputActionInteractionType.Tap) { onTapped?.Invoke(context); }
        else if (context.actionType == InputActionInteractionType.HoldStarted) { onHoldStarted?.Invoke(context); }
        else if (context.actionType == InputActionInteractionType.HoldPerformed) { onHoldPerformed?.Invoke(context); }
        else if (context.actionType == InputActionInteractionType.HoldCanceled) { onHoldCanceled?.Invoke(context); }
        onAny?.Invoke();

        isDone = true;
    }

    private bool PassDoOnceCheck()
    {
        if (isDoOnce == true && isDone == true) return false;
        else return true;
    }
}
