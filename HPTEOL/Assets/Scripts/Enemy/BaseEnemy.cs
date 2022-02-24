using UnityEngine;
using System.Collections;

public class BaseEnemy : MonoBehaviour
{
    [Header("Pathfinding")]
    [Range(0f, 100f)]
    [SerializeField] float RandomTurnChance = 2;
    [SerializeField] Transform StartBounds, EndBounds;
    public int State;
    [Header("Base Stats")]
    [Range(1f, 20f)]
    public float moveSpeed = 4;
    [Range(1f, 155f)]
    [SerializeField] int Health = 100;
    [Range(4f, 25f)]
    [SerializeField] int viewDistance = 6;
    [Range(0f, 100f)]
    [SerializeField] int attackDamage = 20;

    [HideInInspector] public Transform Player;
    [HideInInspector] public bool DamageTimeout;
    [HideInInspector] public float firstSpeed;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Animator animator;
    [HideInInspector] public bool moving;
    [HideInInspector] public string Animation = "Moving";
    private RaycastHit2D Seeing;
    private SpriteRenderer sprite;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        sprite = GetComponent<SpriteRenderer>();
        firstSpeed = moveSpeed;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.Play("Moving");
    }

    public virtual void FixedUpdate()
    {
        if (State == 1)
        {
            Target();
        }
        else if (State == 0)
        {
            Roam();
        }
    }

    public virtual void Update()
    {
        Seeing = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), viewDistance, 8);
        if (Seeing.transform != null && Seeing.transform.CompareTag("Player") && State != -1)
        {
            State = 1;
        }

        if (moveSpeed == 0)
        {
            moving = false;
        }

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
        if (sprite.flipX)
        {
            rb.MovePosition(Vector2.MoveTowards(transform.position, EndBounds.position, moveSpeed * Time.fixedDeltaTime));
            moving = true;
            if (Random.Range(0, 100) < RandomTurnChance)
            {
                sprite.flipX = false;
            }
        }
        else
        {
            rb.MovePosition(Vector2.MoveTowards(transform.position, StartBounds.position, moveSpeed * Time.fixedDeltaTime));
            moving = true;
            if (Random.Range(0, 100) < RandomTurnChance)
            {
                sprite.flipX = true;
            }
        }
    }

    /// <summary>
    /// This put's the enemy in the state where he target's the player.
    /// </summary>
    public virtual void Target()
    {
        rb.MovePosition(Vector2.MoveTowards(transform.position, new Vector2(Player.position.x, transform.position.y), moveSpeed * Time.fixedDeltaTime));
        moving = true;
        if (Player.position.x > transform.position.x)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyEndOfWorld"))
        {
            if (sprite.flipX && State == 0)
            {
                sprite.flipX = false;
            }
            else if (State == 0)
            {
                sprite.flipX = true;
            }
        }

        if (collision.CompareTag("Spell"))
        {
            Health -= collision.GetComponent<Spell>().damage;
            Destroy(collision.gameObject);
        }
    }

    public virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !DamageTimeout)
        {
            StartCoroutine(DamagePlayer());
        }
    }

    /// <summary>
    /// Damages the player and has a damage cooldown starts melee animation and other stuff.
    /// </summary>
    /// <returns></returns>
    public virtual IEnumerator DamagePlayer()
    {
        if (!DamageTimeout)
        {
            Player.GetComponent<PlayerStats>().PlayerTakesDamage(attackDamage);
            moving = false;
            animator.Play("Melee");
            var damage = attackDamage;
            moveSpeed = 0;
            attackDamage = 0;
            DamageTimeout = true;
            yield return new WaitForSeconds(0.5f);
            moveSpeed = firstSpeed;
            yield return new WaitForSeconds(0.5f);
            attackDamage = damage;
            DamageTimeout = false;
        }
    }
}
