using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    [SerializeField]
    private string _sceneName;
    public void NextScene()
    {
        SceneManager.LoadScene(_sceneName);
    }
    public void NextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
