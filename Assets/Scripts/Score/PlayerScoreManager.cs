using UnityEngine;

public class PlayerScoreManager : Singleton<PlayerScoreManager>
{
    [SerializeField] private int spiritScore; 
    public override void Awake()
    {
        base.Awake();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spiritScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ObtainOneSpirit() 
    {
        spiritScore++; 
    }

    public int GetSpiritScore() 
    {
        return spiritScore;
    }

    public void RestarScore() 
    {
        spiritScore = 0;
    }
}
