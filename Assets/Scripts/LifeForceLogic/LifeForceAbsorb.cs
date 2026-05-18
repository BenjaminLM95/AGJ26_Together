using UnityEngine;

public class LifeForceAbsorb : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            LifeForceHandler.Instance.ObtainLifeForce(-100f); 
        }
    }
}
