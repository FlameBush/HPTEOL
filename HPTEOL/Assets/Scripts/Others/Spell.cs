using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] float speed = 65f;
    public int damage = 50;
    private Rigidbody2D rb2d;
    private Animator bulletAnimtor;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        bulletAnimtor = GetComponent<Animator>();

    }

    void Start()
    {
        rb2d.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "End of World" || collider.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }
}
