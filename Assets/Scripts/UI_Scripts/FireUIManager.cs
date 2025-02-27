using UnityEngine;
using TMPro;

public class FireUIManager : MonoBehaviour
{
    [SerializeField] private GameObject currentUICanvas; // Assign the current active UI Canvas
    [SerializeField] private GameObject newUICanvas; // Assign the disabled UI Canvas (already in the Hierarchy)
    [SerializeField] private int requiredFireCount; // The count at which UI should change
    [SerializeField] private TextMeshProUGUI fireCountText; // Reference to the UI Text
    [SerializeField] Canvas finalCanavs; //Added a ref for final result canvas
    [SerializeField] LevelManager_Parth levelManager; //Added ref for level manager

    private void Start()
    {
        finalCanavs.enabled = false;
    }

    private void Update()
    {
        if (ExtinguishFire.fireCount >= requiredFireCount)
        {
            levelManager.isLevelRunning = false; //Set level running to false after all fire extinguish (only for a ref to level manager to call result canvas)
            finalCanavs.enabled = true; //enables the final canavs
            SwitchUI();
        }
    }

    void SwitchUI()
    {
        if (newUICanvas != null)
        {
            newUICanvas.SetActive(true); // Enable the new UI Canvas
        }
        else
        {
            Debug.LogError("New UI Canvas reference is not assigned!");
        }

        if (currentUICanvas != null)
        {
            Destroy(currentUICanvas); // Destroy the current UI Canvas
        }
        else
        {
            Debug.LogError("Current UI Canvas reference is not assigned!");
        }
    }
}
