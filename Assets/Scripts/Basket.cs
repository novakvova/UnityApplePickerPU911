using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;
    public int pointNumber = 100;

    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");

        scoreGT = scoreGO.GetComponent<Text>();

        scoreGT.text = "0";
    }
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);

            int score = int.Parse(scoreGT.text);
            score += pointNumber;
            scoreGT.text = score.ToString();

            if (SceneManager.GetActiveScene().name == "_Scene_0" && score == 10000)
                SceneManager.LoadScene("_Scene_1");

            if (SceneManager.GetActiveScene().name == "_Scene_1" && score == 15000)
                SceneManager.LoadScene("_Scene_InfinityLevel");


            if (SceneManager.GetActiveScene().name == "_Scene_InfinityLevel" && score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
