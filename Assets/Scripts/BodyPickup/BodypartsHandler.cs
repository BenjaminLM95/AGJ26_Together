using UnityEngine;
using System.Collections.Generic;

public class BodypartsHandler : MonoBehaviour
{
    [SerializeField] private BodyPickup b_jumpingLeg;
    [SerializeField] private BodyPickup b_crystalLeg;
    [SerializeField] private BodyPickup b_streckyArm;
    [SerializeField] private BodyPickup b_secondArm; 

    
    private void DisableAllParts() 
    {
        b_jumpingLeg.gameObject.SetActive(false);
        b_crystalLeg.gameObject.SetActive(false);
        b_streckyArm.gameObject.SetActive(false);
        b_secondArm.gameObject.SetActive(false);    
    }

    public void DisableParts(PlayerState playerState) 
    {
        DisableAllParts();

        switch (playerState) 
        {
            case PlayerState.Head:
                b_jumpingLeg.gameObject.SetActive(true);
                b_crystalLeg.gameObject.SetActive(true);
                b_streckyArm.gameObject.SetActive(true);
                b_secondArm.gameObject.SetActive(true);
                Debug.Log("Player is in head state");
                break;
            case PlayerState.JumpLeg:
                b_crystalLeg.gameObject.SetActive(true);
                b_streckyArm.gameObject.SetActive(true);
                b_secondArm.gameObject.SetActive(true);
                Debug.Log("Player is in jumping leg state");
                break;
            case PlayerState.CrystalLeg:
                b_streckyArm.gameObject.SetActive(true);
                b_secondArm.gameObject.SetActive(true);
                Debug.Log("Player is in crystal leg state");
                break;
            case PlayerState.StretchyArm:
                b_secondArm.gameObject.SetActive(true);
                Debug.Log("Player is in strechy arm state"); 
                break;
        }
    }

}
