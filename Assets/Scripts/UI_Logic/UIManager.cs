using UnityEngine;

public class UIManager : Singleton<UIManager>
{

    #region All UI Screen 

    public GameObject mainMenuScreen;
    public GameObject gameplayScreen;
    public GameObject pauseScreen;
    public GameObject settingScreen; 
    public GameObject winScreen;
    public GameObject loseScreen;

    #endregion

    public override void Awake()
    {
        base.Awake();
    }

    public void ActivateMainMenuScreen()
    {
        ActivateScreen(mainMenuScreen);
    }

    public void ActivateGameplayScreen()
    {
        ActivateScreen(gameplayScreen);
    }

    public void ActivatePauseScreen()
    {
        ActivateScreen(pauseScreen);
    }

    public void ActivateSettingScreen() 
    {
        ActivateScreen(settingScreen);
    }

    public void ActivateGameWinScreen() 
    {
        ActivateScreen(winScreen);
    }

    public void ActivateGameLoseScreen() 
    {
        ActivateScreen(loseScreen);
    }

    private void ActivateScreen(GameObject screen)
    {
        if (screen == null) return;

        DisactivateAllUI();
        screen.SetActive(true);
    }


    private void DisactivateAllUI()
    {
        mainMenuScreen.SetActive(false);
        settingScreen.SetActive(false);
        pauseScreen.SetActive(false);
        gameplayScreen.SetActive(false);
    }

}
