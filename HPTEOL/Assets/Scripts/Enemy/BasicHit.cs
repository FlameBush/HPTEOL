using UnityEngine;
using System.Collections;

public class BasicHit : MonoBehaviour
{

    private bool DamageTimeout;
    private Transform Player;
    [Range(0.000001f, 10f)]
    [SerializeField] float damageTimeout = 0.15f;
    [Range(1, 10)]
    [SerializeField] int attackDamage;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !DamageTimeout)
        {
            StartCoroutine(DamagePlayer());

        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player") && !DamageTimeout)
    //    {
    //        StartCoroutine(DamagePlayer());
    //        addReverseForce();
    //    }
    //}


    public virtual IEnumerator DamagePlayer()
    {
        Player.GetComponent<PlayerStats>().PlayerTakesDamage(attackDamage, true);
        var damage = attackDamage;
        attackDamage = 0;
        DamageTimeout = true;
        addReverseForce();
        yield return new WaitForSeconds(damageTimeout);
        attackDamage = damage;
        DamageTimeout = false;
    }

    [SerializeField] float backForce;
    public void addReverseForce()
    {
        Rigidbody2D rb = Player.GetComponent<Rigidbody2D>();
        //Vector2 dir = transform.position - Player.position; 
        Player.GetComponent<Rigidbody2D>().AddRelativeForce(Player.transform.up * backForce,ForceMode2D.Impulse);
    }
}
