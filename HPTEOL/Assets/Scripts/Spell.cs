using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    private Rigidbody2D rb2d;
    private Animator bulletAnimtor;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        bulletAnimtor = GetComponent<Animator>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "End of World"
            || collision.collider.tag == "Floor"
            )
        {
            Destroy(gameObject);
        }
    }
}
