using UnityEngine;
using System.Collections.Generic; 

public class TaskHandler : MonoBehaviour
{
    [SerializeField] List<TaskBase> unassignedTasks = new List<TaskBase>();

    [SerializeField] List<TaskBase> inProgressTasks = new List<TaskBase>();

    [SerializeField] List<TaskBase> completedTasks = new List<TaskBase>();


    private void Start()
    {
        for(int i = 0; i < unassignedTasks.Count; i++) 
        {
            
        }
    }

    public void AssignATask(TaskBase task) 
    {
        if (!unassignedTasks.Contains(task)) return;

        inProgressTasks.Add(task);

        unassignedTasks.Remove(task); 
    }

    public void CompleteATask(TaskBase task) 
    {
        if(!inProgressTasks.Contains(task)) return;

        completedTasks.Add(task);

        inProgressTasks.Remove(task); 
    }

}
