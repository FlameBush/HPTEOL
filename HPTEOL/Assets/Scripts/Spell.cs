using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    private float speed = 65f;
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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "End of World" || collider.tag == "Floor")
        {
            Debug.Log("YES!");
            Destroy(gameObject);
        }
    }
}
