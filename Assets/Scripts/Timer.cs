using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float timer = 0f;
    private float decreasingTimer = 960f; // 16 minutes in seconds
    private bool isTimerRunning = false;
    private Text timerText; // Reference to the Text element in the UI.

    // Singleton instance to ensure there's only one timer throughout the game.
    public static Timer Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make the GameObject persist across scenes.
        }
        else
        {
            Destroy(gameObject); // Destroy any duplicate instances.
        }
        StartTimer();
        timerText = GameObject.Find("TimerText").GetComponent<Text>();
        UpdateTimerUI(); // Initialize the UI with the starting time.
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            decreasingTimer -= Time.deltaTime;
            timer = 960f - decreasingTimer; // Calculate elapsed time

            if (decreasingTimer <= 0f)
            {
                decreasingTimer = 0f;
                isTimerRunning = false;
            }

            UpdateTimerUI(); // Update the UI Text element.
        }
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public float GetElapsedTime()
    {
        return timer;
    }

    public void ResetTimer()
    {
        timer = 0f;
        decreasingTimer = 960f; // Reset to 16 minutes
        UpdateTimerUI(); // Update the UI Text element when resetting.
    }

    private void UpdateTimerUI()
    {
        // Convert decreasingTimer to minutes and seconds for display.
        int minutes = Mathf.FloorToInt(decreasingTimer / 60);
        int seconds = Mathf.FloorToInt(decreasingTimer % 60);
        string timeText = string.Format("Timer: {0:D2}:{1:D2}", minutes, seconds);

        // Update the Text element with the timer value.
        timerText.text = timeText;
    }
}
