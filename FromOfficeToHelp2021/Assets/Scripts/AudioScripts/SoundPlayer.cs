using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource audioSound;

    private void OnTriggerEnter(Collider target)
    {
        audioSound.Play();
    }

    private void OnTriggerExit(Collider target)
    {
        audioSound.Stop();
    }
}
