using UnityEngine;

public class PlayerInSceneHandler : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab; 

    [SerializeField] GameObject playerObj = null;

    private IGameState _currentState;

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

            if(_currentState is GameplayState) 
            {
                if(playerObj == null) 
                {
                    Instantiate(playerPrefab, new Vector3(-9, 10, 0), Quaternion.identity);
                }
                else 
                {
                    playerObj.SetActive(true);

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
