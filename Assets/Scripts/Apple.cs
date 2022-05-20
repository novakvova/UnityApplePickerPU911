using UnityEngine;

public class Apple : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedWith = collision.gameObject;
        if (collidedWith.tag == "Terrain" && this.tag == "Apple")
        {
            this.gameObject.tag = "Untagged";
            this.gameObject.layer = 10;

            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();

            apScript.AppleDestroyed();
        }
    }
}
