using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string sceneName; // Assign this in the Inspector

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    void Start()
    {
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Skybox;
        RenderSettings.ambientLight = Color.white;  // Ensures ambient light is applied
        DynamicGI.UpdateEnvironment();  // Updates Global Illumination
    }
}
