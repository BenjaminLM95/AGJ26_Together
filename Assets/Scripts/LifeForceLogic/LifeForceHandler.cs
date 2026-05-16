using UnityEngine;
using UnityEngine.UI;

public class LifeForceHandler : Singleton<LifeForceHandler>
{
    [SerializeField] private Slider lifeForceBar; 

    [SerializeField] private float lifeForce;
    [SerializeField] private float maxLifeForce;

    [SerializeField] private float lifeSpeed;

    public override void Awake()
    {
        base.Awake();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lifeForce = 100;
        lifeForceBar.value = lifeForce;
        maxLifeForce = lifeForceBar.maxValue; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(lifeForce > 0) 
        {
            lifeForce -= Time.fixedDeltaTime * lifeSpeed; 
        }

        if(lifeForce > maxLifeForce) 
        {
            lifeForce = maxLifeForce;
        }

        lifeForceBar.value = lifeForce;

        if(lifeForce < 0) 
        {
            lifeForce = 0;
            GameFlowManager.Instance.ToLoseGame(); 
        }
    }

    public void ObtainLifeForce(float energy) 
    {
        lifeForce += energy; 
        lifeForceBar.value = lifeForce;
    }

    public void ResetLifeForce() 
    {
        lifeForce = maxLifeForce; 
    }

}
