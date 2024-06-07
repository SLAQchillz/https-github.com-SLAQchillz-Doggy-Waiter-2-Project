using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreDisplayer : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public float updateDelay = 0.05f;
    private int scoreToDisplay;

    public void UpdateScoreDisplay(int newScore)
    {
        StartCoroutine(SmoothScoreChange(newScore));
    }

    private IEnumerator SmoothScoreChange(int targetScore)
    {
        while (scoreToDisplay < targetScore)
        {
            scoreToDisplay++;
            tmp.text = scoreToDisplay.ToString();
            yield return new WaitForSeconds(updateDelay);
        }
    }
}
