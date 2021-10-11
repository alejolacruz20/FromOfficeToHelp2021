using UnityEngine.Audio;
using UnityEngine;

//Creador: Lucas Olivares

[System.Serializable]

public class Sound 
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float Volume;
    [Range(1f, 3f)]
    public float Pitch;

    public bool Loop;

    [HideInInspector]
    public AudioSource source;
}
