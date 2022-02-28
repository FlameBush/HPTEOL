using UnityEngine;

public class EscapeMenuScript : MonoBehaviour
{
    public static bool escapeScreenIsActive = false;
    public GameObject escapeScreen;
    [SerializeField] GameObject Settings;

    private Animator playerAnimator;

    private void Awake()
    {
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
        escapeScreenIsActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (escapeScreen != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !escapeScreenIsActive)
            {
                PauseGame();
                escapeScreen.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && escapeScreenIsActive && !Settings.activeSelf)
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
