using UnityEngine;
using TMPro;

public class TaskListUI : MonoBehaviour
{
    [SerializeField] private TaskHandler _taskHandler;

    [SerializeField] private TextMeshProUGUI _textFieldText; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateTaskList();
    }

    // Update is called once per frame
    void Update()
    {
        if (_taskHandler.updateTaskList) 
        {
            UpdateTaskList();
            _taskHandler.updateTaskList = false;
        }
    }

    public void UpdateTaskList() 
    {
        string allCurrentTaskText = "";

        if (_taskHandler.inProgressTasks.Count < 1) 
        {
            _textFieldText.text = "No task available"; 
            return; 
        }

        for (int i = 0; i < _taskHandler.inProgressTasks.Count; i++) 
        {
            allCurrentTaskText += (i+1) + ") "; 
            allCurrentTaskText += _taskHandler.inProgressTasks[i].taskDescription;
            allCurrentTaskText += "\n"; 
        }

        _textFieldText.text = allCurrentTaskText;

    }


}
