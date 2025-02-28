using UnityEngine;

public class UICanvasSwitcher : MonoBehaviour
{
    public GameObject firstCanvas;  // Assign the currently active canvas
    public GameObject secondCanvas; // Assign the disabled canvas in Inspector
    //[SerializeField] LevelManager_Parth levelManager;

    void Update()
    {
        if (ExtinguishFire.fireCount == 16) // Check if fireCount reaches 16
        {
            SwitchCanvas();
            //levelManager.isLevelRunning = false;
        }
    }

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
