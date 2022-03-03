using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private DiedMenu dms;
    private EscapeMenu esc;
    private GameManager instance;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        dms = GetComponent<DiedMenu>();
        esc = GetComponent<EscapeMenu>();

        if (instance != null)
        {
            Destroy(this.gameObject);
        } else
        {
            instance = this;
        }

        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            dms.enabled = true;
            esc.enabled = true;
        }
        else
        {
            dms.enabled = false;
            esc.enabled = false;
        }

        DontDestroyOnLoad(transform.gameObject);
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex != 0)
        {
            dms.enabled = true;
            esc.enabled = true;
        }
        else
        {
            dms.enabled = false;
            esc.enabled = false;
        }
    }
}
