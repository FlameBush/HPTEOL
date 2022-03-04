using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private DiedMenu dms;
    private GameManager instance;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        dms = GetComponent<DiedMenu>();

        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            dms.enabled = true;
        }
        else
        {
            dms.enabled = false;
        }

        DontDestroyOnLoad(transform.gameObject);
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0 || scene.buildIndex == 6)
        {
            dms.enabled = false;
        }
        else
        {
            dms.enabled = true;
        }
    }
}
