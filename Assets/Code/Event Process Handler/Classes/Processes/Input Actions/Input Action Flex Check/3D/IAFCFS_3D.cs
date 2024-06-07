using UnityEngine;
using UnityEngine.InputSystem;

public class IAFCFS_3D : InputActionFlexCheckFirstStep
{
    [HideInInspector]
    public Collider currentCollider;

    public override bool PassColliderCheck()
    {
        currentCollider = null;
        
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (CheckAndStoreCollider(hitInfo))
            {
                return true;
            }
            else return false;
        }
        else return false;
    }

    private bool CheckAndStoreCollider(RaycastHit hitInfo)
    {
        Collider hitCollider = hitInfo.collider;
        if (hitCollider != null)
        {
            currentCollider = hitCollider;
            return true;
        }
        else return false;
    }
}
