using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public bool isInGoal;

    [SerializeField] SpriteRenderer objSprite; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isInGoal = false;
        objSprite.enabled = true; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }   

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            if (!isInGoal) 
            {
                isInGoal = true;
                objSprite.enabled = false;

            }
        }
    }
}
