using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] GameObject[] disableForWebgl;
    private void Start()
    {
    #if UNITY_WEBGL
        for (int i = 0; i < disableForWebgl.Length; i++)
        {
            disableForWebgl[i].SetActive(false);
        }
    #endif
    }

    public void PlayGame(int scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;
        LeanTween.reset();
    }

    public void BackButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
