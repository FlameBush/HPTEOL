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
    [Header("Settings")]
    public bool Flying;
    public string[] Animations = { "Moving", "Idle", "Death", "Melee" };

    [HideInInspector] public Transform Player;
    [HideInInspector] public bool DamageTimeout;
    [HideInInspector] public bool DamageTimeoutE;
    [HideInInspector] public float firstSpeed;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Animator animator;
    [HideInInspector] public bool moving;
    private RaycastHit2D Seeing;
    private SpriteRenderer sprite;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        sprite = GetComponent<SpriteRenderer>();
        firstSpeed = moveSpeed;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (Animations[0] == "Moving" || Animations[0] == "Idle")
        {
            animator.Play(Animations[0]);
        }
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

        if (Input.GetKeyDown(KeyCode.F1))
        {
            Debug.Log(animator.GetCurrentAnimatorStateInfo(0).fullPathHash);
        }

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
            Health = 1000;
            Die();
        }
    }

    /// <summary>
    /// This put's the enemy in the roam state where he moves randomly within his bounds.
    /// </summary>
    public virtual void Roam()
    {
        if (sprite.flipX)
        {
            if (Flying)
            {
                rb.MovePosition(Vector2.MoveTowards(transform.position, new Vector2(EndBounds.position.x, transform.position.y + 1), moveSpeed * Time.fixedDeltaTime));
            }
            else
            {
                rb.MovePosition(Vector2.MoveTowards(transform.position, EndBounds.position, moveSpeed * Time.fixedDeltaTime));
            }
            moving = true;
            if (Random.Range(0, 100) < RandomTurnChance)
            {
                sprite.flipX = false;
            }
        }
        else
        {
            if (Flying)
            {
                rb.MovePosition(Vector2.MoveTowards(transform.position, new Vector2(StartBounds.position.x, transform.position.y + 1), moveSpeed * Time.fixedDeltaTime));
            }
            else
            {
                rb.MovePosition(Vector2.MoveTowards(transform.position, StartBounds.position, moveSpeed * Time.fixedDeltaTime));
            }
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
        if (Flying)
        {
            rb.MovePosition(Vector2.MoveTowards(transform.position, new Vector2(Player.position.x, Player.position.y + 1f), moveSpeed * Time.fixedDeltaTime));
        }
        else
        {
            rb.MovePosition(Vector2.MoveTowards(transform.position, new Vector2(Player.position.x, transform.position.y), moveSpeed * Time.fixedDeltaTime));
        }
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
            Destroy(collision.gameObject);
            StartCoroutine(DamageSelf(collision.gameObject.GetComponent<Spell>().damage));
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
            for (int i = 0; i < Animations.Length; i++)
            {
                if (Animations[i] == "Melee")
                {
                    animator.Play(Animations[i]);
                    break;
                }
            }
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

    /// <summary>
    /// Damages own enemy.
    /// </summary>
    /// <returns></returns>
    public virtual IEnumerator DamageSelf(int spelldamage)
    {
        if (!DamageTimeoutE)
        {
            Health -= spelldamage;
            DamageTimeoutE = true;
            yield return new WaitForSeconds(0.5f);
            DamageTimeoutE = false;
        }
    }

    /// <summary>
    /// Makes the enemy die.
    /// </summary>
    /// <returns></returns>
    public virtual void Die()
    {
        for (int i = 0; i < Animations.Length; i++)
        {
            if (Animations[i] == "Death")
            {
                State = -1;
                moving = false;
                moveSpeed = 20;
                animator.Play(Animations[i]);
            }
            else if (Animations[i] == "NoDeath")
            {
                Destroy(gameObject);
            }
        }

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            Destroy(gameObject);
        }
    }
}
