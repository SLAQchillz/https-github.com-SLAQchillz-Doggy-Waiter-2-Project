using UnityEngine;
using System.Collections.Generic;

public class Process_ToggleColliders2D : SingleEventProcess
{
    public List<Collider2D> colliders;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        foreach (var collider in colliders)
        {
            collider.enabled = !collider.enabled;
        }
    }
}
