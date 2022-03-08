using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public static Vector2 CheckPointPosition;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CheckPointPosition = transform.position;
        }
    }
}
