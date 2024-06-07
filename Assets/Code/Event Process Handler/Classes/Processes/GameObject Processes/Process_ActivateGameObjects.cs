using UnityEngine;
using System.Collections.Generic;

public class Process_ActivateGameObjects : SingleEventProcess
{
    public List<GameObject> goList;
    public bool isTurnOn;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        foreach (GameObject go in goList)
        {
            go.SetActive(isTurnOn);
        }
    }
}
