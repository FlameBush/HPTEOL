using UnityEngine;

public class Death : MonoBehaviour
{
    private PlayerStats player;
    private DiedMenuScript diedMenu;
    private EscapeMenuScript escapeMenuScript;
    public Transform SpawningPoint;

    private void Start()
    {
        player = GetComponent<PlayerStats>();
        if (GameObject.Find("GameManager"))
        {
            escapeMenuScript = GameObject.Find("GameManager").GetComponent<EscapeMenuScript>();
            diedMenu = GameObject.Find("GameManager").GetComponent<DiedMenuScript>();
        } else
        {
            Debug.LogWarning("Game Manager was not found certain functions may not work ignore this error or start from main menu!");
        }
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
        player.gameObject.SetActive(false);
        if (diedMenu != null && escapeMenuScript != null)
        {
            diedMenu.DisplayDiedMenu();
            escapeMenuScript.PauseGame();
        }
    }
}
