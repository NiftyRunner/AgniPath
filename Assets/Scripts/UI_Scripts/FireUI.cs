using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // Required for scene loading

public class FireUI : MonoBehaviour
{
    [SerializeField] GameObject uiPanel1; // Assign in Inspector
    [SerializeField] GameObject uiPanel2; // Assign in Inspector
    [SerializeField] float delayBeforeUI = 5f; // Delay before UI appears
    [SerializeField] float delayBeforeSceneChange = 5f; // Delay before scene transition
    [SerializeField] string sceneToLoad; // Assign the scene name in Inspector

    private bool uiSpawned = false;

    private void Update()
    {
        if (!uiSpawned && ExtinguishFire.fireCount >= 16)
        {
            uiSpawned = true; // Prevent multiple triggers
            StartCoroutine(ShowUIPanelsAndChangeScene());
        }
    }

    IEnumerator ShowUIPanelsAndChangeScene()
    {
        // Wait before showing the UI panels
        yield return new WaitForSeconds(delayBeforeUI);

        if (uiPanel1 != null) uiPanel1.SetActive(true);
        if (uiPanel2 != null) uiPanel2.SetActive(true);

        // Wait before changing the scene
        yield return new WaitForSeconds(delayBeforeSceneChange);

        // Load the assigned scene
        SceneManager.LoadScene(sceneToLoad);
    }
}
