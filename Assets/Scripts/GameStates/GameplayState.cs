using UnityEngine;

public class GameplayState : IGameState
{
    public void Enter()
    {
        Debug.Log("Gameplay Enter"); 
    }

    public void Exit()
    {
        Debug.Log("Gameplay Exit"); 
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
