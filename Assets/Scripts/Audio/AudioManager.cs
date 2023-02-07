using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class AudioManager : MonoBehaviour
{
    public static AudioManager instantiate {get; private set;}
    public AudioSource musicSource, soundSource;


    private void Awake()
    {
        instantiate = this;
    }

    public void PlaySound(AudioClip sound)
    {
        soundSource.PlayOneShot(sound);
    }


}
