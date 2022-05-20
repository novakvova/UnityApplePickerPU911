using UnityEngine;

public class AppleTree : MonoBehaviour
{
    // Шаблон яблука, яке буде викидати яблуня
    public GameObject applePrefab;
    // Швидкість переміщення яблуні
    public float speed = 1f;
    // Межі у яких буде рухатися яблуня
    public float leftAndRightEdge = 10f;
    // Імовірність зміни напрямку яблуні
    public float chanceToChangeDirections = 0.1f;
    // Частота скидання яблук
    public float secondBetweenAppleDrops = 1f;
    // Частота скидання яблук
    public float velocity = 0f;
    void Start()
    {
        Invoke("DropApple", 2);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Rigidbody rd = (Rigidbody)apple.GetComponent<Rigidbody>();
        rd.velocity = new Vector3(0, velocity, 0);
        Invoke("DropApple", secondBetweenAppleDrops);
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if (pos.x < -leftAndRightEdge)
            speed = Mathf.Abs(speed);
        else if (pos.x > leftAndRightEdge)
            speed = -Mathf.Abs(speed);
    }

    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}
