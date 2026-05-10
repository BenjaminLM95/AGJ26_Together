using UnityEngine;

public class PauseState : IGameState
{
    public void Enter()
    {
        Debug.Log("Pause Enter"); 
    }

    public void Exit()
    {
        Debug.Log("Pause Exit"); 
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
