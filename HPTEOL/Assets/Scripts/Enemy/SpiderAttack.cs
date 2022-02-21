using UnityEngine;

public class SpiderAttack : MonoBehaviour
{
    [Range(0f,100f)]
    [SerializeField] int damage;


    PlayerStats ps;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name + " ");
        ps = collision.gameObject.GetComponent<PlayerStats>();
        if (ps != null)
        {
            Debug.Log("giving Damage");
            ps.PlayerTakesDamage(damage);
        }
    }


}
