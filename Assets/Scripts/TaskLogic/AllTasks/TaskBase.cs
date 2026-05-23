using UnityEngine;

public class TaskBase : MonoBehaviour, ITaskLogic
{
    public bool isUnassigned;

    public bool isInProgress;

    public bool isFinished;

    public string taskName;

    public string taskDescription;

    public PlayerState currentState;
    public PlayerStateEvent onStateChanged;

    private void GetCurrentState(PlayerState newState)
    {
        currentState = newState;
    }

    private void OnEnable()
    {
        onStateChanged.gameEvent += GetCurrentState;
    }

    private void OnDisable()
    {
        onStateChanged.gameEvent -= GetCurrentState;
    }
    private void Start()
    {
        isUnassigned = true;
    }

    private void Update()
    {
        
    }

    public void CheckForCompletion()
    {
        if (CheckConditions() && isInProgress && !isFinished) 
        {
            isFinished = true; 
        }
    }

    public void CheckForAssignment() 
    {
        if(CheckForRequirements() && isUnassigned && !isInProgress) 
        {
            isInProgress = true;
        }
    }

    public virtual bool CheckConditions() 
    {
        return false; 
    }

    public virtual bool CheckForRequirements() 
    {
        return false; 
    }

    public void GiveTaskName(string tName) 
    {
        taskName = tName; 
    }

    public void GiveTaskDescription(string tDescription) 
    { 
        taskDescription = tDescription; 
    }

    public void ResetTaskData() 
    {        
        isInProgress = false;
        isFinished = false; 
    }

    public virtual void ResetTaskStatus() 
    {
        Debug.Log("Something awesome happens");
    }

   
 
}
