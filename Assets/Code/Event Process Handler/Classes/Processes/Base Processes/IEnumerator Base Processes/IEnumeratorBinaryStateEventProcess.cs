using System.Collections;
using UnityEngine;

public class IEnumeratorBinaryStateEventProcess : IEnumeratorEventProcess
{
    public bool isOn = false;

    public override IEnumerator ProcessSpecificOverrideIEnumerator()
    {
        isOn = true;
        while (isOn)
        {
            yield return BinaryOverrideRoutine();
        }
        yield break;
    }

    public virtual IEnumerator BinaryOverrideRoutine()
    {
        yield return null;
    }

    public virtual void TurnOff()
    {
        isOn = false;
    }
}
