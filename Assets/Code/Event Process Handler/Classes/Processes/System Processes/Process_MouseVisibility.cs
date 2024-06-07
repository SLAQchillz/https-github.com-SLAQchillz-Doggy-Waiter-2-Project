using UnityEngine;

public class Process_MouseVisibility : SingleEventProcess
{
    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        Cursor.visible = (!Cursor.visible);
    }
}
