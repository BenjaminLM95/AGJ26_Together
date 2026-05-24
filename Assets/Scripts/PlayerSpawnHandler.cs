using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawnHandler : Singleton<PlayerSpawnHandler>
{
    [SerializeField] Vector3 lastSpawnPoint;

    [SerializeField] Vector3 startingSpawnPoint; 

    [SerializeField] GameObject _camara;

    [SerializeField] PlayerBody playerBody; 
    public override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        lastSpawnPoint = startingSpawnPoint; 
    }

    private void Update()
    {
        if (!(GameStateMachine.Instance.currentGameStateString == "GameplayState"))
        {
            if(_camara != null) 
            {
                _camara.SetActive(false);
            }
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (lastSpawnPoint == null)
        {
            Debug.Log("Spawnpoint not found"); 
            GameObject spawnPoint = GameObject.FindWithTag("SpawnPoint");
            transform.position = spawnPoint.transform.position;
        }


        if (lastSpawnPoint != null)
        {
            transform.position = lastSpawnPoint;            
        }

        DisablePartOfBodyOnMap();
    }

    public void MoveToSpawnPoint() 
    {
        if (lastSpawnPoint != null)
        {
            transform.position = lastSpawnPoint;
        }
    }

    public void GetNewSpawnPoint(Vector3 newSpawnPoint) 
    {
        lastSpawnPoint = newSpawnPoint;
    }

    public void UnparentObject() 
    {
        transform.parent = null;
        DontDestroyOnLoad(this.gameObject);
    }


    public void RestartAllValues() 
    {
        lastSpawnPoint = startingSpawnPoint;
        playerBody.RestartState();
        
    }

    public void DisablePartOfBodyOnMap() 
    {
        BodypartsHandler bodypartHandler = FindFirstObjectByType<BodypartsHandler>();
        Debug.Log("Trying to find the body part handler");

        if(bodypartHandler != null)
        {
            bodypartHandler.DisableParts(playerBody.GetCurrentState());
            Debug.Log("Body Part: " + playerBody.GetCurrentState()); 
        }

    }

}
