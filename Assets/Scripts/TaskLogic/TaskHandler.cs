using UnityEngine;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

public class TaskHandler : Singleton<TaskHandler>
{
    public List<TaskBase> allTasks = new List<TaskBase>();

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
        SetAllTasks(); 
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

        for(int i = 0; i < unassignedTasks.Count; i++) 
        {
            unassignedTasks[i].CheckForAssignment(); 
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

        TaskNotificationUI.Instance.NotifyNewTask(task.taskDescription);
        SFXManager.Instance.PlaySoundFXClip("PH_NewTask");

        unassignedTasks.Remove(task); 

        updateTaskList = true;
    }

    public void CompleteATask(TaskBase task) 
    {
        if(!inProgressTasks.Contains(task)) return;

        completedTasks.Add(task);

        TaskNotificationUI.Instance.NotifyCompleteTask(task.taskDescription);
        SFXManager.Instance.PlaySoundFXClip("PH_TaskCompleted");

        inProgressTasks.Remove(task);

        updateTaskList = true;
    }

    public void SetAllTasks() 
    {
        if (allTasks.Count <= 0) return;

        unassignedTasks.Clear();
        inProgressTasks.Clear();
        completedTasks.Clear();

        
        for (int i = 0; i < allTasks.Count; i++) 
        {
            allTasks[i].ResetTaskData(); 
            allTasks[i].ResetTaskStatus(); 
            unassignedTasks.Add(allTasks[i]); 
        }
    }

}
