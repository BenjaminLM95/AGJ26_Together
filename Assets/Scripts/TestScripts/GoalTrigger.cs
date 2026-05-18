using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public bool isInGoal; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isInGoal = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isInGoal)
            {
                isInGoal = true;
                
            }

            GameFlowManager.Instance.ToWinGame();
        }
    }
}
