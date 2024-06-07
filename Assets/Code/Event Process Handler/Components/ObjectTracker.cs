using System.Collections.Generic;
using UnityEngine;

public class ObjectTracker : MonoBehaviour, IObjectTracker
{
    public List<GameObject> MyObjectList { get; } = new List<GameObject>();

    public void AddObjectToList(GameObject NewObject)
    {
        if (!MyObjectList.Contains(NewObject))
        {
            MyObjectList.Add(NewObject);
        }
    }
}
