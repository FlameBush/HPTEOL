using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 20f;
    Rigidbody2D rb2d;
    Animator bulletAnimtor;
    SpriteRenderer sprite;
    bool collision = false;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        bulletAnimtor = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d.velocity = transform.right * speed;
    }

    private void Update()
    {

    }
}
