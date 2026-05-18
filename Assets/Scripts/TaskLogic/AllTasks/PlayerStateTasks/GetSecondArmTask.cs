using UnityEngine;
using System.Collections;

public class GetSecondArmTask : TaskBase
{
    private bool openTask = false;

    private bool taskOpened = false;

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

            if (currentState == PlayerState.StretchyArm && !taskOpened)
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

            if (currentState == PlayerState.FullBody)
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
