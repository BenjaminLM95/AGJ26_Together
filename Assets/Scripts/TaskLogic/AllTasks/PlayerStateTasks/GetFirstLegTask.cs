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
            if (PlayerBody.Instance.GetCurrentState().ToString() == PlayerState.Head.ToString())
            {
                return true;
            }

        }

        return false;
    }

    public override bool CheckConditions() 
    {
        if (GameStateMachine.Instance.currentGameStateString == "GameplayState")
        {

            if (PlayerBody.Instance.GetCurrentState() == PlayerState.JumpLeg ||
            PlayerBody.Instance.GetCurrentState() == PlayerState.CrystalLeg || PlayerBody.Instance.GetCurrentState() == PlayerState.StretchyArm ||
            PlayerBody.Instance.GetCurrentState() == PlayerState.FullBody)
            {
                return true;
            }
        }

        return false;
    }    

}
