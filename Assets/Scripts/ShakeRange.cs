using UnityEngine;

public class ShakeRange : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shake")
        {
            transform.position = collision.transform.position;
        }
    }
}
