using UnityEngine;

public class EscapeMenuScript : MonoBehaviour
{
    public static bool escapeScreenIsActive = false;
    private GameObject escapeScreen;
    private GameObject settings;

    private void Start()
    {
        escapeScreenIsActive = false;
        escapeScreen = GameObject.Find("EscapeMenu").transform.Find("Escape").gameObject;
        settings = GameObject.Find("EscapeMenu").transform.Find("Settings").gameObject;
        escapeScreen.SetActive(false);
    }

    private void Update()
    {
        if (escapeScreen != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !escapeScreenIsActive)
            {
                PauseGame();
                escapeScreen.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && escapeScreenIsActive && !settings.activeSelf)
            {
                ResumeGame();
                escapeScreen.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Pauses the game.
    /// </summary>
    public void PauseGame()
    {
        Time.timeScale = 0;
        escapeScreenIsActive = true;
    }

    /// <summary>
    /// Resumes the game.
    /// </summary>
    public void ResumeGame()
    {
        Time.timeScale = 1;
        escapeScreenIsActive = false;
    }
}
