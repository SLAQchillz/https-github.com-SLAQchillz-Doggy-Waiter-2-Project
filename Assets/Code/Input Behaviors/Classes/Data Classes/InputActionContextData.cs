using UnityEngine;

[System.Serializable]
public class InputActionContextData 
{
    public InputActionInteractionType actionType = InputActionInteractionType.None;
    public Vector2 screenPositionTrue;
    public Vector2 screenWorldPosition;
}
