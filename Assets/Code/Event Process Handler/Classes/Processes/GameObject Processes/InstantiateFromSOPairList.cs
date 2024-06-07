using UnityEngine;

public class InstantiateFromSOPairList : SingleEventProcess
{
    public SO_GameObjectIntPairList list;

    public GameObject ParentObject;
    public Transform spawnPoint;

    public GameObjectUnityEvent onObjectInstantiatedObjectEvent;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        foreach (SO_GameObjectIntPair pair in list.list) ProcessSO_Pair(pair);
    }

    private void ProcessSO_Pair(SO_GameObjectIntPair pair)
    {
        for (int i = 0; i < pair.pair.number; i++) InstantiateObjectAtPoint(pair.pair.prefab);
    }

    private void InstantiateObjectAtPoint(GameObject Prefab)
    {
        GameObject NewObject = Instantiate(Prefab, spawnPoint.position, Quaternion.identity);
        NewObject.transform.SetParent(ParentObject.transform);
        ObjectInstantiationOverride(NewObject);
        if (NewObject != null) { onObjectInstantiatedObjectEvent.Invoke(NewObject); }
    }

    public virtual void ObjectInstantiationOverride(GameObject NewObject) { }
}
