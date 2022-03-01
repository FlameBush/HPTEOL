using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        DontDestroyOnLoad(transform.gameObject);
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(LevelScene(scene.buildIndex));
    }

    private IEnumerator LevelScene(int index)
    {
        yield return new WaitForSeconds(1);
        if (index != 0)
        {
            while (GetComponent<LevelManager>().enabled)
            {
                GetComponent<EscapeMenuScript>().enabled = true;
                GetComponent<DiedMenuScript>().enabled = true;
                GetComponent<LevelManager>().enabled = false;
            }
        }
        else
        {
            while(!GetComponent<LevelManager>().enabled)
            {
                GetComponent<EscapeMenuScript>().enabled = false;
                GetComponent<DiedMenuScript>().enabled = false;
                GetComponent<LevelManager>().enabled = true;
            }
        }
    }
}
