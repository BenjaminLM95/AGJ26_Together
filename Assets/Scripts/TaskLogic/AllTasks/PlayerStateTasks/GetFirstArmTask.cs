using UnityEngine;
using System.Collections;

public class GetFirstArmTask : TaskBase
{
    private bool openTask = false;

    private bool taskOpened = false;

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
        if (GameStateMachine.Instance.currentGameStateString == "GameplayState" && !taskOpened)
        {

            if (currentState == PlayerState.CrystalLeg)
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

            if (currentState == PlayerState.StretchyArm ||
            currentState == PlayerState.FullBody)
            {
                return true;
            }
        }

        return false;
    }

    private IEnumerator OpenTask()
    {
        yield return new WaitForSeconds(7f);

        openTask = true;
    }

}
