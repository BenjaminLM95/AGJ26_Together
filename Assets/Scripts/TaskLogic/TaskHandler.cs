using UnityEngine;
using System.Collections.Generic; 

public class TaskHandler : Singleton<TaskHandler>
{
    [SerializeField] List<TaskBase> unassignedTasks = new List<TaskBase>();

    [SerializeField] List<TaskBase> inProgressTasks = new List<TaskBase>();

    [SerializeField] List<TaskBase> completedTasks = new List<TaskBase>();

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
