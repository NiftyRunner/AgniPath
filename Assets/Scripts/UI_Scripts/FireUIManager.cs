using UnityEngine;
using TMPro;

public class FireUIManager : MonoBehaviour
{
    [SerializeField] private GameObject currentUICanvas; // Assign the current active UI Canvas
    [SerializeField] private GameObject newUICanvas; // Assign the disabled UI Canvas (already in the Hierarchy)
    [SerializeField] private int requiredFireCount; // The count at which UI should change
    [SerializeField] private TextMeshProUGUI fireCountText; // Reference to the UI Text

    private void Update()
    {
        if (ExtinguishFire.fireCount >= requiredFireCount)
        {
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
