using System.Collections.Generic;
using UnityEngine;

public class MoveObjectsToPointsProcess : SingleEventProcess
{
    public ObjectTracker objectTracker;
    public Transform[] movePoints;
    public Transform newParent;

    public bool isRandomMove;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        List<GameObject> objectsToMove = objectTracker.MyObjectList;

        if (isRandomMove)
        {
            // Move objects to random points
            foreach (GameObject obj in objectsToMove)
            {
                int randomIndex = Random.Range(0, movePoints.Length);
                obj.transform.position = movePoints[randomIndex].position;
                obj.transform.parent = newParent;
            }
        }
        else
        {
            // Move objects to points iteratively
            for (int i = 0; i < objectsToMove.Count; i++)
            {
                int pointIndex = i % movePoints.Length; // Loop back to the start if there are more objects than points
                objectsToMove[i].transform.position = movePoints[pointIndex].position;
                objectsToMove[i].transform.parent = newParent;
            }
        }
    }
}
