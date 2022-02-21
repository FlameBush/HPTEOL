using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [Range(0f,100f)]
    [SerializeField] int damage;


    PlayerStats ps;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ps = collision.gameObject.GetComponent<PlayerStats>();
        if (ps != null)
        {
            ps.PlayerTakesDamage(damage);
        }
    }


}
