using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LifeForceHandler : Singleton<LifeForceHandler>
{
    [SerializeField] private Slider lifeForceBar; 

    [SerializeField] private float lifeForce;
    [SerializeField] private float maxLifeForce;

    [SerializeField] private float lifeSpeed;

    private float currentLifeSpeed; 

    [SerializeField] private Image fillImage;

    [SerializeField] private float perilValue;     

    [SerializeField] private float perilSpeed;

    [SerializeField] private Color perilColor;

    [SerializeField] private Color drainingColor; 

    [SerializeField] private float colorSpeed;

    [SerializeField] private GameObject lifeForceBarObj;

    private float scaleValue;

    private Color barColor;

    private bool isUpdatingBar = false; 

    public override void Awake()
    {
        base.Awake();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {      
        maxLifeForce = lifeForceBar.maxValue;
        lifeForce = maxLifeForce; 
        lifeForceBar.value = lifeForce;
        scaleValue = transform.localScale.x;
        barColor = fillImage.color;
        currentLifeSpeed = lifeSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(lifeForce > 0) 
        {
            lifeForce -= Time.fixedDeltaTime * currentLifeSpeed; 
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

        if(lifeForce <= 0) 
        {
            fillImage.gameObject.SetActive(false);
        }
        else 
        {
            fillImage.gameObject.SetActive(true);
        }

        if (!isUpdatingBar)
        {
            if (lifeForce < perilValue)
            {
                EmergencyFeedback();
                fillImage.color = Color.Lerp(fillImage.color, perilColor, colorSpeed * Time.deltaTime);
            }
            else
            {
                transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
                fillImage.color = barColor;
            }
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

    private void EmergencyFeedback() 
    {
        float augm = (Mathf.Cos(Time.time * perilSpeed)/5f) + scaleValue;

        transform.localScale = new Vector3(augm, augm, transform.localScale.z); 
       
    }

    public void GetWispFeedback() 
    {
        isUpdatingBar = true; 
        lifeForceBarObj.transform.localScale = new Vector3(1, 1, 1) * (1f/3f); 
        fillImage.color = new Color(135f/255f, 206f/255f, 235f/255f);
        StartCoroutine(ReturnBaseColor(0.75f)); 
    }

    private IEnumerator ReturnBaseColor(float time) 
    {
        yield return new WaitForSecondsRealtime(time);
        fillImage.color = barColor;
        lifeForceBarObj.transform.localScale = new Vector3(1, 1, 1) * (1f/3f);
        isUpdatingBar = false; 
    } 

    public void ChangingLifeSpeed(float newLifeSpeed) 
    {
        currentLifeSpeed = newLifeSpeed;
    }

    public void RestartLifeSpeed() 
    {
        currentLifeSpeed = lifeSpeed; 
    }

    public float GetCurrentLifeSpeed() 
    {
        return currentLifeSpeed;
    }

    public void ChangingToDrainingBarColor() 
    {
        fillImage.color = drainingColor;
        isUpdatingBar = true;
    }

    public void ReturnToNormalBarColor() 
    {
        fillImage.color = barColor;
        isUpdatingBar = false; 
    }

}
