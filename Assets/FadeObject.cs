using System.Collections;
using UnityEngine;

public class FadeObject : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float timer; // Set the initial time (in seconds)
    private float startAlpha;
    private float timeElapsed = 0.0f;
    private bool isFading = false;
    private float fadeDuration;
    void Start()
    {
        fadeDuration = timer;
        // Get the Sprite Renderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        // Record the initial alpha value
        startAlpha = spriteRenderer.color.a;

        // Start the fading coroutine
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        isFading = true;

        while (timeElapsed < fadeDuration)
        {
            // Calculate the new alpha value based on the time elapsed
            float newAlpha = Mathf.Lerp(startAlpha, 0.0f, timeElapsed / timer);

            // Create a new color with the updated alpha value
            Color newColor = spriteRenderer.color;
            newColor.a = newAlpha;

            // Assign the new color to the material
            spriteRenderer.color = newColor;

            // Increment the time elapsed
            timeElapsed += Time.deltaTime;

            yield return null; // Wait for the next frame
        }

        // Ensure the final alpha value is exactly 0
        Color finalColor = spriteRenderer.color;
        finalColor.a = 0.0f;
        spriteRenderer.color = finalColor;

        isFading = false;
    }

    void Update()
    {
        // Update the timer (you can replace this with your game's logic)
        timer -= Time.deltaTime;

        // Check if the timer reaches zero and the fading is not in progress
        if (timer <= 0 && !isFading)
        {
            // Start the fading coroutine again
            StartCoroutine(FadeOut());
        }
    }
}
