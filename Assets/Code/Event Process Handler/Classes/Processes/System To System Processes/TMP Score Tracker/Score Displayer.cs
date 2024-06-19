using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System.Collections;

public class ScoreDisplayer : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public float updateDelay = 0.05f;
    private int scoreToDisplay;
    private int targetScore;
    private bool isUpdating;
    public UnityEvent onIncrement;

    public void UpdateScoreDisplay(int newScore)
    {
        targetScore = newScore;
        if (isUpdating) return;
        StartCoroutine(SmoothScoreChange());
    }

    private IEnumerator SmoothScoreChange()
    {
        isUpdating = true;

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
        isUpdating = false; 
    }
}
