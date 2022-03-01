using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Stats")]
    [Range(0f, 50f)]
    [SerializeField] float runSpeed = 40f;
    [Range(0f, 100f)]
    [SerializeField] float sprintSpeed = 60f;

    [HideInInspector] public float horizontal;
    private CharacterController2D controller;
    private Animator animator;
    private bool jump;
    private float currentSpeed;
    private ParticleSystem dust;
    private bool walking;

    private void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController2D>();
        dust = transform.Find("Ground").GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (!jump)
        {
            // Read the jump input in Update so button presses aren't missed.
            jump = Input.GetButtonDown("Jump");
        }

        if (Input.GetButton("Sprint"))
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = runSpeed;
        }

        if (jump && !EscapeMenu.escapeScreenIsActive)
        {
            animator.Play("Spinny");
            dust.Stop();
        }

        if (!EscapeMenu.escapeScreenIsActive)
        {
            animator.SetFloat("Moving", Mathf.Abs(horizontal));
        }
    }

    private void FixedUpdate()
    {
        walking = Mathf.Abs(horizontal) > 0;

        if (walking && !jump)
        {
            dust.Play();
        }

        horizontal = Input.GetAxisRaw("Horizontal") * currentSpeed;
        controller.Move(horizontal * Time.fixedDeltaTime, false, jump);
        jump = false;
    }


    /// <summary>
    /// Triggered when player touches the ground.
    /// </summary>
    public void OnLanding()
    {
        animator.Play("Idle");
        dust.Play();
    }

    /// <summary>
    /// Triggered when a spell spawns.
    /// </summary>
    public void OnSpellShoot()
    {
        if (walking)
        {
            animator.Play("AttackMoving");
        }
        else
        {
            animator.Play("AttackIdle");
        }
    }
}
