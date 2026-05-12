using UnityEngine;

public class TaskBase : MonoBehaviour, ITaskLogic
{
    public bool isUnassigned;

    public bool isInProgress;

    public bool isFinished; 


    public void CheckForCompletion()
    {
        if (CheckConditions() && isInProgress) 
        {
            isFinished = true; 
        }
    }

    public virtual bool CheckConditions() 
    {
        return false; 
    }
 
}
