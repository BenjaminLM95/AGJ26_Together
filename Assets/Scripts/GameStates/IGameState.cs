using UnityEngine;

public interface IGameState
{
    public void Enter();

    public void UpdateState();

    public void FixedUpdateState();

    public void LateUpdateState();

    public void Exit();
}
