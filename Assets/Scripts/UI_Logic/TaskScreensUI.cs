using UnityEngine;

public class TaskScreensUI : MonoBehaviour
{
    [SerializeField] private GameObject taskListButton;

    [SerializeField] private GameObject taskListPanel; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CloseTaskList(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenTaskList() 
    {
        DisactivateTaskUI();
        taskListPanel.SetActive(true);
    }

    public void CloseTaskList() 
    {
        DisactivateTaskUI();
        taskListButton.SetActive(true); 
    }

    private void DisactivateTaskUI() 
    {
        taskListButton.SetActive(false);
        taskListPanel.SetActive(false);
    }
}
