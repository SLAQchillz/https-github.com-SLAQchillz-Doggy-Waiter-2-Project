using TMPro;
using UnityEngine;
using System.Collections;

public class Behaviour_TextSquashRoutine : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public float sizeChange;
    public float duration = 0.5f;
    private float originalSize;

    private void Awake()
    {
        originalSize = tmp.fontSize;
    }

    public void StartTextSquash()
    {
        tmp.fontSize = originalSize + sizeChange;
        //StopAllCoroutines();
        StartCoroutine(TextSquashRoutine());
    }

    public IEnumerator TextSquashRoutine()
    {
        // Capture the new size
        float newSize = tmp.fontSize;
        // Calculate the time when this routine started
        float startTime = Time.time;

        while (Time.time - startTime < duration)
        {
            // Calculate the progress ratio
            float progress = (Time.time - startTime) / duration;
            // Lerp the font size from newSize back to originalSize
            tmp.fontSize = Mathf.Lerp(newSize, originalSize, progress);
            // Yield until the next frame
            yield return null;
        }

        // Ensure the font size is set to the original size after the duration
        tmp.fontSize = originalSize;
    }
}
