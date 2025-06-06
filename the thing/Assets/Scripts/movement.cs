using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    InputAction moveAction;
    InputAction jumpAction;
    InputAction SprintAction;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sr;

    // other scripts
    nikoWeapons weaponsScript;

    bool canJump = true;
    public float jumpHeight;
    public float DefaultmoveSpeed;
    public float sprintSpeed;

    float moveSpeed;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        SprintAction = InputSystem.actions.FindAction("Sprint");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        moveSpeed = DefaultmoveSpeed;

        weaponsScript = GetComponent<nikoWeapons>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();

        if (SprintAction.IsPressed()) // Sprint \
        {
            moveSpeed = sprintSpeed;
        }
        else
        {
            moveSpeed = DefaultmoveSpeed;
        }

        if (weaponsScript.canAttack)
        {
            if (move.x < 0)
            {// Control animations 
                sr.flipX = true;
                animator.Play("Niko_Run");
            }
            else if (move.x > 0)
            {
                sr.flipX = false;
                animator.Play("Niko_Run");
            }
            else
            {
                if (canJump == false) // I FINALLY FIXED THIS STUPID BUG.
                {
                    animator.Play("Niko_Idle");
                }
                if (canJump == true && weaponsScript.canAttack) // Only play the idle animation if the player is not jumping
                {
                    animator.Play("Niko_Idle");
                }
            }
        }

        rb.linearVelocity = new Vector2(move[0] * moveSpeed, rb.linearVelocityY);

        if (jumpAction.triggered && canJump == true)
        {
            if (rb.linearVelocityX == 0  && weaponsScript.canAttack)
            {
                animator.Play("Niko_Fall");
            }
            canJump = false;
            rb.linearVelocity = new Vector2(0, jumpHeight);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Solid"))
        {
            CollisionCode();
        }
        else if (collision.gameObject.CompareTag("Enemies"))
        {
            CollisionCode();
        }
    }

    void CollisionCode()
    {
        canJump = true;

        if (weaponsScript.canAttack)
        {
            animator.Play("Niko_Idle");
        }
    }
}
