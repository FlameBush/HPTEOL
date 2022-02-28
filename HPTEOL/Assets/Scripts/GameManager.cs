using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void OnEnable()
    {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

    private void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
        if (scene.buildIndex != 0)
        {
			GetComponent<LevelManager>().enabled = false;
        }
	}
}
