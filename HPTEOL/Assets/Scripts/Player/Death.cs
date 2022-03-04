using UnityEngine;

public class Death : MonoBehaviour
{
    private PlayerStats player;
    private DiedMenu diedMenu;
    private EscapeMenu escapeMenu;
    public Transform SpawningPoint;

    private void Start()
    {
        player = GetComponent<PlayerStats>();
        escapeMenu = GameObject.Find("EscapeMenu").GetComponent<EscapeMenu>();
        diedMenu = GameObject.Find("DiedMenu").GetComponent<DiedMenu>();
    }

    private void Update()
    {
        if (player.PlayersCurrentHealth <= 0)
        {
            PlayerDied();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("End of World"))
        {
            transform.position = SpawningPoint.position;
            player.PlayerTakesDamage(50, false);
        }

        if (collider.CompareTag("EnemySpell"))
        {
            player.PlayerTakesDamage(collider.GetComponent<Spell>().damage, true);
            Destroy(collider.gameObject);
        }
    }

    private void PlayerDied()
    {
        diedMenu.DisplayDiedMenu();
        escapeMenu.PauseGame();
        player.gameObject.SetActive(false);
    }
}
