using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public Animator animator;
    private bool isGrounded;
    private bool sprinting = false;
    public float speed = 2f;
    public float gravity = -9.81f;
    public float jumpHeight = 1f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", false);
        animator.SetBool("isRunning", false);
        animator.SetBool("isJumping", false);
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        if(sprinting)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", Input.GetAxisRaw("Vertical") != 0);
        }
        else
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", Input.GetAxisRaw("Vertical") != 0);
        }
        animator.SetBool("isJumping", !controller.isGrounded);
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Sprint()
    {
        sprinting = !sprinting;
        if (sprinting)
        {
            speed = 5;
        }
        else
        {
            speed = 2;
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
        }
    }
}
