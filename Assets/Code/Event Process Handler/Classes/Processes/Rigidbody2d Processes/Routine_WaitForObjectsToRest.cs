using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Routine_WaitForObjectsToRest : IEnumeratorEventProcess
{
    public SO_CoreRules rules;
    public ObjectTracker tracker;

    public override IEnumerator ProcessSpecificOverrideIEnumerator()
    {
        List<GameObject> objects = tracker.MyObjectList;
        List<GameObject> movingObjects = CheckAndReturnMoving(objects);
        while (movingObjects.Count > 0)
        {
            movingObjects = CheckAndReturnMoving(objects);
            yield return new WaitForSeconds(0.1f);
        }

    }

    private List<GameObject> CheckAndReturnMoving(List<GameObject> objects)
    {
        List<GameObject> movingObjects = new();
        foreach (GameObject obj in objects)
        {
            if (CheckVelocity(obj)) movingObjects.Add(obj);
        }
        return movingObjects;
    }

    private bool CheckVelocity(GameObject go)
    {
        Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
        if (rb.velocity.sqrMagnitude > rules.rules.stacking_RestVelocity) return true;
        else return false;
    }
}
