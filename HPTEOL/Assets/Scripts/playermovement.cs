using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class playermovement : MonoBehaviour
{

    public CharacterController2D controller;
    // animation support
    public Animator animator;

    // Movement support
    [SerializeField] private float runSpeed = 40f;
    private float horizontal = 0f;
    private bool jump = false;

    // Escapescreen support
    private bool escapeScreenIsActive = false;
    public GameObject escapeScreen;
    public GameObject settingsScreen;


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * runSpeed;

        // handle animation
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        // handle movement
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
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

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        controller.Move(horizontal * Time.fixedDeltaTime, false, jump);
        jump = false;   
    }
}
