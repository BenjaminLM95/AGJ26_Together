using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawnHandler : Singleton<PlayerSpawnHandler>
{
    [SerializeField] Vector3 lastSpawnPoint; 

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

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (lastSpawnPoint == null)
        {
            GameObject spawnPoint = GameObject.FindWithTag("SpawnPoint");
        }


        if (lastSpawnPoint != null)
        {
            transform.position = lastSpawnPoint;            
        }
    }

    public void GetNewSpawnPoint(Vector3 newSpawnPoint) 
    {
        lastSpawnPoint = newSpawnPoint;
    }
}
