using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class playermovement : MonoBehaviour
{

    public CharacterController2D controller;

    public float runSpeed = 40f;
    float horizontal = 0f;
    bool jump = false;

    private bool escapeScreenIsActive = false;
    public GameObject escapeScreen;
    public GameObject settingsScreen;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (escapeScreen != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !escapeScreenIsActive)
            {
                Time.timeScale = 0;
                escapeScreen.SetActive(true);
                escapeScreenIsActive = true;
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && escapeScreenIsActive)
            {
                Time.timeScale = 1;
                escapeScreen.SetActive(false);
                escapeScreenIsActive = false;
            }
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontal * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void SettingsScreen()
    {
        if (escapeScreenIsActive)
        {
            settingsScreen.setActive(true);
            escapeScreen.setActive(false);
            escapeScreenIsActive = false;
            Time.timeScale = 0;
        }
    }

    public void BackEscapeScreen()
    {
        if (!escapeScreenIsActive)
        {
            escapeScreen.setActive(true);
            escapeScreenIsActive = true;
            settingsScreen.setActive(false);
            Time.timeScale = 0;
        }
    }
}
