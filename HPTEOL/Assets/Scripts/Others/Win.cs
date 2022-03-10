using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Win : MonoBehaviour
{
    [SerializeField] GameObject Cutscene;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            StartCoroutine(PassLevel(collider.gameObject));
        }
    }

    public IEnumerator PassLevel(GameObject player)
    {
        player.SetActive(false);
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel <= 2)
        {
            PlayerPrefs.SetInt("levelsUnlocked", currentLevel + 1);
        }
        GameObject.Find("GameCanvas").SetActive(false);
        Cutscene.SetActive(true);
        yield return new WaitForSeconds(2);
        if (currentLevel != 5)
        {
            SceneManager.LoadSceneAsync(currentLevel + 1);
        }
        else
        {
            SceneManager.LoadSceneAsync(0);
        }
    }
}
