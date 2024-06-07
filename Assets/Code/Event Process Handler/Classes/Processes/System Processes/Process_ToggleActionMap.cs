using UnityEngine;
using UnityEngine.InputSystem;

public class Process_ToggleActionMap : SingleEventProcess
{
    public PlayerInput playerInput;
    public string actionMapName;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        if (playerInput.actions[actionMapName].enabled) playerInput.actions[actionMapName].Disable();
        else playerInput.actions[actionMapName].Enable();
    }
}
