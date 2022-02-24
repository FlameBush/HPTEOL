using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class Win : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            StartCoroutine(PassLevel(collider.gameObject));
        }
    }

    public IEnumerator PassLevel(GameObject player)
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel >= PlayerPrefs.GetInt("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", currentLevel + 1);
            player.SetActive(false);
            GameObject.Find("Healthbar").SetActive(false);
            GameObject.Find("Spellbar").SetActive(false);
            GameObject.Find("DiedMenu").SetActive(false);
            GameObject.Find("Cutscene").SetActive(true);
            yield return new WaitForSeconds(2);
            SceneManager.LoadSceneAsync(currentLevel + 1);
        }
    }
}
