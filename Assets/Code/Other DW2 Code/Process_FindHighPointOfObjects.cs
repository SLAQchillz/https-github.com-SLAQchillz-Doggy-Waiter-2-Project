using UnityEngine;

public class Process_FindHighPointOfObjects : SingleEventProcess
{
    public ObjectTracker tracker;

    public FloatUnityEvent onHighestPointFound;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        float highestPoint = -6.78f;

        Debug.Log(tracker.GetObjectList().Count + " objects in tracker list.");
        foreach (GameObject go in tracker.GetObjectList())
        {
            Breakable_ScoreStack stacker = go.GetComponentInChildren<Breakable_ScoreStack>();
            if (stacker != null)
            {
                if (!stacker.isStacked) break;
            }
            
            PolygonCollider2D polyCollider = go.GetComponent<PolygonCollider2D>();
            if (polyCollider != null)
            {
                foreach (Vector2 point in polyCollider.points)
                {
                    Vector2 worldPoint = polyCollider.transform.TransformPoint(point);
                    if (worldPoint.y > highestPoint)
                    {
                        highestPoint = worldPoint.y;
                    }
                }
            }
        }
        Debug.Log("Highest point is " + highestPoint);
        onHighestPointFound?.Invoke(highestPoint);
    }
}
