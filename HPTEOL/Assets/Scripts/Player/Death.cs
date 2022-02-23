using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    private PlayerStats player;
    [SerializeField] DiedMenuScript diedMenu;
    [SerializeField] EscapeMenuScript escapeMenuScript;
    public Transform SpawningPoint;

    private void Awake()
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
            player.PlayerTakesDamage(50);
        }
    }

    private void PlayerDied()
    {
        player.gameObject.SetActive(false);
        diedMenu.GetComponent<DiedMenuScript>().DisplayDiedMenu();
        escapeMenuScript.GetComponent<EscapeMenuScript>().PauseGame();
    }
}
