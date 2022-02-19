using UnityEngine;

public class Winning : MonoBehaviour
{
    private GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            gameManager.GetComponent<LevelScripts>().PassLevel();
        }
    }
}
