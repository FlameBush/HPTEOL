using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenuScript : MonoBehaviour
{
    public bool escapeScreenIsActive = false;
    public GameObject escapeScreen;

    private Animator playerAnimator;

    private void Awake()
    {
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (escapeScreen != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !escapeScreenIsActive)
            {
                PauseGame();
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && escapeScreenIsActive)
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        escapeScreen.SetActive(true);
        escapeScreenIsActive = true;
        playerAnimator.SetBool("GameIsPaused", true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        escapeScreen.SetActive(false);
        escapeScreenIsActive = false;
        playerAnimator.SetBool("GameIsPaused", false);
    }
}
