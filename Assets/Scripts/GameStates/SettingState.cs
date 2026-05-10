using UnityEngine;

public class SettingState : IGameState
{
    public void Enter()
    {
        Debug.Log("Setting Enter"); 
    }

    public void Exit()
    {
        Debug.Log("Setting Exit"); 
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
