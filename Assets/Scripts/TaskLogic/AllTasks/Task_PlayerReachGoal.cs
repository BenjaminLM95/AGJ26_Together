using UnityEngine;

public class Task_PlayerReachGoal : TaskBase
{
    [SerializeField] private GoalTrigger goalTrigger; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GiveTaskName("ReachGoal");
        GiveTaskDescription("Reach to the yellow platform");
        isUnassigned = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(goalTrigger == null) 
        {
            goalTrigger = FindFirstObjectByType<GoalTrigger>();
        }
    }

    public override bool CheckConditions()
    {       

        if(goalTrigger == null) return false;

        if (goalTrigger.isInGoal) 
        {

            return true;
        }
        else 
        {
            return false;
        }
    }
}
