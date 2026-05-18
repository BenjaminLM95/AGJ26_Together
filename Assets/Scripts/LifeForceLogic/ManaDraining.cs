using UnityEngine;

public class ManaDraining : MonoBehaviour
{
    [SerializeField] private float drainingLifeForce; 

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (LifeForceHandler.Instance.GetCurrentLifeSpeed() != drainingLifeForce)
            {
                LifeForceHandler.Instance.ChangingLifeSpeed(drainingLifeForce);
                LifeForceHandler.Instance.ChangingToDrainingBarColor(); 
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            LifeForceHandler.Instance.RestartLifeSpeed();
            LifeForceHandler.Instance.ReturnToNormalBarColor(); 
        }
    }
}
