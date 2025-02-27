using UnityEngine;

public class DestroyUICanvas : MonoBehaviour
{
    // Reference to the Canvas GameObject
    public GameObject canvasToDestroy;

    // Method to destroy the canvas
    public void DestroyCanvas()
    {
        if (canvasToDestroy != null)
        {
            Destroy(canvasToDestroy);
        }
        else
        {
            Debug.LogWarning("No canvas assigned to destroy!");
        }
    }
}