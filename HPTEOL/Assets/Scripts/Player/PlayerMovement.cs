using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    // Animation support
    public Animator animator;

    // Movement support
    [SerializeField] private float runSpeed = 40f;
    public float sprintSpeed = 60f;
    private float horizontal = 0f;
    private bool jump = false;
    private float running = 0;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("sprint"))
        {
            running = sprintSpeed;
        }
        else
        {
            running = runSpeed;
        }

        horizontal = Input.GetAxisRaw("Horizontal") * running;

        // handle animation
        animator.SetFloat("Speed", Mathf.Abs(horizontal));



        // handle movement
        if (Input.GetButtonDown("Jump") && !EscapeMenuScript.escapeScreenIsActive)
        {
            jump = true;
            animator.SetBool("IsJumping", true);
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
