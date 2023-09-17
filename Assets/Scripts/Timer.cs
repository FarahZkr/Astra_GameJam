using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public float timeCount;
    public Text timerText;

    void Update()
    {

        if (timeCount > 0)
        {
            timeCount -= Time.deltaTime;
        }
        else
        {
            timeCount = 0;
            SceneManager.LoadScene(sceneName: "BlckOutEnd");
        }
        DisplayTime(timeCount);
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