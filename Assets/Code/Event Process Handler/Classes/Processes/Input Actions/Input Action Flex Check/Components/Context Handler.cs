using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ContextHandler : MonoBehaviour
{
    public EventProcessHandler handler;
    public InputActionContextData currentContext;

    public UnityEvent OnHoldBegun;
    public UnityEvent OnContextCanceled;

    public void ProcessContext(InputActionContextData context)
    {
        if (handler.isEventProcessStarted == true && context.actionType == InputActionInteractionType.HoldCanceled)
        {
            OnContextCanceled?.Invoke();
        }
        else if (handler.isEventProcessStarted == true) return;

        currentContext = new()
        {
            actionType = context.actionType,
            screenPositionTrue = context.screenPositionTrue,
            screenWorldPosition = context.screenWorldPosition,
        };

        if (currentContext.actionType == InputActionInteractionType.HoldStarted)
        {
            OnHoldBegun?.Invoke();
        }
    }

    public void ClearContext()
    {
        currentContext = null;
    }
}
