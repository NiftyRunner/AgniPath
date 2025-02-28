using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CollisionUISceneChanger : MonoBehaviour
{
    [SerializeField] private GameObject uiCanvas; // Assign the UI Canvas (Initially Disabled)
    [SerializeField] private string sceneToLoad; // Name of the scene to load
    [SerializeField] private float uiDisplayTime = 10f; // Time UI stays on screen

    private bool uiActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!uiActivated) // Ensures UI only activates once
        {
            uiActivated = true;
            StartCoroutine(ShowUIAndChangeScene());
        }
    }

    IEnumerator ShowUIAndChangeScene()
    {
        if (uiCanvas != null)
        {
            uiCanvas.SetActive(true); // Activate UI
            Debug.Log("📜 UI Activated! Waiting for " + uiDisplayTime + " seconds...");

            yield return new WaitForSeconds(uiDisplayTime); // Wait for UI to be displayed

            Debug.Log("🚀 Changing scene to: " + sceneToLoad);
            SceneManager.LoadScene(sceneToLoad); // Load the next scene
        }
        else
        {
            Debug.LogError("⚠️ UI Canvas is not assigned in the Inspector!");
        }
    }
}
