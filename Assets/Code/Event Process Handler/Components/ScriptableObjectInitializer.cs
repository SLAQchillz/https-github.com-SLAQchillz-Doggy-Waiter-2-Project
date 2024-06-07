using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectInitializer : SingleEventProcess
{
    public List<ScriptableObject> scriptableObjectList;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        foreach (ISO_Init scriptableObject in scriptableObjectList)
        {
            if (scriptableObject is ISO_Init)
            {
                scriptableObject.SO_Init();
            }
        }
    }
}
