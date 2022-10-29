using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerMovement : MonoBehaviour
{

    [Header("Running")]
    public bool canRun = true;
    public float maxSpeed;
    public float acceleration;
    public float decceleration;

    [Header("Jumping")]
    public bool canJump = true;
    public float jumpHeight;
    public bool isGrounded;
    public bool isFalling;

    [Space]

    [Range(0.1f, 0.4f)]
    public float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    public float jumpBufferTime = 5f;
    private float jumpBufferCounter;

    [Space]

    [Range(1, 3)]
    public float fallGravity = 3;
    public float normalGravity;

    [Space]

    public Vector2 groundCheckPos;
    public Vector2 groundCheckSize;
    public LayerMask groundLayer;


    GameObject gameController;
    Rigidbody2D playerBody;
    Animator playerAnimator;
    InputManager inputManager;

    void Start() {
        gameController = GameObject.Find("Game Controller");
        inputManager = gameController.GetComponent<InputManager>();

        playerBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

        normalGravity = playerBody.gravityScale;
    }

    void Update() {
        Checks();

        if (canRun)
        {
            RunControls();
        }
        if (canJump)
        {
            JumpControls();
        }

        ExtraFallGravity();
    }

    private void RunControls() {
        playerAnimator.SetBool("Running", Input.GetAxisRaw("Horizontal") != 0 ? true : false);
        Run(Input.GetAxisRaw("Horizontal"));
    }

    private void JumpControls() {
        if (isGrounded)
        {
            playerAnimator.SetBool("TouchingGround", true);
            coyoteTimeCounter = coyoteTime;
        } else {
            playerAnimator.SetBool("TouchingGround", false);
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(inputManager.jumpKey))
        {
            jumpBufferCounter = jumpBufferTime;
        } else {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (jumpBufferCounter > 0 && coyoteTimeCounter > 0)
        {
            Jump();
            jumpBufferCounter = 0;
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            coyoteTimeCounter = 0;
        }
    }

    private void Run(float direction) {
        float targetSpeed = direction * maxSpeed;
        float speedDiff = targetSpeed - playerBody.velocity.x;
        float accelerationRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
        float moveForce = Mathf.Pow(Mathf.Abs(speedDiff) * accelerationRate, 0.96f) * Mathf.Sign(speedDiff);

        playerBody.AddRelativeForce(moveForce * Vector2.right);
    }

    private void Jump() {
        playerAnimator.SetTrigger("Jump");
        playerBody.AddRelativeForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
    }

    private void Checks() {
        bool isGroundedBefore = isGrounded;
        isGrounded = Physics2D.OverlapBox((Vector2)transform.position + groundCheckPos, groundCheckSize, 0, groundLayer);
        isFalling = playerBody.velocity.y < 0;
    }

    private void ExtraFallGravity() {
        if (isFalling)
        {
            playerBody.gravityScale = fallGravity;
        } else
        {
            playerBody.gravityScale = normalGravity;
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireCube((Vector2)transform.position + groundCheckPos, groundCheckSize);
    }

}
