using UnityEngine;

public class InstantiatorEventProcess : SingleEventProcess
{
    public GameObject PrefabObject;

    public GameObject ParentObject;
    public Transform[] SpawnPoints;
    public int numberToSpawnPerPoint;

    public GameObjectUnityEvent onObjectInstantiatedObjectEvent;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        foreach (Transform t in SpawnPoints)
        {
            for (int i = 0; i < numberToSpawnPerPoint; i++)
            {
                GameObject NewObject = Instantiate(PrefabObject, t.position, Quaternion.identity);
                NewObject.transform.SetParent(ParentObject.transform);
                ObjectInstantiationOverride(NewObject);
                if (NewObject != null)
                {
                    onObjectInstantiatedObjectEvent?.Invoke(NewObject);
                }
            }
        }
    }

    public virtual void ObjectInstantiationOverride(GameObject NewObject) { }
}
