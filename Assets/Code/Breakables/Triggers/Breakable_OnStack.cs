using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Breakable_OnStack : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool isScoring { get; private set; } = false;
    private bool hasScored = false;
    public UnityEvent onStackOneShot;
    private HashSet<Breakable_OnStack> checkedObjects = new();

    private void CheckForScoreLogic(Collision2D col)
    {
        if (!CheckVelocity()) return;

    }

    private bool CheckVelocity()
    {
        if (rb.velocity.sqrMagnitude < 0.01f) return true;
        else return false;
    }

    private bool CheckTrayContact(GameObject go)
    {
        if (go.CompareTag("Tray")) return true;
        else return false;
    }

    private void CheckStackContact(GameObject go)
    {

        
        Breakable_OnStack sgo = go.GetComponent<Breakable_OnStack>();
        if (sgo != null && !checkedObjects.Contains(sgo))
        {
            checkedObjects.Add(sgo);
            foreach (Collider2D col in sgo.GetComponents<Collider2D>())
            {

            }
        }
    }
}
