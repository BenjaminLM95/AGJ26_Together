using UnityEngine;
using System.Collections;

public class GetTheHeart : TaskBase
{
    private bool openTask = false;

    private bool taskOpened = false;

    [SerializeField] private GoalTrigger _goalTrigger; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GiveTaskName("Find your heart");
        GiveTaskDescription("Find the yellow heart. You will be complete!");
        isUnassigned = true;
        SearchForGoalTrigger(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(GameStateMachine.Instance.currentGameStateString == "GameplayState" && _goalTrigger == null) 
        {
            SearchForGoalTrigger(); 
        }
    }

    public override bool CheckForRequirements()
    {
        if (GameStateMachine.Instance.currentGameStateString == "GameplayState")
        {

            if (currentState == PlayerState.FullBody && !taskOpened)
            {
                taskOpened = true;
                StartCoroutine(OpenTask());
                SearchForGoalTrigger(); 
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
        if (_goalTrigger == null) return false;

        if (_goalTrigger.isInGoal) 
        {
            SFXManager.Instance.PlaySoundFXClip("PH_WinSound"); 
            StartCoroutine(WinTheGame()); 
            return true; 
        }

        return false;
    }

    private IEnumerator OpenTask()
    {
        yield return new WaitForSeconds(5f);

        openTask = true;
    }

    private void SearchForGoalTrigger() 
    {
        if (_goalTrigger == null)
        {
            _goalTrigger = FindFirstObjectByType<GoalTrigger>();
        }
    }

    public override void ResetTaskStatus()
    {
        openTask = false;
        taskOpened = false;
    }

    private IEnumerator WinTheGame() 
    {
        yield return new WaitForSeconds(2.5f); 
        GameFlowManager.Instance.ToWinGame();
    }
}
