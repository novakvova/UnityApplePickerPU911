using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("_Scene_0");
    }

    public void Exit()
    {
        Application.Quit();
    }

}
