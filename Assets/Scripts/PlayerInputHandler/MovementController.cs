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
        isJumpOnCooldown = true;
        rb = GetComponent<Rigidbody>();
        body ??= GetComponent<PlayerBody>();
    }

    public void SetMove(Vector2 moveInput)
    {
        moveDirection = moveInput;
        SetXMovement(moveInput);
    }

    private void SetXMovement(Vector2 moveInput)
    {
        xMovement = new Vector2(moveInput.x, 0);
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
        if (!isJumpOnCooldown) return;
        if (!body.CanJump()) return;
        if (!IsGrounded()) return;

        Jump();
        StartCoroutine(JumpCooldown(jumpCooldownTime));
    }
    private void Jump()
    {
        Vector2 jumpDirection = (xMovement + Vector2.up).normalized;
        rb.AddForce(jumpDirection * jumpForce, ForceMode.Impulse);
    }
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);
    }

    
    private IEnumerator JumpCooldown(float jumpCooldownTime)
    {
        isJumpOnCooldown = false;

        yield return new WaitForSeconds(jumpCooldownTime);

        isJumpOnCooldown = true;
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
