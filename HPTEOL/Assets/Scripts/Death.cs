using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    PlayerStats player;

    [SerializeField] private Transform SpawningPoint;
    int playerHealth;

    // to avoid a glitch I encountered
    bool previousTimeHitWorldEdgeTrigger = false;
    
    private void Awake()
    {
        player = GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!previousTimeHitWorldEdgeTrigger)
        {
            previousTimeHitWorldEdgeTrigger = true;
            if (collider.tag == "End of World")
            {
                transform.position = SpawningPoint.position;
                player.PlayerTakesDamage(20);
                //playerHealth = player.PlayersCurrentHealth;
                //Debug.Log(playerHealth);
            }
        }
        else
        {
            previousTimeHitWorldEdgeTrigger = false;
        }
    }

    // needs some work
    //private void Update()
    //{
    //    if (playerHealth == 0)
    //    {
    //        PlayerDied();
    //    }
    //}

    //private void PlayerDied()
    //{
    //    Debug.Log("Player Died");
    //}
}
