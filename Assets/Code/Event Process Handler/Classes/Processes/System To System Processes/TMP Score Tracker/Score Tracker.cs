using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public int score { get; private set; } = 0;
    public int floatToIntRation = 100;
    public IntUnityEvent onScoreUpdated;

    public void SetScore(int amount)
    {
        score = amount;
        onScoreUpdated.Invoke(score);
    }

    public void SetScore(float amount) { SetScore((int)(amount * floatToIntRation)); }

    public void AddScore(int amount) { SetScore(score += amount); }

    public void IncrementScore()
    {
        score++;
        onScoreUpdated?.Invoke(score);
    }

    public void DecrementScore()
    {
        score--;
        onScoreUpdated?.Invoke(score);
    }

    public void MultiplyScore(int amount)
    {
        score = score * amount;
        onScoreUpdated?.Invoke(score);
    }

    public void MultiplyScore(float amount) { MultiplyScore((int)(amount * floatToIntRation)); }
}
