using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager_Parth : MonoBehaviour
{
    [SerializeField] float timeRemaining = 60f; // Set the initial time (in seconds)
    [SerializeField] bool isCountingDown = true; // Toggle between countdown and countup
    [SerializeField] TextMeshProUGUI timerText; // Reference to the UI Text element to display the timer
    [SerializeField] TextMeshProUGUI resultText;

    public bool isLevelRunning = true;
    bool gradeCalculated = false;
    [SerializeField] bool useTaskCompletion = true; // Toggle to use MCB, Stove, and Rescue counts

    int mcbCount;
    int stoveCount;
    int rescueCount;

    string grade;

    private void Start()
    {
        mcbCount = 0;
        stoveCount = 0;
        rescueCount = 0;
    }

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
                // Countup logic (Increase time instead of decreasing)
                timeRemaining += Time.deltaTime;
            }

            // Update the timer display
            DisplayTime(timeRemaining);
            //CalculateResult();
        }
        else
        {
            CalculateResult();
        }
    }

    public void IncreaseMCBCount() { mcbCount++; }
    public void IncreaseStoveCount() { stoveCount++; }
    public void IncreaseRescueCount() { rescueCount++; }

    public string CalculateResult()
    {
        Debug.Log("Calculate Result");
        if (!isLevelRunning && !gradeCalculated)
        {
            gradeCalculated = true;
            grade = "F"; // Default grade

            // If the player didn't interact with anything, give them an F immediately
            
            if (useTaskCompletion)
            {
                if (mcbCount == 0 && stoveCount == 0 && rescueCount == 0)
                {
                    grade = "D";
                }
                // If we consider MCB count, Stove count, and Rescue count
                else if (mcbCount >= 3 && stoveCount >= 2 && rescueCount >= 3)
                {
                    grade = (timeRemaining <= 180) ? "S" : "A";
                }
                else if (mcbCount >= 2 && stoveCount >= 1 && rescueCount >= 2)
                {
                    grade = (timeRemaining <= 240) ? "A" : "B";
                }
                else if (mcbCount >= 1 && stoveCount >= 1 && rescueCount >= 1)
                {
                    grade = (timeRemaining <= 360) ? "B" : "C";
                }
                else
                {
                    grade = "D"; // Poor performance
                }
            }
            else
            {
                // If we only consider time
                if (timeRemaining <= 120) grade = "A";
                else if (timeRemaining <= 240) grade = "B";
                else if (timeRemaining <= 360) grade = "C";
                else grade = "D";
            }

            Debug.Log("Final Grade: " + grade);
            resultText.text = "Final Grade: " + grade;

            // Show formatted final time
            timerText.text = "Your Time: " + FormatTime(timeRemaining);
            //return grade;
        }
        return grade;
    }

    void DisplayTime(float timeToDisplay)
    {
        string gradeToDisplay = CalculateResult();
        resultText.text = "Final Grade: " + CalculateResult();
        timerText.text = "Your Time: " + FormatTime(timeRemaining);
    }

    // Helper method to format time properly
    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Call this method to start or stop the timer
    public void ToggleTimer(bool start) { isLevelRunning = start; }

    // Call this method to reset the timer
    public void ResetTimer(float newTime)
    {
        timeRemaining = newTime;
        isLevelRunning = true;
    }
}
