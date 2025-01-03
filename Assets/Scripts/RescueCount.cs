using UnityEngine;
using TMPro;

public class GameObjectDestroyCounter : MonoBehaviour
{
    public static GameObjectDestroyCounter Instance; // Singleton for easy access

    [SerializeField] private TextMeshProUGUI destroyedCountText; // Reference to the Text UI element
    private int destroyedCount;

    private void Awake()
    {
        // Ensure there is only one instance of this script
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
        destroyedCount = 0;
        UpdateUI();
    }

    public void IncrementDestroyedCount()
    {
        destroyedCount++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (destroyedCountText != null)
        {
            destroyedCountText.text = $"Destroyed: {destroyedCount}";
        }
    }
}
