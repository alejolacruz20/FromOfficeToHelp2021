using UnityEngine.Audio;
using System;
using UnityEngine;

//Creador: Lucas Olivares
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.Volume; //Control sobre el volumen
            s.source.pitch = s.Pitch;   //Control sobre el Pitch
            s.source.loop = s.Loop;     //Control sobre el loop
        }
    }

    void Start()
    {
        Play("Ambiente");
        Play("MusicLVL1");
    }

    public void Play (string name)
    {
       Sound SFX = Array.Find(sounds, Sound => Sound.name == name);
        SFX.source.Play();
    }
}
