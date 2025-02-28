using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager_Parth : MonoBehaviour
{
    [SerializeField] float timeRemaining = 60f; // Initial time (in seconds)
    [SerializeField] bool isCountingDown = true; // Toggle between countdown and countup
    [SerializeField] TextMeshProUGUI timerText; // UI Text element for timer
    [SerializeField] TextMeshProUGUI resultText;

    public bool isLevelRunning = true;
    bool gradeCalculated = false;

    [SerializeField] bool useTaskCompletion = true; // Uses MCB, Stove, and Rescue counts
    [SerializeField] bool useFireCompletion = false; // Alternative grading based on rescues

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
                timeRemaining += Time.deltaTime;
            }

            DisplayTime(timeRemaining);
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
        if (!isLevelRunning && !gradeCalculated)
        {
            gradeCalculated = true;
            grade = "D"; // Default grade

            if (useTaskCompletion)
            {
                if (mcbCount == 0 && stoveCount == 0 && rescueCount == 0)
                {
                    grade = "D"; // If no tasks were completed
                }
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
                    grade = "D";
                }
            }
            else if (useFireCompletion)
            {
                if (rescueCount >= 2)
                {
                    grade = (timeRemaining <= 180) ? "S" : "A";
                }
                else if (rescueCount == 1)
                {
                    grade = (timeRemaining <= 240) ? "B" : "C";
                }
                else
                {
                    grade = "D"; // No rescues = fail
                }
            }
            else
            {
                if (timeRemaining <= 60) grade = "S";
                else if (timeRemaining <= 120) grade = "A";
                else if (timeRemaining <= 240) grade = "B";
                else if (timeRemaining <= 360) grade = "C";
                else grade = "D";
            }

            Debug.Log("Final Grade: " + grade);
            resultText.text = "Final Grade: " + grade;
            timerText.text = "Your Time: " + FormatTime(timeRemaining);
        }
        return grade;
    }

    void DisplayTime(float timeToDisplay)
    {
        timerText.text = "Your Time: " + FormatTime(timeRemaining);
    }

    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ToggleTimer(bool start) { isLevelRunning = start; }

    public void ResetTimer(float newTime)
    {
        timeRemaining = newTime;
        isLevelRunning = true;
        gradeCalculated = false;
    }
}
