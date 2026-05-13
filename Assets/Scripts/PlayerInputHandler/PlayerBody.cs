using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    private PlayerState currentState;
    private Rigidbody rb;

    // I put this here just because I wasn't sure if were using capsule or sphere collider
    [Header("Capsule Size for ball mode and full body mode")]
    [SerializeField] private float sphereSize;
    [SerializeField] private float bodyRadius;
    [SerializeField] private float bodyHeight;
    private CapsuleCollider playerColider;

    //Added this to make my life easier for testing
    [SerializeField] private bool quickStateSwitch;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb ??= GetComponent<Rigidbody>();
        playerColider ??= GetComponent<CapsuleCollider>();
        SwitchState(PlayerState.Head);
    }

    private void Update()
    {
        if (!quickStateSwitch) return;

        if (Input.GetKey(KeyCode.Alpha1))
        {
            SwitchState(PlayerState.Head);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            SwitchState(PlayerState.JumpLeg);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            SwitchState(PlayerState.StretchyArm);
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            SwitchState(PlayerState.FullBody);
        }
    }

    public bool CanMove()
    {
        return currentState == PlayerState.Head ||
               currentState == PlayerState.CrystalLeg ||
               currentState == PlayerState.StretchyArm ||
               currentState == PlayerState.FullBody;
    }

    public bool CanJump()
    {
        return currentState == PlayerState.JumpLeg ||
               currentState == PlayerState.CrystalLeg ||
               currentState == PlayerState.StretchyArm ||
               currentState == PlayerState.FullBody;
    }

    public bool CanWalkNormal()
    {
        return currentState == PlayerState.FullBody ||
               currentState == PlayerState.CrystalLeg ||
               currentState == PlayerState.StretchyArm ||
               currentState == PlayerState.FullBody;
    }

    public bool CanRoll()
    {
        return currentState == PlayerState.Head;
    }

    public void SwitchState(PlayerState newState)
    {
        currentState = newState;

        if (CanRoll())
        {
            SetBallMode();
        }
        else
        {
            SetWalkMode();
        }
    }

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
}
