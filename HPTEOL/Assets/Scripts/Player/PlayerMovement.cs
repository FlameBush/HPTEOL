using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    // Animation support
    public Animator animator;

    // Movement support
    [SerializeField] private float runSpeed = 40f;
    private float horizontal = 0f;
    private bool jump = false;


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * runSpeed;

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