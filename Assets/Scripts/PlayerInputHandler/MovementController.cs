using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [SerializeField] private PlayerStateEvent onStateChanged;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private CapsuleCollider playerColider;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpCooldownTime;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isJumpOnCooldown;
    [Range(0f, 2f)]
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private float catchPlayerHeight;

    private Vector2 moveDirection;
    private Vector2 xMovement;

    [SerializeField] private PlayerState currentState;

    // I put this here just because I wasn't sure if were using capsule or sphere collider
    [Header("Capsule Size for ball mode and full body mode")]
    [SerializeField] private float sphereSize;
    [SerializeField] private float bodyRadius;
    [SerializeField] private float bodyHeight;

    
    

    private void OnEnable()
    {
        if (onStateChanged == null) return;
        onStateChanged.gameEvent += GetCurrentState;
        onStateChanged.gameEvent += SetStateMode;
        ResetJumpCooldown();
    }
    private void OnDisable()
    {
        if (onStateChanged == null) return;
        onStateChanged.gameEvent -= GetCurrentState;
        onStateChanged.gameEvent -= SetStateMode;
        ResetJumpCooldown();
    }

    private void GetCurrentState(PlayerState newState)
    {
        currentState = newState;
    }
    public void Awake()
    {
        //base.Awake(); 

        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb ??= GetComponent<Rigidbody>();
        playerColider ??= GetComponent<CapsuleCollider>();
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

    public void StopPlayerMovement() 
    {
        rb.linearVelocity = Vector3.zero;
    }

    private void HandleMovementState()
    {
        //if (body == null) return;
        if (!CanMove()) return;

        if (currentState == PlayerState.Head)
        {
            RollaBall();
        }
        else if (currentState == PlayerState.JumpLeg)
        {
            HopMovement();
        }
        else
        {
            NormalMovement();
        }
    }

    #region Movement Method
    private void HopMovement()
    {
        if (moveDirection == Vector2.zero) return;
        RequestJump();
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

    #endregion

    #region Jump Methods
    public void RequestJump()
    {
        if (isJumpOnCooldown) return; // Checks if jump is on cooldown
        if (!CanJump()) return; // Checks if the player has the body parts to jump
        if (!IsGrounded()) return;
        Jump();

    }

    private void Jump()
    {
        Vector2 jumpDirection = (moveDirection + Vector2.up).normalized;
        rb.AddForce(jumpDirection * jumpForce, ForceMode.Impulse);
        StartCoroutine(JumpCooldown(jumpCooldownTime));
    }

    private IEnumerator JumpCooldown(float jumpCooldownTime)
    {
        isJumpOnCooldown = true;

        yield return new WaitForSeconds(jumpCooldownTime);

        isJumpOnCooldown = false;
    }
    #endregion

    #region Movement Bool
    /// <summary>
    /// Checks if the player has the body parts to move
    /// </summary>
    /// <returns></returns>
    public bool CanMove()
    {
        return currentState == PlayerState.Head ||
               currentState == PlayerState.JumpLeg ||
               currentState == PlayerState.CrystalLeg ||
               currentState == PlayerState.StretchyArm ||
               currentState == PlayerState.FullBody;
    }
    /// <summary>
    /// Checks if the player has the body parts to jump
    /// </summary>
    /// <returns></returns>
    public bool CanJump()
    {
        return currentState == PlayerState.JumpLeg ||
               currentState == PlayerState.Head ||
               currentState == PlayerState.CrystalLeg ||
               currentState == PlayerState.StretchyArm ||
               currentState == PlayerState.FullBody;
    }
    private bool IsGrounded()
    {
        Vector3 rayOrigin = playerColider.bounds.center;

        bool middleRay = Physics.Raycast(rayOrigin, Vector3.down, groundCheckDistance);

        bool leftAngleRay = Physics.Raycast(rayOrigin,(Vector3.down + Vector3.left).normalized,groundCheckDistance);

        bool rightAngleRay = Physics.Raycast(rayOrigin,(Vector3.down + Vector3.right).normalized,groundCheckDistance);

        return middleRay || leftAngleRay || rightAngleRay;
    }
    #endregion

    /// <summary>
    /// Sets Rigidbody to un-freeze on z to roll and makes the collider into a sphere
    /// </summary>
    private void SetBallMode()
    {

        if (rb != null)
        {
            // un-freezing z rotation for rolling ball effect
            rb.constraints = RigidbodyConstraints.None
                | RigidbodyConstraints.FreezePositionZ
                | RigidbodyConstraints.FreezeRotationX
                | RigidbodyConstraints.FreezeRotationY;
        }
        if (playerColider != null)
        {
            playerColider.radius = sphereSize;
            playerColider.height = sphereSize;
        }

    }

    /// <summary>
    /// Sets Rigidbody to freeze on rotation and makes the collider into a capsule
    /// </summary>
    private void SetWalkMode()
    {
        // Setting them back up to standing rotation
        transform.rotation = Quaternion.identity;
        if (rb != null)
        {
            // Freezing rotation to stand up straight
            rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
        }
        if (playerColider != null)
        {
            playerColider.radius = bodyRadius;
            playerColider.height = bodyHeight;
        }
    }

    private void SetStateMode(PlayerState newState)
    {
        if (newState == PlayerState.Head)
        {
            SetBallMode();
        }
        else
        {
            SetWalkMode();
        }
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
        if (playerColider == null) return;
        Vector3 rayOrigin = playerColider.bounds.center;
        //rayOrigin.y -= playerColider.bounds.extents.y;
        Gizmos.DrawLine(
        rayOrigin,
        rayOrigin + Vector3.down * groundCheckDistance);
    }

    public void ResetJumpCooldown() 
    {
        isJumpOnCooldown = false; 
    }
        
}
