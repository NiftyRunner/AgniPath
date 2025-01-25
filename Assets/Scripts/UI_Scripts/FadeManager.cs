using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public Image fadeImage; // Reference to the full-screen UI Image for fade
    public float fadeInDuration = 2f; // Time to fade in
    public float fadeOutDuration = 2f; // Time to fade out
    public float holdDuration = 1f; // Time to hold at fully opaque


    public IEnumerator FadeInOutEffect()
    {
        // 1. Fade in (transparent to opaque)
        yield return StartCoroutine(Fade(0f, 1f, fadeInDuration));

        // 2. Hold at fully opaque
        yield return new WaitForSeconds(holdDuration);

        // 3. Fade out (opaque to transparent)
        yield return StartCoroutine(Fade(1f, 0f, fadeOutDuration));
    }

    private IEnumerator Fade(float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0f;
        Color color = fadeImage.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            fadeImage.color = color;
            yield return null;
        }

        color.a = endAlpha; // Ensure the final alpha value is exact
        fadeImage.color = color;
    }
}
