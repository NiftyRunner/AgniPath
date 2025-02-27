using UnityEngine;
using TMPro;

public class FireUIManager : MonoBehaviour
{
    [SerializeField] private GameObject currentUICanvas; // Assign the current UI Canvas
    [SerializeField] private GameObject newUICanvasPrefab; // Assign the new UI Canvas prefab
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
        if (newUICanvasPrefab != null)
        {
            // Spawn the new UI Canvas
            GameObject newUICanvas = Instantiate(newUICanvasPrefab);
            newUICanvas.SetActive(true);

            // Destroy the current UI Canvas
            if (currentUICanvas != null)
            {
                Destroy(currentUICanvas);
            }
        }
        else
        {
            Debug.LogError("New UI Canvas Prefab is not assigned!");
        }
    }
}
