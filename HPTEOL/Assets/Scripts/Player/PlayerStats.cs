using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int playersMaxHealth = 100;
    [SerializeField] int playersCurrentHealth;
    private HealthBar playerHealthBar;

    private void Start()
    {
        playerHealthBar = GameObject.Find("Healthbar").GetComponent<HealthBar>();
        playerHealthBar.SetMaxHealth(playersMaxHealth);
        playersCurrentHealth = playersMaxHealth;
    }

    #region Properties
    public int PlayersCurrentHealth
    {
        get { return playersCurrentHealth; }
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

    public void ResetHealth()
    {
        playersCurrentHealth = playersMaxHealth;
        gameObject.transform.position = gameObject.GetComponent<Death>().SpawningPoint.position;
        playerHealthBar.SetPlayerHealth(playersCurrentHealth);
    }

}
