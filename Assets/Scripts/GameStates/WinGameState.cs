using UnityEngine;

public class WinGameState : IGameState
{
    public void Enter()
    {
        Time.timeScale = 0f;
        Debug.Log("You won"); 
    }

    public void Exit()
    {
        Debug.Log("You win");
        LifeForceHandler.Instance.ResetLifeForce();
        PlayerSpawnHandler.Instance.RestartAllValues();
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
