using UnityEngine;

public class LoseGameState : IGameState
{
    public void Enter()
    {
        Debug.Log("You lost");
        Time.timeScale = 0f;
        PlayerSpawnHandler.Instance.UnparentObject(); 
    }

    public void Exit()
    {
        LifeForceHandler.Instance.ResetLifeForce();
        //PlayerBody.Instance.RestartState();
        PlayerScoreManager.Instance.RestartScore();
        //MovementController.Instance.ResetJumpCooldown(); 
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
