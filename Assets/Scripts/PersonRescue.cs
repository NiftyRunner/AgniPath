using UnityEngine;
using TMPro;

public class PersonRescue : MonoBehaviour
{
    public static PersonRescue Instance; // Singleton for global access

    [SerializeField] private TextMeshProUGUI destroyedCountText; // Reference to the UI text
    private int destroyedCount;

    private void Awake()
    {
        // Ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        destroyedCount = 0; // Initialize count to 0
        UpdateUI(); // Display the initial count on the UI
    }

    public void IncrementDestroyedCount()
    {
        destroyedCount++; // Increment the count
        UpdateUI(); // Update the displayed value
    }

    private void UpdateUI()
    {
        if (destroyedCountText != null)
        {
            destroyedCountText.text = destroyedCount.ToString(); // Display only the count (starting from 0)
        }
    }
}
