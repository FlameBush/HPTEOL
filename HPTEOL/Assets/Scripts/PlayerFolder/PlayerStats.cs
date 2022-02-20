using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int playersMaxHealth = 100;
    [SerializeField] int playersCurrentHealth;
    [SerializeField] HealthBar playerHealthBar;

    void Awake()
    {
        playersCurrentHealth = playersMaxHealth;
        playerHealthBar.SetMaxHealth(playersMaxHealth);
    }

    #region Properties
    public int PlayersCurrentHealth
    {
        get { return playersCurrentHealth; }
    }
    #endregion

    private void Update()
    {
        playerHealthBar.SetPlayerHealth(playersCurrentHealth);
    }

    public void PlayerTakesDamage(int damageTaken)
    {
        if (PlayersCurrentHealth >= 0)
        {
            playersCurrentHealth -= damageTaken;

            playerHealthBar.SetPlayerHealth(playersCurrentHealth);
        }
    }

    public void ResetHealth()
    {
        playersCurrentHealth = playersMaxHealth;
    }

}
