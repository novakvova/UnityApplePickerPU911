using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public float basketBottomY = -14f;

    void Start()
    {
        GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
        Vector3 pos = Vector3.zero;
        pos.y = basketBottomY;
        pos.z = -7;

        tBasketGO.transform.position = pos;

    }

    public void AppleDestroyed()
    {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }

        Lives.lives -= 1;

        if (Lives.lives == 0)
        {
            SceneManager.LoadScene("_Scene_GameOver");
        }
    }

}
