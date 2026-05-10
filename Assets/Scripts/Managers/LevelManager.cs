using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager> 
{
    public override void Awake()
    {
        base.Awake();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
}
