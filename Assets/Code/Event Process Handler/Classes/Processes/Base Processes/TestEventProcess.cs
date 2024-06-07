using UnityEngine;

public class TestEventProcess : SingleEventProcess
{
    public string consoleStatement;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        Debug.Log(consoleStatement);
    }
}
