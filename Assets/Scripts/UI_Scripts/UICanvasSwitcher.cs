using UnityEngine;

public class UICanvasSwitcher : MonoBehaviour
{
    public GameObject firstCanvas;  // Assign the currently active canvas
    public GameObject secondCanvas; // Assign the disabled canvas in Inspector

    public void SwitchCanvas()
    {
        if (secondCanvas != null)
        {
            secondCanvas.SetActive(true); // Enable the second canvas
            firstCanvas.SetActive(false); // Disable the first canvas
        }
        else
        {
            Debug.LogError("Second Canvas is not assigned!");
        }
    }
}
