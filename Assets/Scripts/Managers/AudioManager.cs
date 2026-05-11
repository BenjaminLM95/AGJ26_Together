using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioSource audioSource;
    public AudioMixer audioMixer; // Reference to the AudioMixer for volume control
    public AudioRepertoire BackgroundMusicRepertoire;

    public override void Awake()
    {
        base.Awake();
    }

    
    public void PlayMusic(string audioName) 
    {
        if (BackgroundMusicRepertoire.GetAudioClip(audioName) == null) return;

        audioSource.clip = BackgroundMusicRepertoire.GetAudioClip(audioName);
        audioSource.Play();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

}
