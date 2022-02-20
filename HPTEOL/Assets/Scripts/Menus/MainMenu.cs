using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
