using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class IEnumeratorEventCoprocessor : IEnumeratorEventProcess
{
    public List<LinearEventProcess> CoprocessList;
    public int numberOfEventsToComplete { get; private set; }
    public int numberOfEventsCompleted { get; private set; } = 0;
    private bool isAborted = false;

    public override IEnumerator ProcessSpecificOverrideIEnumerator()
    {
        Debug.Log("IEnumerator Event Coprocesses started.");
        numberOfEventsToComplete = CoprocessList.Count;
        List<UnityAction> listeners = new List<UnityAction>();

        foreach (var process in CoprocessList)
        {
            UnityAction action = () => numberOfEventsCompleted++;
            listeners.Add(action);
            process.OnComplete.AddListener(action);
            process.DoThis.Invoke(process.OnComplete);
        }

        try
        {
            while (numberOfEventsCompleted < numberOfEventsToComplete)
            {
                yield return null;
            }
        }
        finally
        {
            for (int i = 0; i < CoprocessList.Count; i++)
            {
                CoprocessList[i].OnComplete.RemoveListener(listeners[i]);
            }
            Debug.Log("IEnumerator Event Coprosses ended.");
        }
    }
}
