using UnityEngine;

[RequireComponent (typeof(SphereCollider),typeof(SpriteRenderer))]
public class BodyPickup : MonoBehaviour
{
    [SerializeField] private BodyPickupData bodyPickupData;
    private PlayerState stateToGive;
    private bool disableOnPickup;

    //These don't need to be [SerializeField] i just wanted to test on validate 
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] SphereCollider sphereCollider;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        sphereCollider = GetComponent<SphereCollider>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetData();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SwitchPlayerState(other.GetComponent<PlayerBody>());
            if (disableOnPickup) gameObject.SetActive(false);
        }
    }

    private void SwitchPlayerState(PlayerBody body)
    {
        if (body == null) return;
        Debug.Log("State has changed");
        body.SwitchState(stateToGive);
    }

    private void SetData()
    {
        if (bodyPickupData == null) return;

        if (sphereCollider != null)
        {
            sphereCollider.radius = bodyPickupData.colliderRange;
            sphereCollider.isTrigger = true;
        }
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = bodyPickupData.bodySprite;
        }

        stateToGive = bodyPickupData.stateToGive;
        disableOnPickup = bodyPickupData.disableOnPickup;
    }

    private void OnValidate()
    {
        SetData();
    }
}
