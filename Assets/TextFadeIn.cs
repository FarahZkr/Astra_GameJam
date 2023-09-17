using System.Collections;
using UnityEngine;
using TMPro;

public class TextFadeIn : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float fadeInDuration = 2.0f;
    private bool isFading = false;
    private float currentAlpha = 0.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isFading)
        {
            StartCoroutine(FadeInText());
        }
    }

    IEnumerator FadeInText()
    {
        isFading = true;
        float timer = 0.0f;

        while (timer < fadeInDuration)
        {
            currentAlpha = Mathf.Lerp(0.0f, 1.0f, timer / fadeInDuration);
            textMeshPro.color = new Color(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b, currentAlpha);

            timer += Time.deltaTime;
            yield return null;
        }

        isFading = false;
    }
}
