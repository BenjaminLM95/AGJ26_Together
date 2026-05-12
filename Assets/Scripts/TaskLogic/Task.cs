using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTaskData", menuName = "ScriptableObjects/Task", order = 1)]
public class Task : ScriptableObject
{
    public string _taskName;

    public string _taskDescription; 

    public TaskStatus _taskStatus;

    public string _taskStatusString;   

    public void GetCurrentStatusString() 
    {
        _taskStatusString = _taskStatus.ToString();
    }

   
    
}

public enum TaskStatus 
{
    Unassigned,
    InProgress,
    Completed
}
