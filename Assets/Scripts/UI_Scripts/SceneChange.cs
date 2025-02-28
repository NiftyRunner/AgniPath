using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad;

    public void LoadSceneFromButton()
    {
        Debug.Log("🚀 Button Clicked! Starting Scene Load.");
        StartCoroutine(LoadSceneWithFix());
    }

    IEnumerator LoadSceneWithFix()
    {
        // Load the scene
        SceneManager.LoadScene(sceneToLoad);
        Debug.Log("📜 Scene Loaded: " + sceneToLoad);

        // Wait for the scene to initialize
        yield return new WaitForSeconds(0.5f);

        // Force Unity to update lighting settings
        Debug.Log("🔆 Updating Lighting...");
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Skybox;
        RenderSettings.ambientLight = Color.white;
        DynamicGI.UpdateEnvironment();
        LightProbes.TetrahedralizeAsync(); // Ensures lighting data is recalculated
        yield return null; // Give Unity time to process lighting

        // Fix camera issues
        yield return null;
        Camera mainCam = Camera.main;
        if (mainCam != null)
        {
            Debug.Log("🎥 Fixing Camera Visibility...");
            mainCam.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            mainCam.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("⚠️ No Main Camera Found!");
        }
    }

    void Start()
    {
        Debug.Log("🎮 Scene Loader Initialized.");
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Skybox;
        RenderSettings.ambientLight = Color.white;
        DynamicGI.UpdateEnvironment();
        LightProbes.TetrahedralizeAsync();
    }
}
