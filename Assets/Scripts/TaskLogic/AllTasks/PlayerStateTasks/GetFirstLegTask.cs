using System.Collections;
using UnityEngine;

public class GetFirstLegTask : TaskBase
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GiveTaskName("Get First Leg");
        GiveTaskDescription("Find your right Leg!");
        isUnassigned = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public override bool CheckForRequirements() 
    {
        if (GameStateMachine.Instance.currentGameStateString == "GameplayState")
        {            
            if (currentState == PlayerState.Head)
            {
                return true;
            }

        }

        return false;
    }

    public override void ResetTaskStatus()
    {
        Debug.Log("No reset values here");
    }

    public override bool CheckConditions() 
    {
        if (GameStateMachine.Instance.currentGameStateString == "GameplayState")
        {

            if (currentState == PlayerState.JumpLeg ||
            currentState == PlayerState.CrystalLeg || currentState == PlayerState.StretchyArm ||
            currentState == PlayerState.FullBody)
            {
                return true;
            }
        }

        return false;
    }    

}
