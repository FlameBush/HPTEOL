using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
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
            while (GetComponent<DiedMenu>().enabled)
            {
                GetComponent<EscapeMenu>().enabled = true;
                GetComponent<DiedMenu>().enabled = true;
            }
        }
        else
        {
            while (!GetComponent<DiedMenu>().enabled)
            {
                GetComponent<EscapeMenu>().enabled = false;
                GetComponent<DiedMenu>().enabled = false;
            }
        }
    }
}
