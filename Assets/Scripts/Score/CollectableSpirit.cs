using UnityEngine;

public class CollectableSpirit : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            PlayerScoreManager.Instance.ObtainOneSpirit();
            SFXManager.Instance.PlaySoundFXClip("PH_WispWhoosh");
            this.gameObject.SetActive(false);
        }
    }
}
