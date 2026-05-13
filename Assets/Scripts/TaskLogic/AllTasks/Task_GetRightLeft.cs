using UnityEngine;

public class Task_GetRightLeft : TaskBase
{
    public override bool CheckConditions()
    {
        return GameStateMachine.Instance.currentGameStateString == "GameplayState"; 
    }

    
}
