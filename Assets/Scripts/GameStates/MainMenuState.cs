using UnityEngine;

public class MainMenuState : IGameState
{
    public void Enter()
    {
        Debug.Log("Main Menu Enter");

        AudioManager.Instance.PlayMusic("PH_MainMenu");
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
