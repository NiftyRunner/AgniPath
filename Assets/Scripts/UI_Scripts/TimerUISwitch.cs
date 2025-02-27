using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject currentCanvas; // Assign the active canvas
    [SerializeField] private GameObject newCanvas; // Assign the disabled canvas in the Hierarchy

    private void Start()
    {
        Invoke("SwitchCanvas", 5f); // Call SwitchCanvas after 5 seconds
    }

    void SwitchCanvas()
    {
        if (newCanvas != null)
        {
            newCanvas.SetActive(true); // Enable the new canvas
        }
        else
        {
            Debug.LogError("New Canvas reference is not assigned!");
        }

        if (currentCanvas != null)
        {
            Destroy(currentCanvas); // Destroy the current canvas
        }
        else
        {
            Debug.LogError("Current Canvas reference is not assigned!");
        }
    }
}
