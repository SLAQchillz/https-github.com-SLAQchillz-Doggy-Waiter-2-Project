using UnityEngine;

public class Behaviour_ActivateGameObject : MonoBehaviour
{
    public void AcceptActiveObject(GameObject go)
    {
        go.SetActive(true);
    }
}
