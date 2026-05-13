using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [SerializeField] private PlayerBody body;
    private Rigidbody rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpCooldownTime;
    [SerializeField] private float jumpForce;
    private bool isJumpOnCooldown;
    [Range(0f, 2f)]
    [SerializeField] private float groundCheckDistance;

    private Vector2 moveDirection;
    private Vector2 xMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        body ??= GetComponent<PlayerBody>();
    }

    public void SetMove(Vector2 moveInput)
    {
        moveDirection = moveInput;
        xMovement.x = moveInput.x;
    }

    private void FixedUpdate()
    {
        HandleMovementState();
    }

    private void HandleMovementState()
    {
        if (body == null) return;
        if (!body.CanMove()) return;

        if (body.CanRoll())
        {
            RollaBall();
        }
        else
        {
            NormalMovement();
        }
    }


    private void RollaBall()
    {
        rb.AddForce(xMovement * moveSpeed, ForceMode.Force);
    }

    private void NormalMovement()
    {
        float targetSpeed = xMovement.x * moveSpeed;

        float speedOffset = targetSpeed - rb.linearVelocity.x;

        Vector2 movementForce = new Vector2(speedOffset, 0);

        rb.AddForce(movementForce, ForceMode.VelocityChange);
    }

    public void RequestJump()
    {
        if (isJumpOnCooldown) return; // Checks if jump is on cooldown
        if (!body.CanJump()) return; // Checks if the player has the body parts to jump
        if (!IsGrounded()) return; // Checks if the player is grounded

        Jump();
        StartCoroutine(JumpCooldown(jumpCooldownTime));
    }

    private void Jump()
    {
        Vector2 jumpDirection = (moveDirection + Vector2.up).normalized;
        rb.AddForce(jumpDirection * jumpForce, ForceMode.Impulse);
    }
    /// <summary>
    /// Checks if raycast hits for ground check
    /// </summary>
    /// <returns></returns>
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);
    }

    
    private IEnumerator JumpCooldown(float jumpCooldownTime)
    {
        isJumpOnCooldown = true;

        yield return new WaitForSeconds(jumpCooldownTime);

        isJumpOnCooldown = false;
    }

    private void OnDrawGizmos()
    {
        if (IsGrounded())
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }
        Gizmos.DrawLine(
        transform.position,
        transform.position + Vector3.down * groundCheckDistance);
    }
}
