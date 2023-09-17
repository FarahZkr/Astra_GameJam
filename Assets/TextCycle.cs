using System.Collections;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;
public class TextCycle : MonoBehaviour
{
    public TextMeshProUGUI[] textMeshPros;
    public float fadeInDuration = 2.0f;
    private int currentIndex = 0;
    private bool isFading = false;
    private float currentAlpha = 0.0f;
    public string nextLvlName;
    void Start()
    {
        // Ensure all TextMeshPro objects are initially invisible
        foreach (var textMeshPro in textMeshPros)
        {
            textMeshPro.alpha = 0;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isFading)
        {
            if(currentIndex < textMeshPros.Length)
                StartCoroutine(FadeInText());
            else
            {
                SceneManager.LoadScene("Level2");
            }
        }
    }

    IEnumerator FadeInText()
    {
        isFading = true;
        float timer = 0.0f;
        TextMeshProUGUI currentText = textMeshPros[currentIndex];

        while (timer < fadeInDuration)
        {
            currentAlpha = Mathf.Lerp(0.0f, 1.0f, timer / fadeInDuration);
            currentText.alpha = currentAlpha;

            timer += Time.deltaTime;
            yield return null;
        }

        currentText.alpha = 1.0f;
        currentIndex = (currentIndex + 1); // Move to the next TextMeshPro
        isFading = false;
    }
}
