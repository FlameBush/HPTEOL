using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Stats")]
    [Range(0f, 50f)]
    [SerializeField] float runSpeed = 40f;
    [Range(0f, 100f)]
    [SerializeField] float sprintSpeed = 60f;

    private CharacterController2D controller;
    private Animator animator;
    [HideInInspector] public float horizontal;
    private bool jump;
    private float currentSpeed;

    private void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController2D>();
    }

    private void Update()
    {
        if (Input.GetButton("Sprint"))
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = runSpeed;
        }

        if (Input.GetButtonDown("Jump") && !EscapeMenuScript.escapeScreenIsActive)
        {
            jump = true;
            animator.Play("Spinny");
        }

        if (!EscapeMenuScript.escapeScreenIsActive)
        {
            animator.SetFloat("Moving", Mathf.Abs(horizontal));
        }
    }

    private void FixedUpdate()
    {
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
    }

    /// <summary>
    /// Triggered when a spell spawns.
    /// </summary>
    public void OnSpellShoot()
    {
        var walking = Mathf.Abs(horizontal) > 0;
        if (walking)
        {
            animator.Play("AttackMoving");
        } else
        {
            animator.Play("AttackIdle");
        }
    }
}
