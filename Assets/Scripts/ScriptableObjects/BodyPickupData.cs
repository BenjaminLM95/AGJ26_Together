using UnityEngine;

[CreateAssetMenu(fileName = "Body Pickup Data", menuName = "ScriptableObjects/BodyPickup")]
public class BodyPickupData : ScriptableObject
{
    public Sprite bodySprite;
    public PlayerState stateToGive;
    public float colliderRange;
    public bool disableOnPickup;
}
