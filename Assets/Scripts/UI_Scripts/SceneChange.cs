using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string sceneName; // Assign this in the Inspector

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
