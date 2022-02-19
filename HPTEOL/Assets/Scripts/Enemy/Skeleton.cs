using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    BoxCollider2D canSeePlayer;

    [SerializeField] private float skeletonSpeed = 60f;
    Rigidbody2D rb2d;

    void Awake()
    {
        canSeePlayer = GetComponentInChildren<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
    }


    public void SkeletonWalk ()
    {
        rb2d.velocity = new Vector2(-skeletonSpeed, 0) * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        SkeletonWalk();
    }

}
