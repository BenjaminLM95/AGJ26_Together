using UnityEngine;

public class CollectableSpirit : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            PlayerScoreManager.Instance.ObtainOneSpirit();
            SFXManager.Instance.PlaySoundFXClip("PH_WispWhoosh");
            LifeForceHandler.Instance.ObtainLifeForce(20f);
            LifeForceHandler.Instance.GetWispFeedback(); 
            this.gameObject.SetActive(false);
        }
    }
}
