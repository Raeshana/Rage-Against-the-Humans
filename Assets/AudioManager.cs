using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------Audio Source---------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------Audio Clip---------")]
    public AudioClip GameLoop;
    public AudioClip Hacking;
    public AudioClip Loading;
    public AudioClip MachineShutdown;
    public AudioClip TargetFound;
    public AudioClip Warning;

    [Header("--------Initialize Music Audio---------")]
    public AudioClip musicClip;

    public void Start() 
    {
        musicSource.clip = musicClip;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
