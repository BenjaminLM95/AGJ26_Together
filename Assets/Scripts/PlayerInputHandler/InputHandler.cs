using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour, PlayerInput.IPlayerActions
{
    private PlayerInput input;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        input = new PlayerInput();
        input.Player.SetCallbacks(this);
        input.Enable();

    }

    // Update is called once per frame
    void Update()
    {
        
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
        //Debug.Log("Moving " + context.ReadValue<Vector2>());
        if (context.started)
        {
            Debug.Log($"{context.action.name} has started");
        }

        if (context.performed)
        {
            Debug.Log($"{context.action.name} has performed");
        }

        if (context.canceled)
        {
            Debug.Log($"{context.action.name} has canceled");
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //Debug.Log("Jump");
        if (context.started)
        {
            Debug.Log($"{context.action.name} has started");
        }

        if (context.performed)
        {
            Debug.Log($"{context.action.name} has performed");
        }

        if (context.canceled)
        {
            Debug.Log($"{context.action.name} has canceled");
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        //Debug.Log("Interacting");
        if (context.started)
        {
            Debug.Log($"{context.action.name} has started");
        }

        if (context.performed)
        {
            Debug.Log($"{context.action.name} has performed");
        }

        if (context.canceled)
        {
            Debug.Log($"{context.action.name} has canceled");
        }
    }

    public void OnStretchyArm(InputAction.CallbackContext context)
    {
        //Debug.Log("Stretchy Arm Go");
        if (context.started)
        {
            Debug.Log($"{context.action.name} has started");
        }

        if (context.performed)
        {
            Debug.Log($"{context.action.name} has performed");
        }

        if (context.canceled)
        {
            Debug.Log($"{context.action.name} has canceled");
        }
    }
}
