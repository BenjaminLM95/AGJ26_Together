using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VolumesSlides : Singleton<VolumesSlides>
{
    public Slider musicSlider;
    public Slider soundSlider;

    public float musicVolume;
    public float soundVolume;
      

    private bool changeSFXVolume = false;

    public override void Awake()
    {
        base.Awake();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicSlider.value = 0.75f;
        soundSlider.value = 0.5f;
        musicVolume = musicSlider.value;
        soundVolume = soundSlider.value;
        AudioManager.Instance.SetVolume(musicVolume); 
        SFXManager.Instance.SetVolume(soundVolume);       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (musicVolume != musicSlider.value)
        {
            musicVolume = musicSlider.value;
            AudioManager.Instance.SetVolume(musicVolume);             
        }

        if (soundVolume != soundSlider.value)
        {
            soundVolume = soundSlider.value;
            SFXManager.Instance.SetVolume(soundVolume); 

        }

    }

    public void TestSoundEffect() 
    {
        SFXManager.Instance.PlaySoundFXClip("PH_TaskCompleted");
    }
   
}
