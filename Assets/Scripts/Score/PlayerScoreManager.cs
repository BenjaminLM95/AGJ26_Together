using UnityEngine;
using TMPro;

public class PlayerScoreManager : Singleton<PlayerScoreManager>
{
    [SerializeField] private int spiritScore;
    [SerializeField] private TextMeshProUGUI scoreText; 
    public override void Awake()
    {
        base.Awake();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spiritScore = 0;
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ObtainOneSpirit() 
    {
        spiritScore++;
        UpdateScoreText();
    }

    public int GetSpiritScore() 
    {
        return spiritScore;
    }

    public void RestartScore() 
    {
        spiritScore = 0;
        scoreText.text = spiritScore.ToString(); 
    }

    public void UpdateScoreText() 
    {
        scoreText.text = spiritScore.ToString();
    }
}
