using UnityEngine;

public class GetFirstArmTask : TaskBase
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GiveTaskName("Get an arm");
        GiveTaskDescription("Find the strechy arm!");
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

            if (PlayerBody.Instance.GetCurrentState() == PlayerState.CrystalLeg)
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

            if (PlayerBody.Instance.GetCurrentState() == PlayerState.StretchyArm ||
            PlayerBody.Instance.GetCurrentState() == PlayerState.FullBody)
            {
                return true;
            }
        }

        return false;
    }

}
