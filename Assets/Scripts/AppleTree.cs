using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    //Ўаблон €блука, €ке буде викидать €блун€
    public GameObject applePrefab;
    //Ўвидк≥сть перем≥щенн€ €блун≥
    public float speed = 1f;
    //ћеж≥ у €ких буде рухатис€ €блун€
    public float leftAndRightEdge = 10f;
    //≤мов≥рн≥сть зм≥ни напр€мку руху €блун≥
    public float chanceToChangeDirections = 0.1f;
    //„астота скиданн€ €блук ≥з €блун≥
    public float secondBetweenAppleDrops = 1f; 
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2);
    }
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if (pos.x < -leftAndRightEdge)
            speed = Mathf.Abs(speed); //рух в право
        else if(pos.x > leftAndRightEdge)
            speed = -Mathf.Abs(speed);
    }

    private void FixedUpdate()
    {
        if(Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}
