using UnityEngine;
using UnityEngine.Events;

public class Breakable_OnCollision : MonoBehaviour
{
    public float dingThreshold;
    public float breakThreshold;

    public UnityEvent onBreak;
    public UnityEvent onDing;
    public GameObjectUnityEvent onBreakWithObject;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject go = collision.gameObject;
        if (!PassFloorCheck(go))
        {
            StartBreak();
            return;
        }

        float collisionForce = DetermineCollisionForce(collision);
        //Debug.Log("Collision with force " +  collisionForce);
        if (collisionForce > breakThreshold)
        {
            StartBreak();
        }
        else if (collisionForce > dingThreshold)
        {
            StartDing();
        }
    }

    private float DetermineCollisionForce(Collision2D col)
    {
        float mass = col.rigidbody.mass;
        Vector2 relativeVelocity = col.relativeVelocity;
        float colForce = mass * relativeVelocity.magnitude;
        return colForce;
    }

    private bool PassFloorCheck(GameObject colObject)
    {
        if (colObject == null) return true;
        if (colObject.CompareTag("Floor")) return false;
        else return true;
    }

    private void StartBreak()
    {
        onBreak?.Invoke();
        onBreakWithObject?.Invoke(gameObject);
    }

    private void StartDing()
    {
        onDing?.Invoke();
    }
}
