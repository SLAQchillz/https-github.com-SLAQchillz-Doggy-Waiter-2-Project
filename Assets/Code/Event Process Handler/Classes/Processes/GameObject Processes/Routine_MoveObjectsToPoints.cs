using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Routine_MoveObjectsToPoints : IEnumeratorEventProcess
{
    public ObjectTracker objectTracker;
    public Transform[] movePoints;
    public Transform newParent;

    public bool isRandomMove;
    public float delayBetweenMoves = 2f;

    public GameObjectUnityEvent OnObjectMoved;

    public override IEnumerator ProcessSpecificOverrideIEnumerator()
    {
        base.ProcessSpecificOverride();

        List<GameObject> objectsToMove = objectTracker.MyObjectList;

        if (isRandomMove)
        {
            foreach (GameObject obj in objectsToMove)
            {
                int randomIndex = Random.Range(0, movePoints.Length);
                obj.transform.position = movePoints[randomIndex].position;
                if (newParent != null) { obj.transform.parent = newParent; }
                OnObjectMoved?.Invoke(obj);
                yield return new WaitForSeconds(delayBetweenMoves); 
            }
        }
        else
        {
            for (int i = 0; i < objectsToMove.Count; i++)
            {
                int pointIndex = i % movePoints.Length;
                objectsToMove[i].transform.position = movePoints[pointIndex].position;
                if (newParent != null) { objectsToMove[i].transform.parent = newParent; }
                OnObjectMoved?.Invoke(objectsToMove[i]);
                yield return new WaitForSeconds(delayBetweenMoves); 
            }
        }
    }
}
