using UnityEngine;

public class PlayerInSceneHandler : MonoBehaviour
{
    [SerializeField] GameObject playerObj;

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
                playerObj.SetActive(true);
                secondCamera.SetActive(false);
            }
            else 
            {
                playerObj.SetActive(false);
                secondCamera.SetActive(true);
            }
        }

        
    }

    private void UpdateGameState() 
    {
        _currentState = GameStateMachine.Instance.GetCurrentState();
    }

}
