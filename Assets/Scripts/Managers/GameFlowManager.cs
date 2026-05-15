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
        levelManager.LoadGameplayLevel();
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

    public void ToSettings() 
    {
        gameStateMachine.EnterSettingState();
        screenManager.ActivateSettingScreen();
    }

    public void GoBack() 
    {
        if (gameStateMachine.GetPreviousState() == null) return; 

        ChangeGameFlow(gameStateMachine.GetPreviousState()); 
    }


    private void ChangeGameFlow(IGameState gameState) 
    {
        switch (gameState) 
        {
            case MainMenuState:
                ToMainMenu();
                break;
            case SettingState:
                ToSettings();
                break;
            case PauseState:
                ToPause();
                break;
            case GameplayState:
                ToGameplay();
                break;
            default:
                return; 

        }
    }


}
