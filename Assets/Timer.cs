using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float timeCount;
    public Text timerText;
    private float totalDuration;
    private float elapsedTime = 0.0f;
    private float percentageRemaining = 100.0f;
    public GameObject player;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        totalDuration = timeCount;
        spriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        percentageRemaining = Mathf.Max(0.0f, 100.0f - (elapsedTime / totalDuration) * 100.0f);

        if (timeCount > 0)
        {
            timeCount -= Time.deltaTime;
        }
        else
        {
            timeCount = 0;
        }
        DisplayTime(timeCount);
        if (spriteRenderer != null)
        {
            Color spriteColor = spriteRenderer.material.color;
            spriteColor.a = percentageRemaining; // Set the alpha component.
            spriteRenderer.material.color = spriteColor;
        }
        else
        {
            Debug.Log("HELLLOOOOOOOOO");
        }
        Debug.Log(percentageRemaining);
    }

    void DisplayTime(float TimeToDisplay)
    {
        if (TimeToDisplay < 0)
        {
            TimeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(TimeToDisplay / 60);
        float seconds = Mathf.FloorToInt(TimeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}