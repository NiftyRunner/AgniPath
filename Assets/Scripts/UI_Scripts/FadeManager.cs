using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public Image fadeImage;
    public float defaultFadeInDuration = 2f;
    public float defaultFadeOutDuration = 2f;
    public float holdDuration = 1f;

    public IEnumerator FadeInOutEffect(float? fadeInSpeed = null, float? fadeOutSpeed = null)
    {
        float fadeInTime = fadeInSpeed ?? defaultFadeInDuration;
        float fadeOutTime = fadeOutSpeed ?? defaultFadeOutDuration;

        yield return Fade(0f, 1f, fadeInTime);
        yield return new WaitForSeconds(holdDuration);
        yield return Fade(1f, 0f, fadeOutTime);
    }

    public void StartFade(float fadeInSpeed, float fadeOutSpeed)
    {
        StartCoroutine(FadeInOutEffect(fadeInSpeed, fadeOutSpeed));
    }

    private IEnumerator Fade(float from, float to, float duration)
    {
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            fadeImage.color = new Color(0, 0, 0, Mathf.Lerp(from, to, t / duration));
            yield return null;
        }
        fadeImage.color = new Color(0, 0, 0, to);
    }
}
