using UnityEngine;

public class CollectableSpirit : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            PlayerScoreManager.Instance.ObtainOneSpirit();
            this.gameObject.SetActive(false);
        }
    }
}
