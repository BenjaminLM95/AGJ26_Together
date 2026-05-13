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
        isInProgress = true;
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
 
}
