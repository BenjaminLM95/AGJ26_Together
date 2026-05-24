using UnityEngine;

public class CreditState : IGameState
{
    public void Enter()
    {
        Time.timeScale = 0; 
        Debug.Log("Showing the credits! Yipee!");
    }

    public void Exit()
    {
        Debug.Log("Back to the game"); 
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
