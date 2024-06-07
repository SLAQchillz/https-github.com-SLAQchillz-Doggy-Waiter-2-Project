using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public int score { get; private set; } = 0;
    public IntUnityEvent onScoreUpdated;

    public void AddScore(int amount)
    {
        score += amount;
        onScoreUpdated?.Invoke(score);
    }
}
