using UnityEngine;

public class EscapeMenuScript : MonoBehaviour
{
    public static bool escapeScreenIsActive = false;
    private GameObject escapeScreen;
    private GameObject settings;

    private void Awake()
    {
        escapeScreenIsActive = false;
        if (GameObject.FindWithTag("EscapeMenu") != null)
        {
            escapeScreen = GameObject.FindWithTag("EscapeMenu").gameObject;
            settings = escapeScreen.transform.Find("Settings").gameObject;
        } else
        {
            Debug.Log(escapeScreen);
            Debug.Log(settings);
        }
    }

    void Update()
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

    public void PauseGame()
    {
        Time.timeScale = 0;
        escapeScreenIsActive = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        escapeScreenIsActive = false;
    }
}
