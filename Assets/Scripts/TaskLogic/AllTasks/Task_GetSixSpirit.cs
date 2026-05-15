using UnityEngine;

public class Task_GetSixSpirit : TaskBase
{
    [SerializeField] private PlayerScoreManager playerScoreManager; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GiveTaskName("SixSpirit");
        GiveTaskDescription("Collect six blue wisp spirits");
        isUnassigned = true;
    }

    
    public override bool CheckConditions() 
    {        

        if (playerScoreManager == null) return false;        

        if (playerScoreManager.GetSpiritScore() >= 6)
        {
            return true;
        }
        else 
        { 
            return false; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScoreManager == null) 
        {
            playerScoreManager = FindFirstObjectByType<PlayerScoreManager>();
        }
    }
}
