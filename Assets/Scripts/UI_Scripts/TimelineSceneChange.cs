using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using System.Collections;

public class TimelineSceneLoader : MonoBehaviour
{
    public string sceneToLoad;

    public void LoadSceneFromSignal()
    {
        StartCoroutine(LoadSceneWithFix());
    }

    IEnumerator LoadSceneWithFix()
    {
        SceneManager.LoadScene(sceneToLoad);
        yield return new WaitForSeconds(0.1f); // Wait for scene setup
        DynamicGI.UpdateEnvironment(); // Force lighting refresh

        // Ensure the camera is active after the transition
        yield return null;
        Camera mainCam = Camera.main;
        if (mainCam != null)
        {
            mainCam.gameObject.SetActive(false);
            yield return null;
            mainCam.gameObject.SetActive(true);
        }
    }

    void Start()
    {
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Skybox;
        RenderSettings.ambientLight = Color.white;  // Ensures ambient light is applied
        DynamicGI.UpdateEnvironment();  // Updates Global Illumination
    }

}
