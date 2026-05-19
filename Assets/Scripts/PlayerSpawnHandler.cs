using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawnHandler : Singleton<PlayerSpawnHandler>
{
    [SerializeField] Vector3 lastSpawnPoint;

    [SerializeField] GameObject _camara; 
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
    }
}
