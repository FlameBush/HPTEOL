using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [Header("Stats")]
    [Range(1f, 20f)]
    [SerializeField] float moveSpeed = 4;
    [Range(1f, 155f)]
    [SerializeField] int Health = 100;
    [Range(4f, 25f)]
    [SerializeField] int viewDistance = 6;
    [Range(0f, 100f)]
    [SerializeField] int attackDamage = 20;
    [Header("Pathfinding")]
    [Range(0f, 100f)]
    [SerializeField] float RandomTurnChance = 2;
    [SerializeField] Transform StartBounds, EndBounds;

    private bool MoveRight;
    private GameObject Player;
    private bool DamageTimeout;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    private void FixedUpdate()
    {
        RaycastHit2D Eyes = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), viewDistance);
        if (Eyes.transform.CompareTag("Player"))
        {
            Debug.Log("Player seen");
            Target();
        }
        else if (groundCheck())
        {
            Roam();
        }
    }

    private void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// This put's the enemy in the roam state where he moves randomly within his bounds.
    /// </summary>
    public virtual void Roam()
    {
        if (MoveRight)
        {
            transform.position = Vector2.MoveTowards(transform.position, EndBounds.position, moveSpeed * Time.deltaTime);
            if (Random.Range(0, 100) < RandomTurnChance)
            {
                MoveRight = false;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, StartBounds.position, moveSpeed * Time.deltaTime);
            if (Random.Range(0, 100) < RandomTurnChance)
            {
                MoveRight = true;
            }
        }
    }

    /// <summary>
    /// This put's the enemy in the state where he target's the player.
    /// </summary>
    public virtual void Target()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, moveSpeed * Time.deltaTime);
    }

    [SerializeField] private LayerMask m_WhatIsGround;

    /// <summary>
    /// Whether or not the enemy is touching the ground.
    /// </summary>
    /// <returns>True or False depending on if enemy is touching ground</returns>
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
            }
            else
            {
                MoveRight = true;
            }
        }

        if (collision.CompareTag("Spell"))
        {
            Health -= collision.GetComponent<Spell>().damage;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Player") && !DamageTimeout)
        {
            collision.GetComponent<PlayerStats>().PlayerTakesDamage(attackDamage);
            DamageTimeout = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DamageTimeout = false;
        }
    }
}
