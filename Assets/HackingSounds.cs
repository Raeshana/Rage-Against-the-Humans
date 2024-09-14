using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackingSounds : MonoBehaviour
{

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void CallSound()
    {
        audioManager.PlaySFX(audioManager.Hacking);
    }
}
