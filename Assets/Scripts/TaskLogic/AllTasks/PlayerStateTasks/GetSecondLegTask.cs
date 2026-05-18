using System.Collections;
using UnityEngine;

public class GetSecondLegTask : TaskBase
{
    private bool openTask = false;

    private bool taskOpened = false; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GiveTaskName("Get Second Leg");
        GiveTaskDescription("Find your left Leg!");
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

            if (currentState == PlayerState.JumpLeg && !taskOpened)
            {
                taskOpened = true;
                StartCoroutine(OpenTask()); 
                return false;
            }

            if (openTask) 
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

            if (currentState == PlayerState.CrystalLeg || currentState == PlayerState.StretchyArm ||
            currentState == PlayerState.FullBody)
            {
                return true;
            }
        }

        return false;
    }

    private IEnumerator OpenTask() 
    {
        yield return new WaitForSeconds(5f); 

        openTask = true;
    }
}
