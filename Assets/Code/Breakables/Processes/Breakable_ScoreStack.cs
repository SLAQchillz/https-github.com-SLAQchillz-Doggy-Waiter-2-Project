using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Breakable_ScoreStack : FixedUpdateEventProcess
{
    public SO_CoreRules rules;
    
    public Rigidbody2D rb;
    public Collider2D myCollider2D;
    public bool isStacked = false;
    public bool hasScored = false;

    public UnityEvent onFirstStack;
    public UnityEvent onStack;
    public UnityEvent onUnstack;

    private LayerMask trayLayerMask;
    private LayerMask tableLayerMask;

    private void Start()
    {
        trayLayerMask = LayerMask.GetMask("Tray");
        tableLayerMask = LayerMask.GetMask("Table");
    }

    public override void SpecificFixedUpdateOverrideProcess()
    {
        base.SpecificFixedUpdateOverrideProcess();

        UpdateStackedStatus();
        UpdateScoringStatus();
    }

    private void UpdateStackedStatus()
    {
        bool wasStacked = isStacked;
        isStacked = StackingLogic();
        if (!wasStacked && isStacked) onStack?.Invoke();
        if (wasStacked && !isStacked) onUnstack?.Invoke();

    }

    private void UpdateScoringStatus()
    {
        if (!isStacked || hasScored) return;
        hasScored = true;
        onFirstStack.Invoke();
    }

    private bool StackingLogic()
    {
        if (!CheckVelocity()) return false;
        if (CheckTrayContact()) return true;
        else if (CheckContactedObjectsForStacking()) return true;
        else return false;
    }

    private bool CheckVelocity()
    {
        if (rb.velocity.sqrMagnitude < rules.rules.stacking_RestVelocity) return true;
        else return false;
    }

    private bool CheckTrayContact()
    {
        if (myCollider2D.IsTouchingLayers(tableLayerMask)) return false;
        else if (myCollider2D.IsTouchingLayers(trayLayerMask)) return true;
        else return false;
    }

    private bool CheckContactedObjectsForStacking()
    {
        List<ContactPoint2D> contacts = new List<ContactPoint2D>();
        int contactCount = rb.GetContacts(contacts);

        foreach (var contact in contacts)
        {
            Breakable_ScoreStack component = contact.collider.GetComponentInChildren<Breakable_ScoreStack>();
            if (component != null && component.isStacked) return true;
        }
        return false;
    }
}
