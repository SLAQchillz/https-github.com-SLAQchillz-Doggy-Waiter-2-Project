using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventProcessHandler : MonoBehaviour
{ 
    public List<LinearEventProcess> StartupEventProcessList;
    public bool isEventProcessStarted { get; private set; } = false;
    public bool isCurrentEventComplete { get; private set; } = false;
    private bool isAborted = false;

    public bool isStartupEventProcess = false;

    private void Start()
    {
        if (isStartupEventProcess)
        {
            BeginProcessLogic();
        }
    }

    public void BeginProcessLogic()
    {
        Debug.Log("Linear Event Process started.");
        isEventProcessStarted = true;
        isAborted = false;
        StartCoroutine(ProcessLogic());
    }

    public IEnumerator ProcessLogic()
    {
        try
        {
            foreach (var startupEventProcess in StartupEventProcessList)
            {
                if (isAborted) yield break;

                isCurrentEventComplete = false;

                startupEventProcess.OnComplete.AddListener(() => isCurrentEventComplete = true);
                startupEventProcess.DoThis.Invoke(startupEventProcess.OnComplete);


                yield return new WaitUntil(() => isCurrentEventComplete);

                startupEventProcess.OnComplete.RemoveListener(() => isCurrentEventComplete = true);

                Debug.Log("Process completed.");
            }
        }
        finally
        {
            isEventProcessStarted = false;
            Debug.Log("Linear Event Process done.");
        }
    }

    public void CompleteEventProcessNow()
    {
        isAborted = true;
        Debug.Log("Process aborted.");
    }
}


