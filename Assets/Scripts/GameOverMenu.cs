using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
    }
    public void PlayAgain()
    {

        SceneManager.LoadScene("_Scene_0");
    }
}
