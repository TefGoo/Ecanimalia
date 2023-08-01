using System.Collections;
using UnityEngine;

public class BackgroundFader : MonoBehaviour
{
    public SpriteRenderer[] backgroundSprites;
    public float fadeDuration = 1.0f;
    public float delayBetweenFades = 2.0f;
    public float fadeInterval = 0.1f;

    private int currentIndex = 0;
    private Coroutine fadeCoroutine;

    private void Start()
    {
        // Set the first background sprite to be active and fully opaque
        for (int i = 0; i < backgroundSprites.Length; i++)
        {
            backgroundSprites[i].gameObject.SetActive(i == currentIndex);
            backgroundSprites[i].color = new Color(1f, 1f, 1f, i == currentIndex ? 1f : 0f);
        }

        // Start the fading process
        StartCoroutine(FadeBackgrounds());
    }

    private IEnumerator FadeBackgrounds()
    {
        while (true)
        {
            // Determine the next background index to show
            int nextIndex = (currentIndex + 1) % backgroundSprites.Length;

            // Start fading out the current background
            fadeCoroutine = StartCoroutine(FadeOut(backgroundSprites[currentIndex]));

            // Immediately start fading in the next background
            StartCoroutine(FadeIn(backgroundSprites[nextIndex]));

            // Wait for the fade interval before fading to the next background
            yield return new WaitForSeconds(fadeInterval);

            // Disable the current background
            backgroundSprites[currentIndex].gameObject.SetActive(false);

            // Update the current index
            currentIndex = nextIndex;
        }
    }

    private IEnumerator FadeOut(SpriteRenderer spriteRenderer)
    {
        float timer = 0f;
        Color startColor = spriteRenderer.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(startColor.a, 0f, timer / fadeDuration);
            spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
    }

    private IEnumerator FadeIn(SpriteRenderer spriteRenderer)
    {
        spriteRenderer.gameObject.SetActive(true);

        float timer = 0f;
        Color startColor = spriteRenderer.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(startColor.a, 1f, timer / fadeDuration);
            spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, 1f);
    }
}
