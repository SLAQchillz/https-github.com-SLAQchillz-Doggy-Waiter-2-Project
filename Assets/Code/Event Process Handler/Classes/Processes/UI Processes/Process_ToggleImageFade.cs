using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Process_ToggleImageFade : IEnumeratorEventProcess
{
    public Image image;
    public float duration = 3f;
    public float elapsedTime = 0f;

    public override IEnumerator ProcessSpecificOverrideIEnumerator()
    {
        float startingAlpha = image.color.a;
        float targetAlpha;
        elapsedTime = 0f;
        if (startingAlpha != 0) targetAlpha = 0;
        else targetAlpha = 1;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startingAlpha, targetAlpha, elapsedTime / duration);
            image.color = new Color(image.color.r, image.color.g, image.color.b, newAlpha);
            yield return null;
        }

        image.color = new Color(image.color.r, image.color.g, image.color.b, targetAlpha);
    }
}
