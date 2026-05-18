using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour, PlayerInput.IPlayerActions
{
    private PlayerInput input;

    [SerializeField] private MovementController movementController;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        input = new PlayerInput();
        input.Player.SetCallbacks(this);
        //input.Enable();
        movementController ??= GetComponent<MovementController>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementController.SetMove(context.ReadValue<Vector2>());

        if (context.started)
        {
            animator.SetBool("isWalking",true);

        }

        if (context.performed)
        {
            //Debug.Log($"{context.action.name} has performed");
        }

        if (context.canceled)
        {
            animator.SetBool("isWalking", false);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //Debug.Log("Jump");
        if (context.started)
        {
            movementController.RequestJump();
        }

        if (context.performed)
        {
            //Debug.Log($"{context.action.name} has performed");
        }

        if (context.canceled)
        {
            //Debug.Log($"{context.action.name} has canceled");
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        //Debug.Log("Interacting");
        if (context.started)
        {
            //Debug.Log($"{context.action.name} has started");
        }

        if (context.performed)
        {
            //Debug.Log($"{context.action.name} has performed");
        }

        if (context.canceled)
        {
            //Debug.Log($"{context.action.name} has canceled");
        }
    }

    public void OnStretchyArm(InputAction.CallbackContext context)
    {
        //Debug.Log("Stretchy Arm Go");
        if (context.started)
        {
            //Debug.Log($"{context.action.name} has started");
        }

        if (context.performed)
        {
            //Debug.Log($"{context.action.name} has performed");
        }

        if (context.canceled)
        {
            //Debug.Log($"{context.action.name} has canceled");
        }
    }
}
