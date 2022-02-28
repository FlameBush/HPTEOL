using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager: MonoBehaviour
{
    static float startTimer = 0f;

    public enum Scene
    {
        MainMenu,
        LoadingScreen,
        DeckBuilder,
        GameScene
    }

    public void GoToMainMenu()
    {
        startTimer += Time.time;
        SceneManager.LoadScene(Scene.LoadingScreen.ToString());

        if (startTimer >= 2f)
        {
            SceneManager.LoadScene(Scene.MainMenu.ToString());
            startTimer = 0;
        }
    }
}
