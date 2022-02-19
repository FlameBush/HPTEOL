using UnityEngine;
// WIP SCRIPT
public class CanSeePlayerScript : MonoBehaviour
{
    [SerializeField] Skeleton skeleton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("NO");
        }
    }

}
