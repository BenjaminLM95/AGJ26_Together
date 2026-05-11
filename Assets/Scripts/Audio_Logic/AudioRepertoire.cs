using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioRepertoire : MonoBehaviour
{

    [SerializeField] private List<AudioClip> audioRepertoire = new List<AudioClip>(); 

    Dictionary<string, AudioClip> m_AudioRepertoire = new Dictionary<string, AudioClip>();

    private void Start()
    {
        m_AudioRepertoire.Clear();

        for(int i = 0; i < audioRepertoire.Count; i++) 
        {
            m_AudioRepertoire.Add(audioRepertoire[i].name, audioRepertoire[i]); 
        }
    }

    public AudioClip GetAudioClip(string name) 
    {
        if (m_AudioRepertoire == null) return null;

        if (!m_AudioRepertoire.ContainsKey(name)) return null; 

        return m_AudioRepertoire[name];
    }

}
