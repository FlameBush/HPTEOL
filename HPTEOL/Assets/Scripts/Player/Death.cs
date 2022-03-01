using UnityEngine;

public class Death : MonoBehaviour
{
    private PlayerStats player;
    [SerializeField] DiedMenuScript diedMenu;
    [SerializeField] EscapeMenuScript escapeMenuScript;
    public Transform SpawningPoint;

    private void Start()
    {
        player = GetComponent<PlayerStats>();
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
        if (collider.tag == "End of World")
        {
            transform.position = SpawningPoint.position;
            player.PlayerTakesDamage(50, false);
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
