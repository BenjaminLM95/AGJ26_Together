using UnityEngine;

public class CheckPointLogic : MonoBehaviour
{
    [SerializeField] GameObject spawnPoint;

    [SerializeField] GameObject objOff;
    [SerializeField] GameObject objOn; 

    private void Start()
    {
        GetSpawnPointReference();
        SettingOff();
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
            Vector3 newSpawnPoint = new Vector3(transform.position.x, transform.position.y, 0); 
            spawnPoint.transform.position = newSpawnPoint;
            PlayerBody.Instance.SavePlayerState();            
            PlayerSpawnHandler.Instance.GetNewSpawnPoint(newSpawnPoint);
            SettingOn(); 
            
        }
    }

    private void SavePlayerState(PlayerBody playerBody)
    {
        playerBody.SavePlayerState();
        Debug.Log("Player State saved");
    public void SettingOff() 
    {
        objOff.SetActive(true);
        objOn.SetActive(false);
    }

    public void SettingOn() 
    {
        objOn.SetActive(true);
        objOff.SetActive(false); 
    }
        
}
