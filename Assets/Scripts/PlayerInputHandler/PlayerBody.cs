using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    [SerializeField] private PlayerStateEvent onStateChanged;

    [SerializeField] private PlayerState currentState;

    //Added this to make my life easier for testing
    [SerializeField] private bool quickStateSwitch;

    private Animator animator;


    [SerializeField] private PlayerState savedState;

    private MovementController movementController;

    private void OnEnable()
    {
       onStateChanged.gameEvent += SetAnimationState;

        SwitchState(savedState);
    }
    private void OnDisable()
    {
        onStateChanged.gameEvent -= SetAnimationState;
    }

    public void Awake()
    {
        //base.Awake();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        SwitchState(PlayerState.Head);
        movementController = GetComponent<MovementController>();
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
    
    /// <summary>
    /// Handles switching states logic
    /// </summary>
    /// <param name="newState"></param>
    public void SwitchState(PlayerState newState)
    {
        if (movementController != null) 
        { 
            movementController.StopPlayerMovement();
        }
        
        currentState = newState;
        onStateChanged.RaiseEvent(currentState);
    }

    private void SetAnimationState(PlayerState newState)
    {
        if (animator == null) return; 

        animator.SetBool("isHeadState", false);
        animator.SetBool("isJumpLegState", false);
        animator.SetBool("isCrystalLegState", false);
        animator.SetBool("isStrechyArmState", false);
        animator.SetBool("isFullBodyState", false);
        switch (newState)
        {
            case PlayerState.Head:
                animator.SetBool("isHeadState", true);
                break;
                
            case PlayerState.JumpLeg:
                animator.SetBool("isJumpLegState", true);
                break;
            case PlayerState.CrystalLeg:
                animator.SetBool("isCrystalLegState", true);
                break;
            case PlayerState.StretchyArm:
                animator.SetBool("isStrechyArmState", true);
                break;
            case PlayerState.FullBody:
                animator.SetBool("isFullBodyState", true);
                break;

        }
    }

    public PlayerState GetCurrentState()
    {
        return currentState;
    }

    public void SavePlayerState() 
    {
        savedState = currentState; 
    }

    public void RestartState() 
    {
        currentState = PlayerState.Head;        
    }
}
