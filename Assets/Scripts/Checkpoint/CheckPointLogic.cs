using UnityEngine;

public class CheckPointLogic : MonoBehaviour
{
    [SerializeField] GameObject spawnPoint;

    private void Start()
    {
        GetSpawnPointReference(); 
    }

    private void GetSpawnPointReference() 
    {
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint"); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            if(spawnPoint == null) 
            {
                GetSpawnPointReference();
            }

            if (spawnPoint == null) return;

            spawnPoint.transform.position = transform.position;
            //PlayerBody.Instance.SavePlayerState();
            PlayerSpawnHandler.Instance.GetNewSpawnPoint(transform.position); 
            this.gameObject.SetActive(false); 

            SavePlayerState(other.GetComponent<PlayerBody>());
            
        }
    }

    private void SavePlayerState(PlayerBody playerBody)
    {
        playerBody.SavePlayerState();
        Debug.Log("Player State saved");
    }
        
}
