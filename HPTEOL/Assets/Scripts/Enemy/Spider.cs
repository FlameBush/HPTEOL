using UnityEngine;

public class Spider : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Transform StartBounds, EndBounds;

    private bool MoveRight;
    private GameObject Player;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    private void FixedUpdate()
    {
        if (groundCheck())
        {
            Roam();
        }
    }

    /// <summary>
    /// This put's the spider in the roam state where he moves randomly within his bounds.
    /// </summary>
    private void Roam()
    {
        if (MoveRight)
        {
            transform.position = Vector2.MoveTowards(transform.position, EndBounds.position, moveSpeed * Time.deltaTime);
            if (Random.Range(0, 100) > 98)
            {
                MoveRight = false;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, StartBounds.position, moveSpeed * Time.deltaTime);
            if (Random.Range(0, 100) > 98)
            {
                MoveRight = true;
            }
        }
    }

    /// <summary>
    /// This put's the spider in the state where he target's the player.
    /// </summary>
    private void Target()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, moveSpeed * Time.deltaTime);
    }

    [SerializeField] private LayerMask m_WhatIsGround;

    /// <summary>
    /// Whether or not the spider is touching the ground.
    /// </summary>
    /// <returns>True or False depending on if spider is touching ground</returns>
    private bool groundCheck()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, 0.1f, m_WhatIsGround);
        if (collider != null)
        {
            return true;
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyEndOfWorld"))
        {
            if (MoveRight)
            {
                MoveRight = false;
            } else
            {
                MoveRight = true;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}
