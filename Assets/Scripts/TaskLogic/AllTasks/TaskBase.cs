using UnityEngine;

public class TaskBase : MonoBehaviour, ITaskLogic
{
    public bool isUnassigned;

    public bool isInProgress;

    public bool isFinished;

    public string taskName;

    public string taskDescription;


    private void Start()
    {
        isUnassigned = true;
    }

    private void Update()
    {
        CheckForCompletion(); 
    }

    public void CheckForCompletion()
    {
        if (CheckConditions() && isInProgress && !isFinished) 
        {
            isFinished = true; 
        }
    }

    public virtual bool CheckConditions() 
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
 
}
