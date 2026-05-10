using UnityEngine;
using UnityEngine.VFX;

public class GameFlowManager : Singleton<GameFlowManager>
{
    public GameStateMachine gameStateMachine;
    public UIManager screenManager;
    public LevelManager levelManager;

    public override void Awake()
    {
        base.Awake();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ToMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToMainMenu()
    {
        gameStateMachine.EnterMainMenu();
        screenManager.ActivateMainMenuScreen();
    }

    public void ToStartGame()
    {
        levelManager.LoadFirstLevel();
        ToGameplay();
    }

    public void ToGameplay()
    {
        gameStateMachine.EnterGameplayState();
        screenManager.ActivateGameplayScreen();        
    }

    public void ToPause()
    {
        gameStateMachine.EnterPause();
        screenManager.ActivatePauseScreen();
    }

}
