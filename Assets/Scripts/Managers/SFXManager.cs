using UnityEngine;
using UnityEngine.Audio;

public class SFXManager : Singleton<SFXManager>
{
    [SerializeField] private AudioSource soundFXObject;
    [SerializeField] private AudioSource audioSource;

    public AudioMixer audioMixer; // Reference to the AudioMixer for volume control

    public float sfxVolume = 1;

    public AudioRepertoire sfxRepertoire;

    public override void Awake()
    {
        base.Awake();
    }

    public void PlaySoundFXClip(string sfxName)
    {
        AudioClip audioClip = sfxRepertoire.GetAudioClip(sfxName);

        // Spawn the gameObject, in this case is child of this manager
        AudioSource audioSource = Instantiate(soundFXObject, Vector3.zero, Quaternion.identity, this.transform);

        // assign the audioClip
        audioSource.clip = audioClip;

        // Assign Volume
        audioSource.volume = sfxVolume;

        // play Sound
        audioSource.Play();

        // get length of sound FX clip
        float clipLength = audioSource.clip.length;

        //destroy the clip after it is done playing
        Destroy(audioSource.gameObject, clipLength);

    }
}
