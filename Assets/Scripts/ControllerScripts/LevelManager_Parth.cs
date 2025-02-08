using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager_Parth : MonoBehaviour
{
    [SerializeField] float timeRemaining = 60f; // Set the initial time (in seconds)
    [SerializeField] bool isCountingDown = true; // Toggle between countdown and countup
    [SerializeField] TextMeshProUGUI timerText; // Reference to the UI Text element to display the timer

    [SerializeField] bool isLevelRunning = true;

    void Update()
    {
        if (isLevelRunning)
        {
            if (isCountingDown)
            {
                // Countdown logic
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                }
                else
                {
                    timeRemaining = 0;
                    isLevelRunning = false;
                    Debug.Log("Timer has finished!");
                }
            }
            else
            {
                // Countup logic
                timeRemaining += Time.deltaTime;
            }

            // Update the timer display
            DisplayTime(timeRemaining);
        }
        else
        {
            CalculateRating();
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        // Convert time to minutes and seconds
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // Update the UI Text
        if (timerText != null)
        {
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    // Call this method to start or stop the timer
    public void ToggleTimer(bool start)
    {
        isLevelRunning = start;
    }

    // Call this method to reset the timer
    public void ResetTimer(float newTime)
    {
        timeRemaining = newTime;
        isLevelRunning = true;
    }

    void CalculateRating()
    {
        if (timeRemaining < 120)
        {
            Debug.Log("A");
        }
        else if (timeRemaining < 240)
        {
            Debug.Log("B");
        }
        else if (timeRemaining < 360)
        {
            Debug.Log("C");
        }
        else
        {
            Debug.Log("D");
        }
    }
}