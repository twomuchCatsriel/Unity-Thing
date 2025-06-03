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
        moveSpeed = DefaultmoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();

        if (SprintAction.IsPressed())
        {
            moveSpeed = sprintSpeed;
        }
        else
        {
            moveSpeed = DefaultmoveSpeed;
        }

        rb.linearVelocity = new Vector2(move[0] * moveSpeed, rb.linearVelocityY);

        if (jumpAction.IsPressed() && canJump == true)
        {
            canJump = false;
            rb.linearVelocity = new Vector2(0, jumpHeight);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Solid"))
        {
            canJump = true;
        }
    }
}
