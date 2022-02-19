using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winning : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            gameManager.GetComponent<LevelScripts>().PassLevel();
        }
    }
}
