using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Process_ScoreDisplay : SingleEventProcess
{
    public TextMeshProUGUI tmp;
    public int scoreToDisplay;
    public UnityEvent onScoreUpdate;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        tmp.text = scoreToDisplay.ToString();
        onScoreUpdate?.Invoke();
    }

    public void AcceptNewScore(int value) { scoreToDisplay = value; }
}
