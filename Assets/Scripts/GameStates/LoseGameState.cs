using UnityEngine;

public class LoseGameState : IGameState
{
    public void Enter()
    {
        Debug.Log("You lost");
        Time.timeScale = 0f; 
    }

    public void Exit()
    {
        Debug.Log("Try again, eh?"); 
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
