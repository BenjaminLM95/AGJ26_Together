using UnityEngine;
using TMPro;
using System.Collections;

public class TaskNotificationUI : Singleton<TaskNotificationUI>
{
    [SerializeField] private GameObject notificationPanelObj;

    [SerializeField] private TextMeshProUGUI notificationText;

    public float notifCooldown; 

    public override void Awake()
    {
        base.Awake();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CloseNotifObj(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NotifyNewTask(string tName) 
    {
        notificationPanelObj.gameObject.SetActive(true);
        notificationText.text = "New Task assigned!! \n" + tName;
        StartCoroutine(CloseNotification()); 
    }

    public void NotifyCompleteTask(string tDes) 
    {
        notificationPanelObj.gameObject.SetActive(true);
        notificationText.text = tDes + "\nTask Complete!!";
        StartCoroutine(CloseNotification());
    }

    private void CloseNotifObj() 
    {
        notificationText.text = "";
        notificationPanelObj.gameObject.SetActive(false);
    }
    
    private IEnumerator CloseNotification() 
    {
        yield return new WaitForSeconds(notifCooldown);
        CloseNotifObj();
    }

}
