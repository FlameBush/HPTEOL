using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int playersMaxHealth = 100;
    [SerializeField] int playersCurrentHealth;
    [SerializeField] HealthBar playerHealthBar;

    private void Awake()
    {
        //playerHealthBar = GameObject.Find("Healthbar").GetComponent<HealthBar>();
    }

    void Start()
    {
        playersCurrentHealth = playersMaxHealth;
        playerHealthBar.SetMaxHealth(playersMaxHealth);
    }

    //private void Update()
    //{
    //    playerHealthBar.SetPlayerHealth(PlayersCurrentHealth);
    //}

    #region Properties
    public int PlayersCurrentHealth
    {
        get { return playersMaxHealth; }
        set { playersCurrentHealth = value; }
    }

    #endregion

    public void PlayerTakesDamage(int damageTaken)
    {
        if (PlayersCurrentHealth >= 0)
        {
            playersCurrentHealth -= damageTaken;

            playerHealthBar.SetPlayerHealth(playersCurrentHealth);
        }
    }

}
