using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    // other classes
    PlayerStats player;
    [SerializeField] DiedMenuScript diedMenu;
    [SerializeField] EscapeMenuScript escapeMenuScript;

    // support respawning
    public Transform SpawningPoint;

    // to avoid a glitch I encountered
    bool previousTimeHitWorldEdgeTrigger = false;
    
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
        if (!previousTimeHitWorldEdgeTrigger)
        {
            previousTimeHitWorldEdgeTrigger = true;
            if (collider.tag == "End of World")
            {
                transform.position = SpawningPoint.position;
                player.PlayerTakesDamage(50);
            }
        }
        else
        {
            previousTimeHitWorldEdgeTrigger = false;
        }
    }

    private void PlayerDied()
    {
        player.gameObject.SetActive(false);
        diedMenu.GetComponent<DiedMenuScript>().DisplayDiedMenu();
        escapeMenuScript.GetComponent<EscapeMenuScript>().PauseGame();
    }
}
