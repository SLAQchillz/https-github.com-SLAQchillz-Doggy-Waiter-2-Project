using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputRouter : MonoBehaviour
{    
    public InputActionContextEvent onReceivedInputContext;
    public UnityEvent onInputReceived;
    public Vector2 pointerPosition;

    private void Awake()
    {
        if (onInputReceived == null)
        {
            onInputReceived = new();
        }
    }

    private InputActionContextData ConstructContextData(InputActionInteractionType type)
    {
        InputActionContextData data = new InputActionContextData
        {
            actionType = type,
            screenPositionTrue = pointerPosition,
            screenWorldPosition = Camera.main.ScreenToWorldPoint(pointerPosition)
        };
        return data;
    }

    public void AcceptTapInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            InputActionContextData data = ConstructContextData(InputActionInteractionType.Tap);
            onReceivedInputContext?.Invoke(data);
            onInputReceived?.Invoke();
        }
    }

    public void AcceptHoldInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ProcessHoldStarted();
        }
        if (context.performed)
        {
            ProcessHoldPerformedInput();
        }
        else if (context.canceled)
        {
            ProcessHoldCanceledInput();
        }
    }

    private void ProcessHoldStarted()
    {
        InputActionContextData data = ConstructContextData(InputActionInteractionType.HoldStarted);
        onReceivedInputContext?.Invoke(data);
        onInputReceived?.Invoke();
    }

    private void ProcessHoldPerformedInput()
    {
            InputActionContextData data = ConstructContextData(InputActionInteractionType.HoldPerformed);
            onReceivedInputContext?.Invoke(data);
            onInputReceived?.Invoke();
    }

    private void ProcessHoldCanceledInput()
    {
            InputActionContextData data = ConstructContextData(InputActionInteractionType.HoldCanceled);
            onReceivedInputContext?.Invoke(data);
    }

    public void AcceptPointerPositionData(InputAction.CallbackContext context)
    {
        pointerPosition = context.ReadValue<Vector2>();
    }

    public void AcceptPauseInput(InputAction.CallbackContext context)
    {
        onInputReceived?.Invoke();
    }
}
