using UnityEngine;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

public class TaskHandler : Singleton<TaskHandler>
{
    public List<TaskBase> unassignedTasks = new List<TaskBase>();

    public List<TaskBase> inProgressTasks = new List<TaskBase>();

    public List<TaskBase> completedTasks = new List<TaskBase>();

    public bool updateTaskList = false; 

    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        for(int i = 0; i < unassignedTasks.Count; i++) 
        {
            if (unassignedTasks[i].isInProgress) 
            {
                AssignATask(unassignedTasks[i]);
            }
        }

        for(int i = 0; i < inProgressTasks.Count; i++) 
        {
            if (inProgressTasks[i].isFinished) 
            {
                CompleteATask(inProgressTasks[i]);
            }
        }

        for(int i = 0; i < inProgressTasks.Count; i++) 
        {
            inProgressTasks[i].CheckForCompletion(); 
        }

    }

    public void AssignATask(TaskBase task) 
    {
        if (!unassignedTasks.Contains(task)) return;

        inProgressTasks.Add(task);

        unassignedTasks.Remove(task); 

        updateTaskList = true;
    }

    public void CompleteATask(TaskBase task) 
    {
        if(!inProgressTasks.Contains(task)) return;

        completedTasks.Add(task);

        inProgressTasks.Remove(task);

        updateTaskList = true;
    }

}
