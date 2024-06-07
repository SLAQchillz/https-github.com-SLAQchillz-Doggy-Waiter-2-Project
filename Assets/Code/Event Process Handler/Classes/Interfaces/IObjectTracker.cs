using System.Collections.Generic;
using UnityEngine;

public interface IObjectTracker
{
    List<GameObject> MyObjectList { get; }

    void AddObjectToList(GameObject NewObject);
}
