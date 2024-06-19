using UnityEngine;
using System.Collections;

public class Tray_OnFirstStack : MonoBehaviour
{
    public Material trayMaterial;
    public float defaultHeight;
    public float maxHeight;
    public float defaultAlpha;
    public float maxAlpha;
    public float mainDuration = 2;
    public float lerpUpDuration = 0.5f;
    public float timer = 0f;

    private void Start()
    {
        trayMaterial.SetFloat("_HeightMask", defaultHeight);
        trayMaterial.SetFloat("_TotalAlpha", defaultAlpha);
    }

    public void AcceptFirstStack()
    {
        bool newCycle = (timer <= 0f);
        timer = mainDuration;
        if (newCycle) StartCoroutine(EffectRoutine());
    }

    private IEnumerator EffectRoutine()
    {
        StartCoroutine(LerpUp());
        StartCoroutine(FadeIn());
        yield return new WaitForSeconds(lerpUpDuration);

        float alphaLerp = Mathf.InverseLerp(mainDuration, 0f, timer);

        while (timer > 0f) 
        {
            timer -= Time.deltaTime;
            alphaLerp = Mathf.InverseLerp(mainDuration, 0f, timer);
            trayMaterial.SetFloat("_TotalAlpha", Mathf.Lerp(maxAlpha, defaultAlpha, alphaLerp));
            yield return null;
        }

    }

    private IEnumerator LerpUp()
    {
        float currentHeight = trayMaterial.GetFloat("_HeightMask");
        float timeElapsed = 0f;

        while (timeElapsed < lerpUpDuration)
        {
            timeElapsed += Time.deltaTime;
            float heightLerp = Mathf.Lerp(currentHeight, maxHeight, timeElapsed / lerpUpDuration);
            trayMaterial.SetFloat("_HeightMask", heightLerp);
            yield return null;
        }
    }

    private IEnumerator FadeIn()
    {
        float currentAlpha = trayMaterial.GetFloat("_TotalAlpha");
        float timeElapsed = 0f;

        while (timeElapsed < lerpUpDuration)
        {
            timeElapsed += Time.deltaTime;
            float alphaLerp = Mathf.Lerp(currentAlpha, maxAlpha, timeElapsed / lerpUpDuration);
            trayMaterial.SetFloat("_TotalAlpha", alphaLerp);
            yield return null;
        }
    }
}
