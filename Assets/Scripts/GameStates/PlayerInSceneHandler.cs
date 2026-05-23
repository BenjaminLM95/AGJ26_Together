using UnityEngine;

public class PlayerInSceneHandler : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab; 

    [SerializeField] GameObject playerObj;

    [SerializeField] private IGameState _currentState;

    [SerializeField] GameObject secondCamera; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateGameState(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(_currentState != GameStateMachine.Instance.GetCurrentState()) 
        {
            UpdateGameState(); 

            if(GameStateMachine.Instance.currentGameStateString == "GameplayState") 
            {
                if(playerObj == null) 
                {
                    playerObj = Instantiate(playerPrefab, new Vector3(-9, 10, 0), Quaternion.identity);

                    if (GameStateMachine.Instance.previousGameStateString == "MainMenuState")
                    {
                        PlayerSpawnHandler.Instance.RestartAllValues();
                        Debug.Log("Restart values on instantiated player");
                    }
                }
                else 
                {
                    playerObj.SetActive(true);

                    if (GameStateMachine.Instance.previousGameStateString == "MainMenuState") 
                    {
                        PlayerSpawnHandler.Instance.RestartAllValues();
                        Debug.Log("Restart values on existing player"); 
                    }

                }
                    
                secondCamera.SetActive(false);
            }
            else 
            {
                if (playerObj != null)
                {
                    playerObj.SetActive(false);
                }

                secondCamera.SetActive(true);
            }

            
        }

        
    }

    private void UpdateGameState() 
    {
        _currentState = GameStateMachine.Instance.GetCurrentState();
    }

}
