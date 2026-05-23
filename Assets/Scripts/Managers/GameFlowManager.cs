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
        MainMenuStart(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToMainMenu()
    {
       
        gameStateMachine.EnterMainMenu();
        screenManager.ActivateMainMenuScreen();
        levelManager.LoadMainMenu(); 
    }

    private void MainMenuStart() 
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
        SFXManager.Instance.PlaySoundFXClip("PH_MouseClick", 0.5f);
        gameStateMachine.EnterGameplayState();        
        screenManager.ActivateGameplayScreen();        
    }

    public void RestartGame() 
    {
        PlayerSpawnHandler.Instance.MoveToSpawnPoint(); 
        gameStateMachine.EnterGameplayState();
        screenManager.ActivateGameplayScreen();
        levelManager.LoadCurrentScene(); 
    }

    public void ToPause()
    {
        SFXManager.Instance.PlaySoundFXClip("PH_MouseClick", 0.5f); 
        gameStateMachine.EnterPause();
        screenManager.ActivatePauseScreen();
    }

    public void ToSettings() 
    {
        SFXManager.Instance.PlaySoundFXClip("PH_MouseClick", 0.5f);
        gameStateMachine.EnterSettingState();
        screenManager.ActivateSettingScreen();
    }

    public void ToWinGame() 
    {
        gameStateMachine.EnterWinGameState();
        screenManager.ActivateGameWinScreen();
    }

    public void ToLoseGame() 
    {
        gameStateMachine.EnterLoseGameState();
        screenManager.ActivateGameLoseScreen(); 
    }

    public void GoBack() 
    {
        if (gameStateMachine.GetPreviousState() == null) return;

        SFXManager.Instance.PlaySoundFXClip("PH_MouseClick", 0.5f);
        ChangeGameFlow(gameStateMachine.GetPreviousState()); 
    }

    public void QuitGame() 
    {
        Application.Quit();
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
