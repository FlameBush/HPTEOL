using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int playersMaxHealth = 100;
    [SerializeField] int playersCurrentHealth;
    private HealthBar playerHealthBar;
    private ParticleSystem blood;
    private bool ableDamage = true;

    private void Start()
    {
        playerHealthBar = GameObject.Find("Healthbar").GetComponent<HealthBar>();
        playerHealthBar.SetMaxHealth(playersMaxHealth);
        playersCurrentHealth = playersMaxHealth;
        blood = GetComponent<ParticleSystem>();
    }

    #region Properties
    public int PlayersCurrentHealth
    {
        get { return playersCurrentHealth; }
    }
    #endregion

    public void PlayerTakesDamage(int damageTaken, bool bleed)
    {
        if (PlayersCurrentHealth >= 0 && ableDamage)
        {
            playersCurrentHealth -= damageTaken;
            if (bleed)
            {
                blood.Play();
            }
            playerHealthBar.SetPlayerHealth(playersCurrentHealth);
        }
    }

    public void ResetHealth()
    {
        playersCurrentHealth = playersMaxHealth;
        gameObject.transform.position = gameObject.GetComponent<Death>().SpawningPoint.position;
        playerHealthBar.SetPlayerHealth(playersCurrentHealth);
        GameObject.Find("GameManager").GetComponent<EscapeMenu>().ResumeGame();
    }

}
