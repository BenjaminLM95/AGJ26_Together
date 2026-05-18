using UnityEngine;
using System.Collections;

public class GetTheHeart : TaskBase
{
    private bool openTask = false;

    private bool taskOpened = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GiveTaskName("Find your heart");
        GiveTaskDescription("Find the yellow heart. You will be complete!");
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

            if (currentState == PlayerState.FullBody && !taskOpened)
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

        return false;
    }

    private IEnumerator OpenTask()
    {
        yield return new WaitForSeconds(5f);

        openTask = true;
    }
}
