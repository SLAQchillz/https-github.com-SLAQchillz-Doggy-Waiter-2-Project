using UnityEngine;

public class Process_DrawTestLine : SingleEventProcess
{
    public float yPosition; 
    public Color lineColor = Color.red; 
    public float lineDuration = 10f; 

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        Vector3 start = new Vector3(-1000, yPosition, 0); 
        Vector3 end = new Vector3(1000, yPosition, 0); 

        Debug.DrawLine(start, end, lineColor, lineDuration);
    }

    public void AcceptYValue(float newValue)
    {
        yPosition = newValue;
    }
}
