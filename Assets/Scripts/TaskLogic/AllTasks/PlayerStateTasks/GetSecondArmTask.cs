using UnityEngine;

public class GetSecondArmTask : TaskBase
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GiveTaskName("Get the second arm");
        GiveTaskDescription("Find the second arm!");
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

            if (PlayerBody.Instance.GetCurrentState() == PlayerState.StretchyArm)
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

            if (PlayerBody.Instance.GetCurrentState() == PlayerState.FullBody)
            {
                return true;
            }
        }

        return false;
    }
}
