using UnityEngine;

public class IAFCFS_2D : InputActionFlexCheckFirstStep
{
    //[HideInInspector]
    public Collider2D currentCollider;

    public override bool PassColliderCheck()
    {
        currentCollider = null;
        Vector2 pointPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentCollider = Physics2D.OverlapPoint(pointPosition);
        if (currentCollider != null)
        {
            return true;
        }
        else return false;
    }
}
