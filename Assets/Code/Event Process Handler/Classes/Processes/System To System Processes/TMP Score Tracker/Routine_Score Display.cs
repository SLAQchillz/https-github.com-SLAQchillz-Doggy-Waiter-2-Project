using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System.Collections;

public class Routine_ScoreDisplay : IEnumeratorEventProcess
{
    public TextMeshProUGUI tmp;
    public float updateDelay = 0.05f;
    private int scoreToDisplay = 0;
    private int targetScore = 0;

    public UnityEvent onIncrement;

    public override IEnumerator ProcessSpecificOverrideIEnumerator()
    {
        while (scoreToDisplay != targetScore)
        {
            if (scoreToDisplay < targetScore)
            {
                scoreToDisplay++;
                tmp.text = scoreToDisplay.ToString();
                onIncrement?.Invoke();
                yield return new WaitForSeconds(updateDelay);
            }
            else if (scoreToDisplay > targetScore)
            {
                scoreToDisplay--;
                tmp.text = scoreToDisplay.ToString();
                onIncrement?.Invoke();
                yield return new WaitForSeconds(updateDelay);
            }
        }

        scoreToDisplay = targetScore;
        tmp.text = scoreToDisplay.ToString();
    }

    public void AcceptNewScore(int value) { targetScore = value; }
}
