using UnityEngine;

public class GameStateMachine : Singleton<GameStateMachine>
{

    #region All Game States 

    public MainMenuState mainMenuState = new MainMenuState();
    public PauseState pauseState = new PauseState();
    public SettingState settingState = new SettingState();
    public GameplayState gameplayState = new GameplayState();
    //public LoseState loseState = new LoseState();
    //public WinState winState = new WinState();


    #endregion

    private IGameState currentGameState;
    private IGameState previousGameState;
    public string currentGameStateString; //{  get; private set; } 


    public override void Awake()
    {
        base.Awake();
    }
      

    public void EnterMainMenu()
    {
        ChangeGameState(mainMenuState);
    }

    public void EnterPause()
    {
        ChangeGameState(pauseState);
    }

    public void EnterGameplayState()
    {
        ChangeGameState(gameplayState);
    }

    public void EnterSettingState() 
    {
        ChangeGameState(settingState);
    }

    public void ChangeGameState(IGameState gameState)
    {


        if (currentGameState != null)
        {
            if (currentGameState == gameState) return;

            currentGameState.Exit();
            previousGameState = currentGameState;
        }

        currentGameState = gameState;
        currentGameStateString = currentGameState.ToString();
        currentGameState.Enter();

    }

}
