using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class screenFader : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 1f;

    private void Awake()
    {
        fadeImage = GetComponent<Image>();
    }

    public void StartFadeTransition(System.Action methodToExecute)
    {
        StartCoroutine(FadeTransition(methodToExecute));
    }

    private IEnumerator FadeTransition(System.Action methodToExecute)
    {
        yield return Fade(1);
        methodToExecute?.Invoke();
        yield return Fade(0);
    }

    private IEnumerator Fade(float targetAlpha)
    {
        float startAlpha = fadeImage.color.a;
        float time = 0;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, targetAlpha);
    }
}
