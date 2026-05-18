using UnityEngine;

public class MainMenuState : IGameState
{
    public void Enter()
    {
        Debug.Log("Main Menu Enter");

        if (!(GameStateMachine.Instance.previousGameStateString == "SettingState"))
        {
            AudioManager.Instance.PlayMusic("MainMenu_Music");
        }
    }

    public void Exit()
    {
        Debug.Log("Main Menu Exit"); 
    }

    public void FixedUpdateState()
    {
        throw new System.NotImplementedException();
    }

    public void LateUpdateState()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateState()
    {
        throw new System.NotImplementedException();
    }
}
