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
        SFXManager.Instance.PlaySoundFXClip("PH_MouseClick");
        gameStateMachine.EnterGameplayState();
        screenManager.ActivateGameplayScreen();        
    }

    public void ToPause()
    {
        SFXManager.Instance.PlaySoundFXClip("PH_MouseClick"); 
        gameStateMachine.EnterPause();
        screenManager.ActivatePauseScreen();
    }

    public void ToSettings() 
    {
        SFXManager.Instance.PlaySoundFXClip("PH_MouseClick");
        gameStateMachine.EnterSettingState();
        screenManager.ActivateSettingScreen();
    }

    public void GoBack() 
    {
        if (gameStateMachine.GetPreviousState() == null) return;

        SFXManager.Instance.PlaySoundFXClip("PH_MouseClick");
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
